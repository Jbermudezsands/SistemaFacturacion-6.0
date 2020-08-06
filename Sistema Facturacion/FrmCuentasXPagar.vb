Public Class FrmCuentasXPagar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public DatasetReporte As New DataSet

    Private Sub FrmCuentasXPagar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ctas x Pagar")
    End Sub
    Private Sub FrmCuentasXPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT  Cod_Proveedor, Nombre_Proveedor + ' ' + Apellido_Proveedor AS Nombres FROM Proveedor"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("Clientes")
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
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SQL As String = "SELECT Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & CboCodigoProveedor.Text & "') "
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Proveedores").Rows(0)("Nombre_Proveedor")) Then
                Me.LblNombres.Text = DataSet.Tables("Proveedores").Rows(0)("Nombre_Proveedor")
                Me.Button1.Enabled = False
                Me.Button3.Enabled = False
                Me.Button5.Enabled = False
            End If

        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQlString As String, NumeroFactura As String, NumeroRecibo As String = "", MontoRecibo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, TasaCambio As Double, Saldo As Double
        Dim oDataRow As DataRow, MontoFactura As Double, FechaFactura As Date, Dias As Double, TasaInteres As Double, MontoMora As Double, Total As Double
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double, TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, FechaVence As Date, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        Dim CodigoProveedor As String, TipoNota As String, Observaciones As String, MontoMetodoCompra As Double, Numero_Compra As String
        Dim H As Double

        If Me.CboCodigoProveedor.Text = "" Then
            Exit Sub
        End If


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        DataSet.Reset()
        DatasetReporte.Reset()
        SQlString = "SELECT Compras.Fecha_Compra As Fecha_Factura, Compras.Numero_Compra As Numero_Factura, Compras.Numero_Compra As Numero_Recibo, Compras.Numero_Compra As NotaDebito, Compras.SubTotal As MontoNota, Compras.SubTotal As Monto, Compras.Fecha_Compra As FechaVence, Compras.IVA As Abono, Compras.SubTotal AS Saldo, Compras.SubTotal As Moratorio, Compras.SubTotal As Dias, Compras.SubTotal AS Total, Compras.Observaciones   FROM Compras INNER JOIN Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor  " & _
                    "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta')  AND (Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Compras.Fecha_Compra, Compras.Numero_Compra"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DatasetReporte, "TotalVentas")


        CodigoProveedor = Me.CboCodigoProveedor.Text
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////cod
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT DISTINCT CASE WHEN Detalle_MetodoCompras.Monto = Compras.SubTotal + Compras.IVA THEN 'Contado' ELSE 'Credito' END AS MetodoPago, Compras.* FROM Compras LEFT OUTER JOIN Detalle_MetodoCompras ON Compras.Numero_Compra = Detalle_MetodoCompras.Numero_Compra AND Compras.Fecha_Compra = Detalle_MetodoCompras.Fecha_Compra And Compras.Tipo_Compra = Detalle_MetodoCompras.Tipo_Compra  " & _
                    "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta')  AND (Compras.Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') AND (CASE WHEN Detalle_MetodoCompras.Monto = Compras.SubTotal + Compras.IVA THEN 'Contado' ELSE 'Credito' END = 'Credito') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        Registros = DataSet.Tables("Proveedores").Rows.Count
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
        Me.ProgressBar.Maximum = DataSet.Tables("Proveedores").Rows.Count
        Do While Registros > i
            NumeroRecibo = ""
            MontoRecibo = 0

            My.Application.DoEvents()

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("Proveedores").Rows(i)("MonedaCompra") = "Cordobas" Then
                    TasaCambio = 1
                Else
                    TasaCambio = BuscaTasaCambio(DataSet.Tables("Proveedores").Rows(i)("Fecha_Compra"))
                End If
            Else
                If DataSet.Tables("Proveedores").Rows(i)("MonedaCompra") = "Dolares" Then
                    TasaCambio = 1
                Else
                    TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("Proveedores").Rows(i)("Fecha_Compra"))
                End If
            End If

            'NumeroFactura = DataSet.Tables("Proveedores").Rows(i)("Numero_Compra") Su_Referencia
            If Not IsDBNull(DataSet.Tables("Proveedores").Rows(i)("Su_Referencia")) Then
                NumeroFactura = DataSet.Tables("Proveedores").Rows(i)("Su_Referencia")
            Else
                NumeroFactura = DataSet.Tables("Proveedores").Rows(i)("Numero_Compra")
            End If

            Numero_Compra = DataSet.Tables("Proveedores").Rows(i)("Numero_Compra")

            If Not IsDBNull(DataSet.Tables("Proveedores").Rows(i)("Observaciones")) Then
                Observaciones = DataSet.Tables("Proveedores").Rows(i)("Observaciones")
            End If

            FechaFactura = DataSet.Tables("Proveedores").Rows(i)("Fecha_Compra")
            FechaVence = DataSet.Tables("Proveedores").Rows(i)("Fecha_Vencimiento")
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo " & _
            '            "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "')"


            SQlString = "SELECT * FROM  ReciboPago INNER JOIN DetalleReciboPago ON ReciboPago.CodReciboPago = DetalleReciboPago.CodReciboPago AND ReciboPago.Fecha_Recibo = DetalleReciboPago.Fecha_Recibo WHERE (DetalleReciboPago.Numero_Compra = '" & Numero_Compra & "')"
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
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Debito Proveedores') AND (Detalle_Nota.Numero_Factura = '" & Numero_Compra & "')"

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
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Proveedores') AND (Detalle_Nota.Numero_Factura = '" & Numero_Compra & "')"

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
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
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
                MontoNotaCR = MontoNotaCR + DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL INTERES MORATORIO PARA ESTE CLIENTE //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  * FROM Clientes WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DatosCliente")
            'If Not DataSet.Tables("DatosCliente").Rows.Count = 0 Then
            '    If Not IsDBNull(DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio")) Then
            '        TasaInteres = (DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio") / 100)
            '    End If
            'End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS COMPRAS DE CONTADO //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MontoMetodoCompra = 0
            SQlString = "SELECT * FROM Detalle_MetodoCompras INNER JOIN MetodoPago ON Detalle_MetodoCompras.NombrePago = MetodoPago.NombrePago WHERE (Detalle_MetodoCompras.Tipo_Compra = 'Mercancia Recibida') AND (Detalle_MetodoCompras.Numero_Compra = '" & Numero_Compra & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "MetodoCompra")

            j = 0
            Do While DataSet.Tables("MetodoCompra").Rows.Count > j
                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("MetodoCompra").Rows(j)("Moneda") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("MetodoCompra").Rows(j)("Fecha_Compra"))
                    End If
                Else
                    If DataSet.Tables("MetodoCompra").Rows(j)("Moneda") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("MetodoCompra").Rows(j)("Fecha_Compra"))
                    End If
                End If

                MontoMetodoCompra = MontoMetodoCompra + DataSet.Tables("MetodoCompra").Rows(j)("Monto") * TasaCambioRecibo

                j = j + 1
            Loop
            DataSet.Tables("MetodoCompra").Reset()



            MontoFactura = (DataSet.Tables("Proveedores").Rows(i)("SubTotal") + DataSet.Tables("Proveedores").Rows(i)("IVA")) * TasaCambio
            Dias = DateDiff(DateInterval.Day, FechaVence, Me.DTPFechaFin.Value)
            Saldo = MontoFactura - MontoRecibo + MontoNota - MontoNotaCR - MontoMetodoCompra
            If Format(Saldo, "##,##0.00") = "0.00" Then
                Dias = 0
            End If
            MontoMora = Dias * Saldo * TasaInteres
            Total = Saldo + MontoMora

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("Proveedores").Rows(i)("Fecha_Compra")
            oDataRow("Numero_Factura") = NumeroFactura
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
            oDataRow("FechaVence") = DataSet.Tables("Proveedores").Rows(i)("Fecha_Vencimiento")
            oDataRow("Abono") = Format(MontoRecibo + MontoMetodoCompra, "##,##0.00")
            oDataRow("MontoNota") = Format(MontoNota - MontoNotaCR, "##,##0.00")
            oDataRow("Saldo") = Format(Saldo, "##,##0.00")
            oDataRow("Moratorio") = Format(MontoMora, "##,##0.00")
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(Total, "##,##0.00")
            oDataRow("Observaciones") = Observaciones
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            i = i + 1
            Me.ProgressBar.Value = i

            TotalFactura = TotalFactura + Saldo
            TotalAbonos = TotalAbonos + MontoRecibo
            TotalCargos = TotalCargos + MontoFactura
            TotalMora = TotalMora + MontoMora
            'DataSet.Tables("DatosCliente").Reset()
            DataSet.Tables("Recibos").Reset()
        Loop

        '--------------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------------------

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN COMPRAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Debito Proveedores%') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoProveedor.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"
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
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            Dim Abono As Double = 0
            If Me.OptCordobas.Checked = True Then
                Abono = MontoReciboNotas(NumeroNota, "Cordobas")
            Else
                Abono = MontoReciboNotas(NumeroNota, "Dolares")
            End If

            If CadenaRecibo = "" Then
                CadenaRecibo = "0000"
            End If

            '////////////////////////////////////CREO LA LISTA DE RECIBOS /////////////////////////


            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"), Me.DTPFechaFin.Value)

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            oDataRow("Numero_Factura") = "0000"
            oDataRow("Numero_Recibo") = CadenaRecibo
            oDataRow("NotaDebito") = "NB:" & NumeroNota
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            oDataRow("Abono") = Abono
            oDataRow("MontoNota") = Format(-1 * MontoNota, "##,##0.00")
            oDataRow("Saldo") = Format(-1 * MontoNota, "##,##0.00")
            oDataRow("Moratorio") = "0"
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(-1 * MontoNota, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)


            TotalFactura = TotalFactura + MontoNota

            j = j + 1
        Loop


        DataSet.Tables("NotaDB").Reset()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Credito Proveedores%') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoProveedor.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCR")
        Registros2 = DataSet.Tables("NotaCR").Rows.Count
        NumeroNotaCR = ""
        j = 0
        MontoNotaCR = 0
        Do While Registros2 > j

            TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")

            If Me.OptCordobas.Checked = True Then
                If TipoNota <> "Credito Proveedores Dif $" Then
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            Else
                If TipoNota <> "Credito Proveedores Dif C$" Then
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
            TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR

            'MontoNotaCR +

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"), Me.DTPFechaFin.Value)

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            oDataRow("Numero_Factura") = "0000"
            oDataRow("Numero_Recibo") = "0000"
            oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            oDataRow("Abono") = "0"
            oDataRow("MontoNota") = Format(MontoNotaCR, "##,##0.00")
            oDataRow("Saldo") = Format(MontoNotaCR, "##,##0.00")
            oDataRow("Moratorio") = "0"
            oDataRow("Dias") = Dias
            oDataRow("Total") = Format(MontoNotaCR, "##,##0.00")
            DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            TotalFactura = TotalFactura - MontoNotaCR

            j = j + 1
        Loop
        DataSet.Tables("NotaCR").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT  ReciboPago.CodReciboPago, ReciboPago.Fecha_Recibo, DetalleReciboPago.Numero_Compra, DetalleReciboPago.MontoPagado, ReciboPago.MonedaRecibo FROM ReciboPago INNER JOIN DetalleReciboPago ON ReciboPago.CodReciboPago = DetalleReciboPago.CodReciboPago AND ReciboPago.Fecha_Recibo = DetalleReciboPago.Fecha_Recibo WHERE (DetalleReciboPago.Numero_Compra = '0') AND (ReciboPago.Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY ReciboPago.Fecha_Recibo"
        'SQlString = "SELECT  DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, Recibo.MonedaRecibo FROM  DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoProveedor.Text & "') ORDER BY DetalleRecibo.Fecha_Recibo"
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


        NumeroRecibo = ""
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN DEVOLUCIONES DE COMPRA//////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN Detalle_MetodoCompras.Monto = Compras.SubTotal + Compras.IVA THEN 'Contado' ELSE 'Credito' END AS MetodoPago, Detalle_MetodoCompras.Monto, Compras.* FROM Compras LEFT OUTER JOIN Detalle_MetodoCompras ON Compras.Numero_Compra = Detalle_MetodoCompras.Numero_Compra AND Compras.Fecha_Compra = Detalle_MetodoCompras.Fecha_Compra And Compras.Tipo_Compra = Detalle_MetodoCompras.Tipo_Compra  " & _
                           "WHERE  (Compras.Tipo_Compra = 'Devolucion de Compra')  AND (Compras.Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') AND (CASE WHEN Detalle_MetodoCompras.Monto = Compras.SubTotal + Compras.IVA THEN 'Contado' ELSE 'Credito' END = 'Credito') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Devoluciones")
        Registros2 = DataSet.Tables("Devoluciones").Rows.Count
        j = 0
        MontoRecibo = 0

        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("Devoluciones").Rows(j)("MonedaCompra") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Devoluciones").Rows(j)("Fecha_Compra"))
                End If
            Else
                If DataSet.Tables("Devoluciones").Rows(j)("MonedaCompra") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Devoluciones").Rows(j)("Fecha_Compra"))
                End If
            End If
            If NumeroRecibo = "" Then
                NumeroRecibo = DataSet.Tables("Devoluciones").Rows(j)("Numero_Compra")
            Else
                NumeroRecibo = DataSet.Tables("Devoluciones").Rows(j)("Numero_Compra")
            End If
            MontoRecibo = DataSet.Tables("Devoluciones").Rows(j)("NetoPagar") * TasaCambioRecibo

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("Devoluciones").Rows(j)("Fecha_Compra"), Me.DTPFechaFin.Value)

            oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            oDataRow("Fecha_Factura") = DataSet.Tables("Devoluciones").Rows(j)("Fecha_Compra")
            oDataRow("Numero_Factura") = NumeroRecibo
            oDataRow("Numero_Recibo") = " "
            oDataRow("Monto") = "0"
            oDataRow("FechaVence") = DataSet.Tables("Devoluciones").Rows(j)("Fecha_Compra")
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



        Me.TxtCargos.Text = Format(TotalCargos, "##,##0.00")
        Me.TxtAbonos.Text = Format(TotalAbonos + MontoMetodoCompra, "##,##0.00")
        Me.TxtMora.Text = Format(TotalMora, "##,##0.00")
        Me.TxtNB.Text = Format(TotalMontoNotaDB - TotalMontoNotaCR, "##,##0.00")
        Me.TxtSaldoFinal.Text = Format(TotalFactura, "##,##0.00")

        Me.Button1.Enabled = True
        Me.Button3.Enabled = True
        Me.Button5.Enabled = True


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
        My.Forms.FrmRegistroDebito.TipoNota = "Debito Proveedores"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoProveedor.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE DEBITO PROVEEDORES"

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
        My.Forms.FrmRegistroDebito.TipoNota = "Credito Proveedores"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.NumeroFactura = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoProveedor.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE CREDITO PROVEEDOR"
        My.Forms.FrmRegistroDebito.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmPagos.TxtCodigoProveedor.Text = Me.CboCodigoProveedor.Text
        My.Forms.FrmPagos.ShowDialog()
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
        ArepEstadoCuentas.LblCodCliente.Text = Me.CboCodigoProveedor.Text
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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class