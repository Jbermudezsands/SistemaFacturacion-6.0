IF COL_LENGTH('dbo.PlanPagos', 'MonedaFactura') IS NULL
BEGIN
    ALTER TABLE dbo.PlanPagos
    ADD MonedaFactura nvarchar(50) NULL;
END
GO