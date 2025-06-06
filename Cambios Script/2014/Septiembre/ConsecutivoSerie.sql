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
CREATE TABLE dbo.EmpresaTransporte
	(
	[IdEmpresaTransporte] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](4) NOT NULL,
	[NombreEmpresa] [varchar](75) NOT NULL,
	[CedulaEmpresa] [varchar](20) NULL,
	[NombreRepresentante] [varchar](75) NULL,
	[CedulaRepresentante] [varchar](20) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[IdTipoPersoneria] [int] NULL,
	[Activo] [bit] NULL,
	[IdTipoEmpresaTransporte] [int] NOT NULL,
	[IdUsuario] [int] NULL,
	[IdCompany] [int] NULL
	)  ON [PRIMARY]
GO
COMMIT
