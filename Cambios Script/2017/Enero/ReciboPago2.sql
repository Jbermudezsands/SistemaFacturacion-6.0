/*
   lunes, 30 de enero de 201704:04:28 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionFincaSantaClara
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
	Retencion1 nvarchar(2) NULL,
	Retencion2 nvarchar(2) NULL
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion1 DEFAULT N'0%' FOR Retencion1
GO
ALTER TABLE dbo.ReciboPago ADD CONSTRAINT
	DF_ReciboPago_Retencion2 DEFAULT N'0%' FOR Retencion2
GO
COMMIT
