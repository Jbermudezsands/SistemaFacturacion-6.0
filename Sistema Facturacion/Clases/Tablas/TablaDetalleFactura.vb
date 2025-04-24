Public Class TablaDetalleFactura
    Private idDetalleFactura As Double
    Private NumeroFactura As String
    Private FechaFactura As Date
    Private TipoFactura As String
    Private CodProducto As String
    Private DescripcionProducto As String
    Private Cantidad As Double
    Private PrecioUnitario As Double
    Private PrecioNeto As Double
    Private Importe As Double
    Private TasaCambio As Double
    Private CodTarea As String
    Private CostoUnitario As Double
    Private Descuento As String
    Private NoPresupuesto As String
    Private NumeroLote As String
    Private FechaVence As Date

    Public Property Numero_Factura As String
        Get
            Return NumeroFactura
        End Get
        Set(value As String)
            NumeroFactura = value
        End Set
    End Property

    Public Property Fecha_Factura As Date
        Get
            Return FechaFactura
        End Get
        Set(value As Date)
            FechaFactura = value
        End Set
    End Property

    Public Property Tipo_Factura As String
        Get
            Return TipoFactura
        End Get
        Set(value As String)
            TipoFactura = value
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

    Public Property Descripcion_Producto As String
        Get
            Return DescripcionProducto
        End Get
        Set(value As String)
            DescripcionProducto = value
        End Set
    End Property

    Public Property Cantidad_DetalleFactura As Double
        Get
            Return Cantidad
        End Get
        Set(value As Double)
            Cantidad = value
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

    Public Property Precio_Neto As Double
        Get
            Return PrecioNeto
        End Get
        Set(value As Double)
            PrecioNeto = value
        End Set
    End Property

    Public Property Importe_DetalleFactura As Double
        Get
            Return Importe
        End Get
        Set(value As Double)
            Importe = value
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

    Public Property Cod_Tarea As String
        Get
            Return CodTarea
        End Get
        Set(value As String)
            CodTarea = value
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

    Public Property Descuento_DetalleFactura As String
        Get
            Return Descuento
        End Get
        Set(value As String)
            Descuento = value
        End Set
    End Property

    Public Property No_Presupuesto As String
        Get
            Return NoPresupuesto
        End Get
        Set(value As String)
            NoPresupuesto = value
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

    Public Property Fecha_Vence As Date
        Get
            Return FechaVence
        End Get
        Set(value As Date)
            FechaVence = value
        End Set
    End Property

    Public Property Id_Detalle_Factura As Double
        Get
            Return idDetalleFactura
        End Get
        Set(value As Double)
            idDetalleFactura = value
        End Set
    End Property
End Class
