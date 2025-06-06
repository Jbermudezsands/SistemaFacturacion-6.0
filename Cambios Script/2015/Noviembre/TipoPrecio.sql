/*
   viernes, 13 de noviembre de 201507:56:16 p.m.
   Usuario: 
   Servidor: JUAN\SQL2012
   Base de datos: SistemaFactuacionBuhler
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
ALTER TABLE dbo.TipoPrecio ADD
	PrecioPorcentual bit NULL
GO
ALTER TABLE dbo.TipoPrecio ADD CONSTRAINT
	DF_TipoPrecio_PrecioPorcentual DEFAULT 0 FOR PrecioPorcentual
GO
ALTER TABLE dbo.TipoPrecio SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
