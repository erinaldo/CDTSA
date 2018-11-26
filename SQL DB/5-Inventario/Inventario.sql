
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
	[IDCuentaContable] [BigInt]  ,
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

ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProducto_TipoImpuesto] FOREIGN KEY([TipoImpuesto])
REFERENCES [dbo].[globalImpuesto] ([IDImpuesto])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProducto_TipoImpuesto]
GO


CREATE  TABLE [dbo].[invCuentaContable](
	[IDCuenta] [bigint] NOT NULL,
	[Descr][nvarchar](250)  NOT NULL,
	[CtrInventario][int],
	[CtaInventario][bigint],
	[CtrVenta] [int], 
	[CtaVenta] [bigint], 
	[CtrCompra] [int], 
	[CtaCompra][bigint],
	[CtrDescVenta] [int],    
	[CtaDescVenta] [bigint], 
    [CtrCostoVenta] [int],     
    [CtaCostoVenta] [bigint], 
    [CtrComisionVenta] [int], 
    [CtaComisionVenta] [bigint], 
    [CtrComisionCobro] [int], 
    [CtaComisionCobro] [bigint], 
    [CtrDescLinea] [int],
    [CtaDescLinea] [bigint],  
    [CtrCostoDesc] [int], 
    [CtaCostoDesc] [bigint], 
    [CtrSobranteInvFisico] [int], 
    [CtaSobranteInvFisico] [bigint], 
    [CtrFaltanteInvFisico] [int], 
    [CtaFaltanteInvFisico] [bigint], 
    [CtrVariacionCosto] [int],   
    [CtaVariacionCosto] [bigint],  
    [CtrVencimiento] [int], 
    [CtaVencimiento] [bigint], 
    [CtrDescBonificacion] [int], 
    [CtaDescBonificacion] [bigint], 
    [CtrDevVentas] [int], 
    [CtaDevVentas] [bigint],
    [CtrConsumo] [int],
    [CtaConsumo] [bigint]
 CONSTRAINT [pkinvCuentaContable] PRIMARY KEY CLUSTERED 
(
	[IDCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrInventario] FOREIGN KEY([CtrInventario])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrInventario]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrVenta] FOREIGN KEY([CtrVenta])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrVenta]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrCompra] FOREIGN KEY([CtrCompra])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrCompra]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrDescVenta] FOREIGN KEY([CtrDescVenta])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrDescVenta]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrCostoVenta] FOREIGN KEY([CtrCostoVenta])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrCostoVenta]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrComisionVenta] FOREIGN KEY([CtrComisionVenta])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrComisionVenta]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrComisionCobro] FOREIGN KEY([CtrComisionCobro])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrComisionCobro]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrDescLinea] FOREIGN KEY([CtrDescLinea])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrDescLinea]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrCostoDesc] FOREIGN KEY([CtrCostoDesc])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrCostoDesc]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrFaltanteInvFisico] FOREIGN KEY([CtrFaltanteInvFisico])
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrFaltanteInvFisico]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrVariacionCosto] FOREIGN KEY(CtrVariacionCosto)
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrVariacionCosto]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrVencimiento] FOREIGN KEY(CtrVencimiento)
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrVencimiento]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrDescBonificacion] FOREIGN KEY(CtrDescBonificacion)
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrDescBonificacion]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrDevVentas] FOREIGN KEY(CtrDevVentas)
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrDevVentas]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtrConsumo] FOREIGN KEY(CtrConsumo)
REFERENCES dbo.cntCentroCosto ([IDCentro])
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtrConsumo]
GO



ALTER TABLE [dbo].[invProducto]  WITH CHECK ADD  CONSTRAINT [fkinvProductoCuentaContable] FOREIGN KEY([IDCuentaContable])
REFERENCES [dbo].[invCuentaContable] ([IDCuenta])
GO

ALTER TABLE [dbo].[invProducto] CHECK CONSTRAINT [fkinvProductoCuentaContable]
GO



--//Begin
ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaInventario] FOREIGN KEY([CtaInventario])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaInventario]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaVenta] FOREIGN KEY([CtaVenta])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaVenta]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaCompra] FOREIGN KEY([CtaCompra])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaCompra]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaDescVenta] FOREIGN KEY([CtaDescVenta])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaDescVenta]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaCostoVenta] FOREIGN KEY([CtaCostoVenta])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaCostoVenta]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaComisionVenta] FOREIGN KEY([CtaComisionVenta])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaComisionVenta]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaComisionCobro] FOREIGN KEY([CtaComisionCobro])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaComisionCobro]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaDescLinea] FOREIGN KEY([CtaDescLinea])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaDescLinea]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaCostoDesc] FOREIGN KEY([CtaCostoDesc])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaCostoDesc]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaFaltanteInvFisico] FOREIGN KEY([CtaFaltanteInvFisico])
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaFaltanteInvFisico]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaVariacionCosto] FOREIGN KEY(CtaVariacionCosto)
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaVariacionCosto]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaVencimiento] FOREIGN KEY(CtaVencimiento)
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaVencimiento]
GO

ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaDescBonificacion] FOREIGN KEY(CtaDescBonificacion)
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaDescBonificacion]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaDevVentas] FOREIGN KEY(CtaDevVentas)
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaDevVentas]
GO


ALTER TABLE [dbo].[invCuentaContable]  WITH CHECK ADD  CONSTRAINT [fkinvCuentaContable_CtaConsumo] FOREIGN KEY(CtaConsumo)
REFERENCES dbo.cntCuenta (IDCuenta)
GO

ALTER TABLE [dbo].[invCuentaContable] CHECK CONSTRAINT [fkinvCuentaContable_CtaConsumo]
GO


--//End

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
@Clasif1 int, @Clasif2 INT, @Clasif3 INT ,@Clasif4 INT , @Clasif5 INT, @Clasif6 INT,@IDCuentaContable AS BIGINT, @CodigoBarra NVARCHAR(50),@IDUnidad INT,
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
	
	if Exists ( Select IDProducto  from  dbo.invTransaccionLinea   Where IDProducto  = @IDProducto)	
	begin 
		RAISERROR ( 'El producto no puede ser eliminado, tiene movimientos en el inventario, unicamente lo puede desactivar', 16, 1) ;
		return				
	END
	
	if Exists ( SELECT IDProducto  from  dbo.invExistenciaBodega    Where IDProducto  = @IDProducto AND Existencia>0 )	
	begin 
		RAISERROR ( 'El artículo tiene existencia en Bodega, no se puede eliminar', 16, 1) ;
		return				
	END

	if Exists ( Select IDLote  from  dbo.invLote    Where IDProducto  = @IDProducto AND IDLote<>0)	
	begin 
		RAISERROR ( 'El artículo tiene asociado lotes, por favor elimine los lotes antes de eliminar el producto', 16, 1) ;
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
IF @IDTipoTran NOT IN (6,7)  
BEGIN
	SELECT @CostoLocal= CostoPromLocal,@CostoDolar = @CostoDolar  FROM dbo.invProducto WHERE IDProducto = @IDProducto
END
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
        ISNULL(Asiento,'ND') Asiento,
        Documento ,
        Aplicado ,
        UniqueValue ,
        EsTraslado ,
        IDTraslado ,
        CreateDate  FROM dbo.invTransaccion WHERE IDTransaccion =@IDTransaccion
 
GO

CREATE  PROCEDURE dbo.invGetTransaccionCabeceraByCriterio(@FechaInicio AS DATETIME,@FechaFinal AS DATETIME	, @Referencia AS NVARCHAR(250),
						@Documento AS NVARCHAR(250),@IDPaquete AS INT,@EsTraslado AS INT,@IDTraslado AS INT,@AsientoContable NVARCHAR(20),@Usuario AS NVARCHAR(20))
AS 

set @FechaInicio = CAST(SUBSTRING(CAST(@FechaInicio AS CHAR),1,11) + ' 00:00:00.000' AS DATETIME)
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT  IDTransaccion ,
        ModuloOrigen ,
       IDPaquete, 
        Fecha ,
        Usuario ,
        Referencia ,
        ISNULL(Asiento,'ND') Asiento,
        Documento ,
        ASIENTO,
        Aplicado ,
        UniqueValue ,
        EsTraslado ,
        IDTraslado ,
        CreateDate  FROM dbo.invTransaccion 
