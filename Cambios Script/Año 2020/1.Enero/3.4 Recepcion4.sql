/*
   viernes, 24 de enero de 202007:19:28 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionManagua
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
ALTER TABLE dbo.Recepcion ADD
	Numero_Compra nvarchar(50) NULL,
	Tipo_Compra nvarchar(50) NULL,
	Fecha_Compra smalldatetime NULL
GO
ALTER TABLE dbo.Recepcion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
