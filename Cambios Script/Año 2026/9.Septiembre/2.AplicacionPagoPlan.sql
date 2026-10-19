CREATE TABLE [dbo].[AplicacionPagoPlan]
(
    [idAplicacion] [int] IDENTITY(1,1) NOT NULL,

    [idDetallePago] [int] NOT NULL,
    [idDetalleRecibo] [numeric](18,0) NOT NULL,

    [MontoAplicado] [decimal](18,2) NOT NULL,

    [FechaAplicacion] [datetime2](3) NOT NULL,
    [UsuarioAplicacion] [nvarchar](50) NULL,

    [Anulado] [bit] NOT NULL,

    [FechaAnulacion] [datetime2](3) NULL,
    [UsuarioAnulacion] [nvarchar](50) NULL,
    [MotivoAnulacion] [nvarchar](250) NULL,

    [FechaRegistro] [datetime2](3) NOT NULL,

    CONSTRAINT [PK_AplicacionPagoPlan]
        PRIMARY KEY CLUSTERED
        (
            [idAplicacion] ASC
        )
);
GO