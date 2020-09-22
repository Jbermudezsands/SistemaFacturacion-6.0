Public Class FrmPagosFacturas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub TrueDBGridMetodo_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridMetodo.ButtonClick
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TrueDBGridMetodo.Columns(0).Text = Metodo
    End Sub

    Private Sub FrmPagosFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

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

            Me.TrueDBGridComponentes.Enabled = True

            MiConexion.Close()

            If FrmPagos.TxtMonedaFactura.Text = "Cordobas" Then
                'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                '               "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') OR (Compras.Tipo_Compra = 'Cuenta')"

                SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar, Compras.Tipo_Compra, Compras.Su_Referencia AS Numero_Factura FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                               "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
            Else
                'SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                '                "WHERE (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') Or (Compras.Tipo_Compra = 'Cuenta')"
                SqlProveedor = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar,  Compras.Tipo_Compra, Compras.Su_Referencia AS Numero_Factura FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                                             "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
            End If

            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "FactConsultas")
            Me.BindingFacturas.DataSource = DataSet.Tables("FactConsultas")
            Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas.DataSource
            MiConexion.Close()

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

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False

        Else

            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TrueDBGridComponentes.Enabled = False
            MiConexion.Close()

        End If
    End Sub

    Private Sub TrueDBGridMetodo_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.AfterUpdate
        ActualizaMETODOPagosProveedores(FrmPagos.TxtMonedaFactura.Text)
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
        ActualizaMETODOPagosProveedores(FrmPagos.TxtMonedaFactura.Text)
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

        'If MontoCredito < MontoAplicado Then
        '    MsgBox("No se puede Pagar mas del Monto facturado", MsgBoxStyle.Critical, "Sistema Facturacion")
        '    Me.TrueDBGridComponentes.Columns(3).Text = 0
        '    MontoAplicado = 0
        'End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim Registros As Integer, iPosicion As Integer, RegistrosCompras As Integer, iPosicionCompras As Integer
        Dim MontoMetodo As Double, MontoCompra As Double, ResultadoCompra As Double, MontoRecibido As Double
        Dim Respuesta As Integer = 0, oDataRow As DataRow, SQlString As String, NombrePago As String, NumeroCompra As String = "", NumeroTarjeta As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaVence As Date, Pagado As Double = 0, NumeroFactura As String
        Dim SaldoCompraInicial As Double, AplicaFactura As Double, SaldoFacturaFinal As Double, FechaFactura As Date, Descripcion As String = ""
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
        SQlString = "SELECT NombrePago, Descripcion, Numero_Compra, Numero_Factura, Numero_Nota, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura FROM DetalleReciboPago WHERE (CodReciboPago = '-1') AND (Fecha_Recibo = CONVERT(DATETIME, '2010-01-01 00:00:00', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecibo")

        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        RegistrosCompras = Me.BindingFacturas.Count
        iPosicionCompras = 0
        ResultadoCompra = 0

        Do While iPosicion < Registros

            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("Monto")) Then
                MontoMetodo = Me.BindingMetodo.Item(iPosicion)("Monto")
            Else
                MsgBox("Se necesita completar el monto en Efectivo", MsgBoxStyle.Critical, "Zeus Facturacio")
                Exit Sub

            End If
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            'FechaFactura = Me.BindingFacturas.Item(iPosicion)("Fecha_Factura")
            TipoFactura = Me.BindingFacturas.Item(iPosicionCompras)("Tipo_Compra")
            NumeroFactura = Me.BindingFacturas.Item(iPosicionCompras)("Numero_Factura")
            NumeroCompra = Me.BindingFacturas.Item(iPosicionCompras)("Numero_Compra")

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


            If ResultadoCompra < 0 Then

                '///////////////////////////////BUSCO LACONFIGURACION DEL RECIBO /////////////////////////////////
                SQlString = "SELECT  * FROM DatosEmpresa"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "DatosEmpresa")
                If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                    If DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura") = True Then
                        SQlString = "SELECT *  FROM Detalle_Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "DetalleCompras")
                        If DataSet.Tables("DetalleFacturas").Rows.Count <> 0 Then
                            Descripcion = DataSet.Tables("DetalleFacturas").Rows(0)("Descripcion_Producto")
                        End If
                    End If
                    'DataSet.Tables("DetalleFacturas").Clear()
                End If

                '


                If MontoMetodo >= System.Math.Abs(ResultadoCompra) Then
                    MontoMetodo = MontoMetodo - System.Math.Abs(ResultadoCompra)
                    MontoCompra = System.Math.Abs(ResultadoCompra)
                    AplicaFactura = MontoCompra
                    SaldoFacturaFinal = SaldoCompraInicial - AplicaFactura
                    ResultadoCompra = 0
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                    oDataRow = FrmRecibos.ds.Tables("DetalleRecibo").NewRow
                    oDataRow("NombrePago") = NombrePago
                    oDataRow("Descripcion") = "PAGO " & Descripcion
                    If TipoFactura = "Factura" Then
                        oDataRow("Numero_Nota") = "0000"
                        oDataRow("Numero_Compra") = NumeroCompra
                        oDataRow("Numero_Factura") = NumeroFactura
                    Else
                        oDataRow("Numero_Nota") = NumeroCompra
                        oDataRow("Numero_Compra") = NumeroCompra
                        oDataRow("Numero_Factura") = NumeroFactura
                    End If
                    oDataRow("MontoPagado") = MontoCompra
                    oDataRow("NumeroTarjeta") = NumeroTarjeta
                    oDataRow("FechaVence") = FechaVence
                    oDataRow("MontoFactura") = SaldoCompraInicial
                    oDataRow("AplicaFactura") = AplicaFactura
                    oDataRow("SaldoFactura") = SaldoFacturaFinal
                    FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                    'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)


                Else
                    ResultadoCompra = MontoMetodo - System.Math.Abs(ResultadoCompra)
                    MontoCompra = MontoMetodo
                    AplicaFactura = MontoMetodo
                    SaldoFacturaFinal = SaldoCompraInicial - AplicaFactura
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
                        oDataRow("Numero_Compra") = NumeroCompra
                    Else
                        oDataRow("Numero_Nota") = NumeroCompra
                        oDataRow("Numero_Factura") = NumeroFactura
                        oDataRow("Numero_Compra") = NumeroCompra
                    End If
                    oDataRow("MontoPagado") = MontoCompra
                    oDataRow("NumeroTarjeta") = NumeroTarjeta
                    oDataRow("FechaVence") = FechaVence
                    oDataRow("MontoFactura") = SaldoCompraInicial
                    oDataRow("AplicaFactura") = AplicaFactura
                    oDataRow("SaldoFactura") = SaldoFacturaFinal
                    FrmRecibos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                    'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)

                End If
            End If

            Do While iPosicionCompras < RegistrosCompras
                If MontoMetodo <> 0 Then

                    TipoFactura = Me.BindingFacturas.Item(iPosicionCompras)("Tipo_Compra")
                    NumeroFactura = Me.BindingFacturas.Item(iPosicionCompras)("Numero_Factura")
                    NumeroCompra = Me.BindingFacturas.Item(iPosicionCompras)("Numero_Compra")
                    FechaFactura = Me.BindingFacturas.Item(iPosicionCompras)("Fecha_Compra")
                    If Not IsDBNull(Me.BindingFacturas.Item(iPosicionCompras)("MontoPagado")) Then
                        MontoCompra = Me.BindingFacturas.Item(iPosicionCompras)("MontoPagado")
                    End If

                    SaldoCompraInicial = Me.BindingFacturas.Item(iPosicionCompras)("MontoCredito")
                    If Not IsDBNull(Me.BindingFacturas.Item(iPosicionCompras)("MontoPagado")) Then
                        AplicaFactura = Me.BindingFacturas.Item(iPosicionCompras)("MontoPagado")
                    End If
                    SaldoFacturaFinal = Me.BindingFacturas.Item(iPosicionCompras)("Saldo")

                    NumeroFactura = Me.BindingFacturas.Item(iPosicionCompras)("Numero_Factura")

                    '///////////////////////////////BUSCO LACONFIGURACION DEL RECIBO /////////////////////////////////
                    SQlString = "SELECT  * FROM DatosEmpresa"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                    DataAdapter.Fill(DataSet, "DatosEmpresa")
                    If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                        If DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura") = True Then
                            SQlString = "SELECT *  FROM Detalle_Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = 'Mercancia Recibida')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                            DataAdapter.Fill(DataSet, "DetalleFacturas")
                            If DataSet.Tables("DetalleFacturas").Rows.Count <> 0 Then
                                Descripcion = DataSet.Tables("DetalleFacturas").Rows(0)("Descripcion_Producto")
                            End If
                        End If
                        'DataSet.Tables("DetalleFacturas").Clear()
                    End If

                    '

                    If MontoCompra <> 0 Then
                        If MontoMetodo >= MontoCompra Then
                            ResultadoCompra = MontoMetodo - MontoCompra
                            MontoMetodo = MontoMetodo - MontoCompra
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                            oDataRow = FrmPagos.ds.Tables("DetalleRecibo").NewRow
                            oDataRow("NombrePago") = NombrePago
                            oDataRow("Descripcion") = "PAGO " & Descripcion
                            If TipoFactura = "Factura" Then
                                oDataRow("Numero_Nota") = "0000"
                                oDataRow("Numero_Factura") = NumeroFactura
                                oDataRow("Numero_Compra") = NumeroCompra
                            Else
                                oDataRow("Numero_Nota") = NumeroFactura
                                oDataRow("Numero_Factura") = NumeroFactura
                                oDataRow("Numero_Compra") = NumeroCompra
                            End If
                            oDataRow("MontoPagado") = MontoCompra
                            oDataRow("NumeroTarjeta") = NumeroTarjeta
                            oDataRow("FechaVence") = FechaVence
                            oDataRow("MontoFactura") = SaldoCompraInicial
                            oDataRow("AplicaFactura") = AplicaFactura
                            oDataRow("SaldoFactura") = SaldoFacturaFinal
                            FrmPagos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)

                        Else
                            ResultadoCompra = MontoMetodo - MontoCompra
                            AplicaFactura = MontoMetodo
                            SaldoFacturaFinal = SaldoCompraInicial - AplicaFactura
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////AQUI AGREGO EL DETALLE AL RECIBO///////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'oDataRow = DataSet.Tables("DetalleRecibo").NewRow
                            oDataRow = FrmPagos.ds.Tables("DetalleRecibo").NewRow
                            oDataRow("NombrePago") = NombrePago
                            oDataRow("Descripcion") = "PAGO " & Descripcion
                            If TipoFactura = "Factura" Then
                                oDataRow("Numero_Nota") = "0000"
                                oDataRow("Numero_Factura") = NumeroFactura
                                oDataRow("Numero_Compra") = NumeroCompra
                            Else
                                oDataRow("Numero_Nota") = NumeroFactura
                                oDataRow("Numero_Factura") = NumeroFactura
                                oDataRow("Numero_Compra") = NumeroCompra
                            End If
                            oDataRow("MontoPagado") = MontoMetodo
                            oDataRow("NumeroTarjeta") = NumeroTarjeta
                            oDataRow("FechaVence") = FechaVence
                            oDataRow("MontoFactura") = SaldoCompraInicial
                            oDataRow("AplicaFactura") = AplicaFactura
                            oDataRow("SaldoFactura") = SaldoFacturaFinal
                            FrmPagos.ds.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            'DataSet.Tables("DetalleRecibo").Rows.Add(oDataRow)
                            MontoMetodo = 0
                            SaldoCompraInicial = SaldoFacturaFinal

                        End If

                    End If
                    iPosicionCompras = iPosicionCompras + 1
                Else
                    Exit Do
                End If

            Loop



            iPosicion = iPosicion + 1
        Loop

        FrmPagos.BindingMetodo.DataSource = Me.BindingMetodo.DataSource

        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Button = True
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Width = 85
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("Descripcion").Width = 213
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 100
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Factura").Width = 100
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoPagado").Width = 75
        FrmPagos.TDBGridDetalle.Columns("MontoPagado").NumberFormat = "##,##0.00"
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("NumeroTarjeta").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("FechaVence").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoFactura").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("AplicaFactura").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("SaldoFactura").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("idDetallePago").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("CodReciboPago").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("Fecha_Recibo").Visible = False
        FrmPagos.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Nota").Visible = False

        'FrmPagos.TxtImporteRecibido.Text = Me.TxtImporteRecibido.Text
        'FrmPagos.TxtPorAplicar.Text = Me.TxtPorAplicar.Text
        'FrmPagos.TxtImporteAplicado.Text = Me.TxtImporteAplicado.Text
        Me.Close()
    End Sub
End Class