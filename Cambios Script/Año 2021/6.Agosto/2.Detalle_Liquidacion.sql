/*
   martes, 17 de agosto de 202114:04:39
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionRevetsa
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
ALTER TABLE dbo.Detalle_Liquidacion ADD
	Fecha_Vence datetime NULL
GO
ALTER TABLE dbo.Detalle_Liquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
