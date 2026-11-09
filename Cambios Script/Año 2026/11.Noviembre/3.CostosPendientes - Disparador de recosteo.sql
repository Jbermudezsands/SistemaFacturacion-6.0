/*
  Motor de Costos - cola de recosteo.
  Cuando se inserta, edita o elimina una compra (Mercancia Recibida / Devolucion de Compra) cambia el
  promedio de ese producto desde esa fecha en adelante. Este disparador registra (producto, fecha desde)
  en CostosPendientes; el sistema la procesa con MotorCostos.ProcesarPendientes() y recalcula SOLO
  las filas posteriores a esa fecha.
  Script idempotente.
*/

IF OBJECT_ID('dbo.CostosPendientes') IS NULL
BEGIN
    CREATE TABLE dbo.CostosPendientes
    (
        Id             INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CostosPendientes PRIMARY KEY,
        Cod_Producto   NVARCHAR(100) NOT NULL,
        FechaDesde     SMALLDATETIME NOT NULL,
        FechaRegistro  DATETIME      NOT NULL CONSTRAINT DF_CostosPendientes_Fecha DEFAULT (GETDATE())
    );
    CREATE INDEX IX_CostosPendientes_Producto ON dbo.CostosPendientes (Cod_Producto);
END
GO

IF OBJECT_ID('dbo.TR_Detalle_Compras_CostosPendientes') IS NOT NULL
    DROP TRIGGER dbo.TR_Detalle_Compras_CostosPendientes;
GO

CREATE TRIGGER dbo.TR_Detalle_Compras_CostosPendientes
ON dbo.Detalle_Compras
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- En una edicion solo importan los campos que mueven el promedio.
    -- (El propio recosteo solo escribe Costo_Unitario, por eso no se vuelve a encolar.)
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
       AND NOT (UPDATE(Cantidad) OR UPDATE(Precio_Neto) OR UPDATE(Fecha_Compra)
                OR UPDATE(Cod_Producto) OR UPDATE(Tipo_Compra))
        RETURN;

    INSERT INTO dbo.CostosPendientes (Cod_Producto, FechaDesde)
    SELECT m.Cod_Producto, MIN(m.Fecha_Compra)
    FROM (
        SELECT Cod_Producto, Fecha_Compra FROM inserted
         WHERE Tipo_Compra IN (N'Mercancia Recibida', N'Devolucion de Compra')
        UNION ALL
        SELECT Cod_Producto, Fecha_Compra FROM deleted
         WHERE Tipo_Compra IN (N'Mercancia Recibida', N'Devolucion de Compra')
    ) m
    WHERE m.Cod_Producto IS NOT NULL AND m.Fecha_Compra IS NOT NULL
    GROUP BY m.Cod_Producto;
END
GO
