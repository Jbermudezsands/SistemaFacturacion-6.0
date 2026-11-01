Option Strict On
Option Explicit On

Imports System.Collections.Generic

''' <summary>Monedas que maneja el arqueo. Coinciden con el valor guardado en MetodoPago.Moneda.</summary>
Public NotInheritable Class ArqueoMoneda
    Public Const Cordobas As String = "Cordobas"
    Public Const Dolares As String = "Dolares"

    Private Sub New()
    End Sub
End Class

''' <summary>Encabezado de un arqueo (tabla Arqueo).</summary>
Public Class ArqueoCabecera
    Public Property Codigo As String
    Public Property Fecha As Date
    Public Property CodCajero As String
    Public Property FondoApertura As Decimal
    Public Property Observaciones As String
    Public Property PracticadoPor As String

    ''' <summary>Total contado en córdobas (efectivo + cheques/tarjetas, dólares convertidos). Nulo mientras no se ha grabado.</summary>
    Public Property TotalCordobasDolares As Decimal?

    ''' <summary>Monto que debió recibirse según facturas y recibos. Nulo mientras no se ha grabado.</summary>
    Public Property ValorFacturas As Decimal?

    ''' <summary>Efectivo esperado y tasa capturados al iniciar el arqueo. Nulo en arqueos anteriores a esa captura.</summary>
    Public Property EfectivoEsperado As ArqueoEfectivoEsperado

    ''' <summary>Un arqueo grabado ya no se modifica; solo uno iniciado y aún no grabado admite cambios.</summary>
    Public ReadOnly Property EsEditable As Boolean
        Get
            Return Not ValorFacturas.HasValue
        End Get
    End Property
End Class

''' <summary>Renglón del conteo de efectivo por denominación (tabla Detalle_Arqueo).</summary>
Public Class ArqueoDenominacion
    Public Property Moneda As String
    Public Property IdDenominacion As Integer
    Public Property Valor As Decimal
    Public Property Cantidad As Decimal

    ''' <summary>Siempre se recalcula como Valor x Cantidad; no se confía en el monto digitado en pantalla.</summary>
    Public ReadOnly Property Monto As Decimal
        Get
            Return ArqueoCalculadora.CalcularMonto(Valor, Cantidad)
        End Get
    End Property
End Class

Public Enum ArqueoOrigenPago
    Factura = 1
    Recibo = 2
End Enum

''' <summary>Pago no efectivo (cheque, tarjeta, transferencia) de una factura o recibo pendiente de arquear.</summary>
Public Class ArqueoPagoDiferido
    Public Property Origen As ArqueoOrigenPago
    Public Property Numero As String
    Public Property FechaDocumento As Date
    Public Property Moneda As String
    Public Property NombrePago As String
    Public Property NumeroTarjeta As String
    Public Property FechaVence As Date?
    Public Property Monto As Decimal

    ''' <summary>Referencia que se guarda en Detalle_ArqueoCheque.NumeroFactura: "Fact" o "Rec" + número.</summary>
    Public ReadOnly Property Documento As String
        Get
            If Origen = ArqueoOrigenPago.Recibo Then
                Return "Rec" & Numero
            End If
            Return "Fact" & Numero
        End Get
    End Property
End Class

''' <summary>Efectivo que el sistema espera haber recibido del cajero (facturas y recibos pendientes de arquear).</summary>
Public Class ArqueoEfectivoEsperado
    Public Property EfectivoCordobas As Decimal
    Public Property EfectivoDolares As Decimal
    Public Property TasaCambio As Decimal
End Class

''' <summary>Datos que alimentan el cálculo del arqueo.</summary>
Public Class ArqueoEntradaCalculo
    Public Property FondoApertura As Decimal
    Public Property TasaCambio As Decimal
    Public Property EfectivoEsperadoCordobas As Decimal
    Public Property EfectivoEsperadoDolares As Decimal
    Public Property ChequesCordobas As Decimal
    Public Property ChequesDolares As Decimal

    Private ReadOnly _denominacionesCordobas As New List(Of ArqueoDenominacion)()
    Private ReadOnly _denominacionesDolares As New List(Of ArqueoDenominacion)()

    Public ReadOnly Property DenominacionesCordobas As List(Of ArqueoDenominacion)
        Get
            Return _denominacionesCordobas
        End Get
    End Property

    Public ReadOnly Property DenominacionesDolares As List(Of ArqueoDenominacion)
        Get
            Return _denominacionesDolares
        End Get
    End Property
End Class

''' <summary>Resultado del cálculo del arqueo. Todos los montos están redondeados a 2 decimales.</summary>
Public Class ArqueoResumen
    Public Property TasaCambio As Decimal
    Public Property FondoApertura As Decimal

    ' Conteo físico
    Public Property EfectivoContadoCordobas As Decimal
    Public Property EfectivoContadoDolares As Decimal
    Public Property ChequesCordobas As Decimal
    Public Property ChequesDolares As Decimal

    ' Lo que el sistema espera (facturas + recibos)
    Public Property EfectivoEsperadoCordobas As Decimal
    Public Property EfectivoEsperadoDolares As Decimal

    ''' <summary>Total contado expresado en córdobas.</summary>
    Public Property TotalContado As Decimal

    ''' <summary>Total que debió recibirse en córdobas, incluyendo el fondo de apertura.</summary>
    Public Property TotalEsperado As Decimal

    ''' <summary>TotalEsperado - TotalContado. Positivo = faltante, negativo = sobrante.</summary>
    Public Property Diferencia As Decimal

    ''' <summary>Hay montos en dólares y no existe tasa de cambio para la fecha: los totales no son confiables.</summary>
    Public Property FaltaTasaCambio As Boolean
End Class

''' <summary>Datos de la empresa para el encabezado del reporte.</summary>
Public Class ArqueoEmpresa
    Public Property Nombre As String
    Public Property Direccion As String
    Public Property Ruc As String
    Public Property RutaLogo As String
End Class
