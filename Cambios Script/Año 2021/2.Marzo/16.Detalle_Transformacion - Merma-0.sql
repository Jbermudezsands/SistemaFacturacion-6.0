/*
   martes, 30 de marzo de 202114:59:18
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
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	DF_Detalle_Transformacion_Merma DEFAULT 0 FOR Merma
GO
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	DF_Detalle_Transformacion_Basura DEFAULT 0 FOR Basura
GO
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	DF_Detalle_Transformacion_Porciento_Basura DEFAULT 0 FOR Porciento_Basura
GO
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	DF_Detalle_Transformacion_Porciento_Merma DEFAULT 0 FOR Porciento_Merma
GO
ALTER TABLE dbo.Detalle_Transformacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
