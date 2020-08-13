

/****** Object:  Table [dbo].[NominaTransportista]    Script Date: 06/08/2020 02:50:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NominaLiquidacion](
	[NumPlanilla] [nvarchar](50) NOT NULL,
	[FechaInicial] [smalldatetime] NULL,
	[FechaFinal] [smalldatetime] NULL,
	[Año] [float] NULL,
	[mes] [float] NULL,
	[Periodo] [float] NULL,
	[PorcientoIR] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PorcientoIR]  DEFAULT ((0)),
	[PorcientoPolicia] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PorcientoPolicia]  DEFAULT ((0)),
	[PrecioUnitario] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioUnitario]  DEFAULT ((0)),
	[Contabilizado] [bit] NULL CONSTRAINT [DF_NominaLiquidacion_Contabilizado]  DEFAULT ((0)),
	[Marca] [bit] NULL CONSTRAINT [DF_NominaLiquidacion_Marca]  DEFAULT ((1)),
	[Activo] [bit] NULL CONSTRAINT [DF_NominaLiquidacion_Activo]  DEFAULT ((1)),
	[PrecioLunes] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioLunes]  DEFAULT ((0)),
	[PrecioMartes] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioMartes]  DEFAULT ((0)),
	[PrecioMiercoles] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioMiercoles]  DEFAULT ((0)),
	[PrecioJueves] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioJueves]  DEFAULT ((0)),
	[PrecioViernes] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioViernes]  DEFAULT ((0)),
	[PrecioSabado] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioSabado]  DEFAULT ((0)),
	[PrecioDomingo] [float] NULL CONSTRAINT [DF_NominaLiquidacion_PrecioDomingo]  DEFAULT ((0)),
 CONSTRAINT [PK_NominaLiquiacion] PRIMARY KEY CLUSTERED 
(
	[NumPlanilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


