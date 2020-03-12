
/****** Object:  Table [dbo].[FechaPlanilla]    Script Date: 12/03/2020 07:05:22 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FechaPlanilla](
	[idFechaPlanilla] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodTipoNomina] [nvarchar](50) NOT NULL,
	[FechaIni] [smalldatetime] NOT NULL,
	[FechaFin] [smalldatetime] NOT NULL,
	[Activa] [bit] NULL CONSTRAINT [DF_FechaPlanilla_Activa]  DEFAULT ((1)),
	[Año] [float] NULL,
	[TipoNomina] [nvarchar](50) NULL,
 CONSTRAINT [PK_FechaPlanilla] PRIMARY KEY CLUSTERED 
(
	[idFechaPlanilla] ASC,
	[CodTipoNomina] ASC,
	[FechaIni] ASC,
	[FechaFin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


