ALTER TABLE dbo.AplicacionPagoPlan
WITH CHECK ADD CONSTRAINT FK_AplicacionPagoPlan_DetalleRecibo
FOREIGN KEY
(
    idDetalleRecibo,
    CodReciboPago,
    Fecha_Recibo,
    Numero_Factura
)
REFERENCES dbo.DetalleRecibo
(
    idDetalleRecibo,
    CodReciboPago,
    Fecha_Recibo,
    Numero_Factura
);
GO