/*
   viernes, 14 de febrero de 202516:55:45
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2022
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
ALTER TABLE dbo.Lote ADD
	Existencia float(53) NULL
GO
ALTER TABLE dbo.Lote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
