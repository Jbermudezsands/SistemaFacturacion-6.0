-- Indices cubrientes para el Motor de Costos (carga de movimientos por producto y por fecha).
-- Idempotente. No modifica datos.

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Detalle_Compras_Costos' AND object_id = OBJECT_ID('dbo.Detalle_Compras'))
    CREATE NONCLUSTERED INDEX IX_Detalle_Compras_Costos
        ON dbo.Detalle_Compras (Cod_Producto, Fecha_Compra, Tipo_Compra)
        INCLUDE (Numero_Compra, Cantidad, Precio_Unitario, Precio_Neto, Costo_Unitario);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Detalle_Facturas_Costos' AND object_id = OBJECT_ID('dbo.Detalle_Facturas'))
    CREATE NONCLUSTERED INDEX IX_Detalle_Facturas_Costos
        ON dbo.Detalle_Facturas (Cod_Producto, Fecha_Factura, Tipo_Factura)
        INCLUDE (Numero_Factura, Cantidad, Precio_Unitario, Precio_Neto, Costo_Unitario);
GO

-- Para la carga masiva por fecha (reportes): filtro por Tipo y Fecha sin producto.
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Detalle_Facturas_Fecha_Tipo' AND object_id = OBJECT_ID('dbo.Detalle_Facturas'))
    CREATE NONCLUSTERED INDEX IX_Detalle_Facturas_Fecha_Tipo
        ON dbo.Detalle_Facturas (Tipo_Factura, Fecha_Factura)
        INCLUDE (Cod_Producto, Numero_Factura, Cantidad, Precio_Unitario, Precio_Neto, Costo_Unitario);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Detalle_Compras_Fecha_Tipo' AND object_id = OBJECT_ID('dbo.Detalle_Compras'))
    CREATE NONCLUSTERED INDEX IX_Detalle_Compras_Fecha_Tipo
        ON dbo.Detalle_Compras (Tipo_Compra, Fecha_Compra)
        INCLUDE (Cod_Producto, Numero_Compra, Cantidad, Precio_Unitario, Precio_Neto, Costo_Unitario);
GO
