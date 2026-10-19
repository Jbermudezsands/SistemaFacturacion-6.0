Public Class PlanillaPlanPagoItem

    Public Property MontoCobrado As Decimal
    Public Property NumPlanilla As String

    Public Property FechaInicial As DateTime
    Public Property FechaFinal As DateTime

    Public Property CodProductor As String
    Public Property TipoProductor As String

    Public Property NumeroCredito As Integer
    Public Property NumeroFactura As String
    Public Property FechaFactura As DateTime

    Public Property idDetallePago As Integer
    Public Property NumeroCuota As Integer
    Public Property FechaVencimiento As DateTime

    Public Property MontoCuota As Decimal
    Public Property MontoAbonadoAnterior As Decimal
    Public Property SaldoAntesPlanilla As Decimal

    Public Property TotalIngresos As Decimal

    Public Property SaldoAnteriorAcumulado As Decimal
    Public Property MontoPropuesto As Decimal

End Class
