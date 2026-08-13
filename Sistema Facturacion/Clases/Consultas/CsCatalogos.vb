Imports System.Data.SqlClient

Public Class CsCatalogos

    Public Function ObtenerDepartamentos() As DataTable

        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
        SELECT Cod_Departamento, Nombre_Departamento
        FROM Departamentos
        ORDER BY Nombre_Departamento"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt

    End Function

    Public Function ObtenerMunicipios(codDepartamento As String) As DataTable

        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
        SELECT IdMunicipio, Nombre_Municipio
        FROM Municipio
        WHERE Cod_Departamento = @Cod
        ORDER BY Nombre_Municipio"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Cod", codDepartamento)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt

    End Function

    Public Function ObtenerEndoso() As DataTable

        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
        SELECT Nombre
        FROM Endoso
        ORDER BY Nombre"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt

    End Function

    Public Function ObtenerEscolaridad() As DataTable
        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
                 SELECT Cod_Escolaridad, Nombre_Escolaridad FROM Escolaridad"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Public Function ObtenerCooperativa() As DataTable
        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
                 SELECT Cod_Cooperativa, Nombre_Cooperativa FROM Cooperativa"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Public Function ObtnerRuta() As DataTable
        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
                 SELECT CodRuta, Nombre_Ruta FROM Ruta_Distribucion"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    Public Function ObtenerTipoNomina() As DataTable
        Dim dt As New DataTable()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
                 SELECT * FROM TipoNomina"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

End Class
