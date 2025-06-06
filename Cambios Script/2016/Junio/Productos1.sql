/*
   jueves, 30 de junio de 201605:06:37 p.m.
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
ALTER TABLE dbo.Productos ADD
	Rendimiento float(53) NULL
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	DF_Productos_Rendimiento DEFAULT 0 FOR Rendimiento
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
