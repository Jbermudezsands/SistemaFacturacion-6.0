/*
   domingo, 06 de septiembre de 202006:58:36 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionSAYCO
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
	MontoFactura float(53) NULL,
	AplicaFactura float(53) NULL,
	SaldoFactura float(53) NULL,
	TasaCambio float(53) NULL,
	Numero_Nota nvarchar(50) NULL
GO
ALTER TABLE dbo.DetalleReciboPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
