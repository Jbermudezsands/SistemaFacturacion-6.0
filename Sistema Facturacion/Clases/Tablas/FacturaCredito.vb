Public Class FacturaCredito

    Public Property NumeroFactura As String
    Public Property FechaFactura As Date

    'Monto total de la factura
    Public Property MontoFactura As Double

    'Pago realizado al momento de emitir la factura
    Public Property MontoPagoInicial As Double

    'Pagos posteriores mediante recibos
    Public Property MontoPagado As Double

    Public Property MontoNotaDebito As Double
    Public Property MontoNotaCredito As Double

    'Saldo pendiente real
    Public Property Saldo As Double

    Public Property TipoFactura As String
    Public Property MonedaFactura As String
    Public Property FechaVencimiento As Date

    Public Property NumeroRecibo As String
    Public Property NumeroNotaDebito As String
    Public Property NumeroNotaCredito As String

End Class




