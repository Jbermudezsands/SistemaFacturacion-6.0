Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data

'=====================================================================================================
'  CUENTAS POR COBRAR - SERVICIO (punto de entrada único)
'  Lo usan FrmCuentasXCobrar, FrmReportes, FrmAjustarTodos y los envoltorios de compatibilidad.
'
'     Dim cxc = CrearServicioCxC()                       ' (módulo CxC_Compatibilidad)
'     Dim r = cxc.CalcularSaldos(CxCFiltro.PorCliente("1144", Today, MonedaCxC.Cordobas))
'     r.SaldoFinal, r.TotalCargos, r.ToDataView(True, True) ...
'
'  Es seguro llamarlo desde un hilo de fondo (BackgroundWorker): no toca controles.
'=====================================================================================================
Public Class CxCServicio

    Private ReadOnly _repositorio As CxCRepositorio
    Private ReadOnly _motor As New CxCMotor()

    Public Sub New(cadenaConexion As String)
        _repositorio = New CxCRepositorio(cadenaConexion)
    End Sub

    ''' <summary>
    ''' Se invoca por cada factura después de calcular, para mantener Facturas.MontoCredito
    ''' (antes FillDataSetCtaxCobrar llamaba a ActualizaMontoCredito en el mismo ciclo).
    ''' </summary>
    Public Property AlActualizarSaldoFactura As Action(Of CxCLinea, MonedaCxC)

    Public ReadOnly Property Repositorio As CxCRepositorio
        Get
            Return _repositorio
        End Get
    End Property

    ''' <summary>Saldo por factura (grid de Cuentas x Cobrar y reporte de cuentas por cobrar).</summary>
    Public Function CalcularSaldos(filtro As CxCFiltro, Optional actualizarMontoCredito As Boolean = False) As CxCResultado
        Dim datos = _repositorio.Cargar(filtro)
        Dim resultado = _motor.CalcularSaldos(datos, filtro)

        If actualizarMontoCredito AndAlso AlActualizarSaldoFactura IsNot Nothing Then
            Dim errores = 0
            For Each linea As CxCLinea In resultado.Lineas
                If linea.TipoLinea <> TipoLineaCxC.Factura Then Continue For
                Try
                    AlActualizarSaldoFactura.Invoke(linea, filtro.Moneda)
                Catch
                    errores += 1
                End Try
            Next
            If errores > 0 Then resultado.Advertencias.Add(String.Format("No se pudo actualizar MontoCredito en {0} factura(s).", errores))
        End If

        Return resultado
    End Function

    ''' <summary>Estado de cuenta (ArepEstadoCuentasClientes).</summary>
    Public Function EstadoCuenta(filtro As CxCFiltro, fechaInicio As Date, Optional advertencias As List(Of String) = Nothing) As DataTable
        Dim datos = _repositorio.Cargar(filtro)
        Return CxCTablas.EstadoCuenta(_motor.EstadoCuenta(datos, filtro, fechaInicio, advertencias))
    End Function

    ''' <summary>Saldo inicial, débitos, créditos y saldo final por cliente (ArepSaldoClientes).</summary>
    Public Function SaldosClientes(filtro As CxCFiltro, fechaInicio As Date, Optional advertencias As List(Of String) = Nothing) As DataTable
        Dim datos = _repositorio.Cargar(filtro)
        Return CxCTablas.SaldosClientes(_motor.SaldosClientes(datos, filtro, fechaInicio, advertencias))
    End Function

    ''' <summary>Antigüedad de saldos: corriente, 30, 60, 90 y más de 90 días (ArepSaldoClientesHistoricos).</summary>
    Public Function Antiguedad(filtro As CxCFiltro, Optional advertencias As List(Of String) = Nothing) As DataTable
        Dim resultado = CalcularSaldos(filtro)
        If advertencias IsNot Nothing Then advertencias.AddRange(resultado.Advertencias)
        Return CxCTablas.Antiguedad(_motor.Antiguedad(resultado))
    End Function

    Public Function ListarClientes() As DataTable
        Return _repositorio.ListarClientes()
    End Function
End Class
