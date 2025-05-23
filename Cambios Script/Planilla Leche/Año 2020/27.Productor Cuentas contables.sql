/*
   jueves, 23 de abril de 202001:17:56 p.m.
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
ALTER TABLE dbo.Productor ADD
	Cuenta_Banco nvarchar(50) NULL,
	Cuenta_IR nvarchar(50) NULL,
	Cuenta_Bolsa nvarchar(50) NULL,
	Cuenta_Anticipo nvarchar(50) NULL,
	Cuenta_Pulperia nvarchar(50) NULL,
	Cuenta_Transporte nvarchar(50) NULL,
	Cuenta_Inseminacion nvarchar(50) NULL,
	Cuenta_Trazabilidad nvarchar(50) NULL,
	Cuenta_Veterinario nvarchar(50) NULL,
	Cuenta_Otras nvarchar(50) NULL
GO
ALTER TABLE dbo.Productor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
