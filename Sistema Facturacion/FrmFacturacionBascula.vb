Public Class FrmFacturacionBascula
    Public MiConexion As New SqlClient.SqlConnection(Conexion), ConsecutivoFacturaManual As Boolean = False
    Public Function GenerarNumeroFacturaBascula(ByVal ConsecutivoFacturaManual As Boolean, ByVal TipoFactura As String) As String
        Dim ConsecutivoFactura As Double, SqlConsecutivo As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim NumeroFactura As String, FacturaSerie As Boolean = False, SqlString As String, Numero As Double = 0
        Dim CadenaDiv() As String


        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////
        SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        DataAdapter.Fill(DataSet, "Configuracion")
        If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
                FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
            End If

            If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
                CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
            End If

            If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacSerie")) Then
                FacturaSerie = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacSerie")
            End If

        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Select Case TipoFactura
            Case "Cotizacion"
                If FacturaSerie = False Then
                    ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                Else
                    ConsecutivoFactura = BuscaConsecutivoSerie("Cotizacion", FrmFacturas.CmbSerie.Text)
                End If
            Case "Factura"
                If ConsecutivoFacturaManual = False Then
                    If FacturaSerie = False Then
                        ConsecutivoFactura = BuscaConsecutivo("Factura")
                    Else
                        ConsecutivoFactura = BuscaConsecutivoSerie("Factura", FrmFacturas.CmbSerie.Text)
                    End If
                Else
                    FrmConsecutivos.ShowDialog()
                    If FrmConsecutivos.TxtConsecutivo.Text <> "-----0-----" Then
                        ConsecutivoFactura = FrmConsecutivos.NumeroFactura
                    Else
                        ConsecutivoFactura = -1
                    End If
                End If
            Case "Devolucion de Venta"
                If FacturaSerie = False Then
                    ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                Else
                    ConsecutivoFactura = BuscaConsecutivoSerie("DevFactura", "M")   ' FrmFacturas.CmbSerie.Text
                End If
            Case "Transferencia Enviada"
                If FacturaSerie = False Then
                    ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                Else
                    ConsecutivoFactura = BuscaConsecutivoSerie("Transferencia_Enviada", "M") 'FrmFacturas.CmbSerie.Text
                End If
            Case "Salida Bodega"
                If FacturaSerie = False Then
                    ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
                Else
                    ConsecutivoFactura = BuscaConsecutivoSerie("SalidaBodega", "M") 'FrmFacturas.CmbSerie.Text
                End If

        End Select

        If ConsecutivoFactura <> -1 Then
            If FacturaBodega = True Then
                NumeroFactura = "01" & "-" & Format(ConsecutivoFactura, "0000#") 'FrmFacturas.CboCodigoBodega.Columns(0).Text
            ElseIf FacturaSerie = True Then
                NumeroFactura = "M" & Format(ConsecutivoFactura, "0000#")  'FrmFacturas.CmbSerie.Text
                FrmFacturas.CmbSerie.Enabled = False
            Else
                NumeroFactura = Format(ConsecutivoFactura, "0000#")
            End If

        Else
            NumeroFactura = "-----0-----"
        End If

        '----------------------------------------------------------------------------------------------------------------------------------------
        '-----------------------------VERIFICO QUE EL CONSECUTIVO NO EXISTE EN LAS FACTURAS GRABADAS--------------------------------------------
        '----------------------------------------------------------------------------------------------------------------------------------------
        SqlString = "SELECT  *  FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = '" & TipoFactura & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            '-------------------------SI EXISTE ESTA FACTURA GRABADA, ENTONCES RECOMIENDO EL SIGUIENTE SEGUN LA FACTURACION ------------------------------

            If FacturaBodega = True Then
                CadenaDiv = NumeroFactura.Split("-")
                SqlString = "SELECT  *  FROM Facturas WHERE (Tipo_Factura = '" & TipoFactura & "') AND (Numero_Factura LIKE '" & CadenaDiv(0) & "%') ORDER BY Numero_Factura DESC"
            ElseIf FacturaSerie = True Then
                SqlString = "SELECT  *  FROM Facturas WHERE (Tipo_Factura = '" & TipoFactura & "') AND (Numero_Factura LIKE '" & My.Forms.FrmFacturas.CmbSerie.Text & "%') ORDER BY Numero_Factura DESC"
            Else
                SqlString = "SELECT  *  FROM Facturas WHERE (Tipo_Factura = '" & TipoFactura & "') ORDER BY Numero_Factura DESC"
            End If


            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If DataSet.Tables("Facturas").Rows.Count <> 0 Then
                NumeroFactura = DataSet.Tables("Facturas").Rows(0)("Numero_Factura")
                Numero = Mid(NumeroFactura, Len("M") + 1, Len(NumeroFactura)) 'My.Forms.FrmFacturas.CmbSerie.Text
                ConsecutivoFactura = Numero + 1
            End If


            If FacturaBodega = True Then
                NumeroFactura = "01" & "-" & Format(ConsecutivoFactura, "0000#") 'FrmFacturas.CboCodigoBodega.Columns(0).Text
            ElseIf FacturaSerie = True Then
                NumeroFactura = "M" & Format(ConsecutivoFactura, "0000#") 'FrmFacturas.CmbSerie.Text
                FrmFacturas.CmbSerie.Enabled = False
            Else
                NumeroFactura = Format(ConsecutivoFactura, "0000#")
            End If
        End If


        GenerarNumeroFacturaBascula = NumeroFactura


    End Function


    Private Sub FrmFacturacionBascula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnActualizar_Click(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim Sql As String, DataAdapter As New SqlClient.SqlDataAdapter, Dataset As New DataSet
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT Recepcion.NumeroRecepcion, Recepcion.TipoRecepcion, Recepcion.Fecha, Clientes.Cod_Cliente, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres, Conductor.Nombre AS Conductor, Conductor.Cedula, Conductor.Licencia, Vehiculo.IdVehiculo, Vehiculo.Placa, Recepcion.Cod_Bodega, Recepcion.SubTotal FROM  Recepcion INNER JOIN Clientes ON Recepcion.Cod_Proveedor = Clientes.Cod_Cliente INNER JOIN Conductor ON Recepcion.Conductor = Conductor.Codigo INNER JOIN Vehiculo ON Recepcion.Id_Vehiculo = Vehiculo.IdVehiculo  WHERE  (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'SalidaBascula') AND (Recepcion.Contabilizado = 0) AND (Recepcion.Procesado = 0) ORDER BY Recepcion.NumeroRecepcion"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = Dataset.Tables("DetalleRecepcion")
        Me.TrueDBGridConsultas.DataSource = Me.BindingDetalle
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim FechaSalida As Date, NombreProductor As String, CodigoProductor As String, TipoRecepcion As String, NumeroRecepcion As String
        Dim Posicion As Double

        Posicion = Me.BindingDetalle.Position
        FechaSalida = Me.TrueDBGridConsultas.Item(Posicion)("Fecha")
        NombreProductor = Me.TrueDBGridConsultas.Item(Posicion)("Nombres")
        TipoRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("TipoRecepcion")
        NumeroRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("NumeroRecepcion")
        Quien = "SalidaBascula"
        FrmRecepcion.Show()
        FrmRecepcion.DTPFecha.Text = Format(FechaSalida, "dd/MM/yyyy")
        FrmRecepcion.CboConductor.Text = NombreProductor
        FrmRecepcion.CboCodigoProveedor.Text = NombreProductor
        FrmRecepcion.CboTipoRecepcion.Text = TipoRecepcion
        FrmRecepcion.TxtNumeroEnsamble.Text = NumeroRecepcion

        FrmRecepcion.Show()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepRecepcion As New ArepRecepcion, CodigoProducto As String, Sqldatos As String, RutaLogo As String
        Dim oDataRow As DataRow, Fecha As String, Registros As Double, i As Double, Buscar_Fila() As DataRow, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""
        Dim FechaSalida As Date, NombreProductor As String, CodigoProductor As String, TipoRecepcion As String, NumeroRecepcion As String
        Dim Año As Double, Mes As Double, Dia As Double, Cod_Cliente As String

        Posicion = Me.BindingDetalle.Position
        FechaSalida = Me.TrueDBGridConsultas.Item(Posicion)("Fecha")
        NombreProductor = Me.TrueDBGridConsultas.Item(Posicion)("Nombres")
        TipoRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("TipoRecepcion")
        NumeroRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("NumeroRecepcion")

        Año = Microsoft.VisualBasic.DateAndTime.Year(Now)
        Mes = Microsoft.VisualBasic.DateAndTime.Month(Now)
        Dia = Microsoft.VisualBasic.DateAndTime.Day(Now)


        Fecha = Format(CDate(FechaSalida), "yyyy-MM-dd")


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '-100000') AND (Fecha = CONVERT(DATETIME, '2013-10-12 00:00:00', 102)) AND (TipoRecepcion = N'Recepcion') ORDER BY Cantidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Reporte")

        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') ORDER BY Cod_Productos DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        Registros = DataSet.Tables("Recepcion").Rows.Count
        i = 0

        Do While Registros > i

            CodigoProducto = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")

            '//////////////////////////////////////////BUSCO SI NO EXISTE PARA AGREGAR UNO NUEVO ///////////////////////////
            Criterios = "Cod_Productos= '" & CodigoProducto & "'"
            Buscar_Fila = DataSet.Tables("Reporte").Select(Criterios)
            If Buscar_Fila.Length = 0 Then
                oDataRow = DataSet.Tables("Reporte").NewRow
                oDataRow("id_Eventos") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos")
                oDataRow("NumeroRecepcion") = DataSet.Tables("Recepcion").Rows(i)("NumeroRecepcion")
                oDataRow("Fecha") = DataSet.Tables("Recepcion").Rows(i)("Fecha")
                oDataRow("TipoRecepcion") = DataSet.Tables("Recepcion").Rows(i)("TipoRecepcion")
                oDataRow("Cod_Productos") = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")
                oDataRow("Descripcion_Producto") = DataSet.Tables("Recepcion").Rows(i)("Descripcion_Producto")
                oDataRow("Codigo_Beams") = DataSet.Tables("Recepcion").Rows(i)("Codigo_Beams")
                oDataRow("Cantidad") = DataSet.Tables("Recepcion").Rows(i)("Cantidad")
                oDataRow("Unidad_Medida") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows.Add(oDataRow)
            Else
                Posicion = DataSet.Tables("Reporte").Rows.IndexOf(Buscar_Fila(0))
                DescripcionAnterior = DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida")
                DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida") = DescripcionAnterior & " , " & DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") = DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") + DataSet.Tables("Recepcion").Rows(i)("Cantidad")
            End If

            i = i + 1
        Loop


        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If


        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') ORDER BY Cod_Productos DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaRecepcion")

        ArepRecepcion.LblLote.Text = Año & "-" & Mes & "-" & Dia & "-" & Me.TrueDBGridConsultas.Item(Posicion)("Cod_Cliente")
        'ArepRecepcion.LblNotas.Text = Me.txtobservaciones.Text
        ArepRecepcion.LblOrden.Text = NumeroRecepcion
        ArepRecepcion.LblFechaOrden.Text = Format(CDate(FechaSalida), "dd/MM/yyyy")
        ArepRecepcion.LblTipoCompra.Text = TipoRecepcion
        'ArepRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepRecepcion.LblNombres.Text = NombreProductor
        'ArepRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblPila.Text = Me.txtapellido.Text
        ArepRecepcion.LblConductor.Text = Me.TrueDBGridConsultas.Item(Posicion)("Conductor")
        ArepRecepcion.LblCedula.Text = Me.TrueDBGridConsultas.Item(Posicion)("Cedula")
        ArepRecepcion.LblPlaca.Text = Me.TrueDBGridConsultas.Item(Posicion)("Placa")

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepRecepcion.Document
        My.Application.DoEvents()

        ArepRecepcion.DataSource = DataSet.Tables("Reporte")
        ArepRecepcion.Run(False)
        ViewerForm.Show()

    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Dim ConsecutivoFactura As Double, NumeroFactura As String, iPosicion As Double, Registros As Double, Fecha As Date, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaSalida As Date, Posicion As Double, NumeroRecepcion As String, TipoRecepcion As String
        Dim FechaFactura As Date, CodigoCliente As String, CodigoBodega As String, SubTotal As Double, Pagado As Double, CodProductos As String, NombreProductos As String, PrecioCompra As Double, Cantidad As Double, Importe As Double
        Dim Respuesta As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String
        Dim ComandoUpdate As New SqlClient.SqlCommand


        Posicion = Me.BindingDetalle.Position


        Respuesta = MsgBox("Esta Seguro de Generar la Factura a " & Me.TrueDBGridConsultas.Item(Posicion)("NumeroRecepcion"), MsgBoxStyle.YesNo, "Zeus Facturacion")
        If Respuesta = 7 Then
            Exit Sub
        End If

        FechaSalida = Me.TrueDBGridConsultas.Item(Posicion)("Fecha")
        Fecha = Format(CDate(FechaSalida), "yyyy-MM-dd")

        TipoRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("TipoRecepcion")
        NumeroRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("NumeroRecepcion")
        CodigoCliente = Me.TrueDBGridConsultas.Item(Posicion)("Cod_Cliente")
        CodigoBodega = Me.TrueDBGridConsultas.Item(Posicion)("Cod_Bodega")
        SubTotal = Me.TrueDBGridConsultas.Item(Posicion)("SubTotal")
        NombreCliente = Me.TrueDBGridConsultas.Item(Posicion)("Nombres")

        Sql = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
        End If


        FechaFactura = Format(Now, "dd/MM/yyyy")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA SALIDA DE BODEGA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Quien = "NumeroFacturas"
        NumeroFactura = GenerarNumeroFacturaBascula(ConsecutivoFacturaManual, "Factura")

        GrabaEncabezadoFacturas(NumeroFactura, FechaFactura, "Factura", CodigoCliente, CodigoBodega, NombreCliente, NombreCliente, FechaFactura, SubTotal, 0, SubTotal, SubTotal, "Cordobas", "Procesado por Inventario Fisico  ")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(Precio) AS Precio, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ  FROM Detalle_Recepcion GROUP BY NumeroRecepcion, TipoRecepcion, Cod_Productos, Descripcion_Producto " & _
              "HAVING (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")


        Registros = DataSet.Tables("DetalleRecepcion").Rows.Count
        iPosicion = 0

        Do While iPosicion < Registros

            CodProductos = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Cod_Productos")
            NombreProductos = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Descripcion_Producto")
            PrecioCompra = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Precio")
            Cantidad = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("PesoNetoKg")
            Importe = 0

            GrabaDetalleFacturaSalida(NumeroFactura, CodProductos, NombreProductos, PrecioCompra, 0, PrecioCompra, Importe, Cantidad, "Cordobas", FechaFactura, "Factura", PrecioCompra)
            ActualizaExistencia(CodProductos)

            iPosicion = iPosicion + 1
            'Me.ProgressBar.Value = Me.ProgressBar.Value + 1
        Loop



        MiConexion.Close()

        StrSqlUpdate = "UPDATE [Recepcion] SET [Numero_Compra] = '" & NumeroFactura & "' ,[Tipo_Compra] = 'Factura' ,[Fecha_Compra] = '" & CDate(FechaFactura) & "' ,[Procesado] = 1 WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'SalidaBascula')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Se ha Procesado con la Compra " & NumeroFactura, MsgBoxStyle.Information, "Zeus Facturacion")

        BtnActualizar_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlString As String, NumeroRecepcion As String, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Sql As String
        Dim StrSqlUpdate As String, iResultado As Integer
        Dim ComandoUpdate As New SqlClient.SqlCommand

        i = Me.TrueDBGridConsultas.Row
        NumeroRecepcion = Me.TrueDBGridConsultas.Item(i)("NumeroRecepcion")

        SqlString = "SELECT NumeroRecepcion, TipoRecepcion, Fecha, Cod_Proveedor, Cod_SubProveedor, Conductor, Id_identificacion, Id_Vehiculo, Cod_Bodega, Observaciones, SubTotal, Telefono, Cancelar, Activo, Seleccion, Peso, Lote, Contabilizado, FechaHora, TipoPesada, Numero_Compra, Tipo_Compra, Fecha_Compra, Procesado FROM Recepcion WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'SalidaBascula')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")

        If DataSet.Tables("DetalleRecepcion").Rows.Count <> 0 Then
            MiConexion.Close()
            StrSqlUpdate = "UPDATE [Recepcion] SET [Cancelar] = 1 WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'SalidaBascula')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If


        BtnActualizar_Click(sender, e)
    End Sub
End Class