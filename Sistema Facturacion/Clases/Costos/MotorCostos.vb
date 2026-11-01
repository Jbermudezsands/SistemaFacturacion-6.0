Option Strict On
Option Explicit On

Imports System.Collections.Generic

''' <summary>
''' Fachada del Motor de Costos. Independiente de formularios: recibe parametros y devuelve resultados.
'''
''' FASE 4a: solo lectura. Expone el calculo de costo promedio en memoria (replica validada contra
''' CostoPromedioKardex con ComparadorCostos). Todavia NO esta conectado a ningun formulario ni reporte
''' y NO reemplaza ninguna funcion existente.
'''
''' Pendiente (fases siguientes): RepararDocumento, RecalcularProducto, RecalcularRango, ReconstruirDesde,
''' costo para transferencias y costo por bodega.
''' </summary>
Public Class MotorCostos

    Private ReadOnly _repositorio As RepositorioMovimientos
    Private ReadOnly _calculador As New CalculadorCostoPromedio

    Public Sub New(ByVal cadenaConexion As String)
        _repositorio = New RepositorioMovimientos(cadenaConexion)
    End Sub

    ''' <summary>Costo general del producto a una fecha. Equivale a CostoPromedioKardex(codigo, fecha).</summary>
    Public Function CostoGeneral(ByVal codProducto As String, ByVal fecha As Date) As ResultadoCosteo
        Dim movs As List(Of MovimientoCosto) = _repositorio.CargarMovimientos(codProducto, fecha)
        Dim cands As List(Of UltimoCostoCandidato) = _repositorio.CargarCandidatosUltimoCosto(codProducto, fecha)
        Return _calculador.CostoAFecha(codProducto, fecha, movs, cands)
    End Function

    ''' <summary>
    ''' Costo general del producto en varias fechas con una sola lectura de la BD (para reportes y recosteo).
    ''' La clave del diccionario es fecha.Date.
    ''' </summary>
    Public Function CostoGeneralPorFechas(ByVal codProducto As String, ByVal fechas As IEnumerable(Of Date)) As Dictionary(Of Date, ResultadoCosteo)
        Dim movs As List(Of MovimientoCosto) = _repositorio.CargarMovimientos(codProducto, Nothing)
        Dim cands As List(Of UltimoCostoCandidato) = _repositorio.CargarCandidatosUltimoCosto(codProducto, Nothing)
        Return _calculador.CostosPorFechas(codProducto, fechas, movs, cands)
    End Function

End Class
