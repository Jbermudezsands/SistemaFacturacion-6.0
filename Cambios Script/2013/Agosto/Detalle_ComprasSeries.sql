/*
   jueves, 29 de agosto de 201306:36:31 a.m.
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
CREATE TABLE dbo.Detalle_ComprasSeries
	(
	Id_Series numeric(18, 0) NOT NULL,
	Numero_Compra nvarchar(50) NOT NULL,
	Fecha_Compra smalldatetime NOT NULL,
	Tipo_Compra nvarchar(50) NOT NULL,
	Cod_Producto nvarchar(50) NULL,
	NSeries nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_ComprasSeries ADD CONSTRAINT
	PK_Detalle_ComprasSeries PRIMARY KEY CLUSTERED 
	(
	Id_Series,
	Numero_Compra,
	Fecha_Compra,
	Tipo_Compra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
