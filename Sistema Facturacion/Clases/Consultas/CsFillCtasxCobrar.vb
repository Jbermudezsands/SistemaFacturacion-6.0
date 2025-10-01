Public Class CsFillCtasxCobrar
    Private CodigoCliente As String
    Private OptCordobas As Boolean
    Private FechaFin As Date
    Private ProcesoCtas As String
    Private ClientesDesde As String
    Private ClientesHasta As String
    Private VendedorDesde As String
    Private VendedorHasta As String
    Private CodDepartamento_Ini As String
    Private CodDepartamento_Fin As String
    Private ExcluirCero As Boolean
    Private OrdenarCtas As String

    Public Property Codigo_Cliente As String
        Get
            Return CodigoCliente
        End Get
        Set(value As String)
            CodigoCliente = value
        End Set
    End Property

    Public Property Opt_Cordobas As Boolean
        Get
            Return OptCordobas
        End Get
        Set(value As Boolean)
            OptCordobas = value
        End Set
    End Property

    Public Property Fecha_Fin As Date
        Get
            Return FechaFin
        End Get
        Set(value As Date)
            FechaFin = value
        End Set
    End Property

    Public Property Proceso As String
        Get
            Return ProcesoCtas
        End Get
        Set(value As String)
            ProcesoCtas = value
        End Set
    End Property

    Public Property Clientes_Desde As String
        Get
            Return ClientesDesde
        End Get
        Set(value As String)
            ClientesDesde = value
        End Set
    End Property

    Public Property Clientes_Hasta As String
        Get
            Return ClientesHasta
        End Get
        Set(value As String)
            ClientesHasta = value
        End Set
    End Property

    Public Property Vendedor_Desde As String
        Get
            Return VendedorDesde
        End Get
        Set(value As String)
            VendedorDesde = value
        End Set
    End Property

    Public Property Vendedor_Hasta As String
        Get
            Return VendedorHasta
        End Get
        Set(value As String)
            VendedorHasta = value
        End Set
    End Property

    Public Property CodDepartamentoIni As String
        Get
            Return CodDepartamento_Ini
        End Get
        Set(value As String)
            CodDepartamento_Ini = value
        End Set
    End Property

    Public Property CodDepartamentoFin As String
        Get
            Return CodDepartamento_Fin
        End Get
        Set(value As String)
            CodDepartamento_Fin = value
        End Set
    End Property

    Public Property Excluir_Cero As Boolean
        Get
            Return ExcluirCero
        End Get
        Set(value As Boolean)
            ExcluirCero = value
        End Set
    End Property

    Public Property Ordenar As String
        Get
            Return OrdenarCtas
        End Get
        Set(value As String)
            OrdenarCtas = value
        End Set
    End Property
End Class
