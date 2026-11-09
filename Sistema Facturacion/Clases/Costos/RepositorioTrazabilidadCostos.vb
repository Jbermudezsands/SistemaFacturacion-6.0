Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

''' <summary>Filtros de la consulta de trazabilidad. Un campo vacio / Nothing no filtra.</summary>
Public Class FiltroTrazabilidadCostos
    Public Property Producto As String
    Public Property Documento As String
    Public Property Origen As String
    Public Property Usuario As String
    Public Property Desde As Date?
    Public Property Hasta As Date?
    Public Property Lote As Guid?
    Public Property Maximo As Integer = 5000
End Class

''' <summary>Consulta (solo lectura) de AjusteCostosLog. Todas las consultas son parametrizadas.</summary>
Public Class RepositorioTrazabilidadCostos

    Private ReadOnly _cadena As String

    Public Sub New(ByVal cadenaConexion As String)
        If String.IsNullOrEmpty(cadenaConexion) Then
            Throw New ArgumentException("La cadena de conexion es obligatoria.")
        End If
        _cadena = cadenaConexion
    End Sub

    ''' <summary>Devuelve las filas mas recientes primero. Lanza SqlException 208 si la tabla no existe.</summary>
    Public Function Buscar(ByVal f As FiltroTrazabilidadCostos) As DataTable
        Dim sql As New System.Text.StringBuilder
        sql.Append("SELECT TOP (@Maximo) IdLog, FechaHora, Usuario, Equipo, Origen, Referencia, Tabla, IdDetalle, ")
        sql.Append("Tipo_Documento, Numero_Documento, Fecha_Documento, Cod_Producto, Cantidad, ")
        sql.Append("Costo_Anterior, Costo_Nuevo, (Costo_Nuevo - Costo_Anterior) AS Dif_Costo, ")
        sql.Append("PrecioUnitario_Anterior, PrecioUnitario_Nuevo, PrecioNeto_Anterior, PrecioNeto_Nuevo, ")
        sql.Append("Importe_Anterior, Importe_Nuevo, Observaciones, Lote ")
        sql.Append("FROM AjusteCostosLog WHERE 1 = 1 ")

        Using cn As New SqlConnection(_cadena)
            Using cmd As New SqlCommand("", cn)
                cmd.CommandTimeout = 120
                cmd.Parameters.Add("@Maximo", SqlDbType.Int).Value = If(f.Maximo > 0, f.Maximo, 5000)

                If Not String.IsNullOrEmpty(f.Producto) Then
                    sql.Append("AND Cod_Producto LIKE @Producto ")
                    cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 60).Value = f.Producto.Trim() & "%"
                End If
                If Not String.IsNullOrEmpty(f.Documento) Then
                    sql.Append("AND Numero_Documento LIKE @Documento ")
                    cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 60).Value = f.Documento.Trim() & "%"
                End If
                If Not String.IsNullOrEmpty(f.Origen) Then
                    sql.Append("AND Origen LIKE @Origen ")
                    cmd.Parameters.Add("@Origen", SqlDbType.NVarChar, 110).Value = "%" & f.Origen.Trim() & "%"
                End If
                If Not String.IsNullOrEmpty(f.Usuario) Then
                    sql.Append("AND Usuario LIKE @Usuario ")
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 110).Value = "%" & f.Usuario.Trim() & "%"
                End If
                If f.Desde.HasValue Then
                    sql.Append("AND FechaHora >= @Desde ")
                    cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = f.Desde.Value.Date
                End If
                If f.Hasta.HasValue Then
                    sql.Append("AND FechaHora < @Hasta ")
                    cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = f.Hasta.Value.Date.AddDays(1)
                End If
                If f.Lote.HasValue Then
                    sql.Append("AND Lote = @Lote ")
                    cmd.Parameters.Add("@Lote", SqlDbType.UniqueIdentifier).Value = f.Lote.Value
                End If
                sql.Append("ORDER BY FechaHora DESC, IdLog DESC")
                cmd.CommandText = sql.ToString()

                Dim tabla As New DataTable("AjusteCostosLog")
                cn.Open()
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    tabla.Load(rd)
                End Using
                Return tabla
            End Using
        End Using
    End Function

End Class
