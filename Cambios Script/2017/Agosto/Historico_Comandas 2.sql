/*
   viernes, 11 de agosto de 201702:00:56
   Usuario: 
   Servidor: DESKTOP-E2SQPU1\SQL2005
   Base de datos: FacturacionFincaSantaClara
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
ALTER TABLE dbo.Historico_Comandas ADD
	Descripcion_Producto nvarchar(50) NULL
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'CONTROL') as Contr_Per 