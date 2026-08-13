Imports DataDynamics.ActiveReports.Chart

Public Class FrmImportacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public MiConexionExcel As New OleDb.OleDbConnection
    Public DataAdapterExcel As New OleDb.OleDbDataAdapter
    Public MiDataSet As New DataSet()
    Public MiEnlazador As New BindingSource
    Public ConexionExcel As String
    Public RutaBD As String, FacturaTarea As Boolean = False

    Private Sub FrmImportacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Importacion")
    End Sub


    Private Sub FrmImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String


        Try

            SqlString = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
            Else
                FacturaTarea = False
            End If


            Me.ChkLotes.Checked = FacturaTarea

            Me.OpenFileDialog.Filter = "Excel 2003 (*.xls)|*.xls"
            '"Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

            Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
            Me.DtpFechaCtasXCobrar.Value = Format(Now, "dd/MM/yyyy")

            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 180
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
            Me.TrueDBGridConsultas.Columns(6).NumberFormat = "##,##0.00"
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75
            Me.TrueDBGridConsultas.Columns(7).NumberFormat = "##,##0.00"
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(9).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(10).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(11).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(12).Width = 75
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Width = 75

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataSet.Reset()
            SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ConsecutivoSerie")
            CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
            If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
                Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
            End If
            MiConexion.Close()





        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub


    Private Sub C1Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '(Me.MiAdaptador)
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRuta.Text = RutaBD
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 4.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcel")
        Me.TrueDBGridConsultas.DataSource = MiDataSet.Tables("DatosExcel")

        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 180
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Columns(6).NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridConsultas.Columns(7).NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(10).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(11).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(12).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Width = 75

        MiConexionExcel.Close()
    End Sub

    Private Sub C1Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SQL As String, iPosicionFila As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodProducto As String = "", Descripcion As String = "", UnidadMedida As String, CodLinea As String, CuentaInventario As String = ""
        Dim CuentaCostos As String = "", CuentaVentas As String = "", CuentaIngresoAjuste As String = "", CuentaGastoAjuste As String = "", CodIva As String = ""
        Dim CodBodega As String = "", TipoCompra As String = "Mercancia Recibida", ConsecutivoCompra As Double, NumeroCompra As String
        Dim CodProveedor As String = "", Nombres As String = "", Apellidos As String = ""
        Dim CodigoProducto As String = "", PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim SubTotal As Double, IVA As Double, NetoPagar As Double, TasaIva As Double = 0, CodRubro As String = "", PVtaDolar As Double = 0, PVtaCordobas As Double

        'Try




        '////////////////////////////////BUSCO LA PRIMER LINEA DE PRODUCTOS ///////////////////////////////////////////////

        NumeroCompra = 0
        SubTotal = 0
        NetoPagar = 0
        IVA = 0

        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("DatosExcel").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("DatosExcel").Rows.Count)
            My.Application.DoEvents()
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")) Then
                CodProducto = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")
                CodProducto = Replace(CodProducto, "'", " ")
                Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DESCRIPCION")) Then
                Descripcion = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DESCRIPCION")
            End If
            CodBodega = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("BODEGA")
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("UM")) Then
                UnidadMedida = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("UM")
            Else
                UnidadMedida = "UM"
            End If
            CodLinea = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("LINEA")
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINV")) Then
                CuentaInventario = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINV")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACOSTOS")) Then
                CuentaCostos = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACOSTOS")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAVTAS")) Then
                CuentaVentas = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAVTAS")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGA")) Then
                CuentaIngresoAjuste = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGG")) Then
                CuentaGastoAjuste = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGG")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIVA")) Then
                CodIva = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIVA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODRUBRO")) Then
                CodRubro = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODRUBRO")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTADOL")) Then
                PVtaDolar = Format(CDbl(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTADOL")), "##,##0.00")
            Else
                PVtaDolar = 0
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTACOR")) Then
                PVtaCordobas = Format(CDbl(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTACOR")), "##,##0.00")
            Else
                PVtaCordobas = 0
            End If

            Descripcion = Replace(Descripcion, "'", "")

            '/////////////////////////////BUSCO SI EXISTE EL PRODUCTO EN EL INVENTARIO /////////////////////////////////////////////////////////////
            SQL = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Cod_Linea],[Tipo_Producto],[Cod_Cuenta_Inventario],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro]) " &
                               "VALUES('" & CodProducto & "','" & Descripcion & "','" & UnidadMedida & "','" & CodLinea & "','Productos' ,'" & CuentaInventario & "','" & CuentaCostos & "','" & CuentaVentas & "','" & UnidadMedida & "','" & PVtaCordobas & "','" & PVtaDolar & "','0.00','NO','" & CodIva & "','Activo','0.00' ,'0.00','Nota','" & CuentaGastoAjuste & "','" & CuentaIngresoAjuste & "','0','" & CodRubro & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery

            Else
                '///////SI EL PRODUCTO EXISTE BUSCA EL CODIVA /////////////////////////////////////////////////
                CodIva = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
            End If

            DataSet.Tables("Productos").Reset()

            MiConexion.Close()

            '////////////////////////////BUSCO SI EL PRODUCTO EXISTE EN LA BODEGA /////////////////////////////////////////////////////////////////////////////
            SQL = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Bodega")
            If DataSet.Tables("Bodega").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " &
                               "VALUES ('" & CodBodega & "','" & CodProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
            End If

            DataSet.Tables("Bodega").Reset()

            MiConexion.Close()


            '/////////////////////////////////////////BUSCO LA TASA DEL IVA ///////////////////////////////////////////////////
            SQL = "SELECT  *  FROM Impuestos WHERE (Cod_Iva = '" & CodIva & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Iva")
            If DataSet.Tables("Iva").Rows.Count <> 0 Then
                TasaIva = DataSet.Tables("Iva").Rows(0)("Impuesto")
            Else
                TasaIva = 0
            End If

            DataSet.Tables("Iva").Reset()


            If Me.ChkProductos.Checked = False Then
                '//////////////////////////BUSCO EL PROVEEDOR ///////////////////////////////////////////////////////////
                CodProveedor = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODPROV")
                SQL = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & CodProveedor & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedor")
                If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                    Nombres = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                    If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                        Apellidos = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                    End If
                Else
                    MsgBox("El Proveedor  no existe, Se detendra el Proceso " & CodProveedor, MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If

                DataSet.Tables("Proveedor").Reset()
                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                If NumeroCompra = 0 Then
                    Select Case TipoCompra
                        Case "Orden de Compra"
                            ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
                        Case "Mercancia Recibida"
                            ConsecutivoCompra = BuscaConsecutivo("Compra")
                        Case "Devolucion de Compra"
                            ConsecutivoCompra = BuscaConsecutivo("DevCompra")
                        Case "Transferencia Recibida"
                            ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
                    End Select

                    NumeroCompra = Format(ConsecutivoCompra, "0000#")

                    '////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                    GrabaEncabezadoCompras(NumeroCompra, Me.DTPFecha.Value, "Mercancia Recibida", CodProveedor, CodBodega, Nombres, Apellidos, Me.DTPFecha.Value, Val(0), Val(0), Val(0), Val(0), "Cordobas", "Procesando por la importacion", "", False)
                End If


                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")) Then
                    PrecioUnitario = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")
                End If
                Descuento = 0
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CANTIDAD")) Then
                    Cantidad = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CANTIDAD")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")) Then
                    PrecioNeto = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")
                End If
                Importe = Cantidad * PrecioUnitario


                If PrecioUnitario <> 0 And Cantidad <> 0 Then
                    GrabaDetalleCompraLiquidacion(NumeroCompra, CodProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, "Cordobas", Me.DTPFecha.Value, "0000", "01/01/1900")

                    Select Case TipoCompra
                        Case "Mercancia Recibida"
                            ExistenciasCostosBodega(CodProducto, Cantidad, PrecioNeto, TipoCompra, CodBodega, Me.DTPFecha.Value)
                            CostoBodega(CodProducto, Cantidad, PrecioNeto, TipoCompra, CodBodega, Me.DTPFecha.Value)
                    End Select

                    SubTotal = SubTotal + (PrecioUnitario * Cantidad)
                    IVA = IVA + (TasaIva * SubTotal)



                End If

                CodigoProducto = 0
                PrecioUnitario = 0
                Descuento = 0
                PrecioNeto = 0
                Importe = 0
                Cantidad = 0


            End If


            Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            iPosicionFila = iPosicionFila + 1
            Me.ProgressBar.Value = iPosicionFila
        Loop

        '/////////////////////////////CUANDO TERMINA EL CICLO GRABO LOS TOTALES DE LA COMPRA /////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.OptInventarioIni.Checked = True Then
            IVA = 0
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        SQL = "UPDATE [Compras]  SET [SubTotal] = " & SubTotal & ",[IVA] = " & IVA & ",[Pagado] = '0',[NetoPagar] = " & SubTotal + IVA & ",[MontoCredito] = " & SubTotal + IVA & ",[MonedaCompra] = 'Cordobas'  " &
                     "WHERE  (Numero_Compra = '" & NumeroCompra & "') AND (Tipo_Compra = '" & TipoCompra & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQL, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Proceso Terminado!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        'Catch ex As Exception
        'MsgBox(Err.Description & " Linea: " & iPosicionFila, MsgBoxStyle.Critical, "Zeus Facturacion")
        'End Try
    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click


        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaClientes.Text = RutaBD
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 8.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcel")

        Me.TrueDBGridClientes.DataSource = MiDataSet.Tables("DatosExcel")

        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(0).Width = 79
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(1).Width = 150
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(2).Width = 150
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(3).Width = 150
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(4).Width = 100
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(5).Width = 100
        Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(6).Width = 100


        MiConexionExcel.Close()
    End Sub

    Private Sub ChkProductos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ChkProductos.Checked = True Then
            Me.FrameTipo.Enabled = False
            Me.OptActualizaInv.Checked = False
            Me.OptInventarioIni.Checked = False
        Else
            Me.FrameTipo.Enabled = True
            Me.OptActualizaInv.Checked = False
            Me.OptInventarioIni.Checked = True
        End If
    End Sub

    Private Sub TrueDBGridConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.Click

    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        Dim iPosicionFila As Double = 0, Codigo As String = "", Nombres As String = "", Apellidos As String = "", Telefono As String = "", CtaContable As String = "", Ruc As String = ""
        Dim Direccion As String = "", Sql As String, Numero_Cedula As String = ""
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, CodVendedor = ""
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        '////////////////////////////////BUSCO LA PRIMER LINEA DE PRODUCTOS ///////////////////////////////////////////////


        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("DatosExcel").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("DatosExcel").Rows.Count)
            My.Application.DoEvents()



            If Me.OptClientes.Checked = True Then
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")) Then
                    Codigo = Trim(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO"))
                Else
                    MsgBox("El codigo del Cliente no puede ser Nulo", MsgBoxStyle.Critical)
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("NOMBRES")) Then
                    Nombres = Trim(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("NOMBRES"))
                End If

                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("APELLIDOS")) Then
                    Apellidos = Trim(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("APELLIDOS"))
                Else
                    Apellidos = ""
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DIRECCION")) Then
                    Direccion = Trim(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DIRECCION"))
                Else
                    Direccion = ""
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("TELEFONO")) Then
                    Telefono = Trim(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("TELEFONO"))
                Else
                    Telefono = ""
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACONTABLE")) Then
                    CtaContable = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACONTABLE")
                Else
                    CtaContable = ""
                End If

                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("RUC")) Then
                    Ruc = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("RUC")
                Else
                    Ruc = ""
                End If

                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CEDULA")) Then
                    Numero_Cedula = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CEDULA")
                Else
                    Numero_Cedula = ""
                End If

                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CodVendedor")) Then
                    CodVendedor = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CodVendedor")
                Else
                    CodVendedor = ""
                End If

                '/////////////////////////////BUSCO SI EXISTE EL PRODUCTO EN EL INVENTARIO /////////////////////////////////////////////////////////////
                Sql = "SELECT  *   FROM Clientes WHERE  (Cod_Cliente = '" & Codigo & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Clientes")
                If DataSet.Tables("Clientes").Rows.Count = 0 Then
                    MiConexion.Close()
                    StrSqlUpdate = "INSERT INTO [Clientes] ([Cod_Cliente],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono],[Cod_Cuenta_Cliente],[RUC],[Cedula],[CodVendedor]) " &
                                   "VALUES ('" & Codigo & "' ,'" & Nombres & "','" & Apellidos & "','" & Direccion & "','" & Telefono & "','" & CtaContable & "' ,'" & Ruc & "','" & Numero_Cedula & "','" & CodVendedor & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                DataSet.Tables("Clientes").Reset()
            ElseIf Me.OptProveedores.Checked = True Then
                Codigo = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")
                Nombres = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("NOMBRES")
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("APELLIDOS")) Then
                    Apellidos = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("APELLIDOS")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DIRECCION")) Then
                    Direccion = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DIRECCION")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("TELEFONO")) Then
                    Telefono = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("TELEFONO")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACONTABLE")) Then
                    CtaContable = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACONTABLE")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("RUC")) Then
                    Ruc = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("RUC")
                End If
                '/////////////////////////////BUSCO SI EXISTE EL PRODUCTO EN EL INVENTARIO /////////////////////////////////////////////////////////////
                Sql = "SELECT  *  FROM Proveedor WHERE (Cod_Proveedor =  '" & Codigo & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedor")
                If DataSet.Tables("Proveedor").Rows.Count = 0 Then
                    MiConexion.Close()
                    StrSqlUpdate = "INSERT INTO [Proveedor] ([Cod_Proveedor],[Nombre_Proveedor],[Apellido_Proveedor],[Direccion_Proveedor],[Telefono],[Cod_Cuenta_Pagar],[RUC]) " &
                                   "VALUES ('" & Codigo & "' ,'" & Nombres & "','" & Apellidos & "','" & Direccion & "','" & Telefono & "','" & CtaContable & "' ,'" & Ruc & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                Else
                    MiConexion.Close()
                    StrSqlUpdate = "UPDATE [Proveedor]  SET [Nombre_Proveedor] = '" & Nombres & "' ,[Apellido_Proveedor] = '" & Apellidos & "' ,[Direccion_Proveedor] = '" & Direccion & "' ,[Telefono] = '" & Telefono & "' ,[Cod_Cuenta_Pagar] = '" & CtaContable & "'   WHERE (Cod_Proveedor =  '" & Codigo & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                DataSet.Tables("Proveedor").Reset()

            End If

            iPosicionFila = iPosicionFila + 1
            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count

        Loop
        MsgBox("Proceso Terminado!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
    End Sub

    Private Sub C1Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button5.Click
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaClientes.Text = RutaBD
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 8.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcel")

        Me.TrueDBGridPrecios.DataSource = MiDataSet.Tables("DatosExcel")

        Me.TrueDBGridPrecios.Splits.Item(0).DisplayColumns(0).Width = 122
        Me.TrueDBGridPrecios.Splits.Item(0).DisplayColumns(1).Width = 373
        Me.TrueDBGridPrecios.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridPrecios.Splits.Item(0).DisplayColumns(3).Width = 90
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(4).Width = 100
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(5).Width = 100
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(6).Width = 100


        MiConexionExcel.Close()
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Dim iPosicionFila As Double, CodProducto As String, Descripcion As String
        Dim PrecioC As Double = 0, PrecioD As Double = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("DatosExcel").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("DatosExcel").Rows.Count)
            My.Application.DoEvents()
            CodProducto = ""
            Descripcion = ""

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO PRODUCTO")) Then
                CodProducto = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO PRODUCTO")
                CodProducto = Replace(CodProducto, "'", " ")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("NOMBRE PRODUCTO")) Then
                Descripcion = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("NOMBRE PRODUCTO")
                Descripcion = Replace(Descripcion, "'", " ")
                Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PRECIO C$")) Then
                PrecioC = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PRECIO C$")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PRECIO $")) Then
                PrecioD = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PRECIO $")
            End If


            MiConexion.Close()
            '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
            StrSqlUpdate = "UPDATE [Productos] SET [Precio_Venta] = " & PrecioC & " ,[Precio_Lista] = " & PrecioD & " ,[Ultimo_Precio_Venta] = " & PrecioC & " " &
                           "WHERE (Cod_Productos = '" & CodProducto & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            iPosicionFila = iPosicionFila + 1
            Me.ProgressBar.Value = iPosicionFila
        Loop
    End Sub

    Private Sub C1Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub C1Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLeerCtaxCob.Click
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaCtaxCobrar.Text = RutaBD
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 8.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcelCtasXCob")

        Me.TDGridCtasXCobrar.DataSource = MiDataSet.Tables("DatosExcelCtasXCob")

        Me.TDGridCtasXCobrar.Splits.Item(0).DisplayColumns(0).Width = 122
        Me.TDGridCtasXCobrar.Splits.Item(0).DisplayColumns(1).Width = 373
        Me.TDGridCtasXCobrar.Splits.Item(0).DisplayColumns(2).Width = 90
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(4).Width = 100
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(5).Width = 100
        'Me.TrueDBGridClientes.Splits.Item(0).DisplayColumns(6).Width = 100


        MiConexionExcel.Close()
    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub BtnProcesarCtaxCob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesarCtaxCob.Click
        Dim iPosicionFila As Double, CodCliente As String, NombreCliente As String, Saldo As Double
        Dim PrecioC As Double = 0, PrecioD As Double = 0
        Dim ConsecutivoConSerie As Boolean, TipoNota As String, Consecutivo As Double, NumeroNota As String, CodTipoNota As String
        Dim CodigoNotaDebito As String = "001", CodigoNotaCredito As String = "01", SqlString As String, NombreNotaDebito As String = "", NombreNotaCredito As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NombreNota As String = ""


        '////////////////////////////////////////////BUSCO EL TIPO DE NOTA ////////////////////////////////////////////////////////////
        SqlString = "SELECT  CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Debito Clientes')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDebito")
        If Not DataSet.Tables("NotaDebito").Rows.Count = 0 Then
            CodigoNotaDebito = DataSet.Tables("NotaDebito").Rows(0)("CodigoNB")
            NombreNotaDebito = DataSet.Tables("NotaDebito").Rows(0)("Descripcion")
        End If
        MiConexion.Close()

        SqlString = "SELECT  CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCredito")
        If Not DataSet.Tables("NotaCredito").Rows.Count = 0 Then
            CodigoNotaCredito = DataSet.Tables("NotaCredito").Rows(0)("CodigoNB")
            NombreNotaCredito = DataSet.Tables("NotaDebito").Rows(0)("Descripcion")
        End If
        MiConexion.Close()


        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("DatosExcelCtasXCob").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("DatosExcelCtasXCob").Rows.Count)
            My.Application.DoEvents()
            CodCliente = ""
            NombreCliente = ""

            If Not IsDBNull(MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("CodigoCliente")) Then
                CodCliente = MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("CodigoCliente")
                CodCliente = Replace(CodCliente, "'", " ")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("NombreCliente")) Then
                NombreCliente = MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("NombreCliente")
                NombreCliente = Replace(NombreCliente, "'", " ")
                Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcelCtasXCob").Rows.Count & " " & NombreCliente
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("Saldo")) Then
                Saldo = MiDataSet.Tables("DatosExcelCtasXCob").Rows(iPosicionFila)("Saldo")
            End If

            MiConexion.Close()

            If Saldo > 0 Then
                TipoNota = "Debito Clientes"
                CodTipoNota = CodigoNotaDebito
                NombreNota = NombreNotaDebito
            Else
                TipoNota = "Credito Clientes"
                CodTipoNota = CodigoNotaCredito
                NombreNota = NombreNotaCredito
            End If


            If ConsecutivoConSerie = False Then
                Select Case TipoNota
                    Case "Debito Clientes" : Consecutivo = BuscaConsecutivo("NotaDebito")
                    Case "Credito Clientes" : Consecutivo = BuscaConsecutivo("NotaCredito")
                End Select
                NumeroNota = Format(Consecutivo, "0000#")
            Else

                Select Case TipoNota
                    Case "Debito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaDebito", Me.CmbSerie.Text)
                    Case "Credito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaCredito", Me.CmbSerie.Text)
                End Select
                NumeroNota = Me.CmbSerie.Text & Format(Consecutivo, "0000#")
            End If

            GrabaNotaDebito(NumeroNota, Me.DtpFechaCtasXCobrar.Text, CodTipoNota, Saldo, Me.LblMoneda.Text, CodCliente, NombreCliente, "Importacion desde Excel", True, False, False)
            InsertarDetalleNotaDebito(NumeroNota, Me.DtpFechaCtasXCobrar.Text, CodTipoNota, NombreNota, "0000", Saldo)
            'GrabaDetalleNotaDebito(NumeroNota, Me.DtpFechaCtasXCobrar.Text, CodTipoNota, NombreNota, "0000", Saldo)

            Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcelCtasXCob").Rows.Count & " " & NombreCliente
            iPosicionFila = iPosicionFila + 1
            Me.ProgressBar.Value = iPosicionFila
        Loop
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub C1Button7_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button7.Click
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaContratos.Text = RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 8.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "Contratos")

        Me.TrueDBGridContratos.DataSource = MiDataSet.Tables("Contratos")

        Me.TrueDBGridContratos.Splits.Item(0).DisplayColumns(0).Width = 122
        Me.TrueDBGridContratos.Splits.Item(0).DisplayColumns(1).Width = 373
        Me.TrueDBGridContratos.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridContratos.Splits.Item(0).DisplayColumns(3).Width = 90

        MiConexionExcel.Close()
    End Sub

    Private Sub C1Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button6.Click
        Dim SQLClientes As String, Exonerado As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim IdContrato1 As Double, iPosicionFila As Double = 0, IdContrato2 As Double
        Dim Consecutivocompra As Double, NumeroCompra As Double, CodigoCliente As String
        Dim TipoServicio1 As String, TipoServicio2 As String, Frecuencia1 As Double, Frecuencia2 As Double, PrecioUnitario As Double, PrecioUnitario2 As Double
        Dim ContratoVariable1 As Double, ContratoVariable2 As Double
        Dim Activo As Double = 0, Activo2 As Double = 0


        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("Contratos").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("Contratos").Rows.Count)
            My.Application.DoEvents()

            Consecutivocompra = BuscaConsecutivo("Numero_Contrato")
            NumeroCompra = Format(Consecutivocompra, "0000#")
            CodigoCliente = MiDataSet.Tables("Contratos").Rows(iPosicionFila)("CodCliente")

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("TipoServicio") & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato")
            If Not DataSet.Tables("Contrato").Rows.Count = 0 Then
                IdContrato1 = DataSet.Tables("Contrato").Rows(0)("idTipoContrato")
                TipoServicio1 = DataSet.Tables("Contrato").Rows(0)("TipoContrato")
            Else
                MsgBox("No Existe el Tipo de Contrato", MsgBoxStyle.Critical, "ZEUS FACTURACION")
                Exit Sub
            End If

            SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("TipoServicio2") & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato2")
            IdContrato2 = 0
            If Not DataSet.Tables("Contrato2").Rows.Count = 0 Then
                IdContrato2 = DataSet.Tables("Contrato2").Rows(0)("idTipoContrato")
                TipoServicio2 = DataSet.Tables("Contrato").Rows(0)("TipoContrato")
            Else
                MsgBox("No Existe el Tipo de Contrato 2", MsgBoxStyle.Critical, "ZEUS FACTURACION")
                Exit Sub
            End If

            If TipoServicio1 = "15Mts3" Then
                ContratoVariable1 = 1
            Else
                ContratoVariable1 = 0
            End If

            If TipoServicio2 = "15Mts3" Then
                ContratoVariable2 = 1
            Else
                ContratoVariable2 = 0
            End If

            If IdContrato1 = 0 Then
                Activo = 0
            End If




            SQLClientes = "SELECT Contratos.* FROM Contratos WHERE (Numero_Contrato = " & NumeroCompra & ") AND (Cod_Cliente = '" & CodigoCliente & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Contratos]    SET [Cod_Cliente] = '" & CodigoCliente & "',[Tipo_Servicios1] = '" & TipoServicio1 & "' ,[Tipo_Servicios2] = '" & TipoServicio2 & "' ,[Frecuencia] = '" & Frecuencia1 & "' ,[Inicio_Contrato] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("InicioContrato") & "' ,[Fin_Contrato] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("FinContrato") & "' ,[Contacto_Administrativo] =  ' ' ,[Contacto_Operativo] =  ' ' ,[Precio_Unitario] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("PrecioUnitario") & "' ,[Moneda] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Moneda") & "' ,[Activo] = 1 ,[Activo2] = 1  ,[Exonerado] = 0 ,[Referencia] =  'Importacion'  ,[Observaciones] =  '' ,[Precio_Unitario2] =  '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("PrecioUnitario2") & "' ,[Inicio_Contrato2] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("InicioContrato2") & "' ,[Fin_Contrato2] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("FinContrato2") & "' ,[Moneda2] ='" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Moneda2") & "' ,[Frecuencia2] = " & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Frecuencia2") & " ,[IdContrato1] = " & IdContrato1 & " ,[IdContrato2] = " & IdContrato2 & ",[DiasFactura1] = " & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("DiasFacturar") & " ,[DiasFactura2] = " & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("DiasFacturar2") & ",[CodBodega1] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Bodega") & "',[CodBodega2] = '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Bodega2") & "' ,[Contrato_Variable] = '" & ContratoVariable1 & "' ,[Contrato_Variable2] = '" & ContratoVariable2 & "'    WHERE (Numero_Contrato = " & NumeroCompra & ") AND (Cod_Cliente = '" & CodigoCliente & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [Contratos] ([Cod_Cliente],[Tipo_Servicios1],[Tipo_Servicios2],[Frecuencia],[Inicio_Contrato],[Fin_Contrato] ,[Contacto_Administrativo] ,[Contacto_Operativo],[Precio_Unitario] ,[Moneda],[Activo],[Activo2],[Anulado],[Retencion1],[Retencion2],[Exonerado],[Referencia],[Observaciones],[Precio_Unitario2],[Inicio_Contrato2],[Fin_Contrato2] ,[Moneda2] ,[Frecuencia2] ,[IdContrato1],[IdContrato2],[DiasFactura1],[DiasFactura2],[CodBodega1],[CodBodega2],[Contrato_Variable],[Contrato_Variable2]) " &
                               "VALUES ('" & CodigoCliente & "','" & TipoServicio1 & "' ,'" & TipoServicio2 & "' ,'" & Frecuencia1 & "' ,'" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("InicioContrato") & "' ,'" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("FinContrato") & "' , ' ' , ' ' , '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("PrecioUnitario") & "' , '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Moneda") & "' ,1,1,0,0,0, 0, 'Importacion' ,' ' , " & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("PrecioUnitario2") & " ,'" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("InicioContrato2") & "' ,'" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("FinContrato2") & "' ,'" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Moneda2") & "' ," & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Frecuencia2") & "  , " & IdContrato1 & " ," & IdContrato2 & ", " & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("DiasFacturar") & " ," & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("DiasFacturar2") & ", '" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Bodega") & "','" & MiDataSet.Tables("Contratos").Rows(iPosicionFila)("Bodega2") & "','" & ContratoVariable1 & "','" & ContratoVariable2 & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If




            Bitacora(Now, NombreUsuario, "Clientes", "Grabo contrato nuevo: ")


            iPosicionFila = iPosicionFila + 1

        Loop



    End Sub

    Private Sub CmdLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLeer.Click

        '(Me.MiAdaptador)
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRuta.Text = RutaBD
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 4.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcel")
        Me.TrueDBGridConsultas.DataSource = MiDataSet.Tables("DatosExcel")

        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 180
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Columns(6).NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridConsultas.Columns(7).NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(10).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(11).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(12).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Width = 75

        MiConexionExcel.Close()
    End Sub

    Private Sub BtnLeerBeneficiario_Click(sender As Object, e As EventArgs) Handles BtnLeerBeneficiario.Click
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaBeneficiario.Text = RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 8.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "Contratos")

        Me.TrueDBGridBeneficiario.DataSource = MiDataSet.Tables("Contratos")

        Me.TrueDBGridBeneficiario.Splits.Item(0).DisplayColumns(0).Width = 122
        Me.TrueDBGridBeneficiario.Splits.Item(0).DisplayColumns(1).Width = 373
        Me.TrueDBGridBeneficiario.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridBeneficiario.Splits.Item(0).DisplayColumns(3).Width = 90

        MiConexionExcel.Close()
    End Sub

    Private Sub BtnProcesaroBeneficiario_Click(sender As Object, e As EventArgs) Handles BtnProcesaroBeneficiario.Click

        If MiDataSet Is Nothing OrElse Not MiDataSet.Tables.Contains("Contratos") Then
            MessageBox.Show("Primero debe leer el archivo Excel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim tabla As DataTable = MiDataSet.Tables("Contratos")
        If tabla.Rows.Count = 0 Then
            MessageBox.Show("El archivo no contiene registros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dal As New CsBeneficiario()
        Dim procesados As Integer = 0
        Dim errores As Integer = 0
        Dim errMsg As New System.Text.StringBuilder()

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = tabla.Rows.Count
        Me.ProgressBar.Value = 0

        For Each fila As DataRow In tabla.Rows
            Try
                If fila(0) Is DBNull.Value OrElse String.IsNullOrWhiteSpace(fila(0).ToString()) Then
                    Continue For
                End If

                '////CLASIFICACION BENEFICIARIO
                '1-SOCIO, 2-PRESOCIO, 3-TRANSPORTISTA, 4-PROVEEDOR, 5-PRODUCTOR, 6-CLIENTE, 7-NOMINA.

                ' ── ROLES del beneficiario ────────────────────────────────────
                Dim tiposRol As String = SafeStr(fila(5)).ToUpper()
                Dim esNomina As Boolean = tiposRol.Contains("7")
                Dim esCliente As Boolean = tiposRol.Contains("6")
                Dim esProveedor As Boolean = tiposRol.Contains("4")
                Dim esSocio As Boolean = tiposRol.Contains("1") AndAlso Not tiposRol.Contains("2")
                Dim esPreSocio As Boolean = tiposRol.Contains("2")
                Dim esProductor As Boolean = tiposRol.Contains("5")
                Dim esTransportista As Boolean = tiposRol.Contains("3")

                ' ── DATOS BASE (compartidos por todos los roles) ──────────────
                Dim b As New Beneficiario()
                b.Codigo = SafeStr(fila(0))
                b.Nombre = (SafeStr(fila(1)) & " " & SafeStr(fila(2))).Trim()
                b.Apellido = (SafeStr(fila(3)) & " " & SafeStr(fila(4))).Trim()
                b.Direccion = SafeStr(fila(6))
                b.Estado_Civil = SafeStr(fila(24))
                b.Sexo = SafeStr(fila(9))
                b.RUC = SafeStr(fila(10))
                b.Cedula = SafeStr(fila(11))
                b.Telefonos = SafeStr(fila(32))
                b.Activo = True
                b.Fecha_Admision = Date.Today
                b.Fecha_Nacimiento = Date.MinValue

                Me.Text = "Procesando: " & b.Codigo & " " & b.Nombre & " " & b.Apellido


                ' ── 1. GRABAR BENEFICIARIO BASE (siempre) ─────────────────────
                b.EsEmpleado = esNomina
                b.EsCliente = esCliente
                b.EsProveedor = esProveedor
                b.EsSocio = esSocio
                b.EsPreSocio = esPreSocio
                b.EsProductor = esProductor
                b.EsTransportista = esTransportista

                ' INSERT o UPDATE tabla Beneficiario

                ' ── 2. NÓMINA ─────────────────────────────────────────────────
                'If esNomina Then
                '    b.Cargo = SafeStr(fila(12))
                '    b.Departamento = SafeStr(fila(13))
                '    b.INSS = SafeStr(fila(14))
                '    b.Hijos = SafeInt(fila(15))
                '    b.TipoNomina = SafeStr(fila(16))
                '    b.GrupoNomina = SafeStr(fila(17))
                '    b.Turno = SafeStr(fila(18))
                '    b.SueldoPeriodo = SafeDbl(fila(19))
                '    b.TarifaHoraria = SafeDbl(fila(20))
                '    b.CuentaBanco = SafeStr(fila(21))
                '    b.Celular = SafeStr(fila(22))
                '    b.Profesion = SafeStr(fila(23))
                '    b.JefeInmediato = SafeStr(fila(25))
                '    b.Incentivo = SafeDbl(fila(26))
                '    b.SalarioDolarizado = SafeDbl(fila(27))
                '    b.CorreoElectronico = SafeStr(fila(28))
                '    b.CuentaBancoLAFISE = SafeStr(fila(29))
                '    b.CuentaBancoBANPRO = SafeStr(fila(30))
                '    b.CuentaBancoBDF = SafeStr(fila(31))
                '    dal.GestionarEmpleado(b)
                'End If

                ' ── 3. CLIENTE (Col 33–39) ────────────────────────────────────
                If esCliente Then
                    b.Departamento = SafeStr(fila(33))
                    b.Municipio = SafeStr(fila(34))
                    b.MonedaCredito = SafeStr(fila(35))
                    b.DiasCredito = SafeDbl(fila(36))
                    b.LimiteCredito = SafeDbl(fila(37))
                    b.Efectivo = (SafeStr(fila(38)).ToUpper() = "SI")
                    b.CodCuentaCliente = SafeStr(fila(39))
                    b.BloquearPorLimiteCredito = False
                    b.CausaIva = False
                    b.CreditoDisponible = False
                End If

                ' ── 4. PROVEEDOR (Col 40–44) ──────────────────────────────────
                If esProveedor Then
                    b.CodCuentaProveedor = SafeStr(fila(40))
                    b.MonedaCreditoProveedor = SafeStr(fila(41))
                    b.DiasCreditoProveedor = SafeDbl(fila(42))
                    b.LimiteCreditoProveedor = SafeDbl(fila(43))
                    b.EfectivoProveedor = (SafeStr(fila(44)).ToUpper() = "SI")

                End If

                ' ── 5. SOCIO (Col 45–60) ──────────────────────────────────────
                If esSocio Then
                    b.EscolaridadSocio = SafeStr(fila(45))
                    b.CooperatiaSocio = SafeStr(fila(46))
                    b.RutaSocio = SafeStr(fila(47))
                    b.CtasxCobrarSocio = SafeStr(fila(48))
                    b.CtasxPagarSocio = SafeStr(fila(49))
                    b.CtaPlanillaSocio = SafeStr(fila(50))
                    b.CtaBancoSocio = SafeStr(fila(51))
                    b.CtaIrSocio = SafeStr(fila(52))
                    b.CtaBolsaSocio = SafeStr(fila(53))
                    b.CtaAnticipoSocio = SafeStr(fila(54))
                    b.CtaTransporteSocio = SafeStr(fila(55))
                    b.CtaInseminacionSocio = SafeStr(fila(56))
                    b.CtaTrazabilidadSocio = SafeStr(fila(57))
                    b.CtaVeterinariosSocio = SafeStr(fila(58))
                    b.CtaFondosSocio = SafeStr(fila(59))
                    b.CtaOtrasDeduccionesSocio = SafeStr(fila(60))

                    '-----COLUMNAS EXTRAS PARA TODOS -----
                    b.TipoPagoSocio = SafeStr(fila(109))
                    b.CodTipoNominaSocio = SafeStr(fila(110))
                    b.PrecioSocio = SafeStr(fila(111))

                    b.TipoPagoProductor = SafeStr(fila(109))
                    b.CodTipoNominaProductor = SafeStr(fila(110))
                    b.PrecioProductor = SafeStr(fila(111))


                End If

                ' ── 6. PRE-SOCIO (Col 61–76) ──────────────────────────────────
                If esPreSocio Then
                    b.EscolaridadPreSocio = SafeStr(fila(61))
                    b.CooperatiaPreSocio = SafeStr(fila(62))
                    b.RutaPreSocio = SafeStr(fila(63))
                    b.CtasxCobrarPreSocio = SafeStr(fila(64))
                    b.CtasxPagarPreSocio = SafeStr(fila(65))
                    b.CtaPlanillaPreSocio = SafeStr(fila(66))
                    b.CtaBancoPreSocio = SafeStr(fila(67))
                    b.CtaIrPreSocio = SafeStr(fila(68))
                    b.CtaBolsaPreSocio = SafeStr(fila(69))
                    b.CtaAnticipoPreSocio = SafeStr(fila(70))
                    b.CtaTransportePreSocio = SafeStr(fila(71))
                    b.CtaInseminacionPreSocio = SafeStr(fila(72))
                    b.CtaTrazabilidadPreSocio = SafeStr(fila(73))
                    b.CtaVeterinariosPreSocio = SafeStr(fila(74))
                    b.CtaFondosPreSocio = SafeStr(fila(75))
                    b.CtaOtrasDeduccionesPreSocio = SafeStr(fila(76))

                    '-----COLUMNAS EXTRAS PARA TODOS -----
                    b.TipoPagoPreSocio = SafeStr(fila(109))
                    b.CodTipoNominaPreSocio = SafeStr(fila(110))
                    b.PrecioPreSocio = SafeStr(fila(111))

                    b.TipoPagoProductor = SafeStr(fila(109))
                    b.CodTipoNominaProductor = SafeStr(fila(110))
                    b.PrecioProductor = SafeStr(fila(111))
                End If

                ' ── 7. PRODUCTOR (Col 77–92) ──────────────────────────────────
                If esProductor Then
                    b.EscolaridadProductor = SafeStr(fila(77))
                    b.CooperatiaProductor = SafeStr(fila(78))
                    b.RutaProductor = SafeStr(fila(79))
                    b.CtasxCobrarProductor = SafeStr(fila(80))
                    b.CtasxPagarProductor = SafeStr(fila(81))
                    b.CtaPlanillaProductor = SafeStr(fila(82))
                    b.CtaBancoProductor = SafeStr(fila(83))
                    b.CtaIrProductor = SafeStr(fila(84))
                    b.CtaBolsaProductor = SafeStr(fila(85))
                    b.CtaAnticipoProductor = SafeStr(fila(86))
                    b.CtaTransporteProductor = SafeStr(fila(87))
                    b.CtaInseminacionProductor = SafeStr(fila(88))
                    b.CtaTrazabilidadProductor = SafeStr(fila(89))
                    b.CtaVeterinariosProductor = SafeStr(fila(90))
                    b.CtaFondosProductor = SafeStr(fila(91))
                    b.CtaOtrasDeduccionesProductor = SafeStr(fila(92))

                    '-----COLUMNAS EXTRAS PARA TODOS -----
                    b.TipoPagoProductor = SafeStr(fila(109))
                    b.CodTipoNominaProductor = SafeStr(fila(110))
                    b.PrecioProductor = SafeStr(fila(111))
                End If

                ' ── 8. TRANSPORTISTA (Col 93–107) ─────────────────────────────
                If esTransportista Then
                    b.Licencia = SafeStr(fila(93))
                    b.Precio = SafeDbl(fila(94))
                    'b.RutaTransportista = SafeStr(fila(95))
                    b.CtaGtosPlanillaTransp = SafeStr(fila(97))
                    b.CtaBancoTransp = SafeStr(fila(98))
                    b.CtaIrTransp = SafeStr(fila(99))
                    b.CtaBolsaTransp = SafeStr(fila(100))
                    b.CtaAnticipoTransp = SafeStr(fila(101))
                    b.CtaTransportista = SafeStr(fila(102))
                    b.CtaInseminacionTransp = SafeStr(fila(103))
                    b.CtaTrazabilidadTransp = SafeStr(fila(104))
                    b.CtaVeterinariaTransp = SafeStr(fila(105))
                    b.CtaFondosTransp = SafeStr(fila(106))
                    b.CtaOtrasDeduccionesTransp = SafeStr(fila(107))
                End If

                If b.Codigo = "5284" Then
                    b.Codigo = "5284"
                End If

                dal.Guardar(b)

                procesados += 1
                Me.ProgressBar.Value = procesados

            Catch ex As Exception
                errores += 1
                errMsg.AppendLine($"Código {SafeStr(fila(0))}: {ex.Message}")
            End Try
        Next

        Dim resumen As String = $"Proceso finalizado.{Environment.NewLine}Procesados: {procesados}{Environment.NewLine}Errores: {errores}"
        If errores > 0 Then
            resumen &= $"{Environment.NewLine}{Environment.NewLine}Detalle de errores:{Environment.NewLine}{errMsg.ToString()}"
        End If

        MessageBox.Show(resumen, "Resultado de importación",
                    MessageBoxButtons.OK,
                    If(errores > 0, MessageBoxIcon.Warning, MessageBoxIcon.Information))

    End Sub

    ' ── Helpers ───────────────────────────────────────────────────────────────────
    Private Function SafeStr(valor As Object) As String
        If valor Is Nothing OrElse valor Is DBNull.Value Then Return ""
        Return valor.ToString().Trim()
    End Function

    Private Function SafeDbl(valor As Object) As Double
        If valor Is Nothing OrElse valor Is DBNull.Value Then Return 0
        Dim result As Double
        Double.TryParse(valor.ToString(), result)
        Return result
    End Function

    Private Function SafeInt(valor As Object) As Integer
        If valor Is Nothing OrElse valor Is DBNull.Value Then Return 0
        Dim result As Integer
        Integer.TryParse(valor.ToString(), result)
        Return result
    End Function

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Dim SQL As String, iPosicionFila As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodProducto As String = "", Descripcion As String = "", UnidadMedida As String, CodLinea As String, CuentaInventario As String = ""
        Dim CuentaCostos As String = "", CuentaVentas As String = "", CuentaIngresoAjuste As String = "", CuentaGastoAjuste As String = "", CodIva As String = ""
        Dim CodBodega As String = "", TipoCompra As String = "Mercancia Recibida", ConsecutivoCompra As Double, NumeroCompra As String
        Dim CodProveedor As String = "", Nombres As String = "", Apellidos As String = ""
        Dim CodigoProducto As String = "", PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim SubTotal As Double, IVA As Double, NetoPagar As Double, TasaIva As Double = 0, CodRubro As String = "", PVtaDolar As Double = 0, PVtaCordobas As Double
        Dim FVencimiento As Date, LOTE As String = "0000", NumeroLote As String = "0000"

        'Try




        '////////////////////////////////BUSCO LA PRIMER LINEA DE PRODUCTOS ///////////////////////////////////////////////

        NumeroCompra = 0
        SubTotal = 0
        NetoPagar = 0
        IVA = 0

        iPosicionFila = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = MiDataSet.Tables("DatosExcel").Rows.Count
        Do While iPosicionFila < (MiDataSet.Tables("DatosExcel").Rows.Count)
            My.Application.DoEvents()
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")) Then
                CodProducto = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIGO")
                CodProducto = Replace(CodProducto, "'", " ")
                Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DESCRIPCION")) Then
                Descripcion = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("DESCRIPCION")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("BODEGA")) Then
                CodBodega = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("BODEGA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("UM")) Then
                UnidadMedida = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("UM")
            Else
                UnidadMedida = "UM"
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("LINEA")) Then
                CodLinea = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("LINEA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINV")) Then
                CuentaInventario = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINV")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACOSTOS")) Then
                CuentaCostos = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTACOSTOS")
            End If

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAVTAS")) Then
                CuentaVentas = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAVTAS")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGA")) Then
                CuentaIngresoAjuste = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGG")) Then
                CuentaGastoAjuste = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CTAINGG")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIVA")) Then
                CodIva = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODIVA")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODRUBRO")) Then
                CodRubro = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODRUBRO")
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTADOL")) Then
                PVtaDolar = Format(CDbl(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTADOL")), "##,##0.00")
            Else
                PVtaDolar = 0
            End If
            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTACOR")) Then
                PVtaCordobas = Format(CDbl(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PVTACOR")), "##,##0.00")
            Else
                PVtaCordobas = 0
            End If

            If Me.FacturaTarea = True Then
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("FVENCIMIENTO")) Then

                    If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("LOTE")) Then

                        LOTE = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("LOTE")

                        If LOTE <> "SINLOTE" Then
                            FVencimiento = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("FVENCIMIENTO")
                            If Len(LOTE) > 20 Then
                                NumeroLote = Mid(LOTE, 1, 20)
                            Else
                                NumeroLote = LOTE
                            End If

                            '///////////////////////////AGREGO EL LOTE ////////////////////////////////////////
                            NuevoLote(NumeroLote, FVencimiento, LOTE)
                        End If
                    Else
                        LOTE = "SINLOTE"
                            NumeroLote = "SINLOTE"
                        End If

                    Else
                        FVencimiento = "01/01/1900"
                    End If

                End If





            Descripcion = Replace(Descripcion, "'", "")

            '/////////////////////////////BUSCO SI EXISTE EL PRODUCTO EN EL INVENTARIO /////////////////////////////////////////////////////////////
            SQL = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Cod_Linea],[Tipo_Producto],[Cod_Cuenta_Inventario],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro]) " &
                               "VALUES('" & CodProducto & "','" & Descripcion & "','" & UnidadMedida & "','" & CodLinea & "','Productos' ,'" & CuentaInventario & "','" & CuentaCostos & "','" & CuentaVentas & "','" & UnidadMedida & "','" & PVtaCordobas & "','" & PVtaDolar & "','0.00','NO','" & CodIva & "','Activo','0.00' ,'0.00','Nota','" & CuentaGastoAjuste & "','" & CuentaIngresoAjuste & "','0','" & CodRubro & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery

            Else
                '///////SI EL PRODUCTO EXISTE BUSCA EL CODIVA /////////////////////////////////////////////////
                CodIva = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
            End If

            DataSet.Tables("Productos").Reset()

            MiConexion.Close()

            '////////////////////////////BUSCO SI EL PRODUCTO EXISTE EN LA BODEGA /////////////////////////////////////////////////////////////////////////////
            SQL = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Bodega")
            If DataSet.Tables("Bodega").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " &
                               "VALUES ('" & CodBodega & "','" & CodProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
            End If

            DataSet.Tables("Bodega").Reset()

            MiConexion.Close()


            '/////////////////////////////////////////BUSCO LA TASA DEL IVA ///////////////////////////////////////////////////
            SQL = "SELECT  *  FROM Impuestos WHERE (Cod_Iva = '" & CodIva & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Iva")
            If DataSet.Tables("Iva").Rows.Count <> 0 Then
                TasaIva = DataSet.Tables("Iva").Rows(0)("Impuesto")
            Else
                TasaIva = 0
            End If

            DataSet.Tables("Iva").Reset()


            If Me.ChkProductos.Checked = False Then
                '//////////////////////////BUSCO EL PROVEEDOR ///////////////////////////////////////////////////////////
                CodProveedor = MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CODPROV")
                SQL = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & CodProveedor & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedor")
                If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                    Nombres = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                    If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                        Apellidos = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                    End If
                Else
                    MsgBox("El Proveedor  no existe, Se detendra el Proceso " & CodProveedor, MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If

                DataSet.Tables("Proveedor").Reset()
                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                If NumeroCompra = 0 Then
                    Select Case TipoCompra
                        Case "Orden de Compra"
                            ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
                        Case "Mercancia Recibida"
                            ConsecutivoCompra = BuscaConsecutivo("Compra")
                        Case "Devolucion de Compra"
                            ConsecutivoCompra = BuscaConsecutivo("DevCompra")
                        Case "Transferencia Recibida"
                            ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
                    End Select

                    NumeroCompra = Format(ConsecutivoCompra, "0000#")

                    '////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                    GrabaEncabezadoCompras(NumeroCompra, Me.DTPFecha.Value, "Mercancia Recibida", CodProveedor, CodBodega, Nombres, Apellidos, Me.DTPFecha.Value, Val(0), Val(0), Val(0), Val(0), "Cordobas", "Procesando por la importacion", "", False)
                End If


                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")) Then
                    PrecioUnitario = Format(Val(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")), "##,##0.00")
                End If
                Descuento = 0
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CANTIDAD")) Then
                    Cantidad = Format(Val(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("CANTIDAD")), "##,##0.00")
                End If
                If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")) Then
                    PrecioNeto = Format(Val(MiDataSet.Tables("DatosExcel").Rows(iPosicionFila)("PUNITARIO")), "##,##0.00")
                End If
                Importe = Cantidad * PrecioUnitario


                If PrecioUnitario <> 0 And Cantidad <> 0 Then

                    If Me.FacturaTarea = True Then
                        GrabaDetalleCompraLiquidacion(NumeroCompra, CodProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, "Cordobas", Me.DTPFecha.Value, NumeroLote, FVencimiento)

                    Else
                        GrabaDetalleCompraLiquidacion(NumeroCompra, CodProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, "Cordobas", Me.DTPFecha.Value, "0000", "01/01/1900")
                    End If




                    Select Case TipoCompra
                        Case "Mercancia Recibida"
                            ExistenciasCostosBodega(CodProducto, Cantidad, PrecioNeto, TipoCompra, CodBodega, Me.DTPFecha.Value)
                            CostoBodega(CodProducto, Cantidad, PrecioNeto, TipoCompra, CodBodega, Me.DTPFecha.Value)
                    End Select

                    SubTotal = SubTotal + (PrecioUnitario * Cantidad)
                    IVA = IVA + (TasaIva * SubTotal)



                End If

                CodigoProducto = 0
                PrecioUnitario = 0
                Descuento = 0
                PrecioNeto = 0
                Importe = 0
                Cantidad = 0


            End If


            Me.Text = "Procesando " & iPosicionFila & " de " & MiDataSet.Tables("DatosExcel").Rows.Count & " " & Descripcion
            iPosicionFila = iPosicionFila + 1
            Me.ProgressBar.Value = iPosicionFila
        Loop

        '/////////////////////////////CUANDO TERMINA EL CICLO GRABO LOS TOTALES DE LA COMPRA /////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.OptInventarioIni.Checked = True Then
            IVA = 0
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        SQL = "UPDATE [Compras]  SET [SubTotal] = " & SubTotal & ",[IVA] = " & IVA & ",[Pagado] = '0',[NetoPagar] = " & SubTotal + IVA & ",[MontoCredito] = " & SubTotal + IVA & ",[MonedaCompra] = 'Cordobas'  " &
                     "WHERE  (Numero_Compra = '" & NumeroCompra & "') AND (Tipo_Compra = '" & TipoCompra & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQL, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Proceso Terminado!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        'Catch ex As Exception
        'MsgBox(Err.Description & " Linea: " & iPosicionFila, MsgBoxStyle.Critical, "Zeus Facturacion")
        'End Try
    End Sub
End Class