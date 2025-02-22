/*
   domingo, 07 de julio de 201306:30:49 a.m.
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
CREATE TABLE dbo.NotaDebito
	(
	CodigoNB nvarchar(50) NOT NULL,
	Tipo nvarchar(50) NULL,
	Descripcion nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.NotaDebito ADD CONSTRAINT
	PK_NotaDebito PRIMARY KEY CLUSTERED 
	(
	CodigoNB
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
