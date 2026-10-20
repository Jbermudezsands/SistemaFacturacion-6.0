
Public Class TipoPrestamoService

    Private ReadOnly _datos As CsTipoPrestamo

    Public Sub New()
        _datos = New CsTipoPrestamo()
    End Sub

    Public Function ObtenerModalidades() As DataTable
        Return _datos.ObtenerModalidades()
    End Function

    Public Function ObtenerTiposPrestamo() As DataTable
        Return _datos.ObtenerTiposPrestamo()
    End Function

    Public Function ObtenerPorCodigo(
        ByVal codigo As String
    ) As TipoPrestamo

        If String.IsNullOrWhiteSpace(codigo) Then
            Return Nothing
        End If

        Return _datos.ObtenerPorCodigo(codigo.Trim())

    End Function

    Public Sub Guardar(ByVal prestamo As TipoPrestamo)

        If prestamo Is Nothing Then
            Throw New ArgumentNullException(NameOf(prestamo))
        End If

        If String.IsNullOrWhiteSpace(prestamo.CodTipoPrestamo) Then
            Throw New ArgumentException(
                "Debe especificar el código del tipo de préstamo.")
        End If

        If String.IsNullOrWhiteSpace(prestamo.Nombre) Then
            Throw New ArgumentException(
                "Debe especificar el nombre del tipo de préstamo.")
        End If

        If String.IsNullOrWhiteSpace(prestamo.CodModalidad) Then
            Throw New ArgumentException(
                "Debe seleccionar una modalidad.")
        End If

        If _datos.ExisteTipoPrestamo(prestamo.CodTipoPrestamo) Then

            Dim filas As Integer = _datos.Actualizar(prestamo)

            If filas = 0 Then
                Throw New InvalidOperationException(
                    "No se actualizó el tipo de préstamo.")
            End If

        Else

            _datos.Insertar(prestamo)

        End If

    End Sub

    Public Sub Eliminar(ByVal codigo As String)

        If String.IsNullOrWhiteSpace(codigo) Then
            Throw New ArgumentException(
                "Debe especificar el código del tipo de préstamo.")
        End If

        If Not _datos.ExisteTipoPrestamo(codigo) Then
            Throw New InvalidOperationException(
                "El tipo de préstamo no existe.")
        End If

        _datos.Eliminar(codigo)

    End Sub

End Class

