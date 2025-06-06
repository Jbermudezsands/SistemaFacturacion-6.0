/*
   martes, 09 de marzo de 202109:59:59 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionEmtrides
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
ALTER TABLE dbo.Contratos ADD
	IdContrato1 int NULL,
	IdContrato2 int NULL
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_idContrato1 DEFAULT 0 FOR IdContrato1
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_IdContrato2 DEFAULT 0 FOR IdContrato2
GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
