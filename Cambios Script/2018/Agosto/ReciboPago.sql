/*
   miércoles, 15 de agosto de 201804:02:58 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
	Retencion3 nvarchar(4) NULL,
	Retencion4 nvarchar(4) NULL,
	Retencion5 nvarchar(4) NULL,
	Retencion6 nvarchar(4) NULL,
	Retencion7 nvarchar(4) NULL
GO
COMMIT
