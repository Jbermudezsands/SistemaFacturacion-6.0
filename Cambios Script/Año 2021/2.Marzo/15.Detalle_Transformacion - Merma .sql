/*
   martes, 30 de marzo de 202114:57:19
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
ALTER TABLE dbo.Detalle_Transformacion
	DROP CONSTRAINT DF_Detalle_Transformacion_Cantidad
GO
CREATE TABLE dbo.Tmp_Detalle_Transformacion
	(
	IdDetalleOrigen int NOT NULL IDENTITY (1, 1),
	TipoTransforma nvarchar(50) NOT NULL,
	Numero_Transforma nvarchar(50) NOT NULL,
	Codigo_Producto nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NULL,
	Cantidad numeric(18, 2) NULL,
	Numero_Compra_Salida nvarchar(50) NULL,
	Fecha_Compra_Salida smalldatetime NULL,
	Tipo_Compra_Salida nvarchar(50) NOT NULL,
	Merma numeric(18, 2) NULL,
	Basura numeric(18, 2) NULL,
	Porciento_Basura numeric(18, 2) NULL,
	Porciento_Merma numeric(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Detalle_Transformacion SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Detalle_Transformacion ADD CONSTRAINT
	DF_Detalle_Transformacion_Cantidad DEFAULT ((0)) FOR Cantidad
GO
SET IDENTITY_INSERT dbo.Tmp_Detalle_Transformacion ON
GO
IF EXISTS(SELECT * FROM dbo.Detalle_Transformacion)
	 EXEC('INSERT INTO dbo.Tmp_Detalle_Transformacion (IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad, Numero_Compra_Salida, Fecha_Compra_Salida, Tipo_Compra_Salida)
		SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad, Numero_Compra_Salida, Fecha_Compra_Salida, Tipo_Compra_Salida FROM dbo.Detalle_Transformacion WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Detalle_Transformacion OFF
GO
DROP TABLE dbo.Detalle_Transformacion
GO
EXECUTE sp_rename N'dbo.Tmp_Detalle_Transformacion', N'Detalle_Transformacion', 'OBJECT' 
GO
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	PK_Detalle_Transformacion PRIMARY KEY CLUSTERED 
	(
	IdDetalleOrigen,
	TipoTransforma,
	Numero_Transforma
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
