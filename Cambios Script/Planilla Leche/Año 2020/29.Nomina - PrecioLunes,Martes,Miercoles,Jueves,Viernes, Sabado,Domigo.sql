/*
   viernes, 05 de junio de 202008:36:06 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionMulukuku
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
ALTER TABLE dbo.Nomina ADD
	PrecioLunes float(53) NULL,
	PrecioMartes float(53) NULL,
	PrecioMiercoles float(53) NULL,
	PrecioJueves float(53) NULL,
	PrecioViernes float(53) NULL,
	PrecioSabado float(53) NULL,
	PrecioDomingo float(53) NULL
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioLunes DEFAULT 0 FOR PrecioLunes
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioMartes DEFAULT 0 FOR PrecioMartes
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioMiercoles DEFAULT 0 FOR PrecioMiercoles
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioJueves DEFAULT 0 FOR PrecioJueves
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioViernes DEFAULT 0 FOR PrecioViernes
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioSabado DEFAULT 0 FOR PrecioSabado
GO
ALTER TABLE dbo.Nomina ADD CONSTRAINT
	DF_Nomina_PrecioDomingo DEFAULT 0 FOR PrecioDomingo
GO
ALTER TABLE dbo.Nomina SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
