/*
   lunes, 31 de marzo de 202510:03:45
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2022
   Base de datos: SistemaFacturacionRestaurante
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
ALTER TABLE dbo.Historico_Comandas ADD
	Anulada bit NULL
GO
ALTER TABLE dbo.Historico_Comandas ADD CONSTRAINT
	DF_Historico_Comandas_Anulada DEFAULT 0 FOR Anulada
GO
ALTER TABLE dbo.Historico_Comandas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
