/*
   martes, 02 de febrero de 202110:19:54 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
ALTER TABLE dbo.Transformacion ADD
	Activo bit NULL,
	Procesado bit NULL,
	Anulado bit NULL
GO
ALTER TABLE dbo.Transformacion ADD CONSTRAINT
	DF_Transformacion_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Transformacion ADD CONSTRAINT
	DF_Transformacion_Procesado DEFAULT 0 FOR Procesado
GO
ALTER TABLE dbo.Transformacion ADD CONSTRAINT
	DF_Transformacion_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.Transformacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
