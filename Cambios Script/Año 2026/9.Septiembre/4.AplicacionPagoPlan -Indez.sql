CREATE NONCLUSTERED INDEX [IX_AplicacionPagoPlan_DetallePago]
ON [dbo].[AplicacionPagoPlan]
(
    [idDetallePago],
    [Anulado]
)
INCLUDE
(
    [MontoAplicado]
);
GO