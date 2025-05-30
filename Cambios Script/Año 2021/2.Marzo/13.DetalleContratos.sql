/*
   jueves, 18 de marzo de 202110:32:29 p.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionEmtrides
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
CREATE TABLE dbo.DetalleTipoCotrato
	(
	IdDetalleTipoContrato int NOT NULL IDENTITY (1, 1),
	IdTipoContrato int NOT NULL,
	NumeroContrato int NOT NULL,
	Cod_Productos nvarchar(50) NULL,
	Descripcion_Producto nvarchar(50) NULL,
	Cantidad float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DetalleTipoCotrato ADD CONSTRAINT
	DF_DetalleTipoCotrato_Cantidad DEFAULT 0 FOR Cantidad
GO
ALTER TABLE dbo.DetalleTipoCotrato ADD CONSTRAINT
	PK_DetalleTipoCotrato PRIMARY KEY CLUSTERED 
	(
	IdDetalleTipoContrato,
	IdTipoContrato,
	NumeroContrato
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.DetalleTipoCotrato SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
