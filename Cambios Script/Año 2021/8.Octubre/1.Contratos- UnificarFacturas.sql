/*
   jueves, 28 de octubre de 202113:51:19
   Usuario: sa
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
	UnificarFacturas bit NULL
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_UnificarFacturas DEFAULT 0 FOR UnificarFacturas
GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
