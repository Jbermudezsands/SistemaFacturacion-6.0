/*
   lunes, 24 de mayo de 202109:14:10
   Usuario: 
   Servidor: JUANBERMUDEZ
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
CREATE TABLE dbo.Registro_Transporte
	(
	Numero_Registro nvarchar(50) NOT NULL,
	Fecha_Inicio datetime NULL,
	Fecha_Fin datetime NULL,
	Tipo_Servicios nvarchar(50) NULL,
	Numero_Factura nvarchar(50) NULL,
	Fecha_Factura datetime NULL,
	Tipo_Factura nvarchar(50) NULL,
	Activo bit NULL,
	Procesado bit NULL,
	Anulado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Registro_Transporte ADD CONSTRAINT
	DF_Registro_Transporte_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Registro_Transporte ADD CONSTRAINT
	DF_Registro_Transporte_Procesado DEFAULT 0 FOR Procesado
GO
ALTER TABLE dbo.Registro_Transporte ADD CONSTRAINT
	DF_Registro_Transporte_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.Registro_Transporte ADD CONSTRAINT
	PK_Registro_Transporte PRIMARY KEY CLUSTERED 
	(
	Numero_Registro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Registro_Transporte SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
