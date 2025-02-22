/*
   jueves, 27 de septiembre de 201210:23:00 a.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionDATANIC
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
ALTER TABLE dbo.Impresion ADD
	Ancho float(53) NULL,
	Largo float(53) NULL
GO
ALTER TABLE dbo.Impresion ADD CONSTRAINT
	DF_Impresion_Ancho DEFAULT 8.5 FOR Ancho
GO
ALTER TABLE dbo.Impresion ADD CONSTRAINT
	DF_Impresion_Largo DEFAULT 11 FOR Largo
GO
COMMIT
