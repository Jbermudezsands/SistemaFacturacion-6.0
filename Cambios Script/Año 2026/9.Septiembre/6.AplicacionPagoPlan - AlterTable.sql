USE [SistemaFacturacionNicacentro]
GO

/****** Object:  Table [dbo].[AplicacionPagoPlan]    Script Date: 09/09/2026 13:30:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.AplicacionPagoPlan
ADD
    CodReciboPago NVARCHAR(50) NOT NULL,
    Fecha_Recibo SMALLDATETIME NOT NULL,
    Numero_Factura NVARCHAR(50) NOT NULL;
GO