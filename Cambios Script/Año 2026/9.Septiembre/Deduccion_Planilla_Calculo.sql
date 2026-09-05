CREATE TABLE [dbo].[Deducciones_Planilla_Calculo](
    [IdCalculo] [int] IDENTITY(1,1) NOT NULL,
    [NumNomina] [nvarchar](50) NOT NULL,
    [TipoDeduccion] [nvarchar](50) NOT NULL,
    [TipoCalculo] [nvarchar](50) NOT NULL,
    [Monto] [float] NOT NULL,
    [Decimales] [int] NOT NULL,
    [UnidadesDistribuidas] [float] NULL,
    [FechaCalculo] [datetime2](3) NOT NULL,

    CONSTRAINT [PK_Deducciones_Planilla_Calculo]
        PRIMARY KEY CLUSTERED
        (
            [IdCalculo] ASC
        ),

    CONSTRAINT [FK_DeduccionesPlanillaCalculo_Nomina]
        FOREIGN KEY ([NumNomina])
        REFERENCES [dbo].[Nomina] ([NumPlanilla])
);
GO

ALTER TABLE [dbo].[Deducciones_Planilla_Calculo]
ADD CONSTRAINT [DF_Deducciones_Planilla_Calculo_FechaCalculo]
DEFAULT (sysdatetime()) FOR [FechaCalculo];
GO