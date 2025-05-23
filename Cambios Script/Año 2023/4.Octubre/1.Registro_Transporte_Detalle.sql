/*
   viernes, 27 de octubre de 202303:40:58 p.m.
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
ALTER TABLE dbo.Registro_Transporte_Detalle ADD
	Num_Cont_Evacuado nvarchar(50) NULL,
	Num_Cont_Colocado nvarchar(50) NULL
GO
ALTER TABLE dbo.Registro_Transporte_Detalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
