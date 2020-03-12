
/****** Object:  Table [dbo].[Cooperativa]    Script Date: 12/03/2020 06:55:01 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cooperativa](
	[Cod_Cooperativa] [nvarchar](50) NOT NULL,
	[Nombre_Cooperativa] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cooperativa] PRIMARY KEY CLUSTERED 
(
	[Cod_Cooperativa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


