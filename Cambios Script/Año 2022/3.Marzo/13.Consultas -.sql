/*
   martes, 17 de mayo de 202217:13:46
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
CREATE TABLE dbo.Consulta
	(
	IdConsulta int NOT NULL IDENTITY (1, 1),
	Numero_Expediente nvarchar(50) NULL,
	Fecha_Hora_Inicio smalldatetime NULL,
	Fecha_Hora_Fin smalldatetime NULL,
	Sintomas nvarchar(MAX) NULL,
	Diagnostico nvarchar(MAX) NULL,
	idPreConsulta int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Consulta ADD CONSTRAINT
	PK_Consulta PRIMARY KEY CLUSTERED 
	(
	IdConsulta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Consulta SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
