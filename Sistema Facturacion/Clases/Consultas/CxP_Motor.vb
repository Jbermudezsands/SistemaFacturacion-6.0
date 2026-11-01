Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

'=====================================================================================================
'  CUENTAS POR PAGAR - MOTOR DE CÁLCULO
'  No toca la base de datos ni la pantalla: recibe CxPDatos y devuelve un CxPResultado.
'
'  Saldo de una compra = Monto - Abonos (pagos + pagos de contado) - Notas de débito + Notas de crédito.
'  (Una nota de débito a un proveedor reduce lo que se le debe; una de crédito lo aumenta.)
'  Todo se convierte a la moneda de consulta con la tasa de la fecha de cada documento.
'=====================================================================================================
Public Class CxPMotor

    Private Const MaxEjemplos As Integer = 10

    Public Function CalcularSaldos(datos As CxPDatos, filtro As CxPFiltro) As CxPResultado
        Dim resultado As New CxPResultado(filtro)
        Dim destino = filtro.Moneda
        Dim tasas = datos.Tasas
        tasas.LimpiarFaltantes()

        Dim lineas As New List(Of CxPLinea)
        Dim porClave As New Dictionary(Of String, CxPLinea)(StringComparer.Ordinal)
        Dim porNumero As New Dictionary(Of String, List(Of CxPCompraDoc))(StringComparer.Ordinal)
        Dim duplicadas As New List(Of String)

        ' Compras a crédito
        For Each c As CxPCompraDoc In datos.Compras
            Dim llaveNumero = ClaveCxC.Normalizar(c.Numero)
            Dim lista As List(Of CxPCompraDoc) = Nothing
            If Not porNumero.TryGetValue(llaveNumero, lista) Then
                lista = New List(Of CxPCompraDoc)
                porNumero.Add(llaveNumero, lista)
            ElseIf lista.Count = 1 Then
                duplicadas.Add(c.Numero.Trim())
            End If
            lista.Add(c)

            Dim linea As New CxPLinea With {
                .TipoLinea = TipoLineaCxP.Compra,
                .FechaFactura = c.Fecha,
                .NumeroCompra = c.Numero,
                .NumeroFactura = NumeroFacturaProveedor(c),
                .FechaVence = c.FechaVence,
                .Observaciones = c.Observaciones,
                .TipoCompra = c.TipoCompra,
                .FechaCompra = c.Fecha,
                .MonedaCompra = c.Moneda,
                .MontoCompraOriginal = DineroCxC.Redondear(c.Monto),
                .Monto = tasas.Convertir(c.Monto, c.Moneda, destino, c.Fecha)
            }
            porClave(ClaveCompra(c)) = linea
            lineas.Add(linea)
        Next

        ' Notas de débito y crédito
        Dim notasHuerfanas As New List(Of String)
        For Each n As CxPNotaDoc In datos.Notas
            Dim monto = If(n.AplicaEn(destino), tasas.Convertir(n.Monto, n.Moneda, destino, n.Fecha), 0D)

            If ClaveCxC.EsSinFactura(n.NumeroCompra) Then
                Dim sinCompra As New CxPLinea With {
                    .TipoLinea = If(n.EsDebito, TipoLineaCxP.NotaDebitoSinCompra, TipoLineaCxP.NotaCreditoSinCompra),
                    .FechaFactura = n.Fecha,
                    .FechaVence = n.Fecha,
                    .NumeroCompra = "0000",
                    .NumeroFactura = "0000",
                    .NumeroRecibo = "0000"
                }
                AplicarNota(sinCompra, n, monto)
                lineas.Add(sinCompra)
            Else
                Dim c = BuscarCompra(porNumero, n.NumeroCompra, n.Fecha)
                If c Is Nothing Then
                    notasHuerfanas.Add(n.NumeroNota.Trim() & " → compra " & n.NumeroCompra.Trim())
                    Continue For
                End If
                Dim linea = porClave(ClaveCompra(c))
                AplicarNota(linea, n, monto)
                If n.AplicaEn(linea.MonedaCompra) Then
                    Dim enMonedaCompra = tasas.Convertir(n.Monto, n.Moneda, linea.MonedaCompra, n.Fecha)
                    linea.PagadoMonedaCompra += If(n.EsDebito, enMonedaCompra, -enMonedaCompra)
                End If
            End If
        Next

        ' Pagos (recibos de pago)
        Dim pagosHuerfanos As New List(Of String)
        For Each p As CxPPagoDoc In datos.Pagos
            Dim monto = tasas.Convertir(p.Monto, p.Moneda, destino, p.Fecha)
            Dim c = BuscarCompra(porNumero, p.NumeroCompra, p.Fecha)
            If c IsNot Nothing Then
                Dim linea = porClave(ClaveCompra(c))
                linea.Abono += monto
                linea.PagadoMonedaCompra += tasas.Convertir(p.Monto, p.Moneda, linea.MonedaCompra, p.Fecha)
                AgregarUnico(linea.Recibos, p.CodRecibo)
            ElseIf EsPagoSinCompra(p.NumeroCompra) Then
                Dim sinCompra As New CxPLinea With {
                    .TipoLinea = TipoLineaCxP.PagoSinCompra,
                    .FechaFactura = p.Fecha,
                    .FechaVence = p.Fecha,
                    .NumeroCompra = p.NumeroCompra,
                    .NumeroFactura = "0000",
                    .Abono = monto
                }
                AgregarUnico(sinCompra.Recibos, p.CodRecibo)
                lineas.Add(sinCompra)
            Else
                pagosHuerfanos.Add(p.CodRecibo.Trim() & " → compra " & p.NumeroCompra.Trim())
            End If
        Next

        ' Pagos de contado (formas de pago de compras a crédito)
        For Each pc As CxPPagoContadoDoc In datos.PagosContado
            Dim linea As CxPLinea = Nothing
            Dim clave = ClaveCxC.Componer("C", ClaveCxC.Normalizar(pc.NumeroCompra), ClaveCxC.Normalizar(pc.TipoCompra), ClaveCxC.Fecha(pc.FechaCompra))
            If Not porClave.TryGetValue(clave, linea) Then Continue For
            linea.Abono += tasas.Convertir(pc.Monto, pc.Moneda, destino, pc.FechaCompra)
            linea.PagadoMonedaCompra += tasas.Convertir(pc.Monto, pc.Moneda, linea.MonedaCompra, pc.FechaCompra)
        Next

        ' Devoluciones de compra: reducen lo que se le debe al proveedor
        For Each d As CxPCompraDoc In datos.Devoluciones
            lineas.Add(New CxPLinea With {
                .TipoLinea = TipoLineaCxP.Devolucion,
                .FechaFactura = d.Fecha,
                .FechaVence = d.Fecha,
                .NumeroCompra = d.Numero,
                .NumeroFactura = NumeroFacturaProveedor(d),
                .Abono = tasas.Convertir(d.NetoPagar, d.Moneda, destino, d.Fecha),
                .Observaciones = "Devolucion de Compras"
            })
        Next

        ' Saldos
        For Each linea As CxPLinea In lineas
            linea.Saldo = linea.Monto - linea.Abono - linea.NotaDebitoMonto + linea.NotaCreditoMonto
            linea.NumeroRecibo = If(linea.TipoLinea = TipoLineaCxP.NotaDebitoSinCompra OrElse linea.TipoLinea = TipoLineaCxP.NotaCreditoSinCompra,
                                    "0000", String.Join(",", linea.Recibos))
            linea.NotaDebito = TextoNotas(linea)

            If linea.Saldo = 0D Then
                linea.Dias = 0
            Else
                linea.Dias = CInt((filtro.FechaFin.Date - linea.FechaVence.Date).TotalDays)
            End If

            ' A los proveedores no se les calcula mora (el formulario anterior tampoco: la tasa era 0).
            linea.Moratorio = 0D
            linea.Total = linea.Saldo + linea.Moratorio
        Next

        resultado.Lineas.AddRange(lineas.
            OrderBy(Function(l) l.FechaFactura).
            ThenBy(Function(l) l.NumeroCompra, StringComparer.OrdinalIgnoreCase))

        ' Advertencias
        Dim sinTasa = tasas.FechasSinTasa()
        If sinTasa.Count > 0 Then
            resultado.TasasFaltantes = True
            resultado.Advertencias.Add(String.Format("Faltan tasas de cambio para {0} fecha(s); esos documentos se calcularon en 0: {1}",
                                                     sinTasa.Count, Ejemplos(sinTasa.Select(Function(d) d.ToString("dd/MM/yyyy")))))
        End If
        If pagosHuerfanos.Count > 0 Then
            resultado.Advertencias.Add(String.Format("{0} pago(s) apuntan a compras que no están en cartera (de contado, de otro proveedor o inexistentes) y no se tomaron en cuenta: {1}",
                                                     pagosHuerfanos.Count, Ejemplos(pagosHuerfanos)))
        End If
        If notasHuerfanas.Count > 0 Then
            resultado.Advertencias.Add(String.Format("{0} nota(s) apuntan a compras que no están en cartera y no se tomaron en cuenta: {1}",
                                                     notasHuerfanas.Count, Ejemplos(notasHuerfanas)))
        End If
        If duplicadas.Count > 0 Then
            resultado.Advertencias.Add(String.Format("Hay números de compra repetidos para el proveedor; los pagos se asignaron a la compra más reciente anterior al pago: {0}",
                                                     Ejemplos(duplicadas)))
        End If

        Return resultado
    End Function

    '-------------------------------------------------------------------------------------------------
    Private Shared Sub AplicarNota(linea As CxPLinea, nota As CxPNotaDoc, monto As Decimal)
        If nota.EsDebito Then
            linea.NotaDebitoMonto += monto
            AgregarUnico(linea.NotasDebito, nota.NumeroNota)
        Else
            linea.NotaCreditoMonto += monto
            AgregarUnico(linea.NotasCredito, nota.NumeroNota)
        End If
    End Sub

    Private Shared Function ClaveCompra(c As CxPCompraDoc) As String
        Return ClaveCxC.Componer("C", ClaveCxC.Normalizar(c.Numero), ClaveCxC.Normalizar(c.TipoCompra), ClaveCxC.Fecha(c.Fecha))
    End Function

    Private Shared Function NumeroFacturaProveedor(c As CxPCompraDoc) As String
        If String.IsNullOrWhiteSpace(c.Referencia) Then Return c.Numero
        Return c.Referencia
    End Function

    ''' <summary>Compra con ese número; si hay varias, la más reciente que no sea posterior al documento.</summary>
    Private Shared Function BuscarCompra(porNumero As Dictionary(Of String, List(Of CxPCompraDoc)), numero As String, fechaDocumento As Date) As CxPCompraDoc
        Dim lista As List(Of CxPCompraDoc) = Nothing
        If Not porNumero.TryGetValue(ClaveCxC.Normalizar(numero), lista) Then Return Nothing
        If lista.Count = 1 Then Return lista(0)

        Dim elegida As CxPCompraDoc = Nothing
        For Each c As CxPCompraDoc In lista
            If c.Fecha.Date <= fechaDocumento.Date AndAlso (elegida Is Nothing OrElse c.Fecha > elegida.Fecha) Then elegida = c
        Next
        Return If(elegida, lista(0))
    End Function

    ''' <summary>Pagos que no son de una compra: número "0" o con una "T" (anticipos / transferencias).</summary>
    Private Shared Function EsPagoSinCompra(numeroCompra As String) As Boolean
        Dim n = ClaveCxC.Normalizar(numeroCompra)
        Return n = "0" OrElse n.Contains("T")
    End Function

    ''' <summary>"NC:12,13 NB:4" (primero las notas de crédito, igual que el formulario anterior).</summary>
    Private Shared Function TextoNotas(linea As CxPLinea) As String
        Dim partes As New List(Of String)
        If linea.NotasCredito.Count > 0 Then partes.Add("NC:" & String.Join(",", linea.NotasCredito))
        If linea.NotasDebito.Count > 0 Then partes.Add("NB:" & String.Join(",", linea.NotasDebito))
        Return String.Join(" ", partes)
    End Function

    Private Shared Sub AgregarUnico(lista As List(Of String), valor As String)
        Dim v = If(valor, "").Trim()
        If v <> "" AndAlso Not lista.Contains(v) Then lista.Add(v)
    End Sub

    Private Shared Function Ejemplos(valores As IEnumerable(Of String)) As String
        Dim todos = valores.ToList()
        Dim texto = String.Join(", ", todos.Take(MaxEjemplos))
        If todos.Count > MaxEjemplos Then texto &= " ..."
        Return texto
    End Function
End Class
