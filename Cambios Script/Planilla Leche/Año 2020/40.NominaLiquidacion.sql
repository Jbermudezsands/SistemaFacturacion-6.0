/*
   martes, 08 de septiembre de 202003:04:50 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
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
CREATE TABLE dbo.LiquidacionLeche
	(
	NumeroLiquidacion nvarchar(50) NOT NULL,
	FechaInicio smalldatetime NULL,
	FechaFin smalldatetime NULL,
	Cod_Bodega nvarchar(50) NULL,
	Cod_Proveedor nvarchar(50) NULL,
	PorcientoIR float(53) NULL,
	PorcientoPolicia float(53) NULL,
	PrecioUnitario float(53) NULL,
	Activo bit NULL,
	Contabilizado bit NULL,
	Marca bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LiquidacionLeche ADD CONSTRAINT
	DF_LiquidacionLeche_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.LiquidacionLeche ADD CONSTRAINT
	DF_LiquidacionLeche_Contabilizado DEFAULT 0 FOR Contabilizado
GO
ALTER TABLE dbo.LiquidacionLeche ADD CONSTRAINT
	DF_LiquidacionLeche_Marca DEFAULT 1 FOR Marca
GO
ALTER TABLE dbo.LiquidacionLeche ADD CONSTRAINT
	PK_LiquidacionLeche PRIMARY KEY CLUSTERED 
	(
	NumeroLiquidacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LiquidacionLeche SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
