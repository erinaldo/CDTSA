
CREATE TABLE [dbo].[invGrupoClasif](
	[IDGrupo] [int] NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Activo] [bit] NULL DEFAULT 1,
	[Etiqueta] [nvarchar](250) NULL DEFAULT 'ND',
 CONSTRAINT [pkinvGrupoClasif] PRIMARY KEY CLUSTERED 
(
	[IDGrupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[invClasificacion](
	[IDClasificacion] [int] NOT NULL,
	[Descr] [nvarchar](250) NOT NULL,
	[IDGrupo] [int] NOT NULL,
	[Activo] [bit] NULL DEFAULT 1,
 CONSTRAINT [pkinvClasificacion] PRIMARY KEY CLUSTERED 
(
	[IDClasificacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invClasificacion]  WITH CHECK ADD  CONSTRAINT [fkinvClasificacion] FOREIGN KEY([IDGrupo])
REFERENCES [dbo].[invGrupoClasif] ([IDGrupo])
GO

ALTER TABLE [dbo].[invClasificacion] CHECK CONSTRAINT [fkinvClasificacion]
GO

CREATE TABLE [dbo].[invUnidadMedida](
	[IDUnidad] [int] IDENTITY(1,1) NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Activo] [bit] NOT NULL DEFAULT 1,
 CONSTRAINT [pkinvUnidadMedida] PRIMARY KEY CLUSTERED 
(
	[IDUnidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[invProducto](
	[IDProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Descr] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](20) NULL,
	[CostoUltLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[CostoUltDolar] [decimal](28, 4) NOT NULL DEFAULT 0,
	[CostoPromLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[CostoPromDolar] [decimal](28, 4) NOT NULL DEFAULT 0,
	[PrecioPublicoLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[PrecioFarmaciaLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[PrecioCIFLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[PrecioFOBLocal] [decimal](28, 4) NOT NULL DEFAULT 0,
	[PrecioDolar] [decimal](28, 4)  NOT NULL DEFAULT 0,
	[Clasif1] [int] NOT NULL DEFAULT 1,
	[Clasif2] [int] NOT NULL DEFAULT 2,
	[Clasif3] [int] NOT NULL DEFAULT 3,
	[Clasif4] [int] NOT NULL DEFAULT 4,
	[Clasif5] [int] NOT NULL DEFAULT 5,
	[Clasif6] [int] NOT NULL DEFAULT 6,
	[CodigoBarra] [nvarchar](50) NULL,
	[IDUnidad] [int] NOT NULL,
	[FactorEmpaque] [decimal](28, 4) NULL DEFAULT 1,
	[TipoImpuesto] INT NOT NULL,
	[EsMuestra] BIT DEFAULT 0,
	[EsControlado] BIT DEFAULT 0,
	[EsEtico] BIT DEFAULT 0,
	[BajaPrecioDistribuidor] BIT DEFAULT 0,
	[BajaPrecioProveedor] BIT DEFAULT 0,
	[PorcDescuentoAlzaProveedor] DECIMAL(28,4) DEFAULT 0,
	[BonificaFA] BIT DEFAULT 0,
	[BonificaCOPorCada] DECIMAL(28,4) DEFAULT 0,
	[BonificaCOCantidad] DECIMAL(28,4) DEFAULT 0,
	[Activo] [bit] NOT NULL DEFAULT 1,
	[UserInsert] NVARCHAR(50) NULL,
	[UserUpdate] NVARCHAR(50) NULL,
	[CreateDate] [datetime] NOT NULL DEFAULT (GETDATE()),
	[UpdateDate] DATETIME NULL,
 CONSTRAINT [pkinvProducto] PRIMARY KEY CLUSTERED 
(
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas1] FOREIGN KEY([Clasif1])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas1]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas2] FOREIGN KEY([Clasif2])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas2]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas3] FOREIGN KEY([Clasif3])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas3]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas4] FOREIGN KEY([Clasif4])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas4]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas5] FOREIGN KEY([Clasif5])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas5]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoclas6] FOREIGN KEY([Clasif6])
REFERENCES [dbo].[invClasificacion] ([IDClasificacion])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoclas6]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoUnd] FOREIGN KEY([IDUnidad])
REFERENCES [dbo].[invUnidadMedida] ([IDUnidad])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoUnd]
GO


