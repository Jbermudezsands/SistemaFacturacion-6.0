Public Class FrmComprasHistorico
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String


        Select Case Me.TrueDBGridComponentes.Col

            Case 0
                If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
                    Exit Sub
                Else
                    CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                    SqlString = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count <> 0 Then
                        Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                        Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Costo_Promedio")
                        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                    Else
                        MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Quien = "CodigoProductosDetalle"
                        My.Forms.FrmConsultas.ShowDialog()
                        Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                        Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                        Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
                        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                    End If
                End If
        End Select
    End Sub



    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlProveedor As String, CodProducto As String
        Dim ConsecutivoCompra As Double, iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, NumeroLote As String, FechaLote As Date, DescripcionProducto As String

        If Me.CboCodigoBodega.Text = "" Then
            MsgBox("Es necesario que seleccione el tipo de Compra", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If


        If Me.TxtCodigoProveedor.Text = "" Then
            Exit Sub
        Else

            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If DataSet.Tables("Proveedor").Rows.Count = 0 Then
                Exit Sub
            End If
        End If


        If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
            Exit Sub
        Else
            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count = 0 Then
                Exit Sub
            End If
        End If



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Orden de Compra"
                    ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
                Case "Mercancia Recibida"
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
                Case "Devolucion de Compra"
                    ConsecutivoCompra = BuscaConsecutivo("DevCompra")
                Case "Transferencia Recibida"
                    ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
                Case "Cuenta"
                    'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
                Case "Cuenta DB"
                    'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
            End Select
        Else
            ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        End If

        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        ActualizaMETODOcOMPRA()

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaCompras(NumeroCompra)

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroCompras"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


        Registros = Me.BindingDetalle.Count
        iPosicion = Me.BindingDetalle.Position


        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
            DescripcionProducto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        End If
        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        End If
        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        End If

        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
            NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        Else
            NumeroLote = "SINLOTE"
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
            FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
        Else
            FechaLote = "01/01/1900"
        End If

        GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote, DescripcionProducto)

        Select Case Me.CboTipoProducto.Text
            Case "Mercancia Recibida"
                DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            Case "Devolucion de Compra"
                DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        End Select

        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
        ActualizaMETODOcOMPRA()

        CodigoProducto = 0
        PrecioUnitario = 0
        Descuento = 0
        PrecioNeto = 0
        Importe = 0
        Cantidad = 0

        Me.TrueDBGridComponentes.Col = 0



    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double

        Cols = e.ColIndex
        Select Case Cols
            Case 2
                If Not IsNumeric(Me.TrueDBGridComponentes.Columns(2).Text) Then
                    Me.TrueDBGridComponentes.Columns(2).Text = 0
                End If

                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    iPosicion = Me.BindingDetalle.Position
                    CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Else
                    CantidadAnterior = 0
                End If
            Case 3
                If Not IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
                    Me.TrueDBGridComponentes.Columns(3).Text = 0
                End If


                If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                    iPosicion = Me.BindingDetalle.Position
                    PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                Else
                    PrecioAnterior = 0
                End If
        End Select
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim Cols As Double, Precio As Double, Cantidad As Double, Descuento As Double, SubTotal As Double, Neto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Tasa As Double, SqlProveedor As String
        Dim CodProducto As String, CodImpuesto As String
        Dim TipoProducto As String = "Productos", TipoDescuento As String = "ImporteFijo"
        Dim PrecioDescDolar As Double, PrecioDescCordobas As Double, PorcientoDescuento As Double

        Cols = e.ColIndex
        If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
            Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)

        Else
            Precio = 0
        End If
        Descuento = 0
        Tasa = 0


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL CODIGO DEL IMPUESTO PARA EL PRODUCTO///////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Productos")
        If DataSet.Tables("Productos").Rows.Count <> 0 Then
            CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
            TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
            TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
            PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
            PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
        End If

        DataSet.Reset()
        Select Case Cols
            Case 0

                CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count = 0 Then
                    MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                Else
                    Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                    Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                End If
                DataSet.Tables("Productos").Clear()
            Case 2
                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                End If
            Case 3
                If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                End If
                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                End If
            Case 4

                If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                End If
                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                End If

        End Select

        '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
        Select Case TipoDescuento
            Case "ImporteFijo"
                Me.TrueDBGridComponentes.Columns(2).Text = 1
                Cantidad = 1
                Me.TrueDBGridComponentes.Columns(4).Text = ""
                If Me.TxtMonedaFactura.Text = "Cordobas" Then
                    Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.00")
                    Precio = PrecioDescCordobas
                Else
                    Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.00")
                    Precio = PrecioDescDolar
                End If

            Case "SubTotal"
                Me.TrueDBGridComponentes.Columns(2).Text = 1
                Cantidad = 1
                Me.TrueDBGridComponentes.Columns(4).Text = ""
                SubTotal = Me.TxtSubTotal.Text
                If PrecioDescCordobas <> 0 Then
                    PorcientoDescuento = (PrecioDescCordobas / 100)
                End If
                Precio = SubTotal * PorcientoDescuento
                Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")

        End Select

        SubTotal = Cantidad * Precio
        Neto = SubTotal * (1 - Descuento)

        Select Case TipoProducto
            Case "Productos"
                SubTotal = Cantidad * Precio
                Neto = SubTotal * (1 - Descuento)
            Case "Descuento"
                Neto = Math.Abs(Cantidad * Precio) * -1
        End Select


        Me.TrueDBGridComponentes.Columns(5).Text = Format(Precio * (1 - Descuento), "##,##0.00")
        Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")


        If Me.TxtCodigoProveedor.Text = "" Then
            MsgBox("Es necesario que seleccione un proveedor", MsgBoxStyle.Critical, "Sistema Facturacion")
            Me.TrueDBGridComponentes.Enabled = False
            Exit Sub
        Else

            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If DataSet.Tables("Proveedor").Rows.Count = 0 Then
                MsgBox("El Codigo del Proveedor no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridComponentes.Enabled = False
                Exit Sub
            End If
        End If


        If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
            MsgBox("Necesita Seleccionar un producto", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        Else

            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count = 0 Then
                MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub TrueDBGridComponentes_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeDelete
        Dim SQlString As String, iPosicion As Double, TipoCompra As String, Fecha As String
        Dim Descripcion_Producto As String, CodigoProducto As String, NumeroCompra As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Cantidad As Double, DiferenciaCantidad As Double, DiferenciaPrecio As Double, PrecioNeto As Double

        iPosicion = Me.BindingDetalle.Position
        Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        TipoCompra = Me.CboTipoProducto.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        NumeroCompra = Me.TxtNumeroEnsamble.Text


        MiConexion.Close()
        SQlString = "DELETE FROM  Detalle_Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & TipoCompra & "') AND (Cod_Producto = '" & CodigoProducto & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")

        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        End If

        Select Case Me.CboTipoProducto.Text
            Case "Mercancia Recibida"
                DiferenciaCantidad = CDbl(Cantidad)
                DiferenciaPrecio = CDbl(PrecioNeto)
                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            Case "Devolucion de Compra"
                DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        End Select


    End Sub



    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick

        Quien = "CodigoProductosDetalle"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
        Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False

        'Select Case My.Forms.FrmConsultas.TipoProducto
        '    Case "Descuento"
        '        Me.TrueDBGridComponentes.Columns(2).Text = 1
        '        Me.TrueDBGridComponentes.Columns(5).Text = My.Forms.FrmConsultas.Precio
        '        Me.TrueDBGridComponentes.Columns(6).Text = My.Forms.FrmConsultas.Precio
        '    Case "Servicio"
        '        Me.TrueDBGridComponentes.Columns(2).Text = 1
        '        Me.TrueDBGridComponentes.Columns(5).Text = My.Forms.FrmConsultas.Precio
        '        Me.TrueDBGridComponentes.Columns(6).Text = My.Forms.FrmConsultas.Precio
        'End Select

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            Me.TrueDBGridMetodo.Visible = True
        Else
            Me.TrueDBGridMetodo.Visible = False
        End If
    End Sub

    Private Sub TrueDBGridMetodo_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridMetodo.BeforeDelete
        ActualizaMETODOcOMPRA()
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
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If
        End Select


        ActualizaMETODOcOMPRA()


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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProveedor.TextChanged
        Try



            Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                End If
                If Not IsDBNull(Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
                End If
                If Not IsDBNull(Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
                End If
                Me.TrueDBGridComponentes.Enabled = True
            Else

                Me.TxtNombres.Text = ""
                Me.TxtApellidos.Text = ""
                Me.TxtDireccion.Text = ""
                Me.TxtTelefono.Text = ""
                Me.TrueDBGridComponentes.Enabled = False

            End If
        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub

    Private Sub FrmComprasHistorico_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Historico Compras")
    End Sub

    Private Sub FrmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.DTVencimiento.Value = Format(Now, "dd/MM/yyyy")

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


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

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN  Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto  WHERE (Detalle_Compras.Numero_Compra = '-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleCompra")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
        Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
        Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA COMPRA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaCompra")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaImprimeCompra")
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim Metodo As String, iPosicion As Double, Registros As Double, Monto As Double
        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0

        Do While iPosicion < Registros
            Metodo = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto


            iPosicion = iPosicion + 1
        Loop
        Me.TxtPagado.Text = Monto
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim ConsecutivoCompra As Double, iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Orden de Compra"
                    ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
                Case "Mercancia Recibida"
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
                Case "Devolucion de Compra"
                    ConsecutivoCompra = BuscaConsecutivo("DevCompra")
                Case "Transferencia Recibida"
                    ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
                Case "Cuenta"
                    'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
                Case "Cuenta DB"
                    'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
                    ConsecutivoCompra = BuscaConsecutivo("Compra")
            End Select
        Else
            ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        End If

        NumeroCompra = Format(ConsecutivoCompra, "0000#")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaCompras(NumeroCompra)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Me.BindingDetalle.MoveFirst()
        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0

        'Do While iPosicion < Registros
        '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        '    PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '        Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '    End If
        '    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '    GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad)

        '    Select Case Me.CboTipoProducto.Text
        '        Case "Mercancia Recibida"
        '            ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '    End Select

        '    CodigoProducto = 0
        '    PrecioUnitario = 0
        '    Descuento = 0
        '    PrecioNeto = 0
        '    Importe = 0
        '    Cantidad = 0

        '    iPosicion = iPosicion + 1
        'Loop

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        Monto = 0
        Do While iPosicion < Registros
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
                FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            Else
                FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            End If

            GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
            iPosicion = iPosicion + 1
        Loop


        MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Orden de Compra"
                    Me.CmdFacturar.Enabled = True
                Case Else
                    LimpiarCompras()
            End Select
        End If

        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True

    End Sub

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged
        If Me.CboTipoProducto.Text <> "" Then
            Me.TrueDBGridComponentes.Enabled = True
        End If

        If Me.CboTipoProducto.Text = "Mercancia Recibida" Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
            Me.RadioButton1.Checked = True
        End If

        If Me.CboTipoProducto.Text = "Transferencia Recibida" Then
            Me.CmdTransferencias.Visible = True
        Else
            Me.CmdTransferencias.Visible = False
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "ComprasHistorico"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Nombres <> "******CANCELADO ******" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
            Me.CboCodigoBodega.Enabled = False
            Me.Button7.Enabled = False
        End If
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoCompra As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "NumeroCompras" Then
            Exit Sub
        ElseIf Quien = "MetodoPago" Then
            Exit Sub
        End If

        Try



            If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
                TipoCompra = Me.CboTipoProducto.Text
                Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
                SqlCompras = "SELECT  * FROM Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & TipoCompra & "')  AND (Activo = 0)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "Compras")
                If Not DataSet.Tables("Compras").Rows.Count = 0 Then
                    '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                    Me.TxtCodigoProveedor.Text = DataSet.Tables("Compras").Rows(0)("Cod_Proveedor")
                    Me.TxtNombres.Text = DataSet.Tables("Compras").Rows(0)("Nombre_Proveedor")
                    Me.TxtApellidos.Text = DataSet.Tables("Compras").Rows(0)("Apellido_Proveedor")
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Direccion_Proveedor")) Then
                        Me.TxtDireccion.Text = DataSet.Tables("Compras").Rows(0)("Direccion_Proveedor")
                    End If
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Telefono_Proveedor")) Then
                        Me.TxtTelefono.Text = DataSet.Tables("Compras").Rows(0)("Telefono_Proveedor")
                    End If

                    '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////
                    Me.DTVencimiento.Value = DataSet.Tables("Compras").Rows(0)("Fecha_Vencimiento")
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Observaciones")) Then
                        Me.TxtObservaciones.Text = DataSet.Tables("Compras").Rows(0)("Observaciones")
                    End If
                    Me.TxtSubTotal.Text = DataSet.Tables("Compras").Rows(0)("SubTotal")
                    Me.TxtIva.Text = DataSet.Tables("Compras").Rows(0)("IVA")
                    Me.TxtPagado.Text = DataSet.Tables("Compras").Rows(0)("Pagado")
                    Me.TxtNetoPagar.Text = DataSet.Tables("Compras").Rows(0)("NetoPagar")
                    Me.CboCodigoBodega.Text = DataSet.Tables("Compras").Rows(0)("Cod_Bodega")

                    Me.TxtMonedaFactura.Text = DataSet.Tables("Compras").Rows(0)("MonedaCompra")



                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SqlCompras = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
                        "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleCompras")
                    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompras")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                    Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
                    Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                    Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
                    Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
                    Me.TrueDBGridComponentes.Columns(5).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
                    Me.TrueDBGridComponentes.Columns(6).NumberFormat = "##,##0.00"


                    '//////////////////////////////////////BUSCO LOS METODOS DE PAGOS///////////////////////////////////////////////////////////////////////////////////
                    SqlCompras = "SELECT  NombrePago, Monto, NumeroTarjeta, FechaVence  FROM Detalle_MetodoCompras " & _
                                 "WHERE (Detalle_MetodoCompras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_MetodoCompras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_MetodoCompras.Tipo_Compra = '" & TipoCompra & "') "
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")
                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    'Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

                    If DataSet.Tables("MetodoPago").Rows.Count = 0 Then
                        Me.RadioButton1.Checked = True
                    Else
                        Me.RadioButton2.Checked = True
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiarCompras()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
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

        Me.CboCodigoBodega.Enabled = False
        Me.Button7.Enabled = False
        ActualizaMETODOcOMPRA()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQLproductos As String, iPosicionFila As Double = 0

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Compra?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " & _
                     "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Dim Idetalle As Double = 0, CodigoProducto As String = "", DiferenciaCantidad As Double = 0
        SQlProductos = "SELECT * FROM Detalle_Compras WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        MiConexion.Close()
        iPosicionFila = 0
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            Do While iPosicionFila < (DataSet.Tables("Detalle").Rows.Count)

                Idetalle = DataSet.Tables("Detalle").Rows(IposicionFila)("id_Detalle_Compra")
                CodigoProducto = DataSet.Tables("Detalle").Rows(iPosicionFila)("Cod_Producto")
                DiferenciaCantidad = DataSet.Tables("Detalle").Rows(iPosicionFila)("Cantidad") * -1

                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                CostoBodega(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)


                SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                             "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "') AND (id_Detalle_Compra = " & Idetalle & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
                '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////

                ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)

                '////////////////////////////////////////////ACTUALIZO LA EXISTENCIA DE LA BODEGA////////////////////////////////////////////////////////
                SqlCompras = "UPDATE [DetalleBodegas] SET [Existencia] = " & ExistenciaBodega & " " & _
                            "WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodigoProducto & "') "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                IposicionFila = IposicionFila + 1
            Loop
        End If


        LimpiarCompras()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepCompras As New ArepCompras, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String
        Dim ConsecutivoCompra As Double, NumeroCompra As String




        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Orden de Compra"
        '            ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
        '        Case "Mercancia Recibida"
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '        Case "Devolucion de Compra"
        '            ConsecutivoCompra = BuscaConsecutivo("DevCompra")
        '        Case "Transferencia Recibida"
        '            ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
        '    End Select
        'Else
        '    ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        'End If

        'NumeroCompra = Format(ConsecutivoCompra, "0000#")

        NumeroCompra = Me.TxtNumeroEnsamble.Text


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaCompras(NumeroCompra)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        Monto = 0
        Do While iPosicion < Registros
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
                FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            Else
                FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            End If

            'GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
            iPosicion = iPosicion + 1
        Loop




        ActualizaMETODOcOMPRA()

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepCompras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepCompras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepCompras.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepCompras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        ArepCompras.LblNotas.Text = Me.TxtObservaciones.Text
        ArepCompras.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepCompras.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        ArepCompras.LblTipoCompra.Text = Me.CboTipoProducto.Text
        ArepCompras.LblCodProveedor.Text = Me.TxtCodigoProveedor.Text
        ArepCompras.LblNombres.Text = Me.TxtNombres.Text
        ArepCompras.LblApellidos.Text = Me.TxtApellidos.Text
        ArepCompras.LblDireccionProveedor.Text = Me.TxtDireccion.Text
        ArepCompras.LblTelefono.Text = Me.TxtTelefono.Text
        ArepCompras.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
        ArepCompras.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

        ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
        ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
        ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
        ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        Monto = 0
        ArepCompras.TxtMetodo.Text = "Credito"
        Do While iPosicion < Registros
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
                FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            Else
                FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            End If

            ArepCompras.TxtMetodo.Text = NombrePago & " " & Monto

            iPosicion = iPosicion + 1
        Loop


        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
            "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        SQL.ConnectionString = Conexion
        SQL.SQL = SQlDetalle
        ArepCompras.DataSource = SQL
        ArepCompras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepCompras.Document
        ViewerForm.Show()
        ArepCompras.Run(False)
        'ArepCompras.Show()


        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Orden de Compra"
                    Me.CmdFacturar.Enabled = True
                Case Else
                    '//////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////

                    SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False' " & _
                                 "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    LimpiarCompras()
            End Select
        End If








    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CuentasPagarCompras"
        My.Forms.FrmConsultas.ShowDialog()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub TrueDBGridComponentes_ColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ColEdit



    End Sub

    Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
        Dim ConsecutivoCompra As Double, iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim TipoCompra As String = "Mercancia Recibida", CodigoProyecto As String



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Select Case TipoCompra
            Case "Orden de Compra"
                ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
            Case "Mercancia Recibida"
                ConsecutivoCompra = BuscaConsecutivo("Compra")
            Case "Devolucion de Compra"
                ConsecutivoCompra = BuscaConsecutivo("DevCompra")
            Case "Transferencia Recibida"
                ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
            Case "Cuenta"
                'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                ConsecutivoCompra = BuscaConsecutivo("Compra")
            Case "Cuenta DB"
                'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
                ConsecutivoCompra = BuscaConsecutivo("Compra")
        End Select


        NumeroCompra = Format(ConsecutivoCompra, "0000#")

        CodigoProyecto = ""
        'If Not Me.CboProyecto.Text = "" Then
        '    CodigoProyecto = Me.CboProyecto.Columns(0).Text
        'End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoCompras(NumeroCompra, Me.DTPFecha.Value, "Mercancia Recibida", Me.TxtCodigoProveedor.Text, Me.CboCodigoBodega.Text, Me.TxtNombres.Text, Me.TxtApellidos.Text, Me.DTPFecha.Value, Val(Me.TxtSubTotal.Text), Val(Me.TxtIva.Text), Val(Me.TxtPagado.Text), Val(Me.TxtNetoPagar.Text), Me.TxtMonedaFactura.Text, "Procesado por la Orden de Compra " & Me.TxtNumeroEnsamble.Text, CodigoProyecto)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0

        Do While iPosicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            End If
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            GrabaDetalleCompraLiquidacion(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, Me.TxtMonedaFactura.Text, Me.DTPFecha.Value)

            'ExistenciasCostos(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", Me.CboCodigoBodega.Text)

            Select Case TipoCompra
                Case "Mercancia Recibida"
                    ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, TipoCompra, Me.CboCodigoBodega.Text)
            End Select

            CodigoProducto = 0
            PrecioUnitario = 0
            Descuento = 0
            PrecioNeto = 0
            Importe = 0
            Cantidad = 0

            iPosicion = iPosicion + 1
        Loop

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingMetodo.MoveFirst()
        Registros = Me.BindingMetodo.Count
        iPosicion = 0
        Monto = 0
        Do While iPosicion < Registros
            NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If
            If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
                FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            Else
                FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            End If

            GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
            iPosicion = iPosicion + 1
        Loop


        MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
        LimpiarCompras()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
        Me.CmdFacturar.Enabled = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class