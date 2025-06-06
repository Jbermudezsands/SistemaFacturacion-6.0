/*
   domingo, 26 de julio de 202010:44:06 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionMulukuku
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
CREATE TABLE dbo.Detalle_NominaTransportista
	(
	NumNomina nvarchar(50) NOT NULL,
	CodigoTransportista nvarchar(50) NOT NULL,
	Lunes float(53) NULL,
	Martes float(53) NULL,
	Miercoles float(53) NULL,
	Jueves float(53) NULL,
	Viernes float(53) NULL,
	Sabado float(53) NULL,
	Domingo float(53) NULL,
	PrecioVenta float(53) NULL,
	TotalIngresos float(53) NULL,
	IR float(53) NULL,
	DeduccionPolicia float(53) NULL,
	Anticipo float(53) NULL,
	DeduccionTransporte float(53) NULL,
	Pulperia float(53) NULL,
	Inseminacion float(53) NULL,
	ProductosVeterinarios float(53) NULL,
	Trazabilidad float(53) NULL,
	OtrasDeducciones float(53) NULL,
	Nombres nvarchar(50) NULL,
	Bolsa float(53) NULL,
	PrecioLunes float(53) NULL,
	PrecioMartes float(53) NULL,
	PrecioMiercoles float(53) NULL,
	PrecioJueves float(53) NULL,
	PrecioViernes float(53) NULL,
	PrecioSabado float(53) NULL,
	PrecioDomingo float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_NominaTransportista ADD CONSTRAINT
	DF_Detalle_NominaTransportista_Lunes DEFAULT 0 FOR Lunes
GO
ALTER TABLE dbo.Detalle_NominaTransportista ADD CONSTRAINT
	DF_Detalle_NominaTransportista_Martes DEFAULT 0 FOR Martes
GO
ALTER TABLE dbo.Detalle_NominaTransportista ADD CONSTRAINT
	DF_Detalle_NominaTransportista_Miercoles DEFAULT 0 FOR Miercoles
GO
ALTER TABLE dbo.Detalle_NominaTransportista ADD CONSTRAINT
	DF_Detalle_NominaTransportista_Viernes DEFAULT 0 FOR Viernes
GO
ALTER TABLE dbo.Detalle_NominaTransportista ADD CONSTRAINT
	PK_Detalle_NominaTransportista PRIMARY KEY CLUSTERED 
	(
	NumNomina,
	CodigoTransportista
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_NominaTransportista SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
