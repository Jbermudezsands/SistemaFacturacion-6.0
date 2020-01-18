
GO

/****** Object:  Table [dbo].[ReciboCafePergamino]    Script Date: 18/09/2018 10:00:05 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ReciboCafePergamino](
	[IdReciboPergamino] [int] NOT NULL,
	[Codigo] [varchar](10) NULL,
	[Fecha] [datetime] NULL,
	[Observaciones] [varchar](500) NULL,
	[IdTipoCafe] [int] NULL,
	[IdCosecha] [int] NULL,
	[IdLocalidad] [int] NULL,
	[IdDano] [int] NULL,
	[IdFinca] [int] NULL,
	[IdTipoCompra] [int] NULL,
	[IdEstadoDocumento] [int] NULL,
	[IdProductor] [int] NULL,
	[IdUnidadMedida] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdLocalidadLiquidacion] [int] NULL,
	[SincronizadoECS] [bit] NULL,
	[FechaSincronizacion] [datetime] NULL,
	[FechaIngresoSistemas] [datetime] NULL,
	[Imei] [varchar](50) NULL,
	[IdPignorado] [int] NULL,
	[EsProductorManual] [int] NULL,
	[CedulaManual] [varchar](50) NULL,
	[ProductorManual] [varchar](50) NULL,
	[FincaManual] [varchar](300) NULL,
 CONSTRAINT [PK_ReciboCafePergamino] PRIMARY KEY CLUSTERED 
(
	[IdReciboPergamino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ReciboCafePergamino] ADD  CONSTRAINT [DF_ReciboCafePergamino_SincronizadoECS]  DEFAULT ((0)) FOR [SincronizadoECS]
GO


