IF COL_LENGTH('dbo.DetallePagos', 'Anulado') IS NULL
BEGIN
    ALTER TABLE dbo.DetallePagos
    ADD Anulado bit NOT NULL
        CONSTRAINT DF_DetallePagos_Anulado DEFAULT (0);
END
GO