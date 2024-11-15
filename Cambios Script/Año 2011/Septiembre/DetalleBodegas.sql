/*
   martes, 06 de septiembre de 201108:48:26 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionNorteak
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
ALTER TABLE dbo.DetalleBodegas ADD
	Costo float(53) NULL,
	Ultimo_Precio_Compra float(53) NULL,
	Existencia_Dinero float(53) NULL,
	Existencia_Unidades float(53) NULL,
	Existencia_DineroDolar float(53) NULL
GO
ALTER TABLE dbo.DetalleBodegas ADD CONSTRAINT
	DF_DetalleBodegas_Costo DEFAULT 0 FOR Costo
GO
ALTER TABLE dbo.DetalleBodegas ADD CONSTRAINT
	DF_DetalleBodegas_Ultimo_Precio_Compra DEFAULT 0 FOR Ultimo_Precio_Compra
GO
ALTER TABLE dbo.DetalleBodegas ADD CONSTRAINT
	DF_DetalleBodegas_Existencia_Dinero DEFAULT 0 FOR Existencia_Dinero
GO
ALTER TABLE dbo.DetalleBodegas ADD CONSTRAINT
	DF_DetalleBodegas_Existencia_Unidades DEFAULT 0 FOR Existencia_Unidades
GO
ALTER TABLE dbo.DetalleBodegas ADD CONSTRAINT
	DF_DetalleBodegas_Existencia_DineroDolar DEFAULT 0 FOR Existencia_DineroDolar
GO
COMMIT
