Imports System.Text.RegularExpressions

Public Class FrmRecibosFacturas
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoClientes As String
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
        SQlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.MetodoPago As Numero_Recibo, Facturas.Numero_Factura As NotaDebito, Facturas.SubTotal As MontoNota, Facturas.SubTotal As Monto, Facturas.Fecha_Factura As FechaVence, Facturas.IVA As Abono, Facturas.SubTotal AS Saldo, Facturas.SubTotal As Moratorio, Facturas.SubTotal As Dias, Facturas.SubTotal AS Total  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " &
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

            If NumeroFactura = "M73054" Then
                NumeroFactura = "M73054"
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
            SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, SUM(CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / ISNULL(TasaCambio.MontoTasa, 1) END) AS MontoDolar, SUM(CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * ISNULL(TasaCambio.MontoTasa, 1) END) AS MontoCordobas, MAX(Recibo.MonedaRecibo) AS MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON DetalleRecibo.Fecha_Recibo = TasaCambio.FechaTasa  GROUP BY DetalleRecibo.Numero_Factura  " &
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

        Dim DataSet As New DataSet
        Dim oDataRow As DataRow
        Dim MonedaRecibo As String

        Me.TrueDBGridComponentes.Enabled = True

        '==============================================================
        ' MONEDA Y FECHA DEL RECIBO
        '==============================================================
        MonedaRecibo = My.Forms.FrmRecibos.TxtMonedaFactura.Text
        Dim fechaRecibo As Date = My.Forms.FrmRecibos.DTPFecha.Value.Date


        '==============================================================
        ' ESTRUCTURA DE FACTURARECIBOS (misma que antes, para no afectar
        ' BindingFacturas ni el grid). La consulta no devuelve filas.
        '==============================================================
        Dim SqlString As String =
            "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito, " &
            "Facturas.MontoCredito AS MontoPagado, Facturas.MontoCredito AS Saldo, Facturas.Tipo_Factura " &
            "FROM Facturas WHERE 1 = 0"

        Using conexionBD As New SqlClient.SqlConnection(Conexion)
            conexionBD.Open()
            Using DataAdapter As New SqlClient.SqlDataAdapter(SqlString, conexionBD)
                DataAdapter.Fill(DataSet, "FacturaRecibos")
            End Using
        End Using


        '==============================================================
        ' FACTURAS Y NOTAS DE DÉBITO PENDIENTES
        ' Mismo cálculo que Cuentas x Cobrar y que la validación al
        ' grabar el recibo (clase Recibos), a la fecha del recibo.
        '==============================================================
        Dim filtroCxC As CxCFiltro = CxCFiltro.PorCliente(CodigoClientes, fechaRecibo, DineroCxC.MonedaDesdeTexto(MonedaRecibo))
        Dim resultadoCxC As CxCResultado = CrearServicioCxC().CalcularSaldos(filtroCxC)

        Dim pendientes As New List(Of CxCLinea)
        For Each lineaCxC As CxCLinea In resultadoCxC.Lineas
            If lineaCxC.Saldo <= 0D Then Continue For
            If lineaCxC.TipoLinea = TipoLineaCxC.Factura OrElse lineaCxC.TipoLinea = TipoLineaCxC.NotaDebitoSinFactura Then
                pendientes.Add(lineaCxC)
            End If
        Next
        pendientes.Sort(Function(a, b) a.FechaFactura.CompareTo(b.FechaFactura))

        My.Forms.FrmRecibos.ProgressBar1.Minimum = 0
        My.Forms.FrmRecibos.ProgressBar1.Maximum = Math.Max(pendientes.Count, 1)
        My.Forms.FrmRecibos.ProgressBar1.Value = 0

        For Each lineaCxC As CxCLinea In pendientes

            oDataRow = DataSet.Tables("FacturaRecibos").NewRow

            If lineaCxC.TipoLinea = TipoLineaCxC.Factura Then
                ' MontoCredito = lo disponible para aplicar en este recibo
                oDataRow("Numero_Factura") = lineaCxC.NumeroFactura.Trim()
                oDataRow("MontoCredito") = CDbl(lineaCxC.Saldo)
                oDataRow("Tipo_Factura") = "Factura"
            Else
                ' Nota de débito sin factura: se paga como "NB" + número de nota
                oDataRow("Numero_Factura") = "NB" & lineaCxC.NumeroNotaDebito
                oDataRow("MontoCredito") = CDbl(lineaCxC.Saldo)
                oDataRow("Tipo_Factura") = "NotaDebito"
            End If

            oDataRow("Fecha_Factura") = lineaCxC.FechaFactura
            oDataRow("MontoPagado") = 0
            oDataRow("Saldo") = CDbl(lineaCxC.Saldo)

            DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)

            If My.Forms.FrmRecibos.ProgressBar1.Value < My.Forms.FrmRecibos.ProgressBar1.Maximum Then
                My.Forms.FrmRecibos.ProgressBar1.Value += 1
            End If
        Next

        If resultadoCxC.Advertencias.Count > 0 Then
            MostrarAdvertenciasCxC(resultadoCxC.Advertencias)
        End If


        '==============================================================
        ' ENLAZAR GRID DE FACTURAS
        '==============================================================
        Me.BindingFacturas.DataSource = DataSet.Tables("FacturaRecibos")
        Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas

        Me.TrueDBGridComponentes.Columns(0).Caption = "Factura No"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 70

        Me.TrueDBGridComponentes.Columns(1).Caption = "Fecha Fact"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 80

        Me.TrueDBGridComponentes.Columns(2).Caption = "Monto Credito"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridComponentes.Columns(2).NumberFormat = "##,##0.00"

        Me.TrueDBGridComponentes.Columns(3).Caption = "Monto Pagado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 90
        Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"

        Me.TrueDBGridComponentes.Columns(4).Caption = "Saldo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 90
        Me.TrueDBGridComponentes.Columns(4).NumberFormat = "##,##0.00"

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False


        '==============================================================
        ' METODO DE PAGO POR DEFECTO
        '==============================================================
        Dim MetodoPagoDefecto As String = ""
        Dim NombrePagoEfectivo As String = ""

        Using conexionMetodo As New SqlClient.SqlConnection(Conexion)
            conexionMetodo.Open()

            Using comandoDefecto As New SqlClient.SqlCommand("SELECT TOP (1) MetodoPagoDefecto FROM DatosEmpresa", conexionMetodo)
                Dim valorDefecto As Object = comandoDefecto.ExecuteScalar()
                If valorDefecto IsNot Nothing AndAlso Not IsDBNull(valorDefecto) Then
                    MetodoPagoDefecto = Convert.ToString(valorDefecto).Trim()
                End If
            End Using

            If MetodoPagoDefecto = "Efectivo" Then
                Using comandoEfectivo As New SqlClient.SqlCommand(
                    "SELECT TOP (1) NombrePago FROM MetodoPago WHERE TipoPago = @TipoPago AND Moneda = @Moneda", conexionMetodo)
                    comandoEfectivo.Parameters.Add("@TipoPago", SqlDbType.NVarChar, 50).Value = "Efectivo"
                    comandoEfectivo.Parameters.Add("@Moneda", SqlDbType.NVarChar, 50).Value = MonedaRecibo
                    Dim valorEfectivo As Object = comandoEfectivo.ExecuteScalar()
                    If valorEfectivo IsNot Nothing AndAlso Not IsDBNull(valorEfectivo) Then
                        NombrePagoEfectivo = Convert.ToString(valorEfectivo)
                    End If
                End Using
            End If
        End Using


        '==============================================================
        ' TABLA DE METODOS DE PAGO
        '==============================================================
        Dim TablaMetodo As New DataTable("MetodoPago")
        TablaMetodo.Columns.Add("NombrePago", GetType(String))
        TablaMetodo.Columns.Add("Monto", GetType(Double))
        TablaMetodo.Columns.Add("NumeroTarjeta", GetType(String))
        TablaMetodo.Columns.Add("FechaVence", GetType(Date))

        If NombrePagoEfectivo <> "" Then
            Dim filaMetodo As DataRow = TablaMetodo.NewRow()
            filaMetodo("NombrePago") = NombrePagoEfectivo
            filaMetodo("Monto") = 0
            filaMetodo("NumeroTarjeta") = ""
            filaMetodo("FechaVence") = fechaRecibo
            TablaMetodo.Rows.Add(filaMetodo)
        End If

        Me.BindingMetodo.DataSource = TablaMetodo
        Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Width = 110
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub


    'Private Sub FrmRecibosFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim SqlString As String = "", DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
    '    Dim NumeroFactura As String, FechaFactura As Date, iPosicion As Double = 0, Registros As Double = 0, TasaCambio As Double = 0
    '    Dim oDataRow As DataRow, MontoCredito As Double, Saldo As Double, MonedaFactura As String, MonedaRecibo As String
    '    Dim NumeroNota As String = ""


    '    Me.TrueDBGridComponentes.Enabled = True


    '    MiConexion.Close()


    '    ConsultaCreditos(CodigoClientes, Now, My.Forms.FrmRecibos.TxtMonedaFactura.Text)

    '    SqlString = "SELECT DISTINCT  Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito, DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado AS MontoPagado, Facturas.MontoCredito AS Saldo, Facturas.MonedaFactura, Detalle_Facturas.TasaCambio FROM   Facturas INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " &
    '                "WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '" & CodigoClientes & "') AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Facturas.Fecha_Factura"
    '    MiConexion.Open()
    '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "Consultas")


    '    SqlString = "SELECT DISTINCT  Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito, DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado AS MontoPagado, Facturas.MontoCredito AS Saldo, Facturas.Tipo_Factura FROM   Facturas INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " &
    '                "WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '-1') AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Facturas.Fecha_Factura"

    '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "FacturaRecibos")
    '    MiConexion.Close()

    '    iPosicion = 0
    '    Registros = DataSet.Tables("Consultas").Rows.Count

    '    My.Forms.FrmRecibos.ProgressBar1.Minimum = 0
    '    My.Forms.FrmRecibos.ProgressBar1.Maximum = Registros
    '    My.Forms.FrmRecibos.ProgressBar1.Value = 0

    '    Do While Registros > iPosicion
    '        My.Application.DoEvents()

    '        NumeroFactura = DataSet.Tables("Consultas").Rows(iPosicion)("Numero_Factura")
    '        FechaFactura = DataSet.Tables("Consultas").Rows(iPosicion)("Fecha_Factura")
    '        TasaCambio = BuscaTasaCambio(FechaFactura)
    '        MontoCredito = DataSet.Tables("Consultas").Rows(iPosicion)("MontoCredito")
    '        Saldo = DataSet.Tables("Consultas").Rows(iPosicion)("Saldo")
    '        MonedaFactura = DataSet.Tables("Consultas").Rows(iPosicion)("MonedaFactura")

    '        If CDbl(Format(Saldo, "0.00")) > 0 Then

    '            If My.Forms.FrmRecibos.TxtMonedaFactura.Text = "Cordobas" Then
    '                If MonedaFactura = "Cordobas" Then
    '                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                    oDataRow("Numero_Factura") = NumeroFactura
    '                    oDataRow("Fecha_Factura") = FechaFactura
    '                    oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
    '                    oDataRow("MontoPagado") = 0
    '                    oDataRow("Saldo") = Format(Saldo, "##,##0.00")
    '                    oDataRow("Tipo_Factura") = "Factura"
    '                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '                Else
    '                    '//////////////MONTOS EN DOLARES /////////////////////////
    '                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                    oDataRow("Numero_Factura") = NumeroFactura
    '                    oDataRow("Fecha_Factura") = FechaFactura
    '                    oDataRow("MontoCredito") = Format(MontoCredito * TasaCambio, "##,##0.00")
    '                    oDataRow("MontoPagado") = 0
    '                    oDataRow("Saldo") = Format(Saldo * TasaCambio, "##,##0.00")
    '                    oDataRow("Tipo_Factura") = "Factura"
    '                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '                End If
    '            Else
    '                If MonedaFactura = "Cordobas" Then
    '                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                    oDataRow("Numero_Factura") = NumeroFactura
    '                    oDataRow("Fecha_Factura") = FechaFactura
    '                    oDataRow("MontoCredito") = Format(MontoCredito / TasaCambio, "##,##0.00")
    '                    oDataRow("MontoPagado") = 0
    '                    oDataRow("Saldo") = Format(Saldo / TasaCambio, "##,##0.00")
    '                    oDataRow("Tipo_Factura") = "Factura"
    '                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '                Else
    '                    oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                    oDataRow("Numero_Factura") = NumeroFactura
    '                    oDataRow("Fecha_Factura") = FechaFactura
    '                    oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
    '                    oDataRow("MontoPagado") = 0
    '                    oDataRow("Saldo") = Format(Saldo, "##,##0.00")
    '                    oDataRow("Tipo_Factura") = "Factura"
    '                    DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '                End If

    '            End If

    '        End If

    '        My.Application.DoEvents()
    '        iPosicion = iPosicion + 1
    '        My.Forms.FrmRecibos.ProgressBar1.Value = My.Forms.FrmRecibos.ProgressBar1.Value + 1
    '    Loop


    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '    '///////////////////////////////////BUSCO LAS NOTAS DE DEBITOS SIN FACTURAS ////////////////////////////////////////////
    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '    'SqlString = "SELECT Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota, Detalle_Nota.Monto, Detalle_Nota.Numero_Nota,IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Numero_Factura = N'0000') AND (IndiceNota.Cod_Cliente = '" & CodigoClientes & "')"
    '    SqlString = "SELECT  Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota, Detalle_Nota.Monto, Detalle_Nota.Numero_Nota, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente,  IndiceNota.Nombre_Cliente, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Tipo_Nota, NotaDebito.Tipo FROM Detalle_Nota INNER JOIN  IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND  Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB WHERE (Detalle_Nota.Numero_Factura = N'0000') AND (IndiceNota.Cod_Cliente = '" & CodigoClientes & "') AND (NotaDebito.Tipo = 'Debito Clientes')"
    '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "ConsultaNota")
    '    MiConexion.Close()

    '    iPosicion = 0
    '    Registros = DataSet.Tables("ConsultaNota").Rows.Count

    '    My.Forms.FrmRecibos.ProgressBar1.Minimum = 0
    '    My.Forms.FrmRecibos.ProgressBar1.Maximum = Registros
    '    My.Forms.FrmRecibos.ProgressBar1.Value = 0

    '    Do While Registros > iPosicion
    '        NumeroNota = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Numero_Nota")
    '        NumeroFactura = "NB" & NumeroNota
    '        FechaFactura = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Fecha_Nota")
    '        TasaCambio = BuscaTasaCambio(FechaFactura)
    '        MontoCredito = DataSet.Tables("ConsultaNota").Rows(iPosicion)("Monto")
    '        MonedaFactura = DataSet.Tables("ConsultaNota").Rows(iPosicion)("MonedaNota")

    '        '////////////////////////////////BUSCO UN RECIBO PARA ESTA NOTA DE DEBITO ///////////////////////////////////////////////
    '        SqlString = "SELECT SUM(MontoPagado) AS MontoPagado FROM DetalleRecibo WHERE (Numero_Nota = '" & NumeroFactura & "')"
    '        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '        DataAdapter.Fill(DataSet, "Saldo")
    '        MiConexion.Close()
    '        Saldo = MontoCredito
    '        If DataSet.Tables("Saldo").Rows.Count <> 0 Then
    '            If Not IsDBNull(DataSet.Tables("Saldo").Rows(0)("MontoPagado")) Then
    '                Saldo = MontoCredito - DataSet.Tables("Saldo").Rows(0)("MontoPagado")
    '                MontoCredito = Saldo
    '            End If
    '        Else
    '            Saldo = MontoCredito
    '        End If
    '        DataSet.Tables("Saldo").Reset()



    '        If My.Forms.FrmRecibos.TxtMonedaFactura.Text = "Cordobas" Then
    '            If MonedaFactura = "Cordobas" Then
    '                oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                oDataRow("Numero_Factura") = NumeroFactura
    '                oDataRow("Fecha_Factura") = FechaFactura
    '                oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
    '                oDataRow("MontoPagado") = 0
    '                oDataRow("Saldo") = Format(Saldo, "##,##0.00")
    '                oDataRow("Tipo_Factura") = "NotaDebito"
    '                DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '            Else
    '                '//////////////MONTOS EN DOLARES /////////////////////////
    '                oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                oDataRow("Numero_Factura") = NumeroFactura
    '                oDataRow("Fecha_Factura") = FechaFactura
    '                oDataRow("MontoCredito") = Format(MontoCredito * TasaCambio, "##,##0.00")
    '                oDataRow("MontoPagado") = 0
    '                oDataRow("Saldo") = Format(Saldo * TasaCambio, "##,##0.00")
    '                oDataRow("Tipo_Factura") = "NotaDebito"
    '                DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '            End If
    '        Else
    '            If MonedaFactura = "Cordobas" Then
    '                oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                oDataRow("Numero_Factura") = NumeroFactura
    '                oDataRow("Fecha_Factura") = FechaFactura
    '                oDataRow("MontoCredito") = Format(MontoCredito / TasaCambio, "##,##0.00")
    '                oDataRow("MontoPagado") = 0
    '                oDataRow("Saldo") = Format(Saldo / TasaCambio, "##,##0.00")
    '                oDataRow("Tipo_Factura") = "NotaDebito"
    '                DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '            Else
    '                oDataRow = DataSet.Tables("FacturaRecibos").NewRow
    '                oDataRow("Numero_Factura") = NumeroFactura
    '                oDataRow("Fecha_Factura") = FechaFactura
    '                oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
    '                oDataRow("MontoPagado") = 0
    '                oDataRow("Saldo") = Format(Saldo, "##,##0.00")
    '                oDataRow("Tipo_Factura") = "NotaDebito"
    '                DataSet.Tables("FacturaRecibos").Rows.Add(oDataRow)
    '            End If

    '        End If


    '        My.Application.DoEvents()
    '        iPosicion = iPosicion + 1
    '        My.Forms.FrmRecibos.ProgressBar1.Value = My.Forms.FrmRecibos.ProgressBar1.Value + 1

    '    Loop



    '    Me.BindingFacturas.DataSource = DataSet.Tables("FacturaRecibos")
    '    Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas
    '    Me.TrueDBGridComponentes.Columns(0).Caption = "Factura No"
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 70
    '    Me.TrueDBGridComponentes.Columns(1).Caption = "Fecha Fact"
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 80
    '    Me.TrueDBGridComponentes.Columns(2).Caption = "Monto Credito"
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 90
    '    Me.TrueDBGridComponentes.Columns(3).Caption = "Monto Pagado"
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 90
    '    Me.TrueDBGridComponentes.Columns(4).Caption = "Saldo"
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 90
    '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False

    '    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '    '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
    '    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '    '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '    MonedaRecibo = My.Forms.FrmRecibos.TxtMonedaFactura.Text
    '    SqlString = "SELECT  * FROM DatosEmpresa "
    '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "DatosEmpresa")
    '    If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
    '        If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
    '            '*************************************************************************************************************************
    '            '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
    '            '**************************************************************************************************************************
    '            SqlString = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & MonedaRecibo & "')"
    '            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '            DataAdapter.Fill(DataSet, "Metodo")
    '            If DataSet.Tables("Metodo").Rows.Count <> 0 Then
    '                '************************************************************************************************************************
    '                '  ///////////////////////////AGREO LA FORMA DE PAGO DEL TOTAL //////////////////////////////////////////////////////////
    '                '*************************************************************************************************************************
    '                SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
    '                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '                DataAdapter.Fill(DataSet, "MetodoPago")

    '                oDataRow = DataSet.Tables("MetodoPago").NewRow
    '                oDataRow("NombrePago") = DataSet.Tables("Metodo").Rows(0)("NombrePago")
    '                oDataRow("Monto") = 0
    '                oDataRow("NumeroTarjeta") = 0
    '                oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
    '                DataSet.Tables("MetodoPago").Rows.Add(oDataRow)

    '                Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
    '                Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
    '                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
    '                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
    '                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
    '                Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
    '                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
    '                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
    '            End If
    '        End If
    '    End If



    '    SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoCompras WHERE (Numero_Compra = '-1')"
    '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "MetodoPago")
    '    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
    '    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
    '    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
    '    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
    '    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
    '    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
    '    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
    '    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
    'End Sub


    '==============================================================
    ' AL CAMBIAR EL MONTO A PAGAR DE UNA FACTURA
    '==============================================================
    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate

        Dim montoCredito As Decimal = CeldaDecimal(Me.TrueDBGridComponentes.Columns(2).Text)
        Dim aplicado As Decimal = CeldaDecimal(Me.TrueDBGridComponentes.Columns(3).Text)
        Me.TrueDBGridComponentes.Columns(4).Text = Format(montoCredito - aplicado, "##,##0.00")

        '--- Total aplicado a todas las facturas
        Dim total As Decimal = 0D
        For i As Integer = 0 To Me.BindingFacturas.Count - 1
            total += CeldaDecimal(CType(Me.BindingFacturas.Item(i), DataRowView)("MontoPagado"))
        Next

        '--- Con un solo método de pago, su monto sigue al total aplicado.
        '    Con varios métodos, los montos los define el usuario (ya no se borran).
        Dim tablaMetodo As DataTable = TryCast(Me.BindingMetodo.DataSource, DataTable)
        If tablaMetodo Is Nothing Then Exit Sub
        Dim vivas As New List(Of DataRow)
        For Each r As DataRow In tablaMetodo.Rows
            If r.RowState <> DataRowState.Deleted Then vivas.Add(r)
        Next
        If vivas.Count = 1 Then vivas(0)("Monto") = CDbl(total)

    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate

        If Not IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
            MsgBox("Es Necesario Digitar Numero", MsgBoxStyle.Critical, "Zeus Facturacion")
            e.Cancel = True
            Exit Sub
        End If

        Dim montoCredito As Decimal = CeldaDecimal(Me.TrueDBGridComponentes.Columns(2).Text)
        Dim aplicado As Decimal = CeldaDecimal(Me.TrueDBGridComponentes.Columns(3).Text)

        If aplicado < 0D Then
            MsgBox("El monto a pagar no puede ser negativo", MsgBoxStyle.Critical, "Zeus Facturacion")
            e.Cancel = True
        ElseIf aplicado > montoCredito + 0.005D Then
            MsgBox(String.Format("No se puede pagar más del saldo ({0:N2})", montoCredito), MsgBoxStyle.Critical, "Zeus Facturacion")
            e.Cancel = True
        End If
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        ActualizaMETODORecibos2()
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

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        Me.BindingMetodo.EndEdit()
        Me.BindingFacturas.EndEdit()

        '--- Métodos de pago con monto
        Dim metodos As New List(Of DataRowView)
        Dim totalMetodos As Decimal = 0D
        For i As Integer = 0 To Me.BindingMetodo.Count - 1
            Dim m As DataRowView = CType(Me.BindingMetodo.Item(i), DataRowView)
            Dim monto As Decimal = CeldaDecimal(m("Monto"))
            If monto < 0D Then
                MsgBox("El monto de un método de pago no puede ser negativo.", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If
            If monto > 0D Then
                If Celda(m("NombrePago")) = "" Then
                    MsgBox("Falta el nombre del método de pago.", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
                metodos.Add(m)
                totalMetodos += monto
            End If
        Next

        '--- Facturas / notas con monto a pagar
        Dim documentos As New List(Of DataRowView)
        Dim totalAplicado As Decimal = 0D
        For i As Integer = 0 To Me.BindingFacturas.Count - 1
            Dim f As DataRowView = CType(Me.BindingFacturas.Item(i), DataRowView)
            Dim pagar As Decimal = CeldaDecimal(f("MontoPagado"))
            If pagar <= 0D Then Continue For
            If pagar > CeldaDecimal(f("MontoCredito")) + 0.005D Then
                MsgBox(String.Format("{0}: está pagando {1:N2} y el saldo es {2:N2}.", Celda(f("Numero_Factura")), pagar, CeldaDecimal(f("MontoCredito"))),
                       MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If
            documentos.Add(f)
            totalAplicado += pagar
        Next

        If documentos.Count = 0 Then
            MsgBox("Indique el monto a pagar en al menos una factura.", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If
        If totalMetodos < totalAplicado - 0.005D Then
            MsgBox(String.Format("Lo aplicado a facturas ({0:N2}) es mayor que lo recibido en los métodos de pago ({1:N2}).", totalAplicado, totalMetodos),
                   MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If
        If totalMetodos > totalAplicado + 0.005D Then
            If MsgBox(String.Format("Quedan {0:N2} sin aplicar. Ese monto NO quedará en el recibo. ¿Desea continuar?", totalMetodos - totalAplicado),
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Zeus Facturacion") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        '--- Reparto: cada documento se paga con los métodos en el orden en que están
        Dim lineaFactura As Boolean = LeerLineaFactura()
        Dim tabla As DataTable = FrmRecibos.ds.Tables("DetalleRecibo")
        Dim iMetodo As Integer = 0
        Dim disponible As Decimal = CeldaDecimal(metodos(0)("Monto"))

        For Each f As DataRowView In documentos

            Dim numero As String = Celda(f("Numero_Factura"))
            Dim tipo As String = Celda(f("Tipo_Factura"), "Factura")
            Dim saldo As Decimal = CeldaDecimal(f("MontoCredito"))
            Dim porPagar As Decimal = CeldaDecimal(f("MontoPagado"))
            Dim descripcion As String = "PAGO " & DescripcionDocumento(numero, CDate(f("Fecha_Factura")), tipo, lineaFactura)

            Do While porPagar > 0D AndAlso iMetodo < metodos.Count

                If disponible <= 0D Then
                    iMetodo += 1
                    If iMetodo < metodos.Count Then disponible = CeldaDecimal(metodos(iMetodo)("Monto"))
                    Continue Do
                End If

                Dim m As DataRowView = metodos(iMetodo)
                Dim aplica As Decimal = Math.Min(porPagar, disponible)

                Dim fila As DataRow = tabla.NewRow()
                fila("NombrePago") = Celda(m("NombrePago"))
                fila("Descripcion") = descripcion
                fila("Numero_Factura") = numero
                fila("Numero_Nota") = If(tipo = "NotaDebito", numero, "0000")
                fila("MontoPagado") = CDbl(aplica)
                fila("NumeroTarjeta") = Celda(m("NumeroTarjeta"), "0")
                fila("FechaVence") = If(IsDBNull(m("FechaVence")), CObj(DBNull.Value), m("FechaVence"))
                fila("MontoFactura") = CDbl(saldo)               ' saldo antes de esta línea
                fila("AplicaFactura") = CDbl(aplica)
                fila("SaldoFactura") = CDbl(saldo - aplica)      ' saldo después de esta línea
                tabla.Rows.Add(fila)

                saldo -= aplica
                porPagar -= aplica
                disponible -= aplica
            Loop
        Next

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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.TxtImporteAplicado.Text = ""
        Me.TxtImporteRecibido.Text = ""
        Me.TxtPorAplicar.Text = ""
        ActualizaMETODORecibos()
        Me.Close()
    End Sub

    Private Sub btnAgregarMetodo_Click(sender As Object, e As EventArgs) Handles btnAgregarMetodo.Click
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TrueDBGridMetodo.Columns(0).Text = Metodo
    End Sub

    '==============================================================
    ' FUNCIONES DE APOYO
    '==============================================================
    Private Function LeerLineaFactura() As Boolean
        Using cn As New SqlClient.SqlConnection(Conexion)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SELECT TOP (1) LineaFactura FROM DatosEmpresa", cn)
                Dim v As Object = cmd.ExecuteScalar()
                Return v IsNot Nothing AndAlso Not IsDBNull(v) AndAlso Convert.ToBoolean(v)
            End Using
        End Using
    End Function

    ''' <summary>Descripción para la línea del recibo: el primer producto de la factura (si LineaFactura
    ''' está activo) o la descripción de la nota de débito. Siempre la del documento que se paga.</summary>
    Private Function DescripcionDocumento(numero As String, fecha As Date, tipo As String, lineaFactura As Boolean) As String
        Dim sql As String
        If tipo = "NotaDebito" Then
            ' "NBM04880" -> nota "M04880" (antes se quitaban todas las letras y no se encontraba)
            numero = ClaveCxC.NumeroNotaPagada(numero, "")
            sql = "SELECT TOP (1) DN.Descripcion FROM Detalle_Nota DN " &
                  "INNER JOIN IndiceNota I ON I.Numero_Nota = DN.Numero_Nota AND I.Fecha_Nota = DN.Fecha_Nota AND I.Tipo_Nota = DN.Tipo_Nota " &
                  "WHERE DN.Numero_Nota = @Numero AND DN.Fecha_Nota = @Fecha AND I.Cod_Cliente = @Cliente"
        ElseIf lineaFactura Then
            sql = "SELECT TOP (1) Descripcion_Producto FROM Detalle_Facturas " &
                  "WHERE Numero_Factura = @Numero AND Fecha_Factura = @Fecha AND Tipo_Factura = N'Factura'"
        Else
            Return ""
        End If

        Using cn As New SqlClient.SqlConnection(Conexion)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha.Date
                cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = If(CodigoClientes, "")
                Dim v As Object = cmd.ExecuteScalar()
                If v Is Nothing OrElse IsDBNull(v) Then Return ""
                Return Convert.ToString(v).Trim()
            End Using
        End Using
    End Function

    Private Function Celda(ByVal valor As Object, Optional ByVal siVacio As String = "") As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return siVacio
        Dim texto As String = CStr(valor).Trim()
        Return If(texto = "", siVacio, texto)
    End Function

    Private Function CeldaDecimal(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
        If Not TypeOf valor Is String Then Return DineroCxC.Redondear(Convert.ToDecimal(valor))
        Dim numero As Decimal
        If Decimal.TryParse(CStr(valor), numero) Then Return DineroCxC.Redondear(numero)
        Return 0D
    End Function


End Class