/*
   Miércoles, 18 de Agosto de 201005:04:17 p.m.
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
CREATE TABLE dbo.Plantilla
	(
	NumeroPlantilla nvarchar(50) NOT NULL,
	Fecha_Plantilla nvarchar(50) NOT NULL,
	Tipo_Plantilla nvarchar(50) NOT NULL,
	MonedaPlantilla nvarchar(50) NULL,
	Seleccion_Cliente nvarchar(50) NULL,
	Cod_Cliente nvarchar(50) NULL,
	Cod_Bodega nvarchar(50) NULL,
    Cod_Vendedor nvarchar(50) NULL,
	Nombre_Plantilla nvarchar(50) NULL,
	Apellido_Plantilla nvarchar(50) NULL,
	Direccion_Plantilla nvarchar(50) NULL,
	Telefono_Plantilla nvarchar(50) NULL,
	Dias_Vencimiento float(53) NULL,
	Observaciones nvarchar(MAX) NULL,
    Referencia_Plantilla nvarchar(MAX) NULL,
	Exonerado bit NULL,
	Descuento nvarchar(50) NULL,
	SubTotal float(53) NULL,
	IVA float(53) NULL,
	Pagado float(53) NULL,
	NetoPagar float(53) NULL,
	Activo bit NULL,
	Cancelado bit NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Plantilla ADD CONSTRAINT
	PK_Plantilla PRIMARY KEY CLUSTERED 
	(
	NumeroPlantilla,
	Fecha_Plantilla,
	Tipo_Plantilla
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
