/*
   martes, 02 de febrero de 202101:57:31 p.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
CREATE TABLE dbo.Detalle_Transformacion
	(
	IdDetalleOrigen int NOT NULL IDENTITY (1, 1),
	TipoTransforma nvarchar(50) NOT NULL,
	Numero_Transforma nvarchar(50) NOT NULL,
	Codigo_Producto nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NULL,
	Cantidad numeric(18, 0) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Transformacion ADD CONSTRAINT
	PK_Detalle_Transformacion PRIMARY KEY CLUSTERED 
	(
	IdDetalleOrigen,
	TipoTransforma,
	Numero_Transforma
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Transformacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
