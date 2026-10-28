Option Strict On
Option Explicit On

''' <summary>Datos de entrada para calcular el plan de pagos de un crédito (equivale a los controles de FrmNuevoCredito del Sistema de Crédito 5.0).</summary>
Public Class ParametrosPlanCredito
    Public Property Monto As Decimal
    Public Property NumCuotas As Integer
    Public Property FechaInicial As Date
    ''' <summary>Si es True hay un solo pago en <see cref="FechaVencimiento"/>.</summary>
    Public Property AlVencimiento As Boolean
    Public Property FechaVencimiento As Date
    ''' <summary>Cada cuántos días vence la cuota; con <see cref="CadaMes"/> es el día del mes.</summary>
    Public Property DiasPeriodo As Integer
    Public Property CadaMes As Boolean
    Public Property Nivelada As Boolean
    ''' <summary>Interés diario en porcentaje (0.10 = 0.10 %).</summary>
    Public Property InteresDiario As Decimal
    ''' <summary>Interés mensual en porcentaje, usado cuando las cuotas son "de cada mes".</summary>
    Public Property InteresMensual As Decimal
    ''' <summary>Mantenimiento de valor (deslizamiento) MENSUAL en porcentaje. Cero en dólares.</summary>
    Public Property MantoValorMensual As Decimal
End Class

Public Class CuotaCredito
    Public Property NumCuota As Integer
    Public Property Capital As Decimal
    Public Property Interes As Decimal
    Public Property MantoValor As Decimal
    Public Property Pago As Decimal
    Public Property Fecha As Date
End Class

