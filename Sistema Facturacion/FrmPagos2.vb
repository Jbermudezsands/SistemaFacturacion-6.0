Public Class FrmPagos2
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
    Private Function CalcularRetencion() As Double
        Dim Registros As Double, iPosicion As Double, NumeroCompra As String, MontoPagado As Double, MontoCredito As Double
        Dim Impuesto As Double, SQlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SubTotal As Double = 0, Iva As Double = 0, Ret10 As Double, Ret2 As Double, Ret1 As Double, Ret7 As Double, Retencion As Double = 0
        Dim TotalRetencion As Double = 0

        Me.BindingFacturas.MoveFirst()
        Registros = Me.TrueDBGridComponentes.RowCount
        iPosicion = 0


        If Me.OptRet10Porciento.Checked = True Then
            Ret10 = 0.1
        Else
            Ret10 = 0
        End If

        If Me.OptRet1Porciento.Checked = True Then
            Ret1 = 0.01
        Else
            Ret1 = 0
        End If


        If Me.OptRet2Porciento.Checked = True Then
            Ret2 = 0.02
        Else
            Ret2 = 0
        End If


        If Me.OptRet7Porciento.Checked = True Then
            Ret7 = 0.07
        Else
            Ret7 = 0
        End If

        TotalRetencion = 0

        Do While iPosicion < Registros
            NumeroCompra = Me.TrueDBGridComponentes.Item(iPosicion)("Numero_Compra")
            Retencion = 0

            If Not IsDBNull(Me.TrueDBGridComponentes.Item(iPosicion)("MontoPagado")) Then
                MontoPagado = Me.TrueDBGridComponentes.Item(iPosicion)("MontoPagado")

                If MontoPagado > 0 Then

                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        '/////////////////////////////BUSCO EL SUBTOTAL DE LA COMPRA SIN IMPUESTO //////////////////////////////
                        SQlString = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN SubTotal ELSE SubTotal * TasaCambio.MontoTasa END, 2) AS SubTotal, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN IVA ELSE IVA * TasaCambio.MontoTasa END, 2) AS IVA FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                                    "WHERE (Compras.Tipo_Compra = 'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (Compras.Numero_Compra = '" & NumeroCompra & "') OR (Compras.Tipo_Compra = 'Cuenta')"
                    Else
                        '/////////////////////////////BUSCO EL SUBTOTAL DE LA COMPRA SIN IMPUESTO //////////////////////////////
                        SQlString = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN SubTotal ELSE SubTotal / TasaCambio.MontoTasa END, 2) AS SubTotal, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN IVA ELSE IVA / TasaCambio.MontoTasa END, 2) AS IVA FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                                    "WHERE (Compras.Tipo_Compra = 'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (Compras.Numero_Compra = '" & NumeroCompra & "') OR (Compras.Tipo_Compra = 'Cuenta')"
                    End If
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Compras")
                    If DataSet.Tables("Compras").Rows.Count <> 0 Then
                        SubTotal = DataSet.Tables("Compras").Rows(0)("SubTotal")
                        Iva = DataSet.Tables("Compras").Rows(0)("IVA")
                        Retencion = SubTotal * (Ret1 + Ret2 + Ret7 + Ret10)
                    End If

                    MontoCredito = Me.TrueDBGridComponentes.Item(iPosicion)("Saldo")

                    '///////////////////////SI QUEDA SALDO SIGNIFICA QUE ES UN PAGO PARCIAL//////////////////////////////////////
                    If MontoCredito <> 0 Then
                        'MsgBox("Si realiza un Pago Parcial, el calculo es Proporcional!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                        If MontoPagado < SubTotal Then
                            Retencion = MontoPagado * (Ret1 + Ret2 + Ret7 + Ret10)
                            Me.TrueDBGridComponentes.Item(iPosicion)("Retencion") = Retencion
                            Me.TrueDBGridComponentes.Item(iPosicion)("NetoPagar") = Me.TrueDBGridComponentes.Item(iPosicion)("Saldo") - Retencion
                        End If
                    End If

                End If
            Else
                MontoPagado = 0
                Me.TrueDBGridComponentes.Item(iPosicion)("Retencion") = 0
                Me.TrueDBGridComponentes.Item(iPosicion)("NetoPagar") = Me.TrueDBGridComponentes.Item(iPosicion)("Saldo")
            End If



            TotalRetencion = TotalRetencion + Retencion
            iPosicion = iPosicion + 1
        Loop


        CalcularRetencion = TotalRetencion
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub FrmPagos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Pagos")
    End Sub
    Private Sub FrmPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String



        Me.DTPFecha.Value = Now



        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        MiConexion.Close()


        'If Me.TxtMonedaFactura.Text = "Cordobas" Then
        '    'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
        '    '               "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') OR (Compras.Tipo_Compra = 'Cuenta')"

        '    SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
        '                   "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '-1000') OR (Compras.Tipo_Compra = 'Cuenta')"
        'Else
        '    'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
        '    '                "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') Or (Compras.Tipo_Compra = 'Cuenta')"
        '    SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
        '                                 "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '-10000') OR (Compras.Tipo_Compra = 'Cuenta')"
        'End If

        'MiConexion.Open()
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        'DataAdapter.Fill(DataSet, "Consultas")
        'Me.BindingFacturas.DataSource = DataSet.Tables("Consultas")
        'Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas

        'Me.TrueDBGridComponentes.Columns(0).Caption = "Compra No"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 63

        'Me.TrueDBGridComponentes.Columns("Fecha_Compra").Caption = "Fecha"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Width = 63

        'Me.TrueDBGridComponentes.Columns("MontoCredito").Caption = "Monto Credito"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("MontoCredito").Width = 100

        'Me.TrueDBGridComponentes.Columns("MontoPagado").Caption = "Monto Pagado"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("MontoPagado").Width = 100

        'Me.TrueDBGridComponentes.Columns("Saldo").Caption = "Saldo"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Saldo").Width = 100

        'Me.TrueDBGridComponentes.Columns("Retencion").Caption = "Retencion"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Retencion").Width = 63

        'Me.TrueDBGridComponentes.Columns("NetoPagar").Caption = "NetoPagar"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NetoPagar").Width = 100

    End Sub

    Private Sub TxtCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
            End If
            Me.TrueDBGridComponentes.Enabled = True

            MiConexion.Close()

            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                '               "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') OR (Compras.Tipo_Compra = 'Cuenta')"

                SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                               "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
            Else
                'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                '                "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') Or (Compras.Tipo_Compra = 'Cuenta')"
                SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                                             "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
            End If

            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "FactConsultas")
            Me.BindingFacturas.DataSource = DataSet.Tables("FactConsultas")
            Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas.DataSource

            Me.TrueDBGridComponentes.Columns(0).Caption = "Compra No"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 63

            Me.TrueDBGridComponentes.Columns("Fecha_Compra").Caption = "Fecha"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Width = 63

            Me.TrueDBGridComponentes.Columns("MontoCredito").Caption = "Monto Credito"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("MontoCredito").Width = 100

            Me.TrueDBGridComponentes.Columns("MontoPagado").Caption = "Monto Pagado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("MontoPagado").Width = 100

            Me.TrueDBGridComponentes.Columns("Saldo").Caption = "Saldo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Saldo").Width = 100

            Me.TrueDBGridComponentes.Columns("Retencion").Caption = "Retencion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Retencion").Width = 63

            Me.TrueDBGridComponentes.Columns("NetoPagar").Caption = "NetoPagar"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NetoPagar").Width = 100

        Else

            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TrueDBGridComponentes.Enabled = False

        End If
    End Sub

    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate
        Dim Saldo As Double, MontoCredito As Double, MontoAplicado As Double, Retencion As Double, NetoPagar As Double

        If Me.TrueDBGridComponentes.Columns("MontoCredito").Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns("MontoCredito").Text)
        End If

        If Me.TrueDBGridComponentes.Columns("MontoPagado").Text = "" Then
            MontoAplicado = 0
        Else
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns("MontoPagado").Text)
        End If


        Saldo = MontoCredito - MontoAplicado
        Me.TrueDBGridComponentes.Columns(4).Text = Format(Saldo, "##,##0.00")


        Retencion = 0
        If Me.TrueDBGridComponentes.Columns("Retencion").Text <> "" Then
            Retencion = CDbl(Me.TrueDBGridComponentes.Columns("Retencion").Text)
        End If

        NetoPagar = Saldo - Retencion


        Me.TrueDBGridComponentes.Columns("NetoPagar").Text = Format(NetoPagar, "##,##0.00")

    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        ActualizaMETODOPagosProveedores(Me.TxtMonedaFactura.Text)
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim MontoCredito As Double, MontoAplicado As Double

        If Me.TrueDBGridComponentes.Columns(2).Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns(2).Text)
        End If

        If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
            MontoAplicado = 0
        ElseIf IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        Else
            MsgBox("Monto a Pagar espera un Numero", MsgBoxStyle.Critical, "Zeus Facturacion")
            Me.TrueDBGridComponentes.Columns(3).Text = ""
        End If

        If MontoCredito < MontoAplicado Then
            MsgBox("No se puede Pagar mas del Monto facturado", MsgBoxStyle.Critical, "Sistema Facturacion")
            Me.TrueDBGridComponentes.Columns(3).Text = 0
            MontoAplicado = 0
        End If
    End Sub

    Private Sub TrueDBGridMetodo_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.AfterUpdate
        ActualizaMETODOPagosProveedores(Me.TxtMonedaFactura.Text)
    End Sub

    Private Sub TrueDBGridMetodo_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridMetodo.ButtonClick
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TrueDBGridMetodo.Columns(0).Text = Metodo
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        Dim SubTotal As Double, Descuento As Double

        Descuento = 0
        SubTotal = 0


        If Me.TxtDescuento.Text <> "" Then
            If IsNumeric(Me.TxtDescuento.Text) Then
                Descuento = Me.TxtDescuento.Text
            Else
                Me.TxtDescuento.Text = ""
                Descuento = 0
            End If
        End If

        If Me.TxtSubTotal.Text <> "" Then
            SubTotal = Me.TxtSubTotal.Text
        End If

        Me.TxtNetoPagar.Text = Format(SubTotal - Descuento, "##,##0.00")
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim ConsecutivoPago As Double, NumeroCompra As String, Registros As Double, iPosicion As Double
        Dim NumeroPago As String, MontoPagado As Double, MontoCredito As Double, Descuento As Double
        Dim ArepPagoProveedores As New ArepPagoProveedores, RutaLogo As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SQlPagos As String
        Dim Cadena As String, NombrePago As String, Filtro As String, SubTotal As Double, Ret1 As Double, Ret2 As Double, Ret7 As Double, Ret10 As Double
        Dim Retencion As Double

        If IsDBNull(Me.BindingMetodo.Item(iPosicion)("Monto")) Then
            MsgBox("Es neceario completar el Metodo de Pago", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            ConsecutivoPago = BuscaConsecutivo("Pago_Proveedor")
        Else
            ConsecutivoPago = Me.TxtNumeroEnsamble.Text
        End If
        NumeroPago = Format(ConsecutivoPago, "0000#")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LOS PAGOS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaPagos(NumeroPago)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingFacturas.MoveFirst()
        Registros = Me.BindingFacturas.Count
        iPosicion = 0

        Do While iPosicion < Registros
            NumeroCompra = Me.BindingFacturas.Item(iPosicion)("Numero_Compra")
            If Not IsDBNull(Me.BindingFacturas.Item(iPosicion)("MontoPagado")) Then
                MontoPagado = Me.BindingFacturas.Item(iPosicion)("MontoPagado")
            Else
                MontoPagado = 0
            End If

            If Not IsDBNull(Me.BindingFacturas.Item(iPosicion)("Retencion")) Then
                Retencion = Me.BindingFacturas.Item(iPosicion)("Retencion")
            Else
                Retencion = 0
            End If


            MontoCredito = Me.BindingFacturas.Item(iPosicion)("Saldo")
            If MontoPagado <> 0 Then
                GrabaDetallePagos(NumeroPago, NumeroCompra, MontoPagado, Retencion)
                ActualizaMontoCreditoCompra(NumeroCompra, MontoCredito, Me.TxtMonedaFactura.Text)
            End If
            iPosicion = iPosicion + 1


            '/////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////CALCULO LAS RETENCIONES //////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////
            'If Me.OptRet1Porciento.Checked = True Or Me.OptRet2Porciento.Checked = True Or Me.OptRet7Porciento.Checked = True Or Me.OptRet10Porciento.Checked = True Then
            '    '////////////////////////////////////CONSULTO EL SUBTOTAL SIN EL IVA DE LA COMPRA //////////////////////////////////
            '    If Me.TxtMonedaFactura.Text = "Cordobas" Then
            '        MiConexion.Close()
            '        'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, Compras.MontoCredito,  DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, Compras.MontoCredito AS Saldo FROM  DetalleReciboPago FULL OUTER JOIN Compras ON DetalleReciboPago.Numero_Compra = Compras.Numero_Compra WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            '        SqlDatos = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN SubTotal ELSE SubTotal * TasaCambio.MontoTasa END, 2) AS SubTotal, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN IVA ELSE IVA * TasaCambio.MontoTasa END, 2) AS IVA FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
            '                       "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (Compras.Numero_Compra = '" & NumeroCompra & "')"
            '        MiConexion.Open()
            '        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            '        DataAdapter.Fill(DataSet, "Consultas")
            '        Me.BindingFacturas.DataSource = DataSet.Tables("Consultas")
            '        Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas

            '    Else
            '        MiConexion.Close()
            '        'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, Compras.MontoCredito,  DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, Compras.MontoCredito AS Saldo FROM  DetalleReciboPago FULL OUTER JOIN Compras ON DetalleReciboPago.Numero_Compra = Compras.Numero_Compra WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            '        SqlDatos = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN SubTotal ELSE SubTotal / TasaCambio.MontoTasa END, 2) AS SubTotal, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN IVA ELSE IVA / TasaCambio.MontoTasa END, 2) AS IVA FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
            '                       "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (Compras.Numero_Compra = '" & NumeroCompra & "')"
            '        MiConexion.Open()
            '        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            '        DataAdapter.Fill(DataSet, "Consultas")
            '        Me.BindingFacturas.DataSource = DataSet.Tables("Consultas")
            '        Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas
            '    End If



            '    If Me.OptRet1Porciento.Checked = True Then
            '        If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("SubTotal")) Then
            '            Ret1 = DataSet.Tables("Consultas").Rows(0)("SubTotal") * 0.01
            '        End If
            '    End If

            '    If Me.OptRet2Porciento.Checked = True Then
            '        If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("SubTotal")) Then
            '            Ret2 = DataSet.Tables("Consultas").Rows(0)("SubTotal") * 0.02
            '        End If
            '    End If

            '    If Me.OptRet7Porciento.Checked = True Then
            '        If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("SubTotal")) Then
            '            Ret7 = DataSet.Tables("Consultas").Rows(0)("SubTotal") * 0.07
            '        End If
            '    End If

            '    If Me.OptRet10Porciento.Checked = True Then
            '        If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("SubTotal")) Then
            '            Ret10 = DataSet.Tables("Consultas").Rows(0)("SubTotal") * 0.1
            '        End If
            '    End If

            'End If





        Loop

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO METODO DE PAGO /////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        NombrePago = ""

        Do While iPosicion < Registros
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("Monto")) Then
                If iPosicion <> 0 Then
                    MontoPagado = MontoPagado + Me.BindingMetodo.Item(iPosicion)("Monto")
                    Cadena = NombrePago & " $" & MontoPagado
                    GrabaMetodoDetallePago(NumeroPago, NombrePago, MontoPagado)
                Else
                    MontoPagado = Me.BindingMetodo.Item(iPosicion)("Monto")
                    NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
                    GrabaMetodoDetallePago(NumeroPago, NombrePago, MontoPagado)
                End If

            Else
                MontoPagado = 0
            End If
            iPosicion = iPosicion + 1
        Loop

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ArepPagoProveedores.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepPagoProveedores.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepPagoProveedores.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepPagoProveedores.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If

        End If

        Me.TxtNumeroEnsamble.Text = NumeroPago
        ArepPagoProveedores.LblCodProveedor.Text = Me.TxtCodigoProveedor.Text
        ArepPagoProveedores.LblNombres.Text = Me.TxtNombres.Text
        ArepPagoProveedores.LblApellidos.Text = Me.TxtApellidos.Text
        ArepPagoProveedores.LblDireccionProveedor.Text = Me.TxtDireccion.Text
        ArepPagoProveedores.LblTelefono.Text = Me.TxtTelefono.Text
        ArepPagoProveedores.LblOrden.Text = NumeroPago
        ArepPagoProveedores.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")

        'Filtro = "Numero_Compra = '00050'"
        'Me.BindingFacturas.Filter = Filtro

        'SQlPagos = "SELECT DISTINCT  Compras.Numero_Compra, Compras.Fecha_Compra, DetalleReciboPago.MontoPagado + Compras.MontoCredito As MontoCredito, DetalleReciboPago.MontoPagado, Compras.MontoCredito AS Saldo, DetalleReciboPago.CodReciboPago FROM DetalleReciboPago FULL OUTER JOIN Compras ON DetalleReciboPago.Numero_Compra = Compras.Numero_Compra  " & _
        '           "WHERE (Compras.Tipo_Compra = 'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (DetalleReciboPago.CodReciboPago = '" & NumeroPago & "')"
        'SQL.ConnectionString = Conexion
        'SQL.SQL = SQlPagos

        ArepPagoProveedores.DataSource = Me.BindingFacturas.DataSource
        ArepPagoProveedores.Document.Name = "SOLICITUD DE PAGO PROVEEDORES"

        If Me.TxtDescuento.Text = "" Then
            Descuento = 0
        Else
            Descuento = Me.TxtDescuento.Text
        End If

        'Descuento = Ret1 + Ret2 + Ret7 + Ret10

        ArepPagoProveedores.ChkRetencion1.Checked = Me.OptRet1Porciento.Checked
        ArepPagoProveedores.ChkRetencion2.Checked = Me.OptRet2Porciento.Checked
        ArepPagoProveedores.ChkRetencion3.Checked = Me.OptRet7Porciento.Checked
        ArepPagoProveedores.ChkRetencion4.Checked = Me.OptRet10Porciento.Checked

        ArepPagoProveedores.LblSubTotal.Text = Me.TxtSubTotal.Text
        ArepPagoProveedores.LblDescuento.Text = Format(Descuento, "##,##0.00")
        ArepPagoProveedores.LblPagado.Text = Me.TxtNetoPagar.Text
        ArepPagoProveedores.DataSource = SQL
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepPagoProveedores.Document
        ViewerForm.Show()
        ArepPagoProveedores.Run(False)
        'ArepPagoProveedores.Show()

        LimpiaPago()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaPago()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Pagos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.CodigoProveedor
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub OptRet1Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet1Porciento.CheckedChanged
        Me.TxtDescuento.Text = Format(CalcularRetencion(), "##,##0.00")
    End Sub

    Private Sub OptRet7Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet7Porciento.CheckedChanged
        Me.TxtDescuento.Text = Format(CalcularRetencion(), "##,##0.00")
    End Sub

    Private Sub OptRet2Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet2Porciento.CheckedChanged
        Me.TxtDescuento.Text = Format(CalcularRetencion(), "##,##0.00")
    End Sub

    Private Sub OptRet10Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet10Porciento.CheckedChanged
        Me.TxtDescuento.Text = Format(CalcularRetencion(), "##,##0.00")
    End Sub





    Private Sub TrueDBGridMetodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.Click

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub
End Class