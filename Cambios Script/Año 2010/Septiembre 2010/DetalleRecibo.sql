/*
   Sábado, 18 de Septiembre de 201009:13:59 p.m.
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
ALTER TABLE dbo.DetalleRecibo ADD
	NombrePago nvarchar(50) NULL,
	Descripcion nvarchar(MAX) NULL,
	NumeroTarjeta nvarchar(50) NULL,
	FechaVence smalldatetime NULL,
	MontoFactura float(53) NULL,
	AplicaFactura float(53) NULL,
	SaldoFactura float(53) NULL
GO
COMMIT
