
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

CREATE TABLE dbo.cppCondicionPago(
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
	IDProducto BIGINT NOT NULL,
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
REFERENCES [dbo].[cppProveedor] ([IDProveedor])
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
	IDProducto BIGINT NOT NULL,
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
REFERENCES [dbo].invOrdenCompra (IDOrdenCompra)
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
	IDProducto BIGINT NOT NULL,
	IDLote int NOT NULL,
	Cantidad DECIMAL(28,4) DEFAULT  0,
	CantidadAceptada DECIMAL(28,4) DEFAULT 0,
	CantidadRechazada  DECIMAL(28,4) DEFAULT 0,
	Comentario NVARCHAR(20) ,
CONSTRAINT [pkinvEmbarqueDetalle] PRIMARY KEY CLUSTERED 
(
	[IDEmbarque] ASC,
	[IDProducto] ASC,
	IDLote ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkiinvEmbarqueDetalle_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)

GO
ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkinvEmbarqueDetalle_Lote] FOREIGN KEY(IDLote,IDProducto)
REFERENCES [dbo].invLote (IDLote,IDProducto)


GO

CREATE TABLE dbo.invArticuloProveedor (
	IDProducto BIGINT NOT NULL,
	IDProveedor int NOT NULL,
	IDPaisManofactura int,
	LoteMinCompra decimal(28,4),
	CantEconomicaCompra decimal(28,4),
	LoteEstandardCompra decimal(28,4),
	PesoMinimoCompra decimal(28,4),
	MultiploCompra decimal(28,4),
	UnidadAlmacenamiento INT,
	UnidadMedidaCompra INT,
	FactorConversion decimal(28,4), 
	CONSTRAINT [pkinvArticuloProveedor] PRIMARY KEY CLUSTERED 
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
REFERENCES [dbo].cppProveedor (IDProveedor)

GO

ALTER TABLE dbo.invArticuloProveedor WITH CHECK ADD CONSTRAINT fkinvArticuloProveedorUnAlmacenamiento_UnidadMedida FOREIGN KEY(UnidadAlmacenamiento)
REFERENCES dbo.invUnidadMedida(IDUnidad)

GO

ALTER TABLE dbo.invArticuloProveedor WITH CHECK ADD CONSTRAINT fkinvArticuloProveedorUnCompra_UnidadMedida FOREIGN KEY(UnidadMedidaCompra)
REFERENCES dbo.invUnidadMedida(IDUnidad)

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


GO

CREATE PROCEDURE dbo.invUpdateSolicitudCompra(@Operacion NVARCHAR(1), @IDSolicitud AS int, @Fecha date, @FechaRequerida  AS date, @IDEstado AS int ,@Comentario nvarchar(20),
@IDOrdenCompra AS int, @UsuarioSolicitud nvarchar(50),@UsuarioCreaOC nvarchar(20),@FechaCreaOC datetime,@Usuario nvarchar(50),@CreatedDate datetime,@CreatedBy nvarchar(50),@RecordDate datetime,@UpdateBy nvarchar(50))
AS 
IF (@Operacion='I')  
BEGIN
	INSERT INTO dbo.invSolicitudCompra(IdSolicitud,Fecha,FechaRequerida,IDEstado,Comentario,UsuarioSolicitud,CreateDate,CreatedBy,RecordDate,UpdateBy)
	VALUES (@IDSolicitud,@Fecha,@FechaRequerida,@IDEstado,@Comentario,@UsuarioSolicitud,@CreatedDate,@CreatedBy,@RecordDate,@UpdateBy)
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invSolicitudCompra  SET FechaRequerida=@FechaRequerida,IDEstado =@IDEstado,IDOrdenCompra = @IDOrdenCompra,
															UsuarioCreaOC = @UsuarioCreaOC,FechaCreaOC= @FechaCreaOC,RecordDate=@RecordDate,UpdateBy = @UpdateBy
	WHERE IdSolicitud=@IDSolicitud
END
IF (@Operacion ='D')
BEGIN
	DELETE dbo.invSolicitudCompra WHERE IdSolicitud=@IDSolicitud
END

GO


CREATE PROCEDURE dbo.invUpdateDetalleSolicitud(@Operacion NVARCHAR(1),@IDSolicitud INT,@IDProducto INT, @Cantidad INT, @Comentario NVARCHAR(20))
AS 
IF (@Operacion ='I') 
BEGIN
	INSERT INTO dbo.invSolicitudCompraDetalle(IdSolicitud,IDproducto,Cantidad,Comentario)
	VALUES (@IDSolicitud,@IDProducto,@Cantidad,@Comentario)
END
IF (@Operacion='U')
	UPDATE dbo.invSolicitudCompraDetalle SET CANTIDAD =@Cantidad,COMENTARIO=@Comentario WHERE IdSolicitud=@IDSolicitud

IF (@Operacion ='D')
	DELETE FROM dbo.invSolicitudCompraDetalle WHERE  IdSolicitud=@IDSolicitud
	
GO 

CREATE PROCEDURE dbo.invUpdateOrdenCompra (@Operacion nvarchar(1),@IDOrdenCompra INT,@OrdenCompra NVARCHAR(20),@Fecha DATETIME, 
										@FechaRequerida DATE, @FechaEmision DATE,@FechaRequeridaEmbarque DATE,@FechaCotizacion DATE,
										@IDEstado AS INT, @IDBodega AS INT, @IDProveedor AS INT, @IDMoneda AS INT, @IDCondicionPago AS INT, 
										@Descuento AS DECIMAL(28,4), @Flete AS DECIMAL(28,4),@Documentacion AS DECIMAL(28,4),@Anticipos AS DECIMAL(28,4),
										@IDTipoProrrateo AS INT, @IDEmbarque AS INT, @IDSolicitud AS INT, @IDDocumentoCP AS INT, @TipoCambio AS DECIMAL(28,4),
										 @Usuario AS NVARCHAR(50),@UsuarioEmbarque AS NVARCHAR(50),@FechaCreaEmbarque AS DATETIME, 
										 @UsuarioAprobacion AS NVARCHAR(50),@FechaAprobacion AS DATETIME, @CreateDate AS DATETIME, 
										 @CreatedBy AS NVARCHAR(50), @RecordDate AS DATETIME, @UpdatedBy AS DATETIME)
AS 
IF (@Operacion ='I')
BEGIN
	INSERT INTO dbo.invOrdenCompra(IDOrdenCompra,OrdenCompra,Fecha,FechaRequerida,FechaEmision,FechaRequeridaEmbarque,FechaCotizacion,IdEstado, IDBodega,IDProveedor,IDMoneda,IDCondicionPago,Descuento,Flete,Documentacion,Anticipos,IDTipoProrrateo,IDEmbarque,IDSolicitud,IdDocumentoCP,TipoCambio,Usuario,UsuarioCreaEmbarque,FechaCreaEmbarque,UsuarioAprobacion,FechaAprobacion,CreateDate,Createdby,RecordDate,UpdateBy)
	VALUES (@IDOrdenCompra, @OrdenCompra, @Fecha,@FechaRequerida,@FechaEmision,@FechaRequeridaEmbarque,@FechaCotizacion,@IDEstado,@IDBodega,@IDProveedor,@IDMoneda,@IDCondicionPago,@Descuento,@Flete,@Documentacion,@Anticipos,@IDTipoProrrateo,@IDEmbarque,@IDSolicitud,@IDDocumentoCP,@TipoCambio,@Usuario,@UsuarioEmbarque,@FechaCreaEmbarque,@UsuarioAprobacion,@FechaAprobacion, @CreateDate,@CreatedBy,@RecordDate,@UpdatedBy)
END										 
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invOrdenCompra SET FechaRequerida= @FechaRequerida ,FechaRequeridaEmbarque = @FechaRequeridaEmbarque, FechaCotizacion = @FechaCotizacion,IDEstado = @IDEstado,IDBodega=@IDBodega, IDCondicionPago = @IDCondicionPago, Descuento= @Descuento ,Flete=@Flete,Documentacion = @Documentacion,Anticipos= @Anticipos,IDTipoProrrateo = @IDTipoProrrateo,IDEmbarque = @IDEmbarque,IDSolicitud = @IDSolicitud,IDDocumentoCP = @IDDocumentoCP, 
																																																																																																																						TipoCambio = @TipoCambio,UsuarioCreaEmbarque = @UsuarioEmbarque,UsuarioAprobacion =@UsuarioAprobacion, FechaAprobacion=@FechaAprobacion,RecordDate=@RecordDate,UpdateBy=@UpdatedBy
END
IF (@Operacion='D')
BEGIN
	DELETE FROM dbo.invOrdenCompra WHERE IDOrdenCompra=@IDOrdenCompra
END


GO 

CREATE PROCEDURE dbo.invUpdateOrdenCompraDetalle(@Operacion AS NVARCHAR(1),@IDOrdenCompra AS INT,@IDProducto AS BIGINT,@Cantidad AS DECIMAL(28,4),@CantidadAceptada AS DECIMAL(28,4),
									@CantidadRechazada AS DECIMAL(28,4),@PrecioUnitario AS DECIMAL(28,4), @Impuesto AS DECIMAL(28,4),@PorcDesc AS DECIMAL(28,4),
									@MontoDesc AS DECIMAL(28,4) ,@Estado AS INT, @Comentario AS NVARCHAR(20))
AS 
IF (@Operacion='I')
BEGIN
	INSERT INTO dbo.invOrdenCompraDetalle( IDOrdenCompra ,IDProducto ,Cantidad ,CantidadAceptada ,CantidadRechazada ,PrecioUnitario ,Impuesto ,PorcDesc ,MontoDesc ,Estado ,Comentario)
	VALUES (@IDOrdenCompra,@IDProducto,@Cantidad,@CantidadAceptada,@CantidadRechazada,@PrecioUnitario,@Impuesto,@PorcDesc,@MontoDesc,@Estado,@Comentario)
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invOrdenCompraDetalle SET  Cantidad =@Cantidad,CantidadAceptada=@CantidadAceptada,CantidadRechazada=@CantidadRechazada,
							PrecioUnitario =@PrecioUnitario,Impuesto = @Impuesto,PorcDesc=@PorcDesc,MontoDesc= @MontoDesc,Estado =@Estado,Comentario =@Comentario
	 WHERE IDOrdenCompra=@IDOrdenCompra AND IDProducto=@IDProducto
END
IF (@Operacion='D')
	DELETE FROM dbo.invOrdenCompraDetalle WHERE IDOrdenCompra=@IDOrdenCompra AND (IDProducto=@IDProducto OR @IDProducto=-1)


GO


CREATE PROCEDURE dbo.invUpdateEmbaque(@Operacion AS NVARCHAR(1),@IDEmbarque AS INT, @Embarque AS NVARCHAR(20),@Fecha AS DATE, 
						@FechaEmbarque AS INT,@Asiento AS NVARCHAR(20),@IDBodega AS INT, @IDProveedor AS INT, @IDOrdenCompra AS INT, 
						@IDSolicitud AS INT, @IDDocumentoCP AS INT, @TipoCambio AS DECIMAL(28,4), @Usuario AS NVARCHAR(50),@CreateDate AS DATETIME, 
						@CreatedBy AS NVARCHAR(50),@RecordDate AS DATETIME,@UpdateBy AS NVARCHAR(50))
AS 
IF (@Operacion ='I')
BEGIN
	 INSERT INTO dbo.invEmbarque( IDEmbarque ,Embarque ,Fecha ,FechaEmbarque ,Asiento ,IDBodega ,IDProveedor ,IDOrdenCompra ,IDSolicitud ,IDDocumentoCP ,TipoCambio ,Usuario ,CreateDate ,CreatedBy ,RecordDate ,UpdateBy)
	 VALUES (@IDEmbarque,@Embarque,@Fecha,@FechaEmbarque,@Asiento,@IDBodega,@IDProveedor,@IDOrdenCompra,@IDSolicitud,@IDDocumentoCP,@TipoCambio,@Usuario,@CreateDate,@CreateDate,@RecordDate,@UpdateBy)
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invEmbarque SET  FechaEmbarque=@FechaEmbarque, Asiento= @Asiento,IDBodega=@IDBodega,IDProveedor=@IDProveedor,
			IDOrdenCompra=@IDOrdenCompra,IDSolicitud=@IDSolicitud,IDDocumentoCP=@IDDocumentoCP,RecordDate= @RecordDate,UpdateBy= @UpdateBy
	  WHERE IDEmbarque=@IDEmbarque
END
IF (@Operacion ='D')
	DELETE FROM dbo.invEmbarque WHERE IDEmbarque=@IDEmbarque


GO 

CREATE PROCEDURE dbo.invUpdateEmbarqueDetalle(@Operacion AS NVARCHAR(1),@IDEmbarque AS INT,@IDProducto AS bigint, @IDLote AS int, @Cantidad AS decimal(28,4), @CantidadAceptada AS decimal(28,4),@CantidadRechazada AS decimal(28,4),@Comentario AS nvarchar(20))
AS 
IF (@Operacion='I')
BEGIN
	INSERT INTO dbo.invEmbarqueDetalle( IDEmbarque ,IDProducto ,IDLote ,Cantidad ,CantidadAceptada ,CantidadRechazada ,Comentario)
	VALUES (@IDEmbarque,@IDProducto,@IDLote,@Cantidad,@CantidadAceptada,@CantidadRechazada,@Comentario)
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invEmbarqueDetalle SET  Cantidad=@Cantidad,CantidadAceptada=@CantidadAceptada,CantidadRechazada=@CantidadRechazada,
																Comentario=@Comentario
	 WHERE IDEmbarque=@IDEmbarque AND IDProducto=@IDProducto AND IDLote=@IDLote
END
IF (@Operacion='D')
BEGIN
	DELETE FROM dbo.invEmbarqueDetalle WHERE IDEmbarque=@IDEmbarque AND( IDProducto=@IDProducto OR @IDProducto=-1) AND (IDLote=@IDLote OR @IDLote=-1)
END


GO


CREATE PROCEDURE dbo.invUpdateArticuloProveedor (@Operacion AS NVARCHAR(1),@IDProducto AS BIGINT,@IDProveedor AS INT, 
				@IDPaisManoFactura AS INT,@LoteMinCompra AS DECIMAL(28,4),@CantEconomicaCompra AS DECIMAL(28,4), @LoteEstandardCompra AS DECIMAL(28,4),
				@PesoMinimoCompra AS DECIMAL(28,4),@MultiploCompra AS DECIMAL(28,4),@IDUnidadAlmacenamiento AS int, @IDUnidadMedidaCompra AS INT, 
				@FactorConversion AS DECIMAL(28,4))
AS 
IF (@Operacion='I')
BEGIN
	INSERT INTO dbo.invArticuloProveedor( IDProducto ,IDProveedor ,IDPaisManofactura ,LoteMinCompra ,CantEconomicaCompra ,LoteEstandardCompra ,PesoMinimoCompra ,MultiploCompra ,UnidadAlmacenamiento ,UnidadMedidaCompra ,FactorConversion)
	VALUES (@IDProducto,@IDProveedor,@IDPaisManoFactura,@LoteMinCompra,@CantEconomicaCompra,@LoteEstandardCompra,@PesoMinimoCompra,@MultiploCompra,@IDUnidadAlmacenamiento,@IDUnidadMedidaCompra,@FactorConversion)
END			
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invArticuloProveedor SET  IDPaisManofactura=@IDPaisManoFactura,CantEconomicaCompra=@CantEconomicaCompra,
				LoteEstandardCompra=@LoteEstandardCompra,UnidadAlmacenamiento=@IDUnidadAlmacenamiento,UnidadMedidaCompra=@IDUnidadMedidaCompra,
				FactorConversion=@FactorConversion 
	WHERE IDProducto=@IDProducto AND IDProveedor= @IDProveedor
END
IF (@Operacion='D')
	DELETE FROM dbo.invArticuloProveedor WHERE IDProducto=@IDProducto AND IDProveedor=@IDProveedor


GO