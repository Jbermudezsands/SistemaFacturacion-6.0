/*
   sábado, 13 de marzo de 202107:48:13 a.m.
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
ALTER TABLE dbo.DatosEmpresa ADD
	PedirCantEscaner bit NULL
GO
ALTER TABLE dbo.DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_PedirCantEscaner DEFAULT 0 FOR PedirCantEscaner
GO
ALTER TABLE dbo.DatosEmpresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
