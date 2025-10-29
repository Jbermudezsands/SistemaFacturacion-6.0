DECLARE 	
    @FechaCorte DATE = '2026-10-08';  -- Filtrar por fecha

SELECT
    P.Cod_Producto,
    Prod.Descripcion_Producto AS Producto,
    
    -- Entradas separadas
    ISNULL(MR.Cantidad,0) AS Mercancia_Recibida,
    ISNULL(TR.Cantidad,0) AS Transferencia_Recibida,
    ISNULL(DV.Cantidad,0) AS Devolucion_Venta,
    
    -- Salidas separadas
    ISNULL(Fact.Cantidad,0) AS Factura,
    ISNULL(SB.Cantidad,0) AS Salidas_Bodegas,
    ISNULL(TE.Cantidad,0) AS Transferencia_Enviada,
    ISNULL(DC.Cantidad,0) AS Devolucion_Compra,

    ISNULL(MR.Cantidad,0) + ISNULL(TR.Cantidad,0) + ISNULL(DV.Cantidad,0)
    - (ISNULL(Fact.Cantidad,0) + ISNULL(SB.Cantidad,0) + ISNULL(TE.Cantidad,0) + ISNULL(DC.Cantidad,0)) AS Existencia
FROM
    -- Todos los productos con algún movimiento
    (SELECT Cod_Producto FROM Detalle_Compras WHERE Fecha_Compra <= @FechaCorte
     UNION
     SELECT Cod_Producto FROM Detalle_Facturas WHERE Fecha_Factura <= @FechaCorte
    ) P
INNER JOIN Productos Prod
    ON P.Cod_Producto = Prod.Cod_Productos

-- Entradas
LEFT JOIN (
    SELECT DC.Cod_Producto, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C
        ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Mercancia Recibida'
    GROUP BY DC.Cod_Producto
) MR ON P.Cod_Producto = MR.Cod_Producto

LEFT JOIN (
    SELECT DC.Cod_Producto, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C
        ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Transferencia Recibida'
    GROUP BY DC.Cod_Producto
) TR ON P.Cod_Producto = TR.Cod_Producto

LEFT JOIN (
    SELECT DF.Cod_Producto, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F
        ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Devolucion de Venta'
    GROUP BY DF.Cod_Producto
) DV ON P.Cod_Producto = DV.Cod_Producto

-- Salidas
LEFT JOIN (
    SELECT DF.Cod_Producto, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F
        ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Factura'
    GROUP BY DF.Cod_Producto
) Fact ON P.Cod_Producto = Fact.Cod_Producto

LEFT JOIN (
    SELECT DF.Cod_Producto, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F
        ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Salida Bodega'
    GROUP BY DF.Cod_Producto
) SB ON P.Cod_Producto = SB.Cod_Producto

LEFT JOIN (
    SELECT DF.Cod_Producto, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F
        ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Transferencia Enviada'
    GROUP BY DF.Cod_Producto
) TE ON P.Cod_Producto = TE.Cod_Producto

LEFT JOIN (
    SELECT DC.Cod_Producto, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C
        ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Devolucion de Compra'
    GROUP BY DC.Cod_Producto
) DC ON P.Cod_Producto = DC.Cod_Producto

ORDER BY P.Cod_Producto;
