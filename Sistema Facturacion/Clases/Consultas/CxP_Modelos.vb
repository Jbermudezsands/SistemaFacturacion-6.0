Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic

'=====================================================================================================
'  CUENTAS POR PAGAR - MODELOS
'  Comparte con Cuentas x Cobrar el manejo de monedas, redondeo, tasas de cambio y normalización de
'  llaves (MonedaCxC, DineroCxC, TasaCambioCache, ClaveCxC). Los montos se manejan en Decimal y se
'  redondean UNA sola vez por documento.
'=====================================================================================================

Public Enum TipoMovimientoCxP
    Compra = 1
    NotaDebito = 2
    Pago = 3
    NotaCredito = 4
    PagoContado = 5
    Devolucion = 6
End Enum

Public Enum TipoLineaCxP
    Compra = 1
    NotaDebitoSinCompra = 2
    NotaCreditoSinCompra = 3
    PagoSinCompra = 4
    Devolucion = 5
End Enum

'-----------------------------------------------------------------------------------------------------
' Documentos tal como vienen de la base de datos (moneda original, sin convertir).
'-----------------------------------------------------------------------------------------------------
Public Class CxPProveedorDoc
    Public Property Codigo As String
    Public Property Nombre As String
End Class

Public Class CxPCompraDoc
    Public Property Numero As String
    Public Property TipoCompra As String
    Public Property Fecha As Date
    Public Property FechaVence As Date
    Public Property Moneda As MonedaCxC
    Public Property CodProveedor As String
    ''' <summary>Su_Referencia: número de factura del proveedor (vacío si no se digitó).</summary>
    Public Property Referencia As String
    Public Property Observaciones As String
    ''' <summary>SubTotal + IVA en la moneda de la compra.</summary>
    Public Property Monto As Decimal
    ''' <summary>NetoPagar: monto de las devoluciones de compra.</summary>
    Public Property NetoPagar As Decimal
End Class

Public Class CxPPagoDoc
    Public Property CodRecibo As String
    Public Property Fecha As Date
    Public Property NumeroCompra As String
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
    Public Property CodProveedor As String
End Class

Public Class CxPNotaDoc
    Public Property NumeroNota As String
    Public Property Fecha As Date
    Public Property CodigoTipoNota As String
    ''' <summary>NotaDebito.Tipo: "Debito Proveedores", "Credito Proveedores Dif $", etc.</summary>
    Public Property TipoNota As String
    Public Property NumeroCompra As String
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
    Public Property CodProveedor As String

    Public ReadOnly Property EsDebito As Boolean
        Get
            Return TipoNota IsNot Nothing AndAlso TipoNota.IndexOf("Debito Proveedores", StringComparison.OrdinalIgnoreCase) >= 0
        End Get
    End Property

    ''' <summary>
    ''' Las notas de diferencial cambiario solo aplican en su moneda:
    ''' "Dif $" no se cuenta en córdobas y "Dif C$" no se cuenta en dólares.
    ''' </summary>
    Public Function AplicaEn(destino As MonedaCxC) As Boolean
        Dim t = ClaveCxC.Normalizar(TipoNota)
        If destino = MonedaCxC.Cordobas Then
            Return Not t.EndsWith("DIF $")
        Else
            Return Not t.EndsWith("DIF C$")
        End If
    End Function
End Class

Public Class CxPPagoContadoDoc
    Public Property NumeroCompra As String
    Public Property TipoCompra As String
    Public Property FechaCompra As Date
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
End Class

''' <summary>Todo lo que se necesita para calcular, cargado en una sola ida a la base de datos.</summary>
Public Class CxPDatos
    Public Property FechaFin As Date
    Public ReadOnly Property Proveedores As New Dictionary(Of String, CxPProveedorDoc)(StringComparer.Ordinal)
    Public ReadOnly Property Compras As New List(Of CxPCompraDoc)
    Public ReadOnly Property Devoluciones As New List(Of CxPCompraDoc)
    Public ReadOnly Property Pagos As New List(Of CxPPagoDoc)
    Public ReadOnly Property Notas As New List(Of CxPNotaDoc)
    Public ReadOnly Property PagosContado As New List(Of CxPPagoContadoDoc)
    Public ReadOnly Property Tasas As New TasaCambioCache

    Public Function Proveedor(codigo As String) As CxPProveedorDoc
        Dim p As CxPProveedorDoc = Nothing
        If Proveedores.TryGetValue(ClaveCxC.Normalizar(codigo), p) Then Return p
        Return Nothing
    End Function
End Class

''' <summary>Encabezado del estado de cuenta impreso (tabla DatosEmpresa).</summary>
Public Class CxPEmpresa
    Public Property Nombre As String = ""
    Public Property Direccion As String = ""
    Public Property Ruc As String = ""
    Public Property RutaLogo As String = ""
End Class

'-----------------------------------------------------------------------------------------------------
' Filtro del formulario.
'-----------------------------------------------------------------------------------------------------
Public Class CxPFiltro
    Public Property CodProveedor As String
    Public Property FechaFin As Date = Date.Today
    Public Property Moneda As MonedaCxC = MonedaCxC.Cordobas

    Public Shared Function PorProveedor(codigoProveedor As String, fechaFin As Date, moneda As MonedaCxC) As CxPFiltro
        Return New CxPFiltro With {.CodProveedor = If(codigoProveedor, "").Trim(), .FechaFin = fechaFin.Date, .Moneda = moneda}
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Una fila del grid de Cuentas x Pagar (equivale a una fila de la tabla "TotalVentas" anterior).
'-----------------------------------------------------------------------------------------------------
Public Class CxPLinea
    Public Property TipoLinea As TipoLineaCxP
    Public Property FechaFactura As Date
    Public Property NumeroCompra As String
    ''' <summary>Número de factura del proveedor (Su_Referencia) o, si no hay, el número de compra.</summary>
    Public Property NumeroFactura As String
    Public Property NumeroRecibo As String
    Public Property NotaDebito As String
    Public Property Monto As Decimal
    Public Property FechaVence As Date
    Public Property Abono As Decimal
    Public Property NotaDebitoMonto As Decimal
    Public Property NotaCreditoMonto As Decimal
    Public Property Saldo As Decimal
    Public Property Moratorio As Decimal
    Public Property Dias As Integer
    Public Property Total As Decimal
    Public Property Observaciones As String

    ' Datos de la compra para mantener Compras.Pagado / MontoCredito (en la moneda de la compra)
    Public Property TipoCompra As String
    Public Property FechaCompra As Date
    Public Property MonedaCompra As MonedaCxC
    Public Property MontoCompraOriginal As Decimal
    Public Property PagadoMonedaCompra As Decimal

    ''' <summary>Neto de notas (NB - NC), columna "MontoNota".</summary>
    Public ReadOnly Property MontoNota As Decimal
        Get
            Return NotaDebitoMonto - NotaCreditoMonto
        End Get
    End Property

    Friend ReadOnly Property Recibos As New List(Of String)
    Friend ReadOnly Property NotasDebito As New List(Of String)
    Friend ReadOnly Property NotasCredito As New List(Of String)
End Class
