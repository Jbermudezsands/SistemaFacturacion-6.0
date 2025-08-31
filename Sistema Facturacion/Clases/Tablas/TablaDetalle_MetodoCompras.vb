Public Class TablaDetalle_MetodoCompras
    Private NumeroCompra As String
    Private FechaCompra As Date
    Private TipoCompra As String
    Private NombrePago As String
    Private MontoCompra As Double
    Private NumeroTarjeta As String
    Private FechaVence As Date

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

    Public Property Nombre_Pago As String
        Get
            Return NombrePago
        End Get
        Set(value As String)
            NombrePago = value
        End Set
    End Property

    Public Property Monto_Compra As Double
        Get
            Return MontoCompra
        End Get
        Set(value As Double)
            MontoCompra = value
        End Set
    End Property

    Public Property Numero_Tarjeta As String
        Get
            Return NumeroTarjeta
        End Get
        Set(value As String)
            NumeroTarjeta = value
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
