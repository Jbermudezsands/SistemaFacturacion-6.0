/*
   martes, 23 de junio de 201507:17:20 a.m.
   Usuario: sa
   Servidor: JUAN\SQL2012
   Base de datos: SistemaFacturacionIMELNICSA
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
ALTER TABLE dbo.ReciboPago ADD
	Activo bit NULL,
	Contabilizado bit NULL,
	Marca bit NULL
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Contabilizado DEFAULT 0 FOR Contabilizado
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Marca DEFAULT 1 FOR Marca
GO
ALTER TABLE dbo.ReciboPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
