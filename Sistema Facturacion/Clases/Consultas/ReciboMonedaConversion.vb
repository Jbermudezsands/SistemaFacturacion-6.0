Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

'=====================================================================================================
'  CONVERSIÓN DE MONEDA DEL MÉTODO DE PAGO A LA MONEDA DEL RECIBO
'
'  El monto que el cajero digita en la línea del recibo está en la moneda del MÉTODO DE PAGO
'  (p. ej. "Efectivo $" = Dolares). El recibo tiene su propia moneda (Cordobas o Dolares).
'  Cuando son distintas se convierte con la tasa de cambio de la fecha del recibo:
'
'     Método Dolares  -> Recibo Cordobas :  monto * tasa
'     Método Cordobas -> Recibo Dolares  :  monto / tasa
'     Misma moneda                       :  monto (tasa 1)
'
'  TasaCambio.MontoTasa = córdobas por dólar.
'=====================================================================================================
Public Class ReciboMonedaConversion

    Private ReadOnly _conexion As String
    Private ReadOnly _cacheMetodo As New System.Collections.Generic.Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly _cacheTasa As New System.Collections.Generic.Dictionary(Of Date, Decimal)

    Public Sub New(ByVal conexion As String)
        _conexion = conexion
    End Sub

    ''' <summary>Quita los datos en caché (llamar al cambiar de fecha o recargar métodos).</summary>
    Public Sub Limpiar()
        _cacheMetodo.Clear()
        _cacheTasa.Clear()
    End Sub

    ''' <summary>Moneda configurada en el método de pago ("Cordobas" o "Dolares"). Vacío si no existe.</summary>
    Public Function MonedaMetodo(ByVal nombrePago As String) As String
        If nombrePago Is Nothing OrElse nombrePago.Trim() = "" Then Return ""
        Dim valor As String = ""
        If _cacheMetodo.TryGetValue(nombrePago.Trim(), valor) Then Return valor

        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT TOP 1 Moneda FROM MetodoPago WHERE NombrePago = @Nombre", cn)
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = nombrePago.Trim()
                cn.Open()
                Dim r As Object = cmd.ExecuteScalar()
                If r IsNot Nothing AndAlso Not IsDBNull(r) Then valor = Convert.ToString(r).Trim()
            End Using
        End Using
        _cacheMetodo(nombrePago.Trim()) = valor
        Return valor
    End Function

    ''' <summary>Tasa de cambio (córdobas por dólar) del día; 0 si no existe.</summary>
    Public Function TasaDelDia(ByVal fecha As Date) As Decimal
        Dim f As Date = fecha.Date
        Dim valor As Decimal = 0D
        If _cacheTasa.TryGetValue(f, valor) Then Return valor

        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT TOP 1 MontoTasa FROM TasaCambio WHERE FechaTasa = @Fecha", cn)
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = f
                cn.Open()
                Dim r As Object = cmd.ExecuteScalar()
                If r IsNot Nothing AndAlso Not IsDBNull(r) Then valor = Convert.ToDecimal(r)
            End Using
        End Using
        If valor > 0D Then _cacheTasa(f) = valor
        Return valor
    End Function

    ''' <summary>True si el método está en una moneda distinta a la del recibo.</summary>
    Public Function RequiereConversion(ByVal nombrePago As String, ByVal monedaRecibo As String) As Boolean
        Dim mm As String = MonedaMetodo(nombrePago)
        If mm = "" OrElse monedaRecibo Is Nothing Then Return False
        Return Not String.Equals(mm, monedaRecibo.Trim(), StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Factor para pasar el monto digitado (moneda del método) a la moneda del recibo.
    ''' Devuelve 1 si no hay conversión; 0 si hace falta tasa y no existe para la fecha.
    ''' </summary>
    Public Function Factor(ByVal nombrePago As String, ByVal monedaRecibo As String, ByVal fecha As Date) As Decimal
        If Not RequiereConversion(nombrePago, monedaRecibo) Then Return 1D

        Dim tasa As Decimal = TasaDelDia(fecha)
        If tasa <= 0D Then Return 0D

        If String.Equals(MonedaMetodo(nombrePago), "Dolares", StringComparison.OrdinalIgnoreCase) Then
            Return tasa                 ' dólares -> córdobas
        End If
        Return 1D / tasa                ' córdobas -> dólares
    End Function

    ''' <summary>Convierte el monto digitado a la moneda del recibo (redondeo a 2 decimales). Nothing-seguro: tasa faltante = 0.</summary>
    Public Function Convertir(ByVal monto As Decimal, ByVal nombrePago As String, ByVal monedaRecibo As String, ByVal fecha As Date) As Decimal
        Return Math.Round(monto * Factor(nombrePago, monedaRecibo, fecha), 2, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>Operación inversa: del monto del recibo al monto en la moneda del método (para mostrar al editar).</summary>
    Public Function ConvertirInverso(ByVal montoRecibo As Decimal, ByVal nombrePago As String, ByVal monedaRecibo As String, ByVal fecha As Date) As Decimal
        Dim f As Decimal = Factor(nombrePago, monedaRecibo, fecha)
        If f <= 0D Then Return montoRecibo
        Return Math.Round(montoRecibo / f, 2, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>Texto informativo para el cajero ("Recibe dólares, se aplica en córdobas a tasa X").</summary>
    Public Function Aviso(ByVal nombrePago As String, ByVal monedaRecibo As String, ByVal fecha As Date) As String
        If Not RequiereConversion(nombrePago, monedaRecibo) Then Return ""
        Dim mm As String = MonedaMetodo(nombrePago)
        Dim tasa As Decimal = TasaDelDia(fecha)
        If tasa <= 0D Then
            Return String.Format("El método '{0}' es en {1} y el recibo en {2}, pero no existe tasa de cambio para el {3:dd/MM/yyyy}.",
                                 nombrePago, mm, monedaRecibo, fecha)
        End If
        Return String.Format("El método '{0}' recibe {1}; el recibo es en {2}. Se convierte con la tasa del {3:dd/MM/yyyy}: {4:N4}.",
                             nombrePago, mm, monedaRecibo, fecha, tasa)
    End Function
End Class
