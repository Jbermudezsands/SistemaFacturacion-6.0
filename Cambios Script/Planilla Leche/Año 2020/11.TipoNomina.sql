/****** Object:  Table [dbo].[TipoNomina]    Script Date: 12/03/2020 09:43:39 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoNomina](
	[CodTipoNomina] [nvarchar](50) NOT NULL,
	[TipoNomina] [nvarchar](50) NOT NULL,
	[Activa] [bit] NULL,
 CONSTRAINT [PK_TipoNomina_1] PRIMARY KEY CLUSTERED 
(
	[CodTipoNomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


