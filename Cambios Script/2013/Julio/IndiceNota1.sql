/*
   miércoles, 10 de julio de 201301:42:30 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionQuimagro
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
ALTER TABLE dbo.IndiceNota ADD
	Activo bit NOT NULL CONSTRAINT DF_IndiceNota_Activo DEFAULT 1,
	Contabilizado bit NULL
GO
ALTER TABLE dbo.IndiceNota ADD CONSTRAINT
	DF_IndiceNota_Contabilizado DEFAULT 0 FOR Contabilizado
GO
COMMIT
