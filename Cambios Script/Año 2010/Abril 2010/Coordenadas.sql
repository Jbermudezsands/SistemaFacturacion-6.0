/*
   Martes, 06 de Abril de 201009:29:30 a.m.
   Usuario: 
   Servidor: JUAN\SQL2005
   Base de datos: SistemaFacturacion
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
CREATE TABLE dbo.Coordenadas
	(
	Tipo nvarchar(50) NULL,
	Nlineas float(53) NULL,
	X1 float(53) NULL,
	Y1 float(53) NULL,
	X2 float(53) NULL,
	Y2 float(53) NULL,
	X3 float(53) NULL,
	Y3 float(53) NULL,
	X4 float(53) NULL,
	Y4 float(53) NULL,
	X5 float(53) NULL,
	Y5 float(53) NULL,
	X6 float(53) NULL,
	Y6 float(53) NULL,
	X7 float(53) NULL,
	Y7 float(53) NULL,
	X8 float(53) NULL,
	Y8 float(53) NULL,
	X9 float(53) NULL,
	Y9 float(53) NULL,
	X10 float(53) NULL,
	Y10 float(53) NULL,
	X11 float(53) NULL,
	Y11 float(53) NULL,
	X12 float(53) NULL,
	Y12 float(53) NULL,
	X13 float(53) NULL,
	Y13 float(53) NULL,
	X14 float(53) NULL,
	Y14 float(53) NULL,
	X15 float(53) NULL,
	Y15 float(53) NULL,
	X16 float(53) NULL,
	Y16 float(53) NULL,
	X17 float(53) NULL,
	Y17 float(53) NULL,
	X18 float(53) NULL,
	Y18 float(53) NULL,
	X19 float(53) NULL,
	Y19 float(53) NULL,
	X20 float(53) NULL,
	Y20 float(53) NULL,
	X21 float(53) NULL,
	Y21 float(53) NULL,
	X22 float(53) NULL,
	Y22 float(53) NULL,
	X23 float(53) NULL,
	Y23 float(53) NULL,
	X24 float(53) NULL,
	Y24 float(53) NULL
	)  ON [PRIMARY]
GO
COMMIT
