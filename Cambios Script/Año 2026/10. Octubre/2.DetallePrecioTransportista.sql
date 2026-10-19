CREATE TABLE [dbo].[DetallePrecioTransportista]
(
    [IdDetallePrecio] BIGINT IDENTITY(1,1) NOT NULL,

    -- Identificación de las planillas
    [NumNominaTransportista] NVARCHAR(50) NOT NULL,
    [NumNominaLeche] NVARCHAR(50) NOT NULL,

    -- Identificación del movimiento
    [CodigoTransportista] NVARCHAR(50) NOT NULL,
    [CodProductor] NVARCHAR(50) NOT NULL,
    [TipoProductor] NVARCHAR(50) NOT NULL,

    -- Fecha y día del movimiento
    [FechaViaje] SMALLDATETIME NOT NULL,
    [Dia] NVARCHAR(10) NOT NULL,

    -- Cantidad transportada
    [Litros] FLOAT NOT NULL
        CONSTRAINT [DF_DetallePrecioTransportista_Litros]
        DEFAULT (0),

    -- Precios disponibles al momento del cálculo
    [PrecioProductor] FLOAT NOT NULL
        CONSTRAINT [DF_DetallePrecioTransportista_PrecioProductor]
        DEFAULT (0),

    [PrecioTransportista] FLOAT NOT NULL
        CONSTRAINT [DF_DetallePrecioTransportista_PrecioTransportista]
        DEFAULT (0),

    [PrecioManual] FLOAT NOT NULL
        CONSTRAINT [DF_DetallePrecioTransportista_PrecioManual]
        DEFAULT (0),

    -- Precio realmente utilizado
    [PrecioAplicado] FLOAT NOT NULL,

    -- PRODUCTOR, TRANSPORTISTA o MANUAL
    [OrigenPrecio] NVARCHAR(20) NOT NULL,

    -- Litros multiplicados por PrecioAplicado
    [Importe] FLOAT NOT NULL,

    -- Fecha y hora de registro
    [FechaRegistro] DATETIME2(3) NOT NULL
        CONSTRAINT [DF_DetallePrecioTransportista_FechaRegistro]
        DEFAULT (SYSDATETIME()),

    CONSTRAINT [PK_DetallePrecioTransportista]
        PRIMARY KEY CLUSTERED ([IdDetallePrecio]),

    CONSTRAINT [CK_DetallePrecioTransportista_OrigenPrecio]
        CHECK
        (
            [OrigenPrecio] IN
            (
                'PRODUCTOR',
                'TRANSPORTISTA',
                'MANUAL'
            )
        ),

    CONSTRAINT [CK_DetallePrecioTransportista_Dia]
        CHECK
        (
            [Dia] IN
            (
                'Lunes',
                'Martes',
                'Miercoles',
                'Jueves',
                'Viernes',
                'Sabado',
                'Domingo'
            )
        )
);
GO

-- Índice para consultar rápidamente el historial por planilla
CREATE NONCLUSTERED INDEX [IX_DetallePrecioTransportista_Planilla]
ON [dbo].[DetallePrecioTransportista]
(
    [NumNominaTransportista],
    [FechaViaje]
);
GO

-- Índice para consultar los movimientos de un productor
CREATE NONCLUSTERED INDEX [IX_DetallePrecioTransportista_Productor]
ON [dbo].[DetallePrecioTransportista]
(
    [CodProductor],
    [TipoProductor],
    [FechaViaje]
);
GO

-- Índice para consultar los movimientos de un transportista
CREATE NONCLUSTERED INDEX [IX_DetallePrecioTransportista_Transportista]
ON [dbo].[DetallePrecioTransportista]
(
    [CodigoTransportista],
    [FechaViaje]
);
GO