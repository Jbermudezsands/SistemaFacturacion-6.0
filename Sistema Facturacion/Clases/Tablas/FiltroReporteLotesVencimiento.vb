Public Class FiltroReporteLotesVencimiento

    ' Intervalo de fechas de vencimiento (ambas fechas incluidas).
    Public Property FechaDesde As Date
    Public Property FechaHasta As Date

    ' Fecha hasta la cual se calcula la existencia de cada lote.
    Public Property FechaCorte As Date

    Public Property CodigoLineaDesde As String
    Public Property CodigoLineaHasta As String

    Public Property CodigoBodegaDesde As String
    Public Property CodigoBodegaHasta As String

    Public Property FiltrarPorLinea As Boolean
    Public Property FiltrarPorBodega As Boolean

    Public Sub New()

        FechaDesde = Date.Today
        FechaHasta = Date.Today.AddMonths(9)
        FechaCorte = Date.Today

        CodigoLineaDesde = String.Empty
        CodigoLineaHasta = String.Empty

        CodigoBodegaDesde = String.Empty
        CodigoBodegaHasta = String.Empty

        FiltrarPorLinea = False
        FiltrarPorBodega = False

    End Sub

End Class
