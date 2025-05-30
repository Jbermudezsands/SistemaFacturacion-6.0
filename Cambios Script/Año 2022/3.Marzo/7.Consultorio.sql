/*
   lunes, 28 de marzo de 202215:08:36
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
CREATE TABLE dbo.Consultorio
	(
	IdConsultorio int NOT NULL IDENTITY (1, 1),
	Codigo_Minsa nvarchar(50) NULL,
	Nombre_Consultorio nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Consultorio ADD CONSTRAINT
	PK_Consultorio PRIMARY KEY CLUSTERED 
	(
	IdConsultorio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Consultorio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
