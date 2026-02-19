Public Class Beneficiario
	Private CodigoBeneficiario As String
    Private NombreBeneficiario As String
    Private Apellido_Beneficiario As String
	Private FechaAdmision As Date
	Private FechaNacimiento As Date
    Private DireccionBeneficiario As String
    Private SexoBeneficiario As String
    Private TelefonosBeneficiario As String
    Private EstadoCivil As String
    Private CedulaBeneficiario As String
    Private RUCBeneficiario As String
    Private FotoBeneficiario As String
    Private _EsSocio As Boolean
    Private _EsPreSocio As Boolean

    'Tipos
    Private _EsCliente As Boolean
    Private _EsProveedor As Boolean
    Private _EsProductor As Boolean
    Private _EsEmpleado As Boolean
    Private _Activo As Boolean

#Region "Propiedades"
    Public Property Codigo As String
        Get
            Return CodigoBeneficiario
        End Get
        Set(value As String)
            CodigoBeneficiario = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return NombreBeneficiario
        End Get
        Set(value As String)
            NombreBeneficiario = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return Apellido_Beneficiario
        End Get
        Set(value As String)
            Apellido_Beneficiario = value
        End Set
    End Property

    Public Property Fecha_Admision As Date
        Get
            Return FechaAdmision
        End Get
        Set(value As Date)
            FechaAdmision = value
        End Set
    End Property

    Public Property Fecha_Nacimiento As Date
        Get
            Return FechaNacimiento
        End Get
        Set(value As Date)
            FechaNacimiento = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return DireccionBeneficiario
        End Get
        Set(value As String)
            DireccionBeneficiario = value
        End Set
    End Property

    Public Property Sexo As String
        Get
            Return SexoBeneficiario
        End Get
        Set(value As String)
            SexoBeneficiario = value
        End Set
    End Property

    Public Property Telefonos As String
        Get
            Return TelefonosBeneficiario
        End Get
        Set(value As String)
            TelefonosBeneficiario = value
        End Set
    End Property

    Public Property Estado_Civil As String
        Get
            Return EstadoCivil
        End Get
        Set(value As String)
            EstadoCivil = value
        End Set
    End Property

    Public Property Cedula As String
        Get
            Return CedulaBeneficiario
        End Get
        Set(value As String)
            CedulaBeneficiario = value
        End Set
    End Property

    Public Property RUC As String
        Get
            Return RUCBeneficiario
        End Get
        Set(value As String)
            RUCBeneficiario = value
        End Set
    End Property

    Public Property Foto As String
        Get
            Return FotoBeneficiario
        End Get
        Set(value As String)
            FotoBeneficiario = value
        End Set
    End Property

    'TIPOS
    Public Property EsCliente As Boolean
        Get
            Return _EsCliente
        End Get
        Set(value As Boolean)
            _EsCliente = value
        End Set
    End Property

    Public Property EsProveedor As Boolean
        Get
            Return _EsProveedor
        End Get
        Set(value As Boolean)
            _EsProveedor = value
        End Set
    End Property

    Public Property EsProductor As Boolean
        Get
            Return _EsProductor
        End Get
        Set(value As Boolean)
            _EsProductor = value
        End Set
    End Property

    Public Property EsEmpleado As Boolean
        Get
            Return _EsEmpleado
        End Get
        Set(value As Boolean)
            _EsEmpleado = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return _Activo
        End Get
        Set(value As Boolean)
            _Activo = value
        End Set
    End Property

    Public Property EsSocio As Boolean
        Get
            Return _EsSocio
        End Get
        Set(value As Boolean)
            _EsSocio = value
        End Set
    End Property

    Public Property EsPreSocio As Boolean
        Get
            Return _EsPreSocio
        End Get
        Set(value As Boolean)
            _EsPreSocio = value
        End Set
    End Property

#End Region

End Class
