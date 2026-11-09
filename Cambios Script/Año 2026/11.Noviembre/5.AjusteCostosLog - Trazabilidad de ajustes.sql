/* ============================================================================
   Trazabilidad de ajustes de costo.
   Cada vez que el sistema modifica Costo_Unitario / Precio_Unitario / Precio_Neto /
   Importe de Detalle_Facturas o Detalle_Compras (recosteo, reparacion de documentos,
   reparaciones de la auditoria) se guarda aqui UNA fila por linea modificada con
   el valor ANTERIOR y el NUEVO, quien lo hizo, desde que formulario y por que documento.
   Idempotente: se puede ejecutar varias veces.
   ============================================================================ */

IF OBJECT_ID(N'dbo.AjusteCostosLog', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AjusteCostosLog
    (
        IdLog                   BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AjusteCostosLog PRIMARY KEY,
        Lote                    UNIQUEIDENTIFIER     NOT NULL,   -- agrupa todo lo modificado en una misma ejecucion
        FechaHora               DATETIME             NOT NULL CONSTRAINT DF_AjusteCostosLog_Fecha DEFAULT (GETDATE()),
        Usuario                 NVARCHAR(100)        NULL,
        Equipo                  NVARCHAR(100)        NULL,
        Origen                  NVARCHAR(100)        NULL,       -- formulario / proceso (FrmActualiza.CmdCostear, FrmFacturas, ...)
        Referencia              NVARCHAR(200)        NULL,       -- documento que disparo el ajuste, o rango de productos
        Tabla                   NVARCHAR(30)         NOT NULL,   -- Detalle_Facturas | Detalle_Compras
        IdDetalle               DECIMAL(18, 0)       NOT NULL,   -- id_Detalle_Factura | id_Detalle_Compra
        Tipo_Documento          NVARCHAR(50)         NULL,
        Numero_Documento        NVARCHAR(50)         NULL,
        Fecha_Documento         DATETIME             NULL,
        Cod_Producto            NVARCHAR(50)         NULL,
        Cantidad                FLOAT                NULL,
        Costo_Anterior          FLOAT                NULL,
        Costo_Nuevo             FLOAT                NULL,
        PrecioUnitario_Anterior FLOAT                NULL,
        PrecioUnitario_Nuevo    FLOAT                NULL,
        PrecioNeto_Anterior     FLOAT                NULL,
        PrecioNeto_Nuevo        FLOAT                NULL,
        Importe_Anterior        FLOAT                NULL,
        Importe_Nuevo           FLOAT                NULL,
        Observaciones           NVARCHAR(500)        NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_AjusteCostosLog_Producto' AND object_id = OBJECT_ID(N'dbo.AjusteCostosLog'))
    CREATE INDEX IX_AjusteCostosLog_Producto ON dbo.AjusteCostosLog (Cod_Producto, FechaHora);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_AjusteCostosLog_Detalle' AND object_id = OBJECT_ID(N'dbo.AjusteCostosLog'))
    CREATE INDEX IX_AjusteCostosLog_Detalle ON dbo.AjusteCostosLog (Tabla, IdDetalle);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_AjusteCostosLog_Lote' AND object_id = OBJECT_ID(N'dbo.AjusteCostosLog'))
    CREATE INDEX IX_AjusteCostosLog_Lote ON dbo.AjusteCostosLog (Lote);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_AjusteCostosLog_Documento' AND object_id = OBJECT_ID(N'dbo.AjusteCostosLog'))
    CREATE INDEX IX_AjusteCostosLog_Documento ON dbo.AjusteCostosLog (Numero_Documento, Tipo_Documento);
GO

/* Ejemplos de consulta:
   -- Historia de un documento
   SELECT * FROM AjusteCostosLog WHERE Numero_Documento = '000123' ORDER BY FechaHora;
   -- Todo lo que cambio un recosteo
   SELECT * FROM AjusteCostosLog WHERE Lote = '...';
   -- Para volver a un valor anterior: Costo_Anterior de la fila mas antigua de esa linea
*/
