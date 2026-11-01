-- Arqueo de caja: guarda el efectivo esperado (facturas + recibos) y la tasa de cambio al iniciar el arqueo.
-- Permite reabrir un arqueo con los mismos totales del cierre y marcar el efectivo como arqueado
-- para que un segundo arqueo del mismo cajero y dia no lo cuente otra vez.
-- Script idempotente. Ejecutar ANTES de usar la version nueva de FrmArqueo.

IF COL_LENGTH('dbo.Arqueo', 'EfectivoEsperadoCordobas') IS NULL
    ALTER TABLE dbo.Arqueo ADD EfectivoEsperadoCordobas DECIMAL(18, 4) NULL;
GO

IF COL_LENGTH('dbo.Arqueo', 'EfectivoEsperadoDolares') IS NULL
    ALTER TABLE dbo.Arqueo ADD EfectivoEsperadoDolares DECIMAL(18, 4) NULL;
GO

IF COL_LENGTH('dbo.Arqueo', 'TasaCambio') IS NULL
    ALTER TABLE dbo.Arqueo ADD TasaCambio DECIMAL(18, 4) NULL;
GO

-- Los arqueos anteriores quedan con NULL: la aplicacion los sigue calculando en vivo, como antes.
