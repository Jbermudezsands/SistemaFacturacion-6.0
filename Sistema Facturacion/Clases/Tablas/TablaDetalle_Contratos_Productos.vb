Public Class TablaDetalle_Contratos_Productos

	Private NumeroContrato As String
	Private TipoContrato As String
    Private CodProductos As String
    Private DescripcionProducto As String
    Private Cantidad_Contrato As Double
    Private PrecioUnitario As Double

    Public Property Numero_Contrato As String
        Get
            Return NumeroContrato
        End Get
        Set(value As String)
            NumeroContrato = value
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

    Public Property Cod_Productos As String
        Get
            Return CodProductos
        End Get
        Set(value As String)
            CodProductos = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return Cantidad_Contrato
        End Get
        Set(value As Double)
            Cantidad_Contrato = value
        End Set
    End Property

    Public Property Precio_Unitario As Double
        Get
            Return PrecioUnitario
        End Get
        Set(value As Double)
            PrecioUnitario = value
        End Set
    End Property

    Public Property Descripcion_Productos As String
        Get
            Return DescripcionProducto
        End Get
        Set(value As String)
            DescripcionProducto = value
        End Set
    End Property
End Class
