Public Class ArgsReporteExistenciaLote
    Private Fecha_Ini As Date
    Private Fecha_Fin As Date
    Private Codigo_Bodega1 As String
    Private Codigo_Bodega2 As String
    Private Agrupado_Reporte As String
    Private Tipo_Reporte As String
    Private CodProducto_Ini As String
    Private CodProducto_Fin As String
    Private CodLInea_Ini As String
    Private CodLinea_Fin As String

    Public Property FechaIni As Date
        Get
            Return Fecha_Ini
        End Get
        Set(value As Date)
            Fecha_Ini = value
        End Set
    End Property

    Public Property FechaFin As Date
        Get
            Return Fecha_Fin
        End Get
        Set(value As Date)
            Fecha_Fin = value
        End Set
    End Property

    Public Property CodBodegaIni As String
        Get
            Return Codigo_Bodega1
        End Get
        Set(value As String)
            Codigo_Bodega1 = value
        End Set
    End Property

    Public Property CodBodegaFin As String
        Get
            Return Codigo_Bodega2
        End Get
        Set(value As String)
            Codigo_Bodega2 = value
        End Set
    End Property

    Public Property Agrupado As String
        Get
            Return Agrupado_Reporte
        End Get
        Set(value As String)
            Agrupado_Reporte = value
        End Set
    End Property

    Public Property TipoReporte As String
        Get
            Return Tipo_Reporte
        End Get
        Set(value As String)
            Tipo_Reporte = value
        End Set
    End Property

    Public Property CodProductoIni As String
        Get
            Return CodProducto_Ini
        End Get
        Set(value As String)
            CodProducto_Ini = value
        End Set
    End Property

    Public Property CodProductoFin As String
        Get
            Return CodProducto_Fin
        End Get
        Set(value As String)
            CodProducto_Fin = value
        End Set
    End Property

    Public Property CodLIneaIni As String
        Get
            Return CodLInea_Ini
        End Get
        Set(value As String)
            CodLInea_Ini = value
        End Set
    End Property

    Public Property CodLineaFin As String
        Get
            Return CodLinea_Fin
        End Get
        Set(value As String)
            CodLinea_Fin = value
        End Set
    End Property
End Class
