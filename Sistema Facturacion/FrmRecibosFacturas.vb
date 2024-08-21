Public Class FrmRecibosFacturas
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoClientes As String
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.TxtImporteAplicado.Text = ""
        Me.TxtImporteRecibido.Text = ""
        Me.TxtPorAplicar.Text = ""
        ActualizaMETODORecibos()
        Me.Close()
    End Sub
    Public Sub ConsultaCreditos(ByVal CodigoCliente As String, ByVal FechaCorte As Date, ByVal Moneda As String)

        Dim SQlString As String, NumeroFactura As String, NumeroRecibo As String = "", MontoRecibo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, TasaCambio As Double, Saldo As Double
        Dim MontoFactura As Double, FechaFactura As Date, MontoMora As Double, TipoNota As String
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double, TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, FechaVence As Date, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0



        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        DataSet.Reset()
        SQlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.MetodoPago As Numero_Recibo, Facturas.Numero_Factura As NotaDebito, Facturas.SubTotal As MontoNota, Facturas.SubTotal As Monto, Facturas.Fecha_Factura As FechaVence, Facturas.IVA As Abono, Facturas.SubTotal AS Saldo, Facturas.SubTotal As Moratorio, Facturas.SubTotal As Dias, Facturas.SubTotal AS Total  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                    "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "TotalVentas")

        My.Application.DoEvents()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT *  FROM Facturas WHERE (MetodoPago = 'Credito') AND (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & CodigoCliente & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        Registros = DataSet.Tables("Clientes").Rows.Count
        i = 0
        TotalFactura = 0
        TotalAbonos = 0
        TotalMora = 0
        TotalCargos = 0
        TotalMontoNotaDB = 0
        TotalMontoNotaCR = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = DataSet.Tables("Clientes").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            NumeroRecibo = ""
            MontoRecibo = 0

            My.Application.DoEvents()

            If Moneda = "Cordobas" Then
                If DataSet.Tables("Clientes").Rows(i)("MonedaFactura") = "Cordobas" Then
                    TasaCambio = 1
                Else
                    TasaCambio = BuscaTasaCambio(DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"))
                End If
            Else
                If DataSet.Tables("Clientes").Rows(i)("MonedaFactura") = "Dolares" Then
                    TasaCambio = 1
                Else
                    TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"))
                End If
            End If

            NumeroFactura = DataSet.Tables("Clientes").Rows(i)("Numero_Factura")

            If NumeroFactura = "J11203" Then
                NumeroFactura = "J11203"
            End If

            FechaFactura = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")) Then
                FechaVence = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            Else
                FechaVence = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            End If
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo " & _
            '            "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, SUM(CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / ISNULL(TasaCambio.MontoTasa, 1) END) AS MontoDolar, SUM(CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * ISNULL(TasaCambio.MontoTasa, 1) END) AS MontoCordobas, MAX(Recibo.MonedaRecibo) AS MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON DetalleRecibo.Fecha_Recibo = TasaCambio.FechaTasa  GROUP BY DetalleRecibo.Numero_Factura  " & _
                        "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            Registros2 = DataSet.Tables("Recibos").Rows.Count
            j = 0

            Do While Registros2 > j

                If Moneda = "Cordobas" Then
                    'If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                    '    TasaCambioRecibo = 1
                    'Else
                    '    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    'End If

                    MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoCordobas")
                Else
                    'If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                    '    TasaCambioRecibo = 1
                    'Else
                    '    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    'End If

                    MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoDolar")
                End If
                If NumeroRecibo = "" Then
                    NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                Else
                    NumeroRecibo = NumeroRecibo & "," & DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                End If

                'MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

                j = j + 1
            Loop

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            'SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & "', 102)) AND (NotaDebito.Tipo LIKE '%Debito Clientes%') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') "

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaDB")
            Registros2 = DataSet.Tables("NotaDB").Rows.Count
            NumeroNota = ""
            j = 0
            MontoNota = 0
            TotalMontoNotaDB = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaDB").Rows(j)("Tipo")

                If Moneda = "Cordobas" Then
                    If TipoNota <> "Debito Clientes Dif $" Then
                        If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                            TasaCambioRecibo = 1
                        Else

                            TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                            If TasaCambioRecibo <> 0 Then
                                TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                            Else
                                MsgBox("No Existe Tasa de cambios!!! Fecha NB " & DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                            End If

                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                Else
                    If TipoNota <> "Debito Clientes Dif C$" Then
                        If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                            TasaCambioRecibo = 1
                        Else
                            TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                End If


                If NumeroNota = "" Then
                    NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                Else
                    NumeroNota = NumeroNota & "," & DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                End If

                MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

                'If Moneda = "Cordobas" Then
                '    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                '        TasaCambioRecibo = 1
                '    Else
                '        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                '    End If
                'Else
                '    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                '        TasaCambioRecibo = 1
                '    Else
                '        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                '    End If
                'End If
                'If NumeroNota = "" Then
                '    NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                'Else
                '    NumeroNota = NumeroNota & "," & DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                'End If
                'MontoNota = MontoNota + DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
                'TotalMontoNotaDB = TotalMontoNotaDB + MontoNota
                j = j + 1
            Loop
            DataSet.Tables("NotaDB").Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaCR")
            Registros2 = DataSet.Tables("NotaCR").Rows.Count
            NumeroNotaCR = ""
            j = 0
            MontoNotaCR = 0
            TotalMontoNotaCR = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")

                If Moneda = "Cordobas" Then
                    If TipoNota <> "Credito Clientes Dif $" Then
                        If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                            TasaCambioRecibo = 1
                        Else
                            TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                Else
                    If TipoNota <> "Credito Clientes Dif C$" Then
                        If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                            TasaCambioRecibo = 1
                        Else


                            TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                            If TasaCambioRecibo <> 0 Then
                                TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                            Else
                                MsgBox("No Existe Tasa de cambios!!! Fecha NC " & DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                            End If


                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                End If


                If NumeroNotaCR = "" Then
                    NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                Else
                    NumeroNotaCR = NumeroNotaCR & "," & DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                End If
                MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR


                'If Moneda = "Cordobas" Then
                '    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                '        TasaCambioRecibo = 1
                '    Else
                '        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                '    End If
                'Else
                '    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                '        TasaCambioRecibo = 1
                '    Else
                '        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                '    End If
                'End If
                'If NumeroNotaCR = "" Then
                '    NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                'Else
                '    NumeroNotaCR = NumeroNotaCR & "," & DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                'End If
                'MontoNotaCR = MontoNotaCR + DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                'TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL INTERES MORATORIO PARA ESTE CLIENTE //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  * FROM Clientes WHERE (Cod_Cliente = '" & CodigoCliente & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DatosCliente")
            'If Not DataSet.Tables("DatosCliente").Rows.Count = 0 Then
            '    If Not IsDBNull(DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio")) Then
            '        TasaInteres = (DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio") / 100)
            '    End If
            'End If

            MontoFactura = Format((DataSet.Tables("Clientes").Rows(i)("SubTotal") + DataSet.Tables("Clientes").Rows(i)("IVA")) * TasaCambio, "####0.00")
            'Dias = DateDiff(DateInterval.Day, FechaVence, FechaCorte)
            Saldo = MontoFactura - MontoRecibo + TotalMontoNotaDB - TotalMontoNotaCR
            'If Format(Saldo, "##,##0.00") = "0.00" Then
            '    Dias = 0
            'End If
            'MontoMora = Dias * Saldo * TasaInteres
            'Total = Saldo + MontoMora

            'oDataRow = DataSet.Tables("TotalVentas").NewRow
            'oDataRow("Fecha_Factura") = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            'oDataRow("Numero_Factura") = DataSet.Tables("Clientes").Rows(i)("Numero_Factura")
            'oDataRow("Numero_Recibo") = NumeroRecibo
            'If NumeroNota = "" Then
            '    If NumeroNotaCR <> "" Then
            '        oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
            '    End If
            'ElseIf NumeroNotaCR = "" Then
            '    If NumeroNota <> "" Then
            '        oDataRow("NotaDebito") = "NB:" & NumeroNota
            '    End If
            'Else
            '    oDataRow("NotaDebito") = "NC:" & NumeroNotaCR & " NB:" & NumeroNota
            'End If
            'oDataRow("Monto") = Format(MontoFactura, "##,##0.00")
            'oDataRow("FechaVence") = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            'oDataRow("Abono") = Format(MontoRecibo, "##,##0.00")
            'oDataRow("MontoNota") = Format(MontoNota - MontoNotaCR, "##,##0.00")
            'oDataRow("Saldo") = Format(Saldo, "##,##0.00")
            'oDataRow("Moratorio") = Format(MontoMora, "##,##0.00")
            'oDataRow("Dias") = Dias
            'oDataRow("Total") = Format(Total, "##,##0.00")
            'DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

            ActualizaMontoCredito(DataSet.Tables("Clientes").Rows(i)("Numero_Factura"), DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"), Saldo, Moneda)

            My.Application.DoEvents()
            i = i + 1
            Me.ProgressBar.Value = i

            TotalFactura = TotalFactura + Saldo
            TotalAbonos = TotalAbonos + MontoRecibo
            TotalCargos = TotalCargos + MontoFactura
            TotalMora = TotalMora + MontoMora
            'DataSet.Tables("DatosCliente").Reset()
            DataSet.Tables("Recibos").Reset()
        Loop




    End Sub


    Private Sub FrmRecibosFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String = "", DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroFactura As String, FechaFactura As Date, iPosicion As Double = 0, Registros As Double = 0, TasaCambio As Double = 0
        Dim oDataRow As DataRow, MontoCredito As Double, Saldo As Double, MonedaFactura As String, MonedaRecibo As String
        Dim NumeroNota As String = ""


        Me.TrueDBGridComponentes.Enabled = True


        MiConexion.Close()


        ConsultaCreditos(CodigoClientes, Now, My.Forms.FrmRecibos.TxtMonedaFactura.Text)

        SqlString = "SELECT DISTINCT  Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito, DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado AS MontoPagado, Facturas.MontoCredito AS Saldo, Facturas.MonedaFactura, Detalle_Facturas.TasaCambio FROM   Facturas INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " & _
                    "WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '" & CodigoClientes & "') AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Facturas.Fecha_Factura"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consultas")


        SqlString = "SELECT DISTINCT  Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito, DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado AS MontoPagado, Facturas.MontoCredito AS Saldo, Facturas.Tipo_Factura FROM   Facturas INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " & _
                    "WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '-1') AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Facturas.Fecha_Factura"

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "FacturaRecibos")
        MiConexion.Close()

        iPosicion = 0
        Registros = DataSet.Tables("Consultas").Rows.Count

        My.Forms.FrmRecibos.ProgressBar1.Minimum = 0
        My.Forms.FrmRecibos.ProgressBar1.Maximum = Registros
        My.Forms.FrmRecibos.ProgressBar1.Value = 0

        Do While Registros > iPosicion
            My.Application.DoEvents()

            NumeroFactura = DataSet.Tables("Consultas").Rows(iPosicion)("Numero_Factura")
            FechaFactura = DataSet.Tables("Consultas").Rows(iPosicion)("Fecha_Factura")
            TasaCambio = BuscaTasaCambio(FechaFactura)
            MontoCredito = DataSet.Tables("Consultas").Rows(iPosicion)("MontoCredito")
            Saldo = DataSet.Tables("Consultas").Rows(iPosicion)("Saldo")
            MonedaFactura = DataSet.Tables("Consultas").Rows(iPosicion)("MonedaFactura")

            If CDbl(Format(Saldo, "0.00")) > 0 Then

                If My.Forms.FrmRecibos.TxtMonedaFactura.Text = "Cordobas" Then
                    If MonedaFactura = "Cordobas" Then
                        oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                        oDataRow("Numero_Factura") = NumeroFactura
                        oDataRow("Fecha_Factura") = FechaFactura
                        oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
                        oDataRow("MontoPagado") = 0
                        oDataRow("Saldo") = Format(Saldo, "##,##0.00")
                        oDataRow("Tipo_Factura") = "Factura"
                        DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                    Else
                        '//////////////MONTOS EN DOLARES /////////////////////////
                        oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                        oDataRow("Numero_Factura") = NumeroFactura
                        oDataRow("Fecha_Factura") = FechaFactura
                        oDataRow("MontoCredito") = Format(MontoCredito * TasaCambio, "##,##0.00")
                        oDataRow("MontoPagado") = 0
                        oDataRow("Saldo") = Format(Saldo * TasaCambio, "##,##0.00")
                        oDataRow("Tipo_Factura") = "Factura"
                        DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                    End If
                Else
                    If MonedaFactura = "Cordobas" Then
                        oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                        oDataRow("Numero_Factura") = NumeroFactura
                        oDataRow("Fecha_Factura") = FechaFactura
                        oDataRow("MontoCredito") = Format(MontoCredito / TasaCambio, "##,##0.00")
                        oDataRow("MontoPagado") = 0
                        oDataRow("Saldo") = Format(Saldo / TasaCambio, "##,##0.00")
                        oDataRow("Tipo_Factura") = "Factura"
                        DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                    Else
                        oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                        oDataRow("Numero_Factura") = NumeroFactura
                        oDataRow("Fecha_Factura") = FechaFactura
                        oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
                        oDataRow("MontoPagado") = 0
                        oDataRow("Saldo") = Format(Saldo, "##,##0.00")
                        oDataRow("Tipo_Factura") = "Factura"
                        DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                    End If

                End If

            End If

            My.Application.DoEvents()
            iPosicion = iPosicion + 1
            My.Forms.FrmRecibos.ProgressBar1.Value = My.Forms.FrmRecibos.ProgressBar1.Value + 1
        Loop


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////BUSCO LAS NOTAS DE DEBITOS SIN FACTURAS ////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota, Detalle_Nota.Monto, Detalle_Nota.Numero_Nota,IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Numero_Factura = N'0000') AND (IndiceNota.Cod_Cliente = '" & CodigoClientes & "')"
        SqlString = "SELECT  Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota, Detalle_Nota.Monto, Detalle_Nota.Numero_Nota, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente,  IndiceNota.Nombre_Cliente, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Tipo_Nota, NotaDebito.Tipo FROM Detalle_Nota INNER JOIN  IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND  Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB WHERE (Detalle_Nota.Numero_Factura = N'0000') AND (IndiceNota.Cod_Cliente = '" & CodigoClientes & "') AND (NotaDebito.Tipo = 'Debito Clientes')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaNota")
        MiConexion.Close()

        iPosicion = 0
        Registros = DataSet.Tables("ConsultaNota").Rows.Count

        My.Forms.FrmRecibos.ProgressBar1.Minimum = 0
        My.Forms.FrmRecibos.ProgressBar1.Maximum = Registros
        My.Forms.FrmRecibos.ProgressBar1.Value = 0

        Do While Registros > iPosicion
            NumeroNota = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Numero_Nota")
            NumeroFactura = "NB" & NumeroNota
            FechaFactura = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Fecha_Nota")
            TasaCambio = BuscaTasaCambio(FechaFactura)
            MontoCredito = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Monto")
            MonedaFactura = DataSet.Tables("ConsultaNota").Rows(iPosicion)("MonedaNota")

            '////////////////////////////////BUSCO UN RECIBO PARA ESTA NOTA DE DEBITO ///////////////////////////////////////////////
            SqlString = "SELECT SUM(MontoPagado) AS MontoPagado FROM DetalleRecibo WHERE (Numero_Nota = '" & NumeroFactura & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Saldo")
            MiConexion.Close()
            Saldo = MontoCredito
            If DataSet.Tables("Saldo").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("Saldo").Rows(0)("MontoPagado")) Then
                    Saldo = MontoCredito - DataSet.Tables("Saldo").Rows(0)("MontoPagado")
                    MontoCredito = Saldo
                End If
            Else
                Saldo = MontoCredito
            End If
            DataSet.Tables("Saldo").Reset()



            If My.Forms.FrmRecibos.TxtMonedaFactura.Text = "Cordobas" Then
                If MonedaFactura = "Cordobas" Then
                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                    oDataRow("Numero_Factura") = NumeroFactura
                    oDataRow("Fecha_Factura") = FechaFactura
                    oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
                    oDataRow("MontoPagado") = 0
                    oDataRow("Saldo") = Format(Saldo, "##,##0.00")
                    oDataRow("Tipo_Factura") = "NotaDebito"
                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                Else
                    '//////////////MONTOS EN DOLARES /////////////////////////
                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                    oDataRow("Numero_Factura") = NumeroFactura
                    oDataRow("Fecha_Factura") = FechaFactura
                    oDataRow("MontoCredito") = Format(MontoCredito * TasaCambio, "##,##0.00")
                    oDataRow("MontoPagado") = 0
                    oDataRow("Saldo") = Format(Saldo * TasaCambio, "##,##0.00")
                    oDataRow("Tipo_Factura") = "NotaDebito"
                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                End If
            Else
                If MonedaFactura = "Cordobas" Then
                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                    oDataRow("Numero_Factura") = NumeroFactura
                    oDataRow("Fecha_Factura") = FechaFactura
                    oDataRow("MontoCredito") = Format(MontoCredito / TasaCambio, "##,##0.00")
                    oDataRow("MontoPagado") = 0
                    oDataRow("Saldo") = Format(Saldo / TasaCambio, "##,##0.00")
                    oDataRow("Tipo_Factura") = "NotaDebito"
                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                Else
                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
                    oDataRow("Numero_Factura") = NumeroFactura
                    oDataRow("Fecha_Factura") = FechaFactura
                    oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
                    oDataRow("MontoPagado") = 0
                    oDataRow("Saldo") = Format(Saldo, "##,##0.00")
                    oDataRow("Tipo_Factura") = "NotaDebito"
                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
                End If

            End If


            My.Application.DoEvents()
            iPosicion = iPosicion + 1
            My.Forms.FrmRecibos.ProgressBar1.Value = My.Forms.FrmRecibos.ProgressBar1.Value + 1

        Loop



        Me.BindingFacturas.DataSource = DataSet.Tables("FacturaRecibos")
        Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas
        Me.TrueDBGridComponentes.Columns(0).Caption = "Factura No"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 70
        Me.TrueDBGridComponentes.Columns(1).Caption = "Fecha Fact"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 80
        Me.TrueDBGridComponentes.Columns(2).Caption = "Monto Credito"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridComponentes.Columns(3).Caption = "Monto Pagado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 90
        Me.TrueDBGridComponentes.Columns(4).Caption = "Saldo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MonedaRecibo = My.Forms.FrmRecibos.TxtMonedaFactura.Text
        SqlString = "SELECT  * FROM DatosEmpresa "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
            If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
                '*************************************************************************************************************************
                '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
                '**************************************************************************************************************************
                SqlString = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & MonedaRecibo & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Metodo")
                If DataSet.Tables("Metodo").Rows.Count <> 0 Then
                    '************************************************************************************************************************
                    '  ///////////////////////////AGREO LA FORMA DE PAGO DEL TOTAL //////////////////////////////////////////////////////////
                    '*************************************************************************************************************************
                    SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")

                    oDataRow = DataSet.Tables("MetodoPago").NewRow
                    oDataRow("NombrePago") = DataSet.Tables("Metodo").Rows(0)("NombrePago")
                    oDataRow("Monto") = 0
                    oDataRow("NumeroTarjeta") = 0
                    oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
                    DataSet.Tables("MetodoPago").Rows.Add(oDataRow)

                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
                End If
            End If
        End If



        SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoCompras WHERE (Numero_Compra = '-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
        Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
    End Sub


    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate
        Dim Saldo As Double, MontoCredito As Double, MontoAplicado As Double, MonedaRecibo As String, SqlString As String
        Dim iPosicion As Double = 0, Registros As Double = 0, Monto As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, oDataRow As DataRow

        If Me.TrueDBGridComponentes.Columns(2).Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns(2).Text)
        End If

        If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
            MontoAplicado = 0
        Else
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        End If


        Saldo = MontoCredito - MontoAplicado

        Me.TrueDBGridComponentes.Columns(4).Text = Format(Saldo, "##,##0.00")


        '/////////////////////////////////////////SUMO EL TOTAL DE LOS MONTOS APLICADOS /////////////////////////////////////////////////////
        iPosicion = 0
        Registros = Me.BindingFacturas.Count
        Monto = 0
        Do While Registros > iPosicion
            Monto = Me.BindingFacturas.Item(iPosicion)("MontoPagado") + Monto
            iPosicion = iPosicion + 1
        Loop

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MonedaRecibo = My.Forms.FrmRecibos.TxtMonedaFactura.Text
        SqlString = "SELECT  * FROM DatosEmpresa "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
            If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
                '*************************************************************************************************************************
                '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
                '**************************************************************************************************************************
                SqlString = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & MonedaRecibo & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Metodo")
                If DataSet.Tables("Metodo").Rows.Count <> 0 Then
                    '************************************************************************************************************************
                    '  ///////////////////////////AGREO LA FORMA DE PAGO DEL TOTAL //////////////////////////////////////////////////////////
                    '*************************************************************************************************************************
                    SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")

                    oDataRow = DataSet.Tables("MetodoPago").NewRow
                    oDataRow("NombrePago") = DataSet.Tables("Metodo").Rows(0)("NombrePago")
                    oDataRow("Monto") = Monto
                    oDataRow("NumeroTarjeta") = 0
                    oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
                    DataSet.Tables("MetodoPago").Rows.Add(oDataRow)

                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
                End If
            End If
        End If


    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        ActualizaMETODORecibos2()
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim MontoCredito As Double, MontoAplicado As Double

        If Not IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
            MsgBox("Es Necesario Digitar Numero", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TrueDBGridComponentes.Columns(2).Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns(2).Text)
        End If

        If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
            MontoAplicado = 0
        Else
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        End If

        If MontoCredito < MontoAplicado Then
            MsgBox("No se puede Pagar mas del Monto facturado", MsgBoxStyle.Critical, "Sistema Facturacion")
            Me.TrueDBGridComponentes.Columns(3).Text = 0
            MontoAplicado = 0
        End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridMetodo_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.AfterUpdate
        ActualizaMETODORecibos2()
    End Sub

    Private Sub TrueDBGridMetodo_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridMetodo.BeforeUpdate
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TrueDBGridMetodo.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TrueDBGridMetodo.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridMetodo.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Cheque"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Text = ""
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Tarjeta"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Text = ""
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If
        End Select


        ActualizaMETODORecibos2()
    End Sub

    Private Sub TrueDBGridMetodo_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridMetodo.ButtonClick
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TrueDBGridMetodo.Columns(0).Text = Metodo
    End Sub

    Private Sub TrueDBGridMetodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.Click

    End Sub

    Private Sub TrueDBGridMetodo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.DoubleClick
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TrueDBGridMetodo.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TrueDBGridMetodo.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridMetodo.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If Me.TrueDBGridMetodo.Columns(2).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TrueDBGridMetodo.Columns(2).Text
                End If
                If Me.TrueDBGridMetodo.Columns(3).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TrueDBGridMetodo.Columns(3).Text
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"

                If Me.TrueDBGridMetodo.Columns(2).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TrueDBGridMetodo.Columns(2).Text
                End If
                If Me.TrueDBGridMetodo.Columns(3).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TrueDBGridMetodo.Columns(3).Text
                End If
                My.Forms.FrmMetodosPagos.ShowDialog()
        End Select


        ActualizaMETODORecibos2()
    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim Registros As Integer, iPosicion As Integer, RegistrosFacturas As Integer, iPosicionFacturas As Integer
        Dim MontoMetodo As Double, MontoFactura As Double, ResultadoFactura As Double, MontoRecibido As Double
        Dim Respuesta As Integer = 0, oDataRow As DataRow, SQlString As String, NombrePago As String, NumeroFactura As String = "", NumeroTarjeta As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaVence As Date, Pagado As Double = 0
        Dim SaldoFacturaInicial As Double, AplicaFactura As Double, SaldoFacturaFinal As Double, FechaFactura As Date, Descripcion As String = ""
        Dim TipoFactura As String

        If Me.TxtImporteRecibido.Text <> "" Then
            MontoRecibido = Me.TxtImporteRecibido.Text
        Else

            MsgBox("No se puede procesar, debe indicar el importe recibido", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        '*****************************************************************************************************************************************************
        '///////////////////////CON ESTA CONSULTA BORRO EL DETALLE DEL RECIBO ////////////////////////////////////////////////////////////////////////////////
        '**********************************************************************************************************************************************
        SQlString = "SELECT NombrePago, Descripcion, Numero_Factura, Numero_Nota, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura FROM DetalleRecibo WHERE (CodReciboPago = '-1') AND (Fecha_Recibo = CONVERT(DATETIME, '2010-01-01 00:00:00', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecibo")

        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        RegistrosFacturas = Me.BindingFacturas.Count
        iPosicionFacturas = 0
        ResultadoFactura = 0

        Do While iPosicion < Registros

            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("Monto")) Then
                MontoMetodo = Me.BindingMetodo.Item(iPosicion)("Monto")
            Else
                MsgBox("Se necesita completar el monto en Efectivo", MsgBoxStyle.Critical, "Zeus Facturacio")
                Exit Sub

            End If
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            'FechaFactura = Me.BindingFacturas.Item(iPosicion)("Fecha_Factura")
            TipoFactura = Me.BindingFacturas.Item(iPosicionFacturas)("Tipo_Factura")

            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = "0"
            End If
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
                FechaVence = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            Else
                FechaVence = "01/01/1900"
            End If


            If ResultadoFactura < 0 Then

                '///////////////////////////////BUSCO LACONFIGURACION DEL RECIBO /////////////////////////////////
                SQlString = "SELECT  * FROM DatosEmpresa"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "DatosEmpresa")
                If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                    If DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura") = True Then
                        SQlString = "SELECT *  FROM Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "DetalleFacturas")
                        If DataSet.Tables("DetalleFacturas").Rows.Count <> 0 Then
                            Descripcion = DataSet.Tables("DetalleFacturas").Rows(0)("Descripcion_Producto")
                        End If
                    End If
                    'DataSet.Tables("DetalleFacturas").Clear()
                End If

                '


                If MontoMetodo >= System.Math.Abs(ResultadoFactura) Then
                    MontoMetodo = MontoMetodo - System.Math.Abs(ResultadoFactura)
                    MontoFactura = System.Math.Abs(ResultadoFactura)
                    AplicaFactura = MontoFactura
                    SaldoFacturaFinal = SaldoFacturaInicial - AplicaFactura
                    ResultadoFactura = 0
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                    oDataRow = FrmRecibos.ds.Tables("DetalleRecibo").NewRow
                    oDataRow("NombrePago") = NombrePago
                    oDataRow("Descripcion") = "PAGO " & Descripcion
                    If TipoFactura = "Factura" Then
                        oDataRow("Numero_Nota") = "0000"
                        oDataRow("Numero_Factura") = NumeroFactura
                    Else
                        oDataRow("Numero_Nota") = NumeroFactura
                        oDataRow("Numero_Factura") = NumeroFactura
                    End If
                    oDataRow("MontoPagado") = MontoFactura
                    oDataRow("NumeroTarjeta") = NumeroTarjeta
                    oDataRow("FechaVence") = FechaVence
                    oDataRow("MontoFactura") = SaldoFacturaInicial
                    oDataRow("AplicaFactura") = AplicaFactura
                    oDataRow("SaldoFactura") = SaldoFacturaFinal
                    FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                    'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)


                Else
                    ResultadoFactura = MontoMetodo - System.Math.Abs(ResultadoFactura)
                    MontoFactura = MontoMetodo
                    AplicaFactura = MontoMetodo
                    SaldoFacturaFinal = SaldoFacturaInicial - AplicaFactura
                    MontoMetodo = 0
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                    oDataRow = FrmRecibos.ds.Tables("DetalleRecibo").NewRow
                    oDataRow("NombrePago") = NombrePago
                    oDataRow("Descripcion") = "PAGO " & Descripcion
                    If TipoFactura = "Factura" Then
                        oDataRow("Numero_Nota") = "0000"
                        oDataRow("Numero_Factura") = NumeroFactura
                    Else
                        oDataRow("Numero_Nota") = NumeroFactura
                        oDataRow("Numero_Factura") = NumeroFactura
                    End If
                    oDataRow("MontoPagado") = MontoFactura
                    oDataRow("NumeroTarjeta") = NumeroTarjeta
                    oDataRow("FechaVence") = FechaVence
                    oDataRow("MontoFactura") = SaldoFacturaInicial
                    oDataRow("AplicaFactura") = AplicaFactura
                    oDataRow("SaldoFactura") = SaldoFacturaFinal
                    FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                    'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)

                End If
            End If

            Do While iPosicionFacturas < RegistrosFacturas
                If MontoMetodo <> 0 Then

                    TipoFactura = Me.BindingFacturas.Item(iPosicionFacturas)("Tipo_Factura")
                    NumeroFactura = Me.BindingFacturas.Item(iPosicionFacturas)("Numero_Factura")
                    FechaFactura = Me.BindingFacturas.Item(iPosicionFacturas)("Fecha_Factura")
                    If Not IsDBNull(Me.BindingFacturas.Item(iPosicionFacturas)("MontoPagado")) Then
                        MontoFactura = Me.BindingFacturas.Item(iPosicionFacturas)("MontoPagado")
                    End If

                    SaldoFacturaInicial = Me.BindingFacturas.Item(iPosicionFacturas)("MontoCredito")
                    If Not IsDBNull(Me.BindingFacturas.Item(iPosicionFacturas)("MontoPagado")) Then
                        AplicaFactura = Me.BindingFacturas.Item(iPosicionFacturas)("MontoPagado")
                    End If
                    SaldoFacturaFinal = Me.BindingFacturas.Item(iPosicionFacturas)("Saldo")

                    NumeroFactura = Me.BindingFacturas.Item(iPosicionFacturas)("Numero_Factura")

                    '///////////////////////////////BUSCO LACONFIGURACION DEL RECIBO /////////////////////////////////
                    SQlString = "SELECT  * FROM DatosEmpresa"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                    DataAdapter.Fill(DataSet, "DatosEmpresa")
                    If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                        If DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura") = True Then
                            SQlString = "SELECT *  FROM Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                            DataAdapter.Fill(DataSet, "DetalleFacturas")
                            If DataSet.Tables("DetalleFacturas").Rows.Count <> 0 Then
                                Descripcion = DataSet.Tables("DetalleFacturas").Rows(0)("Descripcion_Producto")
                            End If
                        End If
                        'DataSet.Tables("DetalleFacturas").Clear()
                    End If

                    '/////////////////////////////////////SI ES UNA NOTA DE DEBITO IMPRIMO LAS OBSERVACIONES ///////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////
                    If TipoFactura = "NotaDebito" Then
                        'SQlString = "SELECT  Detalle_Nota.* FROM Detalle_Nota WHERE Numero_Nota = '" & Mid(NumeroFactura, 3, Len(NumeroFactura)) & "')"
                        SQlString = "SELECT Detalle_Nota.Numero_Nota, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB  " & _
                                    "WHERE (Detalle_Nota.Numero_Nota = '" & Mid(NumeroFactura, 3, Len(NumeroFactura)) & "') AND (NotaDebito.Tipo LIKE N'%Debito Clientes%')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                            Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                        End If

                        DataSet.Tables("Consulta").Reset()
                    End If



                    If MontoFactura <> 0 Then
                        If MontoMetodo >= MontoFactura Then
                            ResultadoFactura = MontoMetodo - MontoFactura
                            MontoMetodo = MontoMetodo - MontoFactura
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                            oDataRow = FrmRecibos.ds.Tables("DetalleRecibo").NewRow
                            oDataRow("NombrePago") = NombrePago
                            oDataRow("Descripcion") = "PAGO " & Descripcion
                            If TipoFactura = "Factura" Then
                                oDataRow("Numero_Nota") = "0000"
                                oDataRow("Numero_Factura") = NumeroFactura
                            Else
                                oDataRow("Numero_Nota") = NumeroFactura
                                oDataRow("Numero_Factura") = NumeroFactura
                            End If
                            oDataRow("MontoPagado") = MontoFactura
                            oDataRow("NumeroTarjeta") = NumeroTarjeta
                            oDataRow("FechaVence") = FechaVence
                            oDataRow("MontoFactura") = SaldoFacturaInicial
                            oDataRow("AplicaFactura") = AplicaFactura
                            oDataRow("SaldoFactura") = SaldoFacturaFinal
                            FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)

                        Else
                            ResultadoFactura = MontoMetodo - MontoFactura
                            AplicaFactura = MontoMetodo
                            SaldoFacturaFinal = SaldoFacturaInicial - AplicaFactura
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                            oDataRow = FrmRecibos.ds.Tables("DetalleRecibo").NewRow
                            oDataRow("NombrePago") = NombrePago
                            oDataRow("Descripcion") = "PAGO " & Descripcion
                            If TipoFactura = "Factura" Then
                                oDataRow("Numero_Nota") = "0000"
                                oDataRow("Numero_Factura") = NumeroFactura
                            Else
                                oDataRow("Numero_Nota") = NumeroFactura
                                oDataRow("Numero_Factura") = NumeroFactura
                            End If
                            oDataRow("MontoPagado") = MontoMetodo
                            oDataRow("NumeroTarjeta") = NumeroTarjeta
                            oDataRow("FechaVence") = FechaVence
                            oDataRow("MontoFactura") = SaldoFacturaInicial
                            oDataRow("AplicaFactura") = AplicaFactura
                            oDataRow("SaldoFactura") = SaldoFacturaFinal
                            FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            MontoMetodo = 0
                            SaldoFacturaInicial = SaldoFacturaFinal

                        End If

                    End If
                    iPosicionFacturas = iPosicionFacturas + 1
                Else
                    Exit Do
                End If

            Loop



            iPosicion = iPosicion + 1
        Loop

        'FrmRecibos.BindingDetalleRecibo.DataSource = DataSet.Tables("DetalleRecibo")

        'FrmRecibos.ds.Tables("DetalleRecibo").ImportRow = DataSet.Tables("DetalleRecibo")
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Button = True
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 213
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 100
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 75
        FrmRecibos.TDBGridDetalle.Columns(3).NumberFormat = "##,##0.00"
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Visible = False
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Visible = False
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Visible = False
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Visible = False
        FrmRecibos.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Visible = False

        FrmRecibos.TxtImporteRecibido.Text = Me.TxtImporteRecibido.Text
        FrmRecibos.TxtPorAplicar.Text = Me.TxtPorAplicar.Text
        FrmRecibos.TxtImporteAplicado.Text = Me.TxtImporteAplicado.Text
        Me.Close()
    End Sub
End Class