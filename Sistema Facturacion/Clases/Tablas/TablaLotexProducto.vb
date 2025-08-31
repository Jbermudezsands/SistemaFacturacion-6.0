Public Class TablaLotexProducto
    Private Cod_Productos As String
    Private Numero_Lote As String
    Private Cod_Bodega As String
    Private Existencia As Double
    Private Fecha_Vence As Date
    Private Activo As Boolean

    Public Property Cod_Productos_LoteProducto As String
        Get
            Return Cod_Productos
        End Get
        Set(value As String)
            Cod_Productos = value
        End Set
    End Property

    Public Property Numero_Lote_Producto As String
        Get
            Return Numero_Lote
        End Get
        Set(value As String)
            Numero_Lote = value
        End Set
    End Property

    Public Property Cod_Bodega_LoteProducto As String
        Get
            Return Cod_Bodega
        End Get
        Set(value As String)
            Cod_Bodega = value
        End Set
    End Property

    Public Property Existencia_LoteProducto As Double
        Get
            Return Existencia
        End Get
        Set(value As Double)
            Existencia = value
        End Set
    End Property

    Public Property Fecha_Vence_LoteProducto As Date
        Get
            Return Fecha_Vence
        End Get
        Set(value As Date)
            Fecha_Vence = value
        End Set
    End Property

    Public Property Activo_LoteProducto As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property
End Class
