Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

'=====================================================================================================
'  SALIDAS DE BÁSCULA (facturación) - lógica separada del formulario FrmFacturacionBascula
'
'     Modelo        : SalidaBasculaFila / SalidaBasculaLinea
'     Repositorio   : SalidaBasculaRepositorio (SQL parametrizado, una conexión por operación)
'     Servicio      : SalidaBasculaServicio (ticket y facturación)
'
'  Mejoras respecto a la versión anterior:
'   - Consultas parametrizadas (no se arma SQL concatenando datos).
'   - Se leen los datos de la fila seleccionada UNA vez (antes se volvía a leer la fila del grid con un
'     índice que el propio ciclo de agrupación cambiaba, por lo que el ticket podía imprimir el cliente
'     de otra fila).
'   - El ticket agrupa por producto con un diccionario (antes una búsqueda DataTable.Select por línea).
'   - No se factura con número "-----0-----" si el usuario cancela el consecutivo manual.
'=====================================================================================================

Public Class SalidaBasculaFila
    Public Property NumeroRecepcion As String = ""
    Public Property TipoRecepcion As String = ""
    Public Property Fecha As Date
    Public Property CodCliente As String = ""
    Public Property Nombres As String = ""
    Public Property Conductor As String = ""
    Public Property Cedula As String = ""
    Public Property Licencia As String = ""
    Public Property Placa As String = ""
    Public Property CodBodega As String = ""
    Public Property SubTotal As Double

    ''' <summary>Crea la fila desde un lector de valores por nombre de columna (grid, DataRow...).</summary>
    Public Shared Function Desde(ByVal leer As Func(Of String, Object)) As SalidaBasculaFila
        Dim f As New SalidaBasculaFila
        f.NumeroRecepcion = Texto(leer("NumeroRecepcion"))
        f.TipoRecepcion = Texto(leer("TipoRecepcion"))
        Dim fecha As Object = leer("Fecha")
        If fecha IsNot Nothing AndAlso Not IsDBNull(fecha) Then f.Fecha = Convert.ToDateTime(fecha, CultureInfo.CurrentCulture)
        f.CodCliente = Texto(leer("Cod_Cliente"))
        f.Nombres = Texto(leer("Nombres"))
        f.Conductor = Texto(leer("Conductor"))
        f.Cedula = Texto(leer("Cedula"))
        f.Licencia = Texto(leer("Licencia"))
        f.Placa = Texto(leer("Placa"))
        f.CodBodega = Texto(leer("Cod_Bodega"))
        Dim sub1 As Object = leer("SubTotal")
        If sub1 IsNot Nothing AndAlso Not IsDBNull(sub1) AndAlso IsNumeric(sub1) Then f.SubTotal = Convert.ToDouble(sub1, CultureInfo.CurrentCulture)
        Return f
    End Function

    Private Shared Function Texto(ByVal o As Object) As String
        If o Is Nothing OrElse IsDBNull(o) Then Return ""
        Return Convert.ToString(o, CultureInfo.CurrentCulture)
    End Function
End Class

Public Class SalidaBasculaLinea
    Public Property CodProducto As String = ""
    Public Property Descripcion As String = ""
    Public Property Precio As Double
    Public Property PesoNetoKg As Double
End Class

Public Class SalidaBasculaRepositorio
    Private ReadOnly _conexion As String

    Public Sub New(ByVal conexion As String)
        _conexion = conexion
    End Sub

    ''' <summary>Salidas de báscula pendientes de facturar (las mismas que mostraba el grid).</summary>
    Public Function ListarPendientes() As DataTable
        Const sql As String =
            "SELECT Recepcion.NumeroRecepcion, Recepcion.TipoRecepcion, Recepcion.Fecha, Clientes.Cod_Cliente, " &
            "Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres, Conductor.Nombre AS Conductor, " &
            "Conductor.Cedula, Conductor.Licencia, Vehiculo.IdVehiculo, Vehiculo.Placa, Recepcion.Cod_Bodega, Recepcion.SubTotal " &
            "FROM Recepcion " &
            "INNER JOIN Clientes ON Recepcion.Cod_Proveedor = Clientes.Cod_Cliente " &
            "INNER JOIN Conductor ON Recepcion.Conductor = Conductor.Codigo " &
            "INNER JOIN Vehiculo ON Recepcion.Id_Vehiculo = Vehiculo.IdVehiculo " &
            "WHERE (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'SalidaBascula') " &
            "AND (Recepcion.Contabilizado = 0) AND (Recepcion.Procesado = 0) " &
            "ORDER BY Recepcion.NumeroRecepcion"
        Dim dt As New DataTable("DetalleRecepcion")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>Pesadas de la salida, sin agrupar (para el ticket).</summary>
    Public Function ListarPesadas(ByVal numero As String, ByVal tipo As String) As DataTable
        Const sql As String =
            "SELECT id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida " &
            "FROM Detalle_Recepcion WHERE (NumeroRecepcion = @Numero) AND (TipoRecepcion = @Tipo) ORDER BY Cod_Productos DESC"
        Dim dt As New DataTable("Recepcion")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                da.SelectCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = tipo
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>Tabla vacía con la estructura del reporte de ticket.</summary>
    Public Function EstructuraTicket() As DataTable
        Const sql As String =
            "SELECT id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida " &
            "FROM Detalle_Recepcion WHERE 1 = 0"
        Dim dt As New DataTable("Reporte")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>Pesadas agrupadas por producto (lo que se factura).</summary>
    Public Function ListarLineasAgrupadas(ByVal numero As String, ByVal tipo As String) As List(Of SalidaBasculaLinea)
        Const sql As String =
            "SELECT Cod_Productos, Descripcion_Producto, SUM(Precio) AS Precio, SUM(PesoNetoKg) AS PesoNetoKg " &
            "FROM Detalle_Recepcion WHERE (NumeroRecepcion = @Numero) AND (TipoRecepcion = @Tipo) " &
            "GROUP BY Cod_Productos, Descripcion_Producto"
        Dim lista As New List(Of SalidaBasculaLinea)
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = tipo
                cn.Open()
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        Dim l As New SalidaBasculaLinea
                        l.CodProducto = Convert.ToString(rd("Cod_Productos"))
                        l.Descripcion = Convert.ToString(rd("Descripcion_Producto"))
                        l.Precio = If(IsDBNull(rd("Precio")), 0.0R, Convert.ToDouble(rd("Precio")))
                        l.PesoNetoKg = If(IsDBNull(rd("PesoNetoKg")), 0.0R, Convert.ToDouble(rd("PesoNetoKg")))
                        lista.Add(l)
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    Public Function DatosEmpresa() As DataRow
        Dim dt As New DataTable("DatosEmpresa")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter("SELECT * FROM DatosEmpresa", cn)
                da.Fill(dt)
            End Using
        End Using
        If dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function

    Public Sub Anular(ByVal numero As String)
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("UPDATE Recepcion SET Cancelar = 1 WHERE (NumeroRecepcion = @Numero) AND (TipoRecepcion = 'SalidaBascula')", cn)
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub MarcarProcesada(ByVal numero As String, ByVal numeroFactura As String, ByVal fechaFactura As Date)
        Const sql As String =
            "UPDATE Recepcion SET Numero_Compra = @Factura, Tipo_Compra = 'Factura', Fecha_Compra = @Fecha, Procesado = 1 " &
            "WHERE (NumeroRecepcion = @Numero) AND (TipoRecepcion = 'SalidaBascula')"
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = numeroFactura
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fechaFactura
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class

