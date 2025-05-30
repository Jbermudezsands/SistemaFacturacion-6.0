/*
   jueves, 16 de enero de 202002:59:43 p.m.
   Usuario: sa
   Servidor: ROSE\SQLEXPRESS2014
   Base de datos: FacturacionManagua
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
ALTER TABLE dbo.Proveedor ADD
	RUC nvarchar(50) NULL
GO
ALTER TABLE dbo.Proveedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
