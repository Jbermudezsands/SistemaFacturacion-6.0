-- Detalle_Compras
CREATE INDEX IX_DetalleCompras_Producto_Lote
ON Detalle_Compras (Cod_Producto, Numero_Lote, Fecha_Compra);

-- Detalle_Facturas
CREATE INDEX IX_DetalleFacturas_Producto_Lote
ON Detalle_Facturas (Cod_Producto, CodTarea, Fecha_Factura);

-- Lote
CREATE INDEX IX_Lote_Numero
ON Lote (Numero_Lote);
