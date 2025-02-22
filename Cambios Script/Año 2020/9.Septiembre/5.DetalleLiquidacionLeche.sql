/*
   martes, 08 de septiembre de 202005:02:12 p.m.
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
CREATE TABLE dbo.DetalleLiquidacionLeche
	(
	idDetalleLiquidacion int NOT NULL IDENTITY (1, 1),
	NumeroLiquidacion nvarchar(50) NOT NULL,
	Cod_Proveedor nvarchar(50) NULL,
	Nombre_Proveedor nvarchar(250) NULL,
	FechaEnvio smalldatetime NULL,
	Cantidad_Enviada float(53) NULL,
	CantidadRecibida float(53) NULL,
	Diferencia float(53) NULL,
	PorcientoAgua float(53) NULL,
	Litros_Agua float(53) NULL,
	Ajuste float(53) NULL,
	Precio_Unitario float(53) NULL,
	Total_Ingresos float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	PK_DetalleLiquidacionLeche PRIMARY KEY CLUSTERED 
	(
	idDetalleLiquidacion,
	NumeroLiquidacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.DetalleLiquidacionLeche SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
