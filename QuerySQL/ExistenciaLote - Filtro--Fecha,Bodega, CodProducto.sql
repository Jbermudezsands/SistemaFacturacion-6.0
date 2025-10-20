DECLARE 
    @FechaCorte DATE = '2026-10-12',       -- Fecha de corte
    @CodBodega NVARCHAR(50) = '01',        -- Filtrar por bodega
    @CodProducto NVARCHAR(50) = '17RBIAM500';  -- Filtrar por producto específico

-- Reunir todos los lotes con movimientos del producto en la bodega
WITH Movimientos AS (
    SELECT Cod_Producto, ISNULL(Numero_Lote, 'SINLOTE') AS Lote
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE DC.Fecha_Compra <= @FechaCorte
      AND DC.Cod_Producto = @CodProducto
      AND C.Cod_Bodega = @CodBodega

    UNION

    SELECT Cod_Producto, ISNULL(CodTarea, 'SINLOTE') AS Lote
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE DF.Fecha_Factura <= @FechaCorte
      AND DF.Cod_Producto = @CodProducto
      AND F.Cod_Bodega = @CodBodega
)

SELECT
    L.Cod_Producto,
    Prod.Descripcion_Producto AS Producto,
    @CodBodega AS Cod_Bodega,
    L.Lote,

    -- Entradas
    ISNULL(MR.Cantidad,0) AS Mercancia_Recibida,
    ISNULL(TR.Cantidad,0) AS Transferencia_Recibida,
    ISNULL(DV.Cantidad,0) AS Devolucion_Venta,

    -- Salidas
    ISNULL(Fact.Cantidad,0) AS Factura,
    ISNULL(SB.Cantidad,0) AS Salidas_Bodegas,
    ISNULL(TE.Cantidad,0) AS Transferencia_Enviada,
    ISNULL(DC.Cantidad,0) AS Devolucion_Compra,

    -- Existencia Final
    ISNULL(MR.Cantidad,0) + ISNULL(TR.Cantidad,0) + ISNULL(DV.Cantidad,0)
    - (ISNULL(Fact.Cantidad,0) + ISNULL(SB.Cantidad,0) + ISNULL(TE.Cantidad,0) + ISNULL(DC.Cantidad,0)) AS Existencia

FROM Movimientos L
INNER JOIN Productos Prod
    ON L.Cod_Producto = Prod.Cod_Productos

-- =====================
-- ENTRADAS
-- =====================

-- Mercancia Recibida
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Mercancia Recibida'
      AND DC.Cod_Producto = @CodProducto
      AND C.Cod_Bodega = @CodBodega
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE')
) MR ON L.Cod_Producto = MR.Cod_Producto AND L.Lote = MR.Lote

-- Transferencia Recibida
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Transferencia Recibida'
      AND DC.Cod_Producto = @CodProducto
      AND C.Cod_Bodega = @CodBodega
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE')
) TR ON L.Cod_Producto = TR.Cod_Producto AND L.Lote = TR.Lote

-- Devolución de Venta
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Devolucion de Venta'
      AND DF.Cod_Producto = @CodProducto
      AND F.Cod_Bodega = @CodBodega
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE')
) DV ON L.Cod_Producto = DV.Cod_Producto AND L.Lote = DV.Lote

-- =====================
-- SALIDAS
-- =====================

-- Factura
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Factura'
      AND DF.Cod_Producto = @CodProducto
      AND F.Cod_Bodega = @CodBodega
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE')
) Fact ON L.Cod_Producto = Fact.Cod_Producto AND L.Lote = Fact.Lote

-- Salida Bodega
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Salida Bodega'
      AND DF.Cod_Producto = @CodProducto
      AND F.Cod_Bodega = @CodBodega
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE')
) SB ON L.Cod_Producto = SB.Cod_Producto AND L.Lote = SB.Lote

-- Transferencia Enviada
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Transferencia Enviada'
      AND DF.Cod_Producto = @CodProducto
      AND F.Cod_Bodega = @CodBodega
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE')
) TE ON L.Cod_Producto = TE.Cod_Producto AND L.Lote = TE.Lote

-- Devolución de Compra
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Devolucion de Compra'
      AND DC.Cod_Producto = @CodProducto
      AND C.Cod_Bodega = @CodBodega
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE')
) DC ON L.Cod_Producto = DC.Cod_Producto AND L.Lote = DC.Lote

ORDER BY L.Cod_Producto, L.Lote;
