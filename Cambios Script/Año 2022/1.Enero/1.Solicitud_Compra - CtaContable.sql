/*
   viernes, 14 de enero de 202214:26:55
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionEmtrides
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
ALTER TABLE dbo.Solicitud_Compra ADD
	Solcitud_Cta_Contable bit NULL
GO
ALTER TABLE dbo.Solicitud_Compra ADD CONSTRAINT
	DF_Solicitud_Compra_Solcitud_Cta_Contable DEFAULT 0 FOR Solcitud_Cta_Contable
GO
ALTER TABLE dbo.Solicitud_Compra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
