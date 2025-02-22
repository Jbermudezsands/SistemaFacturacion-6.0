/*
   lunes, 02 de mayo de 201610:58:04 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionPlanoDigital
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
ALTER TABLE dbo.IndiceNota ADD
	Activo bit NULL,
	Contabilizado bit NULL
GO
ALTER TABLE dbo.IndiceNota ADD CONSTRAINT
	DF_IndiceNota_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.IndiceNota ADD CONSTRAINT
	DF_IndiceNota_Contabilizado DEFAULT 0 FOR Contabilizado
GO
ALTER TABLE dbo.IndiceNota SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
