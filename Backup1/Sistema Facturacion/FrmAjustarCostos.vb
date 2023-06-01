Public Class FrmAjustarCostos
    Public MostrarImagen As Boolean = False, ImagenReporte As Integer, Registros As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        My.Application.DoEvents()

        If MostrarImagen = False Then
            Me.Imagen.Visible = False
        Else
            Me.Imagen.Visible = True
        End If

        If ImagenReporte = 3 Then
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            ImagenReporte = 0

        ElseIf ImagenReporte = 0 Then
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            ImagenReporte = ImagenReporte + 1

        Else
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            ImagenReporte = ImagenReporte + 1

        End If
    End Sub

    Private Sub FrmAjustarCostos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub FrmActualizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Application.DoEvents()
        Imagen.Visible = True
        MostrarImagen = True

        Dim i As Integer, CodProducto As String

        For i = 0 To Registros - 1
            My.Application.DoEvents()
            CodProducto = CodigoProducto(i)
            Costear(CodProducto, CodProducto)
        Next
    End Sub

    Public Sub Costear(ByVal Desde As String, ByVal Hasta As String)
        Dim iPosicionFila As Double, PrecioCostoDolar As Double, NumeroFactura As String = "", TipoSalida As String = "", FechaCompra As Date
        Dim DataSet As New DataSet, SQLProductos As String, PrecioCosto As Double, iPosicionFila2 As Double = 0, iPosicionFila3 As Double = 0
        Dim DataAdapter As New SqlClient.SqlDataAdapter, RegistrosMaximos As Double, SqlSTring As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim CodProductos As String, DescripcionProducto As String, Contador As Double = 0, j As Double = 0, iResultado As Integer
        Dim Cantidad As Double = 0, Registros As Double = 0, PrecioUnitario As Double = 0, StrSQLUpdate As String


        If Desde = "" And Hasta = "" Then
            SQLProductos = "SELECT * FROM Productos "
        Else
            SQLProductos = "SELECT * FROM Productos WHERE (Cod_Productos BETWEEN '" & Desde & "' AND '" & Hasta & "')"
        End If



        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar5.Minimum = 0
            Me.ProgressBar5.Visible = True
            Me.ProgressBar5.Value = 0
            Me.ProgressBar5.Maximum = DataSet.Tables("ListaProductos").Rows.Count
            RegistrosMaximos = DataSet.Tables("ListaProductos").Rows.Count

            Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                'Me.Text = "Procesando " & Me.ProgressBar5.Value + 1 & " de " & RegistrosMaximos
                My.Application.DoEvents()
                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                DescripcionProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Descripcion_Producto"))
                Me.Text = "Procesando " & DescripcionProducto



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////EL DETALLE DE LA FACTURA LA LLENO DE CERO PARA EL COSTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////
                StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = 0  WHERE (Cod_Producto = '" & CodProductos & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////
                SqlSTring = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                            "WHERE (DetalleBodegas.Cod_Productos = '" & CodProductos & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                DataAdapter.Fill(DataSet, "Bodegas")


                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////ASIGNO EL COSTO A TODAS LAS SALIDAS DE ESTE PRODUCTO Y BODEGA/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                'SqlSTring = "SELECT  * FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Facturas.Cod_Bodega = '" & CodigoBodega & "') AND (Facturas.Tipo_Factura <> 'Cotizacion') ORDER BY Facturas.Fecha_Factura"
                SqlSTring = "SELECT  * FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "')  AND (Facturas.Tipo_Factura <> 'Cotizacion') ORDER BY Facturas.Fecha_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                DataAdapter.Fill(DataSet, "Salidas")
                iPosicionFila3 = 0
                Me.ProgressBar4.Minimum = 0
                Me.ProgressBar4.Visible = True
                Me.ProgressBar4.Value = 0
                Me.ProgressBar4.Maximum = DataSet.Tables("Salidas").Rows.Count
                Do While iPosicionFila3 < (DataSet.Tables("Salidas").Rows.Count)

                    FechaCompra = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Fecha_Factura")
                    NumeroFactura = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Numero_Factura")
                    If Not IsDBNull(DataSet.Tables("Salidas").Rows(iPosicionFila3)("Cantidad")) Then
                        Cantidad = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Cantidad")
                    End If
                    TipoSalida = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Tipo_Factura")
                    PrecioCosto = CostoPromedioKardex(CodProductos, FechaCompra)
                    PrecioCostoDolar = CostoPromedioDolar
                    PrecioUnitario = PrecioCosto
                    'PrecioUnitario = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Precio_Unitario")
                    'PrecioCosto = CostoPromedioActualizaBodega(CodProductos, FechaCompra, CodigoBodega)
                    'PrecioCostoDolar = CostoPromedioDolar
                    Me.Text = "Procesando el Producto: " & CodProductos & "Factura No" & NumeroFactura
                    My.Application.DoEvents()

                    '///////////SI EL COSTO ES CERO PERO SE DESCARGAR, SIGNIFICA FACTURACION EN NEGATIVO ///////////
                    If Cantidad <> 0 Then
                        If PrecioCosto = 0 Then
                            SqlSTring = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Costo_Unitario / TasaCambio.MontoTasa AS Costo_UnitarioDolar FROM Detalle_Facturas INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                        "WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Detalle_Facturas.Costo_Unitario <> 0) AND (Detalle_Facturas.Fecha_Factura <= CONVERT(DATETIME,'" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Facturas.Fecha_Factura"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                            DataAdapter.Fill(DataSet, "UltimoCosto")
                            If DataSet.Tables("UltimoCosto").Rows.Count <> 0 Then
                                Registros = DataSet.Tables("UltimoCosto").Rows.Count
                                PrecioCosto = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_Unitario")
                                PrecioCostoDolar = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_UnitarioDolar")
                            End If
                            DataSet.Tables("UltimoCosto").Reset()

                        End If
                    End If


                    If TipoSalida = "Transferencia Enviada" Then
                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA ENTRADA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Compras] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Compra = '" & NumeroFactura & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    ElseIf TipoSalida = "Salida Bodega" Then
                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        'StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioUnitario) & "' WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Salida Bodega') AND (Cod_Producto = '" & CodProductos & "')"
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Salida Bodega') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    Else

                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "' WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoSalida & "') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If

                    iPosicionFila3 = iPosicionFila3 + 1
                    Me.ProgressBar4.Value = iPosicionFila3
                Loop
                DataSet.Tables("Salidas").Reset()


                DataSet.Tables("Bodegas").Reset()


                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar5.Value = iPosicionFila
            Loop


        End If
    End Sub



End Class