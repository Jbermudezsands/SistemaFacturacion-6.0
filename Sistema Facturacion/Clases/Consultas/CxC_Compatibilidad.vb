Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data

'=====================================================================================================
'  CUENTAS POR COBRAR - COMPATIBILIDAD
'  Reemplaza a las funciones anteriores con la MISMA firma, para que FrmAjustarTodos, FrmReportes y
'  cualquier otro llamador sigan funcionando sin cambios, pero usando la lógica nueva.
'
'  IMPORTANTE: borre (o comente) las versiones anteriores de FillDataSetCtaxCobrar y dvCtasxCobrar
'  del módulo donde estaban; si no, el proyecto tendrá dos definiciones con el mismo nombre.
'=====================================================================================================
Module CxC_Compatibilidad

    ''' <summary>
    ''' Campo de Clientes que filtran los combos "CboCodDepartamentoIni/Fin" de FrmReportes.
    ''' El código anterior usaba Municipio en unas ramas y Departamento en otra; ajuste aquí si aplica.
    ''' </summary>
    Public CampoZonaReportesCxC As CampoZonaCxC = CampoZonaCxC.Departamento

    ''' <summary>
    ''' Crea el servicio con la conexión del sistema.
    ''' Ya no se enlaza ActualizaMontoCredito: su UPDATE está comentado, así que por cada factura solo hacía
    ''' 1 a 3 consultas sin guardar nada, y podía mostrar un MsgBox desde el hilo de fondo.
    ''' Si algún día se reactiva MontoCredito, se asigna aquí servicio.AlActualizarSaldoFactura.
    ''' </summary>
    Public Function CrearServicioCxC() As CxCServicio
        Return New CxCServicio(Conexion)
    End Function

    ''' <summary>Filtro de cuentas por cobrar armado con los combos de FrmReportes.</summary>
    Public Function FiltroCxCDesdeReportes(fechaFin As Date, enCordobas As Boolean) As CxCFiltro
        Return New CxCFiltro With {
            .FechaFin = fechaFin.Date,
            .Moneda = If(enCordobas, MonedaCxC.Cordobas, MonedaCxC.Dolares),
            .ClienteDesde = FrmReportes.CmbClientes.Text,
            .ClienteHasta = FrmReportes.CmbClientes2.Text,
            .ZonaDesde = FrmReportes.CboCodDepartamentoIni.Text,
            .ZonaHasta = FrmReportes.CboCodDepartamentoFin.Text,
            .CampoZona = CampoZonaReportesCxC,
            .VendedorDesde = FrmReportes.CmbVendedores.Text,
            .VendedorHasta = FrmReportes.CmbVendedores2.Text
        }
    End Function

    ''' <summary>Muestra las advertencias del cálculo (tasas faltantes, pagos a facturas inexistentes, etc.).</summary>
    Public Sub MostrarAdvertenciasCxC(advertencias As IEnumerable(Of String))
        If advertencias Is Nothing Then Exit Sub
        Dim texto = String.Join(vbCrLf & vbCrLf, advertencias)
        If texto <> "" Then MsgBox(texto, MsgBoxStyle.Exclamation, "Zeus Facturacion - Revise")
    End Sub

    ''' <summary>Misma firma y misma tabla "TotalVentas" que la versión anterior.</summary>
    'Public Function FillDataSetCtaxCobrar(CodigoCliente As String, OptCordobas As Boolean, FechaFin As Date, Proceso As String) As DataSet
    '    If CodigoCliente = "" Then Return Nothing

    '    Dim moneda = If(OptCordobas, MonedaCxC.Cordobas, MonedaCxC.Dolares)
    '    Dim filtro As CxCFiltro
    '    If Proceso = "ReporteCtasxCobrar" Then
    '        filtro = FiltroCxCDesdeReportes(FechaFin, OptCordobas)
    '    Else
    '        filtro = CxCFiltro.PorCliente(CodigoCliente, FechaFin, moneda)
    '    End If

    '    Dim resultado = CrearServicioCxC().CalcularSaldos(filtro)

    '    If Proceso = "CtasxCobrar" Then
    '        FrmCuentasXCobrar.AsignarTotales(resultado)
    '    End If

    '    Return resultado.ToDataSet()
    'End Function

    ''' <summary>Misma firma que la versión anterior.</summary>
    'Public Function dvCtasxCobrar(CodigoCliente As String, OptCordobas As Boolean, FechaFin As Date, Proceso As String, ExcluirCero As Boolean, Ordenar As String) As DataView
    '    Dim ds = FillDataSetCtaxCobrar(CodigoCliente, OptCordobas, FechaFin, Proceso)
    '    If ds Is Nothing OrElse Not ds.Tables.Contains("TotalVentas") Then Return New DataView()

    '    Dim dv As New DataView(ds.Tables("TotalVentas"))
    '    If ExcluirCero Then dv.RowFilter = "Saldo <> 0"
    '    dv.Sort = If(Ordenar = "Cliente", "Cod_Cliente, Fecha_Factura, Numero_Factura", "Fecha_Factura, Numero_Factura")
    '    Return dv
    'End Function

End Module
