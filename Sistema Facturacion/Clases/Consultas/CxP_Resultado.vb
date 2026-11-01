Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Linq

'=====================================================================================================
'  CUENTAS POR PAGAR - RESULTADOS
'  La tabla "TotalVentas" conserva los nombres de columna que ya usan el grid y ArepEstadoCuentas.
'=====================================================================================================
Public Class CxPResultado

    Public Sub New(filtro As CxPFiltro)
        Me.Filtro = filtro
    End Sub

    Public ReadOnly Property Filtro As CxPFiltro
    Public ReadOnly Property Lineas As New List(Of CxPLinea)
    Public ReadOnly Property Advertencias As New List(Of String)

    ''' <summary>True si faltó alguna tasa de cambio: los montos convertidos de esas fechas salen en 0.</summary>
    Public Property TasasFaltantes As Boolean

    Public ReadOnly Property TotalCargos As Decimal
        Get
            Return Lineas.Sum(Function(l) l.Monto)
        End Get
    End Property

    ''' <summary>Pagos + pagos de contado + devoluciones de compra.</summary>
    Public ReadOnly Property TotalAbonos As Decimal
        Get
            Return Lineas.Sum(Function(l) l.Abono)
        End Get
    End Property

    Public ReadOnly Property TotalNotasDebito As Decimal
        Get
            Return Lineas.Sum(Function(l) l.NotaDebitoMonto)
        End Get
    End Property

    Public ReadOnly Property TotalNotasCredito As Decimal
        Get
            Return Lineas.Sum(Function(l) l.NotaCreditoMonto)
        End Get
    End Property

    Public ReadOnly Property TotalNotasNeto As Decimal
        Get
            Return TotalNotasDebito - TotalNotasCredito
        End Get
    End Property

    Public ReadOnly Property TotalSaldo As Decimal
        Get
            Return Lineas.Sum(Function(l) l.Saldo)
        End Get
    End Property

    Public ReadOnly Property TotalMora As Decimal
        Get
            Return Lineas.Sum(Function(l) l.Moratorio)
        End Get
    End Property

    ''' <summary>Cargos - Abonos - NB + NC + Mora. Siempre es igual a la suma de la columna Total.</summary>
    Public ReadOnly Property SaldoFinal As Decimal
        Get
            Return TotalCargos - TotalAbonos - TotalNotasDebito + TotalNotasCredito + TotalMora
        End Get
    End Property

    Public Function ToDataTable(Optional excluirCero As Boolean = False) As DataTable
        Dim t = CrearTablaSaldos()
        t.BeginLoadData()
        For Each l As CxPLinea In Lineas
            If excluirCero AndAlso l.Saldo = 0D Then Continue For
            t.Rows.Add(l.FechaFactura, l.NumeroCompra, l.NumeroFactura, l.NumeroRecibo, l.NotaDebito, l.MontoNota, l.Monto,
                       l.FechaVence, l.Abono, l.Saldo, l.Moratorio, l.Dias, l.Total, l.Observaciones)
        Next
        t.EndLoadData()
        t.AcceptChanges()
        Return t
    End Function

    Public Function ToDataSet(Optional excluirCero As Boolean = False) As DataSet
        Dim ds As New DataSet("CuentasXPagar")
        ds.Tables.Add(ToDataTable(excluirCero))
        Return ds
    End Function

    Public Function ToDataView(excluirCero As Boolean) As DataView
        Dim dv As New DataView(ToDataTable(excluirCero))
        dv.Sort = "Fecha_Factura, Numero_Compra"
        Return dv
    End Function

    Public Shared Function CrearTablaSaldos() As DataTable
        Dim t As New DataTable("TotalVentas")
        t.Columns.Add("Fecha_Factura", GetType(Date))
        t.Columns.Add("Numero_Compra", GetType(String))
        t.Columns.Add("Numero_Factura", GetType(String))
        t.Columns.Add("Numero_Recibo", GetType(String))
        t.Columns.Add("NotaDebito", GetType(String))
        t.Columns.Add("MontoNota", GetType(Decimal))
        t.Columns.Add("Monto", GetType(Decimal))
        t.Columns.Add("FechaVence", GetType(Date))
        t.Columns.Add("Abono", GetType(Decimal))
        t.Columns.Add("Saldo", GetType(Decimal))
        t.Columns.Add("Moratorio", GetType(Decimal))
        t.Columns.Add("Dias", GetType(Integer))
        t.Columns.Add("Total", GetType(Decimal))
        t.Columns.Add("Observaciones", GetType(String))
        Return t
    End Function
End Class
