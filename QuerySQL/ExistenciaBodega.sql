DECLARE 
    @FechaCorte DATE = '2025-10-08',   -- Fecha límite
    @CodBodega NVARCHAR(50) = '01';  -- Código de bodega (puedes dejar NULL para todas)

-- =====================
-- MOVIMIENTOS DE ENTRADA
-- =====================
WITH Entradas AS (
    SELECT 
        DC.Cod_Producto,
        C.Cod_Bodega,
        SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C 
        ON DC.Numero_Compra = C.Numero_Compra 
        AND DC.Fecha_Compra = C.Fecha_Compra 
        AND DC.Tipo_Compra = C.Tipo_Compra
    INNER JOIN Productos P 
        ON DC.Cod_Producto = P.Cod_Productos
    WHERE 
        C.Fecha_Compra <= @FechaCorte
        AND C.Tipo_Compra IN ('Mercancia Recibida', 'Transferencia Recibida')
        AND P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
        AND (C.Cod_Bodega = @CodBodega)
    GROUP BY DC.Cod_Producto, C.Cod_Bodega

    UNION ALL

    SELECT 
        DF.Cod_Producto,
        F.Cod_Bodega,
        SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F 
        ON DF.Numero_Factura = F.Numero_Factura 
        AND DF.Fecha_Factura = F.Fecha_Factura 
        AND DF.Tipo_Factura = F.Tipo_Factura
    INNER JOIN Productos P 
        ON DF.Cod_Producto = P.Cod_Productos
    WHERE 
        F.Fecha_Factura <= @FechaCorte
        AND F.Tipo_Factura = 'Devolucion de Venta'
        AND P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
        AND (F.Cod_Bodega = @CodBodega)
    GROUP BY DF.Cod_Producto, F.Cod_Bodega
),

-- =====================
-- MOVIMIENTOS DE SALIDA
-- =====================
Salidas AS (
    SELECT 
        DC.Cod_Producto,
        C.Cod_Bodega,
        SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C 
        ON DC.Numero_Compra = C.Numero_Compra 
        AND DC.Fecha_Compra = C.Fecha_Compra 
        AND DC.Tipo_Compra = C.Tipo_Compra
    INNER JOIN Productos P 
        ON DC.Cod_Producto = P.Cod_Productos
    WHERE 
        C.Fecha_Compra <= @FechaCorte
        AND C.Tipo_Compra = 'Devolucion de Compra'
        AND P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
        AND (C.Cod_Bodega = @CodBodega)
    GROUP BY DC.Cod_Producto, C.Cod_Bodega

    UNION ALL

    SELECT 
        DF.Cod_Producto,
        F.Cod_Bodega,
        SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F 
        ON DF.Numero_Factura = F.Numero_Factura 
        AND DF.Fecha_Factura = F.Fecha_Factura 
        AND DF.Tipo_Factura = F.Tipo_Factura
    INNER JOIN Productos P 
        ON DF.Cod_Producto = P.Cod_Productos
    WHERE 
        F.Fecha_Factura <= @FechaCorte
        AND F.Tipo_Factura IN ('Factura', 'Salidas Bodegas', 'Transferencia Enviada')
        AND P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
        AND (F.Cod_Bodega = @CodBodega)
    GROUP BY DF.Cod_Producto, F.Cod_Bodega
)

-- =====================
-- EXISTENCIA FINAL POR PRODUCTO
-- =====================
SELECT 
    P.Cod_Productos,
    P.Descripcion_Producto,
    ISNULL(E.Cod_Bodega, SA.Cod_Bodega) AS Cod_Bodega,
    ISNULL(SUM(E.Cantidad), 0) - ISNULL(SUM(SA.Cantidad), 0) AS Existencia
FROM Productos P
LEFT JOIN Entradas E ON P.Cod_Productos = E.Cod_Producto
LEFT JOIN Salidas SA ON P.Cod_Productos = SA.Cod_Producto 
    AND E.Cod_Bodega = SA.Cod_Bodega
WHERE 
    P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
GROUP BY 
    P.Cod_Productos,
    P.Descripcion_Producto,
    E.Cod_Bodega,
    SA.Cod_Bodega
ORDER BY 
    P.Descripcion_Producto;
