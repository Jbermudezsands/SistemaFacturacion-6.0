CREATE PROCEDURE SP_RepararLotesNegativos
AS
BEGIN

UPDATE DF
SET DF.CodTarea = A.LoteSugerido
FROM Detalle_Facturas DF
INNER JOIN Auditoria_LotesNegativos A
ON DF.Numero_Factura = A.Documento
AND DF.Cod_Producto = A.Cod_Producto
AND DF.CodTarea = A.LoteIncorrecto
WHERE A.Reparado = 0

UPDATE Auditoria_LotesNegativos
SET Reparado = 1
WHERE Reparado = 0

END