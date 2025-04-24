Public Class Lote
    Private CodigoProducto As String
    Private CodigoBodega As String
    Private NumeroLote As String
    Private Existencia As Double
    Private NombreLote As String
    Private FechaVence As Date

    Public Property Codigo_Producto As String
        Get
            Return CodigoProducto
        End Get
        Set(value As String)
            CodigoProducto = value
        End Set
    End Property

    Public Property Codigo_Bodega As String
        Get
            Return CodigoBodega
        End Get
        Set(value As String)
            CodigoBodega = value
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

    Public Property Existencia_Lote As Double
        Get
            Return Existencia
        End Get
        Set(value As Double)
            Existencia = value
        End Set
    End Property

    Public Property Nombre_Lote As String
        Get
            Return NombreLote
        End Get
        Set(value As String)
            NombreLote = value
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
End Class
