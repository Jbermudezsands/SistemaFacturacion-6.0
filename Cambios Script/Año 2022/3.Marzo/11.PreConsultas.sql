/*
   miércoles, 4 de mayo de 202211:56:20
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
CREATE TABLE dbo.PreConsultas
	(
	idPreConsulta int NOT NULL IDENTITY (1, 1),
	Numero_Expediente nvarchar(50) NULL,
	Fecha_Hora smalldatetime NULL,
	Sistolica float(53) NULL,
	Diastolica float(53) NULL,
	Temperatura float(53) NULL,
	Azucar_Sangre float(53) NULL,
	Activo bit NULL,
	Procesado bit NULL,
	Anulado bit NULL,
	idAdmision int NULL,
	iIdConsultas int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_Activo DEFAULT 0 FOR Activo
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_Procesado DEFAULT 0 FOR Procesado
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_idPreConsultas DEFAULT 0 FOR idAdmision
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	DF_PreConsultas_IdConsultas DEFAULT 0 FOR iIdConsultas
GO
ALTER TABLE dbo.PreConsultas ADD CONSTRAINT
	PK_PreConsultas PRIMARY KEY CLUSTERED 
	(
	idPreConsulta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PreConsultas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
