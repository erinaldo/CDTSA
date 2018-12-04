CREATE TABLE dbo.cppProveedor(
	IDProveedor INT NOT NULL,
	Nombre NVARCHAR(250),
	Alias NVARCHAR(250),
	Contacto NVARCHAR(250),
	IDRuc INT,
	Telefonos NVARCHAR(50),
	IDImpuesto INT,
	IDCategoria INT,
	FechaIngreso DATETIME,
	Activo BIT DEFAULT 1,
	MultiMoneda BIT DEFAULT 0,
	PagosCongelador BIT DEFAULT 0,
	IsLocal BIT DEFAULT 0,
	TipoContribuyente INT
CONSTRAINT [pkcppProveedor] PRIMARY KEY CLUSTERED 
(
	IDProveedor ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.invEstadoOrdenCompra(
	IDEstadoOrden INT NOT NULL,
	Descr NVARCHAR(250),
	Activo BIT DEFAULT 1
CONSTRAINT [pkinvEstadoOrdenCompra] PRIMARY KEY CLUSTERED 
(
	IDEstadoOrden ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.ccpCondicionPago(
	IDCondicionPago INT NOT NULL,
	Descr NVARCHAR(250),
	Dias INT NOT NULL,
	DescuentoContado DECIMAL(28,4),
	PagosParciales BIT DEFAULT 0,
	Activo BIT DEFAULT 1
CONSTRAINT [pkccpCondicionPago] PRIMARY KEY CLUSTERED 
(
	IDCondicionPago ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.invTipoProrrateoRubrosCompra(
	IDTipoProrrateo INT NOT NULL,
	Descr NVARCHAR(250),
	Activo BIT DEFAULT 1
CONSTRAINT pkinvTipoProrrateoRubrosCompra PRIMARY KEY CLUSTERED 
(
	IDTipoProrrateo ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.invEstadoSolicitud(
	IDEstado int NOT NULL,
	Descr nvarchar(250),
	Activo bit DEFAULT 1,
CONSTRAINT pkinvEstadoSolicitud PRIMARY KEY CLUSTERED 
(
	IDEstado ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.invSolicitudCompra(
	IDSolicitud int NOT NULL,
	Fecha date,
	FechaRequerida date,
	IDEstado int,
	Comentario nvarCHAR(250),
	IDOrdenCompra int,
	UsuarioSolicitud nvarchar(50),
	UsuarioCreaOC nvarchar(50),
	FechaCreaOC datetime,
	CreateDate datetime,
	CreatedBy nvarchar(50),
	RecordDate datetime,
	UpdateBy nvarchar(50)
	CONSTRAINT pkinvSolicitudCompra PRIMARY KEY CLUSTERED 
(
	IDSolicitud ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invSolicitudCompra]  WITH CHECK ADD  CONSTRAINT [fkinvSolicitudCompra_EstadoSolicitud] FOREIGN KEY([IDEstado])
REFERENCES [dbo].invEstadoSolicitud (IDEstado)


GO

CREATE TABLE dbo.invSolicitudCompraDetalle (
	IDSolicitud INT NOT NULL,
	IDProducto INT NOT NULL,
	Cantidad DECIMAL(28,4) DEFAULT  0,
	Comentario NVARCHAR(20) ,
CONSTRAINT [pkinvSolicitudCompraDetalle] PRIMARY KEY CLUSTERED 
(
	IDSolicitud ASC,
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invSolicitudCompraDetalle]  WITH CHECK ADD  CONSTRAINT [fkinvSolicitudCompraDetalle_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)


GO


CREATE TABLE [dbo].[invOrdenCompra](
	[IDOrdenCompra] [int] NOT NULL,
	[OrdenCompra] [nvarchar](20) NOT NULL,
	Fecha [datetime] ,
	FechaRequerida DATE,
	FechaEmision DATE,
	FechaRequeridaEmbarque DATE,
	FechaCotizacion DATE,
	[IDEstado] INT,
	[IDBodega] INT,
	[IDProveedor] INT,
	[IDMoneda] INT,
	[IDCondicionPago] INT,
	Descuento DECIMAL(28,4),
	Flete DECIMAL(28,4),
	Documentacion DECIMAL(28,4),
	Anticipos decimal(28,4),
	IDTipoProrrateo INt,
	IDEmbarque INT,
	IDSolicitud INT,
	IDDocumentoCP INT,
	TipoCambio DECIMAL(28,4),
	Usuario NVARCHAR(50) NOT NULL,
	UsuarioCreaEmbarque NVARCHAR(50) NOT	NULL,
	FechaCreaEmbarque datetime,
	UsuarioAprobacion NVARCHAR(50) NOT NULL,
	FechaAprobacion datetime,
	CreateDate datetime,
	CreatedBy nvarchar(50),
	RecordDate datetime,
	UpdateBy nvarchar(50)
 CONSTRAINT [pkinvOrdenCompra] PRIMARY KEY CLUSTERED 
(
	[IDOrdenCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invOrdenCompra]  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompra_Proveedor] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[ccpProveedor] ([IDProveedor])
GO

ALTER TABLE [dbo].[invOrdenCompra]  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompra_GlobalMoneda] FOREIGN KEY([IDMoneda])
REFERENCES [dbo].globalMoneda (IDMoneda)
GO


ALTER TABLE [dbo].[invOrdenCompra]  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompra_Bodega] FOREIGN KEY([IDBodega])
REFERENCES [dbo].invBodega (IDBodega)
GO


ALTER TABLE [dbo].[invOrdenCompra]  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompra_CondicionPago] FOREIGN KEY([IDCondicionPago])
REFERENCES [dbo].cppCondicionPago (IDCondicionPago)
GO


ALTER TABLE [dbo].[invOrdenCompra]  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompra_TipoProrrateo] FOREIGN KEY([IDTipoProrrateo])
REFERENCES [dbo].invTipoProrrateoRubrosCompra (IDTipoProrrateo)
GO


CREATE TABLE dbo.invOrdenCompraDetalle (
	IDOrdenCompra INT NOT NULL,
	IDProducto INT NOT NULL,
	Cantidad DECIMAL(28,4) DEFAULT  0,
	CantidadAceptada DECIMAL(28,4) DEFAULT 0,
	CantidadRechazada  DECIMAL(28,4) DEFAULT 0,
	PrecioUnitario DECIMAL(28,4)  DEFAULT 0,
	Impuesto DECIMAL(28,4) DEFAULT 0,
	PorcDesc  DECIMAL(28,4) DEFAULT 0,
	MontoDesc DECIMAL(28,4)  DEFAULT 0,
	Estado INT ,
	Comentario NVARCHAR(20) ,
CONSTRAINT [pkinvOrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[IDOrdenCompra] ASC,
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].invOrdenCompraDetalle  WITH CHECK ADD  CONSTRAINT [fkinvOrdenCompraDetalle_Prodcuto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)


GO
CREATE TABLE [dbo].[invEmbarque](
	[IDEmbarque] [int] NOT NULL,
	[Embarque] nvarchar(20) NOT NULL,
	Fecha [datetime] ,
	FechaEmbarque DATE,
	Asiento nvarchar(20),
	[IDBodega] INT,
	[IDProveedor] INT,
	[IDOrdenCompra] int,
	IDSolicitud INT,
	IDDocumentoCP INT,
	TipoCambio DECIMAL(28,4),
	Usuario NVARCHAR(50) NOT NULL,
	CreateDate datetime,
	CreatedBy nvarchar(50),
	RecordDate datetime,
	UpdateBy nvarchar(50)
 CONSTRAINT [pkinvEmbarque] PRIMARY KEY CLUSTERED 
(
	[IDEmbarque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invEmbarque]  WITH CHECK ADD  CONSTRAINT [fkinvEmbarque_Bodega] FOREIGN KEY(IDBodega)
REFERENCES [dbo].invBodega (IDBodega)
GO

ALTER TABLE [dbo].[invEmbarque]  WITH CHECK ADD  CONSTRAINT [fkinvEmbarque_OrdenCompra] FOREIGN KEY(IDOrdenCompra)
REFERENCES [dbo].OrdenCompra (IDOrdenCompra)
GO


ALTER TABLE [dbo].[invEmbarque]  WITH CHECK ADD  CONSTRAINT [fkinvEmbarque_SolicitudCompra] FOREIGN KEY(IDSolicitud)
REFERENCES [dbo].invSolicitudCompra (IDSolicitud)
GO

--// TODO Pendiente crear tabla de Cuentas por pagar
--ALTER TABLE [dbo].[invEmbarque]  WITH CHECK ADD  CONSTRAINT [fkinvEmbarque_DocumentoCP] FOREIGN KEY(IDDocumentoCP)
--REFERENCES [dbo].ccpDocumentoCP (IDDocumentoCP)
--GO


CREATE TABLE dbo.invEmbarqueDetalle (
	IDEmbarque INT NOT NULL,
	IDProducto INT NOT NULL,
	IDLote int NOT NULL,
	Cantidad DECIMAL(28,4) DEFAULT  0,
	CantidadAceptada DECIMAL(28,4) DEFAULT 0,
	CantidadRechazada  DECIMAL(28,4) DEFAULT 0,
	Comentario NVARCHAR(20) ,
CONSTRAINT [pkinvOrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[IDOrdenCompra] ASC,
	[IDProducto] ASC,
	IDLote ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkiinvEmbarqueDetalle_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)

GO
ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkiinvEmbarqueDetalle_Lote] FOREIGN KEY([IDProducto,IDLote])
REFERENCES [dbo].invLote (IDProducto,IDLote)


GO

CREATE TABLE dbo.invArticuloProveedor (
	IDProducto int NOT NULL,
	IDProveedor int NOT NULL,
	IDPaisManofactura int,
	LoteMinCompra decimal(28,4),
	CantEconomicaCompra decimal(28,4),
	LoteEstandardCompra decimal(28,4),
	PesoMinimoCompra decimal(28,4),
	MultimoCompra decimal(28,4),
	UnidadAlmacenamiento decimal(28,4),
	UnidadMedidaCompra decimal(28,4),
	FactorConversion decimal(28,4), 
	CONSTRAINT [pkinvOrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[IDProducto] ASC,
	IDProveedor ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].invArticuloProveedor  WITH CHECK ADD  CONSTRAINT [fkinvArticuloProveedor_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)

GO
ALTER TABLE [dbo].invArticuloProveedor  WITH CHECK ADD  CONSTRAINT [fkinvArticuloProveedor_Proveedor] FOREIGN KEY(IDProveedor)
REFERENCES [dbo].ccpProveedor (IDProveedor)


GO


CREATE TABLE dbo.invParametrosCompra(
	IDParametro int,
	IDConsecSolicitud int	,
	IDConsecOrdenCompra int,
	IDConsecEmbarque int,
	IDConsecDevolucion int,
	CantLineasOrdenCompra int,
	IDBodegaDefault int,
	IDTipoCambio int,
	CantDecimalesPrecio int	,
	CantDecimalesCantidad int	,
	IDTipoAsientoContable int,
	IDPaquete int,
	CtaTransitoLocal bigInt,
	CtrTransitoLocal int,
	CtaTransitoExterior bigint,
	CtrTransifoExterior int,
	AplicaAutomaticamenteAsiento bit DEFAULT 0,
	CanEditAsiento bit DEFAULT 1,
	CanViewAsiento bit DEFAULT 1,
	CONSTRAINT [pkinvParametrosCompra] PRIMARY KEY CLUSTERED 
(
	IDParametro ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]