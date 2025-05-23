/*
   martes, 17 de marzo de 202002:40:44 p.m.
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
ALTER TABLE dbo.Nomina ADD
	Marca bit NULL
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_Marca DEFAULT 0 FOR Marca
GO
ALTER TABLE dbo.Nomina SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
