/*
   domingo, 03 de abril de 201611:22:58 a.m.
   Usuario: 
   Servidor: JUAN\SQL2012
   Base de datos: SistemaFacturacionDISTELSA
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
	Retener1Porciento bit NULL,
	Retener2Porciento bit NULL
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_Retener1Porciento DEFAULT 0 FOR Retener1Porciento
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_Retener2Porciento DEFAULT 0 FOR Retener2Porciento
GO
ALTER TABLE dbo.Facturas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
