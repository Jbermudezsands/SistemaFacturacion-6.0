/* ============================================================
   APLICACION DE RECIBOS A CUOTAS DE CREDITOS
   ============================================================ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* ============================================================
   ELIMINAR SI EXISTE
   ============================================================ */

IF OBJECT_ID('dbo.AplicacionPagoCredito', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.AplicacionPagoCredito;
END
GO


/* ============================================================
   CREAR TABLA
   ============================================================ */

CREATE TABLE dbo.AplicacionPagoCredito
(
    idAplicacionPagoCredito bigint IDENTITY(1,1) NOT NULL,

    idDetallePago int NOT NULL,

    /* Referencia al detalle exacto del recibo */
    idDetalleRecibo numeric(18,0) NOT NULL,
    CodReciboPago nvarchar(50) NOT NULL,
    Fecha_Recibo smalldatetime NOT NULL,
    Numero_Factura nvarchar(50) NOT NULL,

    MontoAplicado decimal(18,2) NOT NULL,

    FechaAplicacion smalldatetime NOT NULL
        CONSTRAINT DF_AplicacionPagoCredito_FechaAplicacion
        DEFAULT (GETDATE()),

    CONSTRAINT PK_AplicacionPagoCredito
        PRIMARY KEY CLUSTERED
        (
            idAplicacionPagoCredito
        ),

    CONSTRAINT FK_AplicacionPagoCredito_DetallePagos
        FOREIGN KEY
        (
            idDetallePago
        )
        REFERENCES dbo.DetallePagos
        (
            idDetallePago
        ),

    CONSTRAINT FK_AplicacionPagoCredito_DetalleRecibo
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
        ),

    CONSTRAINT CK_AplicacionPagoCredito_MontoAplicado
        CHECK
        (
            MontoAplicado > 0
        )
);
GO


/* ============================================================
   INDICE PARA CONSULTAR LAS APLICACIONES DE UNA CUOTA
   ============================================================ */

CREATE NONCLUSTERED INDEX IX_AplicacionPagoCredito_DetallePago
ON dbo.AplicacionPagoCredito
(
    idDetallePago
)
INCLUDE
(
    idDetalleRecibo,
    CodReciboPago,
    Fecha_Recibo,
    Numero_Factura,
    MontoAplicado,
    FechaAplicacion
);
GO


/* ============================================================
   INDICE PARA CONSULTAR LAS APLICACIONES DE UN RECIBO
   ============================================================ */

CREATE NONCLUSTERED INDEX IX_AplicacionPagoCredito_DetalleRecibo
ON dbo.AplicacionPagoCredito
(
    idDetalleRecibo,
    CodReciboPago,
    Fecha_Recibo,
    Numero_Factura
)
INCLUDE
(
    idDetallePago,
    MontoAplicado,
    FechaAplicacion
);
GO