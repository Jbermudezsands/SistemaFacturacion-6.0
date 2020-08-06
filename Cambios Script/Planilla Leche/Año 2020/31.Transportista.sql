
/****** Object:  Table [dbo].[Transportista]    Script Date: 26/07/2020 09:37:16 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transportista](
	[CodigoTransportista] [nvarchar](50) NOT NULL,
	[NombreTransportista] [nvarchar](50) NULL,
	[TelefonoTransportista] [nvarchar](50) NULL,
	[DireccionTransportista] [nvarchar](50) NULL,
	[CuentaContable] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transportista] PRIMARY KEY CLUSTERED 
(
	[CodigoTransportista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


