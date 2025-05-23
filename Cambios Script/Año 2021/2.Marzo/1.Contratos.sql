/*
   martes, 02 de marzo de 202104:51:50 p.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
   Base de datos: SistemaFacturacionEmtrides
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.Contratos
	(
	Numero_Contrato int NOT NULL IDENTITY (1, 1),
	Cod_Cliente nvarchar(50) NOT NULL,
	Tipo_Servicios1 nvarchar(50) NULL,
	Tipo_Servicios2 nvarchar(50) NULL,
	Frecuencia nvarchar(50) NULL,
	Inicio_Contrato smalldatetime NULL,
	Fin_Contrato smalldatetime NULL,
	Contacto_Administrativo nvarchar(50) NULL,
	Contacto_Operativo nvarchar(50) NULL,
	Precio_Unitario decimal(18, 2) NULL,
	Moneda nvarchar(50) NULL,
	Activo bit NULL,
	Anulado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	DF_Contratos_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.Contratos ADD CONSTRAINT
	PK_Contratos PRIMARY KEY CLUSTERED 
	(
	Numero_Contrato,
	Cod_Cliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Contratos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
