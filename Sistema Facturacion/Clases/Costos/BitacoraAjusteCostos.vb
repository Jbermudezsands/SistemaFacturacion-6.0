Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

''' <summary>
''' Quien / desde donde / por que se ajusta un costo. Todas las filas modificadas en una misma ejecucion
''' comparten el mismo Lote.
''' </summary>
Public Class ContextoAjusteCostos
    Public Property Lote As Guid
    ''' <summary>Formulario o proceso, p. ej. "FrmActualiza.CmdCostear". Si no se indica se deduce de la pila de llamadas.</summary>
    Public Property Origen As String
    ''' <summary>Documento que disparo el ajuste (p. ej. "Factura 000123") o el rango de productos.</summary>
    Public Property Referencia As String
    Public Property Usuario As String

    Public Sub New()
        Me.New("", "")
    End Sub

    Public Sub New(ByVal origen As String, ByVal referencia As String)
        Me.Lote = Guid.NewGuid()
        Me.Origen = origen
        Me.Referencia = referencia
        Me.Usuario = NombreUsuario
        If String.IsNullOrEmpty(Me.Origen) Then Me.Origen = DeducirOrigen()
    End Sub

    ''' <summary>Copia con otro origen / referencia pero el mismo lote.</summary>
    Public Function Con(ByVal origen As String, ByVal referencia As String) As ContextoAjusteCostos
        Dim c As New ContextoAjusteCostos(origen, referencia)
        c.Lote = Me.Lote
        Return c
    End Function

    ''' <summary>Primer formulario (Frm*) o clase de auditoria en la pila de llamadas.</summary>
    Private Shared Function DeducirOrigen() As String
        Try
            Dim pila As New StackTrace(False)
            For Each marco As StackFrame In pila.GetFrames()
                Dim metodo As System.Reflection.MethodBase = marco.GetMethod()
                If metodo Is Nothing OrElse metodo.DeclaringType Is Nothing Then Continue For
                Dim tipo As String = metodo.DeclaringType.Name
                If tipo.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) OrElse tipo.StartsWith("Auditoria", StringComparison.OrdinalIgnoreCase) Then
                    Return tipo & "." & metodo.Name
                End If
            Next
        Catch
        End Try
        Return "Desconocido"
    End Function
End Class