WHERE Fecha BETWEEN @FechaInicio AND @FechaFinal AND (Referencia LIKE  '%' + @Referencia +'%' OR @Referencia ='*') AND 
			(Documento LIKE '%' +@Documento +'%' OR @Documento='*') AND (EsTraslado = @EsTraslado OR  @EsTraslado = -1) AND	
			((EsTraslado = 1 AND IDTraslado = @IDTraslado ) OR @IDTraslado = -1) AND (Usuario = @Usuario OR @USuario = '*') AND 
			(IDPaquete = @IDPaquete OR @IDPaquete =-1) AND (Asiento =@AsientoContable  OR @AsientoContable='*')
			

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
		if Exists ( Select IDProducto  from  dbo.invExistenciaBodega   Where IDProducto  = @IDProducto AND IDLote=@IDLote)	
	begin 
		RAISERROR ( 'El lote no puede ser eliminado, tiene Existencias en el inventario, unicamente lo puede desactivar', 16, 1) ;
		return				
	END
	
	if Exists ( Select IDProducto  from  dbo.invTransaccionLinea   Where IDProducto  = @IDProducto AND IDLote=@IDLote)	
	begin 
		RAISERROR ( 'El lote no puede ser eliminado, tiene movimientos en el inventario, unicamente lo puede desactivar', 16, 1) ;
		return				
	END
	
	if Exists ( Select *  from  dbo.invBoletaInvFisico   Where IDProducto  = @IDProducto AND IDLote=@IDLote)	
	begin 
		RAISERROR ( 'El lote tiene registro en Boletas de inventario. ', 16, 1) ;
		return				
	END

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


CREATE   PROCEDURE dbo.invUpdateCuentaContableInv(@Operacion NVARCHAR(1),@IDCuenta AS INT OUTPUT,@Descr NVARCHAR(250),@CtrInventario AS INT,@CtaInventario AS BIGINT,  @CtrVenta AS INT,
											@CtaVenta AS BIGINT,@CtrCompra as INT,@CtaCompra AS BIGINT,@CtrDescVenta AS INT,@CtaDescVenta AS BIGINT, @CtrCostoVenta AS INT,@CtaCostoVenta AS BIGINT,@CtrComisionVenta AS INT,
											@CtaComisionVenta AS BIGINT,@CtrComisionCobro AS INT,@CtaComisionCobro AS BIGINT,@CtrDescLinea AS INT,@CtaDescLinea AS BIGINT,@CtrCostoDesc AS INT,@CtaCostoDesc AS BIGINT,@CtrSobranteInvFisico AS INT,
											@CtaSobranteInvFisico AS BIGINT,@CtrFaltanteInvFisico AS INT,@CtaFaltanteInvFisico AS BIGINT,@CtrVariacionCosto AS int,@CtaVariacionCosto AS BIGINT, @CtrVencimiento AS int, @CtaVencimiento AS BIGINT	,
											@CtrDescBonificacion AS int	,@CtaDescBonificacion AS BIGINT	,@CtrDevVentas AS int	,@CtaDevVentas AS BIGINT,@CtrConsumo AS INT,@CtaConsumo AS BIGINT	)
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
	          CtaDescBonificacion ,CtrDevVentas ,CtaDevVentas,CtrConsumo,CtaConsumo)
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
	          @CtaDevVentas,  -- CtaDevVentas - int
	          @CtrConsumo,
	          @CtaConsumo
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
		CtaDevVentas = @CtaDevVentas,
		CtrConsumo = @CtrConsumo,
		CtaConsumo = @CtaConsumo
	WHERE IDCuenta=@IDCuenta
END


GO 

CREATE  PROCEDURE dbo.invGetCuentaContableInv (@IDCuentaContable AS BIGINT,@Descr AS NVARCHAR(250))
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
        CtaDevVentas,
        CtrConsumo,
        CtaConsumo  FROM dbo.invCuentaContable WHERE (IDCuenta = @IDCuentaContable OR @IDCuentaContable = -1)
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


CREATE  PROCEDURE [dbo].[invGetTransaccionesByProducto] (@Bodega AS NVARCHAR(4000), @IDProducto AS INT,
							@Lote AS  NVARCHAR(4000),@Transacciones NVARCHAR(4000),@Paquete NVARCHAR(4000),
							@Documento NVARCHAR(4000), @Referencia NVARCHAR(4000),@FechaInicial DATE, @FechaFinal DATE)
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
AND (B.IDProducto =@IDProducto OR @IDProducto=-1)
AND (B.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') 
AND (b.IDTransaccion IN (SELECT *  FROM dbo.ConvertListToTable(@Transacciones,@Separador)) or @Transacciones='*')
AND (A.IDPaquete IN (SELECT *  FROM dbo.ConvertListToTable(@Paquete,@Separador)) or @Paquete='*')
AND (A.Documento LIKE '%' + @Documento +'%' OR  @Documento='*')
AND (A.Referencia LIKE '%' +  @Referencia + '%' OR  @Referencia ='*')
AND A.Fecha BETWEEN @FechaInicial AND @FechaFinal

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


CREATE  ALTER   PROCEDURE [dbo].[invGetProductoByID] @IDProducto BIgint	,@Descr AS NVARCHAR(250)
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
 

CREATE TABLE dbo.invBoletaInvFisico ( 
	IDBodega  INT NOT NULL,
	IDProducto  BIGINT NOT NULL,
	IDLote   INT NOT NULL,	 
	Cantidad  decimal(28,4) DEFAULT 0,
	Validada BIT DEFAULT 0,
	Usuario  nvarchar(50) NOT NULL,
	Fecha  date,
	RecordDate  DATETIME,
	CONSTRAINT [pkinvBoletaInvFisico] PRIMARY KEY CLUSTERED 
(
	IDBodega ASC,
	IDProducto ASC,
	IDLote ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




ALTER TABLE dbo.invBoletaInvFisico  WITH CHECK ADD  CONSTRAINT fkBoleta_Bodega FOREIGN KEY(IDBodega)
REFERENCES [dbo].invBodega (IDBodega)
GO

ALTER TABLE dbo.invBoletaInvFisico CHECK CONSTRAINT fkBoleta_Bodega
GO


ALTER TABLE dbo.invBoletaInvFisico  WITH CHECK ADD  CONSTRAINT fkBoleta_Producto FOREIGN KEY(IDProducto)
REFERENCES [dbo].invProducto (IDProducto)
GO

ALTER TABLE dbo.invBoletaInvFisico CHECK CONSTRAINT fkBoleta_Producto
GO


ALTER TABLE dbo.invBoletaInvFisico  WITH CHECK ADD  CONSTRAINT fkBoleta_Lote FOREIGN KEY(IDLote,IDProducto)
REFERENCES [dbo].invLote (IDLote,IDProducto)
GO

ALTER TABLE dbo.invBoletaInvFisico CHECK CONSTRAINT fkBoleta_Lote
GO
 

CREATE  PROCEDURE  dbo.invUpdateBoletaInvFisico(@Operacion AS NVARCHAR(1), @IDBodega INT, @IDProducto BIGINT, @IDLote AS INT,@Cantidad INT,@Validada BIT, @Usuario NVARCHAR(50),@Fecha AS DATE )
AS 
IF UPPER(@Operacion) ='I'
BEGIN
	IF Exists(SELECT *  FROM dbo.invBoletaInvFisico WHERE IDBodega=@IDBodega AND IDProducto=@IDProducto AND IDLote = @IDLote)
	BEGIN
		 RAISERROR ('La boleta  que desea ingresar, ya existe .', -- Message text.
               16, -- Severity.
               1 -- State.
               )
         RETURN 
	END
	
	INSERT INTO dbo.invBoletaInvFisico( IDBodega ,IDProducto ,IDLote , Cantidad ,Validada ,Usuario ,Fecha ,RecordDate)
	VALUES (@IDBodega,@IDProducto,@IDLote,@Cantidad,@Validada,@Usuario,@Fecha,GETDATE())
END
IF UPPER(@Operacion) ='U'
BEGIN
	UPDATE dbo.invBoletaInvFisico SET  Cantidad = @Cantidad, Validada = @Validada, Fecha = @Fecha WHERE IDBodega = @IDBodega AND  IDLote = @IDLote AND IDProducto=@IDProducto
END
IF UPPER(@Operacion)='D'
BEGIN
	DELETE FROM dbo.invBoletaInvFisico WHERE IDBodega = @IDBodega AND  IDLote = @IDLote AND IDProducto=@IDProducto
END

GO
 

CREATE   PROCEDURE dbo.invGetBoletaInvFisico @IDBodega AS INT, @IDProducto BIGINT, @IDLote INT,@Validada INT	,@Fecha AS DATE
AS
	SELECT A.IDBodega,B.Descr DescrBodega,A.IDProducto, P.Descr DescrProducto,A.IDLote, L.LoteProveedor,L.LoteInterno,
				L.FechaVencimiento,A.Cantidad,A.Fecha,A.Usuario,A.Validada
	 FROM dbo.invBoletaInvFisico A
	INNER JOIN dbo.invBodega B ON A.IDBodega = B.IDBodega
	INNER JOIN dbo.invProducto P ON A.IDProducto= P.IDProducto
	INNER JOIN dbo.invLote L ON P.IDProducto = L.IDProducto AND A.IDLote=L.IDLote
	WHERE (A.IDProducto=@IDProducto OR  @IDProducto=-1)
	          AND (A.IDBodega = @IDBodega OR @IDBodega=-1) 
	          AND (A.IDLote =@IDLote  OR @IDLote=-1) 
	          AND (A.Validada =@Validada OR @Validada=-1)
	          AND (A.Fecha =@Fecha OR @Fecha='19810821')


go


--// Imprime las Boletas
CREATE PROCEDURE dbo.invGetBoletas @IDBodega AS INT,@IDProducto AS INT,@Clasif1 AS INT,@Clasif2 AS INT,@Clasif3 AS INT,@Clasif4 AS INT,@Clasif5 AS INT, @Clasif6 AS INT,@ConsolidaByProducto AS BIT
AS
/*SET @IDBodega=-1
SET @IDProducto=-1
SET @Clasif1 =-1
SET @Clasif2 = -1
SET @Clasif3 =-1
SET @Clasif4=-1
SET @Clasif5=-1
SET @Clasif6=-1
SET @ConsolidaByProducto=1
*/
IF (@ConsolidaByProducto=1)
BEGIN
	SELECT B.IDBodega,BO.Descr DescrBodega,B.IDProducto,P.Descr DescrProducto,0 IDLote,'xx' LoteProveedor,'2018/01/01' FechaVencimiento,B.Cantidad,B.Fecha,B.Validada
	FROM dbo.invBoletaInvFisico B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	INNER JOIN dbo.invBodega BO ON B.IDBodega=BO.IDBodega
	INNER JOIN dbo.invLote L ON B.IDLote=L.IDLote AND B.IDProducto=L.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)
	GROUP BY  B.IDBodega,BO.Descr ,B.IDProducto,P.Descr ,B.Cantidad,B.Fecha,B.Validada
END
ELSE 
BEGIN
	SELECT B.IDBodega,BO.Descr DescrBodega,B.IDProducto,P.Descr DescrProducto,L.IDLote,L.LoteProveedor,L.FechaVencimiento,B.Cantidad,B.Fecha,B.Validada
	FROM dbo.invBoletaInvFisico B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	INNER JOIN dbo.invBodega BO ON B.IDBodega=BO.IDBodega
	INNER JOIN dbo.invLote L ON B.IDLote=L.IDLote AND B.IDProducto=L.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)
END

GO



--// Cuadre de Diferencias

CREATE PROCEDURE dbo.invGetBoletasVrsInventario @IDBodega AS INT,@IDProducto AS INT,@Clasif1 AS INT,@Clasif2 AS INT,@Clasif3 AS INT,@Clasif4 AS INT,@Clasif5 AS INT, @Clasif6 AS INT,@ConsolidaByProducto AS BIT
AS
/*
SET @IDBodega=-1
SET @IDProducto=-1
SET @Clasif1 =-1
SET @Clasif2 = -1
SET @Clasif3 =-1
SET @Clasif4=-1
SET @Clasif5=-1
SET @Clasif6=-1
SET @ConsolidaByProducto=0
*/
CREATE TABLE  #Boletas (IDBodega int,IDProducto INT,IDLote INT,Cantidad DECIMAL(28,4))

CREATE TABLE  #Inventario (IDBodega int,IDProducto INT,IDLote INT,Cantidad DECIMAL(28,4))


IF (@ConsolidaByProducto=1)
BEGIN
	--//Cargar Boletas
	INSERT INTO #Boletas( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,-1 IDLote,SUM(B.Cantidad )
	FROM dbo.invBoletaInvFisico B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)
	GROUP BY  B.IDBodega ,B.IDProducto 
	
	--//Cargar Inventario
	INSERT INTO #Inventario( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,-1 IDLote,SUM(B.Existencia)
	FROM dbo.invExistenciaBodega B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)
	GROUP BY  B.IDBodega ,B.IDProducto 
