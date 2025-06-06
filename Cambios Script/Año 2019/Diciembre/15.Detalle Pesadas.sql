/*
   martes, 14 de mayo de 201903:53:53 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: TRANSPORTE_AGRANCHOGRANDE
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
CREATE TABLE dbo.Detalle_Pesadas
	(
	id_Eventos float(53) NOT NULL,
	NumeroRemision nvarchar(50) NOT NULL,
	Fecha smalldatetime NOT NULL,
	TipoRemision nvarchar(50) NOT NULL,
	TipoPesada nvarchar(50) NOT NULL,
	Cod_Productos nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NULL,
	Codigo_Beams nvarchar(50) NULL,
	Cantidad float(53) NULL,
	Unidad_Medida nvarchar(50) NULL,
	Liquidado bit NULL,
	Codigo_BeamsOrigen nvarchar(50) NULL,
	RecepcionBin nvarchar(50) NULL,
	Transferido bit NULL,
	Calidad nvarchar(50) NULL,
	Estado nvarchar(50) NULL,
	Precio float(53) NULL,
	PesoKg float(53) NULL,
	Tara float(53) NULL,
	PesoNetoLb float(53) NULL,
	PesoNetoKg float(53) NULL,
	QQ float(53) NULL,
	Calidad_Cafe nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Pesadas ADD CONSTRAINT
	DF_Detalle_Pesadas_Liquidado DEFAULT ((0)) FOR Liquidado
GO
ALTER TABLE dbo.Detalle_Pesadas ADD CONSTRAINT
	DF_Detalle_Pesadas_Transferido DEFAULT ((0)) FOR Transferido
GO
ALTER TABLE dbo.Detalle_Pesadas ADD CONSTRAINT
	DF_Detalle_Pesadas_Calidad_Cafe DEFAULT (N'AP1ra') FOR Calidad_Cafe
GO
ALTER TABLE dbo.Detalle_Pesadas ADD CONSTRAINT
	PK_Detalle_Pesadas PRIMARY KEY CLUSTERED 
	(
	id_Eventos,
	NumeroRemision,
	Fecha,
	TipoRemision,
	TipoPesada
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Pesadas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Detalle_Pesada', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Detalle_Pesada', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Detalle_Pesada', 'Object', 'CONTROL') as Contr_Per 