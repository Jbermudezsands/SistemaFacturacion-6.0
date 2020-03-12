
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Productor](
	[CodProductor] [nvarchar](50) NOT NULL,
	[TipoProductor] [nvarchar](50) NOT NULL,
	[NombreProductor] [nvarchar](max) NULL,
	[ApellidoProductor] [nvarchar](max) NULL,
	[FechaAdmision] [smalldatetime] NULL,
	[FechaNacimiento] [smalldatetime] NULL,
	[DireccionProductor] [nvarchar](max) NULL,
	[Sexo] [nvarchar](50) NULL,
	[CodEscolaridad] [nvarchar](50) NULL,
	[CodDepartamentos] [nvarchar](50) NULL,
	[CodCooperativa] [nvarchar](50) NULL,
	[CodRuta] [nvarchar](50) NULL,
	[NombreConyugue] [nvarchar](max) NULL,
	[NumeroHijos] [nvarchar](50) NULL,
	[Telefonos] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[CorreoElectronico] [nvarchar](max) NULL,
	[Comunidad] [nvarchar](50) NULL,
	[Edad] [nvarchar](50) NULL,
	[EstadoCivil] [nvarchar](50) NULL,
	[FuentesAgua] [bit] NULL CONSTRAINT [DF_Productor_FuentesAgua]  DEFAULT ((1)),
	[ViviendaPropia] [char](10) NULL CONSTRAINT [DF_Productor_ViviendaPropia]  DEFAULT ((1)),
	[DescripcionVivienda] [nvarchar](50) NULL,
	[TenenciaTierra] [nvarchar](50) NULL CONSTRAINT [DF_Productor_TenenciaTierra]  DEFAULT (N'Propia'),
	[AreadePasto] [nvarchar](50) NULL,
	[CantidadVacas] [float] NULL,
	[CantidadVaquillas] [float] NULL,
	[CantidadBueyes] [float] NULL,
	[CantidadTerrenos] [float] NULL,
	[TieneContrato] [bit] NULL CONSTRAINT [DF_Productor_TieneContrato]  DEFAULT ((1)),
	[Activo] [bit] NULL CONSTRAINT [DF_Productor_Activo]  DEFAULT ((1)),
	[CausaIVA] [bit] NULL CONSTRAINT [DF_Productor_CausaIVA]  DEFAULT ((1)),
	[CualEmpresa] [nvarchar](50) NULL,
	[Cod_Cuenta_Cliente] [nvarchar](50) NULL,
	[Cod_Cuenta_Proveedor] [nvarchar](50) NULL,
	[Limite_Credito] [nvarchar](50) NULL,
	[RUC] [nvarchar](50) NULL,
	[Credito_Disponible] [bit] NULL,
 CONSTRAINT [PK_Productor] PRIMARY KEY CLUSTERED 
(
	[CodProductor] ASC,
	[TipoProductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


