/*
   Viernes, 10 de Septiembre de 201007:14:19 a.m.
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
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ModedaImprimeFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaCompra
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaImprimeCompra
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_SincronizarTasa
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_IvaProducto
GO
CREATE TABLE dbo.Tmp_DatosEmpresa
	(
	Nombre_Empresa nvarchar(150) NULL,
	Direccion_Empresa nvarchar(250) NULL,
	Numero_Ruc nvarchar(50) NULL,
	Telefono nvarchar(50) NULL,
	Ruta_Logo nvarchar(250) NULL,
	Conexion_Contabilidad nvarchar(250) NULL,
	MonedaFactura nvarchar(50) NULL,
	ModedaImprimeFactura nvarchar(50) NULL,
	MonedaCompra nvarchar(50) NULL,
	MonedaImprimeCompra nvarchar(50) NULL,
	SincronizarTasa bit NULL,
	IvaProducto nvarchar(50) NULL,
	NombreCliente nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaFactura DEFAULT (N'Cordobas') FOR MonedaFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ModedaImprimeFactura DEFAULT (N'Cordobas') FOR ModedaImprimeFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaCompra DEFAULT (N'Cordobas') FOR MonedaCompra
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaImprimeCompra DEFAULT (N'Cordobas') FOR MonedaImprimeCompra
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_SincronizarTasa DEFAULT ((0)) FOR SincronizarTasa
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_IvaProducto DEFAULT (N'Sumando IVA del Producto') FOR IvaProducto
GO
IF EXISTS(SELECT * FROM dbo.DatosEmpresa)
	 EXEC('INSERT INTO dbo.Tmp_DatosEmpresa (Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Telefono, Ruta_Logo, Conexion_Contabilidad, MonedaFactura, ModedaImprimeFactura, MonedaCompra, MonedaImprimeCompra, SincronizarTasa, IvaProducto)
		SELECT Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Telefono, Ruta_Logo, Conexion_Contabilidad, MonedaFactura, ModedaImprimeFactura, MonedaCompra, MonedaImprimeCompra, SincronizarTasa, IvaProducto FROM dbo.DatosEmpresa WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.DatosEmpresa
GO
EXECUTE sp_rename N'dbo.Tmp_DatosEmpresa', N'DatosEmpresa', 'OBJECT' 
GO
COMMIT
