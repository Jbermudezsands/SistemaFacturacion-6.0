/*
   martes, 20 de junio de 202305:18:56 p.m.
   User: 
   Server: JUANBERMUDEZ\SQL2019
   Database: SistemaFacturacionRestaurante
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
ALTER TABLE dbo.Lineas ADD
	Foto nvarchar(MAX) NULL
GO
ALTER TABLE dbo.Lineas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
