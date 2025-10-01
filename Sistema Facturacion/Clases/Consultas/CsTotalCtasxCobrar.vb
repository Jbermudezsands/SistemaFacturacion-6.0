Public Class CsTotalCtasxCobrar
    Private Total_Factura As Double
    Private Total_Cargos As Double
    Private Total_Abonos As Double
    Private Total_Mora As Double
    Private Total_MontoNotaDB As Double
    Private Total_MontoNotaCR As Double

    Public Property TotalFactura As Double
        Get
            Return Total_Factura
        End Get
        Set(value As Double)
            Total_Factura = value
        End Set
    End Property

    Public Property TotalCargos As Double
        Get
            Return Total_Cargos
        End Get
        Set(value As Double)
            Total_Cargos = value
        End Set
    End Property

    Public Property TotalAbonos As Double
        Get
            Return Total_Abonos
        End Get
        Set(value As Double)
            Total_Abonos = value
        End Set
    End Property

    Public Property TotalMora As Double
        Get
            Return Total_Mora
        End Get
        Set(value As Double)
            Total_Mora = value
        End Set
    End Property

    Public Property TotalMontoNotaDB As Double
        Get
            Return Total_MontoNotaDB
        End Get
        Set(value As Double)
            Total_MontoNotaDB = value
        End Set
    End Property

    Public Property TotalMontoNotaCR As Double
        Get
            Return Total_MontoNotaCR
        End Get
        Set(value As Double)
            Total_MontoNotaCR = value
        End Set
    End Property
End Class
