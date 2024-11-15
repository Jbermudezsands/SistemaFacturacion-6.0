/*
   jueves, 05 de diciembre de 201901:56:29 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionManagua
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
CREATE TABLE dbo.Conductor
	(
	Codigo varchar(50) NOT NULL,
	Nombre varchar(500) NULL,
	Cedula varchar(20) NULL,
	Licencia varchar(20) NULL,
	Activo bit NULL,
	ListaNegra bit NULL,
	RazonListaNegra varchar(2000) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Conductor ADD CONSTRAINT
	PK_Conductor PRIMARY KEY CLUSTERED 
	(
	Codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Conductor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
