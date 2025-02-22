/*
   Martes, 13 de Abril de 201007:38:02 a.m.
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
ALTER TABLE dbo.Facturas ADD
	MetodoPago nvarchar(50) NULL
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_MetodoPago DEFAULT N'Credito' FOR MetodoPago
GO
COMMIT
