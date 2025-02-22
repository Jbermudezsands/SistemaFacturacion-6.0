/*
   martes, 8 de junio de 202110:00:04
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
ALTER TABLE dbo.Liquidacion ADD
	SSA float(53) NULL,
	TSI float(53) NULL,
	SPE float(53) NULL
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_SSA DEFAULT 0 FOR SSA
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_TSI DEFAULT 0 FOR TSI
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_SPE DEFAULT 0 FOR SPE
GO
ALTER TABLE dbo.Liquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