END
ELSE 
BEGIN
	INSERT INTO #Boletas( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,B.IDLote, B.Cantidad
	FROM dbo.invBoletaInvFisico B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)
				    
	INSERT INTO #Inventario( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,B.IDLote, B.Existencia
	FROM dbo.invExistenciaBodega B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1) AND 
					(B.IDProducto =@IDProducto OR @IDProducto=-1) AND 
					(P.Clasif1=@Clasif1 OR @Clasif1=-1) AND 
					(p.Clasif2=@Clasif2 OR @Clasif2=-1) AND
				    (p.Clasif3 = @Clasif3 OR @Clasif3=-1) AND 
				    (p.Clasif4=@Clasif4 OR @Clasif4=-1) AND 
				    (p.Clasif5=@Clasif5 OR @Clasif5=-1) AND 
				    (p.Clasif6=@Clasif6 OR @Clasif6=-1)				 
END

SELECT DISTINCT   IDBodega ,
        IDProducto ,
        IDLote  INTO #Catalogo FROM 
(
SELECT IDBodega,IDProducto,IDLote  FROM #Boletas
UNION 
SELECT IDBodega,IDProducto,IDLote  FROM #Inventario
) A


SELECT A.IDBodega,BO.Descr DescrBodega,A.IDProducto,P.Descr DescrProducto,A.IDLote,L.LoteProveedor,L.FechaVencimiento,ISNULL(B.Cantidad,0) Boleta,ISNULL(C.Cantidad,0) Inventario,ISNULL(B.Cantidad,0) - ISNULL(C.Cantidad,0)  Diferencia FROM #Catalogo A
LEFT  JOIN #Boletas B ON A.IDBodega = B.IDBodega AND a.IDLote=B.IDLote AND A.IDProducto = B.IDProducto
LEFT  JOIN #Inventario C ON A.IDBodega = C.IDBodega AND A.IDLote = C.IDLote AND A.IDProducto = C.IDProducto
LEFT  JOIN dbo.invBodega BO ON A.IDBodega=BO.IDBodega
LEFT JOIN dbo.invLote L ON A.IDLote = L.IDLote AND A.IDProducto=L.IDProducto
LEFT  JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
WHERE ISNULL(B.Cantidad,0)<> ISNULL(C.Cantidad,0)


DROP TABLE #Boletas
DROP TABLE #Inventario
DROP TABLE #Catalogo



GO


--//Generación de Paquetes

CREATE PROCEDURE dbo.invCreaPaqueteInvFisico(@IDBodega AS INT,@IDPaquete AS NVARCHAR(20),@IDTransaccion AS INT OUTPUT,@Fecha AS DATE,@ProductoNoInvSetCero AS BIT,@Usuario AS NVARCHAR(50))
AS 
/*SET @IDBodega =-1
SET @IDPaquete=11
SET @ProductoNoInvSetCero=0
SET @Usuario='jespinoza'
SET @Fecha = '20180101'*/

SET  NOCOUNT ON


