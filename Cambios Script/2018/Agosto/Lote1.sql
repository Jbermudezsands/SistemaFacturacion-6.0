/*
   jueves, 30 de agosto de 201804:27:25 p.m.
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
ALTER TABLE dbo.Lote ADD
	Activo bit NULL
GO
ALTER TABLE dbo.Lote ADD CONSTRAINT
	DF_Lote_Activo DEFAULT 1 FOR Activo
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Lote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'CONTROL') as Contr_Per 