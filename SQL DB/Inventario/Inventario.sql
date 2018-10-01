
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

CREATE  TABLE [dbo].[globalImpuesto](
	[IDImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[Descr] [nvarchar](250) NOT NULL,
	[Porc] [decimal](28, 4) NULL,
	[Activo] [bit] DEFAULT 1,
 CONSTRAINT [pkglobalTipoImpuesto] PRIMARY KEY CLUSTERED 
(
	[IDImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
) ON [PRIMARY]

GO

CREATE     TABLE  [dbo].[invProducto](
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
	[IDCuentaContable] [BigInt] NOT NULL ,
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

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoCuentaContable] FOREIGN KEY([IDCuentaContable])
REFERENCES [dbo].[invCuentaContable] ([IDCuenta])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoCuenta]
GO


ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoUnd] FOREIGN KEY([IDUnidad])
REFERENCES [dbo].[invUnidadMedida] ([IDUnidad])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoUnd]
GO

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProducto_TipoImpuesto] FOREIGN KEY([TipoImpuesto])
REFERENCES [dbo].[globalImpuesto] ([IDImpuesto])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProducto_TipoImpuesto]
GO


CREATE  TABLE [dbo].[invCuentaContable](
	[IDCuenta] [bigint] NOT NULL,
	[Descr][nvarchar](250)  NOT NULL,
	[CtrInventario][int],
	[CtaInventario][int],
	[CtrVenta] [int], 
	[CtaVenta] [int], 
	[CtrCompra] [int], 
	[CtaCompra][int],
	[CtrDescVenta] [int],    
	[CtaDescVenta] [int], 
    [CtrCostoVenta] [int],     
    [CtaCostoVenta] [int], 
    [CtrComisionVenta] [int], 
    [CtaComisionVenta] [int], 
    [CtrComisionCobro] [int], 
    [CtaComisionCobro] [int], 
    [CtrDescLinea] [int],
    [CtaDescLinea] [int],  
    [CtrCostoDesc] [int], 
    [CtaCostoDesc] [int], 
    [CtrSobranteInvFisico] [int], 
    [CtaSobranteInvFisico] [int], 
    [CtrFaltanteInvFisico] [int], 
    [CtaFaltanteInvFisico] [int], 
    [CtrVariacionCosto] [int],   
    [CtaVariacionCosto] [int],  
    [CtrVencimiento] [int], 
    [CtaVencimiento] [int], 
    [CtrDescBonificacion] [int], 
    [CtaDescBonificacion] [int], 
    [CtrDevVentas] [int], 
    [CtaDevVentas] [int]
 CONSTRAINT [pkinvCuentaContable] PRIMARY KEY CLUSTERED 
(
	[IDCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[invBodega](
	[IDBodega] [int] IDENTITY(1,1) NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Activo] [bit] NOT NULL DEFAULT 1,
	[PuedeFacturar] BIT DEFAULT 0,
	[PuedePreFacturar] BIT DEFAULT 0,
	[IDPaqueteFactura]  INT  NULL,
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


CREATE TABLE  dbo.globalClaseTipoTran( 
[Transaccion] [nvarchar](3) NOT NULL, 
Descr NVARCHAR(255)  NOT NULL,
 CONSTRAINT [pkinvClaseTipoTran] PRIMARY KEY CLUSTERED 
(
	[Transaccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

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
ALTER TABLE [dbo].[globalTipoTran]  ADD  CONSTRAINT [fkglobalTipoTranClase] FOREIGN KEY  (Transaccion )  REFERENCES dbo.globalClaseTipoTran (Transaccion)
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
	[IDConsecutivo] [int] IDENTITY (1,1) NOT NULL,
	[Descr] [nvarchar](250) NULL,
	[Prefijo] NVARCHAR(50) NOT NULL,
	[Consecutivo] INT NOT NULL DEFAULT 0,
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
 

CREATE  TABLE [dbo].[invPaquete](
	[IDPaquete] [int] IDENTITY(1,1) NOT NULL,
	[PAQUETE] [nvarchar](20) NULL,
	[Descr] [nvarchar](250) NULL,
	[IDConsecutivo] [int] NOT  NULL,
	[Transaccion] [nvarchar](3) not NULL,
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


ALTER TABLE [dbo].[invPaquete]  WITH CHECK ADD  CONSTRAINT [FK_invPaquete_globalClaseTipoTran] FOREIGN KEY([Transaccion])
REFERENCES [dbo].[globalClaseTipoTran] ([Transaccion])
GO

ALTER TABLE [dbo].[invPaquete] CHECK CONSTRAINT [FK_invPaquete_globalClaseTipoTran]
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


ALTER TABLE [dbo].[invDetalleTraslados]  WITH CHECK ADD  CONSTRAINT [fkinvDetalleTraslados_invTraslado] FOREIGN KEY([IDTraslado])
REFERENCES [dbo].[invTraslados] ([IDTraslado])
GO

ALTER TABLE [dbo].[invDetalleTraslados] CHECK CONSTRAINT [fkinvDetalleTraslados_invTraslado]


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


CREATE  TABLE [dbo].[invTransaccion](
	[IDTransaccion] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuloOrigen] NVARCHAR(4) NOT NULL,
	[IDPaquete] INT  NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Referencia] [nvarchar](250) NULL,
	[Documento] [nvarchar](250) NULL,
	[Asiento][nvarchar](20) NULL,
	[Aplicado] [bit] NULL DEFAULT 0,
	[UniqueValue] [uniqueidentifier] NULL,
	[EsTraslado] [bit] NULL DEFAULT 0,
	[IDTraslado] [bigint] NULL,
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

ALTER TABLE [dbo].[invTransaccion]
ADD CONSTRAINT UC_invTransaccionUnique UNIQUE (Documento,IDPaquete,Fecha);

GO

--ALTER TABLE [dbo].[invTransaccion]  WITH CHECK ADD  CONSTRAINT [fkinvTransaccion] FOREIGN KEY([IDTraslado])
--REFERENCES [dbo].[invTraslados] ([IDTraslado])
--GO

--ALTER TABLE [dbo].[invTransaccion] CHECK CONSTRAINT [fkinvTransaccion]

GO

CREATE TABLE [dbo].[invTransaccionLinea](
	[IDTransaccion] [bigint] NOT NULL,
	[IDProducto] [bigint] NOT NULL,
	[IDLote] [int] NOT NULL,
	[IDTipoTran] [int] NOT NULL,
	[IDBodega] [int] NOT NULL,
	[IDTraslado] [bigint] NULL,
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

--ALTER TABLE [dbo].[invTransaccionLinea]  WITH NOCHECK ADD  CONSTRAINT [chktranlineaTransaccion] CHECK  (([Transaccion]='TR' OR ([Transaccion]='FI' OR ([Transaccion]='CS' OR ([Transaccion]='CO' OR [Transaccion]='AJ' )))))
--GO

--ALTER TABLE [dbo].[invTransaccionLinea] CHECK CONSTRAINT [chktranlineaTransaccion]
--GO


CREATE TABLE [dbo].[cppProveedor](
	[IDProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[IDRuc] int NULL DEFAULT 0,
	[Activo] [bit] NULL DEFAULT 0,
 CONSTRAINT [pkcppProveedor] PRIMARY KEY CLUSTERED 
(
	[IDProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cppProveedor]  WITH CHECK ADD  CONSTRAINT [fk_cppProveedor_cbRUC] FOREIGN KEY([IDRuc])
REFERENCES [dbo].[cbRUC] ([IDRuc])
GO

ALTER TABLE [dbo].[cppProveedor] CHECK CONSTRAINT [fk_cppProveedor_cbRUC]
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
REFERENCES [dbo].[cppProveedor] ([IDProveedor])
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

--Tipo Impuesto
INSERT INTO dbo.globalImpuesto(Descr,Activo)
VALUES ('Exento',1)

--Unidad de Medida
INSERT INTO dbo.invUnidadMedida
        ( Descr, Activo )
VALUES  ( N'UND', -- Descr - nvarchar(250)
          1  -- Activo - bit
          )

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

GO

/* INSERT DE TIPO TRANSACIONES */
INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('FI','Inventario Físico')

go

INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('TR','Traslados')

go 

INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('CS','Consumos')

go

INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('CO','Compras')

go 


INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('AJ','Ajustes')

GO

INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('VT','Ventas')

GO

INSERT INTO dbo.globalClaseTipoTran(Transaccion,Descr)
VALUES ('DV','Devolución sobre Ventas')

GO

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

GO

INSERT INTO dbo.globalTipoTran( IDTipoTran ,Descr ,Transaccion ,Naturaleza ,Factor ,Orden ,SystemReadOnly ,EsTraslado ,
          EsFisico ,EsConsumo ,EsCompra ,EsVenta ,EsAjuste ,EsCosto ,EsRequisable ,DobleMovimiento)
VALUES  ( 10 ,N'DEVOLUCIONES SOBRE VENTA (+)' , N'DV' , N'E' , 1 , 8, 1 , 0 , 0 ,0 , 0 ,1 , 0 ,0 , 0, 0 )

--PENDIENTE AJUSTE AL COSTO
GO

CREATE  Procedure  [dbo].[invUpdateProducto] @Operacion nvarchar(1), @IDProducto BIGINT OUTPUT, @Descr nvarchar(250), @Alias nvarchar(20),
@Clasif1 int, @Clasif2 INT, @Clasif3 INT ,@Clasif4 INT , @Clasif5 INT, @Clasif6 INT,@IDCuentaContable AS INT, @CodigoBarra NVARCHAR(50),@IDUnidad INT,
@FactorEmpaque DECIMAL(28,4), @TipoImpuesto INT, @EsMuestra BIT, @EsControlado BIT, @EsEtico BIT, @BajaPrecioDistribuidor BIT,
@BajaPrecioProveedor BIT, @PorcDescuentoAlzaProveedor DECIMAL(28,4), @BonificaFA BIT, @BonificaCOPorCada DECIMAL(28,4),
@BonificaCOCantidad DECIMAL(28,4), @Activo BIT,@UserInsert NVARCHAR(50),@UserUpdate NVARCHAR(50),@UpdateDate DATETIME
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	INSERT INTO dbo.invProducto( Descr ,Alias ,Clasif1 ,Clasif2 ,Clasif3 ,Clasif4 ,Clasif5 ,Clasif6 ,IDCuentaContable,CodigoBarra ,IDUnidad ,FactorEmpaque ,TipoImpuesto ,
	          EsMuestra ,EsControlado ,EsEtico ,BajaPrecioDistribuidor ,BajaPrecioProveedor ,PorcDescuentoAlzaProveedor ,BonificaFA ,BonificaCOPorCada ,BonificaCOCantidad ,
	          Activo ,UserInsert ,UserUpdate  ,UpdateDate)
	VALUES (@Descr,@Alias,@Clasif1,@Clasif2,@Clasif3,@Clasif4,@Clasif5,@Clasif6,@IDCuentaContable,@CodigoBarra,@IDUnidad,@FactorEmpaque,@TipoImpuesto,
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
	DELETE FROM dbo.invLote WHERE IDLote=0 AND IDProducto=@IDProducto
	DELETE  FROM dbo.invProducto WHERE IDProducto = @IDProducto
	
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invProducto SET Descr=@Descr, Alias = @Alias,Clasif1=@Clasif1,Clasif2=@Clasif2,Clasif3=@Clasif3,Clasif4=@Clasif4,Clasif5=@Clasif5,Clasif6=@Clasif6,
	IDCuentaContable = @IDCuentaContable,CodigoBarra =@CodigoBarra,IDUnidad=@IDUnidad,FactorEmpaque=@FactorEmpaque,TipoImpuesto=@TipoImpuesto,EsMuestra=@EsMuestra,EsControlado=@EsControlado,
	EsEtico=@EsEtico,BajaPrecioDistribuidor=@BajaPrecioDistribuidor,BajaPrecioProveedor=@BajaPrecioProveedor,PorcDescuentoAlzaProveedor=@PorcDescuentoAlzaProveedor,
	BonificaFA=@BonificaFA,BonificaCOPorCada=@BonificaCOPorCada,BonificaCOCantidad=@BonificaCOCantidad,Activo=@Activo,UserUpdate=@UserUpdate,UpdateDate=@UpdateDate
	WHERE IDProducto=@IDProducto
	
end

GO

CREATE  PROCEDURE [dbo].[invGetProducto] @IDProducto BIgint	,@Descr AS NVARCHAR(250),@Alias NVARCHAR(20),@Clasif1 int, @Clasif2 INT, @Clasif3 INT ,@Clasif4 INT , @Clasif5 INT, @Clasif6 INT, @CodigoBarra NVARCHAR(50),
															@EsMuestra INT,@EsControlado INT,@EsEtico INT
AS 
	SELECT IDProducto,Descr ,Alias ,Clasif1 ,Clasif2 ,Clasif3 ,Clasif4 ,Clasif5 ,Clasif6 ,CodigoBarra,IDCuentaContable ,IDUnidad ,FactorEmpaque ,TipoImpuesto ,
	          EsMuestra ,EsControlado ,EsEtico ,BajaPrecioDistribuidor ,BajaPrecioProveedor ,PorcDescuentoAlzaProveedor ,BonificaFA ,BonificaCOPorCada ,BonificaCOCantidad ,
	          Activo ,UserInsert ,UserUpdate  ,UpdateDate,CreateDate FROM dbo.invProducto 
	          WHERE (IDProducto=@IDProducto OR  @IDProducto=-1)
	          AND (Clasif1 =@Clasif1 OR @Clasif1=-1) AND (Clasif2 =@Clasif2 OR @Clasif2=-1) AND (Clasif3 =@Clasif3 OR @Clasif3=-1)
	          AND (Clasif4 =@Clasif4 OR @Clasif4=-1) AND (Clasif5 =@Clasif5 OR @Clasif5=-1) AND (Clasif6 =@Clasif6 OR @Clasif6=-1)
	          AND (CodigoBarra=@CodigoBarra OR @CodigoBarra='*') AND ( EsMuestra =@EsMuestra OR @EsMuestra=-1)  AND
	          (EsControlado =  @EsControlado OR @EsControlado =-1) AND (EsEtico= @EsEtico OR @EsEtico=-1) AND 
	          (Descr =@Descr OR Descr LIKE '%' +@Descr + '%' OR @Descr='*') AND (Alias=@Alias OR Alias LIKE '%'+ @Alias + '%' OR @Alias = '*')  
	          


GO


CREATE Procedure [dbo].[invUpdateUnidadMedida] @Operacion nvarchar(1), @IDUnidad int, @Descr nvarchar(250),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.invUnidadMedida( Descr, Activo )
	VALUES (@Descr,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDUnidad  from  dbo.invProducto    Where IDUnidad  = @IDUnidad)	
	begin 
		RAISERROR ( 'La unidad de medida que desea eliminar, esta asociada a un producto ', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.invUnidadMedida WHERE IDUnidad = @IDUnidad 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invUnidadMedida SET  Descr = @Descr,Activo=@Activo WHERE IDUnidad=@IDUnidad

end

GO


CREATE Procedure [dbo].[invUpdateglobalImpuesto] @Operacion nvarchar(1), @IDImpuesto int, @Descr nvarchar(250),@Porc DECIMAL(28,4),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.globalImpuesto( Descr, Porc, Activo )
	VALUES (@Descr,@Porc,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDProducto  from  dbo.invProducto    Where TipoImpuesto  = @IDImpuesto)	
	begin 
		RAISERROR ( 'El impuesto que desea eliminar, esta asociado a un producto ', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.globalImpuesto WHERE IDImpuesto = @IDImpuesto 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.globalImpuesto SET  Descr = @Descr,Porc = @Porc,Activo=@Activo WHERE IDImpuesto=@IDImpuesto

end

GO

CREATE Procedure [dbo].[invUpdateInvClasificacion] @Operacion nvarchar(1), @IDClasificacion int, @Descr nvarchar(250),@IDGrupo DECIMAL(28,4),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDClasificacion  = (SELECT dbo.[invNextConsecutivoClasificacionInv]())
	
	INSERT INTO dbo.invClasificacion( IDClasificacion ,Descr ,IDGrupo ,Activo)
	VALUES (@IDClasificacion,@Descr,@IDGrupo,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDProducto  from  dbo.invProducto    Where 
		(@IDGrupo=1 AND Clasif1=@IDClasificacion ) OR
		(@IDGrupo=2 AND Clasif2=@IDClasificacion) OR
		(@IDGrupo=3 AND Clasif3=@IDClasificacion) OR
		(@IDGrupo=4 AND Clasif4=@IDClasificacion) OR
		(@IDGrupo=5 AND Clasif5=@IDClasificacion) OR
		(@IDGrupo=6 AND Clasif6=@IDClasificacion) ) 	
	begin 
		RAISERROR ( 'La Clasificacion que desea eliminar, esta asociado a un producto ', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.invClasificacion WHERE IDGrupo = @IDGrupo AND IDClasificacion=@IDClasificacion 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invClasificacion SET  Descr = @Descr,IDGrupo = @IDGrupo,Activo=@Activo WHERE IDClasificacion=@IDClasificacion

end

GO


CREATE   PROCEDURE dbo.invGetClasificacion @IDClasificacion AS INT, @IDGrupo AS int	, @Descr nvarchar(250)
AS 
SELECT B.IDGrupo,B.Descr DescrGrupo, IDClasificacion,A.Descr,A.Activo  FROM dbo.invClasificacion A
INNER JOIN dbo.invGrupoClasif B ON A.IDGrupo = B.IDGrupo
 WHERE  (IDClasificacion = @IDClasificacion OR @IDClasificacion=-1) AND  (A.IDGrupo=@IDGrupo OR @IDGrupo=-1) AND (A.Descr LIKE '%'+@Descr+'%' OR @Descr = '*') AND A.Activo=1


GO


CREATE  Procedure [dbo].[invUpdatePaquete] @Operacion nvarchar(1), @IDPaquete INT OUTPUT, @Paquete NVARCHAR(20), @Descr nvarchar(250),@IDconsecutivo INT ,@Transaccion AS NVARCHAR(3),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.invPaquete(Paquete,Descr,IDConsecutivo,Transaccion,Activo)
	VALUES (@Paquete, @Descr,@IDConsecutivo,@Transaccion,@Activo)
	
	SET @IDPaquete = @@IDENTITY
end

if upper(@Operacion) = 'D'
begin

	--if Exists ( Select IDProducto  from  dbo.    Where TipoImpuesto  = @IDImpuesto)	
	--begin 
	--	RAISERROR ( 'El impuesto que desea eliminar, esta asociado a un producto ', 16, 1) ;
	--	return				
	--end
	
	DELETE  FROM dbo.invPaquete WHERE IdPaquete = @IDPaquete 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invPaquete SET  Descr = @Descr,Paquete = @Paquete ,Activo=@Activo, IDConsecutivo = @IDconsecutivo, Transaccion = @Transaccion WHERE IDPaquete=@IDPaquete

END

GO

CREATE   PROCEDURE dbo.invGetPaquete @IDPaquete int, @Paquete nvarchar(20), @Descr nvarchar(200),@Transaccion nvarchar(3) , @IDConsecutivo int ,@Activo INT
AS 
SELECT  IDPaquete ,
        PAQUETE ,
        Descr ,
        IDConsecutivo ,
        Transaccion ,
        Activo  FROM dbo.invPaquete
WHERE (IDPaquete = @IDPaquete OR @IDPaquete=-1)  AND (PAQUETE LIKE '%' +@Paquete + ' %' OR @Paquete = '*') 
AND (Descr LIKE '%' + @Descr + '%' OR @Descr ='*' ) 
AND (Transaccion = @Transaccion OR @Transaccion ='*')  AND ( IDConsecutivo = @IDConsecutivo OR @IDConsecutivo =-1 )  AND  (Activo = @Activo or @Activo =-1)


GO

CREATE PROCEDURE  dbo.invGetGlobalTransacciones @IDTipoTran AS INT, @Descr AS NVARCHAR(250),@Transaccion AS NVARCHAR(20), @Naturaleza AS NVARCHAR(1)
AS 
SELECT	 IDTipoTran ,
        Descr ,
        Transaccion ,
        Naturaleza ,
        Factor ,
        Orden ,
        SystemReadOnly ,
        EsTraslado ,
        EsFisico ,
        EsConsumo ,
        EsCompra ,
        EsVenta ,
        EsAjuste ,
        EsCosto ,
        EsRequisable ,
        DobleMovimiento  FROM dbo.globalTipoTran
WHERE (IDTipoTran = @IDTipoTran OR @IDTipoTran =-1) 
AND (Descr LIKE '%' + @Descr + '%' OR @Descr='*') 
AND (Transaccion = @Transaccion OR @Transaccion = '*') 
AND (Naturaleza = @Naturaleza OR @Naturaleza ='*')

GO


CREATE  Procedure [dbo].[invUpdateGlobalConsecutivos] @Operacion NVARCHAR(1), @IDConsecutivo INT OUTPUT, @Descr NVARCHAR(250), @Prefijo NVARCHAR(50), 
																					@Consecutivo int,@Documento NVARCHAR(20),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.globalConsecutivos( Descr ,Prefijo ,Consecutivo  ,Documento ,Activo)
	VALUES  (@Descr,@Prefijo,@Consecutivo,@Documento,@Activo)
	
	SET @IDConsecutivo = @@IDENTITY
end

if upper(@Operacion) = 'D'
begin

	--if Exists ( Select IDProducto  from  dbo.invTransaccionLinea    Where IDConsecutivo  = @IDImpuesto)	
	--begin 
	--	RAISERROR ( 'El impuesto que desea eliminar, esta asociado a un producto ', 16, 1) ;
	--	return				
	--end
	
	DELETE  FROM dbo.globalConsecutivos WHERE IDConsecutivo = @IDConsecutivo 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.globalConsecutivos SET  Descr = @Descr,Prefijo = @Prefijo ,Activo=@Activo, Documento = @Documento WHERE IDConsecutivo=@IDConsecutivo

END

GO



CREATE  PROCEDURE dbo.invGetGlobalConsecutivo(@IDConsecutivo AS INT,@Descr AS NVARCHAR(250),@Activo AS BIT)
AS 
SELECT  IDConsecutivo ,Descr ,Prefijo ,Consecutivo  ,Documento ,Activo 
 FROM dbo.globalConsecutivos WHERE (IDConsecutivo= @IDConsecutivo OR @IDConsecutivo=-1) and (Descr LIKE '%' + @Descr + '%' OR @Descr='*')  AND (Activo=@Activo OR @Activo=-1)

GO


CREATE  PROCEDURE [dbo].[invGetNextGlobalConsecutivo] (@IDConsecutivo AS INT ,@Documento AS NVARCHAR(20) OUTPUT)
AS
BEGIN
	

	UPDATE  dbo.globalConsecutivos  SET Documento=Prefijo + RIGHT('00000000'+ CAST(ISNULL(Consecutivo,0) +1 AS NVARCHAR(20)),8) , Consecutivo = ISNULL(Consecutivo,0) + 1
	WHERE IDConsecutivo=@IDConsecutivo

	SELECT @Documento = Documento FROM dbo.globalConsecutivos WHERE IDConsecutivo=@IDConsecutivo

	
END


GO


-- Se le pasa -1 para el nivel que quiero tomar el maximo
CREATE FUNCTION [dbo].[invGetNextConsecutivoTraslado] ()
RETURNS int
AS
BEGIN
Declare @Resultado BIGINT

set @Resultado = (
	SELECT max (IDTraslado) FROM dbo.invTraslados
	)
if @Resultado is null
	set @Resultado = 0


RETURN @Resultado
END





GO



CREATE  PROCEDURE dbo.invUpdateDocumentoInv(@Operacion NVARCHAR(1),@IDTransaccion AS INT OUTPUT,@ModuloOrigen NVARCHAR(4),@IDPaquete AS INT,@Fecha AS DATETIME,  @Usuario AS NVARCHAR(20),
											@Referencia AS NVARCHAR(250),@Documento NVARCHAR(250) OUTPUT,@Aplicado AS BIT,@EsTraslado AS BIT,@IDTraslado AS INT)
AS 
if upper(@Operacion) = 'I'
BEGIN
	--Obtener el siguiente consecutivo
	DECLARE @IDConsecutivo AS BIGINT
	
	SET @IDConsecutivo = (
				SELECT TOP 1 C.IDConsecutivo  FROM dbo.invPaquete A
				INNER JOIN dbo.globalConsecutivos C ON A.IDConsecutivo = C.IDConsecutivo
				WHERE A.IDPaquete=@IDPaquete)
	
	EXEC [dbo].[invGetNextGlobalConsecutivo] @IDConsecutivo,@Documento OUTPUT
	
	

	INSERT INTO dbo.invTransaccion( ModuloOrigen ,IDPaquete,Fecha ,Usuario ,Referencia ,Documento ,Aplicado ,UniqueValue ,EsTraslado ,IDTraslado  ,CreateDate)
	VALUES (@ModuloOrigen,@IDPaquete,@Fecha,@Usuario,@Referencia,@Documento,1,NEWID(),@EsTraslado,@IDTraslado,GETDATE())
	
	SET @IDTransaccion = @@IDENTITY
END
if upper(@Operacion) = 'D'
BEGIN
	DELETE FROM dbo.invTransaccionLinea WHERE IDTransaccion =@IDTransaccion
	DELETE FROM dbo.invTransaccion WHERE IDTransaccion =@IDTransaccion
END
IF UPPER(@Operacion)='U'
BEGIN
	UPDATE dbo.invTransaccion SET Aplicado=@Aplicado,Fecha=@Fecha,Referencia =@Referencia,Documento=@Documento  WHERE IDTransaccion=@IDTransaccion
END

GO

CREATE   PROCEDURE dbo.invUpdateDocumentoInvDetalle(@Operacion AS NVARCHAR(1),@IDTransaccion AS INT,@IDProducto AS INT,@IDLote AS INT,@IDTipoTran AS INT,@IDBodega AS INT,
											@IDTraslado AS INT,@Cantidad AS DECIMAL(28,4),@PrecioUnitarioDolar AS DECIMAL(28,4),@PrecioUnitarioLocal AS DECIMAL(28,4), 
											@CostoDolar AS decimal(28,4), @CostoLocal AS decimal(28,4), @Transaccion AS NVARCHAR(3),@TipoCambio AS decimal(26,4),@Aplicado AS BIT)
AS 


--Preguntar si se hace una revaloracion del costo dolar o costo local
SELECT @CostoLocal= CostoPromLocal,@CostoDolar = @CostoDolar  FROM dbo.invProducto WHERE IDProducto = @IDProducto
DECLARE @Naturaleza AS NVARCHAR(1)
DECLARE @Factor AS INT

SELECT @Naturaleza = Naturaleza,@Factor=Factor  FROM dbo.globalTipoTran WHERE IDTipoTran=@IDTipoTran

IF UPPER(@Operacion)='I'
BEGIN
	INSERT INTO dbo.invTransaccionLinea( IDTransaccion ,IDProducto ,IDLote ,IDTipoTran ,IDBodega ,IDTraslado  ,Naturaleza ,Factor ,Cantidad ,CostoUntLocal ,CostoUntDolar ,PrecioUntLocal ,PrecioUntDolar ,Transaccion ,TipoCambio ,Aplicado)
	VALUES (@IDTransaccion,@IDProducto,@IDLote,@IDTipoTran,@IDBodega,ISNULL(@IDTraslado,-1),@Naturaleza ,@Factor,@Cantidad,@CostoLocal,@CostoDolar,@PrecioUnitarioLocal,@PrecioUnitarioDolar,@Transaccion,@TipoCambio,@Aplicado)
END
IF UPPER(@Operacion)='U'
BEGIN
	UPDATE dbo.invTransaccionLinea SET Cantidad =@Cantidad , Naturaleza= @Naturaleza , Factor = @Factor,
		PrecioUntLocal = @PrecioUnitarioLocal,PrecioUntDolar = @PrecioUnitarioDolar,TipoCambio = @TipoCambio,Aplicado = @Aplicado
	WHERE IDTransaccion=@IDTransaccion AND IDProducto=@IDProducto AND IDLote=@IDLote AND IDTipoTran =@IDTipoTran AND IDBodega=@IDBodega
END
IF UPPER(@Operacion) = 'D'
BEGIN	
	DELETE FROM dbo.invTransaccionLinea WHERE   IDTransaccion=@IDTransaccion AND IDProducto=@IDProducto AND IDLote=@IDLote AND IDTipoTran =@IDTipoTran AND IDBodega=@IDBodega
END

GO

CREATE   PROCEDURE dbo.invGetTransaccionCabecera(@IdTransaccion AS INT)
AS 
SELECT  IDTransaccion ,
        ModuloOrigen ,
		IDPaquete, 
        Fecha ,
        Usuario ,
        Referencia ,
        Documento ,
        Aplicado ,
        UniqueValue ,
        EsTraslado ,
        IDTraslado ,
        CreateDate  FROM dbo.invTransaccion WHERE IDTransaccion =@IDTransaccion
 
GO

CREATE  PROCEDURE dbo.invGetTransaccionCabeceraByCriterio(@FechaInicio AS DATETIME,@FechaFinal AS DATETIME	, @Referencia AS NVARCHAR(250),
						@Documento AS NVARCHAR(250),@IDPaquete AS INT,@EsTraslado AS INT,@IDTraslado AS INT,@Usuario AS NVARCHAR(20))
AS 

set @FechaInicio = CAST(SUBSTRING(CAST(@FechaInicio AS CHAR),1,11) + ' 00:00:00.000' AS DATETIME)
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT  IDTransaccion ,
        ModuloOrigen ,
       IDPaquete, 
        Fecha ,
        Usuario ,
        Referencia ,
        Documento ,
        Aplicado ,
        UniqueValue ,
        EsTraslado ,
        IDTraslado ,
        CreateDate  FROM dbo.invTransaccion 
WHERE Fecha BETWEEN @FechaInicio AND @FechaFinal AND (Referencia LIKE  '%' + @Referencia +'%' OR @Referencia ='*') AND 
			(Documento LIKE '%' +@Documento +'%' OR @Documento='*') AND (EsTraslado = @EsTraslado OR  @EsTraslado = -1) AND	
			((EsTraslado = 1 AND IDTraslado = @IDTraslado ) OR @IDTraslado = -1) AND (Usuario = @Usuario OR @USuario = '*') AND 
			(IDPaquete = @IDPaquete OR @IDPaquete =-1)
			

GO

CREATE  PROCEDURE dbo.invGetTransaccionInvDetalle (@IDTransaccion AS INT )
AS 

SELECT  IDTransaccion ,A.IDProducto, P.Descr DescrProducto ,A.IDLote, L.LoteInterno, L.LoteProveedor,L.FechaVencimiento ,A.IDTipoTran,TT.Descr DescrTipoTran,
				B.IDBodega IDBodegaOrigen,B.Descr DescrBodegaOrigen ,IDTraslado ,A.Naturaleza ,A.Factor ,Cantidad ,CostoUntLocal ,CostoUntDolar ,
				PrecioUntLocal ,PrecioUntDolar ,A.Transaccion ,TipoCambio ,Aplicado, CASE WHEN ISNULL(E.Existencia,0) < A.Cantidad THEN 'E' ELSE 'N' END Estado
FROM dbo.invTransaccionLinea A 
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.invBodega B ON A.IDBodega=B.IDBodega
INNER JOIN dbo.invLote L ON A.IDLote = L.IDLote AND  A.IDProducto = L.IDProducto
INNER JOIN dbo.globalTipoTran TT ON A.IDTipoTran=TT.IDTipoTran
LEFT  JOIN dbo.invExistenciaBodega E ON a.IDBodega = E.IDBodega AND A.IDProducto=E.IDProducto AND A.IDLote=E.IDLote
 WHERE IDTransaccion  = @IDTransaccion


go

CREATE    PROCEDURE dbo.invGetEmptyTransaccionInvDetalle 
AS 
SELECT  IDTransaccion ,'A' Estado,A.IDProducto, P.Descr DescrProducto ,A.IDLote, L.LoteInterno,L.LoteProveedor ,A.IDTipoTran,TT.Descr DescrTipoTran ,A.IDBodega IDBodegaOrigen,BO.Descr DescrBodegaOrigen,A.IDBodega IDBodegaDestino,Bo.Descr DescrBodegaDestino ,IDTraslado ,A.Naturaleza ,A.Factor ,Cantidad ,CostoUntLocal ,CostoUntDolar ,PrecioUntLocal ,PrecioUntDolar ,A.Transaccion ,TipoCambio ,Aplicado  
FROM dbo.invTransaccionLinea A 
INNER JOIN dbo.invProducto P ON	A.IDProducto = P.IDProducto
INNER JOIN dbo.invBodega BO ON A.IDBodega= BO.IDBodega
INNER JOIN dbo.invLote L ON A.IDLote= L.IDLote  AND A.IDProducto=L.IDProducto
INNER JOIN dbo.globalTipoTran TT ON A.IDTipoTran = TT.IDTipoTran
WHERE 1=2


GO 

CREATE  PROCEDURE  dbo.invUpdateBodega(@Operacion AS NVARCHAR(1), @IDBodega AS int OUTPUT, @Descr nvarchar(250), @Activo AS bit,@PuedeFacturar AS bit,@PuedePreFacturar AS bit	,@IDPaqueteFactura AS int,@ConsecutivoPreFactura AS int)
AS 
IF UPPER(@Operacion) ='I'
BEGIN
	INSERT INTO dbo.invBodega( Descr ,Activo ,PuedeFacturar ,PuedePreFacturar ,IDPaqueteFactura ,ConsecutivoPreFactura)
	VALUES (@Descr,@Activo,@PuedeFacturar,@PuedePreFacturar,@IDPaqueteFactura,@ConsecutivoPreFactura)
END
IF UPPER(@Operacion) ='U'
BEGIN
	UPDATE dbo.invBodega SET PuedeFacturar =@PuedeFacturar,PuedePreFacturar = @PuedePreFacturar,IDPaqueteFactura = @IDPaqueteFactura, ConsecutivoPreFactura=@ConsecutivoPreFactura WHERE IDBodega = @IDBodega
END
IF UPPER(@Operacion)='D'
BEGIN
	DELETE FROM dbo.invBodega WHERE IDBodega=@IDBodega
END

GO

CREATE PROCEDURE dbo.invGetBodega(@IDBodega AS INT,@Descr AS NVARCHAR(250),@Activo AS INT)
AS 
SELECT IDBodega,Descr,Activo,PuedeFacturar,PuedePreFacturar,IDPaqueteFactura,ConsecutivoPreFactura  FROM dbo.invBodega WHERE (IDBodega = @IDBodega OR @IDBodega =-1) AND (Descr LIKE '%'+ @Descr+'%' OR @Descr ='*') AND (Activo = @Activo OR @Activo=-1)

GO 

CREATE PROCEDURE dbo.GetGlobalClaseTipoTran(@Transaccion AS nvarchar(3),@Descr AS NVARCHAR(250))
AS 
SELECT Transaccion,Descr FROM dbo.globalClaseTipoTran WHERE (Transaccion = @Transaccion OR @Transaccion ='*') AND (Descr LIKE '%'+ @Descr+'%' OR @Descr ='*') 

GO


CREATE  PROCEDURE  dbo.invUpdateLote(@Operacion AS NVARCHAR(1), @IDLote AS int OUTPUT, @IDProducto INT, @LoteInterno AS NVARCHAR(50),@LoteProveedor AS NVARCHAR(50),@FechaVencimiento AS DATE,@FechaFabricacion AS DATE,@FechaIngreso AS DATE )
AS 

IF UPPER(@Operacion) ='I'
BEGIN
	IF Exists(SELECT *  FROM dbo.invLote WHERE LoteInterno=@LoteInterno AND IDProducto=@IDProducto)
	BEGIN
		 RAISERROR ('Ya existe el Lote que desea ingresar, para el producto.', -- Message text.
               16, -- Severity.
               1 -- State.
               )
         RETURN 
	END
	SET @IDLote = ( SELECT MAX(IDLote)+1  FROM dbo.invLote)
	INSERT INTO dbo.invLote( IDLote ,IDProducto ,LoteInterno ,LoteProveedor ,FechaVencimiento ,FechaFabricacion ,FechaIngreso)
	VALUES (@IDLote,@IDProducto,@LoteInterno,@LoteProveedor,@FechaVencimiento,@FechaFabricacion,@FechaIngreso)
END
IF UPPER(@Operacion) ='U'
BEGIN
	UPDATE dbo.invLote SET LoteInterno =@LoteInterno,LoteProveedor = @LoteProveedor,FechaVencimiento = @FechaVencimiento, FechaFabricacion=@FechaFabricacion WHERE IDLote = @IDLote AND IDProducto=@IDProducto
END
IF UPPER(@Operacion)='D'
BEGIN
	DELETE FROM dbo.invLote WHERE IDLote=@IDLote  AND IDProducto=@IDProducto
END

GO

CREATE   PROCEDURE dbo.invGetLote(@IDLote AS INT,@IDProducto AS INT ,@LoteInterno AS NVARCHAR(50),@LoteProveedor AS NVARCHAR(50))
AS 
SELECT  IDLote ,
        L.IDProducto ,
        P.Descr DescrProducto,  
        LoteInterno ,
        LoteProveedor ,
        FechaVencimiento ,
        FechaFabricacion ,
        FechaIngreso  FROM dbo.invLote L
       INNER JOIN dbo.invProducto P ON L.IDProducto = P.IDProducto
        WHERE (IDLote = @IDLote OR @IDLote =-1) AND (L.IDProducto = @IDProducto OR @IDProducto =-1)  AND (LoteInterno LIKE '%'+ @LoteInterno+'%' OR @LoteInterno ='*') AND (LoteProveedor LIKE '%'+ @LoteProveedor+'%' OR @LoteProveedor ='*')  

GO 


CREATE    PROCEDURE dbo.invUpdateCuentaContableInv(@Operacion NVARCHAR(1),@IDCuenta AS INT OUTPUT,@Descr NVARCHAR(250),@CtrInventario AS INT,@CtaInventario AS INT,  @CtrVenta AS INT,
											@CtaVenta AS INT,@CtrCompra as INT,@CtaCompra AS INT,@CtrDescVenta AS INT,@CtaDescVenta AS INT, @CtrCostoVenta AS INT,@CtaCostoVenta AS INT,@CtrComisionVenta AS INT,
											@CtaComisionVenta AS INT,@CtrComisionCobro AS INT,@CtaComisionCobro AS INT,@CtrDescLinea AS INT,@CtaDescLinea AS INT,@CtrCostoDesc AS INT,@CtaCostoDesc AS INT,@CtrSobranteInvFisico AS INT,
											@CtaSobranteInvFisico AS INT,@CtrFaltanteInvFisico AS INT,@CtaFaltanteInvFisico AS INT,@CtrVariacionCosto AS int,@CtaVariacionCosto AS int, @CtrVencimiento AS int, @CtaVencimiento AS int	,
											@CtrDescBonificacion AS int	,@CtaDescBonificacion AS int	,@CtrDevVentas AS int	,@CtaDevVentas AS int	)
AS 
if upper(@Operacion) = 'I'
BEGIN
	--Obtener el siguiente consecutivo
	DECLARE @IDConsecutivo AS BIGINT
	
	SET @IDConsecutivo = (
				SELECT ISNULL(MAX( IDCuenta),0) +1 FROM dbo.invCuentaContable )
	
	SET @IDCuenta = @IDConsecutivo

	INSERT INTO dbo.invCuentaContable(IDCuenta ,Descr ,CtrInventario ,CtaInventario ,CtrVenta , CtaVenta ,CtrCompra ,CtaCompra ,
	          CtrDescVenta ,CtaDescVenta ,CtrCostoVenta ,CtaCostoVenta ,CtrComisionVenta ,CtaComisionVenta ,CtrComisionCobro ,
	          CtaComisionCobro ,CtrDescLinea ,CtaDescLinea ,CtrCostoDesc ,CtaCostoDesc ,CtrSobranteInvFisico ,CtaSobranteInvFisico ,
	          CtrFaltanteInvFisico ,CtaFaltanteInvFisico ,CtrVariacionCosto ,CtaVariacionCosto ,CtrVencimiento ,CtaVencimiento ,CtrDescBonificacion ,
	          CtaDescBonificacion ,CtrDevVentas ,CtaDevVentas)
	VALUES  ( @IDCuenta , -- IDCuenta - bigint
	          @Descr , -- Descr - nvarchar(250)
	          @CtrInventario , -- CtrInventario - int
	          @CtaInventario , -- CtaInventario - int
	          @CtrVenta , -- CtrVenta - int
	          @CtaVenta , -- CtaVenta - int
	          @CtrCompra , -- CtrCompra - int
	          @CtaCompra , -- CtaCompra - int
	          @CtrDescVenta , -- CtrDescVenta - int
	          @CtaDescVenta , -- CtaDescVenta - int
	          @CtrCostoVenta , -- CtrCostoVenta - int
	          @CtaCostoVenta , -- CtaCostoVenta - int
	          @CtrComisionVenta , -- CtrComisionVenta - int
	          @CtaComisionVenta , -- CtaComisionVenta - int
	          @CtrComisionCobro , -- CtrComisionCobro - int
	          @CtaComisionCobro , -- CtaComisionCobro - int
	          @CtrDescLinea , -- CtrDescrLinea - int
	          @CtaDescLinea , -- CtaDescLinea - int
	          @CtrCostoDesc , -- CtrCostoDesc - int
	          @CtaCostoDesc , -- CtaCostoDesc - int
	          @CtrSobranteInvFisico , -- CtrSobranteInvFisico - int
	          @CtaSobranteInvFisico , -- CtaSobranteInvFisico - int
	          @CtrFaltanteInvFisico , -- CtrFaltanteInvFisico - int
	          @CtaFaltanteInvFisico , -- CtaFaltanteInvFisico - int
	          @CtrVariacionCosto , -- CtrVariacionCosto - int
	          @CtaVariacionCosto , -- CtaVariacionCosto - int
	          @CtrVencimiento , -- CtrVencimiento - int
	          @CtaVencimiento , -- CtaVencimiento - int
	          @CtrDescBonificacion , -- CtrDescBonificacion - int
	          @CtaDescBonificacion , -- CtaDescBonificacion - int
	          @CtrDevVentas , -- CtrDevVentas - int
	          @CtaDevVentas  -- CtaDevVentas - int
	        )
	
END
if upper(@Operacion) = 'D'
BEGIN	
	UPDATE dbo.invProducto SET  IDCuentaContable=NULL WHERE IDCuentaContable=@IDCuenta
	DELETE FROM dbo.invCuentaContable WHERE IDCuenta =@IDCuenta
END
IF UPPER(@Operacion)='U'
BEGIN
	UPDATE dbo.invCuentaContable SET  
		Descr =@Descr,
		CtrInventario = @CtrInventario,
		CtaInventario = @CtaInventario,
		CtrVenta = @CtrVenta,
		CtaVenta = @CtaVenta,
		CtrCompra = @CtrCompra,
		CtaCompra = @CtaCompra,
		CtrDescVenta =@CtrDescVenta,
		CtaDescVenta=@CtaDescVenta,
		CtrCostoVenta = @CtrCostoVenta,
		CtaCostoVenta = @CtaCostoVenta,
		CtrComisionVenta =@CtrComisionVenta,
		CtaComisionVenta = @CtaComisionVenta,
		CtrComisionCobro =@CtrComisionCobro,
		CtaComisionCobro = @CtaComisionCobro,
		CtrDescLinea = @CtrDescLinea,
		CtaDescLinea = @CtaDescLinea,
		CtrCostoDesc= @CtrCostoDesc,
		CtaCostoDesc = @CtaCostoDesc,
		CtrSobranteInvFisico = @CtrSobranteInvFisico,
		CtaSobranteInvFisico = @CtaSobranteInvFisico,
		CtrFaltanteInvFisico = @CtrFaltanteInvFisico,
		CtaFaltanteInvFisico= @CtaFaltanteInvFisico,
		CtrVariacionCosto = @CtrVariacionCosto,
		CtaVariacionCosto = @CtaVariacionCosto,
		CtrVencimiento = @CtrVencimiento,
		CtaVencimiento = @CtaVencimiento,
		CtrDescBonificacion = @CtrDescBonificacion,
		CtaDescBonificacion= @CtaDescBonificacion,
		CtrDevVentas = @CtrDevVentas,
		CtaDevVentas = @CtaDevVentas
	WHERE IDCuenta=@IDCuenta
END


GO 

CREATE PROCEDURE dbo.invGetCuentaContableInv (@IDCuentaContable AS BIGINT,@Descr AS NVARCHAR(250))
AS 
SELECT  IDCuenta ,
        Descr ,
        CtrInventario ,
        CtaInventario ,
        CtrVenta ,
        CtaVenta ,
        CtrCompra ,
        CtaCompra ,
        CtrDescVenta ,
        CtaDescVenta ,
        CtrCostoVenta ,
        CtaCostoVenta ,
        CtrComisionVenta ,
        CtaComisionVenta ,
        CtrComisionCobro ,
        CtaComisionCobro ,
        CtrDescLinea ,
        CtaDescLinea ,
        CtrCostoDesc ,
        CtaCostoDesc ,
        CtrSobranteInvFisico ,
        CtaSobranteInvFisico ,
        CtrFaltanteInvFisico ,
        CtaFaltanteInvFisico ,
        CtrVariacionCosto ,
        CtaVariacionCosto ,
        CtrVencimiento ,
        CtaVencimiento ,
        CtrDescBonificacion ,
        CtaDescBonificacion ,
        CtrDevVentas ,
        CtaDevVentas  FROM dbo.invCuentaContable WHERE (IDCuenta = @IDCuentaContable OR @IDCuentaContable = -1)
AND (Descr  LIKE '%' + @Descr + '%' OR  @Descr = '*')


GO 



CREATE   PROCEDURE dbo.invGetExistenciaBodega (@IDBodega AS BIGINT,@IDProducto AS BIGINT,@IDLote AS  BIGINT)
AS 
SELECT A.IDBodega,B.Descr DescrBodega,A.IDProducto,P.Descr DescrProducto,A.IDLote, L.LoteInterno , L.LoteProveedor,L.FechaVencimiento,L.FechaIngreso,A.Existencia,A.Reservada  FROM dbo.invExistenciaBodega A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.invLote L ON P.IDProducto = L.IDProducto AND A.IDLote=L.IDLote
INNER JOIN dbo.invBodega B ON A.IDBodega=B.IDBodega
WHERE (A.IDBodega =  @IDBodega OR @IDBodega =-1) AND (A.IDProducto = @IDProducto OR @IDProducto=-1)
AND (A.IDLote = @IDLote  OR @IDLote=-1)


GO


CREATE  PROCEDURE dbo.invGetExistenciaBodegabyClasificacion (@Bodega AS NVARCHAR(4000), @Producto AS NVARCHAR(250),
							@Lote AS  NVARCHAR(4000),@Clasif1 AS NVARCHAR(4000),@Clasif2 NVARCHAR(4000), @Clasif3 NVARCHAR(4000),
							@Clasif4 NVARCHAR(4000), @Clasif5 NVARCHAR(4000), @Clasif6 NVARCHAR(4000))
AS 
DECLARE @Separador AS NVARCHAR(1)
SET @Separador =','

SELECT A.IDBodega,B.Descr DescrBodega,A.IDProducto,P.Descr DescrProducto,A.IDLote, L.LoteInterno , L.LoteProveedor,L.FechaVencimiento,L.FechaIngreso,A.Existencia,A.Reservada  
FROM dbo.invExistenciaBodega A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.invLote L ON P.IDProducto = L.IDProducto AND A.IDLote=L.IDLote
INNER JOIN dbo.invBodega B ON A.IDBodega=B.IDBodega
WHERE (A.IDBodega  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Bodega,@Separador) )or @Bodega ='*') AND (A.IDProducto IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) OR @Producto='*')
AND (A.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') AND (P.Clasif1   IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif1,@Separador)) or @Clasif1='*') 
AND (P.Clasif2  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif2,@Separador)) or @Clasif2='*') AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) or @Clasif3='*')
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif3,@Separador)) or @Clasif3='*') AND (P.Clasif4  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif4,@Separador) ) or @Clasif4='*')
AND (P.Clasif5  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif5,@Separador)) or @Clasif5='*')  AND (P.Clasif6 IN (SELECT Value FROM [dbo].[ConvertListToTable](@clasif6,@Separador)) or @Clasif6='*')


GO



CREATE PROCEDURE dbo.invGetClasificacionesSplit(@IDGrupo INT ,@lstClasificaciones NVARCHAR(2000))
AS 
/*
DECLARE @IDGrupo AS INT
DECLARE @lstClasificaciones  AS NVARCHAR(2000)
SET @IDGrupo=-1
SET @lstClasificaciones ='3,5'
*/


SELECT IDClasificacion,Descr
FROM dbo.invClasificacion A
WHERE (IDGrupo = @IDGrupo OR @IDGrupo=-1) 
AND (IDClasificacion IN (SELECT *  FROM dbo.ConvertListToTable(@lstClasificaciones,',')) OR @lstClasificaciones='*')
AND Activo=1

GO


CREATE PROCEDURE dbo.invGetProductoSplit(@lstProducto NVARCHAR(2000))
AS 
/*
DECLARE @lstProducto  AS NVARCHAR(2000)
SET @lstProducto ='1,2'
*/

SELECT IDProducto,Descr
FROM dbo.invProducto A
WHERE (IDProducto IN (SELECT *  FROM dbo.ConvertListToTable(@lstProducto,',')) OR @lstProducto='*')
AND Activo=1

GO


CREATE PROCEDURE dbo.invGetLoteSplit(@lstProducto NVARCHAR(2000),@lstLote NVARCHAR(2000))
AS 
/*
DECLARE @lstProducto  AS NVARCHAR(2000)
SET @lstProducto ='1,2'
*/

SELECT IDLote,LoteProveedor
FROM dbo.invLote A
WHERE (IDProducto IN (SELECT *  FROM dbo.ConvertListToTable(@lstProducto,',')) OR @lstProducto='*') AND (IDLote IN (SELECT *  FROM dbo.ConvertListToTable(@lstLote,',')) OR @lstLote='*')


GO

CREATE PROCEDURE dbo.invGetBodegaSplit(@lstBodega NVARCHAR(2000))
AS 
/*
DECLARE @lstProducto  AS NVARCHAR(2000)
SET @lstProducto ='1,2'
*/

SELECT IDBodega,Descr
FROM dbo.invBodega A
WHERE (IDBodega IN (SELECT *  FROM dbo.ConvertListToTable(@lstBodega,',')) OR @lstBodega='*') 




GO


CREATE  PROCEDURE dbo.invGetExistenciaBodegabyClasificacion (@Bodega AS NVARCHAR(4000), @Producto AS NVARCHAR(250),
							@Lote AS  NVARCHAR(4000),@Clasif1 AS NVARCHAR(4000),@Clasif2 NVARCHAR(4000), @Clasif3 NVARCHAR(4000),
							@Clasif4 NVARCHAR(4000), @Clasif5 NVARCHAR(4000), @Clasif6 NVARCHAR(4000))
AS 
DECLARE @Separador AS NVARCHAR(1)
SET @Separador =','

SELECT A.IDBodega,B.Descr DescrBodega,A.IDProducto,P.Descr DescrProducto,A.IDLote, L.LoteInterno , L.LoteProveedor,L.FechaVencimiento,L.FechaIngreso,A.Existencia,A.Reservada  
FROM dbo.invExistenciaBodega A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.invLote L ON P.IDProducto = L.IDProducto AND A.IDLote=L.IDLote
INNER JOIN dbo.invBodega B ON A.IDBodega=B.IDBodega
WHERE (A.IDBodega  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Bodega,@Separador) )or @Bodega ='*') AND (A.IDProducto IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) OR @Producto='*')
AND (A.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') AND (P.Clasif1   IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif1,@Separador)) or @Clasif1='*') 
AND (P.Clasif2  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif2,@Separador)) or @Clasif2='*') AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) or @Clasif3='*')
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif3,@Separador)) or @Clasif3='*') AND (P.Clasif4  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif4,@Separador) ) or @Clasif4='*')
AND (P.Clasif5  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif5,@Separador)) or @Clasif5='*')  AND (P.Clasif6 IN (SELECT Value FROM [dbo].[ConvertListToTable](@clasif6,@Separador)) or @Clasif6='*')


