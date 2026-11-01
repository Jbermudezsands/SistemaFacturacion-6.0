Option Strict On
Option Explicit On
Option Infer On

Imports System.Data
Imports System.Globalization

'=====================================================================================================
'  ENSAMBLE - PROCESO CONTABLE
'  Procesar: da salida a los componentes (Salida Bodega) y da entrada al producto terminado (Compra
'            "Mercancia Recibida") en la bodega destino.
'  Deshacer: el camino inverso, entrada de componentes y salida del producto terminado.
'
'  Conserva la misma secuencia de movimientos y el mismo cálculo de costos que tenía el formulario;
'  se apoya en las rutinas globales de kardex, facturas y compras del sistema.
'=====================================================================================================
Public Class EnsambleProcesoServicio

    Private Const MONEDA As String = "Cordobas"
    Private Const TIPO_SALIDA As String = "Salida Bodega"
    Private Const TIPO_ENTRADA As String = "Mercancia Recibida"

    Private ReadOnly _repositorio As EnsambleRepositorio

    'Cuentas del sistema usadas para los ajustes de inventario
    Private Class CuentasInventario
        Public CodCliente As String
        Public CodProveedor As String
    End Class

    Public Sub New(ByVal conexion As String)
        _repositorio = New EnsambleRepositorio(conexion)
    End Sub

