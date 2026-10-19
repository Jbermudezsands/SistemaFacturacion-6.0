CREATE NONCLUSTERED INDEX [IX_AplicacionPagoPlan_DetalleRecibo]
ON [dbo].[AplicacionPagoPlan]
(
    [idDetalleRecibo],
    [Anulado]
)
INCLUDE
(
    [MontoAplicado],
    [idDetallePago]
);
GO