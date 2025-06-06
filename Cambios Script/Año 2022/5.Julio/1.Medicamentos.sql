/*
   viernes, 4 de noviembre de 202219:06:59 p. m.
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
CREATE TABLE dbo.Medicamentos_Consulta
	(
	idMedicamentos int NOT NULL IDENTITY (1, 1),
	IdConsulta int NOT NULL,
	Cod_Productos nvarchar(50) NULL,
	Descripcion nvarchar(50) NULL,
	Cantidad nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Medicamentos_Consulta ADD CONSTRAINT
	PK_Medicamentos_Consulta PRIMARY KEY CLUSTERED 
	(
	idMedicamentos,
	IdConsulta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Medicamentos_Consulta SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