GO


CREATE  PROCEDURE dbo.invGetConsultaTransaccionesByCriterio (@Bodega AS NVARCHAR(4000), @Producto AS NVARCHAR(250),
							@Lote AS  NVARCHAR(4000),@Clasif1 AS NVARCHAR(4000),@Clasif2 NVARCHAR(4000), @Clasif3 NVARCHAR(4000),
							@Clasif4 NVARCHAR(4000), @Clasif5 NVARCHAR(4000), @Clasif6 NVARCHAR(4000),@Transacciones NVARCHAR(4000),
							@Paquete NVARCHAR(4000),@Documento NVARCHAR(4000), @Referencia NVARCHAR(4000),@FechaInicial DATE, @FechaFinal DATE)
AS 
DECLARE @Separador NVARCHAR(1)
SET @Separador =','

SELECT  A.IDTransaccion ,A.ModuloOrigen ,A.IDPaquete ,PQ.Descr DescrPaquete,A.Fecha ,A.Usuario ,B.IDProducto,P.Descr DescrProducto,
		B.IDBodega ,C.Descr DescrBodega,B.IDTipoTran,T.Descr DescrTipoTran,B.IDLote ,L.LoteProveedor,L.FechaIngreso,L.FechaVencimiento,L.FechaFabricacion,B.Cantidad ,
		B.PrecioUntDolar , B.PrecioUntLocal,B.CostoUntDolar,B.CostoUntLocal, B.TipoCambio, A.Referencia ,A.Documento ,A.Asiento ,A.Aplicado  ,A.EsTraslado ,A.IDTraslado ,A.CreateDate 
