/*
   sábado, 18 de abril de 202005:14:01 p.m.
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
ALTER TABLE dbo.TipoNomina ADD CONSTRAINT
	DF_TipoNomina_Activa DEFAULT 0 FOR Activa
GO
ALTER TABLE dbo.TipoNomina SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
