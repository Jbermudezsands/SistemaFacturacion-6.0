/*
   jueves, 17 de marzo de 202210:01:16
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
CREATE TABLE dbo.Doctores
	(
	Codigo_Minsa nvarchar(50) NOT NULL,
	Nombre_Doctor nvarchar(50) NULL,
	Apellido_Doctor nvarchar(50) NULL,
	Telefono_Doctor nvarchar(50) NULL,
	Correo_Doctor nvarchar(50) NULL,
	Especialidad_Doctor nvarchar(50) NULL,
	Direccion_Doctor nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Doctores ADD CONSTRAINT
	PK_Doctores PRIMARY KEY CLUSTERED 
	(
	Codigo_Minsa
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Doctores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
