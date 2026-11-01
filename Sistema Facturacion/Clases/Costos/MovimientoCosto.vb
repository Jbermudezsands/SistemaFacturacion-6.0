Option Strict On
Option Explicit On

Imports System.Collections.Generic

''' <summary>
''' Origen del movimiento: Detalle_Compras o Detalle_Facturas.
''' </summary>
Public Enum TipoOrigenMovimiento
    Compra = 1
    Factura = 2
End Enum

''' <summary>
''' Movimiento de un producto tal como lo necesita CostoPromedioKardex.
''' Los campos numericos son Nullable porque la BD permite NULL y el SQL original
''' ignora los NULL dentro de SUM(); el calculador replica ese comportamiento.
''' </summary>
Public Class MovimientoCosto
    Public Property Origen As TipoOrigenMovimiento
    Public Property Id As Decimal
    Public Property Numero As String
    Public Property Fecha As Date
    Public Property Tipo As String
    Public Property CodProducto As String
    Public Property Cantidad As Double?
    Public Property PrecioUnitario As Double?
    Public Property PrecioNeto As Double?
    Public Property CostoUnitario As Double?
    ''' <summary>Compras.MonedaCompra (solo compras).</summary>
    Public Property Moneda As String
    ''' <summary>TasaCambio.MontoTasa de la fecha del documento. Nothing = no existe tasa ese dia.</summary>
    Public Property Tasa As Double?
    ''' <summary>Solo Detalle_Facturas: importe de la linea.</summary>
    Public Property Importe As Double?
    ''' <summary>True si existe la cabecera (Facturas / Compras) del documento.</summary>
    Public Property TieneCabecera As Boolean

    ' Valores leidos de la BD, para detectar que filas cambian al reparar.
    Public Property OriginalCostoUnitario As Double?
    Public Property OriginalPrecioUnitario As Double?
    Public Property OriginalPrecioNeto As Double?
    Public Property OriginalImporte As Double?

    Public Sub GuardarOriginal()
        OriginalCostoUnitario = CostoUnitario
        OriginalPrecioUnitario = PrecioUnitario
        OriginalPrecioNeto = PrecioNeto
        OriginalImporte = Importe
    End Sub
End Class

''' <summary>
''' Fila de Detalle_Facturas con Costo_Unitario &lt;&gt; 0 (cualquier tipo). Se usa solo como
''' respaldo "ultimo costo utilizado" cuando el promedio da cero.
''' </summary>
Public Class UltimoCostoCandidato
    Public Property Id As Decimal
    Public Property Fecha As Date
    Public Property CostoUnitario As Double
    Public Property Tasa As Double
End Class
