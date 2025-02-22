/*
   domingo, 07 de julio de 201309:11:43 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionQuimagro
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
CREATE TABLE dbo.Detalle_Nota
	(
	id_Detalle_Nota numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Numero_Nota nvarchar(50) NOT NULL,
	Fecha_Nota smalldatetime NOT NULL,
	Tipo_Nota nvarchar(50) NOT NULL,
	CodigoNB nvarchar(50) NULL,
	Descripcion nvarchar(50) NULL,
	Numero_Factura nvarchar(50) NULL,
	Monto float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Detalle_Nota ADD CONSTRAINT
	PK_Detalle_Nota PRIMARY KEY CLUSTERED 
	(
	id_Detalle_Nota,
	Numero_Nota,
	Fecha_Nota,
	Tipo_Nota
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
