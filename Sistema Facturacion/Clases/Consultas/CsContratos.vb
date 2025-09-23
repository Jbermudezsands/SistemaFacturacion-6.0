Public Class CsContratos
    Private CodigoProveedor As String
    Private NumeroContrato As String
    Private CodProductos As String
    Private DescripcionProductos As String
    Private TipoContrato As String

    Public Property Codigo_Proveedor As String
        Get
            Return CodigoProveedor
        End Get
        Set(value As String)
            CodigoProveedor = value
        End Set
    End Property

    Public Property Numero_Contrato As String
        Get
            Return NumeroContrato
        End Get
        Set(value As String)
            NumeroContrato = value
        End Set
    End Property

    Public Property Cod_Productos As String
        Get
            Return CodProductos
        End Get
        Set(value As String)
            CodProductos = value
        End Set
    End Property

    Public Property Descripcion_Productos As String
        Get
            Return DescripcionProductos
        End Get
        Set(value As String)
            DescripcionProductos = value
        End Set
    End Property

    Public Property Tipo_Contrato As String
        Get
            Return TipoContrato
        End Get
        Set(value As String)
            TipoContrato = value
        End Set
    End Property
End Class
