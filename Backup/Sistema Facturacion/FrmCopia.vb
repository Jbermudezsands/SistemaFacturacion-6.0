Public Class FrmCopia
    Public TipoCopia As String, Contador As Double = 0

    Private Sub FrmCopia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtDestino.Text = Conexion
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = 0
    End Sub
    Public Sub BacktoLifeRecibos(ByVal OrigenCS As System.Data.SqlClient.SqlConnection, ByVal DestinoCS As System.Data.SqlClient.SqlConnection)
        Dim TablaRecibos, TablaDetalle_Recibos, TablaAuxiliar As New DataTable, Counter As Integer = 0
        Dim Command As SqlClient.SqlCommand

        '/////// Recibos ///////

        'Saco los datos a rescatar, datos de origen.
        Dim Adaptor As New SqlClient.SqlDataAdapter("SELECT     CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, Sub_Total, Descuento, Total, NombreCliente, ApellidosCliente, DireccionCliente, TelefonoCliente, MonedaRecibo, Activo, Contabilizado,    Marca, Observaciones  FROM    Recibo", OrigenCS)
        Adaptor.Fill(TablaAuxiliar)

        Dim MayorCounter As Integer = 0
        'Recorro e inyecto cada uno de los recibos que no existen

        Me.ProgressBar.Value = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = TablaAuxiliar.Rows.Count
        Contador = 0

        Do While MayorCounter < TablaAuxiliar.Rows.Count
            TablaRecibos = New DataTable

            'Busco si existe el recibo, si no existe lo inserto si no no lo hace.
            Adaptor = New SqlClient.SqlDataAdapter("SELECT     CodReciboPago, Fecha_Recibo, Cod_Cliente,Cod_Cajero, Sub_Total, Descuento, Total, NombreCliente, ApellidosCliente, DireccionCliente, TelefonoCliente, MonedaRecibo, Activo, Contabilizado,    Marca, Observaciones  FROM    Recibo Where CodReciboPago = '" & TablaAuxiliar.Rows(MayorCounter)("CodReciboPago") & "'", DestinoCS)
            Adaptor.Fill(TablaRecibos)

            If TablaRecibos.Rows.Count = 0 Then
                Contador = Contador + 1
                Command = New SqlClient.SqlCommand("INSERT INTO [Recibo] ([CodReciboPago] ,[Fecha_Recibo] ,[Cod_Cliente] ,[Cod_Cajero] ,[Sub_Total]  ,[Descuento] ,[Total]  ,[NombreCliente] ,[ApellidosCliente]  ,[DireccionCliente]  ,[TelefonoCliente] ,[MonedaRecibo] ,[Activo] ,[Contabilizado] ,[Marca] ,[Observaciones])  VALUES   ( '" & TablaAuxiliar.Rows(MayorCounter)("CodReciboPago") & "'  , '" & Format(TablaAuxiliar.Rows(MayorCounter)("Fecha_Recibo"), "dd/MM/yyyy") & "'  , '" & TablaAuxiliar.Rows(MayorCounter)("Cod_Cliente") & "'  , '" & TablaAuxiliar.Rows(MayorCounter)("Cod_Cajero") & "'   , " & TablaAuxiliar.Rows(MayorCounter)("Sub_Total") & "  , " & TablaAuxiliar.Rows(MayorCounter)("Descuento") & "  , " & TablaAuxiliar.Rows(MayorCounter)("Total") & " , '" & TablaAuxiliar.Rows(MayorCounter)("NombreCliente") & "' , '" & TablaAuxiliar.Rows(MayorCounter)("ApellidosCliente") & "' , '" & TablaAuxiliar.Rows(MayorCounter)("DireccionCliente") & "'  , '" & TablaAuxiliar.Rows(MayorCounter)("TelefonoCliente") & "' , '" & TablaAuxiliar.Rows(MayorCounter)("MonedaRecibo") & "'  , '" & TablaAuxiliar.Rows(MayorCounter)("Activo") & "' ,  '" & TablaAuxiliar.Rows(MayorCounter)("Contabilizado") & "'  , '" & TablaAuxiliar.Rows(MayorCounter)("Marca") & "' , '" & TablaAuxiliar.Rows(MayorCounter)("Observaciones") & "' )", DestinoCS)
                DestinoCS.Open()
                Command.ExecuteNonQuery()
                DestinoCS.Close()

                TablaDetalle_Recibos = New DataTable

                'Busco si existe la factura, si no existe lo inserta si no no lo hace.
                Adaptor = New SqlClient.SqlDataAdapter("SELECT     idDetalleRecibo, CodReciboPago, Fecha_Recibo, Numero_Factura, MontoPagado, NombrePago, Descripcion, NumeroTarjeta, FechaVence, MontoFactura, AplicaFactura, SaldoFactura,       TasaCambio FROM         DetalleRecibo Where CodReciboPago = '" & TablaAuxiliar.Rows(MayorCounter)("CodReciboPago") & "'", OrigenCS)
                Adaptor.Fill(TablaDetalle_Recibos)
                Counter = 0

                Dim SaldoFactura, MontoFactura, AplicaFactura, TasaCambio As Double

                Do While Counter < TablaDetalle_Recibos.Rows.Count

                    If IsDBNull(TablaDetalle_Recibos.Rows(Counter)("MontoFactura")) Then
                        MontoFactura = 0
                    Else
                        MontoFactura = TablaDetalle_Recibos.Rows(Counter)("MontoFactura")
                    End If


                    If IsDBNull(TablaDetalle_Recibos.Rows(Counter)("SaldoFactura")) Then
                        SaldoFactura = 0
                    Else
                        SaldoFactura = TablaDetalle_Recibos.Rows(Counter)("SaldoFactura")
                    End If


                    If IsDBNull(TablaDetalle_Recibos.Rows(Counter)("AplicaFactura")) Then
                        AplicaFactura = 0
                    Else
                        AplicaFactura = TablaDetalle_Recibos.Rows(Counter)("AplicaFactura")
                    End If


                    If IsDBNull(TablaDetalle_Recibos.Rows(Counter)("TasaCambio")) Then
                        TasaCambio = 0
                    Else
                        TasaCambio = TablaDetalle_Recibos.Rows(Counter)("TasaCambio")
                    End If



                    Command = New SqlClient.SqlCommand("INSERT INTO [DetalleRecibo] ([CodReciboPago]  ,[Fecha_Recibo]  ,[Numero_Factura] ,[MontoPagado]  ,[NombrePago]   ,[Descripcion]  ,[NumeroTarjeta]  ,[FechaVence]  ,[MontoFactura] ,[AplicaFactura] ,[SaldoFactura] ,[TasaCambio]) VALUES  ('" & TablaDetalle_Recibos.Rows(Counter)("CodReciboPago") & "'  ,'" & Format(TablaDetalle_Recibos.Rows(Counter)("Fecha_Recibo"), "dd/MM/yyyy") & "' , '" & TablaDetalle_Recibos.Rows(Counter)("Numero_Factura") & "'   ," & TablaDetalle_Recibos.Rows(Counter)("MontoPagado") & "  , '" & TablaDetalle_Recibos.Rows(Counter)("NombrePago") & "' , '" & TablaDetalle_Recibos.Rows(Counter)("Descripcion") & "'  , '" & TablaDetalle_Recibos.Rows(Counter)("NumeroTarjeta") & "' , '" & Format(TablaDetalle_Recibos.Rows(Counter)("FechaVence"), "dd/MM/yyyy") & "' ," & MontoFactura & " , " & AplicaFactura & " ," & SaldoFactura & " , " & TasaCambio & ")", DestinoCS)
                    DestinoCS.Open()
                    Command.ExecuteNonQuery()
                    DestinoCS.Close()
                    Counter = Counter + 1
                Loop






                Counter = 0


                TablaDetalle_Recibos = New DataTable
                'Busco si existe la factura, si no existe lo inserta si no no lo hace.
                Adaptor = New SqlClient.SqlDataAdapter("SELECT     idDetalle_Recibo, CodRecibo, Fecha_Recibo, NombrePago, Monto, NumeroTarjeta, Fecha_Vence, Arqueado  FROM         Detalle_MetodoRecibo Where CodRecibo = '" & TablaAuxiliar.Rows(MayorCounter)("CodReciboPago") & "'", OrigenCS)
                Adaptor.Fill(TablaDetalle_Recibos)

                Do While Counter < TablaDetalle_Recibos.Rows.Count

                    Command = New SqlClient.SqlCommand("INSERT INTO [Detalle_MetodoRecibo] ([CodRecibo]   ,[Fecha_Recibo] ,[NombrePago]     ,[Monto]  ,[NumeroTarjeta]  ,[Fecha_Vence]  ,[Arqueado])  VALUES ('" & TablaDetalle_Recibos.Rows(Counter)("CodRecibo") & "'  , '" & Format(TablaDetalle_Recibos.Rows(Counter)("Fecha_Recibo"), "dd/MM/yyyy") & "' , '" & TablaDetalle_Recibos.Rows(Counter)("NombrePago") & "'  ," & TablaDetalle_Recibos.Rows(Counter)("Monto") & " , '" & TablaDetalle_Recibos.Rows(Counter)("NumeroTarjeta") & "' , '" & TablaDetalle_Recibos.Rows(Counter)("Fecha_Vence") & "' , '" & TablaDetalle_Recibos.Rows(Counter)("Arqueado") & "')", DestinoCS)
                    DestinoCS.Open()
                    Command.ExecuteNonQuery()
                    DestinoCS.Close()


                    Counter = Counter + 1
                Loop



            End If

            MayorCounter = MayorCounter + 1
            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
        Loop



    End Sub


    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrecios.Click
        Dim mydlg As New MSDASC.DataLinks
        Dim ADOcon As New ADODB.Connection


        Try


            ADOcon = mydlg.PromptNew
            If Not IsDBNull(ADOcon.ConnectionString) Then
                Me.TxtConexion.Text = ADOcon.ConnectionString
            Else
                Me.TxtConexion.Text = ""
            End If

            'Dim RutaReportes As String
            'RutaReportes = My.Application.Info.DirectoryPath & "\CreateConnectString.exe"
            'Shell(RutaReportes)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim ConexionOrigen As String = Me.TxtConexion.Text, Registros As Double, i As Double
        Dim ConexionDestino As String = Me.TxtDestino.Text
        Dim NumeroCompra As String, FechaCompra As Date, TipoCompra As String
        Dim MiConexion As New SqlClient.SqlConnection(ConexionDestino), MiConexionOrigen As New SqlClient.SqlConnection(ConexionOrigen)
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, RegDetalle As Double, i2 As Double
        Dim Exonerado As Double, StrSqlUpdate As String = "", Descuento As Double


        Contador = 0

        Select Case TipoCopia
            Case "Recibos"

                BacktoLifeRecibos(MiConexionOrigen, MiConexion)


            Case "Productos"
                Dim CodigoProducto As String = "", Iposicion As Double = 0, SQLProductos As String, CodBodega As String = ""

                '--------------------------------------------------------------------------------------------
                '---------------------------CARGO EL DATASET DE LA COMPRA ORIGEN ----------------------------
                '--------------------------------------------------------------------------------------------
                SqlDatos = "SELECT  *  FROM Productos"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionOrigen)
                DataAdapter.Fill(DataSet, "ProductoOrigen")
                Registros = DataSet.Tables("ProductoOrigen").Rows.Count
                i = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Maximum = Registros
                Contador = 0

                Do While Registros > i
                    CodigoProducto = DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Productos")

                    SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionDestino)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If DataSet.Tables("Consulta").Rows.Count = 0 Then

                        MiConexion.Close()
                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                        StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Cod_Linea],[Tipo_Producto],[Cod_Cuenta_Inventario],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro],[Porcentaje_Aumento],[Rendimiento]) " & _
                                       "VALUES('" & CodigoProducto & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Descripcion_Producto") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Ubicacion") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Linea") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Tipo_Producto") & "' ,'" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Cuenta_Inventario") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Cuenta_Costo") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Cuenta_Ventas") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Unidad_Medida") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Precio_Venta") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Precio_Lista") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Descuento") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Existencia_Negativa") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Iva") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Activo") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Minimo") & "' ,'" & DataSet.Tables("ProductoOrigen").Rows(i)("Reorden") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Nota") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Cuenta_GastoAjuste") & "','" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Cuenta_IngresoAjuste") & "'," & DataSet.Tables("ProductoOrigen").Rows(i)("CodComponente") & ",'" & DataSet.Tables("ProductoOrigen").Rows(i)("Cod_Rubro") & "'," & DataSet.Tables("ProductoOrigen").Rows(i)("Porcentaje_Aumento") & "," & DataSet.Tables("ProductoOrigen").Rows(i)("Rendimiento") & ")"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery

                        Contador = Contador + 1

                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////////////////////BUSCO LAS BODEGAS//////////////////////////////////////////////////////////////////////////
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Iposicion = 0
                        SQLProductos = "SELECT  *  FROM Bodegas "
                        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                        DataAdapter.Fill(DataSet, "Bodegas")
                        Do While Iposicion < DataSet.Tables("Bodegas").Rows.Count
                            CodBodega = DataSet.Tables("Bodegas").Rows(Iposicion)("Cod_Bodega")

                            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '/////////////////////////////////////BUSCO SI EXISTE EN LAS BODEGAS DETALLES///////////////////////////////////////////////////////
                            '(//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            SQLProductos = "SELECT  * FROM DetalleBodegas WHERE (Cod_Productos = '" & CodigoProducto & "') AND (Cod_Bodegas = '" & CodBodega & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                            DataAdapter.Fill(DataSet, "DetalleBodegas")
                            If DataSet.Tables("DetalleBodegas").Rows.Count = 0 Then
                                StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                                               "VALUES('" & CodBodega & "','" & CodigoProducto & "') "
                                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                                iResultado = ComandoUpdate.ExecuteNonQuery
                            End If
                            DataSet.Tables("DetalleBodegas").Reset()
                            Iposicion = Iposicion + 1
                        Loop

                        MiConexion.Close()


                    End If


                    DataSet.Tables("Consulta").Reset()

                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1
                Loop





            Case "Factura"

                Dim NumeroFactura As String, FechaFactura As Date, TipoFactura As String
                Dim MontoIva As Double = 0, MontoPagado As Double = 0, MontoNetoPagar As Double = 0, MontoCredito As Double = 0, SubTotal As Double = 0
                Dim MontoRentencion1 As Double, MontoRetencion2 As Double, ViaEmbarque As String = "", FechaEnvio As Date = "01/01/1900", FechaDescuento As Date
                Dim CodVendedor As String, CostoUnitario As Double = 0

                '--------------------------------------------------------------------------------------------
                '---------------------------CARGO EL DATASET DE LA COMPRA ORIGEN ----------------------------
                '--------------------------------------------------------------------------------------------
                SqlDatos = "SELECT  * FROM  Facturas "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionOrigen)
                DataAdapter.Fill(DataSet, "FacturasOrigen")
                Registros = DataSet.Tables("FacturasOrigen").Rows.Count
                i = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Maximum = Registros
                Contador = 0

                Do While Registros > i

                    NumeroFactura = DataSet.Tables("FacturasOrigen").Rows(i)("Numero_Factura")
                    FechaFactura = DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Factura")
                    TipoFactura = DataSet.Tables("FacturasOrigen").Rows(i)("Tipo_Factura")

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("IVA")) Then
                        MontoIva = DataSet.Tables("FacturasOrigen").Rows(i)("IVA")
                    Else
                        MontoIva = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("Pagado")) Then
                        MontoPagado = DataSet.Tables("FacturasOrigen").Rows(i)("Pagado")
                    Else
                        MontoPagado = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("NetoPagar")) Then
                        MontoNetoPagar = DataSet.Tables("FacturasOrigen").Rows(i)("NetoPagar")
                    Else
                        MontoNetoPagar = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("MontoCredito")) Then
                        MontoCredito = DataSet.Tables("FacturasOrigen").Rows(i)("MontoCredito")
                    Else
                        MontoCredito = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("SubTotal")) Then
                        SubTotal = DataSet.Tables("FacturasOrigen").Rows(i)("SubTotal")
                    Else
                        SubTotal = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion1Porciento")) Then
                        MontoRentencion1 = DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion1Porciento")
                    Else
                        MontoRentencion1 = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion2Porciento")) Then
                        MontoRetencion2 = DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion2Porciento")
                    Else
                        MontoRetencion2 = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion2Porciento")) Then
                        MontoRetencion2 = DataSet.Tables("FacturasOrigen").Rows(i)("MontoRetencion2Porciento")
                    Else
                        MontoRetencion2 = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Envio")) Then
                        FechaEnvio = DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Envio")
                    Else
                        FechaEnvio = "01/01/1900"
                    End If

                    If Not IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Descuento")) Then
                        FechaDescuento = DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Descuento")
                    Else
                        FechaDescuento = "01/01/1900"
                    End If

                    If IsDBNull(DataSet.Tables("FacturasOrigen").Rows(i)("Cod_Vendedor")) Then
                        CodVendedor = "01"
                    Else
                        CodVendedor = DataSet.Tables("FacturasOrigen").Rows(i)("Cod_Vendedor")
                    End If



                    'If NumeroCompra = "00337" Then
                    '    NumeroCompra = DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Compra")
                    'End If

                    If TipoFactura <> "" Then
                        '-------------------------------CONSULTO SI EXISTE EL REGISTRO ------------------------------
                        SqlDatos = "SELECT  * FROM  Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionDestino)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If DataSet.Tables("Consulta").Rows.Count = 0 Then

                            If DataSet.Tables("FacturasOrigen").Rows(i)("Exonerado") = "False" Then
                                Exonerado = 0
                            Else
                                Exonerado = 1
                            End If

                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlDatos = "INSERT INTO [Facturas]  ([Numero_Factura],[Fecha_Factura],[Tipo_Factura],[MonedaFactura] ,[Cod_Cliente] ,[Cod_Bodega],[Cod_Vendedor],[Cod_Cajero],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono_Cliente],[Fecha_Vencimiento],[Observaciones],[Fecha_Envio],[Via_Envarque],[Descuento],[Fecha_Descuento],[Su_Referencia],[Nuestra_Referencia],[SubTotal],[IVA],[Pagado],[NetoPagar],[MontoCredito],[Contabilizado],[Activo],[Cancelado],[MetodoPago],[Exonerado],[Descuentos],[Marca],[FechaPago],[TransferenciaProcesada] ,[MonedaImprime],[CodigoProyecto],[Retener1Porciento] ,[Retener2Porciento],[MontoRetencion1Porciento],[MontoRetencion2Porciento],[Referencia]) " & _
                                       "VALUES ('" & NumeroFactura & "','" & FechaFactura & "','" & TipoFactura & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("MonedaFactura") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Cod_Cliente") & "' , '" & DataSet.Tables("FacturasOrigen").Rows(i)("Cod_Bodega") & "','" & CodVendedor & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Cod_Cajero") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Nombre_Cliente") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Apellido_Cliente") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Direccion_Cliente") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Telefono_Cliente") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Fecha_Vencimiento") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Observaciones") & "','" & FechaEnvio & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Via_Envarque") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Descuento") & "','" & FechaDescuento & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Su_Referencia") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Nuestra_Referencia") & "','" & SubTotal & "','" & MontoIva & "','" & MontoPagado & "','" & MontoNetoPagar & "' ,'" & MontoCredito & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Contabilizado") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Activo") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("Cancelado") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("MetodoPago") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Exonerado") & "' ," & DataSet.Tables("FacturasOrigen").Rows(i)("Descuentos") & " ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Marca") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("FechaPago") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("TransferenciaProcesada") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("MonedaImprime") & "','" & DataSet.Tables("FacturasOrigen").Rows(i)("CodigoProyecto") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Retener1Porciento") & "' ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Retener2Porciento") & "' ," & MontoRentencion1 & " ," & MontoRetencion2 & " ,'" & DataSet.Tables("FacturasOrigen").Rows(i)("Referencia") & "') "
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlDatos, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()


                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////AGREGO EL DETALLE DE LA FACTURA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlDatos = "SELECT  * FROM Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionOrigen)
                            DataAdapter.Fill(DataSet, "ConsultaDetalle")
                            RegDetalle = DataSet.Tables("ConsultaDetalle").Rows.Count
                            i2 = 0
                            Do While RegDetalle > i2

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Costo_Unitario")) Then
                                    CostoUnitario = DataSet.Tables("ConsultaDetalle").Rows(i2)("Costo_Unitario")
                                Else
                                    CostoUnitario = 0
                                End If


                                SqlDatos = "INSERT INTO [Detalle_Facturas] ([Numero_Factura],[Fecha_Factura],[Tipo_Factura],[Cod_Producto],[Descripcion_Producto],[Cantidad],[Precio_Unitario],[Precio_Neto],[Importe],[TasaCambio],[CodTarea],[Costo_Unitario],[Descuento],[NoPresupuesto]) " & _
                                            "VALUES ('" & NumeroFactura & "','" & FechaFactura & "','" & TipoFactura & "','" & DataSet.Tables("ConsultaDetalle").Rows(i2)("Cod_Producto") & "' ,'" & DataSet.Tables("ConsultaDetalle").Rows(i2)("Descripcion_Producto") & "'," & DataSet.Tables("ConsultaDetalle").Rows(i2)("Cantidad") & "," & DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Unitario") & " ," & DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Neto") & "," & DataSet.Tables("ConsultaDetalle").Rows(i2)("Importe") & "," & DataSet.Tables("ConsultaDetalle").Rows(i2)("TasaCambio") & " ,'" & DataSet.Tables("ConsultaDetalle").Rows(i2)("CodTarea") & "'," & CostoUnitario & ", '" & DataSet.Tables("ConsultaDetalle").Rows(i2)("Descuento") & "', '" & DataSet.Tables("ConsultaDetalle").Rows(i2)("NoPresupuesto") & "' )"
                                MiConexion.Open()
                                ComandoUpdate = New SqlClient.SqlCommand(SqlDatos, MiConexion)
                                iResultado = ComandoUpdate.ExecuteNonQuery
                                MiConexion.Close()


                                i2 = i2 + 1
                            Loop
                            DataSet.Tables("ConsultaDetalle").Reset()


                            Contador = Contador + 1


                        End If
                        DataSet.Tables("Consulta").Reset()


                    End If
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1

                Loop


            Case "Compra"

                Dim MontoIva As Double = 0, MontoPagado As Double = 0, MontoNetoPagar As Double = 0, MontoCredito As Double = 0, SubTotal As Double = 0
                Dim Cantidad As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, TasaCambio As Double
                Dim FechaHora As Date, TipoProductor As String, Estatus As String, NumeroSolicitud As String, NumeroOrden As String, Descripcion As String

                '--------------------------------------------------------------------------------------------
                '---------------------------CARGO EL DATASET DE LA COMPRA ORIGEN ----------------------------
                '--------------------------------------------------------------------------------------------
                SqlDatos = "SELECT  * FROM  Compras "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionOrigen)
                DataAdapter.Fill(DataSet, "ComprasOrigen")
                Registros = DataSet.Tables("ComprasOrigen").Rows.Count
                i = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Maximum = Registros
                Contador = 0

                Do While Registros > i


                    MontoPagado = 0
                    MontoNetoPagar = 0
                    MontoCredito = 0
                    SubTotal = 0


                    NumeroCompra = DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Compra")
                    FechaCompra = DataSet.Tables("ComprasOrigen").Rows(i)("Fecha_Compra")
                    TipoCompra = DataSet.Tables("ComprasOrigen").Rows(i)("Tipo_Compra")

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("FechaHora")) Then
                        FechaHora = DataSet.Tables("ComprasOrigen").Rows(i)("FechaHora")
                    Else
                        FechaHora = FechaCompra
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("TipoProductor")) Then
                        TipoProductor = DataSet.Tables("ComprasOrigen").Rows(i)("TipoProductor")
                    Else
                        TipoProductor = ""
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("Estatus")) Then
                        Estatus = DataSet.Tables("ComprasOrigen").Rows(i)("Estatus")
                    Else
                        Estatus = ""
                    End If


                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Solicitud")) Then
                        NumeroSolicitud = DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Solicitud")
                    Else
                        NumeroSolicitud = ""
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Orden")) Then
                        NumeroOrden = DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Orden")
                    Else
                        NumeroOrden = ""
                    End If


                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("IVA")) Then
                        MontoIva = DataSet.Tables("ComprasOrigen").Rows(i)("IVA")
                    Else
                        MontoIva = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("Pagado")) Then
                        MontoPagado = DataSet.Tables("ComprasOrigen").Rows(i)("Pagado")
                    Else
                        MontoPagado = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("NetoPagar")) Then
                        MontoNetoPagar = DataSet.Tables("ComprasOrigen").Rows(i)("NetoPagar")
                    Else
                        MontoNetoPagar = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("MontoCredito")) Then
                        MontoCredito = DataSet.Tables("ComprasOrigen").Rows(i)("MontoCredito")
                    Else
                        MontoCredito = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("ComprasOrigen").Rows(i)("SubTotal")) Then
                        SubTotal = DataSet.Tables("ComprasOrigen").Rows(i)("SubTotal")
                    Else
                        SubTotal = 0
                    End If

                    'If NumeroCompra = "00337" Then
                    '    NumeroCompra = DataSet.Tables("ComprasOrigen").Rows(i)("Numero_Compra")
                    'End If

                    If TipoCompra <> "" Then
                        '-------------------------------CONSULTO SI EXISTE EL REGISTRO ------------------------------
                        SqlDatos = "SELECT  * FROM  Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = '" & TipoCompra & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionDestino)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If DataSet.Tables("Consulta").Rows.Count = 0 Then

                            If DataSet.Tables("ComprasOrigen").Rows(i)("Exonerado") = "False" Then
                                Exonerado = 0
                            Else
                                Exonerado = 1
                            End If

                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlDatos = "INSERT INTO [Compras] ([Numero_Compra] ,[Fecha_Compra],[Tipo_Compra],[Cod_Proveedor],[Cod_Bodega],[Nombre_Proveedor],[Apellido_Proveedor],[Direccion_Proveedor],[Telefono_Proveedor],[Fecha_Vencimiento],[Observaciones],[SubTotal],[IVA],[Pagado],[NetoPagar],[MontoCredito],[MonedaCompra],[Exonerado],[Su_Referencia],[CodigoProyecto],[Referencia],[FechaHora],[TipoProductor],[Estatus],[Numero_Solicitud],[Numero_Orden]) " & _
                            "VALUES ('" & NumeroCompra & "','" & FechaCompra & "','" & TipoCompra & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Cod_Proveedor") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Cod_Bodega") & "' , '" & DataSet.Tables("ComprasOrigen").Rows(i)("Nombre_Proveedor") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Apellido_Proveedor") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Direccion_Proveedor") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Telefono_Proveedor") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Fecha_Vencimiento") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Observaciones") & "'," & SubTotal & "," & MontoIva & "," & MontoPagado & "," & MontoNetoPagar & "," & MontoCredito & ",'" & DataSet.Tables("ComprasOrigen").Rows(i)("MonedaCompra") & "'," & Exonerado & ",'" & DataSet.Tables("ComprasOrigen").Rows(i)("Su_Referencia") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("CodigoProyecto") & "','" & DataSet.Tables("ComprasOrigen").Rows(i)("Referencia") & "', CONVERT(DATETIME, '" & Format(FechaHora, "yyyy/MM/dd hh:mm:ss") & "', 102), '" & TipoProductor & "', '" & Estatus & "', '" & NumeroSolicitud & "', '" & NumeroOrden & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlDatos, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()



                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////AGREGO EL DETALLE DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlDatos = "SELECT  * FROM Detalle_Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = '" & TipoCompra & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, ConexionOrigen)
                            DataAdapter.Fill(DataSet, "ConsultaDetalle")
                            RegDetalle = DataSet.Tables("ConsultaDetalle").Rows.Count
                            i2 = 0
                            Do While RegDetalle > i2

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Descripcion_Producto")) Then
                                    Descripcion = DataSet.Tables("ConsultaDetalle").Rows(i2)("Descripcion_Producto")
                                Else
                                    Descripcion = ""
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Descuento")) Then
                                    Descuento = DataSet.Tables("ConsultaDetalle").Rows(i2)("Descuento")
                                Else
                                    Descuento = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Cantidad")) Then
                                    Cantidad = DataSet.Tables("ConsultaDetalle").Rows(i2)("Cantidad")
                                Else
                                    Cantidad = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Unitario")) Then
                                    PrecioUnitario = DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Unitario")
                                Else
                                    PrecioUnitario = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Neto")) Then
                                    PrecioNeto = DataSet.Tables("ConsultaDetalle").Rows(i2)("Precio_Neto")
                                Else
                                    PrecioNeto = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Importe")) Then
                                    Importe = DataSet.Tables("ConsultaDetalle").Rows(i2)("Importe")
                                Else
                                    Importe = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("TasaCambio")) Then
                                    TasaCambio = DataSet.Tables("ConsultaDetalle").Rows(i2)("TasaCambio")
                                Else
                                    TasaCambio = 0
                                End If

                                If Not IsDBNull(DataSet.Tables("ConsultaDetalle").Rows(i2)("Cod_Producto")) Then
                                    SqlDatos = "INSERT INTO [Detalle_Compras] ([Numero_Compra],[Fecha_Compra],[Tipo_Compra],[Cod_Producto],[Cantidad],[Precio_Unitario],[Descuento],[Precio_Neto],[Importe],[TasaCambio],[Descripcion_Producto]) " & _
                                                "VALUES ('" & NumeroCompra & "','" & FechaCompra & "','" & TipoCompra & "','" & DataSet.Tables("ConsultaDetalle").Rows(i2)("Cod_Producto") & "' ," & Cantidad & "," & PrecioUnitario & "," & Descuento & " ," & PrecioNeto & "," & Importe & "," & TasaCambio & ", '" & Descripcion & "')"
                                    MiConexion.Open()
                                    ComandoUpdate = New SqlClient.SqlCommand(SqlDatos, MiConexion)
                                    iResultado = ComandoUpdate.ExecuteNonQuery
                                    MiConexion.Close()
                                Else
                                    MsgBox("Existe Compras sin Productos, no se Agregara el Detalle Compra No." & NumeroCompra, MsgBoxStyle.Critical, "Zeus Facturacion")
                                End If




                                i2 = i2 + 1
                            Loop
                            DataSet.Tables("ConsultaDetalle").Reset()


                            Contador = Contador + 1


                        End If
                        DataSet.Tables("Consulta").Reset()


                    End If
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1

                Loop



        End Select

        MsgBox("Se agregaron " & Contador & " Registros")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class