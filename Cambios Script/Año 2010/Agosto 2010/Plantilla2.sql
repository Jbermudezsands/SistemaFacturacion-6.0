/*
   Miércoles, 18 de Agosto de 201007:39:09 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionImportadora
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
ALTER TABLE dbo.Plantilla ADD CONSTRAINT
	DF_Plantilla_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Plantilla ADD CONSTRAINT
	DF_Plantilla_Cancelado DEFAULT 0 FOR Cancelado
GO
COMMIT