Public Class SalidaBasculaServicio
    Private ReadOnly _repo As SalidaBasculaRepositorio

    Public Sub New(ByVal conexion As String)
        _repo = New SalidaBasculaRepositorio(conexion)
    End Sub

    Public ReadOnly Property Repositorio As SalidaBasculaRepositorio
        Get
            Return _repo
        End Get
    End Property

    Public Function ListarPendientes() As DataTable
        Return _repo.ListarPendientes()
    End Function

    Public Sub Anular(ByVal fila As SalidaBasculaFila)
        If fila Is Nothing OrElse fila.NumeroRecepcion = "" Then Throw New ArgumentException("Seleccione una salida.")
        _repo.Anular(fila.NumeroRecepcion)
    End Sub

    ''' <summary>
    ''' Tabla del ticket: una fila por producto con el detalle de pesadas ("1-250Lb , 2-300Lb") y la cantidad total.
    ''' </summary>
    Public Function ConstruirTicket(ByVal fila As SalidaBasculaFila) As DataTable
        Dim reporte As DataTable = _repo.EstructuraTicket()
        Dim pesadas As DataTable = _repo.ListarPesadas(fila.NumeroRecepcion, fila.TipoRecepcion)
        Dim porProducto As New Dictionary(Of String, DataRow)(StringComparer.Ordinal)

        For Each p As DataRow In pesadas.Rows
            Dim codigo As String = Convert.ToString(p("Cod_Productos"))
            Dim detalle As String = Convert.ToString(p("id_Eventos")) & "-" & Convert.ToString(p("Cantidad")) & "Lb"
            Dim destino As DataRow = Nothing

            If Not porProducto.TryGetValue(codigo, destino) Then
                destino = reporte.NewRow()
                For Each col As DataColumn In reporte.Columns
                    If pesadas.Columns.Contains(col.ColumnName) Then destino(col.ColumnName) = p(col.ColumnName)
                Next
                destino("Unidad_Medida") = detalle
                reporte.Rows.Add(destino)
                porProducto(codigo) = destino
            Else
                destino("Unidad_Medida") = Convert.ToString(destino("Unidad_Medida")) & " , " & detalle
                destino("Cantidad") = Convert.ToDouble(destino("Cantidad")) + Convert.ToDouble(p("Cantidad"))
            End If
        Next
        Return reporte
    End Function

    ''' <summary>Datos de la empresa para el encabezado del ticket (puede ser Nothing).</summary>
    Public Function DatosEmpresa() As DataRow
        Return _repo.DatosEmpresa()
    End Function

    ''' <summary>
    ''' ¿Se maneja consecutivo de factura manual? (configuración de la empresa).
    ''' </summary>
    Public Function ConsecutivoFacturaManual() As Boolean
        Dim emp As DataRow = _repo.DatosEmpresa()
        If emp Is Nothing OrElse Not emp.Table.Columns.Contains("ConsecutivoFacturaManual") Then Return False
        If IsDBNull(emp("ConsecutivoFacturaManual")) Then Return False
        Return Convert.ToBoolean(emp("ConsecutivoFacturaManual"))
    End Function

    ''' <summary>
    ''' Genera la factura de la salida. <paramref name="obtenerNumero"/> entrega el número de factura
    ''' (puede pedir el consecutivo manual al usuario) y devuelve "-----0-----" si se canceló.
    ''' Devuelve el número de factura, o "" si el usuario canceló.
    ''' </summary>
    Public Function Facturar(ByVal fila As SalidaBasculaFila, ByVal obtenerNumero As Func(Of String)) As String
        If fila Is Nothing OrElse fila.NumeroRecepcion = "" Then Throw New ArgumentException("Seleccione una salida.")

        Dim numeroFactura As String = obtenerNumero()
        If String.IsNullOrEmpty(numeroFactura) OrElse numeroFactura = "-----0-----" Then Return ""

        Dim fechaFactura As Date = Date.Today
        Dim textoFecha As String = Format(fechaFactura, "dd/MM/yyyy")

        GrabaEncabezadoFacturas(numeroFactura, textoFecha, "Factura", fila.CodCliente, fila.CodBodega, fila.Nombres, fila.Nombres,
                                textoFecha, fila.SubTotal, 0, fila.SubTotal, fila.SubTotal, "Cordobas", "Procesado por Inventario Fisico  ")

        For Each l As SalidaBasculaLinea In _repo.ListarLineasAgrupadas(fila.NumeroRecepcion, fila.TipoRecepcion)
            GrabaDetalleFacturaSalida(numeroFactura, l.CodProducto, l.Descripcion, l.Precio, 0, l.Precio, 0, l.PesoNetoKg,
                                      "Cordobas", fechaFactura, "Factura", l.Precio)
            ActualizaExistencia(l.CodProducto)
        Next

        _repo.MarcarProcesada(fila.NumeroRecepcion, numeroFactura, fechaFactura)
        Return numeroFactura
    End Function
End Class
