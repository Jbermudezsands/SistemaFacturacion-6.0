
/****** Object:  Table [dbo].[Nomina]    Script Date: 12/03/2020 07:07:05 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nomina](
	[NumPlanilla] [nvarchar](50) NOT NULL,
	[CodTipoNomina] [nvarchar](50) NULL,
	[FechaInicial] [smalldatetime] NULL,
	[FechaFinal] [smalldatetime] NULL,
	[Año] [float] NULL,
	[mes] [float] NULL,
	[Periodo] [float] NULL,
	[PorcientoIR] [float] NULL CONSTRAINT [DF_Nomina_PorcientoIR]  DEFAULT ((3)),
	[PorcientoPolicia] [float] NULL CONSTRAINT [DF_Nomina_PorcientoPolicia]  DEFAULT ((2.5)),
	[PrecioUnitario] [float] NULL CONSTRAINT [DF_Nomina_PrecioUnitario]  DEFAULT ((0)),
 CONSTRAINT [PK_Nomina] PRIMARY KEY CLUSTERED 
(
	[NumPlanilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


