/*
   domingo, 13 de noviembre de 201104:02:53 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionSystemsAndSolutions
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
CREATE TABLE dbo.HistoricoCostos
	(
	IdDetalle numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Numero_Compra nvarchar(50) NOT NULL,
	Fecha_Compra smalldatetime NOT NULL,
	Tipo_Compra nvarchar(50) NOT NULL,
	CodProducto nvarchar(50) NOT NULL,
	CodBodega nvarchar(50) NULL,
	CostoUnitAnt float(53) NULL,
	CostoUnitNuevo float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.HistoricoCostos ADD CONSTRAINT
	DF_HistoricoCostos_CostoUnitAnt DEFAULT 0 FOR CostoUnitAnt
GO
ALTER TABLE dbo.HistoricoCostos ADD CONSTRAINT
	DF_Table_2_CostoUnitNuevo DEFAULT 0 FOR CostoUnitNuevo
GO
ALTER TABLE dbo.HistoricoCostos ADD CONSTRAINT
	PK_HistoricoCostos PRIMARY KEY CLUSTERED 
	(
	IdDetalle,
	Numero_Compra,
	Fecha_Compra,
	Tipo_Compra,
	CodProducto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
