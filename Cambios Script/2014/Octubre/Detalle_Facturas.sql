/*
   domingo, 19 de octubre de 201402:23:22 p.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionDISTELSA
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
ALTER TABLE dbo.Detalle_Facturas ADD
	Costo_Unitario float(53) NULL
GO
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	DF_Detalle_Facturas_Costo_Unitario DEFAULT 0 FOR Costo_Unitario
GO
COMMIT
