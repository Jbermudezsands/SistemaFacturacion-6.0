/*
   martes, 24 de mayo de 202211:17:50
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
ALTER TABLE dbo.PreConsultas ADD
	Peso float(53) NULL,
	Talla float(53) NULL
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_Peso DEFAULT 0 FOR Peso
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_Talla DEFAULT 0 FOR Talla
GO
ALTER TABLE dbo.PreConsultas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
