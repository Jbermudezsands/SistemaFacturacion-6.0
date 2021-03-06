/*
   jueves, 27 de agosto de 202010:20:28 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionSAYCO
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
ALTER TABLE dbo.Facturas ADD
	AplicarCtasXCobrar bit NULL
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_AplicarCtasXCobrar DEFAULT 0 FOR AplicarCtasXCobrar
GO
ALTER TABLE dbo.Facturas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
