/*
   martes, 17 de marzo de 202010:41:04 a.m.
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
ALTER TABLE dbo.Deducciones_Planilla ADD
	Trazabilidad float(53) NULL,
	OtrasDeducciones float(53) NULL
GO
ALTER TABLE dbo.Deducciones_Planilla ADD CONSTRAINT
	DF_Deducciones_Planilla_Trazabilidad DEFAULT 0 FOR Trazabilidad
GO
ALTER TABLE dbo.Deducciones_Planilla ADD CONSTRAINT
	DF_Deducciones_Planilla_OtrasDeducciones DEFAULT 0 FOR OtrasDeducciones
GO
ALTER TABLE dbo.Deducciones_Planilla SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
