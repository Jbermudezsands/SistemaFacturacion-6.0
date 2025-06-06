/*
   Miércoles, 04 de Noviembre de 200908:07:25 a.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacion
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
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT FK_Facturas_Vendedores
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT FK_Facturas_Clientes
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_SubTotal
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_IVA
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_Pagado
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_NetoPagar
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_MontoCredito
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_Contabilizado
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_Activo
GO
ALTER TABLE dbo.Facturas
	DROP CONSTRAINT DF_Facturas_Cancelado
GO
CREATE TABLE dbo.Tmp_Facturas
	(
	Numero_Factura nvarchar(50) NOT NULL,
	Fecha_Factura smalldatetime NOT NULL,
	Tipo_Factura nvarchar(50) NOT NULL,
	MonedaFactura nvarchar(50) NULL,
	Cod_Cliente nvarchar(50) NULL,
	Cod_Bodega nvarchar(50) NULL,
	Cod_Vendedor nvarchar(50) NULL,
	Cod_Cajero nvarchar(50) NULL,
	Nombre_Cliente nvarchar(50) NULL,
	Apellido_Cliente nvarchar(50) NULL,
	Direccion_Cliente nvarchar(250) NULL,
	Telefono_Cliente nvarchar(50) NULL,
	Fecha_Vencimiento smalldatetime NULL,
	Observaciones nvarchar(150) NULL,
	Fecha_Envio smalldatetime NULL,
	Via_Envarque nvarchar(50) NULL,
	Descuento nvarchar(50) NULL,
	Fecha_Descuento smalldatetime NULL,
	Su_Referencia nvarchar(50) NULL,
	Nuestra_Referencia nvarchar(50) NULL,
	SubTotal float(53) NULL,
	IVA float(53) NULL,
	Pagado float(53) NULL,
	NetoPagar float(53) NULL,
	MontoCredito float(53) NULL,
	Contabilizado bit NULL,
	Activo bit NULL,
	Cancelado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_MonedaFactura DEFAULT N'Cordobas' FOR MonedaFactura
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_SubTotal DEFAULT ((0)) FOR SubTotal
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_IVA DEFAULT ((0)) FOR IVA
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_Pagado DEFAULT ((0)) FOR Pagado
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_NetoPagar DEFAULT ((0)) FOR NetoPagar
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_MontoCredito DEFAULT ((0)) FOR MontoCredito
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_Contabilizado DEFAULT ((0)) FOR Contabilizado
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_Activo DEFAULT ((1)) FOR Activo
GO
ALTER TABLE dbo.Tmp_Facturas ADD CONSTRAINT
	DF_Facturas_Cancelado DEFAULT ((0)) FOR Cancelado
GO
IF EXISTS(SELECT * FROM dbo.Facturas)
	 EXEC('INSERT INTO dbo.Tmp_Facturas (Numero_Factura, Fecha_Factura, Tipo_Factura, Cod_Cliente, Cod_Bodega, Cod_Vendedor, Cod_Cajero, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono_Cliente, Fecha_Vencimiento, Observaciones, Fecha_Envio, Via_Envarque, Descuento, Fecha_Descuento, Su_Referencia, Nuestra_Referencia, SubTotal, IVA, Pagado, NetoPagar, MontoCredito, Contabilizado, Activo, Cancelado)
		SELECT Numero_Factura, Fecha_Factura, Tipo_Factura, Cod_Cliente, Cod_Bodega, Cod_Vendedor, Cod_Cajero, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono_Cliente, Fecha_Vencimiento, Observaciones, Fecha_Envio, Via_Envarque, Descuento, Fecha_Descuento, Su_Referencia, Nuestra_Referencia, SubTotal, IVA, Pagado, NetoPagar, MontoCredito, Contabilizado, Activo, Cancelado FROM dbo.Facturas WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Detalle_MetodoFacturas
	DROP CONSTRAINT FK_Detalle_MetodoFacturas_Facturas
GO
ALTER TABLE dbo.Detalle_Facturas
	DROP CONSTRAINT FK_Detalle_Facturas_Facturas
GO
DROP TABLE dbo.Facturas
GO
EXECUTE sp_rename N'dbo.Tmp_Facturas', N'Facturas', 'OBJECT' 
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	PK_Facturas_1 PRIMARY KEY CLUSTERED 
	(
	Numero_Factura,
	Fecha_Factura,
	Tipo_Factura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	FK_Facturas_Clientes FOREIGN KEY
	(
	Cod_Cliente
	) REFERENCES dbo.Clientes
	(
	Cod_Cliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	FK_Facturas_Vendedores FOREIGN KEY
	(
	Cod_Vendedor
	) REFERENCES dbo.Vendedores
	(
	Cod_Vendedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_Facturas ADD CONSTRAINT
	FK_Detalle_Facturas_Facturas FOREIGN KEY
	(
	Numero_Factura,
	Fecha_Factura,
	Tipo_Factura
	) REFERENCES dbo.Facturas
	(
	Numero_Factura,
	Fecha_Factura,
	Tipo_Factura
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Detalle_MetodoFacturas ADD CONSTRAINT
	FK_Detalle_MetodoFacturas_Facturas FOREIGN KEY
	(
	Numero_Factura,
	Fecha_Factura,
	Tipo_Factura
	) REFERENCES dbo.Facturas
	(
	Numero_Factura,
	Fecha_Factura,
	Tipo_Factura
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