CREATE TABLE  #Boletas (IDBodega int,IDProducto INT,IDLote INT,Cantidad DECIMAL(28,4))
CREATE TABLE  #Inventario (IDBodega int,IDProducto INT,IDLote INT,Cantidad DECIMAL(28,4))
CREATE TABLE #Catalogo(IDBodega INT,IDProducto INT,IDLote INT)


	INSERT INTO #Boletas( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,B.IDLote, B.Cantidad
	FROM dbo.invBoletaInvFisico B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto 
	--WHERE B.Validada=1
				    
	INSERT INTO #Inventario( IDBodega  ,IDProducto  ,IDLote  ,Cantidad )
	SELECT B.IDBodega,B.IDProducto,B.IDLote, B.Existencia
	FROM dbo.invExistenciaBodega B
	INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
	WHERE (B.IDBodega =@IDBodega OR @IDBodega=-1)
	
	
	IF (@ProductoNoInvSetCero =1)
	BEGIN	
		INSERT INTO #Catalogo
		        ( IDBodega, IDProducto, IDLote )
		SELECT DISTINCT   IDBodega ,
			IDProducto ,
			IDLote  FROM 
		(
			SELECT IDBodega,IDProducto,IDLote  FROM #Boletas
			UNION 
			SELECT IDBodega,IDProducto,IDLote  FROM #Inventario
		) A
	END
	ELSE 
	BEGIN
		INSERT INTO #Catalogo
		        ( IDBodega, IDProducto, IDLote )
		SELECT DISTINCT   IDBodega ,
			IDProducto ,
			IDLote  FROM 
		(
			SELECT IDBodega,IDProducto,IDLote  FROM #Boletas
		) A
	END


	SELECT ROW_NUMBER() OVER (ORDER BY A.IDBodega,A.IDProducto,A.IDLote) ID, A.IDBodega,BO.Descr DescrBodega,A.IDProducto,P.Descr DescrProducto,A.IDLote,L.LoteProveedor,L.FechaVencimiento,ISNULL(B.Cantidad,0) Boleta,ISNULL(C.Cantidad,0) Inventario,ISNULL(B.Cantidad,0) - ISNULL(C.Cantidad,0)  Diferencia INTO #Result
	 FROM #Catalogo A
	LEFT  JOIN #Boletas B ON A.IDBodega = B.IDBodega AND a.IDLote=B.IDLote AND A.IDProducto = B.IDProducto
	LEFT  JOIN #Inventario C ON A.IDBodega = C.IDBodega AND A.IDLote = C.IDLote AND A.IDProducto = C.IDProducto
	LEFT  JOIN dbo.invBodega BO ON A.IDBodega=BO.IDBodega
	LEFT JOIN dbo.invLote L ON A.IDLote = L.IDLote AND A.IDProducto=L.IDProducto
	LEFT  JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
	WHERE ISNULL(B.Cantidad,0)<> ISNULL(C.Cantidad,0)
	
	DECLARE @Count AS INT
	DECLARE @i AS INT

	DECLARE @Documento NVARCHAR(20)
	
	SET @Count = @@ROWCOUNT
	SET @i=1
	--//Validar si hay elementos para realizar el paquete
	IF (@Count>0)
		EXEC dbo.invUpdateDocumentoInv 'I',@IDTransaccion OUTPUT,'CI',@IDPaquete,@Fecha,@Usuario,'Aplicacion de Inventario Fiscal',@Documento OUTPUT,0,0,-1
	
	WHILE (@i<=@Count)
	BEGIN
		DECLARE @IDProducto AS INT,@IDLote AS INT,@IDBodegaDet AS INT,@Boleta AS DECIMAL(28,4),@Existencia AS DECIMAL(28,4) ,@Dif AS decimal(28,4),@CostoLocal AS DECIMAL(28,4),@CostoDolar AS DECIMAL(28,4)
		DECLARE @IDTipoTran AS INT
		DECLARE @Tran AS NVARCHAR(3)
		
		SELECT @IDProducto = A.IDProducto,@IDLote = IDLote,@IDBodegaDet =  IDBodega,@Boleta=Boleta,@Existencia = Inventario,@Dif = Diferencia,
					  @CostoLocal= CostoPromLocal,@CostoDolar= CostoPromDolar  
		FROM #Result A
		INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto WHERE ID=@i
		
		SELECT @Tran = Transaccion  FROM dbo.invPaquete WHERE IDPaquete=@IDPaquete
		
		DECLARE @TipoCambio AS DECIMAL(28,4)
		DECLARE @TipoC AS NVARCHAR(3)
		
		SELECT @TipoC =TipoCambio  FROM dbo.cntParametros
		
		SET @TipoCambio = ( SELECT dbo.globalGetLastTipoCambio(@Fecha,@TipoC))
		
		IF (@Dif<0)
			SET @IDTipoTran = 1
		ELSE 
			SET @IDTipoTran =2	
		
		SET @Dif = ABS(@Dif);
		EXEC  dbo.invUpdateDocumentoInvDetalle  'I',@IDTransaccion,@IDProducto,@IDLote, @IDTipoTran,@IDBodegaDet , -1,@Dif, 0, 0, @CostoDolar ,@CostoLocal , 
		    @Tran, @TipoCambio,0 
		SET @i = @i+1
	END

	
	DROP TABLE #Boletas
	DROP TABLE #Inventario
	DROP TABLE #Catalogo
	DROP TABLE #Result
 

GO

CREATE PROCEDURE dbo.invCreaPaqueteInvFactura (@Modulo AS NVARCHAR(4),@IDDocumento AS INT,@Usuario AS NVARCHAR(50),@IDTransaccion AS BIGINT OUTPUT)
AS 
/*SET @Modulo = 'FAC'
SET @IDDocumento= 2
SET @Usuario= 'jespinoza'
*/
DECLARE @IDConsecutivo  AS INT
DECLARE @DocumentoInv AS NVARCHAR(20)
DECLARE @FechaDocumento DATE
DECLARE @Referencia AS NVARCHAR(250)
DECLARE @Documento AS NVARCHAR(20) --//Numero del documento Fisico
DECLARE @Transaccion AS NVARCHAR(2)
DECLARE @IDTipoTran AS INT
DECLARE @Factor AS INT
DECLARE @IDPaquete AS INT 
DECLARE @TipoCambioCont AS NVARCHAR(4)
DECLARE @TipoCambio AS DECIMAL(28,4)	
DECLARE @Naturaleza AS NVARCHAR(1)


IF (@Modulo = 'FAC')
BEGIN
	--//Leer parametros de configuración
	SELECT TOP	1 @IDPaquete = IDPaquete, @TipoCambioCont= TipoCambioCont  FROM dbo.fafParametros
	
	IF (@IDPaquete IS NULL)
	BEGIN
		RAISERROR ( 'GENERACIÓN DEL DOCUMENTO: Revise los parametros de Factura, si el paquete de inventario se encuentra establecido', 16, 1) ;
		return		
	END
	
	SELECT @FechaDocumento = Fecha, @Referencia = 'Factura: ' + Factura , @Documento = Factura
	 FROM dbo.fafFACTURA WHERE IDFactura =@IDDocumento 
	 
	--//Cargar el Tipo de Cambio Contabilidad
	SELECT @TipoCambio = dbo.globalGetTipoCambio(@FechaDocumento,@TipoCambioCont) 
	  
	--//Crear la cabecera del Documento  
	EXEC  dbo.invUpdateDocumentoInv  @Operacion = N'I', -- nvarchar(1)
	    @IDTransaccion = @IDTransaccion OUTPUT, -- int
	    @ModuloOrigen = N'FA', -- nvarchar(4)
	    @IDPaquete =@IDPaquete, -- int
	    @Fecha = @FechaDocumento, -- datetime
	    @Usuario =@Usuario, -- nvarchar(20)
	    @Referencia = @Referencia, -- nvarchar(250)
	    @Documento = @Documento OUTPUT, -- nvarchar(250)
	    @Aplicado = 1, -- bit
	    @EsTraslado = 0, -- bit
	    @IDTraslado = -1 -- int
	
	--//Obtener las transacciones asociadas al Paquete.
	SELECT @IDTipoTran =IDTipoTran, @Factor = Factor,@Naturaleza = Naturaleza, @Transaccion=Transaccion  FROM dbo.globalTipoTran WHERE  Transaccion = (SELECT Transaccion  FROM dbo.invPaquete WHERE IDPaquete=@IDPaquete) 

	--//Insertar el detalle del documento
	INSERT INTO dbo.invTransaccionLinea( IDTransaccion ,IDProducto ,IDLote ,IDTipoTran ,IDBodega ,IDTraslado , Naturaleza ,Factor ,Cantidad ,CostoUntLocal ,CostoUntDolar ,PrecioUntLocal ,PrecioUntDolar ,Transaccion ,TipoCambio ,Aplicado)
	SELECT @IDTransaccion, A.IDProducto,B.IDLote,@IDTipoTran,A.IDBodega,-1 IDTranslado,@Naturaleza,@Factor ,B.Cantidad, P.CostoPromLocal,CostoPromDolar,A.PrecioLocal,A.PrecioDolar,@Transaccion, @TipoCambio, 0 Aplicado
	 FROM dbo.fafFacturaProd A
	INNER JOIN dbo.fafFacturaProdLote B ON A.IDFacturaProd = B.IDFacturaProd
	INNER JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
	WHERE A.IDFactura=@IDDocumento

END  

GO

CREATE  FUNCTION dbo.invfCalculaCostoPromProd  (@IDProducto AS BIGINT,
																							 @Cantidad AS DECIMAL(28,4),
																							 @CostoUnt AS DECIMAL(28,4),
																							 @Moneda AS NVARCHAR(1)  )
