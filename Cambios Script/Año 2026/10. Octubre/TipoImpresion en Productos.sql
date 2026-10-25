-- Agrega el campo TipoImpresion a la tabla Productos.
-- Define a que impresora (segun Impresoras.dll) se envia el producto en la comanda del restaurante:
--   'Comanda'    -> impresora de cocina
--   'ComandaBar' -> impresora del bar
-- NULL / '' se trata como 'Comanda'. Script idempotente: se puede ejecutar varias veces.

IF COL_LENGTH('dbo.Productos', 'TipoImpresion') IS NULL
BEGIN
    ALTER TABLE dbo.Productos ADD TipoImpresion NVARCHAR(50) NULL;
END
GO

-- Los productos existentes siguen imprimiendo en cocina
UPDATE dbo.Productos SET TipoImpresion = 'Comanda' WHERE TipoImpresion IS NULL OR LTRIM(RTRIM(TipoImpresion)) = '';
GO
