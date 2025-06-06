/*
   lunes, 24 de mayo de 202109:49:37
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
CREATE TABLE dbo.Registro_Transporte_Detalle
	(
	Numero_Registro nvarchar(50) NOT NULL,
	Fecha_Registro datetime NOT NULL,
	Cod_Cliente nvarchar(50) NULL,
	Id_Conductor nvarchar(50) NULL,
	Id_Vehiculo nvarchar(50) NULL,
	Activo bit NULL,
	Anulado bit NULL,
	Procesado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Activo DEFAULT 0 FOR Activo
GO
ALTER TABLE dbo.Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Anulado DEFAULT 0 FOR Anulado
GO
ALTER TABLE dbo.Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Procesado DEFAULT 0 FOR Procesado
GO
ALTER TABLE dbo.Registro_Transporte_Detalle ADD CONSTRAINT
	PK_Registro_Transporte_Detalle PRIMARY KEY CLUSTERED 
	(
	Numero_Registro,
	Fecha_Registro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Registro_Transporte_Detalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