#Region "Procesar"

    ''' <summary>
    ''' Saca de la bodega origen los componentes y recibe el producto terminado en la bodega destino.
    ''' <paramref name="rendimientoGeneral"/> es el rendimiento por unidad del producto elegido.
    ''' </summary>
    Public Sub Procesar(ByVal enc As EnsambleEncabezado, ByVal rendimientoGeneral As Double)
        Dim cuentas As CuentasInventario = ObtenerCuentas()
        Dim detalle As DataTable = ObtenerDetalleOrError(enc)

        VerificarCostosYExistencias(enc, detalle)

        Dim fechaTexto As String = enc.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim numeroDoc As String = enc.Numero.ToString()

        '--- Salida de bodega de los componentes
        Dim numeroFactura As String = Format(BuscaConsecutivo("SalidaBodega"), "0000#")
        GrabaEncabezadoFacturas(numeroFactura, fechaTexto, TIPO_SALIDA, cuentas.CodCliente, enc.BodegaOrigen, NombreCliente, NombreCliente, _
                                fechaTexto, 0, 0, 0, 0, MONEDA, "Procesado por Ensamble " & numeroDoc)
        _repositorio.DesactivarSalidaBodega(numeroFactura, enc.Fecha)

        Dim totalImporte As Double = 0
        Dim precio As Double = 0, importe As Double = 0, cantidad As Double = 0

        For Each fila As DataRow In detalle.Rows
            Dim codProducto As String = Convert.ToString(fila("CodProducto"))
            Dim cantidadDetalle As Double = Numero(fila("Cantidad_Ensamble"))
            Dim producto As DataRow = _repositorio.ObtenerProducto(codProducto)

            If producto IsNot Nothing Then
                Select Case Convert.ToString(producto("Tipo_Producto"))
                    Case "Productos", "Insumos"
                        StringMoneda = ""
                        cantidad = cantidadDetalle
                        precio = CalcularCosto(codProducto, cantidad, enc.Fecha)
                        importe = cantidad * precio
                        totalImporte += importe
                    Case "Servicio"
                        AplicarServicio(producto, cantidadDetalle, totalImporte, cantidad, precio, importe)
                End Select
            End If

            GrabaDetalleFacturaSalida(numeroFactura, codProducto, Convert.ToString(fila("Descripcion_Producto")), precio, 0, precio, importe, _
                                      cantidad, MONEDA, enc.Fecha, TIPO_SALIDA, precio)
            ActualizaExistencia(codProducto)
        Next

        ActulizacionFacturaEnsamble(numeroFactura, TIPO_SALIDA, enc.Fecha, True)

        '--- Entrada del producto terminado: el costo es el total de lo que salió
        totalImporte = _repositorio.TotalSalidaBodega(numeroFactura, enc.Fecha)

        cantidad = enc.Cantidad
        precio = totalImporte / cantidad
        importe = cantidad * precio

        Dim numeroCompra As String = Format(BuscaConsecutivo("Compra"), "0000#")
        GrabaEncabezadoCompras(numeroCompra, fechaTexto, TIPO_ENTRADA, cuentas.CodProveedor, enc.BodegaDestino, NombreCliente, NombreCliente, _
                               fechaTexto, 0, 0, 0, 0, MONEDA, "Procesado por Ensamble " & numeroDoc, "", False)
        _repositorio.DesactivarCompra(numeroCompra, enc.Fecha)

        'Ajuste de la entrada según el rendimiento estimado del producto
        If enc.Rendimiento <> 0 AndAlso rendimientoGeneral <> 0 Then
            cantidad = cantidad * rendimientoGeneral
            precio = precio / cantidad
        End If

        GrabaDetalleCompraLiquidacion(numeroCompra, enc.CodProducto, precio, 0, precio, importe, cantidad, MONEDA, enc.Fecha, "0000", #1/1/1900#)
        ActualizaExistencia(enc.CodProducto)
        ActulizacionCompraEnsamble(numeroCompra, TIPO_ENTRADA, enc.Fecha, True)

        _repositorio.Inactivar(enc.Numero, enc.Fecha, enc.Tipo)
    End Sub

    ''' <summary>Cada componente que no es servicio debe tener costo y existencia suficiente en la bodega origen.</summary>
    Private Sub VerificarCostosYExistencias(ByVal enc As EnsambleEncabezado, ByVal detalle As DataTable)
        For Each fila As DataRow In detalle.Rows
            Dim codProducto As String = Convert.ToString(fila("CodProducto"))
            Dim producto As DataRow = _repositorio.ObtenerProducto(codProducto)
            If producto IsNot Nothing AndAlso EsServicio(producto) Then Continue For

            StringMoneda = ""
            Dim cantidad As Double = Numero(fila("Cantidad_Ensamble"))
            Dim precio As Double = CalcularCosto(codProducto, cantidad, enc.Fecha)

            If precio <= 0 Then
                Throw New EnsambleNegocioException("No existe costo para el producto " & codProducto)
            End If

            Dim existencia As Double = BuscaExistenciaBodega(codProducto, enc.BodegaOrigen, Now)
            If cantidad > existencia Then
                Throw New EnsambleNegocioException("No existe inventario para este ensamble: " & codProducto)
            End If
        Next
    End Sub

#End Region

#Region "Deshacer"

    ''' <summary>
    ''' Recibe los componentes en la bodega origen y da salida al producto terminado.
    ''' </summary>
    Public Sub Deshacer(ByVal enc As EnsambleEncabezado)
        Dim cuentas As CuentasInventario = ObtenerCuentas()
        Dim detalle As DataTable = ObtenerDetalleOrError(enc)

        Dim fechaTexto As String = enc.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim numeroDoc As String = enc.Numero.ToString()

        '--- Entrada de los componentes
        Dim numeroCompra As String = Format(BuscaConsecutivo("Compra"), "0000#")
        GrabaEncabezadoCompras(numeroCompra, fechaTexto, TIPO_ENTRADA, cuentas.CodProveedor, enc.BodegaOrigen, NombreCliente, NombreCliente, _
                               fechaTexto, 0, 0, 0, 0, MONEDA, "Procesado por DesEnsamble " & numeroDoc, "", False)

        Dim totalImporte As Double = 0
        Dim precio As Double = 0, importe As Double = 0, cantidad As Double = 0

        For Each fila As DataRow In detalle.Rows
            Dim codProducto As String = Convert.ToString(fila("CodProducto"))
            Dim cantidadDetalle As Double = Numero(fila("Cantidad_Ensamble"))
            Dim producto As DataRow = _repositorio.ObtenerProducto(codProducto)

            If producto Is Nothing OrElse Not EsServicio(producto) Then
                cantidad = cantidadDetalle
                precio = CalcularCosto(codProducto, cantidad, enc.Fecha)
                importe = cantidad * precio
                totalImporte += importe
            Else
                AplicarServicio(producto, cantidadDetalle, totalImporte, cantidad, precio, importe)
            End If

            GrabaDetalleCompraLiquidacion(numeroCompra, codProducto, precio, 0, precio, importe, cantidad, MONEDA, enc.Fecha, "0000", #1/1/1900#)
            ActualizaExistencia(codProducto)
        Next

        ActulizacionCompra(numeroCompra, TIPO_ENTRADA, enc.Fecha, True)

        '--- Salida del producto terminado: el costo es el total de lo que entró
        totalImporte = _repositorio.TotalCompra(numeroCompra, enc.Fecha)

        precio = totalImporte / enc.Cantidad
        importe = enc.Cantidad * precio

        Dim numeroFactura As String = Format(BuscaConsecutivo("SalidaBodega"), "0000#")
        GrabaEncabezadoFacturas(numeroFactura, fechaTexto, TIPO_SALIDA, cuentas.CodCliente, enc.BodegaOrigen, NombreCliente, NombreCliente, _
                                fechaTexto, 0, 0, 0, 0, MONEDA, "Procesado por DesEnsamble " & numeroDoc)

        GrabaDetalleFacturaSalida(numeroFactura, enc.CodProducto, Convert.ToString(detalle.Rows(0)("Descripcion_Producto")), precio, 0, precio, importe, _
                                  enc.Cantidad, MONEDA, enc.Fecha, TIPO_SALIDA, precio)
        ActualizaExistencia(enc.CodProducto)
        ActulizacionFactura(numeroFactura, TIPO_SALIDA, enc.Fecha, True)

        _repositorio.Inactivar(enc.Numero, enc.Fecha, enc.Tipo)
    End Sub

#End Region

#Region "Cálculo de costos"

    ''' <summary>
    ''' Costo promedio en córdobas del kardex a la fecha. Si es cero y se está descargando,
    ''' significa facturación en negativo: se toma el último costo facturado.
    ''' </summary>
    Private Function CalcularCosto(ByVal codProducto As String, ByVal cantidad As Double, ByVal fecha As Date) As Double
        Dim costo As Double = CostoPromedioKardex(codProducto, fecha.Date).Costo_Cordoba

        If cantidad <> 0 AndAlso costo = 0 Then
            Dim ultimo As Double? = _repositorio.UltimoCostoFactura(codProducto, fecha.Date)
            If ultimo.HasValue Then costo = ultimo.Value
        End If
        Return costo
    End Function

    ''' <summary>
    ''' Calcula cantidad, precio e importe de un servicio según su unidad de medida
    ''' (importe fijo, por unidad/fracción o porcentaje del subtotal acumulado).
    ''' </summary>
    Private Shared Sub AplicarServicio(ByVal producto As DataRow, ByVal cantidadDetalle As Double, ByRef totalImporte As Double, _
                                       ByRef cantidad As Double, ByRef precio As Double, ByRef importe As Double)
        Dim precioVenta As Double = Numero(producto("Precio_Venta"))

        Select Case Convert.ToString(producto("Unidad_Medida"))
            Case "ImporteFijo"
                cantidad = 1
                precio = precioVenta
            Case "Unidades/Fracciones"
                cantidad = cantidadDetalle
                precio = precioVenta
            Case "SubTotal"
                cantidad = 1
                precio = totalImporte * (precioVenta / 100)
            Case Else
                Return
        End Select

        importe = cantidad * precio
        totalImporte += importe
    End Sub

    Private Shared Function EsServicio(ByVal producto As DataRow) As Boolean
        Return Convert.ToString(producto("Tipo_Producto")) = "Servicio"
    End Function

#End Region

#Region "Utilidades"

    Private Function ObtenerCuentas() As CuentasInventario
        Dim cliente As DataRow = _repositorio.ObtenerClienteInventario()
        If cliente Is Nothing Then
            Throw New EnsambleNegocioException("Seleccione una cuenta de cliente para ajustes de inventario.")
        End If

        Dim proveedor As DataRow = _repositorio.ObtenerProveedorInventario()
        If proveedor Is Nothing Then
            Throw New EnsambleNegocioException("Seleccione una cuenta de proveedor para ajustes de inventario.")
        End If

        NombreCliente = Convert.ToString(cliente("Nombre_Cliente"))

        Dim cuentas As New CuentasInventario
        cuentas.CodCliente = Convert.ToString(cliente("Cod_Cliente"))
        cuentas.CodProveedor = Convert.ToString(proveedor("Cod_Proveedor"))
        Return cuentas
    End Function

    Private Function ObtenerDetalleOrError(ByVal enc As EnsambleEncabezado) As DataTable
        Dim detalle As DataTable = _repositorio.ObtenerDetalle(enc.Numero, enc.Fecha, enc.Tipo)
        If detalle.Rows.Count = 0 Then
            Throw New EnsambleNegocioException("El ensamble no tiene componentes para procesar.")
        End If
        Return detalle
    End Function

    Private Shared Function Numero(ByVal valor As Object) As Double
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0
        Return Convert.ToDouble(valor)
    End Function

#End Region

End Class
