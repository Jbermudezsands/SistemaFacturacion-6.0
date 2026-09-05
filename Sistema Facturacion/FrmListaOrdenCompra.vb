Public Class FrmListaOrdenCompra
    Public Nuevo As Boolean = False
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub BloquearBotones(Bloquear As Boolean)
        If Bloquear = True Then
            BtnVer.Enabled = False
            BtnActualizar.Enabled = False
            BtnComprar.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            TDGridSolicitud.Enabled = False
            BtnSalir.Enabled = False
        Else
            BtnVer.Enabled = True
            BtnActualizar.Enabled = True
            BtnComprar.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
            TDGridSolicitud.Enabled = True
            BtnSalir.Enabled = True

        End If




    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlString = "SELECT  DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, Compras.MonedaCompra, Compras.Nombre_Proveedor, Detalle_Solicitud.Numero_Solicitud, Compras.Estatus, Compras.FechaHora FROM Compras LEFT OUTER JOIN Detalle_Solicitud ON Compras.Numero_Compra = Detalle_Solicitud.Orden_Compra  " &
                    "WHERE (Compras.Tipo_Compra = 'Orden de Compra') AND (Compras.Cancelado = 0) AND (Compras.Activo = 1) ORDER BY Compras.Estatus DESC, Compras.Fecha_Compra DESC, Compras.Numero_Compra"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lista")
        Me.TDGridSolicitud.DataSource = DataSet.Tables("Lista")

        Me.TDGridSolicitud.Columns("Numero_Compra").Caption = "Num Orden"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 70
        Me.TDGridSolicitud.Columns("Fecha_Compra").Caption = "Fecha Orden"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha_Compra").Width = 80
        Me.TDGridSolicitud.Columns("MonedaCompra").Caption = "Moneda"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("MonedaCompra").Width = 70
        Me.TDGridSolicitud.Columns("Nombre_Proveedor").Caption = "Proveedor"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Nombre_Proveedor").Width = 300
        Me.TDGridSolicitud.Columns("Numero_Solicitud").Caption = "Num Solicitud"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Solicitud").Width = 80
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Estatus").Width = 80
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("FechaHora").Visible = False

        MiConexion.Close()
    End Sub

    Private Sub FrmListaOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Forms.FrmCompras.CboTipoProducto.Enabled = True
        My.Forms.FrmCompras.GroupBox1.Enabled = True
        My.Forms.FrmCompras.GroupBox5.Enabled = True
        My.Forms.FrmCompras.TrueDBGridComponentes.Enabled = True

        Me.BtnActualizar_Click(sender, e)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmCompras.CboTipoProducto.Text = "Orden de Compra"
        My.Forms.FrmCompras.CboTipoProducto.Enabled = False
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim Fecha_Compra As Date, Fecha_Hora As Date, NumeroCompra As String
        Dim frm As New FrmCompras

        NumeroCompra = Me.TDGridSolicitud.Columns("Numero_Compra").Text
        Fecha_Compra = Me.TDGridSolicitud.Columns("Fecha_Compra").Text
        Fecha_Hora = Me.TDGridSolicitud.Columns("FechaHora").Text
        Quien = "Orden de Compra"



        frm.InicializarFormulario()

        frm.Fecha_Compra = Fecha_Compra
        frm.FechaHoraCompra = Fecha_Hora
        frm.NumeroCompra = NumeroCompra
        frm.EsSolicitud = True
        frm.CboTipoProducto.Text = "Orden de Compra"
        frm.DTPFecha.Value = Fecha_Compra


        frm.CargarDesdeOrden(Fecha_Compra, Fecha_Hora, NumeroCompra)
        'frm.CargarCompra(Fecha_Compra, Fecha_Hora, NumeroCompra, "Orden de Compra")

        frm.TrueDBGridComponentes.Enabled = False

        frm.ShowDialog()


        '////////////////CODIGO RETIRADO 22/04/2026 ////////////////////
        'My.Forms.FrmCompras.EsSolicitud = True
        ''//////////////////////////////////////////CARGO LA ORDEN DE COMPRA EN EL MODULO DE COMPRAS //////////////

        'My.Forms.FrmCompras.TrueDBGridComponentes.Enabled = False
        'My.Forms.FrmCompras.ShowDialog()
        'My.Forms.FrmCompras.EsSolicitud = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Compra?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        BloquearBotones(True)
        Numero = Me.TDGridSolicitud.Columns("Numero_Compra").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha_Compra").Text), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0, [Estatus]= 'Anulado' " & _
                     "WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Dim Idetalle As Double = 0, CodigoProducto As String = "", DiferenciaCantidad As Double = 0
        SQlProductos = "SELECT * FROM Detalle_Compras WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        MiConexion.Close()
        IposicionFila = 0
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            Do While IposicionFila < (DataSet.Tables("Detalle").Rows.Count)

                Idetalle = DataSet.Tables("Detalle").Rows(IposicionFila)("id_Detalle_Compra")
                CodigoProducto = DataSet.Tables("Detalle").Rows(IposicionFila)("Cod_Producto")
                DiferenciaCantidad = DataSet.Tables("Detalle").Rows(IposicionFila)("Cantidad") * -1

                'ExistenciasCostos(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                'CostoBodega(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)


                SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                             "WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra') AND (id_Detalle_Compra = " & Idetalle & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
                '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////

                'ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)

                '////////////////////////////////////////////ACTUALIZO LA EXISTENCIA DE LA BODEGA////////////////////////////////////////////////////////
                'SqlCompras = "UPDATE [DetalleBodegas] SET [Existencia] = " & ExistenciaBodega & " " & _
                '            "WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodigoProducto & "') "
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

                IposicionFila = IposicionFila + 1
            Loop
        End If

        Bitacora(Now, NombreUsuario, "Orden de Compra", "Eliminar la Orden Compra: " & Numero)

        BloquearBotones(False)

    End Sub

    Private Sub BtnComprar_Click(sender As Object, e As EventArgs) Handles BtnComprar.Click
        Dim NumeroOrden As String = Me.TDGridSolicitud.Columns("Numero_Compra").Text
        Dim FechaOrden As Date = Me.TDGridSolicitud.Columns("Fecha_Compra").Text
        Dim TipoOrden As String = "Orden de Compra"

        BloquearBotones(True)

        ' 🔥 PEDIR FECHA AQUÍ (UI)
        Dim frmFecha As New FrmFechaxProveedor
        'frmFecha.TxtCodigoProveedor.Text = Me.TDGridSolicitud.Columns("Cod_Proveedor").Text

        frmFecha.ShowDialog()

        If Quien = "Cancelar" Then Exit Sub

        Dim FechaCompra As Date = frmFecha.DTPFechaRequerido.Value
        Dim CodigoProveedor As String = frmFecha.Codigo_Proveedor

        ' 🔥 LLAMAR FUNCIÓN LIMPIA
        ProcesarOrdenACompra(NumeroOrden, TipoOrden, FechaOrden, CodigoProveedor)

        Me.BtnActualizar_Click(sender, e)

        BloquearBotones(False)

    End Sub
    Private Function ObtenerEncabezadoOrden(ByVal NumeroOrden As String) As DataTable

        Dim dt As New DataTable

        Dim sql As String = "SELECT * FROM Compras 
                         WHERE Numero_Compra = @Numero 
                         AND Tipo_Compra = 'Orden de Compra'"

        Dim da As New SqlClient.SqlDataAdapter(sql, MiConexion)
        da.SelectCommand.Parameters.AddWithValue("@Numero", NumeroOrden)

        da.Fill(dt)

        Return dt

    End Function

    Private Function ObtenerDetalleOrden(ByVal NumeroOrden As String) As DataTable

        Dim dt As New DataTable

        Dim sql As String = "SELECT * FROM Detalle_Compras 
                         WHERE Numero_Compra = @Numero 
                         AND Tipo_Compra = 'Orden de Compra'"

        Dim da As New SqlClient.SqlDataAdapter(sql, MiConexion)
        da.SelectCommand.Parameters.AddWithValue("@Numero", NumeroOrden)

        da.Fill(dt)

        Return dt

    End Function

    Private Sub ProcesarOrdenACompra(ByVal NumeroOrden As String,
                                     ByVal TipoOrden As String,
                                     ByVal FechaCompra As Date,
                                     ByVal CodigoProveedorInput As String)

        Dim trans As SqlClient.SqlTransaction = Nothing

        Try
            If NumeroOrden = "" Then
                MsgBox("Seleccione una orden válida")
                Exit Sub
            End If

            MiConexion.Open()
            trans = MiConexion.BeginTransaction()

            '---------------------------------------------------
            ' 🔹 1. OBTENER ENCABEZADO DESDE BD
            '---------------------------------------------------
            Dim dtEncabezado As New DataTable

            Dim sqlEnc As String = "SELECT * FROM Compras 
                               WHERE Numero_Compra = @Numero 
                               AND Tipo_Compra = @Tipo"

            Dim daEnc As New SqlClient.SqlDataAdapter(sqlEnc, MiConexion)
            daEnc.SelectCommand.Transaction = trans
            daEnc.SelectCommand.Parameters.AddWithValue("@Numero", NumeroOrden)
            daEnc.SelectCommand.Parameters.AddWithValue("@Tipo", TipoOrden)

            daEnc.Fill(dtEncabezado)

            If dtEncabezado.Rows.Count = 0 Then
                MsgBox("No se encontró la orden")
                trans.Rollback()
                MiConexion.Close()
                Exit Sub
            End If

            Dim fila = dtEncabezado.Rows(0)

            Dim CodigoProveedor As String = fila("Cod_Proveedor")
            Dim Bodega As String = fila("Cod_Bodega")
            Dim Nombre As String = fila("Nombre_Proveedor")
            Dim Apellido As String = fila("Apellido_Proveedor")
            Dim SubTotal As Double = fila("SubTotal")
            Dim Iva As Double = fila("IVA")
            Dim Pagado As Double = fila("Pagado")
            Dim Neto As Double = fila("NetoPagar")
            Dim Moneda As String = fila("MonedaCompra")

            ' Si quieres priorizar el proveedor ingresado desde UI:
            If CodigoProveedorInput <> "" Then
                CodigoProveedor = CodigoProveedorInput
            End If

            '---------------------------------------------------
            ' 🔹 2. OBTENER DETALLE DESDE BD
            '---------------------------------------------------
            Dim dtDetalle As New DataTable

            Dim sqlDet As String = "SELECT * FROM Detalle_Compras 
                               WHERE Numero_Compra = @Numero 
                               AND Tipo_Compra = @Tipo"

            Dim daDet As New SqlClient.SqlDataAdapter(sqlDet, MiConexion)
            daDet.SelectCommand.Transaction = trans
            daDet.SelectCommand.Parameters.AddWithValue("@Numero", NumeroOrden)
            daDet.SelectCommand.Parameters.AddWithValue("@Tipo", TipoOrden)

            daDet.Fill(dtDetalle)

            If dtDetalle.Rows.Count = 0 Then
                MsgBox("La orden no tiene detalle")
                trans.Rollback()
                MiConexion.Close()
                Exit Sub
            End If

            '---------------------------------------------------
            ' 🔹 3. GENERAR CONSECUTIVO
            '---------------------------------------------------
            Dim Consecutivo As Double = BuscaConsecutivo("Compra")
            Dim NumeroCompraNueva As String = Format(Consecutivo, "0000#")

            '---------------------------------------------------
            ' 🔹 4. CREAR ENCABEZADO COMPRA
            '---------------------------------------------------
            GrabaEncabezadoCompras(NumeroCompraNueva,
                                  FechaCompra,
                                  "Mercancia Recibida",
                                  CodigoProveedor,
                                  Bodega,
                                  Nombre,
                                  Apellido,
                                  FechaCompra,
                                  SubTotal,
                                  Iva,
                                  Pagado,
                                  Neto,
                                  Moneda,
                                  "Procesado desde Orden " & NumeroOrden,
                                  "",
                                  False)

            '---------------------------------------------------
            ' 🔹 5. CREAR DETALLE
            '---------------------------------------------------
            For Each row As DataRow In dtDetalle.Rows

                Dim CodigoProducto As String = row("Cod_Producto")
                Dim PrecioUnitario As Double = row("Precio_Unitario")
                Dim Descuento As Double = If(IsDBNull(row("Descuento")), 0, row("Descuento"))
                Dim PrecioNeto As Double = row("Precio_Neto")
                Dim Importe As Double = row("Importe")
                Dim Cantidad As Double = row("Cantidad")

                GrabaDetalleCompraLiquidacion(NumeroCompraNueva,
                                             CodigoProducto,
                                             PrecioUnitario,
                                             Descuento,
                                             PrecioNeto,
                                             Importe,
                                             Cantidad,
                                             Moneda,
                                             FechaCompra,
                                             "0000",
                                             "01/01/1900")

                ' 🔹 Inventario
                'ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, "Mercancia Recibida", Bodega)
                CostoBodega(CodigoProducto, Cantidad, PrecioNeto, "Mercancia Recibida", Bodega, FechaCompra)

            Next

            '---------------------------------------------------
            ' 🔹 6. INACTIVAR ORDEN
            '---------------------------------------------------
            Dim cmdUpdate As New SqlClient.SqlCommand(
                "UPDATE Compras 
             SET Activo = 0, Estatus = 'Comprado' 
             WHERE Numero_Compra = @Numero AND Tipo_Compra = @Tipo",
                MiConexion, trans)

            cmdUpdate.Parameters.AddWithValue("@Numero", NumeroOrden)
            cmdUpdate.Parameters.AddWithValue("@Tipo", TipoOrden)
            cmdUpdate.ExecuteNonQuery()

            '---------------------------------------------------
            ' 🔹 7. RELACIONAR ORDEN CON COMPRA
            '---------------------------------------------------
            Dim cmdRelacion As New SqlClient.SqlCommand(
                "UPDATE Compras 
             SET Numero_Orden = @Orden 
             WHERE Numero_Compra = @Compra 
             AND Tipo_Compra = 'Mercancia Recibida'",
                MiConexion, trans)

            cmdRelacion.Parameters.AddWithValue("@Orden", NumeroOrden)
            cmdRelacion.Parameters.AddWithValue("@Compra", NumeroCompraNueva)
            cmdRelacion.ExecuteNonQuery()

            '---------------------------------------------------
            ' 🔹 8. CONFIRMAR
            '---------------------------------------------------
            trans.Commit()
            MiConexion.Close()

            MsgBox("Compra generada correctamente", MsgBoxStyle.Information)

        Catch ex As Exception

            If Not trans Is Nothing Then trans.Rollback()
            If MiConexion.State = ConnectionState.Open Then MiConexion.Close()

            MsgBox("Error al procesar: " & ex.Message)

        End Try

    End Sub

End Class