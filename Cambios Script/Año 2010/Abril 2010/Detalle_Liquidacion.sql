/*
   Jueves, 15 de Abril de 201002:28:20 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBuiler
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Detalle_Liquidacion
	(
	Id_Detalle_Liquidacion numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Numero_Liquidacion nvarchar(50) NOT NULL,
	Fecha_Liquidacion smalldatetime NOT NULL,
	Cod_Producto nvarchar(50) NULL,
	Cantidad float(53) NULL,
	Precio_Compra float(53) NULL,
	Descuento float(53) NULL,
	FOB float(53) NULL,
	Precio_Costo float(53) NULL,
	TasaCambio float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Liquidacion ADD CONSTRAINT
	DF_Detalle_Liquidacion_TasaCambio DEFAULT 0 FOR TasaCambio
GO
ALTER TABLE dbo.Detalle_Liquidacion ADD CONSTRAINT
	PK_Detalle_Liquidacion PRIMARY KEY CLUSTERED 
	(
	Id_Detalle_Liquidacion,
	Numero_Liquidacion,
	Fecha_Liquidacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
