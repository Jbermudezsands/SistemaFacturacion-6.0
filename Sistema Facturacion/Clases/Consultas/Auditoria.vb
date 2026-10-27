Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class Auditoria

    ' ============================================================
    ' ENUMERACIONES
    ' ============================================================

    Public Enum SeveridadAuditoria
        Baja = 1
        Media = 2
        Alta = 3
        Informativa = 4
    End Enum

    Public Enum EstadoHallazgo
        Detectado = 1
        Revisado = 2
        Reparable = 3
        Reparado = 4
        NoReparable = 5
        Verificado = 6
    End Enum

    ' ============================================================
    ' CLASE: CONTROL DE AUDITORÍA
    ' ============================================================

    Public Class ControlAuditoria

        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Severidad As SeveridadAuditoria
        Public Property Reparable As Boolean
        Public Property Ejecutado As Boolean
        Public Property CantidadHallazgos As Integer
        Public Property Estado As String

        Public Sub New()

            Codigo = String.Empty
            Descripcion = String.Empty
            Severidad = SeveridadAuditoria.Informativa
            Reparable = False
            Ejecutado = False
            CantidadHallazgos = 0
            Estado = "Pendiente"

        End Sub

    End Class

    ' ============================================================
    ' CLASE: EVIDENCIA
    ' ============================================================

    Public Class EvidenciaAuditoria

        Public Property Documento As String
        Public Property Fecha As DateTime
        Public Property Tipo As String
        Public Property Producto As String

        Public Property Cantidad As Double
        Public Property PrecioUnitario As Double
        Public Property CostoUnitario As Double

        Public Property Motivo As String
        Public Property Accion As String

        Public Property CostoAnterior As Double
        Public Property CostoNuevo As Double
        Public Property CostoEsperado As Double

        Public Property EntradaJustificativa As Boolean
        Public Property DetalleEvidencia As String

        Public Sub New()


            Documento = String.Empty
            Fecha = DateTime.MinValue
            Tipo = String.Empty
            Producto = String.Empty

            Cantidad = 0
            PrecioUnitario = 0
            CostoUnitario = 0

            Motivo = String.Empty
            Accion = String.Empty

            CostoAnterior = 0
            CostoNuevo = 0
            CostoEsperado = 0

            EntradaJustificativa = False
            DetalleEvidencia = String.Empty

        End Sub

    End Class

    ' ============================================================
    ' CLASE: HALLAZGO
    ' ============================================================

    Public Class HallazgoAuditoria

        ' ============================================================
        ' INFORMACIÓN ESPECÍFICA DE TRANSFERENCIAS
        ' ============================================================


        Public Property EsDuplicado As Boolean
        Public Property PuedeEliminar As Boolean
        Public Property IdDetalleRelacionado As Decimal
        Public Property IdDetalleCompra As Decimal
        Public Property IdDetalleTransferencia As Decimal

        Public Property Control As ControlAuditoria

        ' Identificación exacta del detalle de factura
        Public Property IdDetalleFactura As Decimal

        Public Property Codigo As String
        Public Property Severidad As SeveridadAuditoria
        Public Property Descripcion As String

        Public Property Documento As String
        Public Property Fecha As DateTime
        Public Property Tipo As String
        Public Property Producto As String

        Public Property Cantidad As Double
        Public Property PrecioUnitario As Double
        Public Property CostoUnitario As Double

        ' ------------------------------------------------------------
        ' INFORMACIÓN PARA REPARACIÓN
        ' ------------------------------------------------------------

        Public Property CostoPropuesto As Double
        Public Property CostoPropuestoDolar As Double

        ' Líneas que corrige una reparación (0 = una sola línea).
        Public Property LineasAfectadas As Integer
        Public Property TieneCostoPropuesto As Boolean
        Public Property OrigenCosto As String

        ' ------------------------------------------------------------
        ' ESTADO DEL HALLAZGO
        ' ------------------------------------------------------------

        Public Property Estado As EstadoHallazgo
        Public Property Reparable As Boolean

        Public Property Motivo As String
        Public Property Accion As String

        Public Property Evidencia As EvidenciaAuditoria


        Public Sub New()

            EsDuplicado = False
            PuedeEliminar = False
            IdDetalleRelacionado = 0

            IdDetalleCompra = 0
            IdDetalleTransferencia = 0

            Control = Nothing

            IdDetalleFactura = 0

            Codigo = String.Empty
            Descripcion = String.Empty

            Documento = String.Empty
            Fecha = DateTime.MinValue
            Tipo = String.Empty
            Producto = String.Empty

            Cantidad = 0
            PrecioUnitario = 0
            CostoUnitario = 0

            CostoPropuesto = 0
            CostoPropuestoDolar = 0
            TieneCostoPropuesto = False
            OrigenCosto = String.Empty

            Severidad = SeveridadAuditoria.Informativa

            Estado = EstadoHallazgo.Detectado

            Reparable = False

            Motivo = String.Empty
            Accion = String.Empty

            Evidencia = New EvidenciaAuditoria()

        End Sub

    End Class

    ' ============================================================
    ' CLASE: RESULTADO DE LA AUDITORÍA
    ' ============================================================

    Public Class ResultadoAuditoria

        Public Property FechaInicio As DateTime
        Public Property FechaFin As DateTime

        Public Property ControlesEjecutados As Integer
        Public Property TotalControles As Integer

        Public Property TotalHallazgos As Integer
        Public Property TotalReparables As Integer

        Public Property CostosConfiables As Boolean

        Public Property Cancelada As Boolean
        Public Property TieneError As Boolean
        Public Property MensajeError As String

        Public Property Controles As List(Of ControlAuditoria)
        Public Property Hallazgos As List(Of HallazgoAuditoria)

        Public Sub New()

            FechaInicio = DateTime.MinValue
            FechaFin = DateTime.MinValue

            ControlesEjecutados = 0
            TotalControles = 0

            TotalHallazgos = 0
            TotalReparables = 0

            CostosConfiables = False

            Cancelada = False
            TieneError = False
            MensajeError = String.Empty

            Controles = New List(Of ControlAuditoria)()
            Hallazgos = New List(Of HallazgoAuditoria)()

        End Sub

    End Class

    ' ============================================================
    ' CLASE:  DETALLE TRANSFERENCIA TEMPORAL EN MEMORIA
    ' ============================================================
    Private Class DetalleTransferenciaTemporal

        Public Property IdDetalleFactura As Decimal
        Public Property CodProducto As String
        Public Property DescripcionProducto As String
        Public Property Cantidad As Double
        Public Property PrecioUnitario As Double
        Public Property PrecioNeto As Double
        Public Property Importe As Double
        Public Property TasaCambio As Double
        Public Property CostoUnitario As Double
        Public Property NumeroLote As String
        Public Property FechaVence As Object

    End Class


    ' ============================================================
    ' CLASE:  transferenicaenviada
    ' ============================================================
    Private Class TransferenciaEnviadaAuditoria

        Public Property IdDetalleFactura As Decimal

        Public Property Numero As String

        Public Property Fecha As DateTime

        Public Property Tipo As String

        Public Property Producto As String

        Public Property Cantidad As Double

        Public Property PrecioUnitario As Double

        Public Property CostoUnitario As Double

    End Class
    Private Class TransferenciaRecibidaAuditoria

        Public Property IdDetalleCompra As Decimal

        Public Property Numero As String

        Public Property Fecha As DateTime

        Public Property Tipo As String

        Public Property Producto As String

        Public Property Cantidad As Double

        Public Property PrecioUnitario As Double

        Public Property CostoUnitario As Double

        Public Property IdDetalleTransferencia As Decimal

    End Class


    ' ============================================================
    ' EVENTO DE PROGRESO
    ' ============================================================

    Public Event Progreso(ByVal porcentaje As Integer,
                          ByVal mensaje As String)

    ' Motivo de la última reparación rechazada (para mostrarlo al usuario).
    Public Property UltimoError As String = String.Empty

    ' ============================================================
    ' PROPIEDADES
    ' ============================================================

    Private _cancelar As Boolean

    ' ============================================================
    ' CONSTRUCTOR
    ' ============================================================

    Public Sub New()

        _cancelar = False

    End Sub

    ' ============================================================
    ' SOLICITAR CANCELACIÓN
    ' ============================================================

    Public Sub Cancelar()

        _cancelar = True

    End Sub

    ' ============================================================
    ' CONSULTAR CANCELACIÓN
    ' ============================================================

    Private Function DebeCancelar() As Boolean

        Return _cancelar

    End Function

    ' ============================================================
    ' EJECUTAR AUDITORÍA
    ' ============================================================

    Public Function Ejecutar() As ResultadoAuditoria

        Dim resultado As New ResultadoAuditoria()

        resultado.FechaInicio = DateTime.Now

        Try

            Dim controles As List(Of ControlAuditoria) =
            CrearControles()

            resultado.Controles = controles
            resultado.TotalControles = controles.Count

            ' ====================================================
            ' INICIAR AUDITORÍA
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            RaiseEvent Progreso(
            0,
            "Iniciando auditoría...")

            ' ====================================================
            ' COST-001
            ' FACTURAS CON COSTO CERO
            ' ====================================================

            Dim control001 As ControlAuditoria =
            controles.Find(
                Function(c) c.Codigo = "COST-001")

            If control001 IsNot Nothing Then

                If DebeCancelar() Then

                    resultado.Cancelada = True
                    resultado.FechaFin = DateTime.Now

                    Return resultado

                End If

                IniciarPasoProgreso(
                1,
                "Verificando COST-001 - Facturas con costo cero...")

                Dim hallazgos001 As List(Of HallazgoAuditoria) =
                AuditarCost001(control001)

                control001.Ejecutado = True

                control001.CantidadHallazgos =
                hallazgos001.Count

                If hallazgos001.Count > 0 Then

                    control001.Estado =
                    "Revisar"

                Else

                    control001.Estado =
                    "Correcto"

                End If

                resultado.Hallazgos.AddRange(
                hallazgos001)

                resultado.ControlesEjecutados += 1

            End If

            ' ====================================================
            ' COST-002
            ' DEVOLUCIONES CON COSTO CERO
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
            2,
            "Verificando COST-002 - Devoluciones con costo cero...")

            Dim control002 As ControlAuditoria =
            controles.Find(
                Function(c) c.Codigo = "COST-002")

            If control002 IsNot Nothing Then

                Dim hallazgos002 As List(Of HallazgoAuditoria) =
                AuditarCost002(control002)

                control002.Ejecutado = True

                control002.CantidadHallazgos =
                hallazgos002.Count

                If hallazgos002.Count > 0 Then

                    control002.Estado =
                    "Revisar"

                Else

                    control002.Estado =
                    "Correcto"

                End If

                resultado.Hallazgos.AddRange(
                hallazgos002)

                resultado.ControlesEjecutados += 1

            End If

            ' ====================================================
            ' COST-003
            ' SALIDAS DE BODEGA CON COSTO CERO
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
            3,
            "Verificando COST-003 - Salidas de Bodega con costo cero...")

            Dim control003 As ControlAuditoria =
            controles.Find(
                Function(c) c.Codigo = "COST-003")

            If control003 IsNot Nothing Then

                Dim hallazgos003 As List(Of HallazgoAuditoria) =
                AuditarCost003(control003)

                control003.Ejecutado = True

                control003.CantidadHallazgos =
                hallazgos003.Count

                If hallazgos003.Count > 0 Then

                    control003.Estado =
                    "Revisar"

                Else

                    control003.Estado =
                    "Correcto"

                End If

                resultado.Hallazgos.AddRange(
                hallazgos003)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' COST-004
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    4,
    "Verificando COST-004 - Transferencias Enviadas con costo en Precio_Unitario...")

            Dim control004 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "COST-004")

            If control004 IsNot Nothing Then

                Dim hallazgos004 As List(Of HallazgoAuditoria) =
        AuditarCost004(control004)

                control004.Ejecutado = True

                control004.CantidadHallazgos =
        hallazgos004.Count

                If hallazgos004.Count > 0 Then

                    control004.Estado =
            "Revisar"

                Else

                    control004.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgos004)

                resultado.ControlesEjecutados += 1

            End If


            ' ============================================================
            ' COST-005
            ' ============================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    5,
    "Verificando COST-005 - Transferencias Recibidas con Precio_Unitario cero...")

            Dim control005 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "COST-005")

            If control005 IsNot Nothing Then

                Dim hallazgos005 As List(Of HallazgoAuditoria) =
        AuditarCost005(control005)

                control005.Ejecutado = True

                control005.CantidadHallazgos =
        hallazgos005.Count

                If hallazgos005.Count > 0 Then

                    control005.Estado =
            "Revisar"

                Else

                    control005.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgos005)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' TRANS-001
            ' TRANSFERENCIA ENVIADA SIN TRANSFERENCIA RECIBIDA
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    6,
    "Verificando TRANS-001 - Transferencias Enviadas sin Transferencia Recibida...")

            Dim controlTrans001 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "TRANS-001")

            If controlTrans001 IsNot Nothing Then

                Dim hallazgosTrans001 As List(Of HallazgoAuditoria) =
        AuditarTrans001(controlTrans001)

                controlTrans001.Ejecutado = True

                controlTrans001.CantidadHallazgos =
        hallazgosTrans001.Count

                If hallazgosTrans001.Count > 0 Then

                    controlTrans001.Estado =
            "Revisar"

                Else

                    controlTrans001.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgosTrans001)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' TRANS-002
            ' TRANSFERENCIA RECIBIDA SIN TRANSFERENCIA ENVIADA
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    7,
    "Verificando TRANS-002 - Transferencias Recibidas sin Transferencia Enviada...")

            Dim controlTrans002 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "TRANS-002")

            If controlTrans002 IsNot Nothing Then

                Dim hallazgosTrans002 As List(Of HallazgoAuditoria) =
        AuditarTrans002(controlTrans002)

                controlTrans002.Ejecutado = True

                controlTrans002.CantidadHallazgos =
        hallazgosTrans002.Count

                If hallazgosTrans002.Count > 0 Then

                    controlTrans002.Estado =
            "Revisar"

                Else

                    controlTrans002.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgosTrans002)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' TRANS-003
            ' DIFERENCIA DE CANTIDAD ENTRE TRANSFERENCIAS
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    8,
    "Verificando TRANS-003 - Diferencia de cantidad entre transferencias...")

            Dim controlTrans003 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "TRANS-003")

            If controlTrans003 IsNot Nothing Then

                Dim hallazgosTrans003 As List(Of HallazgoAuditoria) =
        AuditarTrans003(controlTrans003)

                controlTrans003.Ejecutado = True

                controlTrans003.CantidadHallazgos =
        hallazgosTrans003.Count

                If hallazgosTrans003.Count > 0 Then

                    controlTrans003.Estado =
            "Revisar"

                Else

                    controlTrans003.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgosTrans003)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' TRANS-004
            ' DIFERENCIA DE COSTO ENTRE TRANSFERENCIAS
            ' ====================================================

            If DebeCancelar() Then

                resultado.Cancelada = True
                resultado.FechaFin = DateTime.Now

                Return resultado

            End If

            IniciarPasoProgreso(
    9,
    "Verificando TRANS-004 - Diferencia de costo entre transferencias...")

            Dim controlTrans004 As ControlAuditoria =
    controles.Find(
        Function(c) c.Codigo = "TRANS-004")

            If controlTrans004 IsNot Nothing Then

                Dim hallazgosTrans004 As List(Of HallazgoAuditoria) =
        AuditarTrans004(controlTrans004)

                controlTrans004.Ejecutado = True

                controlTrans004.CantidadHallazgos =
        hallazgosTrans004.Count

                If hallazgosTrans004.Count > 0 Then

                    controlTrans004.Estado =
            "Revisar"

                Else

                    controlTrans004.Estado =
            "Correcto"

                End If

                resultado.Hallazgos.AddRange(
        hallazgosTrans004)

                resultado.ControlesEjecutados += 1

            End If


            ' ====================================================
            ' DATA-001 A DATA-004
            ' ====================================================

            Dim codigosData As String() = New String() {
                "DATA-001", "DATA-002", "DATA-003", "DATA-004",
                "TC-001", "TC-002",
                "COST-006", "COST-007", "COST-008", "DATA-005"}

            For indiceData As Integer = 0 To codigosData.Length - 1

                Dim codigoData As String = codigosData(indiceData)

                If DebeCancelar() Then

                    resultado.Cancelada = True
                    resultado.FechaFin = DateTime.Now

                    Return resultado

                End If

                Dim codigoActual As String = codigoData

                IniciarPasoProgreso(
                10 + indiceData,
                "Verificando " & codigoActual & "...")

                Dim controlData As ControlAuditoria =
                controles.Find(
                    Function(c) c.Codigo = codigoActual)

                If controlData IsNot Nothing Then

                    Dim hallazgosData As List(Of HallazgoAuditoria)

                    Select Case codigoActual

                        Case "DATA-001"
                            hallazgosData = AuditarData001(controlData)

                        Case "DATA-002"
                            hallazgosData = AuditarData002(controlData)

                        Case "DATA-003"
                            hallazgosData = AuditarData003(controlData)

                        Case "DATA-004"
                            hallazgosData = AuditarData004(controlData)

                        Case "TC-001"
                            hallazgosData = AuditarTc001(controlData)

                        Case "TC-002"
                            hallazgosData = AuditarTc002(controlData)

                        Case "COST-006"
                            hallazgosData = AuditarCost006(controlData)

                        Case "COST-007"
                            hallazgosData = AuditarCost007(controlData)

                        Case "DATA-005"
                            hallazgosData = AuditarData005(controlData)

                        Case Else
                            hallazgosData = AuditarCost008(controlData)

                    End Select

                    controlData.Ejecutado = True

                    controlData.CantidadHallazgos =
                    hallazgosData.Count

                    If hallazgosData.Count > 0 Then

                        controlData.Estado = "Revisar"

                    Else

                        controlData.Estado = "Correcto"

                    End If

                    resultado.Hallazgos.AddRange(hallazgosData)

                    resultado.ControlesEjecutados += 1

                End If

            Next


            ' ====================================================
            ' RESULTADO
            ' ====================================================

            resultado.TotalHallazgos =
            resultado.Hallazgos.Count

            ' ====================================================
            ' CONTAR HALLAZGOS REPARABLES
            ' ====================================================

            resultado.TotalReparables = 0

            For Each hallazgo As HallazgoAuditoria In resultado.Hallazgos

                If hallazgo.Reparable Then

                    resultado.TotalReparables += 1

                End If

            Next

            ' ====================================================
            ' CONFIABILIDAD DE COSTOS
            ' ====================================================

            ' Los hallazgos informativos no restan confiabilidad.

            resultado.CostosConfiables = True

            For Each hallazgo As HallazgoAuditoria In resultado.Hallazgos

                If hallazgo.Severidad <> SeveridadAuditoria.Informativa Then

                    resultado.CostosConfiables = False
                    Exit For

                End If

            Next

            ' ====================================================
            ' FINALIZAR
            ' ====================================================

            RaiseEvent Progreso(
            100,
            "Auditoría finalizada.")

            resultado.FechaFin = DateTime.Now

            Return resultado

        Catch ex As Exception

            resultado.TieneError = True
            resultado.MensajeError = ex.Message
            resultado.FechaFin = DateTime.Now

            Return resultado

        End Try

    End Function


    ' ============================================================
    ' OBTENER CATÁLOGO DE CONTROLES
    ' ============================================================

    Public Function ObtenerControles() As List(Of ControlAuditoria)

        Return CrearControles()

    End Function

    ' ============================================================
    ' CREAR CATÁLOGO DE CONTROLES
    ' ============================================================

    Private Function CrearControles() As List(Of ControlAuditoria)

        Dim controles As New List(Of ControlAuditoria)

        controles.Add(CrearControl(
            "COST-001",
            "Factura con costo cero",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "COST-002",
            "Devolución con costo cero",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "COST-003",
            "Salida Bodega con costo cero",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "COST-004",
            "Transferencia Enviada con costo en Precio_Unitario",
            SeveridadAuditoria.Media,
            False))

        controles.Add(CrearControl(
            "COST-005",
            "Transferencia Recibida con costo en Precio_Unitario",
            SeveridadAuditoria.Media,
            False))

        controles.Add(CrearControl(
            "TRANS-001",
            "Transferencia Enviada sin Transferencia Recibida",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "TRANS-002",
            "Transferencia Recibida sin Transferencia Enviada",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "TRANS-003",
            "Diferencia de cantidad entre transferencias",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "TRANS-004",
            "Diferencia de costo entre transferencias",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "DATA-001",
            "Detalle sin Tipo_Factura",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "DATA-002",
            "Cantidad cero",
            SeveridadAuditoria.Baja,
            False))

        controles.Add(CrearControl(
            "DATA-003",
            "Costo negativo",
            SeveridadAuditoria.Media,
            False))

        controles.Add(CrearControl(
            "DATA-004",
            "Cantidad negativa",
            SeveridadAuditoria.Media,
            False))

        controles.Add(CrearControl(
            "DATA-005",
            "Detalle sin cabecera",
            SeveridadAuditoria.Baja,
            False))

        controles.Add(CrearControl(
            "TC-001",
            "Tasa de cambio inexistente",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "TC-002",
            "Tasa de cambio cero",
            SeveridadAuditoria.Alta,
            False))

        controles.Add(CrearControl(
            "COST-006",
            "Precio cero con costo existente",
            SeveridadAuditoria.Informativa,
            False))

        controles.Add(CrearControl(
            "COST-007",
            "Costo histórico diferente del costo promedio",
            SeveridadAuditoria.Informativa,
            False))

        controles.Add(CrearControl(
            "COST-008",
            "Cambio de costo sin movimiento de entrada justificativo",
            SeveridadAuditoria.Alta,
            True))

        Return controles

    End Function


    ' ============================================================
    ' CREAR CONTROL
    ' ============================================================

    Private Function CrearControl(
        ByVal codigo As String,
        ByVal descripcion As String,
        ByVal severidad As SeveridadAuditoria,
        ByVal reparable As Boolean) As ControlAuditoria

        Dim control As New ControlAuditoria()

        control.Codigo = codigo
        control.Descripcion = descripcion
        control.Severidad = severidad
        control.Reparable = reparable
        control.Ejecutado = False
        control.CantidadHallazgos = 0
        control.Estado = "Pendiente"

        Return control

    End Function


    ' ============================================================
    ' FUNCIONES GENERALES
    ' ============================================================
    Private Function ObtenerCostoReparacion(
    ByVal hallazgo As HallazgoAuditoria) As RstCostoPromedio

        Return CostoPromedioKardex(
        hallazgo.Producto,
        hallazgo.Fecha)

    End Function

    Public Sub CompararCostoKardex(
    ByVal CodigoProducto As String,
    ByVal Fecha As Date)

        Dim costoOriginal As RstCostoPromedio
        Dim costoAuditoria As RstCostoPromedio

        Dim diferenciaCordoba As Double
        Dim diferenciaDolar As Double

        costoOriginal =
        CostoPromedioKardex(
            CodigoProducto,
            Fecha)

        costoAuditoria =
        CostoPromedioAuditoria(
            CodigoProducto,
            Fecha)

        diferenciaCordoba =
        costoOriginal.Costo_Cordoba -
        costoAuditoria.Costo_Cordoba

        diferenciaDolar =
        costoOriginal.Costo_Dolar -
        costoAuditoria.Costo_Dolar

        Debug.Print("========================================")
        Debug.Print("Producto: " & CodigoProducto)
        Debug.Print("Fecha: " & Fecha.ToString("dd/MM/yyyy"))
        Debug.Print("")

        Debug.Print(
        "Kardex C$     : " &
        costoOriginal.Costo_Cordoba.ToString("N6"))

        Debug.Print(
        "Auditoria C$  : " &
        costoAuditoria.Costo_Cordoba.ToString("N6"))

        Debug.Print(
        "Diferencia C$ : " &
        diferenciaCordoba.ToString("N6"))

        Debug.Print("")

        Debug.Print(
        "Kardex US$    : " &
        costoOriginal.Costo_Dolar.ToString("N6"))

        Debug.Print(
        "Auditoria US$ : " &
        costoAuditoria.Costo_Dolar.ToString("N6"))

        Debug.Print(
        "Diferencia US$: " &
        diferenciaDolar.ToString("N6"))

    End Sub

    Private Function ObtenerTipoBitacora(
    ByVal Tipo As String) As String

        If String.IsNullOrWhiteSpace(Tipo) Then
            Return "Doc"
        End If

        Select Case Tipo.Trim()

            Case "Factura"

                Return "Factura"

            Case "Devolucion de Venta"

                Return "Devolucion"

            Case "Salida Bodega"

                Return "SalBodega"

            Case "Transferencia Enviada"

                Return "Trans"

            Case Else

                ' Si aparece un nuevo tipo de documento
                ' utilizamos el tipo original.
                Return Tipo.Trim()

        End Select

    End Function

    Public Function RepararTransferenciaEnviada(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        If hallazgo Is Nothing Then
            Return False
        End If

        If hallazgo.Codigo <> "TRANS-001" Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(hallazgo.Documento) Then
            Return False
        End If

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                ' ========================================================
                ' CARGAR DETALLES EN MEMORIA
                ' ========================================================

                Dim detalles As New List(Of DetalleTransferenciaTemporal)

                Dim sqlDetalles As String =
                "SELECT " &
                "id_Detalle_Factura, " &
                "Cod_Producto, " &
                "Descripcion_Producto, " &
                "Cantidad, " &
                "Precio_Unitario, " &
                "Precio_Neto, " &
                "Importe, " &
                "TasaCambio, " &
                "Costo_Unitario, " &
                "Numero_Lote, " &
                "Fecha_Vence " &
                "FROM Detalle_Facturas " &
                "WHERE Numero_Factura = @Numero " &
                "AND Fecha_Factura = @Fecha " &
                "AND Tipo_Factura = N'Transferencia Enviada' " &
                "ORDER BY id_Detalle_Factura"

                Using cmd As New SqlCommand(
                sqlDetalles,
                cn)

                    cmd.CommandTimeout = 300

                    cmd.Parameters.Add(
                    "@Numero",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Documento

                    cmd.Parameters.Add(
                    "@Fecha",
                    SqlDbType.SmallDateTime).Value =
                    hallazgo.Fecha

                    Using dr As SqlDataReader =
                    cmd.ExecuteReader()

                        While dr.Read()

                            Dim detalle As New DetalleTransferenciaTemporal()

                            If Not IsDBNull(
                            dr("id_Detalle_Factura")) Then

                                detalle.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Factura"))

                            End If

                            If Not IsDBNull(
                            dr("Cod_Producto")) Then

                                detalle.CodProducto =
                                dr("Cod_Producto").ToString()

                            End If

                            If Not IsDBNull(
                            dr("Descripcion_Producto")) Then

                                detalle.DescripcionProducto =
                                dr("Descripcion_Producto").ToString()

                            End If

                            If Not IsDBNull(
                            dr("Cantidad")) Then

                                detalle.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                            End If

                            If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                                detalle.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                            End If

                            If Not IsDBNull(
                            dr("Precio_Neto")) Then

                                detalle.PrecioNeto =
                                Convert.ToDouble(
                                    dr("Precio_Neto"))

                            End If

                            If Not IsDBNull(
                            dr("Importe")) Then

                                detalle.Importe =
                                Convert.ToDouble(
                                    dr("Importe"))

                            End If

                            If Not IsDBNull(
                            dr("TasaCambio")) Then

                                detalle.TasaCambio =
                                Convert.ToDouble(
                                    dr("TasaCambio"))

                            End If

                            If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                                detalle.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                            End If

                            If Not IsDBNull(
                            dr("Numero_Lote")) Then

                                detalle.NumeroLote =
                                dr("Numero_Lote").ToString()

                            End If

                            If Not IsDBNull(
                            dr("Fecha_Vence")) Then

                                detalle.FechaVence =
                                dr("Fecha_Vence")

                            Else

                                detalle.FechaVence =
                                DBNull.Value

                            End If

                            detalles.Add(detalle)

                        End While

                    End Using

                End Using


                ' ========================================================
                ' VALIDAR QUE EXISTAN DETALLES
                ' ========================================================

                If detalles.Count = 0 Then
                    Return False
                End If


                ' ========================================================
                ' LEER ENCABEZADO DE LA TRANSFERENCIA ENVIADA
                ' ========================================================

                Dim moneda As Object = DBNull.Value
                Dim bodega As Object = DBNull.Value
                Dim fechaVencimiento As Object = DBNull.Value
                Dim observaciones As Object = DBNull.Value
                Dim descuento As Object = DBNull.Value
                Dim fechaDescuento As Object = DBNull.Value
                Dim subtotal As Object = DBNull.Value
                Dim iva As Object = DBNull.Value
                Dim pagado As Object = DBNull.Value
                Dim netoPagar As Object = DBNull.Value
                Dim montoCredito As Object = DBNull.Value
                Dim contabilizado As Object = DBNull.Value
                Dim activo As Object = DBNull.Value
                Dim cancelado As Object = DBNull.Value
                Dim exonerado As Object = DBNull.Value
                Dim suReferencia As Object = DBNull.Value
                Dim nuestraReferencia As Object = DBNull.Value
                Dim transferenciaProcesada As Object = DBNull.Value
                Dim marca As Object = DBNull.Value
                Dim codigoProyecto As Object = DBNull.Value
                Dim referencia As Object = DBNull.Value
                Dim fechaHora As Object = DBNull.Value
                Dim tipoProductor As Object = DBNull.Value

                Dim sqlFactura As String =
                "SELECT " &
                "MonedaFactura, " &
                "Cod_Bodega, " &
                "Fecha_Vencimiento, " &
                "Observaciones, " &
                "Descuento, " &
                "Fecha_Descuento, " &
                "SubTotal, " &
                "IVA, " &
                "Pagado, " &
                "NetoPagar, " &
                "MontoCredito, " &
                "Contabilizado, " &
                "Activo, " &
                "Cancelado, " &
                "Exonerado, " &
                "Su_Referencia, " &
                "Nuestra_Referencia, " &
                "TransferenciaProcesada, " &
                "Marca, " &
                "CodigoProyecto, " &
                "Referencia, " &
                "FechaHora, " &
                "TipoProductor " &
                "FROM Facturas " &
                "WHERE Numero_Factura = @Numero " &
                "AND Fecha_Factura = @Fecha " &
                "AND Tipo_Factura = N'Transferencia Enviada'"

                Using cmd As New SqlCommand(
                sqlFactura,
                cn)

                    cmd.CommandTimeout = 300

                    cmd.Parameters.Add(
                    "@Numero",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Documento

                    cmd.Parameters.Add(
                    "@Fecha",
                    SqlDbType.SmallDateTime).Value =
                    hallazgo.Fecha

                    Using dr As SqlDataReader =
                    cmd.ExecuteReader()

                        If Not dr.Read() Then
                            Return False
                        End If

                        If Not IsDBNull(dr("MonedaFactura")) Then
                            moneda = dr("MonedaFactura")
                        End If

                        If Not IsDBNull(dr("Cod_Bodega")) Then
                            bodega = dr("Cod_Bodega")
                        End If

                        If Not IsDBNull(dr("Fecha_Vencimiento")) Then
                            fechaVencimiento = dr("Fecha_Vencimiento")
                        End If

                        If Not IsDBNull(dr("Observaciones")) Then
                            observaciones = dr("Observaciones")
                        End If

                        If Not IsDBNull(dr("Descuento")) Then
                            descuento = dr("Descuento")
                        End If

                        If Not IsDBNull(dr("Fecha_Descuento")) Then
                            fechaDescuento = dr("Fecha_Descuento")
                        End If

                        If Not IsDBNull(dr("SubTotal")) Then
                            subtotal = dr("SubTotal")
                        End If

                        If Not IsDBNull(dr("IVA")) Then
                            iva = dr("IVA")
                        End If

                        If Not IsDBNull(dr("Pagado")) Then
                            pagado = dr("Pagado")
                        End If

                        If Not IsDBNull(dr("NetoPagar")) Then
                            netoPagar = dr("NetoPagar")
                        End If

                        If Not IsDBNull(dr("MontoCredito")) Then
                            montoCredito = dr("MontoCredito")
                        End If

                        If Not IsDBNull(dr("Contabilizado")) Then
                            contabilizado = dr("Contabilizado")
                        End If

                        If Not IsDBNull(dr("Activo")) Then
                            activo = dr("Activo")
                        End If

                        If Not IsDBNull(dr("Cancelado")) Then
                            cancelado = dr("Cancelado")
                        End If

                        If Not IsDBNull(dr("Exonerado")) Then
                            exonerado = dr("Exonerado")
                        End If

                        If Not IsDBNull(dr("Su_Referencia")) Then
                            suReferencia = dr("Su_Referencia")
                        End If

                        If Not IsDBNull(dr("Nuestra_Referencia")) Then
                            nuestraReferencia = dr("Nuestra_Referencia")
                        End If

                        If Not IsDBNull(dr("TransferenciaProcesada")) Then
                            transferenciaProcesada =
                            dr("TransferenciaProcesada")
                        End If

                        If Not IsDBNull(dr("Marca")) Then
                            marca = dr("Marca")
                        End If

                        If Not IsDBNull(dr("CodigoProyecto")) Then
                            codigoProyecto =
                            dr("CodigoProyecto")
                        End If

                        If Not IsDBNull(dr("Referencia")) Then
                            referencia = dr("Referencia")
                        End If

                        If Not IsDBNull(dr("FechaHora")) Then
                            fechaHora = dr("FechaHora")
                        End If

                        If Not IsDBNull(dr("TipoProductor")) Then
                            tipoProductor = dr("TipoProductor")
                        End If

                    End Using

                End Using


                ' ========================================================
                ' INICIAR TRANSACCIÓN
                ' ========================================================

                Using trans As SqlTransaction =
                cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' VERIFICAR NUEVAMENTE QUE NO EXISTA
                        ' ====================================================

                        Dim sqlExiste As String =
                        "SELECT COUNT(*) " &
                        "FROM Compras " &
                        "WHERE Numero_Compra = @Numero " &
                        "AND Fecha_Compra = @Fecha " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmdExiste As New SqlCommand(
                        sqlExiste,
                        cn,
                        trans)

                            cmdExiste.Parameters.Add(
                            "@Numero",
                            SqlDbType.NVarChar,
                            50).Value =
                            hallazgo.Documento

                            cmdExiste.Parameters.Add(
                            "@Fecha",
                            SqlDbType.SmallDateTime).Value =
                            hallazgo.Fecha

                            If Convert.ToInt32(
                            cmdExiste.ExecuteScalar()) > 0 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' CREAR ENCABEZADO COMPRA
                        ' ====================================================

                        Dim sqlCompra As String =
                        "INSERT INTO Compras (" &
                        "Numero_Compra, Fecha_Compra, Tipo_Compra, " &
                        "MonedaCompra, Cod_Proveedor, Cod_Bodega, " &
                        "Fecha_Vencimiento, Observaciones, Descuento, " &
                        "Fecha_Descuento, SubTotal, IVA, Pagado, " &
                        "NetoPagar, MontoCredito, Contabilizado, Activo, " &
                        "Cancelado, Exonerado, Su_Referencia, " &
                        "Nuestra_Referencia, TransferenciaProcesada, " &
                        "Marca, CodigoProyecto, Referencia, FechaHora, " &
                        "TipoProductor, Estatus, AplicarCtasXPagar, " &
                        "Solcitud_Cta_Contable) " &
                        "VALUES (" &
                        "@Numero, @Fecha, N'Transferencia Recibida', " &
                        "@Moneda, NULL, @Bodega, @FechaVencimiento, " &
                        "@Observaciones, @Descuento, @FechaDescuento, " &
                        "@SubTotal, @IVA, @Pagado, @NetoPagar, " &
                        "@MontoCredito, @Contabilizado, @Activo, " &
                        "@Cancelado, @Exonerado, @SuReferencia, " &
                        "@NuestraReferencia, @TransferenciaProcesada, " &
                        "@Marca, @CodigoProyecto, @Referencia, @FechaHora, " &
                        "@TipoProductor, N'Grabado', 0, 0)"

                        Using cmdCompra As New SqlCommand(
                        sqlCompra,
                        cn,
                        trans)

                            cmdCompra.Parameters.Add(
                            "@Numero",
                            SqlDbType.NVarChar,
                            50).Value =
                            hallazgo.Documento

                            cmdCompra.Parameters.Add(
                            "@Fecha",
                            SqlDbType.SmallDateTime).Value =
                            hallazgo.Fecha

                            cmdCompra.Parameters.Add(
                            "@Moneda",
                            SqlDbType.NVarChar,
                            50).Value =
                            moneda

                            cmdCompra.Parameters.Add(
                            "@Bodega",
                            SqlDbType.NVarChar,
                            50).Value =
                            bodega

                            cmdCompra.Parameters.Add(
                            "@FechaVencimiento",
                            SqlDbType.SmallDateTime).Value =
                            fechaVencimiento

                            cmdCompra.Parameters.Add(
                            "@Observaciones",
                            SqlDbType.NVarChar,
                            150).Value =
                            observaciones

                            cmdCompra.Parameters.Add(
                            "@Descuento",
                            SqlDbType.NVarChar,
                            50).Value =
                            descuento

                            cmdCompra.Parameters.Add(
                            "@FechaDescuento",
                            SqlDbType.NVarChar,
                            50).Value =
                            fechaDescuento

                            cmdCompra.Parameters.Add(
                            "@SubTotal",
                            SqlDbType.Float).Value =
                            subtotal

                            cmdCompra.Parameters.Add(
                            "@IVA",
                            SqlDbType.Float).Value =
                            iva

                            cmdCompra.Parameters.Add(
                            "@Pagado",
                            SqlDbType.Float).Value =
                            pagado

                            cmdCompra.Parameters.Add(
                            "@NetoPagar",
                            SqlDbType.Float).Value =
                            netoPagar

                            cmdCompra.Parameters.Add(
                            "@MontoCredito",
                            SqlDbType.Float).Value =
                            montoCredito

                            cmdCompra.Parameters.Add(
                            "@Contabilizado",
                            SqlDbType.Bit).Value =
                            contabilizado

                            cmdCompra.Parameters.Add(
                            "@Activo",
                            SqlDbType.Bit).Value =
                            activo

                            cmdCompra.Parameters.Add(
                            "@Cancelado",
                            SqlDbType.Bit).Value =
                            cancelado

                            cmdCompra.Parameters.Add(
                            "@Exonerado",
                            SqlDbType.Bit).Value =
                            exonerado

                            cmdCompra.Parameters.Add(
                            "@SuReferencia",
                            SqlDbType.NVarChar,
                            50).Value =
                            suReferencia

                            cmdCompra.Parameters.Add(
                            "@NuestraReferencia",
                            SqlDbType.NVarChar,
                            50).Value =
                            nuestraReferencia

                            cmdCompra.Parameters.Add(
                            "@TransferenciaProcesada",
                            SqlDbType.Bit).Value =
                            transferenciaProcesada

                            cmdCompra.Parameters.Add(
                            "@Marca",
                            SqlDbType.Bit).Value =
                            marca

                            cmdCompra.Parameters.Add(
                            "@CodigoProyecto",
                            SqlDbType.NVarChar,
                            50).Value =
                            codigoProyecto

                            cmdCompra.Parameters.Add(
                            "@Referencia",
                            SqlDbType.NVarChar,
                            50).Value =
                            referencia

                            cmdCompra.Parameters.Add(
                            "@FechaHora",
                            SqlDbType.DateTime).Value =
                            fechaHora

                            cmdCompra.Parameters.Add(
                            "@TipoProductor",
                            SqlDbType.NVarChar,
                            50).Value =
                            tipoProductor

                            cmdCompra.ExecuteNonQuery()

                        End Using


                        ' ====================================================
                        ' CREAR DETALLES
                        ' ====================================================

                        Dim sqlDetalle As String =
                        "INSERT INTO Detalle_Compras (" &
                        "Numero_Compra, Fecha_Compra, Tipo_Compra, " &
                        "Cod_Producto, Cantidad, Precio_Unitario, " &
                        "Descuento, Precio_Neto, Importe, TasaCambio, " &
                        "id_Detalle_Transferencia, Costo_Unitario, " &
                        "Numero_Lote, Fecha_Vence, Descripcion_Producto) " &
                        "VALUES (" &
                        "@Numero, @Fecha, N'Transferencia Recibida', " &
                        "@Producto, @Cantidad, @Precio, 0, " &
                        "@PrecioNeto, @Importe, @Tasa, " &
                        "@IdTransferencia, @Costo, @Lote, @Vence, " &
                        "@Descripcion)"

                        For Each detalle As DetalleTransferenciaTemporal _
                        In detalles

                            Using cmdDetalle As New SqlCommand(
                            sqlDetalle,
                            cn,
                            trans)

                                cmdDetalle.Parameters.Add(
                                "@Numero",
                                SqlDbType.NVarChar,
                                50).Value =
                                hallazgo.Documento

                                cmdDetalle.Parameters.Add(
                                "@Fecha",
                                SqlDbType.SmallDateTime).Value =
                                hallazgo.Fecha

                                cmdDetalle.Parameters.Add(
                                "@Producto",
                                SqlDbType.NVarChar,
                                50).Value =
                                If(detalle.CodProducto Is Nothing,
                                   CType(DBNull.Value, Object),
                                   detalle.CodProducto)

                                cmdDetalle.Parameters.Add(
                                "@Cantidad",
                                SqlDbType.Float).Value =
                                detalle.Cantidad

                                ' Precio de transferencia:
                                ' Factura → Compra

                                cmdDetalle.Parameters.Add(
                                "@Precio",
                                SqlDbType.Float).Value =
                                detalle.PrecioUnitario

                                cmdDetalle.Parameters.Add(
                                "@PrecioNeto",
                                SqlDbType.Float).Value =
                                detalle.PrecioNeto

                                cmdDetalle.Parameters.Add(
                                "@Importe",
                                SqlDbType.Float).Value =
                                detalle.Importe

                                cmdDetalle.Parameters.Add(
                                "@Tasa",
                                SqlDbType.Float).Value =
                                detalle.TasaCambio

                                ' Relación directa entre ambas tablas

                                cmdDetalle.Parameters.Add(
                                "@IdTransferencia",
                                SqlDbType.Float).Value =
                                Convert.ToDouble(
                                    detalle.IdDetalleFactura)

                                cmdDetalle.Parameters.Add(
                                "@Costo",
                                SqlDbType.Float).Value =
                                detalle.CostoUnitario

                                cmdDetalle.Parameters.Add(
                                "@Lote",
                                SqlDbType.NVarChar,
                                50).Value =
                                If(detalle.NumeroLote Is Nothing,
                                   CType(DBNull.Value, Object),
                                   detalle.NumeroLote)

                                cmdDetalle.Parameters.Add(
                                "@Vence",
                                SqlDbType.NVarChar,
                                50).Value =
                                If(detalle.FechaVence Is Nothing,
                                   CType(DBNull.Value, Object),
                                   detalle.FechaVence)

                                cmdDetalle.Parameters.Add(
                                "@Descripcion",
                                SqlDbType.NVarChar,
                                250).Value =
                                If(
                                    detalle.DescripcionProducto Is Nothing,
                                    CType(DBNull.Value, Object),
                                    detalle.DescripcionProducto)

                                cmdDetalle.ExecuteNonQuery()

                            End Using

                        Next


                        ' ====================================================
                        ' CONFIRMAR TODO
                        ' ====================================================

                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Return False

                    End Try

                End Using

            End Using


            ' ============================================================
            ' ACTUALIZAR HALLAZGO
            ' ============================================================

            hallazgo.Estado =
            EstadoHallazgo.Reparado

            hallazgo.Reparable = False

            hallazgo.Accion =
            "REPARADO"

            hallazgo.Motivo =
            "Se creó la Transferencia Recibida " &
            hallazgo.Documento &
            " a partir de la Transferencia Enviada." &
            Environment.NewLine &
            "Id_Detalle_Factura: " &
            hallazgo.IdDetalleFactura.ToString("0")

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function
    Public Function RepararTransferencia001(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        If hallazgo Is Nothing Then Return False
        If hallazgo.Codigo <> "TRANS-001" Then Return False
        If Not hallazgo.Reparable Then Return False
        If hallazgo.IdDetalleFactura <= 0 Then Return False

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' VERIFICAR DETALLE FACTURA
                        ' ====================================================

                        Dim sqlExiste As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Facturas " &
                        "WHERE id_Detalle_Factura = @Id " &
                        "AND Tipo_Factura = N'Transferencia Enviada'"

                        Using cmd As New SqlCommand(
                        sqlExiste, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' VERIFICAR QUE NO EXISTA YA LA CONTRAPARTE
                        ' ====================================================

                        Dim sqlContraparte As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Transferencia = @Id " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmd As New SqlCommand(
                        sqlContraparte, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' CREAR DETALLE COMPRA
                        '
                        ' SE COPIA DIRECTAMENTE DESDE DETALLE_FACTURAS
                        '
                        ' NO SE CALCULA COSTO
                        ' ====================================================

                        Dim sqlInsert As String =
                        "INSERT INTO Detalle_Compras " &
                        "(" &
                        " Numero_Compra, " &
                        " Fecha_Compra, " &
                        " Tipo_Compra, " &
                        " Cod_Producto, " &
                        " Cantidad, " &
                        " Precio_Unitario, " &
                        " Descuento, " &
                        " Precio_Neto, " &
                        " Importe, " &
                        " TasaCambio, " &
                        " id_Detalle_Transferencia, " &
                        " Costo_Unitario, " &
                        " Numero_Lote, " &
                        " Fecha_Vence, " &
                        " Descripcion_Producto" &
                        ") " &
                        "SELECT " &
                        " Numero_Factura, " &
                        " Fecha_Factura, " &
                        " N'Transferencia Recibida', " &
                        " Cod_Producto, " &
                        " Cantidad, " &
                        " Precio_Unitario, " &
                        " CASE WHEN ISNUMERIC(Descuento) = 1 " &
                        "      AND Descuento NOT LIKE '%[^0-9.-]%' " &
                        "      THEN CONVERT(float, Descuento) ELSE 0 END, " &
                        " Precio_Neto, " &
                        " Importe, " &
                        " TasaCambio, " &
                        " id_Detalle_Factura, " &
                        " Costo_Unitario, " &
                        " ISNULL(Numero_Lote, N'SINLOTE'), " &
                        " CASE WHEN Fecha_Vence IS NULL " &
                        "      OR Fecha_Vence <= CONVERT(smalldatetime, '19000101', 112) " &
                        "      THEN NULL " &
                        "      ELSE CONVERT(nvarchar(10), Fecha_Vence, 103) END, " &
                        " Descripcion_Producto " &
                        "FROM Detalle_Facturas " &
                        "WHERE id_Detalle_Factura = @Id"

                        Using cmd As New SqlCommand(
                        sqlInsert, cn, trans)

                            cmd.CommandTimeout = 300

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If cmd.ExecuteNonQuery() <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            ' ================================================================
            ' ACTUALIZAR HALLAZGO
            ' ================================================================

            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.PuedeEliminar = False
            hallazgo.Accion = "REPARADO"

            hallazgo.Motivo =
            "Se creó la Transferencia Recibida equivalente." &
            Environment.NewLine &
            "ID Detalle Factura: " &
            hallazgo.IdDetalleFactura.ToString()

            Return True

        Catch

            Return False

        End Try

    End Function
    Public Function RepararTransferencia002(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        If hallazgo Is Nothing Then Return False
        If hallazgo.Codigo <> "TRANS-002" Then Return False
        If Not hallazgo.Reparable Then Return False
        If hallazgo.IdDetalleCompra <= 0 Then Return False

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' VERIFICAR DETALLE COMPRA
                        ' ====================================================

                        Dim sqlExiste As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Compra = @Id " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmd As New SqlCommand(
                        sqlExiste, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If Convert.ToInt32(cmd.ExecuteScalar()) <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' VERIFICAR QUE NO EXISTA YA LA CONTRAPARTE
                        ' ====================================================

                        Dim sqlContraparte As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Facturas " &
                        "WHERE id_Detalle_Factura = " &
                        "    (SELECT id_Detalle_Transferencia " &
                        "     FROM Detalle_Compras " &
                        "     WHERE id_Detalle_Compra = @Id) " &
                        "AND Tipo_Factura = N'Transferencia Enviada'"

                        Using cmd As New SqlCommand(
                        sqlContraparte, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' CREAR DETALLE FACTURA
                        '
                        ' SE COPIA DIRECTAMENTE DESDE DETALLE_COMPRAS
                        '
                        ' NO SE CALCULA COSTO
                        ' ====================================================

                        Dim sqlInsert As String =
                        "INSERT INTO Detalle_Facturas " &
                        "(" &
                        " Numero_Factura, " &
                        " Fecha_Factura, " &
                        " Tipo_Factura, " &
                        " Cod_Producto, " &
                        " Descripcion_Producto, " &
                        " Cantidad, " &
                        " Precio_Unitario, " &
                        " Precio_Neto, " &
                        " Importe, " &
                        " TasaCambio, " &
                        " CodTarea, " &
                        " Costo_Unitario, " &
                        " Descuento, " &
                        " NoPresupuesto, " &
                        " Numero_Lote, " &
                        " Fecha_Vence" &
                        ") " &
                        "SELECT " &
                        " Numero_Compra, " &
                        " Fecha_Compra, " &
                        " N'Transferencia Enviada', " &
                        " Cod_Producto, " &
                        " Descripcion_Producto, " &
                        " Cantidad, " &
                        " Precio_Unitario, " &
                        " Precio_Neto, " &
                        " Importe, " &
                        " 0, " &
                        " 0, " &
                        " Costo_Unitario, " &
                        " ISNULL(Descuento, 0), " &
                        " NULL, " &
                        " ISNULL(Numero_Lote, N'SINLOTE'), " &
                        " CASE " &
                        "   WHEN ISDATE(Fecha_Vence) = 1 " &
                        "   THEN CONVERT(smalldatetime, Fecha_Vence) " &
                        "   ELSE CONVERT(smalldatetime, '1900-01-01') " &
                        " END " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Compra = @Id"

                        Using cmd As New SqlCommand(
                        sqlInsert, cn, trans)

                            cmd.CommandTimeout = 300

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If cmd.ExecuteNonQuery() <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            ' ================================================================
            ' ACTUALIZAR HALLAZGO
            ' ================================================================

            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.PuedeEliminar = False
            hallazgo.Accion = "REPARADO"

            hallazgo.Motivo =
            "Se creó la Transferencia Enviada equivalente." &
            Environment.NewLine &
            "ID Detalle Compra: " &
            hallazgo.IdDetalleCompra.ToString()

            Return True

        Catch

            Return False

        End Try

    End Function
    ' ============================================================
    ' REPARAR TRANS-003 (VÍNCULO CON PRODUCTO DISTINTO)
    '
    ' Corrige únicamente Detalle_Compras.id_Detalle_Transferencia
    ' de una recibida, para que apunte a la enviada correcta.
    ' No crea ni elimina líneas y no modifica cantidades ni costos.
    '
    '   hallazgo.IdDetalleCompra        = recibida a corregir
    '   hallazgo.IdDetalleTransferencia = vínculo actual (incorrecto)
    '   hallazgo.IdDetalleFactura       = enviada correcta
    ' ============================================================
    Public Function RepararTransferencia003(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        UltimoError = String.Empty

        If hallazgo Is Nothing Then Return False

        UltimoError =
        "Datos del hallazgo: control=" & hallazgo.Codigo &
        ", reparable=" & hallazgo.Reparable.ToString() &
        ", IdDetalleCompra=" & hallazgo.IdDetalleCompra.ToString("0") &
        ", vínculo actual=" & hallazgo.IdDetalleTransferencia.ToString("0") &
        ", enviada destino=" & hallazgo.IdDetalleFactura.ToString("0") & "."

        If hallazgo.Codigo <> "TRANS-003" Then Return False
        If Not hallazgo.Reparable Then Return False
        If hallazgo.IdDetalleCompra <= 0 Then Return False
        If hallazgo.IdDetalleTransferencia <= 0 Then Return False
        If hallazgo.IdDetalleFactura <= 0 Then Return False

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' LA ENVIADA DESTINO DEBE COINCIDIR EN DOCUMENTO,
                        ' PRODUCTO Y CANTIDAD, Y EL VÍNCULO ACTUAL DEBE
                        ' SEGUIR SIENDO EL DETECTADO
                        ' ====================================================

                        Dim datosHallazgo As String = UltimoError

                        UltimoError =
                        "La enviada destino no coincide en documento, " &
                        "producto y cantidad con la recibida, o el vínculo " &
                        "actual ya no es el detectado. " & datosHallazgo

                        Dim sqlValida As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras c " &
                        "INNER JOIN Detalle_Facturas f " &
                        "  ON f.id_Detalle_Factura = @Nuevo " &
                        " AND f.Tipo_Factura = N'Transferencia Enviada' " &
                        " AND f.Numero_Factura = c.Numero_Compra " &
                        " AND LTRIM(RTRIM(f.Cod_Producto)) = LTRIM(RTRIM(c.Cod_Producto)) " &
                        " AND f.Cantidad = c.Cantidad " &
                        "WHERE c.id_Detalle_Compra = @IdCompra " &
                        "AND c.Tipo_Compra = N'Transferencia Recibida' " &
                        "AND c.id_Detalle_Transferencia = @Actual"

                        Using cmd As New SqlCommand(
                        sqlValida, cn, trans)

                            cmd.Parameters.Add("@Nuevo", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura
                            cmd.Parameters.Add("@IdCompra", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra
                            cmd.Parameters.Add("@Actual", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleTransferencia

                            If Convert.ToInt32(cmd.ExecuteScalar()) <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' LA ENVIADA DESTINO NO DEBE TENER YA UNA RECIBIDA
                        ' ====================================================

                        UltimoError =
                        "La enviada destino ya tiene una recibida relacionada. " &
                        datosHallazgo

                        Dim sqlLibre As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Transferencia = @Nuevo " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmd As New SqlCommand(
                        sqlLibre, cn, trans)

                            cmd.Parameters.Add("@Nuevo", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' CORREGIR SOLO EL VÍNCULO
                        ' ====================================================

                        UltimoError =
                        "El UPDATE no afectó exactamente una fila. " &
                        datosHallazgo

                        Dim sqlUpdate As String =
                        "UPDATE Detalle_Compras " &
                        "SET id_Detalle_Transferencia = @Nuevo " &
                        "WHERE id_Detalle_Compra = @IdCompra " &
                        "AND Tipo_Compra = N'Transferencia Recibida' " &
                        "AND id_Detalle_Transferencia = @Actual"

                        Using cmd As New SqlCommand(
                        sqlUpdate, cn, trans)

                            cmd.Parameters.Add("@Nuevo", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura
                            cmd.Parameters.Add("@IdCompra", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra
                            cmd.Parameters.Add("@Actual", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleTransferencia

                            If cmd.ExecuteNonQuery() <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.PuedeEliminar = False
            hallazgo.Accion = "REPARADO"

            UltimoError = String.Empty

            hallazgo.Motivo =
            "Se corrigió el vínculo de la Transferencia Recibida." &
            Environment.NewLine &
            "ID Detalle Compra: " &
            hallazgo.IdDetalleCompra.ToString("0") &
            Environment.NewLine &
            "Nuevo id_Detalle_Transferencia: " &
            hallazgo.IdDetalleFactura.ToString("0")

            Return True

        Catch ex As Exception

            UltimoError = "Error de SQL Server: " & ex.Message

            Return False

        End Try

    End Function

    Private Function CrearClaveTransferencia(
    ByVal documento As String,
    ByVal fecha As DateTime,
    ByVal producto As String,
    ByVal cantidad As Double) As String

        Return documento.Trim().ToUpperInvariant() & "|" &
           fecha.Date.ToString("yyyyMMdd") & "|" &
           producto.Trim().ToUpperInvariant() & "|" &
           cantidad.ToString("0.######",
                             Globalization.CultureInfo.InvariantCulture)

    End Function

    ' Fragmento SQL: existe una enviada del mismo documento, producto y
    ' cantidad que la recibida "c", sin ninguna recibida relacionada.
    Private Const SQL_EXISTE_CANDIDATA As String =
        "EXISTS (SELECT 1 FROM Detalle_Facturas f2 " &
        "WHERE f2.Tipo_Factura = N'Transferencia Enviada' " &
        "AND f2.Numero_Factura = c.Numero_Compra " &
        "AND LTRIM(RTRIM(f2.Cod_Producto)) = LTRIM(RTRIM(c.Cod_Producto)) " &
        "AND f2.Cantidad = c.Cantidad " &
        "AND ISNULL(f2.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " &
        "AND NOT EXISTS (SELECT 1 FROM Detalle_Compras c3 " &
        "WHERE c3.id_Detalle_Transferencia = f2.id_Detalle_Factura " &
        "AND c3.Tipo_Compra = N'Transferencia Recibida'))"

    Private Function CrearClaveSinFecha(
    ByVal documento As String,
    ByVal producto As String,
    ByVal cantidad As Double) As String

        Return documento.Trim().ToUpperInvariant() & "|" &
           producto.Trim().ToUpperInvariant() & "|" &
           cantidad.ToString("0.######",
                             Globalization.CultureInfo.InvariantCulture)

    End Function

    ' Devuelve el conjunto de ids de una consulta de una sola columna.
    Private Function ObtenerIdsTransferencia(
    ByVal sql As String) As HashSet(Of Decimal)

        Dim ids As New HashSet(Of Decimal)()

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(sql, cn)

                cmd.CommandTimeout = 300

                Using rd As SqlDataReader = cmd.ExecuteReader()

                    While rd.Read()

                        If Not rd.IsDBNull(0) Then
                            ids.Add(Convert.ToDecimal(rd.GetValue(0)))
                        End If

                    End While

                End Using

            End Using

        End Using

        Return ids

    End Function

    Public Function EliminarTransferencia001(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        If hallazgo Is Nothing Then Return False
        If hallazgo.Codigo <> "TRANS-001" Then Return False
        If Not hallazgo.PuedeEliminar Then Return False
        If Not hallazgo.EsDuplicado Then Return False
        If hallazgo.IdDetalleFactura <= 0 Then Return False

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' VERIFICAR QUE EL DETALLE EXISTA
                        ' ====================================================

                        Dim sqlExiste As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Facturas " &
                        "WHERE id_Detalle_Factura = @Id " &
                        "AND Tipo_Factura = N'Transferencia Enviada'"

                        Using cmd As New SqlCommand(
                        sqlExiste, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' NINGUNA RECEPCIÓN DEBE APUNTAR A ESTE DETALLE
                        ' ====================================================

                        Dim sqlReferenciado As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Transferencia = @Id"

                        Using cmd As New SqlCommand(
                        sqlReferenciado, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' DEBE QUEDAR OTRA LÍNEA ENVIADA (MISMO DOCUMENTO,
                        ' PRODUCTO Y CANTIDAD) CON RECEPCIÓN RELACIONADA
                        ' ====================================================

                        Dim sqlSobreviviente As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Facturas o " &
                        "INNER JOIN Detalle_Facturas d " &
                        "  ON d.Numero_Factura = o.Numero_Factura " &
                        " AND d.Cod_Producto = o.Cod_Producto " &
                        " AND d.Cantidad = o.Cantidad " &
                        " AND d.Tipo_Factura = N'Transferencia Enviada' " &
                        " AND d.id_Detalle_Factura <> o.id_Detalle_Factura " &
                        "WHERE o.id_Detalle_Factura = @Id " &
                        "AND EXISTS (SELECT 1 FROM Detalle_Compras c " &
                        "    WHERE c.id_Detalle_Transferencia = d.id_Detalle_Factura " &
                        "    AND c.Tipo_Compra = N'Transferencia Recibida')"

                        Using cmd As New SqlCommand(
                        sqlSobreviviente, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If Convert.ToInt32(cmd.ExecuteScalar()) < 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' ELIMINAR
                        ' ====================================================

                        Dim sqlDelete As String =
                        "DELETE FROM Detalle_Facturas " &
                        "WHERE id_Detalle_Factura = @Id " &
                        "AND Tipo_Factura = N'Transferencia Enviada'"

                        Using cmd As New SqlCommand(
                        sqlDelete, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                            If cmd.ExecuteNonQuery() <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.PuedeEliminar = False
            hallazgo.Accion = "ELIMINADO"

            hallazgo.Motivo =
            "Se eliminó el detalle duplicado de " &
            "Transferencia Enviada." &
            Environment.NewLine &
            "ID Detalle Factura: " &
            hallazgo.IdDetalleFactura.ToString()

            Return True

        Catch

            Return False

        End Try

    End Function
    Public Function EliminarTransferencia002(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        If hallazgo Is Nothing Then Return False
        If hallazgo.Codigo <> "TRANS-002" Then Return False
        If Not hallazgo.PuedeEliminar Then Return False
        If Not hallazgo.EsDuplicado Then Return False
        If hallazgo.IdDetalleCompra <= 0 Then Return False

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try

                        ' ====================================================
                        ' VERIFICAR QUE EL DETALLE EXISTA
                        ' ====================================================

                        Dim sqlExiste As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras " &
                        "WHERE id_Detalle_Compra = @Id " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmd As New SqlCommand(
                        sqlExiste, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If Convert.ToInt32(cmd.ExecuteScalar()) <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' DEBE QUEDAR OTRA RECEPCIÓN (MISMO DOCUMENTO,
                        ' PRODUCTO Y CANTIDAD) RELACIONADA CON UNA ENVIADA
                        ' EXISTENTE
                        ' ====================================================

                        Dim sqlSobreviviente As String =
                        "SELECT COUNT(*) " &
                        "FROM Detalle_Compras o " &
                        "INNER JOIN Detalle_Compras d " &
                        "  ON d.Numero_Compra = o.Numero_Compra " &
                        " AND d.Cod_Producto = o.Cod_Producto " &
                        " AND d.Cantidad = o.Cantidad " &
                        " AND d.Tipo_Compra = N'Transferencia Recibida' " &
                        " AND d.id_Detalle_Compra <> o.id_Detalle_Compra " &
                        "WHERE o.id_Detalle_Compra = @Id " &
                        "AND EXISTS (SELECT 1 FROM Detalle_Facturas f " &
                        "    WHERE f.id_Detalle_Factura = d.id_Detalle_Transferencia " &
                        "    AND f.Tipo_Factura = N'Transferencia Enviada')"

                        Using cmd As New SqlCommand(
                        sqlSobreviviente, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If Convert.ToInt32(cmd.ExecuteScalar()) < 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        ' ====================================================
                        ' ELIMINAR
                        ' ====================================================

                        Dim sqlDelete As String =
                        "DELETE FROM Detalle_Compras " &
                        "WHERE id_Detalle_Compra = @Id " &
                        "AND Tipo_Compra = N'Transferencia Recibida'"

                        Using cmd As New SqlCommand(
                        sqlDelete, cn, trans)

                            cmd.Parameters.Add(
                            "@Id",
                            SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleCompra

                            If cmd.ExecuteNonQuery() <> 1 Then

                                trans.Rollback()
                                Return False

                            End If

                        End Using


                        trans.Commit()

                    Catch

                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.PuedeEliminar = False
            hallazgo.Accion = "ELIMINADO"

            hallazgo.Motivo =
            "Se eliminó el detalle duplicado de " &
            "Transferencia Recibida." &
            Environment.NewLine &
            "ID Detalle Compra: " &
            hallazgo.IdDetalleCompra.ToString()

            Return True

        Catch

            Return False

        End Try

    End Function

    Private Function ObtenerDecimal(
    ByVal valor As Object) As Decimal

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0D
        End If

        Return Convert.ToDecimal(valor)

    End Function
    Private Function ObtenerDouble(
    ByVal valor As Object) As Double

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0
        End If

        Return Convert.ToDouble(valor)

    End Function
    ' ============================================================
    ' DETERMINAR COSTO DE REPARACIÓN
    '
    ' Utiliza el Motor de Costos existente.
    ' No realiza ningún cálculo propio.
    ' ============================================================
    Private Sub DeterminarCostoReparacion(
    ByVal hallazgo As HallazgoAuditoria)

        Dim rstCosto As RstCostoPromedio

        ' ============================================================
        ' DETERMINAR COSTO UTILIZANDO EL KARDEX ORIGINAL
        ' ============================================================

        rstCosto =
        CostoPromedioKardex(
            hallazgo.Producto,
            hallazgo.Fecha)

        hallazgo.CostoPropuesto =
        rstCosto.Costo_Cordoba

        hallazgo.CostoPropuestoDolar =
        rstCosto.Costo_Dolar

        hallazgo.OrigenCosto =
        "CostoPromedioKardex"

        ' ============================================================
        ' DETERMINAR SI EL HALLAZGO ES REPARABLE
        ' ============================================================

        If rstCosto.Costo_Cordoba > 0 Then

            hallazgo.TieneCostoPropuesto = True
            hallazgo.Reparable = True

            hallazgo.Estado =
            EstadoHallazgo.Reparable

            hallazgo.Accion =
            "REPARAR"

            hallazgo.Motivo =
            "La factura tiene Costo_Unitario en cero. " &
            "El Motor de Costos determinó un costo válido de " &
            rstCosto.Costo_Cordoba.ToString("N6") & "."

        Else

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La factura tiene Costo_Unitario en cero y " &
            "el Motor de Costos no determinó un costo válido."

        End If

    End Sub
    Private Sub DeterminarCostoReparacionDevolucion(
    ByVal hallazgo As HallazgoAuditoria)

        If String.IsNullOrWhiteSpace(hallazgo.Producto) Then

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.CostoPropuesto = 0
            hallazgo.CostoPropuestoDolar = 0
            hallazgo.OrigenCosto = String.Empty

            hallazgo.Estado =
        EstadoHallazgo.Detectado

            hallazgo.Accion =
        "REVISIÓN MANUAL"

            hallazgo.Motivo =
        "La devolución tiene Costo_Unitario en cero, " &
        "pero no tiene un Código de Producto. " &
        "No es posible determinar el costo histórico."

            Return

        End If

        Dim rstCosto As RstCostoPromedio

        rstCosto =
        CostoPromedioKardex(
            hallazgo.Producto,
            hallazgo.Fecha)

        hallazgo.CostoPropuesto =
        rstCosto.Costo_Cordoba

        hallazgo.CostoPropuestoDolar =
        rstCosto.Costo_Dolar

        hallazgo.OrigenCosto =
        "CostoPromedioKardex"

        If rstCosto.Costo_Cordoba > 0 Then

            hallazgo.TieneCostoPropuesto = True
            hallazgo.Reparable = True

            hallazgo.Estado =
            EstadoHallazgo.Reparable

            hallazgo.Accion =
            "REPARAR"

            hallazgo.Motivo =
            "La devolución tiene Costo_Unitario en cero. " &
            "Se determinó un costo histórico de " &
            rstCosto.Costo_Cordoba.ToString("N6") &
            " para la fecha de la devolución."

        Else

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La devolución tiene Costo_Unitario en cero " &
            "y no fue posible determinar un costo histórico válido."

        End If

    End Sub
    Private Sub DeterminarCostoReparacionSalidaBodega(
    ByVal hallazgo As HallazgoAuditoria)

        ' ============================================================
        ' VALIDAR PRODUCTO
        ' ============================================================

        If String.IsNullOrWhiteSpace(hallazgo.Producto) Then

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.CostoPropuesto = 0
            hallazgo.CostoPropuestoDolar = 0
            hallazgo.OrigenCosto = String.Empty

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La salida de bodega tiene Costo_Unitario " &
            "en cero, pero no tiene un Código de Producto. " &
            "No es posible determinar el costo histórico."

            Return

        End If

        ' ============================================================
        ' DETERMINAR COSTO HISTÓRICO
        ' ============================================================

        Dim rstCosto As RstCostoPromedio

        rstCosto =
        CostoPromedioKardex(
            hallazgo.Producto,
            hallazgo.Fecha)

        hallazgo.CostoPropuesto =
        rstCosto.Costo_Cordoba

        hallazgo.CostoPropuestoDolar =
        rstCosto.Costo_Dolar

        hallazgo.OrigenCosto =
        "CostoPromedioKardex"

        ' ============================================================
        ' COSTO VÁLIDO
        ' ============================================================

        If rstCosto.Costo_Cordoba > 0 Then

            hallazgo.TieneCostoPropuesto = True
            hallazgo.Reparable = True

            hallazgo.Estado =
            EstadoHallazgo.Reparable

            hallazgo.Accion =
            "REPARAR"

            hallazgo.Motivo =
            "La salida de bodega tiene Costo_Unitario " &
            "en cero. Se determinó un costo histórico de " &
            rstCosto.Costo_Cordoba.ToString("N6") &
            " para la fecha de la salida."

        Else

            ' ========================================================
            ' NO SE PUDO DETERMINAR COSTO
            ' ========================================================

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La salida de bodega tiene Costo_Unitario " &
            "en cero y no fue posible determinar un " &
            "costo histórico válido."

        End If

    End Sub

    Private Sub DeterminarCostoReparacionTransferencia(
    ByVal hallazgo As HallazgoAuditoria)

        ' ============================================================
        ' VALIDAR PRODUCTO
        ' ============================================================

        If String.IsNullOrWhiteSpace(hallazgo.Producto) Then

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.CostoPropuesto = 0
            hallazgo.CostoPropuestoDolar = 0
            hallazgo.OrigenCosto = String.Empty

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La transferencia enviada tiene un Precio_Unitario " &
            "que requiere revisión, pero no tiene un Código " &
            "de Producto. No es posible determinar el costo histórico."

            Return

        End If

        ' ============================================================
        ' DETERMINAR COSTO HISTÓRICO
        ' ============================================================

        Dim rstCosto As RstCostoPromedio

        rstCosto =
        CostoPromedioKardex(
            hallazgo.Producto,
            hallazgo.Fecha)

        ' ============================================================
        ' REDONDEAR A 6 DECIMALES
        ' ============================================================

        Dim costoKardex As Double =
        Math.Round(
            rstCosto.Costo_Cordoba,
            6)

        Dim precioActual As Double =
        Math.Round(
            hallazgo.PrecioUnitario,
            6)

        ' ============================================================
        ' GUARDAR COSTO PROPUESTO
        ' ============================================================

        hallazgo.CostoPropuesto =
        costoKardex

        hallazgo.CostoPropuestoDolar =
        Math.Round(
            rstCosto.Costo_Dolar,
            6)

        hallazgo.OrigenCosto =
        "CostoPromedioKardex"

        ' ============================================================
        ' COSTO VÁLIDO
        ' ============================================================

        If costoKardex > 0 Then

            ' ========================================================
            ' EL PRECIO YA ES CORRECTO
            ' ========================================================

            If precioActual = costoKardex Then

                hallazgo.TieneCostoPropuesto = False
                hallazgo.Reparable = False

                hallazgo.CostoPropuesto =
                0

                hallazgo.CostoPropuestoDolar =
                0

                hallazgo.OrigenCosto =
                String.Empty

                Return

            End If

            ' ========================================================
            ' PRECIO UNITARIO INCORRECTO
            ' ========================================================

            hallazgo.TieneCostoPropuesto = True
            hallazgo.Reparable = True

            hallazgo.Estado =
            EstadoHallazgo.Reparable

            hallazgo.Accion =
            "REPARAR"

            hallazgo.Motivo =
            "La transferencia enviada tiene un Precio_Unitario " &
            "diferente al costo determinado por el Motor de Costos. " &
            "Precio actual: " &
            precioActual.ToString("N6") &
            ". Costo correcto: " &
            costoKardex.ToString("N6") & "."

        Else

            ' ========================================================
            ' NO SE PUDO DETERMINAR COSTO
            ' ========================================================

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.CostoPropuesto = 0
            hallazgo.CostoPropuestoDolar = 0
            hallazgo.OrigenCosto = String.Empty

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La transferencia enviada tiene un Precio_Unitario " &
            "que requiere revisión y no fue posible determinar " &
            "un costo histórico válido."

        End If

    End Sub

    Private Sub DeterminarCostoReparacionTransferenciaRecibida(
    ByVal hallazgo As HallazgoAuditoria)

        ' ============================================================
        ' VALIDAR PRODUCTO
        ' ============================================================

        If String.IsNullOrWhiteSpace(
        hallazgo.Producto) Then

            hallazgo.TieneCostoPropuesto = False
            hallazgo.Reparable = False

            hallazgo.CostoPropuesto = 0
            hallazgo.CostoPropuestoDolar = 0
            hallazgo.OrigenCosto = String.Empty

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La transferencia recibida tiene Precio_Unitario " &
            "en cero, pero no tiene un Código de Producto. " &
            "No es posible determinar el costo histórico."

            Return

        End If


        ' ============================================================
        ' DETERMINAR COSTO HISTÓRICO
        ' ============================================================

        Dim rstCosto As RstCostoPromedio

        rstCosto =
        CostoPromedioKardex(
            hallazgo.Producto,
            hallazgo.Fecha)


        ' ============================================================
        ' GUARDAR COSTO PROPUESTO
        ' ============================================================

        hallazgo.CostoPropuesto =
        rstCosto.Costo_Cordoba

        hallazgo.CostoPropuestoDolar =
        rstCosto.Costo_Dolar

        hallazgo.OrigenCosto =
        "CostoPromedioKardex"


        ' ============================================================
        ' COSTO VÁLIDO
        ' ============================================================

        If rstCosto.Costo_Cordoba > 0 Then

            hallazgo.TieneCostoPropuesto =
            True

            hallazgo.Reparable =
            True

            hallazgo.Estado =
            EstadoHallazgo.Reparable

            hallazgo.Accion =
            "REPARAR"

            hallazgo.Motivo =
            "La transferencia recibida tiene Precio_Unitario " &
            "en cero. Se determinó un costo histórico de " &
            rstCosto.Costo_Cordoba.ToString("N6") &
            " para la fecha de la transferencia."

        Else

            ' ========================================================
            ' NO SE PUDO DETERMINAR COSTO
            ' ========================================================

            hallazgo.TieneCostoPropuesto =
            False

            hallazgo.Reparable =
            False

            hallazgo.CostoPropuesto =
            0

            hallazgo.CostoPropuestoDolar =
            0

            hallazgo.OrigenCosto =
            String.Empty

            hallazgo.Estado =
            EstadoHallazgo.Detectado

            hallazgo.Accion =
            "REVISIÓN MANUAL"

            hallazgo.Motivo =
            "La transferencia recibida tiene Precio_Unitario " &
            "en cero y no fue posible determinar un " &
            "costo histórico válido mediante " &
            "CostoPromedioKardex."

        End If

    End Sub


    ' ============================================================
    ' REPARAR COSTO DEL HALLAZGO
    '
    ' Actualiza únicamente el detalle de factura que fue auditado.
    '
    ' La reparación utiliza el CostoPropuesto que previamente
    ' determinó CostoPromedioKardex.
    '
    ' La condición Costo_Unitario = 0 evita sobrescribir un costo
    ' que haya sido modificado por otro proceso después de la
    ' auditoría.
    ' ============================================================
    Public Function RepararCosto(
    ByVal hallazgo As HallazgoAuditoria) As Boolean

        Try

            ' ============================================================
            ' VALIDACIONES
            ' ============================================================

            If hallazgo Is Nothing Then
                Return False
            End If

            If Not hallazgo.Reparable Then
                Return False
            End If

            If Not hallazgo.TieneCostoPropuesto Then
                Return False
            End If

            If hallazgo.IdDetalleFactura <= 0 Then
                Return False
            End If

            If hallazgo.CostoPropuesto <= 0 Then
                Return False
            End If


            ' ============================================================
            ' VALORES
            ' ============================================================

            Dim costoAnterior As Double =
            hallazgo.CostoUnitario

            Dim costoNuevo As Double =
            Math.Round(
                hallazgo.CostoPropuesto,
                6)

            Dim precioAnterior As Double =
            hallazgo.PrecioUnitario

            Dim precioNuevo As Double =
            costoNuevo

            Dim costoGuardado As Double = 0
            Dim precioGuardado As Double = 0


            ' ============================================================
            ' TIPO DE REPARACIÓN
            ' ============================================================

            Dim esTransferenciaEnviada As Boolean =
            (hallazgo.Codigo = "COST-004")

            Dim esTransferenciaRecibida As Boolean =
            (hallazgo.Codigo = "COST-005")

            Dim esTransferencia As Boolean =
            esTransferenciaEnviada OrElse
            esTransferenciaRecibida


            ' ============================================================
            ' ACTUALIZAR BASE DE DATOS
            ' ============================================================

            Dim sqlUpdate As String


            If esTransferenciaEnviada Then

                ' --------------------------------------------------------
                ' COST-004
                '
                ' Detalle_Facturas
                ' Transferencia Enviada
                ' --------------------------------------------------------

                sqlUpdate =
                "UPDATE Detalle_Facturas " &
                "SET Precio_Unitario = @PrecioNuevo, " &
                "    Costo_Unitario = @CostoNuevo " &
                "WHERE id_Detalle_Factura = @IdDetalle " &
                "  AND Numero_Factura = @Documento " &
                "  AND Fecha_Factura = @Fecha " &
                "  AND Tipo_Factura = @Tipo " &
                "  AND ISNULL(Precio_Unitario, 0) = 0"


            ElseIf esTransferenciaRecibida Then

                ' --------------------------------------------------------
                ' COST-005
                '
                ' Detalle_Compras
                ' Transferencia Recibida
                ' --------------------------------------------------------

                sqlUpdate =
                "UPDATE Detalle_Compras " &
                "SET Precio_Unitario = @PrecioNuevo, " &
                "    Costo_Unitario = @CostoNuevo " &
                "WHERE id_Detalle_Compra = @IdDetalle " &
                "  AND Numero_Compra = @Documento " &
                "  AND Fecha_Compra = @Fecha " &
                "  AND Tipo_Compra = @Tipo " &
                "  AND ISNULL(Precio_Unitario, 0) = 0"


            Else

                ' --------------------------------------------------------
                ' COST-001 / COST-002 / COST-003
                '
                ' Mantener comportamiento existente.
                ' --------------------------------------------------------

                sqlUpdate =
                "UPDATE Detalle_Facturas " &
                "SET Costo_Unitario = @CostoNuevo " &
                "WHERE id_Detalle_Factura = @IdDetalle " &
                "  AND Numero_Factura = @Documento " &
                "  AND Fecha_Factura = @Fecha " &
                "  AND Tipo_Factura = @Tipo " &
                "  AND ISNULL(Costo_Unitario, 0) = 0"

            End If


            Using cn As New SqlConnection(Conexion)

                cn.Open()


                ' ========================================================
                ' ACTUALIZAR
                ' ========================================================

                Using cmd As New SqlCommand(
                sqlUpdate,
                cn)

                    cmd.CommandType =
                    CommandType.Text

                    cmd.CommandTimeout =
                    300


                    cmd.Parameters.Add(
                    "@CostoNuevo",
                    SqlDbType.Float).Value =
                    costoNuevo


                    If esTransferencia Then

                        cmd.Parameters.Add(
                        "@PrecioNuevo",
                        SqlDbType.Float).Value =
                        precioNuevo

                    End If


                    cmd.Parameters.Add(
                    "@IdDetalle",
                    SqlDbType.Decimal).Value =
                    hallazgo.IdDetalleFactura


                    cmd.Parameters.Add(
                    "@Documento",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Documento


                    cmd.Parameters.Add(
                    "@Fecha",
                    SqlDbType.SmallDateTime).Value =
                    hallazgo.Fecha


                    cmd.Parameters.Add(
                    "@Tipo",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Tipo


                    Dim filasAfectadas As Integer =
                    cmd.ExecuteNonQuery()


                    If filasAfectadas <> 1 Then
                        Return False
                    End If

                End Using


                ' ========================================================
                ' VERIFICAR VALORES GUARDADOS
                ' ========================================================

                Dim sqlVerificar As String


                If esTransferenciaRecibida Then

                    sqlVerificar =
                    "SELECT Precio_Unitario, Costo_Unitario " &
                    "FROM Detalle_Compras " &
                    "WHERE id_Detalle_Compra = @IdDetalle " &
                    "  AND Numero_Compra = @Documento " &
                    "  AND Fecha_Compra = @Fecha " &
                    "  AND Tipo_Compra = @Tipo"


                Else

                    sqlVerificar =
                    "SELECT Precio_Unitario, Costo_Unitario " &
                    "FROM Detalle_Facturas " &
                    "WHERE id_Detalle_Factura = @IdDetalle " &
                    "  AND Numero_Factura = @Documento " &
                    "  AND Fecha_Factura = @Fecha " &
                    "  AND Tipo_Factura = @Tipo"

                End If


                Using cmdVerificar As New SqlCommand(
                sqlVerificar,
                cn)

                    cmdVerificar.CommandType =
                    CommandType.Text

                    cmdVerificar.CommandTimeout =
                    300


                    cmdVerificar.Parameters.Add(
                    "@IdDetalle",
                    SqlDbType.Decimal).Value =
                    hallazgo.IdDetalleFactura


                    cmdVerificar.Parameters.Add(
                    "@Documento",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Documento


                    cmdVerificar.Parameters.Add(
                    "@Fecha",
                    SqlDbType.SmallDateTime).Value =
                    hallazgo.Fecha


                    cmdVerificar.Parameters.Add(
                    "@Tipo",
                    SqlDbType.NVarChar,
                    50).Value =
                    hallazgo.Tipo


                    Using dr As SqlDataReader =
                    cmdVerificar.ExecuteReader()

                        If Not dr.Read() Then
                            Return False
                        End If


                        If Not IsDBNull(
                        dr("Precio_Unitario")) Then

                            precioGuardado =
                            Convert.ToDouble(
                                dr("Precio_Unitario"))

                        End If


                        If Not IsDBNull(
                        dr("Costo_Unitario")) Then

                            costoGuardado =
                            Convert.ToDouble(
                                dr("Costo_Unitario"))

                        End If

                    End Using

                End Using


                ' ========================================================
                ' COMPROBAR VALORES
                ' ========================================================

                If esTransferencia Then

                    ' ----------------------------------------------------
                    ' COST-004 / COST-005
                    '
                    ' Ambos campos deben quedar correctamente guardados.
                    ' ----------------------------------------------------

                    If Math.Abs(
                    precioGuardado - precioNuevo) >
                    0.000001 Then

                        Return False

                    End If


                    If Math.Abs(
                    costoGuardado - costoNuevo) >
                    0.000001 Then

                        Return False

                    End If

                Else

                    ' ----------------------------------------------------
                    ' COST-001 / COST-002 / COST-003
                    ' ----------------------------------------------------

                    If Math.Abs(
                    costoGuardado - costoNuevo) >
                    0.000001 Then

                        Return False

                    End If

                End If

            End Using


            ' ============================================================
            ' BITÁCORA
            ' ============================================================

            Dim tipoDocumento As String =
            ObtenerTipoBitacora(
                hallazgo.Tipo)

            Dim accionBitacora As String


            If esTransferenciaEnviada Then

                accionBitacora =
                "Reparo costo Transferencia Enviada:" &
                hallazgo.Documento &
                " Prod:" &
                hallazgo.Producto &
                " Det:" &
                hallazgo.IdDetalleFactura.ToString() &
                " Precio:" &
                precioAnterior.ToString("N6") &
                "->" &
                precioGuardado.ToString("N6") &
                " Costo:" &
                costoAnterior.ToString("N6") &
                "->" &
                costoGuardado.ToString("N6")


            ElseIf esTransferenciaRecibida Then

                accionBitacora =
                "Reparo costo Transferencia Recibida:" &
                hallazgo.Documento &
                " Prod:" &
                hallazgo.Producto &
                " Det:" &
                hallazgo.IdDetalleFactura.ToString() &
                " Precio:" &
                precioAnterior.ToString("N6") &
                "->" &
                precioGuardado.ToString("N6") &
                " Costo:" &
                costoAnterior.ToString("N6") &
                "->" &
                costoGuardado.ToString("N6")


            Else

                accionBitacora =
                "Reparo costo " &
                tipoDocumento &
                ":" &
                hallazgo.Documento &
                " Prod:" &
                hallazgo.Producto &
                " Det:" &
                hallazgo.IdDetalleFactura.ToString() &
                " " &
                costoAnterior.ToString("N6") &
                "->" &
                costoGuardado.ToString("N6")

            End If


            Bitacora(
            Now,
            NombreUsuario,
            "Auditoria Facturacion",
            accionBitacora)


            ' ============================================================
            ' ACTUALIZAR HALLAZGO
            ' ============================================================

            If esTransferencia Then

                hallazgo.PrecioUnitario =
                precioGuardado

                hallazgo.CostoUnitario =
                costoGuardado

                If esTransferenciaEnviada Then

                    hallazgo.Motivo =
                    "La transferencia enviada tenía Precio_Unitario " &
                    "en cero. Se determinó un costo histórico de " &
                    costoNuevo.ToString("N6") &
                    " mediante CostoPromedioKardex. " &
                    "El valor fue asignado a Precio_Unitario y " &
                    "Costo_Unitario."

                Else

                    hallazgo.Motivo =
                    "La transferencia recibida tenía Precio_Unitario " &
                    "en cero. Se determinó un costo histórico de " &
                    costoNuevo.ToString("N6") &
                    " mediante CostoPromedioKardex. " &
                    "El valor fue asignado a Precio_Unitario y " &
                    "Costo_Unitario."

                End If

            Else

                hallazgo.CostoUnitario =
                costoGuardado

                hallazgo.Motivo =
                "El Costo_Unitario fue corregido desde " &
                costoAnterior.ToString("N6") &
                " hasta " &
                costoGuardado.ToString("N6") &
                " utilizando CostoPromedioKardex."

            End If


            hallazgo.Estado =
            EstadoHallazgo.Reparado

            hallazgo.Reparable =
            False

            hallazgo.TieneCostoPropuesto =
            False

            hallazgo.Accion =
            "REPARADO"


            ' ============================================================
            ' ACTUALIZAR EVIDENCIA
            ' ============================================================

            hallazgo.Evidencia.CostoAnterior =
            costoAnterior

            hallazgo.Evidencia.CostoNuevo =
            costoGuardado

            hallazgo.Evidencia.CostoEsperado =
            costoNuevo

            hallazgo.Evidencia.CostoUnitario =
            costoGuardado

            hallazgo.Evidencia.PrecioUnitario =
            precioGuardado

            hallazgo.Evidencia.Motivo =
            hallazgo.Motivo

            hallazgo.Evidencia.Accion =
            hallazgo.Accion


            Return True


        Catch ex As Exception

            Return False

        End Try

    End Function

    ' ============================================================
    ' COSTO PROMEDIO PARA AUDITORÍA
    '
    ' Versión optimizada de CostoPromedioKardex.
    '
    ' IMPORTANTE:
    '   - CostoPromedioKardex NO se modifica.
    '   - Esta función debe producir los mismos resultados.
    '   - Primero se valida contra la función original.
    ' ============================================================
    Private Function CostoPromedioAuditoria(
    ByVal CodigoProducto As String,
    ByVal FechaCompras As Date) As RstCostoPromedio

        Dim resultado As New RstCostoPromedio()

        Dim totalCantidad As Double = 0
        Dim totalImporte As Double = 0
        Dim totalImporteD As Double = 0

        ' ============================================================
        ' CONSTRUIR CONSULTA
        ' ============================================================

        Dim sb As New System.Text.StringBuilder()

        sb.AppendLine("SELECT")
        sb.AppendLine("    ISNULL(SUM(M.Cantidad), 0) AS TotalCantidad,")
        sb.AppendLine("    ISNULL(SUM(M.Importe), 0) AS TotalImporte,")
        sb.AppendLine("    ISNULL(SUM(M.ImporteDolar), 0) AS TotalImporteDolar")
        sb.AppendLine("FROM (")

        ' ============================================================
        ' COMPRAS - CORDOBAS
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    ISNULL(dc.Cantidad, 0) AS Cantidad,")
        sb.AppendLine("    ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0) AS Importe,")
        sb.AppendLine("    (ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0)) / tc.MontoTasa AS ImporteDolar")
        sb.AppendLine("FROM Detalle_Compras dc")
        sb.AppendLine("INNER JOIN Compras c")
        sb.AppendLine("    ON dc.Numero_Compra = c.Numero_Compra")
        sb.AppendLine("   AND dc.Fecha_Compra = c.Fecha_Compra")
        sb.AppendLine("   AND dc.Tipo_Compra = c.Tipo_Compra")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON c.Fecha_Compra = tc.FechaTasa")
        sb.AppendLine("WHERE dc.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND dc.Fecha_Compra <= @Fecha")
        sb.AppendLine("  AND dc.Tipo_Compra = 'Mercancia Recibida'")
        sb.AppendLine("  AND c.MonedaCompra <> 'Dolares'")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' COMPRAS - DOLARES
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    ISNULL(dc.Cantidad, 0),")
        sb.AppendLine("    ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0) * tc.MontoTasa,")
        sb.AppendLine("    ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0)")
        sb.AppendLine("FROM Detalle_Compras dc")
        sb.AppendLine("INNER JOIN Compras c")
        sb.AppendLine("    ON dc.Numero_Compra = c.Numero_Compra")
        sb.AppendLine("   AND dc.Fecha_Compra = c.Fecha_Compra")
        sb.AppendLine("   AND dc.Tipo_Compra = c.Tipo_Compra")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON c.Fecha_Compra = tc.FechaTasa")
        sb.AppendLine("WHERE dc.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND dc.Fecha_Compra <= @Fecha")
        sb.AppendLine("  AND dc.Tipo_Compra = 'Mercancia Recibida'")
        sb.AppendLine("  AND c.MonedaCompra = 'Dolares'")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' DEVOLUCIONES DE COMPRA - CORDOBAS
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    -ISNULL(dc.Cantidad, 0),")
        sb.AppendLine("    -(ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0)),")
        sb.AppendLine("    -(ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0)) / tc.MontoTasa")
        sb.AppendLine("FROM Detalle_Compras dc")
        sb.AppendLine("INNER JOIN Compras c")
        sb.AppendLine("    ON dc.Numero_Compra = c.Numero_Compra")
        sb.AppendLine("   AND dc.Fecha_Compra = c.Fecha_Compra")
        sb.AppendLine("   AND dc.Tipo_Compra = c.Tipo_Compra")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON c.Fecha_Compra = tc.FechaTasa")
        sb.AppendLine("WHERE dc.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND dc.Fecha_Compra <= @Fecha")
        sb.AppendLine("  AND dc.Tipo_Compra = 'Devolucion de Compra'")
        sb.AppendLine("  AND c.MonedaCompra <> 'Dolares'")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' DEVOLUCIONES DE COMPRA - DOLARES
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    -ISNULL(dc.Cantidad, 0),")
        sb.AppendLine("    -(ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0) * tc.MontoTasa),")
        sb.AppendLine("    -(ISNULL(dc.Precio_Neto, 0) * ISNULL(dc.Cantidad, 0))")
        sb.AppendLine("FROM Detalle_Compras dc")
        sb.AppendLine("INNER JOIN Compras c")
        sb.AppendLine("    ON dc.Numero_Compra = c.Numero_Compra")
        sb.AppendLine("   AND dc.Fecha_Compra = c.Fecha_Compra")
        sb.AppendLine("   AND dc.Tipo_Compra = c.Tipo_Compra")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON c.Fecha_Compra = tc.FechaTasa")
        sb.AppendLine("WHERE dc.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND dc.Fecha_Compra <= @Fecha")
        sb.AppendLine("  AND dc.Tipo_Compra = 'Devolucion de Compra'")
        sb.AppendLine("  AND c.MonedaCompra = 'Dolares'")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' FACTURAS
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    CASE")
        sb.AppendLine("        WHEN ISNULL(df.Costo_Unitario, 0) = 0 THEN 0")
        sb.AppendLine("        ELSE ISNULL(df.Cantidad, 0)")
        sb.AppendLine("    END,")
        sb.AppendLine("    -(ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0)),")
        sb.AppendLine("    -(ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0)) / tc.MontoTasa")
        sb.AppendLine("FROM Detalle_Facturas df")
        sb.AppendLine("INNER JOIN Facturas f")
        sb.AppendLine("    ON df.Numero_Factura = f.Numero_Factura")
        sb.AppendLine("   AND df.Fecha_Factura = f.Fecha_Factura")
        sb.AppendLine("   AND df.Tipo_Factura = f.Tipo_Factura")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON f.Fecha_Factura = tc.FechaTasa")
        sb.AppendLine("WHERE df.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND df.Fecha_Factura <= @Fecha")
        sb.AppendLine("  AND df.Tipo_Factura = 'Factura'")
        sb.AppendLine("  AND ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0) <> 0")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' DEVOLUCIONES DE VENTA
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    ISNULL(df.Cantidad, 0),")
        sb.AppendLine("    ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0),")
        sb.AppendLine("    (ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0)) / tc.MontoTasa")
        sb.AppendLine("FROM Detalle_Facturas df")
        sb.AppendLine("INNER JOIN Facturas f")
        sb.AppendLine("    ON df.Numero_Factura = f.Numero_Factura")
        sb.AppendLine("   AND df.Fecha_Factura = f.Fecha_Factura")
        sb.AppendLine("   AND df.Tipo_Factura = f.Tipo_Factura")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON f.Fecha_Factura = tc.FechaTasa")
        sb.AppendLine("WHERE df.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND df.Fecha_Factura <= @Fecha")
        sb.AppendLine("  AND df.Tipo_Factura = 'Devolucion de Venta'")
        sb.AppendLine("  AND ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0) <> 0")

        sb.AppendLine("UNION ALL")

        ' ============================================================
        ' SALIDA BODEGA
        ' ============================================================

        sb.AppendLine("SELECT")
        sb.AppendLine("    CASE")
        sb.AppendLine("        WHEN ISNULL(df.Cantidad, 0) * ISNULL(df.Precio_Unitario, 0) = 0 THEN 0")
        sb.AppendLine("        ELSE -ISNULL(df.Cantidad, 0)")
        sb.AppendLine("    END,")
        sb.AppendLine("    -(ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0)),")
        sb.AppendLine("    -(ISNULL(df.Cantidad, 0) * ISNULL(df.Costo_Unitario, 0)) / tc.MontoTasa")
        sb.AppendLine("FROM Detalle_Facturas df")
        sb.AppendLine("INNER JOIN Facturas f")
        sb.AppendLine("    ON df.Numero_Factura = f.Numero_Factura")
        sb.AppendLine("   AND df.Fecha_Factura = f.Fecha_Factura")
        sb.AppendLine("   AND df.Tipo_Factura = f.Tipo_Factura")
        sb.AppendLine("INNER JOIN TasaCambio tc")
        sb.AppendLine("    ON f.Fecha_Factura = tc.FechaTasa")
        sb.AppendLine("WHERE df.Cod_Producto = @CodigoProducto")
        sb.AppendLine("  AND df.Fecha_Factura <= @Fecha")
        sb.AppendLine("  AND df.Tipo_Factura = 'Salida Bodega'")
        sb.AppendLine("  AND ISNULL(df.Cantidad, 0) * ISNULL(df.Precio_Unitario, 0) <> 0")

        sb.AppendLine(") M")

        Dim sql As String = sb.ToString()

        ' ============================================================
        ' EJECUTAR CONSULTA
        ' ============================================================

        Using cn As New SqlClient.SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlClient.SqlCommand(sql, cn)

                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 300

                cmd.Parameters.Add(
                "@CodigoProducto",
                SqlDbType.NVarChar,
                50).Value = CodigoProducto

                cmd.Parameters.Add(
                "@Fecha",
                SqlDbType.DateTime).Value = FechaCompras

                Using dr As SqlClient.SqlDataReader =
                cmd.ExecuteReader()

                    If dr.Read() Then

                        If Not IsDBNull(dr("TotalCantidad")) Then
                            totalCantidad =
                            Convert.ToDouble(
                                dr("TotalCantidad"))
                        End If

                        If Not IsDBNull(dr("TotalImporte")) Then
                            totalImporte =
                            Convert.ToDouble(
                                dr("TotalImporte"))
                        End If

                        If Not IsDBNull(
                        dr("TotalImporteDolar")) Then

                            totalImporteD =
                            Convert.ToDouble(
                                dr("TotalImporteDolar"))

                        End If

                    End If

                End Using

            End Using

        End Using

        ' ============================================================
        ' CALCULAR COSTO PROMEDIO
        ' ============================================================

        Dim precioCosto As Double = 0
        Dim precioCostoDolar As Double = 0

        If totalCantidad <> 0 Then

            precioCosto =
            totalImporte / totalCantidad

            precioCostoDolar =
            totalImporteD / totalCantidad

        Else

            precioCosto = 0
            precioCostoDolar = 0

        End If

        ' ============================================================
        ' RESPALDO DEL COSTO
        ' ============================================================

        If precioCosto = 0 Then

            Dim sqlUltimoCosto As String =
            "SELECT TOP 1 " &
            "    df.Costo_Unitario, " &
            "    df.Fecha_Factura " &
            "FROM Detalle_Facturas df " &
            "WHERE df.Cod_Producto = @CodigoProducto " &
            "  AND df.Costo_Unitario <> 0 " &
            "  AND df.Fecha_Factura <= @Fecha " &
            "ORDER BY df.Fecha_Factura DESC"

            Using cn As New SqlClient.SqlConnection(Conexion)

                cn.Open()

                Using cmd As New SqlClient.SqlCommand(
                sqlUltimoCosto, cn)

                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 300

                    cmd.Parameters.Add(
                    "@CodigoProducto",
                    SqlDbType.NVarChar,
                    50).Value = CodigoProducto

                    cmd.Parameters.Add(
                    "@Fecha",
                    SqlDbType.DateTime).Value = FechaCompras

                    Using dr As SqlClient.SqlDataReader =
                    cmd.ExecuteReader()

                        If dr.Read() Then

                            If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                                precioCosto =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                            End If

                            If Not IsDBNull(
                            dr("Fecha_Factura")) Then

                                Dim fechaCosto As DateTime =
                                Convert.ToDateTime(
                                    dr("Fecha_Factura"))

                                precioCostoDolar =
                                precioCosto *
                                BuscaTasaCambio(fechaCosto)

                            End If

                        End If

                    End Using

                End Using

            End Using

        End If

        ' ============================================================
        ' RESULTADO
        ' ============================================================

        resultado.Codigo_Producto =
        CodigoProducto

        resultado.Fecha_Compras =
        FechaCompras

        resultado.Costo_Cordoba =
        precioCosto

        resultado.Costo_Dolar =
        precioCostoDolar

        Return resultado

    End Function




    ' ============================================================
    ' CABECERA DEL DETALLE
    '
    ' El kardex y el costo promedio unen Detalle_Facturas con
    ' Facturas (INNER JOIN): un detalle sin cabecera pertenece a un
    ' documento que nunca se guardó y no afecta inventario ni costos.
    ' Reportarlo en los controles de costo y transferencias es un
    ' falso positivo (y su "reparación" crearía movimientos reales).
    ' Esos detalles huérfanos se informan aparte en DATA-005.
    ' ============================================================
    Private Function ExisteCabeceraFactura(
        ByVal alias_ As String) As String

        Return "EXISTS (SELECT 1 FROM Facturas cab " &
            "WHERE cab.Numero_Factura = " & alias_ & ".Numero_Factura " &
            "AND cab.Fecha_Factura = " & alias_ & ".Fecha_Factura " &
            "AND cab.Tipo_Factura = " & alias_ & ".Tipo_Factura)"

    End Function

    ' ============================================================
    ' COST-001
    ' FACTURA CON COSTO UNITARIO CERO
    ' ============================================================
    Private Function AuditarCost001(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim sql As String =
            "SELECT " &
            "    df.id_Detalle_Factura, " &
            "    df.Numero_Factura, " &
            "    df.Fecha_Factura, " &
            "    df.Tipo_Factura, " &
            "    df.Cod_Producto, " &
            "    df.Cantidad, " &
            "    df.Precio_Unitario, " &
            "    df.Costo_Unitario " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = df.Cod_Producto " &
            "WHERE df.Tipo_Factura = @TipoFactura " &
            "  AND " & ExisteCabeceraFactura("df") & " " &
            "  AND ISNULL(df.Cantidad, 0) <> 0 " &
            "  AND ISNULL(df.Costo_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento') " &
            "ORDER BY " &
            "    df.Fecha_Factura, " &
            "    df.Numero_Factura, " &
            "    df.id_Detalle_Factura"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(sql, cn)

                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 300

                cmd.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value = "Factura"

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()

                        Dim hallazgo As New HallazgoAuditoria()

                        ' ------------------------------------------------
                        ' CONTROL
                        ' ------------------------------------------------

                        hallazgo.Control = control

                        hallazgo.Codigo =
                            control.Codigo

                        hallazgo.Descripcion =
                            control.Descripcion

                        hallazgo.Severidad =
                            control.Severidad

                        ' ------------------------------------------------
                        ' ID DETALLE
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("id_Detalle_Factura")) Then

                            hallazgo.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Factura"))

                        End If

                        ' ------------------------------------------------
                        ' DOCUMENTO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Numero_Factura")) Then

                            hallazgo.Documento =
                                dr("Numero_Factura").ToString()

                        End If

                        ' ------------------------------------------------
                        ' FECHA
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Fecha_Factura")) Then

                            hallazgo.Fecha =
                                Convert.ToDateTime(
                                    dr("Fecha_Factura"))

                        End If

                        ' ------------------------------------------------
                        ' TIPO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Tipo_Factura")) Then

                            hallazgo.Tipo =
                                dr("Tipo_Factura").ToString()

                        End If

                        ' ------------------------------------------------
                        ' PRODUCTO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Cod_Producto")) Then

                            hallazgo.Producto =
                                dr("Cod_Producto").ToString()

                        End If

                        ' ------------------------------------------------
                        ' CANTIDAD
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Cantidad")) Then

                            hallazgo.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                        End If

                        ' ------------------------------------------------
                        ' PRECIO UNITARIO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                            hallazgo.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                        End If

                        ' ------------------------------------------------
                        ' COSTO ACTUAL
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                            hallazgo.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                        Else

                            hallazgo.CostoUnitario = 0

                        End If

                        ' ------------------------------------------------
                        ' ESTADO INICIAL
                        ' ------------------------------------------------

                        hallazgo.Estado =
                            EstadoHallazgo.Detectado

                        hallazgo.Reparable = False

                        hallazgo.TieneCostoPropuesto = False

                        hallazgo.CostoPropuesto = 0

                        hallazgo.CostoPropuestoDolar = 0

                        hallazgo.OrigenCosto =
                            String.Empty

                        ' ------------------------------------------------
                        ' MOTIVO INICIAL
                        ' ------------------------------------------------

                        hallazgo.Motivo =
                            "La factura contiene un producto " &
                            "que no es Servicio ni Descuento, " &
                            "pero Costo_Unitario es cero."

                        ' ------------------------------------------------
                        ' ACCIÓN INICIAL
                        ' ------------------------------------------------

                        hallazgo.Accion =
                            "REVISIÓN MANUAL"

                        ' ------------------------------------------------
                        ' EVIDENCIA
                        ' ------------------------------------------------

                        hallazgo.Evidencia.Documento =
                            hallazgo.Documento

                        hallazgo.Evidencia.Fecha =
                            hallazgo.Fecha

                        hallazgo.Evidencia.Tipo =
                            hallazgo.Tipo

                        hallazgo.Evidencia.Producto =
                            hallazgo.Producto

                        hallazgo.Evidencia.Cantidad =
                            hallazgo.Cantidad

                        hallazgo.Evidencia.PrecioUnitario =
                            hallazgo.PrecioUnitario

                        hallazgo.Evidencia.CostoUnitario =
                            hallazgo.CostoUnitario

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion

                        ' ------------------------------------------------
                        ' DETERMINAR COSTO CON KARDEX
                        ' ------------------------------------------------

                        DeterminarCostoReparacion(
                            hallazgo)

                        ' ------------------------------------------------
                        ' ACTUALIZAR EVIDENCIA CON EL RESULTADO
                        ' ------------------------------------------------

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion

                        ' ------------------------------------------------
                        ' AGREGAR HALLAZGO
                        ' ------------------------------------------------

                        hallazgos.Add(hallazgo)

                    End While

                End Using

            End Using

        End Using

        Return hallazgos

    End Function


    ' ============================================================
    ' COST-002
    ' DEVOLUCION DE VENTA CON COSTO UNITARIO CERO
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    ' ============================================================
    Private Function AuditarCost002(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim sql As String =
            "SELECT " &
            "    df.id_Detalle_Factura, " &
            "    df.Numero_Factura, " &
            "    df.Fecha_Factura, " &
            "    df.Tipo_Factura, " &
            "    df.Cod_Producto, " &
            "    df.Cantidad, " &
            "    df.Precio_Unitario, " &
            "    df.Costo_Unitario " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = df.Cod_Producto " &
            "WHERE df.Tipo_Factura = @TipoFactura " &
            "  AND " & ExisteCabeceraFactura("df") & " " &
            "  AND ISNULL(df.Cantidad, 0) <> 0 " &
            "  AND ISNULL(df.Costo_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento') " &
            "ORDER BY " &
            "    df.Fecha_Factura, " &
            "    df.Numero_Factura, " &
            "    df.id_Detalle_Factura"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(sql, cn)

                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 300

                cmd.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value =
                    "Devolucion de Venta"

                Using dr As SqlDataReader =
                    cmd.ExecuteReader()

                    While dr.Read()

                        Dim hallazgo As New HallazgoAuditoria()

                        ' ====================================================
                        ' CONTROL
                        ' ====================================================

                        hallazgo.Control =
                            control

                        hallazgo.Codigo =
                            control.Codigo

                        hallazgo.Descripcion =
                            control.Descripcion

                        hallazgo.Severidad =
                            control.Severidad

                        ' ====================================================
                        ' ID DETALLE
                        ' ====================================================

                        If Not IsDBNull(
                            dr("id_Detalle_Factura")) Then

                            hallazgo.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Factura"))

                        End If

                        ' ====================================================
                        ' DOCUMENTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Numero_Factura")) Then

                            hallazgo.Documento =
                                dr("Numero_Factura").ToString()

                        End If

                        ' ====================================================
                        ' FECHA
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Fecha_Factura")) Then

                            hallazgo.Fecha =
                                Convert.ToDateTime(
                                    dr("Fecha_Factura"))

                        End If

                        ' ====================================================
                        ' TIPO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Tipo_Factura")) Then

                            hallazgo.Tipo =
                                dr("Tipo_Factura").ToString()

                        End If

                        ' ====================================================
                        ' PRODUCTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cod_Producto")) Then

                            hallazgo.Producto =
                                dr("Cod_Producto").ToString()

                        End If

                        ' ====================================================
                        ' CANTIDAD
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cantidad")) Then

                            hallazgo.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                        End If

                        ' ====================================================
                        ' PRECIO UNITARIO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                            hallazgo.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                        End If

                        ' ====================================================
                        ' COSTO ACTUAL
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                            hallazgo.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                        Else

                            hallazgo.CostoUnitario = 0

                        End If

                        ' ====================================================
                        ' ESTADO INICIAL
                        ' ====================================================

                        hallazgo.Estado =
                            EstadoHallazgo.Detectado

                        hallazgo.Reparable = False

                        hallazgo.TieneCostoPropuesto = False

                        hallazgo.CostoPropuesto = 0

                        hallazgo.CostoPropuestoDolar = 0

                        hallazgo.OrigenCosto =
                            String.Empty

                        ' ====================================================
                        ' DETERMINAR COSTO HISTORICO
                        ' ====================================================

                        DeterminarCostoReparacionDevolucion(
                            hallazgo)

                        ' ====================================================
                        ' EVIDENCIA
                        ' ====================================================

                        hallazgo.Evidencia.Documento =
                            hallazgo.Documento

                        hallazgo.Evidencia.Fecha =
                            hallazgo.Fecha

                        hallazgo.Evidencia.Tipo =
                            hallazgo.Tipo

                        hallazgo.Evidencia.Producto =
                            hallazgo.Producto

                        hallazgo.Evidencia.Cantidad =
                            hallazgo.Cantidad

                        hallazgo.Evidencia.PrecioUnitario =
                            hallazgo.PrecioUnitario

                        hallazgo.Evidencia.CostoUnitario =
                            hallazgo.CostoUnitario

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion

                        ' ====================================================
                        ' AGREGAR HALLAZGO
                        ' ====================================================

                        hallazgos.Add(
                            hallazgo)

                    End While

                End Using

            End Using

        End Using

        Return hallazgos

    End Function


    ' ============================================================
    ' COST-003
    ' SALIDA DE BODEGA CON COSTO UNITARIO CERO
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    ' ============================================================
    Private Function AuditarCost003(
    ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim sql As String =
            "SELECT " &
            "    df.id_Detalle_Factura, " &
            "    df.Numero_Factura, " &
            "    df.Fecha_Factura, " &
            "    df.Tipo_Factura, " &
            "    df.Cod_Producto, " &
            "    df.Cantidad, " &
            "    df.Precio_Unitario, " &
            "    df.Costo_Unitario " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = df.Cod_Producto " &
            "WHERE df.Tipo_Factura = @TipoFactura " &
            "  AND " & ExisteCabeceraFactura("df") & " " &
            "  AND ISNULL(df.Cantidad, 0) <> 0 " &
            "  AND ISNULL(df.Costo_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento') " &
            "ORDER BY " &
            "    df.Fecha_Factura, " &
            "    df.Numero_Factura, " &
            "    df.id_Detalle_Factura"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(sql, cn)

                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 300

                cmd.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value = "Salida Bodega"

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()

                        Dim hallazgo As New HallazgoAuditoria()

                        ' ------------------------------------------------
                        ' CONTROL
                        ' ------------------------------------------------

                        hallazgo.Control = control

                        hallazgo.Codigo =
                            control.Codigo

                        hallazgo.Descripcion =
                            control.Descripcion

                        hallazgo.Severidad =
                            control.Severidad

                        ' ------------------------------------------------
                        ' ID DETALLE
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("id_Detalle_Factura")) Then

                            hallazgo.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Factura"))

                        End If

                        ' ------------------------------------------------
                        ' DOCUMENTO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Numero_Factura")) Then

                            hallazgo.Documento =
                                dr("Numero_Factura").ToString()

                        End If

                        ' ------------------------------------------------
                        ' FECHA
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Fecha_Factura")) Then

                            hallazgo.Fecha =
                                Convert.ToDateTime(
                                    dr("Fecha_Factura"))

                        End If

                        ' ------------------------------------------------
                        ' TIPO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Tipo_Factura")) Then

                            hallazgo.Tipo =
                                dr("Tipo_Factura").ToString()

                        End If

                        ' ------------------------------------------------
                        ' PRODUCTO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Cod_Producto")) Then

                            hallazgo.Producto =
                                dr("Cod_Producto").ToString()

                        End If

                        ' ------------------------------------------------
                        ' CANTIDAD
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Cantidad")) Then

                            hallazgo.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                        End If

                        ' ------------------------------------------------
                        ' PRECIO UNITARIO
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                            hallazgo.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                        End If

                        ' ------------------------------------------------
                        ' COSTO ACTUAL
                        ' ------------------------------------------------

                        If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                            hallazgo.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                        Else

                            hallazgo.CostoUnitario = 0

                        End If

                        ' ------------------------------------------------
                        ' ESTADO INICIAL
                        ' ------------------------------------------------

                        hallazgo.Estado =
                            EstadoHallazgo.Detectado

                        hallazgo.Reparable = False

                        hallazgo.TieneCostoPropuesto = False

                        hallazgo.CostoPropuesto = 0

                        hallazgo.CostoPropuestoDolar = 0

                        hallazgo.OrigenCosto =
                            String.Empty

                        ' ------------------------------------------------
                        ' MOTIVO INICIAL
                        ' ------------------------------------------------

                        hallazgo.Motivo =
                            "La salida de bodega tiene Costo_Unitario " &
                            "en cero."

                        ' ------------------------------------------------
                        ' ACCIÓN INICIAL
                        ' ------------------------------------------------

                        hallazgo.Accion =
                            "REVISIÓN MANUAL"

                        ' ------------------------------------------------
                        ' EVIDENCIA
                        ' ------------------------------------------------

                        hallazgo.Evidencia.Documento =
                            hallazgo.Documento

                        hallazgo.Evidencia.Fecha =
                            hallazgo.Fecha

                        hallazgo.Evidencia.Tipo =
                            hallazgo.Tipo

                        hallazgo.Evidencia.Producto =
                            hallazgo.Producto

                        hallazgo.Evidencia.Cantidad =
                            hallazgo.Cantidad

                        hallazgo.Evidencia.PrecioUnitario =
                            hallazgo.PrecioUnitario

                        hallazgo.Evidencia.CostoUnitario =
                            hallazgo.CostoUnitario

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion

                        ' ------------------------------------------------
                        ' DETERMINAR COSTO
                        ' ------------------------------------------------

                        DeterminarCostoReparacionSalidaBodega(
                            hallazgo)

                        ' ------------------------------------------------
                        ' ACTUALIZAR EVIDENCIA
                        ' ------------------------------------------------

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion

                        ' ------------------------------------------------
                        ' AGREGAR HALLAZGO
                        ' ------------------------------------------------

                        hallazgos.Add(hallazgo)

                    End While

                End Using

            End Using

        End Using

        Return hallazgos

    End Function

    ' ============================================================
    ' COST-004
    ' TRANSFERENCIA ENVIADA CON COSTO UNITARIO CERO
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    ' ============================================================
    Private Function AuditarCost004(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        ' ============================================================
        ' CONSULTA
        '
        ' COST-004:
        ' Transferencia Enviada con Precio_Unitario en cero.
        '
        ' IMPORTANTE:
        ' CostoPromedioKardex solamente se ejecutará sobre
        ' los registros que SQL encuentre aquí.
        ' ============================================================

        Dim sql As String =
            "SELECT " &
            "    df.id_Detalle_Factura, " &
            "    df.Numero_Factura, " &
            "    df.Fecha_Factura, " &
            "    df.Tipo_Factura, " &
            "    df.Cod_Producto, " &
            "    df.Cantidad, " &
            "    df.Precio_Unitario, " &
            "    df.Costo_Unitario " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = df.Cod_Producto " &
            "WHERE df.Tipo_Factura = @TipoFactura " &
            "  AND " & ExisteCabeceraFactura("df") & " " &
            "  AND ISNULL(df.Cantidad, 0) <> 0 " &
            "  AND ISNULL(df.Precio_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento') " &
            "ORDER BY " &
            "    df.Fecha_Factura, " &
            "    df.Numero_Factura, " &
            "    df.id_Detalle_Factura"


        ' ============================================================
        ' CONTAR REGISTROS
        '
        ' Necesitamos saber cuántos candidatos existen para poder
        ' mostrar progreso real mientras se procesan.
        ' ============================================================

        Dim totalRegistros As Integer = 0

        Dim sqlCount As String =
            "SELECT COUNT(*) " &
            "FROM Detalle_Facturas df " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = df.Cod_Producto " &
            "WHERE df.Tipo_Factura = @TipoFactura " &
            "  AND " & ExisteCabeceraFactura("df") & " " &
            "  AND ISNULL(df.Cantidad, 0) <> 0 " &
            "  AND ISNULL(df.Precio_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento')"


        Using cnCount As New SqlConnection(Conexion)

            cnCount.Open()

            Using cmdCount As New SqlCommand(
                sqlCount,
                cnCount)

                cmdCount.CommandType =
                    CommandType.Text

                cmdCount.CommandTimeout =
                    300

                cmdCount.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value =
                        "Transferencia Enviada"

                totalRegistros =
                    Convert.ToInt32(
                        cmdCount.ExecuteScalar())

            End Using

        End Using


        ' ============================================================
        ' INFORMAR INICIO DEL CONTROL
        ' ============================================================

        If totalRegistros = 0 Then

            RaiseEvent Progreso(
                PorcentajeSegmento(1),
                "COST-004 finalizado. No se encontraron " &
                "transferencias enviadas con Precio_Unitario cero.")

            Return hallazgos

        End If


        RaiseEvent Progreso(
            PorcentajeSegmento(0),
            "Verificando COST-004 - Transferencias Enviadas con Precio_Unitario cero...")


        ' ============================================================
        ' PROCESAR REGISTROS
        ' ============================================================

        Dim registrosProcesados As Integer = 0


        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(
                sql,
                cn)

                cmd.CommandType =
                    CommandType.Text

                cmd.CommandTimeout =
                    300

                cmd.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value =
                        "Transferencia Enviada"


                Using dr As SqlDataReader =
                    cmd.ExecuteReader()


                    While dr.Read()

                        ' ====================================================
                        ' CONTROL DE CANCELACIÓN
                        ' ====================================================

                        If DebeCancelar() Then

                            Exit While

                        End If


                        Dim hallazgo As New HallazgoAuditoria()


                        ' ====================================================
                        ' CONTROL
                        ' ====================================================

                        hallazgo.Control =
                            control

                        hallazgo.Codigo =
                            control.Codigo

                        hallazgo.Descripcion =
                            control.Descripcion

                        hallazgo.Severidad =
                            control.Severidad


                        ' ====================================================
                        ' ID DETALLE
                        ' ====================================================

                        If Not IsDBNull(
                            dr("id_Detalle_Factura")) Then

                            hallazgo.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Factura"))

                        End If


                        ' ====================================================
                        ' DOCUMENTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Numero_Factura")) Then

                            hallazgo.Documento =
                                dr("Numero_Factura").ToString()

                        End If


                        ' ====================================================
                        ' FECHA
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Fecha_Factura")) Then

                            hallazgo.Fecha =
                                Convert.ToDateTime(
                                    dr("Fecha_Factura"))

                        End If


                        ' ====================================================
                        ' TIPO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Tipo_Factura")) Then

                            hallazgo.Tipo =
                                dr("Tipo_Factura").ToString()

                        End If


                        ' ====================================================
                        ' PRODUCTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cod_Producto")) Then

                            hallazgo.Producto =
                                dr("Cod_Producto").ToString().Trim()

                        End If


                        ' ====================================================
                        ' CANTIDAD
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cantidad")) Then

                            hallazgo.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                        End If


                        ' ====================================================
                        ' PRECIO UNITARIO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                            hallazgo.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                        Else

                            hallazgo.PrecioUnitario =
                                0

                        End If


                        ' ====================================================
                        ' COSTO UNITARIO
                        '
                        ' Solo se carga como evidencia.
                        ' NO participa en COST-004.
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                            hallazgo.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                        Else

                            hallazgo.CostoUnitario =
                                0

                        End If


                        ' ====================================================
                        ' ESTADO INICIAL
                        ' ====================================================

                        hallazgo.Estado =
                            EstadoHallazgo.Detectado

                        hallazgo.Reparable =
                            False

                        hallazgo.TieneCostoPropuesto =
                            False

                        hallazgo.CostoPropuesto =
                            0

                        hallazgo.CostoPropuestoDolar =
                            0

                        hallazgo.OrigenCosto =
                            String.Empty


                        ' ====================================================
                        ' MOTIVO INICIAL
                        ' ====================================================

                        hallazgo.Motivo =
                            "La transferencia enviada tiene " &
                            "Precio_Unitario en cero."


                        ' ====================================================
                        ' ACCIÓN INICIAL
                        ' ====================================================

                        hallazgo.Accion =
                            "REVISIÓN MANUAL"


                        ' ====================================================
                        ' EVIDENCIA INICIAL
                        ' ====================================================

                        hallazgo.Evidencia.Documento =
                            hallazgo.Documento

                        hallazgo.Evidencia.Fecha =
                            hallazgo.Fecha

                        hallazgo.Evidencia.Tipo =
                            hallazgo.Tipo

                        hallazgo.Evidencia.Producto =
                            hallazgo.Producto

                        hallazgo.Evidencia.Cantidad =
                            hallazgo.Cantidad

                        hallazgo.Evidencia.PrecioUnitario =
                            hallazgo.PrecioUnitario

                        hallazgo.Evidencia.CostoUnitario =
                            hallazgo.CostoUnitario

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion


                        ' ====================================================
                        ' DETERMINAR COSTO CON KARDEX
                        '
                        ' SOLO llegamos aquí porque SQL encontró:
                        '
                        ' Precio_Unitario = 0
                        '
                        ' ====================================================

                        DeterminarCostoReparacionTransferencia(
                            hallazgo)


                        ' ====================================================
                        ' ACTUALIZAR EVIDENCIA CON EL RESULTADO
                        ' ====================================================

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion


                        ' ====================================================
                        ' AGREGAR HALLAZGO
                        ' ====================================================

                        hallazgos.Add(
                            hallazgo)


                        ' ====================================================
                        ' ACTUALIZAR PROGRESO
                        '
                        ' COST-004 ocupa aproximadamente del 85% al 95%.
                        ' ====================================================

                        registrosProcesados += 1


                        Dim porcentaje As Integer =
                            PorcentajeSegmento(
                                registrosProcesados /
                                CDbl(totalRegistros))


                        RaiseEvent Progreso(
                            porcentaje,
                            "Verificando COST-004 - Transferencias Enviadas... " &
                            registrosProcesados.ToString() &
                            " de " &
                            totalRegistros.ToString())


                    End While


                End Using

            End Using

        End Using


        ' ============================================================
        ' FINALIZAR COST-004
        ' ============================================================

        RaiseEvent Progreso(
            PorcentajeSegmento(1),
            "COST-004 finalizado. " &
            hallazgos.Count.ToString() &
            " hallazgo(s) encontrado(s).")


        Return hallazgos

    End Function

    ' ============================================================
    ' COST-005
    ' TRANSFERENCIA RECIBIDA CON COSTO UNITARIO CERO
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    ' ============================================================
    Private Function AuditarCost005(
    ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        ' ============================================================
        ' CONSULTA
        '
        ' COST-005:
        ' Transferencia Recibida con Precio_Unitario en cero.
        '
        ' Solamente estos registros serán evaluados con
        ' CostoPromedioKardex.
        ' ============================================================

        Dim sql As String =
            "SELECT " &
            "    dc.id_Detalle_Compra, " &
            "    dc.Numero_Compra, " &
            "    dc.Fecha_Compra, " &
            "    dc.Tipo_Compra, " &
            "    dc.Cod_Producto, " &
            "    dc.Cantidad, " &
            "    dc.Precio_Unitario, " &
            "    dc.Costo_Unitario, " &
            "    dc.Descripcion_Producto, " &
            "    dc.id_Detalle_Transferencia " &
            "FROM Detalle_Compras dc " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = dc.Cod_Producto " &
            "WHERE dc.Tipo_Compra = @TipoCompra " &
            "  AND ISNULL(dc.Cantidad, 0) <> 0 " &
            "  AND ISNULL(dc.Precio_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento') " &
            "ORDER BY " &
            "    dc.Fecha_Compra, " &
            "    dc.Numero_Compra, " &
            "    dc.id_Detalle_Compra"


        ' ============================================================
        ' CONTAR REGISTROS
        ' ============================================================

        Dim totalRegistros As Integer = 0

        Dim sqlCount As String =
            "SELECT COUNT(*) " &
            "FROM Detalle_Compras dc " &
            "LEFT JOIN Productos p " &
            "    ON p.Cod_Productos = dc.Cod_Producto " &
            "WHERE dc.Tipo_Compra = @TipoCompra " &
            "  AND ISNULL(dc.Cantidad, 0) <> 0 " &
            "  AND ISNULL(dc.Precio_Unitario, 0) = 0 " &
            "  AND ISNULL(p.Tipo_Producto, '') " &
            "      NOT IN ('Servicio', 'Descuento')"


        Using cnCount As New SqlConnection(Conexion)

            cnCount.Open()

            Using cmdCount As New SqlCommand(
                sqlCount,
                cnCount)

                cmdCount.CommandType =
                    CommandType.Text

                cmdCount.CommandTimeout =
                    300

                cmdCount.Parameters.Add(
                    "@TipoCompra",
                    SqlDbType.NVarChar,
                    50).Value =
                        "Transferencia Recibida"

                totalRegistros =
                    Convert.ToInt32(
                        cmdCount.ExecuteScalar())

            End Using

        End Using


        ' ============================================================
        ' SIN HALLAZGOS
        ' ============================================================

        If totalRegistros = 0 Then

            RaiseEvent Progreso(
                PorcentajeSegmento(1),
                "COST-005 finalizado. No se encontraron " &
                "transferencias recibidas con Precio_Unitario cero.")

            Return hallazgos

        End If


        RaiseEvent Progreso(
            PorcentajeSegmento(0),
            "Verificando COST-005 - Transferencias Recibidas con Precio_Unitario cero...")


        ' ============================================================
        ' PROCESAR REGISTROS
        ' ============================================================

        Dim registrosProcesados As Integer = 0


        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using cmd As New SqlCommand(
                sql,
                cn)

                cmd.CommandType =
                    CommandType.Text

                cmd.CommandTimeout =
                    300

                cmd.Parameters.Add(
                    "@TipoCompra",
                    SqlDbType.NVarChar,
                    50).Value =
                        "Transferencia Recibida"


                Using dr As SqlDataReader =
                    cmd.ExecuteReader()


                    While dr.Read()

                        ' ====================================================
                        ' CANCELACIÓN
                        ' ====================================================

                        If DebeCancelar() Then

                            Exit While

                        End If


                        Dim hallazgo As New HallazgoAuditoria()


                        ' ====================================================
                        ' CONTROL
                        ' ====================================================

                        hallazgo.Control =
                            control

                        hallazgo.Codigo =
                            control.Codigo

                        hallazgo.Descripcion =
                            control.Descripcion

                        hallazgo.Severidad =
                            control.Severidad


                        ' ====================================================
                        ' ID DETALLE
                        '
                        ' HallazgoAuditoria actualmente utiliza
                        ' IdDetalleFactura como identificador.
                        '
                        ' Para COST-005 guardamos aquí el
                        ' id_Detalle_Compra.
                        ' ====================================================

                        If Not IsDBNull(
                            dr("id_Detalle_Compra")) Then

                            hallazgo.IdDetalleFactura =
                                Convert.ToDecimal(
                                    dr("id_Detalle_Compra"))

                        End If


                        ' ====================================================
                        ' DOCUMENTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Numero_Compra")) Then

                            hallazgo.Documento =
                                dr("Numero_Compra").ToString()

                        End If


                        ' ====================================================
                        ' FECHA
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Fecha_Compra")) Then

                            hallazgo.Fecha =
                                Convert.ToDateTime(
                                    dr("Fecha_Compra"))

                        End If


                        ' ====================================================
                        ' TIPO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Tipo_Compra")) Then

                            hallazgo.Tipo =
                                dr("Tipo_Compra").ToString()

                        End If


                        ' ====================================================
                        ' PRODUCTO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cod_Producto")) Then

                            hallazgo.Producto =
                                dr("Cod_Producto").ToString().Trim()

                        End If


                        ' ====================================================
                        ' CANTIDAD
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Cantidad")) Then

                            hallazgo.Cantidad =
                                Convert.ToDouble(
                                    dr("Cantidad"))

                        End If


                        ' ====================================================
                        ' PRECIO UNITARIO
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Precio_Unitario")) Then

                            hallazgo.PrecioUnitario =
                                Convert.ToDouble(
                                    dr("Precio_Unitario"))

                        Else

                            hallazgo.PrecioUnitario =
                                0

                        End If


                        ' ====================================================
                        ' COSTO UNITARIO
                        '
                        ' Solo se carga como evidencia.
                        ' ====================================================

                        If Not IsDBNull(
                            dr("Costo_Unitario")) Then

                            hallazgo.CostoUnitario =
                                Convert.ToDouble(
                                    dr("Costo_Unitario"))

                        Else

                            hallazgo.CostoUnitario =
                                0

                        End If


                        ' ====================================================
                        ' ESTADO INICIAL
                        ' ====================================================

                        hallazgo.Estado =
                            EstadoHallazgo.Detectado

                        hallazgo.Reparable =
                            False

                        hallazgo.TieneCostoPropuesto =
                            False

                        hallazgo.CostoPropuesto =
                            0

                        hallazgo.CostoPropuestoDolar =
                            0

                        hallazgo.OrigenCosto =
                            String.Empty


                        ' ====================================================
                        ' MOTIVO
                        ' ====================================================

                        hallazgo.Motivo =
                            "La transferencia recibida tiene " &
                            "Precio_Unitario en cero."


                        ' ====================================================
                        ' ACCIÓN
                        ' ====================================================

                        hallazgo.Accion =
                            "REVISIÓN MANUAL"


                        ' ====================================================
                        ' EVIDENCIA
                        ' ====================================================

                        hallazgo.Evidencia.Documento =
                            hallazgo.Documento

                        hallazgo.Evidencia.Fecha =
                            hallazgo.Fecha

                        hallazgo.Evidencia.Tipo =
                            hallazgo.Tipo

                        hallazgo.Evidencia.Producto =
                            hallazgo.Producto

                        hallazgo.Evidencia.Cantidad =
                            hallazgo.Cantidad

                        hallazgo.Evidencia.PrecioUnitario =
                            hallazgo.PrecioUnitario

                        hallazgo.Evidencia.CostoUnitario =
                            hallazgo.CostoUnitario

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion


                        ' ====================================================
                        ' DETERMINAR COSTO
                        ' ====================================================

                        DeterminarCostoReparacionTransferenciaRecibida(
                            hallazgo)


                        ' ====================================================
                        ' ACTUALIZAR EVIDENCIA
                        ' ====================================================

                        hallazgo.Evidencia.Motivo =
                            hallazgo.Motivo

                        hallazgo.Evidencia.Accion =
                            hallazgo.Accion


                        ' ====================================================
                        ' AGREGAR HALLAZGO
                        ' ====================================================

                        hallazgos.Add(
                            hallazgo)


                        ' ====================================================
                        ' PROGRESO
                        ' ====================================================

                        registrosProcesados += 1

                        Dim porcentaje As Integer =
                            PorcentajeSegmento(
                                registrosProcesados /
                                CDbl(totalRegistros))

                        RaiseEvent Progreso(
                            porcentaje,
                            "Verificando COST-005 - Transferencias Recibidas... " &
                            registrosProcesados.ToString() &
                            " de " &
                            totalRegistros.ToString())

                    End While

                End Using

            End Using

        End Using


        ' ============================================================
        ' FINALIZAR COST-005
        ' ============================================================

        RaiseEvent Progreso(
            PorcentajeSegmento(1),
            "COST-005 finalizado. " &
            hallazgos.Count.ToString() &
            " hallazgo(s) encontrado(s).")


        Return hallazgos

    End Function

    ' ============================================================
    ' TRANS-001
    ' TRANSFERENCIA ENVIADA SIN TRANSFERENCIA RECIBIDA
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    ' ============================================================
    Private Function AuditarTrans001(
    ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        ' ============================================================
        ' CARGAR TRANSFERENCIAS RECIBIDAS EN MEMORIA
        ' ============================================================

        Dim dtRecibidas As New DataTable()

        Dim sqlRecibidas As String = ""

        sqlRecibidas &= "SELECT " & vbCrLf
        sqlRecibidas &= "    id_Detalle_Compra, " & vbCrLf
        sqlRecibidas &= "    Numero_Compra, " & vbCrLf
        sqlRecibidas &= "    Fecha_Compra, " & vbCrLf
        sqlRecibidas &= "    Cod_Producto, Descripcion_Producto," & vbCrLf
        sqlRecibidas &= "    Cantidad, " & vbCrLf
        sqlRecibidas &= "    Precio_Unitario, " & vbCrLf
        sqlRecibidas &= "    Costo_Unitario, " & vbCrLf
        sqlRecibidas &= "    id_Detalle_Transferencia " & vbCrLf
        sqlRecibidas &= "FROM Detalle_Compras " & vbCrLf
        sqlRecibidas &= "WHERE Tipo_Compra = N'Transferencia Recibida'" & vbCrLf
        sqlRecibidas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(
            sqlRecibidas, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtRecibidas)

            End Using

        End Using


        ' ============================================================
        ' RECIBIDAS CON VÍNCULO A UNA ENVIADA DE OTRO PRODUCTO
        '
        ' Su id_Detalle_Transferencia es incorrecto (lo reporta
        ' TRANS-003). Se tratan como sin relación para que no
        ' oculten ni clasifiquen mal a la enviada que les corresponde.
        ' ============================================================

        Dim recibidasMalVinculadas As HashSet(Of Decimal) =
        ObtenerIdsTransferencia(
            "SELECT c.id_Detalle_Compra " &
            "FROM Detalle_Compras c " &
            "LEFT JOIN Detalle_Facturas f " &
            "  ON f.id_Detalle_Factura = c.id_Detalle_Transferencia " &
            " AND f.Tipo_Factura = N'Transferencia Enviada' " &
            "WHERE c.Tipo_Compra = N'Transferencia Recibida' " &
            "AND ISNULL(c.id_Detalle_Transferencia, 0) <> 0 " &
            "AND (f.id_Detalle_Factura IS NULL " &
            "     OR LTRIM(RTRIM(f.Cod_Producto)) <> LTRIM(RTRIM(c.Cod_Producto)) " &
            "     OR (f.Numero_Factura <> c.Numero_Compra " &
            "         AND f.Cantidad <> c.Cantidad) " &
            "     OR (f.Cantidad <> c.Cantidad AND " &
            SQL_EXISTE_CANDIDATA & "))")

        If recibidasMalVinculadas.Count > 0 Then

            For Each r As DataRow In dtRecibidas.Rows

                If recibidasMalVinculadas.Contains(
                   ObtenerDecimal(r("id_Detalle_Compra"))) Then

                    r("id_Detalle_Transferencia") = 0

                End If

            Next

        End If


        ' ============================================================
        ' ENVIADAS YA RELACIONADAS POR ID
        '
        ' Una enviada referenciada por id_Detalle_Transferencia ya
        ' tiene contraparte, aunque la clave documento/fecha/producto/
        ' cantidad no coincida. Es la misma comprobación que aplica
        ' RepararTransferencia001.
        ' ============================================================

        Dim enviadasRelacionadasActivas As New HashSet(Of Decimal)()

        For Each r As DataRow In dtRecibidas.Rows

            Dim idRel As Decimal =
            ObtenerDecimal(r("id_Detalle_Transferencia"))

            If idRel > 0D Then
                enviadasRelacionadasActivas.Add(idRel)
            End If

        Next

        Dim enviadasRelacionadasTodas As HashSet(Of Decimal) =
        ObtenerIdsTransferencia(
            "SELECT DISTINCT id_Detalle_Transferencia " &
            "FROM Detalle_Compras " &
            "WHERE Tipo_Compra = N'Transferencia Recibida' " &
            "AND id_Detalle_Transferencia > 0")


        ' ============================================================
        ' CREAR ÍNDICE EN MEMORIA
        ' ============================================================

        Dim recibidasPorClave As New Dictionary(
        Of String, List(Of DataRow))(
            StringComparer.OrdinalIgnoreCase)


        For Each r As DataRow In dtRecibidas.Rows

            Dim documento As String =
            If(IsDBNull(r("Numero_Compra")),
               "",
               r("Numero_Compra").ToString().Trim())

            Dim fecha As DateTime =
            If(IsDBNull(r("Fecha_Compra")),
               DateTime.MinValue,
               Convert.ToDateTime(r("Fecha_Compra")))

            Dim producto As String =
            If(IsDBNull(r("Cod_Producto")),
               "",
               r("Cod_Producto").ToString().Trim())

            Dim cantidad As Double =
            ObtenerDouble(r("Cantidad"))

            If Math.Abs(cantidad) < 0.000001 Then
                Continue For
            End If


            Dim clave As String =
            CrearClaveTransferencia(
                documento,
                fecha,
                producto,
                cantidad)


            If Not recibidasPorClave.ContainsKey(clave) Then

                recibidasPorClave.Add(
                clave,
                New List(Of DataRow))

            End If


            recibidasPorClave(clave).Add(r)

        Next


        ' ============================================================
        ' CARGAR TRANSFERENCIAS ENVIADAS
        ' ============================================================

        Dim dtEnviadas As New DataTable()

        Dim sqlEnviadas As String = ""

        sqlEnviadas &= "SELECT " & vbCrLf
        sqlEnviadas &= "    id_Detalle_Factura, " & vbCrLf
        sqlEnviadas &= "    Numero_Factura, " & vbCrLf
        sqlEnviadas &= "    Fecha_Factura, " & vbCrLf
        sqlEnviadas &= "    Tipo_Factura, " & vbCrLf
        sqlEnviadas &= "    Cod_Producto, Descripcion_Producto, " & vbCrLf
        sqlEnviadas &= "    Cantidad, " & vbCrLf
        sqlEnviadas &= "    Precio_Unitario " & vbCrLf
        sqlEnviadas &= "FROM Detalle_Facturas " & vbCrLf
        sqlEnviadas &= "WHERE Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sqlEnviadas &= "AND " & ExisteCabeceraFactura("Detalle_Facturas") & " " & vbCrLf
        sqlEnviadas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(
            sqlEnviadas, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtEnviadas)

            End Using

        End Using


        ' ============================================================
        ' ANALIZAR EN MEMORIA
        ' ============================================================

        ' Claves (documento|producto|cantidad, sin fecha) de enviadas
        ' que ya tienen una recepción relacionada por id.
        Dim clavesSinFechaRelacionadas As New HashSet(Of String)(
            StringComparer.OrdinalIgnoreCase)

        For Each f0 As DataRow In dtEnviadas.Rows

            If enviadasRelacionadasActivas.Contains(
               ObtenerDecimal(f0("id_Detalle_Factura"))) Then

                clavesSinFechaRelacionadas.Add(
                    CrearClaveSinFecha(
                        If(IsDBNull(f0("Numero_Factura")), "",
                           f0("Numero_Factura").ToString()),
                        If(IsDBNull(f0("Cod_Producto")), "",
                           f0("Cod_Producto").ToString()),
                        ObtenerDouble(f0("Cantidad"))))

            End If

        Next

        ' Claves (documento|producto|cantidad, sin fecha) de enviadas
        ' que tienen una recibida equivalente histórica (misma clave
        ' con fecha, aunque sin vínculo por id).
        Dim clavesSinFechaHistoricas As New HashSet(Of String)(
            StringComparer.OrdinalIgnoreCase)

        For Each f1 As DataRow In dtEnviadas.Rows

            Dim doc1 As String =
            If(IsDBNull(f1("Numero_Factura")), "",
               f1("Numero_Factura").ToString())

            Dim prod1 As String =
            If(IsDBNull(f1("Cod_Producto")), "",
               f1("Cod_Producto").ToString())

            Dim cant1 As Double = ObtenerDouble(f1("Cantidad"))

            Dim fec1 As DateTime =
            If(IsDBNull(f1("Fecha_Factura")),
               DateTime.MinValue,
               Convert.ToDateTime(f1("Fecha_Factura")))

            If recibidasPorClave.ContainsKey(
               CrearClaveTransferencia(
                   doc1.Trim(), fec1, prod1.Trim(), cant1)) Then

                clavesSinFechaHistoricas.Add(
                    CrearClaveSinFecha(doc1, prod1, cant1))

            End If

        Next

        For Each f As DataRow In dtEnviadas.Rows

            Dim idFactura As Decimal =
            ObtenerDecimal(
                f("id_Detalle_Factura"))

            Dim documento As String =
            If(IsDBNull(f("Numero_Factura")),
               "",
               f("Numero_Factura").ToString().Trim())

            Dim fecha As DateTime =
            If(IsDBNull(f("Fecha_Factura")),
               DateTime.MinValue,
               Convert.ToDateTime(f("Fecha_Factura")))

            Dim producto As String =
            If(IsDBNull(f("Cod_Producto")),
               "",
               f("Cod_Producto").ToString().Trim())

            Dim cantidad As Double =
            ObtenerDouble(f("Cantidad"))

            If Math.Abs(cantidad) < 0.000001 Then
                Continue For
            End If

            Dim precio As Double =
            ObtenerDouble(f("Precio_Unitario"))


            Dim clave As String =
            CrearClaveTransferencia(
                documento,
                fecha,
                producto,
                cantidad)


            ' ============================================================
            ' RELACIÓN POR ID
            ' ============================================================

            If enviadasRelacionadasActivas.Contains(idFactura) Then

                Continue For

            End If

            If enviadasRelacionadasTodas.Contains(idFactura) Then

                ' La única recepción relacionada está cancelada:
                ' no se repara automáticamente (la reparación la
                ' rechazaría por encontrar una contraparte).
                Dim hRev As New HallazgoAuditoria()

                hRev.Control = control
                hRev.Codigo = "TRANS-001"
                hRev.Documento = documento
                hRev.Fecha = fecha
                hRev.Tipo = "Transferencia Enviada"
                hRev.Producto = producto
                hRev.Cantidad = cantidad
                hRev.PrecioUnitario = precio
                hRev.CostoUnitario = precio
                hRev.IdDetalleFactura = idFactura
                hRev.EsDuplicado = False
                hRev.PuedeEliminar = False
                hRev.Reparable = False
                hRev.Estado = EstadoHallazgo.Detectado
                hRev.Severidad = SeveridadAuditoria.Media
                hRev.Descripcion =
                "Transferencia Enviada con recepción cancelada."
                hRev.Motivo =
                "Existe una Transferencia Recibida relacionada " &
                "con este detalle, pero está cancelada." &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID Detalle Factura: " & idFactura.ToString() &
                Environment.NewLine &
                "Producto: " & producto
                hRev.Accion = "REVISIÓN MANUAL"

                hallazgos.Add(hRev)

                Continue For

            End If

            Dim candidatas As List(Of DataRow) = Nothing

            If Not recibidasPorClave.TryGetValue(
            clave,
            candidatas) Then

                ' ========================================================
                ' HUÉRFANO
                ' ========================================================

                Dim h As New HallazgoAuditoria()

                h.Control = control
                h.Codigo = "TRANS-001"

                h.Documento = documento
                h.Fecha = fecha

                h.Tipo = "Transferencia Enviada"
                h.Producto = producto

                h.Cantidad = cantidad

                h.PrecioUnitario = precio

                ' NO CALCULAR COSTO
                h.CostoUnitario = precio

                h.IdDetalleFactura = idFactura

                h.IdDetalleCompra = 0D
                h.IdDetalleTransferencia = 0D
                h.IdDetalleRelacionado = 0D

                h.EsDuplicado = False
                h.PuedeEliminar = False

                h.Reparable = True

                h.Estado =
                EstadoHallazgo.Reparable

                h.Severidad =
                SeveridadAuditoria.Alta

                h.Descripcion =
                "Transferencia Enviada sin " &
                "Transferencia Recibida."

                h.Motivo =
                "La Transferencia Enviada no posee " &
                "una línea equivalente en Transferencia " &
                "Recibida." &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID Detalle Factura: " &
                idFactura.ToString() &
                Environment.NewLine &
                "Producto: " & producto &
                Environment.NewLine &
                "Cantidad: " &
                cantidad.ToString("N6")

                h.Accion = "REPARAR"

                ' Otra línea enviada del mismo documento, producto y
                ' cantidad ya tiene recepción (p. ej. 01-00544): puede ser
                ' una línea duplicada o editada. No se repara
                ' automáticamente para no duplicar el ingreso.
                If clavesSinFechaHistoricas.Contains(
                   CrearClaveSinFecha(documento, producto, cantidad)) AndAlso
                   Not clavesSinFechaRelacionadas.Contains(
                   CrearClaveSinFecha(documento, producto, cantidad)) Then

                    ' La línea hermana tiene su recibida histórica sin
                    ' vínculo por id: no hay sobreviviente enlazado que
                    ' permita eliminar con seguridad. Solo revisión manual.
                    h.Reparable = False
                    h.EsDuplicado = False
                    h.PuedeEliminar = False
                    h.Estado = EstadoHallazgo.Detectado
                    h.Severidad = SeveridadAuditoria.Media
                    h.Descripcion =
                    "Transferencia Enviada posiblemente duplicada."
                    h.Motivo =
                    "Otra línea enviada del mismo documento, producto " &
                    "y cantidad ya tiene su Transferencia Recibida " &
                    "(sin vínculo por id). Esta línea podría ser un " &
                    "duplicado; revisar manualmente." &
                    Environment.NewLine &
                    "Documento: " & documento &
                    Environment.NewLine &
                    "ID Detalle Factura: " & idFactura.ToString("0") &
                    Environment.NewLine &
                    "Producto: " & producto &
                    Environment.NewLine &
                    "Cantidad: " & cantidad.ToString("N6")
                    h.Accion = "REVISIÓN MANUAL"

                ElseIf clavesSinFechaRelacionadas.Contains(
                   CrearClaveSinFecha(documento, producto, cantidad)) Then

                    h.Reparable = False
                    h.EsDuplicado = True
                    h.PuedeEliminar = True
                    h.Estado = EstadoHallazgo.Detectado
                    h.Severidad = SeveridadAuditoria.Media
                    h.Descripcion =
                    "Transferencia Enviada duplicada (distinta fecha)."
                    h.Motivo =
                    "Otra línea enviada del mismo documento, producto " &
                    "y cantidad ya tiene Transferencia Recibida, pero " &
                    "con distinta fecha. Es un probable duplicado: " &
                    "puede eliminarse con el botón Eliminar." &
                    Environment.NewLine &
                    "Documento: " & documento &
                    Environment.NewLine &
                    "ID Detalle Factura: " & idFactura.ToString() &
                    Environment.NewLine &
                    "Producto: " & producto &
                    Environment.NewLine &
                    "Cantidad: " & cantidad.ToString("N6")
                    h.Accion = "ELIMINAR"

                End If

                hallazgos.Add(h)

                Continue For

            End If


            ' ============================================================
            ' BUSCAR RELACIÓN DIRECTA
            ' ============================================================

            Dim relacionDirecta As Boolean = False

            For Each r As DataRow In candidatas

                Dim idRelacionado As Decimal =
                ObtenerDecimal(
                    r("id_Detalle_Transferencia"))

                If idRelacionado = idFactura Then

                    relacionDirecta = True
                    Exit For

                End If

            Next


            If relacionDirecta Then

                ' ========================================================
                ' CORRECTO
                ' ========================================================

                Continue For

            End If


            ' ============================================================
            ' BUSCAR UNA RECEPCIÓN HISTÓRICA SIN RELACIÓN
            '
            ' Este caso es importante:
            '
            ' 01-00495
            '
            ' Existe la contraparte, pero
            ' id_Detalle_Transferencia = 0.
            '
            ' ES CORRECTO.
            ' ============================================================

            Dim historicoSinRelacion As Boolean = False

            For Each r As DataRow In candidatas

                Dim idRelacionado As Decimal =
                ObtenerDecimal(
                    r("id_Detalle_Transferencia"))

                If idRelacionado = 0D Then

                    historicoSinRelacion = True
                    Exit For

                End If

            Next


            If historicoSinRelacion Then

                Continue For

            End If


            ' ============================================================
            ' EXISTEN CANDIDATAS PERO TODAS ESTÁN RELACIONADAS
            ' CON OTROS DETALLES
            '
            ' => DUPLICADO
            ' ============================================================

            Dim rDuplicada As DataRow = candidatas(0)

            Dim idCompra As Decimal =
            ObtenerDecimal(
                rDuplicada("id_Detalle_Compra"))

            Dim idTransferencia As Decimal =
            ObtenerDecimal(
                rDuplicada("id_Detalle_Transferencia"))


            Dim hDuplicado As New HallazgoAuditoria()

            hDuplicado.Control = control
            hDuplicado.Codigo = "TRANS-001"

            hDuplicado.Documento = documento
            hDuplicado.Fecha = fecha

            hDuplicado.Tipo =
            "Transferencia Enviada"

            hDuplicado.Producto = producto

            hDuplicado.Cantidad = cantidad

            hDuplicado.PrecioUnitario = precio

            ' NO CALCULAR COSTO
            hDuplicado.CostoUnitario = precio

            hDuplicado.IdDetalleFactura =
            idFactura

            hDuplicado.IdDetalleCompra =
            idCompra

            hDuplicado.IdDetalleTransferencia =
            idTransferencia

            hDuplicado.IdDetalleRelacionado =
            idTransferencia

            hDuplicado.EsDuplicado = True

            hDuplicado.PuedeEliminar = True

            hDuplicado.Reparable = False

            hDuplicado.Estado =
            EstadoHallazgo.Detectado

            hDuplicado.Severidad =
            SeveridadAuditoria.Alta

            hDuplicado.Descripcion =
            "Transferencia Enviada duplicada."

            hDuplicado.Motivo =
            "La Transferencia Enviada tiene una " &
            "línea equivalente que ya está relacionada " &
            "con otro detalle." &
            Environment.NewLine &
            "Documento: " & documento &
            Environment.NewLine &
            "ID Detalle Factura: " &
            idFactura.ToString() &
            Environment.NewLine &
            "ID Detalle Compra: " &
            idCompra.ToString() &
            Environment.NewLine &
            "ID Detalle Transferencia: " &
            idTransferencia.ToString() &
            Environment.NewLine &
            "Producto: " & producto &
            Environment.NewLine &
            "Cantidad: " &
            cantidad.ToString("N6")

            hDuplicado.Accion = "ELIMINAR"

            hallazgos.Add(hDuplicado)

        Next


        Return hallazgos

    End Function

    ' ============================================================
    ' TRANS-002
    ' TRANSFERENCIA RECIBIDA SIN TRANSFERENCIA ENVIADA
    '
    ' Este control solamente detecta el problema.
    '
    ' No utiliza Precio_Unitario como costo.
    ' No determina automáticamente un costo.
    ' El hallazgo queda para REVISION MANUAL.
    Private Function AuditarTrans002(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        ' ============================================================
        ' CARGAR TRANSFERENCIAS ENVIADAS
        ' ============================================================

        Dim dtEnviadas As New DataTable()

        Dim sqlEnviadas As String = ""

        sqlEnviadas &= "SELECT " & vbCrLf
        sqlEnviadas &= "    id_Detalle_Factura, " & vbCrLf
        sqlEnviadas &= "    Numero_Factura, " & vbCrLf
        sqlEnviadas &= "    Fecha_Factura, " & vbCrLf
        sqlEnviadas &= "    Cod_Producto, Descripcion_Producto, " & vbCrLf
        sqlEnviadas &= "    Cantidad, " & vbCrLf
        sqlEnviadas &= "    Precio_Unitario " & vbCrLf
        sqlEnviadas &= "FROM Detalle_Facturas " & vbCrLf
        sqlEnviadas &= "WHERE Tipo_Factura = N'Transferencia Enviada'" & vbCrLf
        sqlEnviadas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(
                sqlEnviadas, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtEnviadas)

            End Using

        End Using


        ' ============================================================
        ' IDS DE ENVIADAS EXISTENTES
        '
        ' Una recibida cuyo id_Detalle_Transferencia apunta a una
        ' enviada existente ya tiene contraparte, aunque la clave
        ' documento/fecha/producto/cantidad no coincida. Es la misma
        ' comprobación que aplica RepararTransferencia002.
        ' ============================================================

        Dim enviadasActivas As New HashSet(Of Decimal)()

        For Each f As DataRow In dtEnviadas.Rows
            enviadasActivas.Add(
                ObtenerDecimal(f("id_Detalle_Factura")))
        Next

        Dim enviadasTodas As HashSet(Of Decimal) =
        ObtenerIdsTransferencia(
            "SELECT id_Detalle_Factura " &
            "FROM Detalle_Facturas " &
            "WHERE Tipo_Factura = N'Transferencia Enviada'")


        ' ============================================================
        ' ÍNDICE DE ENVIADAS
        ' ============================================================

        Dim enviadasPorClave As New Dictionary(
            Of String, List(Of DataRow))(
                StringComparer.OrdinalIgnoreCase)


        For Each f As DataRow In dtEnviadas.Rows

            Dim documento As String =
                If(IsDBNull(f("Numero_Factura")),
                   "",
                   f("Numero_Factura").ToString().Trim())

            Dim fecha As DateTime =
                If(IsDBNull(f("Fecha_Factura")),
                   DateTime.MinValue,
                   Convert.ToDateTime(f("Fecha_Factura")))

            Dim producto As String =
                If(IsDBNull(f("Cod_Producto")),
                   "",
                   f("Cod_Producto").ToString().Trim())

            Dim cantidad As Double =
                ObtenerDouble(f("Cantidad"))

            If Math.Abs(cantidad) < 0.000001 Then
                Continue For
            End If


            Dim clave As String =
                CrearClaveTransferencia(
                    documento,
                    fecha,
                    producto,
                    cantidad)


            If Not enviadasPorClave.ContainsKey(clave) Then

                enviadasPorClave.Add(
                    clave,
                    New List(Of DataRow))

            End If


            enviadasPorClave(clave).Add(f)

        Next


        ' ============================================================
        ' CARGAR TRANSFERENCIAS RECIBIDAS
        ' ============================================================

        Dim dtRecibidas As New DataTable()

        Dim sqlRecibidas As String = ""

        sqlRecibidas &= "SELECT " & vbCrLf
        sqlRecibidas &= "    id_Detalle_Compra, " & vbCrLf
        sqlRecibidas &= "    Numero_Compra, " & vbCrLf
        sqlRecibidas &= "    Fecha_Compra, " & vbCrLf
        sqlRecibidas &= "    Cod_Producto, Descripcion_Producto, " & vbCrLf
        sqlRecibidas &= "    Cantidad, " & vbCrLf
        sqlRecibidas &= "    Precio_Unitario, " & vbCrLf
        sqlRecibidas &= "    Costo_Unitario, " & vbCrLf
        sqlRecibidas &= "    id_Detalle_Transferencia " & vbCrLf
        sqlRecibidas &= "FROM Detalle_Compras " & vbCrLf
        sqlRecibidas &= "WHERE Tipo_Compra = N'Transferencia Recibida' " & vbCrLf
        sqlRecibidas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(
                sqlRecibidas, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtRecibidas)

            End Using

        End Using


        ' ============================================================
        ' ANALIZAR EN MEMORIA
        ' ============================================================

        For Each r As DataRow In dtRecibidas.Rows

            Dim idCompra As Decimal =
                ObtenerDecimal(
                    r("id_Detalle_Compra"))

            Dim idTransferencia As Decimal =
                ObtenerDecimal(
                    r("id_Detalle_Transferencia"))

            Dim documento As String =
                If(IsDBNull(r("Numero_Compra")),
                   "",
                   r("Numero_Compra").ToString().Trim())

            Dim fecha As DateTime =
                If(IsDBNull(r("Fecha_Compra")),
                   DateTime.MinValue,
                   Convert.ToDateTime(r("Fecha_Compra")))

            Dim producto As String =
                If(IsDBNull(r("Cod_Producto")),
                   "",
                   r("Cod_Producto").ToString().Trim())

            Dim cantidad As Double =
                ObtenerDouble(r("Cantidad"))

            If Math.Abs(cantidad) < 0.000001 Then
                Continue For
            End If

            Dim precio As Double =
                ObtenerDouble(r("Precio_Unitario"))


            Dim clave As String =
                CrearClaveTransferencia(
                    documento,
                    fecha,
                    producto,
                    cantidad)


            ' ============================================================
            ' RELACIÓN POR ID
            ' ============================================================

            If idTransferencia > 0D Then

                If enviadasActivas.Contains(idTransferencia) Then

                    Continue For

                End If

                If enviadasTodas.Contains(idTransferencia) Then

                    ' La enviada relacionada está cancelada: no se repara
                    ' automáticamente (la reparación la rechazaría por
                    ' encontrar una contraparte).
                    Dim hRev As New HallazgoAuditoria()

                    hRev.Control = control
                    hRev.Codigo = "TRANS-002"
                    hRev.Documento = documento
                    hRev.Fecha = fecha
                    hRev.Tipo = "Transferencia Recibida"
                    hRev.Producto = producto
                    hRev.Cantidad = cantidad
                    hRev.PrecioUnitario = precio
                    hRev.CostoUnitario = precio
                    hRev.IdDetalleCompra = idCompra
                    hRev.IdDetalleTransferencia = idTransferencia
                    hRev.EsDuplicado = False
                    hRev.PuedeEliminar = False
                    hRev.Reparable = False
                    hRev.Estado = EstadoHallazgo.Detectado
                    hRev.Severidad = SeveridadAuditoria.Media
                    hRev.Descripcion =
                    "Transferencia Recibida con envío cancelado."
                    hRev.Motivo =
                    "Existe una Transferencia Enviada relacionada " &
                    "con este detalle, pero está cancelada." &
                    Environment.NewLine &
                    "Documento: " & documento &
                    Environment.NewLine &
                    "ID Detalle Compra: " & idCompra.ToString() &
                    Environment.NewLine &
                    "Producto: " & producto
                    hRev.Accion = "REVISIÓN MANUAL"

                    hallazgos.Add(hRev)

                    Continue For

                End If

            End If

            Dim candidatas As List(Of DataRow) = Nothing

            If Not enviadasPorClave.TryGetValue(
                clave,
                candidatas) Then

                ' ========================================================
                ' HUÉRFANO
                ' ========================================================

                Dim h As New HallazgoAuditoria()

                h.Control = control
                h.Codigo = "TRANS-002"

                h.Documento = documento
                h.Fecha = fecha

                h.Tipo =
                    "Transferencia Recibida"

                h.Producto = producto

                h.Cantidad = cantidad

                h.PrecioUnitario = precio

                ' NO CALCULAR COSTO
                h.CostoUnitario = precio

                h.IdDetalleCompra =
                    idCompra

                h.IdDetalleFactura = 0D

                h.IdDetalleTransferencia =
                    idTransferencia

                h.IdDetalleRelacionado = 0D

                h.EsDuplicado = False

                h.PuedeEliminar = False

                h.Reparable = True

                h.Estado =
                    EstadoHallazgo.Reparable

                h.Severidad =
                    SeveridadAuditoria.Alta

                h.Descripcion =
                    "Transferencia Recibida sin " &
                    "Transferencia Enviada."

                h.Motivo =
                    "La Transferencia Recibida no posee " &
                    "una línea equivalente en Transferencia " &
                    "Enviada." &
                    Environment.NewLine &
                    "Documento: " & documento &
                    Environment.NewLine &
                    "ID Detalle Compra: " &
                    idCompra.ToString() &
                    Environment.NewLine &
                    "Producto: " & producto &
                    Environment.NewLine &
                    "Cantidad: " &
                    cantidad.ToString("N6")

                h.Accion = "REPARAR"

                hallazgos.Add(h)

                Continue For

            End If


            ' ============================================================
            ' BUSCAR RELACIÓN DIRECTA
            ' ============================================================

            Dim relacionDirecta As Boolean = False

            For Each f As DataRow In candidatas

                Dim idFactura As Decimal =
                    ObtenerDecimal(
                        f("id_Detalle_Factura"))

                If idFactura = idTransferencia Then

                    relacionDirecta = True
                    Exit For

                End If

            Next


            If relacionDirecta Then

                Continue For

            End If


            ' ============================================================
            ' BUSCAR UNA ENVIADA HISTÓRICA SIN RELACIÓN
            '
            ' Si existe la contraparte aunque no tenga una relación
            ' registrada en Detalle_Compras, es correcta.
            ' ============================================================

            Dim enviadaSinRelacion As Boolean = False

            For Each f As DataRow In candidatas

                Dim idFactura As Decimal =
                    ObtenerDecimal(
                        f("id_Detalle_Factura"))


                Dim tieneRelacion As Boolean = False

                ' --------------------------------------------------------
                ' Para una enviada necesitamos determinar si algún
                ' detalle recibido apunta hacia ella.
                '
                ' Esa información la obtenemos de dtRecibidas,
                ' que ya está cargada en memoria.
                ' --------------------------------------------------------

                For Each r2 As DataRow In dtRecibidas.Rows

                    Dim idRelacion As Decimal =
                        ObtenerDecimal(
                            r2("id_Detalle_Transferencia"))

                    Dim idCompra2 As Decimal =
                        ObtenerDecimal(
                            r2("id_Detalle_Compra"))

                    If idRelacion = idFactura AndAlso
                       idCompra2 <> idCompra Then

                        tieneRelacion = True
                        Exit For

                    End If

                Next


                If Not tieneRelacion Then

                    enviadaSinRelacion = True
                    Exit For

                End If

            Next


            If enviadaSinRelacion Then

                Continue For

            End If


            ' ============================================================
            ' DUPLICADO
            ' ============================================================

            Dim fDuplicada As DataRow =
                candidatas(0)

            Dim idFacturaDuplicada As Decimal =
                ObtenerDecimal(
                    fDuplicada("id_Detalle_Factura"))


            Dim hDuplicado As New HallazgoAuditoria()

            hDuplicado.Control = control
            hDuplicado.Codigo = "TRANS-002"

            hDuplicado.Documento = documento
            hDuplicado.Fecha = fecha

            hDuplicado.Tipo =
                "Transferencia Recibida"

            hDuplicado.Producto = producto

            hDuplicado.Cantidad = cantidad

            hDuplicado.PrecioUnitario = precio

            ' NO CALCULAR COSTO
            hDuplicado.CostoUnitario = precio

            hDuplicado.IdDetalleCompra =
                idCompra

            hDuplicado.IdDetalleFactura =
                idFacturaDuplicada

            hDuplicado.IdDetalleTransferencia =
                idTransferencia

            hDuplicado.IdDetalleRelacionado =
                idFacturaDuplicada

            hDuplicado.EsDuplicado = True

            hDuplicado.PuedeEliminar = True

            hDuplicado.Reparable = False

            hDuplicado.Estado =
                EstadoHallazgo.Detectado

            hDuplicado.Severidad =
                SeveridadAuditoria.Alta

            hDuplicado.Descripcion =
                "Transferencia Recibida duplicada."

            hDuplicado.Motivo =
                "La Transferencia Recibida tiene una " &
                "línea equivalente que ya está relacionada " &
                "con otra recepción." &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID Detalle Compra: " &
                idCompra.ToString() &
                Environment.NewLine &
                "ID Detalle Factura relacionado: " &
                idFacturaDuplicada.ToString() &
                Environment.NewLine &
                "Producto: " & producto &
                Environment.NewLine &
                "Cantidad: " &
                cantidad.ToString("N6")

            hDuplicado.Accion = "ELIMINAR"

            hallazgos.Add(hDuplicado)

        Next


        Return hallazgos

    End Function

    ' ============================================================
    ' TRANS-003
    ' DIFERENCIA DE CANTIDAD ENTRE TRANSFERENCIAS
    '
    ' Parte A: enviada y recibida relacionadas por
    '          id_Detalle_Transferencia con cantidades distintas
    '          (si hay varias recibidas para una enviada se suman).
    ' Parte B: enviada y recibida sin relación por id, únicas para
    '          su documento y producto, con cantidades distintas.
    '
    ' Solo detecta. No calcula costos ni repara: REVISION MANUAL.
    ' ============================================================
    Private Function AuditarTrans003(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        ' ============================================================
        ' PARTE A: RELACIONADAS POR ID
        ' ============================================================

        Dim dtA As New DataTable()

        Dim sqlA As String = ""

        sqlA &= "SELECT f.id_Detalle_Factura, f.Numero_Factura, " & vbCrLf
        sqlA &= "    f.Fecha_Factura, f.Cod_Producto, " & vbCrLf
        sqlA &= "    f.Cantidad AS CantEnviada, f.Precio_Unitario, " & vbCrLf
        sqlA &= "    SUM(c.Cantidad) AS CantRecibida, " & vbCrLf
        sqlA &= "    COUNT(*) AS NumRecibidas, " & vbCrLf
        sqlA &= "    MIN(c.id_Detalle_Compra) AS IdCompra " & vbCrLf
        sqlA &= "FROM Detalle_Facturas f " & vbCrLf
        sqlA &= "INNER JOIN Detalle_Compras c " & vbCrLf
        sqlA &= "    ON c.id_Detalle_Transferencia = f.id_Detalle_Factura " & vbCrLf
        sqlA &= "    AND c.Tipo_Compra = N'Transferencia Recibida' " & vbCrLf
        sqlA &= "    AND LTRIM(RTRIM(c.Cod_Producto)) = LTRIM(RTRIM(f.Cod_Producto)) " & vbCrLf
        sqlA &= "    AND (c.Numero_Compra = f.Numero_Factura " & vbCrLf
        sqlA &= "         OR c.Cantidad = f.Cantidad) " & vbCrLf
        sqlA &= "    AND NOT (c.Cantidad <> f.Cantidad AND " &
                SQL_EXISTE_CANDIDATA & ") " & vbCrLf
        sqlA &= "    AND ISNULL(c.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlA &= "WHERE f.Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sqlA &= "AND ISNULL(f.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlA &= "GROUP BY f.id_Detalle_Factura, f.Numero_Factura, " & vbCrLf
        sqlA &= "    f.Fecha_Factura, f.Cod_Producto, " & vbCrLf
        sqlA &= "    f.Cantidad, f.Precio_Unitario " & vbCrLf
        sqlA &= "HAVING ABS(f.Cantidad - SUM(c.Cantidad)) > 0.000001"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sqlA, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtA)

            End Using

        End Using

        For Each r As DataRow In dtA.Rows

            Dim cantEnv As Double = ObtenerDouble(r("CantEnviada"))
            Dim cantRec As Double = ObtenerDouble(r("CantRecibida"))
            Dim precio As Double = ObtenerDouble(r("Precio_Unitario"))
            Dim numRec As Integer = Convert.ToInt32(r("NumRecibidas"))

            Dim idFactura As Decimal =
            ObtenerDecimal(r("id_Detalle_Factura"))

            Dim idCompra As Decimal =
            ObtenerDecimal(r("IdCompra"))

            Dim documento As String =
            If(IsDBNull(r("Numero_Factura")), "",
               r("Numero_Factura").ToString().Trim())

            Dim producto As String =
            If(IsDBNull(r("Cod_Producto")), "",
               r("Cod_Producto").ToString().Trim())

            Dim h As New HallazgoAuditoria()

            h.Control = control
            h.Codigo = "TRANS-003"
            h.Documento = documento
            h.Fecha = If(IsDBNull(r("Fecha_Factura")),
                         DateTime.MinValue,
                         Convert.ToDateTime(r("Fecha_Factura")))
            h.Tipo = "Transferencia Enviada"
            h.Producto = producto
            h.Cantidad = cantEnv
            h.PrecioUnitario = precio
            h.CostoUnitario = precio
            h.IdDetalleFactura = idFactura
            h.IdDetalleCompra = idCompra
            h.IdDetalleTransferencia = idFactura
            h.EsDuplicado = False
            h.PuedeEliminar = False
            h.Reparable = False
            h.Estado = EstadoHallazgo.Detectado
            h.Severidad = SeveridadAuditoria.Alta
            h.Descripcion =
            "Diferencia de cantidad entre Transferencia Enviada y Recibida."
            h.Motivo =
            "La cantidad enviada no coincide con la recibida " &
            "(relacionadas por id_Detalle_Transferencia)." &
            Environment.NewLine &
            "Documento: " & documento &
            Environment.NewLine &
            "ID Detalle Factura (enviada): " & idFactura.ToString("0") &
            Environment.NewLine &
            "ID Detalle Compra (recibida): " & idCompra.ToString("0") &
            If(numRec > 1,
               " (+" & (numRec - 1).ToString() & " más)", "") &
            Environment.NewLine &
            "Producto: " & producto &
            Environment.NewLine &
            "Cantidad enviada: " & cantEnv.ToString("N6") &
            Environment.NewLine &
            "Cantidad recibida: " & cantRec.ToString("N6") &
            Environment.NewLine &
            "Diferencia: " & (cantEnv - cantRec).ToString("N6")
            h.Accion = "REVISIÓN MANUAL"

            hallazgos.Add(h)

        Next


        ' ============================================================
        ' PARTE B: SIN RELACIÓN POR ID, UNA SOLA LÍNEA POR LADO
        ' ============================================================

        Dim dtEnv As New DataTable()
        Dim dtRec As New DataTable()

        Dim sqlEnv As String = ""

        sqlEnv &= "SELECT f.id_Detalle_Factura, f.Numero_Factura, " & vbCrLf
        sqlEnv &= "    f.Fecha_Factura, f.Cod_Producto, " & vbCrLf
        sqlEnv &= "    f.Cantidad, f.Precio_Unitario " & vbCrLf
        sqlEnv &= "FROM Detalle_Facturas f " & vbCrLf
        sqlEnv &= "WHERE f.Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sqlEnv &= "AND ISNULL(f.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlEnv &= "AND NOT EXISTS (SELECT 1 FROM Detalle_Compras c " & vbCrLf
        sqlEnv &= "    WHERE c.id_Detalle_Transferencia = f.id_Detalle_Factura " & vbCrLf
        sqlEnv &= "    AND c.Tipo_Compra = N'Transferencia Recibida')"

        Dim sqlRec As String = ""

        sqlRec &= "SELECT c.id_Detalle_Compra, c.Numero_Compra, " & vbCrLf
        sqlRec &= "    c.Fecha_Compra, c.Cod_Producto, " & vbCrLf
        sqlRec &= "    c.Cantidad, c.Precio_Unitario " & vbCrLf
        sqlRec &= "FROM Detalle_Compras c " & vbCrLf
        sqlRec &= "WHERE c.Tipo_Compra = N'Transferencia Recibida' " & vbCrLf
        sqlRec &= "AND ISNULL(c.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlRec &= "AND ISNULL(c.id_Detalle_Transferencia, 0) = 0"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sqlEnv, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dtEnv)
            End Using

            Using da As New SqlDataAdapter(sqlRec, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dtRec)
            End Using

        End Using

        Dim enviadasPorDoc As New Dictionary(
        Of String, List(Of DataRow))(StringComparer.OrdinalIgnoreCase)

        For Each f As DataRow In dtEnv.Rows

            Dim k As String =
            If(IsDBNull(f("Numero_Factura")), "",
               f("Numero_Factura").ToString().Trim()) & "|" &
            If(IsDBNull(f("Cod_Producto")), "",
               f("Cod_Producto").ToString().Trim())

            If Not enviadasPorDoc.ContainsKey(k) Then
                enviadasPorDoc.Add(k, New List(Of DataRow))
            End If

            enviadasPorDoc(k).Add(f)

        Next

        Dim recibidasPorDoc As New Dictionary(
        Of String, List(Of DataRow))(StringComparer.OrdinalIgnoreCase)

        For Each c As DataRow In dtRec.Rows

            Dim k As String =
            If(IsDBNull(c("Numero_Compra")), "",
               c("Numero_Compra").ToString().Trim()) & "|" &
            If(IsDBNull(c("Cod_Producto")), "",
               c("Cod_Producto").ToString().Trim())

            If Not recibidasPorDoc.ContainsKey(k) Then
                recibidasPorDoc.Add(k, New List(Of DataRow))
            End If

            recibidasPorDoc(k).Add(c)

        Next

        For Each kv As KeyValuePair(Of String, List(Of DataRow)) In enviadasPorDoc

            Dim listaRec As List(Of DataRow) = Nothing

            If kv.Value.Count <> 1 Then Continue For
            If Not recibidasPorDoc.TryGetValue(kv.Key, listaRec) Then Continue For
            If listaRec.Count <> 1 Then Continue For

            Dim f As DataRow = kv.Value(0)
            Dim c As DataRow = listaRec(0)

            Dim cantEnv As Double = ObtenerDouble(f("Cantidad"))
            Dim cantRec As Double = ObtenerDouble(c("Cantidad"))

            If Math.Abs(cantEnv - cantRec) <= 0.000001 Then Continue For

            ' Si ambas son cero no hay efecto de inventario.
            If Math.Abs(cantEnv) < 0.000001 AndAlso
               Math.Abs(cantRec) < 0.000001 Then Continue For

            Dim idFactura As Decimal =
            ObtenerDecimal(f("id_Detalle_Factura"))

            Dim idCompra As Decimal =
            ObtenerDecimal(c("id_Detalle_Compra"))

            Dim documento As String =
            If(IsDBNull(f("Numero_Factura")), "",
               f("Numero_Factura").ToString().Trim())

            Dim producto As String =
            If(IsDBNull(f("Cod_Producto")), "",
               f("Cod_Producto").ToString().Trim())

            Dim precio As Double = ObtenerDouble(f("Precio_Unitario"))

            Dim h As New HallazgoAuditoria()

            h.Control = control
            h.Codigo = "TRANS-003"
            h.Documento = documento
            h.Fecha = If(IsDBNull(f("Fecha_Factura")),
                         DateTime.MinValue,
                         Convert.ToDateTime(f("Fecha_Factura")))
            h.Tipo = "Transferencia Enviada"
            h.Producto = producto
            h.Cantidad = cantEnv
            h.PrecioUnitario = precio
            h.CostoUnitario = precio
            h.IdDetalleFactura = idFactura
            h.IdDetalleCompra = idCompra
            h.EsDuplicado = False
            h.PuedeEliminar = False
            h.Reparable = False
            h.Estado = EstadoHallazgo.Detectado
            h.Severidad = SeveridadAuditoria.Alta
            h.Descripcion =
            "Diferencia de cantidad entre Transferencia Enviada y Recibida " &
            "(sin relación por id)."
            h.Motivo =
            "Una única línea enviada y una única recibida del mismo " &
            "documento y producto, sin relación por " &
            "id_Detalle_Transferencia, tienen cantidades distintas." &
            Environment.NewLine &
            "Documento: " & documento &
            Environment.NewLine &
            "ID Detalle Factura (enviada): " & idFactura.ToString("0") &
            Environment.NewLine &
            "ID Detalle Compra (recibida): " & idCompra.ToString("0") &
            Environment.NewLine &
            "Producto: " & producto &
            Environment.NewLine &
            "Cantidad enviada: " & cantEnv.ToString("N6") &
            Environment.NewLine &
            "Cantidad recibida: " & cantRec.ToString("N6") &
            Environment.NewLine &
            "Diferencia: " & (cantEnv - cantRec).ToString("N6")
            h.Accion = "REVISIÓN MANUAL"

            hallazgos.Add(h)

        Next


        ' ============================================================
        ' PARTE C: RECIBIDA VINCULADA A UNA ENVIADA DE OTRO PRODUCTO
        '
        ' El id_Detalle_Transferencia apunta a una enviada cuyo
        ' producto no coincide (p. ej. 02-00665). Es reparable solo si
        ' existe una única enviada candidata (mismo documento, producto
        ' y cantidad) que no tenga ya una recibida relacionada.
        ' La reparación corrige únicamente el id del vínculo.
        ' ============================================================

        Dim dtC As New DataTable()

        Dim sqlC As String = ""

        sqlC &= "SELECT c.id_Detalle_Compra, c.Numero_Compra, " & vbCrLf
        sqlC &= "    c.Fecha_Compra, c.Cod_Producto, c.Cantidad, " & vbCrLf
        sqlC &= "    c.Precio_Unitario, " & vbCrLf
        sqlC &= "    c.id_Detalle_Transferencia AS IdActual, " & vbCrLf
        sqlC &= "    fa.Cod_Producto AS ProductoActual, " & vbCrLf
        sqlC &= "    fa.Numero_Factura AS DocumentoActual, " & vbCrLf
        sqlC &= "    fa.Cantidad AS CantidadActual, " & vbCrLf
        sqlC &= "    x.NumCand, x.IdCand " & vbCrLf
        sqlC &= "FROM Detalle_Compras c " & vbCrLf
        sqlC &= "LEFT JOIN Detalle_Facturas fa " & vbCrLf
        sqlC &= "    ON fa.id_Detalle_Factura = c.id_Detalle_Transferencia " & vbCrLf
        sqlC &= "    AND fa.Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sqlC &= "OUTER APPLY (" & vbCrLf
        sqlC &= "    SELECT COUNT(*) AS NumCand, " & vbCrLf
        sqlC &= "        MIN(f.id_Detalle_Factura) AS IdCand " & vbCrLf
        sqlC &= "    FROM Detalle_Facturas f " & vbCrLf
        sqlC &= "    WHERE f.Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sqlC &= "    AND f.Numero_Factura = c.Numero_Compra " & vbCrLf
        sqlC &= "    AND LTRIM(RTRIM(f.Cod_Producto)) = LTRIM(RTRIM(c.Cod_Producto)) " & vbCrLf
        sqlC &= "    AND f.Cantidad = c.Cantidad " & vbCrLf
        sqlC &= "    AND ISNULL(f.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlC &= "    AND NOT EXISTS (SELECT 1 FROM Detalle_Compras c2 " & vbCrLf
        sqlC &= "        WHERE c2.id_Detalle_Transferencia = f.id_Detalle_Factura " & vbCrLf
        sqlC &= "        AND c2.Tipo_Compra = N'Transferencia Recibida')" & vbCrLf
        sqlC &= ") x " & vbCrLf
        sqlC &= "WHERE c.Tipo_Compra = N'Transferencia Recibida' " & vbCrLf
        sqlC &= "AND ISNULL(c.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sqlC &= "AND ISNULL(c.Cantidad, 0) <> 0 " & vbCrLf
        sqlC &= "AND ISNULL(c.id_Detalle_Transferencia, 0) <> 0 " & vbCrLf
        sqlC &= "AND (fa.id_Detalle_Factura IS NULL " & vbCrLf
        sqlC &= "     OR LTRIM(RTRIM(fa.Cod_Producto)) <> LTRIM(RTRIM(c.Cod_Producto)) " & vbCrLf
        sqlC &= "     OR (fa.Numero_Factura <> c.Numero_Compra " & vbCrLf
        sqlC &= "         AND fa.Cantidad <> c.Cantidad) " & vbCrLf
        sqlC &= "     OR (fa.Cantidad <> c.Cantidad AND " &
                SQL_EXISTE_CANDIDATA & "))"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sqlC, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dtC)

            End Using

        End Using

        ' Candidatas reclamadas por más de una recibida: no se reparan.
        Dim reclamos As New Dictionary(Of Decimal, Integer)()

        For Each r As DataRow In dtC.Rows

            If Not IsDBNull(r("IdCand")) AndAlso
               Convert.ToInt32(r("NumCand")) = 1 Then

                Dim idc As Decimal = ObtenerDecimal(r("IdCand"))

                If reclamos.ContainsKey(idc) Then
                    reclamos(idc) += 1
                Else
                    reclamos.Add(idc, 1)
                End If

            End If

        Next

        For Each r As DataRow In dtC.Rows

            Dim idCompra As Decimal =
            ObtenerDecimal(r("id_Detalle_Compra"))

            Dim idActual As Decimal =
            ObtenerDecimal(r("IdActual"))

            Dim numCand As Integer = Convert.ToInt32(r("NumCand"))

            Dim idCand As Decimal =
            If(IsDBNull(r("IdCand")), 0D, ObtenerDecimal(r("IdCand")))

            Dim documento As String =
            If(IsDBNull(r("Numero_Compra")), "",
               r("Numero_Compra").ToString().Trim())

            Dim producto As String =
            If(IsDBNull(r("Cod_Producto")), "",
               r("Cod_Producto").ToString().Trim())

            Dim productoActual As String =
            If(IsDBNull(r("ProductoActual")), "",
               r("ProductoActual").ToString().Trim())

            Dim documentoActual As String =
            If(IsDBNull(r("DocumentoActual")), "",
               r("DocumentoActual").ToString().Trim())

            Dim cantidadActual As Double =
            ObtenerDouble(r("CantidadActual"))

            Dim cantidad As Double = ObtenerDouble(r("Cantidad"))
            Dim precio As Double = ObtenerDouble(r("Precio_Unitario"))

            Dim reparable As Boolean =
            (numCand = 1 AndAlso idCand > 0D AndAlso
             reclamos.ContainsKey(idCand) AndAlso
             reclamos(idCand) = 1)

            Dim h As New HallazgoAuditoria()

            h.Control = control
            h.Codigo = "TRANS-003"
            h.Documento = documento
            h.Fecha = If(IsDBNull(r("Fecha_Compra")),
                         DateTime.MinValue,
                         Convert.ToDateTime(r("Fecha_Compra")))
            h.Tipo = "Transferencia Recibida"
            h.Producto = producto
            h.Cantidad = cantidad
            h.PrecioUnitario = precio
            h.CostoUnitario = precio
            h.IdDetalleCompra = idCompra
            h.IdDetalleTransferencia = idActual
            h.IdDetalleFactura = If(reparable, idCand, 0D)
            h.IdDetalleRelacionado = If(reparable, idCand, 0D)
            h.EsDuplicado = False
            h.PuedeEliminar = False
            h.Severidad = SeveridadAuditoria.Alta
            h.Descripcion =
            "Transferencia Recibida vinculada a una enviada incorrecta."

            Dim motivo As String =
            "El id_Detalle_Transferencia de la recibida apunta a una " &
            "enviada inexistente, de otro producto o de otro " &
            "documento con distinta cantidad." &
            Environment.NewLine &
            "Documento: " & documento &
            Environment.NewLine &
            "ID Detalle Compra (recibida): " & idCompra.ToString("0") &
            Environment.NewLine &
            "Producto recibido: " & producto &
            Environment.NewLine &
            "Cantidad: " & cantidad.ToString("N6") &
            Environment.NewLine &
            "Vínculo actual: " & idActual.ToString("0") &
            If(documentoActual = String.Empty AndAlso
               productoActual = String.Empty,
               " (el id no existe como Transferencia Enviada)",
               " (documento " & documentoActual &
               ", producto " & productoActual &
               ", cantidad " & cantidadActual.ToString("N6") & ")")

            If reparable Then

                h.Reparable = True
                h.Estado = EstadoHallazgo.Reparable
                h.Accion = "REPARAR"

                h.Motivo = motivo &
                Environment.NewLine &
                "Enviada correcta encontrada: " & idCand.ToString("0") &
                Environment.NewLine &
                "Se corregirá solamente id_Detalle_Transferencia."

            Else

                h.Reparable = False
                h.Estado = EstadoHallazgo.Detectado
                h.Accion = "REVISIÓN MANUAL"

                h.Motivo = motivo &
                Environment.NewLine &
                "No existe una única enviada candidata " &
                "(mismo documento, producto y cantidad, sin recibida)."

            End If

            hallazgos.Add(h)

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' TRANS-004
    ' DIFERENCIA DE COSTO ENTRE TRANSFERENCIAS
    '
    ' Compara, para cada par relacionado por id_Detalle_Transferencia:
    '   Enviada  : Detalle_Facturas.Costo_Unitario
    '   Recibida : Detalle_Compras.Precio_Unitario
    ' (en la recibida el costo se guarda en Precio_Unitario).
    '
    ' Se omiten los pares donde alguno de los dos valores es cero:
    ' esos casos pertenecen a COST-004 y COST-005.
    '
    ' Solo detecta. No calcula costos ni repara: REVISION MANUAL.
    ' ============================================================
    Private Function AuditarTrans004(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Const TOLERANCIA As Double = 0.01

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT f.id_Detalle_Factura, f.Numero_Factura, " & vbCrLf
        sql &= "    f.Fecha_Factura, f.Cod_Producto, " & vbCrLf
        sql &= "    f.Cantidad, f.Costo_Unitario AS CostoEnviada, " & vbCrLf
        sql &= "    c.id_Detalle_Compra, " & vbCrLf
        sql &= "    c.Precio_Unitario AS CostoRecibida " & vbCrLf
        sql &= "FROM Detalle_Facturas f " & vbCrLf
        sql &= "INNER JOIN Detalle_Compras c " & vbCrLf
        sql &= "    ON c.id_Detalle_Transferencia = f.id_Detalle_Factura " & vbCrLf
        sql &= "    AND c.Tipo_Compra = N'Transferencia Recibida' " & vbCrLf
        sql &= "    AND LTRIM(RTRIM(c.Cod_Producto)) = LTRIM(RTRIM(f.Cod_Producto)) " & vbCrLf
        sql &= "    AND (c.Numero_Compra = f.Numero_Factura " & vbCrLf
        sql &= "         OR c.Cantidad = f.Cantidad) " & vbCrLf
        sql &= "    AND ISNULL(c.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sql &= "WHERE f.Tipo_Factura = N'Transferencia Enviada' " & vbCrLf
        sql &= "AND ISNULL(f.Descripcion_Producto, '') NOT LIKE '%CANCELADO%' " & vbCrLf
        sql &= "AND ISNULL(f.Cantidad, 0) <> 0 " & vbCrLf
        sql &= "AND ISNULL(f.Costo_Unitario, 0) <> 0 " & vbCrLf
        sql &= "AND ISNULL(c.Precio_Unitario, 0) <> 0 " & vbCrLf
        sql &= "AND ABS(f.Costo_Unitario - c.Precio_Unitario) > " &
               TOLERANCIA.ToString(
                   Globalization.CultureInfo.InvariantCulture)

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)

                da.SelectCommand.CommandTimeout = 300

                da.Fill(dt)

            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim costoEnv As Double = ObtenerDouble(r("CostoEnviada"))
            Dim costoRec As Double = ObtenerDouble(r("CostoRecibida"))
            Dim cantidad As Double = ObtenerDouble(r("Cantidad"))

            Dim idFactura As Decimal =
            ObtenerDecimal(r("id_Detalle_Factura"))

            Dim idCompra As Decimal =
            ObtenerDecimal(r("id_Detalle_Compra"))

            Dim documento As String =
            If(IsDBNull(r("Numero_Factura")), "",
               r("Numero_Factura").ToString().Trim())

            Dim producto As String =
            If(IsDBNull(r("Cod_Producto")), "",
               r("Cod_Producto").ToString().Trim())

            Dim h As New HallazgoAuditoria()

            h.Control = control
            h.Codigo = "TRANS-004"
            h.Documento = documento
            h.Fecha = If(IsDBNull(r("Fecha_Factura")),
                         DateTime.MinValue,
                         Convert.ToDateTime(r("Fecha_Factura")))
            h.Tipo = "Transferencia Enviada"
            h.Producto = producto
            h.Cantidad = cantidad
            h.PrecioUnitario = costoRec
            h.CostoUnitario = costoEnv
            h.IdDetalleFactura = idFactura
            h.IdDetalleCompra = idCompra
            h.IdDetalleTransferencia = idFactura
            h.EsDuplicado = False
            h.PuedeEliminar = False
            h.Reparable = False
            h.Estado = EstadoHallazgo.Detectado
            h.Severidad = SeveridadAuditoria.Alta
            h.Descripcion =
            "Diferencia de costo entre Transferencia Enviada y Recibida."
            h.Motivo =
            "El Costo_Unitario de la enviada no coincide con el " &
            "Precio_Unitario (costo) de la recibida." &
            Environment.NewLine &
            "Documento: " & documento &
            Environment.NewLine &
            "ID Detalle Factura (enviada): " & idFactura.ToString("0") &
            Environment.NewLine &
            "ID Detalle Compra (recibida): " & idCompra.ToString("0") &
            Environment.NewLine &
            "Producto: " & producto &
            Environment.NewLine &
            "Costo enviada (Costo_Unitario): " & costoEnv.ToString("N6") &
            Environment.NewLine &
            "Costo recibida (Precio_Unitario): " & costoRec.ToString("N6") &
            Environment.NewLine &
            "Diferencia: " & (costoEnv - costoRec).ToString("N6")
            h.Accion = "REVISIÓN MANUAL"

            hallazgos.Add(h)

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' HALLAZGO DE DATOS (DATA-xxx)
    ' Siempre queda para revisión manual: no se asigna tipo, cantidad
    ' ni costo sin evidencia suficiente.
    ' ============================================================
    Private Function NuevoHallazgoData(
        ByVal control As ControlAuditoria,
        ByVal codigo As String,
        ByVal tipo As String,
        ByVal documento As String,
        ByVal fecha As DateTime,
        ByVal producto As String,
        ByVal cantidad As Double,
        ByVal precio As Double,
        ByVal costo As Double,
        ByVal severidad As SeveridadAuditoria,
        ByVal descripcion As String,
        ByVal motivo As String,
        ByVal accion As String) As HallazgoAuditoria

        Dim h As New HallazgoAuditoria()

        h.Control = control
        h.Codigo = codigo
        h.Documento = documento
        h.Fecha = fecha
        h.Tipo = tipo
        h.Producto = producto
        h.Cantidad = cantidad
        h.PrecioUnitario = precio
        h.CostoUnitario = costo
        h.EsDuplicado = False
        h.PuedeEliminar = False
        h.Reparable = False
        h.Estado = EstadoHallazgo.Detectado
        h.Severidad = severidad
        h.Descripcion = descripcion
        h.Motivo = motivo
        h.Accion = accion

        Return h

    End Function

    Private Function LeerFechaData(ByVal valor As Object) As DateTime

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return DateTime.MinValue
        End If

        Return Convert.ToDateTime(valor)

    End Function

    Private Function LeerTextoData(ByVal valor As Object) As String

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return String.Empty
        End If

        Return valor.ToString().Trim()

    End Function

    ' ============================================================
    ' DATA-001
    ' DETALLE SIN TIPO_FACTURA
    '
    ' Líneas con cantidad distinta de cero: un hallazgo por línea.
    ' Líneas con cantidad cero (sin efecto en inventario): un único
    ' hallazgo resumen. No se infiere el tipo: no existe cabecera.
    ' ============================================================
    Private Function AuditarData001(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT id_Detalle_Factura, Numero_Factura, " & vbCrLf
        sql &= "    Fecha_Factura, Cod_Producto, Cantidad, " & vbCrLf
        sql &= "    Precio_Unitario, Costo_Unitario " & vbCrLf
        sql &= "FROM Detalle_Facturas " & vbCrLf
        sql &= "WHERE LTRIM(RTRIM(ISNULL(Tipo_Factura, ''))) = '' " & vbCrLf
        sql &= "AND ISNULL(Cantidad, 0) <> 0 " & vbCrLf
        sql &= "ORDER BY Fecha_Factura, Numero_Factura, id_Detalle_Factura"

        Dim dtResumen As New DataTable()

        Dim sqlResumen As String = ""

        sqlResumen &= "SELECT COUNT(*) AS Lineas, " & vbCrLf
        sqlResumen &= "    COUNT(DISTINCT Numero_Factura) AS Documentos, " & vbCrLf
        sqlResumen &= "    MIN(Fecha_Factura) AS Desde, " & vbCrLf
        sqlResumen &= "    MAX(Fecha_Factura) AS Hasta " & vbCrLf
        sqlResumen &= "FROM Detalle_Facturas " & vbCrLf
        sqlResumen &= "WHERE LTRIM(RTRIM(ISNULL(Tipo_Factura, ''))) = '' " & vbCrLf
        sqlResumen &= "AND ISNULL(Cantidad, 0) = 0"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

            Using da As New SqlDataAdapter(sqlResumen, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dtResumen)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim idFactura As Decimal =
            ObtenerDecimal(r("id_Detalle_Factura"))

            Dim documento As String = LeerTextoData(r("Numero_Factura"))
            Dim producto As String = LeerTextoData(r("Cod_Producto"))
            Dim cantidad As Double = ObtenerDouble(r("Cantidad"))
            Dim precio As Double = ObtenerDouble(r("Precio_Unitario"))
            Dim costo As Double = ObtenerDouble(r("Costo_Unitario"))

            Dim h As HallazgoAuditoria =
            NuevoHallazgoData(
                control, "DATA-001", "(sin tipo)",
                documento, LeerFechaData(r("Fecha_Factura")),
                producto, cantidad, precio, costo,
                SeveridadAuditoria.Alta,
                "Detalle de factura sin Tipo_Factura.",
                "El detalle no tiene Tipo_Factura y no existe una " &
                "cabecera en Facturas con ese número y fecha, por lo " &
                "que el tipo no puede inferirse. Tiene cantidad y " &
                "afecta el inventario." &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID Detalle Factura: " & idFactura.ToString("0") &
                Environment.NewLine &
                "Producto: " & producto &
                Environment.NewLine &
                "Cantidad: " & cantidad.ToString("N6") &
                Environment.NewLine &
                "Precio unitario: " & precio.ToString("N6") &
                Environment.NewLine &
                "Costo unitario: " & costo.ToString("N6"),
                "REVISIÓN MANUAL")

            h.IdDetalleFactura = idFactura

            hallazgos.Add(h)

        Next

        If dtResumen.Rows.Count > 0 Then

            Dim lineas As Integer =
            Convert.ToInt32(dtResumen.Rows(0)("Lineas"))

            If lineas > 0 Then

                Dim desde As DateTime =
                LeerFechaData(dtResumen.Rows(0)("Desde"))

                Dim hasta As DateTime =
                LeerFechaData(dtResumen.Rows(0)("Hasta"))

                hallazgos.Add(
                NuevoHallazgoData(
                    control, "DATA-001", "(sin tipo)",
                    "(varios)", desde,
                    String.Empty, 0, 0, 0,
                    SeveridadAuditoria.Media,
                    "Detalles sin Tipo_Factura con cantidad cero.",
                    "Hay " & lineas.ToString("N0") &
                    " detalles sin Tipo_Factura y con cantidad cero " &
                    "(" & Convert.ToInt32(
                        dtResumen.Rows(0)("Documentos")).ToString("N0") &
                    " documentos, del " & desde.ToString("dd/MM/yyyy") &
                    " al " & hasta.ToString("dd/MM/yyyy") & ")." &
                    Environment.NewLine &
                    "No tienen cabecera en Facturas ni efecto en " &
                    "inventario. Revisar qué proceso las genera; no se " &
                    "eliminan ni se les asigna tipo automáticamente.",
                    "REVISIÓN MANUAL"))

            End If

        End If

        Return hallazgos

    End Function

    ' ============================================================
    ' DATA-002
    ' CANTIDAD CERO
    '
    ' Informativo: un hallazgo resumen por tabla y tipo de movimiento.
    ' No se elimina nada: pueden ser líneas canceladas o históricas.
    ' Las líneas sin Tipo_Factura se reportan en DATA-001.
    ' ============================================================
    Private Function AuditarData002(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT N'Detalle_Facturas' AS Tabla, " & vbCrLf
        sql &= "    Tipo_Factura AS Tipo, COUNT(*) AS Lineas, " & vbCrLf
        sql &= "    MIN(Fecha_Factura) AS Desde, MAX(Fecha_Factura) AS Hasta " & vbCrLf
        sql &= "FROM Detalle_Facturas " & vbCrLf
        sql &= "WHERE Cantidad = 0 " & vbCrLf
        sql &= "AND LTRIM(RTRIM(ISNULL(Tipo_Factura, ''))) <> '' " & vbCrLf
        sql &= "GROUP BY Tipo_Factura " & vbCrLf
        sql &= "UNION ALL " & vbCrLf
        sql &= "SELECT N'Detalle_Compras', " & vbCrLf
        sql &= "    Tipo_Compra, COUNT(*), " & vbCrLf
        sql &= "    MIN(Fecha_Compra), MAX(Fecha_Compra) " & vbCrLf
        sql &= "FROM Detalle_Compras " & vbCrLf
        sql &= "WHERE Cantidad = 0 " & vbCrLf
        sql &= "GROUP BY Tipo_Compra " & vbCrLf
        sql &= "ORDER BY 1, 2"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim lineas As Integer = Convert.ToInt32(r("Lineas"))
            Dim desde As DateTime = LeerFechaData(r("Desde"))
            Dim hasta As DateTime = LeerFechaData(r("Hasta"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "DATA-002", tipo,
                "(varios)", desde,
                String.Empty, 0, 0, 0,
                SeveridadAuditoria.Baja,
                "Detalles con cantidad cero: " & tipo & ".",
                "Hay " & lineas.ToString("N0") &
                " detalles de " & tipo & " con cantidad cero en " &
                tabla & " (del " & desde.ToString("dd/MM/yyyy") &
                " al " & hasta.ToString("dd/MM/yyyy") & ")." &
                Environment.NewLine &
                "Es informativo: pueden ser líneas canceladas o " &
                "históricas sin efecto en inventario. No se eliminan " &
                "automáticamente.",
                "INFORMATIVO"))

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' DATA-005
    ' DETALLE SIN CABECERA
    '
    ' Informativo: un hallazgo por documento. Un detalle con cantidad
    ' sin cabecera (Facturas/Compras) no entra al kardex ni al costo
    ' promedio, por eso los demás controles lo excluyen. Las líneas
    ' sin Tipo_Factura se reportan en DATA-001.
    ' No se elimina nada.
    ' ============================================================
    Private Function AuditarData005(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT N'Detalle_Facturas' AS Tabla, " & vbCrLf
        sql &= "    d.Tipo_Factura AS Tipo, d.Numero_Factura AS Documento, " & vbCrLf
        sql &= "    d.Fecha_Factura AS Fecha, COUNT(*) AS Lineas " & vbCrLf
        sql &= "FROM Detalle_Facturas d " & vbCrLf
        sql &= "WHERE ISNULL(d.Cantidad, 0) <> 0 " & vbCrLf
        sql &= "AND LTRIM(RTRIM(ISNULL(d.Tipo_Factura, ''))) <> '' " & vbCrLf
        sql &= "AND NOT " & ExisteCabeceraFactura("d") & " " & vbCrLf
        sql &= "GROUP BY d.Tipo_Factura, d.Numero_Factura, d.Fecha_Factura " & vbCrLf
        sql &= "UNION ALL " & vbCrLf
        sql &= "SELECT N'Detalle_Compras', " & vbCrLf
        sql &= "    d.Tipo_Compra, d.Numero_Compra, " & vbCrLf
        sql &= "    d.Fecha_Compra, COUNT(*) " & vbCrLf
        sql &= "FROM Detalle_Compras d " & vbCrLf
        sql &= "WHERE ISNULL(d.Cantidad, 0) <> 0 " & vbCrLf
        sql &= "AND NOT EXISTS (SELECT 1 FROM Compras cab " & vbCrLf
        sql &= "    WHERE cab.Numero_Compra = d.Numero_Compra " & vbCrLf
        sql &= "    AND cab.Fecha_Compra = d.Fecha_Compra " & vbCrLf
        sql &= "    AND cab.Tipo_Compra = d.Tipo_Compra) " & vbCrLf
        sql &= "GROUP BY d.Tipo_Compra, d.Numero_Compra, d.Fecha_Compra " & vbCrLf
        sql &= "ORDER BY 4, 3"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim documento As String = LeerTextoData(r("Documento"))
            Dim fecha As DateTime = LeerFechaData(r("Fecha"))
            Dim lineas As Integer = Convert.ToInt32(r("Lineas"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "DATA-005", tipo,
                documento, fecha,
                String.Empty, 0, 0, 0,
                SeveridadAuditoria.Baja,
                "Detalle sin cabecera: " & tipo & ".",
                "El documento tiene " & lineas.ToString("N0") &
                " línea(s) en " & tabla & " con cantidad, pero no " &
                "existe su cabecera." &
                Environment.NewLine &
                "No entra al kardex ni al costo promedio, por eso los " &
                "demás controles lo excluyen. Probablemente es un " &
                "documento que no llegó a guardarse. No se elimina " &
                "automáticamente.",
                "REVISIÓN MANUAL"))

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' DATA-003
    ' COSTO NEGATIVO
    '
    ' Costo_Unitario menor que cero en Detalle_Facturas o
    ' Detalle_Compras. Un hallazgo por línea; no se corrige sin
    ' determinar el costo correcto.
    ' ============================================================
    Private Function AuditarData003(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT N'Detalle_Facturas' AS Tabla, " & vbCrLf
        sql &= "    id_Detalle_Factura AS Id, Numero_Factura AS Documento, " & vbCrLf
        sql &= "    Fecha_Factura AS Fecha, Tipo_Factura AS Tipo, " & vbCrLf
        sql &= "    Cod_Producto, Cantidad, Precio_Unitario, Costo_Unitario " & vbCrLf
        sql &= "FROM Detalle_Facturas " & vbCrLf
        sql &= "WHERE Costo_Unitario < 0 " & vbCrLf
        sql &= "UNION ALL " & vbCrLf
        sql &= "SELECT N'Detalle_Compras', " & vbCrLf
        sql &= "    id_Detalle_Compra, Numero_Compra, " & vbCrLf
        sql &= "    Fecha_Compra, Tipo_Compra, " & vbCrLf
        sql &= "    Cod_Producto, Cantidad, Precio_Unitario, Costo_Unitario " & vbCrLf
        sql &= "FROM Detalle_Compras " & vbCrLf
        sql &= "WHERE Costo_Unitario < 0 " & vbCrLf
        sql &= "ORDER BY 4, 3"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim id As Decimal = ObtenerDecimal(r("Id"))
            Dim documento As String = LeerTextoData(r("Documento"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim producto As String = LeerTextoData(r("Cod_Producto"))
            Dim cantidad As Double = ObtenerDouble(r("Cantidad"))
            Dim precio As Double = ObtenerDouble(r("Precio_Unitario"))
            Dim costo As Double = ObtenerDouble(r("Costo_Unitario"))

            Dim h As HallazgoAuditoria =
            NuevoHallazgoData(
                control, "DATA-003", tipo,
                documento, LeerFechaData(r("Fecha")),
                producto, cantidad, precio, costo,
                SeveridadAuditoria.Media,
                "Costo unitario negativo.",
                "El Costo_Unitario es negativo. No se corrige " &
                "automáticamente: hay que determinar el costo correcto." &
                Environment.NewLine &
                "Tabla: " & tabla &
                Environment.NewLine &
                "Tipo: " & tipo &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID del detalle: " & id.ToString("0") &
                Environment.NewLine &
                "Producto: " & producto &
                Environment.NewLine &
                "Cantidad: " & cantidad.ToString("N6") &
                Environment.NewLine &
                "Precio unitario: " & precio.ToString("N6") &
                Environment.NewLine &
                "Costo unitario: " & costo.ToString("N6"),
                "REVISIÓN MANUAL")

            If tabla = "Detalle_Facturas" Then
                h.IdDetalleFactura = id
            Else
                h.IdDetalleCompra = id
            End If

            hallazgos.Add(h)

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' DATA-004
    ' CANTIDAD NEGATIVA
    '
    ' Cantidad menor que cero en Detalle_Facturas o Detalle_Compras.
    ' Un hallazgo por línea. Algunos tipos de movimiento pueden usar
    ' cantidades negativas como convención: se muestra el tipo y no
    ' se modifica nada.
    ' ============================================================
    Private Function AuditarData004(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String = ""

        sql &= "SELECT N'Detalle_Facturas' AS Tabla, " & vbCrLf
        sql &= "    id_Detalle_Factura AS Id, Numero_Factura AS Documento, " & vbCrLf
        sql &= "    Fecha_Factura AS Fecha, Tipo_Factura AS Tipo, " & vbCrLf
        sql &= "    Cod_Producto, Cantidad, Precio_Unitario, Costo_Unitario " & vbCrLf
        sql &= "FROM Detalle_Facturas " & vbCrLf
        sql &= "WHERE Cantidad < 0 " & vbCrLf
        sql &= "UNION ALL " & vbCrLf
        sql &= "SELECT N'Detalle_Compras', " & vbCrLf
        sql &= "    id_Detalle_Compra, Numero_Compra, " & vbCrLf
        sql &= "    Fecha_Compra, Tipo_Compra, " & vbCrLf
        sql &= "    Cod_Producto, Cantidad, Precio_Unitario, Costo_Unitario " & vbCrLf
        sql &= "FROM Detalle_Compras " & vbCrLf
        sql &= "WHERE Cantidad < 0 " & vbCrLf
        sql &= "ORDER BY 4, 3"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim id As Decimal = ObtenerDecimal(r("Id"))
            Dim documento As String = LeerTextoData(r("Documento"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim producto As String = LeerTextoData(r("Cod_Producto"))
            Dim cantidad As Double = ObtenerDouble(r("Cantidad"))
            Dim precio As Double = ObtenerDouble(r("Precio_Unitario"))
            Dim costo As Double = ObtenerDouble(r("Costo_Unitario"))

            Dim h As HallazgoAuditoria =
            NuevoHallazgoData(
                control, "DATA-004", tipo,
                documento, LeerFechaData(r("Fecha")),
                producto, cantidad, precio, costo,
                SeveridadAuditoria.Media,
                "Cantidad negativa.",
                "La cantidad es negativa. Puede ser una convención " &
                "legítima del tipo de movimiento o un dato inválido; " &
                "no se modifica automáticamente." &
                Environment.NewLine &
                "Tabla: " & tabla &
                Environment.NewLine &
                "Tipo: " & tipo &
                Environment.NewLine &
                "Documento: " & documento &
                Environment.NewLine &
                "ID del detalle: " & id.ToString("0") &
                Environment.NewLine &
                "Producto: " & producto &
                Environment.NewLine &
                "Cantidad: " & cantidad.ToString("N6") &
                Environment.NewLine &
                "Precio unitario: " & precio.ToString("N6") &
                Environment.NewLine &
                "Costo unitario: " & costo.ToString("N6"),
                "REVISIÓN MANUAL")

            If tabla = "Detalle_Facturas" Then
                h.IdDetalleFactura = id
            Else
                h.IdDetalleCompra = id
            End If

            hallazgos.Add(h)

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' PROGRESO
    '
    ' La barra se reparte en partes iguales entre los controles que
    ' ejecuta la auditoría (un paso por control). Dentro de un paso
    ' los controles que informan su avance usan PorcentajeSegmento.
    ' ============================================================
    Private Const TOTAL_PASOS_PROGRESO As Integer = 19

    Private _SegmentoInicio As Integer = 0
    Private _SegmentoFin As Integer = 100

    Private Sub IniciarPasoProgreso(
        ByVal paso As Integer,
        ByVal mensaje As String)

        _SegmentoInicio = ((paso - 1) * 100) \ TOTAL_PASOS_PROGRESO
        _SegmentoFin = (paso * 100) \ TOTAL_PASOS_PROGRESO

        RaiseEvent Progreso(_SegmentoInicio, mensaje)

    End Sub

    Private Function PorcentajeSegmento(
        ByVal fraccion As Double) As Integer

        If fraccion < 0 Then fraccion = 0
        If fraccion > 1 Then fraccion = 1

        Return _SegmentoInicio +
            CInt((_SegmentoFin - _SegmentoInicio) * fraccion)

    End Function

    ' ============================================================
    ' COST-006
    ' PRECIO CERO CON COSTO EXISTENTE
    '
    ' Informativo. Un precio cero con costo puede ser válido
    ' (bonificación, regalía). No se declara error ni se repara.
    ' No se reportan las bonificaciones: líneas con precio cero cuyo
    ' documento tiene otra línea del mismo producto con precio.
    ' Hay decenas de miles de líneas, por eso se resume en un
    ' hallazgo por tipo de documento y mes.
    ' ============================================================
    Private Function AuditarCost006(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String =
        "SELECT df.Tipo_Factura AS Tipo, " &
        "YEAR(df.Fecha_Factura) AS Anio, " &
        "MONTH(df.Fecha_Factura) AS Mes, " &
        "COUNT(*) AS Lineas, " &
        "COUNT(DISTINCT df.Numero_Factura) AS Docs, " &
        "COUNT(DISTINCT df.Cod_Producto) AS Productos, " &
        "SUM(CONVERT(float, df.Cantidad)) AS Unidades, " &
        "SUM(CONVERT(float, df.Cantidad) * " &
        "CONVERT(float, df.Costo_Unitario)) AS CostoTotal, " &
        "MIN(df.Numero_Factura) AS Muestra " &
        "FROM Detalle_Facturas df " &
        "LEFT JOIN Productos p ON p.Cod_Productos = df.Cod_Producto " &
        "WHERE df.Tipo_Factura IN (N'Factura', N'Devolucion de Venta') " &
        "AND ISNULL(df.Cantidad, 0) <> 0 " &
        "AND ISNULL(df.Precio_Unitario, 0) = 0 " &
        "AND ISNULL(df.Costo_Unitario, 0) > 0 " &
        "AND ISNULL(p.Tipo_Producto, '') NOT IN ('Servicio', 'Descuento') " &
        "AND " & ExisteCabeceraFactura("df") & " " &
        "AND NOT EXISTS (SELECT 1 FROM Detalle_Facturas s " &
        "WHERE s.Numero_Factura = df.Numero_Factura " &
        "AND s.Fecha_Factura = df.Fecha_Factura " &
        "AND s.Tipo_Factura = df.Tipo_Factura " &
        "AND s.Cod_Producto = df.Cod_Producto " &
        "AND ISNULL(s.Precio_Unitario, 0) > 0) " &
        "GROUP BY df.Tipo_Factura, YEAR(df.Fecha_Factura), " &
        "MONTH(df.Fecha_Factura) " &
        "ORDER BY YEAR(df.Fecha_Factura), MONTH(df.Fecha_Factura), " &
        "df.Tipo_Factura"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim anio As Integer = Convert.ToInt32(r("Anio"))
            Dim mes As Integer = Convert.ToInt32(r("Mes"))
            Dim lineas As Integer = Convert.ToInt32(r("Lineas"))
            Dim docs As Integer = Convert.ToInt32(r("Docs"))
            Dim productos As Integer = Convert.ToInt32(r("Productos"))
            Dim unidades As Double = ObtenerDouble(r("Unidades"))
            Dim costoTotal As Double = ObtenerDouble(r("CostoTotal"))
            Dim muestra As String = LeerTextoData(r("Muestra"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "COST-006", tipo,
                muestra, New DateTime(anio, mes, 1),
                String.Empty, unidades, 0, costoTotal,
                SeveridadAuditoria.Informativa,
                "Precio cero con costo existente (informativo).",
                lineas.ToString("N0") & " línea(s) de " & tipo &
                " con Precio_Unitario en cero y Costo_Unitario " &
                "mayor que cero en " & mes.ToString("00") & "/" &
                anio.ToString() & "." &
                Environment.NewLine &
                docs.ToString("N0") & " documento(s), " &
                productos.ToString("N0") & " producto(s), " &
                unidades.ToString("N2") & " unidad(es). " &
                "Costo total de esas unidades: " &
                costoTotal.ToString("N2") & "." &
                Environment.NewLine &
                "Documento de muestra: " & muestra &
                Environment.NewLine &
                "Puede ser válido (bonificación, regalía). No se " &
                "modifica ningún precio.",
                "INFORMATIVO"))

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' COST-007
    ' COSTO HISTÓRICO DIFERENTE DEL COSTO PROMEDIO
    '
    ' Informativo. Para cada producto vendido en los últimos
    ' COST007_DIAS días (respecto a su última venta), compara el
    ' Costo_Unitario de su última línea de Factura con el resultado
    ' de CostoPromedioKardex para la fecha de esa línea.
    ' No modifica CostoPromedioKardex ni ningún dato.
    ' ============================================================
    Private Const COST007_DIAS As Integer = 90

    Private Function AuditarCost007(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String =
        "SELECT u.Cod_Producto, u.Fecha_Factura, u.Numero_Factura, " &
        "u.Costo_Unitario " &
        "FROM (SELECT Cod_Producto, Fecha_Factura, Numero_Factura, " &
        " Costo_Unitario, " &
        " ROW_NUMBER() OVER (PARTITION BY Cod_Producto " &
        "  ORDER BY Fecha_Factura DESC, id_Detalle_Factura DESC) AS rn " &
        " FROM Detalle_Facturas " &
        " WHERE Tipo_Factura = N'Factura' " &
        " AND ISNULL(Cantidad, 0) <> 0 " &
        " AND " & ExisteCabeceraFactura("Detalle_Facturas") & " " &
        " AND ISNULL(Costo_Unitario, 0) > 0) u " &
        "WHERE u.rn = 1 " &
        "AND u.Fecha_Factura >= DATEADD(day, -" &
        COST007_DIAS.ToString() &
        ", (SELECT MAX(Fecha_Factura) FROM Detalle_Facturas " &
        " WHERE Tipo_Factura = N'Factura')) " &
        "ORDER BY u.Cod_Producto"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        Dim procesados As Integer = 0

        For Each r As DataRow In dt.Rows

            If DebeCancelar() Then
                Exit For
            End If

            procesados += 1

            RaiseEvent Progreso(
                PorcentajeSegmento(procesados / CDbl(dt.Rows.Count)),
                "Verificando COST-007 - producto " &
                procesados.ToString() & " de " &
                dt.Rows.Count.ToString() & "...")

            Dim producto As String = LeerTextoData(r("Cod_Producto"))
            Dim fecha As DateTime = LeerFechaData(r("Fecha_Factura"))
            Dim documento As String = LeerTextoData(r("Numero_Factura"))
            Dim historico As Double = ObtenerDouble(r("Costo_Unitario"))

            Dim rst As RstCostoPromedio =
                CostoPromedioKardex(producto, fecha)

            Dim promedio As Double = rst.Costo_Cordoba

            Dim diferencia As Double = Math.Abs(historico - promedio)

            If diferencia <= 0.01 OrElse
               diferencia / historico <= 0.01 Then
                Continue For
            End If

            hallazgos.Add(
            NuevoHallazgoData(
                control, "COST-007", "Factura",
                documento, fecha,
                producto, 0, 0, historico,
                SeveridadAuditoria.Informativa,
                "Costo histórico diferente del costo promedio (informativo).",
                "Última venta del producto: factura " & documento &
                " del " & fecha.ToString("dd/MM/yyyy") & "." &
                Environment.NewLine &
                "Costo histórico (Detalle_Facturas): " &
                historico.ToString("N6") & Environment.NewLine &
                "Costo promedio (CostoPromedioKardex a esa fecha): " &
                promedio.ToString("N6") & Environment.NewLine &
                "Diferencia: " & (historico - promedio).ToString("N6") &
                Environment.NewLine &
                "Una diferencia no es automáticamente un error: " &
                "ambos costos pueden tener significados distintos. " &
                "No se repara.",
                "INFORMATIVO"))

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' COST-008
    ' CAMBIO DE COSTO SIN MOVIMIENTO DE ENTRADA JUSTIFICATIVO
    '
    ' Por producto, ordena las líneas de Factura con costo por
    ' fecha e id y toma el PRIMER cambio de costo (diferencia mayor
    ' a 0.01 y a 2%) que no tiene ninguna entrada (Mercancía
    ' Recibida, Transferencia Recibida o Devolución de Compra, con
    ' cantidad) entre la fecha de la línea anterior y la del cambio,
    ' ambas inclusive. Solo detecta; no existe aún una regla de
    ' reparación segura.
    ' ============================================================
    ' Otras líneas del mismo producto en el mismo documento que la
    ' línea del cambio (alias u = #u).
    Private Const SQL_HERMANAS_COST008 As String =
        "WHERE s.Numero_Factura = u.DocNue " &
        "AND s.Fecha_Factura = u.FechaNue " &
        "AND s.Tipo_Factura = N'Factura' " &
        "AND s.Cod_Producto = u.Cod_Producto " &
        "AND s.id_Detalle_Factura <> u.IdNue " &
        "AND ISNULL(s.Cantidad, 0) <> 0 " &
        "AND ISNULL(s.Costo_Unitario, 0) > 0"

    Private Const ORIGEN_RETORNO_COST008 As String =
        "Costo anterior y posterior idénticos (retorno exacto)"

    ' ------------------------------------------------------------
    ' Evalúa la regla 1 de COST-008. Devuelve el número de líneas
    ' del bloque (1 a 4) o 0 si la regla no se cumple. Usa la tabla
    ' temporal #m de la misma conexión.
    '
    ' Se cumple cuando:
    '   - las líneas del producto en el documento son consecutivas,
    '     todas con el costo del cambio, y son TODAS las del producto
    '     en ese documento,
    '   - la línea siguiente al bloque tiene el costo anterior
    '     (diferencia menor a 0.011),
    '   - no hay entradas desde la línea anterior hasta la siguiente.
    ' ------------------------------------------------------------
    Private Function EvaluarRetornoExactoCost008(
        ByVal cn As SqlConnection,
        ByVal producto As String,
        ByVal rn As Integer,
        ByVal documento As String,
        ByVal fechaNue As DateTime,
        ByVal fechaAnt As DateTime,
        ByVal costoAnt As Double,
        ByVal costoNue As Double) As Integer

        Dim docs As New List(Of String)
        Dim fechas As New List(Of DateTime)
        Dim costos As New List(Of Double)

        Using cmd As New SqlCommand(
        "SELECT Numero_Factura, Fecha_Factura, Costo_Unitario " &
        "FROM #m WHERE Cod_Producto = @Producto " &
        "AND rn >= @Rn AND rn <= @Rn + 5 ORDER BY rn", cn)

            cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                producto
            cmd.Parameters.Add("@Rn", SqlDbType.Int).Value = rn

            Using dr As SqlDataReader = cmd.ExecuteReader()

                While dr.Read()

                    docs.Add(LeerTextoData(dr(0)))
                    fechas.Add(LeerFechaData(dr(1)))
                    costos.Add(ObtenerDouble(dr(2)))

                End While

            End Using

        End Using

        Dim n As Integer = 0

        While n < docs.Count AndAlso
              docs(n) = documento AndAlso
              fechas(n) = fechaNue AndAlso
              Math.Abs(costos(n) - costoNue) < 0.0001

            n += 1

        End While

        If n = 0 OrElse n > 4 OrElse n >= docs.Count Then
            Return 0
        End If

        If Math.Abs(costos(n) - costoAnt) >= 0.011 Then
            Return 0
        End If

        Dim fechaSig As DateTime = fechas(n)

        ' Deben ser todas las líneas del producto en el documento.
        Using cmd As New SqlCommand(
        "SELECT COUNT(*) FROM #m WHERE Cod_Producto = @Producto " &
        "AND Numero_Factura = @Documento AND Fecha_Factura = @Fecha", cn)

            cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                producto
            cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 50).Value =
                documento
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value =
                fechaNue

            If Convert.ToInt32(cmd.ExecuteScalar()) <> n Then
                Return 0
            End If

        End Using

        ' Sin entradas entre la línea anterior y la siguiente.
        Using cmd As New SqlCommand(
        "SELECT COUNT(*) FROM Detalle_Compras c " &
        "WHERE c.Cod_Producto = @Producto " &
        "AND c.Fecha_Compra >= @FechaAnt " &
        "AND c.Fecha_Compra < DATEADD(day, 1, @FechaSig) " &
        "AND ISNULL(c.Cantidad, 0) <> 0 " &
        "AND c.Tipo_Compra IN (N'Mercancia Recibida', " &
        "N'Transferencia Recibida', N'Devolucion de Compra')", cn)

            cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                producto
            cmd.Parameters.Add("@FechaAnt", SqlDbType.SmallDateTime).Value =
                fechaAnt
            cmd.Parameters.Add("@FechaSig", SqlDbType.SmallDateTime).Value =
                fechaSig

            If Convert.ToInt32(cmd.ExecuteScalar()) <> 0 Then
                Return 0
            End If

        End Using

        Return n

    End Function

    Private Function AuditarCost008(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Const ENTRADAS As String =
            "c.Tipo_Compra IN (N'Mercancia Recibida', " &
            "N'Transferencia Recibida', N'Devolucion de Compra')"

        Dim sql As String =
        "IF OBJECT_ID('tempdb..#m') IS NOT NULL DROP TABLE #m; " &
        "IF OBJECT_ID('tempdb..#c') IS NOT NULL DROP TABLE #c; " &
        "IF OBJECT_ID('tempdb..#u') IS NOT NULL DROP TABLE #u; " &
        "SELECT Cod_Producto, Fecha_Factura, id_Detalle_Factura, " &
        "Numero_Factura, Costo_Unitario, " &
        "ROW_NUMBER() OVER (PARTITION BY Cod_Producto " &
        "ORDER BY Fecha_Factura, id_Detalle_Factura) AS rn " &
        "INTO #m FROM Detalle_Facturas " &
        "WHERE Tipo_Factura = N'Factura' AND ISNULL(Cantidad, 0) <> 0 " &
        "AND " & ExisteCabeceraFactura("Detalle_Facturas") & " " &
        "AND ISNULL(Costo_Unitario, 0) > 0; " &
        "CREATE UNIQUE CLUSTERED INDEX ix_m ON #m(Cod_Producto, rn); " &
        "SELECT a.Cod_Producto, p.Fecha_Factura AS FechaAnt, " &
        "p.Numero_Factura AS DocAnt, p.Costo_Unitario AS CostoAnt, " &
        "a.Fecha_Factura AS FechaNue, a.Numero_Factura AS DocNue, " &
        "a.id_Detalle_Factura AS IdNue, a.Costo_Unitario AS CostoNue, " &
        "a.rn AS Rn " &
        "INTO #c FROM #m a INNER JOIN #m p " &
        "ON p.Cod_Producto = a.Cod_Producto AND p.rn = a.rn - 1 " &
        "WHERE ABS(a.Costo_Unitario - p.Costo_Unitario) > 0.01 " &
        "AND ABS(a.Costo_Unitario - p.Costo_Unitario) / " &
        "p.Costo_Unitario > 0.02; " &
        "SELECT x.*, ROW_NUMBER() OVER (PARTITION BY x.Cod_Producto " &
        "ORDER BY x.FechaNue, x.IdNue) AS k " &
        "INTO #u FROM #c x WHERE NOT EXISTS (SELECT 1 " &
        "FROM Detalle_Compras c WHERE c.Cod_Producto = x.Cod_Producto " &
        "AND c.Fecha_Compra >= x.FechaAnt " &
        "AND c.Fecha_Compra < DATEADD(day, 1, x.FechaNue) " &
        "AND ISNULL(c.Cantidad, 0) <> 0 AND " & ENTRADAS & "); " &
        "SELECT u.Cod_Producto, u.FechaAnt, u.DocAnt, u.CostoAnt, " &
        "u.FechaNue, u.DocNue, u.CostoNue, u.IdNue, u.Rn, " &
        "(SELECT COUNT(*) FROM Detalle_Facturas s " & SQL_HERMANAS_COST008 &
        ") AS Hermanas, " &
        "(SELECT MIN(s.Costo_Unitario) FROM Detalle_Facturas s " &
        SQL_HERMANAS_COST008 & ") AS CostoHermMin, " &
        "(SELECT MAX(s.Costo_Unitario) FROM Detalle_Facturas s " &
        SQL_HERMANAS_COST008 & ") AS CostoHermMax, " &
        "e.Fecha_Compra AS FechaEnt, e.Tipo_Compra AS TipoEnt, " &
        "e.Numero_Compra AS DocEnt, e.Costo_Unitario AS CostoEnt " &
        "FROM #u u OUTER APPLY (SELECT TOP 1 c.Fecha_Compra, " &
        "c.Tipo_Compra, c.Numero_Compra, c.Costo_Unitario " &
        "FROM Detalle_Compras c WHERE c.Cod_Producto = u.Cod_Producto " &
        "AND c.Fecha_Compra < u.FechaAnt " &
        "AND ISNULL(c.Cantidad, 0) <> 0 AND " & ENTRADAS & " " &
        "ORDER BY c.Fecha_Compra DESC) e " &
        "WHERE u.k = 1 ORDER BY u.Cod_Producto;"

        ' Regla 1 (retorno exacto): IdNue -> líneas del bloque.
        Dim bloques As New Dictionary(Of Decimal, Integer)

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 600
                da.Fill(dt)
            End Using

            ' Las tablas temporales #m viven en esta conexión.
            For Each r As DataRow In dt.Rows

                Dim lineas As Integer =
                    EvaluarRetornoExactoCost008(
                        cn,
                        LeerTextoData(r("Cod_Producto")),
                        Convert.ToInt32(r("Rn")),
                        LeerTextoData(r("DocNue")),
                        LeerFechaData(r("FechaNue")),
                        LeerFechaData(r("FechaAnt")),
                        ObtenerDouble(r("CostoAnt")),
                        ObtenerDouble(r("CostoNue")))

                If lineas > 0 Then
                    bloques(Convert.ToDecimal(r("IdNue"))) = lineas
                End If

            Next

        End Using

        For Each r As DataRow In dt.Rows

            Dim producto As String = LeerTextoData(r("Cod_Producto"))
            Dim fechaAnt As DateTime = LeerFechaData(r("FechaAnt"))
            Dim docAnt As String = LeerTextoData(r("DocAnt"))
            Dim costoAnt As Double = ObtenerDouble(r("CostoAnt"))
            Dim fechaNue As DateTime = LeerFechaData(r("FechaNue"))
            Dim docNue As String = LeerTextoData(r("DocNue"))
            Dim costoNue As Double = ObtenerDouble(r("CostoNue"))

            Dim ultimaEntrada As String

            If IsDBNull(r("FechaEnt")) Then

                ultimaEntrada = "No hay entradas anteriores del producto."

            Else

                ultimaEntrada =
                    "Última entrada anterior: " &
                    LeerTextoData(r("TipoEnt")) & " " &
                    LeerTextoData(r("DocEnt")) & " del " &
                    LeerFechaData(r("FechaEnt")).ToString("dd/MM/yyyy") &
                    " (costo " &
                    ObtenerDouble(r("CostoEnt")).ToString("N6") & ")."

            End If

            ' --------------------------------------------------------
            ' REGLA DE REPARACIÓN SEGURA
            '
            ' La línea del cambio es la única del mismo producto en
            ' su documento con un costo distinto: todas las demás
            ' líneas del producto en ese documento tienen el mismo
            ' costo, y ese costo es el del movimiento anterior.
            ' Solo en ese caso se propone ese costo.
            ' --------------------------------------------------------

            Dim hermanas As Integer = Convert.ToInt32(r("Hermanas"))
            Dim reparable As Boolean = False
            Dim costoHermano As Double = 0

            If hermanas > 0 Then

                Dim minimo As Double = ObtenerDouble(r("CostoHermMin"))
                Dim maximo As Double = ObtenerDouble(r("CostoHermMax"))

                If Math.Abs(maximo - minimo) < 0.0001 AndAlso
                   Math.Abs(minimo - costoAnt) < 0.011 AndAlso
                   Math.Abs(minimo - costoNue) > 0.01 Then

                    reparable = True
                    costoHermano = minimo

                End If

            End If

            ' --------------------------------------------------------
            ' REGLA 1: RETORNO EXACTO
            '
            ' Las líneas del producto en este documento (1 a 4) tienen
            ' un costo distinto, el movimiento anterior y el posterior
            ' tienen el mismo costo y no hay entradas entre ambos.
            ' Sin entradas el costo no puede cambiar: se propone el
            ' costo anterior.
            ' --------------------------------------------------------

            Dim lineasBloque As Integer = 0

            If Not reparable Then

                bloques.TryGetValue(
                    Convert.ToDecimal(r("IdNue")), lineasBloque)

            End If

            Dim motivo As String =
                "Movimiento anterior: factura " & docAnt & " del " &
                fechaAnt.ToString("dd/MM/yyyy") & ", costo " &
                costoAnt.ToString("N6") & "." & Environment.NewLine &
                "Movimiento del cambio: factura " & docNue & " del " &
                fechaNue.ToString("dd/MM/yyyy") & ", costo " &
                costoNue.ToString("N6") & "." & Environment.NewLine &
                "Entradas encontradas entre ambos movimientos: 0 " &
                "(Mercancía Recibida, Transferencia Recibida, " &
                "Devolución de Compra)." & Environment.NewLine &
                ultimaEntrada & Environment.NewLine &
                "Es el primer cambio injustificado de este producto."

            If reparable Then

                motivo &= Environment.NewLine &
                    "Las otras " & hermanas.ToString() &
                    " línea(s) de este producto en el mismo documento " &
                    "tienen costo " & costoHermano.ToString("N6") &
                    ". Solo esta línea difiere: se propone ese costo."

            ElseIf lineasBloque > 0 Then

                motivo &= Environment.NewLine &
                    "Las " & lineasBloque.ToString() &
                    " línea(s) del producto en este documento tienen " &
                    "costo " & costoNue.ToString("N6") &
                    "; la línea anterior y la posterior tienen " &
                    costoAnt.ToString("N6") &
                    " y no hay entradas entre ambas. Sin entradas el " &
                    "costo no puede cambiar: se propone el costo anterior."

            Else

                motivo &= Environment.NewLine &
                    "No se repara: no hay una regla segura para " &
                    "determinar el costo correcto."

            End If

            Dim h As HallazgoAuditoria =
            NuevoHallazgoData(
                control, "COST-008", "Factura",
                docNue, fechaNue,
                producto, 0, 0, costoNue,
                SeveridadAuditoria.Alta,
                "Cambio de costo sin movimiento de entrada justificativo.",
                motivo,
                "REVISIÓN MANUAL")

            If reparable Then

                h.IdDetalleFactura = Convert.ToDecimal(r("IdNue"))
                h.Reparable = True
                h.TieneCostoPropuesto = True
                h.CostoPropuesto = costoHermano
                h.CostoPropuestoDolar = 0
                h.OrigenCosto = "Líneas del mismo producto en el documento"
                h.Estado = EstadoHallazgo.Reparable
                h.Accion = "REPARAR"

            ElseIf lineasBloque > 0 Then

                h.IdDetalleFactura = Convert.ToDecimal(r("IdNue"))
                h.Reparable = True
                h.TieneCostoPropuesto = True
                h.CostoPropuesto = costoAnt
                h.CostoPropuestoDolar = 0
                h.OrigenCosto = ORIGEN_RETORNO_COST008
                h.LineasAfectadas = lineasBloque
                h.Estado = EstadoHallazgo.Reparable
                h.Accion = "REPARAR"

            End If

            hallazgos.Add(h)

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' REPARAR COST-008
    '
    ' Corrige Costo_Unitario de UNA línea de Detalle_Facturas con el
    ' costo que tienen las demás líneas del mismo producto en el
    ' mismo documento. No usa CostoPromedioKardex ni toca otras
    ' líneas, tablas o transferencias.
    '
    ' Dentro de una transacción vuelve a comprobar que:
    '   - la línea conserva el costo detectado,
    '   - existen otras líneas del producto en el documento,
    '   - todas tienen exactamente el costo propuesto.
    ' ============================================================
    Public Function RepararCosto008(
        ByVal hallazgo As HallazgoAuditoria) As Boolean

        UltimoError = String.Empty

        Try

            If hallazgo Is Nothing OrElse
               hallazgo.Codigo <> "COST-008" OrElse
               Not hallazgo.Reparable OrElse
               Not hallazgo.TieneCostoPropuesto OrElse
               hallazgo.IdDetalleFactura <= 0 OrElse
               hallazgo.CostoPropuesto <= 0 Then

                UltimoError = "El hallazgo no es reparable."
                Return False

            End If

            If hallazgo.OrigenCosto = ORIGEN_RETORNO_COST008 Then
                Return RepararCosto008Bloque(hallazgo)
            End If

            Dim costoAnterior As Double = hallazgo.CostoUnitario
            Dim costoNuevo As Double = hallazgo.CostoPropuesto

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Using tx As SqlTransaction = cn.BeginTransaction()

                    ' ----------------------------------------------------
                    ' COMPROBAR LAS LÍNEAS HERMANAS
                    ' ----------------------------------------------------

                    Dim hermanas As Integer = 0
                    Dim distintas As Integer = 0

                    Using cmd As New SqlCommand(
                    "SELECT COUNT(*), " &
                    "SUM(CASE WHEN ABS(s.Costo_Unitario - @Costo) > " &
                    "0.0001 THEN 1 ELSE 0 END) " &
                    "FROM Detalle_Facturas s " &
                    "WHERE s.Numero_Factura = @Documento " &
                    "AND s.Fecha_Factura = @Fecha " &
                    "AND s.Tipo_Factura = N'Factura' " &
                    "AND s.Cod_Producto = @Producto " &
                    "AND s.id_Detalle_Factura <> @IdDetalle " &
                    "AND ISNULL(s.Cantidad, 0) <> 0 " &
                    "AND ISNULL(s.Costo_Unitario, 0) > 0",
                    cn, tx)

                        cmd.Parameters.Add("@Costo", SqlDbType.Float).Value =
                            costoNuevo
                        cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 50).Value =
                            hallazgo.Documento
                        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value =
                            hallazgo.Fecha
                        cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                            hallazgo.Producto
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura

                        Using dr As SqlDataReader = cmd.ExecuteReader()

                            If dr.Read() Then

                                hermanas = Convert.ToInt32(dr(0))

                                If Not IsDBNull(dr(1)) Then
                                    distintas = Convert.ToInt32(dr(1))
                                End If

                            End If

                        End Using

                    End Using

                    If hermanas = 0 OrElse distintas > 0 Then

                        tx.Rollback()

                        UltimoError =
                            "Las otras líneas del producto en el documento " &
                            "ya no tienen el costo propuesto. Vuelva a " &
                            "ejecutar la auditoría."

                        Return False

                    End If

                    ' ----------------------------------------------------
                    ' ACTUALIZAR LA LÍNEA
                    ' ----------------------------------------------------

                    Dim filas As Integer

                    Using cmd As New SqlCommand(
                    "UPDATE Detalle_Facturas " &
                    "SET Costo_Unitario = @CostoNuevo " &
                    "WHERE id_Detalle_Factura = @IdDetalle " &
                    "AND Numero_Factura = @Documento " &
                    "AND Fecha_Factura = @Fecha " &
                    "AND Tipo_Factura = N'Factura' " &
                    "AND Cod_Producto = @Producto " &
                    "AND ABS(ISNULL(Costo_Unitario, 0) - @CostoActual) " &
                    "< 0.000001",
                    cn, tx)

                        cmd.Parameters.Add("@CostoNuevo", SqlDbType.Float).Value =
                            costoNuevo
                        cmd.Parameters.Add("@CostoActual", SqlDbType.Float).Value =
                            costoAnterior
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Decimal).Value =
                            hallazgo.IdDetalleFactura
                        cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 50).Value =
                            hallazgo.Documento
                        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value =
                            hallazgo.Fecha
                        cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                            hallazgo.Producto

                        filas = cmd.ExecuteNonQuery()

                    End Using

                    If filas <> 1 Then

                        tx.Rollback()

                        UltimoError =
                            "La línea cambió después de la auditoría " &
                            "(filas afectadas: " & filas.ToString() &
                            "). Vuelva a ejecutar la auditoría."

                        Return False

                    End If

                    tx.Commit()

                End Using

            End Using

            ' El costo ya está guardado: un fallo de la bitácora no
            ' debe informar la reparación como fallida.
            Try

                Bitacora(
                    Now,
                    NombreUsuario,
                    "Auditoria Facturacion",
                    "Reparo costo COST-008:" & hallazgo.Documento &
                    " Prod:" & hallazgo.Producto &
                    " Det:" & hallazgo.IdDetalleFactura.ToString("0") &
                    " " & costoAnterior.ToString("N6") &
                    "->" & costoNuevo.ToString("N6"))

            Catch
            End Try

            hallazgo.CostoUnitario = costoNuevo

            hallazgo.Motivo =
                "El Costo_Unitario fue corregido desde " &
                costoAnterior.ToString("N6") & " hasta " &
                costoNuevo.ToString("N6") &
                " con el costo de las otras líneas del producto " &
                "en el mismo documento."

            hallazgo.Estado = EstadoHallazgo.Reparado
            hallazgo.Reparable = False
            hallazgo.TieneCostoPropuesto = False
            hallazgo.Accion = "REPARADO"

            Return True

        Catch ex As Exception

            UltimoError = ex.Message

            Return False

        End Try

    End Function

    ' ============================================================
    ' REPARAR COST-008 - REGLA 1 (RETORNO EXACTO)
    '
    ' Corrige Costo_Unitario de las LineasAfectadas líneas del
    ' producto en el documento (todas con el costo detectado) con el
    ' costo anterior, que es también el posterior. Dentro de una
    ' transacción comprueba que el producto tiene en el documento
    ' exactamente esas líneas y que todas conservan el costo
    ' detectado. No toca otras líneas ni tablas.
    ' ============================================================
    Private Function RepararCosto008Bloque(
        ByVal hallazgo As HallazgoAuditoria) As Boolean

        Dim esperadas As Integer = hallazgo.LineasAfectadas

        If esperadas < 1 OrElse esperadas > 4 Then

            UltimoError = "El hallazgo no tiene un bloque de líneas válido."
            Return False

        End If

        Dim costoAnterior As Double = hallazgo.CostoUnitario
        Dim costoNuevo As Double = hallazgo.CostoPropuesto

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using tx As SqlTransaction = cn.BeginTransaction()

                Dim total As Integer = 0
                Dim conformes As Integer = 0

                Using cmd As New SqlCommand(
                "SELECT COUNT(*), " &
                "SUM(CASE WHEN ABS(Costo_Unitario - @CostoActual) < " &
                "0.0001 THEN 1 ELSE 0 END) " &
                "FROM Detalle_Facturas " &
                "WHERE Numero_Factura = @Documento " &
                "AND Fecha_Factura = @Fecha " &
                "AND Tipo_Factura = N'Factura' " &
                "AND Cod_Producto = @Producto " &
                "AND ISNULL(Cantidad, 0) <> 0 " &
                "AND ISNULL(Costo_Unitario, 0) > 0",
                cn, tx)

                    cmd.Parameters.Add("@CostoActual", SqlDbType.Float).Value =
                        costoAnterior
                    cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 50).Value =
                        hallazgo.Documento
                    cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value =
                        hallazgo.Fecha
                    cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                        hallazgo.Producto

                    Using dr As SqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            total = Convert.ToInt32(dr(0))

                            If Not IsDBNull(dr(1)) Then
                                conformes = Convert.ToInt32(dr(1))
                            End If

                        End If

                    End Using

                End Using

                If total <> esperadas OrElse conformes <> esperadas Then

                    tx.Rollback()

                    UltimoError =
                        "Las líneas del producto en el documento cambiaron " &
                        "después de la auditoría (esperadas: " &
                        esperadas.ToString() & ", encontradas: " &
                        total.ToString() & ", con el costo detectado: " &
                        conformes.ToString() &
                        "). Vuelva a ejecutar la auditoría."

                    Return False

                End If

                Dim filas As Integer

                Using cmd As New SqlCommand(
                "UPDATE Detalle_Facturas " &
                "SET Costo_Unitario = @CostoNuevo " &
                "WHERE Numero_Factura = @Documento " &
                "AND Fecha_Factura = @Fecha " &
                "AND Tipo_Factura = N'Factura' " &
                "AND Cod_Producto = @Producto " &
                "AND ISNULL(Cantidad, 0) <> 0 " &
                "AND ABS(ISNULL(Costo_Unitario, 0) - @CostoActual) " &
                "< 0.0001",
                cn, tx)

                    cmd.Parameters.Add("@CostoNuevo", SqlDbType.Float).Value =
                        costoNuevo
                    cmd.Parameters.Add("@CostoActual", SqlDbType.Float).Value =
                        costoAnterior
                    cmd.Parameters.Add("@Documento", SqlDbType.NVarChar, 50).Value =
                        hallazgo.Documento
                    cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value =
                        hallazgo.Fecha
                    cmd.Parameters.Add("@Producto", SqlDbType.NVarChar, 50).Value =
                        hallazgo.Producto

                    filas = cmd.ExecuteNonQuery()

                End Using

                If filas <> esperadas Then

                    tx.Rollback()

                    UltimoError =
                        "Filas afectadas: " & filas.ToString() &
                        " (esperadas: " & esperadas.ToString() &
                        "). No se realizó ningún cambio."

                    Return False

                End If

                tx.Commit()

            End Using

        End Using

        Try

            Bitacora(
                Now,
                NombreUsuario,
                "Auditoria Facturacion",
                "Reparo costo COST-008 (retorno exacto):" &
                hallazgo.Documento &
                " Prod:" & hallazgo.Producto &
                " Lineas:" & esperadas.ToString() &
                " " & costoAnterior.ToString("N6") &
                "->" & costoNuevo.ToString("N6"))

        Catch
        End Try

        hallazgo.CostoUnitario = costoNuevo

        hallazgo.Motivo =
            "El Costo_Unitario de " & esperadas.ToString() &
            " línea(s) fue corregido desde " &
            costoAnterior.ToString("N6") & " hasta " &
            costoNuevo.ToString("N6") &
            ": el movimiento anterior y el posterior tenían ese costo " &
            "y no había entradas entre ambos."

        hallazgo.Estado = EstadoHallazgo.Reparado
        hallazgo.Reparable = False
        hallazgo.TieneCostoPropuesto = False
        hallazgo.Accion = "REPARADO"

        Return True

    End Function

    ' ============================================================
    ' CONSULTA BASE DE TC-001 Y TC-002
    '
    ' Documentos en dólares agrupados por tabla, tipo y día.
    ' La tasa válida de cada día está en la tabla TasaCambio.
    ' (El campo TasaCambio de los detalles no se usa: no es una
    ' regla confiable, la mayoría de las líneas en dólares lo
    ' tienen en cero.)
    ' ============================================================
    Private Const SQL_DOCUMENTOS_DOLARES As String =
        "SELECT N'Facturas' AS Tabla, Tipo_Factura AS Tipo, " &
        "CONVERT(varchar(8), Fecha_Factura, 112) AS Dia, " &
        "COUNT(*) AS Docs, MIN(Numero_Factura) AS Muestra " &
        "FROM Facturas WHERE MonedaFactura = N'Dolares' " &
        "GROUP BY Tipo_Factura, CONVERT(varchar(8), Fecha_Factura, 112) " &
        "UNION ALL " &
        "SELECT N'Compras', Tipo_Compra, " &
        "CONVERT(varchar(8), Fecha_Compra, 112), " &
        "COUNT(*), MIN(Numero_Compra) " &
        "FROM Compras WHERE MonedaCompra = N'Dolares' " &
        "GROUP BY Tipo_Compra, CONVERT(varchar(8), Fecha_Compra, 112) " &
        "UNION ALL " &
        "SELECT N'Recibo', N'Recibo', " &
        "CONVERT(varchar(8), Fecha_Recibo, 112), " &
        "COUNT(*), MIN(CodReciboPago) " &
        "FROM Recibo WHERE MonedaRecibo = N'Dolares' " &
        "GROUP BY CONVERT(varchar(8), Fecha_Recibo, 112)"

    Private Function LeerDiaTasa(ByVal valor As Object) As DateTime

        Return DateTime.ParseExact(
            LeerTextoData(valor),
            "yyyyMMdd",
            Globalization.CultureInfo.InvariantCulture)

    End Function

    ' ============================================================
    ' TC-001
    ' TASA DE CAMBIO INEXISTENTE
    '
    ' Documentos en dólares cuya fecha no tiene fila en TasaCambio.
    ' Un hallazgo por tabla, tipo y día. No se asigna ninguna tasa.
    ' ============================================================
    Private Function AuditarTc001(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dt As New DataTable()

        Dim sql As String =
        "SELECT d.Tabla, d.Tipo, d.Dia, d.Docs, d.Muestra " &
        "FROM (" & SQL_DOCUMENTOS_DOLARES & ") d " &
        "WHERE NOT EXISTS (SELECT 1 FROM TasaCambio x " &
        "WHERE x.FechaTasa >= CONVERT(smalldatetime, d.Dia, 112) " &
        "AND x.FechaTasa < DATEADD(day, 1, " &
        "CONVERT(smalldatetime, d.Dia, 112))) " &
        "ORDER BY d.Dia, d.Tabla, d.Tipo"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dt)
            End Using

        End Using

        For Each r As DataRow In dt.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim dia As DateTime = LeerDiaTasa(r("Dia"))
            Dim docs As Integer = Convert.ToInt32(r("Docs"))
            Dim muestra As String = LeerTextoData(r("Muestra"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "TC-001", tabla & " - " & tipo,
                muestra, dia,
                String.Empty, 0, 0, 0,
                SeveridadAuditoria.Alta,
                "Documentos en dólares sin tasa de cambio.",
                "No existe una fila en TasaCambio para el " &
                dia.ToString("dd/MM/yyyy") & ", pero hay " &
                docs.ToString("N0") & " documento(s) en dólares de " &
                tabla & " (" & tipo & ")." &
                Environment.NewLine &
                "Documento de muestra: " & muestra &
                Environment.NewLine &
                "No se asigna una tasa automáticamente: hay que " &
                "confirmar la tasa que correspondía a esa fecha.",
                "REVISIÓN MANUAL"))

        Next

        Return hallazgos

    End Function

    ' ============================================================
    ' TC-002
    ' TASA DE CAMBIO CERO O FUERA DE RANGO
    '
    ' (a) Documentos en dólares en un día cuya tasa en TasaCambio es
    '     cero o nula.
    ' (b) Tasas atípicas: una tasa que difiere más de 5% de la tasa
    '     válida anterior Y de la siguiente (pico aislado, típico de
    '     un error de captura). Se informa cuántos documentos hay ese
    '     día.
    ' No se corrige ninguna tasa histórica sin confirmar su valor.
    ' ============================================================
    Private Function AuditarTc002(
        ByVal control As ControlAuditoria) As List(Of HallazgoAuditoria)

        Dim hallazgos As New List(Of HallazgoAuditoria)

        Dim dtCero As New DataTable()
        Dim dtAtipicas As New DataTable()

        Dim sqlCero As String =
        "SELECT d.Tabla, d.Tipo, d.Dia, d.Docs, d.Muestra " &
        "FROM (" & SQL_DOCUMENTOS_DOLARES & ") d " &
        "INNER JOIN TasaCambio x " &
        "ON x.FechaTasa >= CONVERT(smalldatetime, d.Dia, 112) " &
        "AND x.FechaTasa < DATEADD(day, 1, " &
        "CONVERT(smalldatetime, d.Dia, 112)) " &
        "WHERE x.MontoTasa IS NULL OR x.MontoTasa <= 0 " &
        "ORDER BY d.Dia, d.Tabla, d.Tipo"

        Dim sqlAtipicas As String =
        "SELECT o.FechaTasa, o.MontoTasa, o.Anterior, o.Siguiente, " &
        "(SELECT COUNT(*) FROM Facturas f " &
        " WHERE f.Fecha_Factura >= o.FechaTasa " &
        " AND f.Fecha_Factura < DATEADD(day, 1, o.FechaTasa)) AS Facturas, " &
        "(SELECT COUNT(*) FROM Facturas f " &
        " WHERE f.MonedaFactura = N'Dolares' " &
        " AND f.Fecha_Factura >= o.FechaTasa " &
        " AND f.Fecha_Factura < DATEADD(day, 1, o.FechaTasa)) AS FacturasDolares, " &
        "(SELECT COUNT(*) FROM Compras c " &
        " WHERE c.Fecha_Compra >= o.FechaTasa " &
        " AND c.Fecha_Compra < DATEADD(day, 1, o.FechaTasa)) AS Compras " &
        "FROM (" &
        " SELECT t.FechaTasa, t.MontoTasa, " &
        " p.MontoTasa AS Anterior, n.MontoTasa AS Siguiente " &
        " FROM TasaCambio t " &
        " OUTER APPLY (SELECT TOP 1 a.MontoTasa FROM TasaCambio a " &
        "  WHERE a.FechaTasa < t.FechaTasa AND a.MontoTasa > 0 " &
        "  ORDER BY a.FechaTasa DESC) p " &
        " OUTER APPLY (SELECT TOP 1 b.MontoTasa FROM TasaCambio b " &
        "  WHERE b.FechaTasa > t.FechaTasa AND b.MontoTasa > 0 " &
        "  ORDER BY b.FechaTasa) n " &
        " WHERE t.MontoTasa > 0 " &
        " AND p.MontoTasa IS NOT NULL AND n.MontoTasa IS NOT NULL " &
        " AND ABS(t.MontoTasa - p.MontoTasa) / p.MontoTasa > 0.05 " &
        " AND ABS(t.MontoTasa - n.MontoTasa) / n.MontoTasa > 0.05" &
        ") o ORDER BY o.FechaTasa"

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using da As New SqlDataAdapter(sqlCero, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dtCero)
            End Using

            Using da As New SqlDataAdapter(sqlAtipicas, cn)
                da.SelectCommand.CommandTimeout = 300
                da.Fill(dtAtipicas)
            End Using

        End Using

        For Each r As DataRow In dtCero.Rows

            Dim tabla As String = LeerTextoData(r("Tabla"))
            Dim tipo As String = LeerTextoData(r("Tipo"))
            Dim dia As DateTime = LeerDiaTasa(r("Dia"))
            Dim docs As Integer = Convert.ToInt32(r("Docs"))
            Dim muestra As String = LeerTextoData(r("Muestra"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "TC-002", tabla & " - " & tipo,
                muestra, dia,
                String.Empty, 0, 0, 0,
                SeveridadAuditoria.Alta,
                "Documentos en dólares con tasa de cambio en cero.",
                "La tasa de TasaCambio para el " &
                dia.ToString("dd/MM/yyyy") &
                " es cero o nula, y hay " & docs.ToString("N0") &
                " documento(s) en dólares de " & tabla &
                " (" & tipo & ")." &
                Environment.NewLine &
                "Documento de muestra: " & muestra &
                Environment.NewLine &
                "No se corrige la tasa automáticamente: hay que " &
                "confirmar la tasa que correspondía a esa fecha.",
                "REVISIÓN MANUAL"))

        Next

        For Each r As DataRow In dtAtipicas.Rows

            Dim dia As DateTime = LeerFechaData(r("FechaTasa"))
            Dim tasa As Double = ObtenerDouble(r("MontoTasa"))
            Dim anterior As Double = ObtenerDouble(r("Anterior"))
            Dim siguiente As Double = ObtenerDouble(r("Siguiente"))
            Dim facturas As Integer = Convert.ToInt32(r("Facturas"))
            Dim facturasDolares As Integer =
            Convert.ToInt32(r("FacturasDolares"))
            Dim compras As Integer = Convert.ToInt32(r("Compras"))

            hallazgos.Add(
            NuevoHallazgoData(
                control, "TC-002", "TasaCambio",
                "(tasa del día)", dia,
                String.Empty, 0, tasa, 0,
                SeveridadAuditoria.Alta,
                "Tasa de cambio atípica.",
                "La tasa del " & dia.ToString("dd/MM/yyyy") &
                " es " & tasa.ToString("N4") &
                " y difiere más de 5% de la tasa válida anterior (" &
                anterior.ToString("N4") & ") y de la siguiente (" &
                siguiente.ToString("N4") & "). Puede ser un error " &
                "de captura." &
                Environment.NewLine &
                "Ese día hay " & facturas.ToString("N0") &
                " factura(s) (" & facturasDolares.ToString("N0") &
                " en dólares) y " & compras.ToString("N0") &
                " compra(s)." &
                Environment.NewLine &
                "No se corrige automáticamente: hay que confirmar " &
                "la tasa correcta de esa fecha.",
                "REVISIÓN MANUAL"))

        Next

        Return hallazgos

    End Function

End Class
