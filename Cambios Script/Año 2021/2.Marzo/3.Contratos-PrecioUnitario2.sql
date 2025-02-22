/*
   sábado, 06 de marzo de 202109:53:07 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
ALTER TABLE dbo.Contratos ADD
	Retencion1 bit NULL,
	Retencion2 bit NULL,
	Exonerado bit NULL,
	Referencia nvarchar(50) NULL,
	Observaciones nvarchar(250) NULL,
	Precio_Unitario2 decimal(18, 2) NULL,
	Inicio_Contrato2 smalldatetime NULL,
	Fin_Contrato2 smalldatetime NULL,
	Moneda2 nvarchar(50) NULL,
	Frecuencia2 nvarchar(50) NULL
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Retencion1 DEFAULT 0 FOR Retencion1
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Retencion2 DEFAULT 0 FOR Retencion2
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Exonerado DEFAULT 0 FOR Exonerado
GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
