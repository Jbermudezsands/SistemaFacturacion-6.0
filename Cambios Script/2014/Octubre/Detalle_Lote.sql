/*
   martes, 28 de octubre de 201408:38:15 a.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionRevetsa
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
CREATE TABLE dbo.Detalle_Lote
	(
	id_Detalle_Lote int NOT NULL IDENTITY (1, 1),
	Numero_Lote nvarchar(50) NOT NULL,
	Fecha smalldatetime NOT NULL,
	Tipo_Documento nvarchar(50) NOT NULL,
	Numero_Documento nvarchar(50) NOT NULL,
	FechaVence smalldatetime NULL,
	Codigo_Producto nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Lote ADD CONSTRAINT
	PK_Detalle_Lote PRIMARY KEY CLUSTERED 
	(
	id_Detalle_Lote
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
