/*
   domingo, 22 de agosto de 202116:21:24
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
ALTER TABLE dbo.Conductor ADD
	Evacuaciones bit NULL
GO
ALTER TABLE dbo.Conductor ADD CONSTRAINT
	DF_Conductor_Evacuaciones DEFAULT 0 FOR Evacuaciones
GO
ALTER TABLE dbo.Conductor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
