/*
   viernes, 18 de julio de 201405:28:48 a.m.
   Usuario: sa
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacionDISTELSA
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
CREATE TABLE dbo.ConsecutivoSerie
	(
	Serie nvarchar(50) NOT NULL,
	Factura float(53) NULL,
    Cotizacion float(53) NULL,
    SalidaBodega float(53) NULL,
    DevFactura float(53) NULL,
    Transferencia_Enviada float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ConsecutivoSerie ADD CONSTRAINT
	PK_ConsecutivoSerie PRIMARY KEY CLUSTERED 
	(
	Serie
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
