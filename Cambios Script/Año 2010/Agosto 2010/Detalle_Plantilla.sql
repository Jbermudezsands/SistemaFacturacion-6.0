/*
   Martes, 17 de Agosto de 201002:24:34 p.m.
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
CREATE TABLE dbo.Detalle_Plantilla
	(
	id_Detalle_Plantilla numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Numero_Plantilla nvarchar(50) NOT NULL,
	Fecha_Plantilla smalldatetime NOT NULL,
	Tipo_Plantilla nvarchar(50) NOT NULL,
	Cod_Producto nvarchar(50) NOT NULL,
    Descripcion_Producto nvarchar(MAX) NULL,
	Cantidad float(53) NULL,
	Precio_Unitario float(53) NULL,
	Descuento float(53) NULL,
	Precio_Neto float(53) NULL,
	Importe float(53) NULL,
	TasaCambio float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Plantilla ADD CONSTRAINT
	PK_Detalle_Plantilla PRIMARY KEY CLUSTERED 
	(
	id_Detalle_Plantilla,
	Numero_Plantilla,
	Fecha_Plantilla,
	Tipo_Plantilla,
	Cod_Producto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
