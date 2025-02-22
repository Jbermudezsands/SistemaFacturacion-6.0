/*
   jueves, 06 de octubre de 201102:24:04 p.m.
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
ALTER TABLE dbo.Bodegas ADD
	CuentaInventario nvarchar(50) NULL,
	CuentaIngresoAjustes nvarchar(50) NULL,
	CuentaGastosAjustes nvarchar(50) NULL,
	CuentaVentas nvarchar(50) NULL,
	CuentaCostos nvarchar(50) NULL
GO
COMMIT
