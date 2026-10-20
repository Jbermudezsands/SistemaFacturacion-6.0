Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Linq

'=====================================================================================================
'  CUENTAS POR COBRAR - RESULTADOS
'  Los DataTable conservan EXACTAMENTE los nombres y el orden de columnas que ya usan el grid y los
'  reportes (ArepEstadoCuentas, ArepEstadoCuentasClientes, ArepSaldoClientes, ArepSaldoClientesHistoricos).
'=====================================================================================================
Public Class CxCResultado

    Public Sub New(filtro As CxCFiltro)
        Me.Filtro = filtro
    End Sub

    Public ReadOnly Property Filtro As CxCFiltro
    Public ReadOnly Property Lineas As New List(Of CxCLinea)
    Public ReadOnly Property Advertencias As New List(Of String)

    Public ReadOnly Property TotalCargos As Decimal
        Get
            Return Lineas.Sum(Function(l) l.Monto)
        End Get
    End Property

    ''' <summary>Recibos + pagos de contado (antes los pagos de contado no se sumaban y el saldo final no cuadraba).</summary>
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

    ''' <summary>Cargos - Abonos + NB - NC + Mora. Siempre es igual a la suma de la columna Total.</summary>
    Public ReadOnly Property SaldoFinal As Decimal
        Get
            Return TotalCargos - TotalAbonos + TotalNotasDebito - TotalNotasCredito + TotalMora
        End Get
    End Property

    '-------------------------------------------------------------------------------------------------
    ' Tabla "TotalVentas" con las mismas 14 columnas y el mismo orden que antes.
    '-------------------------------------------------------------------------------------------------
    Public Function ToDataTable(Optional excluirCero As Boolean = False) As DataTable
        Dim t = CrearTablaSaldos()
        t.BeginLoadData()
        For Each l As CxCLinea In Lineas
            If excluirCero AndAlso l.Saldo = 0D Then Continue For
            t.Rows.Add(l.FechaFactura, l.NumeroFactura, l.NumeroRecibo, l.NotaDebito, l.MontoNota, l.Monto,
                       l.FechaVence, l.Abono, l.Saldo, l.Moratorio, l.Dias, l.Total, l.CodCliente, l.NombreCliente)
        Next
        t.EndLoadData()
        t.AcceptChanges()
        Return t
    End Function

    Public Function ToDataSet(Optional excluirCero As Boolean = False) As DataSet
        Dim ds As New DataSet("CuentasXCobrar")
        ds.Tables.Add(ToDataTable(excluirCero))
        Return ds
    End Function

    ''' <summary>Equivalente a dvCtasxCobrar: vista ordenada por cliente o por fecha.</summary>
    Public Function ToDataView(excluirCero As Boolean, ordenarPorCliente As Boolean) As DataView
        Dim dv As New DataView(ToDataTable(excluirCero))
        dv.Sort = If(ordenarPorCliente, "Cod_Cliente, Fecha_Factura, Numero_Factura", "Fecha_Factura, Numero_Factura")
        Return dv
    End Function

    Public Shared Function CrearTablaSaldos() As DataTable
        Dim t As New DataTable("TotalVentas")
        t.Columns.Add("Fecha_Factura", GetType(Date))
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
        t.Columns.Add("Cod_Cliente", GetType(String))
        t.Columns.Add("Nombre_Cliente", GetType(String))
        Return t
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Filas de los reportes
'-----------------------------------------------------------------------------------------------------
Public Class CxCEstadoCuentaFila
    Public Property CodCliente As String
    Public Property NombreCliente As String
    Public Property Fecha As Date
    Public Property Numero As String
    Public Property TipoDocumento As String
    Public Property Concepto As String
    Public Property SaldoInicial As Decimal
    Public Property Debito As Decimal
    Public Property Credito As Decimal
    Public Property Balance As Decimal
End Class

Public Class CxCSaldoClienteFila
    Public Property CodCliente As String
    Public Property NombreCliente As String
    Public Property SaldoInicial As Decimal
    Public Property Debito As Decimal
    Public Property Credito As Decimal

    Public ReadOnly Property SaldoFinal As Decimal
        Get
            Return SaldoInicial + Debito - Credito
        End Get
    End Property
End Class

Public Class CxCAntiguedadFila
    Public Property CodCliente As String
    Public Property NombreCliente As String
    Public Property CodVendedor As String
    Public Property NombreVendedor As String
    Public Property Corriente As Decimal
    Public Property Dias30 As Decimal
    Public Property Dias60 As Decimal
    Public Property Dias90 As Decimal
    Public Property Mas90 As Decimal

    Public ReadOnly Property SaldoFinal As Decimal
        Get
            Return Corriente + Dias30 + Dias60 + Dias90 + Mas90
        End Get
    End Property
End Class

''' <summary>Convierte las filas a las tablas que ya consumen los reportes de ActiveReports.</summary>
Public NotInheritable Class CxCTablas
    Private Sub New()
    End Sub

    ''' <summary>Columnas de ArepEstadoCuentasClientes.</summary>
    Public Shared Function EstadoCuenta(filas As IEnumerable(Of CxCEstadoCuentaFila)) As DataTable
        Dim t As New DataTable("TotalVentas")
        t.Columns.Add("Cod_Cliente", GetType(String))
        t.Columns.Add("Nombre_Cliente", GetType(String))
        t.Columns.Add("Fecha", GetType(Date))
        t.Columns.Add("Numero", GetType(String))
        t.Columns.Add("TipoDocumento", GetType(String))
        t.Columns.Add("Concepto", GetType(String))
        t.Columns.Add("SaldoInicial", GetType(Decimal))
        t.Columns.Add("Debito", GetType(Decimal))
        t.Columns.Add("Credito", GetType(Decimal))
        t.Columns.Add("Balance", GetType(Decimal))
        For Each f As CxCEstadoCuentaFila In filas
            t.Rows.Add(f.CodCliente, f.NombreCliente, f.Fecha, f.Numero, f.TipoDocumento, f.Concepto, f.SaldoInicial, f.Debito, f.Credito, f.Balance)
        Next
        Return t
    End Function

    ''' <summary>Columnas de ArepSaldoClientes.</summary>
    Public Shared Function SaldosClientes(filas As IEnumerable(Of CxCSaldoClienteFila)) As DataTable
        Dim t As New DataTable("TotalVentas")
        t.Columns.Add("Cod_Cliente", GetType(String))
        t.Columns.Add("Nombre_Cliente", GetType(String))
        t.Columns.Add("SaldoInicial", GetType(Decimal))
        t.Columns.Add("Debito", GetType(Decimal))
        t.Columns.Add("Credito", GetType(Decimal))
        t.Columns.Add("SaldoFinal", GetType(Decimal))
        For Each f As CxCSaldoClienteFila In filas
            t.Rows.Add(f.CodCliente, f.NombreCliente, f.SaldoInicial, f.Debito, f.Credito, f.SaldoFinal)
        Next
        Return t
    End Function

    ''' <summary>Columnas de ArepSaldoClientesHistoricos.</summary>
    Public Shared Function Antiguedad(filas As IEnumerable(Of CxCAntiguedadFila)) As DataTable
        Dim t As New DataTable("TotalVentas")
        t.Columns.Add("Cod_Cliente", GetType(String))
        t.Columns.Add("Nombre_Cliente", GetType(String))
        t.Columns.Add("Corriente", GetType(Decimal))
        t.Columns.Add("30Dias", GetType(Decimal))
        t.Columns.Add("60Dias", GetType(Decimal))
        t.Columns.Add("90Dias", GetType(Decimal))
        t.Columns.Add("mas90", GetType(Decimal))
        t.Columns.Add("SaldoFinal", GetType(Decimal))
        t.Columns.Add("Orden", GetType(String))
        t.Columns.Add("NombreVendedor", GetType(String))
        For Each f As CxCAntiguedadFila In filas
            t.Rows.Add(f.CodCliente, f.NombreCliente, f.Corriente, f.Dias30, f.Dias60, f.Dias90, f.Mas90, f.SaldoFinal, "01", f.NombreVendedor)
        Next
        Return t
    End Function
End Class
