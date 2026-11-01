Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Globalization

Public Class ResultadoReparacionProducto
    Public Property CodigoProducto As String
    Public Property FilasProcesadas As Integer
    Public Property FilasFacturaModificadas As Integer
    Public Property FilasCompraModificadas As Integer
    Public Property Aplicado As Boolean
    Public Property Advertencias As New List(Of String)
End Class

Public Class ResumenReparacion
    Public Property Productos As Integer
    Public Property ProductosConCambios As Integer
    Public Property FilasFacturaModificadas As Integer
    Public Property FilasCompraModificadas As Integer
    Public Property Aplicado As Boolean
    Public Property Cancelado As Boolean
    Public Property Milisegundos As Long
    Public Property Errores As New List(Of String)
    Public Property Advertencias As New List(Of String)
End Class

''' <summary>
''' Recosteo masivo por producto. Replica el proceso de FrmActualiza.CmdCostear_Click:
'''   1. Costo de las 'Devolucion de Compra' = CostoPromedioKardex a su fecha (con el estado ANTERIOR de las facturas).
'''   2. Costo_Unitario = 0 en TODO Detalle_Facturas del producto.
'''   3. Cada fila (con cabecera y Tipo &lt;&gt; 'Cotizacion') en orden de fecha: costo = Kardex a su fecha con el estado actual
'''      (las ya costeadas cuentan, las pendientes estan en 0); si da 0 y Cantidad &lt;&gt; 0, ultimo costo conocido.
'''   4. Escritura segun tipo: Transferencia Enviada y Salida Bodega -> Costo, Precio_Unitario, Precio_Neto e Importe
'''      (la Enviada tambien actualiza su Transferencia Recibida); otros tipos -> solo Costo_Unitario.
''' Diferencias deliberadas respecto del original: todo el producto se calcula en memoria con UNA lectura (no una consulta
''' por fila), se escribe solo lo que cambia, con parametros y en UNA transaccion por producto. Los resultados deben ser
''' identicos (ver validacion con copias de la BD).
''' Comportamientos del original que se conservan a proposito: la clave del UPDATE es Numero + Fecha(sin hora) + Tipo
''' (lineas repetidas del mismo producto en un documento reciben el mismo costo; filas con hora no coinciden y quedan en 0)
''' y los valores se redondean a 15 digitos (Math.Abs(x).ToString()).
''' </summary>
Public Class ReparadorCostos

    Public Event Progreso(ByVal actual As Integer, ByVal total As Integer, ByVal mensaje As String)

    ''' <summary>Poner en True para detener el proceso entre productos (cada producto es atomico).</summary>
    Public Property Cancelar As Boolean

    Private ReadOnly _repositorio As RepositorioMovimientos
    Private ReadOnly _calculador As New CalculadorCostoPromedio

    Public Sub New(ByVal cadenaConexion As String)
        _repositorio = New RepositorioMovimientos(cadenaConexion)
    End Sub

    ' ------------------------------------------------------------------
    ' Rango de productos (equivale a TxtDesdeCosto / TxtHastaCosto)
    ' ------------------------------------------------------------------

    ''' <param name="aplicar">False = simulacion: calcula y cuenta cambios sin escribir nada.</param>
    Public Function RecalcularRango(ByVal desde As String, ByVal hasta As String, ByVal aplicar As Boolean) As ResumenReparacion
        Dim resumen As New ResumenReparacion
        resumen.Aplicado = aplicar
        Cancelar = False
        Dim crono As Stopwatch = Stopwatch.StartNew()

        Dim codigos As List(Of String) = _repositorio.ListarProductos(desde, hasta)
        resumen.Productos = codigos.Count

        For i As Integer = 0 To codigos.Count - 1
            If Cancelar Then
                resumen.Cancelado = True
                Exit For
            End If
            RaiseEvent Progreso(i + 1, codigos.Count, codigos(i))
            Try
                Dim r As ResultadoReparacionProducto = RecalcularProducto(codigos(i), aplicar)
                If r.FilasFacturaModificadas + r.FilasCompraModificadas > 0 Then resumen.ProductosConCambios += 1
                resumen.FilasFacturaModificadas += r.FilasFacturaModificadas
                resumen.FilasCompraModificadas += r.FilasCompraModificadas
                For Each a As String In r.Advertencias
                    If resumen.Advertencias.Count < 500 Then resumen.Advertencias.Add(codigos(i) & ": " & a)
                Next
            Catch ex As Exception
                resumen.Errores.Add(codigos(i) & ": " & ex.Message)
            End Try
        Next

        crono.Stop()
        resumen.Milisegundos = crono.ElapsedMilliseconds
        Return resumen
    End Function

    ' ------------------------------------------------------------------
    ' Un producto (transaccion propia)
    ' ------------------------------------------------------------------

    Public Function RecalcularProducto(ByVal codProducto As String, ByVal aplicar As Boolean) As ResultadoReparacionProducto
        Using cn As New SqlConnection(_repositorio.CadenaConexion)
            cn.Open()
            Dim tx As SqlTransaction = cn.BeginTransaction()
            Try
                Dim filas As List(Of MovimientoCosto) = Nothing
                Dim recibidas As List(Of MovimientoCosto) = Nothing
                Dim devoluciones As List(Of MovimientoCosto) = Nothing
                Dim resultado As ResultadoReparacionProducto = Calcular(cn, tx, codProducto, filas, recibidas, devoluciones)

                For Each f As MovimientoCosto In filas
                    If CambioAlgo(f) Then resultado.FilasFacturaModificadas += 1
                Next
                For Each c As MovimientoCosto In recibidas
                    If CambioAlgo(c) Then resultado.FilasCompraModificadas += 1
                Next
                For Each c As MovimientoCosto In devoluciones
                    If CambioAlgo(c) Then resultado.FilasCompraModificadas += 1
                Next

                If aplicar Then
                    For Each f As MovimientoCosto In filas
                        _repositorio.ActualizarCostos(cn, tx, True, f)
                    Next
                    For Each c As MovimientoCosto In recibidas
                        _repositorio.ActualizarCostos(cn, tx, False, c)
                    Next
                    For Each c As MovimientoCosto In devoluciones
                        _repositorio.ActualizarCostos(cn, tx, False, c)
                    Next
                    tx.Commit()
                    resultado.Aplicado = True
                Else
                    tx.Rollback()
                End If
                Return resultado
            Catch
                Try
                    tx.Rollback()
                Catch
                End Try
                Throw
            End Try
        End Using
    End Function

    ' ------------------------------------------------------------------
    ' Calculo en memoria
    ' ------------------------------------------------------------------

    Private Function Calcular(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cod As String,
                              ByRef filas As List(Of MovimientoCosto),
                              ByRef recibidas As List(Of MovimientoCosto),
                              ByRef devoluciones As List(Of MovimientoCosto)) As ResultadoReparacionProducto
        Dim res As New ResultadoReparacionProducto
        res.CodigoProducto = cod

        filas = _repositorio.CargarFilasFactura(cn, tx, cod)
        recibidas = _repositorio.CargarTransferenciasRecibidas(cn, tx, cod)
        devoluciones = _repositorio.CargarDevolucionesCompra(cn, tx, cod)
        Dim compras As List(Of MovimientoCosto) = _repositorio.CargarComprasKardex(cn, tx, cod, Nothing)

        ' ---- Paso 1: costo de devoluciones de compra con el estado ANTERIOR de las facturas ----
        If devoluciones.Count > 0 Then
            Dim movs0 As New List(Of MovimientoCosto)(compras)
            Dim cands0 As New List(Of UltimoCostoCandidato)
            For Each f As MovimientoCosto In filas
                If f.TieneCabecera Then movs0.Add(f)
                If f.CostoUnitario.HasValue AndAlso f.CostoUnitario.Value <> 0 AndAlso f.Tasa.HasValue Then
                    Dim c As New UltimoCostoCandidato
                    c.Id = f.Id
                    c.Fecha = f.Fecha
                    c.CostoUnitario = f.CostoUnitario.Value
                    c.Tasa = f.Tasa.Value
                    cands0.Add(c)
                End If
            Next
            Dim fechasDev As New List(Of Date)
            For Each d As MovimientoCosto In devoluciones
                fechasDev.Add(d.Fecha.Date)
            Next
            Dim costos As Dictionary(Of Date, ResultadoCosteo) = _calculador.CostosPorFechas(cod, fechasDev, movs0, cands0)
            For Each d As MovimientoCosto In devoluciones
                d.CostoUnitario = Redondear15(costos(d.Fecha.Date).CostoCordoba)
            Next
        End If

        ' ---- Paso 2: costo cero en todo Detalle_Facturas del producto ----
        For Each f As MovimientoCosto In filas
            f.CostoUnitario = 0.0
        Next

        ' ---- Estructuras de apoyo ----
        Dim procesadas As New List(Of MovimientoCosto)       ' con cabecera y Tipo <> 'Cotizacion' (orden fecha, id)
        Dim kardex As New List(Of MovimientoCosto)           ' subconjunto que entra al kardex
        Dim porClave As New Dictionary(Of String, List(Of MovimientoCosto))
        For Each f As MovimientoCosto In filas
            If f.TieneCabecera AndAlso Not EsTipo(f.Tipo, "Cotizacion") Then
                procesadas.Add(f)
                If EsTipo(f.Tipo, "Factura") OrElse EsTipo(f.Tipo, "Salida Bodega") OrElse EsTipo(f.Tipo, "Devolucion de Venta") Then
                    kardex.Add(f)
                End If
                If f.Fecha.TimeOfDay.Ticks <> 0 Then
                    res.Advertencias.Add("Fila con hora " & f.Fecha.ToString("yyyy-MM-dd HH:mm") & " " & f.Tipo & " " & f.Numero & ": el UPDATE por fecha exacta del original no la alcanza (queda en 0).")
                End If
            End If
            If f.Fecha.TimeOfDay.Ticks = 0 Then
                AgregarAClave(porClave, ClaveFactura(f.Numero, f.Tipo, f.Fecha), f)
            End If
        Next
        res.FilasProcesadas = procesadas.Count

        Dim recibidasPorClave As New Dictionary(Of String, List(Of MovimientoCosto))
        For Each c As MovimientoCosto In recibidas
            If c.Fecha.TimeOfDay.Ticks = 0 Then
                AgregarAClave(recibidasPorClave, ClaveCompra(c.Numero, c.Fecha), c)
            End If
        Next

        ' ---- Paso 3: recorrido en orden de fecha ----
        Dim acuFijo As New CalculadorCostoPromedio.Acumulador
        Dim iCompra As Integer = 0
        Dim iFac As Integer = 0
        Dim cantidadActual As Double = 0
        Dim i As Integer = 0

        While i < procesadas.Count
            Dim fechaGrupo As Date = procesadas(i).Fecha
            Dim corte As Date = fechaGrupo.Date
            Dim j As Integer = i
            While j < procesadas.Count AndAlso procesadas(j).Fecha = fechaGrupo
                j += 1
            End While

            ' Compras con Fecha <= corte (estaticas)
            While iCompra < compras.Count AndAlso compras(iCompra).Fecha <= corte
                CalculadorCostoPromedio.Agregar(acuFijo, compras(iCompra))
                iCompra += 1
            End While
            ' Facturas ya definitivas: Fecha anterior al grupo y dentro del corte
            While iFac < kardex.Count AndAlso kardex(iFac).Fecha < fechaGrupo AndAlso kardex(iFac).Fecha <= corte
                CalculadorCostoPromedio.Agregar(acuFijo, kardex(iFac))
                iFac += 1
            End While
            ' Filas del mismo instante que cuentan en el kardex (solo si el instante es medianoche = corte)
            Dim grupoKardex As New List(Of MovimientoCosto)
            If fechaGrupo = corte Then
                Dim k As Integer = iFac
                While k < kardex.Count AndAlso kardex(k).Fecha = fechaGrupo
                    grupoKardex.Add(kardex(k))
                    k += 1
                End While
            End If

            For idx As Integer = i To j - 1
                Dim r As MovimientoCosto = procesadas(idx)

                Dim acu As CalculadorCostoPromedio.Acumulador = acuFijo.Copiar()
                For Each g As MovimientoCosto In grupoKardex
                    CalculadorCostoPromedio.Agregar(acu, g)
                Next
                Dim costo As Double = CalculadorCostoPromedio.Evaluar(cod, corte, acu, Nothing, -1).CostoCordoba

                If r.Cantidad.HasValue Then cantidadActual = r.Cantidad.Value

                ' Facturacion en negativo: costo 0 con cantidad -> ultimo costo conocido
                If cantidadActual <> 0 AndAlso costo = 0 Then
                    For k As Integer = j - 1 To 0 Step -1
                        Dim p As MovimientoCosto = procesadas(k)
                        If p.Fecha <= corte AndAlso p.CostoUnitario.HasValue AndAlso p.CostoUnitario.Value <> 0 AndAlso p.Tasa.HasValue Then
                            costo = p.CostoUnitario.Value
                            Exit For
                        End If
                    Next
                End If

                Dim abs15 As Double = Redondear15(Math.Abs(costo))
                Dim coincidentes As List(Of MovimientoCosto) = Nothing
                porClave.TryGetValue(ClaveFactura(r.Numero, r.Tipo, r.Fecha.Date), coincidentes)

                If String.Equals(r.Tipo, "Transferencia Enviada", StringComparison.Ordinal) Then
                    Dim importe15 As Double = Redondear15(Math.Abs(costo * cantidadActual))
                    AplicarCuatro(coincidentes, abs15, importe15)
                    Dim rec As List(Of MovimientoCosto) = Nothing
                    recibidasPorClave.TryGetValue(ClaveCompra(r.Numero, r.Fecha.Date), rec)
                    AplicarCuatro(rec, abs15, importe15)
                ElseIf String.Equals(r.Tipo, "Salida Bodega", StringComparison.Ordinal) Then
                    Dim importe15 As Double = Redondear15(Math.Abs(costo * cantidadActual))
                    AplicarCuatro(coincidentes, abs15, importe15)
                Else
                    If coincidentes IsNot Nothing Then
                        For Each t As MovimientoCosto In coincidentes
                            t.CostoUnitario = abs15
                        Next
                    End If
                End If
            Next

            i = j
        End While

        Return res
    End Function

    ' ------------------------------------------------------------------
    ' Utilitarios
    ' ------------------------------------------------------------------

    Private Shared Sub AplicarCuatro(ByVal filas As List(Of MovimientoCosto), ByVal costo As Double, ByVal importe As Double)
        If filas Is Nothing Then Return
        For Each t As MovimientoCosto In filas
            t.CostoUnitario = costo
            t.PrecioUnitario = costo
            t.PrecioNeto = costo
            t.Importe = importe
        Next
    End Sub

    Private Shared Function CambioAlgo(ByVal m As MovimientoCosto) As Boolean
        Return RepositorioMovimientos.Distinto(m.CostoUnitario, m.OriginalCostoUnitario) _
            OrElse RepositorioMovimientos.Distinto(m.PrecioUnitario, m.OriginalPrecioUnitario) _
            OrElse RepositorioMovimientos.Distinto(m.PrecioNeto, m.OriginalPrecioNeto) _
            OrElse RepositorioMovimientos.Distinto(m.Importe, m.OriginalImporte)
    End Function

    ''' <summary>Equivale a escribir el valor como texto con Double.ToString() (15 digitos) y que SQL lo lea.</summary>
    Private Shared Function Redondear15(ByVal v As Double) As Double
        If Double.IsNaN(v) OrElse Double.IsInfinity(v) Then Return v
        Return Double.Parse(v.ToString("G15", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)
    End Function

    Private Shared Function EsTipo(ByVal tipo As String, ByVal esperado As String) As Boolean
        Return tipo IsNot Nothing AndAlso String.Equals(tipo.TrimEnd(), esperado, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function Norm(ByVal s As String) As String
        If s Is Nothing Then Return ""
        Return s.TrimEnd().ToUpperInvariant()
    End Function

    Private Shared Function ClaveFactura(ByVal numero As String, ByVal tipo As String, ByVal fecha As Date) As String
        Return Norm(numero) & "|" & Norm(tipo) & "|" & fecha.Date.Ticks.ToString(CultureInfo.InvariantCulture)
    End Function

    Private Shared Function ClaveCompra(ByVal numero As String, ByVal fecha As Date) As String
        Return Norm(numero) & "|" & fecha.Date.Ticks.ToString(CultureInfo.InvariantCulture)
    End Function

    Private Shared Sub AgregarAClave(ByVal d As Dictionary(Of String, List(Of MovimientoCosto)), ByVal clave As String, ByVal m As MovimientoCosto)
        Dim l As List(Of MovimientoCosto) = Nothing
        If Not d.TryGetValue(clave, l) Then
            l = New List(Of MovimientoCosto)
            d(clave) = l
        End If
        l.Add(m)
    End Sub

End Class
