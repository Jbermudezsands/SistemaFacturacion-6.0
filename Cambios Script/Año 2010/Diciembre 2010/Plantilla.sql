/*
   Miércoles, 15 de Diciembre de 201002:59:31 p.m.
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
ALTER TABLE dbo.Plantilla
	DROP CONSTRAINT FK_Plantilla_Bodegas
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Plantilla
	DROP CONSTRAINT DF_Plantilla_Activo
GO
ALTER TABLE dbo.Plantilla
	DROP CONSTRAINT DF_Plantilla_Cancelado
GO
CREATE TABLE dbo.Tmp_Plantilla
	(
	NumeroPlantilla nvarchar(50) NOT NULL,
	Fecha_Plantilla smalldatetime NOT NULL,
	Tipo_Plantilla nvarchar(50) NOT NULL,
	MonedaPlantilla nvarchar(50) NULL,
	Seleccion_Cliente nvarchar(50) NULL,
	Cod_Cliente nvarchar(50) NULL,
	Cod_Bodega nvarchar(50) NULL,
	Cod_Vendedor nvarchar(50) NULL,
	Nombre_Plantilla nvarchar(50) NULL,
	Apellido_Plantilla nvarchar(50) NULL,
	Direccion_Plantilla nvarchar(50) NULL,
	Telefono_Plantilla nvarchar(50) NULL,
	Dias_Vencimiento float(53) NULL,
	Observaciones nvarchar(MAX) NULL,
	Referencia_Plantilla nvarchar(MAX) NULL,
	Exonerado bit NULL,
	Descuento nvarchar(50) NULL,
	SubTotal float(53) NULL,
	IVA float(53) NULL,
	Pagado float(53) NULL,
	NetoPagar float(53) NULL,
	Activo bit NULL,
	Cancelado bit NULL,
	Cod_Cliente2 nvarchar(50) NULL,
	Nombre_Plantilla2 nvarchar(50) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Plantilla ADD CONSTRAINT
	DF_Plantilla_Activo DEFAULT ((1)) FOR Activo
GO
ALTER TABLE dbo.Tmp_Plantilla ADD CONSTRAINT
	DF_Plantilla_Cancelado DEFAULT ((0)) FOR Cancelado
GO
IF EXISTS(SELECT * FROM dbo.Plantilla)
	 EXEC('INSERT INTO dbo.Tmp_Plantilla (NumeroPlantilla, Fecha_Plantilla, Tipo_Plantilla, MonedaPlantilla, Seleccion_Cliente, Cod_Cliente, Cod_Bodega, Cod_Vendedor, Nombre_Plantilla, Apellido_Plantilla, Direccion_Plantilla, Telefono_Plantilla, Dias_Vencimiento, Observaciones, Referencia_Plantilla, Exonerado, Descuento, SubTotal, IVA, Pagado, NetoPagar, Activo, Cancelado, Cod_Cliente2, Nombre_Plantilla2)
		SELECT NumeroPlantilla, CONVERT(smalldatetime, Fecha_Plantilla), Tipo_Plantilla, MonedaPlantilla, Seleccion_Cliente, Cod_Cliente, Cod_Bodega, Cod_Vendedor, Nombre_Plantilla, Apellido_Plantilla, Direccion_Plantilla, Telefono_Plantilla, Dias_Vencimiento, Observaciones, Referencia_Plantilla, Exonerado, Descuento, SubTotal, IVA, Pagado, NetoPagar, Activo, Cancelado, Cod_Cliente2, Nombre_Plantilla2 FROM dbo.Plantilla WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Plantilla
GO
EXECUTE sp_rename N'dbo.Tmp_Plantilla', N'Plantilla', 'OBJECT' 
GO
ALTER TABLE dbo.Plantilla ADD CONSTRAINT
	PK_Plantilla PRIMARY KEY CLUSTERED 
	(
	NumeroPlantilla,
	Fecha_Plantilla,
	Tipo_Plantilla
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
