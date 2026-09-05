CREATE PROCEDURE SP_Auditoria_LotesNegativos
AS
BEGIN

SET NOCOUNT ON;

WITH Movimientos AS (

    -- COMPRAS
    SELECT
        DC.Cod_Producto,
        REPLACE(UPPER(ISNULL(DC.Numero_Lote,'SINLOTE')),' ','') AS Lote,
        C.Cod_Bodega,
        C.Fecha_Compra AS FechaMovimiento,
        C.Numero_Compra AS Documento,
        C.Tipo_Compra AS TipoDocumento,
        DC.Cantidad AS CantidadMovimiento
    FROM Detalle_Compras DC
    INNER JOIN Compras C
        ON DC.Numero_Compra = C.Numero_Compra
        AND DC.Fecha_Compra = C.Fecha_Compra
        AND DC.Tipo_Compra = C.Tipo_Compra

    UNION ALL

    -- FACTURAS
    SELECT
        DF.Cod_Producto,
        REPLACE(UPPER(ISNULL(DF.CodTarea,'SINLOTE')),' ',''),
        F.Cod_Bodega,
        F.Fecha_Factura,
        F.Numero_Factura,
        F.Tipo_Factura,
        CASE
            WHEN F.Tipo_Factura IN ('Factura','Salida Bodega','Transferencia Enviada')
                THEN -DF.Cantidad
            WHEN F.Tipo_Factura = 'Devolucion de Venta'
                THEN DF.Cantidad
            ELSE 0
        END
    FROM Detalle_Facturas DF
    INNER JOIN Facturas F
        ON DF.Numero_Factura = F.Numero_Factura
        AND DF.Fecha_Factura = F.Fecha_Factura
        AND DF.Tipo_Factura = F.Tipo_Factura
),

Kardex AS (

    SELECT *,
        SUM(CantidadMovimiento) OVER(
            PARTITION BY Cod_Producto, Cod_Bodega, Lote
            ORDER BY FechaMovimiento, Documento
        ) AS Existencia
    FROM Movimientos
),

LotesDisponibles AS (

    SELECT
        Cod_Producto,
        Cod_Bodega,
        Lote,
        MAX(Existencia) AS Existencia
    FROM Kardex
    GROUP BY
        Cod_Producto,
        Cod_Bodega,
        Lote
)

INSERT INTO Auditoria_LotesNegativos
(
Cod_Producto,
Cod_Bodega,
LoteIncorrecto,
LoteSugerido,
Documento,
TipoDocumento,
FechaMovimiento,
CantidadMovimiento,
ExistenciaDespuesMovimiento
)

SELECT
    K.Cod_Producto,
    K.Cod_Bodega,
    K.Lote,
    (
        SELECT TOP 1 L.Lote
        FROM LotesDisponibles L
        WHERE L.Cod_Producto = K.Cod_Producto
        AND L.Cod_Bodega = K.Cod_Bodega
        AND L.Existencia > 0
        ORDER BY L.Lote
    ),
    K.Documento,
    K.TipoDocumento,
    K.FechaMovimiento,
    K.CantidadMovimiento,
    K.Existencia
FROM Kardex K
WHERE K.Existencia < 0

END