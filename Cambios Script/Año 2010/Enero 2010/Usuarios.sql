/*
   Domingo, 07 de Marzo de 201009:21:47 a.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacion
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
CREATE TABLE dbo.Tmp_Usuarios
	(
	Usuario nvarchar(50) NULL,
	Contraseña nvarchar(50) NULL,
	Nivel nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.Usuarios)
	 EXEC('INSERT INTO dbo.Tmp_Usuarios (Usuario, Contraseña, Nivel)
		SELECT Usuario, Contraseña, CONVERT(nvarchar(MAX), Nivel) FROM dbo.Usuarios WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Usuarios
GO
EXECUTE sp_rename N'dbo.Tmp_Usuarios', N'Usuarios', 'OBJECT' 
GO
COMMIT
