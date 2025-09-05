Public Class TablaDetalleCompras
    Private id_Detalle_Compra As Double
    Private NumeroCompra As String
	Private FechaCompra As Date
	Private TipoCompra As String
	Private CodProducto As String
    Private CantidadProducto As Double
    Private PrecioUnitario As Double
    Private DescuentoCompra As Double
	Private PrecioNeto As Double
    Private ImporteCompra As Double
    Private TasaCambio As Double
	Private idDetalleTransferencia As Double
	Private CostoUnitario As Double
	Private NumeroLote As String
	Private FechaVence As String
    Private DescripcionProducto As String
    Private CodigoBodega As String


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

    Public Property Cod_Producto As String
        Get
            Return CodProducto
        End Get
        Set(value As String)
            CodProducto = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return CantidadProducto
        End Get
        Set(value As Double)
            CantidadProducto = value
        End Set
    End Property

    Public Property Precio_Unitario As Double
        Get
            Return PrecioUnitario
        End Get
        Set(value As Double)
            PrecioUnitario = value
        End Set
    End Property

    Public Property Descuento As Double
        Get
            Return DescuentoCompra
        End Get
        Set(value As Double)
            DescuentoCompra = value
        End Set
    End Property

    Public Property Precio_Neto As Double
        Get
            Return PrecioNeto
        End Get
        Set(value As Double)
            PrecioNeto = value
        End Set
    End Property

    Public Property Importe As Double
        Get
            Return ImporteCompra
        End Get
        Set(value As Double)
            ImporteCompra = value
        End Set
    End Property

    Public Property Tasa_Cambio As Double
        Get
            Return TasaCambio
        End Get
        Set(value As Double)
            TasaCambio = value
        End Set
    End Property

    Public Property Id_DetalleTransferencia As Double
        Get
            Return idDetalleTransferencia
        End Get
        Set(value As Double)
            idDetalleTransferencia = value
        End Set
    End Property

    Public Property Costo_Unitario As Double
        Get
            Return CostoUnitario
        End Get
        Set(value As Double)
            CostoUnitario = value
        End Set
    End Property

    Public Property Numero_Lote As String
        Get
            Return NumeroLote
        End Get
        Set(value As String)
            NumeroLote = value
        End Set
    End Property

    Public Property Fecha_Vence As String
        Get
            Return FechaVence
        End Get
        Set(value As String)
            FechaVence = value
        End Set
    End Property

    Public Property Descripcion_Producto As String
        Get
            Return DescripcionProducto
        End Get
        Set(value As String)
            DescripcionProducto = value
        End Set
    End Property

    Public Property IdDetalleCompra As Double
        Get
            Return id_Detalle_Compra
        End Get
        Set(value As Double)
            id_Detalle_Compra = value
        End Set
    End Property

    Public Property Cod_Bodega As String
        Get
            Return CodigoBodega
        End Get
        Set(value As String)
            CodigoBodega = value
        End Set
    End Property
End Class
