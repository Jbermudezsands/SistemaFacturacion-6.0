
/****** Object:  Table [dbo].[Deducciones_Planilla]    Script Date: 12/03/2020 07:03:39 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Deducciones_Planilla](
	[IdDeduccion] [int] IDENTITY(1,1) NOT NULL,
	[NumNomina] [nvarchar](50) NOT NULL,
	[CodProductor] [nvarchar](50) NOT NULL,
	[TipoProductor] [nvarchar](50) NOT NULL,
	[NombreProductor] [nvarchar](50) NULL,
	[NoAnticipo] [nvarchar](50) NULL,
	[Anticipo] [float] NULL CONSTRAINT [DF_Deducciones_Planilla_Anticipo]  DEFAULT ((0)),
	[Transporte] [float] NULL CONSTRAINT [DF_Deducciones_Planilla_Transporte]  DEFAULT ((0)),
	[Pulperia] [float] NULL CONSTRAINT [DF_Deducciones_Planilla_Pulperia]  DEFAULT ((0)),
	[Inseminacion] [float] NULL CONSTRAINT [DF_Deducciones_Planilla_Inseminacion]  DEFAULT ((0)),
 CONSTRAINT [PK_Deducciones_Planilla] PRIMARY KEY CLUSTERED 
(
	[IdDeduccion] ASC,
	[NumNomina] ASC,
	[CodProductor] ASC,
	[TipoProductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


