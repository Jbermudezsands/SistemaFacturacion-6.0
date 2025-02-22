/*
   jueves, 05 de diciembre de 201912:02:49 p.m.
   Usuario: 
   Servidor: JUANBERMUDEZ-PC\SQL2014
   Base de datos: FacturacionManagua
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
CREATE TABLE dbo.Recepcion
	(
	NumeroRecepcion nvarchar(50) NOT NULL,
	TipoRecepcion nvarchar(50) NOT NULL,
	Fecha date NULL,
	Cod_Proveedor nvarchar(50) NULL,
	Cod_SubProveedor nvarchar(50) NULL,
	Conductor nvarchar(100) NULL,
	Id_identificacion nvarchar(50) NULL,
	Id_Placa nvarchar(50) NULL,
	Cod_Bodega nvarchar(50) NULL,
	Observaciones nvarchar(MAX) NULL,
	SubTotal float(53) NULL,
	Telefono nvarchar(50) NULL,
	Cancelar bit NULL,
	Activo bit NULL,
	Seleccion bit NULL,
	Peso float(53) NULL,
	Lote nvarchar(50) NULL,
	Contabilizado bit NULL,
	FechaHora datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_Cancelar DEFAULT ((0)) FOR Cancelar
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_Activo DEFAULT ((1)) FOR Activo
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_Seleccion DEFAULT ((0)) FOR Seleccion
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	DF_Recepcion_Contabilizado DEFAULT ((0)) FOR Contabilizado
GO
ALTER TABLE dbo.Recepcion ADD CONSTRAINT
	PK_Recepcion PRIMARY KEY CLUSTERED 
	(
	NumeroRecepcion,
	TipoRecepcion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Recepcion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
