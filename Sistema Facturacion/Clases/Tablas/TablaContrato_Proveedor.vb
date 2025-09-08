Public Class TablaContrato_Proveedor
    Private Numero_Contrato_Proveedor As String
    Private Codigo_Proveedor_Contrato As String
    Private Contacto_Proveedor_Contrato As String
    Private Telefono_Contacto_Contrato As String
    Private Descripcion_Contrato As String
    Private FechaInicio As Date
    Private FechaFin As Date
    Private TipoServicio As String
    Private TipoContrato As String
    Private Modelo_Contrato As String
    Private NumRespuesta As Double
    Private NumResolucion As Double
    Private TiempoRespuesta As String
    Private TiempoResolucion As String
    Private EstadoContrato As String
    Private Comentarios_Contrato As String
    Private CoberturaLunes As Integer
    Private CoberturaMartes As Integer
    Private CoberturaMiercoles As Integer
    Private CoberturaJueves As Integer
    Private CoberturaViernes As Integer
    Private CoberturaSabado As Integer
    Private CoberturaDomingo As Integer
    Private LunesInicio As Date
    Private LunesFin As Date
    Private MartesInicio As Date
    Private MartesFin As Date
    Private MiercolesInicio As Date
    Private MiercolesFin As Date
    Private JuevesInicio As Date
    Private JuevesFin As Date
    Private ViernesInicio As Date
    Private ViernesFin As Date
    Private SabadoInicio As Date
    Private SabadoFin As Date
    Private DomingoInicio As Date
    Private DomingoFin As Date

    Public Property Numero_Contrato As String
        Get
            Return Numero_Contrato_Proveedor
        End Get
        Set(value As String)
            Numero_Contrato_Proveedor = value
        End Set
    End Property

    Public Property Codigo_Proveedor As String
        Get
            Return Codigo_Proveedor_Contrato
        End Get
        Set(value As String)
            Codigo_Proveedor_Contrato = value
        End Set
    End Property

    Public Property Contacto_Proveedor As String
        Get
            Return Contacto_Proveedor_Contrato
        End Get
        Set(value As String)
            Contacto_Proveedor_Contrato = value
        End Set
    End Property

    Public Property Telefono_Contacto As String
        Get
            Return Telefono_Contacto_Contrato
        End Get
        Set(value As String)
            Telefono_Contacto_Contrato = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return Descripcion_Contrato
        End Get
        Set(value As String)
            Descripcion_Contrato = value
        End Set
    End Property

    Public Property Fecha_Inicio As Date
        Get
            Return FechaInicio
        End Get
        Set(value As Date)
            FechaInicio = value
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

    Public Property Tipo_Servicio As String
        Get
            Return TipoServicio
        End Get
        Set(value As String)
            TipoServicio = value
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

    Public Property ModeloContrato As String
        Get
            Return Modelo_Contrato
        End Get
        Set(value As String)
            Modelo_Contrato = value
        End Set
    End Property

    Public Property Num_Respuesta As Double
        Get
            Return NumRespuesta
        End Get
        Set(value As Double)
            NumRespuesta = value
        End Set
    End Property

    Public Property Num_Resolucion As Double
        Get
            Return NumResolucion
        End Get
        Set(value As Double)
            NumResolucion = value
        End Set
    End Property

    Public Property Tiempo_Respuesta As String
        Get
            Return TiempoRespuesta
        End Get
        Set(value As String)
            TiempoRespuesta = value
        End Set
    End Property

    Public Property Tiempo_Resolucion As String
        Get
            Return TiempoResolucion
        End Get
        Set(value As String)
            TiempoResolucion = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return EstadoContrato
        End Get
        Set(value As String)
            EstadoContrato = value
        End Set
    End Property

    Public Property Comentarios As String
        Get
            Return Comentarios_Contrato
        End Get
        Set(value As String)
            Comentarios_Contrato = value
        End Set
    End Property

    Public Property Cobertura_Lunes As Integer
        Get
            Return CoberturaLunes
        End Get
        Set(value As Integer)
            CoberturaLunes = value
        End Set
    End Property

    Public Property Cobertura_Martes As Integer
        Get
            Return CoberturaMartes
        End Get
        Set(value As Integer)
            CoberturaMartes = value
        End Set
    End Property

    Public Property Cobertura_Miercoles As Integer
        Get
            Return CoberturaMiercoles
        End Get
        Set(value As Integer)
            CoberturaMiercoles = value
        End Set
    End Property

    Public Property Cobertura_Jueves As Integer
        Get
            Return CoberturaJueves
        End Get
        Set(value As Integer)
            CoberturaJueves = value
        End Set
    End Property

    Public Property Cobertura_Viernes As Integer
        Get
            Return CoberturaViernes
        End Get
        Set(value As Integer)
            CoberturaViernes = value
        End Set
    End Property

    Public Property Cobertura_Sabado As Integer
        Get
            Return CoberturaSabado
        End Get
        Set(value As Integer)
            CoberturaSabado = value
        End Set
    End Property

    Public Property Cobertura_Domingo As Integer
        Get
            Return CoberturaDomingo
        End Get
        Set(value As Integer)
            CoberturaDomingo = value
        End Set
    End Property

    Public Property Lunes_Inicio As Date
        Get
            Return LunesInicio
        End Get
        Set(value As Date)
            LunesInicio = value
        End Set
    End Property

    Public Property Lunes_Fin As Date
        Get
            Return LunesFin
        End Get
        Set(value As Date)
            LunesFin = value
        End Set
    End Property

    Public Property Martes_Inicio As Date
        Get
            Return MartesInicio
        End Get
        Set(value As Date)
            MartesInicio = value
        End Set
    End Property

    Public Property Martes_Fin As Date
        Get
            Return MartesFin
        End Get
        Set(value As Date)
            MartesFin = value
        End Set
    End Property

    Public Property Miercoles_Inicio As Date
        Get
            Return MiercolesInicio
        End Get
        Set(value As Date)
            MiercolesInicio = value
        End Set
    End Property

    Public Property Miercoles_Fin As Date
        Get
            Return MiercolesFin
        End Get
        Set(value As Date)
            MiercolesFin = value
        End Set
    End Property

    Public Property Jueves_Inicio As Date
        Get
            Return JuevesInicio
        End Get
        Set(value As Date)
            JuevesInicio = value
        End Set
    End Property

    Public Property Jueves_Fin As Date
        Get
            Return JuevesFin
        End Get
        Set(value As Date)
            JuevesFin = value
        End Set
    End Property

    Public Property Viernes_Inicio As Date
        Get
            Return ViernesInicio
        End Get
        Set(value As Date)
            ViernesInicio = value
        End Set
    End Property

    Public Property Viernes_Fin As Date
        Get
            Return ViernesFin
        End Get
        Set(value As Date)
            ViernesFin = value
        End Set
    End Property

    Public Property Sabado_Inicio As Date
        Get
            Return SabadoInicio
        End Get
        Set(value As Date)
            SabadoInicio = value
        End Set
    End Property

    Public Property Sabado_Fin As Date
        Get
            Return SabadoFin
        End Get
        Set(value As Date)
            SabadoFin = value
        End Set
    End Property

    Public Property Domingo_Inicio As Date
        Get
            Return DomingoInicio
        End Get
        Set(value As Date)
            DomingoInicio = value
        End Set
    End Property

    Public Property Domingo_Fin As Date
        Get
            Return DomingoFin
        End Get
        Set(value As Date)
            DomingoFin = value
        End Set
    End Property
End Class
