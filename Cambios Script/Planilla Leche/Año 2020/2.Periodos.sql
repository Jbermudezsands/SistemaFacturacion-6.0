

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Periodos](
	[Periodo] [tinyint] NOT NULL,
	[año] [smallint] NOT NULL,
	[mes] [smallint] NOT NULL,
	[TipoNomina] [nvarchar](50) NOT NULL,
	[Inicio] [smalldatetime] NULL,
	[Final] [smalldatetime] NULL,
	[Actual] [bit] NOT NULL CONSTRAINT [DF_Periodos_Actual]  DEFAULT ((0)),
	[Calculada] [bit] NULL CONSTRAINT [DF_Periodos_Calculada]  DEFAULT ((0)),
	[NumNomina] [nvarchar](50) NULL CONSTRAINT [DF_Periodos_NumNomina]  DEFAULT ((0)),
 CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED 
(
	[Periodo] ASC,
	[año] ASC,
	[mes] ASC,
	[TipoNomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


