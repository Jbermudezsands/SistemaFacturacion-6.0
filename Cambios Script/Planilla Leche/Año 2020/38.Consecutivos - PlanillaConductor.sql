/*
   domingo, 02 de agosto de 202004:00:18 p.m.
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
	PlanillaConductor float(53) NULL
GO
ALTER TABLE dbo.Consecutivos ADD CONSTRAINT
	DF_Consecutivos_PlanillaConductor DEFAULT 0 FOR PlanillaConductor
GO
ALTER TABLE dbo.Consecutivos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