RETURNS DECIMAL(28,4)																							 
AS
BEGIN
		-- Moneda puede ser L o D
		--SET @IDProducto =26003 
		--SET @Cantidad=20
		--SET @CostoUnt = 400

		DECLARE @CostoPromLoc AS DECIMAL(28,4),@CostoPromDol AS DECIMAL(28,4),@ExistenciaActual AS DECIMAL(28,4),@NewCostoProm AS DECIMAL(28,4)

		--//Obtener el costo del Producto Actual
		SELECT @CostoPromLoc = ISNULL(CostoPromLocal,0) , @CostoPromDol = ISNULL(CostoPromDolar,0)
		FROM dbo.invProducto WHERE IDProducto=@IDProducto

		--//Inventario actual
		SELECT @ExistenciaActual = ISNULL(SUM(Existencia),0)  FROM dbo.invExistenciaBodega WHERE IDProducto =@IDProducto

		SET @NewCostoProm = ((@ExistenciaActual * CASE WHEN @Moneda = 'L' THEN @CostoPromLoc ELSE @CostoPromDol END) + (@Cantidad * @CostoUnt)) / (@ExistenciaActual + @Cantidad)
		RETURN @NewCostoProm
END

GO

CREATE PROCEDURE dbo.invAplicaTransaccion ( @IDTransaccion AS  BIGINT)
AS 

--// Insertar todos los productos que no existen en existencia bodega // --
INSERT INTO dbo.invExistenciaBodega( IDBodega ,IDProducto ,IDLote ,Existencia ,Reservada ,Transito)
SELECT A.IDBodega,A.IDProducto,A.IDLote,0,0,0 FROM dbo.invTransaccionLinea A
LEFT JOIN dbo.invExistenciaBodega B ON	A.IDBodega = B.IDBodega AND A.IDLote = B.IDLote AND A.IDProducto = B.IDProducto
WHERE IDTransaccion =@IDTransaccion  AND B.IDProducto IS NULL AND B.IDBodega IS NULL AND B.IDLote IS NULL


--Validar Datos
IF  EXISTS(SELECT  *  FROM dbo.invTransaccionLinea A
INNER JOIN dbo.invExistenciaBodega B ON	A.IDBodega = B.IDBodega AND A.IDLote = B.IDLote AND A.IDProducto = B.IDProducto
WHERE IDTransaccion =@IDTransaccion AND B.Existencia + ( A.Cantidad * A.Factor)<0)
BEGIN
		RAISERROR ( 'No hay suficientes existencias para aplicar el documento', 16, 1) ;
		return		
END


--Actualiza Costos Promedio de los producto  (solo a las transacciones de ajuste y compras)
UPDATE P SET P.CostoPromLocal =  dbo.invfCalculaCostoPromProd(C.IDProducto,Cantidad,CostoUntLocal,'L') ,
						   P.CostoPromDolar = dbo.invfCalculaCostoPromProd(C.IDProducto,Cantidad,CostoUntDolar, 'D') 
FROM 
(SELECT IDProducto, SUM(cantidad * CostoUntLocal)/SUM(Cantidad) CostoUntLocal,SUM(cantidad * CostoUntDolar)/SUM(Cantidad) CostoUntDolar, SUM(Cantidad) Cantidad   FROM dbo.invTransaccionLinea 
WHERE IDTransaccion = @IDTransaccion AND IDTipoTran IN (6,7)
GROUP BY IDProducto) C
INNER JOIN dbo.invProducto P ON C.IDProducto = P.IDProducto


--Actualizar las existencias
UPDATE B SET B.Existencia = B.Existencia + (A.Cantidad * A.Factor) FROM dbo.invTransaccionLinea A
INNER JOIN dbo.invExistenciaBodega B ON	A.IDBodega = B.IDBodega AND A.IDLote = B.IDLote AND A.IDProducto = B.IDProducto
WHERE IDTransaccion =@IDTransaccion 

GO



CREATE  PROCEDURE dbo.fafGeneraAsientoContableFactura @Modulo AS NVARCHAR(4), @IDDocumento AS INT,@Usuario AS NVARCHAR(50),@Asiento AS NVARCHAR(20) OUTPUT 
AS
--BEGIN TRAN
/*
SET @Modulo = 'FAC'
SET @IDDocumento= 2
SET @Usuario= 'jespinoza'
*/

DECLARE @Documento AS NVARCHAR(20)
DECLARE @FechaDocumento AS NVARCHAR(20)
DECLARE @TipoCambio AS DECIMAL(28,4)
DECLARE @TipoFactura AS INT
DECLARE @CodCliente AS INT

--//Seleccionar el documento y Fechas
SELECT @Documento = Factura,@FechaDocumento = Fecha,@TipoCambio = TipoCambio,@TipoFactura = IDTipo,@CodCliente = IDCliente  
FROM dbo.fafFACTURA WHERE IDFactura=@IDDocumento

DECLARE @Rows AS INT
DECLARE @Fecha AS DATE

SET @Fecha =  DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@FechaDocumento)+1,0))
DECLARE @IDEjercicio AS INT,@Periodo NVARCHAR(10), @Cerrado AS BIT,@Activo AS BIT

SELECT  @IDEjercicio =IDEjercicio ,
        @Periodo = Periodo ,
        @Cerrado =Cerrado,
        @Activo = Activo
  FROM dbo.cntPeriodoContable WHERE FechaFinal=@Fecha

IF (@Cerrado =1 OR @Activo=0) 
BEGIN
	RAISERROR ( 'GENERACIÓN DEL ASIENTO CONTABLE: La fecha del documento que desea generar esta fuera del periodo de trabajo', 16, 1) ;
	return		
END

 EXEC [dbo].[globalGetNextConsecutivo] 'FA', @Asiento OUTPUT
	
INSERT INTO dbo.cntAsiento( IDEjercicio ,Periodo ,Asiento ,Tipo ,Fecha ,FechaHora ,Createdby ,CreateDate ,
						Mayorizadoby ,MayorizadoDate ,Anuladoby ,AnuladoDate ,Concepto ,Mayorizado ,Anulado ,TipoCambio ,ModuloFuente ,CuadreTemporal)
VALUES (	@IDEjercicio,@Periodo	,@Asiento,'FA',@FechaDocumento,GETDATE(),@Usuario,GETDATE(),NULL,NULL,NULL,NULL,'Factura',0,0,@TipoCambio,'FA',0)		
						
SELECT A.IDProducto,A.IDBodega,L.IDLote,L.Cantidad,A.PrecioDolar,A.PrecioLocal,P.CostoPromDolar,P.CostoPromLocal,SubTotalLocal,SubTotalDolar,DescuentoLocal,DescuentoDolar,DescuentoEspecialLocal,DescuentoEspecialDolar,ImpuestoLocal,ImpuestoDolar,
			C.CtaCostoVenta,C.CtrCostoVenta,    C.CtaCostoDesc,C.CtrCostoDesc,   C.CtaDescBonificacion,C.CtrDescBonificacion,   C.CtaDescVenta, C.CtrDescVenta    ,
			C.CtaInventario,C.CtrInventario     ,C.CtaVenta,C.CtrVenta INTO #tmpFactura  FROM  dbo.fafFacturaProd A
INNER JOIN dbo.fafFacturaProdLote L ON A.IDFacturaProd = L.IDFacturaProd
INNER JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
LEFT  JOIN dbo.invCuentaContable C ON P.IDCuentaContable=C.IDCuenta
WHERE IDFactura =@IDDocumento


SET @Rows = @@ROWCOUNT

DECLARE @IDProducto AS INT,@IDBodega AS INT,@IDLote AS INT,@Cantidad AS DECIMAL(28,4),@PrecioLocal AS DECIMAL(28,4),@PrecioDolar AS DECIMAL(28,4),
@CostoPromDolar AS DECIMAL(28,4),@CostoPromLocal AS DECIMAL(28,4),
@CtaContado AS BIGINT,@CtrContado AS INT,
@CtaCostoVenta AS BIGINT, @CtrCostoVenta AS INT,
@CtaCostoDesc AS BIGINT, @CtrCostoDesc AS INT,
@CtaDescBonificacion AS BIGINT,@CtrDescBonificacion AS INT,
@CtaDescVenta AS BIGINT,@CtrDescVenta AS INT,
@CtaInventario AS BIGINT,@CtrInventario AS INT,
@CtaVenta AS BIGINT, @CtrVenta AS INT,@CtrIVA AS INT,@CtaIVA AS INT

ALTER TABLE #tmpFactura ADD	 ID INT IDENTITY(1,1)

DECLARE @i AS INT
DECLARE @Linea AS INT
SET @i=1
SET @Linea = 0

