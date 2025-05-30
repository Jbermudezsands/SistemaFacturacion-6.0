/*
   martes, 02 de febrero de 202109:50:59 a.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionMulukuku
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
CREATE TABLE dbo.Transformacion
	(
	Numero_Transforma nvarchar(50) NOT NULL,
	Fecha_Transforma smalldatetime NULL,
	BodegaOrigen nvarchar(50) NULL,
	BodegaDestino nvarchar(50) NULL,
	Observaciones nvarchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Transformacion ADD CONSTRAINT
	PK_Transformacion PRIMARY KEY CLUSTERED 
	(
	Numero_Transforma
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Transformacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
