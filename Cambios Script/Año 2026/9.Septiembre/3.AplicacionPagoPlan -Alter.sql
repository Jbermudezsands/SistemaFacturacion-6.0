ALTER TABLE [dbo].[AplicacionPagoPlan]
ADD CONSTRAINT [DF_AplicacionPagoPlan_Anulado]
DEFAULT ((0)) FOR [Anulado];
GO

ALTER TABLE [dbo].[AplicacionPagoPlan]
ADD CONSTRAINT [DF_AplicacionPagoPlan_FechaAplicacion]
DEFAULT (sysdatetime()) FOR [FechaAplicacion];
GO

ALTER TABLE [dbo].[AplicacionPagoPlan]
ADD CONSTRAINT [DF_AplicacionPagoPlan_FechaRegistro]
DEFAULT (sysdatetime()) FOR [FechaRegistro];
GO