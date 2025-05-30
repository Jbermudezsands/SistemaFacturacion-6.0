/*
   lunes, 04 de abril de 201612:04:32 a.m.
   Usuario: 
   Servidor: JUAN\SQL2012
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
ALTER TABLE dbo.Facturas ADD
	MontoRetencion1Porciento numeric(18, 2) NULL,
	MontoRetencion2Porciento numeric(18, 2) NULL
GO
ALTER TABLE dbo.Facturas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
