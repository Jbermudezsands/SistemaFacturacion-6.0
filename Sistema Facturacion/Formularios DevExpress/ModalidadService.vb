Option Strict On
Option Explicit On

Public Class ModalidadService
    Private ReadOnly _repository As ModalidadRepository

    Public Sub New(ByVal connectionString As String)
        _repository = New ModalidadRepository(connectionString)
    End Sub

    Public Function Listar() As List(Of Modalidad)
        Return _repository.ObtenerTodas()
    End Function

    Public Sub Guardar(ByVal codigo As String, ByVal nombre As String)
        codigo = If(codigo, String.Empty).Trim()
        nombre = If(nombre, String.Empty).Trim()
        If codigo.Length = 0 Then Throw New ArgumentException("Ingrese el código de la modalidad.")
        If nombre.Length = 0 Then Throw New ArgumentException("Ingrese el nombre de la modalidad.")

        Dim entidad As New Modalidad With {.CodModalidad = codigo, .Nombre = nombre}
        If _repository.Existe(codigo) Then
            _repository.Actualizar(entidad)
        Else
            _repository.Insertar(entidad)
        End If
    End Sub

    Public Sub Eliminar(ByVal codigo As String)
        If String.IsNullOrWhiteSpace(codigo) Then Throw New ArgumentException("Seleccione una modalidad para eliminar.")
        _repository.Eliminar(codigo.Trim())
    End Sub
End Class
