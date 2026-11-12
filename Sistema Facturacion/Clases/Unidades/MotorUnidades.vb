Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' Motor unico de existencias fisicas (unidades): Inicial, Entrada, Salida y Saldo por producto, con filtros
''' por producto, linea, bodega y rubro. Todos los reportes que muestren unidades deben usar esta clase para
''' que den el mismo resultado.
'''
''' REGLA UNICA (validada contra DetalleBodegas):
'''   Entradas : Mercancia Recibida + Transferencia Recibida (Detalle_Compras) + Devolucion de Venta (Detalle_Facturas)
'''   Salidas  : Factura + Salida Bodega + Transferencia Enviada (Detalle_Facturas) + Devolucion de Compra (Detalle_Compras)
'''   Inicial  : todo lo anterior con fecha MENOR a la fecha inicial.
'''   Periodo  : fecha desde la fecha inicial hasta la fecha final, ambas incluidas.
''' Cotizaciones y demas tipos no mueven existencia. Productos Servicio / Descuento se excluyen.
''' Solo lectura: no toca costos ni montos (eso es de MotorCostos).
''' </summary>
Public Class MotorUnidades

    Private Const TiposEntradaCompra As String = "'Mercancia Recibida', 'Transferencia Recibida'"
    Private Const TiposSalidaCompra As String = "'Devolucion de Compra'"
    Private Const TiposEntradaFactura As String = "'Devolucion de Venta'"
    Private Const TiposSalidaFactura As String = "'Factura', 'Salida Bodega', 'Transferencia Enviada'"

    Private ReadOnly _cadena As String

    Public Sub New(ByVal cadenaConexion As String)
        If String.IsNullOrEmpty(cadenaConexion) Then
            Throw New ArgumentException("La cadena de conexion es obligatoria.")
        End If
        _cadena = cadenaConexion
    End Sub

    ''' <summary>
    ''' Inicial / Entrada / Salida / Saldo de todos los productos que tengan movimiento (o inicial) y cumplan el filtro.
    ''' Productos sin ningun movimiento hasta la fecha final no aparecen: el reporte decide como tratarlos (cero).
    ''' </summary>
    Public Function Calcular(ByVal desde As Date, ByVal hasta As Date, ByVal filtro As FiltroUnidades) As List(Of ResultadoUnidades)
        If hasta.Date < desde.Date Then
            Throw New ArgumentException("La fecha final no puede ser menor que la fecha inicial.")
        End If
        Return Consultar(desde.Date, hasta.Date.AddDays(1), filtro)
    End Function

    ''' <summary>Igual que Calcular, indexado por ResultadoUnidades.Clave(producto, bodega) para buscar fila por fila.</summary>
    Public Function CalcularDiccionario(ByVal desde As Date, ByVal hasta As Date, ByVal filtro As FiltroUnidades) As Dictionary(Of String, ResultadoUnidades)
        Dim dic As New Dictionary(Of String, ResultadoUnidades)(StringComparer.OrdinalIgnoreCase)
        For Each r As ResultadoUnidades In Calcular(desde, hasta, filtro)
            dic(ResultadoUnidades.Clave(r.CodProducto, r.CodBodega)) = r
        Next
        Return dic
    End Function

    ''' <summary>Resultado de un solo producto (todas las bodegas, o solo codBodega si se indica). Nunca devuelve Nothing.</summary>
    Public Function CalcularProducto(ByVal codProducto As String, ByVal desde As Date, ByVal hasta As Date,
                                     Optional ByVal codBodega As String = "") As ResultadoUnidades
        Dim f As New FiltroUnidades
        f.ProductoDesde = codProducto
        f.ProductoHasta = codProducto
        f.BodegaDesde = codBodega
        f.BodegaHasta = codBodega
        Dim lista As List(Of ResultadoUnidades) = Calcular(desde, hasta, f)
        If lista.Count > 0 Then Return lista(0)
        Dim r As New ResultadoUnidades
        r.CodProducto = FiltroUnidades.Texto(codProducto)
        r.CodBodega = FiltroUnidades.Texto(codBodega)
        Return r
    End Function

    ''' <summary>Existencia (saldo) del producto al cierre de la fecha indicada.</summary>
    Public Function ExistenciaAFecha(ByVal codProducto As String, ByVal fecha As Date,
                                     Optional ByVal codBodega As String = "") As Double
        Dim f As New FiltroUnidades
        f.ProductoDesde = codProducto
        f.ProductoHasta = codProducto
        f.BodegaDesde = codBodega
        f.BodegaHasta = codBodega
        ' Inicial de "el dia siguiente" = todo lo ocurrido hasta el cierre de fecha.
        Dim lista As List(Of ResultadoUnidades) = Consultar(fecha.Date.AddDays(1), fecha.Date.AddDays(1), f)
        If lista.Count = 0 Then Return 0
        Return lista(0).Inicial
    End Function

    ' ------------------------------------------------------------------
    ' Consulta
    ' ------------------------------------------------------------------

    ''' <param name="desde">Primer dia del periodo (el Inicial es todo lo anterior).</param>
    ''' <param name="limite">Primer dia FUERA del periodo (fecha final + 1 dia).</param>
    Private Function Consultar(ByVal desde As Date, ByVal limite As Date, ByVal filtro As FiltroUnidades) As List(Of ResultadoUnidades)
        If filtro Is Nothing Then filtro = New FiltroUnidades

        Dim sql As New StringBuilder
        sql.Append("SELECT M.Cod AS CodProducto, ")
        If filtro.AgruparPorBodega Then
            sql.Append("M.Bod AS CodBodega, ")
        Else
            sql.Append("'' AS CodBodega, ")
        End If
        sql.Append("MAX(P.Cod_Linea) AS CodLinea, ")
        sql.Append("SUM(CASE WHEN M.Fec < @Desde THEN M.Ent - M.Sal ELSE 0 END) AS Inicial, ")
        sql.Append("SUM(CASE WHEN M.Fec >= @Desde THEN M.Ent ELSE 0 END) AS Entrada, ")
        sql.Append("SUM(CASE WHEN M.Fec >= @Desde THEN M.Sal ELSE 0 END) AS Salida ")
        sql.Append("FROM ( ")

        ' --- Compras: entradas (Mercancia / Transferencia Recibida) y salida (Devolucion de Compra)
        sql.Append("SELECT DC.Cod_Producto AS Cod, C.Cod_Bodega AS Bod, DC.Fecha_Compra AS Fec, ")
        sql.Append("CASE WHEN DC.Tipo_Compra IN (" & TiposEntradaCompra & ") THEN ISNULL(DC.Cantidad, 0) ELSE 0 END AS Ent, ")
        sql.Append("CASE WHEN DC.Tipo_Compra IN (" & TiposSalidaCompra & ") THEN ISNULL(DC.Cantidad, 0) ELSE 0 END AS Sal ")
        sql.Append("FROM Detalle_Compras AS DC ")
        sql.Append("INNER JOIN Compras AS C ON C.Numero_Compra = DC.Numero_Compra ")
        sql.Append("   AND C.Fecha_Compra = DC.Fecha_Compra AND C.Tipo_Compra = DC.Tipo_Compra ")
        sql.Append("WHERE DC.Tipo_Compra IN (" & TiposEntradaCompra & ", " & TiposSalidaCompra & ") ")
        sql.Append("  AND DC.Fecha_Compra < @Limite ")

        sql.Append("UNION ALL ")

        ' --- Facturas: entrada (Devolucion de Venta) y salidas (Factura / Salida Bodega / Transferencia Enviada)
        sql.Append("SELECT DF.Cod_Producto, F.Cod_Bodega, DF.Fecha_Factura, ")
        sql.Append("CASE WHEN DF.Tipo_Factura IN (" & TiposEntradaFactura & ") THEN ISNULL(DF.Cantidad, 0) ELSE 0 END, ")
        sql.Append("CASE WHEN DF.Tipo_Factura IN (" & TiposSalidaFactura & ") THEN ISNULL(DF.Cantidad, 0) ELSE 0 END ")
        sql.Append("FROM Detalle_Facturas AS DF ")
        sql.Append("INNER JOIN Facturas AS F ON F.Numero_Factura = DF.Numero_Factura ")
        sql.Append("   AND F.Fecha_Factura = DF.Fecha_Factura AND F.Tipo_Factura = DF.Tipo_Factura ")
        sql.Append("WHERE DF.Tipo_Factura IN (" & TiposEntradaFactura & ", " & TiposSalidaFactura & ") ")
        sql.Append("  AND DF.Fecha_Factura < @Limite ")

        sql.Append(") AS M ")
        sql.Append("INNER JOIN Productos AS P ON P.Cod_Productos = M.Cod ")
        sql.Append("WHERE ISNULL(P.Tipo_Producto, '') NOT IN ('Servicio', 'Descuento') ")

        Dim parametros As New List(Of SqlParameter)
        AgregarRango(sql, parametros, "P.Cod_Productos", "Producto", filtro.ProductoDesde, filtro.ProductoHasta)
        AgregarRango(sql, parametros, "P.Cod_Linea", "Linea", filtro.LineaDesde, filtro.LineaHasta)
        AgregarRango(sql, parametros, "P.Cod_Rubro", "Rubro", filtro.RubroDesde, filtro.RubroHasta)
        AgregarRango(sql, parametros, "M.Bod", "Bodega", filtro.BodegaDesde, filtro.BodegaHasta)

        sql.Append("GROUP BY M.Cod")
        If filtro.AgruparPorBodega Then sql.Append(", M.Bod")
        sql.Append(" ORDER BY M.Cod")
        If filtro.AgruparPorBodega Then sql.Append(", M.Bod")

        Dim lista As New List(Of ResultadoUnidades)
        Using cn As New SqlConnection(_cadena)
            cn.Open()
            Using cmd As New SqlCommand(sql.ToString(), cn)
                cmd.CommandTimeout = 300
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = desde
                cmd.Parameters.Add("@Limite", SqlDbType.DateTime).Value = limite
                For Each p As SqlParameter In parametros
                    cmd.Parameters.Add(p)
                Next
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        Dim r As New ResultadoUnidades
                        r.CodProducto = Convert.ToString(rd.GetValue(0)).Trim()
                        r.CodBodega = Convert.ToString(rd.GetValue(1)).Trim()
                        r.CodLinea = If(rd.IsDBNull(2), "", Convert.ToString(rd.GetValue(2)).Trim())
                        r.Inicial = LeerDouble(rd, 3)
                        r.Entrada = LeerDouble(rd, 4)
                        r.Salida = LeerDouble(rd, 5)
                        lista.Add(r)
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    ''' <summary>Agrega "AND columna >= @XDesde" / "AND columna &lt;= @XHasta" solo si el valor no viene vacio.</summary>
    Private Shared Sub AgregarRango(ByVal sql As StringBuilder, ByVal parametros As List(Of SqlParameter),
                                    ByVal columna As String, ByVal nombre As String,
                                    ByVal desde As String, ByVal hasta As String)
        Dim d As String = FiltroUnidades.Texto(desde)
        Dim h As String = FiltroUnidades.Texto(hasta)
        If d <> "" Then
            sql.Append("AND " & columna & " >= @" & nombre & "Desde ")
            parametros.Add(New SqlParameter("@" & nombre & "Desde", SqlDbType.NVarChar, 50) With {.Value = d})
        End If
        If h <> "" Then
            sql.Append("AND " & columna & " <= @" & nombre & "Hasta ")
            parametros.Add(New SqlParameter("@" & nombre & "Hasta", SqlDbType.NVarChar, 50) With {.Value = h})
        End If
    End Sub

    Private Shared Function LeerDouble(ByVal rd As SqlDataReader, ByVal indice As Integer) As Double
        If rd.IsDBNull(indice) Then Return 0
        Return Convert.ToDouble(rd.GetValue(indice))
    End Function

End Class
