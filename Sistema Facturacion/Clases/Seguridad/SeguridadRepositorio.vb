Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

'=====================================================================================================
'  SEGURIDAD - ACCESO A DATOS
'  Tablas: Perfil (IdPerfil, NombrePerfil), Accesos (IdPerfil, Modulo, Acceso) y Usuarios (Nivel = NombrePerfil).
'=====================================================================================================
Public Class SeguridadRepositorio

    Private ReadOnly _conexion As String

    Public Sub New(conexion As String)
        If String.IsNullOrEmpty(conexion) Then Throw New ArgumentException("Falta la cadena de conexión.")
        _conexion = conexion
    End Sub

    Public Function ListarPerfiles() As List(Of PerfilSeguridad)
        Dim perfiles As New List(Of PerfilSeguridad)()
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT IdPerfil, NombrePerfil FROM Perfil ORDER BY NombrePerfil", cn)
                cn.Open()
                Using lector As SqlDataReader = cmd.ExecuteReader()
                    While lector.Read()
                        perfiles.Add(New PerfilSeguridad(Convert.ToInt64(lector("IdPerfil")), Convert.ToString(lector("NombrePerfil"))))
                    End While
                End Using
            End Using
        End Using
        Return perfiles
    End Function

    ''' <summary>Cadena Acceso del perfil (por nombre) en el modulo, o Nothing si no hay registro.</summary>
    Public Function ObtenerAcceso(nombrePerfil As String, modulo As String) As String
        Const sql As String =
            "SELECT TOP 1 a.Acceso FROM Accesos a INNER JOIN Perfil p ON a.IdPerfil = p.IdPerfil " &
            "WHERE p.NombrePerfil = @perfil AND a.Modulo = @modulo"

        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@perfil", SqlDbType.NVarChar, 100).Value = nombrePerfil
                cmd.Parameters.Add("@modulo", SqlDbType.NVarChar, 100).Value = modulo
                cn.Open()
                Dim valor As Object = cmd.ExecuteScalar()
                If valor Is Nothing OrElse IsDBNull(valor) Then Return Nothing
                Return Convert.ToString(valor)
            End Using
        End Using
    End Function

    Public Sub GuardarAcceso(idPerfil As Long, modulo As String, acceso As String)
        Const sql As String =
            "UPDATE Accesos SET Acceso = @acceso WHERE IdPerfil = @id AND Modulo = @modulo; " &
            "IF @@ROWCOUNT = 0 INSERT INTO Accesos (IdPerfil, Modulo, Acceso) VALUES (@id, @modulo, @acceso);"

        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@id", SqlDbType.Decimal).Value = CDec(idPerfil)
                cmd.Parameters.Add("@modulo", SqlDbType.NVarChar, 100).Value = modulo
                cmd.Parameters.Add("@acceso", SqlDbType.NVarChar, 500).Value = acceso
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>Crea el perfil si no existe. Devuelve False si ya existía.</summary>
    Public Function CrearPerfil(nombre As String) As Boolean
        Const sql As String =
            "IF NOT EXISTS (SELECT 1 FROM Perfil WHERE NombrePerfil = @nombre) " &
            "INSERT INTO Perfil (NombrePerfil) VALUES (@nombre)"

        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre
                cn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function ContarUsuarios(nombrePerfil As String) As Integer
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Nivel = @nombre", cn)
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombrePerfil
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ''' <summary>Elimina el perfil, sus accesos y los usuarios que lo tienen como Nivel (todo o nada).</summary>
    Public Sub EliminarPerfil(perfil As PerfilSeguridad)
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction()
                EjecutarEliminacion(cn, tx, "DELETE FROM Accesos WHERE IdPerfil = @id", perfil)
                EjecutarEliminacion(cn, tx, "DELETE FROM Usuarios WHERE Nivel = @nombre", perfil)
                EjecutarEliminacion(cn, tx, "DELETE FROM Perfil WHERE IdPerfil = @id", perfil)
                tx.Commit()
            End Using
        End Using
    End Sub

    Private Shared Sub EjecutarEliminacion(cn As SqlConnection, tx As SqlTransaction, sql As String, perfil As PerfilSeguridad)
        Using cmd As New SqlCommand(sql, cn, tx)
            If sql.Contains("@id") Then cmd.Parameters.Add("@id", SqlDbType.Decimal).Value = CDec(perfil.Id)
            If sql.Contains("@nombre") Then cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = perfil.Nombre
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
