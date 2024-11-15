/*
   jueves, 10 de noviembre de 202216:21:33 p. m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2019
   Base de datos: SistemaFacturacionMaternoInfantil
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
CREATE TABLE dbo.TipoExamen
	(
	IdTipoExamen int NOT NULL IDENTITY (1, 1),
	TipoExamen nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TipoExamen ADD CONSTRAINT
	PK_TipoExamen PRIMARY KEY CLUSTERED 
	(
	IdTipoExamen
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TipoExamen SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
