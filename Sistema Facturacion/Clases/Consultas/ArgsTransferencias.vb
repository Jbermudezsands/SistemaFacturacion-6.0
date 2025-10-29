Public Class ArgsTransferencias
    Private NumeroTransferencia As String
    Private TipoTransferencia As String
    Private FechaTransferencia As Date
    Private CodigoBodega_Origen As String
    Private CodigoBodega_Destino As String
    Private ObservacionesTransferencia As String
    Private SubTotalTransferencia As Double
    Private ModoOperacionTransferencia As String
    Private UsuarioOperacion As String
    Private IdTransferenciaInterno As Integer


    Public Property Numero As String
        Get
            Return NumeroTransferencia
        End Get
        Set(value As String)
            NumeroTransferencia = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return TipoTransferencia
        End Get
        Set(value As String)
            TipoTransferencia = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return FechaTransferencia
        End Get
        Set(value As Date)
            FechaTransferencia = value
        End Set
    End Property

    Public Property CodigoBodegaOrigen As String
        Get
            Return CodigoBodega_Origen
        End Get
        Set(value As String)
            CodigoBodega_Origen = value
        End Set
    End Property

    Public Property CodigoBodegaDestino As String
        Get
            Return CodigoBodega_Destino
        End Get
        Set(value As String)
            CodigoBodega_Destino = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return ObservacionesTransferencia
        End Get
        Set(value As String)
            ObservacionesTransferencia = value
        End Set
    End Property

    Public Property SubTotal As Double
        Get
            Return SubTotalTransferencia
        End Get
        Set(value As Double)
            SubTotalTransferencia = value
        End Set
    End Property


    ' === Propiedades nuevas ===
    Public Property ModoOperacion As String
        Get
            Return ModoOperacionTransferencia
        End Get
        Set(value As String)
            ModoOperacionTransferencia = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return UsuarioOperacion
        End Get
        Set(value As String)
            UsuarioOperacion = value
        End Set
    End Property

    Public Property IdTransferencia As Integer
        Get
            Return IdTransferenciaInterno
        End Get
        Set(value As Integer)
            IdTransferenciaInterno = value
        End Set
    End Property
End Class
