/*
   martes, 12 de noviembre de 201302:38:54 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionMADSA
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
ALTER TABLE dbo.Coordenadas ADD
	X28 float(53) NULL,
	Y28 float(53) NULL,
	X29 float(53) NULL,
	Y29 float(53) NULL,
	X30 float(53) NULL,
	Y30 float(53) NULL,
	X31 float(53) NULL,
	Y31 float(53) NULL,
	X32 float(53) NULL,
	Y32 float(53) NULL,
	X33 float(53) NULL,
	Y33 float(53) NULL,
	X34 float(53) NULL,
	Y34 float(53) NULL,
	X35 float(53) NULL,
	Y35 float(53) NULL,
	X36 float(53) NULL,
	Y36 float(53) NULL,
	X37 float(53) NULL,
	Y37 float(53) NULL,
	X38 float(53) NULL,
	Y38 float(53) NULL,
	X39 float(53) NULL,
	Y39 float(53) NULL,
	X40 float(53) NULL,
	Y40 float(53) NULL,
	Tasa nvarchar(50) NULL
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X28 DEFAULT 0 FOR X28
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y28 DEFAULT 0 FOR Y28
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X29 DEFAULT 0 FOR X29
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y29 DEFAULT 0 FOR Y29
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X30 DEFAULT 0 FOR X30
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y30 DEFAULT 0 FOR Y30
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X31 DEFAULT 0 FOR X31
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y31 DEFAULT 0 FOR Y31
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X32 DEFAULT 0 FOR X32
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y32 DEFAULT 0 FOR Y32
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X33 DEFAULT 0 FOR X33
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y33 DEFAULT 0 FOR Y33
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X34 DEFAULT 0 FOR X34
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y34 DEFAULT 0 FOR Y34
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X35 DEFAULT 0 FOR X35
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y35 DEFAULT 0 FOR Y35
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X36 DEFAULT 0 FOR X36
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y36 DEFAULT 0 FOR Y36
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X37 DEFAULT 0 FOR X37
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y37 DEFAULT 0 FOR Y37
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X38 DEFAULT 0 FOR X38
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y38 DEFAULT 0 FOR Y38
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X39 DEFAULT 0 FOR X39
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y39 DEFAULT 0 FOR Y39
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X40 DEFAULT 0 FOR X40
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y40 DEFAULT 0 FOR Y40
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Tasa DEFAULT N'%' FOR Tasa
GO
COMMIT
