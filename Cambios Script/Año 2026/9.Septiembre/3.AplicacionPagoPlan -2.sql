ALTER TABLE [dbo].[AplicacionPagoPlan]
ADD CONSTRAINT [FK_AplicacionPagoPlan_DetallePagos]
FOREIGN KEY ([idDetallePago])
REFERENCES [dbo].[DetallePagos] ([idDetallePago]);
GO