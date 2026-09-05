/* ============================================================
   PLANES DE PAGO
   Sistema Facturacion
   ============================================================ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* ============================================================
   1. AGREGAR CONSECUTIVO PARA NUMERO DE CREDITO
   ============================================================ */

IF COL_LENGTH('dbo.Consecutivos', 'NumeroCredito') IS NULL
BEGIN
    ALTER TABLE dbo.Consecutivos
    ADD NumeroCredito float NULL;
END
GO


/* ============================================================
   2. TABLA PLANPAGOS
   ============================================================ */

IF OBJECT_ID('dbo.PlanPagos', 'U') IS NULL
BEGIN

    CREATE TABLE dbo.PlanPagos
    (
        NumeroCredito int NOT NULL,

        NumeroFactura nvarchar(50) NOT NULL,
        FechaFactura smalldatetime NOT NULL,
        TipoFactura nvarchar(50) NOT NULL,

        FechaCredito smalldatetime NOT NULL,

        MontoCredito decimal(18,2) NOT NULL,

        Cuotas int NOT NULL,

        FrecuenciaPago nvarchar(20) NOT NULL,

        DiasFrecuencia int NOT NULL,

        PorcentajeInteres decimal(9,4) NOT NULL
            CONSTRAINT DF_PlanPagos_PorcentajeInteres DEFAULT (0),

        PorcentajeMora decimal(9,4) NOT NULL
            CONSTRAINT DF_PlanPagos_PorcentajeMora DEFAULT (0),

        PorcentajeMantenimientoValor decimal(9,4) NOT NULL
            CONSTRAINT DF_PlanPagos_PorcentajeMantenimientoValor DEFAULT (0),

        Anulado bit NOT NULL
            CONSTRAINT DF_PlanPagos_Anulado DEFAULT (0),

        FechaAnulacion smalldatetime NULL,

        UsuarioAnulacion nvarchar(50) NULL,

        CONSTRAINT PK_PlanPagos
            PRIMARY KEY CLUSTERED (NumeroCredito)
    );

END
GO


/* ============================================================
   3. RELACION PLANPAGOS -> FACTURAS
   ============================================================ */

IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = 'FK_PlanPagos_Facturas'
)
BEGIN

    ALTER TABLE dbo.PlanPagos
    ADD CONSTRAINT FK_PlanPagos_Facturas
    FOREIGN KEY
    (
        NumeroFactura,
        FechaFactura,
        TipoFactura
    )
    REFERENCES dbo.Facturas
    (
        Numero_Factura,
        Fecha_Factura,
        Tipo_Factura
    );

END
GO


/* ============================================================
   4. TABLA DETALLEPAGOS
   ============================================================ */

IF OBJECT_ID('dbo.DetallePagos', 'U') IS NULL
BEGIN

    CREATE TABLE dbo.DetallePagos
    (
        idDetallePago int IDENTITY(1,1) NOT NULL,

        NumeroCredito int NOT NULL,

        NumeroCuota int NOT NULL,

        FechaVencimiento smalldatetime NOT NULL,

        MontoAbono decimal(18,2) NOT NULL,

        MontoInteres decimal(18,2) NOT NULL
            CONSTRAINT DF_DetallePagos_MontoInteres DEFAULT (0),

        MontoMora decimal(18,2) NOT NULL
            CONSTRAINT DF_DetallePagos_MontoMora DEFAULT (0),

        MontoMtoValor decimal(18,2) NOT NULL
            CONSTRAINT DF_DetallePagos_MontoMtoValor DEFAULT (0),

        Pagado bit NOT NULL
            CONSTRAINT DF_DetallePagos_Pagado DEFAULT (0),

        CONSTRAINT PK_DetallePagos
            PRIMARY KEY CLUSTERED (idDetallePago),

        CONSTRAINT UQ_DetallePagos_NumeroCredito_NumeroCuota
            UNIQUE (NumeroCredito, NumeroCuota)
    );

END
GO


/* ============================================================
   5. RELACION DETALLEPAGOS -> PLANPAGOS
   ============================================================ */

IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = 'FK_DetallePagos_PlanPagos'
)
BEGIN

    ALTER TABLE dbo.DetallePagos
    ADD CONSTRAINT FK_DetallePagos_PlanPagos
    FOREIGN KEY (NumeroCredito)
    REFERENCES dbo.PlanPagos
    (
        NumeroCredito
    );

END
GO


/* ============================================================
   6. INDICE PARA BUSCAR PLANES POR FACTURA
   ============================================================ */

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_PlanPagos_Factura'
      AND object_id = OBJECT_ID('dbo.PlanPagos')
)
BEGIN

    CREATE NONCLUSTERED INDEX IX_PlanPagos_Factura
    ON dbo.PlanPagos
    (
        NumeroFactura,
        FechaFactura,
        TipoFactura
    )
    INCLUDE
    (
        NumeroCredito,
        MontoCredito,
        Cuotas,
        FrecuenciaPago,
        Anulado
    );

END
GO


/* ============================================================
   7. INDICE PARA BUSCAR CUOTAS PENDIENTES
   ============================================================ */

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_DetallePagos_Pendientes'
      AND object_id = OBJECT_ID('dbo.DetallePagos')
)
BEGIN

    CREATE NONCLUSTERED INDEX IX_DetallePagos_Pendientes
    ON dbo.DetallePagos
    (
        NumeroCredito,
        Pagado,
        FechaVencimiento
    )
    INCLUDE
    (
        NumeroCuota,
        MontoAbono,
        MontoInteres,
        MontoMora,
        MontoMtoValor
    );

END
GO


/* ============================================================
   8. INDICE PARA CONSULTAR CUOTAS POR FECHA
   ============================================================ */

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_DetallePagos_FechaVencimiento'
      AND object_id = OBJECT_ID('dbo.DetallePagos')
)
BEGIN

    CREATE NONCLUSTERED INDEX IX_DetallePagos_FechaVencimiento
    ON dbo.DetallePagos
    (
        FechaVencimiento,
        Pagado
    )
    INCLUDE
    (
        NumeroCredito,
        NumeroCuota,
        MontoAbono,
        MontoInteres,
        MontoMora,
        MontoMtoValor
    );

END
GO