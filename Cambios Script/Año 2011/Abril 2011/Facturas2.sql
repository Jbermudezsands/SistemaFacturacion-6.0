/*
   Jueves, 07 de Abril de 201101:56:23 p.m.
   Usuario: 
   Servidor: CONSULTOR\SQL2005
   Base de datos: SistemaFacturacionInstituto
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
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_Numero_Factura DEFAULT 01/01/1900 FOR Numero_Factura
GO
COMMIT
