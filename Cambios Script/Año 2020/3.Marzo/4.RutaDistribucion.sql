/*
   martes, 10 de marzo de 202001:55:30 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionManagua
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
CREATE TABLE dbo.Ruta_Distribucion
	(
	CodRuta nvarchar(50) NOT NULL,
	Nombre_Ruta nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Ruta_Distribucion ADD CONSTRAINT
	PK_Ruta_Distribucion PRIMARY KEY CLUSTERED 
	(
	CodRuta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Ruta_Distribucion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