WHILE (@Rows>=@i)
BEGIN
	SELECT @IDProducto = IDProducto, @IDBodega = IDBodega, @IDLote = IDLote,@Cantidad = Cantidad, @PrecioLocal = PrecioLocal, @PrecioDolar = PrecioDolar,
	@CostoPromDolar = CostoPromDolar,@CostoPromLocal = CostoPromLocal,@CtaCostoVenta =CtaCostoVenta, @CtrCostoVenta=CtrCostoVenta,@CtaCostoDesc = CtaCostoDesc,
	@CtaDescBonificacion =CtaDescBonificacion, @CtrDescBonificacion = CtaDescBonificacion, @CtaDescVenta = CtaDescVenta, @CtrDescVenta = CtrDescVenta,
	@CtaInventario = CtaInventario,@CtrInventario = CtrInventario,@CtaVenta = CtaVenta, @CtrVenta = CtrVenta
	  FROM #tmpFactura WHERE ID =@Rows
	  
	  
	 SELECT @CtrIVa = CtrImpuesto,@CtaIVA=CtaImpuesto  FROM dbo.fafParametros
	 --//Costo de Venta
	SET @Linea = @Linea + 1 
	INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
	VALUES (@Asiento,@Linea,@CtrCostoVenta,@CtaCostoVenta,'Costo de Venta: Venta de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, @CostoPromLocal * @Cantidad,0,@Documento,GETDATE())
	
	 --//Inventario
	SET @Linea = @Linea + 1 
	INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
	VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Venta de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())

	
	SET @i = @i +1
END

DECLARE @IVALocal AS DECIMAL(28,4),@DescLocal AS DECIMAL(28,4),@DescEspecial AS DECIMAL(28,4), @VentaLocal AS DECIMAL(28,4)

SELECT  @IVALocal = SUM(ImpuestoLocal) ,@DescLocal = SUM(DescuentoLocal) ,@DescEspecial = SUM(DescuentoEspecialLocal), @VentaLocal = SUM(SubTotalLocal)  
FROM #tmpFactura

	SELECT @IDProducto = IDProducto, @IDBodega = IDBodega, @IDLote = IDLote,@Cantidad = Cantidad, @PrecioLocal = PrecioLocal, @PrecioDolar = PrecioDolar,
	@CostoPromDolar = CostoPromDolar,@CostoPromLocal = CostoPromLocal,@CtaCostoVenta =CtaCostoVenta, @CtrCostoVenta=CtrCostoVenta,@CtaCostoDesc = CtaCostoDesc,
	@CtaDescBonificacion =CtaDescBonificacion, @CtrDescBonificacion = CtaDescBonificacion, @CtaDescVenta = CtaDescVenta, @CtrDescVenta = CtrDescVenta,
	@CtaInventario = CtaInventario,@CtrInventario = CtrInventario,@CtaVenta = CtaVenta, @CtrVenta = CtrVenta
	  FROM #tmpFactura WHERE ID =1
	  
/*
  §•• NOTA••§
  Pendiente la contabilizacion de Descuentos y Bonificaciones.
*/

 --//IVA
SET @Linea = @Linea + 1 
INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
VALUES (@Asiento,@Linea,@CtrIVA,@CtaIVA,'IVA: Venta de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@IVALocal,@Documento,GETDATE())

--//Venta
SET @Linea = @Linea + 1 
DECLARE @FondosPorDep AS DECIMAL(28,4) 
--SET @FondosPorDep =  @VentaLocal + @IVALocal - @DescLocal - @DescEspecial
INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
VALUES (@Asiento,@Linea,@CtrVenta,@CtaVenta,'Venta: Venta de ' + CAST(@IDProducto AS NVARCHAR(20))+ 'CI-' + @Documento, @VentaLocal,0,@Documento,GETDATE())

IF (@TipoFactura= 1) 
BEGIN
		 --//Fondos X Dep
		SET @Linea = @Linea + 1 
		SET @FondosPorDep =  @VentaLocal + @IVALocal - @DescLocal - @DescEspecial
		INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
		VALUES (@Asiento,@Linea,@CtrContado,@CtaContado,'Venta: Venta de ' + CAST(@IDProducto AS NVARCHAR(20))+ 'CI-' + @Documento, @FondosPorDep,0,@Documento,GETDATE())
END
ELSE
BEGIN
		DECLARE @CtrCxC AS INT,@CtaCxC AS BIGINT
		
		 SELECT @CtrCxC = CtrCxc, @CtaCxC = CtaCxC  
		 FROM dbo.fafCategoriaCliente 
		 WHERE IDCategoria =  (SELECT IDCategoria FROM dbo.ccfClientes WHERE IDCliente = @CodCliente)
		 
		 --//CXC
		SET @Linea = @Linea + 1 
		SET @FondosPorDep =  @VentaLocal + @IVALocal - @DescLocal - @DescEspecial
		INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
		VALUES (@Asiento,@Linea,@CtrCxC,@CtaCxC,'Venta Credito: Venta de ' + CAST(@IDProducto AS NVARCHAR(20))+ 'CI-' + @Documento, @FondosPorDep,0,@Documento,GETDATE())
	
END

DROP TABLE #tmpFactura

go

CREATE   PROCEDURE  dbo.invGeneraAsientoTransaccion  @IDDocumento AS INT, @Usuario AS NVARCHAR(50),@Asiento NVARCHAR(20) OUTPUT

AS 

--//Esto genera la mayoria de los movimientos de inventario excepto factuira
--BEGIN TRAN

--SET @IDDocumento= 2
--SET @Usuario= 'jespinoza'
DECLARE @Documento AS NVARCHAR(20)
DECLARE @FechaDocumento AS NVARCHAR(20)
DECLARE @TipoCambio AS DECIMAL(28,4)
DECLARE @IDPaquete AS INT


SELECT @Documento = Documento ,@FechaDocumento = Fecha, @IDPaquete = IDPaquete  FROM DBO.invTransaccion WHERE IDTransaccion = @IDDocumento
SELECT @TipoCambio =  MAX(TipoCambio)  FROM dbo.invTransaccionLinea WHERE IDTransaccion = @IDDocumento

DECLARE @Rows AS INT
DECLARE @Fecha AS DATE

SET @Fecha =  DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@FechaDocumento)+1,0))
DECLARE @IDEjercicio AS INT,@Periodo NVARCHAR(10), @Cerrado AS BIT,@Activo AS BIT

SELECT  @IDEjercicio =IDEjercicio ,
        @Periodo = Periodo ,
        @Cerrado =Cerrado,
        @Activo = Activo
  FROM dbo.cntPeriodoContable WHERE FechaFinal=@Fecha

IF (@Cerrado =1 OR @Activo=0) 
BEGIN
	RAISERROR ( 'GENERACIÓN DEL ASIENTO CONTABLE: La fecha del documento que desea generar esta fuera del periodo de trabajo', 16, 1) ;
	return		
END

--//Generar la cabecera del Asiento

 EXEC [dbo].globalGetNextConsecutivo 'IN', @Asiento OUTPUT

DECLARE @DescrPaquete NVARCHAR(256)
SELECT @DescrPaquete = Descr FROM dbo.invPaquete WHERE IDPaquete = @IDPaquete
	
INSERT INTO dbo.cntAsiento( IDEjercicio ,Periodo ,Asiento ,Tipo ,Fecha ,FechaHora ,Createdby ,CreateDate ,
						Mayorizadoby ,MayorizadoDate ,Anuladoby ,AnuladoDate ,Concepto ,Mayorizado ,Anulado ,TipoCambio ,ModuloFuente ,CuadreTemporal)
VALUES (	@IDEjercicio,@Periodo	,@Asiento,'IN',@FechaDocumento,GETDATE(),@Usuario,GETDATE(),NULL,NULL,NULL,NULL,@DescrPaquete,0,0,@TipoCambio,'CI',0)		
					
SELECT A.IDProducto,A.IDBodega,A.IDLote,A.Cantidad,P.CostoPromDolar,P.CostoPromLocal,A.CostoUntLocal,A.PrecioUntLocal,
			C.CtaInventario,C.CtrInventario , C.CtaSobranteInvFisico,C.CtrSobranteInvFisico,
			C.CtaFaltanteInvFisico,C.CtrFaltanteInvFisico,C.CtaVariacionCosto,C.CtrVariacionCosto,C.CtaVencimiento,C.CtrVencimiento,
			C.CtaCompra,C.CtrCompra, C.CtaConsumo,C.CtrConsumo,
			A.IDTipoTran INTO #tmpDocumento 
			FROM dbo.invTransaccionLinea A
			INNER JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
			LEFT  JOIN dbo.invCuentaContable C ON P.IDCuentaContable=C.IDCuenta
			WHERE IDTransaccion=@IDDocumento

SET @Rows = @@ROWCOUNT

