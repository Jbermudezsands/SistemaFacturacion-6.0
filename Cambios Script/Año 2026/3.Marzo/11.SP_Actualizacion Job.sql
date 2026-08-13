CREATE PROCEDURE sp_ReconstruirInventario
(
    @Modo VARCHAR(20) = 'VALIDAR' -- VALIDAR | CORREGIR
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FacturaLotes BIT = 0

    SELECT @FacturaLotes = ISNULL(FacturaLotes,0)
    FROM DatosEmpresa

    ----------------------------------------
    -- 🔹 CON LOTES
    ----------------------------------------
    IF @FacturaLotes = 1
    BEGIN

        ;WITH Movimientos AS (

            SELECT 
                DC.Cod_Producto,
                REPLACE(UPPER(ISNULL(DC.Numero_Lote,'SINLOTE')),' ','') AS Numero_Lote,
                C.Cod_Bodega,
                CASE 
                    WHEN C.Tipo_Compra IN ('Mercancia Recibida','Transferencia Recibida')
                        THEN DC.Cantidad
                    WHEN C.Tipo_Compra = 'Devolucion de Compra'
                        THEN -DC.Cantidad
                    ELSE 0
                END AS CantidadMovimiento
            FROM Detalle_Compras DC
            INNER JOIN Compras C
                ON DC.Numero_Compra = C.Numero_Compra
                AND DC.Fecha_Compra = C.Fecha_Compra
                AND DC.Tipo_Compra = C.Tipo_Compra

            UNION ALL

            SELECT 
                DF.Cod_Producto,
                REPLACE(UPPER(ISNULL(DF.CodTarea,'SINLOTE')),' ',''),
                F.Cod_Bodega,
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
        )

        SELECT 
            Cod_Producto,
            Cod_Bodega,
            Numero_Lote,
            SUM(CantidadMovimiento) AS ExistenciaCalculada
        INTO #Calc
        FROM Movimientos
        GROUP BY Cod_Producto, Cod_Bodega, Numero_Lote

        SELECT 
            L.Cod_Productos,
            L.Cod_Bodega,
            REPLACE(UPPER(ISNULL(L.Numero_Lote,'SINLOTE')),' ','') AS Numero_Lote,
            L.Existencia AS ExistenciaTabla,
            ISNULL(C.ExistenciaCalculada,0) AS ExistenciaCalculada,
            L.Existencia - ISNULL(C.ExistenciaCalculada,0) AS Diferencia
        INTO #Dif
        FROM LotexProducto L
        LEFT JOIN #Calc C
            ON L.Cod_Productos = C.Cod_Producto
            AND L.Cod_Bodega = C.Cod_Bodega
            AND REPLACE(UPPER(ISNULL(L.Numero_Lote,'SINLOTE')),' ','') = C.Numero_Lote
        WHERE ABS(L.Existencia - ISNULL(C.ExistenciaCalculada,0)) > 0.01

        IF @Modo = 'CORREGIR'
        BEGIN
            UPDATE L
            SET L.Existencia = D.ExistenciaCalculada
            FROM LotexProducto L
            INNER JOIN #Dif D
                ON L.Cod_Productos = D.Cod_Productos
                AND L.Cod_Bodega = D.Cod_Bodega
                AND REPLACE(UPPER(ISNULL(L.Numero_Lote,'SINLOTE')),' ','') = D.Numero_Lote
        END

        SELECT * FROM #Dif

    END
    ELSE
    BEGIN
        ----------------------------------------
        -- 🔹 SIN LOTES (POR BODEGA)
        ----------------------------------------

        ;WITH Movimientos AS (

            SELECT 
                DC.Cod_Producto,
                C.Cod_Bodega,
                CASE 
                    WHEN C.Tipo_Compra IN ('Mercancia Recibida','Transferencia Recibida')
                        THEN DC.Cantidad
                    WHEN C.Tipo_Compra = 'Devolucion de Compra'
                        THEN -DC.Cantidad
                    ELSE 0
                END AS CantidadMovimiento
            FROM Detalle_Compras DC
            INNER JOIN Compras C
                ON DC.Numero_Compra = C.Numero_Compra
                AND DC.Fecha_Compra = C.Fecha_Compra
                AND DC.Tipo_Compra = C.Tipo_Compra

            UNION ALL

            SELECT 
                DF.Cod_Producto,
                F.Cod_Bodega,
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
        )

        SELECT 
            Cod_Producto,
            Cod_Bodega,
            SUM(CantidadMovimiento) AS ExistenciaCalculada
        INTO #CalcBodega
        FROM Movimientos
        GROUP BY Cod_Producto, Cod_Bodega

        SELECT 
            D.Cod_Productos,
            D.Cod_Bodega,
            D.Existencia AS ExistenciaTabla,
            ISNULL(C.ExistenciaCalculada,0) AS ExistenciaCalculada,
            D.Existencia - ISNULL(C.ExistenciaCalculada,0) AS Diferencia
        INTO #DifBodega
        FROM DetalleBodegas D
        LEFT JOIN #CalcBodega C
            ON D.Cod_Productos = C.Cod_Producto
            AND D.Cod_Bodega = C.Cod_Bodega
        WHERE ABS(D.Existencia - ISNULL(C.ExistenciaCalculada,0)) > 0.01

        IF @Modo = 'CORREGIR'
        BEGIN
            UPDATE D
            SET D.Existencia = C.ExistenciaCalculada
            FROM DetalleBodegas D
            INNER JOIN #CalcBodega C
                ON D.Cod_Productos = C.Cod_Producto
                AND D.Cod_Bodega = C.Cod_Bodega
        END

        SELECT * FROM #DifBodega

    END

END
GO