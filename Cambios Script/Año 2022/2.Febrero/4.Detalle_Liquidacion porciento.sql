/*
   viernes, 4 de marzo de 202209:54:37
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionIncogasa
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
	Porciento nchar(10) NULL
GO
ALTER TABLE dbo.Detalle_Liquidacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
