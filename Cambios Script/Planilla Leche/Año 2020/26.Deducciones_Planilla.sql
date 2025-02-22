/*
   miércoles, 22 de abril de 202010:28:35 a.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: SistemaFacturacionMulukuku
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
ALTER TABLE dbo.Deducciones_Planilla ADD
	ProductosVeterinarios float(53) NULL
GO
ALTER TABLE dbo.Deducciones_Planilla ADD CONSTRAINT
	DF_Deducciones_Planilla_ProductosVeterinarios DEFAULT 0 FOR ProductosVeterinarios
GO
ALTER TABLE dbo.Deducciones_Planilla SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
