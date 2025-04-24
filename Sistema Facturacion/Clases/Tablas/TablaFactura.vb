Public Class TablaFactura
    Private NumeroFactura As String
    Private FechaFactura As Date
    Private TipoFactura As String
    Private MonedaFactura As String
    Private CodCliente As String
    Private CodBodega As String
    Private CodVendedor As String
    Private CodCajero As String
    Private NombreCliente As String
    Private ApellidoCliente As String
    Private DireccionCliente As String
    Private TelefonoCliente As String
    Private FechaVencimiento As Date
    Private Observaciones As String
    Private FechaEnvio As Date
    Private ViaEnvarque As String
    Private Descuento As String
    Private FechaDescuento As Date
    Private SuReferencia As String
    Private NuestraReferencia As String
    Private SubTotal As Double
    Private IVA As Double
    Private Pagado As Double
    Private NetoPagar As Double
    Private MontoCredito As Double
    Private Contabilizado As Integer
    Private Activo As Integer
    Private Cancelado As Integer
    Private MetodoPago As String
    Private Exonerado As Integer
    Private Descuentos As Double
    Private Marca As Integer
    Private FechaPago As Date
    Private TransferenciaProcesada As Integer
    Private MonedaImprime As String
    Private CodigoProyecto As String
    Private Retener1Porciento As Integer
    Private Retener2Porciento As Integer
    Private MontoRetencion1Porciento As Double
    Private MontoRetencion2Porciento As Double
    Private Referencia As String
    Private Propina As Double
    Private CalculaPropina As Integer
    Private FechaHora As Date
    Private TipoProductor As String
    Private AplicarCtasXCobrar As Integer

    Public Property Numero_Factura As String
        Get
            Return NumeroFactura
        End Get
        Set(value As String)
            NumeroFactura = value
        End Set
    End Property

    Public Property Fecha_Factura As Date
        Get
            Return FechaFactura
        End Get
        Set(value As Date)
            FechaFactura = value
        End Set
    End Property

    Public Property Tipo_Factura As String
        Get
            Return TipoFactura
        End Get
        Set(value As String)
            TipoFactura = value
        End Set
    End Property

    Public Property Moneda_Factura As String
        Get
            Return MonedaFactura
        End Get
        Set(value As String)
            MonedaFactura = value
        End Set
    End Property

    Public Property Cod_Cliente As String
        Get
            Return CodCliente
        End Get
        Set(value As String)
            CodCliente = value
        End Set
    End Property

    Public Property CodBodega1 As String
        Get
            Return CodBodega
        End Get
        Set(value As String)
            CodBodega = value
        End Set
    End Property

    Public Property Cod_Vendedor As String
        Get
            Return CodVendedor
        End Get
        Set(value As String)
            CodVendedor = value
        End Set
    End Property

    Public Property Cod_Cajero As String
        Get
            Return CodCajero
        End Get
        Set(value As String)
            CodCajero = value
        End Set
    End Property

    Public Property Nombre_Cliente As String
        Get
            Return NombreCliente
        End Get
        Set(value As String)
            NombreCliente = value
        End Set
    End Property

    Public Property Apellido_Cliente As String
        Get
            Return ApellidoCliente
        End Get
        Set(value As String)
            ApellidoCliente = value
        End Set
    End Property

    Public Property Direccion_Cliente As String
        Get
            Return DireccionCliente
        End Get
        Set(value As String)
            DireccionCliente = value
        End Set
    End Property

    Public Property Telefono_Cliente As String
        Get
            Return TelefonoCliente
        End Get
        Set(value As String)
            TelefonoCliente = value
        End Set
    End Property

    Public Property Fecha_Vencimiento As Date
        Get
            Return FechaVencimiento
        End Get
        Set(value As Date)
            FechaVencimiento = value
        End Set
    End Property

    Public Property Observaciones_Factura As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property

    Public Property Fecha_Envio As Date
        Get
            Return FechaEnvio
        End Get
        Set(value As Date)
            FechaEnvio = value
        End Set
    End Property

    Public Property Via_Envarque As String
        Get
            Return ViaEnvarque
        End Get
        Set(value As String)
            ViaEnvarque = value
        End Set
    End Property

    Public Property Descuento_Factura As String
        Get
            Return Descuento
        End Get
        Set(value As String)
            Descuento = value
        End Set
    End Property

    Public Property Fecha_Descuento As Date
        Get
            Return FechaDescuento
        End Get
        Set(value As Date)
            FechaDescuento = value
        End Set
    End Property

    Public Property SuReferencia1 As String
        Get
            Return SuReferencia
        End Get
        Set(value As String)
            SuReferencia = value
        End Set
    End Property

    Public Property Nuestra_Referencia As String
        Get
            Return NuestraReferencia
        End Get
        Set(value As String)
            NuestraReferencia = value
        End Set
    End Property

    Public Property Sub_Total As Double
        Get
            Return SubTotal
        End Get
        Set(value As Double)
            SubTotal = value
        End Set
    End Property

    Public Property IVA_Factura As Double
        Get
            Return IVA
        End Get
        Set(value As Double)
            IVA = value
        End Set
    End Property

    Public Property Pagado_Factura As Double
        Get
            Return Pagado
        End Get
        Set(value As Double)
            Pagado = value
        End Set
    End Property

    Public Property Neto_Pagar As Double
        Get
            Return NetoPagar
        End Get
        Set(value As Double)
            NetoPagar = value
        End Set
    End Property

    Public Property Monto_Credito As Double
        Get
            Return MontoCredito
        End Get
        Set(value As Double)
            MontoCredito = value
        End Set
    End Property

    Public Property Contabilizado_Factura As Integer
        Get
            Return Contabilizado
        End Get
        Set(value As Integer)
            Contabilizado = value
        End Set
    End Property

    Public Property Activo_Factura As Integer
        Get
            Return Activo
        End Get
        Set(value As Integer)
            Activo = value
        End Set
    End Property

    Public Property Cancelado_Factura As Integer
        Get
            Return Cancelado
        End Get
        Set(value As Integer)
            Cancelado = value
        End Set
    End Property

    Public Property Metodo_Pago As String
        Get
            Return MetodoPago
        End Get
        Set(value As String)
            MetodoPago = value
        End Set
    End Property

    Public Property Exonerado_Factura As Integer
        Get
            Return Exonerado
        End Get
        Set(value As Integer)
            Exonerado = value
        End Set
    End Property

    Public Property Descuentos_Factura As Double
        Get
            Return Descuentos
        End Get
        Set(value As Double)
            Descuentos = value
        End Set
    End Property

    Public Property Marca_Factura As Integer
        Get
            Return Marca
        End Get
        Set(value As Integer)
            Marca = value
        End Set
    End Property

    Public Property Fecha_Pago As Date
        Get
            Return FechaPago
        End Get
        Set(value As Date)
            FechaPago = value
        End Set
    End Property

    Public Property Transferencia_Procesada As Integer
        Get
            Return TransferenciaProcesada
        End Get
        Set(value As Integer)
            TransferenciaProcesada = value
        End Set
    End Property

    Public Property Moneda_Imprime As String
        Get
            Return MonedaImprime
        End Get
        Set(value As String)
            MonedaImprime = value
        End Set
    End Property

    Public Property Codigo_Proyecto As String
        Get
            Return CodigoProyecto
        End Get
        Set(value As String)
            CodigoProyecto = value
        End Set
    End Property

    Public Property Retener1_Porciento As Integer
        Get
            Return Retener1Porciento
        End Get
        Set(value As Integer)
            Retener1Porciento = value
        End Set
    End Property

    Public Property Retener2_Porciento As Integer
        Get
            Return Retener2Porciento
        End Get
        Set(value As Integer)
            Retener2Porciento = value
        End Set
    End Property

    Public Property MontoRetencion1_Porciento As Double
        Get
            Return MontoRetencion1Porciento
        End Get
        Set(value As Double)
            MontoRetencion1Porciento = value
        End Set
    End Property

    Public Property MontoRetencion2_Porciento As Double
        Get
            Return MontoRetencion2Porciento
        End Get
        Set(value As Double)
            MontoRetencion2Porciento = value
        End Set
    End Property

    Public Property Referencia_Factura As String
        Get
            Return Referencia
        End Get
        Set(value As String)
            Referencia = value
        End Set
    End Property

    Public Property Propina_Factura As Double
        Get
            Return Propina
        End Get
        Set(value As Double)
            Propina = value
        End Set
    End Property

    Public Property Calcula_Propina As Integer
        Get
            Return CalculaPropina
        End Get
        Set(value As Integer)
            CalculaPropina = value
        End Set
    End Property

    Public Property Fecha_Hora As Date
        Get
            Return FechaHora
        End Get
        Set(value As Date)
            FechaHora = value
        End Set
    End Property

    Public Property Tipo_Productor As String
        Get
            Return TipoProductor
        End Get
        Set(value As String)
            TipoProductor = value
        End Set
    End Property

    Public Property Aplicar_CtasXCobrar As Integer
        Get
            Return AplicarCtasXCobrar
        End Get
        Set(value As Integer)
            AplicarCtasXCobrar = value
        End Set
    End Property
End Class
