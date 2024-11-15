/*
   sábado, 06 de junio de 202004:53:48 p.m.
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
ALTER TABLE dbo.Facturas ADD
	MarcaRevalorizar bit NULL,
	QuitarCtaXCob bit NULL
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_MarcaRevalorizar DEFAULT 1 FOR MarcaRevalorizar
GO
ALTER TABLE dbo.Facturas ADD CONSTRAINT
	DF_Facturas_QuitarHistorial DEFAULT 0 FOR QuitarCtaXCob
GO
ALTER TABLE dbo.Facturas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