''' <summary>
''' Cálculo del plan de pagos igual al de FrmNuevoCredito (VB6, CalcularCuotas).
'''   - Interés (TipoPrestamo.InteresDiario) es % DIARIO; si las cuotas son "de cada mes" se usa el % mensual fijo.
'''   - Mant. de valor (TipoPrestamo.InteresDeslizamiento) es % MENSUAL; en cuotas por días se divide entre 30.4166.
'''   - Saldo decreciente: interés y mant. de valor sobre el saldo pendiente.
'''   - Nivelada: interés y mant. de valor sobre el monto original (iguales en todas las cuotas).
'''   - Capital = monto / cuotas; la última cuota liquida el saldo, absorbiendo el redondeo.
''' </summary>
Public Class CalculadoraPlanCredito

    Public Const DIAS_MES As Decimal = 30.4166D

    Public Function Calcular(ByVal p As ParametrosPlanCredito) As List(Of CuotaCredito)
        Validar(p)

        Dim tasaDiaria As Decimal = p.InteresDiario / 100D
        Dim tasaMensual As Decimal = p.InteresMensual / 100D
        Dim tasaMvMensual As Decimal = p.MantoValorMensual / 100D
        Dim tasaMvDiaria As Decimal = tasaMvMensual / DIAS_MES

        Dim plan As New List(Of CuotaCredito)
        Dim inicio As Date = p.FechaInicial.Date

        'A) Pago único al vencimiento: interés diario x días
        If p.AlVencimiento Then
            Dim vence As Date = p.FechaVencimiento.Date
            Dim dias As Integer = CInt((vence - inicio).TotalDays)
            plan.Add(NuevaCuota(1, p.Monto, Redondear(p.Monto * tasaDiaria * dias), Redondear(p.Monto * tasaMvDiaria * dias), vence))
            Return plan
        End If

        'B) Varias cuotas
        Dim fechas As List(Of Date) = GenerarFechas(inicio, p.NumCuotas, p.DiasPeriodo, p.CadaMes)
        Dim saldo As Decimal = p.Monto
        Dim anterior As Date = inicio

        For i As Integer = 1 To p.NumCuotas
            Dim fecha As Date = fechas(i - 1)
            Dim dias As Integer = CInt((fecha - anterior).TotalDays)

            'Tasa del período: mensual fija si es "de cada mes", si no diaria x días del período
            Dim factorInteres As Decimal
            Dim factorMv As Decimal
            If p.CadaMes Then
                factorInteres = tasaMensual
                factorMv = tasaMvMensual
            Else
                factorInteres = tasaDiaria * dias
                factorMv = tasaMvDiaria * dias
            End If

            Dim baseCalculo As Decimal = If(p.Nivelada, p.Monto, saldo)
            Dim interes As Decimal = Redondear(baseCalculo * factorInteres)
            Dim manto As Decimal = Redondear(baseCalculo * factorMv)

            Dim capital As Decimal
            If i = p.NumCuotas Then
                capital = saldo
            Else
                capital = Redondear(p.Monto / p.NumCuotas)
            End If

            plan.Add(NuevaCuota(i, capital, interes, manto, fecha))

            saldo = Redondear(saldo - capital)
            anterior = fecha
        Next

        Return plan
    End Function

    ''' <summary>
    ''' Fechas de vencimiento. CadaMes: <paramref name="dias"/> es el día del mes (si el mes no lo tiene se usa el último día).
    ''' Si no, vence cada <paramref name="dias"/> días. Siempre parte de la fecha inicial.
    ''' </summary>
    Public Function GenerarFechas(ByVal inicio As Date, ByVal cuotas As Integer, ByVal dias As Integer, ByVal cadaMes As Boolean) As List(Of Date)
        Dim fechas As New List(Of Date)

        If cadaMes Then
            Dim primerMes As Date = New Date(inicio.Year, inicio.Month, 1).AddMonths(1)
            For i As Integer = 0 To cuotas - 1
                Dim mes As Date = primerMes.AddMonths(i)
                Dim dia As Integer = Math.Min(dias, Date.DaysInMonth(mes.Year, mes.Month))
                fechas.Add(New Date(mes.Year, mes.Month, dia))
            Next
        Else
            For i As Integer = 1 To cuotas
                fechas.Add(inicio.AddDays(dias * i))
            Next
        End If

        Return fechas
    End Function

    ''' <summary>Valor de la cuota que se muestra en pantalla: monto / número de cuotas.</summary>
    Public Shared Function CuotaReferencia(ByVal monto As Decimal, ByVal cuotas As Integer) As Decimal
        If monto <= 0D OrElse cuotas <= 0 Then Return 0D
        Return Redondear(monto / cuotas)
    End Function

    ''' <summary>Redondeo comercial a 2 decimales (Math.Round por defecto es bancario).</summary>
    Public Shared Function Redondear(ByVal valor As Decimal) As Decimal
        Return Math.Round(valor, 2, MidpointRounding.AwayFromZero)
    End Function

    Private Shared Function NuevaCuota(ByVal numero As Integer, ByVal capital As Decimal, ByVal interes As Decimal, _
                                       ByVal manto As Decimal, ByVal fecha As Date) As CuotaCredito
        Return New CuotaCredito With {
            .NumCuota = numero,
            .Capital = capital,
            .Interes = interes,
            .MantoValor = manto,
            .Pago = Redondear(capital + interes + manto),
            .Fecha = fecha
        }
    End Function

    Private Shared Sub Validar(ByVal p As ParametrosPlanCredito)
        If p Is Nothing Then Throw New ArgumentNullException("p")
        If p.Monto <= 0D Then Throw New ArgumentException("El monto del préstamo es erróneo.")

        If p.AlVencimiento Then
            If p.FechaVencimiento.Date <= p.FechaInicial.Date Then
                Throw New ArgumentException("La fecha de vencimiento debe ser mayor que la fecha inicial.")
            End If
            Exit Sub
        End If

        If p.NumCuotas <= 0 Then Throw New ArgumentException("El número de cuotas es erróneo.")
        If p.DiasPeriodo <= 0 Then Throw New ArgumentException("Los días del período del préstamo son erróneos.")
        If p.CadaMes AndAlso p.DiasPeriodo > 31 Then
            Throw New ArgumentException("En modo 'De cada mes' el día debe estar entre 1 y 31.")
        End If
    End Sub

End Class
