Public Class TablaProductos
    Private CodProductos As String
    Private TipoProducto As String
    Private DescripcionProducto As String
    Private Ubicacion_Producto As String
    Private CodLinea As String
    Private CodCuentaInventario As String
    Private CodCuentaCosto As String
    Private CodCuentaVentas As String
    Private CodCuentaGastoAjuste As String
    Private CodCuentaIngresoAjuste As String
    Private UnidadMedida As String
    Private PrecioVenta As Double
    Private PrecioLista As Double
    Private DescuentoProducto As Double
    Private ExistenciaNegativa As String
    Private CodIva As String
    Private ActivoProducto As String
    Private CostoPromedio As Double
    Private CostoPromedio_Dolar As Double
    Private UltimoPrecioVenta As Double
    Private UltimoPrecioCompra As Double
    Private ExistenciaDinero As Double
    Private ExistenciaUnidades As Double
    Private ExistenciaDineroDolar As Double
    Private Minimo_Producto As Double
    Private Reorden_Producto As Double
    Private Nota_Producto As String
    Private CodComponente_Producto As Double
    Private Cod_Rubro_Producto As String
    Private PorcentajeAumento As Double
    Private Rendimiento_Producto As Double
    Private Merma_Producto As Double
    Private Desperdicio_Producto As Double
    Private Foto_Producto As String

    Public Property Cod_Productos As String
        Get
            Return CodProductos
        End Get
        Set(value As String)
            CodProductos = value
        End Set
    End Property

    Public Property Tipo_Producto As String
        Get
            Return TipoProducto
        End Get
        Set(value As String)
            TipoProducto = value
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

    Public Property Ubicacion As String
        Get
            Return Ubicacion_Producto
        End Get
        Set(value As String)
            Ubicacion_Producto = value
        End Set
    End Property

    Public Property Cod_Linea As String
        Get
            Return CodLinea
        End Get
        Set(value As String)
            CodLinea = value
        End Set
    End Property

    Public Property Cod_Cuenta_Inventario As String
        Get
            Return CodCuentaInventario
        End Get
        Set(value As String)
            CodCuentaInventario = value
        End Set
    End Property

    Public Property Cod_Cuenta_Costo As String
        Get
            Return CodCuentaCosto
        End Get
        Set(value As String)
            CodCuentaCosto = value
        End Set
    End Property

    Public Property Cod_Cuenta_Ventas As String
        Get
            Return CodCuentaVentas
        End Get
        Set(value As String)
            CodCuentaVentas = value
        End Set
    End Property

    Public Property Cod_Cuenta_GastoAjuste As String
        Get
            Return CodCuentaGastoAjuste
        End Get
        Set(value As String)
            CodCuentaGastoAjuste = value
        End Set
    End Property

    Public Property Cod_Cuenta_IngresoAjuste As String
        Get
            Return CodCuentaIngresoAjuste
        End Get
        Set(value As String)
            CodCuentaIngresoAjuste = value
        End Set
    End Property

    Public Property Unidad_Medida As String
        Get
            Return UnidadMedida
        End Get
        Set(value As String)
            UnidadMedida = value
        End Set
    End Property

    Public Property Precio_Venta As Double
        Get
            Return PrecioVenta
        End Get
        Set(value As Double)
            PrecioVenta = value
        End Set
    End Property

    Public Property Precio_Lista As Double
        Get
            Return PrecioLista
        End Get
        Set(value As Double)
            PrecioLista = value
        End Set
    End Property

    Public Property Descuento As Double
        Get
            Return DescuentoProducto
        End Get
        Set(value As Double)
            DescuentoProducto = value
        End Set
    End Property

    Public Property Existencia_Negativa As String
        Get
            Return ExistenciaNegativa
        End Get
        Set(value As String)
            ExistenciaNegativa = value
        End Set
    End Property

    Public Property Cod_Iva As String
        Get
            Return CodIva
        End Get
        Set(value As String)
            CodIva = value
        End Set
    End Property

    Public Property Activo As String
        Get
            Return ActivoProducto
        End Get
        Set(value As String)
            ActivoProducto = value
        End Set
    End Property

    Public Property Costo_Promedio As Double
        Get
            Return CostoPromedio
        End Get
        Set(value As Double)
            CostoPromedio = value
        End Set
    End Property

    Public Property Costo_Promedio_Dolar As Double
        Get
            Return CostoPromedio_Dolar
        End Get
        Set(value As Double)
            CostoPromedio_Dolar = value
        End Set
    End Property

    Public Property Ultimo_Precio_Venta As Double
        Get
            Return UltimoPrecioVenta
        End Get
        Set(value As Double)
            UltimoPrecioVenta = value
        End Set
    End Property

    Public Property Ultimo_Precio_Compra As Double
        Get
            Return UltimoPrecioCompra
        End Get
        Set(value As Double)
            UltimoPrecioCompra = value
        End Set
    End Property

    Public Property Existencia_Dinero As Double
        Get
            Return ExistenciaDinero
        End Get
        Set(value As Double)
            ExistenciaDinero = value
        End Set
    End Property

    Public Property Existencia_Unidades As Double
        Get
            Return ExistenciaUnidades
        End Get
        Set(value As Double)
            ExistenciaUnidades = value
        End Set
    End Property

    Public Property Existencia_DineroDolar As Double
        Get
            Return ExistenciaDineroDolar
        End Get
        Set(value As Double)
            ExistenciaDineroDolar = value
        End Set
    End Property

    Public Property Minimo As Double
        Get
            Return Minimo_Producto
        End Get
        Set(value As Double)
            Minimo_Producto = value
        End Set
    End Property

    Public Property Reorden As Double
        Get
            Return Reorden_Producto
        End Get
        Set(value As Double)
            Reorden_Producto = value
        End Set
    End Property

    Public Property Nota As String
        Get
            Return Nota_Producto
        End Get
        Set(value As String)
            Nota_Producto = value
        End Set
    End Property

    Public Property CodComponente As Double
        Get
            Return CodComponente_Producto
        End Get
        Set(value As Double)
            CodComponente_Producto = value
        End Set
    End Property

    Public Property Cod_Rubro As String
        Get
            Return Cod_Rubro_Producto
        End Get
        Set(value As String)
            Cod_Rubro_Producto = value
        End Set
    End Property

    Public Property Porcentaje_Aumento As Double
        Get
            Return PorcentajeAumento
        End Get
        Set(value As Double)
            PorcentajeAumento = value
        End Set
    End Property

    Public Property Rendimiento As Double
        Get
            Return Rendimiento_Producto
        End Get
        Set(value As Double)
            Rendimiento_Producto = value
        End Set
    End Property

    Public Property Merma As Double
        Get
            Return Merma_Producto
        End Get
        Set(value As Double)
            Merma_Producto = value
        End Set
    End Property

    Public Property Desperdicio As Double
        Get
            Return Desperdicio_Producto
        End Get
        Set(value As Double)
            Desperdicio_Producto = value
        End Set
    End Property

    Public Property Foto As String
        Get
            Return Foto_Producto
        End Get
        Set(value As String)
            Foto_Producto = value
        End Set
    End Property
End Class
