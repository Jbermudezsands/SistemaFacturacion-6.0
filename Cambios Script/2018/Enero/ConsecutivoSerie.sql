/*
   jueves, 25 de enero de 201806:09:30 p.m.
   Usuario: 
   Servidor: CONTADOR\SQL2005
   Base de datos: SistemaFacturacionInversionPlazaLeon
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
ALTER TABLE dbo.ConsecutivoSerie ADD
	NotaDebitoProveedor float(53) NULL,
	NotaCreditoProveedor float(53) NULL
GO
COMMIT
