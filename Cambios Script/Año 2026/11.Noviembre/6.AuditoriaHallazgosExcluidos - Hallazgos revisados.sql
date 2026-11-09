/* ============================================================================
   Hallazgos de la auditoria marcados por el usuario como Revisado / Autoauditado /
   Declarado al fisco. Un hallazgo marcado deja de aparecer en las siguientes
   ejecuciones del Auditor (no se borra nada: queda quien, cuando y por que).
   Para volver a mostrarlo se pone Activo = 0 (ver ejemplo al final); la fila se conserva
   como evidencia.
   Idempotente: se puede ejecutar varias veces.
   ============================================================================ */

-- Necesarios para el indice filtrado (sqlcmd los trae apagados).
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.AuditoriaHallazgosExcluidos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AuditoriaHallazgosExcluidos
    (
        IdExclusion          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AuditoriaHallazgosExcluidos PRIMARY KEY,
        Clave                NVARCHAR(400)  NOT NULL,   -- Codigo|Tipo|Documento|Producto|IdDetalleFactura|IdDetalleCompra (mayusculas)
        Codigo               NVARCHAR(30)   NOT NULL,   -- control de auditoria (COST-001, TRANS-002, ...)
        Tipo_Documento       NVARCHAR(50)   NULL,
        Numero_Documento     NVARCHAR(50)   NULL,
        Fecha_Documento      DATETIME       NULL,
        Cod_Producto         NVARCHAR(50)   NULL,
        IdDetalleFactura     DECIMAL(18, 0) NOT NULL CONSTRAINT DF_AHE_IdDF DEFAULT (0),
        IdDetalleCompra      DECIMAL(18, 0) NOT NULL CONSTRAINT DF_AHE_IdDC DEFAULT (0),
        Cantidad             FLOAT          NULL,      -- valores del hallazgo al momento de marcarlo (evidencia)
        PrecioUnitario       FLOAT          NULL,
        CostoUnitario        FLOAT          NULL,
        Descripcion          NVARCHAR(500)  NULL,
        Clasificacion        NVARCHAR(30)   NOT NULL,   -- Revisado | Autoauditado | Declarado al fisco
        Motivo               NVARCHAR(500)  NOT NULL,
        Usuario              NVARCHAR(100)  NULL,
        Equipo               NVARCHAR(100)  NULL,
        FechaMarca           DATETIME       NOT NULL CONSTRAINT DF_AHE_Fecha DEFAULT (GETDATE()),
        Activo               BIT            NOT NULL CONSTRAINT DF_AHE_Activo DEFAULT (1),
        UsuarioReactivacion  NVARCHAR(100)  NULL,
        FechaReactivacion    DATETIME       NULL,
        MotivoReactivacion   NVARCHAR(500)  NULL
    );
END
GO

-- Un hallazgo solo puede estar excluido una vez mientras este activo.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_AHE_Clave_Activo' AND object_id = OBJECT_ID(N'dbo.AuditoriaHallazgosExcluidos'))
    CREATE UNIQUE INDEX UX_AHE_Clave_Activo ON dbo.AuditoriaHallazgosExcluidos (Clave) WHERE Activo = 1;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_AHE_Documento' AND object_id = OBJECT_ID(N'dbo.AuditoriaHallazgosExcluidos'))
    CREATE INDEX IX_AHE_Documento ON dbo.AuditoriaHallazgosExcluidos (Numero_Documento, Tipo_Documento);
GO

/* Ejemplos:
   -- Que se ha marcado y por quien
   SELECT * FROM AuditoriaHallazgosExcluidos WHERE Activo = 1 ORDER BY FechaMarca DESC;
   -- Volver a mostrar un hallazgo en la auditoria
   UPDATE AuditoriaHallazgosExcluidos
      SET Activo = 0, UsuarioReactivacion = 'usuario', FechaReactivacion = GETDATE(), MotivoReactivacion = 'motivo'
    WHERE IdExclusion = 1;
*/
