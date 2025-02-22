/*
   lunes, 21 de agosto de 202303:28:38 p.m.
   User: 
   Server: JUANBERMUDEZ\SQL2019
   Database: SistemaFacturacionEmtrides
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
CREATE TABLE dbo.Registros_PBI_Ventas
	(
	Codigo_Cliente nvarchar(50) NULL,
	Nombre_Cliente nvarchar(250) NULL,
	Numero_Factura nvarchar(50) NULL,
	Fecha_Factura smalldatetime NULL,
	Tipo_Factura nvarchar(50) NULL,
	Moneda_Factura nvarchar(50) NULL,
	Codigo_Producto nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NOT NULL,
	Cantidad nvarchar(50) NULL,
	Precio_Unitario float(53) NULL,
	Importe float(53) NULL,
	Costo_Unitario float(53) NULL,
	Monto_Tasa float(53) NULL,
	ImporteC$ float(53) NULL,
	Importe$ float(53) NULL,
	Fecha_Vence smalldatetime NULL,
	Dias_Credito float(53) NULL,
	Exonerado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Registros_PBI_Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
