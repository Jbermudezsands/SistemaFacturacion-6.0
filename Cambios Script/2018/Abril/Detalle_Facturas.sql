/*
   jueves, 19 de abril de 201809:50:23 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionPedrera
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
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	DF_Detalle_Facturas_Cantidad DEFAULT 0 FOR Cantidad
GO
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	DF_Detalle_Facturas_Precio_Unitario DEFAULT 0 FOR Precio_Unitario
GO
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	DF_Detalle_Facturas_Precio_Neto DEFAULT 0 FOR Precio_Neto
GO
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	DF_Detalle_Facturas_Importe DEFAULT 0 FOR Importe
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'CONTROL') as Contr_Per 