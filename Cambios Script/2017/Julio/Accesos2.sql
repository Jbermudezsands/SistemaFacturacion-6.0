/*
   viernes, 28 de julio de 201701:12:39 p.m.
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
CREATE TABLE dbo.Tmp_Accesos
	(
	IdPerfil numeric(18, 0) NOT NULL,
	Modulo nvarchar(50) NOT NULL,
	Acceso nvarchar(250) NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.Accesos)
	 EXEC('INSERT INTO dbo.Tmp_Accesos (IdPerfil, Modulo, Acceso)
		SELECT IdPerfil, Modulo, Acceso FROM dbo.Accesos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Accesos
GO
EXECUTE sp_rename N'dbo.Tmp_Accesos', N'Accesos', 'OBJECT' 
GO
ALTER TABLE dbo.Accesos ADD CONSTRAINT
	PK_Accesos PRIMARY KEY CLUSTERED 
	(
	IdPerfil,
	Modulo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
