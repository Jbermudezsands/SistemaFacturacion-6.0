Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic

'=====================================================================================================
'  CUENTAS POR COBRAR - MODELOS
'  Tipos compartidos por el formulario de Cuentas x Cobrar, FrmReportes y FrmAjustarTodos.
'  Todos los montos se manejan en Decimal y se redondean UNA sola vez por documento (DineroCxC).
'=====================================================================================================

Public Enum MonedaCxC
    Cordobas = 0
    Dolares = 1
End Enum

''' <summary>Campo de Clientes que se usa para el filtro "Departamento" de los reportes.</summary>
Public Enum CampoZonaCxC
    Departamento = 0
    Municipio = 1
End Enum

Public Enum TipoMovimientoCxC
    Factura = 1
    NotaDebito = 2
    Recibo = 3
    NotaCredito = 4
    PagoContado = 5
End Enum

Public Enum TipoLineaCxC
    Factura = 1
    NotaDebitoSinFactura = 2
    NotaCreditoSinFactura = 3
    ReciboSinFactura = 4
End Enum

'-----------------------------------------------------------------------------------------------------
' Redondeo y monedas: el único lugar donde se decide cómo se redondea.
'-----------------------------------------------------------------------------------------------------
Public NotInheritable Class DineroCxC
    Private Sub New()
    End Sub

    Public Const Decimales As Integer = 2
    Public Const FormatoMonto As String = "##,##0.00"

    ''' <summary>Redondeo comercial (0.005 -> 0.01), igual que ROUND() de SQL Server.</summary>
    Public Shared Function Redondear(valor As Decimal) As Decimal
        Return Math.Round(valor, Decimales, MidpointRounding.AwayFromZero)
    End Function

    Public Shared Function MonedaDesdeTexto(texto As String) As MonedaCxC
        If texto Is Nothing Then Return MonedaCxC.Cordobas
        Dim t = texto.Trim().ToUpperInvariant()
        If t.StartsWith("DOL") OrElse t.StartsWith("DÓL") OrElse t = "US$" OrElse t = "USD" OrElse t = "$" Then
            Return MonedaCxC.Dolares
        End If
        Return MonedaCxC.Cordobas
    End Function

    Public Shared Function MonedaTexto(moneda As MonedaCxC) As String
        Return If(moneda = MonedaCxC.Dolares, "Dolares", "Cordobas")
    End Function

    Public Shared Function Formatear(valor As Decimal) As String
        Return valor.ToString(FormatoMonto)
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Tasas de cambio cargadas una sola vez por cálculo (antes: una consulta por documento).
'-----------------------------------------------------------------------------------------------------
Public Class TasaCambioCache
    Private ReadOnly _tasas As New Dictionary(Of Date, Decimal)
    Private ReadOnly _faltantes As New SortedSet(Of Date)

    Public Sub Agregar(fecha As Date, tasa As Decimal)
        If tasa > 0D Then _tasas(fecha.Date) = tasa
    End Sub

    Public ReadOnly Property Cantidad As Integer
        Get
            Return _tasas.Count
        End Get
    End Property

    Public Function TryObtener(fecha As Date, ByRef tasa As Decimal) As Boolean
        If _tasas.TryGetValue(fecha.Date, tasa) Then Return True
        _faltantes.Add(fecha.Date)
        tasa = 0D
        Return False
    End Function

    ''' <summary>Fechas que se necesitaron para convertir y que no existen en TasaCambio.</summary>
    Public Function FechasSinTasa() As List(Of Date)
        Return New List(Of Date)(_faltantes)
    End Function

    Public Sub LimpiarFaltantes()
        _faltantes.Clear()
    End Sub

    ''' <summary>
    ''' Convierte un monto a la moneda destino con la tasa de la fecha del documento y lo redondea a 2 decimales.
    ''' Si no hay tasa para esa fecha devuelve 0 (igual que antes) y la fecha queda registrada en FechasSinTasa.
    ''' </summary>
    Public Function Convertir(monto As Decimal, origen As MonedaCxC, destino As MonedaCxC, fecha As Date) As Decimal
        If monto = 0D Then Return 0D
        If origen = destino Then Return DineroCxC.Redondear(monto)
        Dim tasa As Decimal
        If Not TryObtener(fecha, tasa) Then Return 0D
        If origen = MonedaCxC.Dolares Then
            Return DineroCxC.Redondear(monto * tasa)
        Else
            Return DineroCxC.Redondear(monto / tasa)
        End If
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Normalización de llaves: SQL Server compara sin mayúsculas y sin espacios al final ("1144      ").
'-----------------------------------------------------------------------------------------------------
Friend NotInheritable Class ClaveCxC
    Private Sub New()
    End Sub

    Public Shared Function Normalizar(valor As String) As String
        If valor Is Nothing Then Return ""
        Return valor.Trim().ToUpperInvariant()
    End Function

    Public Shared Function Componer(ParamArray partes() As String) As String
        Return String.Join("|", partes)
    End Function

    Public Shared Function Fecha(valor As Date) As String
        Return valor.ToString("yyyyMMdd")
    End Function

    ''' <summary>Números de factura que en el sistema significan "sin factura".</summary>
    Public Shared Function EsSinFactura(numeroFactura As String) As Boolean
        Dim n = Normalizar(numeroFactura)
        Return n = "" OrElse n = "0" OrElse n = "0000"
    End Function

    ''' <summary>True si el "número de factura" de un recibo es en realidad el pago de una nota ("NB00012").</summary>
    Public Shared Function EsPagoNota(numeroFactura As String) As Boolean
        Dim n = Normalizar(numeroFactura)
        Return n.Length > 2 AndAlso n.StartsWith("NB", StringComparison.Ordinal)
    End Function

    ''' <summary>Número de la nota de débito que paga un recibo, sin el prefijo "NB".</summary>
    Public Shared Function NumeroNotaPagada(numeroFactura As String, numeroNota As String) As String
        Dim n = Normalizar(numeroNota)
        If n = "" AndAlso EsPagoNota(numeroFactura) Then n = Normalizar(numeroFactura)
        If n.Length > 2 AndAlso n.StartsWith("NB", StringComparison.Ordinal) Then n = n.Substring(2)
        Return n
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Documentos tal como vienen de la base de datos (moneda original, sin convertir).
'-----------------------------------------------------------------------------------------------------
Public Class CxCClienteDoc
    Public Property Codigo As String
    Public Property Nombre As String
    ''' <summary>Clientes.InteresMoratorio tal como está guardado (porcentaje diario).</summary>
    Public Property InteresMoratorio As Decimal
End Class

Public Class CxCFacturaDoc
    Public Property Numero As String
    Public Property Fecha As Date
    Public Property FechaVence As Date
    Public Property Moneda As MonedaCxC
    Public Property CodCliente As String
    Public Property CodVendedor As String
    Public Property NombreVendedor As String
    ''' <summary>SubTotal + IVA en la moneda de la factura.</summary>
    Public Property Monto As Decimal
