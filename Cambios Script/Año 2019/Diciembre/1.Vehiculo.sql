/*
   jueves, 05 de diciembre de 201902:29:21 p.m.
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
CREATE TABLE dbo.Vehiculo
	(
	IdVehiculo int NOT NULL IDENTITY (1, 1),
	Placa varchar(20) NULL,
	Marca nvarchar(50) NULL,
	TipoVehiculo nvarchar(50) NULL,
	Activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Vehiculo ADD CONSTRAINT
	DF_Vehiculo_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Vehiculo ADD CONSTRAINT
	PK_Vehiculo PRIMARY KEY CLUSTERED 
	(
	IdVehiculo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Vehiculo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
