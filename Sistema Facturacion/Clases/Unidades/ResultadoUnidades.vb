Option Strict On
Option Explicit On

''' <summary>
''' Existencia fisica (unidades) de un producto en un periodo: Inicial + Entrada - Salida = Saldo.
''' CodBodega solo se llena cuando el calculo se pidio agrupado por bodega.
''' </summary>
Public Class ResultadoUnidades

    Public Property CodProducto As String = ""
    Public Property CodBodega As String = ""
    Public Property CodLinea As String = ""

    Public Property Inicial As Double
    Public Property Entrada As Double
    Public Property Salida As Double

    Public ReadOnly Property Saldo As Double
        Get
            Return Inicial + Entrada - Salida
        End Get
    End Property

    ''' <summary>True si el producto tiene algo que mostrar en el periodo.</summary>
    Public ReadOnly Property TieneActividad As Boolean
        Get
            Return Inicial <> 0 OrElse Entrada <> 0 OrElse Salida <> 0
        End Get
    End Property

    Public Shared Function Clave(ByVal codProducto As String, ByVal codBodega As String) As String
        Return (If(codProducto, "")).Trim() & "|" & (If(codBodega, "")).Trim()
    End Function

End Class
