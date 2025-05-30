/*
   domingo, 6 de noviembre de 202211:34:44 a. m.
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
	Receta nvarchar(MAX) NULL
GO
ALTER TABLE dbo.Medicamentos_Consulta SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
