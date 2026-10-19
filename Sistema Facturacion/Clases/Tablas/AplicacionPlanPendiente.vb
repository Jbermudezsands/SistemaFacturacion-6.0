Public Class AplicacionPlanPendiente

    Public Property IdDetallePago As Integer

    Public Property NumeroCuota As Integer

    Public Property NumeroFactura As String

    Public Property FechaFactura As Date

    Public Property TipoFactura As String

    Public Property MontoAplicado As Decimal

    Public Property NombrePago As String

    Public Property NumeroTarjeta As String

    Public Property FechaVence As Date

    '==========================================================
    ' DATOS DEL CLIENTE / PRODUCTOR
    '==========================================================

    Public Property CodigoCliente As String

    Public Property NombreCliente As String

    Public Property ApellidosCliente As String

    Public Property Moneda As String

End Class