CREATE TABLE [dbo].[PreciosProductor]
(
    [CodProductor]      [nvarchar](50) NOT NULL,
    [TipoProductor]     [nvarchar](50) NOT NULL,
    [Cod_Productos]     [nvarchar](50) NOT NULL,
    [Monto_Precio]      [decimal](18,4) NOT NULL,
    [Monto_PrecioDolar] [decimal](18,4) NOT NULL,
    [FechaActualizacion] [datetime2](3) NOT NULL,

    CONSTRAINT [PK_PreciosProductor]
        PRIMARY KEY CLUSTERED
        (
            [CodProductor],
            [TipoProductor],
            [Cod_Productos]
        ),

    CONSTRAINT [FK_PreciosProductor_Productor]
        FOREIGN KEY
        (
            [CodProductor],
            [TipoProductor]
        )
        REFERENCES [dbo].[Productor]
        (
            [CodProductor],
            [TipoProductor]
        )
);
GO

ALTER TABLE [dbo].[PreciosProductor]
ADD CONSTRAINT [DF_PreciosProductor_Monto_Precio]
DEFAULT ((0)) FOR [Monto_Precio];
GO

ALTER TABLE [dbo].[PreciosProductor]
ADD CONSTRAINT [DF_PreciosProductor_Monto_PrecioDolar]
DEFAULT ((0)) FOR [Monto_PrecioDolar];
GO

ALTER TABLE [dbo].[PreciosProductor]
ADD CONSTRAINT [DF_PreciosProductor_FechaActualizacion]
DEFAULT (sysdatetime()) FOR [FechaActualizacion];
GO