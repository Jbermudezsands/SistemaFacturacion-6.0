Public Class TablaLotexProducto
    Private CodProductos As String
    Private NumeroLote As String
    Private CodBodega As String
    Private ExistenciaLote As Double
    Private FechaVence As Date
    Private ActivoLote As Boolean
    Private CantidadLote As Double

    Public Property Cod_Productos As String
        Get
            Return CodProductos
        End Get
        Set(value As String)
            CodProductos = value
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

    Public Property Cod_Bodega As String
        Get
            Return CodBodega
        End Get
        Set(value As String)
            CodBodega = value
        End Set
    End Property

    Public Property Existencia As Double
        Get
            Return ExistenciaLote
        End Get
        Set(value As Double)
            ExistenciaLote = value
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

    Public Property Activo As Boolean
        Get
            Return ActivoLote
        End Get
        Set(value As Boolean)
            ActivoLote = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return CantidadLote
        End Get
        Set(value As Double)
            CantidadLote = value
        End Set
    End Property
End Class
