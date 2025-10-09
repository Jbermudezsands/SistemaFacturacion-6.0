    DECLARE
    @FechaCorte DATE = '2025-10-08',   -- Fecha límite
    @CodBodega NVARCHAR(50) = '01';  -- Código de bodega (puedes dejar NULL para todas)
	
	
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
        AND C.Activo = 1
        AND C.Tipo_Compra = 'Devolucion de Compra'
        AND P.Tipo_Producto NOT IN ('Servicio', 'Descuento')
        AND (C.Cod_Bodega = @CodBodega)
		AND (P.Cod_Productos ='02RVPAFBID')
    GROUP BY DC.Cod_Producto, C.Cod_Bodega