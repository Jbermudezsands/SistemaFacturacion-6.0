
/****** Object:  Table [dbo].[Medicamentos_Consulta]    Script Date: 09/02/2023 14:20:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Medicamentos_Quirofano](
	[idMedicamentos] [int] IDENTITY(1,1) NOT NULL,
	[IdConsulta] [nvarchar](50) NOT NULL,
	[Cod_Productos] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Cantidad] [nvarchar](50) NULL,
	[Receta] [nvarchar](max) NULL,
	[Numero_Factura] [nvarchar](50) NULL,
	[Facturar] [bit] NULL,
	[Aular] [bit] NULL,
 CONSTRAINT [PK_Medicamentos_Quirofano] PRIMARY KEY CLUSTERED 
(
	[idMedicamentos] ASC,
	[IdConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Medicamentos_Quirofano] ADD  CONSTRAINT [DF_Medicamentos_Quirofano_Facturar]  DEFAULT ((1)) FOR [Facturar]
GO

ALTER TABLE [dbo].[Medicamentos_Quirofano] ADD  CONSTRAINT [DF_Medicamentos_Quirofano_Aular]  DEFAULT ((0)) FOR [Aular]
GO


