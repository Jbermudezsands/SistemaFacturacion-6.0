Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

''' <summary>Acceso a datos para la tabla dbo.Modalidades.</summary>
Public Class ModalidadRepository
    Private ReadOnly _connectionString As String

    Public Sub New(ByVal connectionString As String)
        If String.IsNullOrWhiteSpace(connectionString) Then
            Throw New ArgumentException("La cadena de conexión no puede estar vacía.", "connectionString")
        End If
        _connectionString = connectionString
    End Sub

    Public Function ObtenerTodas() As List(Of Modalidad)
        Dim resultado As New List(Of Modalidad)()
        Const sql As String = "SELECT CodModalidad, Modalidad FROM dbo.Modalidades ORDER BY CodModalidad"
        Using cn As New SqlConnection(_connectionString), cmd As New SqlCommand(sql, cn)
            cn.Open()
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    resultado.Add(New Modalidad With {
                        .CodModalidad = Convert.ToString(dr("CodModalidad")),
                        .Nombre = Convert.ToString(dr("Modalidad"))
                    })
                End While
            End Using
        End Using
        Return resultado
    End Function

    Public Function Existe(ByVal codigo As String) As Boolean
        Const sql As String = "SELECT COUNT(1) FROM dbo.Modalidades WHERE CodModalidad = @Codigo"
        Using cn As New SqlConnection(_connectionString), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = codigo
            cn.Open()
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub Insertar(ByVal modalidad As Modalidad)
        Const sql As String = "INSERT INTO dbo.Modalidades (CodModalidad, Modalidad) VALUES (@Codigo, @Nombre)"
        Using cn As New SqlConnection(_connectionString), cmd As New SqlCommand(sql, cn)
            AgregarParametros(cmd, modalidad)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Actualizar(ByVal modalidad As Modalidad)
        Const sql As String = "UPDATE dbo.Modalidades SET Modalidad = @Nombre WHERE CodModalidad = @Codigo"
        Using cn As New SqlConnection(_connectionString), cmd As New SqlCommand(sql, cn)
            AgregarParametros(cmd, modalidad)
            cn.Open()
            If cmd.ExecuteNonQuery() = 0 Then Throw New InvalidOperationException("No se encontró la modalidad que se desea actualizar.")
        End Using
    End Sub

    Public Sub Eliminar(ByVal codigo As String)
        Const sql As String = "DELETE FROM dbo.Modalidades WHERE CodModalidad = @Codigo"
        Using cn As New SqlConnection(_connectionString), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = codigo
            cn.Open()
            If cmd.ExecuteNonQuery() = 0 Then Throw New InvalidOperationException("No se encontró la modalidad que se desea eliminar.")
        End Using
    End Sub

    Private Shared Sub AgregarParametros(ByVal cmd As SqlCommand, ByVal modalidad As Modalidad)
        cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = modalidad.CodModalidad
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 150).Value = modalidad.Nombre
    End Sub
End Class
