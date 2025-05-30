/*
   Miércoles, 29 de Septiembre de 201009:47:29 a.m.
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
CREATE TABLE dbo.ImpuestosProductos
	(
	Cod_Iva nvarchar(50) NOT NULL,
	Cod_Productos nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ImpuestosProductos ADD CONSTRAINT
	PK_ImpuestosProductos PRIMARY KEY CLUSTERED 
	(
	Cod_Iva,
	Cod_Productos
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
