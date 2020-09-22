Imports System.Data.SqlClient

Public Class FrmPagos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub



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

        Me.TxtNumeroEnsamble.Text = "-----0-----"




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


        SqlString = "SELECT NombrePago, Descripcion, Numero_Compra, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetallePago, CodReciboPago, Fecha_Recibo, Numero_Nota FROM DetalleReciboPago WHERE (CodReciboPago = '-1') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleRecibo")
        Me.BindingDetalleRecibo.DataSource = ds.Tables("DetalleRecibo")
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleRecibo")
        'Me.BindingDetalleRecibo.DataSource = DataSet.Tables("DetalleRecibo")
        Me.TDBGridDetalle.DataSource = Me.BindingDetalleRecibo
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Button = True
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Width = 85
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Descripcion").Width = 213
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 100
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Factura").Width = 100
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoPagado").Width = 75
        Me.TDBGridDetalle.Columns("MontoPagado").NumberFormat = "##,##0.00"
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NumeroTarjeta").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("FechaVence").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoFactura").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("AplicaFactura").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("SaldoFactura").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("idDetallePago").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("CodReciboPago").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Fecha_Recibo").Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Nota").Visible = False
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
            ' ''Me.TrueDBGridComponentes.Enabled = True

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
            'Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas.DataSource
            MiConexion.Close()

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

        Else

            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            'Me.TrueDBGridComponentes.Enabled = False
            MiConexion.Close()

        End If
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
        Dim Retencion As Double, idDetalle As Double, Descripcion As String, NumeroTarjeta As String, FechaVence As Date, SQlString As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        'If IsDBNull(Me.BindingMetodo.Item(iPosicion)("Monto")) Then
        '    MsgBox("Es neceario completar el Metodo de Pago", MsgBoxStyle.Critical, "Zeus Facturacion")
        '    Exit Sub
        'End If

        If Me.BindingDetalleRecibo.Count = 0 Then
            MsgBox("Es neceario completar el pago", MsgBoxStyle.Critical, "Zeus Facturacion")
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

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Me.BindingFacturas.MoveFirst()
        'Registros = Me.BindingFacturas.Count
        'iPosicion = 0

        'Do While iPosicion < Registros
        '    NumeroCompra = Me.BindingFacturas.Item(iPosicion)("Numero_Compra")
        '    If Not IsDBNull(Me.BindingFacturas.Item(iPosicion)("MontoPagado")) Then
        '        MontoPagado = Me.BindingFacturas.Item(iPosicion)("MontoPagado")
        '    Else
        '        MontoPagado = 0
        '    End If

        '    If Not IsDBNull(Me.BindingFacturas.Item(iPosicion)("Retencion")) Then
        '        Retencion = Me.BindingFacturas.Item(iPosicion)("Retencion")
        '    Else
        '        Retencion = 0
        '    End If


        '    MontoCredito = Me.BindingFacturas.Item(iPosicion)("Saldo")
        '    If MontoPagado <> 0 Then
        '        GrabaDetallePagos(NumeroPago, NumeroCompra, MontoPagado, Retencion)
        '        ActualizaMontoCreditoCompra(NumeroCompra, MontoCredito, Me.TxtMonedaFactura.Text)
        '    End If
        '    iPosicion = iPosicion + 1

        'Loop


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DEL RECIBO/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Me.BindingDetalleRecibo.MoveFirst()
        Registros = Me.BindingDetalleRecibo.Count
        iPosicion = 0

        'SqlString = "SELECT NombrePago, Descripcion, Numero_Compra, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetallePago, CodReciboPago, Fecha_Recibo, Numero_Nota FROM DetalleReciboPago WHERE (CodReciboPago = '-1') "

        Do While iPosicion < Registros

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("idDetallePago")) Then
                idDetalle = ds.Tables("DetalleRecibo").Rows(iPosicion)("idDetallePago")
            Else
                idDetalle = -1
            End If

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Compra")) Then
                NumeroCompra = ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Compra")
            Else
                NumeroCompra = 0
                ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Compra") = 0
            End If

            ds.Tables("DetalleRecibo").Rows(iPosicion)("CodReciboPago") = NumeroPago
            ds.Tables("DetalleRecibo").Rows(iPosicion)("Fecha_Recibo") = Format(Me.DTPFecha.Value, "dd/MM/yyyy")


            NombrePago = ds.Tables("DetalleRecibo").Rows(iPosicion)("NombrePago")
            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Descripcion")) Then
                Descripcion = ds.Tables("DetalleRecibo").Rows(iPosicion)("Descripcion")
            End If
            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = ds.Tables("DetalleRecibo").Rows(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("FechaVence")) Then
                FechaVence = ds.Tables("DetalleRecibo").Rows(iPosicion)("FechaVence")
            Else
                FechaVence = Format(Now, "dd/MM/yyyy")
            End If


            MontoPagado = 0
            MontoCredito = 0

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")) Then
                If iPosicion <> 0 Then
                    If Me.BindingDetalleRecibo.Item(iPosicion - 1)("NombrePago") = ds.Tables("DetalleRecibo").Rows(iPosicion)("NombrePago") Then
                        MontoPagado = MontoPagado + ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                        If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                            MontoCredito = MontoCredito + ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                        Else
                            MontoCredito = MontoCredito
                        End If
                        Cadena = NombrePago & " $" & MontoPagado

                        '//////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////SI CAMBIA LA FECHA DEL RECIBO /////////////////////////////////
                        '///////////////////////////////////////////////////////////////////////////////////////

                        'If CambiaFechaRecibo = True Then
                        '    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, MontoPagado, NumeroTarjeta, FechaVence)
                        'End If
                    Else
                        MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                        If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                            MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                        Else
                            MontoCredito = MontoCredito
                        End If

                        '//////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////SI CAMBIA LA FECHA DEL RECIBO /////////////////////////////////
                        '///////////////////////////////////////////////////////////////////////////////////////
                        'If CambiaFechaRecibo = True Then
                        '    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, MontoPagado, NumeroTarjeta, FechaVence)
                        'End If

                    End If
                Else

                    MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                    If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                        MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                    End If


                    'GrabaDetallePagos(NumeroPago, NumeroCompra, MontoPagado, Retencion)
                    ActualizaMontoCreditoCompra(NumeroCompra, MontoCredito, Me.TxtMonedaFactura.Text)

                End If

            Else
                MontoPagado = 0
            End If


            'MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("Saldo")
            If MontoPagado <> 0 Then

                If CambiaFechaRecibo = True Then
                    'GrabaDetallePagos(NumeroPago, NumeroCompra, MontoPagado, Retencion)
                End If

                ActualizaMontoCreditoCompra(NumeroCompra, MontoCredito, Me.TxtMonedaFactura.Text)

                '///////////////////////////////////////////BUSCO SI LA FACTURA QUEDA EN CERO PARA DESACTIVARLAS /////////////////////
                SQlString = "SELECT   *  FROM Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Tipo_Compra = 'Mercancia Recibida') ORDER BY Fecha_Compra DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Compras")
                If DataSet.Tables("Compras").Rows.Count <> 0 Then
                    MiConexion.Close()
                    MontoCredito = DataSet.Tables("Compras").Rows(0)("MontoCredito")
                    If MontoCredito = 0 Then

                        SQlPagos = "UPDATE [Compras]  SET [Activo] = 'False' " & _
                                     "WHERE  (Numero_Compra = '" & NumeroCompra & "') AND (Tipo_Compra = 'Mercancia Recibida')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(SQlPagos, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    End If

                End If

            Else
                ds.Tables("DetalleRecibo").Rows(iPosicion).Delete()
                Registros = Registros - 1
                iPosicion = iPosicion - 1

            End If



            iPosicion = iPosicion + 1
        Loop

        If CambiaFechaRecibo = False Then
            da.Update(ds.Tables("DetalleRecibo"))
        End If



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

    Private Sub TxtMonedaFactura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonedaFactura.SelectedIndexChanged
        Dim Sqlstring As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Me.TxtCodigoProveedor.Text = "" Then
            Exit Sub
        End If

        If Me.TxtMonedaFactura.Text = "Cordobas" Then
            Sqlstring = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN MontoCredito ELSE MontoCredito * TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                           "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
        Else
            Sqlstring = "SELECT DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS MontoCredito, DetalleReciboPago.MontoPagado - DetalleReciboPago.MontoPagado AS MontoPagado, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) AS Saldo, DetalleReciboPago.MontoRetencion AS Retencion, ROUND(CASE WHEN Compras.MonedaCompra = 'Dolares' THEN MontoCredito ELSE MontoCredito / TasaCambio.MontoTasa END, 2) - ROUND(CASE WHEN DetalleReciboPago.MontoRetencion IS NULL THEN 0 ELSE DetalleReciboPago.MontoRetencion END, 2) AS NetoPagar FROM TasaCambio INNER JOIN Compras ON TasaCambio.FechaTasa = Compras.Fecha_Compra FULL OUTER JOIN DetalleReciboPago ON Compras.Numero_Compra = DetalleReciboPago.Numero_Compra  " & _
                                         "WHERE  (Compras.Tipo_Compra = 'Mercancia Recibida' OR Compras.Tipo_Compra = 'Cuenta') AND (Compras.MontoCredito <> 0) AND (Compras.Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') "
        End If


        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Consultas")
        Me.BindingFacturas.DataSource = DataSet.Tables("Consultas")
        'Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas.DataSource
        MiConexion.Close()

        'Me.TrueDBGridComponentes.Columns(0).Caption = "Compra No"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 63

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

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FrmPagosFacturas.OptRet1Porciento.Checked = Me.OptRet1Porciento.Checked
        FrmPagosFacturas.OptRet2Porciento.Checked = Me.OptRet2Porciento.Checked
        FrmPagosFacturas.OptRet7Porciento.Checked = Me.OptRet7Porciento.Checked
        FrmPagosFacturas.OptRet10Porciento.Checked = Me.OptRet10Porciento.Checked
        FrmPagosFacturas.TxtCodigoProveedor.Text = Me.TxtCodigoProveedor.Text
        FrmPagosFacturas.TxtNombres.Text = Me.TxtNombres.Text
        FrmPagosFacturas.TxtApellidos.Text = Me.TxtApellidos.Text

        My.Forms.FrmPagosFacturas.ShowDialog()

    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT ReciboPago.* FROM ReciboPago WHERE (CodReciboPago = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Recibo = CONVERT(DATETIME, '" & Fecha & "', 102))"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            If Not DataSet.Tables("Recibos").Rows.Count = 0 Then
                Me.TxtCodigoProveedor.Text = DataSet.Tables("Recibos").Rows(0)("Cod_Proveedor")
                'Me.TxtNombres.Text = DataSet.Tables("Recibos").Rows(0)("NombreCliente")
                'Me.TxtApellidos.Text = DataSet.Tables("Recibos").Rows(0)("ApellidosCliente")
                'Me.TxtDireccion.Text = DataSet.Tables("Recibos").Rows(0)("DireccionCliente")
                'Me.TxtTelefono.Text = DataSet.Tables("Recibos").Rows(0)("TelefonoCliente")
                'Me.TxtMonedaFactura.Text = DataSet.Tables("Recibos").Rows(0)("MonedaRecibo")
                Me.TxtSubTotal.Text = DataSet.Tables("Recibos").Rows(0)("Sub_Total")
                Me.TxtDescuento.Text = DataSet.Tables("Recibos").Rows(0)("Descuento")
                Me.TxtNetoPagar.Text = DataSet.Tables("Recibos").Rows(0)("Total")

                SqlString = "SELECT NombrePago, Descripcion, Numero_Compra, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetallePago, CodReciboPago, Fecha_Recibo, Numero_Nota FROM DetalleReciboPago WHERE (CodReciboPago = '" & Me.TxtNumeroEnsamble.Text & "') "
                'SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo FROM DetalleRecibo WHERE (CodReciboPago = '-1') AND (Fecha_Recibo = CONVERT(DATETIME, '2010-01-01 00:00:00', 102))"
                ds = New DataSet
                da = New SqlDataAdapter(SqlString, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleRecibo")
                Me.BindingDetalleRecibo.DataSource = ds.Tables("DetalleRecibo")
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleRecibo")
                'Me.BindingDetalleRecibo.DataSource = DataSet.Tables("DetalleRecibo")
                'Me.TDBGridDetalle.DataSource = Me.BindingDetalleRecibo
                Me.TDBGridDetalle.DataSource = Me.BindingDetalleRecibo
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Button = True
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NombrePago").Width = 85
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Descripcion").Width = 213
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 100
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Factura").Width = 100
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoPagado").Width = 75
                Me.TDBGridDetalle.Columns("MontoPagado").NumberFormat = "##,##0.00"
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("NumeroTarjeta").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("FechaVence").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("MontoFactura").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("AplicaFactura").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("SaldoFactura").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("idDetallePago").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("CodReciboPago").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Fecha_Recibo").Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Nota").Visible = False

            End If
        End If
    End Sub

    Private Sub TDBGridDetalle_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDBGridDetalle.ButtonClick
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TDBGridDetalle.Columns("NombrePago").Text = Metodo
        Me.TDBGridDetalle.Columns("Descripcion").Text = "PAGO PROVEEDOR"
    End Sub

    Private Sub TDBGridDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridDetalle.Click

    End Sub
End Class