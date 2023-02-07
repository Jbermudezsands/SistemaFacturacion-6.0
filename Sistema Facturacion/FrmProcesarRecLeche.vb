

Public Class FrmProcesarRecLeche
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmProcesarRecLeche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFechaFin.Value = Format(Now, "dd/MM/yyyy")
        Me.DTPFechaIni.Value = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, iPosicion2 As Double, Cantidad As Double, Registros2 As Double, NRecepcion As Double
        Dim PrecioUnitario As Double = 0, PrecioNeto As Double = 0, Importe As Double = 0, CodBodega As String = "", CodProveedor As String, CodProducto As String = ""
        Dim ConsecutivoCompra As Double, NumeroCompra As String, iPosicion As Double, Registros As Double, CodigoBodega As String
        Dim Fecha As String, NombreProductor As String = "", ApellidoProductor As String = ""
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////BUSCO LAS RECEPCIONES DE LECHE/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Compras.Cod_Proveedor, Compras.Nombre_Proveedor, Compras.Apellido_Proveedor, MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, SUM(Detalle_Compras.Cantidad) AS Cantidad, AVG(Detalle_Compras.Precio_Unitario) AS Precio_Unitario, SUM(Detalle_Compras.Descuento) AS Descuento, AVG(Detalle_Compras.Precio_Neto) AS Precio_Neto, SUM(Detalle_Compras.Importe) AS Importe, MAX(Compras.Cod_Bodega) AS Cod_Bodega FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                    "WHERE (Detalle_Compras.Tipo_Compra = 'Recepcion') AND (Compras.TipoProductor = 'Productor') AND (Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,  '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) GROUP BY Compras.Cod_Proveedor, Compras.Nombre_Proveedor, Compras.Apellido_Proveedor ORDER BY Compras.Cod_Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepciones")
        iPosicion2 = 0
        Cantidad = 0
        NRecepcion = 0
        Registros2 = DataSet.Tables("Recepciones").Rows.Count

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Registros2
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = True


        Do While iPosicion2 < Registros2
            CodProveedor = DataSet.Tables("Recepciones").Rows(iPosicion2)("Cod_Proveedor")
            NombreProductor = DataSet.Tables("Recepciones").Rows(iPosicion2)("Nombre_Proveedor")
            ApellidoProductor = DataSet.Tables("Recepciones").Rows(iPosicion2)("Apellido_Proveedor")
            CodProducto = DataSet.Tables("Recepciones").Rows(iPosicion2)("Cod_Producto")
            Cantidad = DataSet.Tables("Recepciones").Rows(iPosicion2)("Cantidad")
            PrecioUnitario = DataSet.Tables("Recepciones").Rows(iPosicion2)("Precio_Unitario")
            PrecioNeto = DataSet.Tables("Recepciones").Rows(iPosicion2)("Precio_Unitario")
            Importe = DataSet.Tables("Recepciones").Rows(iPosicion2)("Importe")
            CodigoBodega = DataSet.Tables("Recepciones").Rows(iPosicion2)("Cod_Bodega")

            ConsecutivoCompra = BuscaConsecutivo("Compra")
            NumeroCompra = Format(ConsecutivoCompra, "0000#")
            Fecha = Format(CDate(Me.DTPFechaFin.Text), "yyyy-MM-dd")

            '////////////////////////////////////BUSCO SI EL PROVEEDOR EXISTE //////////////////////////////////////////////
            SqlString = "SELECT Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & CodProveedor & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Productor")
            If DataSet.Tables("Productor").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Proveedor] (Cod_Proveedor,Nombre_Proveedor, Apellido_Proveedor) VALUES ('" & CodProveedor & "' ,'" & NombreProductor & "', '" & ApellidoProductor & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            DataSet.Tables("Productor").Reset()


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaEncabezadoCompras(NumeroCompra, CDate(Me.DTPFechaFin.Text), "Mercancia Recibida", CodProveedor, CodigoBodega, NombreProductor, "-", CDate(Me.DTPFechaFin.Text), Importe, 0, 0, Importe, "Cordobas", "Procesado por Planilla de Leche", "", False)

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////
            GrabaDetalleCompraLiquidacion(NumeroCompra, CodProducto, PrecioUnitario, 0, PrecioUnitario, Importe, Cantidad, "Cordobas", CDate(Me.DTPFechaFin.Text), "0000", "01/01/1900")
            ExistenciasCostos(CodProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", CodBodega)

            '///////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////ACTUALIZO LAS RECEPCIONES ///////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////

            StrSqlUpdate = "UPDATE [Compras] SET [Contabilizado] = 'True',[Activo] = 'False',[Cancelado] = 'False',[Exonerado] = 'True',[Su_Referencia] = 'Procesado por Procesos de Leche' " & _
                           "WHERE (Tipo_Compra = 'Recepcion') AND (TipoProductor = 'Productor') AND (Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Compras.Cod_Proveedor = '" & CodProveedor & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            iPosicion2 = iPosicion2 + 1
        Loop

        MsgBox("Proceso Terminado !!!", MsgBoxStyle.Critical, "Zeus Facturacion")

    End Sub
End Class