/*
   lunes, 19 de diciembre de 201609:29:09 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaContableFincaSantaClara
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
ALTER TABLE dbo.Reportes ADD
	CodDepartamento nvarchar(50) NULL
GO
ALTER TABLE dbo.Reportes ADD CONSTRAINT
	DF_Reportes_CodDepartamento DEFAULT N'SDpto' FOR CodDepartamento
GO
COMMIT
