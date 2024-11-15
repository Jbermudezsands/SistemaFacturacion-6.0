/*
   domingo, 19 de abril de 201510:03:05 a.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
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
ALTER TABLE dbo.Detalle_Liquidacion ADD
	Gasto_Compra float(53) NULL
GO
ALTER TABLE dbo.Detalle_Liquidacion ADD CONSTRAINT
	DF_Detalle_Liquidacion_Gasto_Compra DEFAULT 0 FOR Gasto_Compra
GO
COMMIT
