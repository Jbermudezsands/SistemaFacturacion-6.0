/*
   martes, 06 de diciembre de 201603:00:53 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionFincaSantaClara
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Acceso
	(
	IdAccesos int NOT NULL IDENTITY (1, 1),
	IdPerfil int NOT NULL,
	Acceso nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Acceso ADD CONSTRAINT
	PK_Acceso PRIMARY KEY CLUSTERED 
	(
	IdAccesos,
	IdPerfil
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
