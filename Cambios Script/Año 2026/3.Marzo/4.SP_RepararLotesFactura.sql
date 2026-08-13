CREATE PROCEDURE SP_RepararLoteFactura
(
    @IdAuditoria INT
)
AS
BEGIN

SET NOCOUNT ON

DECLARE 
    @CodProducto NVARCHAR(50),
    @CodBodega NVARCHAR(50),
    @Documento NVARCHAR(50),
    @TipoDocumento NVARCHAR(50),
    @LoteIncorrecto NVARCHAR(50),
    @LoteCorrecto NVARCHAR(50)

SELECT
    @CodProducto = Cod_Producto,
    @CodBodega = Cod_Bodega,
    @Documento = Documento,
    @TipoDocumento = TipoDocumento,
    @LoteIncorrecto = LoteIncorrecto,
    @LoteCorrecto = LoteSugerido
FROM Auditoria_LotesNegativos
WHERE Id = @IdAuditoria


-- Actualizar lote en la factura
UPDATE DF
SET CodTarea = @LoteCorrecto
FROM Detalle_Facturas DF
INNER JOIN Facturas F
    ON DF.Numero_Factura = F.Numero_Factura
    AND DF.Fecha_Factura = F.Fecha_Factura
    AND DF.Tipo_Factura = F.Tipo_Factura
WHERE
    DF.Cod_Producto = @CodProducto
    AND F.Cod_Bodega = @CodBodega
    AND DF.CodTarea = @LoteIncorrecto
    AND DF.Numero_Factura = @Documento


-- Marcar auditoría como reparada
UPDATE Auditoria_LotesNegativos
SET Reparado = 1
WHERE Id = @IdAuditoria

END