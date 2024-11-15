/*
   viernes, 14 de mayo de 202112:11:10
   Usuario: 
   Servidor: JUANBERMUDEZ
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
	Contrato_Variable bit NULL,
	Contrato_Variable2 bit NULL
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Contrato_Variable DEFAULT 0 FOR Contrato_Variable
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Contrato_Variable2 DEFAULT 0 FOR Contrato_Variable2
GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
