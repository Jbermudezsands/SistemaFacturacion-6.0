/*
   jueves, 26 de diciembre de 201909:36:18 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
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
ALTER TABLE dbo.Vendedores ADD
	Comision1 decimal(18, 0) NULL,
	Comision2 decimal(18, 0) NULL,
	Recuperacion1 decimal(18, 0) NULL,
	Recuperacion2 decimal(18, 0) NULL,
	TipoComision nvarchar(50) NULL,
	GrupoVendedores nvarchar(50) NULL
GO
ALTER TABLE dbo.Vendedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
