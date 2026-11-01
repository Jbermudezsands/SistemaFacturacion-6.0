Option Strict On
Option Explicit On

Imports System.Collections.Generic

''' <summary>
''' Cálculos del arqueo de caja. No accede a datos ni a controles, de modo que se puede probar de forma aislada.
''' Se usa Decimal y un redondeo único a 2 decimales (AwayFromZero) para evitar los errores de Double.
''' </summary>
Public NotInheritable Class ArqueoCalculadora

    Public Const Decimales As Integer = 2

    Private Sub New()
    End Sub

    Public Shared Function Redondear(ByVal valor As Decimal) As Decimal
        Return Math.Round(valor, Decimales, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>Monto de un renglón de denominaciones: valor del billete/moneda por la cantidad.</summary>
    Public Shared Function CalcularMonto(ByVal valor As Decimal, ByVal cantidad As Decimal) As Decimal
        Return Redondear(valor * cantidad)
    End Function

    ''' <summary>Convierte dólares a córdobas. Se convierte el total, no cada renglón, para no acumular redondeos.</summary>
    Public Shared Function ConvertirDolaresACordobas(ByVal montoDolares As Decimal, ByVal tasaCambio As Decimal) As Decimal
        Return Redondear(montoDolares * tasaCambio)
    End Function

    Public Shared Function SumarDenominaciones(ByVal denominaciones As IEnumerable(Of ArqueoDenominacion)) As Decimal
        Dim total As Decimal = 0D
        If denominaciones Is Nothing Then Return total

        For Each denominacion As ArqueoDenominacion In denominaciones
            total += denominacion.Monto
        Next

        Return Redondear(total)
    End Function

    Public Shared Function Calcular(ByVal entrada As ArqueoEntradaCalculo) As ArqueoResumen
        If entrada Is Nothing Then
            Throw New ArgumentNullException("entrada")
        End If

        Dim resumen As New ArqueoResumen()
        Dim tasa As Decimal = entrada.TasaCambio
        If tasa < 0D Then tasa = 0D

        resumen.TasaCambio = tasa
        resumen.FondoApertura = Redondear(entrada.FondoApertura)

        resumen.EfectivoContadoCordobas = SumarDenominaciones(entrada.DenominacionesCordobas)
        resumen.EfectivoContadoDolares = SumarDenominaciones(entrada.DenominacionesDolares)
        resumen.ChequesCordobas = Redondear(entrada.ChequesCordobas)
        resumen.ChequesDolares = Redondear(entrada.ChequesDolares)
        resumen.EfectivoEsperadoCordobas = Redondear(entrada.EfectivoEsperadoCordobas)
        resumen.EfectivoEsperadoDolares = Redondear(entrada.EfectivoEsperadoDolares)

        resumen.FaltaTasaCambio = tasa = 0D AndAlso
            (resumen.EfectivoContadoDolares <> 0D OrElse resumen.ChequesDolares <> 0D OrElse resumen.EfectivoEsperadoDolares <> 0D)

        ' Contado: efectivo + cheques/tarjetas, con los dólares convertidos a córdobas
        resumen.TotalContado = resumen.EfectivoContadoCordobas +
            ConvertirDolaresACordobas(resumen.EfectivoContadoDolares, tasa) +
            resumen.ChequesCordobas +
            ConvertirDolaresACordobas(resumen.ChequesDolares, tasa)

        ' Esperado: los cheques/tarjetas de la lista ya vienen de las facturas/recibos, más el efectivo recaudado y el fondo
        resumen.TotalEsperado = resumen.ChequesCordobas +
            ConvertirDolaresACordobas(resumen.ChequesDolares, tasa) +
            resumen.EfectivoEsperadoCordobas +
            ConvertirDolaresACordobas(resumen.EfectivoEsperadoDolares, tasa) +
            resumen.FondoApertura

        resumen.Diferencia = Redondear(resumen.TotalEsperado - resumen.TotalContado)

        Return resumen
    End Function

End Class
