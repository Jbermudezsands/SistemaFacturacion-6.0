/*
   Miércoles, 29 de Septiembre de 201001:34:22 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionImportadora
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
CREATE TABLE dbo.ImpuestosLiquidacion
	(
	Numero_Liquidacion nvarchar(50) NOT NULL,
	Fecha_Liquidacion smalldatetime NOT NULL,
	Cod_Producto nvarchar(50) NOT NULL,
	Cod_Iva nvarchar(50) NOT NULL,
	Monto float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ImpuestosLiquidacion ADD CONSTRAINT
	PK_ImpuestosLiquidacion PRIMARY KEY CLUSTERED 
	(
	Numero_Liquidacion,
	Fecha_Liquidacion,
	Cod_Producto,
	Cod_Iva
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
