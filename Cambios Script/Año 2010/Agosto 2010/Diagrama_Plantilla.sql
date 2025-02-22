/*
   Miércoles, 18 de Agosto de 201005:09:06 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionImportadora
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
ALTER TABLE dbo.Plantilla ADD CONSTRAINT
	FK_Plantilla_Bodegas FOREIGN KEY
	(
	Cod_Bodega
	) REFERENCES dbo.Bodegas
	(
	Cod_Bodega
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_Plantilla ADD CONSTRAINT
	FK_Detalle_Plantilla_Productos FOREIGN KEY
	(
	Cod_Producto
	) REFERENCES dbo.Productos
	(
	Cod_Productos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Detalle_Plantilla ADD CONSTRAINT
	FK_Detalle_Plantilla_Plantilla FOREIGN KEY
	(
	Numero_Plantilla,
	Fecha_Plantilla,
	Tipo_Plantilla
	) REFERENCES dbo.Plantilla
	(
	Numero_Plantilla,
	Fecha_Plantilla,
	Tipo_Plantilla
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
