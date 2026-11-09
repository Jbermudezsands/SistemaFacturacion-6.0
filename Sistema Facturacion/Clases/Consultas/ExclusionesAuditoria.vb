Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
''' Hallazgos que el usuario marco como Revisado / Autoauditado / Declarado al fisco (tabla AuditoriaHallazgosExcluidos).
''' El Auditor los descarta al final de cada ejecucion, por lo que no vuelven a aparecer como hallazgo.
''' </summary>
Public Class ExclusionesAuditoria

    Public Const ClasificacionRevisado As String = "Revisado"
    Public Const ClasificacionAutoauditado As String = "Autoauditado"
    Public Const ClasificacionDeclarado As String = "Declarado al fisco"

    Private Const ErrorObjetoInvalido As Integer = 208
    Private Const ErrorLlaveDuplicada1 As Integer = 2601
    Private Const ErrorLlaveDuplicada2 As Integer = 2627

    ''' <summary>Identidad estable de un hallazgo entre ejecuciones (no incluye fecha, cantidad ni costos, que pueden cambiar).</summary>
    Public Shared Function Clave(ByVal h As Auditoria.HallazgoAuditoria) As String
        Return (Texto(h.Codigo) & "|" & Texto(h.Tipo) & "|" & Texto(h.Documento) & "|" & Texto(h.Producto) & "|" &
                h.IdDetalleFactura.ToString("0") & "|" & h.IdDetalleCompra.ToString("0")).ToUpperInvariant()
    End Function

    Private Shared Function Texto(ByVal s As String) As String
        If s Is Nothing Then Return ""
        Return s.Trim()
    End Function

    ''' <summary>Claves de los hallazgos excluidos y activos. Nothing si la tabla aun no existe (script 6 sin aplicar).</summary>
    Public Shared Function CargarClaves(ByVal cadenaConexion As String) As HashSet(Of String)
        Dim claves As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Try
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                Using cmd As New SqlCommand("SELECT Clave FROM AuditoriaHallazgosExcluidos WHERE Activo = 1", cn)
                    cmd.CommandTimeout = 120
                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            claves.Add(rd.GetString(0))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = ErrorObjetoInvalido Then Return Nothing
            Throw
        End Try
        Return claves
    End Function

    ''' <summary>
    ''' Marca el hallazgo como excluido. Guarda los valores que tenia al momento de marcarlo como evidencia.
    ''' Lanza excepcion con mensaje en español si no se pudo guardar (el hallazgo NO queda marcado).
    ''' </summary>
    Public Shared Sub Marcar(ByVal cadenaConexion As String, ByVal h As Auditoria.HallazgoAuditoria,
                             ByVal clasificacion As String, ByVal motivo As String)
        If String.IsNullOrEmpty(motivo) OrElse motivo.Trim().Length < 5 Then
            Throw New ArgumentException("Debe indicar el motivo (mínimo 5 caracteres).")
        End If

        Const sql As String =
            "INSERT INTO AuditoriaHallazgosExcluidos (Clave, Codigo, Tipo_Documento, Numero_Documento, Fecha_Documento, " &
            "Cod_Producto, IdDetalleFactura, IdDetalleCompra, Cantidad, PrecioUnitario, CostoUnitario, Descripcion, " &
            "Clasificacion, Motivo, Usuario, Equipo) " &
            "VALUES (@Clave, @Codigo, @Tipo, @Numero, @Fecha, @Producto, @IdDF, @IdDC, @Cantidad, @Precio, @Costo, " &
            "@Descripcion, @Clasificacion, @Motivo, @Usuario, @Equipo)"

        Try
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@Clave", SqlDbType.NVarChar, 400).Value = Clave(h)
                    cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = Recortar(h.Codigo, 30)
                    cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = Recortar(h.Tipo, 50)
                    cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = Recortar(h.Documento, 50)
                    If h.Fecha = DateTime.MinValue Then
                        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = h.Fecha
                    End If
                    cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value = Recortar(h.Producto, 50)
                    cmd.Parameters.Add("@IdDF", SqlDbType.Decimal).Value = h.IdDetalleFactura
                    cmd.Parameters.Add("@IdDC", SqlDbType.Decimal).Value = h.IdDetalleCompra
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Float).Value = h.Cantidad
                    cmd.Parameters.Add("@Precio", SqlDbType.Float).Value = h.PrecioUnitario
                    cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = h.CostoUnitario
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = Recortar(h.Descripcion, 500)
                    cmd.Parameters.Add("@Clasificacion", SqlDbType.NVarChar, 30).Value = Recortar(clasificacion, 30)
                    cmd.Parameters.Add("@Motivo", SqlDbType.NVarChar, 500).Value = Recortar(motivo.Trim(), 500)
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100).Value = Recortar(NombreUsuario, 100)
                    cmd.Parameters.Add("@Equipo", SqlDbType.NVarChar, 100).Value = Recortar(Environment.MachineName, 100)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = ErrorObjetoInvalido Then
                Throw New InvalidOperationException("Falta la tabla AuditoriaHallazgosExcluidos. Ejecute el script " &
                    "'Cambios Script\Año 2026\11.Noviembre\6.AuditoriaHallazgosExcluidos - Hallazgos revisados.sql'.")
            End If
            ' Ya estaba marcado: el resultado buscado (que no aparezca) ya se cumple.
            If ex.Number = ErrorLlaveDuplicada1 OrElse ex.Number = ErrorLlaveDuplicada2 Then Return
            Throw
        End Try
    End Sub

    ''' <summary>Hallazgos excluidos, los mas recientes primero. incluirReactivados = True agrega los que ya volvieron a la auditoria.</summary>
    Public Shared Function Listar(ByVal cadenaConexion As String, ByVal incluirReactivados As Boolean) As DataTable
        Dim sql As String =
            "SELECT IdExclusion, FechaMarca, Clasificacion, Codigo, Tipo_Documento, Numero_Documento, Fecha_Documento, " &
            "Cod_Producto, Cantidad, PrecioUnitario, CostoUnitario, Motivo, Usuario, Equipo, Activo, " &
            "FechaReactivacion, UsuarioReactivacion, MotivoReactivacion " &
            "FROM AuditoriaHallazgosExcluidos "
        If Not incluirReactivados Then sql &= "WHERE Activo = 1 "
        sql &= "ORDER BY FechaMarca DESC, IdExclusion DESC"

        Try
            Using cn As New SqlConnection(cadenaConexion)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.CommandTimeout = 120
                    Dim tabla As New DataTable("Excluidos")
                    cn.Open()
                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        tabla.Load(rd)
                    End Using
                    Return tabla
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = ErrorObjetoInvalido Then
                Throw New InvalidOperationException("Falta la tabla AuditoriaHallazgosExcluidos. Ejecute el script " &
                    "'Cambios Script\Año 2026\11.Noviembre\6.AuditoriaHallazgosExcluidos - Hallazgos revisados.sql'.")
            End If
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Regresa el hallazgo a la auditoria (marcado por error). La fila se conserva como evidencia con quien, cuando y por que
    ''' se reactivo. Devuelve False si ya estaba reactivado.
    ''' </summary>
    Public Shared Function Reactivar(ByVal cadenaConexion As String, ByVal idExclusion As Integer, ByVal motivo As String) As Boolean
        If String.IsNullOrEmpty(motivo) OrElse motivo.Trim().Length < 5 Then
            Throw New ArgumentException("Debe indicar el motivo (mínimo 5 caracteres).")
        End If

        Const sql As String =
            "UPDATE AuditoriaHallazgosExcluidos " &
            "SET Activo = 0, UsuarioReactivacion = @Usuario, FechaReactivacion = GETDATE(), MotivoReactivacion = @Motivo " &
            "WHERE IdExclusion = @Id AND Activo = 1"

        Using cn As New SqlConnection(cadenaConexion)
            cn.Open()
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100).Value = Recortar(NombreUsuario, 100)
                cmd.Parameters.Add("@Motivo", SqlDbType.NVarChar, 500).Value = Recortar(motivo, 500)
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = idExclusion
                Return cmd.ExecuteNonQuery() = 1
            End Using
        End Using
    End Function

    Private Shared Function Recortar(ByVal s As String, ByVal max As Integer) As String
        If s Is Nothing Then Return ""
        s = s.Trim()
        If s.Length > max Then s = s.Substring(0, max)
        Return s
    End Function

End Class
