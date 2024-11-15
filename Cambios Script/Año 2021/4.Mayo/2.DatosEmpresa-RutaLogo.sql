/*
   martes, 4 de mayo de 202111:20:43
   Usuario: 
   Servidor: JUANBERMUDEZ
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
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ModedaImprimeFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaCompra
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MonedaImprimeCompra
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_SincronizarTasa
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_IvaProducto
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ConsecutivoFacturaManual
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_Factura_Tarea
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_LineaFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_PorcientoTarjetaCredito
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ImprimirSinPreview
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ConsecutivoReciboManual
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_CodigoClienteNumerico
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_NumeroCopias
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_BloquearBajoCosto
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_BloquearPreciosFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_MostrarRetencionFactura
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ConsecutivoReciboSerie
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_FacturaLotes
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_ActivarLimiteCredito
GO
ALTER TABLE dbo.DatosEmpresa
	DROP CONSTRAINT DF_DatosEmpresa_PedirCantEscaner
GO
CREATE TABLE dbo.Tmp_DatosEmpresa
	(
	Nombre_Empresa nvarchar(150) NULL,
	Direccion_Empresa nvarchar(250) NULL,
	Numero_Ruc nvarchar(50) NULL,
	Telefono nvarchar(50) NULL,
	Ruta_Logo nvarchar(MAX) NULL,
	Conexion_Contabilidad nvarchar(250) NULL,
	MonedaFactura nvarchar(50) NULL,
	ModedaImprimeFactura nvarchar(50) NULL,
	MonedaCompra nvarchar(50) NULL,
	MonedaImprimeCompra nvarchar(50) NULL,
	SincronizarTasa bit NULL,
	IvaProducto nvarchar(50) NULL,
	NombreCliente nvarchar(50) NULL,
	ConsecutivoFacturaManual bit NULL,
	Factura_Tarea bit NULL,
	LineaFactura bit NULL,
	MetodoPagoDefecto nvarchar(50) NULL,
	PorcientoTarjetaCredito float(53) NULL,
	ConsecutivoFacBodega bit NULL,
	ConsecutivoComBodega bit NULL,
	ImprimirSinPreview bit NULL,
	ConsecutivoFacSerie bit NULL,
	RutaCompartida nvarchar(MAX) NULL,
	ConsecutivoReciboManual bit NULL,
	CodigoClienteNumerico bit NULL,
	valor nvarchar(50) NULL,
	NumeroCopias int NULL,
	BloquearBajoCosto bit NULL,
	BloquearPreciosFactura bit NULL,
	MostrarRetencionFactura bit NULL,
	MetodoProveedorDefecto nvarchar(50) NULL,
	ConsecutivoReciboSerie bit NULL,
	ConexionImpresionSQL nvarchar(50) NULL,
	CalcularPropina bit NULL,
	PorcentajePropina float(53) NULL,
	Version nvarchar(50) NULL,
	FacturaLotes bit NULL,
	FechaAuditoria datetime NULL,
	Logo image NULL,
	ActivarLimiteCredito bit NULL,
	PedirCantEscaner bit NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DatosEmpresa SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaFactura DEFAULT (N'Cordobas') FOR MonedaFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ModedaImprimeFactura DEFAULT (N'Cordobas') FOR ModedaImprimeFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaCompra DEFAULT (N'Cordobas') FOR MonedaCompra
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MonedaImprimeCompra DEFAULT (N'Cordobas') FOR MonedaImprimeCompra
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_SincronizarTasa DEFAULT ((0)) FOR SincronizarTasa
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_IvaProducto DEFAULT (N'Sumando IVA del Producto') FOR IvaProducto
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ConsecutivoFacturaManual DEFAULT ((0)) FOR ConsecutivoFacturaManual
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_Factura_Tarea DEFAULT ((0)) FOR Factura_Tarea
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_LineaFactura DEFAULT ((0)) FOR LineaFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_PorcientoTarjetaCredito DEFAULT ((0)) FOR PorcientoTarjetaCredito
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ImprimirSinPreview DEFAULT ((0)) FOR ImprimirSinPreview
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ConsecutivoReciboManual DEFAULT ((0)) FOR ConsecutivoReciboManual
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_CodigoClienteNumerico DEFAULT ((1)) FOR CodigoClienteNumerico
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_NumeroCopias DEFAULT ((3)) FOR NumeroCopias
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_BloquearBajoCosto DEFAULT ((0)) FOR BloquearBajoCosto
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_BloquearPreciosFactura DEFAULT ((0)) FOR BloquearPreciosFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_MostrarRetencionFactura DEFAULT ((0)) FOR MostrarRetencionFactura
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ConsecutivoReciboSerie DEFAULT ((0)) FOR ConsecutivoReciboSerie
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_FacturaLotes DEFAULT ((0)) FOR FacturaLotes
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_ActivarLimiteCredito DEFAULT ((0)) FOR ActivarLimiteCredito
GO
ALTER TABLE dbo.Tmp_DatosEmpresa ADD CONSTRAINT
	DF_DatosEmpresa_PedirCantEscaner DEFAULT ((0)) FOR PedirCantEscaner
GO
IF EXISTS(SELECT * FROM dbo.DatosEmpresa)
	 EXEC('INSERT INTO dbo.Tmp_DatosEmpresa (Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Telefono, Ruta_Logo, Conexion_Contabilidad, MonedaFactura, ModedaImprimeFactura, MonedaCompra, MonedaImprimeCompra, SincronizarTasa, IvaProducto, NombreCliente, ConsecutivoFacturaManual, Factura_Tarea, LineaFactura, MetodoPagoDefecto, PorcientoTarjetaCredito, ConsecutivoFacBodega, ConsecutivoComBodega, ImprimirSinPreview, ConsecutivoFacSerie, RutaCompartida, ConsecutivoReciboManual, CodigoClienteNumerico, valor, NumeroCopias, BloquearBajoCosto, BloquearPreciosFactura, MostrarRetencionFactura, MetodoProveedorDefecto, ConsecutivoReciboSerie, ConexionImpresionSQL, CalcularPropina, PorcentajePropina, Version, FacturaLotes, FechaAuditoria, Logo, ActivarLimiteCredito, PedirCantEscaner)
		SELECT Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Telefono, CONVERT(nvarchar(MAX), Ruta_Logo), Conexion_Contabilidad, MonedaFactura, ModedaImprimeFactura, MonedaCompra, MonedaImprimeCompra, SincronizarTasa, IvaProducto, NombreCliente, ConsecutivoFacturaManual, Factura_Tarea, LineaFactura, MetodoPagoDefecto, PorcientoTarjetaCredito, ConsecutivoFacBodega, ConsecutivoComBodega, ImprimirSinPreview, ConsecutivoFacSerie, RutaCompartida, ConsecutivoReciboManual, CodigoClienteNumerico, valor, NumeroCopias, BloquearBajoCosto, BloquearPreciosFactura, MostrarRetencionFactura, MetodoProveedorDefecto, ConsecutivoReciboSerie, ConexionImpresionSQL, CalcularPropina, PorcentajePropina, Version, FacturaLotes, FechaAuditoria, Logo, ActivarLimiteCredito, PedirCantEscaner FROM dbo.DatosEmpresa WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.DatosEmpresa
GO
EXECUTE sp_rename N'dbo.Tmp_DatosEmpresa', N'DatosEmpresa', 'OBJECT' 
GO
COMMIT
