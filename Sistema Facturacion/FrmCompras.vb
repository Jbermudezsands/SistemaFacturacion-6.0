Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports Sistema_Facturacion.FrmFacturas

Public Class FrmCompras
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double, FacturaTarea As Boolean = False
    Public NumeroLote As String = "SINLOTE", FechaLote As Date = "01/01/1900", MiconexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, EsSolicitud As Boolean = False
    Public Fecha_Compra As Date, FechaHoraCompra As Date, NumeroCompra As String, TipoCompra As String, Impresora_Defecto As String
    Public WithEvents backgroundWorkerInsertar As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerGrabar As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerMetodoCompra As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerAgregarEncabezado As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerExistenciaCosto As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerExistenciaLotexProducto As System.ComponentModel.BackgroundWorker
    Public Delegate Sub delegadoGridRegistros(Compras As TablaCompras)
    Public ConexionExcel As String, MiConexionExcel As New OleDb.OleDbConnection, DataAdapterExcel As New OleDb.OleDbDataAdapter
    Public RutaBD As String, MiDataSet As New DataSet()
    Public TieneContrato As Boolean, dsMetodo As New DataSet

    Public Sub LimpiarGridImporacion()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        DataSet.Reset()
        SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Precio_Unitario, Importe, Numero_Lote, Fecha_Vence, Precio_Neto FROM Detalle_Compras WHERE (Numero_Compra = N'-10000') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleCompra")

        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("DetalleCompra")
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 75
        Me.TrueDBGridConsultas.Columns("Cod_Producto").Caption = "CodProducto"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 180
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
        Me.TrueDBGridConsultas.Columns("Cantidad").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 75
        Me.TrueDBGridConsultas.Columns("Precio_Unitario").Caption = "PrecioUnitario"
        Me.TrueDBGridConsultas.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 75
        Me.TrueDBGridConsultas.Columns("Precio_Neto").Caption = "Precio_Neto"
        Me.TrueDBGridConsultas.Columns("Precio_Neto").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Importe").Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Importe").Locked = True
        Me.TrueDBGridConsultas.Columns("Importe").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Lote").Width = 70
        Me.TrueDBGridConsultas.Columns("Numero_Lote").Caption = "Numero Lote"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Fecha_Vence").Width = 75
        Me.TrueDBGridConsultas.Columns("Fecha_Vence").Caption = "FechaVence"

        Me.LblTotalRegistros.Text = "Total Registros: "

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = 0
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = False
    End Sub

    Public Sub Imprime(
    ByVal NumeroEnsamble As String,
    ByVal TipoProducto As String,
    ByVal MonedaFactura As String,
    ByVal MonedaImprime As String,
    ByVal FechaCompra As Date,
    ByVal TxtReferencia As String,
    ByVal TxtObservaciones As String,
    ByVal TxtCodigoProveedor As String,
    ByVal TxtNombres As String,
    ByVal TxtApellidos As String,
    ByVal TxtDireccion As String,
    ByVal TxtTelefono As String,
    ByVal CboCodigoBodega As Object,
    ByVal DTPVencimiento As Date,
    ByVal TxtSubTotal As Double,
    ByVal TxtIva As Double,
    ByVal TxtPagado As Double,
    ByVal TxtNetoPagar As Double
)

        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepCompras As New ArepCompras, SqlDatos As String, SQlDetalle As String = "", Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaCambio As Double
        Dim NumeroCompra As String
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim TipoImpresion As String, SqlString As String, Ancho As Double, Largo As Double



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepCompras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepCompras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepCompras.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                ArepCompras.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepCompras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If



        'ArepCompras.LblReferencia.Text = Me.TxtReferencia.Text
        'ArepCompras.LblNotas.Text = Me.TxtObservaciones.Text
        'ArepCompras.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        'ArepCompras.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        'ArepCompras.LblTipoCompra.Text = Me.CboTipoProducto.Text
        'ArepCompras.LblCodProveedor.Text = Me.TxtCodigoProveedor.Text
        'ArepCompras.LblNombres.Text = Me.TxtNombres.Text
        'ArepCompras.LblApellidos.Text = Me.TxtApellidos.Text
        'ArepCompras.LblDireccionProveedor.Text = Me.TxtDireccion.Text
        'ArepCompras.LblTelefono.Text = Me.TxtTelefono.Text
        'ArepCompras.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")



        'If Me.CboCodigoBodega.Columns(0).Text <> "Nothing" Then
        '    ArepCompras.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'End If

        ''ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
        ''ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
        ''ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
        ''ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
        'Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Me.BindingMetodo.MoveFirst()
        'Registros = Me.BindingMetodo.Count
        'iPosicion = 0
        'Monto = 0
        'ArepCompras.TxtMetodo.Text = "Credito"
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

        '    ArepCompras.TxtMetodo.Text = NombrePago & " " & Monto

        '    iPosicion = iPosicion + 1
        'Loop

        'If Me.CboTipoProducto.Text = "Orden de Compra" Then
        '    If Me.RadioButton2.Checked = True Then
        '        ArepCompras.TxtMetodo.Text = "Contado"
        '    Else
        '        ArepCompras.TxtMetodo.Text = "Credito"
        '    End If
        'End If

        'TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)

        ''If MonedaImprime = "" Then
        ''    MonedaImprime = "Cordobas"
        ''End If

        'If MonedaFactura = "Cordobas" Then
        '    If MonedaImprime = "Cordobas" Then
        '        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        '        SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe, Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " &
        '            "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"

        '        ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
        '        ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
        '        ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
        '        ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
        '    ElseIf MonedaImprime = "Dolares" Then
        '        SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Compras.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Compras.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Compras.Importe * (1 / TasaCambio.MontoTasa) AS Importe, Productos.Unidad_Medida FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " &
        '                     "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        '        ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) / TasaCambio, "##,##0.00")
        '        ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) / TasaCambio, "##,##0.00")
        '        ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) / TasaCambio, "##,##0.00")
        '        ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) / TasaCambio, "##,##0.00")
        '    End If
        'ElseIf MonedaFactura = "Dolares" Then
        '    If MonedaImprime = "Dolares" Then
        '        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        '        SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe, Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " &
        '            "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        '        ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
        '        ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
        '        ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
        '        ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
        '    ElseIf MonedaImprime = "Cordobas" Then
        '        SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Compras.Descuento *  TasaCambio.MontoTasa AS Descuento, Detalle_Compras.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Compras.Importe * TasaCambio.MontoTasa AS Importe, Productos.Unidad_Medida FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " &
        '                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        '        ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
        '        ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
        '        ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
        '        ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")

        '    End If
        'End If


        'Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Imprimir la Compra: " & Me.TxtNumeroEnsamble.Text)


        'TipoImpresion = "Compra"
        'SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Coordenadas")
        'Ancho = DataSet.Tables("Coordenadas").Rows(0)("Ancho")
        'Largo = DataSet.Tables("Coordenadas").Rows(0)("Largo")


        ''///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        ''SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
        ''    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        'SQL.ConnectionString = Conexion
        'SQL.SQL = SQlDetalle
        'ArepCompras.DataSource = SQL
        'ArepCompras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
        ''ArepCompras.PageSettings.PaperWidth = Str(Ancho)
        ''ArepCompras.PageSettings.PaperHeight = Largo
        ''ArepCompras.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        'Dim ViewerForm As New FrmViewer()
        'ViewerForm.arvMain.Document = ArepCompras.Document
        'ViewerForm.Show()
        'ArepCompras.Run(False)
        ''ArepCompras.Show()



        'If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Orden de Compra"
        '            Me.CmdFacturar.Enabled = True
        '        Case Else
        '            '//////////////////////////////////////////////////////////////////////////////////////////////
        '            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '            '/////////////////////////////////////////////////////////////////////////////////////////////////

        '            'SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False' " & _
        '            '             "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        '            'MiConexion.Open()
        '            'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        '            'iResultado = ComandoUpdate.ExecuteNonQuery
        '            'MiConexion.Close()
        '            LimpiarCompras()
        '    End Select
        'End If


    End Sub




    '////////////////////////////////////PROCESOS GRABAR COMPRAS CON HILOS //////////////
    Private Sub backgroundWorkerMetodoCompra_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerMetodoCompra.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim dsMetodo As New DataSet, dsDetalle As New DataSet, Compras As New TablaCompras

        Compras = e.Argument(0)
        dsDetalle = e.Argument(1)
        dsMetodo = e.Argument(2)



        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            e.Result = ActualizaMETODOcOMPRAWorker(Compras, dsDetalle, dsMetodo, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerMetodoCompra_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerMetodoCompra.RunWorkerCompleted



        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Compras", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Compras", "Hilo Cancelado")
        Else

            Dim Compras As New TablaCompras

            MDIMain.txtSPlano3.Text = ""

            Compras = e.Result

            Me.TxtSubTotal.Text = Format(Compras.Sub_Total, "##,##0.00")
            Me.TxtIva.Text = Format(Compras.IVA, "##,##0.00")
            Me.TxtPagado.Text = Format(Compras.Pagado_Compra, "##,##0.00")
            Me.TxtNetoPagar.Text = Format(Compras.Neto_Pagar, "##,##0.00")

        End If

    End Sub
    Private Sub backgroundWorkerMetodoCompra_ProgressChanged(
ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
Handles backgroundWorkerMetodoCompra.ProgressChanged


        MDIMain.txtSPlano3.Text = e.UserState.ToString


    End Sub
    Public Function ActualizaMETODOcOMPRAWorker(Compras As TablaCompras, dsDetalle As DataSet, dsMetodoPago As DataSet, worker As BackgroundWorker, e As DoWorkEventArgs) As TablaCompras
        Dim Metodo As String, iPosicion As Double, Registros As Double, Monto As Double, Importe As Double
        Dim Subtotal As Double, Iva As Double, Neto As Double, CodProducto As String, SQlString As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), CodIva As String, Tasa As Double, Moneda As String, Fecha As String, SQLTasa As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TasaCambio As Double, TipoMetodo As String, SQLMetodo As String, TasaIva As Double = 0
        Dim Resultado As New TablaCompras

        Registros = dsMetodoPago.Tables("MetodoPago").Rows.Count
        iPosicion = 0


        Resultado.Numero_Compra = Compras.Numero_Compra
        Resultado.Fecha_Compra = Compras.Fecha_Compra
        Resultado.Moneda_Compra = Compras.Moneda_Compra
        Resultado.Tipo_Compra = Compras.Tipo_Compra
        Resultado.Exonerado_Compra = Compras.Exonerado_Compra

        Do While iPosicion < Registros
            My.Application.DoEvents()
            Metodo = dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("NombrePago")
            TasaCambio = 1
            Fecha = Format(Compras.Fecha_Compra, "yyyy-MM-dd")
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////BUSCO LA MONEDA DEL METODO DE PAGO///////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Moneda = "Cordobas"
            TipoMetodo = "Cambio"
            SQLMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & Metodo & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count <> 0 Then
                Moneda = DataSet.Tables("Metodo").Rows(0)("Moneda")
                TipoMetodo = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
            DataSet.Tables("Metodo").Clear()


            Select Case Moneda
                Case "Cordobas"
                    If Compras.Moneda_Compra = "Cordobas" Then
                        TasaCambio = 1
                    Else
                        TasaCambio = BuscaTasaCambio(Fecha)
                    End If

                Case "Dolares"

                    If Compras.Moneda_Compra = "Dolares" Then
                        TasaCambio = 1
                    Else
                        SQLTasa = "SELECT  * FROM TasaCambio WHERE (FechaTasa = CONVERT(DATETIME, '" & Fecha & "', 102))"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQLTasa, MiConexion)
                        DataAdapter.Fill(DataSet, "TasaCambio")
                        If DataSet.Tables("TasaCambio").Rows.Count <> 0 Then
                            TasaCambio = DataSet.Tables("TasaCambio").Rows(0)("MontoTasa")
                        Else
                            'TasaCambio = 0
                            MsgBox("La Tasa de Cambio no Existe para esta Fecha", MsgBoxStyle.Critical, "Sistema Facturacion")
                            'FrmFacturas.BindingMetodo.Item(iPosicion)("Monto") = 0
                        End If
                        DataSet.Tables("TasaCambio").Clear()
                    End If

            End Select

            If TipoMetodo = "Cambio" Then
                TasaCambio = TasaCambio * -1
            End If


            If Not IsDBNull(dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("Monto")) Then
                Monto = (dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("Monto") * TasaCambio) + Monto
                iPosicion = iPosicion + 1
            Else
                Monto = 0
                iPosicion = iPosicion + 1
            End If
        Loop


        Registros = dsDetalle.Tables("DetalleCompra").Rows.Count
        iPosicion = 0

        Do While iPosicion < Registros
            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe")) Then
                Subtotal = CDbl(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe")) + Subtotal
            End If


            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe")) Then
                Importe = CDbl(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe"))
            Else
                Importe = 0
            End If

            If IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Cod_Producto")) Then
                Exit Function
            End If

            CodProducto = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Cod_Producto")

            '///////////////PROGRESO DEL HILO GRABAR //////////////////////////
            worker.ReportProgress(1, "SP" & CodProducto)

            'CodProducto = FrmCompras.TrueDBGridComponentes.Columns(0).Text
            SQlString = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodProducto & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If Not DataSet.Tables("Productos").Rows.Count = 0 Then
                CodIva = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                SQlString = "SELECT *  FROM Impuestos WHERE  (Cod_Iva = '" & CodIva & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "IVA")
                If Not DataSet.Tables("IVA").Rows.Count = 0 Then
                    Tasa = DataSet.Tables("IVA").Rows(0)("Impuesto")
                    TasaIva = DataSet.Tables("IVA").Rows(0)("Impuesto")
                End If
                DataSet.Tables("IVA").Reset()
            End If
            DataSet.Tables("Productos").Reset()

            Iva = Format(Iva + Importe * Tasa, "####0.00000000")

            iPosicion = iPosicion + 1




        Loop


        If Compras.Exonerado_Compra = False Then
            'Iva = Subtotal * Tasa
        Else
            Iva = 0
        End If

        Neto = (Subtotal + Iva) - Monto
        Resultado.Sub_Total = Format(Subtotal, "##,##0.00")
        Resultado.IVA = Format(Iva, "##,##0.00")
        Resultado.Pagado_Compra = Format(Monto, "##,##0.00")
        Resultado.Neto_Pagar = Format(Neto, "##,##0.00")

        Return Resultado

    End Function



    '//////////////////////////////////PROCESOS INSERTAR REGISTROS CON HILOS ////////////////////////////////
    Private Sub backgroundWorkerInsertar_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerInsertar.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As TablaCompras = e.Argument

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            InsertarRegistrosWorker(args, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerInsertar_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerInsertar.RunWorkerCompleted

        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Quien = "NumeroCompras"
                Me.TxtNumeroEnsamble.Text = NumeroCompra
                Bitacora(Now, NombreUsuario, "Compras", "Agrego Una Compra: " & Me.TxtNumeroEnsamble.Text)
            End If

        End If

    End Sub
    Public Sub InsertarRowGrid_Hilos(Compras As TablaCompras)
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleCompra").AcceptChanges()
            da.Update(ds.Tables("DetalleCompra"))

            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleCompra").AcceptChanges()
                da.Update(ds.Tables("DetalleCompra"))
            End If
        End If

        ActualizarGridInsertRow_Hilos(Compras)
        ActualizaDetalleBodega(Compras.Cod_Bodega, CodigoProducto)


    End Sub
    Public Sub ActualizarGridInsertRow_Hilos(Compras As TablaCompras)
        Dim SqlCompras As String, TipoCompra As String

        If Me.TrueDBGridComponentes.InvokeRequired Then
            Dim delegadoGrid As New delegadoGridRegistros(AddressOf ActualizarGridInsertRow_Hilos)
            TrueDBGridComponentes.Invoke(delegadoGrid, New Object() {Compras})
            My.Application.DoEvents()
        Else

            TipoCompra = Compras.Tipo_Compra
            If FacturaTarea = True Then
                ds.Tables("DetalleCompra").Reset()
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlCompras = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
                             "WHERE (Detalle_Compras.Numero_Compra = '" & Compras.Numero_Compra & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
                ds = New DataSet
                da = New SqlDataAdapter(SqlCompras, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleCompra")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Else
                ds.Tables("DetalleCompra").Reset()
                '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                SqlCompras = "SELECT Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras " &
                              "WHERE (Detalle_Compras.Numero_Compra = '" & Compras.Numero_Compra & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleCompras")
                'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompras")
                ds = New DataSet
                da = New SqlDataAdapter(SqlCompras, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleCompra")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            End If

        End If
    End Sub

    '////////////////////////////////////PROCESOS GRABAR COMPRAS CON HILOS //////////////
    Private Sub backgroundWorkerGrabar_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerGrabar.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim dsDetalle As New DataSet, dsMetodoPago As New DataSet, DtMetodo As New DataTable
        Dim args As TablaCompras = e.Argument(0), Quien As String = ""

        dsDetalle = e.Argument(1)
        dsMetodoPago = e.Argument(2)

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            AgregarComprasWorker(args, dsDetalle, dsMetodoPago, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerGrabar_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerGrabar.RunWorkerCompleted



        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Compras", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Compras", "Hilo Cancelado")
        Else
            MDIMain.txtSPlano2.Text = ""

            If Quien = "Imprimir" Then

            End If
        End If

    End Sub
    Private Sub backgroundWorkerGrabar_ProgressChanged(
ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
Handles backgroundWorkerGrabar.ProgressChanged


        MDIMain.txtSPlano2.Text = "Compra:" & e.UserState.ToString


    End Sub


    Private Sub backgroundWorkerAgregarEncabezado_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerAgregarEncabezado.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As TablaCompras = e.Argument

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            GrabaCompras(args)
        End If
    End Sub
    Private Sub backgroundWorkerAgregarEncabezado_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerAgregarEncabezado.RunWorkerCompleted

        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Compras", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Compras", "Hilo Cancelado")
        Else



        End If

    End Sub

    '////////////////////////////////EXISTENCIA COSTO EN PRODUCTO CON HILOS ////////////////////////////////////////
    Private Sub backgroundWorkerExistenciaCosto_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerExistenciaCosto.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As TablaDetalleCompras = e.Argument

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            ExistenciasCostos(args.Cod_Producto, args.Cantidad, args.Precio_Unitario, args.Tipo_Compra, args.Cod_Bodega)
        End If
    End Sub
    Private Sub backgroundWorkerExistenciaCosto_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerExistenciaCosto.RunWorkerCompleted

        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else


        End If

    End Sub

    '//////////////////////////////////ExistenciaLotexProducto CON HILOS //////////////
    Private Sub backgroundWorkerExistenciaLotexProducto_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerExistenciaLotexProducto.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As TablaLotexProducto = e.Argument

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            ActualizaExistenciaLotexProducto(args.Numero_Lote, args.Cod_Bodega, args.Cod_Productos, args.Fecha_Vence)
        End If
    End Sub
    Private Sub backgroundWorkerExistenciaLotexProducto_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerExistenciaLotexProducto.RunWorkerCompleted

        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else


        End If

    End Sub

    Public Sub InsertarRegistrosWorker(Compra As TablaCompras, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaCompras(Compra)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'InsertarRowGrid()

        InsertarRowGrid_Hilos(Compra)


    End Sub

    Private Sub GrabaDetalleCompras(ByVal cn As SqlClient.SqlConnection,
                                            ByVal tx As SqlClient.SqlTransaction,
                                            ByVal detalle As TablaDetalleCompras)

        Dim sql As String = "
        INSERT INTO Detalle_Compras (
            Numero_Compra, Cod_Producto, Fecha_Compra, Tipo_Compra,
            MonedaCompra, Cod_Bodega, Descripcion_Producto,
            Precio_Unitario, Descuento, Precio_Neto, Importe,
            Cantidad, Numero_Lote, Fecha_Vence
        )
        VALUES (
            @Numero_Compra, @Cod_Producto, @Fecha_Compra, @Tipo_Compra,
            @MonedaCompra, @Cod_Bodega, @Descripcion_Producto,
            @Precio_Unitario, @Descuento, @Precio_Neto, @Importe,
            @Cantidad, @Numero_Lote, @Fecha_Vence
        )"

        Using cmd As New SqlClient.SqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@Numero_Compra", detalle.Numero_Compra)
            cmd.Parameters.AddWithValue("@Cod_Producto", detalle.Cod_Producto)
            cmd.Parameters.AddWithValue("@Fecha_Compra", detalle.Fecha_Compra)
            cmd.Parameters.AddWithValue("@Tipo_Compra", detalle.Tipo_Compra)
            cmd.Parameters.AddWithValue("@MonedaCompra", detalle.Moneda_Compra)
            cmd.Parameters.AddWithValue("@Cod_Bodega", detalle.Cod_Bodega)
            cmd.Parameters.AddWithValue("@Descripcion_Producto", detalle.Descripcion_Producto)
            cmd.Parameters.AddWithValue("@Precio_Unitario", detalle.Precio_Unitario)
            cmd.Parameters.AddWithValue("@Descuento", detalle.Descuento)
            cmd.Parameters.AddWithValue("@Precio_Neto", detalle.Precio_Neto)
            cmd.Parameters.AddWithValue("@Importe", detalle.Importe)
            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad)
            cmd.Parameters.AddWithValue("@Numero_Lote", detalle.Numero_Lote)
            cmd.Parameters.AddWithValue("@Fecha_Vence", detalle.Fecha_Vence)

            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub AgregarComprasWorker(compras As TablaCompras, dsDetalle As DataSet, dsMetodoPago As DataSet, worker As BackgroundWorker, e As DoWorkEventArgs)
        Dim TotalRegistros As Integer = dsDetalle.Tables("DetalleCompra").Rows.Count
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Try
            MiConexion.Open()
            Dim Transaccion As SqlClient.SqlTransaction = MiConexion.BeginTransaction()

            ' ====================== INSERTA O ACTUALIZA ENCABEZADO ===========================
            ''///////////////////////////////////////////////////////////////////////////
            ''//////////////////////////////GRABO LOS ENCABEZADO DE COMPRAS /////////////
            ''//////////////////////////////////////////////////////////////////////////
            GrabaCompras(compras)

            ' ====================== DETALLES DE COMPRA ===========================
            For i As Integer = 0 To TotalRegistros - 1
                If worker.CancellationPending Then
                    Transaccion.Rollback()
                    e.Cancel = True
                    Exit Sub
                End If

                Dim row = dsDetalle.Tables("DetalleCompra").Rows(i)
                Dim detalle As New TablaDetalleCompras With {
                .Numero_Compra = compras.Numero_Compra,
                .Cod_Producto = If(IsDBNull(row("Cod_Producto")), "", row("Cod_Producto")),
                .Fecha_Compra = If(IsDBNull(row("Fecha_Compra")), compras.Fecha_Compra, row("Fecha_Compra")),
                .Tipo_Compra = If(IsDBNull(row("Tipo_Compra")), compras.Tipo_Compra, row("Tipo_Compra")),
                .Moneda_Compra = compras.Moneda_Compra,
                .Cod_Bodega = compras.Cod_Bodega,
                .Descripcion_Producto = If(IsDBNull(row("Descripcion_Producto")), "", row("Descripcion_Producto")),
                .Precio_Unitario = If(IsDBNull(row("Precio_Unitario")), 0, row("Precio_Unitario")),
                .Descuento = If(IsDBNull(row("Descuento")), 0, row("Descuento")),
                .Precio_Neto = If(IsDBNull(row("Precio_Neto")), 0, row("Precio_Neto")),
                .Importe = If(IsDBNull(row("Importe")), 0, row("Importe")),
                .Cantidad = If(IsDBNull(row("Cantidad")), 0, row("Cantidad")),
                .Numero_Lote = If(IsDBNull(row("Numero_Lote")), "SINLOTE", row("Numero_Lote")),
                .Fecha_Vence = If(IsDBNull(row("Fecha_Vence")) OrElse row("Fecha_Vence") = "0", CDate("1900-01-01"), row("Fecha_Vence"))
            }

                ' Inserta el detalle (transaccional)
                GrabaDetalleCompras(MiConexion, Transaccion, detalle)

                ' Solo recalcular existencias si es Mercancía Recibida
                If compras.Tipo_Compra = "Mercancia Recibida" Then
                    'ExistenciasCostosTransactional(MiConexion, Transaccion, detalle.Cod_Producto, detalle.Cantidad, detalle.Precio_Neto, detalle.Tipo_Compra, detalle.Cod_Bodega)
                    'ExistenciasCostos(detalle.Cod_Producto, detalle.Cantidad, detalle.Precio_Neto, detalle.Tipo_Compra, detalle.Cod_Bodega)
                End If

                '///////////////PROGRESO DEL HILO GRABAR //////////////////////////
                worker.ReportProgress(CInt((i + 1) / TotalRegistros * 100), detalle.Cod_Producto)
            Next

            ' ====================== MÉTODOS DE PAGO ===========================
            If dsMetodoPago IsNot Nothing AndAlso dsMetodoPago.Tables.Contains("MetodoPago") Then
                For Each row As DataRow In dsMetodoPago.Tables("MetodoPago").Rows
                    If Not IsDBNull(row("NombrePago")) Then
                        Dim NombrePago As String = row("NombrePago").ToString()
                        Dim Monto As Double = If(IsDBNull(row("Monto")), 0, row("Monto"))
                        Dim NumeroTarjeta As String = If(IsDBNull(row("NumeroTarjeta")), "", row("NumeroTarjeta"))
                        Dim FechaVence As Date = If(IsDBNull(row("FechaVence")), Now, row("FechaVence"))
                        'GrabaMetodoDetalleCompraTransactional(MiConexion, Transaccion, compras.Numero_Compra, NombrePago, Monto, NumeroTarjeta, FechaVence)
                        GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVence)
                    End If
                Next
            End If

            ' ====================== CONFIRMAR ===========================
            Transaccion.Commit()
            Bitacora(Now, NombreUsuario, compras.Tipo_Compra, "Grabo la Compra: " & compras.Numero_Compra)

        Catch ex As Exception
            Try
                MiConexion.BeginTransaction().Rollback()
            Catch
            End Try
            MessageBox.Show("Error al guardar la compra: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        Finally
            If MiConexion.State = ConnectionState.Open Then MiConexion.Close()
        End Try
    End Sub
    Public Sub AgregarComprasWorkerOld(compras As TablaCompras, dsDetalle As DataSet, dsMetodoPago As DataSet, worker As BackgroundWorker, e As DoWorkEventArgs)
        'Dim dsDetalle As DataSet, dsMetodoPago As New DataSet, DtMetodo As New DataTable
        Dim Registros As Double, iPosicion As Double, Monto As Double, NombrePago As String, NumeroTarjeta As String, FechaVenceTarjeta As Date
        Dim TablaDetalleCompras As TablaDetalleCompras = New TablaDetalleCompras

        'dsDetalle = ds.Copy
        'DtMetodo = Me.BindingMetodo.DataSource
        'dsMetodoPago.Tables.Add(DtMetodo.Copy)

        'LimpiarCompras()


        ''///////////////////////////////////////////////////////////////////////////
        ''//////////////////////////////GRABO LOS ENCABEZADO DE COMPRAS /////////////
        ''//////////////////////////////////////////////////////////////////////////
        GrabaCompras(compras)


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Registros = dsDetalle.Tables("DetalleCompra").Rows.Count
        iPosicion = 0
        Monto = 0

        Do While iPosicion < Registros



            My.Application.DoEvents()

            TablaDetalleCompras.Numero_Compra = compras.Numero_Compra
            TablaDetalleCompras.Cod_Producto = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Cod_Producto")
            TablaDetalleCompras.Fecha_Compra = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Fecha_Compra")
            TablaDetalleCompras.Tipo_Compra = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Tipo_Compra")
            TablaDetalleCompras.Moneda_Compra = compras.Moneda_Compra
            TablaDetalleCompras.Cod_Bodega = compras.Cod_Bodega

            TablaDetalleCompras.Descripcion_Producto = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Descripcion_Producto")

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("id_Detalle_Compra")) Then
                TablaDetalleCompras.IdDetalleCompra = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("id_Detalle_Compra")
            Else
                TablaDetalleCompras.IdDetalleCompra = -1
            End If


            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Precio_Unitario")) Then
                TablaDetalleCompras.Precio_Unitario = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Precio_Unitario")
            Else
                TablaDetalleCompras.Precio_Unitario = 0
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Descuento")) Then
                TablaDetalleCompras.Descuento = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Descuento")
            Else
                TablaDetalleCompras.Descuento = 0
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Precio_Neto")) Then
                TablaDetalleCompras.Precio_Neto = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Precio_Neto")
            Else
                TablaDetalleCompras.Precio_Neto = 0
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe")) Then
                TablaDetalleCompras.Importe = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Importe")
            Else
                TablaDetalleCompras.Importe = 0
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Cantidad")) Then
                TablaDetalleCompras.Cantidad = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Cantidad")
            Else
                TablaDetalleCompras.Cantidad = 0
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Numero_Lote")) Then
                TablaDetalleCompras.Numero_Lote = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Numero_Lote")
            Else
                TablaDetalleCompras.Numero_Lote = "SINLOTE"
            End If

            If Not IsDBNull(dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Fecha_Vence")) Then
                If dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Fecha_Vence") = "0" Then
                    TablaDetalleCompras.Fecha_Vence = "01/01/1900"
                Else
                    TablaDetalleCompras.Fecha_Vence = dsDetalle.Tables("DetalleCompra").Rows(iPosicion)("Fecha_Vence")
                End If

            Else
                TablaDetalleCompras.Fecha_Vence = "01/01/1900"

            End If

            '///////////////PROGRESO DEL HILO GRABAR //////////////////////////
            worker.ReportProgress(iPosicion, TablaDetalleCompras.Cod_Producto)

            If CambiarFechaCompra = True Then

                GrabaDetalleCompra(TablaDetalleCompras.Numero_Compra, TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Precio_Unitario, TablaDetalleCompras.Descuento, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Importe, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Numero_Lote, TablaDetalleCompras.Fecha_Vence, TablaDetalleCompras.Descripcion_Producto, TablaDetalleCompras.Fecha_Compra, TablaDetalleCompras.Moneda_Compra, TablaDetalleCompras.Tipo_Compra)

                Select Case compras.Tipo_Compra
                    Case "Mercancia Recibida"
                        ExistenciasCostos(TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Tipo_Compra, TablaDetalleCompras.Cod_Bodega)
                End Select

            ElseIf compras.Tipo_Compra = "Cuenta" Then

                GrabaDetalleCompra(TablaDetalleCompras.Numero_Compra, TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Precio_Unitario, TablaDetalleCompras.Descuento, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Importe, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Numero_Lote, TablaDetalleCompras.Fecha_Vence, TablaDetalleCompras.Descripcion_Producto, TablaDetalleCompras.Fecha_Compra, TablaDetalleCompras.Moneda_Compra, TablaDetalleCompras.Tipo_Compra)

                Select Case compras.Tipo_Compra
                    Case "Mercancia Recibida"
                        ExistenciasCostos(TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Tipo_Compra, TablaDetalleCompras.Cod_Bodega)
                End Select


            ElseIf compras.Tipo_Compra = "Cuenta DB" Then

                GrabaDetalleCompra(TablaDetalleCompras.Numero_Compra, TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Precio_Unitario, TablaDetalleCompras.Descuento, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Importe, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Numero_Lote, TablaDetalleCompras.Fecha_Vence, TablaDetalleCompras.Descripcion_Producto, TablaDetalleCompras.Fecha_Compra, TablaDetalleCompras.Moneda_Compra, TablaDetalleCompras.Tipo_Compra)

                Select Case compras.Tipo_Compra
                    Case "Mercancia Recibida"
                        ExistenciasCostos(TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Tipo_Compra, TablaDetalleCompras.Cod_Bodega)
                End Select

            Else
                '////////////////ESTA OPCION SI EDITAN ORDNES DE COMPRA Y MERCANCIA RECIBIDA
                GrabaDetalleCompra(TablaDetalleCompras.Numero_Compra, TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Precio_Unitario, TablaDetalleCompras.Descuento, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Importe, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Numero_Lote, TablaDetalleCompras.Fecha_Vence, TablaDetalleCompras.Descripcion_Producto, TablaDetalleCompras.Fecha_Compra, TablaDetalleCompras.Moneda_Compra, TablaDetalleCompras.Tipo_Compra)

                Select Case compras.Tipo_Compra
                    Case "Mercancia Recibida"
                        ExistenciasCostos(TablaDetalleCompras.Cod_Producto, TablaDetalleCompras.Cantidad, TablaDetalleCompras.Precio_Neto, TablaDetalleCompras.Tipo_Compra, TablaDetalleCompras.Cod_Bodega)
                End Select

            End If




            iPosicion = iPosicion + 1
        Loop


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Registros = dsMetodoPago.Tables("MetodoPago").Rows.Count
        iPosicion = 0
        Monto = 0
        Do While iPosicion < Registros
            My.Application.DoEvents()
            If Not IsDBNull(dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("NombrePago")) Then
                NombrePago = dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("NombrePago")
                Monto = dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("Monto") '+ Monto
                If Not IsDBNull(dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("NumeroTarjeta")) Then
                    NumeroTarjeta = dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("NumeroTarjeta")
                Else
                    NumeroTarjeta = 0
                End If
                If Not IsDBNull(dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("FechaVence")) Then
                    FechaVenceTarjeta = dsMetodoPago.Tables("MetodoPago").Rows(iPosicion)("FechaVence")
                Else
                    FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
                End If

                GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)

            End If
            iPosicion = iPosicion + 1
        Loop

        Bitacora(Now, NombreUsuario, compras.Tipo_Compra, "Grabo la Compra: " & compras.Numero_Compra)


        'GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)



    End Sub

    Public Sub AgregarEncabezado()
        Dim cod As String = "1", Compras As TablaCompras = New TablaCompras
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False



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
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                Case "Cuenta DB"
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
            End Select

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

            End If

            If CompraBodega = True Then
                NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
            Else
                NumeroCompra = Format(ConsecutivoCompra, "0000#")
            End If
        Else
            'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroCompras"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
            Bitacora(Now, NombreUsuario, "Compras", "Agrego Una Compra: " & Me.TxtNumeroEnsamble.Text)
        End If


        Compras.Numero_Compra = NumeroCompra
        Compras.Fecha_Compra = Format(DTPFecha.Value, "yyyy-MM-dd")
        Compras.Tipo_Compra = CboTipoProducto.Text
        Compras.Cod_Bodega = CboCodigoBodega.Text
        Compras.Moneda_Compra = TxtMonedaFactura.Text
        Compras.Cod_Proveedor = TxtCodigoProveedor.Text
        Compras.Nombre_Proveedor = TxtNombres.Text
        Compras.Apellido_Proveedor = TxtApellidos.Text
        Compras.Direccion_Proveedor = TxtDireccion.Text
        Compras.Telefono_Proveedor = TxtTelefono.Text
        Compras.Fecha_Vencimiento = DTVencimiento.Value
        Compras.Observaciones_Cómpra = TxtObservaciones.Text
        Compras.Descuento_Compra = 0
        Compras.Fecha_Descuento = Now
        If Me.TxtSubTotal.Text <> "" Then
            Compras.Sub_Total = TxtSubTotal.Text
        Else
            Compras.Sub_Total = 0
        End If
        If Me.TxtIva.Text <> "" Then
            Compras.IVA = TxtIva.Text
        Else
            Compras.IVA = 0
        End If
        If Me.TxtPagado.Text <> "" Then
            Compras.Pagado_Compra = TxtPagado.Text
        Else
            Compras.Pagado_Compra = 0
        End If
        If Me.TxtNetoPagar.Text <> "" Then
            Compras.Neto_Pagar = TxtNetoPagar.Text
            Compras.Monto_Credito = TxtNetoPagar.Text
        Else
            Compras.Neto_Pagar = 0
            Compras.Monto_Credito = 0
        End If

        Compras.Contabilizado_Compra = 0
        Compras.Activo_Compra = 1
        Compras.Cancelado_Compra = 0
        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If
        If TxtReferencia.Text <> "" Then
            Compras.Su_Referencia = TxtReferencia.Text
        End If

        If CboReferencia.Text <> "" Then
            Compras.Referencia_Compra = CboReferencia.Text
        End If
        Compras.Transferencia_Procesada = 0
        Compras.Marca_Compra = 1
        Compras.Codigo_Proyecto = ""
        If Not CboProyecto.Text = "" Then
            Compras.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If
        Compras.Nuestra_Referencia = CboReferencia.Text
        Compras.Fecha_Hora = DTPFecha.Value & " " & Format(Now, "HH:mm")
        Compras.Tipo_Productor = ""
        Compras.Estatus_Compra = "Grabado"
        Compras.Numero_Solicitud = 0
        Compras.Numero_Orden = 0
        Compras.Solcitud_CtaContable = 0

        If TxtSubTotal.Text <> "" Then
            Compras.Sub_Total = TxtSubTotal.Text
        Else
            Compras.Sub_Total = 0
        End If

        If TxtIva.Text <> "" Then
            Compras.IVA = TxtIva.Text
        Else
            Compras.IVA = 0
        End If

        If TxtPagado.Text <> "" Then
            Compras.Pagado_Compra = TxtPagado.Text
        Else
            Compras.Pagado_Compra = 0
        End If

        If TxtNetoPagar.Text <> "" Then
            Compras.Neto_Pagar = TxtNetoPagar.Text
        Else
            Compras.Neto_Pagar = 0
        End If

        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If

        If ChkAplicarCtasXPagar.Checked = True Then
            Compras.Aplicar_CtasXPagar = 1
        Else
            Compras.Aplicar_CtasXPagar = 0
        End If


        GrabaCompras(Compras)

        'Desactivado 27/09/2025
        'Dim worker As BackgroundWorker
        'worker = New BackgroundWorker()
        'AddHandler worker.DoWork, AddressOf backgroundWorkerAgregarEncabezado_DoWork
        'AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerAgregarEncabezado_RunWorkerCompleted
        'worker.RunWorkerAsync(Compras)

    End Sub

    Public Sub AgregarCompras()
        Dim cod As String = "1", Compras As TablaCompras = New TablaCompras
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim dsDetalle As DataSet, dsMetodoPago As New DataSet, DtMetodo As New DataTable

        ActualizaMETODOcOMPRA()

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
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                Case "Cuenta DB"
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
            End Select

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

            End If

            If CompraBodega = True Then
                NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
            Else
                NumeroCompra = Format(ConsecutivoCompra, "0000#")
            End If
        Else
            'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroCompras"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
            Bitacora(Now, NombreUsuario, "Compras", "Agrego Una Compra: " & Me.TxtNumeroEnsamble.Text)
        End If

        Compras.Numero_Compra = NumeroCompra
        Compras.Fecha_Compra = Format(DTPFecha.Value, "yyyy-MM-dd")
        Compras.Tipo_Compra = CboTipoProducto.Text
        Compras.Cod_Bodega = CboCodigoBodega.Text
        Compras.Moneda_Compra = TxtMonedaFactura.Text
        Compras.Cod_Proveedor = TxtCodigoProveedor.Text
        Compras.Nombre_Proveedor = TxtNombres.Text
        Compras.Apellido_Proveedor = TxtApellidos.Text
        Compras.Direccion_Proveedor = TxtDireccion.Text
        Compras.Telefono_Proveedor = TxtTelefono.Text
        Compras.Fecha_Vencimiento = DTVencimiento.Value
        Compras.Observaciones_Cómpra = TxtObservaciones.Text
        Compras.Descuento_Compra = 0
        Compras.Fecha_Descuento = Now
        Compras.Sub_Total = TxtSubTotal.Text
        Compras.IVA = TxtIva.Text
        Compras.Pagado_Compra = TxtPagado.Text
        Compras.Neto_Pagar = TxtNetoPagar.Text
        Compras.Monto_Credito = TxtNetoPagar.Text
        Compras.Contabilizado_Compra = 0
        Compras.Activo_Compra = 1
        Compras.Cancelado_Compra = 0
        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If
        If TxtReferencia.Text <> "" Then
            Compras.Su_Referencia = TxtReferencia.Text
        End If

        If CboReferencia.Text <> "" Then
            Compras.Referencia_Compra = CboReferencia.Text
        End If
        Compras.Transferencia_Procesada = 0
        Compras.Marca_Compra = 1
        Compras.Codigo_Proyecto = ""
        If Not CboProyecto.Text = "" Then
            Compras.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If
        Compras.Nuestra_Referencia = CboReferencia.Text
        Compras.Fecha_Hora = DTPFecha.Value & " " & Format(Now, "HH:mm")
        Compras.Tipo_Productor = ""
        Compras.Estatus_Compra = "Grabado"
        Compras.Numero_Solicitud = 0
        Compras.Numero_Orden = 0
        Compras.Solcitud_CtaContable = 0

        If TxtSubTotal.Text <> "" Then
            Compras.Sub_Total = TxtSubTotal.Text
        Else
            Compras.Sub_Total = 0
        End If

        If TxtIva.Text <> "" Then
            Compras.IVA = TxtIva.Text
        Else
            Compras.IVA = 0
        End If

        If TxtPagado.Text <> "" Then
            Compras.Pagado_Compra = TxtPagado.Text
        Else
            Compras.Pagado_Compra = 0
        End If

        If TxtNetoPagar.Text <> "" Then
            Compras.Neto_Pagar = TxtNetoPagar.Text
        Else
            Compras.Neto_Pagar = 0
        End If

        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If

        If ChkAplicarCtasXPagar.Checked = True Then
            Compras.Aplicar_CtasXPagar = 1
        Else
            Compras.Aplicar_CtasXPagar = 0
        End If

        '/////////////////////////////Copio los DataSet ///////////////////////////
        dsDetalle = ds.Copy
        DtMetodo = Me.BindingMetodo.DataSource
        dsMetodoPago.Tables.Add(DtMetodo.Copy)

        LimpiarCompras()

        My.Application.DoEvents()

        Dim worker As BackgroundWorker
        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf backgroundWorkerGrabar_DoWork
        AddHandler worker.ProgressChanged, AddressOf backgroundWorkerGrabar_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerGrabar_RunWorkerCompleted
        worker.RunWorkerAsync({Compras, dsDetalle, dsMetodoPago})


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
    Public Sub Guardar_Registros_Row()
        Dim cod As String = "1", Compras As TablaCompras = New TablaCompras
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim worker As BackgroundWorker
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
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                Case "Cuenta DB"
                    ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
            End Select

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

            End If

            If CompraBodega = True Then
                NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
            Else
                NumeroCompra = Format(ConsecutivoCompra, "0000#")
            End If
        Else
            'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroCompras"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
            Bitacora(Now, NombreUsuario, "Compras", "Agrego Una Compra: " & Me.TxtNumeroEnsamble.Text)
        End If

        Compras.Numero_Compra = NumeroCompra
        Compras.Fecha_Compra = Format(DTPFecha.Value, "yyyy-MM-dd")
        Compras.Tipo_Compra = CboTipoProducto.Text
        Compras.Cod_Bodega = CboCodigoBodega.Text
        Compras.Moneda_Compra = TxtMonedaFactura.Text
        Compras.Cod_Proveedor = TxtCodigoProveedor.Text
        Compras.Nombre_Proveedor = TxtNombres.Text
        Compras.Apellido_Proveedor = TxtApellidos.Text
        Compras.Direccion_Proveedor = TxtDireccion.Text
        Compras.Telefono_Proveedor = TxtTelefono.Text
        Compras.Fecha_Vencimiento = DTVencimiento.Value
        Compras.Observaciones_Cómpra = TxtObservaciones.Text
        Compras.Descuento_Compra = 0
        Compras.Fecha_Descuento = Now
        Compras.Sub_Total = TxtSubTotal.Text
        Compras.IVA = TxtIva.Text
        Compras.Pagado_Compra = TxtPagado.Text
        Compras.Neto_Pagar = TxtNetoPagar.Text
        Compras.Monto_Credito = TxtNetoPagar.Text
        Compras.Contabilizado_Compra = 0
        Compras.Activo_Compra = 1
        Compras.Cancelado_Compra = 0
        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If
        If TxtReferencia.Text <> "" Then
            Compras.Su_Referencia = TxtReferencia.Text
        End If

        If CboReferencia.Text <> "" Then
            Compras.Referencia_Compra = CboReferencia.Text
        End If
        Compras.Transferencia_Procesada = 0
        Compras.Marca_Compra = 1
        Compras.Codigo_Proyecto = ""
        If Not CboProyecto.Text = "" Then
            Compras.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If
        Compras.Nuestra_Referencia = CboReferencia.Text
        Compras.Fecha_Hora = DTPFecha.Value & " " & Format(Now, "HH:mm")
        Compras.Tipo_Productor = ""
        Compras.Estatus_Compra = "Grabado"
        Compras.Numero_Solicitud = 0
        Compras.Numero_Orden = 0
        Compras.Solcitud_CtaContable = 0

        If TxtSubTotal.Text <> "" Then
            Compras.Sub_Total = TxtSubTotal.Text
        Else
            Compras.Sub_Total = 0
        End If

        If TxtIva.Text <> "" Then
            Compras.IVA = TxtIva.Text
        Else
            Compras.IVA = 0
        End If

        If TxtPagado.Text <> "" Then
            Compras.Pagado_Compra = TxtPagado.Text
        Else
            Compras.Pagado_Compra = 0
        End If

        If TxtNetoPagar.Text <> "" Then
            Compras.Neto_Pagar = TxtNetoPagar.Text
        Else
            Compras.Neto_Pagar = 0
        End If

        If OptExsonerado.Checked = True Then
            Compras.Exonerado_Compra = 1
        Else
            Compras.Exonerado_Compra = 0
        End If

        If ChkAplicarCtasXPagar.Checked = True Then
            Compras.Aplicar_CtasXPagar = 1
        Else
            Compras.Aplicar_CtasXPagar = 0
        End If

        MiConexion.Close()

        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf backgroundWorkerInsertar_DoWork
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerInsertar_RunWorkerCompleted
        worker.RunWorkerAsync(Compras)


    End Sub



    Public Sub CargarCompra(ByVal FechaCompra As Date, ByVal FechaHoraCompra As Date, ByVal NumeroCompra As String, ByVal TipoCompra As String)
        Dim SqlDatos As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If


        'If FacturaTarea = True Then
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras WHERE (Detalle_Compras.Numero_Compra = '-1')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    'DataAdapter.Fill(DataSet, "DetalleCompra")
        '    ds = New DataSet
        '    da = New SqlDataAdapter(SqlString, MiConexion)
        '    CmdBuilder = New SqlCommandBuilder(da)
        '    da.Fill(ds, "DetalleCompra")
        '    Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
        '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        '    Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        '    Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        '    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        '    Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
        '    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
        '    Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
        '    Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        '    Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False

        'Else

        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  WHERE (Detalle_Compras.Numero_Compra = '-1')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    'DataAdapter.Fill(DataSet, "DetalleCompra")
        '    'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
        '    ds = New DataSet
        '    da = New SqlDataAdapter(SqlString, MiConexion)
        '    CmdBuilder = New SqlCommandBuilder(da)
        '    da.Fill(ds, "DetalleCompra")
        '    Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
        '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        '    Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        '    Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        '    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        '    Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
        '    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
        '    Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
        '    Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        '    Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False

        'End If


        Me.DTPFecha.Value = FechaCompra
        Me.DTPFechaHora.Value = FechaHoraCompra
        Me.CboTipoProducto.Text = TipoCompra
        'Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNumeroEnsamble.Text = NumeroCompra
        Me.CboCodigoBodega.Enabled = False
        Me.Button7.Enabled = False

        If PermiteEditar(Acceso, "Compras") = False Then
            Me.ButtonAgregar.Enabled = False
            'Me.TrueDBGridComponentes.Enabled = False
        Else
            Me.ButtonAgregar.Enabled = True
            Me.TrueDBGridComponentes.Enabled = True

        End If
    End Sub


    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleCompra").AcceptChanges()
            da.Update(ds.Tables("DetalleCompra"))

            'Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleCompra").AcceptChanges()
                da.Update(ds.Tables("DetalleCompra"))
            End If
        End If




        'Desactivado 26/09/2025
        'ActualizarGridInsertRow()
        'Me.TrueDBGridComponentes.Row = iPosicion
        'Me.TrueDBGridComponentes.Col = 0
        'ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


    End Sub
    Public Sub ActualizarGridInsertRow()
        Dim SqlCompras As String, TipoCompra As String

        TipoCompra = Me.CboTipoProducto.Text

        My.Application.DoEvents()

        If FacturaTarea = True Then
            ds.Tables("DetalleCompra").Reset()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
                        "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleCompra")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
            ds = New DataSet
            da = New SqlDataAdapter(SqlCompras, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False

        Else
            ds.Tables("DetalleCompra").Reset()
            '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
            SqlCompras = "SELECT Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras " &
                         "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleCompras")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompras")
            ds = New DataSet
            da = New SqlDataAdapter(SqlCompras, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
        End If

    End Sub


    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String, Registros As Double


        Select Case Me.TrueDBGridComponentes.Col

            Case 0


                If Me.CboTipoProducto.Text = "Cuenta" Then
                    CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                    SqlString = "SELECT  Cuentas.* FROM Cuentas WHERE(CodCuentas = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiconexionContabilidad)
                    DataAdapter.Fill(DataSet, "CuentaContable")
                    If DataSet.Tables("CuentaContable").Rows.Count <> 0 Then
                        Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("CuentaContable").Rows(0)("DescripcionCuentas")
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                    End If

                ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then

                    CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                    SqlString = "SELECT  Cuentas.* FROM Cuentas WHERE(CodCuentas = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiconexionContabilidad)
                    DataAdapter.Fill(DataSet, "CuentaContable")
                    If DataSet.Tables("CuentaContable").Rows.Count <> 0 Then
                        Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("CuentaContable").Rows(0)("DescripcionCuentas")
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = -1
                    End If

                Else


                    If PerteneceProductoBodega(Me.CboCodigoBodega.Text, Me.TrueDBGridComponentes.Columns(0).Text) = False Then
                        Exit Sub
                    End If

                    If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
                        Exit Sub
                    Else
                        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                        SqlString = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count <> 0 Then
                            Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")

                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////BUSCO EL ULTIMO PRECIO DE COMPRA /////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlString = "SELECT Cod_Producto, Cantidad, Precio_Unitario, Importe FROM Detalle_Compras WHERE (Cod_Producto = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            Registros = DataSet.Tables("Productos").Rows.Count

                            If Registros = 0 Then
                                Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Costo_Promedio")
                            Else
                                If Not IsDBNull(DataSet.Tables("Productos").Rows(Registros - 1)("Precio_Unitario")) Then
                                    Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(Registros - 1)("Precio_Unitario")
                                Else
                                    Me.TrueDBGridComponentes.Columns(3).Text = 0
                                End If
                            End If


                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                        Else

                            MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Quien = "CodigoProductosCompra"
                            My.Forms.FrmConsultas.ShowDialog()
                            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                                Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                                Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                            Else
                                Me.TrueDBGridComponentes.Columns(0).Text = ""
                                Me.TrueDBGridComponentes.Columns(1).Text = ""
                            End If

                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////BUSCO EL ULTIMO PRECIO DE COMPRA /////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlString = "SELECT Cod_Producto, Cantidad, Precio_Unitario, Importe FROM Detalle_Compras WHERE (Cod_Producto = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            Registros = DataSet.Tables("Productos").Rows.Count

                            If Registros = 0 Then
                                Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
                            Else
                                Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(Registros - 1)("Precio_Unitario")
                            End If


                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                        End If
                    End If


                End If


            Case 3

                If Me.CboTipoProducto.Text = "Cuenta" Then
                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then
                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = -1
                End If

        End Select
    End Sub

    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ConsecutivoCompra As Double, iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, SqlConsecutivo As String
        'Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double

        '////////////////////Comentario 25/08/2025
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
        '        Case "Cuenta"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '        Case "Cuenta DB"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '    End Select

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////
        '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        '    DataAdapter.Fill(DataSet, "Configuracion")
        '    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
        '            FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
        '            CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
        '        End If

        '    End If

        '    If CompraBodega = True Then
        '        NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
        '    Else
        '        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    End If
        'Else
        '    'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        '    'NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    NumeroCompra = Me.TxtNumeroEnsamble.Text
        'End If



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        '//////////Comentario 25/08/2025
        'GrabaCompras(NumeroCompra)

        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Quien = "NumeroCompras"
        '    Me.TxtNumeroEnsamble.Text = NumeroCompra
        '    Bitacora(Now, NombreUsuario, "Compras", "Agrego Una Compra: " & Me.TxtNumeroEnsamble.Text)
        'End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7



        'Registros = Me.BindingDetalle.Count
        'iPosicion = Me.BindingDetalle.Position

        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cod_Producto")) Then
        '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        'End If

        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
        '    PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        'End If
        'If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
        '    PrecioUnitario = Me.TrueDBGridComponentes.Columns(3).Text
        'Else
        '    Me.TrueDBGridComponentes.Columns(3).Text = 0
        'End If
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        'End If
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
        '    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")

        'End If
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
        '    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        'End If
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
        'End If


        'Select Case e.ColIndex
        '    Case 0 : Me.TrueDBGridComponentes.Col = 2
        'End Select



        'If BuscaProducto(CodigoProducto, Me.CboCodigoBodega.Text) = True Then
        '    GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad)

        '    Select Case Me.CboTipoProducto.Text
        '        Case "Mercancia Recibida"
        '            DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
        '            DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
        '            ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '        Case "Devolucion de Compra"
        '            DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
        '            DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
        '            ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '    End Select
        'Else
        '    MsgBox("No se Puede Agregar este Producto ,No esta Asignado en la Bodega", MsgBoxStyle.Critical, "BODEGA " & Me.CboCodigoBodega.Text)
        'End If
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim iPosicion As Double = 0, CodigoProducto As String, Registros As Double
        Dim NumeroLote As String, FechaVence As String

        'Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        'Dim NumeroCompra As String, ConsecutivoCompra As Double, Registros As Double, iPosicion As Double
        'Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, SQLString As String, TipoProducto As String = "", TipoDescuento As String, PrecioDescCordobas As Double, PrecioDescDolar

        If Me.CboCodigoBodega.Text = "" Then
            MsgBox("Es necesario que seleccione la  Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If


        If Me.TxtCodigoProveedor.Text = "" Then
            Exit Sub
        Else

            '///////////////22/08/2025 Desactivo la consulta para aumentar velocidad
            'SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            'DataAdapter.Fill(DataSet, "Proveedor")
            'If DataSet.Tables("Proveedor").Rows.Count = 0 Then
            '    Exit Sub
            'End If
        End If


        If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
            Exit Sub
        Else
            '///////////////////22/08/2025  desactivo por velocidad
            'CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
            'SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            'DataAdapter.Fill(DataSet, "Productos")
            'If DataSet.Tables("Productos").Rows.Count = 0 Then
            '    Exit Sub
            'End If
        End If

        InsertarRowGrid()

        Registros = Me.TrueDBGridComponentes.RowCount
        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")

        '///////////////////////////EXISTENCIA COSTO LA PROCESO EN SEGUNDO PLANO ///////////
        '//////////////////////////PROCESO MUY LARGO ///////////////////////
        Dim worker As BackgroundWorker, workerActualizaMetodo As BackgroundWorker, Detalle As New TablaDetalleCompras
        Dim Compras As New TablaCompras, dsDetalle As New DataSet

        worker = New BackgroundWorker()
        workerActualizaMetodo = New BackgroundWorker()

        If FacturaTarea = True Then
            Dim Lote As TablaLotexProducto = New TablaLotexProducto
            Dim WorkerLote As BackgroundWorker
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
                NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
            Else
                NumeroLote = "SIN LOTE"
            End If
            If IsDate(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
                FechaVence = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
            Else
                FechaVence = "01-01-1900"
            End If

            WorkerLote = New BackgroundWorker()

                Lote.Numero_Lote = NumeroLote
                Lote.Cod_Bodega = Me.CboCodigoBodega.Text
                Lote.Cod_Productos = CodigoProducto
                If Not IsDate(FechaVence) Then
                    FechaVence = "01-01-1900"
                End If
                Lote.Fecha_Vence = FechaVence

                AddHandler WorkerLote.DoWork, AddressOf backgroundWorkerExistenciaLotexProducto_DoWork
                AddHandler WorkerLote.RunWorkerCompleted, AddressOf backgroundWorkerExistenciaLotexProducto_RunWorkerCompleted
                WorkerLote.RunWorkerAsync(Lote)

                'ActualizaExistenciaLotexProducto(NumeroLote, Me.CboCodigoBodega.Text, CodigoProducto, FechaVence)
            End If


            dsDetalle = ds.Copy
        Compras.Numero_Compra = Me.TxtNumeroEnsamble.Text
        Compras.Fecha_Compra = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        Compras.Moneda_Compra = Me.TxtMonedaFactura.Text
        Compras.Tipo_Compra = Me.CboTipoProducto.Text
        Compras.Exonerado_Compra = OptExsonerado.Checked

        '/////////////////////////ACTUALIZO METODO COMPRA SEGUNDO PLANO ////////////////////
        AddHandler workerActualizaMetodo.DoWork, AddressOf backgroundWorkerMetodoCompra_DoWork
        AddHandler workerActualizaMetodo.RunWorkerCompleted, AddressOf backgroundWorkerMetodoCompra_RunWorkerCompleted
        workerActualizaMetodo.RunWorkerAsync({Compras, dsDetalle, dsMetodo})

        Detalle.Cod_Producto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        Detalle.Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        Detalle.Precio_Unitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        Detalle.Tipo_Compra = Me.CboTipoProducto.Text
        Detalle.Cod_Bodega = Me.CboCodigoBodega.Text

        '///////////////////////EXISTENCIA EN SEGUNDO PLANO ///////////////
        AddHandler worker.DoWork, AddressOf backgroundWorkerExistenciaCosto_DoWork
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerExistenciaCosto_RunWorkerCompleted
        worker.RunWorkerAsync(Detalle)

        ActualizarGridInsertRow()
        Me.TrueDBGridComponentes.Row = iPosicion
        Me.TrueDBGridComponentes.Col = 0

        Bitacora(Now, NombreUsuario, "Compras", "Modifico Producto: " & CodigoProducto)




    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double, CodProducto As String

        iPosicion = Me.BindingDetalle.Position


        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        iPosicion = Me.BindingDetalle.Position

        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cod_Productos")) Then
        '    If TieneMovimientos(Me.BindingDetalle.Item(iPosicion)("Cod_Productos"), Me.DTPFechaHora.Value) = True Then
        '        MsgBox("No se Puede Editar " & Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If

        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '    CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        'End If
        If Not IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
            Me.TrueDBGridComponentes.Columns(3).Text = 0
        End If
        'If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
        '    iPosicion = Me.BindingDetalle.Position
        '    PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        'Else
        '    PrecioAnterior = 0
        'End If

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
        Dim iPosicion As Double

        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        'If TieneMovimientos(CodProducto, Me.DTPFechaHora.Value) = True Then
        '    MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
        '    e.Cancel = True
        '    Exit Sub
        'End If

        Cols = e.ColIndex
        If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
            Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        Else
            Precio = 0
        End If
        Descuento = 0
        Tasa = 0

        If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
            MsgBox("Digite la Cantidad", MsgBoxStyle.Critical, "Zeus Facturacion")
            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
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

        DataSet.Reset()
        Select Case Cols
            Case 0

                If Me.CboTipoProducto.Text <> "Cuenta" Then
                    If Me.CboTipoProducto.Text <> "Cuenta DB" Then
                        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text

                        If PerteneceProductoBodega(Me.CboCodigoBodega.Text, Me.TrueDBGridComponentes.Columns(0).Text) = False Then
                            Mensaje = "No Pertenece el Producto a esta Bodega" & Chr(13) &
                                      "Precio ESC Para Salir"
                            MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
                            e.Cancel = True
                            Exit Sub
                        End If


                        SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count = 0 Then
                            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then

                                '////////////////BUSCO EL CODIGO ALTERNATIVO ///////////////////////////////////////////////////
                                Dim CodigoAlterno As String = CodProducto

                                SqlProveedor = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                DataAdapter.Fill(DataSet, "Alternos")
                                If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                                    Me.TrueDBGridComponentes.Columns(0).Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                                    'Me.TrueDBGridComponentes.Col = 2
                                Else
                                    MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                                    Exit Sub
                                End If
                            End If
                        Else
                            Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                            Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                        End If
                        DataSet.Tables("Productos").Clear()

                    End If
                End If

            Case 2
                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                End If
            Case 3
                If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                End If
                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                End If
            Case 4

                If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                End If
                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                End If

        End Select

        If Me.CboTipoProducto.Text <> "Cuenta" Then
            If Me.CboTipoProducto.Text <> "Cuenta DB" Then
                '///////////////////////////////////////  TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                Select Case TipoDescuento
                    Case "ImporteFijo"
                        Me.TrueDBGridComponentes.Columns(2).Text = 1
                        Cantidad = 1
                        Me.TrueDBGridComponentes.Columns(4).Text = ""
                        If Me.TxtMonedaFactura.Text = "Cordobas" Then
                            Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.0000")
                            Precio = PrecioDescCordobas
                        Else
                            Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.0000")
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
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.0000")

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


                Me.TrueDBGridComponentes.Columns(5).Text = Format(Precio * (1 - Descuento), "##,##0.0000")
                Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.0000")

            End If
        End If


        If Me.CboTipoProducto.Text = "Cuenta" Then
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio, "##,##0.0000")
            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Precio, "##,##0.0000")
        ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio, "##,##0.0000")
            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Precio, "##,##0.0000")
        End If



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

            If Me.CboTipoProducto.Text <> "Cuenta" Then
                If Me.CboTipoProducto.Text <> "Cuenta DB" Then
                    CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count = 0 Then

                        '////////////////BUSCO EL CODIGO ALTERNATIVO ///////////////////////////////////////////////////
                        Dim CodigoAlterno As String = CodProducto

                        SqlProveedor = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                        DataAdapter.Fill(DataSet, "Alternos")
                        If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                            Me.TrueDBGridComponentes.Columns(0).Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                        Else
                            MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                            Exit Sub
                        End If
                    End If
                End If

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
                CostoBodega(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
            Case "Devolucion de Compra"
                DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                CostoBodega(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
        End Select


    End Sub



    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim SQlString As String, CodigoProducto As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double
        Dim TipoProducto As String = "Servicio", TipoDescuento As String = "ImporteFijo", PrecioDescCordobas As Double, PrecioDescDolar As Double
        Dim Cantidad As Double, Precio As Double, SubTotal As Double, PorcientoDescuento As Double, Neto As Double
        Dim CodProducto As String, iPosicion As Double

        If Me.TxtCodigoProveedor.Text = "" Then
            MsgBox("Se Necesito el codigo Proveedor", vbCritical, "Zeus Facturacion")
            Exit Sub
        End If


        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        iPosicion = Me.BindingDetalle.Position



        If e.ColIndex = 0 Then
            If TieneContrato = False Then
                If Me.CboTipoProducto.Text = "Cuenta" Then
                    Quien = "Cuenta"
                    My.Forms.FrmConsultas.ShowDialog()
                ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then
                    Quien = "Cuenta"
                    My.Forms.FrmConsultas.ShowDialog()
                Else
                    Quien = "CodigoProductosCompra"
                    My.Forms.FrmConsultas.ShowDialog()
                End If

            Else
                '/////////////////////Tiene Contrato /////////////////////
                If Me.CboTipoProducto.Text = "Cuenta" Then
                    Quien = "CuentaContrato"
                    My.Forms.FrmConsultas.TieneContrato = TieneContrato
                    My.Forms.FrmConsultas.CodigoProveedor = Me.TxtCodigoProveedor.Text
                    My.Forms.FrmConsultas.ShowDialog()
                ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then
                    Quien = "CuentaContrato"
                    My.Forms.FrmConsultas.TieneContrato = TieneContrato
                    My.Forms.FrmConsultas.CodigoProveedor = Me.TxtCodigoProveedor.Text
                    My.Forms.FrmConsultas.ShowDialog()
                Else
                    Quien = "CodigoProductosCompraContrato"
                    My.Forms.FrmConsultas.CodigoProveedor = Me.TxtCodigoProveedor.Text
                    My.Forms.FrmConsultas.ShowDialog()
                End If
            End If

            ActualizaMETODOcOMPRA()

                If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then


                    Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                    Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion

                    If Me.CboTipoProducto.Text = "Cuenta" Then
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                    ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = -1
                    Else

                        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////BUSCO EL ULTIMO PRECIO DE COMPRA /////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        CodigoProducto = My.Forms.FrmConsultas.Codigo
                        SQlString = "SELECT Cod_Producto, Cantidad, Precio_Unitario, Importe FROM Detalle_Compras WHERE (Cod_Producto = '" & CodigoProducto & "') AND (Precio_Unitario <> 0)"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        Registros = DataSet.Tables("Productos").Rows.Count

                        If Registros = 0 Then
                            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
                        Else

                            Precio = DataSet.Tables("Productos").Rows(Registros - 1)("Precio_Unitario")
                            If Precio = 0 Then
                                Me.TrueDBGridComponentes.Columns(3).Text = Format(My.Forms.FrmConsultas.Precio, "##,##0.0000")
                            Else
                                Me.TrueDBGridComponentes.Columns(3).Text = Format(DataSet.Tables("Productos").Rows(Registros - 1)("Precio_Unitario"), "##,##0.0000")
                            End If

                        End If


                        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False



                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '////////////////////////////////BUSCO EL CODIGO PARA EL PRODUCTO///////////////////////////////////////////
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        CodigoProducto = My.Forms.FrmConsultas.Codigo
                        SQlString = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "TipoProductos")
                        If DataSet.Tables("TipoProductos").Rows.Count <> 0 Then
                            TipoProducto = DataSet.Tables("TipoProductos").Rows(0)("Tipo_Producto")
                            TipoDescuento = DataSet.Tables("TipoProductos").Rows(0)("Unidad_Medida")
                            PrecioDescCordobas = DataSet.Tables("TipoProductos").Rows(0)("Precio_Venta")
                            PrecioDescDolar = DataSet.Tables("TipoProductos").Rows(0)("Precio_Lista")
                        End If

                        '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                        Select Case TipoDescuento
                            Case "ImporteFijo"
                                Me.TrueDBGridComponentes.Columns(2).Text = 1
                                Cantidad = 1
                                Me.TrueDBGridComponentes.Columns(4).Text = ""
                                If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                    Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.0000")
                                    Precio = PrecioDescCordobas
                                Else
                                    Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.0000")
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
                                Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.0000")

                        End Select



                        Select Case TipoProducto
                            Case "Servicio"
                                SubTotal = Cantidad * Precio
                                Neto = SubTotal
                                Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.0000")
                                Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.0000")
                            Case "Descuento"
                                Neto = Math.Abs(Cantidad * Precio) * -1
                                Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.0000")
                                Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.0000")


                        End Select



                    End If
                End If

            ElseIf e.ColIndex = 8 Then

                Dim Posicion As Double
            If Me.BindingDetalle.Count <> 0 Then
                My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                Posicion = Me.BindingDetalle.Position
                My.Forms.FrmLotes.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Producto")
                My.Forms.FrmLotes.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                My.Forms.FrmLotes.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                My.Forms.FrmLotes.Fecha = Me.DTPFecha.Value
                My.Forms.FrmLotes.LblProducto.Text = Me.BindingDetalle.Item(Posicion)("Cod_Producto") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                My.Forms.FrmLotes.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
                My.Forms.FrmLotes.LblCantidad.Text = Me.BindingDetalle.Item(Posicion)("Cantidad")
                My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                My.Forms.FrmLotes.ShowDialog()

                Me.TrueDBGridComponentes.Columns(8).Text = My.Forms.FrmLotes.NumeroLote
                Me.TrueDBGridComponentes.Columns(9).Text = My.Forms.FrmLotes.FechaVence


            End If

        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            If Me.CboTipoProducto.Text <> "Orden de Compra" Then
                Me.TrueDBGridMetodo.Visible = True
            End If
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
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Cheque"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Tarjeta"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If
        End Select

        If Val(Me.TrueDBGridMetodo.Columns(1).Text) = 0 Then
            Me.TrueDBGridMetodo.Columns(1).Text = "0.00"
        End If
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
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        End If
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
                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
                End If
                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
                End If
                Me.TrueDBGridComponentes.Enabled = True

                TieneContrato = TieneContratoProveedor(Me.TxtCodigoProveedor.Text)

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

    Private Sub FrmCompras_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


        If EsSolicitud = True Then

            Me.DTPFecha.Value = Fecha_Compra
            Me.DTPFechaHora.Value = FechaHoraCompra
            Me.CboTipoProducto.Text = "Orden de Compra"
            'Me.TxtNumeroEnsamble.Text = "-----0-----"
            Me.TxtNumeroEnsamble.Text = NumeroCompra

            'EsSolicitud = False
            Bloqueo(Me, Acceso, "Orden de Compra")
        Else

            'Bloqueo(Me, Acceso, "Compras")
        End If

        'Me.DTPFecha.Value = Fecha_Compra
        'Me.DTPFechaHora.Value = FechaHoraCompra
        'Me.CboTipoProducto.Text = "Orden de Compra"
        ''Me.TxtNumeroEnsamble.Text = "-----0-----"
        'Me.TxtNumeroEnsamble.Text = NumeroCompra
        'Me.CargarCompra(Fecha_Compra, FechaHoraCompra, NumeroCompra, "Orden de Compra")
        'EsSolicitud = False
    End Sub

    Private Sub FrmCompras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Quien = ""
        LiberarCompras = False
        EsSolicitud = False
        Me.GroupBoxImportar.Visible = False
        Me.GroupBoxImportar.Location = New Point(905, 73)
    End Sub

    Private Sub FrmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

        Me.MinimumSize = Size
        Me.MaximumSize = Size

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.DTVencimiento.Value = Format(Now, "dd/MM/yyyy")
        Me.DTPFechaHora.Value = Format(Now, "dd/MM/yyyy HH:mm")

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            'FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("FacturaLotes")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataSet.Reset()
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            If EsSolicitud = False Then
                Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            End If
        End If


        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


        SqlString = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.CboProyecto.DataSource = DataSet.Tables("Proyectos")
            Me.CboProyecto.Splits.Item(0).DisplayColumns(1).Width = 350
        End If

        Me.CboReferencia.Items.Add("Produccion")
        Me.CboReferencia.Items.Add("Compras")
        Me.CboReferencia.Items.Add("Compras y Beneficios")
        Me.CboReferencia.Items.Add("Re-Empaque de Productos")
        Me.CboReferencia.Items.Add("Beneficios")
        Me.CboReferencia.Items.Add("Correcciones")
        Me.CboReferencia.Items.Add("Devoluciones")


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        dsMetodo.Reset()
        SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoCompras WHERE (Numero_Compra = '-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
        dsMetodo = New DataSet
        dsMetodo = DataSet.Copy
        Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
        MiConexion.Close()

        If EsSolicitud = False Then
            Me.TxtNumeroEnsamble.Text = "-----0-----"
        End If


        If FacturaTarea = True Then
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras WHERE (Detalle_Compras.Numero_Compra = '-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleCompra")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False

        Else

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, TasaCambio, Detalle_Compras.Numero_Compra, Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Numero_Lote, Detalle_Compras.Fecha_Vence FROM  Detalle_Compras  WHERE (Detalle_Compras.Numero_Compra = '-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleCompra")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False

        End If


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


        If EsSolicitud = False Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlString = "SELECT  * FROM DatosEmpresa "
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DatosEmpresa")
            'If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
            '    If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
            '        Me.RadioButton2.Checked = True
            '    Else
            '        Me.RadioButton2.Checked = False
            '    End If
            'End If


            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            Me.CboCodigoBodega.Text = UsuarioBodegaCompra
            Me.CboTipoProducto.Text = UsuarioTipoCompra
            Me.TxtCodigoProveedor.Text = UsuarioProveedor
        Else

            My.Application.DoEvents()
            'Me.DTPFecha.Value = Fecha_Compra
            'Me.DTPFechaHora.Value = FechaHoraCompra
            'Me.CboTipoProducto.Text = "Orden de Compra"
            ''Me.TxtNumeroEnsamble.Text = "-----0-----"
            'Me.TxtNumeroEnsamble.Text = NumeroCompra
            'Me.CargarCompra(Fecha_Compra, FechaHoraCompra, NumeroCompra, "Orden de Compra")
            'EsSolicitud = False
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
        Dim iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String, CompraBodega As Boolean = False, FacturaBodega As Boolean
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, DescripcionProducto As String


        AgregarCompras()

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
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
        '        Case "Cuenta"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '        Case "Cuenta DB"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '    End Select

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////
        '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        '    DataAdapter.Fill(DataSet, "Configuracion")
        '    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
        '            FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
        '            CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
        '        End If

        '    End If

        '    If CompraBodega = True Then
        '        NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
        '    Else
        '        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    End If
        'Else
        '    'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        '    'NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    NumeroCompra = Me.TxtNumeroEnsamble.Text

        'End If



        'ActualizaMETODOcOMPRA()

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        CambiarFechaCompra = False
        'GrabaCompras(NumeroCompra)



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'If CambiarFechaCompra = True Then
        '    Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double, idDetalle As Double

        '    Me.BindingDetalle.MoveFirst()
        '    Registros = Me.BindingDetalle.Count
        '    iPosicion = 0



        '    Do While iPosicion < Registros
        '        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
        '            DescripcionProducto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        '        End If

        '        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '        End If
        '        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")

        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
        '            NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        '        Else
        '            NumeroLote = "SINLOTE"
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
        '            FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
        '        Else
        '            FechaLote = "01/01/1900"
        '        End If


        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")) Then
        '            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")
        '        Else
        '            idDetalle = -1
        '        End If


        '        GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote, DescripcionProducto)

        '        Select Case Me.CboTipoProducto.Text
        '            Case "Mercancia Recibida"
        '                ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '        End Select

        '        CodigoProducto = 0
        '        PrecioUnitario = 0
        '        Descuento = 0
        '        PrecioNeto = 0
        '        Importe = 0
        '        Cantidad = 0

        '        iPosicion = iPosicion + 1
        '    Loop
        'ElseIf Me.CboTipoProducto.Text = "Cuenta" Then

        '    Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double, idDetalle As Double

        '    Me.BindingDetalle.MoveFirst()
        '    Registros = Me.BindingDetalle.Count
        '    iPosicion = 0



        '    Do While iPosicion < Registros
        '        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
        '            DescripcionProducto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        '        End If
        '        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '        End If
        '        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")

        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
        '            NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        '        Else
        '            NumeroLote = "SINLOTE"
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
        '            If Me.BindingDetalle.Item(iPosicion)("Fecha_Vence") = "0" Then
        '                FechaLote = "01/01/1900"
        '            Else
        '                FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
        '            End If

        '        Else
        '            FechaLote = "01/01/1900"
        '        End If


        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")) Then
        '            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")
        '        Else
        '            idDetalle = -1
        '        End If


        '        GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote, DescripcionProducto)

        '        Select Case Me.CboTipoProducto.Text
        '            Case "Mercancia Recibida"
        '                ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '        End Select

        '        CodigoProducto = 0
        '        PrecioUnitario = 0
        '        Descuento = 0
        '        PrecioNeto = 0
        '        Importe = 0
        '        Cantidad = 0

        '        iPosicion = iPosicion + 1
        '    Loop

        'ElseIf Me.CboTipoProducto.Text = "Cuenta DB" Then

        '    Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double, idDetalle As Double

        '    Me.BindingDetalle.MoveFirst()
        '    Registros = Me.BindingDetalle.Count
        '    iPosicion = 0



        '    Do While iPosicion < Registros
        '        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
        '            DescripcionProducto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        '        End If
        '        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '        End If
        '        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")

        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
        '            NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        '        Else
        '            NumeroLote = "SINLOTE"
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
        '            FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
        '        Else
        '            FechaLote = "01/01/1900"
        '        End If


        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")) Then
        '            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")
        '        Else
        '            idDetalle = -1
        '        End If


        '        GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote, DescripcionProducto)

        '        Select Case Me.CboTipoProducto.Text
        '            Case "Mercancia Recibida"
        '                ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '        End Select

        '        CodigoProducto = 0
        '        PrecioUnitario = 0
        '        Descuento = 0
        '        PrecioNeto = 0
        '        Importe = 0
        '        Cantidad = 0

        '        iPosicion = iPosicion + 1
        '    Loop


        'End If

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

        '    GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
        '    iPosicion = iPosicion + 1
        'Loop
        'Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Grabar la Compra: " & Me.TxtNumeroEnsamble.Text)

        'MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")

        'If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Orden de Compra"
        '            Me.CmdFacturar.Enabled = True
        '        Case Else
        '            LimpiarCompras()
        '    End Select
        'End If

        'Me.Button7.Enabled = True
        'Me.CboCodigoBodega.Enabled = True



    End Sub

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged

        Me.ChkAplicarCtasXPagar.Visible = False
        Me.ChkAplicarCtasXPagar.Checked = False
        Me.ChkSolcitudxCta.Visible = True

        If Me.CboTipoProducto.Text <> "" Then
            Me.TrueDBGridComponentes.Enabled = True
        End If

        If Me.CboTipoProducto.Text = "Cuenta" Then
            Me.GroupBox3.Enabled = True
            Me.RadioButton1.Checked = True
            Me.ChkAplicarCtasXPagar.Visible = False

        End If

        If Me.CboTipoProducto.Text = "Devolucion de Compra" Then
            Me.GroupBox3.Enabled = False
            Me.RadioButton1.Checked = True
            Me.ChkAplicarCtasXPagar.Visible = True
        End If

        If Me.CboTipoProducto.Text = "Orden de Compra" Then
            Me.GroupBox3.Enabled = True
            'Else
            '    Me.GroupBox3.Enabled = False
            '    Me.RadioButton1.Checked = True
        End If

        If Me.CboTipoProducto.Text = "Mercancia Recibida" Then
            Me.GroupBox3.Enabled = True
            'Else
            '    Me.GroupBox3.Enabled = False
            '    Me.RadioButton1.Checked = True
        End If

        If Me.CboTipoProducto.Text = "Transferencia Recibida" Then
            Me.CmdTransferencias.Visible = True
            Me.GroupBox2.Text = "Datos del Bodeguero"


        Else
            Me.CmdTransferencias.Visible = False
            Me.GroupBox2.Text = "Informacion del Proveedor"

        End If



        If CboTipoProducto.Text = "Cuenta" Then

            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 350
            Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = False
            Me.TrueDBGridComponentes.Columns(3).Caption = "Monto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
            Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False
            Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False

        ElseIf CboTipoProducto.Text = "Cuenta DB" Then

            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 350
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = False
            Me.TrueDBGridComponentes.Columns(3).Caption = "Monto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
            Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False
            Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False

        ElseIf FacturaTarea = True Then
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = True
            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = True
            Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = True
            Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = True
            Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = True

        ElseIf Me.CboTipoProducto.Text = "Orden de Compra" Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.ChkSolcitudxCta.Visible = True
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = True
            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = True
            Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = True
            Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = True
            Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False


        Else

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = True
            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = True
            Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = True
            Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = True
            Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False


        End If


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Compras"
        My.Forms.FrmConsultas.TipoCompra = Me.CboTipoProducto.Text
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.DTPFechaHora.Value = My.Forms.FrmConsultas.FechaHora
            Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
            Me.CboCodigoBodega.Enabled = False
            Me.Button7.Enabled = False

            If PermiteEditar(Acceso, "Compras") = False Then
                Me.ButtonAgregar.Enabled = False
                'Me.TrueDBGridComponentes.Enabled = False
            Else
                Me.ButtonAgregar.Enabled = True
                Me.TrueDBGridComponentes.Enabled = True

            End If
        End If
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoCompra As String, Exonerado As Boolean
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, CodigoProyecto As String
        Dim AplicaCtasXPagar As Boolean = False, SolicitudCta As Boolean = False


        If Quien = "NumeroCompras" Then
            Exit Sub
        ElseIf Quien = "MetodoPago" Then
            Exit Sub
        End If

        Try



            If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
                PrimerRegistroCompra = False
                TipoCompra = Me.CboTipoProducto.Text
                Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
                SqlCompras = "SELECT  * FROM Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & TipoCompra & "')  AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "Compras")
                If Not DataSet.Tables("Compras").Rows.Count = 0 Then
                    '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Su_Referencia")) Then
                        Me.TxtReferencia.Text = DataSet.Tables("Compras").Rows(0)("Su_Referencia")
                    End If
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("AplicarCtasXPagar")) Then
                        AplicaCtasXPagar = DataSet.Tables("Compras").Rows(0)("AplicarCtasXPagar")
                    End If
                    Me.ChkAplicarCtasXPagar.Checked = AplicaCtasXPagar

                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Solcitud_Cta_Contable")) Then
                        SolicitudCta = DataSet.Tables("Compras").Rows(0)("Solcitud_Cta_Contable")
                    End If

                    Me.ChkSolcitudxCta.Checked = SolicitudCta

                    Me.TxtCodigoProveedor.Text = DataSet.Tables("Compras").Rows(0)("Cod_Proveedor")
                    Me.TxtNombres.Text = DataSet.Tables("Compras").Rows(0)("Nombre_Proveedor")
                    Me.TxtApellidos.Text = DataSet.Tables("Compras").Rows(0)("Apellido_Proveedor")
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Direccion_Proveedor")) Then
                        Me.TxtDireccion.Text = DataSet.Tables("Compras").Rows(0)("Direccion_Proveedor")
                    End If
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Telefono_Proveedor")) Then
                        Me.TxtTelefono.Text = DataSet.Tables("Compras").Rows(0)("Telefono_Proveedor")
                    End If

                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Exonerado")) Then
                        Exonerado = DataSet.Tables("Compras").Rows(0)("Exonerado")
                    End If

                    If Exonerado = True Then
                        Me.OptExsonerado.Checked = True
                    Else
                        Me.OptExsonerado.Checked = False
                    End If

                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("CodigoProyecto")) Then
                        CodigoProyecto = DataSet.Tables("Compras").Rows(0)("CodigoProyecto")

                        SqlCompras = "SELECT * FROM Proyectos WHERE  (CodigoProyectos = '" & CodigoProyecto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaProyecto")
                        If Not DataSet.Tables("ConsultaProyecto").Rows.Count = 0 Then
                            Me.CboProyecto.Text = DataSet.Tables("ConsultaProyecto").Rows(0)("NombreProyectos")
                        Else
                            Me.CboProyecto.Text = ""
                        End If
                        DataSet.Tables("ConsultaProyecto").Reset()

                    Else
                        Me.CboProyecto.Text = ""
                    End If



                    '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////
                    Me.DTVencimiento.Value = DataSet.Tables("Compras").Rows(0)("Fecha_Vencimiento")
                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Observaciones")) Then
                        Me.TxtObservaciones.Text = DataSet.Tables("Compras").Rows(0)("Observaciones")
                    End If
                    Me.TxtSubTotal.Text = Format(DataSet.Tables("Compras").Rows(0)("SubTotal"), "##,##0.00")
                    Me.TxtIva.Text = Format(DataSet.Tables("Compras").Rows(0)("IVA"), "##,##0.00")
                    Me.TxtPagado.Text = Format(DataSet.Tables("Compras").Rows(0)("Pagado"), "##,##0.00")
                    Me.TxtNetoPagar.Text = Format(DataSet.Tables("Compras").Rows(0)("NetoPagar"), "##,##0.00")
                    Me.CboCodigoBodega.Text = DataSet.Tables("Compras").Rows(0)("Cod_Bodega")
                    Me.TxtMonedaFactura.Text = DataSet.Tables("Compras").Rows(0)("MonedaCompra")

                    If Not IsDBNull(DataSet.Tables("Compras").Rows(0)("Referencia")) Then
                        If DataSet.Tables("Compras").Rows(0)("Referencia") <> "" Then
                            Me.CboReferencia.Text = DataSet.Tables("Compras").Rows(0)("Referencia")
                        End If
                    End If


                    If FacturaTarea = True Then
                        ds.Reset()
                        'ds.Tables("DetalleCompra").Reset()
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlCompras = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
                                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                        'DataAdapter.Fill(DataSet, "DetalleCompra")
                        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
                        ds = New DataSet
                        da = New SqlDataAdapter(SqlCompras, MiConexion)
                        CmdBuilder = New SqlCommandBuilder(da)
                        da.Fill(ds, "DetalleCompra")
                        Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Compra").Visible = False

                    ElseIf CboTipoProducto.Text = "Cuenta" Then
                        ds.Reset()
                        'ds.Tables("DetalleCompra").Reset()
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlCompras = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
                                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                        'DataAdapter.Fill(DataSet, "DetalleCompra")
                        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompra")
                        ds = New DataSet
                        da = New SqlDataAdapter(SqlCompras, MiConexion)
                        CmdBuilder = New SqlCommandBuilder(da)
                        da.Fill(ds, "DetalleCompra")
                        Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle


                        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 350
                        Me.TrueDBGridComponentes.Columns(2).Caption = "Ordenado"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = False
                        Me.TrueDBGridComponentes.Columns(3).Caption = "Monto"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                        Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
                        Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False
                        Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Button = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False


                    Else
                        ds.Reset()
                        'ds.Tables("DetalleCompra").Reset()
                        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                        SqlCompras = "SELECT Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence FROM  Detalle_Compras " &
                                     "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                        'DataAdapter.Fill(DataSet, "DetalleCompras")
                        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleCompras")
                        ds = New DataSet
                        da = New SqlDataAdapter(SqlCompras, MiConexion)
                        CmdBuilder = New SqlCommandBuilder(da)
                        da.Fill(ds, "DetalleCompra")
                        Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
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
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False

                    End If

                    dsMetodo.Reset()
                    '//////////////////////////////////////BUSCO LOS METODOS DE PAGOS///////////////////////////////////////////////////////////////////////////////////
                    SqlCompras = "SELECT  NombrePago, Monto, NumeroTarjeta, FechaVence  FROM Detalle_MetodoCompras " &
                                 "WHERE (Detalle_MetodoCompras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_MetodoCompras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_MetodoCompras.Tipo_Compra = '" & TipoCompra & "') "
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")
                    dsMetodo = New DataSet
                    dsMetodo = DataSet.Copy
                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

                    If DataSet.Tables("MetodoPago").Rows.Count = 0 Then
                        Me.RadioButton1.Checked = True
                    Else
                        Me.RadioButton2.Checked = True
                    End If


                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////ESTA OPCION NO PERMITE AGREGAR PRODUCTOS /////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    If Me.CboTipoProducto.Text = "Orden de Compra" Then
                        Me.TrueDBGridComponentes.AllowUpdate = True
                        Me.TrueDBGridComponentes.AllowAddNew = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                    ElseIf LiberarCompras = True Then
                        Me.TrueDBGridComponentes.AllowUpdate = True
                        Me.TrueDBGridComponentes.AllowAddNew = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True

                    Else

                        'Me.TrueDBGridComponentes.AllowUpdate = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Compra").Visible = True
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TasaCambio").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Compra").Visible = False
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = False
                    End If


                    ActualizaMETODOcOMPRA()

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
        Me.ButtonAgregar.Enabled = True
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
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Compra?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " &
                     "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        EjecutarConsulta(SqlCompras)

        SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " &
                             "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "') "
        EjecutarConsulta(SqlCompras)


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Dim Idetalle As Double = 0, CodigoProducto As String = "", DiferenciaCantidad As Double = 0
        SQlProductos = "SELECT * FROM Detalle_Compras WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        MiConexion.Close()
        IposicionFila = 0
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            Do While IposicionFila < (DataSet.Tables("Detalle").Rows.Count)

                Idetalle = DataSet.Tables("Detalle").Rows(IposicionFila)("id_Detalle_Compra")
                CodigoProducto = DataSet.Tables("Detalle").Rows(IposicionFila)("Cod_Producto")
                DiferenciaCantidad = DataSet.Tables("Detalle").Rows(IposicionFila)("Cantidad") * -1

                ExistenciasCostos(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                CostoBodega(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)


                'SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                '             "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "') AND (id_Detalle_Compra = " & Idetalle & ")"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

                '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
                '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////

                ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)

                '////////////////////////////////////////////ACTUALIZO LA EXISTENCIA DE LA BODEGA////////////////////////////////////////////////////////
                SqlCompras = "UPDATE [DetalleBodegas] SET [Existencia] = " & ExistenciaBodega & " " &
                            "WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodigoProducto & "') "
                EjecutarConsulta(SqlCompras)

                IposicionFila = IposicionFila + 1
            Loop




        End If

        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Eliminar la Compra: " & Me.TxtNumeroEnsamble.Text)

        LimpiarCompras()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepCompras As New ArepCompras, SqlDatos As String, SQlDetalle As String = "", Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaCambio As Double
        Dim NumeroCompra As String, MonedaFactura As String = Me.TxtMonedaFactura.Text, MonedaImprime As String = Me.TxtMonedaImprime.Text
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim TipoImpresion As String, SqlString As String, Ancho As Double, Largo As Double

        'ConsecutivoCompra As Double


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

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                ArepCompras.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepCompras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If



        ArepCompras.LblReferencia.Text = Me.TxtReferencia.Text
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



        If Me.CboCodigoBodega.Columns(0).Text <> "Nothing" Then
            ArepCompras.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        End If

        'ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
        'ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
        'ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
        'ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
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

        If Me.CboTipoProducto.Text = "Orden de Compra" Then
            If Me.RadioButton2.Checked = True Then
                ArepCompras.TxtMetodo.Text = "Contado"
            Else
                ArepCompras.TxtMetodo.Text = "Credito"
            End If
        End If

        TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)

        'If MonedaImprime = "" Then
        '    MonedaImprime = "Cordobas"
        'End If

        If MonedaFactura = "Cordobas" Then
            If MonedaImprime = "Cordobas" Then
                '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe, Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " &
                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"

                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
            ElseIf MonedaImprime = "Dolares" Then
                SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Compras.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Compras.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Compras.Importe * (1 / TasaCambio.MontoTasa) AS Importe, Productos.Unidad_Medida FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " &
                             "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) / TasaCambio, "##,##0.00")
            End If
        ElseIf MonedaFactura = "Dolares" Then
            If MonedaImprime = "Dolares" Then
                '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe, Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " &
                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
            ElseIf MonedaImprime = "Cordobas" Then
                SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Compras.Descuento *  TasaCambio.MontoTasa AS Descuento, Detalle_Compras.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Compras.Importe * TasaCambio.MontoTasa AS Importe, Productos.Unidad_Medida FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " &
                            "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")

            End If
        End If


        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Imprimir la Compra: " & Me.TxtNumeroEnsamble.Text)


        TipoImpresion = "Compra"
        SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Coordenadas")
        Ancho = DataSet.Tables("Coordenadas").Rows(0)("Ancho")
        Largo = DataSet.Tables("Coordenadas").Rows(0)("Largo")


        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        'SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
        '    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
        SQL.ConnectionString = Conexion
        SQL.SQL = SQlDetalle
        ArepCompras.DataSource = SQL
        ArepCompras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
        'ArepCompras.PageSettings.PaperWidth = Str(Ancho)
        'ArepCompras.PageSettings.PaperHeight = Largo
        'ArepCompras.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
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

                    'SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False' " & _
                    '             "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                    'MiConexion.Open()
                    'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    'iResultado = ComandoUpdate.ExecuteNonQuery
                    'MiConexion.Close()
                    LimpiarCompras()
            End Select
        End If


        If PermiteEditar(Acceso, Me.CboTipoProducto.Text) = True Then

            AgregarCompras()

            '26/08/2025
            ''////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
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
            '        Case "Cuenta"
            '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
            '            ConsecutivoCompra = BuscaConsecutivo("Compra")
            '        Case "Cuenta DB"
            '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
            '            ConsecutivoCompra = BuscaConsecutivo("Compra")

            '    End Select

            '    '/////////////////////////////////////////////////////////////////////////////////////////
            '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
            '    '////////////////////////////////////////////////////////////////////////////////////////
            '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
            '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
            '    DataAdapter.Fill(DataSet, "Configuracion")
            '    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
            '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
            '            FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) = True Then
            '            CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
            '        End If

            '    End If

            '    If CompraBodega = True Then
            '        NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
            '    Else
            '        NumeroCompra = Format(ConsecutivoCompra, "0000#")
            '    End If
            'Else
            '    'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            '    'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            '    NumeroCompra = Me.TxtNumeroEnsamble.Text

            'End If





            '26/08/2025
            '    '////////////////////////////////////////////////////////////////////////////////////////////////////
            '    '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            '    GrabaCompras(NumeroCompra)

            '    '////////////////////////////////////////////////////////////////////////////////////////////////////
            '    '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            '    Me.BindingMetodo.MoveFirst()
            '    Registros = Me.BindingMetodo.Count
            '    iPosicion = 0
            '    Monto = 0
            '    Do While iPosicion < Registros
            '        NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
            '        Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
            '        If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
            '            NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
            '        Else
            '            NumeroTarjeta = 0
            '        End If
            '        If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
            '            FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
            '        Else
            '            FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
            '        End If

            '        GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
            '        iPosicion = iPosicion + 1
            '    Loop


        End If





    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CuentasPagarCompras"
        My.Forms.FrmConsultas.ShowDialog()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub


    Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
        Dim ConsecutivoCompra As Double, iPosicion As Double, Registros As Double, NumeroCompra As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim TipoCompra As String = "Mercancia Recibida", Numero As String, Fecha As String
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, CodigoProyecto As String
        Dim Fecha_Vence As Date, Fecha_Hora As Date, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, Cuenta() As String, CodigoProveedor As String

        Me.CmdFacturar.Enabled = True

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Fecha_Compra = Format(Now, "dd/MM/yyyy")
        Fecha_Vence = Format(Now, "dd/MM/yyyy")
        Fecha_Hora = Now

        'My.Forms.FrmFecha.ShowDialog()
        My.Forms.FrmFechaxProveedor.TxtCodigoProveedor.Text = Me.TxtCodigoProveedor.Text
        My.Forms.FrmFechaxProveedor.ShowDialog()
        Fecha_Compra = Format(My.Forms.FrmFechaxProveedor.DTPFechaRequerido.Value, "dd/MM/yyyy")
        CodigoProveedor = My.Forms.FrmFechaxProveedor.Codigo_Proveedor
        Me.DTPFecha.Value = Fecha_Compra

        If Quien = "Cancelar" Then
            Exit Sub
        End If

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
        If Not Me.CboProyecto.Text = "" Then
            CodigoProyecto = Me.CboProyecto.Columns(0).Text
        End If




        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        If Me.ChkSolcitudxCta.Checked = False Then
            GrabaEncabezadoCompras(NumeroCompra, Fecha_Compra, "Mercancia Recibida", CodigoProveedor, Me.CboCodigoBodega.Text, Me.TxtNombres.Text, Me.TxtApellidos.Text, Fecha_Compra, Val(Me.TxtSubTotal.Text), Val(Me.TxtIva.Text), Val(Me.TxtPagado.Text), Val(Me.TxtNetoPagar.Text), Me.TxtMonedaFactura.Text, "Procesado por la Orden de Compra " & Me.TxtNumeroEnsamble.Text, CodigoProyecto, Me.ChkSolcitudxCta.Checked)
        Else
            GrabaEncabezadoCompras(NumeroCompra, Fecha_Compra, "Cuenta", CodigoProveedor, Me.CboCodigoBodega.Text, Me.TxtNombres.Text, Me.TxtApellidos.Text, Fecha_Compra, Val(Me.TxtSubTotal.Text), Val(Me.TxtIva.Text), Val(Me.TxtPagado.Text), Val(Me.TxtNetoPagar.Text), Me.TxtMonedaFactura.Text, "Procesado por la Orden de Compra " & Me.TxtNumeroEnsamble.Text, CodigoProyecto, Me.ChkSolcitudxCta.Checked)
        End If
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0

        Do While iPosicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            End If
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")

            '///////////////////////////////////////SI ES DE TIPO CUENTA BUSCO LAS CUENTAS CONTABLES ////////////////////////
            If Me.ChkSolcitudxCta.Checked = True Then

                '///////////////////////////////CONSULTO EL PRODUCTO ////////////////////////////////////////////////////
                Cuenta = Split(CuentaGastosProducto(CodigoProducto), ",")
                If Cuenta(0) <> "" And Cuenta(1) <> "" Then
                    GrabaDetalleCompraCuenta(NumeroCompra, Cuenta(0), Cuenta(1), PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, "0000", "01/01/1900", CodigoProducto, Fecha_Compra, Me.TxtMonedaFactura.Text, "Cuenta")
                End If
            Else
                GrabaDetalleCompraLiquidacion(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, Me.TxtMonedaFactura.Text, Fecha_Compra, "0000", "01/01/1900")
            End If




            'ExistenciasCostos(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", Me.CboCodigoBodega.Text)
            If Me.ChkSolcitudxCta.Checked = False Then
                Select Case TipoCompra
                    Case "Mercancia Recibida"
                        ExistenciasCostos(CodigoProducto, Cantidad, PrecioNeto, TipoCompra, Me.CboCodigoBodega.Text)
                        CostoBodega(CodigoProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Fecha_Compra)

                End Select
            End If

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


        Numero = Me.TxtNumeroEnsamble.Text
        Fecha = Format(CDate(Me.DTPFecha.Value), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA ORDEN DE COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Estatus]= 'Comprado' " &
                     "WHERE  (Numero_Compra = '" & Numero & "')  AND  (Tipo_Compra = 'Orden de Compra')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()



        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA MERCANCIA RECIBIDA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        'Numero = NumeroCompra
        Fecha = Format(CDate(Me.DTPFecha.Value), "yyyy-MM-dd")
        SqlCompras = "UPDATE [Compras]  SET [Numero_Orden] = '" & Numero & "' " &
                     "WHERE  (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Mercancia Recibida')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()



        MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
        LimpiarCompras()
        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
        Me.CmdFacturar.Enabled = False

    End Sub
    Private Sub OptExsonerado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptExsonerado.CheckedChanged
        ActualizaMETODOcOMPRA()
    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        Dim Cont As Double = Me.TrueDBGridConsultas.RowCount, i As Double, NumeroCompra As String
        Dim Compra As TablaDetalleCompras = New TablaDetalleCompras, ConsecutivoCompra As Double = 0
        Dim Encabezado As TablaCompras = New TablaCompras

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione el Tipo Compra", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        ConsecutivoCompra = BuscaConsecutivo("Compra")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")

        Encabezado.Numero_Compra = NumeroCompra
        Encabezado.Tipo_Compra = Me.CboTipoProducto.Text
        Encabezado.Cod_Proveedor = Me.CboCodigoBodega.Text
        Encabezado.Nombre_Proveedor = Me.TxtNombres.Text
        Encabezado.Apellido_Proveedor = Me.TxtApellidos.Text
        Encabezado.Cod_Bodega = Me.CboCodigoBodega.Text
        Encabezado.Fecha_Compra = Me.DTPFecha.Value
        Encabezado.Sub_Total = Val(Me.TxtSubTotal.Text)
        Encabezado.IVA = Val(Me.TxtIva.Text)
        Encabezado.Neto_Pagar = Encabezado.Sub_Total + Encabezado.IVA
        Encabezado.Monto_Credito = Encabezado.Neto_Pagar
        Encabezado.Pagado_Compra = 0
        Encabezado.Moneda_Compra = Me.TxtMonedaFactura.Text
        Encabezado.Fecha_Vencimiento = Me.DTVencimiento.Value



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7v
        GrabaEncabezadoCompras(NumeroCompra, Encabezado.Fecha_Compra, Encabezado.Tipo_Compra, Encabezado.Cod_Proveedor, Encabezado.Cod_Bodega, Encabezado.Nombre_Proveedor, Encabezado.Apellido_Proveedor, Encabezado.Fecha_Vencimiento, Encabezado.Sub_Total, Encabezado.IVA, Encabezado.Pagado_Compra, Encabezado.Neto_Pagar, Encabezado.Moneda_Compra, "Procesado por Importacion Compra " & Encabezado.Numero_Compra, "", False)


        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Cont
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = True
        Do While Cont > i
            Compra.Numero_Compra = NumeroCompra
            Compra.Cod_Producto = Me.TrueDBGridConsultas.Item(i)("Cod_Producto")
            Compra.Descripcion_Producto = Me.TrueDBGridConsultas.Item(i)("Descripcion_Producto")
            Compra.Cantidad = Me.TrueDBGridConsultas.Item(i)("Cantidad")
            Compra.Precio_Unitario = Me.TrueDBGridConsultas.Item(i)("Precio_Unitario")
            Compra.Precio_Neto = Me.TrueDBGridConsultas.Item(i)("Precio_Neto")
            Compra.Importe = Me.TrueDBGridConsultas.Item(i)("Importe")
            Compra.Numero_Lote = Me.TrueDBGridConsultas.Item(i)("Numero_Lote")
            Compra.Fecha_Vence = Me.TrueDBGridConsultas.Item(i)("Fecha_Vence")
            Compra.Cod_Bodega = Me.CboCodigoBodega.Text
            Compra.Tipo_Compra = "Mercancia Recibida"


            GrabaDetalleCompraLiquidacion(Compra.Numero_Compra, Compra.Cod_Producto, Compra.Precio_Unitario, 0, Compra.Precio_Neto, Compra.Importe, Compra.Cantidad, Me.TxtMonedaFactura.Text, Me.DTPFecha.Value, Compra.Numero_Lote, Compra.Fecha_Vence)

            '///////////////////////////EXISTENCIA COSTO LA PROCESO EN SEGUNDO PLANO ///////////
            '//////////////////////////PROCESO MUY LARGO ///////////////////////
            Dim worker As BackgroundWorker
            worker = New BackgroundWorker()
            AddHandler worker.DoWork, AddressOf backgroundWorkerExistenciaCosto_DoWork
            AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerExistenciaCosto_RunWorkerCompleted
            worker.RunWorkerAsync(Compra)




            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            i = i + 1
        Loop


        '/////////////////////////////////////AHORA CARGO LAS COMPRAS ///////////
        Me.CboTipoProducto.Text = Encabezado.Tipo_Compra
        Me.DTPFecha.Value = Encabezado.Fecha_Compra
        Me.TxtNumeroEnsamble.Text = Encabezado.Numero_Compra

        Button14_Click(sender, e)


    End Sub

    Private Sub BtnQuitar_Click(sender As Object, e As EventArgs) Handles BtnQuitar.Click
        Dim Cont As Double
        Me.TrueDBGridConsultas.Delete()
        Cont = Me.TrueDBGridConsultas.RowCount
        Me.LblTotalRegistros.Text = "Total Registros: " & Cont
    End Sub

    Private Sub TrueDBGridConsultas_Click(sender As Object, e As EventArgs) Handles TrueDBGridConsultas.Click

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String

        LimpiarGridImporacion()

        Me.GroupBoxImportar.Visible = False
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione el Tipo Compra", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtCodigoProveedor.Text = "" Then
            MsgBox("Seleccione el Proveedor", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.CboCodigoBodega.Text = "" Then
            MsgBox("Es necesario que seleccione la  Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        LimpiarGridImporacion()

        Me.GroupBoxImportar.Location = New Point(3, 66)
        Me.GroupBoxImportar.Visible = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles BtnAbrir.Click
        Dim Cont As Double, i As Double, oDataRow As DataRow, Registros As Double = 0
        Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.DataAdapterExcel)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String
        Dim Compras As TablaDetalleCompras = New TablaDetalleCompras, Agregar As Boolean = True
        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        DataSet.Reset()
        SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Precio_Unitario, Importe, Numero_Lote, Fecha_Compra As Fecha_Vence, Precio_Neto FROM Detalle_Compras WHERE (Numero_Compra = N'-10000') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleCompra")

        MiDataSet.Reset()

        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        'ConexionExcel = "DRIVER=Microsoft Excel Driver (*.xls);" & "DBQ=" & RutaBD
        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 4.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)

        MiConexionExcel.Open()
        DataAdapterExcel.Fill(MiDataSet, "DatosExcel")
        Cont = MiDataSet.Tables("DatosExcel").Rows.Count
        i = 0

        Do While Cont > i
            Agregar = True

            If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(i)("CodigoProducto")) Then

                Compras.Cod_Producto = MiDataSet.Tables("DatosExcel").Rows(i)("CodigoProducto")
                '/////////////////CONSULTO SI EL PRODUCTO EXISTE ////////////
                SqlString = "SELECT Productos.* FROM Productos WHERE (Cod_Productos = '" & Compras.Cod_Producto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "ConsultaProducto")
                'DataSet = FillConsultaSQL(SqlString, "ConsultaProducto").Copy
                If DataSet.Tables("ConsultaProducto").Rows.Count <> 0 Then
                    Compras.Descripcion_Producto = DataSet.Tables("ConsultaProducto").Rows(0)("Descripcion_Producto")
                    If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(i)("Cantidad")) Then
                        Compras.Cantidad = MiDataSet.Tables("DatosExcel").Rows(i)("Cantidad")
                    Else
                        Compras.Cantidad = 0
                    End If
                    If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(i)("PrecioUnitario")) Then
                        Compras.Precio_Unitario = MiDataSet.Tables("DatosExcel").Rows(i)("PrecioUnitario")
                        Compras.Precio_Neto = MiDataSet.Tables("DatosExcel").Rows(i)("PrecioUnitario")
                    Else
                        Compras.Precio_Unitario = 0
                        Compras.Precio_Neto = 0
                    End If

                    DataSet.Tables("ConsultaProducto").Reset()

                    Compras.Importe = Compras.Cantidad * Compras.Precio_Unitario

                    If Not IsDBNull(MiDataSet.Tables("DatosExcel").Rows(i)("NumeroLote")) Then
                        Compras.Numero_Lote = MiDataSet.Tables("DatosExcel").Rows(i)("NumeroLote")

                        '//////////////////////CONSULTO EL NUMERO DE LOTE /////////////
                        SqlString = "SELECT Numero_Lote, Nombre_Lote, FechaVence, Activo, Existencia FROM Lote WHERE (Numero_Lote = '" & Compras.Numero_Lote & "') "
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaLote")
                        'DataSet = FillConsultaSQL(SqlString, "ConsultaLote").Copy
                        If DataSet.Tables("ConsultaLote").Rows.Count <> 0 Then
                            '/////////////////////VERIFICO SI EL LOTE ESTA ACTIVO 
                            If DataSet.Tables("ConsultaLote").Rows(0)("Activo") = True Then
                                If Not IsDBNull(DataSet.Tables("ConsultaLote").Rows(0)("FechaVence")) Then
                                    Agregar = True
                                    Compras.Fecha_Vence = DataSet.Tables("ConsultaLote").Rows(0)("FechaVence")
                                Else
                                    Compras.Fecha_Vence = "01/01/1900"
                                End If
                            Else
                                Agregar = False
                                TxtError.Text = Me.TxtError.Text & " El Lote: " & Compras.Numero_Lote & " Esta Inactivo"
                            End If


                        Else
                            Agregar = True
                            Compras.Numero_Lote = "SINLOTE"
                            Compras.Fecha_Vence = "01/01/1900"
                        End If

                        DataSet.Tables("ConsultaLote").Reset()
                    Else
                        Compras.Numero_Lote = "SINLOTE"
                        Compras.Fecha_Vence = "01/01/1900"

                    End If


                Else
                    Agregar = False
                    Me.TxtError.Text = Me.TxtError.Text & " El Codigo Producto no Existe :" & Compras.Cod_Producto
                End If


            Else
                Agregar = False
                Me.TxtError.Text = Me.TxtError.Text & " Codigo Producto Nulo, Registro: " & i

            End If

            '///////////SI Cumple con los valores lo agrego 
            If Agregar = True Then
                Registros = Registros + 1
                oDataRow = DataSet.Tables("DetalleCompra").NewRow
                oDataRow("Cod_Producto") = Compras.Cod_Producto
                oDataRow("Descripcion_Producto") = Compras.Descripcion_Producto
                oDataRow("Cantidad") = Compras.Cantidad
                oDataRow("Precio_Unitario") = Compras.Precio_Unitario
                oDataRow("Precio_Neto") = Compras.Precio_Neto
                oDataRow("Importe") = Compras.Importe
                oDataRow("Numero_Lote") = Compras.Numero_Lote
                oDataRow("Fecha_Vence") = Compras.Fecha_Vence
                DataSet.Tables("DetalleCompra").Rows.Add(oDataRow)
            End If




            i = i + 1
        Loop


        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("DetalleCompra")

        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 75
        Me.TrueDBGridConsultas.Columns("Cod_Producto").Caption = "CodProducto"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 180
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
        Me.TrueDBGridConsultas.Columns("Cantidad").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 75
        Me.TrueDBGridConsultas.Columns("Precio_Unitario").Caption = "PrecioUnitario"
        Me.TrueDBGridConsultas.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 75
        Me.TrueDBGridConsultas.Columns("Precio_Neto").Caption = "Precio_Neto"
        Me.TrueDBGridConsultas.Columns("Precio_Neto").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Importe").Width = 75
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Importe").Locked = True
        Me.TrueDBGridConsultas.Columns("Importe").NumberFormat = "##,##0.00"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Lote").Width = 70
        Me.TrueDBGridConsultas.Columns("Numero_Lote").Caption = "Numero Lote"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Fecha_Vence").Width = 75
        Me.TrueDBGridConsultas.Columns("Fecha_Vence").Caption = "FechaVence"



        Me.LblTotalRegistros.Text = "Total Registros: " & DataSet.Tables("DetalleCompra").Rows.Count
        MiConexionExcel.Close()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim SqlString As String, idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, DiferenciaCantidad As Double, DiferenciaPrecio As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, NumeroCompra As String, ConsecutivoCompra As Double
        Dim oDataRow As DataRow, oTablaBorrados As DataTable

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        FechaFactura = Format(Me.DTPFecha.Value, "yyyy-MM-dd")



        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        iPosicion = Me.BindingDetalle.Position

        'If TieneMovimientos(Me.BindingDetalle.Item(iPosicion)("Cod_Productos"), Me.DTPFechaHora.Value) = True Then
        '    MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
        '    Exit Sub
        'End If

        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")) Then
            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Compra")
        Else
            idDetalle = -1
        End If
        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        End If
        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        NombreProducto = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

        'Me.BindingDetalle.RemoveCurrent()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA FACTURA///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT * FROM Detalle_Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (id_Detalle_Compra = '" & idDetalle & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            'MiConexion.Close()
            'StrSqlUpdate = " DELETE FROM Detalle_Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (id_Detalle_Compra = '" & idDetalle & "')"
            'MiConexion.Open()
            'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            'iResultado = ComandoUpdate.ExecuteNonQuery
            'MiConexion.Close()


            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            oDataRow = ds.Tables("DetalleCompra").Rows(iPosicion)
            oDataRow.Delete()

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
            oTablaBorrados = ds.Tables("DetalleCompra").GetChanges(DataRowState.Deleted)
            If Not IsNothing(oTablaBorrados) Then
                '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                da.Update(oTablaBorrados)
            End If
            ds.Tables("DetalleCompra").AcceptChanges()
            da.Update(ds.Tables("DetalleCompra"))



            Select Case Me.CboTipoProducto.Text
                Case "Mercancia Recibida"
                    DiferenciaCantidad = CDbl(CantidadAnterior) - CDbl(Cantidad)
                    DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
                    ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    CostoBodega(CodProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
                Case "Devolucion de Compra"
                    DiferenciaCantidad = CDbl(CantidadAnterior) - CDbl(Cantidad)
                    DiferenciaPrecio = CDbl(CantidadAnterior) - CDbl(Cantidad)
                    ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    CostoBodega(CodProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
            End Select
        End If

        ActualizaMETODOcOMPRA()

        '25/08/2025
        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
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
        '        Case "Cuenta"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '        Case "Cuenta DB"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '    End Select
        'Else
        '    ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        'End If

        ''///////////////////////////////////////////////////////GRABO LOS CAMBIOS EN LA COMPRA /////////////////////////////////////////////
        'NumeroCompra = Format(ConsecutivoCompra, "0000#")

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaCompras(NumeroCompra)

        AgregarCompras()

        ReDim CodigoProducto(1)
        CodigoProducto(0) = CodProducto
        Bitacora(Now, NombreUsuario, "Compras", "Elimino Producto: " & CodProducto & " Compra No." & Me.TxtNumeroEnsamble.Text)
        'My.Forms.FrmAjustarCostos.Registros = 1
        'My.Forms.FrmAjustarCostos.ShowDialog()
        My.Application.DoEvents()


    End Sub


    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim PrecioUnitario As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String
        Dim CodProducto As String, CodImpuesto As String
        Dim TipoProducto As String = "Productos", TipoDescuento As String = "ImporteFijo"
        Dim PrecioDescDolar As Double, PrecioDescCordobas As Double, SubTotal As Double, Cantidad As Double, Precio As Double, PorcientoDescuento As Double
        Dim Descuento As Double, Neto As Double
        Dim CodigoProducto As String, PrecioNeto As Double, Importe As Double
        Dim NumeroCompra As String, ConsecutivoCompra As Double, Registros As Double, iPosicion As Double
        Dim CostoActual As Double = 0, CostoAnterior As Double = 0
        Dim SqlConsecutivo As String, FacturaBodega As Boolean = False, CompraBodega As Boolean = False

        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////SI EL PRECIO ES CERO LA CANTIDAD LA HAGO CERO /////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////


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


        If TipoProducto <> "Descuento" And TipoProducto <> "Servicio" Then
            If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                PrecioUnitario = Me.TrueDBGridComponentes.Columns(3).Text
            Else
                PrecioUnitario = 0
                Me.TrueDBGridComponentes.Columns(3).Text = 0
            End If

            If PrecioUnitario = 0 Then
                Me.TrueDBGridComponentes.Columns(3).Text = 0
            End If
        Else
            '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
            Select Case TipoDescuento
                Case "ImporteFijo"
                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                    Cantidad = 1
                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.0000")
                        Precio = PrecioDescCordobas
                    Else
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.0000")
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
                    Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.0000")

                Case "Unidades/Fracciones"
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If
                    If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                        Precio = Me.TrueDBGridComponentes.Columns(3).Text
                    End If


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


            Me.TrueDBGridComponentes.Columns(5).Text = Format(Precio * (1 - Descuento), "##,##0.0000")
            Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.0000")

        End If


        If PermiteEditar(Acceso, Me.CboTipoProducto.Text) = True Then


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

                AgregarEncabezado()

                '//////////////COMENTARIO 29/08/2025
                'Select Case Me.CboTipoProducto.Text
                '    Case "Orden de Compra"
                '        ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
                '    Case "Mercancia Recibida"
                '        ConsecutivoCompra = BuscaConsecutivo("Compra")
                '    Case "Devolucion de Compra"
                '        ConsecutivoCompra = BuscaConsecutivo("DevCompra")
                '    Case "Transferencia Recibida"
                '        ConsecutivoCompra = BuscaConsecutivo("Transferecia_Recibida")
                '    Case "Cuenta"
                '        ConsecutivoCompra = BuscaConsecutivo("Cuenta")
                '    Case "Cuenta DB"
                '        ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
                'End Select

                ''/////////////////////////////////////////////////////////////////////////////////////////
                ''///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
                ''////////////////////////////////////////////////////////////////////////////////////////
                'SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                'DataAdapter.Fill(DataSet, "Configuracion")
                'If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
                '    If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
                '        FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
                '    End If

                '    If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
                '        CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
                '    End If

                'End If

                'If CompraBodega = True Then
                '    NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
                'Else
                '    NumeroCompra = Format(ConsecutivoCompra, "0000#")
                'End If

                'Quien = "NumeroCompras"
                'Me.TxtNumeroEnsamble.Text = NumeroCompra

                ''////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                'GrabaCompras(NumeroCompra)
                NumeroCompra = Me.TxtNumeroEnsamble.Text
            Else
                'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
                'NumeroCompra = Format(ConsecutivoCompra, "0000#")
                NumeroCompra = Me.TxtNumeroEnsamble.Text
            End If


            'ActualizaMETODOcOMPRA()




            'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            '    Quien = "NumeroCompras"
            '    Me.TxtNumeroEnsamble.Text = NumeroCompra
            'End If

            ''////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            Registros = Me.BindingDetalle.Count
            iPosicion = Me.BindingDetalle.Position
            CodigoProducto = ""

            Me.TrueDBGridComponentes.Columns("TasaCambio").Text = BuscaTasaCambio(Me.DTPFecha.Value)
            Me.TrueDBGridComponentes.Columns("Numero_Compra").Text = NumeroCompra
            Me.TrueDBGridComponentes.Columns("Fecha_Compra").Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            Me.TrueDBGridComponentes.Columns("Tipo_Compra").Text = Me.CboTipoProducto.Text

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cod_Producto")) Then
                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            End If
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            PrecioUnitario = Me.TrueDBGridComponentes.Columns(3).Text
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")

            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
            End If

            If FacturaTarea = True Then
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
                    NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
                Else
                    NumeroLote = "SINLOTE"
                End If

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
                    If IsDate(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
                        FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
                    Else
                        FechaLote = "01/01/1900"
                    End If
                Else
                        FechaLote = "01/01/1900"
                End If
            End If

            '///////26-09-2025
            If Me.CboTipoProducto.Text <> "Cuenta" Then
                If Me.CboTipoProducto.Text <> "Cuenta DB" Then
                    If TipoProducto <> "Descuento" And TipoProducto <> "Servicio" Then
                        If BuscaProducto(CodigoProducto, Me.CboCodigoBodega.Text) = True Then
                            'GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote)

                            Select Case Me.CboTipoProducto.Text
                                Case "Mercancia Recibida"
                                    'Desactivado 26/09/2025
                                    'ActualizaCostoPromedio(CodigoProducto)
                                    ''DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                                    ''DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
                                    ''ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                                    ''CostoAnterior = BuscaCosto(CodProducto, Me.CboCodigoBodega.Text)
                                    ''CostoBodega(CodProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
                                    ''CostoActual = BuscaCosto(CodProducto, Me.CboCodigoBodega.Text)
                                    'Desactivado 26/09/2025
                                    'GrabaComprasHistoricos(NumeroCompra, Me.DTPFecha.Value, "Mercancia Recibida", CodProducto, CostoAnterior, CostoActual, Me.CboCodigoBodega.Text)

                                Case "Devolucion de Compra"
                                    'ActualizaCostoPromedio(CodigoProducto)
                                    'DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                                    'DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
                                    'ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                                    'CostoBodega(CodProducto, Cantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
                            End Select
                        Else
                            MsgBox("No se Puede Agregar este Producto ,No esta Asignado en la Bodega", MsgBoxStyle.Critical, "BODEGA " & Me.CboCodigoBodega.Text)

                        End If
                    Else

                        'GrabaDetalleCompra(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, NumeroLote, FechaLote)
                    End If
                End If
            End If
        End If


        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True
        'ActualizaMETODOcOMPRA()

        CodigoProducto = 0
        PrecioUnitario = 0
        Descuento = 0
        PrecioNeto = 0
        Importe = 0
        Cantidad = 0


    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepCompras As New ArepCompras, SqlDatos As String, SQlDetalle As String = "", Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim NumeroCompra As String, MonedaFactura As String = Me.TxtMonedaFactura.Text, MonedaImprime As String = Me.TxtMonedaImprime.Text
        Dim ConsecutivoCompra As Double, Respuesta As Double, SqlConsecutivo As String, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim Compras As TablaCompras = New TablaCompras
        'ConsecutivoCompra As Double

        Respuesta = MsgBox("Esta seguro de Procesar la " & Me.CboTipoProducto.Text & " " & Me.TxtNumeroEnsamble.Text, MsgBoxStyle.YesNo, "Zeus Facturacion")
        If Respuesta <> 6 Then
            Exit Sub
        End If

        AgregarCompras()

        '28/08/2025
        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
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
        '        Case "Cuenta"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '        Case "Cuenta DB"
        '            'ConsecutivoCompra = BuscaConsecutivo("Cuenta_CR")
        '            ConsecutivoCompra = BuscaConsecutivo("Compra")
        '    End Select

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////
        '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        '    DataAdapter.Fill(DataSet, "Configuracion")
        '    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
        '            FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
        '            CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
        '        End If

        '    End If

        '    If CompraBodega = True Then
        '        NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
        '    Else
        '        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    End If
        'Else
        '    'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        '    'NumeroCompra = Format(ConsecutivoCompra, "0000#")
        '    NumeroCompra = Me.TxtNumeroEnsamble.Text

        'End If





        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaCompras(NumeroCompra)

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

        '    GrabaMetodoDetalleCompra(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
        '    iPosicion = iPosicion + 1
        'Loop


        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Grabar la Compra: " & Me.TxtNumeroEnsamble.Text)

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

        TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)

        If MonedaFactura = "Cordobas" Then
            If MonedaImprime = "Cordobas" Then
                '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"

                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
            ElseIf MonedaImprime = "Dolares" Then
                SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Compras.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Compras.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Compras.Importe * (1 / TasaCambio.MontoTasa) AS Importe FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                             "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) / TasaCambio, "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) / TasaCambio, "##,##0.00")
            End If
        ElseIf MonedaFactura = "Dolares" Then
            If MonedaImprime = "Dolares" Then
                '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
                    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text), "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text), "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text), "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")
            ElseIf MonedaImprime = "Cordobas" Then
                SQlDetalle = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad,Detalle_Compras.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Compras.Descuento *  TasaCambio.MontoTasa AS Descuento, Detalle_Compras.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Compras.Importe * TasaCambio.MontoTasa AS Importe FROM Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto INNER JOIN TasaCambio ON Detalle_Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                            "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
                ArepCompras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepCompras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")

            End If
        End If





        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        'SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario,Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe FROM  Productos INNER JOIN Detalle_Compras ON Productos.Cod_Productos = Detalle_Compras.Cod_Producto " & _
        '    "WHERE (Detalle_Compras.Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Compras.Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Compras.Tipo_Compra = '" & Me.CboTipoProducto.Text & "')"
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

        Bitacora(Now, NombreUsuario, "Compras", "Proceso la Compra: " & Me.TxtNumeroEnsamble.Text)

    End Sub

    Private Sub TrueDBGridComponentes_ContextMenuStripChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.ContextMenuStripChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Dim Posicion As Double
        If Me.BindingDetalle.Count <> 0 Then
            My.Forms.FrmSeries.Tipo = Me.CboTipoProducto.Text
            Posicion = Me.BindingDetalle.Position
            My.Forms.FrmSeries.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Producto")
            My.Forms.FrmSeries.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.Numero = Me.TxtNumeroEnsamble.Text
            My.Forms.FrmSeries.Fecha = Me.DTPFecha.Value
            My.Forms.FrmSeries.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
            My.Forms.FrmSeries.Text = Me.BindingDetalle.Item(Posicion)("Cod_Producto") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.ShowDialog()
        End If
    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        'Dim Posicion As Double
        'If Me.BindingDetalle.Count <> 0 Then
        '    My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
        '    Posicion = Me.BindingDetalle.Position
        '    My.Forms.FrmLotes.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Productos")
        '    My.Forms.FrmLotes.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
        '    My.Forms.FrmLotes.NumeroDocumento = Me.TxtNumeroEnsamble.Text
        '    My.Forms.FrmLotes.Fecha = Me.DTPFecha.Value
        '    My.Forms.FrmLotes.LblProducto.Text = Me.BindingDetalle.Item(Posicion)("Cod_Productos") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
        '    My.Forms.FrmLotes.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
        '    My.Forms.FrmLotes.LblCantidad.Text = Me.BindingDetalle.Item(Posicion)("Cantidad")
        '    My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
        '    My.Forms.FrmLotes.ShowDialog()
        'End If

        My.Forms.FrmNuevoLote.ShowDialog()

    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click
        Quien = "ProyectosFactura"
        My.Forms.FrmConsultas.ShowDialog()
        If Not My.Forms.FrmConsultas.Descripcion = "" Then
            Me.CboProyecto.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmAjustarCostos.ShowDialog()
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridComponentes_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TrueDBGridComponentes.ControlAdded

    End Sub

    Private Sub TrueDBGridComponentes_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles TrueDBGridComponentes.ChangeUICues

    End Sub

    Private Sub TrueDBGridConsultas_BeforeColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridConsultas.BeforeColUpdate
        Dim Cantidad As Double = 0, PrecioUnitario As Double = 0, Importe As Double = 0

        If Not IsNumeric(Me.TrueDBGridConsultas.Columns("Cantidad").Text) Then
            MsgBox("Cantidad digitada no es numerica", vbCritical, "Zeus Facturacion")
            e.Cancel = True
            Exit Sub
        End If

        If Not IsNumeric(Me.TrueDBGridConsultas.Columns("Precio_Unitario").Text) Then
            MsgBox("Cantidad digitada no es numerica", vbCritical, "Zeus Facturacion")
            e.Cancel = True
            Exit Sub
        End If




        Cantidad = Me.TrueDBGridConsultas.Columns("Cantidad").Text
                PrecioUnitario = Me.TrueDBGridConsultas.Columns("Precio_Unitario").Text
                Importe = Cantidad * PrecioUnitario
        Me.TrueDBGridConsultas.Columns("Precio_Neto").Text = PrecioUnitario
        Me.TrueDBGridConsultas.Columns("Importe").Text = Format(Importe, "##,##0.0000")

    End Sub

    Private Sub TrueDBGridConsultas_BindingContextChanged(sender As Object, e As EventArgs) Handles TrueDBGridConsultas.BindingContextChanged

    End Sub

    Private Sub TrueDBGridComponentes_AfterSort(sender As Object, e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles TrueDBGridComponentes.AfterSort

    End Sub
End Class