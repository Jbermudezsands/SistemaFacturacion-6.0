/*
   Jueves, 15 de Abril de 201002:21:40 p.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionBuiler
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
CREATE TABLE dbo.Liquidacion
	(
	Numero_Liquidacion nvarchar(50) NOT NULL,
	Fecha_Liquidacion smalldatetime NOT NULL,
	Cod_Proveedor nvarchar(50) NULL,
	Nombre_Proveedor nvarchar(50) NULL,
	Apellido_Proveedor nvarchar(50) NULL,
	TotalFOB float(53) NULL,
	TotalCosto float(53) NULL,
	Contabilizado bit NULL,
	Activo bit NULL,
	Cancelado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_Contabilizado DEFAULT 0 FOR Contabilizado
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	DF_Liquidacion_Cancelado DEFAULT 0 FOR Cancelado
GO
ALTER TABLE dbo.Liquidacion ADD CONSTRAINT
	PK_Liquidacion PRIMARY KEY CLUSTERED 
	(
	Numero_Liquidacion,
	Fecha_Liquidacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
