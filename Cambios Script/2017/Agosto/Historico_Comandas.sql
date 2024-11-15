/*
   jueves, 10 de agosto de 201706:23:54
   Usuario: 
   Servidor: DESKTOP-E2SQPU1\SQL2005
   Base de datos: FacturacionFincaSantaClara
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
CREATE TABLE dbo.Historico_Comandas
	(
	Id int NOT NULL IDENTITY (1, 1),
	IdContGuardado int NULL,
	Numero_Factura nvarchar(50) NULL,
	Cod_Producto nvarchar(50) NULL,
	Cantidad float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Historico_Comandas ADD CONSTRAINT
	PK_Historico_Comandas PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Historico_Comandas', 'Object', 'CONTROL') as Contr_Per 