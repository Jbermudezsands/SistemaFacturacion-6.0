/*
   domingo, 01 de mayo de 201609:10:03 a.m.
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
ALTER TABLE dbo.Facturas ADD
	Referencia nvarchar(50) NULL
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_Referencia DEFAULT 00 FOR Referencia
GO
ALTER TABLE dbo.Facturas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
