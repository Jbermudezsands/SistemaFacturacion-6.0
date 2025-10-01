Public Class CsResultadoCtasxCobrar
    Private DsTotal_Ventas As DataSet
    Private ClaseTotal_Ventas As CsTotalCtasxCobrar
    Private Args As CsFillCtasxCobrar

    Public Property DsTotalVentas As DataSet
        Get
            Return DsTotal_Ventas
        End Get
        Set(value As DataSet)
            DsTotal_Ventas = value
        End Set
    End Property

    Public Property ClaseTotalVentas As CsTotalCtasxCobrar
        Get
            Return ClaseTotal_Ventas
        End Get
        Set(value As CsTotalCtasxCobrar)
            ClaseTotal_Ventas = value
        End Set
    End Property
End Class