DECLARE @IDProducto AS INT,@IDBodega AS INT,@IDLote AS INT,@Cantidad AS DECIMAL(28,4),
@CostoPromDolar AS DECIMAL(28,4),@CostoPromLocal AS DECIMAL(28,4),@CostoUntLocal AS decimal(28,4),
@PrecioUntLocal AS decimal(28,4),@CtaInventario AS BIGINT,@CtrInventario AS INT,
@CtaSobranteInvFisico AS BIGINT, @CtrSobranteInvFisico AS INT,
@CtaFaltanteInvFisico AS BIGINT, @CtrFaltanteInvFisico AS INT,
@CtaVariacionCosto AS BIGINT, @CtrVariacionCosto AS INT,
@CtaVencimiento AS BIGINT, @CtrVencimiento AS INT,
@CtaCompra AS BIGINT,@CtrCompra AS INT,
@CtaConsumo AS BIGINT ,@CtrConsumo AS INT,
@IDTipoTran AS INT

ALTER TABLE #tmpDocumento ADD	 ID INT IDENTITY(1,1)

DECLARE @i AS INT
DECLARE @Linea AS INT
SET @i=1
SET @Linea = 0

WHILE (@Rows>=@i)
BEGIN
	SELECT @IDProducto = IDProducto, @IDBodega = IDBodega, @IDLote = IDLote,@Cantidad = Cantidad, 
	@CostoPromDolar = CostoPromDolar,@CostoPromLocal = CostoPromLocal,@CostoUntLocal = CostoUntLocal,
	@PrecioUntLocal = PrecioUntLocal,
	@CtaInventario =CtaInventario, 	@CtrInventario=CtrInventario,
	@CtaSobranteInvFisico = CtaSobranteInvFisico,@CtrSobranteInvFisico = CtrSobranteInvFisico,
	@CtaFaltanteInvFisico = CtaFaltanteInvFisico, @CtrFaltanteInvFisico =CtrFaltanteInvFisico,
	@CtaVariacionCosto = CtaVariacionCosto, @CtrVariacionCosto = CtrVariacionCosto,
	@CtaVencimiento = CtaVencimiento, @CtrVencimiento = CtrVencimiento,
	@CtaCompra = CtaCompra,@CtrCompra = CtrCompra,
	@CtaConsumo =  CtaConsumo,@CtrConsumo = CtrConsumo,
	@IDTipoTran = IDTipoTran
	  FROM #tmpDocumento WHERE ID =@i

	 -- Validacion de Datos
	DECLARE @ValidacionDatos  AS BIGINT
	SET @ValidacionDatos = @CtaInventario  + @CtrInventario + 
											@CtaSobranteInvFisico + @CtrSobranteInvFisico + 
											@CtaFaltanteInvFisico + @CtrFaltanteInvFisico +
											@CtaVariacionCosto + @CtrVariacionCosto +
											@CtaVencimiento + @CtrVencimiento +
											@CtaCompra + @CtrCompra +
											@CtaConsumo + @CtrConsumo 
											
	 IF (@ValidacionDatos IS NULL ) 
	 BEGIN
		RAISERROR ( 'El Asiento contable no se puede generar. Por favor verifique que la familia contable del producto, tenga la cuentas contables asociadas.', 16, 1) ;
		RETURN
	END

	  --//Salida de inventario Fisico
	  IF (@IDTipoTran =1)
	  BEGIN
			 --//Compras Locales
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrCompra,@CtaCompra,'Salida Inv Fisico' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, @CostoPromLocal * @Cantidad,0,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Venta de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())
	 END 
	
	  --//Ingreso de inventario Fisico
	  IF (@IDTipoTran =2)
	  BEGIN
			 --//Compras Locales
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrCompra,@CtaCompra,'Salida Inv Fisico' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Venta de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, @CostoPromLocal * @Cantidad,0,@Documento,GETDATE())
	 END  
	
	 --//Consumo de Inventario
	  IF (@IDTipoTran =5)
	  BEGIN
			 --//Consumos
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrConsumo,@CtaConsumo,'Consumo de Inventario' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Consumo ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, @CostoPromLocal * @Cantidad,0,@Documento,GETDATE())
	 END   
	
	--//Compra de Inventario
	  IF (@IDTipoTran =6)
	  BEGIN
			 --//Compras Locales
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrCompra,@CtaCompra,'Consumo de Inventario' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,@CostoUntLocal * @Cantidad,0,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Consumo ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,0,@CostoUntLocal * @Cantidad,@Documento,GETDATE())
	 END    
	
		--//Ingreso por ajuste
	  IF (@IDTipoTran =7)
	  BEGIN
			 --//Compras Locales
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrCompra,@CtaCompra,'Ingreso por Ajuste de Inventario' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,@CostoUntLocal * @Cantidad,0,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Ingreso ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,0,@CostoUntLocal * @Cantidad,@Documento,GETDATE())
	 END     
	
		--//Salida por ajuste
	  IF (@IDTipoTran =8)
	  BEGIN
			 --//Compras Locales
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrCompra,@CtaCompra,'Salida por Ajuste de Inventario' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())
			
			 --//Inventario
			SET @Linea = @Linea + 1 
			INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
			VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: Salida ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento,@CostoPromLocal * @Cantidad,0,@Documento,GETDATE())
	 END      
	
	SET @i = @i +1
END

UPDATE dbo.invTransaccion SET  Asiento = @Asiento WHERE IDTransaccion=@IDDocumento

DROP TABLE #tmpDocumento


--SELECT *  FROM dbo.cntAsientoDetalle WHERE Asiento=@Asiento

--ROLLBACK
GO 



Create Table dbo.invSaldos ( 
IDSaldo bigint identity(1,1) not null,
IDProducto bigint not null,
IDLote int not null,
IDbodega int not null,
Fecha datetime not null,
SaldoMesAnt decimal(28,4) default 0,
Entradas decimal(28,4) default 0,
Salidas decimal(28,4) default 0,
Saldo decimal(28,4) default 0,
CreateDate datetime
)
go

alter table dbo.invSaldos add constraint pkinvSaldos primary key (IDSaldo)
go

alter table dbo.invSaldos add constraint fkinvSaldos foreign key (IDProducto) references dbo.invProducto (IDProducto)
go
ALTER TABLE dbo.invSaldos ADD  DEFAULT (getdate()) FOR CreateDate
GO
alter table dbo.invSaldos add constraint fkinvSaldoLote foreign key (IDLote,IDProducto) references dbo.invLote (IDLote,IDProducto)
go

alter table dbo.invSaldos add constraint fkinvSaldoBodega foreign key (IDBodega) references dbo.invBodega (IDBodega)
go

alter table dbo.invSaldos add constraint ukinvSaldos UNIQUE (IDProducto, IDLote, IDBodega, Fecha) 
go

Create nonclustered index indinvSaldos on dbo.invSaldos (Fecha)
go


CREATE FUNCTION dbo.[invGetSaldo] (@IDProducto bigint, @IDLote int, @IDBodega int, @Fecha datetime)
RETURNS decimal(28,4) AS  
BEGIN 
set @Fecha = CAST(SUBSTRING(CAST(@Fecha AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)
Declare @Saldo decimal(28,4)
 
Set @Saldo = (SELECT top 1 Saldo
				FROM dbo.invSaldos  (NOLOCK)
				where IDProducto  = @IDProducto and IDBodega = @IDBodega and IDLote = @IDLote and Fecha<= @Fecha
				ORDER BY IDProducto, IDLote, IDBodega,  FECHA desc
			)

if @Saldo is null
	set @Saldo = 0
return @Saldo
end
go

create PROCEDURE dbo.ccfUpdateinvSaldos @Operation nvarchar(1),
-- 'I' insertar 'D' Delete 
@IDSaldo int OUTPUT, @IDProducto bigint, @IDLote int, @IDBodega int, 
@Fecha datetime, @SaldoMesAnt decimal(28,4),@Entradas decimal(28,4), @Salidas decimal(28,4), @Saldo decimal(28,4)
as
set nocount on
IF @Operation = 'I'
begin
	insert dbo.invSaldos  ( IDProducto, IDLote, IDbodega, SaldoMesAnt, Entradas, Salidas, Saldo, Fecha)
	values ( @IDProducto, @IDLote, @IDbodega, @SaldoMesAnt, @Entradas, @Salidas, @Saldo, @Fecha)
	Set @IDSaldo = (SELECT SCOPE_IDENTITY())
	
end
IF @Operation = 'D'
begin
	Delete From dbo.invSaldos Where IDSaldo = @IDSaldo
end
return isnull(@IDSaldo,0)
go


CREATE PROCEDURE dbo.invGeneraSaldoInventario(@Fecha DATE)
AS

--SET @Fecha='20181126'

--//Obtener los movimiento desde la fecha anterior al dia del corte
DECLARE @FechaInicial AS DATETIME
DECLARE @FechaFinal AS DATETIME
set @FechaInicial = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@Fecha)-1),@Fecha),101) 
set @FechaFinal = CAST(SUBSTRING(CAST(@Fecha AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT IDProducto,IDLote,IDBodega,C.Naturaleza, SUM(a.Cantidad * C.Factor )  Cantidad INTO #Movimientos  FROM dbo.invTransaccionLinea A
INNER JOIN dbo.invTransaccion B ON A.IDTransaccion = B.IDTransaccion
INNER JOIN dbo.globalTipoTran C ON A.IDTipoTran = C.IDTipoTran
WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY IDProducto,IDLote,IDBodega,C.Naturaleza

--//Obtener el cierre del mes anterior
DECLARE @FechaSaldoAnterior  AS DATETIME

SET @Fecha=  CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@Fecha))),DATEADD(mm,1,@Fecha)),101)
SET @FechaSaldoAnterior = DATEADD(MONTH,-1, @Fecha)
SET @FechaSaldoAnterior  = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@FechaSaldoAnterior))),DATEADD(mm,1,@FechaSaldoAnterior)),101)

