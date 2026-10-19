Imports System.Data.SqlClient
Imports System.IO

Public Class CsLogError

    Private Shared ReadOnly connString As String = Conexion
    Private Shared ReadOnly rutaLogRespaldo As String = Path.Combine(Application.StartupPath, "errores_log.txt")

    Public Shared Sub Registrar(ex As Exception, Optional formulario As String = "")

        Try
            Using cn As New SqlConnection(connString)
                Using cmd As New SqlCommand("INSERT INTO LogErrores (Usuario, Maquina, Formulario, Mensaje, StackTrace, TipoExcepcion) " &
                                             "VALUES (@Usuario, @Maquina, @Formulario, @Mensaje, @StackTrace, @TipoExcepcion)", cn)
                    cmd.Parameters.AddWithValue("@Usuario", Environment.UserName)
                    cmd.Parameters.AddWithValue("@Maquina", Environment.MachineName)
                    cmd.Parameters.AddWithValue("@Formulario", If(String.IsNullOrEmpty(formulario), ObtenerFormularioActivo(), formulario))
                    cmd.Parameters.AddWithValue("@Mensaje", ex.Message)
                    cmd.Parameters.AddWithValue("@StackTrace", If(ex.StackTrace, ""))
                    cmd.Parameters.AddWithValue("@TipoExcepcion", ex.GetType().ToString())

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch exLog As Exception
            ' Si falla el log a BD (ej: se cayó la conexión), respaldar en archivo de texto
            RegistrarEnArchivo(ex, exLog)
        End Try

    End Sub

    Private Shared Sub RegistrarEnArchivo(ex As Exception, exLog As Exception)
        Try
            Dim linea As String = $"{Date.Now:yyyy-MM-dd HH:mm:ss} | Usuario: {Environment.UserName} | " &
                                   $"Error: {ex.Message} | StackTrace: {ex.StackTrace} | " &
                                   $"(Fallo log a BD: {exLog.Message})"
            File.AppendAllText(rutaLogRespaldo, linea & Environment.NewLine)
        Catch
            ' Si hasta el archivo falla, ya no hay más remedio que dejarlo pasar
        End Try
    End Sub

    Private Shared Function ObtenerFormularioActivo() As String
        Try
            Return If(Form.ActiveForm IsNot Nothing, Form.ActiveForm.Name, "Desconocido")
        Catch
            Return "Desconocido"
        End Try
    End Function

End Class
