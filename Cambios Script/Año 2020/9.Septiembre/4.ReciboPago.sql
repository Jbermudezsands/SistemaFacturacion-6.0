/*
   domingo, 06 de septiembre de 202007:16:43 p.m.
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
ALTER TABLE dbo.ReciboPago ADD
	NombreProveedor nvarchar(50) NULL,
	ApellidosProveedor nvarchar(50) NULL,
	DireccionCliente nvarchar(250) NULL,
	TelefonoCliente nvarchar(50) NULL
GO
ALTER TABLE dbo.ReciboPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
