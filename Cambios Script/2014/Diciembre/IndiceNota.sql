/*
   martes, 17 de marzo de 201502:33:03 p.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBlanco
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
ALTER TABLE dbo.IndiceNota ADD
	Marca bit NULL
GO
ALTER TABLE dbo.IndiceNota ADD CONSTRAINT
	DF_IndiceNota_Marca DEFAULT 0 FOR Marca
GO
COMMIT
