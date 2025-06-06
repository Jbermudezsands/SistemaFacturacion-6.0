/*
   jueves, 24 de febrero de 202215:50:20
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
	Prorrateo_Peso bit NULL
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_Prorrateo_Peso DEFAULT 0 FOR Prorrateo_Peso
GO
ALTER TABLE dbo.Liquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
