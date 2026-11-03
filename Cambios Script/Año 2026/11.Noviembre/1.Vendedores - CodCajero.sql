-- Relaciona el vendedor con un cajero (Facturacion Restaurante / Arqueo de caja)
IF COL_LENGTH('dbo.Vendedores', 'CodCajero') IS NULL
    ALTER TABLE dbo.Vendedores ADD CodCajero VARCHAR(50) NULL
GO
