Public Class TablaCompras
	Private NumeroCompra As String
	Private FechaCompra As Date
	Private TipoCompra As String
	Private MonedaCompra As String
	Private CodProveedor As String
	Private CodBodega As String
	Private NombreProveedor As String
	Private ApellidoProveedor As String
	Private DireccionProveedor As String
	Private TelefonoProveedor As String
    Private FechaVencimiento As Date
    Private Observaciones As String
	Private Descuento As String
	Private FechaDescuento As String
	Private SubTotal As Double
	Private VA As Double
	Private Pagado As Double
	Private NetoPagar As Double
	Private MontoCredito As Double
    Private Contabilizado As Integer
    Private Activo As Integer
    Private Cancelado As Integer
    Private Exonerado As Integer
    Private SuReferencia As String
    Private NuestraReferencia As String
    Private TransferenciaProcesada As Integer
    Private Marca As Integer
    Private CodigoProyecto As String
	Private Referencia As String
	Private FechaHora As Date
	Private TipoProductor As String
	Private Estatus As String
    Private NumeroSolicitud As String
    Private NumeroOrden As String
    Private AplicarCtasXPagar As Integer
    Private Solcitud_Cta_Contable As Integer

    Public Property Numero_Compra As String
        Get
            Return NumeroCompra
        End Get
        Set(value As String)
            NumeroCompra = value
        End Set
    End Property

    Public Property Fecha_Compra As Date
        Get
            Return FechaCompra
        End Get
        Set(value As Date)
            FechaCompra = value
        End Set
    End Property

    Public Property Tipo_Compra As String
        Get
            Return TipoCompra
        End Get
        Set(value As String)
            TipoCompra = value
        End Set
    End Property

    Public Property Moneda_Compra As String
        Get
            Return MonedaCompra
        End Get
        Set(value As String)
            MonedaCompra = value
        End Set
    End Property

    Public Property Cod_Proveedor As String
        Get
            Return CodProveedor
        End Get
        Set(value As String)
            CodProveedor = value
        End Set
    End Property

    Public Property Cod_Bodega As String
        Get
            Return CodBodega
        End Get
        Set(value As String)
            CodBodega = value
        End Set
    End Property

    Public Property Nombre_Proveedor As String
        Get
            Return NombreProveedor
        End Get
        Set(value As String)
            NombreProveedor = value
        End Set
    End Property

    Public Property Apellido_Proveedor As String
        Get
            Return ApellidoProveedor
        End Get
        Set(value As String)
            ApellidoProveedor = value
        End Set
    End Property

    Public Property Direccion_Proveedor As String
        Get
            Return DireccionProveedor
        End Get
        Set(value As String)
            DireccionProveedor = value
        End Set
    End Property

    Public Property Telefono_Proveedor As String
        Get
            Return TelefonoProveedor
        End Get
        Set(value As String)
            TelefonoProveedor = value
        End Set
    End Property

    Public Property Fecha_Vencimiento As Date
        Get
            Return FechaVencimiento
        End Get
        Set(value As Date)
            FechaVencimiento = value
        End Set
    End Property

    Public Property Observaciones_Cómpra As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property

    Public Property Descuento_Compra As String
        Get
            Return Descuento
        End Get
        Set(value As String)
            Descuento = value
        End Set
    End Property

    Public Property Fecha_Descuento As String
        Get
            Return FechaDescuento
        End Get
        Set(value As String)
            FechaDescuento = value
        End Set
    End Property

    Public Property Sub_Total As Double
        Get
            Return SubTotal
        End Get
        Set(value As Double)
            SubTotal = value
        End Set
    End Property

    Public Property IVA As Double
        Get
            Return VA
        End Get
        Set(value As Double)
            VA = value
        End Set
    End Property

    Public Property Pagado_Compra As Double
        Get
            Return Pagado
        End Get
        Set(value As Double)
            Pagado = value
        End Set
    End Property

    Public Property Neto_Pagar As Double
        Get
            Return NetoPagar
        End Get
        Set(value As Double)
            NetoPagar = value
        End Set
    End Property

    Public Property Monto_Credito As Double
        Get
            Return MontoCredito
        End Get
        Set(value As Double)
            MontoCredito = value
        End Set
    End Property

    Public Property Contabilizado_Compra As Integer
        Get
            Return Contabilizado
        End Get
        Set(value As Integer)
            Contabilizado = value
        End Set
    End Property

    Public Property Activo_Compra As Integer
        Get
            Return Activo
        End Get
        Set(value As Integer)
            Activo = value
        End Set
    End Property

    Public Property Cancelado_Compra As Integer
        Get
            Return Cancelado
        End Get
        Set(value As Integer)
            Cancelado = value
        End Set
    End Property

    Public Property Exonerado_Compra As Integer
        Get
            Return Exonerado
        End Get
        Set(value As Integer)
            Exonerado = value
        End Set
    End Property

    Public Property Su_Referencia As String
        Get
            Return SuReferencia
        End Get
        Set(value As String)
            SuReferencia = value
        End Set
    End Property

    Public Property Nuestra_Referencia As String
        Get
            Return NuestraReferencia
        End Get
        Set(value As String)
            NuestraReferencia = value
        End Set
    End Property

    Public Property Transferencia_Procesada As Integer
        Get
            Return TransferenciaProcesada
        End Get
        Set(value As Integer)
            TransferenciaProcesada = value
        End Set
    End Property

    Public Property Marca_Compra As Integer
        Get
            Return Marca
        End Get
        Set(value As Integer)
            Marca = value
        End Set
    End Property

    Public Property Codigo_Proyecto As String
        Get
            Return CodigoProyecto
        End Get
        Set(value As String)
            CodigoProyecto = value
        End Set
    End Property

    Public Property Referencia_Compra As String
        Get
            Return Referencia
        End Get
        Set(value As String)
            Referencia = value
        End Set
    End Property

    Public Property Fecha_Hora As Date
        Get
            Return FechaHora
        End Get
        Set(value As Date)
            FechaHora = value
        End Set
    End Property

    Public Property Tipo_Productor As String
        Get
            Return TipoProductor
        End Get
        Set(value As String)
            TipoProductor = value
        End Set
    End Property

    Public Property Estatus_Compra As String
        Get
            Return Estatus
        End Get
        Set(value As String)
            Estatus = value
        End Set
    End Property

    Public Property Numero_Solicitud As String
        Get
            Return NumeroSolicitud
        End Get
        Set(value As String)
            NumeroSolicitud = value
        End Set
    End Property

    Public Property Numero_Orden As String
        Get
            Return NumeroOrden
        End Get
        Set(value As String)
            NumeroOrden = value
        End Set
    End Property

    Public Property Aplicar_CtasXPagar As Integer
        Get
            Return AplicarCtasXPagar
        End Get
        Set(value As Integer)
            AplicarCtasXPagar = value
        End Set
    End Property

    Public Property Solcitud_CtaContable As Integer
        Get
            Return Solcitud_Cta_Contable
        End Get
        Set(value As Integer)
            Solcitud_Cta_Contable = value
        End Set
    End Property
End Class
