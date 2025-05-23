/*
   Sábado, 02 de Octubre de 201010:06:27 a.m.
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
ALTER TABLE dbo.DatosEmpresa ADD
	ConsecutivoFacturaManual bit NULL
GO
ALTER TABLE dbo.DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ConsecutivoFacturaManual DEFAULT 0 FOR ConsecutivoFacturaManual
GO
COMMIT
