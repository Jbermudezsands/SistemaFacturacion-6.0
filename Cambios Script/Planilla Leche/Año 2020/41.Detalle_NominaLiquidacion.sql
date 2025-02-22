/*
   lunes, 14 de septiembre de 202007:11:49 a.m.
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
	Codigo_Productor nvarchar(50) NULL,
	Nombre_Productor nvarchar(50) NULL,
	Fecha smalldatetime NULL,
	Cantidad_Enviada float(53) NULL,
	Cantidad_Recibida float(53) NULL,
	Diferencia float(53) NULL,
	Agua float(53) NULL,
	Litros_Agua float(53) NULL,
	Ajuste_Cordobas float(53) NULL,
	TotalLitros float(53) NULL,
	Precio_Unitario float(53) NULL,
	Total_Ingresos float(53) NULL,
	Enfriamiento float(53) NULL,
	Transporte float(53) NULL,
	Ir float(53) NULL,
	Retencion float(53) NULL,
	Productos_Veterinarios float(53) NULL,
	Bolsa float(53) NULL,
	Anticipos float(53) NULL,
	Reembolso float(53) NULL,
	Pagos_Ant_Retenidos float(53) NULL,
	Total_Deducciones float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Cantidad_Enviada DEFAULT 0 FOR Cantidad_Enviada
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Cantidad_Recibida DEFAULT 0 FOR Cantidad_Recibida
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Diferencia DEFAULT 0 FOR Diferencia
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Agua DEFAULT 0 FOR Agua
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Litros_Agua DEFAULT 0 FOR Litros_Agua
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Ajuste_Cordobas DEFAULT 0 FOR Ajuste_Cordobas
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_TotalLitros DEFAULT 0 FOR TotalLitros
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Precio_Unitario DEFAULT 0 FOR Precio_Unitario
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Total_Ingresos DEFAULT 0 FOR Total_Ingresos
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Enfriamiento DEFAULT 0 FOR Enfriamiento
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Transporte DEFAULT 0 FOR Transporte
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Ir DEFAULT 0 FOR Ir
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Retencion DEFAULT 0 FOR Retencion
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Productos_Veterinarios DEFAULT 0 FOR Productos_Veterinarios
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Bolsa DEFAULT 0 FOR Bolsa
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Anticipos DEFAULT 0 FOR Anticipos
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Reembolso DEFAULT 0 FOR Reembolso
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Pagos_Ant_Retenidos DEFAULT 0 FOR Pagos_Ant_Retenidos
GO
ALTER TABLE dbo.DetalleLiquidacionLeche ADD CONSTRAINT
	DF_DetalleLiquidacionLeche_Total_Deducciones DEFAULT 0 FOR Total_Deducciones
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
