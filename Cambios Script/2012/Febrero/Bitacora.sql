/*
   jueves, 09 de febrero de 201212:52:34 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBuhler
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
CREATE TABLE dbo.Bitacora
	(
	FechaRegistro nvarchar(100) NULL,
	Hora nvarchar(50) NULL,
	NombreUsuario nvarchar(100) NULL,
	Modulo nvarchar(100) NULL,
	Accion nvarchar(100) NULL
	)  ON [PRIMARY]
GO
COMMIT
