/*
   lunes, 30 de octubre de 202312:37:22 p.m.
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
ALTER TABLE dbo.Contenedor ADD
	Activo bit NULL
GO
ALTER TABLE dbo.Contenedor ADD CONSTRAINT
	DF_Contenedor_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Contenedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
