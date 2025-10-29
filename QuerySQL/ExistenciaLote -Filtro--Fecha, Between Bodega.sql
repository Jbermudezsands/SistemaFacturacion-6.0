DECLARE 
    @FechaCorte DATE = '2026-10-12',               -- Fecha de corte
    @CodBodegaDesde NVARCHAR(50) = '01',           -- Bodega inicial
    @CodBodegaHasta NVARCHAR(50) = '05';           -- Bodega final

-- Reunir todos los lotes con movimientos del producto en el rango de bodegas
WITH Movimientos AS (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote, 'SINLOTE') AS Lote, C.Cod_Bodega
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE DC.Fecha_Compra <= @FechaCorte
      AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta

    UNION

    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea, 'SINLOTE') AS Lote, F.Cod_Bodega
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE DF.Fecha_Factura <= @FechaCorte
      AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
)

SELECT
    L.Cod_Producto,
    Prod.Descripcion_Producto AS Producto,
    L.Cod_Bodega,
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
INNER JOIN Productos Prod ON L.Cod_Producto = Prod.Cod_Productos

-- =====================
-- ENTRADAS
-- =====================

-- Mercancia Recibida
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Mercancia Recibida'
      AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE'), C.Cod_Bodega
) MR ON L.Cod_Producto = MR.Cod_Producto AND L.Lote = MR.Lote AND L.Cod_Bodega = MR.Cod_Bodega

-- Transferencia Recibida
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Transferencia Recibida'
      AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE'), C.Cod_Bodega
) TR ON L.Cod_Producto = TR.Cod_Producto AND L.Lote = TR.Lote AND L.Cod_Bodega = TR.Cod_Bodega

-- Devolución de Venta
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Devolucion de Venta'
      AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE'), F.Cod_Bodega
) DV ON L.Cod_Producto = DV.Cod_Producto AND L.Lote = DV.Lote AND L.Cod_Bodega = DV.Cod_Bodega

-- =====================
-- SALIDAS
-- =====================

-- Factura
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Factura'
      AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE'), F.Cod_Bodega
) Fact ON L.Cod_Producto = Fact.Cod_Producto AND L.Lote = Fact.Lote AND L.Cod_Bodega = Fact.Cod_Bodega

-- Salida Bodega
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Salida Bodega'
      AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE'), F.Cod_Bodega
) SB ON L.Cod_Producto = SB.Cod_Producto AND L.Lote = SB.Lote AND L.Cod_Bodega = SB.Cod_Bodega

-- Transferencia Enviada
LEFT JOIN (
    SELECT DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE') AS Lote, F.Cod_Bodega, SUM(DF.Cantidad) AS Cantidad
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
    WHERE F.Fecha_Factura <= @FechaCorte
      AND F.Tipo_Factura = 'Transferencia Enviada'
      AND F.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DF.Cod_Producto, ISNULL(DF.CodTarea,'SINLOTE'), F.Cod_Bodega
) TE ON L.Cod_Producto = TE.Cod_Producto AND L.Lote = TE.Lote AND L.Cod_Bodega = TE.Cod_Bodega

-- Devolución de Compra
LEFT JOIN (
    SELECT DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE') AS Lote, C.Cod_Bodega, SUM(DC.Cantidad) AS Cantidad
    FROM Detalle_Compras DC
    INNER JOIN Compras C ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra
    WHERE C.Fecha_Compra <= @FechaCorte
      AND C.Tipo_Compra = 'Devolucion de Compra'
      AND C.Cod_Bodega BETWEEN @CodBodegaDesde AND @CodBodegaHasta
    GROUP BY DC.Cod_Producto, ISNULL(DC.Numero_Lote,'SINLOTE'), C.Cod_Bodega
) DC ON L.Cod_Producto = DC.Cod_Producto AND L.Lote = DC.Lote AND L.Cod_Bodega = DC.Cod_Bodega

ORDER BY L.Cod_Producto, L.Cod_Bodega, L.Lote;
