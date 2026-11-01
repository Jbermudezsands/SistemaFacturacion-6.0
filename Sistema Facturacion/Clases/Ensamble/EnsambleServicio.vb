Option Strict On
Option Explicit On
Option Infer On

Imports System.Data

'=====================================================================================================
'  ENSAMBLE - SERVICIO
'  Validaciones y casos de uso de guardar, eliminar y consultar ensambles.
'  El procesamiento contable (salida de bodega / compra) está en EnsambleProcesoServicio.
'=====================================================================================================
Public Class EnsambleServicio

    Private ReadOnly _repositorio As EnsambleRepositorio

    Public Sub New(ByVal conexion As String)
        _repositorio = New EnsambleRepositorio(conexion)
    End Sub

#Region "Consultas"

    Public Function ObtenerBodegas() As DataTable
        Return _repositorio.ObtenerBodegas()
    End Function

    Public Function ObtenerProducto(ByVal codigo As String) As DataRow
        If String.IsNullOrEmpty(codigo) Then Return Nothing
        Return _repositorio.ObtenerProducto(codigo)
    End Function

    ''' <summary>Componentes de la receta por unidad, listos para el grid.</summary>
    Public Function ObtenerComponentes(ByVal codComponente As Double) As DataTable
        Return ComponentesGrid.Normalizar(_repositorio.ObtenerComponentes(codComponente))
    End Function

    ''' <summary>Componentes de la receta escalados por la cantidad, listos para el grid.</summary>
    Public Function ObtenerComponentes(ByVal codComponente As Double, ByVal cantidad As Double) As DataTable
        Return ComponentesGrid.Normalizar(_repositorio.ObtenerComponentes(codComponente, cantidad))
    End Function

    ''' <summary>Detalle guardado de un ensamble, listo para el grid.</summary>
    Public Function ObtenerDetalle(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String) As DataTable
        Return ComponentesGrid.Normalizar(_repositorio.ObtenerDetalle(numero, fecha, tipo))
    End Function

#End Region

#Region "Casos de uso"

    ''' <summary>
    ''' Valida y guarda el ensamble (encabezado y detalle). Si no tiene número le asigna el siguiente
    ''' consecutivo de su tipo. Devuelve el número del documento.
    ''' </summary>
    Public Function Guardar(ByVal enc As EnsambleEncabezado) As Double
        Validar(enc)

        If enc.Numero = 0 Then
            enc.Numero = BuscaConsecutivo(TiposEnsamble.CampoConsecutivo(enc.Tipo))
        End If

        _repositorio.Guardar(enc)
        Return enc.Numero
    End Function

    ''' <summary>Elimina el ensamble y su detalle y deja constancia en la bitácora.</summary>
    Public Sub Eliminar(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String)
        If numero = 0 Then
            Throw New EnsambleNegocioException("El documento todavía no se ha guardado.")
        End If
        If Not TiposEnsamble.EsValido(tipo) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar el tipo de ensamble.")
        End If

        If _repositorio.Eliminar(numero, fecha, tipo) Then
            Bitacora(Now, NombreUsuario, "Ensamble", "Borro el ensamble: " & numero.ToString())
        End If
    End Sub

    ''' <summary>Marca el ensamble como inactivo (ya procesado o convertido).</summary>
    Public Sub Inactivar(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String)
        If numero = 0 Then
            Throw New EnsambleNegocioException("El documento todavía no se ha guardado.")
        End If
        _repositorio.Inactivar(numero, fecha, tipo)
    End Sub

    Private Shared Sub Validar(ByVal enc As EnsambleEncabezado)
        If Not TiposEnsamble.EsValido(enc.Tipo) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar el tipo de ensamble.")
        End If
        If String.IsNullOrEmpty(enc.CodProducto) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar un producto.")
        End If
        If enc.Cantidad <= 0 Then
            Throw New EnsambleNegocioException("Es necesario digitar una cantidad mayor que cero.")
        End If
        If String.IsNullOrEmpty(enc.BodegaOrigen) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar la bodega de origen.")
        End If
        If String.IsNullOrEmpty(enc.BodegaDestino) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar la bodega de destino.")
        End If
    End Sub

#End Region

End Class
