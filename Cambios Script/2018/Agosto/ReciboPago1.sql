/*
   miércoles, 15 de agosto de 201804:05:02 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion3 DEFAULT N'0%' FOR Retencion3
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion4 DEFAULT N'0%' FOR Retencion4
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion5 DEFAULT N'0%' FOR Retencion5
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion6 DEFAULT N'0%' FOR Retencion6
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion7 DEFAULT N'0%' FOR Retencion7
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ReciboPago', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ReciboPago', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ReciboPago', 'Object', 'CONTROL') as Contr_Per 