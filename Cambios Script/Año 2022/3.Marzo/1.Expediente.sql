/*
   lunes, 14 de marzo de 202211:30:00
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
CREATE TABLE dbo.Expediente
	(
	Numero_Expediente nvarchar(50) NOT NULL,
	Nombres nvarchar(50) NULL,
	Apellidos nvarchar(50) NULL,
	Edad decimal(18, 0) NULL,
	Sexo nvarchar(50) NULL,
	Estado_Civil nvarchar(50) NULL,
	Escolaridad nvarchar(50) NULL,
	Ocupacion nvarchar(50) NULL,
	Telefono decimal(18, 0) NULL,
	Direccion nvarchar(250) NULL,
	Fecha_Ingreso smalldatetime NULL,
	Unidad_Salud nvarchar(50) NULL,
	Nombre_Padre nvarchar(50) NULL,
	Nombre_Madre nvarchar(50) NULL,
	IdLocalidad int NULL,
	IdMunicipio int NULL,
	Nombre_Emergencia nvarchar(50) NULL,
	Telefono_Emergencia numeric(18, 0) NULL,
	Direccion_Emergencia nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Expediente ADD CONSTRAINT
	PK_Expediente PRIMARY KEY CLUSTERED 
	(
	Numero_Expediente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Expediente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
