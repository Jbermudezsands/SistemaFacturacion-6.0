/*
   miércoles, 9 de noviembre de 202222:56:25 p. m.
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
CREATE TABLE dbo.Quirofano
	(
	IdQuirofano int NOT NULL IDENTITY (1, 1),
	Numero_Expediente nvarchar(50) NOT NULL,
	Fecha_Hora_Inicio smalldatetime NULL,
	Fecha_Hora_Fin smalldatetime NULL,
	Activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Quirofano ADD CONSTRAINT
	DF_Quirofano_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Quirofano ADD CONSTRAINT
	PK_Quirofano PRIMARY KEY CLUSTERED 
	(
	IdQuirofano,
	Numero_Expediente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Quirofano SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