''' <summary>
''' Escribe en AjusteCostosLog una fila por linea de Detalle_Facturas / Detalle_Compras modificada, con el valor
''' anterior y el nuevo. Se registra dentro de la MISMA transaccion del ajuste (si el ajuste se revierte, la bitacora
''' tambien). Si la tabla aun no existe (script 5.AjusteCostosLog no aplicado) no se detiene el ajuste.
''' </summary>
Public Class BitacoraAjusteCostos

    Private Const ErrorObjetoInvalido As Integer = 208

    Private Const SqlInsert As String =
        "INSERT INTO AjusteCostosLog (Lote, Usuario, Equipo, Origen, Referencia, Tabla, IdDetalle, Tipo_Documento, " &
        "Numero_Documento, Fecha_Documento, Cod_Producto, Cantidad, Costo_Anterior, Costo_Nuevo, " &
        "PrecioUnitario_Anterior, PrecioUnitario_Nuevo, PrecioNeto_Anterior, PrecioNeto_Nuevo, " &
        "Importe_Anterior, Importe_Nuevo, Observaciones) " &
        "VALUES (@Lote, @Usuario, @Equipo, @Origen, @Referencia, @Tabla, @IdDetalle, @Tipo, " &
        "@Numero, @FechaDoc, @Producto, @Cantidad, @CostoA, @CostoN, @PrecioUA, @PrecioUN, @PrecioNA, @PrecioNN, " &
        "@ImporteA, @ImporteN, @Obs)"

    ''' <summary>Registra una linea ajustada por el motor (valores tomados de MovimientoCosto: Original* = antes).</summary>
    Public Shared Sub Registrar(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal ctx As ContextoAjusteCostos,
                                ByVal esFactura As Boolean, ByVal m As MovimientoCosto)
        Dim d As New DatosAjuste
        d.Tabla = If(esFactura, "Detalle_Facturas", "Detalle_Compras")
        d.IdDetalle = m.Id
        d.Tipo = m.Tipo
        d.Numero = m.Numero
        d.Fecha = m.Fecha
        d.Producto = m.CodProducto
        d.Cantidad = m.Cantidad
        d.CostoAnterior = m.OriginalCostoUnitario
        d.CostoNuevo = m.CostoUnitario
        d.PrecioUAnterior = m.OriginalPrecioUnitario
        d.PrecioUNuevo = m.PrecioUnitario
        d.PrecioNAnterior = m.OriginalPrecioNeto
        d.PrecioNNuevo = m.PrecioNeto
        d.ImporteAnterior = m.OriginalImporte
        d.ImporteNuevo = m.Importe
        Insertar(cn, tx, ctx, d)
    End Sub

    ''' <summary>
    ''' Registra un ajuste hecho con un UPDATE directo (reparaciones de la auditoria). Abre su propia conexion:
    ''' un fallo al registrar nunca debe invalidar el ajuste que ya se guardo, por eso no lanza excepciones.
    ''' </summary>
    Public Shared Sub RegistrarDirecto(ByVal cadenaConexion As String, ByVal ctx As ContextoAjusteCostos, ByVal d As DatosAjuste)
        Try
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                Insertar(cn, Nothing, ctx, d)
            End Using
        Catch
        End Try
    End Sub

    Private Shared Sub Insertar(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal ctx As ContextoAjusteCostos, ByVal d As DatosAjuste)
        Dim c As ContextoAjusteCostos = If(ctx, New ContextoAjusteCostos())
        Using cmd As New SqlCommand(SqlInsert, cn, tx)
            cmd.Parameters.Add("@Lote", SqlDbType.UniqueIdentifier).Value = c.Lote
            cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100).Value = Texto(c.Usuario, 100)
            cmd.Parameters.Add("@Equipo", SqlDbType.NVarChar, 100).Value = Texto(Environment.MachineName, 100)
            cmd.Parameters.Add("@Origen", SqlDbType.NVarChar, 100).Value = Texto(c.Origen, 100)
            cmd.Parameters.Add("@Referencia", SqlDbType.NVarChar, 200).Value = Texto(c.Referencia, 200)
            cmd.Parameters.Add("@Tabla", SqlDbType.NVarChar, 30).Value = d.Tabla
            cmd.Parameters.Add("@IdDetalle", SqlDbType.Decimal).Value = d.IdDetalle
            cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = Texto(d.Tipo, 50)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = Texto(d.Numero, 50)
            cmd.Parameters.Add("@FechaDoc", SqlDbType.DateTime).Value = d.Fecha
            cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value = Texto(d.Producto, 50)
            cmd.Parameters.Add("@Cantidad", SqlDbType.Float).Value = Valor(d.Cantidad)
            cmd.Parameters.Add("@CostoA", SqlDbType.Float).Value = Valor(d.CostoAnterior)
            cmd.Parameters.Add("@CostoN", SqlDbType.Float).Value = Valor(d.CostoNuevo)
            cmd.Parameters.Add("@PrecioUA", SqlDbType.Float).Value = Valor(d.PrecioUAnterior)
            cmd.Parameters.Add("@PrecioUN", SqlDbType.Float).Value = Valor(d.PrecioUNuevo)
            cmd.Parameters.Add("@PrecioNA", SqlDbType.Float).Value = Valor(d.PrecioNAnterior)
            cmd.Parameters.Add("@PrecioNN", SqlDbType.Float).Value = Valor(d.PrecioNNuevo)
            cmd.Parameters.Add("@ImporteA", SqlDbType.Float).Value = Valor(d.ImporteAnterior)
            cmd.Parameters.Add("@ImporteN", SqlDbType.Float).Value = Valor(d.ImporteNuevo)
            cmd.Parameters.Add("@Obs", SqlDbType.NVarChar, 500).Value = Texto(d.Observaciones, 500)
            Try
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                ' Tabla inexistente (script no aplicado): el ajuste continua sin bitacora.
                If ex.Number <> ErrorObjetoInvalido Then Throw
            End Try
        End Using
    End Sub

    Private Shared Function Valor(ByVal v As Double?) As Object
        If v.HasValue Then Return v.Value
        Return DBNull.Value
    End Function

    Private Shared Function Texto(ByVal s As String, ByVal max As Integer) As Object
        If s Is Nothing Then Return DBNull.Value
        s = s.TrimEnd()
        If s.Length > max Then s = s.Substring(0, max)
        Return s
    End Function
End Class

''' <summary>Datos de una linea ajustada (antes / despues).</summary>
Public Class DatosAjuste
    Public Property Tabla As String
    Public Property IdDetalle As Decimal
    Public Property Tipo As String
    Public Property Numero As String
    Public Property Fecha As Date
    Public Property Producto As String
    Public Property Cantidad As Double?
    Public Property CostoAnterior As Double?
    Public Property CostoNuevo As Double?
    Public Property PrecioUAnterior As Double?
    Public Property PrecioUNuevo As Double?
    Public Property PrecioNAnterior As Double?
    Public Property PrecioNNuevo As Double?
    Public Property ImporteAnterior As Double?
    Public Property ImporteNuevo As Double?
    Public Property Observaciones As String
End Class
