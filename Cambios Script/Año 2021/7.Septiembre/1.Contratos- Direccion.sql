/*
   martes, 7 de septiembre de 202121:12:38
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
ALTER TABLE dbo.Contratos ADD
	Direccion nvarchar(250) NULL,
	Direccion2 nvarchar(250) NULL
GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
