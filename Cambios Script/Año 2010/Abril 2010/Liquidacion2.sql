/*
   Viernes, 16 de Abril de 201007:15:13 a.m.
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
ALTER TABLE dbo.Liquidacion ADD
	Seguro float(53) NULL,
	CodSeguro nvarchar(50) NULL,
	Transporte float(53) NULL,
	CodTransporte nvarchar(50) NULL,
	Almacen float(53) NULL,
	CodAlmacen nvarchar(50) NULL,
	IVA float(53) NULL,
	CodIVA nvarchar(50) NULL,
	DAI float(53) NULL,
	CodDAI nvarchar(50) NULL,
	IEC float(53) NULL,
	CodIEC nvarchar(50) NULL,
	Fletes float(53) NULL,
	CodFletes nvarchar(50) NULL,
	HC float(53) NULL,
	CodHC nvarchar(50) NULL,
	IG float(53) NULL,
	CodIG nvarchar(50) NULL,
	ITF float(53) NULL,
	CodITF nvarchar(50) NULL,
	GA float(53) NULL,
	CodGA nvarchar(50) NULL,
	TSM float(53) NULL,
	CodTSM nvarchar(50) NULL,
	OG float(53) NULL,
	CodOG nvarchar(50) NULL,
	OH float(53) NULL,
	CodOH nvarchar(50) NULL
GO
COMMIT
