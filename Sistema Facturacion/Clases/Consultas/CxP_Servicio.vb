Option Strict On
Option Explicit On
Option Infer On

Imports System.Data

'=====================================================================================================
'  CUENTAS POR PAGAR - SERVICIO (punto de entrada único)
'
'     Dim cxp As New CxPServicio(Conexion)
'     Dim r = cxp.CalcularSaldos(CxPFiltro.PorProveedor("P001", Today, MonedaCxC.Cordobas))
'     r.SaldoFinal, r.TotalCargos, r.ToDataView(True) ...
'
'  Es seguro llamarlo desde un hilo de fondo (BackgroundWorker): no toca controles.
'=====================================================================================================
Public Class CxPServicio

    Private ReadOnly _repositorio As CxPRepositorio
    Private ReadOnly _motor As New CxPMotor()

    Public Sub New(cadenaConexion As String)
        _repositorio = New CxPRepositorio(cadenaConexion)
    End Sub

    Public ReadOnly Property Repositorio As CxPRepositorio
        Get
            Return _repositorio
        End Get
    End Property

    ''' <summary>
    ''' Saldo por compra del proveedor. Con actualizarMontoCredito se guarda en Compras lo pagado y el
    ''' saldo a crédito (como hacía el formulario anterior); si faltan tasas de cambio no se guarda nada,
    ''' para no grabar montos convertidos en 0.
    ''' </summary>
    Public Function CalcularSaldos(filtro As CxPFiltro, Optional actualizarMontoCredito As Boolean = False) As CxPResultado
        If filtro Is Nothing Then Throw New ArgumentNullException(NameOf(filtro))
        If String.IsNullOrWhiteSpace(filtro.CodProveedor) Then Throw New ArgumentException("Seleccione un proveedor.", NameOf(filtro))

        Dim datos = _repositorio.Cargar(filtro)
        Dim resultado = _motor.CalcularSaldos(datos, filtro)

        If actualizarMontoCredito Then
            If resultado.TasasFaltantes Then
                resultado.Advertencias.Add("No se actualizó el saldo a crédito de las compras (Compras.MontoCredito) porque faltan tasas de cambio.")
            Else
                Try
                    _repositorio.ActualizarMontoCredito(resultado.Lineas)
                Catch ex As Exception
                    resultado.Advertencias.Add("No se pudo actualizar el saldo a crédito de las compras: " & ex.Message)
                End Try
            End If
        End If

        Return resultado
    End Function

    Public Function ListarProveedores() As DataTable
        Return _repositorio.ListarProveedores()
    End Function

    Public Function ObtenerEmpresa() As CxPEmpresa
        Return _repositorio.ObtenerEmpresa()
    End Function
End Class
