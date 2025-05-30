/*
   jueves, 03 de octubre de 201906:47:32 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
ALTER TABLE dbo.Detalle_Compras ADD
	Descripcion_Producto nvarchar(250) NULL
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Detalle_Compras', 'Object', 'CONTROL') as Contr_Per 