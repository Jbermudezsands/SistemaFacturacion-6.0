Option Strict On
Option Explicit On

Imports System.Collections.Generic

Public Enum OrigenCostoCalculado
    ''' <summary>Importe / cantidad acumulados (formula de CostoPromedioKardex).</summary>
    Promedio = 0
    ''' <summary>El promedio dio cero y se uso el ultimo Costo_Unitario conocido.</summary>
    UltimoCosto = 1
    ''' <summary>Sin promedio ni ultimo costo: costo cero.</summary>
    SinCosto = 2
End Enum

''' <summary>
''' Resultado de un calculo de costo. Equivale a RstCostoPromedio mas informacion de diagnostico.
''' </summary>
Public Class ResultadoCosteo
    Public Property CodigoProducto As String
    Public Property Fecha As Date
    Public Property CostoCordoba As Double
    Public Property CostoDolar As Double
    Public Property Origen As OrigenCostoCalculado
    Public Property Cantidad As Double
    Public Property Importe As Double
    Public Property ImporteDolar As Double
    ''' <summary>Movimientos descartados porque no existe TasaCambio ese dia (el SQL original los pierde en silencio).</summary>
    Public Property MovimientosSinTasa As Integer
    Public Property Advertencias As New List(Of String)

    ''' <summary>Convierte al DTO que usan hoy los formularios y reportes.</summary>
    Public Function ARstCostoPromedio() As RstCostoPromedio
        Dim rst As New RstCostoPromedio
        rst.Codigo_Producto = CodigoProducto
        rst.Fecha_Compras = Fecha
        rst.Costo_Cordoba = CostoCordoba
        rst.Costo_Dolar = CostoDolar
        Return rst
    End Function
End Class
