/*
   Martes, 14 de Diciembre de 201005:26:42 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionImportadora
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.PlantillaClientes
	(
	NumeroPlantilla nvarchar(50) NOT NULL,
	FechaPlantilla smalldatetime NOT NULL,
	Tipo_Plantilla nvarchar(50) NOT NULL,
	Cod_Cliente nvarchar(50) NULL,
	Nombre_Cliente nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.PlantillaClientes ADD CONSTRAINT
	PK_PlantillaClientes PRIMARY KEY CLUSTERED 
	(
	NumeroPlantilla,
	FechaPlantilla,
	Tipo_Plantilla
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
