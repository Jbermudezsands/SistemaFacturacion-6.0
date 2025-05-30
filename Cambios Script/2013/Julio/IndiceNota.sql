/*
   domingo, 07 de julio de 201308:41:04 p.m.
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
CREATE TABLE dbo.IndiceNota
	(
	Numero_Nota nvarchar(50) NOT NULL,
	Fecha_Nota smalldatetime NOT NULL,
	Tipo_Nota nvarchar(50) NOT NULL,
	MonedaNota nvarchar(50) NULL,
	Cod_Cliente nvarchar(50) NULL,
	Nombre_Cliente nvarchar(MAX) NULL,
	Observaciones nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.IndiceNota ADD CONSTRAINT
	PK_IndiceNota PRIMARY KEY CLUSTERED 
	(
	Numero_Nota,
	Fecha_Nota,
	Tipo_Nota
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
