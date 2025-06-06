/*
   jueves, 18 de noviembre de 202110:02:48
   Usuario: sa
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionGecko
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
ALTER TABLE dbo.Detalle_ComprasSeries ADD
	NSeries2 nvarchar(50) NULL,
	NSeries3 nvarchar(50) NULL,
	NSeries4 nvarchar(50) NULL
GO
ALTER TABLE dbo.Detalle_ComprasSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
