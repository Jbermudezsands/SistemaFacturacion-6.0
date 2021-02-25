Public Class FrmTransformacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub ActualizarGrid()
        Dim SqlString As String = "", DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        MiConexion.Close()
        If Me.OptTodos.Checked = True Then
            SqlString = "SELECT  Numero_Transforma As Numero, Fecha_Transforma As Fecha, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion  "
        ElseIf Me.OptProcesados.Checked = True Then
            SqlString = "SELECT  Numero_Transforma As Numero, Fecha_Transforma AS Fecha, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion WHERE (Procesado = 1)"
        ElseIf Me.OptActivos.Checked = True Then
            SqlString = "SELECT  Numero_Transforma As Numero, Fecha_Transforma AS Fecha, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion WHERE (Anulado = 0) AND (Activo = 1)"
        End If
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lista")
        Me.TDGridSolicitud.DataSource = DataSet.Tables("Lista")

        If Me.TDGridSolicitud.RowCount <> 0 Then
            Me.TDGridSolicitud.Columns("Numero").Caption = "Numero"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero").Width = 80
            Me.TDGridSolicitud.Columns("Fecha").Caption = "Fecha"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha").Width = 84
            Me.TDGridSolicitud.Columns("BodegaOrigen").Caption = "Bodega Origen"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("BodegaOrigen").Width = 70
            Me.TDGridSolicitud.Columns("BodegaDestino").Caption = "BodegaDestino"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("BodegaDestino").Width = 70
            Me.TDGridSolicitud.Columns("Observaciones").Caption = "Observaciones"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Observaciones").Width = 150
        End If
        MiConexion.Close()
    End Sub

    Private Sub FrmTransformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarGrid()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        ActualizarGrid()
    End Sub

    Private Sub OptTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTodos.CheckedChanged
        ActualizarGrid()
    End Sub

    Private Sub OptActivos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptActivos.CheckedChanged
        ActualizarGrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.TransformacionNueva.Nuevo = True
        My.Forms.TransformacionNueva.ShowDialog()
        ActualizarGrid()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        My.Forms.TransformacionNueva.Nuevo = False
        My.Forms.TransformacionNueva.TxtNumeroEnsamble.Text = "-----0-----"
        My.Forms.TransformacionNueva.TxtNumeroEnsamble.Text = Me.TDGridSolicitud.Columns("Numero").Text
        My.Forms.TransformacionNueva.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Transformacion?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        MiConexion.Close()
        Numero = Me.TDGridSolicitud.Columns("Numero").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha").Text), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Transformacion]  SET [Activo] = 0 ,[Procesado] = 0 ,[Anulado] = 1  WHERE (Numero_Transforma = '" & Numero & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        ActualizarGrid()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptProcesados.CheckedChanged
        ActualizarGrid()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Resultado = MsgBox("¿Esta Seguro de procesar la Transformacion?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        Procesar_Transformacion()

        MiConexion.Close()
        Numero = Me.TDGridSolicitud.Columns("Numero").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha").Text), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Transformacion]  SET [Activo] = 0 ,[Procesado] = 1 ,[Anulado] = 0  WHERE (Numero_Transforma = '" & Numero & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        ActualizarGrid()


    End Sub


    Public Sub Procesar_Transformacion()

        Dim ComandoUpdate As New SqlClient.SqlCommand
        Dim ConsecutivoCompra As Double, NumeroCompra As String, iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioFOB As Double, PrecioCosto As Double, Cantidad As Double
        Dim PrecioNeto As Double, Importe As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Fecha As Date, MontoIva As Double, Sql As String, NumeroTransforma As String, Descripcion_Producto As String
        Dim CodBodegaOrigen As String, CodBodegaDestino As String, CodCliente As String, CodProveedor As String, NombreProveedor As String, ConsecutivoFactura As Double, NumeroFactura As String



        '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
        SqlString = "SELECT  * FROM Clientes WHERE(InventarioFisico = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultasCliente")
        If DataSet.Tables("ConsultasCliente").Rows.Count <> 0 Then
            CodCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Cod_Cliente")
            NombreCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Nombre_Cliente")
        Else
            MsgBox("Seleccione una Cuenta cliente para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
        SqlString = "SELECT  * FROM Proveedor  WHERE(InventarioFisico = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultasProveedor")
        If DataSet.Tables("ConsultasProveedor").Rows.Count <> 0 Then
            CodProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Cod_Proveedor")
            NombreProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Nombre_Proveedor")
        Else
            MsgBox("Seleccione una Cuenta Proveedor para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        ConsecutivoCompra = BuscaConsecutivo("Compra")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        NumeroTransforma = Me.TDGridSolicitud.Columns("Numero").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha").Text), "yyyy-MM-dd")
        CodBodegaOrigen = Me.TDGridSolicitud.Columns("BodegaOrigen").Text
        CodBodegaDestino = Me.TDGridSolicitud.Columns("BodegaDestino").Text


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        GrabaEncabezadoCompras(NumeroCompra, CDate(Fecha), "Mercancia Recibida", CodProveedor, CodBodegaDestino, NombreProveedor, "-", CDate(Fecha), 0, 0, 0, 0, "Cordobas", "Procesado por Transformacion " & NumeroTransforma, "")


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Sql = "SELECT Detalle_Transformacion.* FROM Detalle_Transformacion WHERE (Numero_Transforma = '" & NumeroTransforma & "') AND (TipoTransforma = 'Destino')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")


        Registros = DataSet.Tables("DetalleRecepcion").Rows.Count
        iPosicion = 0

        Do While iPosicion < Registros
            CodigoProducto = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Codigo_Producto")

            PrecioFOB = 0 'Me.BindingDetalle.Item(iPosicion)("FOB")
            PrecioCosto = 0 'Me.BindingDetalle.Item(iPosicion)("Precio_Costo")
            Descuento = 0
            If Not IsDBNull(DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Cantidad")) Then
                Cantidad = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Cantidad")
                PrecioUnitario = CostoPromedioKardex(CodigoProducto, Fecha)
            End If
            PrecioNeto = PrecioUnitario * Cantidad
            Importe = PrecioCosto - Descuento

            GrabaDetalleCompraLiquidacion(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioUnitario, Importe, Cantidad, "Cordobas", CDate(Fecha))
            ExistenciasCostos(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", CodBodegaOrigen)


            iPosicion = iPosicion + 1
        Loop

        DataSet.Tables("DetalleRecepcion").Reset()
        MiConexion.Close()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////GRABO LA SALIDA DE BODEGA ////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
        NumeroFactura = Format(ConsecutivoFactura, "0000#")
        GrabaEncabezadoFacturas(NumeroFactura, Fecha, "Salida Bodega", CodCliente, CodBodegaOrigen, NombreCliente, "-", Fecha, Val(0), 0, Val(0), Val(0), "Cordobas", "Procesado por Transformacion " & NumeroTransforma)


        Sql = "SELECT Detalle_Transformacion.* FROM Detalle_Transformacion WHERE (Numero_Transforma = '" & NumeroTransforma & "') AND (TipoTransforma = 'Origen')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleSalida")


        Registros = DataSet.Tables("DetalleSalida").Rows.Count
        iPosicion = 0

        Do While iPosicion < Registros
            CodigoProducto = DataSet.Tables("DetalleSalida").Rows(iPosicion)("Codigo_Producto")
            Descripcion_Producto = DataSet.Tables("DetalleSalida").Rows(iPosicion)("Descripcion_Producto")

            PrecioFOB = 0 'Me.BindingDetalle.Item(iPosicion)("FOB")
            PrecioCosto = 0 'Me.BindingDetalle.Item(iPosicion)("Precio_Costo")
            Descuento = 0
            If Not IsDBNull(DataSet.Tables("DetalleSalida").Rows(iPosicion)("Cantidad")) Then
                Cantidad = DataSet.Tables("DetalleSalida").Rows(iPosicion)("Cantidad")
                'PrecioUnitario = CostoPromedioKardex(CodigoProducto, Fecha)
            End If
            PrecioNeto = PrecioUnitario * Cantidad
            Importe = PrecioCosto - Descuento

            GrabaDetalleFacturaSalida(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, 0, PrecioUnitario, PrecioNeto, Cantidad, "Cordobas", Fecha, "Salida Bodega", PrecioUnitario)
            ActualizaExistencia(CodigoProducto)

            iPosicion = iPosicion + 1
        Loop

        DataSet.Tables("DetalleSalida").Reset()

    End Sub
End Class