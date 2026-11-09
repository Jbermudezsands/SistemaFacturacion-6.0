Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data

''' <summary>
''' Fachada del Motor de Costos. Independiente de formularios: recibe parametros y devuelve resultados.
'''
''' FASE 4a: solo lectura. Expone el calculo de costo promedio en memoria (replica validada contra
''' CostoPromedioKardex con ComparadorCostos). Todavia NO esta conectado a ningun formulario ni reporte
''' y NO reemplaza ninguna funcion existente.
'''
''' Pendiente (fases siguientes): RepararDocumento, RecalcularProducto, RecalcularRango, ReconstruirDesde,
''' costo para transferencias y costo por bodega.
''' </summary>
Public Class MotorCostos

    Private ReadOnly _repositorio As RepositorioMovimientos
    Private ReadOnly _calculador As New CalculadorCostoPromedio
    Private ReadOnly _cadena As String

    Public Sub New(ByVal cadenaConexion As String)
        _cadena = cadenaConexion
        _repositorio = New RepositorioMovimientos(cadenaConexion)
    End Sub

    ''' <summary>Costo general del producto a una fecha. Equivale a CostoPromedioKardex(codigo, fecha).</summary>
    Public Function CostoGeneral(ByVal codProducto As String, ByVal fecha As Date) As ResultadoCosteo
        Dim movs As List(Of MovimientoCosto)
        Dim cands As List(Of UltimoCostoCandidato)
        If _precargaMovs IsNot Nothing AndAlso _precargaFecha = fecha.Date Then
            ' Carga masiva previa (reportes): sin tocar la BD.
            Dim clave As String = codProducto.Trim()
            If Not _precargaMovs.TryGetValue(clave, movs) Then movs = New List(Of MovimientoCosto)
            If Not _precargaCands.TryGetValue(clave, cands) Then cands = New List(Of UltimoCostoCandidato)
        Else
            movs = _repositorio.CargarMovimientos(codProducto, fecha)
            cands = _repositorio.CargarCandidatosUltimoCosto(codProducto, fecha)
        End If
        Return _calculador.CostoAFecha(codProducto, fecha, movs, cands)
    End Function

    Private _precargaFecha As Date
    Private _precargaMovs As Dictionary(Of String, List(Of MovimientoCosto))
    Private _precargaCands As Dictionary(Of String, List(Of UltimoCostoCandidato))

    ''' <summary>
    ''' Carga de una vez los movimientos de TODOS los productos hasta la fecha. Despues, CostoGeneral(cod, esa fecha)
    ''' se resuelve en memoria (para reportes que costean miles de productos a la misma fecha). Usar siempre con
    ''' LimpiarPrecarga al terminar. Para otra fecha, CostoGeneral consulta la BD como siempre.
    ''' </summary>
    Public Sub PrecargarAFecha(ByVal fecha As Date)
        Dim movs As Dictionary(Of String, List(Of MovimientoCosto)) = _repositorio.CargarMovimientosMasivo(fecha)
        Dim cands As Dictionary(Of String, List(Of UltimoCostoCandidato)) = _repositorio.CargarCandidatosMasivo(fecha)
        _precargaMovs = RecortarClaves(movs, AddressOf CompararMov)
        _precargaCands = RecortarClaves(cands, AddressOf CompararCand)
        _precargaFecha = fecha.Date
    End Sub

    Public Sub LimpiarPrecarga()
        _precargaMovs = Nothing
        _precargaCands = Nothing
    End Sub

    Private Shared Function CompararMov(ByVal a As MovimientoCosto, ByVal b As MovimientoCosto) As Integer
        Dim c As Integer = a.Fecha.CompareTo(b.Fecha)
        If c <> 0 Then Return c
        Return a.Id.CompareTo(b.Id)
    End Function

    Private Shared Function CompararCand(ByVal a As UltimoCostoCandidato, ByVal b As UltimoCostoCandidato) As Integer
        Dim c As Integer = a.Fecha.CompareTo(b.Fecha)
        If c <> 0 Then Return c
        Return a.Id.CompareTo(b.Id)
    End Function

    Private Shared Function RecortarClaves(Of T)(ByVal origen As Dictionary(Of String, List(Of T)), ByVal orden As Comparison(Of T)) As Dictionary(Of String, List(Of T))
        Dim r As New Dictionary(Of String, List(Of T))(StringComparer.OrdinalIgnoreCase)
        For Each kv As KeyValuePair(Of String, List(Of T)) In origen
            Dim k As String = kv.Key.Trim()
            Dim l As List(Of T) = Nothing
            If r.TryGetValue(k, l) Then
                l.AddRange(kv.Value)
                l.Sort(orden)
            Else
                r.Add(k, kv.Value)
            End If
        Next
        Return r
    End Function

    ''' <summary>
    ''' Equivale a Funciones.CostoPromedio(codigo): costo con TODO el historial (sin fecha de corte) y SIN el respaldo de
    ''' "ultimo costo" (si no hay existencia neta devuelve 0), redondeado a 6 decimales como el original.
    ''' </summary>
    Public Function CostoActual(ByVal codProducto As String) As RstCostoPromedio
        Dim r As ResultadoCosteo = CostoGeneral(codProducto, New Date(2079, 6, 6))
        Dim rst As New RstCostoPromedio
        rst.Codigo_Producto = codProducto
        rst.Fecha_Compras = Date.Today
        If r.Cantidad <> 0 Then
            rst.Costo_Cordoba = CDbl(Format(r.Importe / r.Cantidad, "##,##0.000000"))
            rst.Costo_Dolar = CDbl(Format(r.ImporteDolar / r.Cantidad, "##,##0.000000"))
        End If
        Return rst
    End Function

    ''' <summary>
    ''' Costo con el que se graba una linea de Factura / Devolucion de Venta / Salida Bodega al fecha del documento.
    ''' Mismo resultado que CostoPromedioKardex(codigo, fecha). La regla "si la linea ya tiene Costo_Unitario no se
    ''' recalcula" la aplica el formulario (solo llama cuando el costo esta vacio).
    ''' </summary>
    Public Function CostoParaFactura(ByVal codProducto As String, ByVal fecha As Date) As RstCostoPromedio
        Return CostoGeneral(codProducto, fecha).ARstCostoPromedio()
    End Function

    ''' <summary>
    ''' Costo de una linea de Transferencia. Las transferencias no entran al promedio (igual que Kardex), por lo
    ''' que el costo es el Kardex a la fecha; la Enviada y la Recibida usan el MISMO valor.
    ''' </summary>
    Public Function CostoParaTransferencia(ByVal codProducto As String, ByVal fecha As Date) As RstCostoPromedio
        Return CostoGeneral(codProducto, fecha).ARstCostoPromedio()
    End Function

    ''' <summary>
    ''' Recalcula los costos guardados (Detalle_Facturas / Devolucion de Compra / Transferencia Recibida) del producto
    ''' desde la fecha indicada en adelante. Lo anterior no se toca. Una transaccion por producto.
    ''' </summary>
    Public Function RecalcularDesde(ByVal codProducto As String, ByVal desde As Date) As ResultadoReparacionProducto
        Return New ReparadorCostos(_cadena, Contexto).RecalcularProducto(codProducto, True, desde)
    End Function

    ''' <summary>
    ''' Trazabilidad (AjusteCostosLog): los formularios pueden indicar origen y referencia antes de llamar a
    ''' RepararDocumento / ProcesarPendientes / RecalcularDesde. Todo lo ajustado por esta instancia comparte el Lote.
    ''' </summary>
    Public Property Contexto As New ContextoAjusteCostos()

    Public Sub IndicarOrigen(ByVal origen As String, ByVal referencia As String)
        Contexto = New ContextoAjusteCostos(origen, referencia)
    End Sub

    ''' <summary>
    ''' Para un documento grabado con fecha F (Factura, Devolucion de Venta, Salida Bodega, Transferencia): si el producto tiene
    ''' entradas POSTERIORES a F (compras, devoluciones de compra o devoluciones de venta), el costo de los movimientos
    ''' posteriores cambia, porque el documento saco/metio unidades al costo del dia F. En ese caso se recalcula el producto
    ''' desde F. Reemplaza a Funciones.RepararCostosDocumento (mismo criterio de deteccion, un solo recorrido por producto).
    ''' Devuelve cuantos productos se recalcularon.
    ''' </summary>
    Public Function RepararDocumento(ByVal detalle As DataTable, ByVal fechaDocumento As Date) As Integer
        Dim productos As New HashSet(Of String)
        If detalle IsNot Nothing AndAlso detalle.Columns.Contains("Cod_Producto") Then
            For Each fila As DataRow In detalle.Rows
                If fila.RowState <> DataRowState.Deleted AndAlso Not IsDBNull(fila("Cod_Producto")) Then
                    Dim cod As String = Convert.ToString(fila("Cod_Producto")).Trim()
                    If cod <> "" Then productos.Add(cod)
                End If
            Next
        End If
        Return RepararDocumento(productos, fechaDocumento)
    End Function

    Public Function RepararDocumento(ByVal productos As IEnumerable(Of String), ByVal fechaDocumento As Date) As Integer
        Dim recalculados As Integer = 0
        For Each cod As String In productos
            If ExisteEntradaPosterior(cod, fechaDocumento.Date) Then
                RecalcularDesde(cod, fechaDocumento.Date)
                recalculados += 1
            End If
        Next
        Return recalculados
    End Function

    Private Function ExisteEntradaPosterior(ByVal codProducto As String, ByVal fecha As Date) As Boolean
        Const sql As String =
            "SELECT CASE WHEN EXISTS (SELECT 1 FROM Detalle_Compras WHERE Cod_Producto = @p AND Fecha_Compra > @f " &
            "                         AND Tipo_Compra IN (N'Mercancia Recibida', N'Devolucion de Compra')) " &
            "          OR EXISTS (SELECT 1 FROM Detalle_Facturas WHERE Cod_Producto = @p AND Fecha_Factura > @f " &
            "                         AND Tipo_Factura = N'Devolucion de Venta') THEN 1 ELSE 0 END"
        Using cn As New SqlClient.SqlConnection(_cadena)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(sql, cn)
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 100).Value = codProducto
                cmd.Parameters.Add("@f", SqlDbType.DateTime).Value = fecha
                Return Convert.ToInt32(cmd.ExecuteScalar()) = 1
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Procesa la cola CostosPendientes (la llena el disparador de Detalle_Compras al registrar, editar o anular
    ''' una compra). Recalcula cada producto desde su fecha mas antigua pendiente. Si un producto falla queda en la
    ''' cola para el siguiente intento. Devuelve la cantidad de productos recalculados. Si la tabla aun no existe
    ''' (script no aplicado) devuelve 0.
    ''' </summary>
    Public Function ProcesarPendientes() As Integer
        Dim pendientes As New List(Of Object())
        Try
            Using cn As New SqlClient.SqlConnection(_cadena)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SELECT Cod_Producto, MIN(FechaDesde), MAX(Id) FROM CostosPendientes GROUP BY Cod_Producto", cn)
                    Using r As SqlClient.SqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            pendientes.Add(New Object() {r.GetString(0), r.GetDateTime(1), r.GetInt32(2)})
                        End While
                    End Using
                End Using
            End Using
        Catch ex As SqlClient.SqlException
            Return 0
        End Try

        Dim procesados As Integer = 0
        For Each p As Object() In pendientes
            Try
                RecalcularDesde(CStr(p(0)), CDate(p(1)))
                Using cn As New SqlClient.SqlConnection(_cadena)
                    cn.Open()
                    Using cmd As New SqlClient.SqlCommand("DELETE FROM CostosPendientes WHERE Cod_Producto = @c AND Id <= @id", cn)
                        cmd.Parameters.Add("@c", SqlDbType.NVarChar, 100).Value = CStr(p(0))
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = CInt(p(2))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                procesados += 1
            Catch
                ' queda en la cola
            End Try
        Next
        Return procesados
    End Function

    ''' <summary>
    ''' Costo general del producto en varias fechas con una sola lectura de la BD (para reportes y recosteo).
    ''' La clave del diccionario es fecha.Date.
    ''' </summary>
    Public Function CostoGeneralPorFechas(ByVal codProducto As String, ByVal fechas As IEnumerable(Of Date)) As Dictionary(Of Date, ResultadoCosteo)
        Dim movs As List(Of MovimientoCosto) = _repositorio.CargarMovimientos(codProducto, Nothing)
        Dim cands As List(Of UltimoCostoCandidato) = _repositorio.CargarCandidatosUltimoCosto(codProducto, Nothing)
        Return _calculador.CostosPorFechas(codProducto, fechas, movs, cands)
    End Function

End Class