--//Seleccionar todos los productos (fuente principal)
SELECT P.IDProducto,P.IDLote,P.IDBodega,@Fecha Fecha,P.SaldoMesAnt,0 Entradas,0 Salidas,0 Saldo,GETDATE() CreateDate INTO #tmpSaldos
FROM 
(SELECT  IDProducto ,IDLote ,IDBodega,0 SaldoMesAnt  FROM #Movimientos
UNION 
SELECT IDProducto,IDLote,IDBodega,SaldoMesAnt  FROM  dbo.invSaldos
WHERE Fecha = @FechaSaldoAnterior) P

--Actualizamos las entradas
UPDATE A SET A.Entradas =  Cantidad FROM #tmpSaldos A
INNER JOIN #Movimientos B ON A.IDProducto=B.IDProducto AND A.IDLote=B.IDLote AND A.IDBodega=B.IDBodega
WHERE Naturaleza='E' 

--Actualizamos las Salidas
UPDATE A SET A.Salidas =  Cantidad FROM #tmpSaldos A
INNER JOIN #Movimientos B ON A.IDProducto=B.IDProducto AND A.IDLote=B.IDLote AND A.IDBodega=B.IDBodega
WHERE Naturaleza='S' 

-- Actualizamos Saldos
UPDATE #tmpSaldos SET Saldo = SaldoMesAnt + Entradas + Salidas
WHERE Entradas + Salidas >0

INSERT INTO dbo.invSaldos( IDProducto ,IDLote ,IDbodega ,Fecha ,SaldoMesAnt ,Entradas ,Salidas ,Saldo ,CreateDate)
SELECT  IDProducto ,IDLote ,IDBodega ,Fecha ,SaldoMesAnt ,Entradas ,Salidas ,Saldo ,CreateDate  FROM #tmpSaldos

DROP TABLE  #Movimientos
DROP TABLE  #tmpSaldos


GO




CREATE PROCEDURE dbo.invGetCorteInventario ( @Fecha DATE,@Bodega AS NVARCHAR(4000), @Producto AS NVARCHAR(250),
							@Lote AS  NVARCHAR(4000),@Clasif1 AS NVARCHAR(4000),@Clasif2 NVARCHAR(4000), @Clasif3 NVARCHAR(4000),
							@Clasif4 NVARCHAR(4000), @Clasif5 NVARCHAR(4000), @Clasif6 NVARCHAR(4000))
AS

--SET @Fecha='20181126'
--SET @Bodega='*'
--SET @Producto='26003,26004'
--SET @Lote ='*'
--SET @Clasif1='*'
--SET @Clasif2='*'
--SET @Clasif3='*'
--SET @Clasif4='*'
--SET @Clasif5='*'
--SET @Clasif6='*'

DECLARE @Separador NVARCHAR(1)
SET @Separador =','

--//Obtener los movimiento desde la fecha anterior al dia del corte
DECLARE @FechaInicial AS DATETIME
DECLARE @FechaFinal AS DATETIME
set @FechaInicial = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@Fecha)-1),@Fecha),101) 
set @FechaFinal = CAST(SUBSTRING(CAST(@Fecha AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT A.IDProducto,IDLote,IDBodega,C.Naturaleza, SUM(a.Cantidad * C.Factor )  Cantidad INTO #Movimientos  FROM dbo.invTransaccionLinea A
INNER JOIN dbo.invTransaccion B ON A.IDTransaccion = B.IDTransaccion
INNER JOIN dbo.globalTipoTran C ON A.IDTipoTran = C.IDTipoTran
INNER JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal
AND  (A.IDBodega  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Bodega,@Separador) )or @Bodega ='*') 
AND (A.IDProducto IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) OR @Producto='*')
AND (A.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') 
AND (P.Clasif1   IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif1,@Separador)) or @Clasif1='*') 
AND (P.Clasif2  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif2,@Separador)) or @Clasif2='*') 
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) or @Clasif3='*')
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif3,@Separador)) or @Clasif3='*') 
AND (P.Clasif4  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif4,@Separador) ) or @Clasif4='*')
AND (P.Clasif5  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif5,@Separador)) or @Clasif5='*')  
AND (P.Clasif6 IN (SELECT Value FROM [dbo].[ConvertListToTable](@clasif6,@Separador)) or @Clasif6='*')
GROUP BY A.IDProducto,IDLote,IDBodega,C.Naturaleza

--//Obtener el cierre del mes anterior
DECLARE @FechaSaldoAnterior  AS DATETIME

SET @Fecha=  CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@Fecha))),DATEADD(mm,1,@Fecha)),101)
SET @FechaSaldoAnterior = DATEADD(MONTH,-1, @Fecha)
SET @FechaSaldoAnterior  = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@FechaSaldoAnterior))),DATEADD(mm,1,@FechaSaldoAnterior)),101)

--//Seleccionar todos los productos (fuente principal)
SELECT P.IDProducto,P.IDLote,P.IDBodega,@Fecha Fecha,P.SaldoMesAnt,0 Entradas,0 Salidas,0 Saldo,GETDATE() CreateDate INTO #tmpSaldos
FROM 
(SELECT  IDProducto ,IDLote ,IDBodega,0 SaldoMesAnt  FROM #Movimientos
UNION 
SELECT S.IDProducto,S.IDLote,S.IDBodega,S.SaldoMesAnt  FROM  dbo.invSaldos S
INNER JOIN dbo.invProducto P ON S.IDProducto = P.IDProducto
WHERE Fecha = @FechaSaldoAnterior  
AND  (S.IDBodega  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Bodega,@Separador) )or @Bodega ='*') 
AND (S.IDProducto IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) OR @Producto='*')
AND (S.IDLote  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Lote,@Separador)) OR @Lote='*') 
AND (P.Clasif1   IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif1,@Separador)) or @Clasif1='*') 
AND (P.Clasif2  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif2,@Separador)) or @Clasif2='*') 
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Producto,@Separador)) or @Clasif3='*')
AND ( P.Clasif3 IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif3,@Separador)) or @Clasif3='*') 
AND (P.Clasif4  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif4,@Separador) ) or @Clasif4='*')
AND (P.Clasif5  IN (SELECT Value FROM [dbo].[ConvertListToTable](@Clasif5,@Separador)) or @Clasif5='*')  
AND (P.Clasif6 IN (SELECT Value FROM [dbo].[ConvertListToTable](@clasif6,@Separador)) or @Clasif6='*')
) P

--Actualizamos las entradas
UPDATE A SET A.Entradas =  Cantidad FROM #tmpSaldos A
INNER JOIN #Movimientos B ON A.IDProducto=B.IDProducto AND A.IDLote=B.IDLote AND A.IDBodega=B.IDBodega
WHERE Naturaleza='E' 

--Actualizamos las Salidas
UPDATE A SET A.Salidas =  Cantidad FROM #tmpSaldos A
INNER JOIN #Movimientos B ON A.IDProducto=B.IDProducto AND A.IDLote=B.IDLote AND A.IDBodega=B.IDBodega
WHERE Naturaleza='S' 

-- Actualizamos Saldos
UPDATE #tmpSaldos SET Saldo = SaldoMesAnt + Entradas + Salidas
WHERE Entradas + Salidas >0

SELECT  IDProducto ,IDLote ,IDBodega ,Fecha ,SaldoMesAnt ,Entradas ,Salidas ,Saldo ,CreateDate  FROM #tmpSaldos

DROP TABLE  #Movimientos
DROP TABLE  #tmpSaldos

GO


