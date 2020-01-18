Public Class FrmTransferenciaListado
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        My.Forms.FrmTransferencias.TxtNumeroEnsamble.Text = "-----0-----"
        My.Forms.FrmTransferencias.NumeroTranferencia = "-----0-----"
        My.Forms.FrmTransferencias.CboCodigoBodega.Enabled = True
        My.Forms.FrmTransferencias.CboCodigoBodega2.Enabled = True
        My.Forms.FrmTransferencias.ShowDialog()

        Dim Sql As String = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega AS BodegaOrigen, Bodegas_1.Nombre_Bodega AS BodegaDestino, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Facturas.TransferenciaProcesada,Facturas.Cancelado FROM Facturas INNER JOIN Bodegas ON Facturas.Su_Referencia = Bodegas.Cod_Bodega INNER JOIN Bodegas AS Bodegas_1 ON Facturas.Nuestra_Referencia = Bodegas_1.Cod_Bodega  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Facturas.Numero_Factura"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Transferencias")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Transferencias")
        Me.TrueDBGridConsultas.Columns(0).Caption = "No.Transferencia"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 91
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 79
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 140
        Me.TrueDBGridConsultas.Columns(4).Caption = "Cod Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Columns(5).Caption = "Cod Destino"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Columns(6).Caption = "Procesado"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75
    End Sub

    Private Sub FrmTransferenciaListado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Transferencia de Bodegas")
    End Sub

    Private Sub FrmTransferenciaListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega AS BodegaOrigen, Bodegas_1.Nombre_Bodega AS BodegaDestino, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Facturas.TransferenciaProcesada,Facturas.Cancelado FROM Facturas INNER JOIN Bodegas ON Facturas.Su_Referencia = Bodegas.Cod_Bodega INNER JOIN Bodegas AS Bodegas_1 ON Facturas.Nuestra_Referencia = Bodegas_1.Cod_Bodega  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Facturas.Numero_Factura"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Transferencias")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Transferencias")
        Me.TrueDBGridConsultas.Columns(0).Caption = "No.Transferencia"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 91
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 79
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 140
        Me.TrueDBGridConsultas.Columns(4).Caption = "Cod Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Columns(5).Caption = "Cod Destino"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Columns(6).Caption = "Procesado"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75

    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Dim NumeroTransfer As String, Procesado As Boolean = True

        If Me.TrueDBGridConsultas.Columns(7).Text = "" Then
            Exit Sub
        End If


        If Me.TrueDBGridConsultas.Columns(7).Text = True Then
            MsgBox("Transferencia Cancelada!!", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Procesado = Me.TrueDBGridConsultas.Columns(6).Text
        NumeroTransfer = Me.TrueDBGridConsultas.Columns(0).Text

        My.Forms.FrmTransferencias.NumeroTranferencia = NumeroTransfer
        My.Forms.FrmTransferencias.CodBodega1 = Me.TrueDBGridConsultas.Columns(4).Text
        My.Forms.FrmTransferencias.CodBodega2 = Me.TrueDBGridConsultas.Columns(5).Text
        My.Forms.FrmTransferencias.FechaTransferencia = Me.TrueDBGridConsultas.Columns(1).Text
        My.Forms.FrmTransferencias.DTPFecha.Value = Me.TrueDBGridConsultas.Columns(1).Text
        If Procesado = True Then

            My.Forms.FrmTransferencias.Button4.Enabled = False
            My.Forms.FrmTransferencias.CboCodigoBodega.Enabled = False
            My.Forms.FrmTransferencias.CboCodigoBodega2.Enabled = False
            'My.Forms.FrmTransferencias.CboCodigoBodega.Enabled = True
            'My.Forms.FrmTransferencias.CboCodigoBodega2.Enabled = True
        Else

            My.Forms.FrmTransferencias.TrueDBGridComponentes.Enabled = True
            My.Forms.FrmTransferencias.Button4.Enabled = True
            My.Forms.FrmTransferencias.CboCodigoBodega.Enabled = True
            My.Forms.FrmTransferencias.CboCodigoBodega2.Enabled = True
        End If
        My.Forms.FrmTransferencias.ShowDialog()

    End Sub

    Private Sub C1Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button5.Click
        Me.Close()
    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroTransferencia As String = "", Resultado As Double
        Dim iPosicionFila As Double, CodigoBodega As String = "", StrSQLUpdate As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Cantidad As Double = 0, PrecioUnitario As Double = 0, CodProducto As String = 0
        Dim CodigoProducto As String, iPosicionFila2 As Double, SqlString As String, FechaTransferencia As Date, CodBodegaTransferencia As String = ""

        If Me.TrueDBGridConsultas.Columns(6).Text = True Then

            MsgBox("Esta Transferencia fue ya esta Procesada!!", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        NumeroTransferencia = Me.TrueDBGridConsultas.Columns(0).Text
        Resultado = MsgBox("Esta seguro de Procesar la Transferencia No. " & NumeroTransferencia, MsgBoxStyle.OkCancel, "Zeus Facturacion")
        If Resultado = 2 Then
            Exit Sub
        End If

        '//////////////////////////////CAMBIO LA TRANSFERENCIA ENVIADA A PROCESADA ////////////////////////////////////////////////
        MiConexion.Close()
        SqlCompras = "UPDATE [Facturas] SET [TransferenciaProcesada] = 1 WHERE (Tipo_Factura = 'Transferencia Enviada') AND (Numero_Factura = '" & NumeroTransferencia & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////CAMBIO LA TRANSFERENCIA RECIBIDA A PROCESADA ////////////////////////////////////////////////
        MiConexion.Close()
        SqlCompras = "UPDATE [Compras] SET [TransferenciaProcesada] = 1 WHERE (Tipo_Compra = 'Transferencia Recibida') AND (Numero_Compra = '" & NumeroTransferencia & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '*******************************************************************************************************************************
        '///////////////////////////////////////////BUSCO LA BODEGA DESTINO PARA ESTA TRANSFERENCIA ////////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT  *  FROM Compras WHERE (Numero_Compra = '" & NumeroTransferencia & "') AND (Tipo_Compra = 'Transferencia Recibida')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BodegaTransferencia")
        If DataSet.Tables("BodegaTransferencia").Rows.Count <> 0 Then
            CodBodegaTransferencia = DataSet.Tables("BodegaTransferencia").Rows(0)("Cod_Bodega")
        Else
            MsgBox("No existe la transferencia recibida", MsgBoxStyle.Critical, "Zeus  Facturacion")
            Exit Sub
        End If
        DataSet.Tables("BodegaTransferencia").Reset()


        '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////
        iPosicionFila2 = 0
        SqlString = "SELECT  *  FROM Detalle_Facturas WHERE (Tipo_Factura = 'Transferencia Enviada') AND (Numero_Factura = '" & NumeroTransferencia & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleTransferencia")
        Do While iPosicionFila2 < (DataSet.Tables("DetalleTransferencia").Rows.Count)
            My.Application.DoEvents()

            CodigoProducto = DataSet.Tables("DetalleTransferencia").Rows(iPosicionFila2)("Cod_Producto")
            Cantidad = DataSet.Tables("DetalleTransferencia").Rows(iPosicionFila2)("Cantidad")
            PrecioUnitario = DataSet.Tables("DetalleTransferencia").Rows(iPosicionFila2)("Precio_Unitario")
            FechaTransferencia = DataSet.Tables("DetalleTransferencia").Rows(iPosicionFila2)("Fecha_Factura")
            SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia,DetalleBodegas.Costo,DetalleBodegas.CostoDolar FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                        "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            iPosicionFila = 0
            Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
                My.Application.DoEvents()
                CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")

                ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
                MiConexion.Close()
                '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
                StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Existencia] = '" & ExistenciaBodega & "'  WHERE (Cod_Productos = '" & CodigoProducto & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


                iPosicionFila = iPosicionFila + 1
            Loop



            DataSet.Tables("Bodegas").Reset()
            CostoBodega(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", CodBodegaTransferencia, FechaTransferencia)
            iPosicionFila2 = iPosicionFila2 + 1
        Loop



        Dim Sql As String = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega AS BodegaOrigen, Bodegas_1.Nombre_Bodega AS BodegaDestino, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Facturas.TransferenciaProcesada,Facturas.Cancelado FROM Facturas INNER JOIN Bodegas ON Facturas.Su_Referencia = Bodegas.Cod_Bodega INNER JOIN Bodegas AS Bodegas_1 ON Facturas.Nuestra_Referencia = Bodegas_1.Cod_Bodega  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Facturas.Numero_Factura"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Transferencias")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Transferencias")
        Me.TrueDBGridConsultas.Columns(0).Caption = "No.Transferencia"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 91
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 79
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 140
        Me.TrueDBGridConsultas.Columns(4).Caption = "Cod Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Columns(5).Caption = "Cod Destino"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Columns(6).Caption = "Procesado"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75

        MsgBox("PROCESO TERMINADO", MsgBoxStyle.Exclamation, "Zeus Facturacion")
        DataSet.Reset()
    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroTransferencia As String = "", Resultado As Double
        Dim iPosicionFila2 As Double = 0, Sqlstring As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, CodigoProducto As String = "", iPosicionFila As String = ""
        Dim CodigoBodega As String = "", StrSQLUpdate As String = ""
        Dim Fecha As String

        If Me.TrueDBGridConsultas.Columns(7).Text = True Then

            MsgBox("Transferencia Cancelada!!", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If



        NumeroTransferencia = Me.TrueDBGridConsultas.Columns(0).Text
        Resultado = MsgBox("Esta seguro de Cancelar la Transferencia No. " & NumeroTransferencia, MsgBoxStyle.OkCancel, "Zeus Facturacion")
        If Resultado = 2 Then
            Exit Sub
        End If

        Fecha = Format(CDate(Me.TrueDBGridConsultas.Columns(1).Text), "yyyy-MM-dd")

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False',[Cancelado] = 'True',[Nombre_Cliente] = '******CANCELADO',[Apellido_Cliente] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " & _
                     "WHERE  (Numero_Factura = '" & NumeroTransferencia & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        SqlCompras = "UPDATE [Detalle_Facturas]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0,[Costo_Unitario] = 0 " & _
                     "WHERE  (Numero_Factura = '" & NumeroTransferencia & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Bitacora(Now, NombreUsuario, "Transferencia Enviada", "Elimino la Transferencia: " & NumeroTransferencia)


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Cancelado] = 'True',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " & _
                     "WHERE  (Numero_Compra = '" & NumeroTransferencia & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                     "WHERE  (Numero_Compra ='" & NumeroTransferencia & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
        '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////


        Bitacora(Now, NombreUsuario, "Transferencia Recibida", "Eliminar la Transferencia: " & NumeroTransferencia)




        Dim Sql As String = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega AS BodegaOrigen, Bodegas_1.Nombre_Bodega AS BodegaDestino, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Facturas.TransferenciaProcesada,Facturas.Cancelado FROM Facturas INNER JOIN Bodegas ON Facturas.Su_Referencia = Bodegas.Cod_Bodega INNER JOIN Bodegas AS Bodegas_1 ON Facturas.Nuestra_Referencia = Bodegas_1.Cod_Bodega  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Facturas.Numero_Factura"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Transferencias")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Transferencias")
        Me.TrueDBGridConsultas.Columns(0).Caption = "No.Transferencia"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 91
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 79
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 140
        Me.TrueDBGridConsultas.Columns(4).Caption = "Cod Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TrueDBGridConsultas.Columns(5).Caption = "Cod Destino"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridConsultas.Columns(6).Caption = "Procesado"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75

        MsgBox("PROCESO TERMINADO", MsgBoxStyle.Exclamation, "Zeus Facturacion")
    End Sub
End Class