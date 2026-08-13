ALTER TABLE NombreTabla
ADD FechaRegistro DATETIME2(3) NOT NULL
    CONSTRAINT DF_NombreTabla_FechaRegistro
    DEFAULT (SYSDATETIME());
