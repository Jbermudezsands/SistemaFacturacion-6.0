/*
   Miércoles, 15 de Diciembre de 201003:00:30 p.m.
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
CREATE TABLE dbo.Tmp_PlantillaClientes
	(
	NumeroPlantilla nvarchar(50) NOT NULL,
	FechaPlantilla smalldatetime NOT NULL,
	Tipo_Plantilla nvarchar(50) NOT NULL,
	Cod_Cliente nvarchar(50) NOT NULL,
	Nombre_Cliente nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.PlantillaClientes)
	 EXEC('INSERT INTO dbo.Tmp_PlantillaClientes (NumeroPlantilla, FechaPlantilla, Tipo_Plantilla, Cod_Cliente, Nombre_Cliente)
		SELECT NumeroPlantilla, CONVERT(smalldatetime, FechaPlantilla), Tipo_Plantilla, Cod_Cliente, Nombre_Cliente FROM dbo.PlantillaClientes WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.PlantillaClientes
GO
EXECUTE sp_rename N'dbo.Tmp_PlantillaClientes', N'PlantillaClientes', 'OBJECT' 
GO
ALTER TABLE dbo.PlantillaClientes ADD CONSTRAINT
	PK_PlantillaClientes PRIMARY KEY CLUSTERED 
	(
	NumeroPlantilla,
	FechaPlantilla,
	Tipo_Plantilla,
	Cod_Cliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
