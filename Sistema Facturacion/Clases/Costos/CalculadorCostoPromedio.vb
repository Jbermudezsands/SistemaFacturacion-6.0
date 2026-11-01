Option Strict On
Option Explicit On

Imports System.Collections.Generic

''' <summary>
''' Replica EN MEMORIA de CostoPromedioKardex (Funciones.vb). No inventa reglas: cada condicion
''' esta tomada de las consultas originales. Como el original es una suma acumulada hasta la
''' fecha, una sola pasada ordenada por fecha entrega el costo de todas las fechas pedidas.
'''
''' Reglas replicadas:
'''  - Compras 'Mercancia Recibida': importe = Precio_Neto * Cantidad. Compras en Dolares: C$ = x Tasa;
'''    otras monedas: US$ = / Tasa. MonedaCompra NULL no entra (NULL &lt;&gt; 'Dolares' es desconocido en SQL).
'''  - 'Devolucion de Compra': se resta con su propio Precio_Neto * Cantidad (no Costo_Unitario).
'''  - 'Factura' y 'Devolucion de Venta': Cantidad * Costo_Unitario &lt;&gt; 0.
'''  - 'Salida Bodega': filtro Cantidad * Precio_Unitario &lt;&gt; 0; la cantidad cuenta solo si
'''    Costo_Unitario &lt;&gt; 0 (NULL cuenta); si el importe total de salidas es 0 la cantidad de salidas se anula.
'''  - Transferencias Enviada/Recibida: EXCLUIDAS (igual que el original).
'''  - Movimientos de una fecha sin TasaCambio se descartan (INNER JOIN original) y se cuentan en el resultado.
'''  - Costo = Format(Importe / Cantidad, "##,##0.000000000") convertido a Double (igual que el original).
'''  - Si el costo es 0: ultimo Costo_Unitario &lt;&gt; 0 de Detalle_Facturas a esa fecha; US$ = costo * tasa de esa fecha.
'''    (Se conserva la multiplicacion del original aunque conceptualmente sea sospechosa; ver informe.)
''' </summary>
Public Class CalculadorCostoPromedio

    Private Const FormatoCosto As String = "##,##0.000000000"

    ''' <summary>Sumas acumuladas del kardex. Copiar() permite evaluar escenarios sin alterar la base acumulada.</summary>
    Public Class Acumulador
        Public Function Copiar() As Acumulador
            Return DirectCast(Me.MemberwiseClone(), Acumulador)
        End Function

        ' Compras
        Public CantComprasUSD As Double
        Public CantComprasOtras As Double
        Public ComprasUSD_C As Double
        Public ComprasUSD_D As Double
        Public ComprasOtras_C As Double
        Public ComprasOtras_D As Double
        ' Devoluciones de compra
        Public CantDevComprasUSD As Double
        Public CantDevComprasOtras As Double
        Public DevComprasUSD_C As Double
        Public DevComprasUSD_D As Double
        Public DevComprasOtras_C As Double
        Public DevComprasOtras_D As Double
        ' Ventas (Factura)
        Public CantVentas As Double
        Public Ventas_C As Double
        Public Ventas_D As Double
        ' Salida Bodega
        Public CantSalida As Double
        Public Salida_C As Double
        Public Salida_D As Double
        ' Devolucion de venta
        Public CantDevVenta As Double
        Public DevVenta_C As Double
        Public DevVenta_D As Double
        ' Diagnostico
        Public SinTasa As Integer
        Public MonedaNula As Integer
        Public TasaCero As Integer
    End Class

    ' ------------------------------------------------------------------
    ' API
    ' ------------------------------------------------------------------

    ''' <summary>Costo promedio a una fecha (equivale a CostoPromedioKardex(codigo, fecha)).</summary>
    Public Function CostoAFecha(ByVal codProducto As String, ByVal fecha As Date,
                                ByVal movimientos As List(Of MovimientoCosto),
                                ByVal candidatos As List(Of UltimoCostoCandidato)) As ResultadoCosteo
        Dim fechas As New List(Of Date)
        fechas.Add(fecha)
        Dim r As Dictionary(Of Date, ResultadoCosteo) = CostosPorFechas(codProducto, fechas, movimientos, candidatos)
        Return r(fecha.Date)
    End Function

    ''' <summary>
    ''' Costo promedio en cada fecha pedida con UN solo recorrido de los movimientos.
    ''' La clave del diccionario es fecha.Date.
    ''' </summary>
    Public Function CostosPorFechas(ByVal codProducto As String, ByVal fechas As IEnumerable(Of Date),
                                    ByVal movimientos As List(Of MovimientoCosto),
                                    ByVal candidatos As List(Of UltimoCostoCandidato)) As Dictionary(Of Date, ResultadoCosteo)
        Dim resultado As New Dictionary(Of Date, ResultadoCosteo)

        ' Fechas distintas y ordenadas
        Dim ordenFechas As New List(Of Date)
        Dim vistas As New HashSet(Of Date)
        For Each f As Date In fechas
            If vistas.Add(f.Date) Then ordenFechas.Add(f.Date)
        Next
        ordenFechas.Sort()

        ' Movimientos ordenados de forma determinista (fecha, origen, id)
        Dim ordenados As New List(Of MovimientoCosto)(movimientos)
        ordenados.Sort(AddressOf CompararMovimientos)

        Dim listaCand As List(Of UltimoCostoCandidato) = If(candidatos, New List(Of UltimoCostoCandidato))

        Dim acu As New Acumulador
        Dim iMov As Integer = 0
        Dim iCand As Integer = -1   ' indice del ultimo candidato con Fecha <= fecha actual

        For Each f As Date In ordenFechas
            While iMov < ordenados.Count AndAlso ordenados(iMov).Fecha <= f
                Agregar(acu, ordenados(iMov))
                iMov += 1
            End While
            While iCand + 1 < listaCand.Count AndAlso listaCand(iCand + 1).Fecha <= f
                iCand += 1
            End While
            resultado(f) = Evaluar(codProducto, f, acu, listaCand, iCand)
        Next

        Return resultado
    End Function

    ' ------------------------------------------------------------------
    ' Acumulacion
    ' ------------------------------------------------------------------

    Private Shared Function CompararMovimientos(ByVal a As MovimientoCosto, ByVal b As MovimientoCosto) As Integer
        Dim c As Integer = a.Fecha.CompareTo(b.Fecha)
        If c <> 0 Then Return c
        c = CInt(a.Origen).CompareTo(CInt(b.Origen))
        If c <> 0 Then Return c
        Return a.Id.CompareTo(b.Id)
    End Function

    Private Shared Function EsTipo(ByVal tipo As String, ByVal esperado As String) As Boolean
        Return tipo IsNot Nothing AndAlso String.Equals(tipo.TrimEnd(), esperado, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Shared Sub Agregar(ByVal a As Acumulador, ByVal m As MovimientoCosto)
        If m.Origen = TipoOrigenMovimiento.Compra Then
            AgregarCompra(a, m)
        Else
            AgregarFactura(a, m)
        End If
    End Sub

    Private Shared Sub AgregarCompra(ByVal a As Acumulador, ByVal m As MovimientoCosto)
        Dim esRecibida As Boolean = EsTipo(m.Tipo, "Mercancia Recibida")
        Dim esDevolucion As Boolean = EsTipo(m.Tipo, "Devolucion de Compra")
        If Not (esRecibida OrElse esDevolucion) Then Return

        ' INNER JOIN TasaCambio del original: sin tasa el movimiento no existe para el calculo.
        If Not m.Tasa.HasValue Then
            a.SinTasa += 1
            Return
        End If
        ' MonedaCompra NULL no cumple ni "= 'Dolares'" ni "<> 'Dolares'".
        If m.Moneda Is Nothing Then
            a.MonedaNula += 1
            Return
        End If

        Dim esUSD As Boolean = String.Equals(m.Moneda.TrimEnd(), "Dolares", StringComparison.OrdinalIgnoreCase)
        Dim tasa As Double = m.Tasa.Value
        If (Not esUSD) AndAlso tasa = 0 Then
            ' El SQL original fallaria con division por cero; aqui se descarta y se informa.
            a.TasaCero += 1
            Return
        End If

        ' SUM() ignora NULL: la cantidad cuenta si Cantidad no es NULL; el importe si ambos no son NULL.
        Dim cant As Double = 0
        If m.Cantidad.HasValue Then cant = m.Cantidad.Value
        Dim impC As Double = 0
        Dim impD As Double = 0
        If m.PrecioNeto.HasValue AndAlso m.Cantidad.HasValue Then
            Dim bruto As Double = m.PrecioNeto.Value * m.Cantidad.Value
            If esUSD Then
                impC = bruto * tasa
                impD = bruto
            Else
                impC = bruto
                impD = bruto / tasa
            End If
        End If

        If esRecibida Then
            If esUSD Then
                a.CantComprasUSD += cant : a.ComprasUSD_C += impC : a.ComprasUSD_D += impD
            Else
                a.CantComprasOtras += cant : a.ComprasOtras_C += impC : a.ComprasOtras_D += impD
            End If
        Else
            If esUSD Then
                a.CantDevComprasUSD += cant : a.DevComprasUSD_C += impC : a.DevComprasUSD_D += impD
            Else
                a.CantDevComprasOtras += cant : a.DevComprasOtras_C += impC : a.DevComprasOtras_D += impD
            End If
        End If
    End Sub

    Private Shared Sub AgregarFactura(ByVal a As Acumulador, ByVal m As MovimientoCosto)
        Dim esFactura As Boolean = EsTipo(m.Tipo, "Factura")
        Dim esSalida As Boolean = EsTipo(m.Tipo, "Salida Bodega")
        Dim esDevVenta As Boolean = EsTipo(m.Tipo, "Devolucion de Venta")
        If Not (esFactura OrElse esSalida OrElse esDevVenta) Then Return

        If Not m.Tasa.HasValue Then
            a.SinTasa += 1
            Return
        End If
        Dim tasa As Double = m.Tasa.Value
        If tasa = 0 Then
            a.TasaCero += 1
            Return
        End If

        If esSalida Then
            ' WHERE Cantidad * Precio_Unitario <> 0
            If Not (m.Cantidad.HasValue AndAlso m.PrecioUnitario.HasValue) Then Return
            If m.Cantidad.Value * m.PrecioUnitario.Value = 0 Then Return

            ' CASE WHEN Costo_Unitario = 0 THEN 0 ELSE Cantidad END  (NULL cae en ELSE)
            If Not (m.CostoUnitario.HasValue AndAlso m.CostoUnitario.Value = 0) Then
                a.CantSalida += m.Cantidad.Value
            End If
            ' SUM(Cantidad * Costo_Unitario): NULL se ignora
            If m.CostoUnitario.HasValue Then
                Dim imp As Double = m.Cantidad.Value * m.CostoUnitario.Value
                a.Salida_C += imp
                a.Salida_D += imp / tasa
            End If
            Return
        End If

        ' Factura y Devolucion de Venta: WHERE Cantidad * Costo_Unitario <> 0
        If Not (m.Cantidad.HasValue AndAlso m.CostoUnitario.HasValue) Then Return
        Dim importe As Double = m.Cantidad.Value * m.CostoUnitario.Value
        If importe = 0 Then Return

        If esFactura Then
            a.CantVentas += m.Cantidad.Value
            a.Ventas_C += importe
            a.Ventas_D += importe / tasa
        Else
            a.CantDevVenta += m.Cantidad.Value
            a.DevVenta_C += importe
            a.DevVenta_D += importe / tasa
        End If
    End Sub

    ' ------------------------------------------------------------------
    ' Formula
    ' ------------------------------------------------------------------

    Public Shared Function Evaluar(ByVal codProducto As String, ByVal fecha As Date, ByVal a As Acumulador,
                                    ByVal candidatos As List(Of UltimoCostoCandidato), ByVal indiceCandidato As Integer) As ResultadoCosteo
        Dim r As New ResultadoCosteo
        r.CodigoProducto = codProducto
        r.Fecha = fecha
        r.MovimientosSinTasa = a.SinTasa

        ' Mismo orden de sumas que el original (USD primero, luego otras monedas)
        Dim cantCompras As Double = a.CantComprasUSD + a.CantComprasOtras
        Dim totalCompras As Double = a.ComprasUSD_C + a.ComprasOtras_C
        Dim totalComprasD As Double = a.ComprasUSD_D + a.ComprasOtras_D

        Dim cantDevCompra As Double = a.CantDevComprasUSD + a.CantDevComprasOtras
        Dim totalDevCompras As Double = a.DevComprasUSD_C + a.DevComprasOtras_C
        Dim totalDevComprasD As Double = a.DevComprasUSD_D + a.DevComprasOtras_D

        ' Salida Bodega: si el importe total es 0 la cantidad se anula
        Dim cantSalida As Double = a.CantSalida
        If a.Salida_C = 0 Then cantSalida = 0

        Dim totalCantidad As Double = cantCompras + a.CantDevVenta - a.CantVentas - cantDevCompra - cantSalida
        Dim totalImporte As Double = totalCompras + a.DevVenta_C - a.Ventas_C - totalDevCompras - a.Salida_C
        Dim totalImporteD As Double = totalComprasD + a.DevVenta_D - a.Ventas_D - totalDevComprasD - a.Salida_D

        r.Cantidad = totalCantidad
        r.Importe = totalImporte
        r.ImporteDolar = totalImporteD

        Dim precioCosto As Double = 0
        Dim precioCostoDolar As Double = 0
        If totalCantidad <> 0 Then
            precioCosto = CDbl(Format(totalImporte / totalCantidad, FormatoCosto))
            precioCostoDolar = CDbl(Format(totalImporteD / totalCantidad, FormatoCosto))
        End If
        r.Origen = OrigenCostoCalculado.Promedio

        If precioCosto = 0 Then
            r.Origen = OrigenCostoCalculado.SinCosto
            If indiceCandidato >= 0 Then
                Dim ult As UltimoCostoCandidato = candidatos(indiceCandidato)
                precioCosto = ult.CostoUnitario
                precioCostoDolar = precioCosto * ult.Tasa
                r.Origen = OrigenCostoCalculado.UltimoCosto
                ' El original ordena solo por fecha: con empate de fecha el elegido no esta definido.
                If indiceCandidato > 0 Then
                    Dim ant As UltimoCostoCandidato = candidatos(indiceCandidato - 1)
                    If ant.Fecha = ult.Fecha AndAlso ant.CostoUnitario <> ult.CostoUnitario Then
                        r.Advertencias.Add("Ultimo costo con empate de fecha " & ult.Fecha.ToString("yyyy-MM-dd") & ": el original no define el orden.")
                    End If
                End If
            End If
        End If

        r.CostoCordoba = precioCosto
        r.CostoDolar = precioCostoDolar

        If a.SinTasa > 0 Then r.Advertencias.Add(a.SinTasa & " movimiento(s) sin TasaCambio descartados (igual que el original).")
        If a.MonedaNula > 0 Then r.Advertencias.Add(a.MonedaNula & " compra(s) con MonedaCompra NULL descartadas (igual que el original).")
        If a.TasaCero > 0 Then r.Advertencias.Add(a.TasaCero & " movimiento(s) con tasa cero descartados (el original produciria division por cero).")

        Return r
    End Function

End Class
