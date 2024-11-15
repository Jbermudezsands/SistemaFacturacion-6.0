/*
   miércoles, 15 de junio de 202205:24:37 p.m.
   User: 
   Server: JUANBERMUDEZ\SQL2019
   Database: SistemaFacturacionIncogasa
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
ALTER TABLE dbo.Proveedor ADD
	DiasCredito float(53) NULL,
	MonedaCredito float(53) NULL,
	Limite_Credito float(53) NULL,
	Credito_Disponible bit NULL
GO
ALTER TABLE dbo.Proveedor ADD CONSTRAINT
	DF_Proveedor_Credito_Disponible DEFAULT 0 FOR Credito_Disponible
GO
ALTER TABLE dbo.Proveedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
