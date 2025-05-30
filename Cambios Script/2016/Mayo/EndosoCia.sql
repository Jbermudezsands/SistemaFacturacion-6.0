/*
   jueves, 26 de mayo de 201602:05:14 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionPlanoDigital
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
CREATE TABLE dbo.Endoso
	(
	Nombre nvarchar(50) NOT NULL,
	Telefono nvarchar(50) NULL,
	Correo nvarchar(50) NULL,
	Direccion nvarchar(200) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Endoso ADD CONSTRAINT
	PK_Endoso PRIMARY KEY CLUSTERED 
	(
	Nombre
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Endoso SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
