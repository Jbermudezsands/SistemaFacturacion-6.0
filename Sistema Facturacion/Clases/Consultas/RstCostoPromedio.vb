Public Class RstCostoPromedio
    Private CodigoProducto As String
    Private FechaCompras As Date
    Private CostoCordoba As Double
    Private CostoDolar As Double

    Public Property Codigo_Producto As String
        Get
            Return CodigoProducto
        End Get
        Set(value As String)
            CodigoProducto = value
        End Set
    End Property

    Public Property Fecha_Compras As Date
        Get
            Return FechaCompras
        End Get
        Set(value As Date)
            FechaCompras = value
        End Set
    End Property

    Public Property Costo_Cordoba As Double
        Get
            Return CostoCordoba
        End Get
        Set(value As Double)
            CostoCordoba = value
        End Set
    End Property

    Public Property Costo_Dolar As Double
        Get
            Return CostoDolar
        End Get
        Set(value As Double)
            CostoDolar = value
        End Set
    End Property
End Class
