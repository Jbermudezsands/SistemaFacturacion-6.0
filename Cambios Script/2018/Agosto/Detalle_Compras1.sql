/*
   domingo, 02 de septiembre de 201810:23:30 p.m.
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
ALTER TABLE dbo.Detalle_Compras
	DROP CONSTRAINT FK_Detalle_Compras_Productos
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Productos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Productos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Productos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_Compras
	DROP CONSTRAINT FK_Detalle_Compras_Compras
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Compras', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Compras', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Compras', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_Compras
	DROP CONSTRAINT DF_Detalle_Compras_TasaCambio
GO
ALTER TABLE dbo.Detalle_Compras
	DROP CONSTRAINT DF_Detalle_Compras_id_Detalle_Transferencia
GO
ALTER TABLE dbo.Detalle_Compras
	DROP CONSTRAINT DF_Detalle_Compras_Costo_Unitario
GO
CREATE TABLE dbo.Tmp_Detalle_Compras
	(
	id_Detalle_Compra numeric(18, 0) NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	Numero_Compra nvarchar(50) NOT NULL,
	Fecha_Compra smalldatetime NOT NULL,
	Tipo_Compra nvarchar(50) NOT NULL,
	Cod_Producto nvarchar(50) NULL,
	Cantidad float(53) NULL,
	Precio_Unitario float(53) NULL,
	Descuento float(53) NULL,
	Precio_Neto float(53) NULL,
	Importe float(53) NOT NULL,
	TasaCambio float(53) NULL,
	id_Detalle_Transferencia float(53) NULL,
	Costo_Unitario float(53) NULL,
	Numero_Lote nvarchar(50) NULL,
	Fecha_Vence nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_TasaCambio DEFAULT ((0)) FOR TasaCambio
GO
ALTER TABLE dbo.Tmp_Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_id_Detalle_Transferencia DEFAULT ((0)) FOR id_Detalle_Transferencia
GO
ALTER TABLE dbo.Tmp_Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_Costo_Unitario DEFAULT ((0)) FOR Costo_Unitario
GO
ALTER TABLE dbo.Tmp_Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_Numero_Lote DEFAULT N'SINLOTE' FOR Numero_Lote
GO
ALTER TABLE dbo.Tmp_Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_Fecha_Vence DEFAULT 01/01/1900 FOR Fecha_Vence
GO
SET IDENTITY_INSERT dbo.Tmp_Detalle_Compras ON
GO
IF EXISTS(SELECT * FROM dbo.Detalle_Compras)
	 EXEC('INSERT INTO dbo.Tmp_Detalle_Compras (id_Detalle_Compra, Numero_Compra, Fecha_Compra, Tipo_Compra, Cod_Producto, Cantidad, Precio_Unitario, Descuento, Precio_Neto, Importe, TasaCambio, id_Detalle_Transferencia, Costo_Unitario, Numero_Lote, Fecha_Vence)
		SELECT id_Detalle_Compra, Numero_Compra, Fecha_Compra, Tipo_Compra, Cod_Producto, Cantidad, Precio_Unitario, Descuento, Precio_Neto, Importe, TasaCambio, id_Detalle_Transferencia, Costo_Unitario, Numero_Lote, Fecha_Vence FROM dbo.Detalle_Compras WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Detalle_Compras OFF
GO
DROP TABLE dbo.Detalle_Compras
GO
EXECUTE sp_rename N'dbo.Tmp_Detalle_Compras', N'Detalle_Compras', 'OBJECT' 
GO
ALTER TABLE dbo.Detalle_Compras ADD CONSTRAINT
	PK_Detalle_Compras_1 PRIMARY KEY CLUSTERED 
	(
	id_Detalle_Compra,
	Numero_Compra,
	Fecha_Compra,
	Tipo_Compra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Compras WITH NOCHECK ADD CONSTRAINT
	FK_Detalle_Compras_Compras FOREIGN KEY
	(
	Numero_Compra,
	Fecha_Compra,
	Tipo_Compra
	) REFERENCES dbo.Compras
	(
	Numero_Compra,
	Fecha_Compra,
	Tipo_Compra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	 NOT FOR REPLICATION

GO
ALTER TABLE dbo.Detalle_Compras WITH NOCHECK ADD CONSTRAINT
	FK_Detalle_Compras_Productos FOREIGN KEY
	(
	Cod_Producto
	) REFERENCES dbo.Productos
	(
	Cod_Productos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	 NOT FOR REPLICATION

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'CONTROL') as Contr_Per 