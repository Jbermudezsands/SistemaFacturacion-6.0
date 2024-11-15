/*
   Domingo, 06 de Marzo de 201109:33:01 a.m.
   Usuario: 
   Servidor: CONSULTOR\SQL2005
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
	PK_TipoPrecio PRIMARY KEY CLUSTERED 
	(
	Cod_TipoPrecio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
