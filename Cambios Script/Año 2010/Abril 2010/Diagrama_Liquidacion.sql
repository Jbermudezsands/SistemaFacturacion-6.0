/*
   Jueves, 15 de Abril de 201002:44:08 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBuiler
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
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_Liquidacion ADD CONSTRAINT
	FK_Detalle_Liquidacion_Liquidacion FOREIGN KEY
	(
	Numero_Liquidacion,
	Fecha_Liquidacion
	) REFERENCES dbo.Liquidacion
	(
	Numero_Liquidacion,
	Fecha_Liquidacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Detalle_Liquidacion ADD CONSTRAINT
	FK_Detalle_Liquidacion_Productos FOREIGN KEY
	(
	Cod_Producto
	) REFERENCES dbo.Productos
	(
	Cod_Productos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
