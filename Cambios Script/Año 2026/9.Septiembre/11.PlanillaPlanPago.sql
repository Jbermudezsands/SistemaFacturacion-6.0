CREATE TABLE [dbo].[PlanillaPlanPago]
(
    [IdPlanillaPlanPago] INT IDENTITY(1,1) NOT NULL,

    [NumNomina] NVARCHAR(50) NOT NULL,
    [CodProductor] NVARCHAR(50) NOT NULL,
    [TipoProductor] NVARCHAR(50) NOT NULL,

    [idDetallePago] INT NOT NULL,

    [MontoCuota] DECIMAL(18,2) NOT NULL,
    [MontoAbonadoAnterior] DECIMAL(18,2) NOT NULL,
    [SaldoAntesPlanilla] DECIMAL(18,2) NOT NULL,

    [MontoPropuesto] DECIMAL(18,2) NOT NULL,
    [MontoCobrado] DECIMAL(18,2) NOT NULL,

    [Estado] NVARCHAR(20) NOT NULL,
    [Motivo] NVARCHAR(250) NULL,

    [UsuarioRegistro] NVARCHAR(50) NULL,
    [FechaRegistro] DATETIME2(3) NOT NULL 
        CONSTRAINT [DF_PlanillaPlanPago_FechaRegistro]
        DEFAULT (SYSDATETIME()),

    CONSTRAINT [PK_PlanillaPlanPago]
        PRIMARY KEY CLUSTERED ([IdPlanillaPlanPago] ASC),

    CONSTRAINT [FK_PlanillaPlanPago_DetallePagos]
        FOREIGN KEY ([idDetallePago])
        REFERENCES [dbo].[DetallePagos] ([idDetallePago]),

    CONSTRAINT [UQ_PlanillaPlanPago]
        UNIQUE
        (
            [NumNomina],
            [CodProductor],
            [TipoProductor],
            [idDetallePago]
        )
);
GO