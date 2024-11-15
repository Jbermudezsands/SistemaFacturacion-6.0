/*
   jueves, 17 de diciembre de 201502:29:04 p.m.
   Usuario: 
   Servidor: JUAN\SQL2012
   Base de datos: SistemaFacturacionDISTELSA
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
ALTER TABLE dbo.DatosEmpresa ADD
	BloquearBajoCosto bit NULL,
	BloquearPreciosFactura bit NULL
GO
ALTER TABLE dbo.DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_BloquearBajoCosto DEFAULT 0 FOR BloquearBajoCosto
GO
ALTER TABLE dbo.DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_BloquearPreciosFactura DEFAULT 0 FOR BloquearPreciosFactura
GO
ALTER TABLE dbo.DatosEmpresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
