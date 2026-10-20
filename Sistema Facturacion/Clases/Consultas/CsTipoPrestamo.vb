
Imports System.Data
Imports System.Data.SqlClient

Public Class CsTipoPrestamo

    Private ReadOnly _cadenaConexion As String

    Public Sub New()
        _cadenaConexion = Conexion
    End Sub

    '========================================================
    ' CONSULTAR TABLAS
    '========================================================

    Private Function ConsultarTabla(
        ByVal sql As String,
        ByVal ParamArray parametros() As SqlParameter
    ) As DataTable

        Dim tabla As New DataTable()

        Using conexionBD As New SqlConnection(_cadenaConexion)

            Using comando As New SqlCommand(sql, conexionBD)

                If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                    comando.Parameters.AddRange(parametros)
                End If

                Using adaptador As New SqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using

        End Using

        Return tabla

    End Function

    '========================================================
    ' EJECUTAR INSERT, UPDATE Y DELETE
    '========================================================

    Private Function EjecutarComando(
        ByVal sql As String,
        ByVal ParamArray parametros() As SqlParameter
    ) As Integer

        Using conexionBD As New SqlConnection(_cadenaConexion)

            Using comando As New SqlCommand(sql, conexionBD)

                If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                    comando.Parameters.AddRange(parametros)
                End If

                conexionBD.Open()

                Return comando.ExecuteNonQuery()

            End Using

        End Using

    End Function

    '========================================================
    ' OBTENER MODALIDADES
    '========================================================

    Public Function ObtenerModalidades() As DataTable

        Return ConsultarTabla(
            "SELECT * FROM dbo.Modalidades ORDER BY CodModalidad")

    End Function

    '========================================================
    ' OBTENER TIPOS DE PRESTAMO PARA EL COMBO
    '========================================================

    Public Function ObtenerTiposPrestamo() As DataTable

        Return ConsultarTabla(
            "SELECT CodTipoPrestamo, TipoPrestamo " &
            "FROM dbo.TipoPrestamo " &
            "ORDER BY CodTipoPrestamo")

    End Function

    '========================================================
    ' VERIFICAR SI EXISTE UN TIPO DE PRESTAMO
    '========================================================

    Public Function ExisteTipoPrestamo(
        ByVal codigo As String
    ) As Boolean

        Dim sql As String =
            "SELECT COUNT(*) FROM dbo.TipoPrestamo " &
            "WHERE CodTipoPrestamo = @Codigo"

        Using conexionBD As New SqlConnection(_cadenaConexion)

            Using comando As New SqlCommand(sql, conexionBD)

                comando.Parameters.Add(
                    "@Codigo", SqlDbType.VarChar, 50
                ).Value = codigo

                conexionBD.Open()

                Return Convert.ToInt32(comando.ExecuteScalar()) > 0

            End Using

        End Using

    End Function

    '========================================================
    ' OBTENER UN TIPO DE PRESTAMO
    '========================================================

    Public Function ObtenerPorCodigo(
        ByVal codigo As String
    ) As TipoPrestamo

        Dim sql As String =
            "SELECT CodTipoPrestamo, TipoPrestamo, InteresAnual, " &
            "InteresMensual, InteresDiario, InteresMora, " &
            "InteresDeslizamiento, MaxCuotas, CantPrestamos, " &
            "CodModalidad " &
            "FROM dbo.TipoPrestamo " &
            "WHERE CodTipoPrestamo = @Codigo"

        Dim tabla As DataTable = ConsultarTabla(
            sql,
            New SqlParameter("@Codigo", codigo))

        If tabla.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim fila As DataRow = tabla.Rows(0)

        Dim prestamo As New TipoPrestamo With {
            .CodTipoPrestamo = TextoDe(fila("CodTipoPrestamo")),
            .Nombre = TextoDe(fila("TipoPrestamo")),
            .InteresAnual = DecimalDe(fila("InteresAnual")),
            .InteresMensual = DecimalDe(fila("InteresMensual")),
            .InteresDiario = DecimalDe(fila("InteresDiario")),
            .InteresMora = DecimalDe(fila("InteresMora")),
            .InteresDeslizamiento = DecimalDe(fila("InteresDeslizamiento")),
            .MaxCuotas = Convert.ToInt32(DecimalDe(fila("MaxCuotas"))),
            .CantPrestamos = Convert.ToInt32(DecimalDe(fila("CantPrestamos"))),
            .CodModalidad = TextoDe(fila("CodModalidad"))
        }

        Return prestamo

    End Function

    '========================================================
    ' INSERTAR TIPO DE PRESTAMO
    '========================================================

    Public Function Insertar(
        ByVal prestamo As TipoPrestamo
    ) As Integer

        Dim sql As String =
            "INSERT INTO dbo.TipoPrestamo " &
            "(CodTipoPrestamo, TipoPrestamo, InteresAnual, " &
            "InteresMensual, InteresDiario, InteresMora, " &
            "InteresDeslizamiento, MaxCuotas, CantPrestamos, CodModalidad) " &
            "VALUES " &
            "(@Codigo, @Nombre, @InteresAnual, @InteresMensual, " &
            "@InteresDiario, @InteresMora, @InteresDeslizamiento, " &
            "@MaxCuotas, @CantPrestamos, @CodModalidad)"

        Return EjecutarComando(sql, CrearParametros(prestamo))

    End Function

    '========================================================
    ' ACTUALIZAR TIPO DE PRESTAMO
    '========================================================

    Public Function Actualizar(
        ByVal prestamo As TipoPrestamo
    ) As Integer

        Dim sql As String =
            "UPDATE dbo.TipoPrestamo SET " &
            "TipoPrestamo = @Nombre, " &
            "InteresAnual = @InteresAnual, " &
            "InteresMensual = @InteresMensual, " &
            "InteresDiario = @InteresDiario, " &
            "InteresMora = @InteresMora, " &
            "InteresDeslizamiento = @InteresDeslizamiento, " &
            "MaxCuotas = @MaxCuotas, " &
            "CantPrestamos = @CantPrestamos, " &
            "CodModalidad = @CodModalidad " &
            "WHERE CodTipoPrestamo = @Codigo"

        Return EjecutarComando(sql, CrearParametros(prestamo))

    End Function

    '========================================================
    ' ELIMINAR TIPO DE PRESTAMO
    '========================================================

    Public Function Eliminar(
        ByVal codigo As String
    ) As Integer

        Dim sql As String =
            "DELETE FROM dbo.TipoPrestamo " &
            "WHERE CodTipoPrestamo = @Codigo"

        Return EjecutarComando(
            sql,
            New SqlParameter("@Codigo", codigo))

    End Function

    '========================================================
    ' CONSTRUIR PARAMETROS SQL
    '========================================================
    Private Function CrearParametros(
    ByVal prestamo As TipoPrestamo
) As SqlParameter()

        Return New SqlParameter() {
        New SqlParameter("@Codigo", SqlDbType.NVarChar, 10) With {
            .Value = prestamo.CodTipoPrestamo
        },
        New SqlParameter("@Nombre", SqlDbType.NVarChar, 50) With {
            .Value = If(prestamo.Nombre Is Nothing,
                        CType(DBNull.Value, Object),
                        prestamo.Nombre)
        },
        New SqlParameter("@InteresAnual", SqlDbType.Float) With {
            .Value = prestamo.InteresAnual
        },
        New SqlParameter("@InteresMensual", SqlDbType.Float) With {
            .Value = prestamo.InteresMensual
        },
        New SqlParameter("@InteresDiario", SqlDbType.Float) With {
            .Value = prestamo.InteresDiario
        },
        New SqlParameter("@InteresMora", SqlDbType.Float) With {
            .Value = prestamo.InteresMora
        },
        New SqlParameter("@InteresDeslizamiento", SqlDbType.Float) With {
            .Value = prestamo.InteresDeslizamiento
        },
        New SqlParameter("@MaxCuotas", SqlDbType.Real) With {
            .Value = Convert.ToSingle(prestamo.MaxCuotas)
        },
        New SqlParameter("@CantPrestamos", SqlDbType.Float) With {
            .Value = prestamo.CantPrestamos
        },
        New SqlParameter("@CodModalidad", SqlDbType.NVarChar, 50) With {
            .Value = If(prestamo.CodModalidad Is Nothing,
                        CType(DBNull.Value, Object),
                        prestamo.CodModalidad)
        }
    }

    End Function


    '========================================================
    ' CONVERSIONES
    '========================================================

    Private Function TextoDe(ByVal valor As Object) As String

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return ""
        End If

        Return Convert.ToString(valor)

    End Function

    Private Function DecimalDe(ByVal valor As Object) As Decimal

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0D
        End If

        Return Convert.ToDecimal(valor)

    End Function

End Class
