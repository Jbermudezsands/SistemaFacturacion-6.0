/*
   martes, 4 de mayo de 202108:08:26
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFOTO
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
CREATE TABLE dbo.Foto
	(
	Codigo nvarchar(50) NOT NULL,
	TipoFoto nvarchar(50) NOT NULL,
	Foto image NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Foto ADD CONSTRAINT
	PK_Foto PRIMARY KEY CLUSTERED 
	(
	Codigo,
	TipoFoto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Foto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
