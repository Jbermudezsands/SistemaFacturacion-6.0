Public Class FrmFacturasHistoricos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double
    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged
        If Me.CboTipoProducto.Text <> "" Then
            Me.TrueDBGridComponentes.Enabled = True
        End If

        If Me.CboTipoProducto.Text = "Factura" Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
            Me.RadioButton1.Checked = True
        End If

        If Me.CboTipoProducto.Text = "Transferencia Enviada" Then
            Me.CboCodigoBodega2.Visible = True
            Me.Label7.Visible = True
            Me.CboCodigoVendedor.Visible = False
            Me.Label12.Visible = False
        Else
            Me.CboCodigoBodega2.Visible = False
            Me.Label7.Visible = False
            Me.CboCodigoVendedor.Visible = True
            Me.Label12.Visible = True
        End If

        If Me.CboTipoProducto.Text = "Cotizacion" Then
            'Me.CmdFacturar.Enabled = True

        Else
            Me.CmdFacturar.Enabled = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            Me.TrueDBGridMetodo.Visible = True
            Me.CboCajero.Visible = True
            Me.LblCajero.Visible = True
        Else
            Me.TrueDBGridMetodo.Visible = False
            Me.CboCajero.Visible = False
            Me.LblCajero.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try

            SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
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
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub FrmFacturasHistoricos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Historico Facturacion")
    End Sub

    Private Sub FrmFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.DTVencimiento.Value = Format(Now, "dd/MM/yyyy")

        If Acceso <> "Administrador" Then
            Me.ButtonBorrar.Enabled = False
        Else
            Me.ButtonBorrar.Enabled = True
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        CboCodigoVendedor.DataSource = DataSet.Tables("Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.Text = DataSet.Tables("Vendedores").Rows(0)("Cod_Vendedor")
        End If
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS CAJEROS////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Cajero, Nombre_Cajero + ' ' + Apellido_Cajero AS Nombres FROM Cajeros"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        Me.CboCajero.DataSource = DataSet.Tables("Cajeros")
        If Not DataSet.Tables("Cajeros").Rows.Count = 0 Then
            Me.CboCajero.Text = DataSet.Tables("Cajeros").Rows(0)("Cod_Cajero")
        End If
        MiConexion.Close()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"
        Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
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
        SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleFactura")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
        Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
        Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA FACTURA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
        End If
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


        ActualizaMETODOFactura()
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

        Me.CboCodigoBodega.Enabled = False
        Me.Button7.Enabled = False
        ActualizaMETODOFactura()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiarFacturas()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim ConsecutivoFactura As Double, iPosicion As Double, Registros As Double, NumeroFactura As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, Descripcion_Producto As String, IdDetalle As Double = -1

        Try



            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Select Case Me.CboTipoProducto.Text
                    Case "Cotizacion"
                        ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                    Case "Factura"
                        ConsecutivoFactura = BuscaConsecutivo("Factura")
                    Case "Devolucion de Venta"
                        ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                    Case "Transferencia Enviada"
                        ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                End Select
            Else
                ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            End If

            NumeroFactura = Format(ConsecutivoFactura, "0000#")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaFacturas(NumeroFactura)


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            Registros = Me.BindingDetalle.Count
            'iPosicion = Me.BindingDetalle.Position

            'Me.BindingDetalle.MoveFirst()
            Registros = Me.BindingDetalle.Count
            iPosicion = 0
            Monto = 0
            Do While iPosicion < Registros

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                Else
                    IdDetalle = -1
                End If

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")

                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                End If
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
                'GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle)

                Select Case Me.CboTipoProducto.Text
                    Case "Factura"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    Case "Devolucion de Venta"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                End Select

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
                Monto = Me.BindingMetodo.Item(iPosicion)("Monto") '+ Monto
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

                GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
                iPosicion = iPosicion + 1
            Loop

            ActualizaMETODOFactura()

            MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            LimpiarFacturas()
            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Iposicion As Double, SqlProductos As String = ""
        Dim idDetalle As Double, StrSqlUpdate As String = "", CodProducto As String = "", DiferenciaCantidad As Double = 0

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Factura?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False',[Nombre_Cliente] = '******CANCELADO',[Apellido_Cliente] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " & _
                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '///////////////////////////////////////EDITO EL DETALLE DE LA FACTURA ////////////////////////////////////////////////
        MiConexion.Close()
        StrSqlUpdate = "UPDATE [Detalle_Facturas] SET [Cantidad] =0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] =0,[Importe] = 0 " & _
                       "WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "'))"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA PARA HACERLA CERO/////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Iposicion = 0
        SqlProductos = "SELECT  *  FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        Do While Iposicion < DataSet.Tables("Detalle").Rows.Count
            idDetalle = DataSet.Tables("Detalle").Rows(Iposicion)("id_Detalle_Factura")
            CodProducto = DataSet.Tables("Detalle").Rows(Iposicion)("Cod_Producto")

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////BUSCO SI EXISTE EN LAS BODEGAS DETALLES///////////////////////////////////////////////////////
            '(//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlProductos = "SELECT   *  FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "') AND (id_Detalle_Factura = " & idDetalle & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleBodegas")
            If DataSet.Tables("DetalleBodegas").Rows.Count <> 0 Then
                MiConexion.Close()
                StrSqlUpdate = "UPDATE [Detalle_Facturas] SET [Cantidad] =0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] =0,[Importe] = 0 " & _
                               "WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "') AND (id_Detalle_Factura = " & idDetalle & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            DataSet.Tables("DetalleBodegas").Reset()

            DiferenciaCantidad = DataSet.Tables("Detalle").Rows(Iposicion)("Cantidad") * -1
            ExistenciasCostos(CodProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)


            ActualizaExistencia(CodProducto)


            Iposicion = Iposicion + 1
        Loop

        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Anulo Facturo Historico: " & Me.TxtNumeroEnsamble.Text)

        LimpiarFacturas()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepFacturas As New ArepFacturas, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim ConsecutivoFactura As Double = 0, NumeroFactura As String, MonedaImprime As String, MonedaFactura As String
        Dim TipoImpresion As String, SqlString As String, RutaBD As String, ConexionAccess As String
        Dim ArepCotizacionFoto As New ArepCotizacionFoto




        Try

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            '    Select Case Me.CboTipoProducto.Text
            '        Case "Cotizacion"
            '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
            '        Case "Factura"
            '            ConsecutivoFactura = BuscaConsecutivo("Factura")
            '        Case "Devolucion de Venta"
            '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
            '        Case "Transferencia Enviada"
            '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
            '    End Select
            'Else
            '    ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            'End If

            'NumeroFactura = Format(ConsecutivoFactura, "0000#")




            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'GrabaFacturas(NumeroFactura)

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            'Registros = Me.BindingDetalle.Count
            ''iPosicion = Me.BindingDetalle.Position


            'Me.BindingDetalle.MoveFirst()
            'Registros = Me.BindingDetalle.Count
            'iPosicion = 0
            'Monto = 0
            'Do While iPosicion < Registros


            '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
            '        IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            '    Else
            '        IdDetalle = -1
            '    End If

            '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")

            '    PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            '        Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            '    End If
            '    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            '    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            '    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            '    Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
            '    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle)

            '    Select Case Me.CboTipoProducto.Text
            '        Case "Factura"
            '            DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
            '            DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
            '            ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            '        Case "Devolucion de Venta"
            '            DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
            '            DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
            '            ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            '    End Select

            '    iPosicion = iPosicion + 1
            'Loop


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            'Me.BindingMetodo.MoveFirst()
            'Registros = Me.BindingMetodo.Count
            'iPosicion = 0
            'Monto = 0
            'Do While iPosicion < Registros
            '    NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            '    Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            '    If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
            '        NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            '    Else
            '        NumeroTarjeta = 0
            '    End If
            '    If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
            '        FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            '    Else
            '        FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            '    End If

            '    GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
            '    iPosicion = iPosicion + 1
            'Loop




            'ActualizaMETODOFactura()

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")

            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                ArepCotizacionFoto.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                ArepCotizacionFoto.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")



                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    ArepFacturas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepCotizacionFoto.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                    If Dir(RutaLogo) <> "" Then
                        ArepFacturas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    End If

                End If
            End If

            ArepCotizacionFoto.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepCotizacionFoto.Label1.Text = "Cliente"
            ArepCotizacionFoto.LblNotas.Text = Me.TxtObservaciones.Text
            ArepCotizacionFoto.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepCotizacionFoto.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepCotizacionFoto.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepCotizacionFoto.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepCotizacionFoto.LblNombres.Text = Me.TxtNombres.Text
            ArepCotizacionFoto.LblApellidos.Text = Me.TxtApellidos.Text
            ArepCotizacionFoto.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepCotizacionFoto.LblTelefono.Text = Me.TxtTelefono.Text
            ArepCotizacionFoto.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepCotizacionFoto.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas.Label1.Text = "Cliente"
            ArepFacturas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturas.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturas.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturas.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            MonedaFactura = Me.TxtMonedaFactura.Text
            MonedaImprime = Me.TxtMonedaImprime.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = 1
                Else
                    TasaCambio = (1 / BuscaTasaCambio(Me.DTPFecha.Value))
                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
                Else
                    TasaCambio = 1
                End If
            End If

            ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Val(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")
            ArepCotizacionFoto.LblIva.Text = Format(CDbl(Val(Me.TxtIva.Text)) * TasaCambio, "##,##0.00")
            ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Val(Me.TxtPagado.Text)) * TasaCambio, "##,##0.00")
            ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Val(Me.TxtNetoPagar.Text)) * TasaCambio, "##,##0.00")
            ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Val(Me.TxtDescuento.Text)) * TasaCambio, "##,##0.00")

            ArepFacturas.LblSubTotal.Text = Format(CDbl(Val(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")
            ArepFacturas.LblIva.Text = Format(CDbl(Val(Me.TxtIva.Text)) * TasaCambio, "##,##0.00")
            ArepFacturas.LblPagado.Text = Format(CDbl(Val(Me.TxtPagado.Text)) * TasaCambio, "##,##0.00")
            ArepFacturas.LblTotal.Text = Format(CDbl(Val(Me.TxtNetoPagar.Text)) * TasaCambio, "##,##0.00")
            ArepFacturas.LblDescuento.Text = Format(CDbl(Val(Me.TxtDescuento.Text)) * TasaCambio, "##,##0.00")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            Me.BindingMetodo.MoveFirst()
            Registros = Me.BindingMetodo.Count
            iPosicion = 0
            Monto = 0
            ArepFacturas.TxtMetodo.Text = "Credito"
            ArepCotizacionFoto.TxtMetodo.Text = "Credito"
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

                ArepFacturas.TxtMetodo.Text = NombrePago & " " & Monto
                ArepCotizacionFoto.TxtMetodo.Text = NombrePago & " " & Monto

                iPosicion = iPosicion + 1
            Loop



            SQlDetalle = ""
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT     Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Facturas.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Facturas.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Facturas.Importe * (1 / TasaCambio.MontoTasa) AS Importe, TasaCambio.MontoTasa FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Facturas.Descuento * TasaCambio.MontoTasa AS Descuento,Detalle_Facturas.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Facturas.Importe * TasaCambio.MontoTasa AS Importe,TasaCambio.MontoTasa FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,'" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            Select Case Me.CboTipoProducto.Text
                Case "Factura"
                    TipoImpresion = Me.CboTipoProducto.Text
                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco"
                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()
                                ArepFacturas.Run(True)
                                'ArepFacturas.Run(False)
                                'ArepFacturas.Show()

                            Case "Personalizado"

                                Dim StrSQLUpdate As String
                                Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                Dim DatasetDatos As New DataSet

                                NumeroFactura = Me.TxtNumeroEnsamble.Text


                                MiConexionAccess.Open()
                                DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & NumeroFactura & "' "
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                                If Dir(RutaReportes) <> "" Then
                                    Shell(RutaReportes)
                                End If



                        End Select
                    End If

                Case "Cotizacion"
                    TipoImpresion = Me.CboTipoProducto.Text
                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco"
                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                ArepFacturas.TxtMetodo.Visible = False

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()
                                ArepFacturas.Run(True)
                            Case "Cotizacion con Fotos"
                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepCotizacionFoto.DataSource = SQL
                                ArepCotizacionFoto.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                ArepCotizacionFoto.TxtMetodo.Visible = False

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepCotizacionFoto.Document
                                ViewerForm.Show()
                                ArepCotizacionFoto.Run(True)


                        End Select
                    End If


                Case Else
                    SQL.ConnectionString = Conexion
                    SQL.SQL = SQlDetalle
                    ArepFacturas.DataSource = SQL
                    ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepFacturas.Document
                    ViewerForm.Show()
                    ArepFacturas.Run(False)
                    'ArepFacturas.Run(False)
                    'ArepFacturas.Show()
            End Select


            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            If Me.CboTipoProducto.Text <> "Cotizacion" Then
                SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                             "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            LimpiarFacturas()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "NumeroFacturas" Then
            Exit Sub
        End If




        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')  AND (Activo = 0)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If Not DataSet.Tables("Facturas").Rows.Count = 0 Then
                '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")) Then
                    Me.CboCodigoVendedor.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")
                End If
                Me.TxtCodigoClientes.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Cliente")
                Me.TxtNombres.Text = DataSet.Tables("Facturas").Rows(0)("Nombre_Cliente")
                Me.TxtApellidos.Text = DataSet.Tables("Facturas").Rows(0)("Apellido_Cliente")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Facturas").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Telefono_Cliente")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Facturas").Rows(0)("Telefono_Cliente")
                End If

                '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////
                Me.DTVencimiento.Value = DataSet.Tables("Facturas").Rows(0)("Fecha_Vencimiento")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Observaciones")) Then
                    Me.TxtObservaciones.Text = DataSet.Tables("Facturas").Rows(0)("Observaciones")
                End If
                Me.TxtSubTotal.Text = DataSet.Tables("Facturas").Rows(0)("SubTotal")
                Me.TxtIva.Text = DataSet.Tables("Facturas").Rows(0)("IVA")
                Me.TxtPagado.Text = DataSet.Tables("Facturas").Rows(0)("Pagado")
                Me.TxtNetoPagar.Text = DataSet.Tables("Facturas").Rows(0)("NetoPagar")
                Me.CboCodigoBodega.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Bodega")
                Me.TxtMonedaFactura.Text = DataSet.Tables("Facturas").Rows(0)("MonedaFactura")
                Me.TxtMonedaImprime.Text = DataSet.Tables("Facturas").Rows(0)("MonedaImprime")

                '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                SqlCompras = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                    "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleFacturas")
                Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
                Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
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
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False

                If DataSet.Tables("Facturas").Rows(0)("MetodoPago") <> "Credito" Then
                    '//////////////////////////////////////BUSCO LOS METODOS DE PAGOS///////////////////////////////////////////////////////////////////////////////////
                    SqlCompras = "SELECT  NombrePago, Monto, NumeroTarjeta, FechaVence  FROM Detalle_MetodoFacturas " & _
                                 "WHERE (Detalle_MetodoFacturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_MetodoFacturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_MetodoFacturas.Tipo_Factura = '" & TipoFactura & "') "
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
                Else
                    Me.RadioButton1.Checked = True
                End If

            End If


            If Me.CboTipoProducto.Text = "Cotizacion" Then
                Me.CmdFacturar.Enabled = True

            Else
                Me.CmdFacturar.Enabled = False
            End If

        End If


    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String

        Try


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

                        Else
                            MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Quien = "CodigoProductosDetalle"
                            My.Forms.FrmConsultas.ShowDialog()
                            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio

                        End If
                    End If

                    If Acceso <> "Administrador" Then
                        If Me.CboTipoProducto.Text = "Cotizacion" Then
                            Me.GroupBox3.Enabled = False
                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                        Else

                            Me.GroupBox3.Enabled = True
                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                        End If
                    End If

            End Select

            ActualizaMETODOFactura()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterDelete
        ActualizaMETODOFactura()
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlProveedor As String, CodProducto As String
        Dim ConsecutivoFactura As Double, NumeroFactura As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double


        Try



            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Tiene que Seleccionar el Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub

            End If



            If Me.CboCodigoBodega.Text = "" Then
                MsgBox("Es necesario que seleccione el tipo de Factura", MsgBoxStyle.Critical, "Sistema Facturacion")
                Exit Sub
            End If


            If Me.TxtCodigoClientes.Text = "" Then
                Exit Sub
            Else

                SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Clientes")
                If DataSet.Tables("Clientes").Rows.Count = 0 Then
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
                    Case "Cotizacion"
                        ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                    Case "Factura"
                        ConsecutivoFactura = BuscaConsecutivo("Factura")
                    Case "Devolucion de Venta"
                        ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                    Case "Transferencia Enviada"
                        ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                End Select
            Else
                ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            End If

            NumeroFactura = Format(ConsecutivoFactura, "0000#")


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaFacturas(NumeroFactura)

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Quien = "NumeroFacturas"
                Me.TxtNumeroEnsamble.Text = NumeroFactura
            End If




            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True

            ActualizaMETODOFactura()

            CodigoProducto = 0
            PrecioUnitario = 0
            Descuento = 0
            PrecioNeto = 0
            Importe = 0
            Cantidad = 0

            Me.TrueDBGridComponentes.Col = 0

            If Acceso <> "Administrador" Then
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////BLOQUEO LOS PRECIOS DESPUES DE ACTUALIZAR////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If Me.CboTipoProducto.Text = "Cotizacion" Then
                    Me.GroupBox3.Enabled = False
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                Else

                    Me.GroupBox3.Enabled = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double

        Try


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

            ActualizaMETODOFactura()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim Cols As Double, Precio As Double, Cantidad As Double, Descuento As Double, SubTotal As Double, Neto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Tasa As Double, SqlProveedor As String
        Dim CodProducto As String, Sql As String, RespuestaIVA As String = "Sumando IVA del Producto", CodImpuesto As String = "", TasaImpuesto As Double
        Dim TipoProducto As String = "Productos", TipoDescuento As String = "ImporteFijo"
        Dim PrecioDescDolar As Double, PrecioDescCordobas As Double, PorcientoDescuento As Double

        Try


            Cols = e.ColIndex

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BUSCO LA CONFIGURACION DEL PRECIO///////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT  * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")) Then
                    RespuestaIVA = DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")
                End If
            End If

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



            Descuento = 0
            Tasa = 0

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
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
                        CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                        Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                        Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                    End If
                    DataSet.Tables("Productos").Clear()


                Case 1
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If

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



            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////BUSCO EL PORCENTAJE DEL IMPUESTO////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT  * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto")
            If DataSet.Tables("Impuesto").Rows.Count <> 0 Then
                TasaImpuesto = DataSet.Tables("Impuesto").Rows(0)("Impuesto")
            Else
                TasaImpuesto = 0
            End If




            If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                If RespuestaIVA = "Sumando IVA del Producto" Then
                    Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
                Else
                    If Me.OptExsonerado.Checked = False Then
                        Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text) / (1 + TasaImpuesto)
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")
                    Else
                        Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
                    End If
                End If
            Else
                Precio = 0
            End If


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


            If Me.TxtCodigoClientes.Text = "" Then
                MsgBox("Es necesario que seleccione un Cliente", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridComponentes.Enabled = False
                Exit Sub
            Else

                SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Clientes")
                If DataSet.Tables("Clientes").Rows.Count = 0 Then
                    MsgBox("El Codigo del Cliente no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
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


            ActualizaMETODOFactura()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeDelete
        Dim SQlString As String, iPosicion As Double, TipoFactura As String, Fecha As String
        Dim Descripcion_Producto As String, CodigoProducto As String, NumeroFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, IdDetalle As Double

        Try



            iPosicion = Me.BindingDetalle.Position

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            Else
                IdDetalle = -1
            End If

            Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            NumeroFactura = Me.TxtNumeroEnsamble.Text


            MiConexion.Close()
            If IdDetalle = -1 Then
                SQlString = "DELETE FROM  Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') AND (Cod_Producto = '" & CodigoProducto & "') AND (Descripcion_Producto = '" & Descripcion_Producto & "')"
            Else
                SQlString = "DELETE FROM  Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') AND (Cod_Producto = '" & CodigoProducto & "') AND (Descripcion_Producto = '" & Descripcion_Producto & "') AND (id_Detalle_Factura = " & IdDetalle & ")"
            End If
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String
        Dim CodProducto As String, TipoProducto As String = "Servicio", TipoDescuento As String = "ImporteFijo", PrecioDescCordobas As Double, PrecioDescDolar As Double
        Dim Cantidad As Double, Precio As Double, SubTotal As Double, PorcientoDescuento As Double, Neto As Double

        Try

            If Me.TxtMonedaFactura.Text = "Dolares" Then
                Quien = "CodigoProductosFactura"
            Else
                Quien = "CodigoProductosCordobas"
            End If
            My.Forms.FrmConsultas.ShowDialog()
            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
            Me.TrueDBGridComponentes.Col = 2

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////BUSCO EL CODIGO PARA EL PRODUCTO///////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CodProducto = My.Forms.FrmConsultas.Codigo
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count <> 0 Then
                TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
            End If

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



            Select Case TipoProducto
                Case "Servicio"
                    SubTotal = Cantidad * Precio
                    Neto = SubTotal
                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")
                Case "Descuento"
                    Neto = Math.Abs(Cantidad * Precio) * -1
                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")

            End Select




            If Acceso <> "Administrador" Then
                If Me.CboTipoProducto.Text = "Cotizacion" Then
                    Me.GroupBox3.Enabled = False
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                Else

                    Me.GroupBox3.Enabled = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                End If
            End If

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = False




        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "FacturasHistoricos"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Nombres <> "******CANCELADO ******" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
            Me.CboCodigoBodega.Enabled = False
            Me.Button7.Enabled = False
        End If
    End Sub

    Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
        Dim ConsecutivoFactura As Double, NumeroFactura As String, iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, Fecha As String, IdDetalle As Double
        Dim Descripcion_Producto As String, TipoFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                         "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            Me.CboTipoProducto.Text = "Factura"
            TipoFactura = "Factura"
            ConsecutivoFactura = BuscaConsecutivo("Factura")
            NumeroFactura = Format(ConsecutivoFactura, "0000#")
            Quien = "NumeroFacturas"
            Me.TxtNumeroEnsamble.Text = "-----0-----"

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaFacturas(NumeroFactura)
            Quien = "NumeroFacturas"
            Me.TxtNumeroEnsamble.Text = NumeroFactura


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            Me.BindingDetalle.MoveFirst()
            Registros = Me.BindingDetalle.Count
            iPosicion = 0

            Do While iPosicion < Registros

                'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                '    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                'Else
                '    IdDetalle = -1
                'End If

                IdDetalle = -1

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                End If
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
                'GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle)


                Select Case Me.CboTipoProducto.Text
                    Case "Factura"
                        ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                End Select

                CodigoProducto = 0
                PrecioUnitario = 0
                Descuento = 0
                PrecioNeto = 0
                Importe = 0
                Cantidad = 0

                iPosicion = iPosicion + 1
            Loop


            '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
            SqlCompras = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFacturas")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        If IsNumeric(Me.TxtDescuento.Text) Then
            ActualizaMETODOFactura()
        Else
            MsgBox("TIENE QUE DIGITAR NUMEROS", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If
    End Sub

    Private Sub OptExsonerado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptExsonerado.CheckedChanged
        'Dim CodImpuesto As String = "", Sql As String, TasaImpuesto As Double
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, RespuestaIVA As String = "Sumando IVA del Producto"
        'Dim Precio As Double, SubTotal As Double, Cantidad As Double, Neto As Double, Descuento As Double

        'Dim iPosicion As Double, Registros As Double, CodProducto As String, SqlProveedor As String

        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0

        'Do While iPosicion < Registros
        '    Precio = 0
        '    Descuento = 0
        '    SubTotal = 0
        '    Cantidad = 0
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '////////////////////////////////////////////BUSCO LA CONFIGURACION DEL PRECIO///////////////////////////////////////////////////
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    Sql = "SELECT  * FROM DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "DatosEmpresa")
        '    If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
        '        If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")) Then
        '            RespuestaIVA = DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")
        '        End If
        '    End If

        '    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '////////////////////////////////BUSCO EL CODIGO DEL IMPUESTO PARA EL PRODUCTO///////////////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    CodProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        '    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        '    DataAdapter.Fill(DataSet, "Productos")
        '    If DataSet.Tables("Productos").Rows.Count <> 0 Then
        '        CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
        '    End If


        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////BUSCO EL PORCENTAJE DEL IMPUESTO////////////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    Sql = "SELECT  * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto")
        '    If DataSet.Tables("Impuesto").Rows.Count <> 0 Then
        '        TasaImpuesto = DataSet.Tables("Impuesto").Rows(0)("Impuesto")
        '    Else
        '        TasaImpuesto = 0
        '    End If




        '    If RespuestaIVA = "Sumando IVA del Producto" Then
        '        Precio = CDbl(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario"))
        '    Else
        '        If Me.OptExsonerado.Checked = False Then
        '            Precio = CDbl(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) / (1 + TasaImpuesto)
        '            'Me.BindingDetalle.Item(iPosicion)("Precio_Unitario") = Format(Precio, "##,##0.00")
        '        Else
        '            Precio = CDbl(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) * (1 + TasaImpuesto)
        '            'Me.BindingDetalle.Item(iPosicion)("Precio_Unitario") = Format(Precio, "##,##0.00")
        '        End If
        '    End If


        '    Cantidad = CDbl(Val(Me.BindingDetalle.Item(iPosicion)("Cantidad")))
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '        Descuento = CDbl(Val(Me.BindingDetalle.Item(iPosicion)("Descuento")))
        '    Else
        '        Descuento = 0
        '    End If

        '    SubTotal = Cantidad * Precio
        '    Neto = SubTotal * (1 - Descuento)
        '    Me.BindingDetalle.Item(iPosicion)("Precio_Neto") = Format(Precio * (1 - Descuento), "##,##0.00")
        '    Me.BindingDetalle.Item(iPosicion)("Importe") = Format(Neto, "##,##0.00")

        '    iPosicion = iPosicion + 1
        'Loop

        ActualizaMETODOFactura()
    End Sub

    Private Sub TrueDBGridComponentes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridComponentes.KeyDown
        Select Case e.KeyCode
            Case 123
                My.Forms.FrmPermisos.ShowDialog()
                If My.Forms.FrmPermisos.RContraseña = True Then
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                End If
        End Select
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SQlString As String, iPosicion As Double, TipoFactura As String, Fecha As String
        Dim Descripcion_Producto As String, CodigoProducto As String, NumeroFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        iPosicion = Me.BindingDetalle.Position
        Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        TipoFactura = Me.CboTipoProducto.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        NumeroFactura = Me.TxtNumeroEnsamble.Text


        MiConexion.Close()
        SQlString = "DELETE FROM  Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') AND (Cod_Producto = '" & CodigoProducto & "') AND (Descripcion_Producto = '" & Descripcion_Producto & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        ActualizaMETODOFactura()




    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class