/*
   miércoles, 03 de marzo de 202109:55:02 a.m.
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
ALTER TABLE dbo.Usuarios ADD
	RecibeNotificacion bit NULL
GO
ALTER TABLE dbo.Usuarios ADD CONSTRAINT
	DF_Usuarios_RecibeNotificacion DEFAULT 0 FOR RecibeNotificacion
GO
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
