/*
   martes, 25 de octubre de 201101:30:29 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionNorteak
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
ALTER TABLE dbo.Detalle_Compras ADD
	id_Detalle_Transferencia float(53) NULL
GO
ALTER TABLE dbo.Detalle_Compras ADD CONSTRAINT
	DF_Detalle_Compras_id_Detalle_Transferencia DEFAULT 0 FOR id_Detalle_Transferencia
GO
COMMIT
