/*
   miércoles, 05 de julio de 201701:27:04 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
CREATE TABLE dbo.Accesos
	(
	IdPerfil numeric(18, 0) NOT NULL,
	Modulo nvarchar(50) NOT NULL,
	Acceso nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Accesos ADD CONSTRAINT
	PK_Accesos PRIMARY KEY CLUSTERED 
	(
	IdPerfil,
	Modulo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
