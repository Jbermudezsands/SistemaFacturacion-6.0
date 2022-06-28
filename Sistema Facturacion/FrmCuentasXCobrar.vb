Imports System.Math

Public Class FrmCuentasXCobrar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public DatasetReporte As New DataSet, ds As New DataSet

    Private Sub FrmCuentasXCobrar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ctas x Cobrar")
    End Sub

    Private Sub FrmCuentasXCobrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Cod_Cliente As Codigo, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion), SqlString As String = ""
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If




        Me.DTPFechaIni.Value = Now


        Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
        Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
        Me.TDGridImpuestos.Columns(3).Caption = "Cargo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 70
        Me.TDGridImpuestos.Columns(4).Caption = "Fecha Vence"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 73
        Me.TDGridImpuestos.Columns(5).Caption = "Abono"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
        Me.TDGridImpuestos.Columns(6).Caption = "Saldo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 70
        Me.TDGridImpuestos.Columns(7).Caption = "Moratorio"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
        Me.TDGridImpuestos.Columns(8).Caption = "Dias"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 40
        Me.TDGridImpuestos.Columns(9).Caption = "Total"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQlString As String, NumeroFactura As String, NumeroRecibo As String = "", MontoRecibo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, TasaCambio As Double, Saldo As Double
        Dim oDataRow As DataRow, MontoFactura As Double, FechaFactura As Date, Dias As Double, TasaInteres As Double, MontoMora As Double, Total As Double
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double, TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, FechaVence As Date, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        Dim MontoMetodoFactura As Double = 0, TipoNota As String = ""

        If Me.CboCodigoCliente.Text = "" Then
            Exit Sub
        End If


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        DataSet.Reset()
        DatasetReporte.Reset()
        SQlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.MetodoPago As Numero_Recibo, Facturas.Numero_Factura As NotaDebito, Facturas.SubTotal As MontoNota, Facturas.SubTotal As Monto, Facturas.Fecha_Factura As FechaVence, Facturas.IVA As Abono, Facturas.SubTotal AS Saldo, Facturas.SubTotal As Moratorio, Facturas.SubTotal As Dias, Facturas.SubTotal AS Total  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                    "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DatasetReporte, "TotalVentas")


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT *  FROM Facturas WHERE (MetodoPago = 'Credito') AND (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102))"
        SQlString = "SELECT *  FROM Facturas WHERE (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102))"
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
            NumeroRecibo = ""
            MontoRecibo = 0

            My.Application.DoEvents()


            If Me.OptCordobas.Checked = True Then
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
            FechaFactura = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            FechaVence = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            Me.Text = "Procesando Factura No " & NumeroFactura

            If NumeroFactura = "M36816" Then
                NumeroFactura = "M36816"
            End If

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
            '            "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"

            'SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE  (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente, DetalleRecibo.Fecha_Recibo HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
            'SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & CboCodigoCliente.Text & "')"

            SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (Recibo.Cod_Cliente = '" & CboCodigoCliente.Text & "') AND (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND " & _
                         "(DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') "

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
                    NumeroRecibo = NumeroRecibo & "," & DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                End If
                MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

                j = j + 1
            Loop

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (NotaDebito.Tipo LIKE '%Debito Clientes%') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaDB")
            Registros2 = DataSet.Tables("NotaDB").Rows.Count
            NumeroNota = ""
            j = 0
            MontoNota = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaDB").Rows(j)("Tipo")

                If Me.OptCordobas.Checked = True Then
                    If TipoNota <> "Debito Clientes Dif $" Then
                        If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                            TasaCambioRecibo = 1
                        Else

                            TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                            If TasaCambioRecibo <> 0 Then
                                TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
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
                MontoNota = MontoNota + DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo

                j = j + 1
            Loop

            DataSet.Tables("NotaDB").Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (NotaDebito.Tipo LIKE '%Credito Clientes%') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaCR")
            Registros2 = DataSet.Tables("NotaCR").Rows.Count
            NumeroNotaCR = ""
            j = 0
            MontoNotaCR = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")

                If Me.OptCordobas.Checked = True Then
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
                MontoNotaCR = MontoNotaCR + DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                'MontoNotaCR +

                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            Dim MontoDev As Double, TotalMontoDev As Double, NumeroDev As String
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN DEVOLUCION DE VENTAS PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.MetodoPago As Numero_Recibo, Facturas.Numero_Factura As NotaDebito, Facturas.SubTotal As MontoNota, Facturas.SubTotal As Monto, Facturas.Fecha_Factura As FechaVence, Facturas.IVA As Abono, Facturas.SubTotal AS Saldo, Facturas.SubTotal As Moratorio, Facturas.SubTotal As Dias, Facturas.SubTotal AS Total  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
            "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "DevVentas")
            Registros2 = DataSet.Tables("DevVentas").Rows.Count
            NumeroDev = ""
            j = 0
            MontoDev = 0
            TotalMontoDev = 0
            Do While Registros2 > j


                If Me.OptCordobas.Checked = True Then
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
                            TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
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
                'MontoNotaCR +
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("DevVentas").Reset()


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MontoMetodoFactura = 0
            SQlString = "SELECT * FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "')"
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






            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL INTERES MORATORIO PARA ESTE CLIENTE //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT  * FROM Clientes WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "DatosCliente")
            If Not DataSet.Tables("DatosCliente").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio")) Then
                    TasaInteres = (DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio") / 100)
                End If
            End If

            MontoFactura = Format((DataSet.Tables("Clientes").Rows(i)("SubTotal") + DataSet.Tables("Clientes").Rows(i)("IVA")) * TasaCambio, "##,##0.00")

            '///////////////////////////////////////REDONDEO PARA LA SUMA //////////////////////////////
            MontoFactura = Format(MontoFactura, "####0.00")
            TotalMontoNotaDB = Format(TotalMontoNotaDB, "####0.00")
            TotalMontoNotaCR = Format(TotalMontoNotaCR, "####0.00")
            MontoMetodoFactura = Format(MontoMetodoFactura, "####0.00")


            Dias = DateDiff(DateInterval.Day, FechaVence, Me.DTPFechaFin.Value)
            Saldo = MontoFactura - MontoRecibo + MontoNota - MontoNotaCR - MontoMetodoFactura
            If Format(Saldo, "##,##0.00") = "0.00" Then
                Dias = 0
            End If
            MontoMora = Dias * Saldo * TasaInteres
            Total = Saldo + MontoMora

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            oDataRow("Numero_Factura") = DataSet.Tables("Clientes").Rows(i)("Numero_Factura")
            oDataRow("Numero_Recibo") = NumeroRecibo
            If NumeroNota = "" Then
                If NumeroNotaCR <> "" Then
                    oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
                End If
            ElseIf NumeroNotaCR = "" Then
                If NumeroNota <> "" Then
                    oDataRow("NotaDebito") = "NB:" & NumeroNota
                End If
            Else
                oDataRow("NotaDebito") = "NC:" & NumeroNotaCR & " NB:" & NumeroNota
            End If
            oDataRow("Monto") = Format(MontoFactura, "##,##0.00")
            oDataRow("FechaVence") = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            oDataRow("Abono") = Format(MontoRecibo + MontoMetodoFactura, "##,##0.00")
            oDataRow("MontoNota") = Format(MontoNota - MontoNotaCR, "##,##0.00")
            oDataRow("Saldo") = Format(Saldo, "##,##0.00")
            oDataRow("Moratorio") = Format(MontoMora, "##,##0.00")
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(Total, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            If Me.OptCordobas.Checked = True Then
                ActualizaMontoCredito(DataSet.Tables("Clientes").Rows(i)("Numero_Factura"), DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"), Saldo, "Cordobas")
            Else
                ActualizaMontoCredito(DataSet.Tables("Clientes").Rows(i)("Numero_Factura"), DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"), Saldo, "Dolares")

            End If



            i = i + 1
            Me.ProgressBar.Value = i

            TotalFactura = TotalFactura + Saldo
            TotalAbonos = TotalAbonos + MontoRecibo
            TotalCargos = TotalCargos + MontoFactura
            TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota
            TotalMora = TotalMora + MontoMora
            DataSet.Tables("DatosCliente").Reset()
            DataSet.Tables("Recibos").Reset()
        Loop


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Debito Clientes%') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDB")
        Registros2 = DataSet.Tables("NotaDB").Rows.Count
        NumeroNota = ""
        j = 0
        MontoNota = 0
        Do While Registros2 > j

            TipoNota = DataSet.Tables("NotaDB").Rows(j)("Tipo")

            If Me.OptCordobas.Checked = True Then
                If TipoNota <> "Debito Clientes Dif $" Then
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
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
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            End If
            MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
            'TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            Dim Abono As Double = 0, AbonoNota As Double = 0

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA NOTA DE DEBITO ///////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If Me.OptCordobas.Checked = True Then
                Abono = MontoReciboNotas(NumeroNota, "Cordobas")
            Else
                Abono = MontoReciboNotas(NumeroNota, "Dolares")
            End If

            If CadenaRecibo = "" Then
                CadenaRecibo = "0000"
            End If

            RefNotaDebito = ""
            '////////////////////////////////////BUSCO SI EXISTEN NOTAS PARA LA NOTA DE DEBITO /////////////////////////
            If Me.OptCordobas.Checked = True Then
                AbonoNota = MontoNotaCreditoNota(NumeroNota, "Cordobas", Me.CboCodigoCliente.Text, NumeroNota)
            Else
                AbonoNota = MontoNotaCreditoNota(NumeroNota, "Dolares", Me.CboCodigoCliente.Text, NumeroNota)
            End If


            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"), Me.DTPFechaFin.Value)

            If Format(MontoNota - Abono, "##,##0.00") = "0.00" Then
                Dias = 0
            End If

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            oDataRow("Numero_Factura") = "0000"
            oDataRow("Numero_Recibo") = CadenaRecibo
            oDataRow("NotaDebito") = "NB:" & NumeroNota & RefNotaDebito
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            oDataRow("Abono") = Abono
            oDataRow("MontoNota") = Format(MontoNota, "##,##0.00")
            oDataRow("Saldo") = Format(MontoNota - Abono, "##,##0.00")
            oDataRow("Moratorio") = "0"
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(MontoNota - Abono, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)


            'TotalFactura = TotalFactura + MontoNota
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            j = j + 1
        Loop

        DataSet.Tables("NotaDB").Reset()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Credito Clientes%') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCR")
        Registros2 = DataSet.Tables("NotaCR").Rows.Count
        NumeroNotaCR = ""
        j = 0
        MontoNotaCR = 0
        Do While Registros2 > j

            TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")

            If Me.OptCordobas.Checked = True Then
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
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            End If

            If NumeroNotaCR = "" Then
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            Else
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            End If
            MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
            'TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR

            'MontoNotaCR +

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"), Me.DTPFechaFin.Value)

            If Format(TotalFactura - MontoNotaCR, "##,##0.00") = "0.00" Then
                Dias = 0
            End If

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            oDataRow("Numero_Factura") = "0000"
            oDataRow("Numero_Recibo") = "0000"
            oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            oDataRow("Abono") = "0"
            oDataRow("MontoNota") = Format(-1 * MontoNotaCR, "##,##0.00")
            oDataRow("Saldo") = Format(-1 * MontoNotaCR, "##,##0.00")
            oDataRow("Moratorio") = "0"
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(-1 * MontoNotaCR, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            TotalFactura = TotalFactura - MontoNotaCR

            j = j + 1
        Loop
        DataSet.Tables("NotaCR").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
        '            "HAVING (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"

        SQlString = "SELECT  DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, Recibo.MonedaRecibo FROM  DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') ORDER BY DetalleRecibo.Fecha_Recibo"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "RecibosSF")
        Registros2 = DataSet.Tables("RecibosSF").Rows.Count
        j = 0
        MontoRecibo = 0

        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("RecibosSF").Rows(j)("MonedaRecibo") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"))
                End If
            Else
                If DataSet.Tables("RecibosSF").Rows(j)("MonedaRecibo") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"))
                End If
            End If
            If NumeroRecibo = "" Then
                NumeroRecibo = DataSet.Tables("RecibosSF").Rows(j)("CodReciboPago")
            Else
                NumeroRecibo = DataSet.Tables("RecibosSF").Rows(j)("CodReciboPago")
            End If
            MontoRecibo = DataSet.Tables("RecibosSF").Rows(j)("MontoPagado") * TasaCambioRecibo

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"), Me.DTPFechaFin.Value)

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo")
            oDataRow("Numero_Factura") = "0000"
            oDataRow("Numero_Recibo") = NumeroRecibo
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo")
            oDataRow("Abono") = Format(MontoRecibo, "##,##0.00")
            oDataRow("MontoNota") = "0"
            oDataRow("Saldo") = Format(-1 * MontoRecibo, "##,##0.00")
            oDataRow("Moratorio") = "0"
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(-1 * MontoRecibo, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            TotalAbonos = TotalAbonos + MontoRecibo
            TotalFactura = TotalFactura - MontoRecibo
            j = j + 1
        Loop

        TotalFactura = TotalCargos - TotalAbonos + TotalMora + TotalMontoNotaDB - TotalMontoNotaCR

        Me.TxtCargos.Text = Format(TotalCargos, "##,##0.00")
        Me.TxtAbonos.Text = Format(TotalAbonos, "##,##0.00")
        Me.TxtMora.Text = Format(TotalMora, "##,##0.00")
        Me.TxtNB.Text = Format(TotalMontoNotaDB - TotalMontoNotaCR, "##,##0.00")
        Me.TxtSaldoFinal.Text = Format(TotalFactura, "##,##0.00")

        Me.Button1.Enabled = True
        Me.Button3.Enabled = True
        Me.Button5.Enabled = True
        Me.CmdAjustes.Enabled = True


        Me.TDGridImpuestos.DataSource = DatasetReporte.Tables("TotalVentas")
        Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
        Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
        Me.TDGridImpuestos.Columns(3).Caption = "DB/CR No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 80
        Me.TDGridImpuestos.Columns(4).Caption = "Monto NB/CR"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TDGridImpuestos.Columns(5).Caption = "Cargo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
        Me.TDGridImpuestos.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(6).Caption = "Fecha Vence"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 73
        Me.TDGridImpuestos.Columns(7).Caption = "Abono"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
        Me.TDGridImpuestos.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(8).Caption = "Saldo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 70
        Me.TDGridImpuestos.Columns(8).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(9).Caption = "Moratorio"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70
        Me.TDGridImpuestos.Columns(9).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(10).Caption = "Dias"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(10).Width = 40
        Me.TDGridImpuestos.Columns(11).Caption = "Total"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(11).Width = 70
        Me.TDGridImpuestos.Columns(11).NumberFormat = "##,##0.00"

    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged

        Dim SQL As String = "SELECT * FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")) Then
                Me.LblNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                Me.Button1.Enabled = False
                Me.Button3.Enabled = False
                Me.Button5.Enabled = False
                Me.CmdAjustes.Enabled = False
            End If

        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub OptDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptDolares.CheckedChanged
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub OptCordobas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCordobas.CheckedChanged
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ArepEstadoCuentas As New ArepEstadoCuentas
        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

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

        If Dir(RutaLogo) <> "" Then
            ArepEstadoCuentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If

        ArepEstadoCuentas.LblTitulo.Text = NombreEmpresa
        ArepEstadoCuentas.LblDireccion.Text = DireccionEmpresa
        ArepEstadoCuentas.LblRuc.Text = Ruc
        ArepEstadoCuentas.LblCodCliente.Text = Me.CboCodigoCliente.Text
        ArepEstadoCuentas.LblNombreCliente.Text = Me.LblNombres.Text

        If Me.OptCordobas.Checked = True Then
            ArepEstadoCuentas.LblMoneda.Text = "Cordobas"
        Else
            ArepEstadoCuentas.LblMoneda.Text = "Dolares"
        End If

        ArepEstadoCuentas.LblFecha.Text = Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
        ArepEstadoCuentas.LblCargo.Text = Me.TxtCargos.Text
        ArepEstadoCuentas.LblAbono.Text = Me.TxtAbonos.Text
        ArepEstadoCuentas.LblMora.Text = Me.TxtMora.Text
        ArepEstadoCuentas.LblSaldoFinal.Text = Me.TxtSaldoFinal.Text


        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepEstadoCuentas.Document
        My.Application.DoEvents()
        ArepEstadoCuentas.DataSource = DatasetReporte.Tables("TotalVentas")
        ArepEstadoCuentas.Run(False)
        ViewerForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If Len(Me.LblNombres.Text) > 29 Then
            My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
        Else
            My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
        End If

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
        Else
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
        End If
        My.Forms.FrmRegistroDebito.TipoNota = "Debito Clientes"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        If Me.TDGridImpuestos.Columns(0).Text <> "" Then
            My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        Else
            My.Forms.FrmRegistroDebito.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        End If
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE DEBITO"

        My.Forms.FrmRegistroDebito.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Len(Me.LblNombres.Text) > 29 Then
            My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
        Else
            My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
        End If

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
        Else
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
        End If
        My.Forms.FrmRegistroDebito.TipoNota = "Credito Clientes"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.NumeroFactura = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE CREDITO"
        My.Forms.FrmRegistroDebito.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmRecibos.TxtCodigoClientes.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRecibos.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        My.Forms.FrmRecibos.ShowDialog()
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub TDGridImpuestos_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles TDGridImpuestos.AfterFilter

    End Sub

    Private Sub TDGridImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.Click

    End Sub

    Private Sub TDGridImpuestos_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.ClientSizeChanged

    End Sub

    Private Sub TDGridImpuestos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TDGridImpuestos.MouseDown


        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Select Case Me.TDGridImpuestos.Col
                Case 2
                    If Me.TDGridImpuestos.Columns(2).Text = "" Then
                        Me.ContextMenuStripGrid.Items(0).Visible = False
                        Me.ContextMenuStripGrid.Items(1).Visible = True

                    Else
                        Me.ContextMenuStripGrid.Items(0).Visible = True
                        Me.ContextMenuStripGrid.Items(1).Visible = True

                    End If

                    Me.ContextMenuStripGrid.Items(2).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = False
                    Me.ContextMenuStripGrid.Items(4).Visible = False

                Case 3
                    Me.ContextMenuStripGrid.Items(0).Visible = False
                    Me.ContextMenuStripGrid.Items(1).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = True
                    Me.ContextMenuStripGrid.Items(4).Visible = True
                    Me.ContextMenuStripGrid.Items(2).Visible = True

                Case Else
                    Me.ContextMenuStripGrid.Items(0).Visible = False
                    Me.ContextMenuStripGrid.Items(1).Visible = False
                    Me.ContextMenuStripGrid.Items(2).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = False
                    Me.ContextMenuStripGrid.Items(4).Visible = False

            End Select



        End If
    End Sub

    Private Sub AnularNotasDeDebitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularNotasDeDebitoToolStripMenuItem.Click
        My.Forms.FrmAgregarRecibo.LblNombreCliente.Text = Me.LblNombres.Text
        My.Forms.FrmAgregarRecibo.LblNumeroFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmAgregarRecibo.TxtMontoRecibo.Text = Me.TDGridImpuestos.Columns(11).Text
        My.Forms.FrmAgregarRecibo.LblMontoFactura.Text = Me.TDGridImpuestos.Columns(11).Text
        My.Forms.FrmAgregarRecibo.DTPFecha.Value = Now

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmAgregarRecibo.MonedaRecibo = "Cordobas"
        Else
            My.Forms.FrmAgregarRecibo.MonedaRecibo = "Dolares"
        End If

        My.Forms.FrmAgregarRecibo.ShowDialog()


        'My.Forms.FrmRecibos.TxtCodigoClientes.Text = Me.CboCodigoCliente.Text
        'My.Forms.FrmRecibos.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        'My.Forms.FrmRecibos.ShowDialog()
        'CmdGrabar_Click(sender, e)




    End Sub

    Private Sub AsignarFacturaAlReciboToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaAlReciboToolStripMenuItem.Click

    End Sub

    Private Sub AnularNotasDeCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularNotasDeCreditoToolStripMenuItem.Click

    End Sub

    Private Sub ContextMenuStripGrid_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripGrid.Opening

    End Sub

    Private Sub AjustarDiferencialCambiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarDiferencialCambiarioToolStripMenuItem.Click
        Dim Consecutivo As Double = 0, SQlstring As String, TipoNota As String = "Credito Clientes", Monto As Double, Moneda As String, CodigoNota As String = "", Descripcion As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroNota As String = "", Consecutivoconserie As Boolean = True

        '/////////////////////////////////////////////////DIFERENCIAL CAMBIARIO AUTOMATICO ////////////////////////////

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        If Me.TDGridImpuestos.Columns(11).Text <> "" Then
            Monto = Me.TDGridImpuestos.Columns(11).Text
        Else
            Monto = 0
        End If

        Select Case Monto
            Case Is > 0 : TipoNota = "Credito Clientes"
            Case Is < 0 : TipoNota = "Debito Clientes"
            Case 0 : Exit Sub
        End Select

        If Me.OptCordobas.Checked = True Then
            Moneda = "Cordobas"
        Else
            Moneda = "Dolares"
        End If


        Select Case TipoNota
            Case "Credito Clientes"

                Quien = "CtasXcob"

                If Moneda = "Cordobas" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif C$')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                ElseIf Moneda = "Dolares" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif $')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                End If





                If Len(Me.LblNombres.Text) > 29 Then
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
                Else
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
                End If

                If Me.OptCordobas.Checked = True Then
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
                Else
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
                End If

                My.Forms.FrmRegistroDebito.TipoNota = "Credito Clientes"
                My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
                My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.NumeroFactura = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
                My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
                My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE CREDITO"
                My.Forms.FrmRegistroDebito.Codigo = CodigoNota
                My.Forms.FrmRegistroDebito.Monto = Monto
                My.Forms.FrmRegistroDebito.TxtObservaciones.Text = "Proceso AJUSTES AUTOMATICOS ZEUS"
                My.Forms.FrmRegistroDebito.ShowDialog()


            Case "Debito Clientes"


                Quien = "CtasXcob"

                If Moneda = "Cordobas" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif C$')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                ElseIf Moneda = "Dolares" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif $')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                End If

                If Len(Me.LblNombres.Text) > 29 Then
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
                Else
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
                End If

                If Me.OptCordobas.Checked = True Then
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
                Else
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
                End If
                My.Forms.FrmRegistroDebito.TipoNota = "Debito Clientes"
                My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
                My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
                My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
                My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE DEBITO"
                My.Forms.FrmRegistroDebito.Codigo = CodigoNota
                My.Forms.FrmRegistroDebito.Monto = Abs(Monto)
                My.Forms.FrmRegistroDebito.TxtObservaciones.Text = "Proceso AJUSTES AUTOMATICOS ZEUS"
                My.Forms.FrmRegistroDebito.ShowDialog()



        End Select





    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAjustes.Click

        If Me.OptCordobas.Checked = True Then
            FrmAjustes.OptCordobas.Checked = True
        Else
            FrmAjustes.OptDolares.Checked = True
        End If

        FrmAjustes.CboCodigoCliente.Text = Me.CboCodigoCliente.Text
        FrmAjustes.TxtNombre.Text = Me.LblNombres.Text
        FrmAjustes.DTPFechaIni.Value = Format(Now, "dd/MM/yyyy")
        FrmAjustes.DTPFechaFin.Value = Format(Now, "dd/MM/yyyy")
        FrmAjustes.ShowDialog()
    End Sub

    Private Sub AsignarFacturaALaNotaDeCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Click
        Dim Saldo As Double

        Saldo = Me.TDGridImpuestos.Columns("Saldo").Text

        If Saldo > 0 Then

            FrmAgregarNotaCredito.ds.Reset()
            FrmAgregarNotaCredito.ds = DatasetReporte.Copy

            FrmAgregarNotaCredito.Numero_Factura = Me.TDGridImpuestos.Columns(1).Text
            FrmAgregarNotaCredito.Fecha_Factura = Me.TDGridImpuestos.Columns(0).Text
            FrmAgregarNotaCredito.MontoFactura = Me.TDGridImpuestos.Columns("Saldo").Text
            FrmAgregarNotaCredito.TxtMontoRecibo.Text = Me.TDGridImpuestos.Columns("Saldo").Text

            If Me.OptCordobas.Checked = True Then
                FrmAgregarNotaCredito.MonedaEstado = "Cordobas"
            ElseIf Me.OptDolares.Checked = True Then
                FrmAgregarNotaCredito.MonedaEstado = "Dolares"
            End If


            FrmAgregarNotaCredito.ShowDialog()

            CmdGrabar_Click(sender, e)

        Else
            MsgBox("La Factura no tiene Saldo Pendiente", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If

    End Sub
End Class