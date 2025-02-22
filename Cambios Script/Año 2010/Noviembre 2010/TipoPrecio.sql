/*
   Sábado, 06 de Noviembre de 201012:44:51 p.m.
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
CREATE TABLE dbo.TipoPrecio
	(
	Cod_TipoPrecio nvarchar(50) NOT NULL,
	Tipo_Precio nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TipoPrecio ADD CONSTRAINT
	DF_TipoPrecio_Tipo_Precio DEFAULT N'Precio A' FOR Tipo_Precio
GO
ALTER TABLE dbo.TipoPrecio ADD CONSTRAINT
	PK_TipoPrecio PRIMARY KEY CLUSTERED 
	(
	Cod_TipoPrecio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