FROM dbo.invTransaccion A
INNER JOIN dbo.invTransaccionLinea B ON A.IDTransaccion = B.IDTransaccion
INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
INNER JOIN dbo.invBodega C ON B.IDBodega = C.IDBodega
INNER JOIN dbo.invPaquete PQ ON A.IDPaquete = PQ.IDPaquete
INNER JOIN dbo.invLote L ON B.IDLote=L.IDLote AND B.IDProducto =L.IDProducto
INNER JOIN dbo.globalTipoTran T ON B.IDTipoTran = T.IDTipoTran
WHERE (B.IDBodega  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Bodega,@Separador) )or @Bodega ='*') 
AND (B.IDProducto IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) OR @Producto='*')
AND (B.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') 
AND (P.Clasif1   IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif1,@Separador)) or @Clasif1='*') 
AND (P.Clasif2  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif2,@Separador)) or @Clasif2='*') 
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) or @Clasif3='*')
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif3,@Separador)) or @Clasif3='*') 
AND (P.Clasif4  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif4,@Separador) ) or @Clasif4='*')
AND (P.Clasif5  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif5,@Separador)) or @Clasif5='*')  
AND (P.Clasif6 IN (SELECT Value FROM [dbo].[ConvertListToTable](@clasif6,@Separador)) or @Clasif6='*')
AND (b.IDTransaccion IN (SELECT *  FROM dbo.ConvertListToTable(@Transacciones,@Separador)) or @Transacciones='*')
AND (A.IDPaquete IN (SELECT *  FROM dbo.ConvertListToTable(@Paquete,@Separador)) or @Paquete='*')
AND (A.Documento LIKE '%' + @Documento +'%' OR  @Documento='*')
AND (A.Referencia LIKE '%' +  @Referencia + '%' OR  @Referencia ='*')
AND A.Fecha BETWEEN @FechaInicial AND @FechaFinal

