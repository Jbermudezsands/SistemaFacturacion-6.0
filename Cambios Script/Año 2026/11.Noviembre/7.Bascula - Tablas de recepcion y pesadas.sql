-- Tablas del modulo de bascula (Conductor, Vehiculo, Recepcion, Detalle_Recepcion, Detalle_Pesadas).
-- Las usan FrmRecepcion, FrmBascula y FrmFacturacionBascula. Esquema tomado de SistemaFacturacionINFARSA.
-- Idempotente: solo crea las tablas que no existen.

IF OBJECT_ID(N'dbo.Conductor', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[Conductor] (
        [Codigo] varchar(50) NOT NULL,
        [Nombre] varchar(500) NULL,
        [Cedula] varchar(20) NULL,
        [Licencia] varchar(20) NULL,
        [Activo] bit NULL,
        [ListaNegra] bit NULL,
        [RazonListaNegra] varchar(2000) NULL,
        [Evacuaciones] bit DEFAULT ((0)) NULL,
        [Cuenta_Contable] nvarchar(50) NULL,
        [Precio] float NULL,
        [Cuenta_Banco] nvarchar(50) NULL,
        [Cuenta_IR] nvarchar(50) NULL,
        [Cuenta_Bolsa] nvarchar(50) NULL,
        [Cuenta_Anticipo] nvarchar(50) NULL,
        [Cuenta_Pulperia] nvarchar(50) NULL,
        [Cuenta_Transporte] nvarchar(50) NULL,
        [Cuenta_Inseminacion] nvarchar(50) NULL,
        [Cuenta_Trazabilidad] nvarchar(50) NULL,
        [Cuenta_Veterinario] nvarchar(50) NULL,
        [Cuenta_Otras] nvarchar(50) NULL,
        [Cuenta_GastoPlanilla] nvarchar(50) NULL,
        CONSTRAINT [PK_Conductor] PRIMARY KEY CLUSTERED ([Codigo])
    );
END
GO

IF OBJECT_ID(N'dbo.Vehiculo', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[Vehiculo] (
        [IdVehiculo] int IDENTITY(1,1) NOT NULL,
        [Placa] varchar(20) NULL,
        [Marca] nvarchar(50) NULL,
        [TipoVehiculo] nvarchar(50) NULL,
        [Activo] bit DEFAULT ((1)) NULL,
        [Evacuaciones] bit DEFAULT ((0)) NULL,
        CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED ([IdVehiculo])
    );
END
GO

IF OBJECT_ID(N'dbo.Recepcion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[Recepcion] (
        [NumeroRecepcion] nvarchar(50) NOT NULL,
        [TipoRecepcion] nvarchar(50) NOT NULL,
        [Fecha] date NULL,
        [Cod_Proveedor] nvarchar(50) NULL,
        [Cod_SubProveedor] nvarchar(50) NULL,
        [Conductor] varchar(50) NULL,
        [Id_identificacion] nvarchar(50) NULL,
        [Id_Vehiculo] int NULL,
        [Cod_Bodega] nvarchar(50) NULL,
        [Observaciones] nvarchar(MAX) NULL,
        [SubTotal] float NULL,
        [Telefono] nvarchar(50) NULL,
        [Cancelar] bit DEFAULT ((0)) NULL,
        [Activo] bit DEFAULT ((1)) NULL,
        [Seleccion] bit DEFAULT ((0)) NULL,
        [Peso] float NULL,
        [Lote] nvarchar(50) NULL,
        [Contabilizado] bit DEFAULT ((0)) NULL,
        [FechaHora] datetime NULL,
        [TipoPesada] nvarchar(50) NULL,
        [Numero_Compra] nvarchar(50) NULL,
        [Tipo_Compra] nvarchar(50) NULL,
        [Fecha_Compra] smalldatetime NULL,
        [Procesado] bit DEFAULT ((0)) NULL,
        [NombreRecolector] nvarchar(50) NULL,
        [TelefonoRecolector] nvarchar(50) NULL,
        [CedulaRecolector] nvarchar(50) NULL,
        [CalcularMermaOculta] bit DEFAULT ((0)) NULL,
        [CalcularMerma] bit DEFAULT ((0)) NULL,
        CONSTRAINT [PK_Recepcion] PRIMARY KEY CLUSTERED ([NumeroRecepcion], [TipoRecepcion])
    );
END
GO

IF OBJECT_ID(N'dbo.Detalle_Recepcion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[Detalle_Recepcion] (
        [id_Eventos] float NOT NULL,
        [NumeroRecepcion] nvarchar(50) NOT NULL,
        [TipoRecepcion] nvarchar(50) NOT NULL,
        [Cod_Productos] nvarchar(50) NULL,
        [Descripcion_Producto] nvarchar(250) NULL,
        [Cantidad] float NULL,
        [Unidad_Medida] nvarchar(50) NULL,
        [Transferido] bit DEFAULT ((0)) NULL,
        [Estado] nvarchar(50) NULL,
        [Precio] float NULL,
        [PesoKg] float NULL,
        [Tara] float NULL,
        [PesoNetoLb] float NULL,
        [PesoNetoKg] float NULL,
        [QQ] float NULL,
        [Liquidado] bit DEFAULT ((0)) NULL,
        [Codigo_Beams] nvarchar(50) NULL,
        [Codigo_BeamsOrigen] nvarchar(50) NULL,
        [RecepcionBin] nvarchar(50) NULL,
        [Calidad] nvarchar(50) NULL,
        [Fecha] date NULL,
        [Porcentaje_Merma] float NULL,
        [Merma] float NULL,
        [Merma2] float DEFAULT ((0)) NULL,
        [PesoKg2] float DEFAULT ((0)) NULL,
        [PesoNetoLb2] float DEFAULT ((0)) NULL,
        [PesoNetoKg2] float DEFAULT ((0)) NULL,
        CONSTRAINT [PK_Detalle_Recepcion] PRIMARY KEY CLUSTERED ([id_Eventos], [NumeroRecepcion], [TipoRecepcion])
    );
END
GO

IF OBJECT_ID(N'dbo.Detalle_Pesadas', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[Detalle_Pesadas] (
        [id_Eventos] float NOT NULL,
        [NumeroRemision] nvarchar(50) NOT NULL,
        [Fecha] smalldatetime NOT NULL,
        [TipoRemision] nvarchar(50) NOT NULL,
        [TipoPesada] nvarchar(50) NOT NULL,
        [Cod_Productos] nvarchar(50) NULL,
        [Descripcion_Producto] nvarchar(250) NULL,
        [Codigo_Beams] nvarchar(50) NULL,
        [Cantidad] float NULL,
        [Unidad_Medida] nvarchar(50) NULL,
        [Liquidado] bit DEFAULT ((0)) NULL,
        [Codigo_BeamsOrigen] nvarchar(50) NULL,
        [RecepcionBin] nvarchar(50) NULL,
        [Transferido] bit DEFAULT ((0)) NULL,
        [Calidad] nvarchar(50) NULL,
        [Estado] nvarchar(50) NULL,
        [Precio] float NULL,
        [PesoKg] float NULL,
        [Tara] float NULL,
        [PesoNetoLb] float NULL,
        [PesoNetoKg] float NULL,
        [QQ] float NULL,
        [Calidad_Cafe] nvarchar(50) DEFAULT (N'AP1ra') NULL,
        [FechaCarga] datetime NULL,
        [IdRemisionPergamino] int NULL,
        [IdDetallePesadas] int IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_Detalle_Pesadas] PRIMARY KEY CLUSTERED ([IdDetallePesadas])
    );
END
GO