End Class

Public Class CxCReciboDoc
    Public Property CodRecibo As String
    Public Property Fecha As Date
    Public Property NumeroFactura As String
    Public Property NumeroNota As String
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
    Public Property CodCliente As String
End Class

Public Class CxCNotaDoc
    Public Property NumeroNota As String
    Public Property Fecha As Date
    Public Property CodigoTipoNota As String
    ''' <summary>NotaDebito.Tipo: "Debito Clientes", "Credito Clientes Dif $", etc.</summary>
    Public Property TipoNota As String
    Public Property NumeroFactura As String
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
    Public Property CodCliente As String
    Public Property Descripcion As String
    Public Property Observaciones As String

    Public ReadOnly Property EsDebito As Boolean
        Get
            Return TipoNota IsNot Nothing AndAlso TipoNota.IndexOf("Debito Clientes", StringComparison.OrdinalIgnoreCase) >= 0
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

Public Class CxCPagoContadoDoc
    Public Property NumeroFactura As String
    Public Property FechaFactura As Date
    Public Property Monto As Decimal
    Public Property Moneda As MonedaCxC
    Public Property CodCliente As String
End Class

''' <summary>Todo lo que se necesita para calcular, cargado en una sola ida a la base de datos.</summary>
Public Class CxCDatos
    Public Property FechaFin As Date
    Public ReadOnly Property Clientes As New Dictionary(Of String, CxCClienteDoc)(StringComparer.Ordinal)
    Public ReadOnly Property Facturas As New List(Of CxCFacturaDoc)
    Public ReadOnly Property Recibos As New List(Of CxCReciboDoc)
    Public ReadOnly Property Notas As New List(Of CxCNotaDoc)
    Public ReadOnly Property PagosContado As New List(Of CxCPagoContadoDoc)
    Public ReadOnly Property Tasas As New TasaCambioCache

    Public Function Cliente(codigo As String) As CxCClienteDoc
        Dim c As CxCClienteDoc = Nothing
        If Clientes.TryGetValue(ClaveCxC.Normalizar(codigo), c) Then Return c
        Return Nothing
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Filtro único para el formulario y todos los reportes.
'-----------------------------------------------------------------------------------------------------
Public Class CxCFiltro
    Public Property FechaFin As Date = Date.Today
    Public Property Moneda As MonedaCxC = MonedaCxC.Cordobas
    Public Property ClienteDesde As String
    Public Property ClienteHasta As String
    Public Property ZonaDesde As String
    Public Property ZonaHasta As String
    Public Property CampoZona As CampoZonaCxC = CampoZonaCxC.Departamento
    Public Property VendedorDesde As String
    Public Property VendedorHasta As String
    ''' <summary>Notas y recibos que no están asociados a una factura (Numero_Factura = '0' / '0000').</summary>
    Public Property IncluirDocumentosSinFactura As Boolean = True

    Public Shared Function PorCliente(codigoCliente As String, fechaFin As Date, moneda As MonedaCxC) As CxCFiltro
        Dim codigo = If(codigoCliente, "").Trim()
        Return New CxCFiltro With {.ClienteDesde = codigo, .ClienteHasta = codigo, .FechaFin = fechaFin.Date, .Moneda = moneda}
    End Function

    Public ReadOnly Property FiltraCliente As Boolean
        Get
            Return Not (String.IsNullOrWhiteSpace(ClienteDesde) AndAlso String.IsNullOrWhiteSpace(ClienteHasta))
        End Get
    End Property

    Public ReadOnly Property FiltraZona As Boolean
        Get
            Return Not (String.IsNullOrWhiteSpace(ZonaDesde) AndAlso String.IsNullOrWhiteSpace(ZonaHasta))
        End Get
    End Property

    Public ReadOnly Property FiltraVendedor As Boolean
        Get
            Return Not (String.IsNullOrWhiteSpace(VendedorDesde) AndAlso String.IsNullOrWhiteSpace(VendedorHasta))
        End Get
    End Property

    Public ReadOnly Property EsUnSoloCliente As Boolean
        Get
            Return FiltraCliente AndAlso ClaveCxC.Normalizar(ClienteDesde) = ClaveCxC.Normalizar(ClienteHasta)
        End Get
    End Property

    Friend Function VendedorEnRango(codigoVendedor As String) As Boolean
        If Not FiltraVendedor Then Return True
        Dim v = ClaveCxC.Normalizar(codigoVendedor)
        If v = "" Then Return False
        Dim desde = ClaveCxC.Normalizar(VendedorDesde)
        Dim hasta = ClaveCxC.Normalizar(VendedorHasta)
        If desde <> "" AndAlso String.CompareOrdinal(v, desde) < 0 Then Return False
        If hasta <> "" AndAlso String.CompareOrdinal(v, hasta) > 0 Then Return False
        Return True
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Movimiento ya convertido a la moneda de consulta. Es la base común del saldo por factura,
' el estado de cuenta, el saldo de clientes y la antigüedad.
'-----------------------------------------------------------------------------------------------------
Public Class CxCMovimiento
    Public Property Tipo As TipoMovimientoCxC
    Public Property CodCliente As String
    Public Property Fecha As Date
    Public Property Numero As String
    Public Property NumeroFactura As String
    Public Property Concepto As String
    Public Property Debito As Decimal
    Public Property Credito As Decimal
    ''' <summary>Línea de saldo a la que pertenece (factura, nota sin factura o recibo sin factura).</summary>
    Public Property ClaveDocumento As String
    Public Property TipoLinea As TipoLineaCxC
End Class

'-----------------------------------------------------------------------------------------------------
' Una fila del grid de Cuentas x Cobrar (equivale a una fila de la tabla "TotalVentas" anterior).
'-----------------------------------------------------------------------------------------------------
Public Class CxCLinea
    Public Property TipoLinea As TipoLineaCxC
    Public Property FechaFactura As Date
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
    Public Property CodCliente As String
    Public Property NombreCliente As String
    Public Property CodVendedor As String
    Public Property NombreVendedor As String
    Public Property MonedaFactura As MonedaCxC

    ''' <summary>Neto de notas (NB - NC), columna "MontoNota".</summary>
    Public ReadOnly Property MontoNota As Decimal
        Get
            Return NotaDebitoMonto - NotaCreditoMonto
        End Get
    End Property

    ''' <summary>En una línea NotaDebitoSinFactura: el número de la nota.</summary>
    Public ReadOnly Property NumeroNotaDebito As String
        Get
            Return If(NotasDebito.Count = 0, "", NotasDebito(0))
        End Get
    End Property

    Friend ReadOnly Property Recibos As New List(Of String)
    Friend ReadOnly Property NotasDebito As New List(Of String)
    Friend ReadOnly Property NotasCredito As New List(Of String)
End Class
