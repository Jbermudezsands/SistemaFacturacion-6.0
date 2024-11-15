/*
   domingo, 12 de julio de 201502:15:32 p.m.
   Usuario: 
   Servidor: JUAN\SQL2012
   Base de datos: SistemaFacturacionDISTELSA
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
CREATE TABLE dbo.Proyectos
	(
	CodigoProyectos nvarchar(50) NOT NULL,
	NombreProyectos nvarchar(250) NULL,
	FechaInicio smalldatetime NULL,
	FechaFin smalldatetime NULL,
	Moneda nvarchar(50) NULL,
	VentaEstimada float(53) NULL,
	CostoEstimado float(53) NULL,
	Activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Proyectos ADD CONSTRAINT
	DF_Proyectos_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Proyectos ADD CONSTRAINT
	PK_Proyectos PRIMARY KEY CLUSTERED 
	(
	CodigoProyectos
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Proyectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
