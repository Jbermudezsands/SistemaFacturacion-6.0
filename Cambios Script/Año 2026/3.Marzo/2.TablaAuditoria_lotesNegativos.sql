CREATE TABLE Auditoria_LotesNegativos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cod_Producto VARCHAR(50),
    Cod_Bodega VARCHAR(50),
    LoteIncorrecto VARCHAR(50),
    LoteSugerido VARCHAR(50),
    Documento VARCHAR(50),
    TipoDocumento VARCHAR(50),
    FechaMovimiento DATETIME,
    CantidadMovimiento DECIMAL(18,4),
    ExistenciaDespuesMovimiento DECIMAL(18,4),
    FechaAuditoria DATETIME DEFAULT GETDATE(),
    Reparado BIT DEFAULT 0
)