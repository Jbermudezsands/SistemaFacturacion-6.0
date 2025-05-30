/*
   lunes, 30 de enero de 202316:00:38 p. m.
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
ALTER TABLE dbo.Quirofano ADD
	IdDoctor_CodigoMinsa nvarchar(50) NULL,
	Diagnostico nvarchar(MAX) NULL,
	Prontuario nvarchar(MAX) NULL,
	Anestecista_CodigoMinsa nvarchar(50) NULL,
	Ayudante_CodigoMinsa nvarchar(50) NULL,
	Tecnico_Quirofano nvarchar(50) NULL
GO
ALTER TABLE dbo.Quirofano SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
