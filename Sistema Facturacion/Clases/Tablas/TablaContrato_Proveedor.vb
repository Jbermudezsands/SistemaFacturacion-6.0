Public Class TablaContrato_Proveedor
	Private Numero_Contrato As Double
	Private Codigo_Proveedor As String
	Private Contacto_Proveedor As String
	Private Telefono_Contacto As String
	Private Descripcion As String
	Private Fecha_Inicio As Date
	Private Fecha_Fin As Date
	Private Tipo_Servicio As String
	Private Tipo_Contrato As String
	Private Modelo As String
	Private Num_Respuesta As Double
	Private Num_Resolucion As Double
	Private Tiempo_Respuesta As Double
	Private Tiempo_Resolucion As Double
	Private Estado As String
	Private Comentarios As String
	Private Cobertura_Lunes As Boolean
	Private Cobertura_Martes As Boolean
	Private Cobertura_Miercoles As Boolean
	Private Cobertura_Jueves As Boolean
	Private Cobertura_Viernes As Boolean
	Private Cobertura_Sabado As Boolean
	Private Cobertura_Domingo As Boolean
	Private Lunes_Inicio As Date
	Private Lunes_Fin As Date
	Private Martes_Inicio As Date
	Private Martes_Fin As Date
	Private Miercoles_Inicio As Date
	Private Miercoles_Fin As Date
	Private Jueves_Inicio As Date
	Private Jueves_Fin As Date
	Private Viernes_Inicio As Date
	Private Viernes_Fin As Date
	Private Sabado_Inicio As Date
	Private Sabado_Fin As Date
	Private Domingo_Inicio As Date
	Private Domingo_Fin As Date

    Public Property Numero_Contrato_Proveedor As Double
        Get
            Return Numero_Contrato
        End Get
        Set(value As Double)
            Numero_Contrato = value
        End Set
    End Property

    Public Property Codigo_Proveedor_Contrato As String
        Get
            Return Codigo_Proveedor
        End Get
        Set(value As String)
            Codigo_Proveedor = value
        End Set
    End Property

    Public Property Contacto_Proveedor_Contrato As String
        Get
            Return Contacto_Proveedor
        End Get
        Set(value As String)
            Contacto_Proveedor = value
        End Set
    End Property

    Public Property Telefono_Contacto_Contrato As String
        Get
            Return Telefono_Contacto
        End Get
        Set(value As String)
            Telefono_Contacto = value
        End Set
    End Property

    Public Property Descripcion_Contrato As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property Fecha_Inicio_Contrato As Date
        Get
            Return Fecha_Inicio
        End Get
        Set(value As Date)
            Fecha_Inicio = value
        End Set
    End Property

    Public Property Fecha_Fin_Contrato As Date
        Get
            Return Fecha_Fin
        End Get
        Set(value As Date)
            Fecha_Fin = value
        End Set
    End Property

    Public Property Tipo_Servicio_Contrato As String
        Get
            Return Tipo_Servicio
        End Get
        Set(value As String)
            Tipo_Servicio = value
        End Set
    End Property

    Public Property Tipo_Contrato_Contrato As String
        Get
            Return Tipo_Contrato
        End Get
        Set(value As String)
            Tipo_Contrato = value
        End Set
    End Property

    Public Property Modelo_Contrato As String
        Get
            Return Modelo
        End Get
        Set(value As String)
            Modelo = value
        End Set
    End Property

    Public Property Num_Respuesta_Contrato As Double
        Get
            Return Num_Respuesta
        End Get
        Set(value As Double)
            Num_Respuesta = value
        End Set
    End Property

    Public Property Num_Resolucion_Contrato As Double
        Get
            Return Num_Resolucion
        End Get
        Set(value As Double)
            Num_Resolucion = value
        End Set
    End Property

    Public Property Tiempo_Respuesta_Contrato As Double
        Get
            Return Tiempo_Respuesta
        End Get
        Set(value As Double)
            Tiempo_Respuesta = value
        End Set
    End Property

    Public Property Tiempo_Resolucion_Contrato As Double
        Get
            Return Tiempo_Resolucion
        End Get
        Set(value As Double)
            Tiempo_Resolucion = value
        End Set
    End Property

    Public Property Estado_Contrato As String
        Get
            Return Estado
        End Get
        Set(value As String)
            Estado = value
        End Set
    End Property

    Public Property Comentarios_Contrato As String
        Get
            Return Comentarios
        End Get
        Set(value As String)
            Comentarios = value
        End Set
    End Property

    Public Property Cobertura_Lunes_Contrato As Boolean
        Get
            Return Cobertura_Lunes
        End Get
        Set(value As Boolean)
            Cobertura_Lunes = value
        End Set
    End Property

    Public Property Cobertura_Martes_Contrato As Boolean
        Get
            Return Cobertura_Martes
        End Get
        Set(value As Boolean)
            Cobertura_Martes = value
        End Set
    End Property

    Public Property Cobertura_Miercoles_Contrato As Boolean
        Get
            Return Cobertura_Miercoles
        End Get
        Set(value As Boolean)
            Cobertura_Miercoles = value
        End Set
    End Property

    Public Property Cobertura_Jueves_Contrato As Boolean
        Get
            Return Cobertura_Jueves
        End Get
        Set(value As Boolean)
            Cobertura_Jueves = value
        End Set
    End Property

    Public Property Cobertura_Viernes_Contrato As Boolean
        Get
            Return Cobertura_Viernes
        End Get
        Set(value As Boolean)
            Cobertura_Viernes = value
        End Set
    End Property

    Public Property Cobertura_Sabado_Contrato As Boolean
        Get
            Return Cobertura_Sabado
        End Get
        Set(value As Boolean)
            Cobertura_Sabado = value
        End Set
    End Property

    Public Property Cobertura_Domingo_Contrato As Boolean
        Get
            Return Cobertura_Domingo
        End Get
        Set(value As Boolean)
            Cobertura_Domingo = value
        End Set
    End Property

    Public Property Lunes_Inicio_Contrato As Date
        Get
            Return Lunes_Inicio
        End Get
        Set(value As Date)
            Lunes_Inicio = value
        End Set
    End Property

    Public Property Lunes_Fin_Contrato As Date
        Get
            Return Lunes_Fin
        End Get
        Set(value As Date)
            Lunes_Fin = value
        End Set
    End Property

    Public Property Martes_Inicio_Contrato As Date
        Get
            Return Martes_Inicio
        End Get
        Set(value As Date)
            Martes_Inicio = value
        End Set
    End Property

    Public Property Martes_Fin_Contrato As Date
        Get
            Return Martes_Fin
        End Get
        Set(value As Date)
            Martes_Fin = value
        End Set
    End Property

    Public Property Miercoles_Inicio_Contrato As Date
        Get
            Return Miercoles_Inicio
        End Get
        Set(value As Date)
            Miercoles_Inicio = value
        End Set
    End Property

    Public Property Miercoles_Fin_Contrato As Date
        Get
            Return Miercoles_Fin
        End Get
        Set(value As Date)
            Miercoles_Fin = value
        End Set
    End Property

    Public Property Jueves_Inicio_Contrato As Date
        Get
            Return Jueves_Inicio
        End Get
        Set(value As Date)
            Jueves_Inicio = value
        End Set
    End Property

    Public Property Jueves_Fin_Contrato As Date
        Get
            Return Jueves_Fin
        End Get
        Set(value As Date)
            Jueves_Fin = value
        End Set
    End Property

    Public Property Viernes_Inicio_Contrato As Date
        Get
            Return Viernes_Inicio
        End Get
        Set(value As Date)
            Viernes_Inicio = value
        End Set
    End Property

    Public Property Viernes_Fin_Contrato As Date
        Get
            Return Viernes_Fin
        End Get
        Set(value As Date)
            Viernes_Fin = value
        End Set
    End Property

    Public Property Sabado_Inicio_Contrato As Date
        Get
            Return Sabado_Inicio
        End Get
        Set(value As Date)
            Sabado_Inicio = value
        End Set
    End Property

    Public Property Sabado_Fin_Contrato As Date
        Get
            Return Sabado_Fin
        End Get
        Set(value As Date)
            Sabado_Fin = value
        End Set
    End Property

    Public Property Domingo_Inicio_Contrato As Date
        Get
            Return Domingo_Inicio
        End Get
        Set(value As Date)
            Domingo_Inicio = value
        End Set
    End Property

    Public Property Domingo_Fin_Contrato As Date
        Get
            Return Domingo_Fin
        End Get
        Set(value As Date)
            Domingo_Fin = value
        End Set
    End Property
End Class
