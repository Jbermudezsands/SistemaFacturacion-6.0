/*
   jueves, 05 de diciembre de 201912:10:56 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionManagua
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revis areste script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Detalle_Recepcion
	(
	id_Eventos float(53) NOT NULL,
	NumeroRecepcion nvarchar(50) NOT NULL,
	TipoRecepcion nvarchar(50) NOT NULL,
	Cod_Productos nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NULL,
	Cantidad float(53) NULL,
	Unidad_Medida nvarchar(50) NULL,
	Transferido bit NULL,
	Estado nvarchar(50) NULL,
	Precio float(53) NULL,
	PesoKg float(53) NULL,
	Tara float(53) NULL,
	PesoNetoLb float(53) NULL,
	PesoNetoKg float(53) NULL,
	QQ float(53) NULL,
	Liquidado bit NULL,
	Codigo_Beams nvarchar(50) NULL,
	Codigo_BeamsOrigen nvarchar(50) NULL,
	RecepcionBin nvarchar(50) NULL,
	Calidad nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_Transferido DEFAULT ((0)) FOR Transferido
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_Liquidado DEFAULT ((0)) FOR Liquidado
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	PK_Detalle_Recepcion PRIMARY KEY CLUSTERED 
	(
	id_Eventos,
	NumeroRecepcion,
	TipoRecepcion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Recepcion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
