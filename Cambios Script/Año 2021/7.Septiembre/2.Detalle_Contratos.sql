/*
   jueves, 9 de septiembre de 202109:04:07
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionEmtrides
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Detalle_Contratos
	(
	IdDetalleContrato int NOT NULL IDENTITY (1, 1),
	Numero_Contrato int NOT NULL,
	IdContrato int NULL,
	Tipo_Servicios nvarchar(50) NULL,
	Frecuencia nvarchar(50) NULL,
	Inicio_Contrato smalldatetime NULL,
	Fin_Contrato smalldatetime NULL,
	Precio_Unitario decimal(18, 2) NULL,
	Moneda nvarchar(50) NULL,
	Activo bit NULL,
	Anulado bit NULL,
	Retencion1 bit NULL,
	Retencion2 bit NULL,
	Exonerado bit NULL,
	Referencia nvarchar(50) NULL,
	DiasFactura int NULL,
	CodBodega nvarchar(50) NULL,
	Contrato_Variable bit NULL,
	Direccion nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Precio_Unitario DEFAULT 0 FOR Precio_Unitario
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Retencion1 DEFAULT 0 FOR Retencion1
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Retencion2 DEFAULT 0 FOR Retencion2
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_Exonerado DEFAULT 0 FOR Exonerado
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	DF_Detalle_Contratos_DiasFactura DEFAULT 0 FOR DiasFactura
GO
ALTER TABLE dbo.Detalle_Contratos ADD CONSTRAINT
	PK_Detalle_Contratos PRIMARY KEY CLUSTERED 
	(
	IdDetalleContrato,
	Numero_Contrato
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
