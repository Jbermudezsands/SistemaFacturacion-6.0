Imports System.Data.SqlClient
Imports System.Threading
Imports System.IO
Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class FrmFacturas
    Inherits System.Windows.Forms.Form
    Public SubTotalGral As Double, IvaGral As Double, NetoGral As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double, ConsecutivoFacturaManual As Boolean = False, FacturaTarea As Boolean = False, ConsecutivoFacturaSerie As Boolean = False, FacturaLotes As Boolean = False, SalirFactura As Boolean = True
    Public ds As New DataSet, dsMetodo As DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, CambioCliente As Boolean, Impresora_Defecto As String
    Private oHebraCliente As Thread, SaldoClienteH As Double, LimiteCredito As Double, MonedaLimiteCredito As String, BloqueoLimiteCredito As Boolean = False, FechaVenceLote As Date
    Private CodigoCliente As String, FechaFin As Date, Moneda As String, PedirCantEscaner As Boolean
    Public WithEvents backgroundWorkerLote As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerInsertar As System.ComponentModel.BackgroundWorker
    Public WithEvents backgroundWorkerGrabar As System.ComponentModel.BackgroundWorker

    Public Delegate Sub delegadoListbox()
    Public Delegate Sub delegadoGridRegistros(Factura As TablaFactura)
    Public TablaFacturaPublica As TablaFactura


    Public Class ClaseLote
        Public CodigoProducto As String
        Public CodigoBodega As String
        Public NumeroLote As String
        Public Existencia As Double
        Public FechaVence As Date
    End Class

    Public Class ClaseFactura
        Public Numero_Factura As String
        Public Fecha_Factura As Date
    End Class
    Public Function CboTipoProducto_Hilos() As String

        If Me.CboTipoProducto.InvokeRequired Then
            Dim delegadoList As New delegadoListbox(AddressOf CboTipoProducto_Hilos)
            CboTipoProducto.Invoke(delegadoList, New Object() {})

        Else
            CboTipoProducto_Hilos = CboTipoProducto.Text
            Exit Function
        End If

    End Function

    Public Sub InsertarRowGrid_Hilos(Factura As TablaFactura)
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.RowCount
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleFactura").AcceptChanges()
            da.Update(ds.Tables("DetalleFactura"))

            'ActualizarGridInsertRow()
            ActualizarGridInsertRow_Hilos(Factura)

            'Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleFactura").AcceptChanges()
                da.Update(ds.Tables("DetalleFactura"))
            End If
        End If

        ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


    End Sub
    Public Sub ActualizarGridInsertRow_Hilos(Factura As TablaFactura)
        Dim SqlCompras As String, iPosicion As Integer

        'iPosicion = Me.TrueDBGridComponentes.Row
        iPosicion = Me.TrueDBGridComponentes.RowCount

        If Me.TrueDBGridComponentes.InvokeRequired Then
            Dim delegadoGrid As New delegadoGridRegistros(AddressOf ActualizarGridInsertRow_Hilos)
            TrueDBGridComponentes.Invoke(delegadoGrid, New Object() {Factura})
            My.Application.DoEvents()
        Else
            If FacturaTarea = True Then
                ds.Tables("DetalleFactura").Reset()
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
                '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                'Detalle_Facturas.id_Detalle_Factura
                SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura ,Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " &
                                                    "WHERE (Detalle_Facturas.Numero_Factura = '" & Factura.Numero_Factura & "') AND  (Detalle_Facturas.Tipo_Factura = '" & Factura.Tipo_Factura & "') ORDER BY id_Detalle_Factura "
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleFactura")
                'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                ds = New DataSet
                da = New SqlDataAdapter(SqlCompras, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleFactura")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Visible = False
                ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False



            ElseIf FacturaLotes = True Then

                ds.Tables("DetalleFactura").Reset()
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
                '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                'Detalle_Facturas.id_Detalle_Factura
                SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " &
                                                    "WHERE (Detalle_Facturas.Numero_Factura = '" & Factura.Numero_Factura & "') AND  (Detalle_Facturas.Tipo_Factura = '" & Factura.Tipo_Factura & "') ORDER BY id_Detalle_Factura "
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleFactura")
                'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                ds = New DataSet
                da = New SqlDataAdapter(SqlCompras, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleFactura")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
            Else
                '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                'Detalle_Facturas.id_Detalle_Factura
                SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM  Detalle_Facturas " &
                             "WHERE (Detalle_Facturas.Numero_Factura = '" & Factura.Numero_Factura & "') AND (Detalle_Facturas.Tipo_Factura = '" & Factura.Tipo_Factura & "') ORDER BY id_Detalle_Factura"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas " & _
                '    "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleFacturas")
                'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
                ds = New DataSet
                da = New SqlDataAdapter(SqlCompras, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleFactura")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
                Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False


            End If

            Me.TrueDBGridComponentes.Row = iPosicion
        End If



    End Sub

    Public Sub AgregarFacturaWorker(Factura As TablaFactura, dsDetalle As DataSet, dsMetodoPago As DataSet, Retencion1Porciento As Boolean, Retencion2Porciento As Boolean, worker As BackgroundWorker, e As DoWorkEventArgs)
        Dim iPosicion As Double, Registros As Double, Monto As Double
        Dim CodTarea As String = Nothing, DetalleFactura As New TablaDetalleFactura
        Dim IdDetalle As Double = -1
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NombrePago As String, NumeroTarjeta As String, FechaVenceTarjeta As Date, SQlstring As String
        Dim Consecutivo As Double, NumeroNota As String
        Dim RstCosto As New RstCostoPromedio

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        CambiarFechaFactura = False
        GrabaFacturas(Factura)

        If CambioCliente = True Then
            Bitacora(Now, NombreUsuario, Factura.Tipo_Factura, "Se Cambio de Cliente: " & Trim(Factura.Cod_Cliente) & " " & Factura.Numero_Factura)
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Registros = dsDetalle.Tables("DetalleFactura").Rows.Count

        iPosicion = 0
        Monto = 0


        Do While iPosicion < Registros
            CostoUnitario = 0

            My.Application.DoEvents()


            DetalleFactura.Numero_Factura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Numero_Factura")
            DetalleFactura.Cod_Producto = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Cod_Producto")
            DetalleFactura.Fecha_Factura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Fecha_Factura")
            DetalleFactura.Tipo_Factura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Tipo_Factura")

            worker.ReportProgress(iPosicion, "Factura:" & DetalleFactura.Cod_Producto)

            If CambiarFechaFactura = True Then

                DetalleFactura.Descripcion_Producto = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Descripcion_Producto")

                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("id_Detalle_Factura")) Then
                    DetalleFactura.Id_Detalle_Factura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("id_Detalle_Factura")
                Else
                    DetalleFactura.Id_Detalle_Factura = -1
                End If


                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Precio_Unitario")) Then
                    DetalleFactura.Precio_Unitario = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Precio_Unitario")
                Else
                    DetalleFactura.Precio_Unitario = 0
                End If
                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Descuento")) Then
                    DetalleFactura.Descuento_DetalleFactura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Descuento")
                Else
                    DetalleFactura.Descuento_DetalleFactura = 0
                End If
                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Precio_Neto")) Then
                    DetalleFactura.Precio_Neto = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Precio_Neto")
                Else
                    DetalleFactura.Precio_Neto = 0
                End If
                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Importe")) Then
                    DetalleFactura.Importe_DetalleFactura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Importe")
                Else
                    DetalleFactura.Importe_DetalleFactura = 0
                End If
                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Cantidad")) Then
                    DetalleFactura.Cantidad_DetalleFactura = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Cantidad")
                Else
                    DetalleFactura.Cantidad_DetalleFactura = 0
                End If

                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Fecha_Vence")) Then
                    DetalleFactura.Fecha_Vence = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Fecha_Vence")
                Else
                    DetalleFactura.Fecha_Vence = "01/01/1900"
                End If


                If FacturaTarea = True Then
                    If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")) Then
                        DetalleFactura.Cod_Tarea = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")
                    Else
                        DetalleFactura.Cod_Tarea = 0
                    End If

                    If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Costo_Unitario")) Then
                        RstCosto = CostoPromedioKardex(DetalleFactura.Cod_Producto, DetalleFactura.Fecha_Factura)
                        CostoUnitario = RstCosto.Costo_Cordoba
                    End If

                    GrabaDetalleFacturaTarea(DetalleFactura.Numero_Factura, DetalleFactura.Cod_Producto, DetalleFactura.Descripcion_Producto, DetalleFactura.Precio_Unitario, DetalleFactura.Descuento_DetalleFactura, DetalleFactura.Precio_Neto, DetalleFactura.Importe_DetalleFactura, DetalleFactura.Cantidad_DetalleFactura, DetalleFactura.Id_Detalle_Factura, DetalleFactura.Cod_Tarea)
                ElseIf FacturaLotes = True Then

                    If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")) Then
                        CodTarea = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")
                    Else
                        CodTarea = 0
                    End If

                    If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Costo_Unitario")) Then
                        RstCosto = CostoPromedioKardex(DetalleFactura.Cod_Producto, DetalleFactura.Fecha_Factura)
                        CostoUnitario = RstCosto.Costo_Cordoba
                    End If

                    GrabaDetalleFacturaLotes(DetalleFactura.Numero_Factura, DetalleFactura.Cod_Producto, DetalleFactura.Descripcion_Producto, DetalleFactura.Precio_Unitario, DetalleFactura.Descuento_DetalleFactura, DetalleFactura.Precio_Neto, DetalleFactura.Importe_DetalleFactura, DetalleFactura.Cantidad_DetalleFactura, DetalleFactura.Id_Detalle_Factura, DetalleFactura.Cod_Tarea, DetalleFactura.Fecha_Vence, DetalleFactura.Tipo_Factura)

                Else
                    '//////////////// POR LOS HILOS REPITO EL CODIGO DEL COSTO ////
                    If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Costo_Unitario")) Then
                        RstCosto = CostoPromedioKardex(DetalleFactura.Cod_Producto, DetalleFactura.Fecha_Factura)
                        CostoUnitario = RstCosto.Costo_Cordoba
                    End If
                    GrabaDetalleFactura(DetalleFactura.Numero_Factura, DetalleFactura.Cod_Producto, DetalleFactura.Descripcion_Producto, DetalleFactura.Precio_Unitario, DetalleFactura.Descuento_DetalleFactura, DetalleFactura.Precio_Neto, DetalleFactura.Importe_DetalleFactura, DetalleFactura.Cantidad_DetalleFactura, DetalleFactura.Id_Detalle_Factura, CostoUnitario)
                End If
            Else
                '//////////////// POR LOS HILOS REPITO EL CODIGO DEL COSTO ////
                If Not IsDBNull(dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Costo_Unitario")) Then
                    RstCosto = CostoPromedioKardex(DetalleFactura.Cod_Producto, DetalleFactura.Fecha_Factura)
                    CostoUnitario = RstCosto.Costo_Cordoba
                End If
                GrabaDetalleFactura(DetalleFactura.Numero_Factura, DetalleFactura.Cod_Producto, DetalleFactura.Descripcion_Producto, DetalleFactura.Precio_Unitario, DetalleFactura.Descuento_DetalleFactura, DetalleFactura.Precio_Neto, DetalleFactura.Importe_DetalleFactura, DetalleFactura.Cantidad_DetalleFactura, DetalleFactura.Id_Detalle_Factura, CostoUnitario)

            End If

            ActualizaDetalleBodega(Factura.CodBodega1, DetalleFactura.Cod_Producto)
            iPosicion = iPosicion + 1
        Loop


        If CambiarFechaFactura = False Then

            'InsertarRowGrid()

        End If

        ''''''''''''''''''''''ACTUALIZO EL LISTADO DE INVENTARIO PARA FACTURACION ---------------------------------
        'Registros = dsDetalle.Tables("DetalleFactura").Rows.Count
        'iPosicion = 0
        'Do While iPosicion < Registros
        '    CodigoProducto = dsDetalle.Tables("DetalleFactura").Rows(iPosicion)("Cod_Producto")
        '    ActualizaDetalleBodega(Factura.CodBodega1, DetalleFactura.Cod_Producto)
        '    iPosicion = iPosicion + 1
        'Loop


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
                If Monto <> 0 Then
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

                    GrabaMetodoDetalleFactura(DetalleFactura.Numero_Factura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, DetalleFactura.Fecha_Factura, DetalleFactura.Tipo_Factura)
                End If
            End If
            iPosicion = iPosicion + 1
        Loop

        Bitacora(Now, NombreUsuario, Factura.Tipo_Factura, "Grabo la Factura: " & Factura.Numero_Factura)


        If Retencion1Porciento = True Then
            Dim MontoIr As Double, CodigoNota As String

            SQlstring = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%1%%')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Retencion")
            If DataSet.Tables("Retencion").Rows.Count <> 0 Then
                MontoIr = Factura.Sub_Total
                MontoIr = Format(MontoIr * 0.01, "##,##0.00")
                CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
            Else
                MsgBox("No Existe Nota de Credito para Retencion 1%", MsgBoxStyle.Critical, "Zeus Facturacion")
                Retencion1Porciento = False
                MontoIr = 0
                CodigoNota = 0
            End If
            DataSet.Tables("Retencion").Reset()

            Consecutivo = BuscaConsecutivo("NotaCredito")
            NumeroNota = Format(Consecutivo, "0000#")
            GrabaNotaDebito(NumeroNota, Factura.Fecha_Factura, CodigoNota, MontoIr, Factura.Moneda_Factura, Factura.Cod_Cliente, Factura.Nombre_Cliente, Factura.Observaciones_Factura, True, False, False)
            'GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
            InsertarDetalleNotaDebito(NumeroNota, Factura.Fecha_Factura, CodigoNota, "Generado Acutomaticamente por Factura", Factura.Numero_Factura, MontoIr)
        End If

        If Retencion2Porciento = True Then
            Dim MontoIr As Double, CodigoNota As String

            SQlstring = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%2%%')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Retencion")
            If DataSet.Tables("Retencion").Rows.Count <> 0 Then
                MontoIr = Factura.Sub_Total
                MontoIr = Format(MontoIr * 0.02, "##,##0.00")
                CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
            Else
                MsgBox("No Existe Nota de Credito para Retencion 1%", MsgBoxStyle.Critical, "Zeus Facturacion")
                Retencion2Porciento = False
                MontoIr = 0
                CodigoNota = 0
            End If
            DataSet.Tables("Retencion").Reset()


            MontoIr = Factura.Sub_Total

            MontoIr = MontoIr * 0.02
            Consecutivo = BuscaConsecutivo("NotaCredito")
            NumeroNota = Format(Consecutivo, "0000#")

            GrabaNotaDebito(NumeroNota, Factura.Fecha_Factura, CodigoNota, MontoIr, Factura.Moneda_Factura, Factura.Cod_Cliente, Factura.Nombre_Cliente, Factura.Observaciones_Factura, True, False, False)
            InsertarDetalleNotaDebito(NumeroNota, Factura.Fecha_Factura, CodigoNota, "Generado Acutomaticamente por Factura", Factura.Numero_Factura, MontoIr)
            'GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
        End If


        'MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
        'LimpiarFacturas()
        'Me.Button7.Enabled = True
        'Me.CboCodigoBodega.Enabled = True


        'If NombreCliente = "Alumnos" Then
        '    Me.Label12.Visible = False
        '    Me.CboCodigoVendedor.Visible = False
        'End If

        'If UsuarioBodega <> "Ninguna" Then
        '    Me.CboCodigoBodega.Text = UsuarioBodega
        '    Me.CboCodigoBodega.Enabled = False
        '    Me.Button7.Enabled = False
        'End If

        'If UsuarioTipoFactura <> "Ninguna" Then
        '    Me.CboTipoProducto.Text = UsuarioTipoFactura
        'End If

        'If UsuarioTipoSerie <> "Ninguna" Then
        '    Me.CmbSerie.Text = UsuarioTipoSerie
        'End If

        'If UsuarioVendedor <> "Ninguna" Then
        '    Me.CboCodigoVendedor.Text = UsuarioVendedor
        'End If

        'If UsuarioCliente <> "Ninguna" Then
        '    Me.TxtCodigoClientes.Text = UsuarioCliente
        'End If



        'SalirFactura = True
        'Me.TxtCodigoClientes.Focus()

        'Catch ex As Exception
        '    MsgBox(Err.Description)
        'End Try
    End Sub

    Public Sub AgregarFactura()
        Dim NumeroFactura As String
        Dim CodTarea As String = Nothing
        Dim IdDetalle As Double = -1
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim dsDetalle As DataSet, dsMetodoPago As New DataSet, DtMetodo As New DataTable
        Dim Retencion1Porciento As Boolean, Retencion2Porciento As Boolean

        ActualizaMETODOFactura()

        Dim TablaFactura As TablaFactura = New TablaFactura
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        NumeroFactura = Me.TxtNumeroEnsamble.Text

        TablaFacturaPublica = New TablaFactura

        NumeroFactura = Me.TxtNumeroEnsamble.Text

        TablaFactura.Numero_Factura = NumeroFactura
        TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        TablaFactura.Tipo_Factura = CboTipoProducto_Hilos()
        TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
        TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
        TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
        TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
        TablaFactura.CodBodega1 = CboCodigoBodega.Text
        TablaFactura.Cod_Cajero = CboCajero.Text
        TablaFactura.Nombre_Cliente = TxtNombres.Text
        TablaFactura.Apellido_Cliente = TxtApellidos.Text
        TablaFactura.Direccion_Cliente = TxtDireccion.Text
        TablaFactura.Telefono_Cliente = TxtTelefono.Text
        TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Via_Envarque = ""
        TablaFactura.SuReferencia1 = CboReferencia.Text
        TablaFactura.Nuestra_Referencia = ""
        TablaFactura.Codigo_Proyecto = CboProyecto.Text
        TablaFactura.Observaciones_Factura = Me.TxtObservaciones.Text

        If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
            TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        Else
            TablaFactura.Sub_Total = 0
        End If

        If My.Forms.FrmFacturas.IvaGral <> 0 Then
            TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        Else
            TablaFactura.IVA_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
            TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        Else
            TablaFactura.Pagado_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
            TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        Else
            TablaFactura.Neto_Pagar = 0
        End If

        If RadioButton1.Checked = True Then
            TablaFactura.Metodo_Pago = "Credito"
        Else
            TablaFactura.Metodo_Pago = "Contado"
        End If

        If OptExsonerado.Checked = True Then
            TablaFactura.Exonerado_Factura = 1
        Else
            TablaFactura.Exonerado_Factura = 0
        End If

        If OptRet1Porciento.Checked = True Then
            TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
            TablaFactura.Retener1_Porciento = 1
        Else
            TablaFactura.MontoRetencion1_Porciento = 0
            TablaFactura.Retener1_Porciento = 0
        End If

        If OptRet2Porciento.Checked = True Then
            TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
            TablaFactura.Retener2_Porciento = 1
        Else
            TablaFactura.MontoRetencion2_Porciento = 0
            TablaFactura.Retener2_Porciento = 0
        End If


        If Not CboProyecto.Text = "" Then
            TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If

        If CboReferencia.Text <> "" Then
            TablaFactura.Referencia_Factura = CboReferencia.Text
        End If

        TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

        dsDetalle = ds.Copy
        'DtMetodo = New DataTable("MetodoPago")
        'DtMetodo = Me.BindingMetodo.DataSource
        'dsMetodoPago.Tables.Add(DtMetodo.Copy)
        dsMetodoPago = dsMetodo.Copy
        Retencion1Porciento = OptRet1Porciento.Checked
        Retencion2Porciento = OptRet2Porciento.Checked

        LimpiarFacturas()
        My.Application.DoEvents()


        Dim worker As BackgroundWorker
        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf backgroundWorkerGrabar_DoWork
        AddHandler worker.ProgressChanged, AddressOf backgroundWorkerGrabar_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerGrabar_RunWorkerCompleted
        worker.RunWorkerAsync({TablaFactura, dsDetalle, dsMetodoPago, Retencion1Porciento, Retencion2Porciento})


    End Sub

    '////////////////////////////////HILOS PARA GRABAR FACTURA /////////////////
    Private Sub backgroundWorkerGrabar_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerGrabar.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim dsDetalle As DataSet, dsMetodoPago As New DataSet, DtMetodo As New DataTable
        Dim Retencion1Porciento As Boolean, Retencion2Porciento As Boolean
        Dim Factura As TablaFactura = New TablaFactura

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            Factura = e.Argument(0)
            dsDetalle = e.Argument(1)
            dsMetodoPago = e.Argument(2)
            Retencion1Porciento = e.Argument(3)
            Retencion2Porciento = e.Argument(4)

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            AgregarFacturaWorker(Factura, dsDetalle, dsMetodoPago, Retencion1Porciento, Retencion2Porciento, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerGrabar_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerGrabar.RunWorkerCompleted

        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else
            MDIMain.txtSPlano3.Text = ""

        End If

    End Sub
    Private Sub backgroundWorkerGrabar_ProgressChanged(
ByVal sender As Object,
ByVal e As ProgressChangedEventArgs) _
Handles backgroundWorkerGrabar.ProgressChanged
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        MDIMain.txtSPlano3.Text = e.UserState.ToString


    End Sub

    '////////////////////////////////HILOS PARA LEER LOTES ////////////////////////////
    Private Sub backgroundWorkerLote_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerLote.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As ClaseLote = e.Argument
        Dim CodigoProducto As String = args.CodigoProducto, CodigoBodega As String = args.CodigoBodega, NumeroLote As String = args.NumeroLote
        Dim fechaVence As Date = args.FechaVence

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            e.Result = BuscaExistenciaDetalleLoteWorker(args, worker, e)

        End If
    End Sub
    Private Sub backgroundWorkerLote_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerLote.RunWorkerCompleted
        Dim Argumentos As New ClaseLote
        Dim ExistenciaLote As Double, NumeroLote As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, StrSqlUpdate As String, iResulteado As Integer
        Dim TablaLotexProducto As TablaLotexProducto = New TablaLotexProducto



        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else
            Argumentos = e.Result

            NumeroLote = Argumentos.NumeroLote
            ExistenciaLote = Argumentos.Existencia


            TablaLotexProducto.Cod_Productos = Argumentos.CodigoProducto
            TablaLotexProducto.Numero_Lote = Argumentos.NumeroLote
            TablaLotexProducto.Cod_Bodega = Argumentos.CodigoBodega
            TablaLotexProducto.Existencia = Argumentos.Existencia
            TablaLotexProducto.Fecha_Vence = Argumentos.FechaVence



            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////


            If ExistenciaLote <= 0 Then
                TablaLotexProducto.Activo = False
                UpdateLotexProducto(TablaLotexProducto)

            ElseIf ExistenciaLote > 0 Then

                LoteFacturaWorker = NumeroLote
                If DateDiff("d", Format(FechaVenceLote, "dd/MM/yyyy"), Format(Argumentos.FechaVence, "dd/MM/yyyy")) < 0 Then

                    FechaVenceLote = Argumentos.FechaVence
                    Me.TrueDBGridComponentes.Col = 2
                    Me.TrueDBGridComponentes.Columns("CodTarea").Text = NumeroLote
                End If

                '/////////////////COMO ESTA ORGANIZADO DE MAYOR A MENOR CANCELO EL PROCESO EN CUANTO ENCUNTRO EL PRIMERO
                TablaLotexProducto.Activo = True
                UpdateLotexProducto(TablaLotexProducto)



            End If


        End If

    End Sub
    Public Sub CancelarWorker(Cancelar As Boolean)
        If Cancelar = True Then
            backgroundWorkerLote.CancelAsync()
        End If
    End Sub


    Public Function BuscaExistenciaDetalleLoteWorker(Args As ClaseLote, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As ClaseLote
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Existencia As Double = 0, SqlConsulta As String, DevolucionCompra As Double = 0
        Dim UnidadFacturada As Double = 0, DevolucionFactura As Double = 0, TransferenciaEnviada As Double = 0, TransferenciaRecibida As Double = 0
        Dim SalidaBodega As Double = 0, CostoVenta As Double = 0, ImporteFactura As Double = 0
        Dim ImporteDevCompra As Double = 0, ImporteVenta As Double = 0, ImporteSalida As Double = 0
        Dim ImporteDevFactura As Double = 0, Argumentos As ClaseLote = New ClaseLote
        Dim UnidadComprada As Double

        Existencia = 0
        If worker.CancellationPending Then
            e.Cancel = True
            Exit Function
        Else

            If Args.NumeroLote = "F-23423" Then
                Args.NumeroLote = "F-23423"
            End If

            '//////////////////////////////////BUSCO EL TOTAL DE LAS COMPRAS////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Compras.Cantidad) AS Cantidad, SUM(Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto) AS Importe  FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " &
                      "WHERE (Detalle_Compras.Cod_Producto = '" & Args.CodigoProducto & "') AND (Compras.Cod_Bodega = '" & Args.CodigoBodega & "') AND (Detalle_Compras.Numero_Lote = '" & Args.NumeroLote & "')  GROUP BY Detalle_Compras.Tipo_Compra HAVING  (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida') "

            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "Compras")
            If DataSet.Tables("Compras").Rows.Count <> 0 Then
                UnidadComprada = DataSet.Tables("Compras").Rows(0)("Cantidad")
                ImporteCompra = DataSet.Tables("Compras").Rows(0)("Importe")
            End If


            '//////////////////////////////////BUSCO EL TOTAL DE LAS DEVOLUCION DE COMPRAS////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT  SUM(Detalle_Compras.Cantidad) AS Cantidad,SUM(Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto) AS Importe FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Detalle_Compras.Cod_Producto = '" & Args.CodigoProducto & "') AND (Compras.Cod_Bodega = '" & Args.CodigoBodega & "') AND (Detalle_Compras.Numero_Lote = '" & Args.NumeroLote & "') GROUP BY Detalle_Compras.Tipo_Compra HAVING  (Detalle_Compras.Tipo_Compra = N'Devolucion de Compra')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "DevolucionCompras")
            If DataSet.Tables("DevolucionCompras").Rows.Count <> 0 Then
                DevolucionCompra = DataSet.Tables("DevolucionCompras").Rows(0)("Cantidad")
                ImporteDevCompra = DataSet.Tables("DevolucionCompras").Rows(0)("Importe")
            End If

            '////////////////////////////////////BUSCO EL TOTAL DE LAS FACTURAS//////////////////////////////////////////////////////////////////////
            SqlConsulta = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " &
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Cod_Producto = '" & Args.CodigoProducto & "') AND (Facturas.Cod_Bodega =  '" & Args.CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & Args.NumeroLote & "')"
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
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Salida Bodega') AND (Detalle_Facturas.Cod_Producto = '" & Args.CodigoProducto & "') AND (Facturas.Cod_Bodega =  '" & Args.CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & Args.NumeroLote & "')"
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
                      "WHERE  (Detalle_Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Detalle_Facturas.Cod_Producto =  '" & Args.CodigoProducto & "') AND (Facturas.Cod_Bodega = '" & Args.CodigoBodega & "') AND (Detalle_Facturas.CodTarea = '" & Args.NumeroLote & "')"
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
                      "WHERE (Detalle_Facturas.Tipo_Factura = 'Transferencia Enviada') AND (Detalle_Facturas.Cod_Producto = '" & Args.CodigoProducto & "') AND (Facturas.Su_Referencia = '" & Args.CodigoBodega & "') AND (Facturas.TransferenciaProcesada = 1) AND (Detalle_Facturas.CodTarea = '" & Args.NumeroLote & "')"
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
                      "WHERE (Compras.TransferenciaProcesada = 1) AND (Compras.Cod_Bodega = '" & Args.CodigoBodega & "') AND (Detalle_Compras.Cod_Producto = '" & Args.CodigoProducto & "') AND (Compras.Tipo_Compra = 'Transferencia Recibida') AND (Detalle_Compras.Numero_Lote = '" & Args.NumeroLote & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
            DataAdapter.Fill(DataSet, "TransferenciasRecibidas")
            If DataSet.Tables("TransferenciasRecibidas").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")) Then
                    TransferenciaRecibida = DataSet.Tables("TransferenciasRecibidas").Rows(0)("Cantidad")
                End If
            End If

            Existencia = UnidadComprada - DevolucionCompra - UnidadFacturada - SalidaBodega + DevolucionFactura - TransferenciaEnviada + TransferenciaRecibida
            Argumentos.Existencia = Existencia
            Argumentos.CodigoProducto = Args.CodigoProducto
            Argumentos.CodigoBodega = Args.CodigoBodega
            Argumentos.NumeroLote = Args.NumeroLote
            Argumentos.FechaVence = Args.FechaVence




        End If



        Return Argumentos


    End Function

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
    Public Function LoteDefectoWorker(ByVal CodigoProducto As String, ByVal CodigoBodega As String, FechaFiltro As Date)
        Dim NumeroLote As String = "SINLOTE"
        Dim FechaVenceLote As Date = FechaFiltro 'DateAdd(DateInterval.Month, -2, FechaFiltro)

        Using cn As New SqlClient.SqlConnection(Conexion)
            cn.Open()

            Dim SqlString As String = "WITH Movimientos AS (SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra AND DC.Fecha_Compra = C.Fecha_Compra AND DC.Tipo_Compra = C.Tipo_Compra WHERE DC.Fecha_Compra <= @FechaCorte AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta UNION SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE DF.Fecha_Factura <= @FechaCorte AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta), Existencias AS (SELECT L.Cod_Producto, Prod.Descripcion_Producto AS Producto, L.Cod_Bodega, L.Lote, Prod.Cod_Linea, Lte.FechaVence AS Fecha_Vencimiento, ISNULL(MR.Cantidad,0) AS Mercancia_Recibida, ISNULL(TR.Cantidad,0) AS Transferencia_Recibida, ISNULL(DV.Cantidad,0) AS Devolucion_Venta, ISNULL(Fact.Cantidad,0) AS Factura, ISNULL(SB.Cantidad,0) AS Salidas_Bodegas, ISNULL(TE.Cantidad,0) AS Transferencia_Enviada, ISNULL(DC.Cantidad,0) AS Devolucion_Compra, ISNULL(MR.Cantidad,0)+ISNULL(TR.Cantidad,0)+ISNULL(DV.Cantidad,0)-(ISNULL(Fact.Cantidad,0)+ISNULL(SB.Cantidad,0)+ISNULL(TE.Cantidad,0)+ISNULL(DC.Cantidad,0)) AS Existencia FROM Movimientos L INNER JOIN Productos Prod ON L.Cod_Producto=Prod.Cod_Productos LEFT JOIN Lote Lte ON L.Lote=Lte.Numero_Lote AND Lte.Activo=1 AND L.Lote NOT IN ('SIN LOTE','SINLOTE','') LEFT JOIN (SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra=C.Numero_Compra AND DC.Fecha_Compra=C.Fecha_Compra AND DC.Tipo_Compra=C.Tipo_Compra WHERE C.Fecha_Compra<=@FechaCorte AND C.Tipo_Compra='Mercancia Recibida' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega) MR ON L.Cod_Producto=MR.Cod_Producto AND L.Lote=MR.Lote AND L.Cod_Bodega=MR.Cod_Bodega LEFT JOIN (SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra=C.Numero_Compra AND DC.Fecha_Compra=C.Fecha_Compra AND DC.Tipo_Compra=C.Tipo_Compra WHERE C.Fecha_Compra<=@FechaCorte AND C.Tipo_Compra='Transferencia Recibida' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega) TR ON L.Cod_Producto=TR.Cod_Producto AND L.Lote=TR.Lote AND L.Cod_Bodega=TR.Cod_Bodega LEFT JOIN (SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura=F.Numero_Factura AND DF.Fecha_Factura=F.Fecha_Factura AND DF.Tipo_Factura=F.Tipo_Factura WHERE F.Fecha_Factura<=@FechaCorte AND F.Tipo_Factura='Devolucion de Venta' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega) DV ON L.Cod_Producto=DV.Cod_Producto AND L.Lote=DV.Lote AND L.Cod_Bodega=DV.Cod_Bodega LEFT JOIN (SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura=F.Numero_Factura AND DF.Fecha_Factura=F.Fecha_Factura AND DF.Tipo_Factura=F.Tipo_Factura WHERE F.Fecha_Factura<=@FechaCorte AND F.Tipo_Factura='Factura' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega) Fact ON L.Cod_Producto=Fact.Cod_Producto AND L.Lote=Fact.Lote AND L.Cod_Bodega=Fact.Cod_Bodega LEFT JOIN (SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura=F.Numero_Factura AND DF.Fecha_Factura=F.Fecha_Factura AND DF.Tipo_Factura=F.Tipo_Factura WHERE F.Fecha_Factura<=@FechaCorte AND F.Tipo_Factura='Salida Bodega' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega) SB ON L.Cod_Producto=SB.Cod_Producto AND L.Lote=SB.Lote AND L.Cod_Bodega=SB.Cod_Bodega LEFT JOIN (SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura=F.Numero_Factura AND DF.Fecha_Factura=F.Fecha_Factura AND DF.Tipo_Factura=F.Tipo_Factura WHERE F.Fecha_Factura<=@FechaCorte AND F.Tipo_Factura='Transferencia Enviada' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega) TE ON L.Cod_Producto=TE.Cod_Producto AND L.Lote=TE.Lote AND L.Cod_Bodega=TE.Cod_Bodega LEFT JOIN (SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra=C.Numero_Compra AND DC.Fecha_Compra=C.Fecha_Compra AND DC.Tipo_Compra=C.Tipo_Compra WHERE C.Fecha_Compra<=@FechaCorte AND C.Tipo_Compra='Devolucion de Compra' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega) DC ON L.Cod_Producto=DC.Cod_Producto AND L.Lote=DC.Lote AND L.Cod_Bodega=DC.Cod_Bodega), LoteMasViejo AS (SELECT *, ROW_NUMBER() OVER(PARTITION BY Cod_Producto,Cod_Bodega ORDER BY Fecha_Vencimiento ASC) AS rn FROM Existencias WHERE Existencia>0 AND Fecha_Vencimiento IS NOT NULL) SELECT lote as Numero_Lote,* FROM LoteMasViejo WHERE rn=1 ORDER BY Cod_Producto, Cod_Bodega, Fecha_Vencimiento;"


            Using cmd As New SqlClient.SqlCommand(SqlString, cn)
                cmd.Parameters.AddWithValue("@FechaCorte", FechaVenceLote)
                cmd.Parameters.AddWithValue("@CodBodegaDesde", CodigoBodega)
                cmd.Parameters.AddWithValue("@CodBodegaHasta", CodigoBodega)
                cmd.Parameters.AddWithValue("@CodProductoDesde", CodigoProducto)
                cmd.Parameters.AddWithValue("@CodProductoHasta", CodigoProducto)

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then NumeroLote = result.ToString()
            End Using
        End Using

        Return NumeroLote




        '***********CODIGO RETIRADO 15/10/2025
        'Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        'Dim SQlString As String, iPosicion As Double = 0
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim Registro As Double = 0, FechaActual As Date = Format(Now, "dd/MM/yyyy")
        'Dim NumeroLote As String = "SINLOTE"
        'Dim ComandoUpdate As New SqlClient.SqlCommand

        'FechaVenceLote = DateAdd(DateInterval.Month, -2, FechaFiltro)

        ''SQlString = "SELECT  MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence as Fecha_Vence FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote WHERE  (Lote.Activo = 1) AND (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Lote.FechaVence >= CONVERT(DATETIME, '" & Format(FechaFiltro, "yyyy-MM-dd") & "', 102)) GROUP BY Detalle_Compras.Numero_Lote, Lote.FechaVence HAVING (NOT (Detalle_Compras.Numero_Lote IS NULL)) ORDER BY Lote.FechaVence"

        'SQlString = "WITH Movimientos AS (SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote, '') AS Lote, C.Cod_Bodega FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra AND DC.Fecha_Compra = C.Fecha_Compra AND DC.Tipo_Compra = C.Tipo_Compra WHERE DC.Fecha_Compra <= @FechaCorte AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta UNION SELECT DF.Cod_Producto, ISNULL(DF.CodTarea, '') AS Lote, F.Cod_Bodega FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE DF.Fecha_Factura <= @FechaCorte AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta ), Existencias AS ( SELECT L.Cod_Producto, Prod.Descripcion_Producto AS Producto, L.Cod_Bodega, L.Lote, Prod.Cod_Linea, Lte.FechaVence AS Fecha_Vencimiento, ISNULL(MR.Cantidad,0) AS Mercancia_Recibida, ISNULL(TR.Cantidad,0) AS Transferencia_Recibida, ISNULL(DV.Cantidad,0) AS Devolucion_Venta, ISNULL(Fact.Cantidad,0) AS Factura, ISNULL(SB.Cantidad,0) AS Salidas_Bodegas, ISNULL(TE.Cantidad,0) AS Transferencia_Enviada, ISNULL(DC.Cantidad,0) AS Devolucion_Compra, ISNULL(MR.Cantidad,0) + ISNULL(TR.Cantidad,0) + ISNULL(DV.Cantidad,0) - (ISNULL(Fact.Cantidad,0) + ISNULL(SB.Cantidad,0) + ISNULL(TE.Cantidad,0) + ISNULL(DC.Cantidad,0)) AS Existencia FROM Movimientos L INNER JOIN Productos Prod ON L.Cod_Producto = Prod.Cod_Productos LEFT JOIN Lote Lte ON L.Lote = Lte.Numero_Lote AND Lte.Activo = 1 AND L.Lote NOT IN ('SIN LOTE', 'SINLOTE', '') LEFT JOIN ( SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra AND DC.Fecha_Compra = C.Fecha_Compra AND DC.Tipo_Compra = C.Tipo_Compra WHERE C.Fecha_Compra <= @FechaCorte AND C.Tipo_Compra = 'Mercancia Recibida' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega ) MR ON L.Cod_Producto = MR.Cod_Producto AND L.Lote = MR.Lote AND L.Cod_Bodega = MR.Cod_Bodega LEFT JOIN ( SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra AND DC.Fecha_Compra = C.Fecha_Compra AND DC.Tipo_Compra = C.Tipo_Compra WHERE C.Fecha_Compra <= @FechaCorte AND C.Tipo_Compra = 'Transferencia Recibida' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega ) TR ON L.Cod_Producto = TR.Cod_Producto AND L.Lote = TR.Lote AND L.Cod_Bodega = TR.Cod_Bodega LEFT JOIN ( SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE F.Fecha_Factura <= @FechaCorte AND F.Tipo_Factura = 'Devolucion de Venta' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega ) DV ON L.Cod_Producto = DV.Cod_Producto AND L.Lote = DV.Lote AND L.Cod_Bodega = DV.Cod_Bodega LEFT JOIN ( SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE F.Fecha_Factura <= @FechaCorte AND F.Tipo_Factura = 'Factura' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega ) Fact ON L.Cod_Producto = Fact.Cod_Producto AND L.Lote = Fact.Lote AND L.Cod_Bodega = Fact.Cod_Bodega LEFT JOIN ( SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE F.Fecha_Factura <= @FechaCorte AND F.Tipo_Factura = 'Salida Bodega' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega ) SB ON L.Cod_Producto = SB.Cod_Producto AND L.Lote = SB.Lote AND L.Cod_Bodega = SB.Cod_Bodega LEFT JOIN ( SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad FROM Detalle_Facturas DF INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura AND DF.Fecha_Factura = F.Fecha_Factura AND DF.Tipo_Factura = F.Tipo_Factura WHERE F.Fecha_Factura <= @FechaCorte AND F.Tipo_Factura = 'Transferencia Enviada' AND DF.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,''), F.Cod_Bodega ) TE ON L.Cod_Producto = TE.Cod_Producto AND L.Lote = TE.Lote AND L.Cod_Bodega = TE.Cod_Bodega LEFT JOIN ( SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad FROM Detalle_Compras DC INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra AND DC.Fecha_Compra = C.Fecha_Compra AND DC.Tipo_Compra = C.Tipo_Compra WHERE C.Fecha_Compra <= @FechaCorte AND C.Tipo_Compra = 'Devolucion de Compra' AND DC.Cod_Producto BETWEEN @CodProductoDesde AND @CodProductoHasta AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,''), C.Cod_Bodega ) DC ON L.Cod_Producto = DC.Cod_Producto AND L.Lote = DC.Lote AND L.Cod_Bodega = DC.Cod_Bodega ), LoteMasViejo AS ( SELECT *, ROW_NUMBER() OVER (PARTITION BY Cod_Producto, Cod_Bodega ORDER BY Fecha_Vencimiento ASC) AS rn FROM Existencias WHERE Existencia > 0 AND Fecha_Vencimiento IS NOT NULL ) SELECT * FROM LoteMasViejo WHERE rn = 1 ORDER BY Cod_Producto, Cod_Bodega, Fecha_Vencimiento;"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)

        '' Parámetros obligatorios
        'DataAdapter.SelectCommand.Parameters.AddWithValue("@FechaCorte", FechaVenceLote)
        'DataAdapter.SelectCommand.Parameters.AddWithValue("@CodBodegaDesde", CodigoBodega)
        'DataAdapter.SelectCommand.Parameters.AddWithValue("@CodBodegaHasta", CodigoBodega)
        'DataAdapter.SelectCommand.Parameters.AddWithValue("@CodProductoDesde", CodigoProducto)
        'DataAdapter.SelectCommand.Parameters.AddWithValue("@CodProductoHasta", CodigoProducto)

        'DataAdapter.Fill(DataSet, "Lotes")

        'If DataSet.Tables("Lotes").Rows.Count <> 0 Then
        '    NumeroLote = DataSet.Tables("Lotes").Rows(0)("Lote")
        'End If



        'Return NumeroLote

    End Function

    '//////////////////////////////////HILOS PARA INSERTAR REGISTROS ////////////////////
    Private Sub backgroundWorkerInsertar_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerInsertar.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim args As TablaFactura = e.Argument
        Dim NumeroFactura As String = args.Numero_Factura
        Dim fechaFactura As Date = args.Fecha_Factura




        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            'e.Result = BuscaExistenciaBodegaWoker(CodigoProducto, CodigoBodega, CostoProductoD, CostoProducto, worker, e)
            InsertarRegistrosWorker(args, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerInsertar_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerInsertar.RunWorkerCompleted
        Dim Argumentos As New ClaseFactura
        Dim ComandoUpdate As New SqlClient.SqlCommand, StrSqlUpdate As String, iResulteado As Integer




        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Productos", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Productos", "Hilo Cancelado")
        Else

            SalirFactura = False

            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True

            ActualizaMETODOFactura()



            Me.TrueDBGridComponentes.Col = 0
            Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.RowCount

            If Acceso <> "Administrador" Then
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////BLOQUEO LOS PRECIOS DESPUES DE ACTUALIZAR////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If Me.CboTipoProducto.Text = "Cotizacion" Then
                    If FacturaTarea = True Then
                        Me.GroupBox3.Enabled = False
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                    Else
                        Me.GroupBox3.Enabled = False
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                    End If
                Else
                    If FacturaTarea = True Then
                        Me.GroupBox3.Enabled = True
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                    Else
                        Me.GroupBox3.Enabled = True
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                    End If

                End If
            End If


        End If

    End Sub

    Public Sub InsertarRegistrosWorker(Factura As TablaFactura, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)

        Dim cod As String = "1"

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaFacturas(Factura)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'InsertarRowGrid()
        InsertarRowGrid_Hilos(Factura)


    End Sub


    Public Sub CalcularSaldoCliente()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQlString As String, NumeroFactura As String, NumeroRecibo As String = "", MontoRecibo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, TasaCambio As Double, Saldo As Double
        Dim MontoFactura As Double, FechaFactura As Date, Dias As Double, TasaInteres As Double, MontoMora As Double, Total As Double
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double, TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, FechaVence As Date, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        Dim MontoMetodoFactura As Double = 0, TipoNota As String = "", TasaCmbio As Double
        'oDataRow As DataRow, 


        If CodigoCliente = "" Then
            Exit Sub
        End If

        'Moneda = Me.TxtMonedaFactura.Text

        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        'DataSet.Reset()
        'DatasetReporte.Reset()
        'SQlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.MetodoPago As Numero_Recibo, Facturas.Numero_Factura As NotaDebito, Facturas.SubTotal As MontoNota, Facturas.SubTotal As Monto, Facturas.Fecha_Factura As FechaVence, Facturas.IVA As Abono, Facturas.SubTotal AS Saldo, Facturas.SubTotal As Moratorio, Facturas.SubTotal As Dias, Facturas.SubTotal AS Total  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
        '            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DatasetReporte, "TotalVentas")


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT *  FROM Facturas WHERE (MetodoPago = 'Credito') AND (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & codigocliente  & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        SQlString = "SELECT *  FROM Facturas WHERE (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & CodigoCliente & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        Registros = DataSet.Tables("Clientes").Rows.Count
        i = 0
        TotalFactura = 0
        TotalAbonos = 0
        TotalMora = 0
        TotalCargos = 0
        TotalMontoNotaDB = 0
        TotalMontoNotaCR = 0

        Do While Registros > i
            NumeroRecibo = ""
            MontoRecibo = 0

            My.Application.DoEvents()

            TasaCambio = BuscaTasaCambio(DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"))

            If Moneda = "Cordobas" Then
                If DataSet.Tables("Clientes").Rows(i)("MonedaFactura") = "Cordobas" Then
                    TasaCambio = 1
                Else
                    If TasaCambio <> 0 Then
                        TasaCambio = BuscaTasaCambio(DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"))
                    Else
                        TasaCambio = 1
                    End If
                End If
            Else
                If DataSet.Tables("Clientes").Rows(i)("MonedaFactura") = "Dolares" Then
                    TasaCambio = 1
                Else
                    If TasaCambio <> 0 Then
                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"))
                    Else
                        TasaCambio = 1
                    End If
                End If
            End If

            NumeroFactura = DataSet.Tables("Clientes").Rows(i)("Numero_Factura")
            FechaFactura = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            FechaVence = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            'Me.Text = "Procesando Factura No " & NumeroFactura

            If NumeroFactura = "01200" Then
                NumeroFactura = "01200"
            End If

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
            '            "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & codigocliente  & "')"

            'SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE  (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente, DetalleRecibo.Fecha_Recibo HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & codigocliente  & "')"
            'SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & codigocliente & "')"

            SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (Recibo.Cod_Cliente = '" & CodigoCliente & "') AND (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND " & _
                         "(DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') "

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            Registros2 = DataSet.Tables("Recibos").Rows.Count
            j = 0

            Do While Registros2 > j


                TasaCambio = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))

                If Moneda = "Cordobas" Then
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = TasaCambio
                    End If
                Else
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                        TasaCambioRecibo = 1
                    ElseIf TasaCambio <> 0 Then
                        TasaCambioRecibo = 1 / TasaCambio
                    Else
                        TasaCambioRecibo = 1
                    End If
                End If
                If NumeroRecibo = "" Then
                    NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                Else
                    NumeroRecibo = NumeroRecibo & "," & DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                End If
                MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

                j = j + 1
            Loop

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (NotaDebito.Tipo LIKE '%Debito Clientes%') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaDB")
            Registros2 = DataSet.Tables("NotaDB").Rows.Count
            NumeroNota = ""
            j = 0
            MontoNota = 0
            TotalMontoNotaDB = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaDB").Rows(j)("Tipo")
                TasaCambio = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))

                If Moneda = "Cordobas" Then
                    If TipoNota <> "Debito Clientes Dif $" Then
                        If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                            TasaCambioRecibo = 1
                        ElseIf TasaCambio <> 0 Then
                            TasaCambioRecibo = TasaCambio
                        Else
                            TasaCambioRecibo = 1
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                Else
                    If TipoNota <> "Debito Clientes Dif C$" Then
                        If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                            TasaCambioRecibo = 1
                        ElseIf TasaCambio <> 0 Then
                            TasaCambioRecibo = 1 / TasaCambio
                        Else
                            TasaCambioRecibo = 1
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                End If


                If NumeroNota = "" Then
                    NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                Else
                    NumeroNota = NumeroNota & "," & DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                End If
                MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaDB = TotalMontoNotaDB + MontoNota
                j = j + 1
            Loop

            DataSet.Tables("NotaDB").Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (Detalle_Nota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (NotaDebito.Tipo LIKE '%Credito Clientes%') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaCR")
            Registros2 = DataSet.Tables("NotaCR").Rows.Count
            NumeroNotaCR = ""
            j = 0
            MontoNotaCR = 0
            TotalMontoNotaCR = 0
            Do While Registros2 > j

                TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")
                TasaCambio = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))

                If Moneda = "Cordobas" Then
                    If TipoNota <> "Credito Clientes Dif $" Then
                        If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                            TasaCambioRecibo = 1
                        ElseIf TasaCambio <> 0 Then
                            TasaCambioRecibo = TasaCambio
                        Else
                            TasaCambioRecibo = 1
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                Else
                    If TipoNota <> "Credito Clientes Dif C$" Then
                        If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                            TasaCambioRecibo = 1
                        ElseIf TasaCambio <> 0 Then
                            TasaCambioRecibo = 1 / TasaCambio
                        Else
                            TasaCambioRecibo = 1
                        End If
                    Else
                        TasaCambioRecibo = 0
                    End If
                End If


                If NumeroNotaCR = "" Then
                    NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                Else
                    NumeroNotaCR = NumeroNotaCR & "," & DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                End If
                MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                'MontoNotaCR +
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MontoMetodoFactura = 0
            SQlString = "SELECT * FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "MetodoFactura")
            If DataSet.Tables("MetodoFactura").Rows.Count <> 0 Then

                TasaCambio = BuscaTasaCambio(DataSet.Tables("MetodoFactura").Rows(0)("Fecha_Factura"))

                If Moneda = "Cordobas" Then
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    ElseIf TasaCambio <> 0 Then
                        TasaCambioRecibo = TasaCambio
                    Else
                        TasaCambioRecibo = 1
                    End If
                Else
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Dolares" Then
                        TasaCambioRecibo = 1
                    ElseIf TasaCambio <> 0 Then
                        TasaCambioRecibo = 1 / TasaCambio
                    Else
                        TasaCambioRecibo = 1
                    End If
                End If

                MontoMetodoFactura = DataSet.Tables("MetodoFactura").Rows(0)("Monto") * TasaCambioRecibo

            End If
            DataSet.Tables("MetodoFactura").Reset()






            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL INTERES MORATORIO PARA ESTE CLIENTE //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT  * FROM Clientes WHERE (Cod_Cliente = '" & CodigoCliente & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "DatosCliente")
            If Not DataSet.Tables("DatosCliente").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio")) Then
                    TasaInteres = (DataSet.Tables("DatosCliente").Rows(0)("InteresMoratorio") / 100)
                End If
            End If

            MontoFactura = (DataSet.Tables("Clientes").Rows(i)("SubTotal") + DataSet.Tables("Clientes").Rows(i)("IVA")) * TasaCambio



            Dias = DateDiff(DateInterval.Day, FechaVence, FechaFin)
            Saldo = MontoFactura - MontoRecibo + TotalMontoNotaDB - TotalMontoNotaCR - MontoMetodoFactura
            If Format(Saldo, "##,##0.00") = "0.00" Then
                Dias = 0
            End If

            If Dias < 0 Then
                Dias = 0
            End If

            MontoMora = Dias * Saldo * TasaInteres
            Total = Saldo + MontoMora

            'oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            'oDataRow("Fecha_Factura") = DataSet.Tables("Clientes").Rows(i)("Fecha_Factura")
            'oDataRow("Numero_Factura") = DataSet.Tables("Clientes").Rows(i)("Numero_Factura")
            'oDataRow("Numero_Recibo") = NumeroRecibo
            'If NumeroNota = "" Then
            '    If NumeroNotaCR <> "" Then
            '        oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
            '    End If
            'ElseIf NumeroNotaCR = "" Then
            '    If NumeroNota <> "" Then
            '        oDataRow("NotaDebito") = "NB:" & NumeroNota
            '    End If
            'Else
            '    oDataRow("NotaDebito") = "NC:" & NumeroNotaCR & " NB:" & NumeroNota
            'End If
            'oDataRow("Monto") = Format(MontoFactura, "##,##0.00")
            'oDataRow("FechaVence") = DataSet.Tables("Clientes").Rows(i)("Fecha_Vencimiento")
            'oDataRow("Abono") = Format(MontoRecibo + MontoMetodoFactura, "##,##0.00")
            'oDataRow("MontoNota") = Format(TotalMontoNotaDB - TotalMontoNotaCR, "##,##0.00")
            'oDataRow("Saldo") = Format(Saldo, "##,##0.00")
            'oDataRow("Moratorio") = Format(MontoMora, "##,##0.00")
            'oDataRow("Dias") = Dias
            'oDataRow("Total") = Format(Total, "##,##0.00")
            'DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            If Moneda = "Cordobas" Then
                ActualizaMontoCredito(DataSet.Tables("Clientes").Rows(i)("Numero_Factura"), DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"), Saldo, "Cordobas")
            Else
                ActualizaMontoCredito(DataSet.Tables("Clientes").Rows(i)("Numero_Factura"), DataSet.Tables("Clientes").Rows(i)("Fecha_Factura"), Saldo, "Dolares")
            End If



            i = i + 1


            TotalFactura = TotalFactura + Saldo
            TotalAbonos = TotalAbonos + MontoRecibo
            TotalCargos = TotalCargos + MontoFactura
            TotalMora = TotalMora + MontoMora
            DataSet.Tables("DatosCliente").Reset()
            DataSet.Tables("Recibos").Reset()
        Loop


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Debito Clientes%') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDB")
        Registros2 = DataSet.Tables("NotaDB").Rows.Count
        NumeroNota = ""
        j = 0
        MontoNota = 0
        Do While Registros2 > j

            TipoNota = DataSet.Tables("NotaDB").Rows(j)("Tipo")

            If Moneda = "Cordobas" Then
                If TipoNota <> "Debito Clientes Dif $" Then
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            Else
                If TipoNota <> "Debito Clientes Dif C$" Then
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            End If

            If NumeroNota = "" Then
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            Else
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            End If
            MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            Dim Abono As Double = 0, AbonoNota As Double = 0

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA NOTA DE DEBITO ///////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If Moneda = "Cordobas" Then
                Abono = MontoReciboNotas(NumeroNota, "Cordobas")
            Else
                Abono = MontoReciboNotas(NumeroNota, "Dolares")
            End If

            If CadenaRecibo = "" Then
                CadenaRecibo = "0000"
            End If

            RefNotaDebito = ""
            '////////////////////////////////////BUSCO SI EXISTEN NOTAS PARA LA NOTA DE DEBITO /////////////////////////
            If Moneda = "Cordobas" Then
                AbonoNota = MontoNotaCreditoNota(NumeroNota, "Cordobas", CodigoCliente, NumeroNota)
            Else
                AbonoNota = MontoNotaCreditoNota(NumeroNota, "Dolares", CodigoCliente, NumeroNota)
            End If


            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"), FechaFin)

            'oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            'oDataRow("Fecha_Factura") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            'oDataRow("Numero_Factura") = "0000"
            'oDataRow("Numero_Recibo") = CadenaRecibo
            'oDataRow("NotaDebito") = "NB:" & NumeroNota & RefNotaDebito
            'oDataRow("Monto") = "0"
            'oDataRow("FechaVence") = DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota")
            'oDataRow("Abono") = Abono
            'oDataRow("MontoNota") = Format(MontoNota, "##,##0.00")
            'oDataRow("Saldo") = Format(MontoNota - Abono, "##,##0.00")
            'oDataRow("Moratorio") = "0"
            'oDataRow("Dias") = Dias
            'oDataRow("Total") = Format(MontoNota - Abono, "##,##0.00")
            'DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)


            TotalFactura = TotalFactura + MontoNota

            j = j + 1
        Loop

        DataSet.Tables("NotaDB").Reset()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo LIKE '%Credito Clientes%') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCR")
        Registros2 = DataSet.Tables("NotaCR").Rows.Count
        NumeroNotaCR = ""
        j = 0
        MontoNotaCR = 0
        Do While Registros2 > j

            TipoNota = DataSet.Tables("NotaCR").Rows(j)("Tipo")

            If Moneda = "Cordobas" Then
                If TipoNota <> "Credito Clientes Dif $" Then
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            Else
                If TipoNota <> "Credito Clientes Dif C$" Then
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    TasaCambioRecibo = 0
                End If
            End If

            If NumeroNotaCR = "" Then
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            Else
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            End If
            MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR

            'MontoNotaCR +

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"), FechaFin)

            'oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            'oDataRow("Fecha_Factura") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            'oDataRow("Numero_Factura") = "0000"
            'oDataRow("Numero_Recibo") = "0000"
            'oDataRow("NotaDebito") = "NC:" & NumeroNotaCR
            'oDataRow("Monto") = "0"
            'oDataRow("FechaVence") = DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota")
            'oDataRow("Abono") = "0"
            'oDataRow("MontoNota") = Format(-1 * MontoNotaCR, "##,##0.00")
            'oDataRow("Saldo") = Format(-1 * MontoNotaCR, "##,##0.00")
            'oDataRow("Moratorio") = "0"
            'oDataRow("Dias") = Dias
            'oDataRow("Total") = Format(-1 * MontoNotaCR, "##,##0.00")
            'DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            TotalFactura = TotalFactura - MontoNotaCR

            j = j + 1
        Loop
        DataSet.Tables("NotaCR").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
        '            "HAVING (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & codigocliente  & "')"

        SQlString = "SELECT  DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, Recibo.MonedaRecibo FROM  DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo WHERE (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & CodigoCliente & "') ORDER BY DetalleRecibo.Fecha_Recibo"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "RecibosSF")
        Registros2 = DataSet.Tables("RecibosSF").Rows.Count
        j = 0
        MontoRecibo = 0

        Do While Registros2 > j

            If Moneda = "Cordobas" Then
                If DataSet.Tables("RecibosSF").Rows(j)("MonedaRecibo") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"))
                End If
            Else
                If DataSet.Tables("RecibosSF").Rows(j)("MonedaRecibo") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"))
                End If
            End If
            If NumeroRecibo = "" Then
                NumeroRecibo = DataSet.Tables("RecibosSF").Rows(j)("CodReciboPago")
            Else
                NumeroRecibo = DataSet.Tables("RecibosSF").Rows(j)("CodReciboPago")
            End If
            MontoRecibo = DataSet.Tables("RecibosSF").Rows(j)("MontoPagado") * TasaCambioRecibo

            Dias = DateDiff(DateInterval.Day, DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo"), FechaFin)

            'oDataRow = DatasetReporte.Tables("TotalVentas").NewRow
            'oDataRow("Fecha_Factura") = DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo")
            'oDataRow("Numero_Factura") = "0000"
            'oDataRow("Numero_Recibo") = NumeroRecibo
            'oDataRow("Monto") = "0"
            'oDataRow("FechaVence") = DataSet.Tables("RecibosSF").Rows(j)("Fecha_Recibo")
            'oDataRow("Abono") = Format(MontoRecibo, "##,##0.00")
            'oDataRow("MontoNota") = "0"
            'oDataRow("Saldo") = Format(-1 * MontoRecibo, "##,##0.00")
            'oDataRow("Moratorio") = "0"
            'oDataRow("Dias") = Dias
            'oDataRow("Total") = Format(-1 * MontoRecibo, "##,##0.00")
            'DatasetReporte.Tables("TotalVentas").Rows.Add(oDataRow)

            TotalAbonos = TotalAbonos + MontoRecibo
            TotalFactura = TotalFactura - MontoRecibo
            j = j + 1
        Loop



        'Me.TxtCargos.Text = Format(TotalCargos, "##,##0.00")
        'Me.TxtAbonos.Text = Format(TotalAbonos, "##,##0.00")
        'Me.TxtMora.Text = Format(TotalMora, "##,##0.00")
        'Me.TxtNB.Text = Format(TotalMontoNotaDB - TotalMontoNotaCR, "##,##0.00")
        'Me.TxtSaldoFinal.Text = Format(TotalFactura, "##,##0.00")

        SaldoClienteH = TotalFactura
        oHebraCliente.Abort()

    End Sub


    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleFactura").AcceptChanges()
            da.Update(ds.Tables("DetalleFactura"))

            ActualizarGridInsertRow()

            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleFactura").AcceptChanges()
                da.Update(ds.Tables("DetalleFactura"))
            End If
        End If

        ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


    End Sub
    Public Sub ActualizarGridInsertRow()
        Dim SqlCompras As String, TipoFactura As String

        TipoFactura = Me.CboTipoProducto.Text


        If FacturaTarea = True Then
            ds.Tables("DetalleFactura").Reset()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
            '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
            'Detalle_Facturas.id_Detalle_Factura
            SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura ,Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " & _
                                                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND  (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlCompras, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Visible = False
            ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False



        ElseIf FacturaLotes = True Then

            ds.Tables("DetalleFactura").Reset()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
            '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
            'Detalle_Facturas.id_Detalle_Factura
            SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " & _
                                                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND  (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlCompras, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
        Else
            '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
            'Detalle_Facturas.id_Detalle_Factura
            SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM  Detalle_Facturas " & _
                         "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas " & _
            '    "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFacturas")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
            ds = New DataSet
            da = New SqlDataAdapter(SqlCompras, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False


        End If

    End Sub

    Public Sub DataAdapterRefresh()
        Dim SqlString As String, Fecha As String, TipoFactura As String

        If FacturaTarea = True Then


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura,Detalle_Facturas.Numero_Lote, Detalle_Facturas.Fecha_Vence  FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 63
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 227
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
            Me.TrueDBGridComponentes.Columns(3).Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 54
            Me.TrueDBGridComponentes.Columns(4).Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 62
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Columns(5).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 43
            Me.TrueDBGridComponentes.Columns(5).DefaultValue = 0
            Me.TrueDBGridComponentes.Columns(6).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Columns(7).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Visible = False

        ElseIf FacturaLotes = True Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Numero_Lote, Detalle_Facturas.Fecha_Vence FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 63
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 227
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Columns(2).Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
            Me.TrueDBGridComponentes.Columns(3).Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 54
            Me.TrueDBGridComponentes.Columns(4).Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 62
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            Me.TrueDBGridComponentes.Columns(5).Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 43
            Me.TrueDBGridComponentes.Columns(5).DefaultValue = 0
            Me.TrueDBGridComponentes.Columns(6).Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
            Me.TrueDBGridComponentes.Columns(7).Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Visible = False


        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            'ds.Tables("DetalleFactura").Reset()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas " & _
                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False


        End If
    End Sub




    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String


        Me.Label16.Text = "Referencia"
        Me.CboReferencia.Visible = True

        Me.BtnFacturas.Visible = False
        Me.TxtNumeroFactura.Visible = False


        Me.BtnSalida.Visible = False
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA FACTURA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If


        If Me.CboTipoProducto.Text <> "" Then
            Me.TrueDBGridComponentes.Enabled = True
        End If
        Me.TxtMonedaFactura.Enabled = True
        Me.CmdFacturar.Visible = True

        If Me.CboTipoProducto.Text = "Salida Bodega" Then
            Me.GroupBox3.Enabled = True
            Me.OptExsonerado.Checked = True
            Me.OptExsonerado.Enabled = True
            Me.TxtMonedaFactura.Text = "Cordobas"
            Me.TxtMonedaFactura.Enabled = False

        Else
            Me.OptExsonerado.Checked = False
            Me.OptExsonerado.Enabled = True
            Me.TxtMonedaFactura.Enabled = True
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


        Else
            Me.CmdFacturar.Enabled = False
        End If

        If Me.CboTipoProducto.Text = "Devolucion de Venta" Then
            Me.GroupBox3.Enabled = True
            Me.TxtMonedaFactura.Text = "Cordobas"
            Me.TxtMonedaFactura.Enabled = False
            Me.Label16.Text = "Factura No"
            Me.CboReferencia.Visible = False
            Me.BtnFacturas.Visible = True
            Me.TxtNumeroFactura.Visible = True
        End If

        If Me.CboTipoProducto.Text = "Orden de Trabajo" Then
            Me.GroupBox3.Enabled = True
            Me.OptExsonerado.Checked = True
            Me.OptExsonerado.Enabled = True
            Me.TxtMonedaFactura.Text = "Cordobas"
            Me.TxtMonedaFactura.Enabled = False
            Me.BtnSalida.Visible = True

        End If

        Select Case Me.CboTipoProducto.Text
            Case "Factura" : Bloqueo(Me, Acceso, "Facturacion")
            Case "Cotizacion" : Bloqueo(Me, Acceso, "Cotizacion")
            Case "Devolucion de Venta" : Bloqueo(Me, Acceso, "Devolucion de Venta")
            Case "Salida Bodega" : Bloqueo(Me, Acceso, "Salida Bodega")
            Case "Orden de Trabajo" : Bloqueo(Me, Acceso, "Salida Bodega")
        End Select

    End Sub

        Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
            Me.Close()
        End Sub

        Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
            Dim Sqlstring As String, EfectivoDefecto As Boolean = False
            Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
            Dim oDataRow As DataRow, iPosicion3 As Double = 0

            'If Me.TxtSubTotal.Text = "" Then
            '    MsgBox("Seleccione un Producto primero", MsgBoxStyle.Critical, "Zeus Facturacion")
            '    Me.RadioButton1.Checked = True
            '    Exit Sub
            'End If

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sqlstring = "SELECT  * FROM DatosEmpresa "
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
            If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
                '        '*************************************************************************************************************************
                '        '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
                '        '**************************************************************************************************************************
                Sqlstring = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & Me.TxtMonedaFactura.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "Metodo")
                If DataSet.Tables("Metodo").Rows.Count <> 0 Then
                    '************************************************************************************************************************
                    '  ///////////////////////////AGREO LA FORMA DE PAGO DEL TOTAL //////////////////////////////////////////////////////////
                    '*************************************************************************************************************************
                    Sqlstring = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")

                    oDataRow = DataSet.Tables("MetodoPago").NewRow
                    oDataRow("NombrePago") = DataSet.Tables("Metodo").Rows(0)("NombrePago")
                    If Me.TxtNetoPagar.Text <> "" Then
                        oDataRow("Monto") = Redondeo(Me.SubTotalGral + Me.IvaGral, 3)
                    Else
                        oDataRow("Monto") = 0
                    End If
                    oDataRow("NumeroTarjeta") = 0
                    oDataRow("FechaVence") = Me.DTVencimiento.Value
                    DataSet.Tables("MetodoPago").Rows.Add(oDataRow)

                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    dsMetodo = DataSet.Copy
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False



                End If


            Else

                Sqlstring = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "Clientes")
                If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                    If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Efectivo")) Then
                        If DataSet.Tables("Clientes").Rows(0)("Efectivo") = "True" Then

                            '        '*************************************************************************************************************************
                            '        '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
                            '        '**************************************************************************************************************************
                            Sqlstring = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & Me.TxtMonedaFactura.Text & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                            DataAdapter.Fill(DataSet, "Metodo")
                            If DataSet.Tables("Metodo").Rows.Count <> 0 Then
                                '************************************************************************************************************************
                                '  ///////////////////////////AGREO LA FORMA DE PAGO DEL TOTAL //////////////////////////////////////////////////////////
                                '*************************************************************************************************************************
                                Sqlstring = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
                                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                                DataAdapter.Fill(DataSet, "MetodoPago")

                                oDataRow = DataSet.Tables("MetodoPago").NewRow
                                oDataRow("NombrePago") = DataSet.Tables("Metodo").Rows(0)("NombrePago")
                                If Me.TxtNetoPagar.Text <> "" Then
                                    oDataRow("Monto") = Me.TxtNetoPagar.Text
                                Else
                                    oDataRow("Monto") = 0
                                End If
                                oDataRow("NumeroTarjeta") = 0
                                oDataRow("FechaVence") = Me.DTVencimiento.Value
                                DataSet.Tables("MetodoPago").Rows.Add(oDataRow)

                                Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                                Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                                dsMetodo = DataSet.Copy
                                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                                Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                                Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False



                            End If


                        Else

                            If Me.TxtSubTotal.Text = "" Then
                                MsgBox("Seleccione un Producto primero", MsgBoxStyle.Critical, "Zeus Facturacion")
                                Me.RadioButton1.Checked = True
                                Exit Sub
                            End If

                        End If
                    End If
                End If





            End If

            End If

            ActualizaMETODOFactura()

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

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridComponentes.Enabled = True
            Me.TrueDBGridComponentes.Focus()
        End If

    End Sub

    Private Sub TxtCodigoClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoClientes.KeyDown

        If e.KeyCode = Keys.Enter Then
            Me.TrueDBGridComponentes.Enabled = True
            Me.TrueDBGridComponentes.Focus()
        End If

    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged

        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaCredito As DateTime = Me.DTPFecha.Value, DiasCredito As Double = 0, CausaIva As Boolean = True
        Dim SqlString As String = ""

        Try

            '/////////////////////////Cierro las herabas abiertas/////////////////
            If Not (oHebraCliente Is Nothing) Then
                If oHebraCliente.IsAlive Then
                    oHebraCliente.Abort()
                End If
            End If

            CambioCliente = True

            SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then

                CodigoCliente = Me.TxtCodigoClientes.Text
                FechaFin = Me.DTPFecha.Value
                Moneda = Me.TxtMonedaFactura.Text

                '//////////////////////////GENERO UNA NUEVA HEBRA ////////////////////////////////////////////
                oHebraCliente = New Thread(AddressOf CalcularSaldoCliente)
                oHebraCliente.Start()

                Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")

                BloqueoLimiteCredito = False
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("BloquearPorLimiteCredito")) Then
                    BloqueoLimiteCredito = DataSet.Tables("Clientes").Rows(0)("BloquearPorLimiteCredito")
                Else
                    BloqueoLimiteCredito = False
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Limite_Credito")) Then
                    LimiteCredito = DataSet.Tables("Clientes").Rows(0)("Limite_Credito")
                Else
                    LimiteCredito = 0
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("MonedaCredito")) Then
                    MonedaLimiteCredito = DataSet.Tables("Clientes").Rows(0)("MonedaCredito")
                Else
                    MonedaLimiteCredito = Me.TxtMonedaFactura.Text
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CausaIva")) Then
                    CausaIva = DataSet.Tables("Clientes").Rows(0)("CausaIva")
                End If

                If CausaIva = True Then
                    Me.OptExsonerado.Checked = False
                Else
                    Me.OptExsonerado.Checked = True
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("DiasCredito")) Then
                    DiasCredito = DataSet.Tables("Clientes").Rows(0)("DiasCredito")
                End If

                If Quien <> "MostrarFactura" Then
                    If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CodVendedor")) Then
                        If DataSet.Tables("Clientes").Rows(0)("CodVendedor") <> "" Then
                            Me.CboCodigoVendedor.Text = DataSet.Tables("Clientes").Rows(0)("CodVendedor")
                        End If
                    Else

                        'SqlString = "SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
                        'MiConexion.Open()
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        'DataAdapter.Fill(DataSet, "Vendedor")
                        'If Not DataSet.Tables("Vendedor").Rows.Count = 0 Then
                        '    Me.CboCodigoVendedor.Text = DataSet.Tables("Vendedores").Rows(0)("Cod_Vendedor")
                        'End If
                        'MiConexion.Close()

                    End If
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Efectivo")) Then
                    If DataSet.Tables("Clientes").Rows(0)("Efectivo") = "True" Then
                        Me.RadioButton2.Checked = True
                        Me.RadioButton1.Checked = False
                    Else
                        Me.RadioButton2.Checked = False
                        Me.RadioButton1.Checked = True
                    End If
                End If

                FechaCredito = Me.DTPFecha.Value

                Me.DTVencimiento.Value = FechaCredito.AddDays(DiasCredito)

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

    Private Sub FrmFacturas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Select Case Me.CboTipoProducto.Text
        '    Case "Factura" : Bloqueo(Me, Acceso, "Facturacion")
        '    Case "Cotizacion" : Bloqueo(Me, Acceso, "Cotizacion")
        '    Case "Devolucion de Venta" : Bloqueo(Me, Acceso, "Devolucion de Venta")
        '    Case "Salida Bodega" : Bloqueo(Me, Acceso, "Salida Bodega")
        'End Select

        Me.TxtCodigoClientes.Focus()
    End Sub

    Private Sub FrmFacturas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SalirFactura = False Then
            MsgBox("Existen Cambios en los productos, necesita Grabar la Factura", MsgBoxStyle.Critical, "Zeus Facturacion")
            e.Cancel = True
        Else

            '/////////////////////////Cierro las herabas abiertas/////////////////
            If Not (oHebraCliente Is Nothing) Then
                If oHebraCliente.IsAlive Then
                    oHebraCliente.Abort()
                End If
            End If

        End If


    End Sub

        Private Sub FrmFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String, i As Double = 0

        Me.MinimumSize = Size
        Me.MaximumSize = Size

        PrimerRegistroFactura = True
        SalirFactura = True


        'Sql = "SELECT *  FROM DatosEmpresa "
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataAdapter.Fill(DataSet, "DatosEmpresa")
        'If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
        '    My.Application.DoEvents()


        'End If


        Select Case Acceso
            Case "Vendedores"
                Me.CboTipoProducto.Items.Add("Cotizacion")
                Me.CboTipoProducto.Items.Add("Factura")
                Me.ButtonBorrar.Enabled = False
                Me.CmdProcesar.Enabled = False


            Case Else
                Me.CboTipoProducto.Items.Add("Cotizacion")
                Me.CboTipoProducto.Items.Add("Factura")
                Me.CboTipoProducto.Items.Add("Devolucion de Venta")
                Me.CboTipoProducto.Items.Add("Salida Bodega")
                Me.CboTipoProducto.Items.Add("Orden de Trabajo")
                Me.ButtonBorrar.Enabled = True

        End Select

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.DTVencimiento.Value = Format(Now, "dd/MM/yyyy")
        Me.DTPFechaHora.Value = Format(Now, "dd/MM/yyyy HH:mm")

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

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


        SqlString = "SELECT  * FROM   Bodegas"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas2")
        Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas2")
        If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
            Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
        MiConexion.Close()

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
        Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
        dsMetodo = DataSet.Copy
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False
        MiConexion.Close()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA FACTURA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
            FacturaLotes = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
            ConsecutivoFacturaSerie = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
            PedirCantEscaner = DataSet.Tables("DatosEmpresa").Rows(0)("PedirCantEscaner")


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura") = True Then
                    Me.OptRet1Porciento.Visible = True
                    Me.OptRet2Porciento.Visible = True
                    Me.TxtTelefono.Size = New Size(209, 20)
                Else
                    Me.OptRet1Porciento.Visible = False
                    Me.OptRet2Porciento.Visible = False
                    Me.OptRet1Porciento.Checked = False
                    Me.OptRet2Porciento.Checked = False
                    Me.TxtTelefono.Size = New Size(256, 20)
                    Me.TxtTelefono.Refresh()
                End If

            End If
        End If

        If ConsecutivoFacturaSerie = True Then
            Me.Label3.Location = New System.Drawing.Point(330, 17)
            Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(419, 14)
            Me.Button6.Location = New System.Drawing.Point(491, 10)
            Me.Label13.Location = New System.Drawing.Point(530, 21)
            Me.TxtMonedaFactura.Location = New System.Drawing.Point(615, 17)
            Me.CmbSerie.Visible = True
        Else
            Me.Label3.Location = New System.Drawing.Point(344, 17)
            Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(385, 14)
            Me.Button6.Location = New System.Drawing.Point(467, 10)
            Me.Label13.Location = New System.Drawing.Point(510, 21)
            Me.TxtMonedaFactura.Location = New System.Drawing.Point(595, 17)
            Me.CmbSerie.Visible = False

        End If

        If FacturaTarea = True Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'Detalle_Facturas.id_Detalle_Factura
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura  FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = True
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False

        ElseIf FacturaLotes = True Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'Detalle_Facturas.id_Detalle_Factura
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False


        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'Detalle_Facturas.id_Detalle_Factura
            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'SqlString = "SELECT Detalle_Facturas.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DetalleFactura")
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleFactura")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
            'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False


        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////BUSCO SI TIENE REFERENCIAS GUARDADAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Referencia FROM Facturas WHERE (NOT (Referencia IS NULL)) AND (Referencia <> N'0') AND (Referencia <> N' ')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Referencias")
        i = 0
        If DataSet.Tables("Referencias").Rows.Count <> 0 Then
            Me.CboReferencia.Text = DataSet.Tables("Referencias").Rows(0)("Referencia")

            Do While DataSet.Tables("Referencias").Rows.Count > i
                My.Application.DoEvents()
                Me.CboReferencia.Items.Add(DataSet.Tables("Referencias").Rows(i)("Referencia"))
                i = i + 1
            Loop


        Else

            Me.CboReferencia.Items.Add("Orden de Trabajo")
            Me.CboReferencia.Items.Add("Mantenimiento y Limpieza")
            Me.CboReferencia.Items.Add("Ventas")
            Me.CboReferencia.Items.Add("Correcion de Envases")
            Me.CboReferencia.Items.Add("Re-Empaque de Productos")
            Me.CboReferencia.Items.Add("Uso de control de Calidad")
            Me.CboReferencia.Items.Add("Correcciones")
            Me.CboReferencia.Items.Add("Cambios")
            Me.CboReferencia.Items.Add("Devoluciones")

        End If



        If NombreCliente = "Alumnos" Then
            Me.Label12.Visible = False
            Me.CboCodigoVendedor.Visible = False
        End If

        If UsuarioBodega <> "" Then
            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = True
                Me.Button7.Enabled = True
            End If
        End If

        If UsuarioTipoFactura <> "" Then
            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If
        End If

        If UsuarioTipoSerie <> "" Then
            If UsuarioTipoSerie <> "Ninguna" Then
                Me.CmbSerie.Text = UsuarioTipoSerie
            End If
        End If

        If UsuarioVendedor <> "" Then
            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If
        End If

        If UsuarioCliente <> "" Then
            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM DatosEmpresa "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
            If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
                Me.RadioButton2.Checked = True
            Else
                'Me.RadioButton2.Checked = False
            End If

            If DataSet.Tables("DatosEmpresa").Rows(0)("CalcularPropina") = False Then
                Me.ChkPropina.Visible = False
                Me.TxtPropina.Visible = False
                Me.LblPropina.Visible = False
                Me.LblSubTotal.Location = New Point(221, 469)
                Me.TxtSubTotal.Location = New Point(284, 466)
                Me.LblIVA.Location = New Point(350, 469)
                Me.TxtIva.Location = New Point(379, 466)
                Me.LblPropina.Location = New Point(872, 21)
                Me.TxtPropina.Location = New Point(921, 18)


            Else
                Me.ChkPropina.Visible = True
                Me.ChkPropina.Checked = True
                Me.TxtPropina.Visible = True
                Me.LblPropina.Visible = True
                Me.LblSubTotal.Location = New Point(119, 469)
                Me.TxtSubTotal.Location = New Point(182, 466)
                Me.LblIVA.Location = New Point(248, 469)
                Me.TxtIva.Location = New Point(277, 466)
                Me.LblPropina.Location = New Point(344, 469)
                Me.TxtPropina.Location = New Point(387, 466)

            End If


        End If

        SqlString = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.CboProyecto.DataSource = DataSet.Tables("Proyectos")
            Me.CboProyecto.Splits.Item(0).DisplayColumns("NombreProyectos").Width = 350
        End If


        Me.TxtCodigoClientes.Focus()


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

        Private Sub TrueDBGridMetodo_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.BindingContextChanged

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
            Dim SqlString As String
            Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
            Dim FacturaSerie As Boolean = False


        If SalirFactura = False Then
            MsgBox("Existen Cambios en los productos, necesita Grabar la Factura", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

            LimpiarFacturas()
            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM DatosEmpresa "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
                    Me.RadioButton2.Checked = True
                Else
                    Me.RadioButton2.Checked = False
                End If

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")) Then
                    If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie") = True Then
                        FacturaSerie = True
                    End If
                End If

            End If

            If FacturaSerie = True Then
                Me.CmbSerie.Visible = True
                Me.CmbSerie.Enabled = True
            Else
                Me.CmbSerie.Visible = False
                Me.CmbSerie.Enabled = False
        End If


        Me.ButtonAgregar.Enabled = True




        End Sub
    Private Sub GrabaItemFactura(ByVal IdDetalleFactura As Double)
        Dim iPosicion As Double, Registros As Double, NumeroFactura As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String, CodTarea As String = Nothing
        Dim CodigoProducto As String, SqlDetalle As String
        Dim IdDetalle As Double = -1, Filtro As String
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim TipoNota As String, NumeroNota As String, FechaVence As Date
        Dim Consecutivo As Double, SQlstring As String
        Dim RstCosto As New RstCostoPromedio

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)


        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        CambiarFechaFactura = False
        ActualizaMETODOFactura()
        'GrabaFacturas(NumeroFactura)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        '"ExisteFacturaDifFecha"

        Filtro = ""

        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        Monto = 0

        Filtro = "id_Detalle_Factura = '" & IdDetalleFactura & "'"
        Me.BindingDetalle.Filter = Filtro

        Do While iPosicion < Registros

            My.Application.DoEvents()



            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
            Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
            Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

            Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value

            CostoUnitario = 0
            Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                ''CostoUnitario = CostoPromedio(CodigoProducto)
                'Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
            Else
                If FacturaTarea = True Then
                    'CostoUnitario = CostoPromedio(CodigoProducto)
                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba
                Else
                    'CostoUnitario = CostoPromedio(CodigoProducto)
                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba
                End If
                Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
            End If

            ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


            If CambiarFechaFactura = True Then
                Dim Descripcion_Producto As String, PrecioUnitario As Double, Descuento As String, PrecioNeto As Double, Importe As Double, Cantidad As Double



                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")


                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                Else
                    IdDetalle = -1
                End If

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                    PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                Else
                    PrecioUnitario = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                Else
                    Descuento = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Else
                    PrecioNeto = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Else
                    Importe = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Else
                    Cantidad = 0
                End If

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
                    FechaVence = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
                Else
                    FechaVence = "01/01/1900"
                End If


                If FacturaTarea = True Then
                    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                    Else
                        CodTarea = 0
                    End If
                    GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
                ElseIf FacturaLotes = True Then

                    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                    Else
                        CodTarea = 0
                    End If
                    GrabaDetalleFacturaLotes(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea, FechaVence, Me.CboTipoProducto.Text)

                Else
                    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
                End If

            End If

            iPosicion = iPosicion + 1
        Loop

        If CambiarFechaFactura = False Then

            da.Update(ds.Tables("DetalleFactura"))

        End If

        '''''''''''''''''''''ACTUALIZO EL LISTADO DE INVENTARIO PARA FACTURACION ---------------------------------
        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        Do While iPosicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)
            iPosicion = iPosicion + 1
        Loop


    End Sub


    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click

        Dim iPosicion As Double, Registros As Double, NumeroFactura As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String, CodTarea As String = Nothing
        Dim CodigoProducto As String, SqlDetalle As String
        Dim IdDetalle As Double = -1
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim TipoNota As String, NumeroNota As String, FechaVence As Date
        Dim Consecutivo As Double, SQlstring As String


        'Try


        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        If BloqueoLimiteCredito = True Then
            If SaldoClienteH > LimiteCredito Then
                MsgBox("Limite de Credito Excedido", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            MsgBox("No se puede grabar antes de asignar numero factura", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If BuscaTasaCambio(Me.DTPFecha.Value) = 0 Then
            MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        AgregarFactura()

        'TablaFacturaPublica = New TablaFactura

        'NumeroFactura = Me.TxtNumeroEnsamble.Text

        'TablaFacturaPublica.Numero_Factura = NumeroFactura
        'TablaFacturaPublica.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        'TablaFacturaPublica.Tipo_Factura = CboTipoProducto_Hilos()
        'TablaFacturaPublica.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        'TablaFacturaPublica.Moneda_Factura = TxtMonedaFactura.Text
        'TablaFacturaPublica.Moneda_Imprime = TxtMonedaImprime.Text
        'TablaFacturaPublica.Cod_Cliente = TxtCodigoClientes.Text
        'TablaFacturaPublica.Cod_Vendedor = CboCodigoVendedor.Text
        'TablaFacturaPublica.CodBodega1 = CboCodigoBodega.Text
        'TablaFacturaPublica.Cod_Cajero = CboCajero.Text
        'TablaFacturaPublica.Nombre_Cliente = TxtNombres.Text
        'TablaFacturaPublica.Apellido_Cliente = TxtApellidos.Text
        'TablaFacturaPublica.Direccion_Cliente = TxtDireccion.Text
        'TablaFacturaPublica.Telefono_Cliente = TxtTelefono.Text
        'TablaFacturaPublica.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        'TablaFacturaPublica.Via_Envarque = ""
        'TablaFacturaPublica.SuReferencia1 = CboReferencia.Text
        'TablaFacturaPublica.Nuestra_Referencia = ""
        'TablaFacturaPublica.Codigo_Proyecto = CboProyecto.Text
        'TablaFacturaPublica.Observaciones_Factura = Me.TxtObservaciones.Text

        'If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
        '    TablaFacturaPublica.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        'Else
        '    TablaFacturaPublica.Sub_Total = 0
        'End If

        'If My.Forms.FrmFacturas.IvaGral <> 0 Then
        '    TablaFacturaPublica.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        'Else
        '    TablaFacturaPublica.IVA_Factura = 0
        'End If

        'If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
        '    TablaFacturaPublica.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        'Else
        '    TablaFacturaPublica.Pagado_Factura = 0
        'End If

        'If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
        '    TablaFacturaPublica.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        'Else
        '    TablaFacturaPublica.Neto_Pagar = 0
        'End If

        'If RadioButton1.Checked = True Then
        '    TablaFacturaPublica.Metodo_Pago = "Credito"
        'Else
        '    TablaFacturaPublica.Metodo_Pago = "Contado"
        'End If

        'If OptExsonerado.Checked = True Then
        '    TablaFacturaPublica.Exonerado_Factura = 1
        'Else
        '    TablaFacturaPublica.Exonerado_Factura = 0
        'End If

        'If OptRet1Porciento.Checked = True Then
        '    TablaFacturaPublica.MontoRetencion1_Porciento = TablaFacturaPublica.Sub_Total * 0.01
        '    TablaFacturaPublica.Retener1_Porciento = 1
        'Else
        '    TablaFacturaPublica.MontoRetencion1_Porciento = 0
        '    TablaFacturaPublica.Retener1_Porciento = 0
        'End If

        'If OptRet2Porciento.Checked = True Then
        '    TablaFacturaPublica.MontoRetencion2_Porciento = TablaFacturaPublica.Sub_Total * 0.02
        '    TablaFacturaPublica.Retener2_Porciento = 1
        'Else
        '    TablaFacturaPublica.MontoRetencion2_Porciento = 0
        '    TablaFacturaPublica.Retener2_Porciento = 0
        'End If


        'If Not CboProyecto.Text = "" Then
        '    TablaFacturaPublica.Codigo_Proyecto = CboProyecto.Columns(0).Text
        'End If

        'If CboReferencia.Text <> "" Then
        '    TablaFacturaPublica.Referencia_Factura = CboReferencia.Text
        'End If

        'TablaFacturaPublica.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        'TablaFacturaPublica.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))


        'Dim worker As BackgroundWorker
        'worker = New BackgroundWorker()
        'AddHandler worker.DoWork, AddressOf backgroundWorkerGrabar_DoWork
        'AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerGrabar_RunWorkerCompleted
        'worker.RunWorkerAsync()



        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Cotizacion"
        '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
        '        Case "Factura"
        '            If ConsecutivoFacturaManual = False Then
        '                ConsecutivoFactura = BuscaConsecutivo("Factura")
        '            Else
        '                FrmConsecutivos.ShowDialog()
        '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
        '            End If
        '        Case "Devolucion de Venta"
        '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
        '        Case "Transferencia Enviada"
        '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
        '        Case "Salida Bodega"
        '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")

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

        '    If FacturaBodega = True Then
        '        NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
        '    Else
        '        NumeroFactura = Format(ConsecutivoFactura, "0000#")
        '    End If

        'Else
        '    NumeroFactura = Me.TxtNumeroEnsamble.Text
        'End If


        'NumeroFactura = Format(ConsecutivoFactura, "0000#")

        'NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)

        'NumeroFactura = Me.TxtNumeroEnsamble.Text

        'Dim TablaFactura As TablaFactura = New TablaFactura

        'TablaFactura.Numero_Factura = NumeroFactura
        'TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        'TablaFactura.Tipo_Factura = CboTipoProducto.Text
        'TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        'TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
        'TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
        'TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
        'TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
        'TablaFactura.CodBodega1 = CboCodigoBodega.Text
        'TablaFactura.Cod_Cajero = CboCajero.Text
        'TablaFactura.Nombre_Cliente = TxtNombres.Text
        'TablaFactura.Apellido_Cliente = TxtApellidos.Text
        'TablaFactura.Direccion_Cliente = TxtDireccion.Text
        'TablaFactura.Telefono_Cliente = TxtTelefono.Text
        'TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        'TablaFactura.Via_Envarque = ""
        'TablaFactura.SuReferencia1 = CboReferencia.Text
        'TablaFactura.Nuestra_Referencia = ""
        'TablaFactura.Codigo_Proyecto = CboProyecto.Text

        'If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
        '    TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        'Else
        '    TablaFactura.Sub_Total = 0
        'End If

        'If My.Forms.FrmFacturas.IvaGral <> 0 Then
        '    TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        'Else
        '    TablaFactura.IVA_Factura = 0
        'End If

        'If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
        '    TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        'Else
        '    TablaFactura.Pagado_Factura = 0
        'End If

        'If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
        '    TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        'Else
        '    TablaFactura.Neto_Pagar = 0
        'End If

        'If RadioButton1.Checked = True Then
        '    TablaFactura.Metodo_Pago = "Credito"
        'Else
        '    TablaFactura.Metodo_Pago = "Contado"
        'End If

        'If OptExsonerado.Checked = True Then
        '    TablaFactura.Exonerado_Factura = 1
        'Else
        '    TablaFactura.Exonerado_Factura = 0
        'End If

        'If OptRet1Porciento.Checked = True Then
        '    TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
        '    TablaFactura.Retener1_Porciento = 1
        'Else
        '    TablaFactura.MontoRetencion1_Porciento = 0
        '    TablaFactura.Retener1_Porciento = 0
        'End If

        'If OptRet2Porciento.Checked = True Then
        '    TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
        '    TablaFactura.Retener2_Porciento = 1
        'Else
        '    TablaFactura.MontoRetencion2_Porciento = 0
        '    TablaFactura.Retener2_Porciento = 0
        'End If


        'If Not CboProyecto.Text = "" Then
        '    TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
        'End If

        'If CboReferencia.Text <> "" Then
        '    TablaFactura.Referencia_Factura = CboReferencia.Text
        'End If

        'TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        'TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////

        'CambiarFechaFactura = False
        'ActualizaMETODOFactura()
        'GrabaFacturas(TablaFactura)

        ''If CambiarFechaFactura = True Then
        ''    Me.DTPFecha.Value = FechaFacturacion
        ''End If

        'If CambioCliente = True Then
        '    Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Cambio de Cliente: " & Trim(Me.TxtCodigoClientes.Text) & " " & Me.TxtNumeroEnsamble.Text)
        'End If



        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        ''"ExisteFacturaDifFecha"

        'Registros = Me.BindingDetalle.Count
        ''iPosicion = Me.BindingDetalle.Position

        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0
        'Monto = 0


        'Do While iPosicion < Registros

        '    My.Application.DoEvents()



        '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '    ' ''Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
        '    ' ''Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
        '    ' ''Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

        '    ' ''Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value

        '    ' ''CostoUnitario = 0
        '    ' ''Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario

        '    ' ''If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
        '    ' ''    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
        '    ' ''    'CostoUnitario = CostoPromedio(CodigoProducto)
        '    ' ''    Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
        '    ' ''Else
        '    ' ''    If FacturaTarea = True Then
        '    ' ''        'CostoUnitario = CostoPromedio(CodigoProducto)
        '    ' ''        CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
        '    ' ''    Else
        '    ' ''        'CostoUnitario = CostoPromedio(CodigoProducto)
        '    ' ''        CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
        '    ' ''    End If
        '    ' ''    Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
        '    ' ''End If

        '    'ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


        '    If CambiarFechaFactura = True Then
        '        Dim Descripcion_Producto As String, PrecioUnitario As Double, Descuento As String, PrecioNeto As Double, Importe As Double, Cantidad As Double



        '        Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")


        '        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
        '        '    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
        '        'Else
        '        '    IdDetalle = -1
        '        'End If

        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
        '            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '        Else
        '            PrecioUnitario = 0
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '        Else
        '            Descuento = 0
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
        '            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '        Else
        '            PrecioNeto = 0
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
        '            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '        Else
        '            Importe = 0
        '        End If
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '        Else
        '            Cantidad = 0
        '        End If

        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")) Then
        '            FechaVence = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
        '        Else
        '            FechaVence = "01/01/1900"
        '        End If


        '        If FacturaTarea = True Then
        '            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
        '                CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
        '            Else
        '                CodTarea = 0
        '            End If
        '            GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
        '        ElseIf FacturaLotes = True Then

        '            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
        '                CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
        '            Else
        '                CodTarea = 0
        '            End If
        '            GrabaDetalleFacturaLotes(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea, FechaVence, Me.CboTipoProducto.Text)

        '        Else
        '            GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
        '        End If

        '    End If

        '    'Select Case Me.CboTipoProducto.Text
        '    '    Case "Factura"
        '    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
        '    '        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
        '    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '    '    Case "Devolucion de Venta"
        '    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
        '    '        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
        '    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
        '    'End Select

        '    iPosicion = iPosicion + 1
        'Loop


        'If CambiarFechaFactura = False Then

        '    'InsertarRowGrid()

        'End If

        ''''''''''''''''''''''ACTUALIZO EL LISTADO DE INVENTARIO PARA FACTURACION ---------------------------------
        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0
        'Do While iPosicion < Registros
        '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '    ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)
        '    iPosicion = iPosicion + 1
        'Loop


        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Me.BindingMetodo.MoveFirst()
        'Registros = Me.BindingMetodo.Count
        'iPosicion = 0
        'Monto = 0
        'Do While iPosicion < Registros
        '    My.Application.DoEvents()
        '    If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NombrePago")) Then
        '        NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
        '        Monto = Me.BindingMetodo.Item(iPosicion)("Monto") '+ Monto
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

        '        GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
        '    End If
        '    iPosicion = iPosicion + 1
        'Loop

        'ActualizaMETODOFactura()

        'Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Grabo la Factura: " & Me.TxtNumeroEnsamble.Text)


        'If Me.OptRet1Porciento.Checked = True Then
        '    Dim MontoIr As Double, CodigoNota As String

        '    SQlstring = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%1%%')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
        '    DataAdapter.Fill(DataSet, "Retencion")
        '    If DataSet.Tables("Retencion").Rows.Count <> 0 Then
        '        MontoIr = Me.TxtSubTotal.Text
        '        MontoIr = Format(MontoIr * 0.01, "##,##0.00")
        '        CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
        '    Else
        '        MsgBox("No Existe Nota de Credito para Retencion 1%", MsgBoxStyle.Critical, "Zeus Facturacion")
        '        Me.OptRet1Porciento.Checked = False
        '        MontoIr = 0
        '        CodigoNota = 0
        '    End If
        '    DataSet.Tables("Retencion").Reset()

        '    Consecutivo = BuscaConsecutivo("NotaCredito")
        '    NumeroNota = Format(Consecutivo, "0000#")
        '    GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, MontoIr, Me.TxtMonedaFactura.Text, Me.TxtCodigoClientes.Text, Me.TxtNombres.Text, Me.TxtObservaciones.Text, True, False, False)
        '    'GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
        '    InsertarDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Acutomaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
        'End If

        'If Me.OptRet2Porciento.Checked = True Then
        '    Dim MontoIr As Double, CodigoNota As String

        '    SQlstring = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%2%%')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
        '    DataAdapter.Fill(DataSet, "Retencion")
        '    If DataSet.Tables("Retencion").Rows.Count <> 0 Then
        '        MontoIr = Me.TxtSubTotal.Text
        '        MontoIr = Format(MontoIr * 0.02, "##,##0.00")
        '        CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
        '    Else
        '        MsgBox("No Existe Nota de Credito para Retencion 1%", MsgBoxStyle.Critical, "Zeus Facturacion")
        '        Me.OptRet1Porciento.Checked = False
        '        MontoIr = 0
        '        CodigoNota = 0
        '    End If
        '    DataSet.Tables("Retencion").Reset()



        '    MontoIr = Me.TxtSubTotal.Text

        '    MontoIr = MontoIr * 0.02
        '    Consecutivo = BuscaConsecutivo("NotaCredito")
        '    NumeroNota = Format(Consecutivo, "0000#")

        '    GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, MontoIr, Me.TxtMonedaFactura.Text, Me.TxtCodigoClientes.Text, Me.TxtNombres.Text, Me.TxtObservaciones.Text, True, False, False)
        '    InsertarDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Acutomaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
        '    'GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Factura", Me.TxtNumeroEnsamble.Text, MontoIr)
        'End If


        ''MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
        'LimpiarFacturas()



        Me.Button7.Enabled = True
        Me.CboCodigoBodega.Enabled = True


        If NombreCliente = "Alumnos" Then
            Me.Label12.Visible = False
            Me.CboCodigoVendedor.Visible = False
        End If

        If UsuarioBodega <> "Ninguna" Then
            Me.CboCodigoBodega.Text = UsuarioBodega
            Me.CboCodigoBodega.Enabled = False
            Me.Button7.Enabled = False
        End If

        If UsuarioTipoFactura <> "Ninguna" Then
            Me.CboTipoProducto.Text = UsuarioTipoFactura
        End If

        If UsuarioTipoSerie <> "Ninguna" Then
            Me.CmbSerie.Text = UsuarioTipoSerie
        End If

        If UsuarioVendedor <> "Ninguna" Then
            Me.CboCodigoVendedor.Text = UsuarioVendedor
        End If

        If UsuarioCliente <> "Ninguna" Then
            Me.TxtCodigoClientes.Text = UsuarioCliente
        End If



        SalirFactura = True
        Me.TxtCodigoClientes.Focus()

        'Catch ex As Exception
        '    MsgBox(Err.Description)
        'End Try
    End Sub

        Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
            Quien = "Bodegas"
            My.Forms.FrmConsultas.ShowDialog()
            Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
        End Sub

        Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
            Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
            Dim Fecha As String, Resultado As Double, Existencia As Double = 0
            Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, StrSQLUpdate As String = ""
            Dim SQlProductos As String, iPosicionFila As Double

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
        EjecutarConsulta(SqlCompras)

        SqlCompras = "UPDATE [Detalle_Facturas]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        EjecutarConsulta(SqlCompras)



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            Dim Idetalle As Double = 0, CodigoProducto As String = "", DiferenciaCantidad As Double = 0
            SQlProductos = "SELECT * FROM Detalle_Facturas WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
            DataAdapter.Fill(DataSet, "Detalle")
            MiConexion.Close()
            iPosicionFila = 0
            If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            Do While iPosicionFila < (DataSet.Tables("Detalle").Rows.Count)

                Idetalle = DataSet.Tables("Detalle").Rows(iPosicionFila)("id_Detalle_Factura")
                CodigoProducto = DataSet.Tables("Detalle").Rows(iPosicionFila)("Cod_Producto")
                DiferenciaCantidad = DataSet.Tables("Detalle").Rows(iPosicionFila)("Cantidad") * 1

                'ExistenciasCostos(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)


                'SqlCompras = "UPDATE [Detalle_Facturas]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                '             "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "') "  'AND (id_Detalle_Factura = " & Idetalle & ")
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

                '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
                '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////

                ActualizaExistencia(CodigoProducto)



                iPosicionFila = iPosicionFila + 1
            Loop



            End If

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Elimino la Factura: " & Me.TxtNumeroEnsamble.Text)

            LimpiarFacturas()
            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
            Me.TxtCodigoClientes.Text = UsuarioCliente
            End If

        End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepFacturas As New ArepFacturas, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double, NombrePago As String
        Dim ArepFacturasTiras As New ArepFacturasTiras2, ArepFacturaMediaPagina As New ArepFacturaMedia
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim NumeroFactura As String, MonedaImprime As String, MonedaFactura As String
        Dim TipoImpresion As String, SqlString As String, RutaBD As String, ConexionAccess As String
        Dim ArepCotizacionFoto As New ArepCotizacionFoto, CodTarea As String = Nothing
        Dim ArepOrdenTrabajo As New ArepFacturasTiras
        Dim CodigoProducto As String

        Dim ArepFacturasTareas As New ArepFacturasTareas, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim ArepFacturas2 As New ArepFacturas2, ArepSalidaBodega As New ArepSalidaBodega, Ancho As Double, Largo As Double
        Dim ArepCotizaciones As New ArepCotizaciones, ImprimeFacturaPreview As Boolean = True, CostoUnitario As Double = 0
        Dim RstCosto As New RstCostoPromedio

        Try

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            If BuscaTasaCambio(Me.DTPFecha.Value) = 0 Then
                MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                MsgBox("No se puede grabar antes de asignar numero factura", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            Me.Button2.Enabled = False


            If PermiteEditar(Acceso, Me.CboTipoProducto.Text) = True Then

                'SqlDatos = "SELECT * FROM DatosEmpresa"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                'DataAdapter.Fill(DataSet, "DatosEmpresa")
                'If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                '    ConsecutivoFacturaSerie = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
                'End If




                ''////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                '    Select Case Me.CboTipoProducto.Text
                '        Case "Cotizacion"
                '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                '        Case "Factura"
                '            If ConsecutivoFacturaManual = False Then
                '                ConsecutivoFactura = BuscaConsecutivo("Factura")
                '            Else
                '                FrmConsecutivos.ShowDialog()
                '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
                '            End If
                '        Case "Devolucion de Venta"
                '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                '        Case "Transferencia Enviada"
                '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                '        Case "Salida Bodega"
                '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
                '    End Select

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

                'If FacturaBodega = True Then
                '    NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
                'Else
                '    NumeroFactura = Format(ConsecutivoFactura, "0000#")
                'End If

                'Else
                ''ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
                ''NumeroFactura = Format(ConsecutivoFactura, "0000#")
                'NumeroFactura = Me.TxtNumeroEnsamble.Text
                'End If

                If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                    NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
                Else
                    NumeroFactura = Me.TxtNumeroEnsamble.Text
                End If


                NumeroFactura = Me.TxtNumeroEnsamble.Text

                Dim TablaFactura As TablaFactura = New TablaFactura

                TablaFactura.Numero_Factura = NumeroFactura
                TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                TablaFactura.Tipo_Factura = CboTipoProducto.Text
                TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
                TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
                TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
                TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
                TablaFactura.CodBodega1 = CboCodigoBodega.Text
                TablaFactura.Cod_Cajero = CboCajero.Text
                TablaFactura.Nombre_Cliente = TxtNombres.Text
                TablaFactura.Apellido_Cliente = TxtApellidos.Text
                TablaFactura.Direccion_Cliente = TxtDireccion.Text
                TablaFactura.Telefono_Cliente = TxtTelefono.Text
                TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Via_Envarque = ""
                TablaFactura.SuReferencia1 = CboReferencia.Text
                TablaFactura.Nuestra_Referencia = ""
                TablaFactura.Codigo_Proyecto = CboProyecto.Text
                TablaFactura.Observaciones_Factura = Me.TxtObservaciones.Text




                If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
                    TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
                Else
                    TablaFactura.Sub_Total = 0
                End If

                If My.Forms.FrmFacturas.IvaGral <> 0 Then
                    TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
                Else
                    TablaFactura.IVA_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
                    TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
                Else
                    TablaFactura.Pagado_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
                    TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
                Else
                    TablaFactura.Neto_Pagar = 0
                End If

                If RadioButton1.Checked = True Then
                    TablaFactura.Metodo_Pago = "Credito"
                Else
                    TablaFactura.Metodo_Pago = "Contado"
                End If

                If OptExsonerado.Checked = True Then
                    TablaFactura.Exonerado_Factura = 1
                Else
                    TablaFactura.Exonerado_Factura = 0
                End If

                If OptRet1Porciento.Checked = True Then
                    TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
                    TablaFactura.Retener1_Porciento = 1
                Else
                    TablaFactura.MontoRetencion1_Porciento = 0
                    TablaFactura.Retener1_Porciento = 0
                End If

                If OptRet2Porciento.Checked = True Then
                    TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
                    TablaFactura.Retener2_Porciento = 1
                Else
                    TablaFactura.MontoRetencion2_Porciento = 0
                    TablaFactura.Retener2_Porciento = 0
                End If


                If Not CboProyecto.Text = "" Then
                    TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
                End If

                If CboReferencia.Text <> "" Then
                    TablaFactura.Referencia_Factura = CboReferencia.Text
                End If

                TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
                TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                GrabaFacturas(TablaFactura)

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


                Registros = Me.BindingDetalle.Count
                'iPosicion = Me.BindingDetalle.Position


                Me.BindingDetalle.MoveFirst()
                Registros = Me.BindingDetalle.Count
                iPosicion = 0
                Monto = 0
                Do While iPosicion < Registros

                    My.Application.DoEvents()

                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                    '            IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                    '        Else
                    '            IdDetalle = -1
                    '        End If

                    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
                    'Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
                    'Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
                    'Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
                    Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")


                    ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                    '            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                    '        Else
                    '            PrecioUnitario = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                    '            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                    '        Else
                    '            PrecioNeto = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                    '            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                    '        Else
                    '            Importe = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                    '            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                    '        Else
                    '            Cantidad = 0
                    '        End If

                    CostoUnitario = 0

                    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                        'CostoUnitario = CostoPromedioKardexBodega(CodigoProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)
                        'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        'Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                    Else
                        RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        CostoUnitario = RstCosto.Costo_Cordoba
                        Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                    End If



                    'Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

                    'If FacturaTarea = True Then
                    '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                    '        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                    '    Else
                    '        CodTarea = 0
                    '    End If
                    '    GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
                    'Else
                    '    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
                    'End If

                    'Select Case Me.CboTipoProducto.Text
                    '    Case "Factura"
                    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    '    Case "Devolucion de Venta"
                    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    'End Select

                    iPosicion = iPosicion + 1
                Loop

                da.Update(ds.Tables("DetalleFactura"))
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

                    GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, TablaFactura.Fecha_Factura, TablaFactura.Tipo_Factura)
                    iPosicion = iPosicion + 1
                Loop


            End If

            ''''ActualizaMETODOFactura()

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")

            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                    ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                Else
                    ImprimeFacturaPreview = False
                End If

                'ArepCotizaciones.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepCotizaciones.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                'ArepCotizaciones.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                'ArepCotizaciones.LblMoneda.Text = Me.TxtMonedaImprime.Text
                'ArepCotizaciones.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                'ArepCotizacionFoto.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepCotizacionFoto.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepSalidaBodega.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                'ArepSalidaBodega.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                    ArepFacturasTiras.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    ArepFacturas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    'ArepCotizacionFoto.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturasTareas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturasTiras.LblRuc.Text = "RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepSalidaBodega.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturaMediaPagina.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    'ArepCotizaciones.LblRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                    If Dir(RutaLogo) <> "" Then
                        ArepFacturas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        'ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepFacturasTareas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepFacturasTiras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepSalidaBodega.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        'ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    End If

                End If
            End If

            'ArepFacturasTiras.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text

            'ArepCotizacionFoto.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            'ArepCotizacionFoto.Label1.Text = "Cliente"
            'ArepCotizacionFoto.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepCotizacionFoto.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            'ArepCotizacionFoto.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            'ArepCotizacionFoto.LblTipoCompra.Text = Me.CboTipoProducto.Text
            'ArepCotizacionFoto.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            'ArepCotizacionFoto.LblNombres.Text = Me.TxtNombres.Text
            'ArepCotizacionFoto.LblApellidos.Text = Me.TxtApellidos.Text
            'ArepCotizacionFoto.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            'ArepCotizacionFoto.LblTelefono.Text = Me.TxtTelefono.Text
            'ArepCotizacionFoto.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            'ArepCotizacionFoto.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            'ArepSalidaBodega.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepSalidaBodega.LblCodProveedor.Text = Me.TxtCodigoClientes.Text

            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'ArepCotizaciones.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            'ArepCotizaciones.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepCotizaciones.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            'ArepCotizaciones.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            'ArepCotizaciones.LblNombres.Text = Me.TxtNombres.Text
            'ArepCotizaciones.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            'ArepCotizaciones.LblTelefono.Text = Me.TxtTelefono.Text
            'ArepCotizaciones.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

            ArepFacturaMediaPagina.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas2.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas.Label1.Text = "Cliente"
            ArepFacturaMediaPagina.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturas.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturas.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturaMediaPagina.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturaMediaPagina.LblApellidos.Text = Me.TxtApellidos.Text

            ArepFacturas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturas.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            ArepFacturas2.Label1.Text = "Cliente"
            ArepFacturas2.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturas2.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturas2.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturas2.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturas2.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturas2.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturas2.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturas2.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturas2.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTareas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturasTareas.Label1.Text = "Cliente"
            ArepFacturasTareas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturasTareas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturasTareas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturasTareas.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturasTareas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturasTareas.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturasTareas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturasTareas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturasTareas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturasTareas.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturasTareas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            ArepSalidaBodega.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTiras.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturasTiras.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturasTiras.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturasTiras.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text
            ArepFacturasTiras.LblApellidos.Text = Me.TxtApellidos.Text


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepOrdenTrabajo.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepOrdenTrabajo.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepOrdenTrabajo.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepOrdenTrabajo.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text



            ArepSalidaBodega.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepSalidaBodega.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepSalidaBodega.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepSalidaBodega.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text

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

            'If Val(Me.TxtSubTotal.Text) <> 0 Then
            '    ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblSubTotal.Text = "0.00"
            'End If

            If Val(Me.TxtIva.Text) <> 0 Then
                ArepSalidaBodega.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                ArepSalidaBodega.LblIva.Text = "0.00"
            End If

            'If Val(Me.TxtIva.Text) <> 0 Then
            '    ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblIva.Text = "0.00"
            'End If

            'If Val(Me.TxtPagado.Text) <> 0 Then
            '    ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblPagado.Text = "0.00"
            'End If
            'If Val(Me.TxtNetoPagar.Text) <> 0 Then
            '    ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblTotal.Text = "0.00"
            'End If
            'If Val(Me.TxtDescuento.Text) <> 0 Then
            '    ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblDescuento.Text = "0.00"
            'End If


            If Val(Me.SubTotalGral) <> 0 Then
                'ArepCotizaciones.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPropina.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblSubTotal.Text = Format(CDbl(Me.SubTotalGral) * TasaCambio, "##,##0.00")

            Else
                'ArepCotizaciones.LblSubTotal.Text = "0.00"
                ArepFacturas.LblSubTotal.Text = "0.00"
                ArepFacturas2.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblSubTotal.Text = "0.00"
                ArepSalidaBodega.LblSubTotal.Text = "0.00"
                ArepOrdenTrabajo.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblPropina.Text = "0.00"
                ArepFacturaMediaPagina.LblSubTotal.Text = "0.00"
                ArepFacturasTareas.LblSubTotal.Text = "0.00"
            End If

            If Val(Me.IvaGral) <> 0 Then
                'ArepCotizaciones.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblIva.Text = Format(CDbl(Me.IvaGral) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblIva.Text = "0.00"
                ArepFacturas.LblIva.Text = "0.00"
                ArepFacturas2.LblIva.Text = "0.00"
                ArepFacturasTiras.LblIva.Text = "0.00"
                ArepOrdenTrabajo.LblIva.Text = "0.00"
                ArepFacturaMediaPagina.LblIva.Text = "0.00"
                ArepFacturasTareas.LblIva.Text = "0.00"
            End If

            If Val(Me.TxtPagado.Text) <> 0 Then
                ArepFacturas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblPagado.Text = "0.00"
                ArepFacturas2.LblPagado.Text = "0.00"
                ArepFacturasTiras.LblPagado.Text = "0.00"
                ArepOrdenTrabajo.LblPagado.Text = "0.00"
                ArepFacturaMediaPagina.LblPagado.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"
            End If

            If Val(Me.TxtNetoPagar.Text) <> 0 Then
                'ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblTotal.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(Me.SubTotalGral + Me.IvaGral) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblTotal.Text = "0.00"
                ArepFacturas.LblTotal.Text = "0.00"
                ArepFacturas2.LblTotal.Text = "0.00"
                ArepFacturasTiras.LblTotal.Text = "0.00"
                ArepOrdenTrabajo.LblTotal.Text = "0.00"
                ArepSalidaBodega.LblTotal.Text = "0.00"
                ArepFacturaMediaPagina.LblTotal.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"

            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                ArepFacturas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblDescuento.Text = "0.00"
                ArepFacturas2.LblDescuento.Text = "0.00"
                ArepFacturaMediaPagina.LblDescuento.Text = "0.00"
                ArepFacturasTareas.LblDescuento.Text = "0.00"
            End If


            ArepFacturasTiras.LblTotal1.Text = Format((CDbl(Me.IvaGral) + CDbl(Me.SubTotalGral) + CDbl(Me.TxtPropina.Text)) * TasaCambio, "##,##0.00")
            ArepOrdenTrabajo.LblTotal1.Text = Format((CDbl(Me.IvaGral) + CDbl(Me.SubTotalGral)) * TasaCambio, "##,##0.00")
            ArepSalidaBodega.LblTotal.Text = Format((CDbl(Me.IvaGral) + CDbl(Me.SubTotalGral)) * TasaCambio, "##,##0.00")
            ArepFacturasTareas.LblTotal.Text = Format((CDbl(Me.IvaGral) + CDbl(Me.SubTotalGral)) * TasaCambio, "##,##0.00")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            Me.BindingMetodo.MoveFirst()
            Registros = Me.BindingMetodo.Count
            iPosicion = 0
            Monto = 0
            ArepFacturas.TxtMetodo.Text = "Credito"
            ArepFacturas2.TxtMetodo.Text = "Credito"
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
                ArepFacturas2.TxtMetodo.Text = NombrePago & " " & Monto
                ArepCotizacionFoto.TxtMetodo.Text = NombrePago & " " & Monto

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA SI EXISTEN FORMA DE PAGO///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                If Me.CboTipoProducto.Text <> "Cotizacion" Then
                    SqlCompras = "UPDATE [Facturas]  SET [FechaPago] = '" & Format(Now, "dd/MM/yyyy") & "' " & _
                                 "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                iPosicion = iPosicion + 1
            Loop



            SQlDetalle = ""
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT     Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Facturas.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Facturas.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Facturas.Importe * (1 / TasaCambio.MontoTasa) AS Importe, TasaCambio.MontoTasa, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida,Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Facturas.Descuento * TasaCambio.MontoTasa AS Descuento,Detalle_Facturas.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Facturas.Importe * TasaCambio.MontoTasa AS Importe,TasaCambio.MontoTasa,Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,'" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            NumeroFactura = Me.TxtNumeroEnsamble.Text

            Select Case Me.CboTipoProducto.Text
                Case "Factura"

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////SELECCIONO LA IMPRESORA CONFIGURADA PARA LAS FACTURAS /////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Dim pd As New PrintDocument
                    Dim ImpresoraFactura As String
                    Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

                    Impresora_Defecto = s_Default_Printer
                    ImpresoraFactura = BuscaImpresora("Factura")
                    Establecer_Impresora(ImpresoraFactura)




                    TipoImpresion = Me.CboTipoProducto.Text

                    If Me.CmbSerie.Visible = True Then
                        TipoImpresion = Me.CboTipoProducto.Text & Me.CmbSerie.Text
                    Else
                        TipoImpresion = Me.CboTipoProducto.Text
                    End If

                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco MediaPagina"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturaMediaPagina.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturaMediaPagina.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturaMediaPagina.DataSource = SQL
                                ArepFacturaMediaPagina.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.s_Default_Printer = s_Default_Printer
                                ViewerForm.arvMain.Document = ArepFacturaMediaPagina.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturaMediaPagina.Run(True)
                                Else
                                    ArepFacturaMediaPagina.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If
                            Case "Papel en Blanco, Lotes"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturasTareas.DataSource = SQL
                                ArepFacturasTareas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.s_Default_Printer = s_Default_Printer
                                ViewerForm.arvMain.Document = ArepFacturasTareas.Document
                                'ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturasTareas.Run(True)
                                Else
                                    ArepFacturasTareas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Papel en Blanco, Sin Encabezado"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas2.DataSource = SQL
                                ArepFacturas2.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                ArepFacturas2.LblLetras.Text = Letras(CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtIva.Text), Me.TxtMonedaFactura.Text)

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.s_Default_Printer = s_Default_Printer
                                ViewerForm.arvMain.Document = ArepFacturas2.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas2.Run(True)
                                Else
                                    ArepFacturas2.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Tira de Papel"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                                    ArepOrdenTrabajo.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepOrdenTrabajo.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                ArepFacturasTiras.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepOrdenTrabajo.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturasTiras.DataSource = SQL
                                ArepFacturasTiras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                ArepOrdenTrabajo.DataSource = SQL
                                ArepOrdenTrabajo.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                If MonedaImprime = "Cordobas" Then
                                    ArepFacturasTiras.Simbolo1.Text = "C$"
                                    ArepFacturasTiras.Simbolo2.Text = "C$"
                                    ArepFacturasTiras.Simbolo3.Text = "C$"
                                    ArepFacturasTiras.Simbolo4.Text = "C$"
                                    ArepFacturasTiras.Simbolo5.Text = "C$"

                                    ArepOrdenTrabajo.Simbolo1.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo2.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo3.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo4.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo5.Text = "C$"
                                Else
                                    ArepFacturasTiras.Simbolo1.Text = "$"
                                    ArepFacturasTiras.Simbolo2.Text = "$"
                                    ArepFacturasTiras.Simbolo3.Text = "$"
                                    ArepFacturasTiras.Simbolo4.Text = "$"
                                    ArepFacturasTiras.Simbolo5.Text = "$"

                                    ArepOrdenTrabajo.Simbolo1.Text = "$"
                                    ArepOrdenTrabajo.Simbolo2.Text = "$"
                                    ArepOrdenTrabajo.Simbolo3.Text = "$"
                                    ArepOrdenTrabajo.Simbolo4.Text = "$"
                                    ArepOrdenTrabajo.Simbolo5.Text = "$"
                                End If


                                If Me.CboReferencia.Text = "Orden de Trabajo" Then
                                    Dim ViewerForm As New FrmViewer()
                                    ViewerForm.s_Default_Printer = s_Default_Printer
                                    ViewerForm.arvMain.Document = ArepOrdenTrabajo.Document

                                    'ViewerForm.Show()
                                    'ArepFacturasTiras.Run(True)
                                    If ImprimeFacturaPreview = True Then
                                        ViewerForm.Show()
                                        ArepOrdenTrabajo.Run(True)
                                    Else
                                        ArepOrdenTrabajo.Run(True)
                                        ViewerForm.arvMain.Document.Print(False, False, False)
                                    End If


                                Else
                                    Dim ViewerForm As New FrmViewer()
                                    ViewerForm.s_Default_Printer = s_Default_Printer
                                    ViewerForm.arvMain.Document = ArepFacturasTiras.Document

                                    'ViewerForm.Show()
                                    'ArepFacturasTiras.Run(True)
                                    If ImprimeFacturaPreview = True Then
                                        ViewerForm.Show()
                                        ArepFacturasTiras.Run(True)
                                    Else
                                        ArepFacturasTiras.Run(True)
                                        ViewerForm.arvMain.Document.Print(False, False, False)
                                    End If
                                End If



                                'ArepFacturas.Run(False)
                                'ArepFacturas.Show()
                            Case "Papel en Blanco"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.s_Default_Printer = s_Default_Printer
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas.Run(True)
                                Else
                                    ArepFacturas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Personalizado"


                                TipoImpresion = Me.CboTipoProducto.Text


                                Dim StrSQLUpdate As String
                                Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                Dim DatasetDatos As New DataSet


                                MiConexionAccess.Open()
                                DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & Me.TxtNumeroEnsamble.Text & "' "
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                '///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                                EscribirArchivo()

                                RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                                If Dir(RutaReportes) <> "" Then
                                    Shell(RutaReportes)
                                End If

                        End Select
                    End If

                    'Establecer_Impresora(Impresora_Defecto)

                Case "Cotizacion"
                    TipoImpresion = Me.CboTipoProducto.Text
                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco Membrete"
                                Dim ArepCotizacionesMembretes As New ArepCotizacionesMembretes
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizacionesMembretes.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionesMembretes.LblNombrePie.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionesMembretes.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepCotizacionesMembretes.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizacionesMembretes.LblTelefonoVendedor.Text = TelefonoVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizacionesMembretes.LblMoneda.Text = Me.TxtMonedaImprime.Text
                                    ArepCotizacionesMembretes.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizacionesMembretes.LblRuc.Text = "Numero RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                                        ArepCotizacionesMembretes.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If
                                    End If
                                End If
                                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ArepCotizacionesMembretes.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepCotizacionesMembretes.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepCotizacionesMembretes.LblOrden.Text = Me.TxtNumeroEnsamble.Text
                                ArepCotizacionesMembretes.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                                ArepCotizacionesMembretes.LblNombres.Text = Me.TxtNombres.Text
                                ArepCotizacionesMembretes.LblDireccionProveedor.Text = Me.TxtDireccion.Text
                                ArepCotizacionesMembretes.LblTelefono.Text = Me.TxtTelefono.Text
                                ArepCotizacionesMembretes.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblTotal.Text = Format((CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtIva.Text)) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblTotal.Text = "0.00"
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepCotizacionesMembretes.DataSource = SQL
                                ArepCotizacionesMembretes.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepCotizacionesMembretes.Document
                                ViewerForm.Show()
                                ArepCotizacionesMembretes.Run(True)

                            Case "Papel en Blanco"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizaciones.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizaciones.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepCotizaciones.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizaciones.LblTelefonoVendedor.Text = TelefonoVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizaciones.LblMoneda.Text = Me.TxtMonedaImprime.Text
                                    ArepCotizaciones.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizaciones.LblRuc.Text = "Numero RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                                        ArepCotizaciones.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If
                                    End If
                                End If
                                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ArepCotizaciones.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepCotizaciones.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepCotizaciones.LblOrden.Text = Me.TxtNumeroEnsamble.Text
                                ArepCotizaciones.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                                ArepCotizaciones.LblNombres.Text = Me.TxtNombres.Text
                                ArepCotizaciones.LblDireccionProveedor.Text = Me.TxtDireccion.Text
                                ArepCotizaciones.LblTelefono.Text = Me.TxtTelefono.Text
                                ArepCotizaciones.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizaciones.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizaciones.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblTotal.Text = "0.00"
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepCotizaciones.DataSource = SQL
                                ArepCotizaciones.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepCotizaciones.Document
                                ViewerForm.Show()
                                ArepCotizaciones.Run(True)
                            Case "Cotizacion con Fotos"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizacionFoto.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionFoto.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizacionFoto.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If

                                    End If
                                End If
                                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtPagado.Text) <> 0 Then
                                    ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblPagado.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtDescuento.Text) <> 0 Then
                                    ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblDescuento.Text = "0.00"
                                End If

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

                Case "Salida Bodega"

                    TipoImpresion = Me.CboTipoProducto.Text

                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepSalidaBodega.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepSalidaBodega.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                End If

                                ArepSalidaBodega.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepSalidaBodega.LblCodProveedor.Text = Me.TxtCodigoClientes.Text


                                SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                                DataAdapter.Fill(DataSet, "Coordenadas")
                                Ancho = DataSet.Tables("Coordenadas").Rows(0)("Ancho")
                                Largo = DataSet.Tables("Coordenadas").Rows(0)("Largo")

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepSalidaBodega.DataSource = SQL
                                ArepSalidaBodega.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                'ArepSalidaBodega.PageSettings.PaperWidth = Str(Ancho)
                                'ArepSalidaBodega.PageSettings.PaperHeight = Largo
                                'ArepSalidaBodega.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepSalidaBodega.Document
                                ViewerForm.Show()
                                ArepSalidaBodega.Run(False)

                            Case "Personalizado"

                                If ConsecutivoFacturaSerie = False Then
                                    TipoImpresion = Me.CboTipoProducto.Text
                                Else
                                    TipoImpresion = Me.CboTipoProducto.Text & Me.CmbSerie.Text
                                End If

                                Dim StrSQLUpdate As String
                                Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                Dim DatasetDatos As New DataSet


                                MiConexionAccess.Open()
                                DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & NumeroFactura & "' "
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                '///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                                EscribirArchivo()

                                RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                                If Dir(RutaReportes) <> "" Then
                                    Shell(RutaReportes)
                                End If
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
                'SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                '             "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()
            End If

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Imprimio la: " & Me.CboTipoProducto.Text & "Numero " & Me.TxtNumeroEnsamble.Text)

            LimpiarFacturas()

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If


            Me.Button2.Enabled = True

            'CmdCerrar_Click(sender, e)

            SalirFactura = True

            If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
                Select Case Me.CboTipoProducto.Text
                    Case "Cotizacion"
                        Me.CmdFacturar.Enabled = True
                    Case "Orden de Trabajo"
                        Me.BtnSalida.Enabled = True
                    Case Else
                        LimpiarCompras()
                End Select
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged

        Dim SqlCompras As String, Fecha As String, TipoFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim FacturaSerie As Boolean = False, CodigoProyecto As String, FacturaContado As Boolean = False


        If Quien = "NumeroFacturas" Then
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
            FacturaSerie = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Me.CboTipoProducto.Enabled = True
        Else
            Me.CboTipoProducto.Enabled = False
        End If


        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then




            PrimerRegistroFactura = False

            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')  AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If Not DataSet.Tables("Facturas").Rows.Count = 0 Then

                If DataSet.Tables("Facturas").Rows(0)("MetodoPago") <> "Credito" Then
                    '//////////////////////////////////////BUSCO LOS METODOS DE PAGOS///////////////////////////////////////////////////////////////////////////////////
                    SqlCompras = "SELECT  NombrePago, Monto, NumeroTarjeta, FechaVence  FROM Detalle_MetodoFacturas " & _
                                 "WHERE (Detalle_MetodoFacturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_MetodoFacturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_MetodoFacturas.Tipo_Factura = '" & TipoFactura & "') "
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoPago")
                    Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
                    Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
                    dsMetodo = DataSet.Copy
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
                    Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
                    Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

                    If DataSet.Tables("MetodoPago").Rows.Count = 0 Then
                        Me.RadioButton1.Checked = True
                        FacturaContado = False
                    Else
                        Me.RadioButton2.Checked = True
                        FacturaContado = True
                    End If
                Else
                    Me.RadioButton1.Checked = True
                    FacturaContado = False
                End If


                '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                Quien = "MostrarFactura"
                Me.TxtCodigoClientes.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Cliente")
                Quien = ""
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")) Then
                    Me.CboCodigoVendedor.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")
                End If
                Me.TxtNombres.Text = DataSet.Tables("Facturas").Rows(0)("Nombre_Cliente")
                Me.TxtApellidos.Text = DataSet.Tables("Facturas").Rows(0)("Apellido_Cliente")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Facturas").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Telefono_Cliente")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Facturas").Rows(0)("Telefono_Cliente")
                End If
                Me.TxtMonedaFactura.Text = DataSet.Tables("Facturas").Rows(0)("MonedaFactura")
                Me.TxtMonedaImprime.Text = DataSet.Tables("Facturas").Rows(0)("MonedaImprime")

                '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////
                Me.DTVencimiento.Value = DataSet.Tables("Facturas").Rows(0)("Fecha_Vencimiento")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Observaciones")) Then
                    Me.TxtObservaciones.Text = DataSet.Tables("Facturas").Rows(0)("Observaciones")
                End If
                Me.TxtSubTotal.Text = Format(DataSet.Tables("Facturas").Rows(0)("SubTotal"), "##,##0.00")
                Me.TxtIva.Text = Format(DataSet.Tables("Facturas").Rows(0)("IVA"), "##,##0.00")
                Me.TxtPagado.Text = Format(DataSet.Tables("Facturas").Rows(0)("Pagado"), "##,##0.00")
                Me.TxtNetoPagar.Text = Format(DataSet.Tables("Facturas").Rows(0)("NetoPagar"), "##,##0.00")
                Me.CboCodigoBodega.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Bodega")

                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Referencia")) Then
                    If DataSet.Tables("Facturas").Rows(0)("Referencia") <> "" Then
                        Me.CboReferencia.Text = DataSet.Tables("Facturas").Rows(0)("Referencia")
                    End If
                End If

                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Propina")) Then
                    If Val(DataSet.Tables("Facturas").Rows(0)("Propina")) <> 0 Then
                        Me.TxtPropina.Text = Format(DataSet.Tables("Facturas").Rows(0)("Propina"), "##,##0.00")
                    End If
                Else
                    Me.TxtPropina.Text = "0.00"
                End If

                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("CodigoProyecto")) Then
                    CodigoProyecto = DataSet.Tables("Facturas").Rows(0)("CodigoProyecto")

                    SqlCompras = "SELECT * FROM Proyectos WHERE  (CodigoProyectos = '" & CodigoProyecto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        Me.CboProyecto.Text = DataSet.Tables("Consulta").Rows(0)("NombreProyectos")
                    Else
                        Me.CboProyecto.Text = ""
                    End If
                    DataSet.Tables("Consulta").Reset()

                Else
                    Me.CboProyecto.Text = ""
                End If



                If FacturaContado = True Then
                    Me.RadioButton2.Checked = True
                Else
                    Me.RadioButton1.Checked = True
                End If

                If DataSet.Tables("Facturas").Rows(0)("Exonerado") = "True" Then
                    Me.OptExsonerado.Checked = True
                Else
                    Me.OptExsonerado.Checked = False
                End If


                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Retener1Porciento")) Then
                    If DataSet.Tables("Facturas").Rows(0)("Retener1Porciento") = "True" Then
                        Me.OptRet1Porciento.Checked = True
                    Else
                        Me.OptRet1Porciento.Checked = False
                    End If
                End If

                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Retener2Porciento")) Then
                    If DataSet.Tables("Facturas").Rows(0)("Retener2Porciento") = "True" Then
                        Me.OptRet2Porciento.Checked = True
                    Else
                        Me.OptRet2Porciento.Checked = False
                    End If
                End If

                If FacturaSerie = True Then
                    Me.CmbSerie.Visible = True
                    Me.CmbSerie.Enabled = False
                    Me.CmbSerie.Text = Mid(Me.TxtNumeroEnsamble.Text, 1, 1)
                Else
                    Me.CmbSerie.Visible = False
                    Me.CmbSerie.Enabled = False
                End If



                If FacturaTarea = True Then
                    ds.Tables("DetalleFactura").Reset()
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
                    '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                    'Detalle_Facturas.id_Detalle_Factura
                    SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura ,Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " & _
                                                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND  (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    'DataAdapter.Fill(DataSet, "DetalleFactura")
                    'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                    ds = New DataSet
                    da = New SqlDataAdapter(SqlCompras, MiConexion)
                    CmdBuilder = New SqlCommandBuilder(da)
                    da.Fill(ds, "DetalleFactura")
                    Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                    Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Visible = False
                    ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False



                ElseIf FacturaLotes = True Then

                    ds.Tables("DetalleFactura").Reset()
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas   " & _
                    '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                    'Detalle_Facturas.id_Detalle_Factura
                    SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea ,Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas   " & _
                                                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND  (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura "
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    'DataAdapter.Fill(DataSet, "DetalleFactura")
                    'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                    ds = New DataSet
                    da = New SqlDataAdapter(SqlCompras, MiConexion)
                    CmdBuilder = New SqlCommandBuilder(da)
                    da.Fill(ds, "DetalleFactura")
                    Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                    Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Visible = False
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Visible = False
                Else
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                    'Detalle_Facturas.id_Detalle_Factura
                    SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura, Detalle_Facturas.id_Detalle_Factura FROM  Detalle_Facturas " & _
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    'SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas " & _
                    '    "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    'DataAdapter.Fill(DataSet, "DetalleFacturas")
                    'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
                    ds = New DataSet
                    da = New SqlDataAdapter(SqlCompras, MiConexion)
                    CmdBuilder = New SqlCommandBuilder(da)
                    da.Fill(ds, "DetalleFactura")
                    Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")

                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
                    Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False


                End If

                '////////////////////////////ACTUALIZO TODO POR CUALQUIER CAMBIO /////////////////////////////////
                ActualizaMETODOFactura()

                If EditarFactura = False Then
                    Me.GroupBox2.Enabled = False
                    Me.GroupBox3.Enabled = False
                    Me.DTVencimiento.Enabled = False
                    Me.CboCodigoBodega.Enabled = False
                    Me.CboCodigoBodega2.Enabled = False
                    Me.CboCodigoVendedor.Enabled = False
                    Me.CboProyecto.Enabled = False
                    Me.ChkPorcientoTarjeta.Enabled = False
                    Me.CboCajero.Enabled = False
                    Me.TxtMonedaFactura.Enabled = False
                    Me.TxtMonedaImprime.Enabled = False
                    Me.Button3.Enabled = False
                    Me.TxtObservaciones.Enabled = False
                    Me.C1Button5.Enabled = False
                    Me.C1Button4.Enabled = False
                    Me.Button1.Enabled = False
                    Me.DTPFecha.Enabled = False
                    Me.C1Button1.Enabled = False
                    Me.C1Button2.Enabled = False
                    Me.C1Button3.Enabled = False
                    Me.CboTipoProducto.Enabled = False
                    Me.TrueDBGridComponentes.Splits.Item(0).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = False
                End If

            End If


            If Me.CboTipoProducto.Text = "Cotizacion" Then
                Me.CmdFacturar.Enabled = True
                Me.CmdFacturar.Visible = True
                Me.BtnSalida.Visible = False
                Me.BtnSalida.Enabled = False

            ElseIf Me.CboTipoProducto.Text = "Orden de Trabajo" Then
                Me.CmdFacturar.Visible = False
                Me.BtnSalida.Visible = True
                Me.BtnSalida.Enabled = True
            Else
                Me.CmdFacturar.Enabled = False
                Me.CmdFacturar.Visible = True
                Me.BtnSalida.Visible = False
                Me.BtnSalida.Enabled = False

            End If

        Else
            If FacturaSerie = True Then
                Me.CmbSerie.Visible = True
                Me.CmbSerie.Enabled = True
            Else
                Me.CmbSerie.Visible = False
                Me.CmbSerie.Enabled = False
            End If
        End If


        CambioCliente = False




    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String, SqlProveedor As String, PrecioDescCordobas As String = 0, PrecioDescDolar As String = 0
        Dim CodigoAlterno As String = "", Precio As Double = 0, Cantidad As Double = 0, Categoria As String
        Dim CostoUnitario As Double = 0, TasaCambio As Double = 1, TipoProducto As String = "", TipoDescuento As String = ""
        Dim SubTotal As Double = 0, PorcientoDescuento As Double = 0, Neto As Double = 0
        Dim RstCosto As New RstCostoPromedio

        Try

            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text


            Select Case Me.TrueDBGridComponentes.Col

                Case 0

                    If PerteneceProductoBodega(Me.CboCodigoBodega.Text, Me.TrueDBGridComponentes.Columns("Cod_Producto").Text) = False Then
                        Exit Sub
                    End If


                    If Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = "" Then
                        Exit Sub
                    Else
                        CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                        SqlString = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count <> 0 Then

                            TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                            TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")

                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '/////////////////////////////////////////////////////////BUSCO EL CODIGO SAC ////////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            If Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = "" Then
                                RstCosto = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                                CostoUnitario = RstCosto.Costo_Cordoba
                                Dim worker As BackgroundWorker, Lotes As Lote = New Lote
                                worker = New BackgroundWorker()
                                AddHandler worker.DoWork, AddressOf backgroundWorkerGrabar_DoWork
                                AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerGrabar_RunWorkerCompleted
                                Lotes.Codigo_Producto = CodProducto
                                worker.RunWorkerAsync()

                                'ActualizaCostoPromedio(CodProducto)
                            Else
                                CostoUnitario = Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text
                            End If

                            Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = CostoUnitario

                            SqlProveedor = "SELECT * FROM Codigos_Alternos WHERE (Cod_Producto = '" & CodProducto & "') AND (Descripcion_Producto = 'SAC')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                DataAdapter.Fill(DataSet, "Alternos")
                                If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                                    CodigoAlterno = DataSet.Tables("Alternos").Rows(0)("Cod_Alternativo")
                                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = Trim(DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")) & " ,SAC: " & CodigoAlterno
                                Else
                                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = Trim(DataSet.Tables("Productos").Rows(0)("Descripcion_Producto"))
                                End If


                            If FacturaTarea = True Then

                                If Me.TxtMonedaFactura.Text = "Dolares" Then
                                    If Me.CboTipoProducto.Text = "Salida Bodega" Then
                                        '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                                        SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                        DataAdapter.Fill(DataSet, "Costo")
                                        If DataSet.Tables("Costo").Rows.Count <> 0 Then
                                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                                'PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                                TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
                                                PrecioDescCordobas = CostoUnitario * TasaCambio
                                                If FacturaTarea = True Then
                                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                Else
                                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                End If
                                            End If
                                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                                PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                                            End If
                                        End If
                                        DataSet.Tables("Costo").Reset()

                                    Else
                                        If Me.ChkPorcientoTarjeta.Checked = True Then
                                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(DataSet.Tables("Productos").Rows(0)("Precio_Lista") * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                        Else
                                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                                        End If
                                    End If
                                Else
                                    If Me.ChkPorcientoTarjeta.Checked = True Then
                                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(DataSet.Tables("Productos").Rows(0)("Precio_Venta") * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                        Else
                                            If Me.CboTipoProducto.Text = "Salida Bodega" Then
                                                '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                                                SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                                DataAdapter.Fill(DataSet, "Costo")
                                                If DataSet.Tables("Costo").Rows.Count <> 0 Then
                                                    If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                                        'PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                                        PrecioDescCordobas = CostoUnitario
                                                        If FacturaTarea = True Then
                                                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                        Else
                                                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                        End If
                                                    End If
                                                    If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                                        PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                                                    End If
                                                End If
                                                DataSet.Tables("Costo").Reset()
                                            Else
                                                If Me.ChkPorcientoTarjeta.Checked = True Then
                                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(DataSet.Tables("Productos").Rows(0)("Precio_Venta") * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                                Else
                                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                                                End If
                                            End If
                                            'Me.TrueDBGridComponentes.Columns(4).Text = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                                        End If
                                    End If
                                Else
                                '////////////////////////////////////////////////////////////////////////////////////////////////////
                                '///////////////////////////////SI NO ES FACTURACION POR LOTE PARA ESTA OPCION ////////////////////////
                                '//////////////////////////////////////////////////////////////////////////////////////////////////////


                                If Me.TxtMonedaFactura.Text = "Dolares" Then
                                        If Me.CboTipoProducto.Text = "Salida Bodega" Then
                                            '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                                            SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                            DataAdapter.Fill(DataSet, "Costo")
                                            If DataSet.Tables("Costo").Rows.Count <> 0 Then
                                                If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                                    'PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                                    PrecioDescCordobas = CostoUnitario
                                                    If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                                        PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                                                    End If
                                                    If FacturaTarea = True Then
                                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescDolar
                                                    Else
                                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescDolar
                                                    End If
                                                End If

                                            End If
                                            DataSet.Tables("Costo").Reset()



                                        Else  '///////////////////////SI NO ES SALIDA DE BODEGGA PONGO LOS PRECIOS DE VENTA ////////////////////////////////////////////
                                            If Me.ChkPorcientoTarjeta.Checked = True Then
                                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(DataSet.Tables("Productos").Rows(0)("Precio_Lista") * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                            Else
                                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                                            End If

                                            ''''---------------------------------CLASIFICO LA CATEGORIA DEL PRECIO --------------------------------------
                                            Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text, Me.TxtMonedaFactura.Text)


                                            Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                            If Categoria <> "" Then
                                                Me.TrueDBGridComponentes.Columns("Descuento").Text = Categoria
                                            Else
                                                Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                            End If
                                            'End If
                                        End If
                                    Else '/////////////////////SI LA FACTUACION ES EN CORDOBAS ///////////////////////////////////
                                        If Me.CboTipoProducto.Text = "Salida Bodega" Then

                                            '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                                            SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                            DataAdapter.Fill(DataSet, "Costo")
                                            If DataSet.Tables("Costo").Rows.Count <> 0 Then
                                                If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                                    'PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                                    'If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                                    '    PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                                                    'End If
                                                    'PrecioDescCordobas = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                                                    PrecioDescCordobas = CostoUnitario
                                                    If FacturaTarea = True Then
                                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                    Else
                                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioDescCordobas
                                                    End If
                                                End If

                                            End If
                                            DataSet.Tables("Costo").Reset()


                                        Else  '//////////////////////SI NO ES SALIDA DE BODEGA /////////////////////////////////////////////



                                            If Me.ChkPorcientoTarjeta.Checked = True Then
                                                If Not Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                Else
                                                    Cantidad = 0
                                                End If

                                                Precio = Format(DataSet.Tables("Productos").Rows(0)("Precio_Venta") * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Precio

                                                Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text, Me.TxtMonedaFactura.Text)

                                                If Me.TrueDBGridComponentes.Columns("Descuento").Text = "" Then
                                                    If Categoria <> "" Then
                                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = Categoria
                                                    Else
                                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    End If
                                                End If

                                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Cantidad * Precio
                                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                            Else
                                                If Not Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                Else
                                                    Cantidad = 0
                                                End If
                                                Precio = Format(DataSet.Tables("Productos").Rows(0)("Precio_Venta"), "##,##0.00")
                                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                                                If Me.TrueDBGridComponentes.Columns("Descuento").Text = "" Then
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                End If
                                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                                Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Cantidad * Precio, "##,##0.00")
                                            End If
                                        End If
                                    End If
                                End If

                            Else

                                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                '//////////////////////////////////////////////////SI NO EXISTE EL CODIGO LO BUSCO EN CODIGOS ALTERNO /////////////
                                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then

                                '////////////////BUSCO EL CODIGO ALTERNATIVO ///////////////////////////////////////////////////
                                CodigoAlterno = CodProducto

                                SqlProveedor = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                DataAdapter.Fill(DataSet, "Alternos")
                                If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                                    RstCosto = CostoPromedioKardex(DataSet.Tables("Alternos").Rows(0)("Cod_Producto"), Me.DTPFecha.Value)
                                    CostoUnitario = RstCosto.Costo_Cordoba
                                    Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = CostoUnitario
                                    'Me.TrueDBGridComponentes.Col = 2
                                Else
                                    MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                                    If Me.TxtMonedaFactura.Text = "Dolares" Then
                                        Quien = "CodigoProductosFactura"
                                    Else
                                        Quien = "CodigoProductosCordobas"
                                    End If
                                    My.Forms.FrmConsultas.ShowDialog()

                                    If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
                                        Exit Sub
                                    End If
                                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
                                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                                    If FacturaTarea = True Then
                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                                    Else
                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                                    End If

                                    Exit Sub
                                End If
                            End If



                        End If
                    End If

                    PrecioDescCordobas = Precio

                    '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                    Select Case TipoDescuento
                        Case "ImporteFijo"
                            If FacturaTarea = True Then
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                                Cantidad = 1
                                Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                                If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                    Precio = PrecioDescCordobas
                                Else
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                    Precio = PrecioDescDolar
                                End If
                            Else

                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                                Cantidad = 1
                                Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                                If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                    Precio = PrecioDescCordobas
                                Else
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                    Precio = PrecioDescDolar
                                End If
                            End If

                        Case "SubTotal"

                            If FacturaTarea = True Then
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                                Cantidad = 1
                                Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                                SubTotal = Me.TxtSubTotal.Text
                                If PrecioDescCordobas <> 0 Then
                                    PorcientoDescuento = (PrecioDescCordobas / 100)
                                End If
                                Precio = SubTotal * PorcientoDescuento
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                            Else
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                                Cantidad = 1
                                Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                                If Me.TxtSubTotal.Text <> "" Then
                                    SubTotal = Me.TxtSubTotal.Text
                                Else
                                    SubTotal = 0
                                End If
                                If PrecioDescCordobas <> 0 Then
                                    PorcientoDescuento = (PrecioDescCordobas / 100)
                                End If
                                Precio = SubTotal * PorcientoDescuento
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                            End If


                    End Select



                    Select Case TipoProducto
                        Case "Servicio"
                            If FacturaTarea = True Then
                                SubTotal = Cantidad * Precio
                                Neto = SubTotal
                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                            Else
                                SubTotal = Cantidad * Precio
                                Neto = SubTotal
                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                            End If
                        Case "Descuento"
                            If FacturaTarea = True Then
                                Neto = Math.Abs(Cantidad * Precio) * -1
                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                            Else
                                Neto = Math.Abs(Cantidad * Precio) * -1
                                Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                                Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                            End If

                    End Select




                    If Acceso <> "Administrador" Then
                        If Me.CboTipoProducto.Text = "Cotizacion" Then
                            If FacturaTarea = True Then
                                Me.GroupBox3.Enabled = False
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                            Else
                                Me.GroupBox3.Enabled = False
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                            End If
                        Else
                            If FacturaTarea = True Then
                                Me.GroupBox3.Enabled = True
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                            Else
                                Me.GroupBox3.Enabled = True
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                            End If

                        End If
                    End If

            End Select



            'ActualizaMETODOFactura()

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
        Dim NumeroFactura As String, iPosicion As Double = 0
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double
        Dim TablaFactura As TablaFactura = New TablaFactura

        'Try

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


        If Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = "" Then
            Exit Sub
        Else
            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count = 0 Then
                Exit Sub
            End If
        End If


        '////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Me.CboTipoProducto.Enabled = True
        Else
            Me.CboTipoProducto.Enabled = False
        End If

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Cotizacion"
        '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
        '        Case "Factura"
        '            If ConsecutivoFacturaManual = False Then
        '                ConsecutivoFactura = BuscaConsecutivo("Factura")
        '            Else
        '                FrmConsecutivos.ShowDialog()
        '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
        '            End If
        '        Case "Devolucion de Venta"
        '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
        '        Case "Transferencia Enviada"
        '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
        '        Case "Salida Bodega"
        '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
        '    End Select

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////

        '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        '    DataAdapter.Fill(DataSet, "DatosEmpresa")
        '    If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
        '        If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacBodega")) Then
        '            FacturaBodega = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacBodega")
        '        End If

        '        If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoComBodega")) Then
        '            CompraBodega = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoComBodega")
        '        End If

        '    End If

        '    If FacturaBodega = True Then
        '        NumeroFactura = Me.CboCodigoBodega.Columns("Cod_Producto").Text & "-" & Format(ConsecutivoFactura, "0000#")
        '    Else
        '        NumeroFactura = Format(ConsecutivoFactura, "0000#")
        '    End If
        'Else
        '    'ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
        '    NumeroFactura = Me.TxtNumeroEnsamble.Text
        'End If


        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroFacturas"
            NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
            Me.TxtNumeroEnsamble.Text = NumeroFactura
        Else
            NumeroFactura = Me.TxtNumeroEnsamble.Text
        End If


        Dim worker As BackgroundWorker
        Dim args As ClaseFactura = New ClaseFactura


        args.Numero_Factura = NumeroFactura
        args.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")

        TablaFactura.Numero_Factura = NumeroFactura
        TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        TablaFactura.Tipo_Factura = CboTipoProducto.Text
        TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
        TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
        TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
        TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
        TablaFactura.CodBodega1 = CboCodigoBodega.Text
        TablaFactura.Cod_Cajero = CboCajero.Text
        TablaFactura.Nombre_Cliente = TxtNombres.Text
        TablaFactura.Apellido_Cliente = TxtApellidos.Text
        TablaFactura.Direccion_Cliente = TxtDireccion.Text
        TablaFactura.Telefono_Cliente = TxtTelefono.Text
        TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Via_Envarque = ""
        TablaFactura.SuReferencia1 = CboReferencia.Text
        TablaFactura.Nuestra_Referencia = ""
        TablaFactura.Codigo_Proyecto = CboProyecto.Text


        If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
            TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        Else
            TablaFactura.Sub_Total = 0
        End If

        If My.Forms.FrmFacturas.IvaGral <> 0 Then
            TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        Else
            TablaFactura.IVA_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
            TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        Else
            TablaFactura.Pagado_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
            TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        Else
            TablaFactura.Neto_Pagar = 0
        End If

        If RadioButton1.Checked = True Then
            TablaFactura.Metodo_Pago = "Credito"
        Else
            TablaFactura.Metodo_Pago = "Contado"
        End If

        If OptExsonerado.Checked = True Then
            TablaFactura.Exonerado_Factura = 1
        Else
            TablaFactura.Exonerado_Factura = 0
        End If

        If OptRet1Porciento.Checked = True Then
            TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
            TablaFactura.Retener1_Porciento = 1
        Else
            TablaFactura.MontoRetencion1_Porciento = 0
            TablaFactura.Retener1_Porciento = 0
        End If

        If OptRet2Porciento.Checked = True Then
            TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
            TablaFactura.Retener2_Porciento = 1
        Else
            TablaFactura.MontoRetencion2_Porciento = 0
            TablaFactura.Retener2_Porciento = 0
        End If


        If Not CboProyecto.Text = "" Then
            TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If

        If CboReferencia.Text <> "" Then
            TablaFactura.Referencia_Factura = CboReferencia.Text
        End If

        TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))


        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf backgroundWorkerInsertar_DoWork
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerInsertar_RunWorkerCompleted
        worker.RunWorkerAsync(TablaFactura)

        My.Application.DoEvents()

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaFacturas(NumeroFactura)


        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL DETALLE DE FACTURA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        '''ds.Tables("DetalleFactura").GetChanges()
        ''da.Update(ds.Tables("DetalleFactura"))
        '''ds.Tables("DetalleFactura").AcceptChanges()
        ''iPosicion = Me.BindingDetalle.Position
        ''CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        ''DataAdapterRefresh()
        ''ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)
        ''Me.TrueDBGridComponentes.Row = iPosicion + 1


        'InsertarRowGrid()
        ''da.Update(ds.Tables("DetalleFactura"))
        'SalirFactura = False

        ''GrabaItemFactura()

        'Me.Button7.Enabled = True
        'Me.CboCodigoBodega.Enabled = True

        'ActualizaMETODOFactura()



        'CodigoProducto = 0
        'PrecioUnitario = 0
        'Descuento = 0
        'PrecioNeto = 0
        'Importe = 0
        'Cantidad = 0

        'Me.TrueDBGridComponentes.Col = 0

        'If Acceso <> "Administrador" Then
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////BLOQUEO LOS PRECIOS DESPUES DE ACTUALIZAR////////////////////////////////////////////////////////
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    If Me.CboTipoProducto.Text = "Cotizacion" Then
        '        If FacturaTarea = True Then
        '            Me.GroupBox3.Enabled = False
        '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
        '        Else
        '            Me.GroupBox3.Enabled = False
        '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
        '        End If
        '    Else
        '        If FacturaTarea = True Then
        '            Me.GroupBox3.Enabled = True
        '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
        '        Else
        '            Me.GroupBox3.Enabled = True
        '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
        '        End If

        '    End If
        'End If


        'If NombreCliente = "Alumnos" Then
        '    'Me.Label12.Visible = False
        '    'Me.CboCodigoVendedor.Visible = False
        'End If

        'If UsuarioBodega <> "Ninguna" Then
        '    'Me.CboCodigoBodega.Text = UsuarioBodega
        '    'Me.CboCodigoBodega.Enabled = False
        '    'Me.Button7.Enabled = False
        'End If

        'If UsuarioTipoFactura <> "Ninguna" Then
        '    'Me.CboTipoProducto.Text = UsuarioTipoFactura
        'End If

        'If UsuarioVendedor <> "Ninguna" Then
        '    'Me.CboCodigoVendedor.Text = UsuarioVendedor
        'End If

        'If UsuarioCliente <> "Ninguna" Then
        '    'Me.TxtCodigoClientes.Text = UsuarioCliente
        'End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

        Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
            Dim Cols As Double, iPosicion As Double

            Try
                Columna = e.ColIndex
            If FacturaTarea = True Then
                Cols = e.ColIndex



                Select Case Cols

                    Case 3
                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                        End If

                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            iPosicion = Me.BindingDetalle.Position
                            CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                        Else
                            CantidadAnterior = 0
                        End If
                    Case 4
                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = 0
                        End If


                        If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                            iPosicion = Me.BindingDetalle.Position
                            PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                        Else
                            PrecioAnterior = 0
                        End If
                End Select
            Else
                Cols = e.ColIndex
                Select Case Cols

                    Case 2
                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                        End If

                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            iPosicion = Me.BindingDetalle.Position
                            CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                        Else
                            CantidadAnterior = 0
                        End If

                        'ActualizaMETODOFactura()
                    Case 3

                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = 0
                        End If


                        If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                            iPosicion = Me.BindingDetalle.Position
                            PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                        Else
                            PrecioAnterior = 0
                        End If

                        'ActualizaMETODOFactura()
                End Select
            End If



            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate

        Dim Cols As Double, Precio As Double, Cantidad As Double, Descuento As Double, SubTotal As Double, Neto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Tasa As Double, SqlProveedor As String
        Dim CodProducto As String, Sql As String, RespuestaIVA As String = "Sumando IVA del Producto", CodImpuesto As String = "", TasaImpuesto As Double
        Dim TipoProducto As String = "Productos", TipoDescuento As String = "ImporteFijo", PrecioAnterior As Double = 0
        Dim PrecioDescDolar As Double, PrecioDescCordobas As Double, PorcientoDescuento As Double, CodigoBodega As String = ""
        Dim ExistenciaNegativa As String = "NO", Existencia As Double = 0, Cantidad2 As Double = 0, Categoria As String, Mensaje As String
        Dim NumeroLote As String, ExistenciaLote As Double, Args As ReporteExistenciaLote = New ReporteExistenciaLote, resul As ReporteExistenciaLote = New ReporteExistenciaLote
        Dim RstCosto As New RstCostoPromedio

        Try


            Args.Codigo_Bodega = Me.CboCodigoBodega.Text
            Args.Codigo_Producto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
            Args.Fecha_Reporte = Me.DTPFecha.Value


            If FacturaTarea = False Then
                If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                    'Exit Sub
                End If

                If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                    'Exit Sub
                End If

                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Descuento").Text) Then
                        'Exit Sub
                    End If
                End If

                Cols = e.ColIndex

                If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                    Cantidad2 = 0
                ElseIf IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then

                    Cantidad2 = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                End If



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
                CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count <> 0 Then
                    CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                    TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                    TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                    PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                    PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                    ExistenciaNegativa = DataSet.Tables("Productos").Rows(0)("Existencia_Negativa")
                End If

                CodigoBodega = Me.CboCodigoBodega.Text
                'Existencia = BuscaExistenciaBodega(CodProducto, CodigoBodega)
                Existencia = BuscaInventarioInicialBodega(CodProducto, DateAdd(DateInterval.Day, 1, Me.DTPFecha.Value), CodigoBodega)
                Descuento = 0
                Tasa = 0




                'Me.TrueDBGridComponentes.Columns(8).Text = CostoPromedioKardexBodega(CodProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)

                If FacturaTarea = True Then
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                    Args.Numero_Lote = Me.TrueDBGridComponentes.Columns("CodTarea").Text
                Else
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False

                End If
                DataSet.Reset()

                If FacturaTarea = True Then
                    If Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = "" Then
                        Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = CostoPromedioKardexBodega(CodProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)
                    End If

                    Select Case Cols
                        Case 0

                            If PerteneceProductoBodega(Me.CboCodigoBodega.Text, Me.TrueDBGridComponentes.Columns("Cod_Producto").Text) = False Then
                                Mensaje = "No Pertenece el Producto a esta Bodega" & Chr(13) &
                                          "Precio ESC Para Salir"
                                MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
                                e.Cancel = True
                                Exit Sub
                            End If

                            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then
                                CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Producto: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)

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
                                        Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                                        'Me.TrueDBGridComponentes.Col = 2
                                    Else
                                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                                        Exit Sub
                                    End If
                                End If
                            Else
                                CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                                If BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text) = 0 Then
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                                Else
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text)
                                End If
                            End If
                            DataSet.Tables("Productos").Clear()

                            Me.TrueDBGridComponentes.Columns("CodTarea").Text = LoteDefecto(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)



                        Case 1


                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If

                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If




                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then

                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If

                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else


                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If

                            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica la cantidad de: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)

                        Case 2


                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If

                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If


                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If

                        Case 3


                            If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                Exit Sub
                            End If

                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote
                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text

                                End If

                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If
                        Case 4


                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                    End If
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If

                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If


                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If

                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If



                        Case 5

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                    End If
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text

                                End If

                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                            MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            End If

                    End Select

                    Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Producto: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)

                Else
                    '/////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////////////////SI NO ES FACTURACION POR LOTE //////////////////////////////////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '22-10-2015
                    'Me.TrueDBGridComponentes.Columns(8).Text = CostoPromedioKardexBodega(CodProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)

                    Select Case Cols

                        Case 0

                            If PerteneceProductoBodega(Me.CboCodigoBodega.Text, Me.TrueDBGridComponentes.Columns("Cod_Producto").Text) = False Then
                                Mensaje = "No Pertenece el Producto a esta Bodega" & Chr(13) &
                                          "Precio ESC Para Salir"
                                MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
                                e.Cancel = True
                                Exit Sub
                            End If

                            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Producto: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)

                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then
                                CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
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
                                        Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                                        'Me.TrueDBGridComponentes.Col = 2
                                    Else
                                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                                        Exit Sub
                                    End If
                                End If
                            Else
                                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                '/////////////////////////////////////////////////////////BUSCO EL CODIGO SAC ////////////////////////////////////////////////////////////////
                                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                Dim CodigoAlterno As String = ""

                                SqlProveedor = "SELECT * FROM Codigos_Alternos WHERE (Cod_Producto = '" & CodProducto & "') AND (Descripcion_Producto = 'SAC')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                DataAdapter.Fill(DataSet, "Alternos")
                                If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                                    CodigoAlterno = DataSet.Tables("Alternos").Rows(0)("Cod_Alternativo")
                                    'Me.TrueDBGridComponentes.Col = 2
                                End If

                                CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                                If CodigoAlterno = "" Then
                                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0

                                Else
                                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = Trim(DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")) & " SAC: " & CodigoAlterno
                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1

                                    If Me.CboTipoProducto.Text = "Salida Bodega" Then
                                        If Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = "" Then
                                            RstCosto = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                                            Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = RstCosto.Costo_Cordoba

                                        End If

                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text
                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = "SB"

                                    Else
                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                                    End If

                                End If





                            End If
                            DataSet.Tables("Productos").Clear()


                        Case 1

                            If Existencia < Cantidad2 Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then

                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If

                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If

                        Case 2

                            If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                Exit Sub
                            End If

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica la cantidad: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica la cantidad: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica la cantidad: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                End If
                            End If
                        Case 3

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia

                                            If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el descuento: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                            End If
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If

                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifico el descuento: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If


                                Else

                                    ''''---------------------------------CLASIFICO LA CATEGORIA DEL PRECIO --------------------------------------
                                    Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text, Me.TxtMonedaFactura.Text)

                                    'If Me.TrueDBGridComponentes.Columns("Descuento").Text = "" Then
                                    If Categoria <> "" Then
                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = Categoria
                                    Else
                                        If IsNumeric(Me.TrueDBGridComponentes.Columns("Descuento").Text) Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el descuento: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                                        Else
                                            Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                        End If

                                    End If


                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then

                                    Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, e.OldValue, Me.TxtMonedaFactura.Text)

                                    If Categoria <> "" Then
                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = Categoria
                                    Else
                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        Me.TrueDBGridComponentes.Columns("Descuento").Text = Descuento
                                    End If

                                Else
                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0

                                End If

                                PrecioAnterior = e.OldValue
                                If BloquearPrecioVentas(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text, Me.DTPFecha.Value, Me.TxtMonedaFactura.Text) = True Then
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioAnterior
                                End If

                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If



                        Case 4

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                            End If
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                    End If
                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    If IsNumeric(Me.TrueDBGridComponentes.Columns("Descuento").Text) Then
                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                    Else
                                        Descuento = 0
                                    End If
                                Else
                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If


                    End Select

                End If



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



                If FacturaTarea = True Then
                    If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                        If RespuestaIVA = "Sumando IVA del Producto" Then
                            Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                        Else
                            If Me.OptExsonerado.Checked = False Then
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) / (1 + TasaImpuesto)
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Precio: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                            Else
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Precio: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                            End If
                        End If
                    Else
                        Precio = 0
                    End If
                Else
                    If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                        If RespuestaIVA = "Sumando IVA del Producto" Then
                            Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                        Else
                            If Me.OptExsonerado.Checked = False Then
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) / (1 + TasaImpuesto)
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Precio: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                            Else
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                                Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se Modifica el Precio: " & CodProducto & "de " & Me.CboTipoProducto.Text & " No." & Me.TxtNumeroEnsamble.Text)
                            End If
                        End If
                    Else
                        Precio = 0
                    End If
                End If


                '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                If FacturaTarea = True Then
                    Select Case TipoDescuento
                        Case "ImporteFijo"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If

                        Case "SubTotal"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            SubTotal = Me.TxtSubTotal.Text
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                    End Select
                Else
                    Select Case TipoDescuento
                        Case "ImporteFijo"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If

                        Case "SubTotal"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            SubTotal = Me.TxtSubTotal.Text
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                    End Select
                End If


                SubTotal = Cantidad * Precio
                Neto = SubTotal * (1 - Descuento)

                Select Case TipoProducto
                    Case "Productos"
                        SubTotal = Cantidad * Precio
                        Neto = SubTotal * (1 - Descuento)
                    Case "Descuento"
                        Neto = Math.Abs(Cantidad * Precio) * -1

                End Select

                If FacturaTarea = True Then
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio * (1 - Descuento), "##,##0.0000")
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.0000")
                Else
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio * (1 - Descuento), "##,##0.0000")
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.0000")
                End If


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


                If Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = "" Then
                    MsgBox("Necesita Seleccionar un producto", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                Else

                    CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count = 0 Then
                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                        Exit Sub
                    End If
                End If
            Else
                '**************************************************************************************************************************************************
                '//////////////////////////////////////////////////////////////CON ESTA CONSULTA VALIDO SI ES CON TAREAS//////////////////////////////////////////////////////////
                '**********************************************************************************************************************************************************
                If FacturaLotes = True Then
                    If Me.TrueDBGridComponentes.Columns("CodTarea").Text <> "" Then
                        NumeroLote = Me.TrueDBGridComponentes.Columns("CodTarea").Text
                        CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                        Args.Numero_Lote = NumeroLote
                        Args.Codigo_Producto = CodProducto

                        'Sql = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & NumeroLote & "')"
                        Sql = "SELECT *  FROM Detalle_Compras WHERE  (Numero_Lote = '" & NumeroLote & "') AND (Cod_Producto = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaLote")
                        If DataSet.Tables("BuscaLote").Rows.Count = 0 Then
                            MsgBox("Este Lote no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            e.Cancel = True
                            Exit Sub
                        End If


                        DataSet.Tables("BuscaLote").Reset()

                    Else
                        Me.TrueDBGridComponentes.Columns("CodTarea").Text = LoteDefecto(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
                    End If
                End If



                If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                    Exit Sub
                End If

                If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                    Exit Sub
                End If

                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                        Exit Sub
                    End If
                End If

                Cols = e.ColIndex

                If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                    Cantidad2 = 0
                ElseIf IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                    Cantidad2 = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                End If

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
                CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count <> 0 Then
                    CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                    TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                    TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                    PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                    PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                    ExistenciaNegativa = DataSet.Tables("Productos").Rows(0)("Existencia_Negativa")
                End If

                'Existencia = ExistenciaProducto(CodProducto)
                CodigoBodega = Me.CboCodigoBodega.Text

                Descuento = 0
                Tasa = 0

                If FacturaTarea = True Then
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                Else
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                End If
                DataSet.Reset()

                If FacturaTarea = True Then


                    Select Case Cols
                        Case 0

                            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then
                                MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                                Exit Sub
                            Else
                                CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                            End If
                            DataSet.Tables("Productos").Clear()


                        Case 1


                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" And Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                Exit Sub
                            End If

                            '************CODIGO RETIRADO 20-10-2025 RENDIMIENTO ********************
                            'resul = BuscaExistenciaBodegaLote(Args)
                            'ExistenciaLote = resul.Existencia_Lote
                            ''Existencia
                            'If ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                            '    If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                            '        If ExistenciaNegativa <> "SI" Then
                            '            If Existencia > 0 Then
                            '                Cantidad = Existencia
                            '                If TipoProducto <> "Servicio" Then
                            '                    If TipoProducto <> "Descuento" Then
                            '                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                            '                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                            '                    Else
                            '                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                        End If
                            '                    End If
                            '                Else
                            '                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                    End If
                            '                End If
                            '            Else
                            '                Cantidad = 0
                            '                If TipoProducto <> "Servicio" Then
                            '                    If TipoProducto <> "Descuento" Then
                            '                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                            '                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                            '                    Else
                            '                        If TipoProducto <> "Servicio" Then
                            '                            If TipoProducto <> "Descuento" Then
                            '                            End If
                            '                        End If
                            '                    End If
                            '                Else
                            '                    If TipoProducto <> "Servicio" Then
                            '                        If TipoProducto <> "Descuento" Then
                            '                        End If
                            '                    End If
                            '                End If

                            '            End If
                            '        Else
                            '            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '            End If
                            '        End If
                            '    Else
                            '        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '    End If

                            'ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                            '    If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                            '        If ExistenciaNegativa <> "SI" Then
                            '            If ExistenciaLote > 0 Then
                            '                Cantidad = ExistenciaLote
                            '                If TipoProducto <> "Servicio" Then
                            '                    If TipoProducto <> "Descuento" Then
                            '                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                            '                        MsgBox("Existencia Negativa: Disponible Lote" & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                            '                    Else
                            '                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                        End If
                            '                    End If
                            '                Else
                            '                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                    End If
                            '                End If
                            '            Else
                            '                Cantidad = 0
                            '                If TipoProducto <> "Servicio" Then
                            '                    If TipoProducto <> "Descuento" Then
                            '                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                            '                        MsgBox("Existencia Negativa: Disponible Lote" & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                            '                    Else
                            '                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                        End If
                            '                    End If
                            '                Else
                            '                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '                    End If
                            '                End If
                            '            End If
                            '        Else
                            '            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '            End If
                            '        End If
                            '    Else
                            '        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '    End If

                            'Else
                            '    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            '        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            '    End If
                            'End If


                        Case 2


                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" And IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                resul = BuscaExistenciaBodegaLote(Args)
                                ExistenciaLote = resul.Existencia_Lote

                                If ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                    If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                        If ExistenciaNegativa <> "SI" Then
                                            If Existencia > 0 Then
                                                Cantidad = Existencia
                                                If TipoProducto <> "Servicio" Then
                                                    If TipoProducto <> "Descuento" Then
                                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                    Else
                                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                        End If
                                                    End If
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                Cantidad = 0
                                                If TipoProducto <> "Servicio" Then
                                                    If TipoProducto <> "Descuento" Then
                                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                    End If
                                                End If
                                            End If
                                        Else
                                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If

                                    Else
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If

                                ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                    If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                        If ExistenciaNegativa <> "SI" Then
                                            If ExistenciaLote > 0 Then
                                                Cantidad = ExistenciaLote
                                                If TipoProducto <> "Servicio" Then
                                                    If TipoProducto <> "Descuento" Then
                                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                        MsgBox("Existencia Negativa: Disponible Lote" & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                    Else
                                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                        End If
                                                    End If
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                Cantidad = 0
                                                If TipoProducto <> "Servicio" Then
                                                    If TipoProducto <> "Descuento" Then
                                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                        MsgBox("Existencia Negativa: Disponible Lote" & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                    Else
                                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                        End If
                                                    End If
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            End If
                                        Else
                                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        End If
                                    Else
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If


                                Else
                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If
                                End If
                            End If

                            'Existencia


                            '/////////////////////////////////////////////////////////////////////////////////////////////////////
                            '//////////////////////////////////BUSCO SI EXISTE EL LOTE //////////////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////////
                            'Sql = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & NumeroLote & "')"
                            'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                            'DataAdapter.Fill(DataSet, "BuscaLote")
                            'If Not DataSet.Tables("BuscaLote").Rows.Count = 0 Then

                            'End If


                        Case 3

                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" And Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                Exit Sub
                            End If

                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote
                            'Existencia
                            If ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            Else
                                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                            End If


                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If


                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If
                        Case 4 'PrecioUnitario


                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" And Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                Exit Sub
                            End If

                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote
                            'Existencia
                            If ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                    End If
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If

                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If



                        Case 5
                            resul = BuscaExistenciaBodegaLote(Args)
                            ExistenciaLote = resul.Existencia_Lote
                            'Existencia
                            If ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                            End If
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text

                                End If


                            ElseIf ExistenciaLote < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If ExistenciaLote > 0 Then
                                            Cantidad = ExistenciaLote
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = ExistenciaLote
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible Lote " & ExistenciaLote, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If
                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If

                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If

                    End Select

                Else

                    Existencia = BuscaExistenciaBodega(CodProducto, CodigoBodega)

                    Select Case Cols
                        Case 0

                            CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                            DataAdapter.Fill(DataSet, "Productos")
                            If DataSet.Tables("Productos").Rows.Count = 0 Then
                                MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                                Exit Sub
                            Else
                                CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                                Me.TrueDBGridComponentes.Columns("Cantidad").Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                            End If
                            DataSet.Tables("Productos").Clear()


                        Case 1

                            If Existencia < Cantidad2 Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then

                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If

                        Case 2

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                Else
                                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                    End If
                                                End If
                                            Else
                                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If
                        Case 3

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                    End If
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                End If
                                            End If
                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If


                                Else
                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                    End If
                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If



                        Case 4

                            If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                                    End If
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                End If
                                            End If

                                        Else
                                            Cantidad = 0
                                            Descuento = 0
                                            If TipoProducto <> "Servicio" Then
                                                If TipoProducto <> "Descuento" Then
                                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                                    Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                                                    MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                                End If
                                            End If
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                            Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                        End If
                                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                        End If
                                    End If

                                Else
                                    If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                    End If
                                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                    End If
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Descuento").Text <> "" Then
                                    Descuento = (CDbl(Me.TrueDBGridComponentes.Columns("Descuento").Text) / 100)
                                End If
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                                End If
                            End If


                    End Select

                End If



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



                If FacturaTarea = True Then
                    If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                        If RespuestaIVA = "Sumando IVA del Producto" Then
                            Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                        Else
                            If Me.OptExsonerado.Checked = False Then
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) / (1 + TasaImpuesto)
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                            Else
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                            End If
                        End If
                    Else
                        Precio = 0
                    End If
                Else
                    If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                        If RespuestaIVA = "Sumando IVA del Producto" Then
                            Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                        Else
                            If Me.OptExsonerado.Checked = False Then
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) / (1 + TasaImpuesto)
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                            Else
                                Precio = CDbl(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text)
                            End If
                        End If
                    Else
                        Precio = 0
                    End If
                End If


                '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                If FacturaTarea = True Then
                    Select Case TipoDescuento
                        Case "ImporteFijo"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = ""
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If

                        Case "SubTotal"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = ""
                            SubTotal = Me.TxtSubTotal.Text
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                    End Select
                Else
                    Select Case TipoDescuento
                        Case "ImporteFijo"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = ""
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If

                        Case "SubTotal"
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = ""
                            SubTotal = Me.TxtSubTotal.Text
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                    End Select
                End If


                SubTotal = Cantidad * Precio
                Neto = SubTotal * (1 - Descuento)

                Select Case TipoProducto
                    Case "Productos"
                        SubTotal = Cantidad * Precio
                        Neto = SubTotal * (1 - Descuento)
                    Case "Descuento"
                        Neto = Math.Abs(Cantidad * Precio) * -1

                End Select

                If FacturaTarea = True Then
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio * (1 - Descuento), "##,##0.0000")
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                Else
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Precio * (1 - Descuento), "##,##0.0000")
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.0000")
                End If


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


                If Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = "" Then
                    MsgBox("Necesita Seleccionar un producto", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                Else

                    CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count = 0 Then
                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                        Exit Sub
                    End If
                End If





            End If

            'Me.TrueDBGridComponentes.Col = 2
            'ActualizaMETODOFactura()

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

    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroFactura As String
        Dim SqlString As String, CodTarea As String = "", CodigoProducto As String = "0000", iPosicion As Double = 0, CostoUnitario As Double = 0
        Dim Descuento As Double, PrecioUnitario As Double, PrecioNeto As Double, Cantidad As Double, NumeroLote As String, Sql As String, Monto As Double
        Dim TasaCambio As Double = 0
        Dim RstCosto As New RstCostoPromedio

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroFacturas"
            NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
            If NumeroFactura = "-00001" Then
                Me.TxtNumeroEnsamble.Text = "-----0-----"
                e.Cancel = True
            Else
                Me.TxtNumeroEnsamble.Text = NumeroFactura
            End If
        End If

        '//////////////////////////////////////////////////////BUSCO EL LIMITE DE CREDITO DE UN CLIENTE //////////////////////////////////////////
        TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
        If Me.TrueDBGridComponentes.Columns("Importe").Text <> "" Then
            Monto = Me.TrueDBGridComponentes.Columns("Importe").Text
        Else
            Monto = 0
        End If

        If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
            Me.TrueDBGridComponentes.Columns("Importe").Text = 0
        End If

        If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = "" Then
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = 0
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = 0
            Me.TrueDBGridComponentes.Columns("Importe").Text = 0
        End If


        If Me.TxtMonedaFactura.Text <> MonedaLimiteCredito Then
            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                LimiteCredito = LimiteCredito * TasaCambio
            Else
                LimiteCredito = LimiteCredito / TasaCambio
            End If
        End If

        'If Me.CboTipoProducto.Text = "Factura" Then
        '    If (SaldoClienteH + Monto) > LimiteCredito Then
        '        MsgBox("Limite Credito Excedido", MsgBoxStyle.Critical, "Zeus Facturacion")
        '        e.Cancel = True
        '    End If
        'End If


        If FacturaTarea = True Then
            If Me.TrueDBGridComponentes.Columns("CodTarea").Text = "" Then
                '////////////////////////////////////////////////////////////////////////////////////
                '////////////////////BUSCO SI EL PRODUCTO ES UN SERVICIO //////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////
                CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                Sql = "SELECT * FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "TipoProducto")
                If DataSet.Tables("TipoProducto").Rows.Count = 0 Then
                    If DataSet.Tables("TipoProducto").Rows(0)("Tipo_Producto") <> "Servicio" Or DataSet.Tables("TipoProducto").Rows(0)("Tipo_Producto") <> "Descuento" Then
                        MsgBox("Se necesita el Codigo de la Tarea", MsgBoxStyle.Critical, "Zeus Facturacion")
                        e.Cancel = True
                    End If
                End If

                DataSet.Tables("TipoProducto").Reset()

            Else

                If FacturaLotes = True Then
                    If Me.TrueDBGridComponentes.Columns("CodTarea").Text <> "" Then
                        NumeroLote = Me.TrueDBGridComponentes.Columns("CodTarea").Text


                        Sql = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & NumeroLote & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaLote")
                        If DataSet.Tables("BuscaLote").Rows.Count = 0 Then
                            MsgBox("Este Lote no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            e.Cancel = True
                            Exit Sub
                        End If

                        DataSet.Tables("BuscaLote").Reset()

                    End If
                End If

            End If

            Me.TrueDBGridComponentes.Columns("Numero_Factura").Text = Me.TxtNumeroEnsamble.Text
            Me.TrueDBGridComponentes.Columns("Fecha_Factura").Text = Me.DTPFecha.Value
            Me.TrueDBGridComponentes.Columns("Tipo_Factura").Text = Me.CboTipoProducto.Text
        Else
            Me.TrueDBGridComponentes.Columns("Numero_Factura").Text = Me.TxtNumeroEnsamble.Text
            Me.TrueDBGridComponentes.Columns("Fecha_Factura").Text = Me.DTPFecha.Value
            Me.TrueDBGridComponentes.Columns("Tipo_Factura").Text = Me.CboTipoProducto.Text

            iPosicion = Me.BindingDetalle.Position
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cod_Producto")) Then
                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            End If
            Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = Me.TxtNumeroEnsamble.Text
            Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
            Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
                Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            Else
                PrecioUnitario = 0
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            Else
                Cantidad = 0
            End If

            If IsNumeric(Me.BindingDetalle.Item(iPosicion)("Descuento")) = True Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                PrecioNeto = PrecioUnitario * (1 - (Descuento / 100))
            Else
                Descuento = 0
                PrecioNeto = PrecioUnitario * (1 - (Descuento / 100))

            End If

            If EsDescuento(CodigoProducto) = True Then
                Me.BindingDetalle.Item(iPosicion)("Precio_Neto") = Format(PrecioNeto, "##,##0.0000")
                Me.BindingDetalle.Item(iPosicion)("Importe") = Format(PrecioNeto * Cantidad * -1, "##,##0.0000")
            Else
                Me.BindingDetalle.Item(iPosicion)("Precio_Neto") = Format(PrecioNeto, "##,##0.0000")
                Me.BindingDetalle.Item(iPosicion)("Importe") = Format(PrecioNeto * Cantidad, "##,##0.0000")
            End If




            CostoUnitario = 0

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                'Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
            Else
                RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                CostoUnitario = RstCosto.Costo_Cordoba
                Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
            End If


        End If
    End Sub


        Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String
        Dim CodProducto As String, TipoProducto As String = "Servicio", TipoDescuento As String = "ImporteFijo", PrecioDescCordobas As Double, PrecioDescDolar As Double
        Dim Cantidad As Double, Precio As Double, SubTotal As Double, PorcientoDescuento As Double, Neto As Double, CodigoAlterno As String = ""
        Dim Categoria As String = "", PrecioTipo As Double = 0, CostoUnitario As Double
        Dim RstCosto As New RstCostoPromedio

        'Try



        Select Case Me.TrueDBGridComponentes.Col
            Case 0
                If Me.TxtMonedaFactura.Text = "Dolares" Then
                    Quien = "CodigoProductosFactura"
                Else
                    Quien = "CodigoProductosCordobas"
                End If


                My.Forms.FrmConsultas.ShowDialog()



                If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
                    Exit Sub
                End If

                Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                CodProducto = My.Forms.FrmConsultas.Codigo

                'CostoUnitario = CostoPromedio(CodProducto)

                If FacturaTarea = True Then

                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion


                    If Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = "" Then
                        RstCosto = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                        'RstCosto = CostoPromedioKardex2(CodProducto, Me.DTPFecha.Value)
                        CostoUnitario = RstCosto.Costo_Cordoba
                    Else
                        CostoUnitario = Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text
                    End If

                    '////////////////INICIO EL PROCESO DE LOS HILOS //////////////
                    Me.TrueDBGridComponentes.Col = 2
                    Me.TrueDBGridComponentes.Columns("CodTarea").Text = LoteDefectoWorker(My.Forms.FrmConsultas.Codigo, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)
                    My.Application.DoEvents()


                    Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = CostoUnitario


                    '////////////////////////////BUSCO UN LOTE PARA DEFINIRLO /////////////////////////////

                    If Me.ChkPorcientoTarjeta.Checked = True Then
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(My.Forms.FrmConsultas.Precio * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                    Else
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                    End If

                Else
                    CodProducto = My.Forms.FrmConsultas.Codigo

                    If Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = "" Then
                        RstCosto = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                        CostoUnitario = RstCosto.Costo_Cordoba
                    Else
                        CostoUnitario = Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text
                    End If


                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo

                    'CostoUnitario = CostoPromedioKardex(My.Forms.FrmConsultas.Codigo, Me.DTPFecha.Value)
                    Me.TrueDBGridComponentes.Columns("Costo_Unitario").Text = CostoUnitario

                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////BUSCO EL CODIGO SAC ////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    SqlProveedor = "SELECT * FROM Codigos_Alternos WHERE (Cod_Producto = '" & My.Forms.FrmConsultas.Codigo & "') AND (Descripcion_Producto = 'SAC')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Alternos")
                    If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                        CodigoAlterno = DataSet.Tables("Alternos").Rows(0)("Cod_Alternativo")
                        Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = Trim(My.Forms.FrmConsultas.Descripcion) & " ,SAC: " & CodigoAlterno
                    Else
                        Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = Trim(My.Forms.FrmConsultas.Descripcion)
                    End If

                    'Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                    If Me.ChkPorcientoTarjeta.Checked = True Then
                        PrecioTipo = BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns(0).Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text)
                        If PrecioTipo = 0 Then
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(My.Forms.FrmConsultas.Precio * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                        Else
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioTipo * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                        End If
                    Else
                        PrecioTipo = BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns(0).Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text)
                        If PrecioTipo = 0 Then
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                        Else
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = PrecioTipo
                        End If
                    End If

                    Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text, Me.TxtMonedaFactura.Text)

                    If Me.TrueDBGridComponentes.Columns("Descuento").Text = "" Then
                        If Categoria <> "" Then
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = Categoria
                        Else
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = 0
                        End If
                    End If

                    Me.TrueDBGridComponentes.Col = 2
                End If

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
                    If Me.CboTipoProducto.Text = "Salida Bodega" Then

                        '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                        SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                        DataAdapter.Fill(DataSet, "Costo")
                        If DataSet.Tables("Costo").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                If FacturaTarea = True Then
                                    'Me.TrueDBGridComponentes.Columns(4).Text = PrecioDescCordobas
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = CostoUnitario
                                Else
                                    'Me.TrueDBGridComponentes.Columns(3).Text = PrecioDescCordobas
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = CostoUnitario
                                End If
                            End If
                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                            End If
                        End If
                        DataSet.Tables("Costo").Reset()

                    ElseIf Me.CboTipoProducto.Text = "Orden de Trabajo" Then

                        '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                        SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                        DataAdapter.Fill(DataSet, "Costo")
                        If DataSet.Tables("Costo").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                If FacturaTarea = True Then
                                    'Me.TrueDBGridComponentes.Columns(4).Text = PrecioDescCordobas
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = CostoUnitario
                                Else
                                    'Me.TrueDBGridComponentes.Columns(3).Text = PrecioDescCordobas
                                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = CostoUnitario
                                End If
                            End If
                            If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                            End If
                        End If
                        DataSet.Tables("Costo").Reset()
                    Else
                        If BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns(0).Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text) = 0 Then
                            PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                            PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                        Else
                            PrecioDescCordobas = BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text)
                            PrecioDescDolar = BuscaPrecioTipo(Me.TrueDBGridComponentes.Columns("Cod_Producto").Text, Me.CboCodigoBodega.Text, Me.TxtMonedaFactura.Text)
                        End If
                    End If

                End If

                '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                Select Case TipoDescuento
                    Case "ImporteFijo"
                        If FacturaTarea = True Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If
                        Else

                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescCordobas, "##,##0.00")
                                Precio = PrecioDescCordobas
                            Else
                                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(PrecioDescDolar, "##,##0.00")
                                Precio = PrecioDescDolar
                            End If
                        End If

                    Case "SubTotal"

                        If FacturaTarea = True Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            SubTotal = Me.TxtSubTotal.Text
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                        Else
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
                            Cantidad = 1
                            Me.TrueDBGridComponentes.Columns("Descuento").Text = "0"
                            If Me.TxtSubTotal.Text <> "" Then
                                SubTotal = Me.TxtSubTotal.Text
                            Else
                                SubTotal = 0
                            End If
                            If PrecioDescCordobas <> 0 Then
                                PorcientoDescuento = (PrecioDescCordobas / 100)
                            End If
                            Precio = SubTotal * PorcientoDescuento
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = Format(Precio, "##,##0.00")
                        End If


                End Select



                Select Case TipoProducto
                    Case "Servicio"
                        If FacturaTarea = True Then
                            SubTotal = Cantidad * Precio
                            Neto = SubTotal
                            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                        Else
                            SubTotal = Cantidad * Precio
                            Neto = SubTotal
                            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                        End If
                    Case "Descuento"
                        If FacturaTarea = True Then
                            Neto = Math.Abs(Cantidad * Precio) * -1
                            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                        Else
                            Neto = Math.Abs(Cantidad * Precio) * -1
                            Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(Cantidad * Precio, "##,##0.00")
                            Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Neto, "##,##0.00")
                        End If

                End Select




                If Acceso <> "Administrador" Then
                    If Me.CboTipoProducto.Text = "Cotizacion" Then
                        If FacturaTarea = True Then
                            Me.GroupBox3.Enabled = False
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                        Else
                            Me.GroupBox3.Enabled = False
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
                        End If
                    Else
                        If FacturaTarea = True Then
                            Me.GroupBox3.Enabled = True
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                        Else
                            Me.GroupBox3.Enabled = True
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                        End If

                    End If
                End If

                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = False

            Case 2
                If FacturaTarea = True Then
                    Quien = "CodigoTarea"
                    'My.Forms.FrmConsultas.ShowDialog()

                    Dim Posicion As Double
                    If Me.BindingDetalle.Count <> 0 Then

                        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                        SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count <> 0 Then
                            TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                        End If
                        DataSet.Tables("Productos").Reset()

                        My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                        Posicion = Me.BindingDetalle.Position
                        My.Forms.FrmLotesFactura.CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text    'Me.BindingDetalle.Item(Posicion)("Cod_Productos")
                        My.Forms.FrmLotesFactura.NombreProducto = Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text   'Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                        My.Forms.FrmLotesFactura.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                        My.Forms.FrmLotesFactura.Fecha = Me.DTPFecha.Value
                        My.Forms.FrmLotesFactura.LblProducto.Text = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text + " " + Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text
                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then    'Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                            My.Forms.FrmLotesFactura.Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                        Else
                            My.Forms.FrmLotesFactura.Cantidad = 1
                        End If
                        My.Forms.FrmLotesFactura.LblCantidad.Text = Me.TrueDBGridComponentes.Columns("Cantidad").Text  'Me.BindingDetalle.Item(Posicion)("Cantidad")
                        My.Forms.FrmLotesFactura.CodigoBodega = Me.CboCodigoBodega.Text
                        My.Forms.FrmLotesFactura.TipoDocumento = Me.CboTipoProducto.Text
                        My.Forms.FrmLotesFactura.ShowDialog()
                    End If


                    If TipoProducto <> "Servicio" Then
                        If TipoProducto <> "Descuento" Then
                            If My.Forms.FrmLotesFactura.NLotes <> "" Then
                                Me.TrueDBGridComponentes.Columns("CodTarea").Text = My.Forms.FrmLotesFactura.NLotes
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                End If
                            End If
                        End If
                    End If
                    'Me.TrueDBGridComponentes.Columns(13).Text = My.Forms.FrmLotesFactura.NLotes
                    'Me.TrueDBGridComponentes.Columns(14).Text = My.Forms.FrmLotesFactura.Fecha


                End If
        End Select






        '    Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        End Sub


        Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
            Quien = "Facturas"
            My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            If Not My.Forms.FrmConsultas.TipoCompra = Nothing Then
                Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
                Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
                Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.NumFactura
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False

                SalirFactura = True


                If PermiteEditar(Acceso, "Facturacion") = False Then
                    If Me.CboTipoProducto.Text = "Facturacion" Then
                        Me.ButtonAgregar.Enabled = False
                    End If
                    'Me.TrueDBGridComponentes.Enabled = False

                Else
                    Me.ButtonAgregar.Enabled = True
                    Me.TrueDBGridComponentes.Enabled = True


                End If
            End If
        End If
        End Sub

        Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
            Dim NumeroFactura As String, iPosicion As Double, Registros As Double
            Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
            Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, Fecha As String, IdDetalle As Double
            Dim Descripcion_Producto As String, TipoFactura As String, FacturaBodega As Boolean = False, FacturaSerie As Boolean = False, CompraBodega As Boolean = False
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Existencia As Double
        Dim NumeroCotizacion As String, Fecha_Factura As Date
        Dim ExistenciaNegativa As String, SqlDatos As String, CostoUnitario As Double = 0
        Dim RstCosto As New RstCostoPromedio

        'Try

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            'Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            'Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If


        ' ''Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '' ''//////////////////////////////////////////////////////////////////////////////////////////////
        '' ''////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
        '' ''/////////////////////////////////////////////////////////////////////////////////////////////////
        ' ''SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
        ' ''             "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        ' ''MiConexion.Open()
        ' ''ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        ' ''iResultado = ComandoUpdate.ExecuteNonQuery
        ' ''MiConexion.Close()

        NumeroCotizacion = Me.TxtNumeroEnsamble.Text
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Me.CboTipoProducto.Text = "Factura"
        TipoFactura = "Factura"
        Me.TxtNumeroEnsamble.Text = "-----0-----"

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Select Case Me.CboTipoProducto.Text
        '    Case "Cotizacion"
        '        ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
        '    Case "Factura"
        '        If ConsecutivoFacturaManual = False Then
        '            ConsecutivoFactura = BuscaConsecutivo("Factura")
        '        Else
        '            FrmConsecutivos.ShowDialog()
        '            ConsecutivoFactura = FrmConsecutivos.NumeroFactura
        '        End If
        '    Case "Devolucion de Venta"
        '        ConsecutivoFactura = BuscaConsecutivo("DevFactura")
        '    Case "Transferencia Enviada"
        '        ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
        '    Case "Salida Bodega"
        '        ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
        'End Select


        'NumeroFactura = Format(ConsecutivoFactura, "0000#")

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

        '    If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacSerie")) Then
        '        FacturaSerie = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacSerie")
        '    End If

        'End If

        'If FacturaBodega = True Then
        '    NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
        'Else
        '    NumeroFactura = Format(ConsecutivoFactura, "0000#")
        'End If


        'NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
        NumeroFactura = GenerarNumeroFactura(True, Me.CboTipoProducto.Text)


        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COTIZACION///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False', [Nuestra_Referencia] = '" & NumeroFactura & "' " & _
                     "WHERE  (Numero_Factura = '" & NumeroCotizacion & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Cotizacion')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Quien = "NumeroFacturas"
        'Me.TxtNumeroEnsamble.Text = "-----0-----"

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Fecha_Factura = Format(Now, "dd/MM/yyyy")

        My.Forms.FrmFecha.ShowDialog()
        Fecha_Factura = Format(My.Forms.FrmFecha.DTPFechaRequerido.Value, "dd/MM/yyyy")
        Me.DTPFecha.Value = Fecha_Factura
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Dim TablaFactura As TablaFactura = New TablaFactura

        TablaFactura.Numero_Factura = NumeroFactura
        TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        TablaFactura.Tipo_Factura = CboTipoProducto.Text
        TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
        TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
        TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
        TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
        TablaFactura.CodBodega1 = CboCodigoBodega.Text
        TablaFactura.Cod_Cajero = CboCajero.Text
        TablaFactura.Nombre_Cliente = TxtNombres.Text
        TablaFactura.Apellido_Cliente = TxtApellidos.Text
        TablaFactura.Direccion_Cliente = TxtDireccion.Text
        TablaFactura.Telefono_Cliente = TxtTelefono.Text
        TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Via_Envarque = ""
        TablaFactura.SuReferencia1 = CboReferencia.Text
        TablaFactura.Nuestra_Referencia = ""
        TablaFactura.Codigo_Proyecto = CboProyecto.Text




        If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
            TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        Else
            TablaFactura.Sub_Total = 0
        End If

        If My.Forms.FrmFacturas.IvaGral <> 0 Then
            TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        Else
            TablaFactura.IVA_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
            TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        Else
            TablaFactura.Pagado_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
            TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        Else
            TablaFactura.Neto_Pagar = 0
        End If

        If RadioButton1.Checked = True Then
            TablaFactura.Metodo_Pago = "Credito"
        Else
            TablaFactura.Metodo_Pago = "Contado"
        End If

        If OptExsonerado.Checked = True Then
            TablaFactura.Exonerado_Factura = 1
        Else
            TablaFactura.Exonerado_Factura = 0
        End If

        If OptRet1Porciento.Checked = True Then
            TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
            TablaFactura.Retener1_Porciento = 1
        Else
            TablaFactura.MontoRetencion1_Porciento = 0
            TablaFactura.Retener1_Porciento = 0
        End If

        If OptRet2Porciento.Checked = True Then
            TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
            TablaFactura.Retener2_Porciento = 1
        Else
            TablaFactura.MontoRetencion2_Porciento = 0
            TablaFactura.Retener2_Porciento = 0
        End If


        If Not CboProyecto.Text = "" Then
            TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If

        If CboReferencia.Text <> "" Then
            TablaFactura.Referencia_Factura = CboReferencia.Text
        End If

        TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))


        GrabaFacturas(TablaFactura)
        Quien = "NumeroFacturas"
        Me.TxtNumeroEnsamble.Text = NumeroFactura

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Facturas]  SET [Nuestra_Referencia] = '" & NumeroCotizacion & "' " & _
                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0

        Do While iPosicion < Registros

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            Else
                IdDetalle = -1
            End If

            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
            'Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
            'Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
            'Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
            Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

            'IdDetalle = -1

            'CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            ExistenciaNegativa = ValidarExistenciaNegativa(CodigoProducto)
            Existencia = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            Else
                Descuento = 0
            End If
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            Else
                Cantidad = 0
            End If
            Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

            If Existencia < Cantidad Then
                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                    If ExistenciaNegativa <> "SI" Then
                        If Existencia > 0 Then
                            Cantidad = Existencia
                            Importe = PrecioNeto * Cantidad
                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                        Else
                            Cantidad = 0
                            Descuento = 0
                            Importe = 0
                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                        End If
                    End If
                End If
            End If



            'If FacturaTarea = True Then
            '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)

            'Else
            '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
            'End If

            RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
            CostoUnitario = RstCosto.Costo_Cordoba

            GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)


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

        'da.Update(ds.Tables("DetalleFactura"))
        'ds.Tables("DetalleFactura").Clear()


        '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
        SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas  " & _
            "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleFacturas")
        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
        ds = New DataSet
        da = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleFactura")
        Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
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
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False


        '////////////////////////////ACTUALIZO TODO POR CUALQUIER CAMBIO /////////////////////////////////
        ActualizaMETODOFactura()
        'GrabaFacturas(NumeroFactura)

        '    Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

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
            Dim Cantidad As Double, PrecioProducto As Double, Descuento As Double, PrecioNeto As Double, Total As Double
            Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String
            Dim CodProducto As String, TipoProducto As String = "Servicio", TipoDescuento As String = "ImporteFijo", PrecioDescCordobas As Double, PrecioDescDolar As Double
        Dim Precio As Double, SubTotal As Double, PorcientoDescuento As Double, Neto As Double, SQl As String = "", Categoria As String

        Select Case e.KeyCode

            '           Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            'Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            'Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 227
            ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            'Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Tarea"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Width = 54
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            'Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            'Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio Unit"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            'Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            'Me.TrueDBGridComponentes.Columns("Descuento").DefaultValue = 0
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            'Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Precio Neto"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            'Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Locked = True
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Costo_Unitario").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Factura").Visible = False
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Factura").Visible = False

            Case 13

                Select Case Me.TrueDBGridComponentes.Col
                    Case 0
                        Dim Posicion As Double
                        If Me.TrueDBGridComponentes.Columns("Cod_Producto").Text <> "" Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1

                            If FacturaTarea = False Then
                                Me.TrueDBGridComponentes.Col = 2
                            Else
                                Me.TrueDBGridComponentes.Col = 2
                            End If

                            If PedirCantEscaner = False Then
                                '///////////////////////////////////////SI NO REQUIERE ESPESIFICAR CANTIDAD PASO A LA SIGUIENTE LINEA //////////////////////
                                Posicion = Me.TrueDBGridComponentes.Row
                                Me.TrueDBGridComponentes.Row = Posicion + 1
                                Me.TrueDBGridComponentes.Col = 0
                            End If
                        End If

                    Case 2
                            Dim Posicion As Double, CodigoBodega As String = "", ExistenciaNegativa As String = "NO", RespuestaIVA As String = "Sumando IVA del Producto"
                            Dim CodImpuesto As String = "", Existencia As Double = 0, Tasa As Double = 0                         '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////////////////////BUSCO LA CONFIGURACION DEL PRECIO///////////////////////////////////////////////////
                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            SQl = "SELECT  * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
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
                                ExistenciaNegativa = DataSet.Tables("Productos").Rows(0)("Existencia_Negativa")
                            End If

                            'Existencia = ExistenciaProducto(CodProducto)
                            CodigoBodega = Me.CboCodigoBodega.Text
                            Existencia = BuscaExistenciaBodega(CodProducto, CodigoBodega)
                            Descuento = 0
                            Tasa = 0

                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                            Exit Sub
                        End If



                        If Existencia < Me.TrueDBGridComponentes.Columns("Cantidad").Text Then
                            If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                If ExistenciaNegativa <> "SI" Then
                                    If Existencia > 0 Then
                                        Cantidad = Existencia
                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                    Else
                                        Cantidad = 0
                                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                                        MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                    End If
                                Else
                                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                    End If
                                End If

                            Else
                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            End If
                        Else
                            If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            End If
                        End If




                        If Me.ChkPorcientoTarjeta.Checked = True Then

                            If Not Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
                                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                            Else
                                Cantidad = 0
                            End If

                            Precio = Me.TrueDBGridComponentes.Columns(4).Text
                            Precio = Format(Precio * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                            Me.TrueDBGridComponentes.Columns(3).Text = Precio

                            Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns(0).Text, Me.TrueDBGridComponentes.Columns(3).Text, Me.TxtMonedaFactura.Text)

                            If Me.TrueDBGridComponentes.Columns(4).Text = "" Then
                                If Categoria <> "" Then
                                    Me.TrueDBGridComponentes.Columns(4).Text = Categoria
                                Else
                                    Me.TrueDBGridComponentes.Columns(4).Text = 0
                                End If
                            End If

                            Me.TrueDBGridComponentes.Columns(5).Text = Cantidad * Precio
                            Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                        Else
                            If Not Me.TrueDBGridComponentes.Columns(2).Text = "" Then
                                Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                            Else
                                Cantidad = 0
                            End If
                            Precio = Me.TrueDBGridComponentes.Columns(3).Text

                            If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
                                Me.TrueDBGridComponentes.Columns(3).Text = 0
                            End If
                            Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                            Me.TrueDBGridComponentes.Columns(6).Text = Format(Cantidad * Precio, "##,##0.00")
                        End If




                            Posicion = Me.TrueDBGridComponentes.Row
                            Me.TrueDBGridComponentes.Row = Posicion + 1
                            Me.TrueDBGridComponentes.Col = 0


                    Case 3
                            Dim Posicion As Double, CodigoBodega As String = "", ExistenciaNegativa As String = "NO", RespuestaIVA As String = "Sumando IVA del Producto"
                            Dim CodImpuesto As String = "", Existencia As Double = 0, Tasa As Double = 0                         '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////////////////////BUSCO LA CONFIGURACION DEL PRECIO///////////////////////////////////////////////////
                            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            SQl = "SELECT  * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
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
                                ExistenciaNegativa = DataSet.Tables("Productos").Rows(0)("Existencia_Negativa")
                            End If

                            'Existencia = ExistenciaProducto(CodProducto)
                            CodigoBodega = Me.CboCodigoBodega.Text
                            Existencia = BuscaExistenciaBodega(CodProducto, CodigoBodega)
                            Descuento = 0
                            Tasa = 0

                            If Not IsNumeric(Me.TrueDBGridComponentes.Columns(2).Text) Then
                                Exit Sub
                            End If



                            If Existencia < Me.TrueDBGridComponentes.Columns(2).Text Then
                                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                                    If ExistenciaNegativa <> "SI" Then
                                        If Existencia > 0 Then
                                            Cantidad = Existencia
                                            Me.TrueDBGridComponentes.Columns(2).Text = Existencia
                                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                        Else
                                            Cantidad = 0
                                            Me.TrueDBGridComponentes.Columns(2).Text = 0
                                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                                        End If
                                    Else
                                        If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                                            Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                        End If
                                    End If

                                Else
                                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                End If
                            Else
                                If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                End If
                            End If

                            If Me.ChkPorcientoTarjeta.Checked = True Then
                                If Not Me.TrueDBGridComponentes.Columns(2).Text = "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                Else
                                    Cantidad = 0
                                End If

                                Precio = Me.TrueDBGridComponentes.Columns(4).Text
                                Precio = Format(Precio * (1 + (IncrementoTarjeta / 100)), "##,##0.00")
                                Me.TrueDBGridComponentes.Columns(3).Text = Precio

                                Categoria = CategoriaPrecio(Me.TrueDBGridComponentes.Columns(0).Text, Me.TrueDBGridComponentes.Columns(3).Text, Me.TxtMonedaFactura.Text)

                                If Me.TrueDBGridComponentes.Columns(4).Text = "" Then
                                    If Categoria <> "" Then
                                        Me.TrueDBGridComponentes.Columns(4).Text = Categoria
                                    Else
                                        Me.TrueDBGridComponentes.Columns(4).Text = 0
                                    End If
                                End If

                                Me.TrueDBGridComponentes.Columns(5).Text = Cantidad * Precio
                                Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                            Else
                                If Not Me.TrueDBGridComponentes.Columns(2).Text = "" Then
                                    Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                                Else
                                    Cantidad = 0
                                End If
                                Precio = Me.TrueDBGridComponentes.Columns(3).Text

                                If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
                                    Me.TrueDBGridComponentes.Columns(3).Text = 0
                                End If
                                Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                                Me.TrueDBGridComponentes.Columns(6).Text = Format(Cantidad * Precio, "##,##0.00")
                            End If


                            Posicion = Me.TrueDBGridComponentes.Row
                            Me.TrueDBGridComponentes.Row = Posicion + 1
                            Me.TrueDBGridComponentes.Col = 0



                End Select




            Case 123
                My.Forms.FrmPermisos.ShowDialog()
                If My.Forms.FrmPermisos.RContraseña = True Then
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                End If

            Case 113

                Select Case Me.TrueDBGridComponentes.Col
                    Case 0
                        If Me.TxtMonedaFactura.Text = "Dolares" Then
                            Quien = "CodigoProductosFactura"
                        Else
                            Quien = "CodigoProductosCordobas"
                        End If
                        My.Forms.FrmConsultas.ShowDialog()

                        If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
                            Exit Sub
                        End If

                        If FacturaTarea = True Then
                            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                            Me.TrueDBGridComponentes.Col = 2
                            Me.TrueDBGridComponentes.Columns(4).Text = My.Forms.FrmConsultas.Precio
                        Else
                            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
                            Me.TrueDBGridComponentes.Col = 2
                        End If

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
                            If Me.CboTipoProducto.Text = "Salida Bodega" Then

                                '///////////////////////////////////////////BUSCO EL COSTO PROMEDIO PARA LA BODEGA ////////////////////////////////////////
                                SqlProveedor = "SELECT  * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodProducto & "')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                                DataAdapter.Fill(DataSet, "Costo")
                                If DataSet.Tables("Costo").Rows.Count <> 0 Then
                                    If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("Costo")) Then
                                        PrecioDescCordobas = DataSet.Tables("Costo").Rows(0)("Costo")
                                        Me.TrueDBGridComponentes.Columns(4).Text = PrecioDescCordobas
                                    End If
                                    If Not IsDBNull(DataSet.Tables("Costo").Rows(0)("CostoDolar")) Then
                                        PrecioDescDolar = DataSet.Tables("Costo").Rows(0)("CostoDolar")
                                    End If
                                End If
                                DataSet.Tables("Costo").Reset()
                            Else
                                PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                                PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
                            End If

                        End If

                        '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
                        Select Case TipoDescuento
                            Case "ImporteFijo"
                                If FacturaTarea = True Then
                                    Me.TrueDBGridComponentes.Columns(3).Text = 1
                                    Cantidad = 1
                                    Me.TrueDBGridComponentes.Columns(5).Text = ""
                                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                                        Me.TrueDBGridComponentes.Columns(4).Text = Format(PrecioDescCordobas, "##,##0.00")
                                        Precio = PrecioDescCordobas
                                    Else
                                        Me.TrueDBGridComponentes.Columns(4).Text = Format(PrecioDescDolar, "##,##0.00")
                                        Precio = PrecioDescDolar
                                    End If
                                Else

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
                                End If

                            Case "SubTotal"

                                If FacturaTarea = True Then
                                    Me.TrueDBGridComponentes.Columns(3).Text = 1
                                    Cantidad = 1
                                    Me.TrueDBGridComponentes.Columns(5).Text = ""
                                    SubTotal = Me.TxtSubTotal.Text
                                    If PrecioDescCordobas <> 0 Then
                                        PorcientoDescuento = (PrecioDescCordobas / 100)
                                    End If
                                    Precio = SubTotal * PorcientoDescuento
                                    Me.TrueDBGridComponentes.Columns(4).Text = Format(Precio, "##,##0.00")
                                Else
                                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                                    Cantidad = 1
                                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                                    SubTotal = Me.TxtSubTotal.Text
                                    If PrecioDescCordobas <> 0 Then
                                        PorcientoDescuento = (PrecioDescCordobas / 100)
                                    End If
                                    Precio = SubTotal * PorcientoDescuento
                                    Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")
                                End If


                        End Select



                        Select Case TipoProducto
                            Case "Servicio"
                                If FacturaTarea = True Then
                                    SubTotal = Cantidad * Precio
                                    Neto = SubTotal
                                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Cantidad * Precio, "##,##0.00")
                                    Me.TrueDBGridComponentes.Columns(7).Text = Format(Neto, "##,##0.00")
                                Else
                                    SubTotal = Cantidad * Precio
                                    Neto = SubTotal
                                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")
                                End If
                            Case "Descuento"
                                If FacturaTarea = True Then
                                    Neto = Math.Abs(Cantidad * Precio) * -1
                                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Cantidad * Precio, "##,##0.00")
                                    Me.TrueDBGridComponentes.Columns(7).Text = Format(Neto, "##,##0.00")
                                Else
                                    Neto = Math.Abs(Cantidad * Precio) * -1
                                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")
                                End If

                        End Select




                        If Acceso <> "Administrador" Then
                            If Me.CboTipoProducto.Text = "Cotizacion" Then
                                If FacturaTarea = True Then
                                    Me.GroupBox3.Enabled = False
                                    Me.TrueDBGridComponentes.Columns(4).Caption = "Precio Unit"
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 62
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = False
                                Else
                                    Me.GroupBox3.Enabled = False
                                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                                End If
                            Else
                                If FacturaTarea = True Then
                                    Me.GroupBox3.Enabled = True
                                    Me.TrueDBGridComponentes.Columns(4).Caption = "Precio Unit"
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 62
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
                                Else
                                    Me.GroupBox3.Enabled = True
                                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
                                End If

                            End If
                        End If

                        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = False

                    Case 2
                        If FacturaTarea = True Then
                            Quien = "CodigoTarea"
                            My.Forms.FrmConsultas.ShowDialog()

                            If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
                                Exit Sub
                            End If
                            Me.TrueDBGridComponentes.Columns(2).Text = My.Forms.FrmConsultas.Codigo
                        End If


                    Case Else
                        My.Forms.FrmPreciosProductos.CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                        My.Forms.FrmPreciosProductos.NombreProducto = Me.TrueDBGridComponentes.Columns(1).Text
                        My.Forms.FrmPreciosProductos.TrueDBGridComponentes.AllowUpdate = False
                        My.Forms.FrmPreciosProductos.cmdAddDocente.Visible = False
                        My.Forms.FrmPreciosProductos.CmdPegar.Visible = True
                        My.Forms.FrmPreciosProductos.ButtonBorrar.Visible = False
                        My.Forms.FrmPreciosProductos.ShowDialog()


                        Me.TrueDBGridComponentes.Columns(3).Text = Format(My.Forms.FrmPreciosProductos.PrecioProducto, "##,##0.00")
                        PrecioProducto = My.Forms.FrmPreciosProductos.PrecioProducto
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                        If Val(Me.TrueDBGridComponentes.Columns(4).Text) = 0 Then
                            Descuento = 0
                        Else
                            Descuento = Me.TrueDBGridComponentes.Columns(0).Text
                        End If
                        PrecioNeto = PrecioProducto * (1 - (Descuento / 100))
                        Total = Cantidad * PrecioNeto

                        Me.TrueDBGridComponentes.Columns(5).Text = Format(PrecioNeto, "##,##0.00")
                        Me.TrueDBGridComponentes.Columns(6).Text = (Format(Total, "##,##0.00"))


                        'My.Forms.FrmPreciosProductos.CodProducto = Me.CboCodigoProducto.Text
                        'My.Forms.FrmPreciosProductos.NombreProducto = Me.TxtNombreProducto.Text
                End Select
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroFactura As String

        Try

            Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If



            FechaFactura = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se elimino Producto: " & CodProducto & " " & Me.TxtNumeroEnsamble.Text)

            iPosicion = Me.BindingDetalle.Position
            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
            '    idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            'Else
            '    idDetalle = -1
            'End If

            'PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")

            'If IsNumeric(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            '        Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            '    End If
            'Else
            '    Descuento = 0
            'End If

            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
            '    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            'End If
            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
            '    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            'End If
            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
            '    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            'Else
            '    Cantidad = 0
            'End If
            'NombreProducto = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

            ''Me.BindingDetalle.RemoveCurrent()

            If Me.BindingDetalle.Count <> 0 Then

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                oDataRow = ds.Tables("DetalleFactura").Rows(iPosicion)
                oDataRow.Delete()

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
                oTablaBorrados = ds.Tables("DetalleFactura").GetChanges(DataRowState.Deleted)
                If Not IsNothing(oTablaBorrados) Then
                    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                    da.Update(oTablaBorrados)
                End If
                ds.Tables("DetalleFactura").AcceptChanges()
                da.Update(ds.Tables("DetalleFactura"))



                NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)

                ActualizaMETODOFactura()

                Dim TablaFactura As TablaFactura = New TablaFactura

                TablaFactura.Numero_Factura = NumeroFactura
                TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                TablaFactura.Tipo_Factura = CboTipoProducto.Text
                TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
                TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
                TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
                TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
                TablaFactura.CodBodega1 = CboCodigoBodega.Text
                TablaFactura.Cod_Cajero = CboCajero.Text
                TablaFactura.Nombre_Cliente = TxtNombres.Text
                TablaFactura.Apellido_Cliente = TxtApellidos.Text
                TablaFactura.Direccion_Cliente = TxtDireccion.Text
                TablaFactura.Telefono_Cliente = TxtTelefono.Text
                TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Via_Envarque = ""
                TablaFactura.SuReferencia1 = CboReferencia.Text
                TablaFactura.Nuestra_Referencia = ""
                TablaFactura.Codigo_Proyecto = CboProyecto.Text




                If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
                    TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
                Else
                    TablaFactura.Sub_Total = 0
                End If

                If My.Forms.FrmFacturas.IvaGral <> 0 Then
                    TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
                Else
                    TablaFactura.IVA_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
                    TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
                Else
                    TablaFactura.Pagado_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
                    TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
                Else
                    TablaFactura.Neto_Pagar = 0
                End If

                If RadioButton1.Checked = True Then
                    TablaFactura.Metodo_Pago = "Credito"
                Else
                    TablaFactura.Metodo_Pago = "Contado"
                End If

                If OptExsonerado.Checked = True Then
                    TablaFactura.Exonerado_Factura = 1
                Else
                    TablaFactura.Exonerado_Factura = 0
                End If

                If OptRet1Porciento.Checked = True Then
                    TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
                    TablaFactura.Retener1_Porciento = 1
                Else
                    TablaFactura.MontoRetencion1_Porciento = 0
                    TablaFactura.Retener1_Porciento = 0
                End If

                If OptRet2Porciento.Checked = True Then
                    TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
                    TablaFactura.Retener2_Porciento = 1
                Else
                    TablaFactura.MontoRetencion2_Porciento = 0
                    TablaFactura.Retener2_Porciento = 0
                End If


                If Not CboProyecto.Text = "" Then
                    TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
                End If

                If CboReferencia.Text <> "" Then
                    TablaFactura.Referencia_Factura = CboReferencia.Text
                End If

                TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
                TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))


                GrabaFacturas(TablaFactura)

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LOS LOTES///////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                MiConexion.Close()
                StrSqlUpdate = "DELETE FROM [Detalle_Lote] WHERE (Codigo_Producto = '" & CodProducto & "') AND (Tipo_Documento = 'Factura') AND (Numero_Documento = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & FechaFactura & "', 102))"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


                ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodProducto)



            End If


            ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA FACTURA///////////////////////////////////////////////////////////
            ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlString = "SELECT * FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "')  AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Factura = '" & idDetalle & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "Detalle")
            'If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            '    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            '    MiConexion.Close()
            '    StrSqlUpdate = " DELETE FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Factura = '" & idDetalle & "')"
            '    MiConexion.Open()
            '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            '    iResultado = ComandoUpdate.ExecuteNonQuery
            '    MiConexion.Close()

            '    Select Case Me.CboTipoProducto.Text
            '        Case "Factura"
            '            DiferenciaCantidad = CDbl(CantidadAnterior) - CDbl(Cantidad)
            '            DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
            '            ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            '        Case "Devolucion de Venta"
            '            DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
            '            DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
            '            ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            '    End Select
            'End If



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            '    Select Case Me.CboTipoProducto.Text
            '        Case "Cotizacion"
            '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
            '        Case "Factura"
            '            If ConsecutivoFacturaManual = False Then
            '                ConsecutivoFactura = BuscaConsecutivo("Factura")
            '            Else
            '                FrmConsecutivos.ShowDialog()
            '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
            '            End If
            '        Case "Devolucion de Venta"
            '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
            '        Case "Transferencia Enviada"
            '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
            '        Case "Salida Bodega"
            '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
            '    End Select
            'Else
            '    ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            'End If

            'NumeroFactura = Format(ConsecutivoFactura, "0000#")





            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'GrabaFacturas(NumeroFactura)


        Catch ex As Exception
            MsgBox("Para borrar es necesario Grabar" & vbCrLf & ex.Message)
        End Try



    End Sub


    Private Sub DTPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFecha.ValueChanged

    End Sub

        Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
            Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
            Dim SqlString As String, NumeroFactura As String, Fecha As String, TipoFactura As String
            Dim oDataRow As DataRow, IposicionFila As Double, Registros As Double, CodProducto As String, Descripcion As String, PrecioNeto As Double, CostoPromedio As Double, CostoPromedioDolar As Double
            Dim Margen As Double, TMargen As Double, TipoProducto As String, Cantidad As Double, n As Double = 0, SubTotal As Double, TotalCostos As Double
            Dim PrecioUnitario As Double, Descuento As Double

            TipoFactura = Me.CboTipoProducto.Text
            NumeroFactura = Me.TxtNumeroEnsamble.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            IposicionFila = 0


            Registros = Me.BindingDetalle.Count

            Do While IposicionFila < Registros
                My.Application.DoEvents()


            CodProducto = Me.BindingDetalle.Item(IposicionFila)("Cod_Producto")
                Descripcion = Me.BindingDetalle.Item(IposicionFila)("Descripcion_Producto")
                PrecioUnitario = Me.BindingDetalle.Item(IposicionFila)("Precio_Unitario")
                If Not IsDBNull(Me.BindingDetalle.Item(IposicionFila)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(IposicionFila)("Descuento")
                End If
                'SubTotal = Me.BindingDetalle.Item(IposicionFila)("Importe") + SubTotal
                Cantidad = Me.BindingDetalle.Item(IposicionFila)("Cantidad")
                PrecioNeto = PrecioUnitario - Descuento


                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////BUSCO EL COSTO PROMEDIO DEL PRODUCTO ///////////////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Producto")
                If DataSet.Tables("Producto").Rows.Count <> 0 Then
                    CostoPromedio = DataSet.Tables("Producto").Rows(0)("Costo_Promedio")
                    CostoPromedioDolar = DataSet.Tables("Producto").Rows(0)("Costo_Promedio_Dolar")
                End If



                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")

                DataSet.Tables("Producto").Clear()

                If TipoProducto <> "Descuento" Then

                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        TotalCostos = (CostoPromedio * Cantidad) + TotalCostos
                    Else
                        TotalCostos = (CostoPromedioDolar * Cantidad) + TotalCostos
                    End If

                    SubTotal = Cantidad * PrecioNeto + SubTotal

                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        Margen = (PrecioNeto / CostoPromedio) - 1
                    Else
                        Margen = (PrecioNeto / CostoPromedioDolar) - 1
                    End If
                    TMargen = Margen + TMargen


                    SqlString = "SELECT  Cod_Producto, Descripcion_Producto , Precio_Neto, Importe AS Costo_Promedio, TasaCambio AS Margen FROM Detalle_Facturas WHERE (Numero_Factura = '-1') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') "
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleFactura2")
                    oDataRow = DataSet.Tables("DetalleFactura2").NewRow
                    oDataRow("Cod_Producto") = CodProducto
                    oDataRow("Descripcion_Producto") = Descripcion
                    oDataRow("Precio_Neto") = PrecioNeto
                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        oDataRow("Costo_Promedio") = CostoPromedio
                    Else
                        oDataRow("Costo_Promedio") = CostoPromedioDolar
                    End If
                    oDataRow("Margen") = Margen
                    DataSet.Tables("DetalleFactura2").Rows.Add(oDataRow)

                    n = n + 1
                Else
                    SubTotal = SubTotal - (Cantidad * PrecioNeto)
                End If

                IposicionFila = IposicionFila + 1
            Loop

            'TMargen = TMargen / n
            TMargen = ((SubTotal / TotalCostos) - 1)
            My.Forms.FrmMargenes.TxtMargen.Text = Format(TMargen, "0.00%")

            My.Forms.FrmMargenes.TrueDBGridConsultas.DataSource = DataSet.Tables("DetalleFactura2")
            My.Forms.FrmMargenes.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
            My.Forms.FrmMargenes.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 171
            My.Forms.FrmMargenes.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 78
            My.Forms.FrmMargenes.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 78
            My.Forms.FrmMargenes.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 78
            My.Forms.FrmMargenes.TrueDBGridConsultas.Columns(2).NumberFormat = "##,##0.00"
            My.Forms.FrmMargenes.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
            My.Forms.FrmMargenes.TrueDBGridConsultas.Columns(4).NumberFormat = "0.00%"

            My.Forms.FrmMargenes.ShowDialog()
        End Sub

    Private Sub TxtMonedaFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtMonedaFactura.SelectedIndexChanged

    End Sub

    Private Sub BtnCancelWorker_Click(sender As Object, e As EventArgs)
        CancelarWorker(True)
    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepFacturas As New ArepFacturas, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double, NombrePago As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim NumeroFactura As String, MonedaImprime As String, MonedaFactura As String
        Dim TipoImpresion As String, SqlString As String, RutaBD As String, ConexionAccess As String
        Dim ArepCotizacionFoto As New ArepCotizacionFoto, IdDetalle As Double = 0, CodTarea As String = Nothing
        Dim CodigoProducto As String, PrecioUnitario As Double = 0, Descuento As Double = 0, PrecioNeto As Double = 0, Importe As Double = 0, Cantidad As Double = 0
        Dim DiferenciaCantidad As Double = 0, DiferenciaPrecio As Double = 0, Descripcion_Producto As String = "", Respuesta As Double
        Dim ArepFacturasTareas As New ArepFacturasTareas, FacturaBodega As Boolean = True, CompraBodega As Boolean = True, CostoUnitario As Double = 0
        Dim ArepFacturasTiras As New ArepFacturasTiras2, ImprimeFacturaPreview As Boolean = True
        Dim ArepFacturas2 As New ArepFacturas2
        Dim RstCosto As New RstCostoPromedio

        Try

            Respuesta = MsgBox("Esta seguro de Procesar la " & Me.CboTipoProducto.Text & " " & Me.TxtNumeroEnsamble.Text, MsgBoxStyle.YesNo, "Zeus Facturacion")
            If Respuesta <> 6 Then
                Exit Sub
            End If

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            If BuscaTasaCambio(Me.DTPFecha.Value) = 0 Then
                MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            Else
                TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
            End If

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                MsgBox("No se puede grabar antes de asignar numero factura", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            ''////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            '    Select Case Me.CboTipoProducto.Text
            '        Case "Cotizacion"
            '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
            '        Case "Factura"
            '            If ConsecutivoFacturaManual = False Then
            '                ConsecutivoFactura = BuscaConsecutivo("Factura")
            '            Else
            '                FrmConsecutivos.ShowDialog()
            '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
            '            End If
            '        Case "Devolucion de Venta"
            '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
            '        Case "Transferencia Enviada"
            '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
            '        Case "Salida Bodega"
            '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
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

            '    If FacturaBodega = True Then
            '        NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
            '    Else
            '        NumeroFactura = Format(ConsecutivoFactura, "0000#")
            '    End If
            'Else
            '    NumeroFactura = Me.TxtNumeroEnsamble.Text
            '    'ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            '    'NumeroFactura = Format(ConsecutivoFactura, "0000#")
            'End If



            'NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
            NumeroFactura = Me.TxtNumeroEnsamble.Text

            Dim TablaFactura As TablaFactura = New TablaFactura

            TablaFactura.Numero_Factura = NumeroFactura
            TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            TablaFactura.Tipo_Factura = CboTipoProducto.Text
            TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
            TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
            TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
            TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
            TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
            TablaFactura.CodBodega1 = CboCodigoBodega.Text
            TablaFactura.Cod_Cajero = CboCajero.Text
            TablaFactura.Nombre_Cliente = TxtNombres.Text
            TablaFactura.Apellido_Cliente = TxtApellidos.Text
            TablaFactura.Direccion_Cliente = TxtDireccion.Text
            TablaFactura.Telefono_Cliente = TxtTelefono.Text
            TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
            TablaFactura.Via_Envarque = ""
            TablaFactura.SuReferencia1 = CboReferencia.Text
            TablaFactura.Nuestra_Referencia = ""
            TablaFactura.Codigo_Proyecto = CboProyecto.Text




            If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
                TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
            Else
                TablaFactura.Sub_Total = 0
            End If

            If My.Forms.FrmFacturas.IvaGral <> 0 Then
                TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
            Else
                TablaFactura.IVA_Factura = 0
            End If

            If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
                TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
            Else
                TablaFactura.Pagado_Factura = 0
            End If

            If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
                TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
            Else
                TablaFactura.Neto_Pagar = 0
            End If

            If RadioButton1.Checked = True Then
                TablaFactura.Metodo_Pago = "Credito"
            Else
                TablaFactura.Metodo_Pago = "Contado"
            End If

            If OptExsonerado.Checked = True Then
                TablaFactura.Exonerado_Factura = 1
            Else
                TablaFactura.Exonerado_Factura = 0
            End If

            If OptRet1Porciento.Checked = True Then
                TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
                TablaFactura.Retener1_Porciento = 1
            Else
                TablaFactura.MontoRetencion1_Porciento = 0
                TablaFactura.Retener1_Porciento = 0
            End If

            If OptRet2Porciento.Checked = True Then
                TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
                TablaFactura.Retener2_Porciento = 1
            Else
                TablaFactura.MontoRetencion2_Porciento = 0
                TablaFactura.Retener2_Porciento = 0
            End If


            If Not CboProyecto.Text = "" Then
                TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
            End If

            If CboReferencia.Text <> "" Then
                TablaFactura.Referencia_Factura = CboReferencia.Text
            End If

            TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
            TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaFacturas(TablaFactura)

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            Registros = Me.BindingDetalle.Count
            'iPosicion = Me.BindingDetalle.Position


            Me.BindingDetalle.MoveFirst()
            Registros = Me.BindingDetalle.Count
            iPosicion = 0
            Monto = 0
            Do While iPosicion < Registros


                My.Application.DoEvents()

                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                '            IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                '        Else
                '            IdDetalle = -1
                '        End If

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
                Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
                Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
                Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
                Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                '            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                '        Else
                '            PrecioUnitario = 0
                '        End If
                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                '        End If
                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                '            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                '        Else
                '            PrecioNeto = 0
                '        End If
                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                '            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                '        Else
                '            Importe = 0
                '        End If
                '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                '            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                '        Else
                '            Cantidad = 0
                '        End If

                CostoUnitario = 0

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                    'CostoUnitario = CostoPromedioKardexBodega(CodigoProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)
                    'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    'Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                Else
                    'If FacturaTarea = True Then
                    '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    'Else
                    '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    'End If

                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba
                    Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                End If



                'Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

                'If FacturaTarea = True Then
                '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                '        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                '    Else
                '        CodTarea = 0
                '    End If
                '    GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
                'Else
                '    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
                'End If

                'Select Case Me.CboTipoProducto.Text
                '    Case "Factura"
                '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                '        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                '    Case "Devolucion de Venta"
                '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                '        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                'End Select

                iPosicion = iPosicion + 1
            Loop

            da.Update(ds.Tables("DetalleFactura"))


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            'Me.BindingMetodo.MoveFirst()
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

                GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, TablaFactura.Fecha_Factura, TablaFactura.Tipo_Factura)
                iPosicion = iPosicion + 1
            Loop




            ActualizaMETODOFactura()

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")

            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                    ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                Else
                    ImprimeFacturaPreview = False
                End If

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

            ArepFacturasTiras.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturasTiras.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturasTiras.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturasTiras.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturasTiras.LblApellidos.Text = Me.TxtApellidos.Text

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                ArepFacturasTiras.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepFacturas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepFacturasTareas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepFacturasTiras.LblRuc.Text = "RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepFacturas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepFacturasTareas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepFacturasTiras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If

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
            If Val(Me.TxtSubTotal.Text) <> 0 Then
                ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            Else
                ArepCotizacionFoto.LblSubTotal.Text = "0.00"
            End If
            If Val(Me.TxtIva.Text) <> 0 Then
                ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                ArepCotizacionFoto.LblIva.Text = "0.00"
            End If
            If Val(Me.TxtPagado.Text) <> 0 Then
                ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            Else
                ArepCotizacionFoto.LblPagado.Text = "0.00"
            End If
            If Val(Me.TxtNetoPagar.Text) <> 0 Then
                ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            Else
                ArepCotizacionFoto.LblTotal.Text = "0.00"
            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            Else
                ArepCotizacionFoto.LblDescuento.Text = "0.00"
            End If
            If Val(Me.TxtSubTotal.Text) <> 0 Then
                ArepFacturas.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblSubTotal.Text = "0.00"
            End If
            If Val(Me.TxtIva.Text) <> 0 Then
                ArepFacturas.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblIva.Text = "0.00"
            End If
            If Val(Me.TxtPagado.Text) <> 0 Then
                ArepFacturas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblPagado.Text = "0.00"
            End If
            If Val(Me.TxtNetoPagar.Text) <> 0 Then
                ArepFacturas.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblTotal.Text = "0.00"
            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                ArepFacturas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblDescuento.Text = "0.00"
            End If


            If Val(Me.TxtSubTotal.Text) <> 0 Then
                ArepFacturas.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblSubTotal.Text = "0.00"
                ArepFacturas.LblSubTotal.Text = "0.00"
                ArepFacturas2.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblSubTotal.Text = "0.00"
            End If
            If Val(Me.TxtIva.Text) <> 0 Then
                ArepFacturas.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblIva.Text = "0.00"
                ArepFacturas.LblIva.Text = "0.00"
                ArepFacturas2.LblIva.Text = "0.00"
                ArepFacturasTiras.LblIva.Text = "0.00"
            End If
            If Val(Me.TxtPagado.Text) <> 0 Then
                ArepFacturas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblPagado.Text = "0.00"
                ArepFacturas2.LblPagado.Text = "0.00"
                ArepFacturasTiras.LblPagado.Text = "0.00"
            End If
            If Val(Me.TxtNetoPagar.Text) <> 0 Then
                'ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblTotal.Text = "0.00"
                ArepFacturas.LblTotal.Text = "0.00"
                ArepFacturas2.LblTotal.Text = "0.00"
                ArepFacturasTiras.LblTotal.Text = "0.00"
            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                ArepFacturas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblDescuento.Text = "0.00"
                ArepFacturas2.LblDescuento.Text = "0.00"
            End If

            ArepFacturasTiras.LblTotal1.Text = Format((CDbl(Me.TxtIva.Text) + CDbl(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")



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

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA SI EXISTEN FORMA DE PAGO///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                If Me.CboTipoProducto.Text <> "Cotizacion" Then
                    SqlCompras = "UPDATE [Facturas]  SET [FechaPago] = '" & Format(Now, "dd/MM/yyyy") & "' " &
                                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                iPosicion = iPosicion + 1
            Loop



            SQlDetalle = ""
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                            "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT     Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Facturas.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Facturas.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Facturas.Importe * (1 / TasaCambio.MontoTasa) AS Importe, TasaCambio.MontoTasa FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " &
                                     "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                            "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Facturas.Descuento * TasaCambio.MontoTasa AS Descuento,Detalle_Facturas.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Facturas.Importe * TasaCambio.MontoTasa AS Importe,TasaCambio.MontoTasa FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa " &
                            "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,'" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            Select Case Me.CboTipoProducto.Text

                Case "Factura"

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////SELECCIONO LA IMPRESORA CONFIGURADA PARA LAS FACTURAS /////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Dim pd As New PrintDocument
                    Dim ImpresoraFactura As String
                    Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

                    Impresora_Defecto = s_Default_Printer
                    ImpresoraFactura = BuscaImpresora("Factura")
                    Establecer_Impresora(ImpresoraFactura)


                    TipoImpresion = Me.CboTipoProducto.Text

                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco, Sin Encabezado"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas2.DataSource = SQL
                                ArepFacturas2.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                ArepFacturas2.LblLetras.Text = Letras(CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtIva.Text), Me.TxtMonedaFactura.Text)

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas2.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas2.Run(True)
                                Else
                                    ArepFacturas2.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Tira de Papel"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                ArepFacturasTiras.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturasTiras.DataSource = SQL
                                ArepFacturasTiras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                If MonedaImprime = "Cordobas" Then
                                    ArepFacturasTiras.Simbolo1.Text = "C$"
                                    ArepFacturasTiras.Simbolo2.Text = "C$"
                                    ArepFacturasTiras.Simbolo3.Text = "C$"
                                    ArepFacturasTiras.Simbolo4.Text = "C$"
                                    ArepFacturasTiras.Simbolo5.Text = "C$"
                                Else
                                    ArepFacturasTiras.Simbolo1.Text = "$"
                                    ArepFacturasTiras.Simbolo2.Text = "$"
                                    ArepFacturasTiras.Simbolo3.Text = "$"
                                    ArepFacturasTiras.Simbolo4.Text = "$"
                                    ArepFacturasTiras.Simbolo5.Text = "$"
                                End If

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturasTiras.Document

                                'ViewerForm.Show()
                                'ArepFacturasTiras.Run(True)
                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturasTiras.Run(True)
                                Else
                                    ArepFacturasTiras.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If



                                'ArepFacturas.Run(False)
                                'ArepFacturas.Show()
                            Case "Papel en Blanco"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas.Run(True)
                                Else
                                    ArepFacturas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Personalizado"


                                TipoImpresion = Me.CboTipoProducto.Text


                                Dim StrSQLUpdate As String
                                Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                Dim DatasetDatos As New DataSet


                                MiConexionAccess.Open()
                                DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & NumeroFactura & "' "
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                '///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                                EscribirArchivo()

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
                SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " &
                                 "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Procesar la Factura: " & Me.TxtNumeroEnsamble.Text)

            LimpiarFacturas()

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ChkPorcientoTarjeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPorcientoTarjeta.CheckedChanged
        Dim SqlDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        If Me.ChkPorcientoTarjeta.Checked = True Then
            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                IncrementoTarjeta = DataSet.Tables("DatosEmpresa").Rows(0)("PorcientoTarjetaCredito")
            Else
                IncrementoTarjeta = 0
            End If
        Else
            IncrementoTarjeta = 0
        End If
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
            Dim Posicion As Double
            If Me.BindingDetalle.Count <> 0 Then
                My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                Posicion = Me.BindingDetalle.Position
                My.Forms.FrmLotesFactura.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Productos")
                My.Forms.FrmLotesFactura.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                My.Forms.FrmLotesFactura.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                My.Forms.FrmLotesFactura.Fecha = Me.DTPFecha.Value
                My.Forms.FrmLotesFactura.LblProducto.Text = Me.BindingDetalle.Item(Posicion)("Cod_Productos") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                    My.Forms.FrmLotesFactura.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
                Else
                    My.Forms.FrmLotesFactura.Cantidad = 1
                End If
                My.Forms.FrmLotesFactura.LblCantidad.Text = Me.BindingDetalle.Item(Posicion)("Cantidad")
                My.Forms.FrmLotesFactura.CodigoBodega = Me.CboCodigoBodega.Text
                My.Forms.FrmLotesFactura.TipoDocumento = Me.CboTipoProducto.Text
                My.Forms.FrmLotesFactura.ShowDialog()
            End If
        End Sub

    Public Sub Graba()

        Dim iPosicion As Double, Registros As Double, NumeroFactura As String
        Dim NombrePago As String, Monto As Double, NumeroTarjeta As String, FechaVenceTarjeta As String, CodTarea As String = Nothing
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, Descripcion_Producto As String, IdDetalle As Double = -1
        Dim FacturaBodega As Boolean = False, CompraBodega As Boolean = False, CostoUnitario As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CamposFactura As TablaFactura = New TablaFactura
        Dim RstCosto As New RstCostoPromedio

        Try



            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            ''////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            '    Select Case Me.CboTipoProducto.Text
            '        Case "Cotizacion"
            '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
            '        Case "Factura"
            '            If ConsecutivoFacturaManual = False Then
            '                ConsecutivoFactura = BuscaConsecutivo("Factura")
            '            Else
            '                FrmConsecutivos.ShowDialog()
            '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
            '            End If
            '        Case "Devolucion de Venta"
            '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
            '        Case "Transferencia Enviada"
            '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
            '        Case "Salida Bodega"
            '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")

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

            '    If FacturaBodega = True Then
            '        NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
            '    Else
            '        NumeroFactura = Format(ConsecutivoFactura, "0000#")
            '    End If

            'Else
            '    NumeroFactura = Me.TxtNumeroEnsamble.Text
            'End If


            'NumeroFactura = Format(ConsecutivoFactura, "0000#")

            NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)

            Dim TablaFactura As TablaFactura = New TablaFactura

            TablaFactura.Numero_Factura = NumeroFactura
            TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            TablaFactura.Tipo_Factura = CboTipoProducto.Text
            TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
            TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
            TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
            TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
            TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
            TablaFactura.CodBodega1 = CboCodigoBodega.Text
            TablaFactura.Cod_Cajero = CboCajero.Text
            TablaFactura.Nombre_Cliente = TxtNombres.Text
            TablaFactura.Apellido_Cliente = TxtApellidos.Text
            TablaFactura.Direccion_Cliente = TxtDireccion.Text
            TablaFactura.Telefono_Cliente = TxtTelefono.Text
            TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
            TablaFactura.Via_Envarque = ""
            TablaFactura.SuReferencia1 = CboReferencia.Text
            TablaFactura.Nuestra_Referencia = ""
            TablaFactura.Codigo_Proyecto = CboProyecto.Text




            If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
                TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
            Else
                TablaFactura.Sub_Total = 0
            End If

            If My.Forms.FrmFacturas.IvaGral <> 0 Then
                TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
            Else
                TablaFactura.IVA_Factura = 0
            End If

            If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
                TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
            Else
                TablaFactura.Pagado_Factura = 0
            End If

            If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
                TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
            Else
                TablaFactura.Neto_Pagar = 0
            End If

            If RadioButton1.Checked = True Then
                TablaFactura.Metodo_Pago = "Credito"
            Else
                TablaFactura.Metodo_Pago = "Contado"
            End If

            If OptExsonerado.Checked = True Then
                TablaFactura.Exonerado_Factura = 1
            Else
                TablaFactura.Exonerado_Factura = 0
            End If

            If OptRet1Porciento.Checked = True Then
                TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
                TablaFactura.Retener1_Porciento = 1
            Else
                TablaFactura.MontoRetencion1_Porciento = 0
                TablaFactura.Retener1_Porciento = 0
            End If

            If OptRet2Porciento.Checked = True Then
                TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
                TablaFactura.Retener2_Porciento = 1
            Else
                TablaFactura.MontoRetencion2_Porciento = 0
                TablaFactura.Retener2_Porciento = 0
            End If


            If Not CboProyecto.Text = "" Then
                TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
            End If

            If CboReferencia.Text <> "" Then
                TablaFactura.Referencia_Factura = CboReferencia.Text
            End If

            TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
            TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            ActualizaMETODOFactura()
            GrabaFacturas(TablaFactura)


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

                My.Application.DoEvents()

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                Else
                    IdDetalle = -1
                End If

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                    PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                Else
                    PrecioUnitario = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                    PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Else
                    PrecioNeto = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                    Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Else
                    Importe = 0
                End If
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Else
                    Cantidad = 0
                End If


                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                    'CostoUnitario = CostoPromedioKardexBodega(CodigoProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)
                    'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                Else
                    'If FacturaTarea = True Then
                    '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    'Else
                    '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    'End If

                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba

                End If

                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

                If FacturaTarea = True Then
                    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                    Else
                        CodTarea = 0
                    End If
                    GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
                Else
                    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
                End If

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
                My.Application.DoEvents()
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

                GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, TablaFactura.Fecha_Factura, TablaFactura.Tipo_Factura)
                iPosicion = iPosicion + 1
            Loop

            'ActualizaMETODOFactura()

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Grabo la Factura: " & Me.TxtNumeroEnsamble.Text)

            'MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            'LimpiarFacturas()
            'Me.Button7.Enabled = True
            'Me.CboCodigoBodega.Enabled = True


            'If NombreCliente = "Alumnos" Then
            '    Me.Label12.Visible = False
            '    Me.CboCodigoVendedor.Visible = False
            'End If

            'If UsuarioBodega <> "Ninguna" Then
            '    Me.CboCodigoBodega.Text = UsuarioBodega
            '    Me.CboCodigoBodega.Enabled = False
            '    Me.Button7.Enabled = False
            'End If

            'If UsuarioTipoFactura <> "Ninguna" Then
            '    Me.CboTipoProducto.Text = UsuarioTipoFactura
            'End If

            'If UsuarioTipoSerie <> "Ninguna" Then
            '    Me.CmbSerie.Text = UsuarioTipoSerie
            'End If

            'If UsuarioVendedor <> "Ninguna" Then
            '    Me.CboCodigoVendedor.Text = UsuarioVendedor
            'End If

            'If UsuarioCliente <> "Ninguna" Then
            '    Me.TxtCodigoClientes.Text = UsuarioCliente
            'End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub


    Private Sub C1Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button5.Click
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


    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub FrmFacturas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

    End Sub

    Private Sub OptRet2Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet2Porciento.CheckedChanged
        ActualizaMETODOFactura()
    End Sub

    Private Sub OptRet1Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRet1Porciento.CheckedChanged
        ActualizaMETODOFactura()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

    End Sub

    Private Sub ChkPropina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPropina.CheckedChanged
        ActualizaMETODOFactura()
    End Sub
    Private Sub TxtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombres.TextChanged
        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Cambio de Cliente: " & Me.TxtNombres.Text & " " & Me.TxtNumeroEnsamble.Text)
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim Fecha As String

        Try


            If BuscaTasaCambio(Me.DTPFecha.Value) = 0 Then
                MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            Else
                TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
            End If

            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

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

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Procesar la Factura: " & Me.TxtNumeroEnsamble.Text)

            LimpiarFacturas()

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

 
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCuentasxCobrar.Click

    End Sub

    Private Sub TrueDBGridComponentes_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles TrueDBGridComponentes.AfterSort

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepFacturas As New ArepFacturas, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double, NombrePago As String
        Dim ArepFacturasTiras As New ArepFacturasTiras2, ArepFacturaMediaPagina As New ArepFacturaMedia
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, TasaCambio As Double
        Dim NumeroFactura As String, MonedaImprime As String, MonedaFactura As String
        Dim TipoImpresion As String, SqlString As String, RutaBD As String, ConexionAccess As String
        Dim ArepCotizacionFoto As New ArepCotizacionFoto, CodTarea As String = Nothing
        Dim ArepOrdenTrabajo As New ArepFacturasTiras
        Dim CodigoProducto As String, RstCosto As New RstCostoPromedio

        Dim ArepFacturasTareas As New ArepFacturasTareas, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim ArepFacturas2 As New ArepFacturas2, ArepSalidaBodega As New ArepSalidaBodega, Ancho As Double, Largo As Double
        Dim ArepCotizaciones As New ArepCotizaciones, ImprimeFacturaPreview As Boolean = True, CostoUnitario As Double = 0

        Try

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            If BuscaTasaCambio(Me.DTPFecha.Value) = 0 Then
                MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                MsgBox("No se puede grabar antes de asignar numero factura", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            Me.Button2.Enabled = False


            If PermiteEditar(Acceso, Me.CboTipoProducto.Text) = True Then

                SqlDatos = "SELECT * FROM DatosEmpresa"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "DatosEmpresa")
                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                    ConsecutivoFacturaSerie = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
                End If


                ''////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                '    Select Case Me.CboTipoProducto.Text
                '        Case "Cotizacion"
                '            ConsecutivoFactura = BuscaConsecutivo("Cotizacion")
                '        Case "Factura"
                '            If ConsecutivoFacturaManual = False Then
                '                ConsecutivoFactura = BuscaConsecutivo("Factura")
                '            Else
                '                FrmConsecutivos.ShowDialog()
                '                ConsecutivoFactura = FrmConsecutivos.NumeroFactura
                '            End If
                '        Case "Devolucion de Venta"
                '            ConsecutivoFactura = BuscaConsecutivo("DevFactura")
                '        Case "Transferencia Enviada"
                '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
                '        Case "Salida Bodega"
                '            ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
                '    End Select

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

                'If FacturaBodega = True Then
                '    NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
                'Else
                '    NumeroFactura = Format(ConsecutivoFactura, "0000#")
                'End If

                'Else
                ''ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
                ''NumeroFactura = Format(ConsecutivoFactura, "0000#")
                'NumeroFactura = Me.TxtNumeroEnsamble.Text
                'End If

                'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                '    NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)
                'Else
                '    NumeroFactura = Me.TxtNumeroEnsamble.Text
                'End If


                NumeroFactura = Me.TxtNumeroEnsamble.Text

                Dim TablaFactura As TablaFactura = New TablaFactura

                TablaFactura.Numero_Factura = NumeroFactura
                TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                TablaFactura.Tipo_Factura = CboTipoProducto.Text
                TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
                TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
                TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
                TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
                TablaFactura.CodBodega1 = CboCodigoBodega.Text
                TablaFactura.Cod_Cajero = CboCajero.Text
                TablaFactura.Nombre_Cliente = TxtNombres.Text
                TablaFactura.Apellido_Cliente = TxtApellidos.Text
                TablaFactura.Direccion_Cliente = TxtDireccion.Text
                TablaFactura.Telefono_Cliente = TxtTelefono.Text
                TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
                TablaFactura.Via_Envarque = ""
                TablaFactura.SuReferencia1 = CboReferencia.Text
                TablaFactura.Nuestra_Referencia = ""
                TablaFactura.Codigo_Proyecto = CboProyecto.Text




                If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
                    TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
                Else
                    TablaFactura.Sub_Total = 0
                End If

                If My.Forms.FrmFacturas.IvaGral <> 0 Then
                    TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
                Else
                    TablaFactura.IVA_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
                    TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
                Else
                    TablaFactura.Pagado_Factura = 0
                End If

                If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
                    TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
                Else
                    TablaFactura.Neto_Pagar = 0
                End If

                If RadioButton1.Checked = True Then
                    TablaFactura.Metodo_Pago = "Credito"
                Else
                    TablaFactura.Metodo_Pago = "Contado"
                End If

                If OptExsonerado.Checked = True Then
                    TablaFactura.Exonerado_Factura = 1
                Else
                    TablaFactura.Exonerado_Factura = 0
                End If

                If OptRet1Porciento.Checked = True Then
                    TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
                    TablaFactura.Retener1_Porciento = 1
                Else
                    TablaFactura.MontoRetencion1_Porciento = 0
                    TablaFactura.Retener1_Porciento = 0
                End If

                If OptRet2Porciento.Checked = True Then
                    TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
                    TablaFactura.Retener2_Porciento = 1
                Else
                    TablaFactura.MontoRetencion2_Porciento = 0
                    TablaFactura.Retener2_Porciento = 0
                End If


                If Not CboProyecto.Text = "" Then
                    TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
                End If

                If CboReferencia.Text <> "" Then
                    TablaFactura.Referencia_Factura = CboReferencia.Text
                End If

                TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
                TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                GrabaFacturas(TablaFactura)

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


                Registros = Me.BindingDetalle.Count
                'iPosicion = Me.BindingDetalle.Position


                Me.BindingDetalle.MoveFirst()
                Registros = Me.BindingDetalle.Count
                iPosicion = 0
                Monto = 0
                Do While iPosicion < Registros

                    My.Application.DoEvents()

                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                    '            IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
                    '        Else
                    '            IdDetalle = -1
                    '        End If

                    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
                    'Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
                    'Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
                    'Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
                    Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")


                    ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                    '            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                    '        Else
                    '            PrecioUnitario = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    '            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                    '            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                    '        Else
                    '            PrecioNeto = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                    '            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                    '        Else
                    '            Importe = 0
                    '        End If
                    '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                    '            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                    '        Else
                    '            Cantidad = 0
                    '        End If

                    CostoUnitario = 0

                    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                        'CostoUnitario = CostoPromedioKardexBodega(CodigoProducto, Me.DTPFecha.Value, Me.CboCodigoBodega.Text)
                        'CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        'Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                    Else
                        'If FacturaTarea = True Then
                        '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        'Else
                        '    CostoUnitario = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        'End If

                        RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                        CostoUnitario = RstCosto.Costo_Cordoba
                        Me.BindingDetalle.Item(iPosicion)("Costo_Unitario") = CostoUnitario
                    End If



                    'Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

                    'If FacturaTarea = True Then
                    '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                    '        CodTarea = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                    '    Else
                    '        CodTarea = 0
                    '    End If
                    '    GrabaDetalleFacturaTarea(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CodTarea)
                    'Else
                    '    GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)
                    'End If

                    'Select Case Me.CboTipoProducto.Text
                    '    Case "Factura"
                    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    '    Case "Devolucion de Venta"
                    '        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    '        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    'End Select

                    iPosicion = iPosicion + 1
                Loop

                da.Update(ds.Tables("DetalleFactura"))
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

                    GrabaMetodoDetalleFactura(NumeroFactura, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, TablaFactura.Fecha_Factura, TablaFactura.Tipo_Factura)
                    iPosicion = iPosicion + 1
                Loop


            End If

            ActualizaMETODOFactura()

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")

            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                    ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                Else
                    ImprimeFacturaPreview = False
                End If

                'ArepCotizaciones.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepCotizaciones.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                'ArepCotizaciones.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                'ArepCotizaciones.LblMoneda.Text = Me.TxtMonedaImprime.Text
                'ArepCotizaciones.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                'ArepCotizacionFoto.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepCotizacionFoto.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                'ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                'ArepSalidaBodega.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                'ArepSalidaBodega.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                    ArepFacturasTiras.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    ArepFacturas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    'ArepCotizacionFoto.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturasTareas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturasTiras.LblRuc.Text = "RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepSalidaBodega.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    ArepFacturaMediaPagina.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                    'ArepCotizaciones.LblRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                    If Dir(RutaLogo) <> "" Then
                        ArepFacturas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        'ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepFacturasTareas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepFacturasTiras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        ArepSalidaBodega.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                        'ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    End If

                End If
            End If

            'ArepFacturasTiras.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text

            'ArepCotizacionFoto.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            'ArepCotizacionFoto.Label1.Text = "Cliente"
            'ArepCotizacionFoto.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepCotizacionFoto.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            'ArepCotizacionFoto.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            'ArepCotizacionFoto.LblTipoCompra.Text = Me.CboTipoProducto.Text
            'ArepCotizacionFoto.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            'ArepCotizacionFoto.LblNombres.Text = Me.TxtNombres.Text
            'ArepCotizacionFoto.LblApellidos.Text = Me.TxtApellidos.Text
            'ArepCotizacionFoto.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            'ArepCotizacionFoto.LblTelefono.Text = Me.TxtTelefono.Text
            'ArepCotizacionFoto.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            'ArepCotizacionFoto.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            'ArepSalidaBodega.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepSalidaBodega.LblCodProveedor.Text = Me.TxtCodigoClientes.Text

            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'ArepCotizaciones.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            'ArepCotizaciones.LblNotas.Text = Me.TxtObservaciones.Text
            'ArepCotizaciones.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            'ArepCotizaciones.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            'ArepCotizaciones.LblNombres.Text = Me.TxtNombres.Text
            'ArepCotizaciones.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            'ArepCotizaciones.LblTelefono.Text = Me.TxtTelefono.Text
            'ArepCotizaciones.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

            ArepFacturaMediaPagina.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas2.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturas.Label1.Text = "Cliente"
            ArepFacturaMediaPagina.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturas.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturas.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturaMediaPagina.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturaMediaPagina.LblApellidos.Text = Me.TxtApellidos.Text

            ArepFacturas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturas.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            ArepFacturas2.Label1.Text = "Cliente"
            ArepFacturas2.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturas2.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturas2.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturas2.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturas2.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturas2.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturas2.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturas2.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturas2.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTareas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepFacturasTareas.Label1.Text = "Cliente"
            ArepFacturasTareas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepFacturasTareas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturasTareas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturasTareas.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturasTareas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepFacturasTareas.LblNombres.Text = Me.TxtNombres.Text
            ArepFacturasTareas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepFacturasTareas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepFacturasTareas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepFacturasTareas.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")
            ArepFacturasTareas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            ArepSalidaBodega.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTiras.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepFacturasTiras.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepFacturasTiras.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepFacturasTiras.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text
            ArepFacturasTiras.LblApellidos.Text = Me.TxtApellidos.Text


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepOrdenTrabajo.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepOrdenTrabajo.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepOrdenTrabajo.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepOrdenTrabajo.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text



            ArepSalidaBodega.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepSalidaBodega.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepSalidaBodega.LblTipoCompra.Text = Me.CboTipoProducto.Text
            ArepSalidaBodega.LblNombres.Text = Me.TxtNombres.Text & " " & Me.TxtApellidos.Text

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

            'If Val(Me.TxtSubTotal.Text) <> 0 Then
            '    ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblSubTotal.Text = "0.00"
            'End If

            If Val(Me.TxtIva.Text) <> 0 Then
                ArepSalidaBodega.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                ArepSalidaBodega.LblIva.Text = "0.00"
            End If

            'If Val(Me.TxtIva.Text) <> 0 Then
            '    ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblIva.Text = "0.00"
            'End If

            'If Val(Me.TxtPagado.Text) <> 0 Then
            '    ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblPagado.Text = "0.00"
            'End If
            'If Val(Me.TxtNetoPagar.Text) <> 0 Then
            '    ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblTotal.Text = "0.00"
            'End If
            'If Val(Me.TxtDescuento.Text) <> 0 Then
            '    ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblDescuento.Text = "0.00"
            'End If


            If Val(Me.TxtSubTotal.Text) <> 0 Then
                'ArepCotizaciones.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPropina.Text = Format(CDbl(Me.TxtPropina.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")

            Else
                'ArepCotizaciones.LblSubTotal.Text = "0.00"
                ArepFacturas.LblSubTotal.Text = "0.00"
                ArepFacturas2.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblSubTotal.Text = "0.00"
                ArepSalidaBodega.LblSubTotal.Text = "0.00"
                ArepOrdenTrabajo.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblPropina.Text = "0.00"
                ArepFacturaMediaPagina.LblSubTotal.Text = "0.00"
                ArepFacturasTareas.LblSubTotal.Text = "0.00"
            End If

            If Val(Me.TxtIva.Text) <> 0 Then
                'ArepCotizaciones.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblIva.Text = "0.00"
                ArepFacturas.LblIva.Text = "0.00"
                ArepFacturas2.LblIva.Text = "0.00"
                ArepFacturasTiras.LblIva.Text = "0.00"
                ArepOrdenTrabajo.LblIva.Text = "0.00"
                ArepFacturaMediaPagina.LblIva.Text = "0.00"
                ArepFacturasTareas.LblIva.Text = "0.00"
            End If

            If Val(Me.TxtPagado.Text) <> 0 Then
                ArepFacturas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblPagado.Text = "0.00"
                ArepFacturas2.LblPagado.Text = "0.00"
                ArepFacturasTiras.LblPagado.Text = "0.00"
                ArepOrdenTrabajo.LblPagado.Text = "0.00"
                ArepFacturaMediaPagina.LblPagado.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"
            End If

            If Val(Me.TxtNetoPagar.Text) <> 0 Then
                'ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblTotal.Text = "0.00"
                ArepFacturas.LblTotal.Text = "0.00"
                ArepFacturas2.LblTotal.Text = "0.00"
                ArepFacturasTiras.LblTotal.Text = "0.00"
                ArepOrdenTrabajo.LblTotal.Text = "0.00"
                ArepSalidaBodega.LblTotal.Text = "0.00"
                ArepFacturaMediaPagina.LblTotal.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"

            End If
            If Val(Me.TxtDescuento.Text) <> 0 Then
                ArepFacturas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblDescuento.Text = "0.00"
                ArepFacturas2.LblDescuento.Text = "0.00"
                ArepFacturaMediaPagina.LblDescuento.Text = "0.00"
                ArepFacturasTareas.LblDescuento.Text = "0.00"
            End If


            ArepFacturasTiras.LblTotal1.Text = Format((CDbl(Me.TxtIva.Text) + CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtPropina.Text)) * TasaCambio, "##,##0.00")
            ArepOrdenTrabajo.LblTotal1.Text = Format((CDbl(Me.TxtIva.Text) + CDbl(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")
            ArepSalidaBodega.LblTotal.Text = Format((CDbl(Me.TxtIva.Text) + CDbl(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")
            ArepFacturasTareas.LblTotal.Text = Format((CDbl(Me.TxtIva.Text) + CDbl(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

            Me.BindingMetodo.MoveFirst()
            Registros = Me.BindingMetodo.Count
            iPosicion = 0
            Monto = 0
            ArepFacturas.TxtMetodo.Text = "Credito"
            ArepFacturas2.TxtMetodo.Text = "Credito"
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
                ArepFacturas2.TxtMetodo.Text = NombrePago & " " & Monto
                ArepCotizacionFoto.TxtMetodo.Text = NombrePago & " " & Monto

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA SI EXISTEN FORMA DE PAGO///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                If Me.CboTipoProducto.Text <> "Cotizacion" Then
                    SqlCompras = "UPDATE [Facturas]  SET [FechaPago] = '" & Format(Now, "dd/MM/yyyy") & "' " & _
                                 "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                iPosicion = iPosicion + 1
            Loop



            SQlDetalle = ""
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT     Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Facturas.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Facturas.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Facturas.Importe * (1 / TasaCambio.MontoTasa) AS Importe, TasaCambio.MontoTasa, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida,Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Facturas.Descuento * TasaCambio.MontoTasa AS Descuento,Detalle_Facturas.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Facturas.Importe * TasaCambio.MontoTasa AS Importe,TasaCambio.MontoTasa,Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa " & _
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,'" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

                End If
            End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            NumeroFactura = Me.TxtNumeroEnsamble.Text

            Select Case Me.CboTipoProducto.Text
                Case "Factura"

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////SELECCIONO LA IMPRESORA CONFIGURADA PARA LAS FACTURAS /////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Dim pd As New PrintDocument
                    Dim ImpresoraFactura As String
                    Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

                    Impresora_Defecto = s_Default_Printer
                    ImpresoraFactura = BuscaImpresora("Factura")
                    Establecer_Impresora(ImpresoraFactura)

                    TipoImpresion = Me.CboTipoProducto.Text

                    'If Me.CmbSerie.Visible = True Then
                    '    TipoImpresion = Me.CboTipoProducto.Text & Me.CmbSerie.Text
                    'Else
                    '    TipoImpresion = Me.CboTipoProducto.Text
                    'End If

                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then

                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")

                            Case "Papel en Blanco MediaPagina"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturaMediaPagina.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturaMediaPagina.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturaMediaPagina.DataSource = SQL
                                ArepFacturaMediaPagina.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturaMediaPagina.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturaMediaPagina.Run(True)
                                Else
                                    ArepFacturaMediaPagina.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If
                            Case "Papel en Blanco, Lotes"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturasTareas.DataSource = SQL
                                ArepFacturasTareas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturasTareas.Document
                                'ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturasTareas.Run(True)
                                Else
                                    ArepFacturasTareas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Papel en Blanco, Sin Encabezado"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas2.DataSource = SQL
                                ArepFacturas2.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                ArepFacturas2.LblLetras.Text = Letras(CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtIva.Text), Me.TxtMonedaFactura.Text)

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas2.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas2.Run(True)
                                Else
                                    ArepFacturas2.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Tira de Papel"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                                    ArepOrdenTrabajo.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepOrdenTrabajo.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                ArepFacturasTiras.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepOrdenTrabajo.TxtVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturasTiras.DataSource = SQL
                                ArepFacturasTiras.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                ArepOrdenTrabajo.DataSource = SQL
                                ArepOrdenTrabajo.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                If MonedaImprime = "Cordobas" Then
                                    ArepFacturasTiras.Simbolo1.Text = "C$"
                                    ArepFacturasTiras.Simbolo2.Text = "C$"
                                    ArepFacturasTiras.Simbolo3.Text = "C$"
                                    ArepFacturasTiras.Simbolo4.Text = "C$"
                                    ArepFacturasTiras.Simbolo5.Text = "C$"

                                    ArepOrdenTrabajo.Simbolo1.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo2.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo3.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo4.Text = "C$"
                                    ArepOrdenTrabajo.Simbolo5.Text = "C$"
                                Else
                                    ArepFacturasTiras.Simbolo1.Text = "$"
                                    ArepFacturasTiras.Simbolo2.Text = "$"
                                    ArepFacturasTiras.Simbolo3.Text = "$"
                                    ArepFacturasTiras.Simbolo4.Text = "$"
                                    ArepFacturasTiras.Simbolo5.Text = "$"

                                    ArepOrdenTrabajo.Simbolo1.Text = "$"
                                    ArepOrdenTrabajo.Simbolo2.Text = "$"
                                    ArepOrdenTrabajo.Simbolo3.Text = "$"
                                    ArepOrdenTrabajo.Simbolo4.Text = "$"
                                    ArepOrdenTrabajo.Simbolo5.Text = "$"
                                End If


                                If Me.CboReferencia.Text = "Orden de Trabajo" Then
                                    Dim ViewerForm As New FrmViewer()
                                    ViewerForm.arvMain.Document = ArepOrdenTrabajo.Document

                                    'ViewerForm.Show()
                                    'ArepFacturasTiras.Run(True)
                                    If ImprimeFacturaPreview = True Then
                                        ViewerForm.Show()
                                        ArepOrdenTrabajo.Run(True)
                                    Else
                                        ArepOrdenTrabajo.Run(True)
                                        ViewerForm.arvMain.Document.Print(False, False, False)
                                    End If


                                Else
                                    Dim ViewerForm As New FrmViewer()
                                    ViewerForm.arvMain.Document = ArepFacturasTiras.Document

                                    'ViewerForm.Show()
                                    'ArepFacturasTiras.Run(True)
                                    If ImprimeFacturaPreview = True Then
                                        ViewerForm.Show()
                                        ArepFacturasTiras.Run(True)
                                    Else
                                        ArepFacturasTiras.Run(True)
                                        ViewerForm.arvMain.Document.Print(False, False, False)
                                    End If
                                End If



                                'ArepFacturas.Run(False)
                                'ArepFacturas.Show()
                            Case "Papel en Blanco"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas.Run(True)
                                Else
                                    ArepFacturas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                            Case "Personalizado"

                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepFacturas.DataSource = SQL
                                ArepFacturas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturas.Document
                                ViewerForm.Show()

                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturas.Run(True)
                                Else
                                    ArepFacturas.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If

                                'TipoImpresion = Me.CboTipoProducto.Text


                                'Dim StrSQLUpdate As String
                                'Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                'RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                'ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                'Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                'Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                'Dim DatasetDatos As New DataSet


                                'MiConexionAccess.Open()
                                'DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                'StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & Me.TxtNumeroEnsamble.Text & "' "
                                'ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                'iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                'MiConexionAccess.Close()

                                ''///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                                'EscribirArchivo()

                                'RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                                'If Dir(RutaReportes) <> "" Then
                                '    Shell(RutaReportes)
                                'End If

                        End Select
                    End If

                Case "Cotizacion"
                    TipoImpresion = Me.CboTipoProducto.Text
                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco Membrete"
                                Dim ArepCotizacionesMembretes As New ArepCotizacionesMembretes
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizacionesMembretes.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionesMembretes.LblNombrePie.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionesMembretes.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepCotizacionesMembretes.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizacionesMembretes.LblTelefonoVendedor.Text = TelefonoVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizacionesMembretes.LblMoneda.Text = Me.TxtMonedaImprime.Text
                                    ArepCotizacionesMembretes.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizacionesMembretes.LblRuc.Text = "Numero RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                                        ArepCotizacionesMembretes.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If
                                    End If
                                End If
                                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ArepCotizacionesMembretes.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepCotizacionesMembretes.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepCotizacionesMembretes.LblOrden.Text = Me.TxtNumeroEnsamble.Text
                                ArepCotizacionesMembretes.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                                ArepCotizacionesMembretes.LblNombres.Text = Me.TxtNombres.Text
                                ArepCotizacionesMembretes.LblDireccionProveedor.Text = Me.TxtDireccion.Text
                                ArepCotizacionesMembretes.LblTelefono.Text = Me.TxtTelefono.Text
                                ArepCotizacionesMembretes.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizacionesMembretes.LblTotal.Text = Format((CDbl(Me.TxtSubTotal.Text) + CDbl(Me.TxtIva.Text)) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionesMembretes.LblTotal.Text = "0.00"
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepCotizacionesMembretes.DataSource = SQL
                                ArepCotizacionesMembretes.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepCotizacionesMembretes.Document
                                ViewerForm.Show()
                                ArepCotizacionesMembretes.Run(True)

                            Case "Papel en Blanco"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizaciones.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizaciones.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepCotizaciones.LblCorreo.Text = EmailVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizaciones.LblTelefonoVendedor.Text = TelefonoVendedor(Me.CboCodigoVendedor.Columns(0).Text)
                                    ArepCotizaciones.LblMoneda.Text = Me.TxtMonedaImprime.Text
                                    ArepCotizaciones.LblLetras.Text = Letras(Me.TxtNetoPagar.Text, Me.TxtMonedaFactura.Text)

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizaciones.LblRuc.Text = "Numero RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                                        ArepCotizaciones.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                                    End If

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If
                                    End If
                                End If
                                ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ArepCotizaciones.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
                                ArepCotizaciones.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepCotizaciones.LblOrden.Text = Me.TxtNumeroEnsamble.Text
                                ArepCotizaciones.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
                                ArepCotizaciones.LblNombres.Text = Me.TxtNombres.Text
                                ArepCotizaciones.LblDireccionProveedor.Text = Me.TxtDireccion.Text
                                ArepCotizaciones.LblTelefono.Text = Me.TxtTelefono.Text
                                ArepCotizaciones.LblFechaVence.Text = Format(Me.DTVencimiento.Value, "dd/MM/yyyy")

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizaciones.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizaciones.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizaciones.LblTotal.Text = "0.00"
                                End If

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepCotizaciones.DataSource = SQL
                                ArepCotizaciones.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepCotizaciones.Document
                                ViewerForm.Show()
                                ArepCotizaciones.Run(True)
                            Case "Cotizacion con Fotos"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                                        ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                                    Else
                                        ImprimeFacturaPreview = False
                                    End If

                                    ArepCotizacionFoto.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                    ArepCotizacionFoto.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                                        ArepCotizacionFoto.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                                    End If
                                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                                        RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                                        If Dir(RutaLogo) <> "" Then
                                            ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                                        End If

                                    End If
                                End If
                                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

                                If Val(Me.TxtSubTotal.Text) <> 0 Then
                                    ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblSubTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtIva.Text) <> 0 Then
                                    ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblIva.Text = "0.00"
                                End If
                                If Val(Me.TxtPagado.Text) <> 0 Then
                                    ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblPagado.Text = "0.00"
                                End If
                                If Val(Me.TxtNetoPagar.Text) <> 0 Then
                                    ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblTotal.Text = "0.00"
                                End If
                                If Val(Me.TxtDescuento.Text) <> 0 Then
                                    ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
                                Else
                                    ArepCotizacionFoto.LblDescuento.Text = "0.00"
                                End If

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

                Case "Salida Bodega"

                    TipoImpresion = Me.CboTipoProducto.Text

                    SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Coordenadas")
                    If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                        Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                            Case "Papel en Blanco"
                                SqlDatos = "SELECT * FROM DatosEmpresa"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                                DataAdapter.Fill(DataSet, "DatosEmpresa")
                                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                    ArepSalidaBodega.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                                    ArepSalidaBodega.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                End If

                                ArepSalidaBodega.LblNotas.Text = Me.TxtObservaciones.Text
                                ArepSalidaBodega.LblCodProveedor.Text = Me.TxtCodigoClientes.Text


                                SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                                DataAdapter.Fill(DataSet, "Coordenadas")
                                Ancho = DataSet.Tables("Coordenadas").Rows(0)("Ancho")
                                Largo = DataSet.Tables("Coordenadas").Rows(0)("Largo")

                                SQL.ConnectionString = Conexion
                                SQL.SQL = SQlDetalle
                                ArepSalidaBodega.DataSource = SQL
                                ArepSalidaBodega.Document.Name = "Reporte de " & Me.CboTipoProducto.Text
                                'ArepSalidaBodega.PageSettings.PaperWidth = Str(Ancho)
                                'ArepSalidaBodega.PageSettings.PaperHeight = Largo
                                'ArepSalidaBodega.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom

                                Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepSalidaBodega.Document
                                ViewerForm.Show()
                                ArepSalidaBodega.Run(False)

                            Case "Personalizado"

                                If ConsecutivoFacturaSerie = False Then
                                    TipoImpresion = Me.CboTipoProducto.Text
                                Else
                                    TipoImpresion = Me.CboTipoProducto.Text & Me.CmbSerie.Text
                                End If

                                Dim StrSQLUpdate As String
                                Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                                RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                                ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                                Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                                Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                                Dim DatasetDatos As New DataSet


                                MiConexionAccess.Open()
                                DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                                StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & NumeroFactura & "' "
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                '///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                                EscribirArchivo()

                                RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                                If Dir(RutaReportes) <> "" Then
                                    Shell(RutaReportes)
                                End If
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
                'SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                '             "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()
            End If

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Imprimio la Factura Previo: " & Me.TxtNumeroEnsamble.Text)

            LimpiarFacturas()

            If NombreCliente = "Alumnos" Then
                Me.Label12.Visible = False
                Me.CboCodigoVendedor.Visible = False
            End If

            If UsuarioBodega <> "Ninguna" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                Me.CboCodigoBodega.Enabled = False
                Me.Button7.Enabled = False
            End If

            If UsuarioTipoFactura <> "Ninguna" Then
                Me.CboTipoProducto.Text = UsuarioTipoFactura
            End If

            If UsuarioVendedor <> "Ninguna" Then
                Me.CboCodigoVendedor.Text = UsuarioVendedor
            End If

            If UsuarioCliente <> "Ninguna" Then
                Me.TxtCodigoClientes.Text = UsuarioCliente
            End If


            Me.Button2.Enabled = True

            'CmdCerrar_Click(sender, e)

            SalirFactura = True


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BtnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalida.Click
        Dim NumeroFactura As String, iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String, Fecha As String, IdDetalle As Double
        Dim Descripcion_Producto As String, TipoFactura As String, FacturaBodega As Boolean = False, FacturaSerie As Boolean = False, CompraBodega As Boolean = False
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Existencia As Double
        Dim ExistenciaNegativa As String, SqlDatos As String, CostoUnitario As Double = 0
        Dim RstCosto As New RstCostoPromedio

        'Try

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            'Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            'Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
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
        Me.CboTipoProducto.Text = "Salida Bodega"
        TipoFactura = "Salida Bodega"
        Me.TxtNumeroEnsamble.Text = "-----0-----"


        NumeroFactura = GenerarNumeroFactura(ConsecutivoFacturaManual, Me.CboTipoProducto.Text)

        Quien = "NumeroFacturas"

        Dim TablaFactura As TablaFactura = New TablaFactura

        TablaFactura.Numero_Factura = NumeroFactura
        TablaFactura.Fecha_Factura = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
        TablaFactura.Tipo_Factura = CboTipoProducto.Text
        TablaFactura.Fecha_Vencimiento = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Moneda_Factura = TxtMonedaFactura.Text
        TablaFactura.Moneda_Imprime = TxtMonedaImprime.Text
        TablaFactura.Cod_Cliente = TxtCodigoClientes.Text
        TablaFactura.Cod_Vendedor = CboCodigoVendedor.Text
        TablaFactura.CodBodega1 = CboCodigoBodega.Text
        TablaFactura.Cod_Cajero = CboCajero.Text
        TablaFactura.Nombre_Cliente = TxtNombres.Text
        TablaFactura.Apellido_Cliente = TxtApellidos.Text
        TablaFactura.Direccion_Cliente = TxtDireccion.Text
        TablaFactura.Telefono_Cliente = TxtTelefono.Text
        TablaFactura.Fecha_Envio = Format(DTVencimiento.Value, "dd/MM/yyyy")
        TablaFactura.Via_Envarque = ""
        TablaFactura.SuReferencia1 = CboReferencia.Text
        TablaFactura.Nuestra_Referencia = ""
        TablaFactura.Codigo_Proyecto = CboProyecto.Text




        If My.Forms.FrmFacturas.SubTotalGral <> 0 Then
            TablaFactura.Sub_Total = Redondeo(My.Forms.FrmFacturas.SubTotalGral, 4)
        Else
            TablaFactura.Sub_Total = 0
        End If

        If My.Forms.FrmFacturas.IvaGral <> 0 Then
            TablaFactura.IVA_Factura = Redondeo(My.Forms.FrmFacturas.IvaGral, 4)
        Else
            TablaFactura.IVA_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtPagado.Text <> "" Then
            TablaFactura.Pagado_Factura = My.Forms.FrmFacturas.TxtPagado.Text
        Else
            TablaFactura.Pagado_Factura = 0
        End If

        If My.Forms.FrmFacturas.TxtNetoPagar.Text <> "" Then
            TablaFactura.Neto_Pagar = My.Forms.FrmFacturas.TxtNetoPagar.Text
        Else
            TablaFactura.Neto_Pagar = 0
        End If

        If RadioButton1.Checked = True Then
            TablaFactura.Metodo_Pago = "Credito"
        Else
            TablaFactura.Metodo_Pago = "Contado"
        End If

        If OptExsonerado.Checked = True Then
            TablaFactura.Exonerado_Factura = 1
        Else
            TablaFactura.Exonerado_Factura = 0
        End If

        If OptRet1Porciento.Checked = True Then
            TablaFactura.MontoRetencion1_Porciento = TablaFactura.Sub_Total * 0.01
            TablaFactura.Retener1_Porciento = 1
        Else
            TablaFactura.MontoRetencion1_Porciento = 0
            TablaFactura.Retener1_Porciento = 0
        End If

        If OptRet2Porciento.Checked = True Then
            TablaFactura.MontoRetencion2_Porciento = TablaFactura.Sub_Total * 0.02
            TablaFactura.Retener2_Porciento = 1
        Else
            TablaFactura.MontoRetencion2_Porciento = 0
            TablaFactura.Retener2_Porciento = 0
        End If


        If Not CboProyecto.Text = "" Then
            TablaFactura.Codigo_Proyecto = CboProyecto.Columns(0).Text
        End If

        If CboReferencia.Text <> "" Then
            TablaFactura.Referencia_Factura = CboReferencia.Text
        End If

        TablaFactura.Fecha_Hora = Format(My.Forms.FrmFacturas.DTPFecha.Value, "dd/MM/yyyy") & " " & Format(Now, "HH:mm")
        TablaFactura.Descuentos_Factura = CDbl(Val(TxtDescuento.Text))


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaFacturas(TablaFactura)
        Quien = "NumeroFacturas"
        Me.TxtNumeroEnsamble.Text = NumeroFactura


        '////////////////////////////////BLOQUEO LOS BOTONES HASTA QUE SE GRABE LA SALIDA ///////////////////////////////////
        Me.ButtonAgregar.Enabled = False
        Me.Button2.Enabled = False
        Me.CmdProcesar.Enabled = False
        Me.Button8.Enabled = False
        Me.Button5.Enabled = False
        Me.BtnSalida.Enabled = False
        Me.CmdNuevo.Enabled = False

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0



        Do While iPosicion < Registros

            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            Else
                IdDetalle = -1
            End If


            'Me.BindingDetalle.Item(iPosicion)("Numero_Factura") = NumeroFactura
            'Me.BindingDetalle.Item(iPosicion)("Fecha_Factura") = DTPFecha.Value
            'Me.BindingDetalle.Item(iPosicion)("Tipo_Factura") = CboTipoProducto.Text
            Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto") = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

            'IdDetalle = -1

            'CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            ExistenciaNegativa = ValidarExistenciaNegativa(CodigoProducto)
            Existencia = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            Else
                Descuento = 0
            End If
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

            If Existencia < Cantidad Then
                If Me.CboTipoProducto.Text <> "Cotizacion" And Me.CboTipoProducto.Text <> "Devolucion de Venta" Then
                    If ExistenciaNegativa <> "SI" Then
                        If Existencia > 0 Then
                            Cantidad = Existencia
                            Importe = PrecioNeto * Cantidad
                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                        Else
                            Cantidad = 0
                            Descuento = 0
                            Importe = 0
                            MsgBox("Existencia Negativa: Disponible " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                        End If
                    End If
                End If
            End If



            If FacturaTarea = True Then
                If IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba
                End If

            Else
                If IsDBNull(Me.BindingDetalle.Item(iPosicion)("Costo_Unitario")) Then
                    RstCosto = CostoPromedioKardex(CodigoProducto, Me.DTPFecha.Value)
                    CostoUnitario = RstCosto.Costo_Cordoba
                End If

            End If



            GrabaDetalleFactura(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, CostoUnitario)


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

        'da.Update(ds.Tables("DetalleFactura"))
        'ds.Tables("DetalleFactura").Clear()

        Bitacora(Now, NombreUsuario, "Facturacion", "Se Genero una Salida: " & Me.TxtNumeroEnsamble.Text)

        '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
        SqlCompras = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Numero_Factura,Detalle_Facturas.Fecha_Factura,Detalle_Facturas.Tipo_Factura FROM  Detalle_Facturas  " & _
            "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleFacturas")
        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
        ds = New DataSet
        da = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleFactura")
        Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
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
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False


        '////////////////////////////ACTUALIZO TODO POR CUALQUIER CAMBIO /////////////////////////////////
        ActualizaMETODOFactura()


        '////////////////////////////////BLOQUEO LOS BOTONES HASTA QUE SE GRABE LA SALIDA ///////////////////////////////////
        Me.ButtonAgregar.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdProcesar.Enabled = True
        Me.Button8.Enabled = True
        Me.Button5.Enabled = True
        Me.BtnSalida.Enabled = True
        Me.CmdNuevo.Enabled = True
        'GrabaFacturas(NumeroFactura)

        '    Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub BtnFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFacturas.Click
        Quien = "DevFacturas"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            If Not My.Forms.FrmConsultas.TipoCompra = Nothing Then

                Me.TxtNumeroFactura.Text = My.Forms.FrmConsultas.NumFactura

                If PermiteEditar(Acceso, "Facturacion") = False Then
                    If Me.CboTipoProducto.Text = "Facturacion" Then
                        Me.ButtonAgregar.Enabled = False
                    End If
                    'Me.TrueDBGridComponentes.Enabled = False

                Else
                    Me.ButtonAgregar.Enabled = True
                    Me.TrueDBGridComponentes.Enabled = True


                End If
            End If
        End If
    End Sub

    Private Sub TrueDBGridComponentes_BackColorChanged(sender As Object, e As EventArgs) Handles TrueDBGridComponentes.BackColorChanged

    End Sub
End Class