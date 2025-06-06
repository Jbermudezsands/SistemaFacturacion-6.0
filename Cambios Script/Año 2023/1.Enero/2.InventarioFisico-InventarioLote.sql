/*
   martes, 17 de enero de 202311:07:54 a. m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2019
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
ALTER TABLE dbo.InventarioFisico ADD
	InventarioLote bit NULL
GO
ALTER TABLE dbo.InventarioFisico ADD CONSTRAINT
	DF_InventarioFisico_InventarioLote DEFAULT 0 FOR InventarioLote
GO
ALTER TABLE dbo.InventarioFisico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
