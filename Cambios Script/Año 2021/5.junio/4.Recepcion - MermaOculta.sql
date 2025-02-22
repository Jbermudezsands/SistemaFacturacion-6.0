/*
   miércoles, 23 de junio de 202111:37:14
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
ALTER TABLE dbo.Recepcion ADD
	CalcularMermaOculta bit NULL,
	CalcularMerma bit NULL
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_CalcularMermaOculta DEFAULT 0 FOR CalcularMermaOculta
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_CalcularMerma DEFAULT 0 FOR CalcularMerma
GO
ALTER TABLE dbo.Recepcion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
