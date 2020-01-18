Public Class FrmProcesarPlantilla
    Public FacturaInicial As String = "", FacturaFinal As String = ""
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Registros As Double, iPosicion As Double
        Dim ConsecutivoFactura As Double, iPosicion2 As Double, Registros2 As Double, NumeroFactura As String = ""
        Dim Monto As Double, CodigoCliente As String, CodBodega As String, NombreCliente As String = "", ApellidoCliente As String = "", DireccionCliente As String = "", TelefonoCliente As String = ""
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, Descripcion_Producto As String, IdDetalle As Double = -1
        Dim SQlProveedor As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SubTotal As Double, Iva As Double, Pagado As Double, Neto As Double
        Dim Fecha As String = "", FechaVencimiento As String = "", FechaAnterior As Date, Mes As Double, Dia As Double, Año As Double
        Dim i As Double = 0

        Try


            Registros = Me.BindingClientes.Count
            iPosicion = 0


            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = Registros
            Do While iPosicion < Registros

                Me.LblProcesar.Text = "Procesando " & (iPosicion + 1) & " de " & Registros & " Clientes"

                CodigoCliente = Me.BindingClientes.Item(iPosicion)("Cod_Cliente")

                '***************************************************************************************************************
                '   ////////////////////BUSO LOS DATOS DEL CLIENTE /////////////////////////////////////////////////////////
                '***************************************************************************************************************
                SQlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & CodigoCliente & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Clientes")
                If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                    NombreCliente = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
                    If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                        ApellidoCliente = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                    End If
                    If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                        TelefonoCliente = DataSet.Tables("Clientes").Rows(0)("Telefono")
                    Else
                        TelefonoCliente = ""
                    End If
                    If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                        DireccionCliente = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                    Else
                        DireccionCliente = ""
                    End If
                End If

                DataSet.Tables("Clientes").Clear()

                CodBodega = FrmPlantillas.CboCodigoBodega.Text





                If FrmPlantillas.CboTipoProducto.Text = "" Then
                    MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If


                If FrmPlantillas.ChkItem.Checked = False Then

                    '////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////BUSCO EL CONSECUTIVO DE LA FACTURA /////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

                    Select Case FrmPlantillas.CboTipoProducto.Text
                        Case "Cotizacion"
                            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                        Case "Factura"
                            ConsecutivoFactura = BuscaConsecutivo("Factura")
                        Case "Devolucion de Venta"
                            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                        Case "Transferencia Enviada"
                            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                    End Select


                    NumeroFactura = Format(ConsecutivoFactura, "0000#")

                    If FrmPlantillas.TxtSubTotal.Text <> "" Then
                        Subtotal = FrmPlantillas.TxtSubTotal.Text
                    Else
                        Subtotal = 0
                    End If

                    If FrmPlantillas.TxtIva.Text <> "" Then
                        Iva = FrmPlantillas.TxtIva.Text
                    Else
                        Iva = 0
                    End If

                    If FrmPlantillas.TxtPagado.Text <> "" Then
                        Pagado = FrmPlantillas.TxtPagado.Text
                    Else
                        Pagado = 0
                    End If

                    If FrmPlantillas.TxtNetoPagar.Text <> "" Then
                        Neto = FrmPlantillas.TxtNetoPagar.Text
                    Else
                        Neto = 0
                    End If

                    Fecha = Format(FrmPlantillas.DTPFecha.Value, "yyyy-MM-dd")
                    FechaVencimiento = DateAdd(DateInterval.Day, Val(FrmPlantillas.TxtDiasVencimiento.Value), FrmPlantillas.DTPFecha.Value)

                    '////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                    GrabaFacturasPlantillas(NumeroFactura, CodigoCliente, CodBodega, NombreCliente, ApellidoCliente, DireccionCliente, TelefonoCliente, SubTotal, Iva, Pagado, Neto, Fecha, FechaVencimiento)


                    '////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

                    If iPosicion = 0 Then
                        FacturaInicial = NumeroFactura
                    End If

                    FrmPlantillas.BindingDetalle.MoveFirst()
                    Registros2 = FrmPlantillas.BindingDetalle.Count
                    iPosicion2 = 0
                    Monto = 0
                    Do While iPosicion2 < Registros2



                        If Not IsDBNull(FrmPlantillas.BindingDetalle.Item(iPosicion2)("id_Detalle_Plantilla")) Then
                            IdDetalle = FrmPlantillas.BindingDetalle.Item(iPosicion2)("id_Detalle_Plantilla")
                        Else
                            IdDetalle = -1
                        End If

                        CodigoProducto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Cod_Productos")

                        PrecioUnitario = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Precio_Unitario")
                        If Not IsDBNull(FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descuento")) Then
                            Descuento = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descuento")
                        End If
                        PrecioNeto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Precio_Neto")
                        Importe = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Importe")
                        Cantidad = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Cantidad")
                        Descripcion_Producto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descripcion_Producto")
                        Fecha = Format(FrmPlantillas.DTPFecha.Value, "yyyy-MM-dd")

                        GrabaDetalleFacturaPlantilla(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CDate(Fecha))

                        Select Case FrmPlantillas.CboTipoProducto.Text
                            Case "Factura"
                                DiferenciaCantidad = CDbl(Cantidad)
                                DiferenciaPrecio = CDbl(PrecioNeto)
                                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, FrmPlantillas.CboTipoProducto.Text, CodBodega)
                            Case "Devolucion de Venta"
                                DiferenciaCantidad = CDbl(Cantidad)
                                DiferenciaPrecio = CDbl(PrecioNeto)
                                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, FrmPlantillas.CboTipoProducto.Text, FrmPlantillas.CboCodigoBodega.Text)
                        End Select

                        iPosicion2 = iPosicion2 + 1
                        Me.ProgressBar1.Value = iPosicion2
                    Loop

                Else
                    '**************************************************************************************************************************************************
                    '   /////////////////////////////SI TIENEN EL CHECK HAGO UNA FACTURA POR ITEM /////////////////////////////////////////////////////////////////
                    '**************************************************************************************************************************************************

                    FrmPlantillas.BindingDetalle.MoveFirst()
                    Registros2 = FrmPlantillas.BindingDetalle.Count
                    iPosicion2 = 0
                    Monto = 0

                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = Registros2

                    Do While iPosicion2 < Registros2

                        '////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA FACTURA /////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

                        Select Case FrmPlantillas.CboTipoProducto.Text
                            Case "Cotizacion"
                                ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                            Case "Factura"
                                ConsecutivoFactura = BuscaConsecutivo("Factura")
                            Case "Devolucion de Venta"
                                ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                            Case "Transferencia Enviada"
                                ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                        End Select

                        NumeroFactura = Format(ConsecutivoFactura, "0000#")


                        SubTotal = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Importe")
                        Iva = 0
                        Pagado = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Importe")
                        Neto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Importe")

                        If iPosicion2 = 0 Then
                            Mes = Month(FrmPlantillas.DTPFecha.Value)
                            Dia = 1
                            Año = Year(FrmPlantillas.DTPFecha.Value)
                            Fecha = Format(FrmPlantillas.DTPFecha.Value, "yyyy-MM-dd")
                            FechaVencimiento = DateAdd(DateInterval.Day, Val(FrmPlantillas.TxtDiasVencimiento.Value), FrmPlantillas.DTPFecha.Value)
                            FechaAnterior = Fecha
                            i = i + 1
                        Else
                            Mes = Month(FechaAnterior)
                            Dia = 1
                            Año = Year(FechaAnterior)
                            Fecha = DateSerial(Año, Mes + 1, 1)
                            FechaAnterior = Fecha
                            FechaVencimiento = DateAdd(DateInterval.Day, Val(FrmPlantillas.TxtDiasVencimiento.Value), FechaAnterior)
                            i = i + 1
                        End If

                        '////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                        GrabaFacturasPlantillas(NumeroFactura, CodigoCliente, CodBodega, NombreCliente, ApellidoCliente, DireccionCliente, TelefonoCliente, SubTotal, Iva, Pagado, Neto, Fecha, FechaVencimiento)


                        '////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

                        If Not IsDBNull(FrmPlantillas.BindingDetalle.Item(iPosicion2)("id_Detalle_Plantilla")) Then
                            IdDetalle = FrmPlantillas.BindingDetalle.Item(iPosicion2)("id_Detalle_Plantilla")
                        Else
                            IdDetalle = -1
                        End If

                        CodigoProducto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Cod_Productos")

                        PrecioUnitario = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Precio_Unitario")
                        If Not IsDBNull(FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descuento")) Then
                            Descuento = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descuento")
                        End If
                        PrecioNeto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Precio_Neto")
                        Importe = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Importe")
                        Cantidad = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Cantidad")
                        Descripcion_Producto = FrmPlantillas.BindingDetalle.Item(iPosicion2)("Descripcion_Producto")
                        GrabaDetalleFacturaPlantilla(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CDate(Fecha))

                        Select Case FrmPlantillas.CboTipoProducto.Text
                            Case "Factura"
                                DiferenciaCantidad = CDbl(Cantidad)
                                DiferenciaPrecio = CDbl(PrecioNeto)
                                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, FrmPlantillas.CboTipoProducto.Text, CodBodega)
                            Case "Devolucion de Venta"
                                DiferenciaCantidad = CDbl(Cantidad)
                                DiferenciaPrecio = CDbl(PrecioNeto)
                                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, FrmPlantillas.CboTipoProducto.Text, FrmPlantillas.CboCodigoBodega.Text)
                        End Select



                        iPosicion2 = iPosicion2 + 1
                        Me.ProgressBar1.Value = iPosicion2
                    Loop
                End If





                iPosicion = iPosicion + 1
                If iPosicion = Registros Then
                    FacturaInicial = NumeroFactura
                End If


                Me.ProgressBar.Value = iPosicion
            Loop


        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmProcesarPlantilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class