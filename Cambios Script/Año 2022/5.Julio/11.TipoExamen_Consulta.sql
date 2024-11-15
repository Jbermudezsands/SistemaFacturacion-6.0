/*
   jueves, 10 de noviembre de 202217:41:11 p. m.
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
CREATE TABLE dbo.TipoExamen_Consulta
	(
	IdTipoExamen_Consulta int NOT NULL IDENTITY (1, 1),
	IdConsulta int NOT NULL,
	IdTipoExamen nvarchar(50) NULL,
	Descripcion nvarchar(250) NULL,
	Facturado bit NULL,
	Activo bit NULL,
	Pagado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TipoExamen_Consulta ADD CONSTRAINT
	DF_TipoExamen_Consulta_Facturado DEFAULT 0 FOR Facturado
GO
ALTER TABLE dbo.TipoExamen_Consulta ADD CONSTRAINT
	DF_TipoExamen_Consulta_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.TipoExamen_Consulta ADD CONSTRAINT
	DF_TipoExamen_Consulta_Pagado DEFAULT 0 FOR Pagado
GO
ALTER TABLE dbo.TipoExamen_Consulta ADD CONSTRAINT
	PK_TipoExamen_Consulta PRIMARY KEY CLUSTERED 
	(
	IdTipoExamen_Consulta,
	IdConsulta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TipoExamen_Consulta SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
