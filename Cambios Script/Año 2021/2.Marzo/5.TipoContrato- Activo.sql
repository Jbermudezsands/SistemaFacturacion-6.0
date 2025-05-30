/*
   martes, 09 de marzo de 202109:26:20 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
ALTER TABLE dbo.TipoContrato ADD
	Activo bit NULL
GO
ALTER TABLE dbo.TipoContrato ADD CONSTRAINT
	DF_TipoContrato_Activo DEFAULT 0 FOR Activo
GO
ALTER TABLE dbo.TipoContrato SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
