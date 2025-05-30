/*
   lunes, 21 de junio de 202113:06:35
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
ALTER TABLE dbo.Detalle_Recepcion ADD
	Merma2 float(53) NULL,
	PesoKg2 float(53) NULL,
	PesoNetoLb2 float(53) NULL,
	PesoNetoKg2 float(53) NULL
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_Merma2 DEFAULT 0 FOR Merma2
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_PesoKg2 DEFAULT 0 FOR PesoKg2
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_PesoNetoLb2 DEFAULT 0 FOR PesoNetoLb2
GO
ALTER TABLE dbo.Detalle_Recepcion ADD CONSTRAINT
	DF_Detalle_Recepcion_PesoNetoKg2 DEFAULT 0 FOR PesoNetoKg2
GO
ALTER TABLE dbo.Detalle_Recepcion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
