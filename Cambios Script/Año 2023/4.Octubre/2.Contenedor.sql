/*
   lunes, 30 de octubre de 202311:06:25 a.m.
   User: 
   Server: JUANBERMUDEZ\SQL2019
   Database: SistemaFacturacionEmtrides
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
CREATE TABLE dbo.Contenedor
	(
	Codigo_Contenedor nvarchar(50) NOT NULL,
	Nombre_Contenedor nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Contenedor ADD CONSTRAINT
	PK_Contenedor PRIMARY KEY CLUSTERED 
	(
	Codigo_Contenedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Contenedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
