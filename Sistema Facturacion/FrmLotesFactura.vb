Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.SqlTypes

Public Class FrmLotesFactura
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public CodigoProducto As String, NombreProducto As String, Cantidad As Double, NumeroDocumento As String, TipoDocumento As String, Fecha As Date, CodigoBodega As String, NLotes As String
    Public WithEvents backgroundWorkerLote2 As System.ComponentModel.BackgroundWorker
    Public ds As New DataSet

    Public Class ClaseLote
        Public CodigoProducto As String
        Public CodigoBodega As String
        Public NumeroLote As String
        Public Existencia As Double
        Public FechaVence As Date
    End Class

    Private Sub backgroundWorkerLote_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerLote2.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As ClaseLote = e.Argument
        Dim CodigoProducto As String = args.CodigoProducto, CodigoBodega As String = args.CodigoBodega, NumeroLote As String = args.NumeroLote, FechaVence As Date = args.FechaVence

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            'e.Result = BuscaExistenciaBodegaWoker(CodigoProducto, CodigoBodega, CostoProductoD, CostoProducto, worker, e)
            e.Result = BuscaExistenciaBodegaLoteWorker(CodigoProducto, CodigoBodega, NumeroLote, FechaVence, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerLote_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerLote2.RunWorkerCompleted
        Dim Argumentos As New ClaseLote
        Dim ExistenciaLote As Double, NumeroLote As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, StrSqlUpdate As String, iResulteado As Integer
        Dim SQlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0




        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else
            Argumentos = e.Result

            NumeroLote = Argumentos.NumeroLote
            ExistenciaLote = Argumentos.Existencia


            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////


            If ExistenciaLote = 0 Then

                MiConexion.Close()
                StrSqlUpdate = "UPDATE [Lote] SET [Activo] = 0 WHERE (Numero_Lote = '" & NumeroLote & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResulteado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            ElseIf ExistenciaLote > 0 Then
                LoteFacturaWorker = NumeroLote

                oDataRow = ds.Tables("ExistenciaLotes").NewRow
                oDataRow("Numero_Lote") = NumeroLote
                oDataRow("FechaVence") = Format(Argumentos.FechaVence, "dd/MM/yyyy")
                oDataRow("Existencia") = ExistenciaLote
                ds.Tables("ExistenciaLotes").Rows.Add(oDataRow)

            End If

            Me.BindingDetalle.DataSource = ds.Tables("ExistenciaLotes")
            Me.C1TrueDBGrid1.DataSource = Me.BindingDetalle.DataSource


        End If

    End Sub
    Public Sub CancelarWorker(Cancelar As Boolean)
        If Cancelar = True Then
            backgroundWorkerLote2.CancelAsync()
        End If
    End Sub
    Public Function BuscaExistenciaBodegaLoteWorker(ByVal CodigoProducto As String, ByVal CodigoBodega As String, ByVal NumeroLote As String, FechaVence As Date, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As ClaseLote
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, UnidadComprada As Double
        Dim TasaCambio As Double, Existencia As Double = 0, SqlConsulta As String, DevolucionCompra As Double = 0
        Dim UnidadFacturada As Double = 0, DevolucionFactura As Double = 0, TransferenciaEnviada As Double = 0, TransferenciaRecibida As Double = 0
        Dim SalidaBodega As Double = 0, CostoVenta As Double = 0, ImporteFactura As Double = 0
        Dim ImporteCompra As Double, ImporteDevCompra As Double = 0, ImporteVenta As Double = 0, ImporteSalida As Double = 0
        Dim ImporteDevFactura As Double = 0, Argumentos As ClaseLote = New ClaseLote

        '///////////////////////////FORMULA DE COMPRA PROMEDIO////////////////////////////////////////////////////////////////
        ' CostoPromedio= ((Existencia*Costo)+(PrecioCompra*CantidadCompra))/(Existencia+CantidadComprada)
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        '///////////////////////////BUSCO LA EXISTENCIA SEGUN EL ULTIMO INVENTARIO FISICO////////////////////////////////////////

        'CostoVenta = CostoPromedio(CodigoProducto)

        TasaCambio = 0


        If worker.CancellationPending Then
            e.Cancel = True
            Exit Function
        Else

            '//////////////////////////////////BUSCO EL TOTAL DE LAS COMPRAS////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Compras.Cantidad) AS Cantidad, SUM(Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto) AS Importe  FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " &
                  "WHERE (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Compras.Cod_Bodega = '" & CodigoBodega & "') AND (Detalle_Compras.Numero_Lote = '" & NumeroLote & "')  GROUP BY Detalle_Compras.Tipo_Compra HAVING  (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "Compras")
            If DataSet.Tables("Compras").Rows.Count <> 0 Then
                UnidadComprada = DataSet.Tables("Compras").Rows(0)("Cantidad")
                ImporteCompra = DataSet.Tables("Compras").Rows(0)("Importe")
            End If

            '//////////////////////////////////BUSCO EL TOTAL DE LAS DEVOLUCION DE COMPRAS////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT  SUM(Detalle_Compras.Cantidad) AS Cantidad,SUM(Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto) AS Importe FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " &
                      "WHERE (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Compras.Cod_Bodega = '" & CodigoBodega & "') AND (Detalle_Compras.Numero_Lote = '" & NumeroLote & "') GROUP BY Detalle_Compras.Tipo_Compra HAVING  (Detalle_Compras.Tipo_Compra = N'Devolucion de Compra')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "DevolucionCompras")
            If DataSet.Tables("DevolucionCompras").Rows.Count <> 0 Then
                DevolucionCompra = DataSet.Tables("DevolucionCompras").Rows(0)("Cantidad")
                ImporteDevCompra = DataSet.Tables("DevolucionCompras").Rows(0)("Importe")
            End If

            '////////////////////////////////////BUSCO EL TOTAL DE LAS FACTURAS//////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " &
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "') AND (Facturas.Cod_Bodega =  '" & CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & NumeroLote & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If DataSet.Tables("Facturas").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Cantidad")) Then
                    UnidadFacturada = DataSet.Tables("Facturas").Rows(0)("Cantidad")
                    ImporteVenta = DataSet.Tables("Facturas").Rows(0)("Cantidad") * CostoVenta
                Else
                    UnidadFacturada = 0
                    ImporteVenta = 0
                End If
            End If

            '////////////////////////////////////BUSCO EL TOTAL DE LA SALIDA DE BODEGA//////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " &
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Salida Bodega') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "') AND (Facturas.Cod_Bodega =  '" & CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & NumeroLote & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "SalidaBodega")
            If DataSet.Tables("SalidaBodega").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("SalidaBodega").Rows(0)("Cantidad")) Then
                    SalidaBodega = DataSet.Tables("SalidaBodega").Rows(0)("Cantidad")
                Else
                    SalidaBodega = 0
                End If
            End If

            DataSet.Reset()
            '////////////////////////////////////BUSCO EL TOTAL DE LA DEVOLUCION DE LAS  FACTURAS//////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT     SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " &
                      "WHERE  (Detalle_Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Detalle_Facturas.Cod_Producto =  '" & CodigoProducto & "') AND (Facturas.Cod_Bodega = '" & CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & NumeroLote & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "DevolucionFacturas")
            If DataSet.Tables("DevolucionFacturas").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("DevolucionFacturas").Rows(0)("Cantidad")) Then
                    DevolucionFactura = DataSet.Tables("DevolucionFacturas").Rows(0)("Cantidad")
                    ImporteDevFactura = DataSet.Tables("DevolucionFacturas").Rows(0)("Cantidad") * CostoVenta
                End If
            End If

            DataSet.Reset()
            '////////////////////////////////////BUSCO EL TOTAL DE TRANSFERENCIAS ENVIADAS  //////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " &
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Transferencia Enviada') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "') AND (Facturas.Su_Referencia = '" & CodigoBodega & "') AND (Facturas.TransferenciaProcesada = 1) AND (Detalle_Facturas.CodTarea = '" & NumeroLote & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "DevolucionFacturas")
            If DataSet.Tables("DevolucionFacturas").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("DevolucionFacturas").Rows(0)("Cantidad")) Then
                    TransferenciaEnviada = DataSet.Tables("DevolucionFacturas").Rows(0)("Cantidad")
                End If
            End If

            DataSet.Reset()
            '////////////////////////////////////BUSCO EL TOTAL DE TRANSFERENCIAS RECIBIDAS  //////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT     SUM(Detalle_Compras.Cantidad) AS Cantidad FROM Compras INNER JOIN Detalle_Compras ON Compras.Numero_Compra = Detalle_Compras.Numero_Compra AND Compras.Fecha_Compra = Detalle_Compras.Fecha_Compra AND Compras.Tipo_Compra = Detalle_Compras.Tipo_Compra " &
                      "WHERE (Compras.TransferenciaProcesada = 1) AND (Compras.Cod_Bodega = '" & CodigoBodega & "') AND (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Compras.Tipo_Compra = 'Transferencia Recibida') AND (Detalle_Compras.Numero_Lote = '" & NumeroLote & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "TransferenciasRecibidas")
            If DataSet.Tables("TransferenciasRecibidas").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")) Then
                    TransferenciaRecibida = DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")
                End If
            End If

            'SqlConsulta = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " & _
            '              "WHERE (Detalle_Facturas.Tipo_Factura = 'Transferencia Enviada') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "') AND (Facturas.Nuestra_Referencia =  '" & CodigoBodega & "') AND (Facturas.TransferenciaProcesada = 1)"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            'DataAdapter.Fill(DataSet, "TransferenciasRecibidas")
            'If DataSet.Tables("TransferenciasRecibidas").Rows.Count <> 0 Then
            '    If Not IsDBNull(DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")) Then
            '        TransferenciaRecibida = DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")
            '    End If
            'End If


            Existencia = UnidadComprada - DevolucionCompra - UnidadFacturada - SalidaBodega + DevolucionFactura - TransferenciaEnviada + TransferenciaRecibida
            Argumentos.Existencia = Existencia
            Argumentos.CodigoProducto = CodigoProducto
            Argumentos.CodigoBodega = CodigoBodega
            Argumentos.NumeroLote = NumeroLote
            Argumentos.FechaVence = FechaVence

            BuscaExistenciaBodegaLoteWorker = Argumentos

        End If

    End Function





    Public Function LoteRecomendado(ByVal CodigoProducto As String, ByVal NumeroLote As String, ByVal CodigoBodega As String) As String
        Dim SQlString As String, iPosicion As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0
        Dim ExistenciaLote As Double, FechaVence As Date
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQlString = "SELECT     MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote WHERE  (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Lote.Activo = 1) GROUP BY Detalle_Compras.Numero_Lote, Lote.FechaVence  HAVING(Not (Detalle_Compras.Numero_Lote Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")
        iPosicion = 0
        LoteRecomendado = "--0--"

        Do While DataSet.Tables("Lotes").Rows.Count > iPosicion

            'CodigoProducto = DataSet.Tables("Lotes").Rows(iPosicion)("Cod_Producto")
            NumeroLote = DataSet.Tables("Lotes").Rows(iPosicion)("Numero_Lote")
            If Not IsDBNull(DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")) Then
                FechaVence = DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")
            End If

            ExistenciaLote = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega, NumeroLote)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////


            If ExistenciaLote = 0 Then
                'MiConexion.Close()
                'StrSqlUpdate = "UPDATE [Lote] SET [Activo] = 0 WHERE (Numero_Lote = '" & NumeroLote & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

            Else
                LoteRecomendado = ExistenciaLote
            End If

            iPosicion = iPosicion + 1
        Loop



    End Function



    Private Sub FrmLotesFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String, iPosicion As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0
        Dim ExistenciaLote As Double, FechaVence As Date, NumeroLote As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        ''*******************************************************************************************************************************
        ''/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        ''*******************************************************************************************************************************
        SQlString = "SELECT Numero_Lote, FechaVence, Cantidad as Existencia FROM Detalle_Lote WHERE (Numero_Documento = '-1000000000') AND (Fecha = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(ds, "ExistenciaLotes")



        SQlString = "SELECT     MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote WHERE  (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Lote.Activo = 1) GROUP BY Detalle_Compras.Numero_Lote, Lote.FechaVence  HAVING(Not (Detalle_Compras.Numero_Lote Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")
        iPosicion = 0

        Do While DataSet.Tables("Lotes").Rows.Count > iPosicion

            'CodigoProducto = DataSet.Tables("Lotes").Rows(iPosicion)("Cod_Producto")
            NumeroLote = DataSet.Tables("Lotes").Rows(iPosicion)("Numero_Lote")
            If Not IsDBNull(DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")) Then
                FechaVence = DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")
            End If

            Dim worker As BackgroundWorker
            Dim args As ClaseLote = New ClaseLote

            NumeroLote = DataSet.Tables("Lotes").Rows(iPosicion)("Numero_Lote")

            args.CodigoProducto = CodigoProducto
            args.CodigoBodega = CodigoBodega
            args.NumeroLote = NumeroLote
            args.FechaVence = FechaVence

            worker = New BackgroundWorker()
            AddHandler worker.DoWork, AddressOf backgroundWorkerLote_DoWork
            AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerLote_RunWorkerCompleted
            worker.RunWorkerAsync(args)

            'ExistenciaLote = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega, NumeroLote)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////

            'If ExistenciaLote = 0 Then
            '    MiConexion.Close()
            '    StrSqlUpdate = "UPDATE [Lote] SET [Activo] = 0 WHERE (Numero_Lote = '" & NumeroLote & "')"
            '    MiConexion.Open()
            '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            '    iResultado = ComandoUpdate.ExecuteNonQuery
            '    MiConexion.Close()

            'Else
            '    oDataRow = DataSet.Tables("ExistenciaLotes").NewRow
            '    oDataRow("Numero_Lote") = NumeroLote
            '    oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
            '    oDataRow("Existencia") = ExistenciaLote
            '    DataSet.Tables("ExistenciaLotes").Rows.Add(oDataRow)
            'End If







            iPosicion = iPosicion + 1
        Loop

        'Me.BindingDetalle.DataSource = DataSet.Tables("ExistenciaLotes")
        'Me.C1TrueDBGrid1.DataSource = Me.BindingDetalle.DataSource


        'SQlString = "SELECT Cantidad, Numero_Lote, Cantidad As Disponible, FechaVence FROM Detalle_Lote WHERE (Numero_Documento = '-1000000000') AND (Fecha = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Lotes"

        'ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
        'ExistenciaSinLote = BuscaExistenciaLoteTotal(CodigoProducto, "SIN LOTE", CodigoBodega)
        'ExistenciaLote = BuscaExistenciaLote(CodigoProducto, CodigoBodega)
        'If ExistenciaSinLote < 0 Then
        '    ExistenciaSinLote = ExistenciaBodega - Math.Abs(ExistenciaSinLote) - ExistenciaLote
        'Else
        '    ExistenciaSinLote = ExistenciaBodega - ExistenciaSinLote - ExistenciaLote
        'End If

        'SQlString = "SELECT id_Detalle_Lote, Cantidad, Numero_Lote, FechaVence, Tipo_Documento, Numero_Documento, Fecha, Codigo_Producto  FROM Detalle_Lote WHERE (Codigo_Producto = '" & CodigoProducto & "') AND (Tipo_Documento = 'Mercancia Recibida')"
        ''SQlString = "SELECT SUM(Cantidad) AS Cantidad, Numero_Lote, MIN(FechaVence) AS FechaVence, MAX(Tipo_Documento) AS Tipo_Documento, MAX(Fecha) AS Fecha, MAX(Codigo_Producto) AS Codigo_Producto FROM Detalle_Lote WHERE  (Tipo_Documento = 'Mercancia Recibida') AND (Codigo_Producto = '" & CodigoProducto & "') GROUP BY Numero_Lote"

        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "ListaLotes")
        'Registro = DataSet.Tables("ListaLotes").Rows.Count


        'If Registro = 0 Then
        '    If ExistenciaSinLote > 0 Then
        '        oDataRow = DataSet.Tables("Lotes").NewRow
        '        oDataRow("Cantidad") = 0
        '        oDataRow("Numero_Lote") = "SIN LOTE"
        '        oDataRow("Disponible") = ExistenciaSinLote
        '        oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
        '        DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '    End If
        'End If
        'i = 0
        'ExistenciaLote = 0
        'Do While Registro > i

        '    CodigoLote = DataSet.Tables("ListaLotes").Rows(i)("Numero_Lote")
        '    FechaVence = DataSet.Tables("ListaLotes").Rows(i)("FechaVence")
        '    'ExistenciaLote = BuscaExistenciaLote(CodigoProducto, CodigoLote)
        '    ExistenciaLote = BuscaExistenciaLoteTotal(CodigoProducto, CodigoLote, CodigoBodega)



        '    If i = 0 Then
        '        If ExistenciaSinLote > 0 Then
        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = "SIN LOTE"
        '            oDataRow("Disponible") = ExistenciaSinLote
        '            oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)

        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = CodigoLote
        '            oDataRow("Disponible") = ExistenciaLote
        '            oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '        Else
        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = CodigoLote
        '            oDataRow("Disponible") = ExistenciaLote
        '            oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '        End If





        '    End If

        '    i = i + 1
        'Loop


        'DataSet.Tables("Lotes").Dispose()

        'SQlString = "SELECT Numero_Lote, Codigo_Producto, Fecha, Cantidad, Tipo_Documento As Tipo,Numero_Documento As Numero,id_Detalle_Lote FROM Detalle_Lote WHERE (Tipo_Documento = 'Factura') AND (Codigo_Producto = '" & CodigoProducto & " ')" 'AND (Numero_Documento = '" & NumeroDocumento & " ')
        ''SQlString = "SELECT * FROM Lote  WHERE(Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleLotes")
        'DataSet.Tables("DetalleLotes").Dispose()

        ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False


        'DataSet.Relations.Add("RelacionLotes", DataSet.Tables("Lotes").Columns("Numero_Lote"), DataSet.Tables("DetalleLotes").Columns("Numero_Lote"))


        ''///////Relacion entre Grid .....
        'Me.TrueDBGridComponentes.DataSource = DataSet
        'Me.TrueDBGridComponentes.DataMember = "Lotes"
        'Me.BindingDetalle.DataSource = DataSet.Tables("Lotes")

        'Me.TrueDBGridComponentes.Col = 1
        'Me.TrueDBGridComponentes.Row = 0
        'Me.TrueDBGridComponentes.Columns(0).Caption = "Numero Lote"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 73
        'Me.TrueDBGridComponentes.Columns(1).Caption = "Nombre Lote"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 254
        'Me.TrueDBGridComponentes.Columns(2).Caption = "Disponible"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 73
        'Me.TrueDBGridComponentes.Columns(3).Caption = "Fecha Vence"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 93

        'Me.TrueDBGridDetalle.DataSource = DataSet
        'Me.TrueDBGridDetalle.DataMember = "Lotes.RelacionLotes"
        'Me.TrueDBGridComponentes.ChildGrid = Me.TrueDBGridDetalle

        'Me.TrueDBGridDetalle.Splits.Item(0).DisplayColumns(6).Visible = False

        'SQlString = "SELECT * FROM Lote  WHERE(Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "LotesFactura")
        '


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Registros As String, iPosicion As Double, NombreLote As String, id As Double, CodigoProducto As String, FechaVence As Date, CantidadLote As Double

        'Me.BindingDetalle.MoveFirst()
        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0

        iPosicion = Me.BindingDetalle.Position
        If iPosicion = -1 Then
            Exit Sub
        End If

        NLotes = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        NLotes = Me.C1TrueDBGrid1.Columns(0).Text
        Fecha = Me.C1TrueDBGrid1.Columns(1).Text

        'Do While iPosicion < Registros
        '    '/////////////////////////////////////////BUSCO EL NUEMERO DE SERIES //////////////////////////////
        '    'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")) Then
        '    '    id = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")
        '    'Else
        '    '    id = -1000000
        '    'End If

        '    CodigoProducto = Me.CodigoProducto
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '        NombreLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        '        FechaVence = Me.BindingDetalle.Item(iPosicion)("FechaVence")
        '        CantidadLote = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '        If CantidadLote <> 0 Then
        '            GrabaDetalleLotes(Me.NumeroDocumento, Me.Fecha, Me.TipoDocumento, id, CodigoProducto, CantidadLote, NombreLote, FechaVence)
        '        End If


        '    End If

        '    iPosicion = iPosicion + 1
        'Loop

        'FrmFacturas.Graba()

        Me.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TrueDBGridDetalle_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridDetalle.BeforeDelete
        Dim IdDetalle As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        If MsgBox("Esta Seguro de eliminar el Registro", MsgBoxStyle.YesNo, "Zeus Facturacion") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        IdDetalle = Me.TrueDBGridDetalle.Columns(5).Text

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LOS LOTES///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        MiConexion.Close()
        StrSqlUpdate = "DELETE FROM [Detalle_Lote] WHERE (id_Detalle_Lote = " & IdDetalle & ") AND (Tipo_Documento = 'Factura') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

    End Sub



    Private Sub TrueDBGridDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridDetalle.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class