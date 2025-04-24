Public Class TablaDetalle_MetodoFacturas
    Private NumeroFactura As String
    Private FechaFactura As Date
    Private TipoFactura As String
    Private NombrePago As String
    Private Monto As Double
    Private NumeroTarjeta As String
    Private FechaVence As Date
    Private Arqueado As Integer

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

    Public Property Nombre_Pago As String
        Get
            Return NombrePago
        End Get
        Set(value As String)
            NombrePago = value
        End Set
    End Property

    Public Property Monto_MetodoFactura As Double
        Get
            Return Monto
        End Get
        Set(value As Double)
            Monto = value
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

    Public Property Arqueado_MetodoFactura As Integer
        Get
            Return Arqueado
        End Get
        Set(value As Integer)
            Arqueado = value
        End Set
    End Property


End Class
