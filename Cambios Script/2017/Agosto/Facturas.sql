/*
   lunes, 7 de agosto de 201712:53:06
   Usuario: 
   Servidor: DESKTOP-E2SQPU1\SQL2005
   Base de datos: FacturacionFincaSantaClara
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
ALTER TABLE dbo.Facturas ADD
	Propina float(53) NULL,
	CalculaPropina bit NULL
GO
COMMIT
