/*
   jueves, 26 de marzo de 202008:49:40 p.m.
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
CREATE TABLE dbo.Solicitud_Compra
	(
	Numero_Solicitud nvarchar(50) NOT NULL,
	Fecha_Solicitud smalldatetime NULL,
	Fecha_Hora_Solicitud smalldatetime NULL,
	Gerencia_Solicitante nvarchar(250) NULL,
	Departamento_Solicitante nvarchar(50) NULL,
	Codigo_Rubro nvarchar(50) NULL,
	Concepto nvarchar(250) NULL,
	Estado_Solicitud nvarchar(10) NULL,
	Cod_Bodega nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Solicitud_Compra ADD CONSTRAINT
	DF_Solicitud_Compra_Estado_Solicitud DEFAULT N'Pendiente' FOR Estado_Solicitud
GO
ALTER TABLE dbo.Solicitud_Compra ADD CONSTRAINT
	PK_Solicitud_Compra PRIMARY KEY CLUSTERED 
	(
	Numero_Solicitud
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Solicitud_Compra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
