/*
   domingo, 6 de noviembre de 202211:29:24 a. m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2019
   Base de datos: SistemaFacturacionMaternoInfantil
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
ALTER TABLE dbo.Medicamentos_Consulta ADD
	Facturar bit NULL,
	Aular bit NULL
GO
ALTER TABLE dbo.Medicamentos_Consulta
	DROP CONSTRAINT DF_Medicamentos_Consulta_Seleccion
GO
ALTER TABLE dbo.Medicamentos_Consulta ADD CONSTRAINT
	DF_Medicamentos_Consulta_Facturar DEFAULT 1 FOR Facturar
GO
ALTER TABLE dbo.Medicamentos_Consulta ADD CONSTRAINT
	DF_Medicamentos_Consulta_Aular DEFAULT 0 FOR Aular
GO
ALTER TABLE dbo.Medicamentos_Consulta
	DROP COLUMN Seleccion
GO
ALTER TABLE dbo.Medicamentos_Consulta SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
