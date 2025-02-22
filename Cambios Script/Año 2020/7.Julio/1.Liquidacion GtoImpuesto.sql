/*
   viernes, 10 de julio de 202009:44:53 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionSAYCO
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
	GtoImpuestos float(53) NULL
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoImpuestos DEFAULT 0 FOR GtoImpuestos
GO
ALTER TABLE dbo.Liquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
