/*
   Sábado, 16 de Octubre de 201007:50:23 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionSystemsAndSolutions
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.Recibo ADD
	NombreCliente nvarchar(MAX) NULL,
	ApellidosCliente nvarchar(MAX) NULL,
	DireccionCliente nvarchar(MAX) NULL,
	TelefonoCliente nvarchar(MAX) NULL
GO
COMMIT
