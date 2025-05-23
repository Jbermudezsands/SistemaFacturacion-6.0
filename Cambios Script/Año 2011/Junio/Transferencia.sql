/*
   Viernes, 03 de Junio de 201106:49:06 a.m.
   Usuario: 
   Servidor: CONSULTOR\SQL2005
   Base de datos: SistemaFacturacionBuhler
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
CREATE TABLE dbo.Transferencia
	(
	Numero_Transferencia nvarchar(50) NOT NULL,
	Fecha_Transferencia smalldatetime NOT NULL,
	Tipo_Transferencia nvarchar(50) NOT NULL,
	Cod_BodegaOrigen nvarchar(50) NULL,
	Cod_BodegaDestino nvarchar(50) NULL,
	Activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Transferencia ADD CONSTRAINT
	DF_Transferencia_Activo DEFAULT 1 FOR Activo
GO
ALTER TABLE dbo.Transferencia ADD CONSTRAINT
	PK_Transferencia PRIMARY KEY CLUSTERED 
	(
	Numero_Transferencia,
	Fecha_Transferencia,
	Tipo_Transferencia
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
