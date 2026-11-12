Option Strict On
Option Explicit On

''' <summary>
''' Filtros que acepta MotorUnidades. Todos son opcionales: cadena vacia = sin filtro en ese criterio.
''' Se pueden combinar (por ejemplo Bodega + rango de productos). Equivalen a los combos del formulario de
''' reportes (Codigo Producto, Linea, Bodega, Rubro; desde / hasta).
''' </summary>
Public Class FiltroUnidades

    Public Property ProductoDesde As String = ""
    Public Property ProductoHasta As String = ""

    Public Property LineaDesde As String = ""
    Public Property LineaHasta As String = ""

    Public Property BodegaDesde As String = ""
    Public Property BodegaHasta As String = ""

    Public Property RubroDesde As String = ""
    Public Property RubroHasta As String = ""

    ''' <summary>
    ''' True = una fila por producto Y bodega (reportes agrupados por bodega).
    ''' False = una fila por producto con todas las bodegas sumadas (o solo las del rango de bodegas, si se indica).
    ''' </summary>
    Public Property AgruparPorBodega As Boolean = False

    Friend Shared Function Texto(ByVal valor As String) As String
        If valor Is Nothing Then Return ""
        Return valor.Trim()
    End Function

End Class
