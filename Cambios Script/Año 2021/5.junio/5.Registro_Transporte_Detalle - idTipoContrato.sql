/*
   martes, 3 de agosto de 202110:11:03
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
ALTER TABLE dbo.Registro_Transporte_Detalle
	DROP CONSTRAINT DF_Registro_Transporte_Detalle_Activo
GO
ALTER TABLE dbo.Registro_Transporte_Detalle
	DROP CONSTRAINT DF_Registro_Transporte_Detalle_Anulado
GO
ALTER TABLE dbo.Registro_Transporte_Detalle
	DROP CONSTRAINT DF_Registro_Transporte_Detalle_Procesado
GO
ALTER TABLE dbo.Registro_Transporte_Detalle
	DROP CONSTRAINT DF_Registro_Transporte_Detalle_idTipoContrato
GO
CREATE TABLE dbo.Tmp_Registro_Transporte_Detalle
	(
	Numero_Registro int NOT NULL IDENTITY (1, 1),
	Fecha_Registro datetime NOT NULL,
	Cod_Cliente nvarchar(50) NULL,
	Id_Conductor nvarchar(50) NULL,
	Id_Vehiculo nvarchar(50) NULL,
	Activo bit NULL,
	Anulado bit NULL,
	Procesado bit NULL,
	idTipoContrato int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Registro_Transporte_Detalle SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Activo DEFAULT ((1)) FOR Activo
GO
ALTER TABLE dbo.Tmp_Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Anulado DEFAULT ((0)) FOR Anulado
GO
ALTER TABLE dbo.Tmp_Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_Procesado DEFAULT ((0)) FOR Procesado
GO
ALTER TABLE dbo.Tmp_Registro_Transporte_Detalle ADD CONSTRAINT
	DF_Registro_Transporte_Detalle_idTipoContrato DEFAULT ((0)) FOR idTipoContrato
GO
SET IDENTITY_INSERT dbo.Tmp_Registro_Transporte_Detalle ON
GO
IF EXISTS(SELECT * FROM dbo.Registro_Transporte_Detalle)
	 EXEC('INSERT INTO dbo.Tmp_Registro_Transporte_Detalle (Numero_Registro, Fecha_Registro, Cod_Cliente, Id_Conductor, Id_Vehiculo, Activo, Anulado, Procesado, idTipoContrato)
		SELECT Numero_Registro, Fecha_Registro, Cod_Cliente, Id_Conductor, Id_Vehiculo, Activo, Anulado, Procesado, CONVERT(int, idTipoContrato) FROM dbo.Registro_Transporte_Detalle WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Registro_Transporte_Detalle OFF
GO
DROP TABLE dbo.Registro_Transporte_Detalle
GO
EXECUTE sp_rename N'dbo.Tmp_Registro_Transporte_Detalle', N'Registro_Transporte_Detalle', 'OBJECT' 
GO
ALTER TABLE dbo.Registro_Transporte_Detalle ADD CONSTRAINT
	PK_Registro_Transporte_Detalle PRIMARY KEY CLUSTERED 
	(
	Numero_Registro,
	Fecha_Registro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
