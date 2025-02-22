/*
   martes, 28 de abril de 202001:54:24 p.m.
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
CREATE TABLE dbo.GerenciaSolicitud
	(
	IdGerencia int NOT NULL IDENTITY (1, 1),
	GerenciaSolicitud nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.GerenciaSolicitud ADD CONSTRAINT
	PK_GerenciaSolicitud PRIMARY KEY CLUSTERED 
	(
	IdGerencia
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.GerenciaSolicitud SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
