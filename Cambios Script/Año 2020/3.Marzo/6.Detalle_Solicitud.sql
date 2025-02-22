/*
   jueves, 26 de marzo de 202009:02:21 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionEMTRIDES
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
CREATE TABLE dbo.Detalle_Solicitud
	(
	Id_DetalleSolicitud int NOT NULL IDENTITY (1, 1),
	Numero_Solicitud nvarchar(50) NULL,
	Cod_Producto nvarchar(50) NULL,
	Descripcion_Producto nvarchar(250) NULL,
	Cantidad float(53) NULL,
	Autorizado bit NULL,
	Activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Solicitud ADD CONSTRAINT
	DF_Detalle_Solicitud_Autorizado DEFAULT 0 FOR Autorizado
GO
ALTER TABLE dbo.Detalle_Solicitud ADD CONSTRAINT
	DF_Detalle_Solicitud_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Detalle_Solicitud ADD CONSTRAINT
	PK_Detalle_Solicitud PRIMARY KEY CLUSTERED 
	(
	Id_DetalleSolicitud
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Detalle_Solicitud SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