GO 


CREATE     PROCEDURE [dbo].[invGetProductoByID] @IDProducto BIgint	,@Descr AS NVARCHAR(250)
AS 
	SELECT IDProducto,P.Descr ,Alias ,Clasif1,C1.Descr DescrClasif1 ,Clasif2 ,C2.Descr DescrClasif2,Clasif3,C3.Descr DescrClasif3 ,Clasif4 ,C4.Descr DescrClasif4,
				Clasif5 ,C5.Descr DescrClasif5 ,Clasif6, C6.Descr DescrClasif6 ,P.CostoPromDolar,P.CostoPromLocal,P.CostoUltDolar,P.CostoUltLocal,CodigoBarra,IDCuentaContable ,P.IDUnidad ,UM.Descr DescrUnidadMedida,FactorEmpaque ,TipoImpuesto , I.Descr DescrTipoImpuesto,
	          EsMuestra ,EsControlado ,EsEtico ,BajaPrecioDistribuidor ,BajaPrecioProveedor ,PorcDescuentoAlzaProveedor ,BonificaFA ,BonificaCOPorCada ,BonificaCOCantidad ,
	          P.Activo ,UserInsert ,UserUpdate  ,UpdateDate,CreateDate FROM dbo.invProducto  P
	          LEFT JOIN dbo.invUnidadMedida UM ON P.IDUnidad = UM.IDUnidad
	          LEFT JOIN dbo.globalImpuesto I ON P.TipoImpuesto = I.IDImpuesto
			  LEFT JOIN dbo.invClasificacion C1 ON P.Clasif1=C1.IDClasificacion  AND C1.IDGrupo=1
			  LEFT JOIN dbo.invClasificacion C2 ON P.Clasif2=C2.IDClasificacion  AND C2.IDGrupo=2
			  LEFT JOIN dbo.invClasificacion C3 ON P.Clasif3=C3.IDClasificacion  AND C3.IDGrupo=3
			  LEFT JOIN dbo.invClasificacion C4 ON P.Clasif4=C4.IDClasificacion  AND C4.IDGrupo=4
			  LEFT JOIN dbo.invClasificacion C5 ON P.Clasif5=C5.IDClasificacion  AND C5.IDGrupo=5
			  LEFT JOIN dbo.invClasificacion C6 ON P.Clasif6=C6.IDClasificacion  AND C6.IDGrupo=6
	          WHERE (IDProducto=@IDProducto OR  @IDProducto=-1) AND 
	          (P.Descr =@Descr OR P.Descr LIKE '%' +@Descr + '%' OR @Descr='*') 
	          
GO

CREATE  PROCEDURE dbo.invGetGrupoClasif (@IDGrupo AS int	,@Descr AS nvarchar(250))
AS 
SELECT IDGrupo,Descr ,Etiqueta,Activo FROM dbo.invGrupoClasif
WHERE (IDGrupo=@IDGrupo OR @IDGrupo=-1) AND (Descr LIKE '%Descr%' OR @Descr ='*')
AND Activo=1

GO
 
CREATE  FUNCTION  [dbo].[invNextConsecutivoClasificacionInv] ()
RETURNS bigint
AS 
BEGIN	
DECLARE @NextConsecutivo AS bigint 
SELECT @NextConsecutivo= ISNULL(MAX(IDClasificacion),0) + 1 
FROM dbo.invClasificacion 

RETURN   @NextConsecutivo

END 

GO
 

CREATE Procedure [dbo].[invUpdateInvGrupoClasificacion] @Operacion nvarchar(1), @IDGrupo int, @Descr nvarchar(250),@Activo BIT
as
set nocount on 
if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.invGrupoClasif SET  Descr = @Descr,Activo=@Activo WHERE IDGrupo = @IDGrupo

end

GO
 