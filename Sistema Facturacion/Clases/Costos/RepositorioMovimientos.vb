Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
''' Acceso a datos del motor de costos. Una consulta por tabla, todas parametrizadas.
''' Replica los JOIN de CostoPromedioKardex: Detalle con su cabecera (Compras / Facturas)
''' y TasaCambio por fecha. La tasa se une con LEFT JOIN para poder CONTAR los movimientos
''' que el INNER JOIN original descarta en silencio.
''' </summary>
Public Class RepositorioMovimientos

    Private ReadOnly _cadenaConexion As String

    Public Sub New(ByVal cadenaConexion As String)
        If String.IsNullOrEmpty(cadenaConexion) Then
            Throw New ArgumentException("La cadena de conexion es obligatoria.")
        End If
        _cadenaConexion = cadenaConexion
    End Sub

    Public ReadOnly Property CadenaConexion As String
        Get
            Return _cadenaConexion
        End Get
    End Property

    ' ------------------------------------------------------------------
    ' Calculo de costo (solo lectura)
    ' ------------------------------------------------------------------

    ''' <summary>
    ''' Carga las compras (Mercancia Recibida / Devolucion de Compra) y los movimientos de facturas
    ''' (Factura / Salida Bodega / Devolucion de Venta) de un producto hasta la fecha de corte.
    ''' Si fechaCorte es Nothing se carga todo el historial.
    ''' </summary>
    Public Function CargarMovimientos(ByVal codProducto As String, ByVal fechaCorte As Date?) As List(Of MovimientoCosto)
        Dim lista As New List(Of MovimientoCosto)
        Using cn As New SqlConnection(_cadenaConexion)
            cn.Open()
            lista.AddRange(CargarComprasKardex(cn, Nothing, codProducto, fechaCorte))

            Dim sqlFacturas As String =
                "SELECT df.id_Detalle_Factura, df.Numero_Factura, df.Fecha_Factura, df.Tipo_Factura, " &
                "       df.Cantidad, df.Precio_Unitario, df.Precio_Neto, df.Costo_Unitario, tc.MontoTasa " &
                "FROM Detalle_Facturas df " &
                "INNER JOIN Facturas f ON df.Numero_Factura = f.Numero_Factura " &
                "    AND df.Fecha_Factura = f.Fecha_Factura AND df.Tipo_Factura = f.Tipo_Factura " &
                "LEFT JOIN TasaCambio tc ON f.Fecha_Factura = tc.FechaTasa " &
                "WHERE df.Cod_Producto = @Producto " &
                "  AND df.Tipo_Factura IN ('Factura', 'Salida Bodega', 'Devolucion de Venta') "
            If fechaCorte.HasValue Then
                sqlFacturas &= "  AND df.Fecha_Factura <= @Fecha "
            End If
            sqlFacturas &= "ORDER BY df.Fecha_Factura, df.id_Detalle_Factura"

            Using cmd As New SqlCommand(sqlFacturas, cn)
                AgregarParametros(cmd, codProducto, fechaCorte)
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        Dim m As New MovimientoCosto
                        m.Origen = TipoOrigenMovimiento.Factura
                        m.Id = Convert.ToDecimal(rd.GetValue(0))
                        m.Numero = Convert.ToString(rd.GetValue(1))
                        m.Fecha = Convert.ToDateTime(rd.GetValue(2))
                        m.Tipo = Convert.ToString(rd.GetValue(3))
                        m.CodProducto = codProducto
                        m.Cantidad = LeerDouble(rd, 4)
                        m.PrecioUnitario = LeerDouble(rd, 5)
                        m.PrecioNeto = LeerDouble(rd, 6)
                        m.CostoUnitario = LeerDouble(rd, 7)
                        m.Tasa = LeerDouble(rd, 8)
                        m.TieneCabecera = True
                        lista.Add(m)
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    ''' <summary>
    ''' Filas de Detalle_Facturas (cualquier tipo, igual que el SQL original) con Costo_Unitario &lt;&gt; 0
    ''' y TasaCambio existente, ordenadas por fecha e id. Es el respaldo "ultimo costo utilizado".
    ''' </summary>
    Public Function CargarCandidatosUltimoCosto(ByVal codProducto As String, ByVal fechaCorte As Date?) As List(Of UltimoCostoCandidato)
        Dim lista As New List(Of UltimoCostoCandidato)

        Dim sql As String =
            "SELECT df.id_Detalle_Factura, df.Fecha_Factura, df.Costo_Unitario, tc.MontoTasa " &
            "FROM Detalle_Facturas df " &
            "INNER JOIN TasaCambio tc ON df.Fecha_Factura = tc.FechaTasa " &
            "WHERE df.Cod_Producto = @Producto AND df.Costo_Unitario <> 0 "
        If fechaCorte.HasValue Then
            sql &= "  AND df.Fecha_Factura <= @Fecha "
        End If
        sql &= "ORDER BY df.Fecha_Factura, df.id_Detalle_Factura"

        Using cn As New SqlConnection(_cadenaConexion)
            cn.Open()
            Using cmd As New SqlCommand(sql, cn)
                AgregarParametros(cmd, codProducto, fechaCorte)
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        Dim c As New UltimoCostoCandidato
                        c.Id = Convert.ToDecimal(rd.GetValue(0))
                        c.Fecha = Convert.ToDateTime(rd.GetValue(1))
                        c.CostoUnitario = Convert.ToDouble(rd.GetValue(2))
                        c.Tasa = If(rd.IsDBNull(3), 0.0, Convert.ToDouble(rd.GetValue(3)))
                        lista.Add(c)
                    End While
                End Using
            End Using
        End Using

        Return lista
    End Function

    ''' <summary>
    ''' Codigos de producto (tabla Productos) en el rango indicado. Rango vacio = todos.
    ''' Misma regla que CmdCostear: Cod_Productos BETWEEN Desde AND Hasta.
    ''' </summary>
    Public Function ListarProductos(ByVal desde As String, ByVal hasta As String) As List(Of String)
        Dim lista As New List(Of String)
        Dim sql As String = "SELECT Cod_Productos FROM Productos"
        Dim filtrar As Boolean = Not (String.IsNullOrEmpty(desde) AndAlso String.IsNullOrEmpty(hasta))
        If filtrar Then
            sql &= " WHERE Cod_Productos BETWEEN @Desde AND @Hasta"
        End If
        sql &= " ORDER BY Cod_Productos"

        Using cn As New SqlConnection(_cadenaConexion)
            cn.Open()
            Using cmd As New SqlCommand(sql, cn)
                If filtrar Then
                    cmd.Parameters.Add("@Desde", SqlDbType.NVarChar, 50).Value = If(desde, "")
                    cmd.Parameters.Add("@Hasta", SqlDbType.NVarChar, 50).Value = If(hasta, "")
                End If
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        lista.Add(Convert.ToString(rd.GetValue(0)).Trim())
                    End While
                End Using
            End Using
        End Using

        Return lista
    End Function

    ' ------------------------------------------------------------------
    ' Carga para reparacion (usa la conexion/transaccion recibida)
    ' ------------------------------------------------------------------

    ''' <summary>Compras del kardex (Mercancia Recibida / Devolucion de Compra) con cabecera y tasa.</summary>
    Public Function CargarComprasKardex(ByVal cn As SqlConnection, ByVal tx As SqlTransaction,
                                        ByVal codProducto As String, ByVal fechaCorte As Date?) As List(Of MovimientoCosto)
        Dim lista As New List(Of MovimientoCosto)
        Dim sqlCompras As String =
            "SELECT dc.id_Detalle_Compra, dc.Numero_Compra, dc.Fecha_Compra, dc.Tipo_Compra, " &
            "       dc.Cantidad, dc.Precio_Unitario, dc.Precio_Neto, dc.Costo_Unitario, " &
            "       c.MonedaCompra, tc.MontoTasa " &
            "FROM Detalle_Compras dc " &
            "INNER JOIN Compras c ON dc.Numero_Compra = c.Numero_Compra " &
            "    AND dc.Fecha_Compra = c.Fecha_Compra AND dc.Tipo_Compra = c.Tipo_Compra " &
            "LEFT JOIN TasaCambio tc ON c.Fecha_Compra = tc.FechaTasa " &
            "WHERE dc.Cod_Producto = @Producto " &
            "  AND dc.Tipo_Compra IN ('Mercancia Recibida', 'Devolucion de Compra') "
        If fechaCorte.HasValue Then
            sqlCompras &= "  AND dc.Fecha_Compra <= @Fecha "
        End If
        sqlCompras &= "ORDER BY dc.Fecha_Compra, dc.id_Detalle_Compra"

        Using cmd As New SqlCommand(sqlCompras, cn, tx)
            AgregarParametros(cmd, codProducto, fechaCorte)
            Using rd As SqlDataReader = cmd.ExecuteReader()
                While rd.Read()
                    Dim m As New MovimientoCosto
                    m.Origen = TipoOrigenMovimiento.Compra
                    m.Id = Convert.ToDecimal(rd.GetValue(0))
                    m.Numero = Convert.ToString(rd.GetValue(1))
                    m.Fecha = Convert.ToDateTime(rd.GetValue(2))
                    m.Tipo = Convert.ToString(rd.GetValue(3))
                    m.CodProducto = codProducto
                    m.Cantidad = LeerDouble(rd, 4)
                    m.PrecioUnitario = LeerDouble(rd, 5)
                    m.PrecioNeto = LeerDouble(rd, 6)
                    m.CostoUnitario = LeerDouble(rd, 7)
                    If Not rd.IsDBNull(8) Then m.Moneda = Convert.ToString(rd.GetValue(8))
                    m.Tasa = LeerDouble(rd, 9)
                    m.TieneCabecera = True
                    lista.Add(m)
                End While
            End Using
        End Using
        Return lista
    End Function

    ''' <summary>
    ''' TODAS las filas de Detalle_Facturas del producto (cualquier tipo), con indicador de cabecera y tasa.
    ''' Copia el estado original (GuardarOriginal) para poder calcular que filas cambian.
    ''' </summary>
    Public Function CargarFilasFactura(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal codProducto As String) As List(Of MovimientoCosto)
        Dim lista As New List(Of MovimientoCosto)
        Dim sql As String =
            "SELECT df.id_Detalle_Factura, df.Numero_Factura, df.Fecha_Factura, df.Tipo_Factura, " &
            "       df.Cantidad, df.Precio_Unitario, df.Precio_Neto, df.Importe, df.Costo_Unitario, " &
            "       tc.MontoTasa, CASE WHEN f.Numero_Factura IS NULL THEN 0 ELSE 1 END " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Facturas f ON df.Numero_Factura = f.Numero_Factura " &
            "    AND df.Fecha_Factura = f.Fecha_Factura AND df.Tipo_Factura = f.Tipo_Factura " &
            "LEFT JOIN TasaCambio tc ON df.Fecha_Factura = tc.FechaTasa " &
            "WHERE df.Cod_Producto = @Producto " &
            "ORDER BY df.Fecha_Factura, df.id_Detalle_Factura"
        Using cmd As New SqlCommand(sql, cn, tx)
            AgregarParametros(cmd, codProducto, Nothing)
            Using rd As SqlDataReader = cmd.ExecuteReader()
                While rd.Read()
                    Dim m As New MovimientoCosto
                    m.Origen = TipoOrigenMovimiento.Factura
                    m.Id = Convert.ToDecimal(rd.GetValue(0))
                    m.Numero = Convert.ToString(rd.GetValue(1))
                    m.Fecha = Convert.ToDateTime(rd.GetValue(2))
                    m.Tipo = Convert.ToString(rd.GetValue(3))
                    m.CodProducto = codProducto
                    m.Cantidad = LeerDouble(rd, 4)
                    m.PrecioUnitario = LeerDouble(rd, 5)
                    m.PrecioNeto = LeerDouble(rd, 6)
                    m.Importe = LeerDouble(rd, 7)
                    m.CostoUnitario = LeerDouble(rd, 8)
                    m.Tasa = LeerDouble(rd, 9)
                    m.TieneCabecera = (Convert.ToInt32(rd.GetValue(10)) = 1)
                    m.GuardarOriginal()
                    lista.Add(m)
                End While
            End Using
        End Using
        Return lista
    End Function

    ''' <summary>Filas 'Transferencia Recibida' (Detalle_Compras) del producto.</summary>
    Public Function CargarTransferenciasRecibidas(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal codProducto As String) As List(Of MovimientoCosto)
        Return CargarDetalleCompraPorTipo(cn, tx, codProducto, "Transferencia Recibida")
    End Function

    ''' <summary>Filas 'Devolucion de Compra' (Detalle_Compras) del producto, sin exigir cabecera (igual que el original).</summary>
    Public Function CargarDevolucionesCompra(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal codProducto As String) As List(Of MovimientoCosto)
        Return CargarDetalleCompraPorTipo(cn, tx, codProducto, "Devolucion de Compra")
    End Function

    Private Function CargarDetalleCompraPorTipo(ByVal cn As SqlConnection, ByVal tx As SqlTransaction,
                                                ByVal codProducto As String, ByVal tipo As String) As List(Of MovimientoCosto)
        Dim lista As New List(Of MovimientoCosto)
        Dim sql As String =
            "SELECT id_Detalle_Compra, Numero_Compra, Fecha_Compra, Tipo_Compra, Cantidad, " &
            "       Precio_Unitario, Precio_Neto, Importe, Costo_Unitario " &
            "FROM Detalle_Compras " &
            "WHERE Cod_Producto = @Producto AND Tipo_Compra = @Tipo " &
            "ORDER BY Fecha_Compra, id_Detalle_Compra"
        Using cmd As New SqlCommand(sql, cn, tx)
            AgregarParametros(cmd, codProducto, Nothing)
            cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = tipo
            Using rd As SqlDataReader = cmd.ExecuteReader()
                While rd.Read()
                    Dim m As New MovimientoCosto
                    m.Origen = TipoOrigenMovimiento.Compra
                    m.Id = Convert.ToDecimal(rd.GetValue(0))
                    m.Numero = Convert.ToString(rd.GetValue(1))
                    m.Fecha = Convert.ToDateTime(rd.GetValue(2))
                    m.Tipo = Convert.ToString(rd.GetValue(3))
                    m.CodProducto = codProducto
                    m.Cantidad = LeerDouble(rd, 4)
                    m.PrecioUnitario = LeerDouble(rd, 5)
                    m.PrecioNeto = LeerDouble(rd, 6)
                    m.Importe = LeerDouble(rd, 7)
                    m.CostoUnitario = LeerDouble(rd, 8)
                    m.GuardarOriginal()
                    lista.Add(m)
                End While
            End Using
        End Using
        Return lista
    End Function

    ' ------------------------------------------------------------------
    ' Escritura (siempre dentro de la transaccion recibida)
    ' ------------------------------------------------------------------

    ''' <summary>
    ''' Actualiza por id solo las columnas que cambiaron respecto del original.
    ''' tabla = "Detalle_Facturas" o "Detalle_Compras". Devuelve 1 si hubo cambios, 0 si no.
    ''' </summary>
    Public Function ActualizarCostos(ByVal cn As SqlConnection, ByVal tx As SqlTransaction,
                                     ByVal esFactura As Boolean, ByVal m As MovimientoCosto) As Integer
        Dim sets As New List(Of String)
        Dim cmd As New SqlCommand("", cn, tx)
        cmd.CommandTimeout = 120

        If Distinto(m.CostoUnitario, m.OriginalCostoUnitario) Then
            sets.Add("Costo_Unitario = @Costo")
            cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = ValorOrNull(m.CostoUnitario)
        End If
        If Distinto(m.PrecioUnitario, m.OriginalPrecioUnitario) Then
            sets.Add("Precio_Unitario = @PrecioU")
            cmd.Parameters.Add("@PrecioU", SqlDbType.Float).Value = ValorOrNull(m.PrecioUnitario)
        End If
        If Distinto(m.PrecioNeto, m.OriginalPrecioNeto) Then
            sets.Add("Precio_Neto = @PrecioN")
            cmd.Parameters.Add("@PrecioN", SqlDbType.Float).Value = ValorOrNull(m.PrecioNeto)
        End If
        If Distinto(m.Importe, m.OriginalImporte) Then
            sets.Add("Importe = @Importe")
            cmd.Parameters.Add("@Importe", SqlDbType.Float).Value = ValorOrNull(m.Importe)
        End If

        If sets.Count = 0 Then
            cmd.Dispose()
            Return 0
        End If

        Dim tabla As String = If(esFactura, "Detalle_Facturas", "Detalle_Compras")
        Dim pk As String = If(esFactura, "id_Detalle_Factura", "id_Detalle_Compra")
        cmd.CommandText = "UPDATE " & tabla & " SET " & String.Join(", ", sets.ToArray()) & " WHERE " & pk & " = @Id"
        cmd.Parameters.Add("@Id", SqlDbType.Decimal).Value = m.Id
        Try
            cmd.ExecuteNonQuery()
        Finally
            cmd.Dispose()
        End Try
        Return 1
    End Function

    Public Shared Function Distinto(ByVal a As Double?, ByVal b As Double?) As Boolean
        If a.HasValue <> b.HasValue Then Return True
        If Not a.HasValue Then Return False
        Return a.Value <> b.Value
    End Function

    Private Shared Function ValorOrNull(ByVal v As Double?) As Object
        If v.HasValue Then Return v.Value
        Return DBNull.Value
    End Function

    ' ------------------------------------------------------------------
    ' Utilitarios
    ' ------------------------------------------------------------------

    Private Shared Sub AgregarParametros(ByVal cmd As SqlCommand, ByVal codProducto As String, ByVal fechaCorte As Date?)
        cmd.CommandTimeout = 120
        cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value = codProducto
        If fechaCorte.HasValue Then
            ' El original compara contra la fecha sin hora (CONVERT DATETIME 'yyyy-MM-dd').
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fechaCorte.Value.Date
        End If
    End Sub

    Private Shared Function LeerDouble(ByVal rd As SqlDataReader, ByVal indice As Integer) As Double?
        If rd.IsDBNull(indice) Then
            Return Nothing
        End If
        Return Convert.ToDouble(rd.GetValue(indice))
    End Function

End Class
