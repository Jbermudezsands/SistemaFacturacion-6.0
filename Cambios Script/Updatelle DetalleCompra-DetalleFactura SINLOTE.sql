BEGIN TRAN

UPDATE Detalle_Compras
SET Numero_Lote = 'SINLOTE'
WHERE 
    Numero_Lote IS NULL
    OR LTRIM(RTRIM(Numero_Lote)) = ''
    OR REPLACE(UPPER(Numero_Lote),' ','') = 'SINLOTE';

UPDATE Detalle_Facturas
SET CodTarea = 'SINLOTE'
WHERE 
    CodTarea IS NULL
    OR LTRIM(RTRIM(CodTarea)) = ''
    OR REPLACE(UPPER(CodTarea),' ','') = 'SINLOTE';

-- Verifica registros afectados
SELECT @@ROWCOUNT;

-- Si todo está correcto:
COMMIT;

-- Si algo no te gusta:
-- ROLLBACK;
