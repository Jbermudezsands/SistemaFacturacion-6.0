/*
   miércoles, 01 de abril de 202005:57:25 p.m.
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
ALTER TABLE dbo.Detalle_Solicitud ADD
	Orden_Compra nvarchar(50) NULL,
	Comprado bit NULL
GO
ALTER TABLE dbo.Detalle_Solicitud ADD CONSTRAINT
	DF_Detalle_Solicitud_Comprado DEFAULT 0 FOR Comprado
GO
ALTER TABLE dbo.Detalle_Solicitud SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
