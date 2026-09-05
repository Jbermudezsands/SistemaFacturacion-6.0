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

                RaiseEvent Progreso(
                15,
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

            RaiseEvent Progreso(
            25,
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

            RaiseEvent Progreso(
            35,
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

            RaiseEvent Progreso(
    60,
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

            RaiseEvent Progreso(
    75,
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

            RaiseEvent Progreso(
    85,
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

            RaiseEvent Progreso(
    95,
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

            resultado.CostosConfiables =
            (resultado.TotalHallazgos = 0)

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
                        " ISNULL(TRY_CONVERT(float, Descuento), 0), " &
                        " Precio_Neto, " &
                        " Importe, " &
                        " TasaCambio, " &
                        " id_Detalle_Factura, " &
                        " Costo_Unitario, " &
                        " ISNULL(Numero_Lote, N'SINLOTE'), " &
                        " ISNULL(Fecha_Vence, CONVERT(smalldatetime, '1900-01-01')), " &
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
                95,
                "COST-004 finalizado. No se encontraron " &
                "transferencias enviadas con Precio_Unitario cero.")

            Return hallazgos

        End If


        RaiseEvent Progreso(
            85,
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
                            85 +
                            CInt(
                                (registrosProcesados * 10.0) /
                                totalRegistros)


                        If porcentaje > 95 Then

                            porcentaje =
                                95

                        End If


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
            95,
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
                95,
                "COST-005 finalizado. No se encontraron " &
                "transferencias recibidas con Precio_Unitario cero.")

            Return hallazgos

        End If


        RaiseEvent Progreso(
            85,
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
                            85 +
                            CInt(
                                (registrosProcesados * 10.0) /
                                totalRegistros)

                        If porcentaje > 95 Then

                            porcentaje = 95

                        End If

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
            95,
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
        sqlRecibidas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

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
        sqlRecibidas &= "WHERE Tipo_Compra = N'Transferencia Recibida'"
        sqlEnviadas &= "AND ISNULL(Descripcion_Producto, '') NOT LIKE '%CANCELADO%' "

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

End Class
