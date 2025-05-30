/*
   domingo, 19 de abril de 201509:30:10 a.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
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
ALTER TABLE dbo.Liquidacion ADD
	GtoAgenteAduana float(53) NULL,
	GtoFletesInternos float(53) NULL,
	GtoCustodio float(53) NULL,
	GtoAduana float(53) NULL,
	GtoOtros float(53) NULL
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoAgenteAduana DEFAULT 0 FOR GtoAgenteAduana
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoFletesInternos DEFAULT 0 FOR GtoFletesInternos
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoCustodio DEFAULT 0 FOR GtoCustodio
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoAduana DEFAULT 0 FOR GtoAduana
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_GtoOtros DEFAULT 0 FOR GtoOtros
GO
COMMIT
