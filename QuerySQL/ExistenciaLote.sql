SELECT        m.Cod_Producto, p.Descripcion_Producto, m.Numero_Lote, m.Cod_Bodega, SUM(m.Cantidad * m.TipoMovimiento) AS Existencia_Lote, p.Cod_Linea, L.FechaVence
FROM            (SELECT        dc.Cod_Producto, dc.Numero_Lote, c.Cod_Bodega, dc.Cantidad, 1 AS TipoMovimiento, dc.Fecha_Compra AS FechaMovimiento
                          FROM            Detalle_Compras AS dc INNER JOIN
                                                    Compras AS c ON dc.Numero_Compra = c.Numero_Compra AND dc.Fecha_Compra = c.Fecha_Compra AND dc.Tipo_Compra = c.Tipo_Compra
                          WHERE        (dc.Tipo_Compra = 'Mercancia Recibida')
                          UNION ALL
                          SELECT        dc.Cod_Producto, dc.Numero_Lote, c.Cod_Bodega, dc.Cantidad, - 1 AS TipoMovimiento, dc.Fecha_Compra AS FechaMovimiento
                          FROM            Detalle_Compras AS dc INNER JOIN
                                                   Compras AS c ON dc.Numero_Compra = c.Numero_Compra AND dc.Fecha_Compra = c.Fecha_Compra AND dc.Tipo_Compra = c.Tipo_Compra
                          WHERE        (dc.Tipo_Compra = 'Devolucion de Compra')
                          UNION ALL
                          SELECT        df.Cod_Producto, df.Numero_Lote, f.Cod_Bodega, df.Cantidad, - 1 AS TipoMovimiento, df.Fecha_Factura AS FechaMovimiento
                          FROM            Detalle_Facturas AS df INNER JOIN
                                                   Facturas AS f ON df.Numero_Factura = f.Numero_Factura AND df.Fecha_Factura = f.Fecha_Factura AND df.Tipo_Factura = f.Tipo_Factura
                          WHERE        (df.Tipo_Factura = 'Factura')
                          UNION ALL
                          SELECT        df.Cod_Producto, df.Numero_Lote, f.Cod_Bodega, df.Cantidad, 1 AS TipoMovimiento, df.Fecha_Factura AS FechaMovimiento
                          FROM            Detalle_Facturas AS df INNER JOIN
                                                   Facturas AS f ON df.Numero_Factura = f.Numero_Factura AND df.Fecha_Factura = f.Fecha_Factura AND df.Tipo_Factura = f.Tipo_Factura
                          WHERE        (df.Tipo_Factura = 'Devolucion de Ventas')
                          UNION ALL
                          SELECT        df.Cod_Producto, df.Numero_Lote, f.Cod_Bodega, df.Cantidad, - 1 AS TipoMovimiento, df.Fecha_Factura AS FechaMovimiento
                          FROM            Detalle_Facturas AS df INNER JOIN
                                                   Facturas AS f ON df.Numero_Factura = f.Numero_Factura AND df.Fecha_Factura = f.Fecha_Factura AND df.Tipo_Factura = f.Tipo_Factura
                          WHERE        (df.Tipo_Factura = 'Transferencias Enviadas')
                          UNION ALL
                          SELECT        dc.Cod_Producto, dc.Numero_Lote, c.Cod_Bodega, dc.Cantidad, 1 AS TipoMovimiento, dc.Fecha_Compra AS FechaMovimiento
                          FROM            Detalle_Compras AS dc INNER JOIN
                                                   Compras AS c ON dc.Numero_Compra = c.Numero_Compra AND dc.Fecha_Compra = c.Fecha_Compra AND dc.Tipo_Compra = c.Tipo_Compra
                          WHERE        (dc.Tipo_Compra = 'Transferencias Recibidas')) AS m INNER JOIN
                         Productos AS p ON m.Cod_Producto = p.Cod_Productos INNER JOIN
                         Lote AS L ON m.Numero_Lote = L.Numero_Lote
WHERE        (m.FechaMovimiento <= CONVERT(DATETIME, '2025-10-04', 102)) AND (m.Cod_Producto BETWEEN '03RIBACT' AND '03RIBACT') AND (p.Cod_Linea BETWEEN N'03' AND N'03') AND (l.Numero_Lote <> N'SIN LOTE') AND (l.Numero_Lote <> N'SINLOTE') AND (l.Numero_Lote <> N'')
GROUP BY m.Cod_Producto, p.Descripcion_Producto, m.Numero_Lote, m.Cod_Bodega, p.Cod_Linea, L.FechaVence
ORDER BY m.Cod_Producto, p.Descripcion_Producto, m.Numero_Lote, m.Cod_Bodega