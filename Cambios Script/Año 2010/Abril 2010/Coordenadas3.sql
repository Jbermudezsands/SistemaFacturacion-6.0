/*
   Viernes, 30 de Abril de 201006:58:24 a.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBuiler
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
	X25 float(53) NULL,
	Y25 float(53) NULL,
	X26 float(53) NULL,
	Y26 float(53) NULL,
	X27 float(53) NULL,
	Y27 float(53) NULL,
	X28 float(53) NULL,
	Y28 float(53) NULL
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X25 DEFAULT 0 FOR X25
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y25 DEFAULT 0 FOR Y25
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X26 DEFAULT 0 FOR X26
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y26 DEFAULT 0 FOR Y26
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X27 DEFAULT 0 FOR X27
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y27 DEFAULT 0 FOR Y27
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_X28 DEFAULT 0 FOR X28
GO
ALTER TABLE dbo.Coordenadas ADD CONSTRAINT
	DF_Coordenadas_Y28 DEFAULT 0 FOR Y28
GO
COMMIT
