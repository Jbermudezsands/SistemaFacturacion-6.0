
/****** Object:  Table [dbo].[Nomina]    Script Date: 26/07/2020 09:59:30 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NominaTransportista](
	[NumPlanilla] [nvarchar](50) NOT NULL,
	[CodTipoNomina] [nvarchar](50) NULL,
	[FechaInicial] [smalldatetime] NULL,
	[FechaFinal] [smalldatetime] NULL,
	[Año] [float] NULL,
	[mes] [float] NULL,
	[Periodo] [float] NULL,
	[PorcientoIR] [float] NULL,
	[PorcientoPolicia] [float] ,
	[PrecioUnitario] [float] ,
	[Contabilizado] [bit] NULL ,
	[Marca] [bit] NULL ,
	[Activo] [bit] NULL ,
	[PrecioLunes] [float] NULL ,
	[PrecioMartes] [float] NULL ,
	[PrecioMiercoles] [float] NULL ,
	[PrecioJueves] [float] NULL ,
	[PrecioViernes] [float] NULL ,
	[PrecioSabado] [float] NULL ,
	[PrecioDomingo] [float] NULL ,
 CONSTRAINT [PK_NominaTransportista] PRIMARY KEY CLUSTERED 
(
	[NumPlanilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

