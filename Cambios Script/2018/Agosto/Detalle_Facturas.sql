/*
   viernes, 31 de agosto de 201806:34:25 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
ALTER TABLE dbo.Detalle_Facturas ADD
	Numero_Lote nvarchar(50) NULL,
	Fecha_Vence smalldatetime NULL
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Detalle_Facturas', 'Object', 'CONTROL') as Contr_Per 