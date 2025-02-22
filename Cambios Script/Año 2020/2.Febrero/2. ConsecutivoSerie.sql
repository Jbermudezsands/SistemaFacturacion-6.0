/*
   miércoles, 05 de febrero de 202011:20:28 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionEMTRIDES
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
ALTER TABLE dbo.ConsecutivoSerie ADD
	SalidaBascula float(53) NULL,
	Cuenta float(53) NULL,
	Cuenta_CR float(53) NULL,
	OrdenSalida float(53) NULL
GO
ALTER TABLE dbo.ConsecutivoSerie ADD CONSTRAINT
	DF_ConsecutivoSerie_SalidaBascula DEFAULT 0 FOR SalidaBascula
GO
ALTER TABLE dbo.ConsecutivoSerie ADD CONSTRAINT
	DF_ConsecutivoSerie_Cuenta DEFAULT 0 FOR Cuenta
GO
ALTER TABLE dbo.ConsecutivoSerie ADD CONSTRAINT
	DF_ConsecutivoSerie_Cuenta_CR DEFAULT 0 FOR Cuenta_CR
GO
ALTER TABLE dbo.ConsecutivoSerie ADD CONSTRAINT
	DF_ConsecutivoSerie_OrdenSalida DEFAULT 0 FOR OrdenSalida
GO
ALTER TABLE dbo.ConsecutivoSerie SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