CREATE TABLE [dbo].[invBodega](
	[IDBodega] [int] IDENTITY(1,1) NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Activo] [bit] NOT NULL DEFAULT 1,
	[PuedeFacturar] BIT DEFAULT 0,
	[PuedePreFacturar] BIT DEFAULT 0,
	[ConsucutivoFactura]  INT NULL,
	[ConsecutivoPreFactura] INT NULL
 CONSTRAINT [pkinvBodega] PRIMARY KEY CLUSTERED 
(
	[IDBodega] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO


CREATE  TABLE [dbo].[invLote](
	[IDLote] [int] NOT NULL,
	[IDProducto] bigint NOT NULL,
	[LoteInterno] [nvarchar](50) NULL,
	[LoteProveedor] [nvarchar](50) NULL,
	[FechaVencimiento] [smalldatetime] NULL,
	[FechaFabricacion] [smalldatetime] NULL,
	[FechaIngreso] [datetime] NOT NULL DEFAULT (GETDATE())
 CONSTRAINT [PKINVLOTE] PRIMARY KEY CLUSTERED 
(
	[IDLote] ASC,
	[IDProducto] ASC 
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invLote]  WITH CHECK ADD  CONSTRAINT [FK_invLote_invProducto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[invPRODUCTO] ([IDProducto])
GO

ALTER TABLE [dbo].[invLote] CHECK CONSTRAINT [FK_invLote_invProducto]
GO


CREATE TABLE [dbo].[invExistenciaBodega](
	[IDBodega] [int] NOT NULL,
	[IDProducto] [bigint] NOT NULL,
	[IDLote] [int] NOT NULL DEFAULT 0,
	[Existencia] [decimal](28, 4) NULL DEFAULT 0,
	[Reservada] [decimal](28, 4) NULL DEFAULT 0,
	[Transito] [decimal](28,4) NULL DEFAULT 0
 CONSTRAINT [pkEXistenciaLOTEBodega] PRIMARY KEY CLUSTERED 
(
	[IDBodega] ASC,
	[IDProducto] ASC,
	[IDLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invExistenciaBodega]  WITH CHECK ADD  CONSTRAINT [FK_invExistenciaBodega_invLote] FOREIGN KEY([IDLote],[IDProducto])
REFERENCES [dbo].[invLote] ([IDLote],[IDProducto])
GO

ALTER TABLE [dbo].[invExistenciaBodega] CHECK CONSTRAINT [FK_invExistenciaBodega_invLote]
GO

ALTER TABLE [dbo].[invExistenciaBodega]  WITH CHECK ADD  CONSTRAINT [fkExistenciaBodega_invBodega] FOREIGN KEY([IDBodega])
REFERENCES [dbo].[invBODEGA] ([IDBodega])
GO

ALTER TABLE [dbo].[invExistenciaBodega] CHECK CONSTRAINT [fkExistenciaBodega_invBodega]
GO


CREATE TABLE [dbo].[globalTipoTran](
	[IDTipoTran] [int] NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Transaccion] [nvarchar](3) NOT NULL,
	[Naturaleza] [nvarchar](1) NULL,
	[Factor] [smallint] NULL,
	[Orden] [smallint] NULL,
	[SystemReadOnly] [bit] NULL DEFAULT 1,
	[EsTraslado] [bit] NULL DEFAULT 0,
	[EsFisico] [bit] NULL DEFAULT 0,
	[EsConsumo] [bit] NULL DEFAULT 0,
	[EsCompra] [bit] NULL DEFAULT 0,
	[EsVenta] [bit] NULL DEFAULT 0,
	[EsAjuste] [bit] NULL DEFAULT 0,
	[EsCosto] [bit] NULL DEFAULT 0,
	[EsRequisable] [bit] NULL DEFAULT 0,
	[DobleMovimiento] [bit] NULL DEFAULT 0,
 CONSTRAINT [pkinvTipoTran] PRIMARY KEY CLUSTERED 
(
	[IDTipoTran] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[globalTipoTran]  WITH CHECK ADD  CONSTRAINT [chkfACTOR] CHECK  (([Factor]=(-1) OR [Factor]=(1)))
GO

ALTER TABLE [dbo].[globalTipoTran] CHECK CONSTRAINT [chkfACTOR]
GO

ALTER TABLE [dbo].[globalTipoTran]  WITH CHECK ADD  CONSTRAINT [chkNaturaleza] CHECK  (([NATURALEZA]='S' OR [NATURALEZA]='E'))
GO

ALTER TABLE [dbo].[globalTipoTran] CHECK CONSTRAINT [chkNaturaleza]
GO

ALTER TABLE [dbo].[globalTipoTran]  WITH CHECK ADD  CONSTRAINT [chkREQUISABLE] CHECK  (([EsRequisable]=(1) AND [NATURALEZA]='S' OR [EsRequisable]=(1) AND [EsTraslado]=(1) OR ([EsRequisable]=(0) AND [NATURALEZA]='E' OR [NATURALEZA]='S')))
GO

ALTER TABLE [dbo].[globalTipoTran] CHECK CONSTRAINT [chkREQUISABLE]
GO

ALTER TABLE [dbo].[globalTipoTran]  WITH CHECK ADD  CONSTRAINT [chkTRASLADO] CHECK  (([EsTraslado]=(1) AND [DobleMovimiento]=(1) OR [EsTraslado]=(0) AND [DobleMovimiento]=(0)))
GO

ALTER TABLE [dbo].[globalTipoTran] CHECK CONSTRAINT [chkTRASLADO]
GO

ALTER TABLE [dbo].[globalTipoTran]  WITH CHECK ADD  CONSTRAINT [chkValorUnico] CHECK  (((((((CONVERT([int],[EsTraslado],0)+CONVERT([int],[EsFisico],0))+CONVERT([int],[EsConsumo],0))+CONVERT([int],[EsCompra],0))+CONVERT([int],[EsVenta],0))+CONVERT([int],[EsAjuste],0))=(1)))
GO

ALTER TABLE [dbo].[globalTipoTran] CHECK CONSTRAINT [chkValorUnico]

GO

CREATE TABLE [dbo].[globalConsecutivos](
	[IDConsecutivo] [int] NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Prefijo] NVARCHAR(50) NOT NULL,
	[Consecutivo] INT NOT NULL DEFAULT 0,
	[ConsecAutomatico] [bit] NULL DEFAULT 1,
	[Documento] [nvarchar](20) NOT NULL,
	[Activo] [bit] NULL,
	CONSTRAINT [pkinvConsecutivo] PRIMARY KEY CLUSTERED(
		[IDConsecutivo] ASC 
	 )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
	CONSTRAINT [uk_PreFijo] UNIQUE NONCLUSTERED 
(
	[Prefijo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 
) ON [PRIMARY]



GO
 

CREATE TABLE [dbo].[invPaquete](
	[IDPaquete] [int] NOT NULL,
	[PAQUETE] [nvarchar](20) NULL,
	[Descr] [nvarchar](250) NULL,
	[IDConsecutivo] [int] NULL,
	[IDTipoTran] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PKINVPAQUETE] PRIMARY KEY CLUSTERED 
(
	[IDPaquete] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_paquete] UNIQUE NONCLUSTERED 
(
	[PAQUETE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invPaquete]  WITH CHECK ADD  CONSTRAINT [FK_invPaquete_globalConsecutivos] FOREIGN KEY([IDConsecutivo])
REFERENCES [dbo].[globalConsecutivos] ([IDConsecutivo])
GO

ALTER TABLE [dbo].[invPaquete] CHECK CONSTRAINT [FK_invPaquete_globalConsecutivos]
GO


ALTER TABLE [dbo].[invPaquete]  WITH CHECK ADD  CONSTRAINT [FK_invPaquete_globalTipoTran] FOREIGN KEY([IDTipoTran])
REFERENCES [dbo].[globalTipoTran] ([IDTipoTran])
GO

ALTER TABLE [dbo].[invPaquete] CHECK CONSTRAINT [FK_invPaquete_globalTipoTran]
GO


CREATE TABLE [dbo].[invEstadosTraslados](
	[IDEstado] int NOT NULL,
	[Descr] [nvarchar](50) NOT NULL,
	[Orden] INT DEFAULT 0,
	[Activo] BIT DEFAULT 1,
	CONSTRAINT [PKDetalleTrasladoEstados] PRIMARY KEY CLUSTERED 
	(	
	IDEstado ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
) ON [PRIMARY]

GO


CREATE  TABLE [dbo].[invTraslados](
	[IDTraslado] [bigint] NOT NULL,
	[IDEstado] INT NOT NULL,
	[FechaRemision] [datetime] NULL,
	[FechaEntrada] [datetime] NULL,
	[NumEntrada] [nvarchar](50) NULL,
	[NumSalida] [nvarchar](50) NULL,
	[DocumentoAjuste] [nvarchar](50) NULL,
	[Aplicado] [bit] NULL,
	CONSTRAINT [PKINVTRASLADOS] PRIMARY KEY CLUSTERED 
	(	
	[IDTraslado] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invTraslados] ADD  DEFAULT ((0)) FOR [Aplicado]
GO

ALTER TABLE [dbo].[invTraslados]  WITH CHECK ADD  CONSTRAINT [FK_invTraslado_invEstadoTraslado] FOREIGN KEY([IDEstado])
REFERENCES [dbo].[invEstadosTraslados] ([IDEstado])
GO

ALTER TABLE [dbo].[invTraslados] CHECK CONSTRAINT [FK_invTraslado_invEstadoTraslado]
GO


CREATE  TABLE [dbo].[invDetalleTraslados](
	[IDTraslado] [bigInt] NOT NULL,
	[IDBodegaOrigen] [int] NOT NULL,
	[IDBodegaDestino] [int] NOT NULL,
	[IDProducto] [Bigint] NOT NULL,
	[IDLote] [int] NOT NULL DEFAULT 0,
	[Cantidad] [decimal](28, 8) NULL DEFAULT 0,
	[CantidadRecibida] [decimal](28, 8) NULL DEFAULT 0,
	[CantidadAjuste] [decimal](28, 8) NULL DEFAULT 0,
	[Observacion] [nvarchar](250) NULL,
	[RecibidoParcial] [bit] NULL DEFAULT 0,
	CONSTRAINT [PKINVTRASLADOSDetalle] PRIMARY KEY CLUSTERED 
	(	
	[IDTraslado] ASC,
	[IDBodegaOrigen] ASC,
	[IDBodegaDestino] ASC,
	[IDProducto] ASC,
	[IDLote] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
) ON [PRIMARY]


GO

ALTER TABLE [dbo].[invDetalleTraslados]  WITH CHECK ADD  CONSTRAINT [fkinvDetalleTraslados_invBodegaOrigen] FOREIGN KEY([IDBodegaOrigen])
REFERENCES [dbo].[invBodega] ([IDBodega])
GO

ALTER TABLE [dbo].[invDetalleTraslados] CHECK CONSTRAINT [fkinvDetalleTraslados_invBodegaOrigen]
GO


ALTER TABLE [dbo].[invDetalleTraslados]  WITH CHECK ADD  CONSTRAINT [fkinvDetalleTraslados_invBodegaDestino] FOREIGN KEY([IDBodegaDestino])
REFERENCES [dbo].[invBodega] ([IDBodega])
GO

ALTER TABLE [dbo].[invDetalleTraslados] CHECK CONSTRAINT [fkinvDetalleTraslados_invBodegaDestino]
GO


ALTER TABLE [dbo].[invDetalleTraslados]  WITH CHECK ADD  CONSTRAINT [fkinvDetalleTraslados_invLote] FOREIGN KEY([IDLote],[IDProducto])
REFERENCES [dbo].[invLote] ([IDLote],[IDProducto])
GO

ALTER TABLE [dbo].[invDetalleTraslados] CHECK CONSTRAINT [fkinvDetalleTraslados_invLote]



GO


CREATE TABLE [dbo].[invDetalleTrasladosEstados](
	[IDTraslado] [bigInt] NOT NULL,
	[IDEstado] int NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Fecha] [datetime]  NULL,
	CONSTRAINT [PKDetalleTrasladoEstadosH] PRIMARY KEY CLUSTERED 
	(	
	[IDTraslado] ASC,
	[IDEstado] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
) ON [PRIMARY]

GO



ALTER TABLE [dbo].[invDetalleTrasladosEstados]  WITH CHECK ADD  CONSTRAINT [FK_invDetalleEstadoTraslado_invEstadoTraslado] FOREIGN KEY([IDEstado])
REFERENCES [dbo].[invEstadosTraslados] ([IDEstado])
GO

ALTER TABLE [dbo].[invDetalleTrasladosEstados] CHECK CONSTRAINT [FK_invDetalleEstadoTraslado_invEstadoTraslado]
GO


ALTER TABLE [dbo].[invDetalleTrasladosEstados]  WITH CHECK ADD  CONSTRAINT [FK_invDetalleEstadoTraslado_invTraslado] FOREIGN KEY([IDTraslado])
REFERENCES [dbo].[invTraslados] ([IDTraslado])

GO

ALTER TABLE [dbo].[invDetalleTrasladosEstados] CHECK CONSTRAINT [FK_invDetalleEstadoTraslado_invTraslado]
GO


CREATE TABLE [dbo].[invTransaccion](
	[IDTransaccion] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuloOrigen] NVARCHAR(4) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Referencia] [nvarchar](250) NULL,
	[Documento] [nvarchar](250) NULL,
	[Aplicado] [bit] NULL DEFAULT 0,
	[UniqueValue] [uniqueidentifier] NULL,
	[EsTraslado] [bit] NULL DEFAULT 0,
	[IDTraslado] [bigint] NULL,
	[IDRequisa] [bigint] NULL,
	[CreateDate] [datetime] NULL DEFAULT (GETDATE()),
 CONSTRAINT [pkinvTransaccion] PRIMARY KEY CLUSTERED 
(
	[IDTransaccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [ukinvTransaccionUniqueValue] UNIQUE NONCLUSTERED 
(
	[UniqueValue] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invTransaccion]  WITH CHECK ADD  CONSTRAINT [fkinvTransaccion] FOREIGN KEY([IDTraslado])
REFERENCES [dbo].[invTraslados] ([IDTraslado])
GO

ALTER TABLE [dbo].[invTransaccion] CHECK CONSTRAINT [fkinvTransaccion]

GO

CREATE TABLE [dbo].[invTransaccionLinea](
	[IDTransaccion] [bigint] NOT NULL,
	[IDProducto] [bigint] NOT NULL,
	[IDLote] [int] NOT NULL,
	[IDTipoTran] [int] NOT NULL,
	[IDBodega] [int] NOT NULL,
	[IDTraslado] [bigint] NULL,
	[IDRequisa] [bigint] NULL ,
	[Naturaleza] [nvarchar](1) NOT NULL,
	[Factor] [smallint] NOT NULL DEFAULT 0,
	[Cantidad] [decimal](28, 4) NULL DEFAULT 0,
	[CostoUntLocal] [decimal](28, 4) NULL DEFAULT 0,
	[CostoUntDolar] [decimal](28, 4) NULL DEFAULT 0,
	[PrecioUntLocal] [decimal](28, 4) NULL DEFAULT 0,
	[PrecioUntDolar] [decimal](28, 4) NULL DEFAULT 0,
	[Transaccion] [nvarchar](3) NOT NULL,
	[TipoCambio] [decimal](28, 4) NULL DEFAULT 0,
	[Aplicado] [bit] NULL DEFAULT 0,
 CONSTRAINT [pkTransaccionLinea] PRIMARY KEY CLUSTERED 
(
	[IDTransaccion] ASC,
	[IDProducto] ASC,
	[IDLote] ASC,
	[IDTipoTran] ASC,
	[IDBodega] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH CHECK ADD  CONSTRAINT [fkTransaccionLinea_invLote] FOREIGN KEY([IDLote],[IDProducto])
REFERENCES [dbo].[invLote] ([IDLote],[IDProducto])
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [fkTransaccionLinea_invLote]
GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH CHECK ADD  CONSTRAINT [fkTransaccionLineaBod] FOREIGN KEY([IDBodega])
REFERENCES [dbo].[invBodega] ([IDBodega])
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [fkTransaccionLineaBod]
GO


ALTER TABLE [dbo].[invTransaccionLinea]  WITH CHECK ADD  CONSTRAINT [fkTransaccionLinea_globalTipoTran] FOREIGN KEY([IDTipoTran])
REFERENCES [dbo].[globalTipoTran] ([IDTipoTran])
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [fkTransaccionLinea_globalTipoTran]
GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH CHECK ADD  CONSTRAINT [fkTransaccionLineaTrans] FOREIGN KEY([IDTransaccion])
REFERENCES [dbo].[invTransaccion] ([IDTransaccion])
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [fkTransaccionLineaTrans]
GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH NOCHECK ADD  CONSTRAINT [chktranlineaFactor] CHECK  (([FACTOR]=(1) OR [FACTOR]=(-1)))
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [chktranlineaFactor]
GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH NOCHECK ADD  CONSTRAINT [chktranlineaNaturaleza] CHECK  (([Naturaleza]='E' OR [Naturaleza]='S'))
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [chktranlineaNaturaleza]
GO

ALTER TABLE [dbo].[invTransaccionLinea]  WITH NOCHECK ADD  CONSTRAINT [chktranlineaTransaccion] CHECK  (([Transaccion]='TR' OR ([Transaccion]='FI' OR ([Transaccion]='CS' OR ([Transaccion]='CO' OR [Transaccion]='AJ')))))
GO

ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [chktranlineaTransaccion]
GO


CREATE TABLE [dbo].[invProveedor](
	[IDProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[IDRuc] int NULL DEFAULT 0,
	[Activo] [bit] NULL DEFAULT 0,
 CONSTRAINT [pkinvProveedor] PRIMARY KEY CLUSTERED 
(
	[IDProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[invProveedor]  WITH CHECK ADD  CONSTRAINT [fk_invProveedor_cbRUC] FOREIGN KEY([IDRuc])
REFERENCES [dbo].[cbRUC] ([IDRuc])
GO

ALTER TABLE [dbo].[invProveedor] CHECK CONSTRAINT [fk_invProveedor_cbRUC]
GO

CREATE  TABLE [dbo].[invProveedorProducto](
	[IDProveedor] [int] NOT NULL,
	[IDProducto] [bigint] NOT NULL,
	[PrecioUltDolar] DECIMAL(28,4) DEFAULT 0,
	[PrecioDolar] DECIMAL(28,4)  DEFAULT 0,
 CONSTRAINT [pkinvProveedorProducto] PRIMARY KEY CLUSTERED 
(
	[IDProveedor] ASC,
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invProveedorProducto]  WITH CHECK ADD  CONSTRAINT [fkdboinvProveedorProductoProd] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[invProducto] ([IDProducto])
GO

ALTER TABLE [dbo].[invProveedorProducto] CHECK CONSTRAINT [fkdboinvProveedorProductoProd]
GO

ALTER TABLE [dbo].[invProveedorProducto]  WITH CHECK ADD  CONSTRAINT [fkdboinvProveedorProductoProv] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[invProveedor] ([IDProveedor])
GO

ALTER TABLE [dbo].[invProveedorProducto] CHECK CONSTRAINT [fkdboinvProveedorProductoProv]
GO


CREATE TABLE [dbo].[invHistCostoPromedio](
	[IDCostoProm] [bigint] IDENTITY(1,1) NOT NULL,
	[IDProducto] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[CostoPromLocal] [decimal](28, 4) NULL,
	[CostoPromDolar] [decimal](28, 4) NULL,
 CONSTRAINT [pkinvHistCostoPromedio] PRIMARY KEY CLUSTERED 
(
	[IDCostoProm] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [ukinvHistCostoPromedio] UNIQUE NONCLUSTERED 
(
	[IDProducto] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invHistCostoPromedio]  WITH CHECK ADD  CONSTRAINT [fkinvHistCostoPromProd] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[invProducto] ([IDProducto])
GO

ALTER TABLE [dbo].[invHistCostoPromedio] CHECK CONSTRAINT [fkinvHistCostoPromProd]
GO

ALTER TABLE [dbo].[invHistCostoPromedio] ADD  DEFAULT ((0)) FOR [CostoPromLocal]
GO

ALTER TABLE [dbo].[invHistCostoPromedio] ADD  DEFAULT ((0)) FOR [CostoPromDolar]
GO

--Ageregar los datos de las tablas que son de sistemas
/*	INSERT DE GRUPO CLASIFICACIONES */
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 0,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 1,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 2,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 3,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 4,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 5,  N'ND',  1, N'ND' )
GO
INSERT INTO dbo.invGrupoClasif  ( IDGrupo, Descr, Activo, Etiqueta )
VALUES  ( 6,  N'ND',  1, N'ND' )

GO
/* INSERT DE CLASIFICACIONES */

INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 1 , N'ND' , 1 , 1 )
GO
INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 2 , N'ND' , 2 , 1 )

GO
INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 3 , N'ND' , 3 , 1 )
GO
INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 4 , N'ND' , 4 , 1 )
GO
INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 5 , N'ND' , 5 , 1 )
GO
INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
VALUES  ( 6 , N'ND' , 6 , 1 )

/* INSERT DE TIPO TRANSACIONES */
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 1 ,N'SALIDA POR INVENTARIO FISICO (-)' , N'FI' , N'S' , -1 , 1 , 1 , 0 , 1 ,0 , 0 ,0 , 0 ,0 , 0 , 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 2 ,N'INGRESO POR INVENTARIO FISICO (+)' , N'FI' , N'E' , 1 , 1 , 1 , 0 , 1 ,0 , 0 ,0 , 0 ,0 , 0 , 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 3 ,N'INGRESO POR TRASLADO (+)' , N'TR' , N'E' , 1 , 2 , 1 , 1 , 0 ,0 , 0 ,0 , 0 ,0 , 0 , 1 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 4 ,N'SALIDA POR TRASLADO (-)' , N'TR' , N'S' , -1 , 2 , 1 , 1 , 0 ,0 , 0 ,0 , 0 ,0 , 0 , 1 )

GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 5 ,N'CONSUMO (-)' , N'CS' , N'S' , -1 , 3 , 1 , 0 , 0 ,1 , 0 ,0 , 0 ,0 , 1 , 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 6 ,N'COMPRA (+)' , N'CO' , N'E' , 1 , 4 , 1 , 0 , 0 ,0 , 1 ,0 , 0 ,0 , 0, 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 7 ,N'INGRESO POR AJUSTE (+)' , N'AJ' , N'E' , 1 , 5 , 1 , 0 , 0 ,0 , 0 ,0 , 1 ,0 , 0, 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 8 ,N'SALIDA POR AJUSTE (-)' , N'AJ' , N'S' , -1 , 6 , 1 , 0 , 0 ,0 , 0 ,0 , 1 ,0 , 0, 0 )
GO
INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 9 ,N'VENTA (-)' , N'VT' , N'S' , -1 , 7 , 1 , 0 , 0 ,0 , 0 ,1 , 0 ,0 , 0, 0 )

--PENDIENTE AJUSTE AL COSTO
GO

CREATE Procedure  [dbo].[cntUpdateProducto] @Operacion nvarchar(1), @IDProducto bigint, @Descr nvarchar(250), @Alias nvarchar(20),
@Clasif1 int, @Clasif2 INT, @Clasif3 INT ,@Clasif4 INT , @Clasif5 INT, @Clasif6 INT, @CodigoBarra NVARCHAR(50),@IDUnidad INT,
@FactorEmpaque DECIMAL(28,4), @TipoImpuesto INT, @EsMuestra BIT, @EsControlado BIT, @EsEtico BIT, @BajaPrecioDistribuidor BIT,
@BajaPrecioProveedor BIT, @PorcDescuentoAlzaProveedor DECIMAL(28,4), @BonificaFA BIT, @BonificaCOPorCada DECIMAL(28,4),
@BonificaCOCantidad DECIMAL(28,4), @Activo BIT,@UserInsert NVARCHAR(50),@UserUpdate NVARCHAR(50),@UpdateDate DATETIME
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.invProducto( Descr ,Alias ,Clasif1 ,Clasif2 ,Clasif3 ,Clasif4 ,Clasif5 ,Clasif6 ,CodigoBarra ,IDUnidad ,FactorEmpaque ,TipoImpuesto ,
	          EsMuestra ,EsControlado ,EsEtico ,BajaPrecioDistribuidor ,BajaPrecioProveedor ,PorcDescuentoAlzaProveedor ,BonificaFA ,BonificaCOPorCada ,BonificaCOCantidad ,
	          Activo ,UserInsert ,UserUpdate  ,UpdateDate)
	VALUES (@Descr,@Alias,@Clasif1,@Clasif2,@Clasif3,@Clasif4,@Clasif5,@Clasif6,@CodigoBarra,@IDUnidad,@FactorEmpaque,@TipoImpuesto,
		@EsMuestra,@EsControlado,@EsEtico,@BajaPrecioDistribuidor,@BajaPrecioProveedor,@PorcDescuentoAlzaProveedor,@BonificaFA,@BonificaCOPorCada,@BonificaCOCantidad,
		@Activo,@UserInsert,@UserUpdate,@UpdateDate)
		
	SET @IDProducto = @@IDENTITY
		
		INSERT INTO dbo.invLote( IDLote ,IDProducto ,LoteInterno ,LoteProveedor ,FechaVencimiento ,FechaFabricacion )
		VALUES  ( 0 , 
		          @IDProducto , -- IDProducto - bigint
		          N'ND' , -- LoteInterno - nvarchar(50)
		          N'ND' , -- LoteProveedor - nvarchar(50)
		          '19810101' , -- FechaVencimiento - smalldatetime
		          '19810101'-- FechaFabricacion - smalldatetime
		        )
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDLote  from  dbo.invLote    Where IDProducto  = @IDProducto AND IDLote<>0)	
	begin 
		RAISERROR ( 'El artículo tiene asociado lotes, por favor elimine los lotes antes de eliminar el producto', 16, 1) ;
		return				
	end
	if Exists ( Select IDProducto  from  dbo.invTransaccionLinea   Where IDProducto  = @IDProducto)	
	begin 
		RAISERROR ( 'El producto no puede ser eliminado, tiene movimientos en el inventario, unicamente lo puede desactivar', 16, 1) ;
		return				
	end
	DELETE  FROM dbo.invProducto WHERE IDProducto = @IDProducto
	DELETE FROM dbo.invLote WHERE IDLote=0 AND IDProducto=@IDProducto
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invProducto SET Descr=@Descr, Alias = @Alias,Clasif1=@Clasif1,Clasif2=@Clasif2,Clasif3=@Clasif3,Clasif4=@Clasif4,Clasif5=@Clasif5,Clasif6=@Clasif6,
	CodigoBarra =@CodigoBarra,IDUnidad=@IDUnidad,FactorEmpaque=@FactorEmpaque,TipoImpuesto=@TipoImpuesto,EsMuestra=@EsMuestra,EsControlado=@EsControlado,
	EsEtico=@EsEtico,BajaPrecioDistribuidor=@BajaPrecioDistribuidor,BajaPrecioProveedor=@BajaPrecioProveedor,PorcDescuentoAlzaProveedor=@PorcDescuentoAlzaProveedor,
	BonificaFA=@BonificaFA,BonificaCOPorCada=@BonificaCOPorCada,BonificaCOCantidad=@BonificaCOCantidad,Activo=@Activo,UserUpdate=@UserUpdate,UpdateDate=@UpdateDate
	WHERE IDProducto=@IDProducto
	
end





