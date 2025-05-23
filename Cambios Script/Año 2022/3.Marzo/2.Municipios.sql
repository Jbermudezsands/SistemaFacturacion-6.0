/*
   jueves, 17 de marzo de 202209:39:26
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionFarmaciaJUIGALPA
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Municipio
	(
	IdMunicipio int NOT NULL IDENTITY (1, 1),
	Cod_Departamento nvarchar(50) NULL,
	Nombre_Municipio nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Municipio ADD CONSTRAINT
	PK_Municipio PRIMARY KEY CLUSTERED 
	(
	IdMunicipio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Municipio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
