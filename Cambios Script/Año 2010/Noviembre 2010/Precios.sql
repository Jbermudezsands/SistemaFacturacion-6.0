/*
   Sábado, 06 de Noviembre de 201011:10:23 a.m.
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
CREATE TABLE dbo.Precios
	(
	Cod_Productos nvarchar(50) NOT NULL,
	Cod_TipoPrecio nvarchar(50) NOT NULL,
	Monto_Precio float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Precios ADD CONSTRAINT
	DF_Precios_Monto_Precio DEFAULT 0 FOR Monto_Precio
GO
ALTER TABLE dbo.Precios ADD CONSTRAINT
	PK_Precios PRIMARY KEY CLUSTERED 
	(
	Cod_Productos,
	Nombre_Precio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
