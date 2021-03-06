/*
   domingo, 17 de mayo de 202005:00:40 p.m.
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
ALTER TABLE dbo.DetalleReciboPago ADD
	MontoRetencion float(53) NULL
GO
ALTER TABLE dbo.DetalleReciboPago ADD CONSTRAINT
	DF_DetalleReciboPago_MontoRetencion DEFAULT 0 FOR MontoRetencion
GO
ALTER TABLE dbo.DetalleReciboPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
