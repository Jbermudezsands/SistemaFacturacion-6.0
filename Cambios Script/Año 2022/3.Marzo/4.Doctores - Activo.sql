/*
   jueves, 17 de marzo de 202210:15:12
   Usuario: 
   Servidor: JUANBERMUDEZ
   Base de datos: SistemaFacturacionFarmaciaJUIGALPA
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
ALTER TABLE dbo.Doctores ADD
	Activo bit NULL
GO
ALTER TABLE dbo.Doctores ADD CONSTRAINT
	DF_Doctores_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Doctores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
