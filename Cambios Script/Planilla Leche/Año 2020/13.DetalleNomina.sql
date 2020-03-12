
/****** Object:  Table [dbo].[Detalle_Nomina]    Script Date: 12/03/2020 10:11:27 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detalle_Nomina](
	[NumNomina] [nvarchar](50) NOT NULL,
	[CodProductor] [nvarchar](50) NOT NULL,
	[TipoProductor] [nvarchar](50) NOT NULL,
	[Roc1] [nvarchar](50) NULL,
	[Lunes] [float] NULL,
	[Roc2] [nvarchar](50) NULL,
	[Martes] [float] NULL,
	[Roc3] [nvarchar](50) NULL,
	[Miercoles] [float] NULL,
	[Roc4] [nvarchar](50) NULL,
	[Jueves] [float] NULL,
	[Roc5] [nvarchar](50) NULL,
	[Viernes] [float] NULL,
	[Roc6] [nvarchar](50) NULL,
	[Sabado] [float] NULL,
	[Roc7] [nvarchar](50) NULL,
	[Domingo] [float] NULL,
	[Total] [float] NULL,
	[PrecioVenta] [float] NULL,
	[TotalIngresos] [float] NULL,
	[IR] [float] NULL,
	[DeduccionPolicia] [float] NULL,
	[Anticipo] [float] NULL,
	[DeduccionTransporte] [float] NULL,
	[Pulperia] [float] NULL,
	[Inseminacion] [float] NULL,
	[ProductosVeterinarios] [float] NULL,
 CONSTRAINT [PK_DetalleNomina] PRIMARY KEY CLUSTERED 
(
	[NumNomina] ASC,
	[CodProductor] ASC,
	[TipoProductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Detalle_Nomina]  WITH CHECK ADD  CONSTRAINT [FK_DetalleNomina_Nomina] FOREIGN KEY([NumNomina])
REFERENCES [dbo].[Nomina] ([NumPlanilla])
GO

ALTER TABLE [dbo].[Detalle_Nomina] CHECK CONSTRAINT [FK_DetalleNomina_Nomina]
GO

ALTER TABLE [dbo].[Detalle_Nomina]  WITH CHECK ADD  CONSTRAINT [FK_DetalleNomina_Productor] FOREIGN KEY([CodProductor], [TipoProductor])
REFERENCES [dbo].[Productor] ([CodProductor], [TipoProductor])
GO

ALTER TABLE [dbo].[Detalle_Nomina] CHECK CONSTRAINT [FK_DetalleNomina_Productor]
GO


