/*
   Lunes, 02 de Mayo de 201105:27:59 p.m.
   Usuario: 
   Servidor: CONSULTOR\SQL2005
   Base de datos: SistemaFacturacionInstituto
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
ALTER TABLE dbo.DetalleRecibo ADD
	TasaCambio float(53) NULL
GO
ALTER TABLE dbo.DetalleRecibo ADD CONSTRAINT
	DF_DetalleRecibo_TasaCambio DEFAULT 1 FOR TasaCambio
GO
COMMIT
