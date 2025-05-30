/*
   martes, 3 de mayo de 202214:01:11
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
CREATE TABLE dbo.Admision
	(
	idAdminsion int NOT NULL IDENTITY (1, 1),
	Numero_Expediente nvarchar(50) NULL,
	Fecha_Hora smalldatetime NULL,
	Activo bit NULL,
	Procesado bit NULL,
	Cancelado bit NULL,
	idPreconsultas int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Admision ADD CONSTRAINT
	DF_Admision_Activo DEFAULT 0 FOR Activo
GO
ALTER TABLE dbo.Admision ADD CONSTRAINT
	DF_Admision_Procesado DEFAULT 0 FOR Procesado
GO
ALTER TABLE dbo.Admision ADD CONSTRAINT
	DF_Admision_Cancelado DEFAULT 0 FOR Cancelado
GO
ALTER TABLE dbo.Admision ADD CONSTRAINT
	DF_Admision_idPreconsultas DEFAULT 0 FOR idPreconsultas
GO
ALTER TABLE dbo.Admision ADD CONSTRAINT
	PK_Admision PRIMARY KEY CLUSTERED 
	(
	idAdminsion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Admision SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
