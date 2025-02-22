/*
   jueves, 12 de marzo de 202010:08:56 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionMulukuku
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
ALTER TABLE dbo.Consecutivos ADD
	Planilla float(53) NULL
GO
ALTER TABLE dbo.Consecutivos ADD CONSTRAINT
	DF_Consecutivos_Planilla DEFAULT 0 FOR Planilla
GO
ALTER TABLE dbo.Consecutivos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
