/*
   martes, 02 de febrero de 202102:30:14 p.m.
   Usuario: sa
   Servidor: JUANBERMUDEZ\SQL2014
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
ALTER TABLE dbo.Detalle_Transformacion ADD
	Numero_Compra_Salida nvarchar(50) NULL,
	Fecha_Compra_Salida smalldatetime NULL,
	Tipo_Compra_Salida nvarchar(50) NULL
GO
ALTER TABLE dbo.Detalle_Transformacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
