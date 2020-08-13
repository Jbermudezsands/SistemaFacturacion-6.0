

/****** Object:  Table [dbo].[Detalle_NominaLiquidacion]    Script Date: 06/08/2020 03:15:17 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detalle_NominaLiquidacion](
	[NumNomina] [nvarchar](50) NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Lunes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Lunes]  DEFAULT ((0)),
	[Martes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Martes]  DEFAULT ((0)),
	[Miercoles] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Miercoles]  DEFAULT ((0)),
	[Jueves] [float] NULL,
	[Viernes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Viernes]  DEFAULT ((0)),
	[Sabado] [float] NULL,
	[Domingo] [float] NULL,
	[PrecioVenta] [float] NULL,
	[TotalIngresos] [float] NULL,
	[IR] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_IR]  DEFAULT ((0)),
	[DeduccionPolicia] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_DeduccionPolicia]  DEFAULT ((0)),
	[Anticipo] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Anticipo]  DEFAULT ((0)),
	[DeduccionTransporte] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_DeduccionTransporte]  DEFAULT ((0)),
	[Pulperia] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Pulperia]  DEFAULT ((0)),
	[Inseminacion] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Inseminacion]  DEFAULT ((0)),
	[ProductosVeterinarios] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_ProductosVeterinarios]  DEFAULT ((0)),
	[Trazabilidad] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Trazabilidad]  DEFAULT ((0)),
	[OtrasDeducciones] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_OtrasDeducciones]  DEFAULT ((0)),
	[Nombres] [nvarchar](50) NULL,
	[Bolsa] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Bolsa]  DEFAULT ((0)),
	[PrecioLunes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioLunes]  DEFAULT ((0)),
	[PrecioMartes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioMartes]  DEFAULT ((0)),
	[PrecioMiercoles] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioMiercoles]  DEFAULT ((0)),
	[PrecioJueves] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioJueves]  DEFAULT ((0)),
	[PrecioViernes] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioViernes]  DEFAULT ((0)),
	[PrecioSabado] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioSabado]  DEFAULT ((0)),
	[PrecioDomingo] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_PrecioDomingo]  DEFAULT ((0)),
	[Total] [float] NULL CONSTRAINT [DF_Detalle_NominaLiquidacion_Total]  DEFAULT ((0)),
 CONSTRAINT [PK_Detalle_NominaLiquidacion] PRIMARY KEY CLUSTERED 
(
	[NumNomina] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


