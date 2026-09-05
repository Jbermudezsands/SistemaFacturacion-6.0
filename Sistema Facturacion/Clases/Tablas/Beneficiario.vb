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


    Public Property CuentaTransporte As String

    Public Property EsTransportista As Boolean
    Public Property Licencia As String
    Public Property ListaNegra As Boolean
    Public Property RazonListaNegra As String
    Public Property CuentaContable As String
    Public Property CuentaBanco As String
    Public Property Precio As Double
    Public Property Evacuaciones As Boolean

    'clientes
    Public Property Departamento As String
    Public Property Municipio As String
    Public Property Endoso As String
    Public Property CodCuentaCliente As String
    Public Property LimiteCredito As Double
    Public Property DiasCredito As Double
    Public Property MonedaCredito As String
    Public Property BloquearPorLimiteCredito As Boolean
    Public Property Efectivo As Boolean
    Public Property CodCuentaBanco As String
    Public Property CtasxCobrarClientes As String
    Public Property CausaIva As Boolean
    Public Property CreditoDisponible As Boolean

    'Proveedor
    Public Property DepartamentoProveedor As String
    Public Property MunicipioProveedor As String
    Public Property EndosoProveedor As String
    Public Property CodCuentaProveedor As String
    Public Property LimiteCreditoProveedor As Double
    Public Property DiasCreditoProveedor As Double
    Public Property MonedaCreditoProveedor As String
    Public Property BloquearPorLimiteCreditoProveedor As Boolean
    Public Property EfectivoProveedor As Boolean
    Public Property CodCuentaBancoProveedor As String
    Public Property CtasxPagarProveedor As String
    Public Property CausaIvaProveedor As Boolean
    Public Property CreditoDisponibleProveedor As Boolean

    'Productor
    Public Property DepartamentoProductor As String
    Public Property MunicipioProductor As String
    Public Property EscolaridadProductor As String
    Public Property CooperatiaProductor As String
    Public Property RutaProductor As String
    Public Property CtasxCobrarProductor As String
    Public Property CtasxPagarProductor As String
    Public Property CtaPlanillaProductor As String
    Public Property CtaBancoProductor As String
    Public Property CtaIrProductor As String
    Public Property CtaBolsaProductor As String
    Public Property CtaAnticipoProductor As String
    Public Property CtaTransporteProductor As String
    Public Property CtaInseminacionProductor As String
    Public Property CtaTrazabilidadProductor As String
    Public Property CtaVeterinariosProductor As String
    Public Property CtaFondosProductor As String
    Public Property CtaOtrasDeduccionesProductor As String
    Public Property TipoPagoProductor As String
    Public Property CodTipoNominaProductor As String
    Public Property PrecioProductor As String
    Public Property CuentaPagarBanco As String

    'Socio
    Public Property DepartamentoSocio As String
    Public Property MunicipioSocio As String
    Public Property EscolaridadSocio As String
    Public Property CooperatiaSocio As String
    Public Property RutaSocio As String
    Public Property CtasxCobrarSocio As String
    Public Property CtasxPagarSocio As String
    Public Property CtaPlanillaSocio As String
    Public Property CtaBancoSocio As String
    Public Property CtaIrSocio As String
    Public Property CtaBolsaSocio As String
    Public Property CtaAnticipoSocio As String
    Public Property CtaTransporteSocio As String
    Public Property CtaInseminacionSocio As String
    Public Property CtaTrazabilidadSocio As String
    Public Property CtaVeterinariosSocio As String
    Public Property CtaFondosSocio As String
    Public Property CtaOtrasDeduccionesSocio As String
    Public Property TipoPagoSocio As String
    Public Property CodTipoNominaSocio As String
    Public Property PrecioSocio As String

    'PreSocio
    Public Property DepartamentoPreSocio As String
    Public Property MunicipioPreSocio As String
    Public Property EscolaridadPreSocio As String
    Public Property CooperatiaPreSocio As String
    Public Property RutaPreSocio As String
    Public Property CtasxCobrarPreSocio As String
    Public Property CtasxPagarPreSocio As String
    Public Property CtaPlanillaPreSocio As String
    Public Property CtaBancoPreSocio As String
    Public Property CtaIrPreSocio As String
    Public Property CtaBolsaPreSocio As String
    Public Property CtaAnticipoPreSocio As String
    Public Property CtaTransportePreSocio As String
    Public Property CtaInseminacionPreSocio As String
    Public Property CtaTrazabilidadPreSocio As String
    Public Property CtaVeterinariosPreSocio As String
    Public Property CtaFondosPreSocio As String
    Public Property CtaOtrasDeduccionesPreSocio As String
    Public Property TipoPagoPreSocio As String
    Public Property CodTipoNominaPreSocio As String
    Public Property PrecioPreSocio As String

    'Transportistas
    Public Property CtaTransportista As String
    Public Property CtaInseminacionTransp As String
    Public Property CtaTrazabilidadTransp As String
    Public Property CtaBolsaTransp As String
    Public Property CtaAnticipoTransp As String
    Public Property CtaFondosTransp As String
    Public Property CtaGtosPlanillaTransp As String
    Public Property CtaBancoTransp As String
    Public Property CtaIrTransp As String
    Public Property CtaVeterinariaTransp As String
    Public Property CtaOtrasDeduccionesTransp As String
    Public Property TipoPagoTransportista As String



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
