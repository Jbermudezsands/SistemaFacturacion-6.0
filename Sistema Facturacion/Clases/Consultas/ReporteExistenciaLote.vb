Public Class ReporteExistenciaLote
    Private NumeroLote As String
    Private CodigoProducto As String
    Private DescripcionProducto As String
    Private CodigoBodega As String
    Private CodigoLinea As String
    Private ExistenciaLote As String
    Private FechaVence As Date
    Private TipoReporte As String
    Private Agrupado As String
    Private FechaReporte As Date



    Public Property Numero_Lote As String
        Get
            Return NumeroLote
        End Get
        Set(value As String)
            NumeroLote = value
        End Set
    End Property

    Public Property Codigo_Producto As String
        Get
            Return CodigoProducto
        End Get
        Set(value As String)
            CodigoProducto = value
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

    Public Property Codigo_Bodega As String
        Get
            Return CodigoBodega
        End Get
        Set(value As String)
            CodigoBodega = value
        End Set
    End Property

    Public Property Codigo_Linea As String
        Get
            Return CodigoLinea
        End Get
        Set(value As String)
            CodigoLinea = value
        End Set
    End Property

    Public Property Existencia_Lote As String
        Get
            Return ExistenciaLote
        End Get
        Set(value As String)
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

    Public Property Tipo_Reporte As String
        Get
            Return TipoReporte
        End Get
        Set(value As String)
            TipoReporte = value
        End Set
    End Property

    Public Property Agrupado_Reporte As String
        Get
            Return Agrupado
        End Get
        Set(value As String)
            Agrupado = value
        End Set
    End Property

    Public Property Fecha_Reporte As Date
        Get
            Return FechaReporte
        End Get
        Set(value As Date)
            FechaReporte = value
        End Set
    End Property
End Class
