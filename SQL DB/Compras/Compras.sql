
CREATE  TABLE dbo.cppProveedor(
	IDProveedor INT NOT NULL,
	Nombre NVARCHAR(250),
	Alias NVARCHAR(250),
	Contacto NVARCHAR(250),
	IDRuc INT,
	Telefono NVARCHAR(50),
	IDImpuesto INT,
	IDCategoria INT,
	IDPais INT,
	IDMoneda INT,
	IDCondicionPago INT,
	FechaIngreso DATETIME,
	PorcDesc DECIMAL(28,4),
	PorcInteresMora DECIMAL(28,4),
	Email NVARCHAR(50),
	Direccion NVARCHAR(255),
	Activo BIT DEFAULT 1,
	MultiMoneda BIT DEFAULT 0,
	PagosCongelados BIT DEFAULT 0,
	IsLocal BIT DEFAULT 0,
	TipoContribuyente INT
CONSTRAINT [pkcppProveedor] PRIMARY KEY CLUSTERED 
(
	IDProveedor ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE dbo.cppCategoriaProveedor(
	IDCategoria INT NOT NULL,
	Descr NVARCHAR(250),
	Ctr_CXP int,
	Cta_CXP bigint,
	Ctr_Letra_CXP int,
	Cta_Letra_CXP bigint,
	Ctr_ProntoPago_CXP int,
	Cta_ProntoPago_CXP bigint,
	Ctr_Comision_CXP int,
	Cta_Comision_CXP bigint,
	Ctr_Anticipos_CXP int,
	Cta_Anticipos_CXP bigint,
	Ctr_CierreDebitos_CXP int,
	Cta_CierreDebitos_CXP bigint,
	Ctr_Impuestos_CXP int,
	Cta_Impuestos_CxP bigint,
	Activo BIT DEFAULT 1
CONSTRAINT [pkcppCategoriaProveedor] PRIMARY KEY CLUSTERED 
(
	IDCategoria ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[cppProveedor]  WITH CHECK ADD  CONSTRAINT [fkcppProveedor_Categoria] FOREIGN KEY([IDCategoria])
REFERENCES [dbo].cppCategoriaProveedor (IDCategoria)

go	

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
	Consecutivo NVARCHAR(20),
	Fecha date,
	FechaRequerida date,
	IDEstado int,
	Comentario nvarCHAR(250),
	UsuarioSolicitud nvarchar(50),
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

CREATE TABLE dbo.invSolicitudOrdenCompra (
	IDSolicitud INT NOT NULL,
	IDOrdenCompra INT NOT NULL,
	IDProducto BIGINT NOT NULL,
	Cantidad DECIMAL(28,4) DEFAULT  0,
	Usuario NVARCHAR(50) ,
	Fecha DATETIME
CONSTRAINT [pkinvSolicitudCompraOrdenCompra] PRIMARY KEY CLUSTERED 
(
	IDSolicitud ASC,
	IDOrdenCompra ASC,
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].invSolicitudOrdenCompra  WITH CHECK ADD  CONSTRAINT [fkinvSolicitudOrdenCompra_Solicitud] FOREIGN KEY([IDSolicitud])
REFERENCES [dbo].invSolicitudCompra (IDSolicitud)


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
	Seguro DECIMAL(28,4),
	Documentacion DECIMAL(28,4),
	Anticipos decimal(28,4),
	IDTipoProrrateo INt,
	IDEmbarque INT,
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

ALTER TABLE [dbo].invSolicitudOrdenCompra  WITH CHECK ADD  CONSTRAINT [fkinvSolicitudOrdenCompra_OrdenCompra] FOREIGN KEY([IDOrdenCompra])
REFERENCES [dbo].invOrdenCompra (IDOrdenCompra)

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
	DocumentoInv NVARCHAR(20),
	[IDBodega] INT,
	[IDProveedor] INT,
	[IDOrdenCompra] int,
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

ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkiinvEmbarque_EmbarqueDetalle] FOREIGN KEY(IDEmbarque)
REFERENCES [dbo].invEmbarque (IDEmbarque)

GO

ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkiinvEmbarqueDetalle_Producto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].invProducto (IDProducto)

GO
ALTER TABLE [dbo].invEmbarqueDetalle  WITH CHECK ADD  CONSTRAINT [fkinvEmbarqueDetalle_Lote] FOREIGN KEY(IDLote,IDProducto)
REFERENCES [dbo].invLote (IDLote,IDProducto)


GO

CREATE TABLE	dbo.globalPais(
		IDPais int	NOT NULL,
		Descr  nvarchar(50),
		Activo  bit
CONSTRAINT [pkglobalPais] PRIMARY KEY CLUSTERED 
(
	IDPais ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE   TABLE dbo.invArticuloProveedor (
	IDProducto BIGINT NOT NULL,
	IDProveedor int NOT NULL,
	IDPaisManofactura int,
	LoteMinCompra decimal(28,4),
	PesoMinimoCompra decimal(28,4),
	Notas NVARCHAR(256),
	CreateDate datetime,
	CreatedBy nvarchar(50),
	UpdatedDate datetime,
	UpdatedBy nvarchar(50)
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


ALTER TABLE [dbo].invArticuloProveedor  WITH CHECK ADD  CONSTRAINT [fkinvArticuloProveedor_Pais] FOREIGN KEY(IDPaisManofactura)
REFERENCES [dbo].globalPais (IDPais)

GO




CREATE TABLE dbo.invParametrosCompra(
	IDParametro int,
	IDConsecSolicitud int	,
	IDConsecOrdenCompra int,
	IDConsecEmbarque int,
	IDConsecDevolucion int,
	CantLineasOrdenCompra int,
	IDBodegaDefault int,
	IDTipoCambio NVARCHAR(20),
	CantDecimalesPrecio int	,
	CantDecimalesCantidad int	,
	IDTipoAsientoContable NVARCHAR(2),
	IDPaquete int,
	CtaTransitoLocal bigInt,
	CtrTransitoLocal int,
	CtaTransitoExterior bigint,
	CtrTransitoExterior int,
	AplicaAutomaticamenteAsiento bit DEFAULT 0,
	CanEditAsiento bit DEFAULT 1,
	CanViewAsiento bit DEFAULT 1,
	CONSTRAINT [pkinvParametrosCompra] PRIMARY KEY CLUSTERED 
(
	IDParametro ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

CREATE   PROCEDURE dbo.invUpdateSolicitudCompra(@Operacion NVARCHAR(1), @IDSolicitud AS INT OUTPUT,@Consecutivo NVARCHAR(20) OUTPUT, @Fecha date, @FechaRequerida  AS date, @IDEstado AS int ,@Comentario nvarchar(20)
, @UsuarioSolicitud nvarchar(50),@Usuario nvarchar(50),@CreatedDate datetime,@CreatedBy nvarchar(50),@RecordDate datetime,@UpdateBy nvarchar(50))
AS 
IF (@Operacion='I')  
BEGIN
	DECLARE @IDConsecutivo  AS INT
	DECLARE @CodigoConsecutivo AS NVARCHAR(4)
	DECLARE @Documento AS NVARCHAR(20)
	
	SET @IDConsecutivo = (SELECT IDConsecSolicitud  FROM dbo.invParametrosCompra WHERE IDParametro=1)
	
	EXEC [dbo].[invGetNextGlobalConsecutivo] @IDConsecutivo,@Documento OUTPUT
	SET @Consecutivo = @Documento
	
	SET @IDSolicitud = (SELECT ISNULL(MAX(IDSolicitud),0)  FROM dbo.invSolicitudCompra) + 1
	INSERT INTO dbo.invSolicitudCompra(IdSolicitud,Consecutivo,Fecha,FechaRequerida,IDEstado,Comentario,UsuarioSolicitud,CreateDate,CreatedBy,RecordDate,UpdateBy)
	VALUES (@IDSolicitud,@Documento,@Fecha,@FechaRequerida,@IDEstado,@Comentario,@UsuarioSolicitud,@CreatedDate,@CreatedBy,@RecordDate,@UpdateBy)
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invSolicitudCompra  SET FechaRequerida=@FechaRequerida,IDEstado =@IDEstado,
															RecordDate=@RecordDate,UpdateBy = @UpdateBy
	WHERE IdSolicitud=@IDSolicitud
END
IF (@Operacion ='D')
BEGIN
	DELETE dbo.invSolicitudCompra WHERE IdSolicitud=@IDSolicitud
END

GO

CREATE PROCEDURE [dbo].[invGetSolicitudCompraByID] (@IDSolicitud AS INT)
AS 
SELECT  A.IDSolicitud,A.Consecutivo ,A.Fecha ,A.FechaRequerida ,A.IDEstado , E.Descr DescrEstado,Comentario ,UsuarioSolicitud ,
				A.CreateDate ,A.CreatedBy ,A.RecordDate ,A.UpdateBy  
FROM dbo.invSolicitudCompra A
INNER JOIN dbo.invEstadoSolicitud E ON A.IDEstado=E.IDEstado
WHERE A.IDSolicitud =@IDSolicitud 

GO

CREATE  PROCEDURE dbo.invGetSolicitudCompra (@IDSolicitud AS INT, @FechaInicial AS DATETIME,@FechaFinal AS DATE,@IDEstado AS INT)
AS 

set @FechaInicial = CONVERT(VARCHAR(25),@FechaInicial,101) 
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT  A.IDSolicitud, Consecutivo ,A.Fecha ,A.FechaRequerida ,A.IDEstado , E.Descr DescrEstado,Comentario  ,UsuarioSolicitud ,
				A.CreateDate ,A.CreatedBy ,A.RecordDate ,A.UpdateBy  
FROM dbo.invSolicitudCompra A
INNER JOIN dbo.invEstadoSolicitud E ON A.IDEstado=E.IDEstado
WHERE (A.IDSolicitud =@IDSolicitud OR @IDSolicitud=-1) AND A.Fecha BETWEEN @FechaInicial AND @FechaFinal  
			AND (A.IDEstado =@IDEstado OR @IDEstado=-1) 
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

CREATE PROCEDURE dbo.invGetSolicitudCompraDetalle (@IDSolicitud AS INT)
AS 
SELECT IDSolicitud,A.IDProducto,P.Descr DescrProducto,A.Cantidad,A.Comentario
FROM dbo.invSolicitudCompraDetalle A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
WHERE (IDSolicitud =@IDSolicitud OR (@IDSolicitud=-1 AND 1=3))
go 

CREATE  PROCEDURE dbo.invGetOrdenCompra(  @IDOrdenCompra AS INT, @FechaInicial AS DATETIME,@FechaFinal AS DATETIME, @Proveedor AS NVARCHAR(1000),@Estado AS NVARCHAR(1000),@FechaRequeridaInicial AS DATETIME ,
																			@FechaRequeridaFinal AS DATETIME)
AS 
DECLARE @Separador AS NVARCHAR(1)
SET @Separador = '|'
IF (@FechaInicial IS NULL) SET @FechaInicial = '19810821'
IF (@FechaFinal IS NULL) SET @FechaFinal = DATEADD(YEAR,50,GETDATE())

IF (@FechaRequeridaInicial IS NULL) SET @FechaRequeridaInicial = '19810821'
IF (@FechaRequeridaFinal IS NULL) SET @FechaRequeridaFinal = DATEADD(YEAR,50,GETDATE())

set @FechaRequeridaInicial = CONVERT(VARCHAR(25),@FechaRequeridaInicial,101) 
set @FechaRequeridaFinal = CAST(SUBSTRING(CAST(@FechaRequeridaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

set @FechaInicial = CONVERT(VARCHAR(25),@FechaInicial,101) 
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT  A.IDOrdenCompra ,OrdenCompra ,A.Fecha ,FechaRequerida ,FechaEmision ,FechaRequeridaEmbarque ,FechaCotizacion ,IDEstado, B.Descr DescrEstado,A.IDBodega, C.Descr DescrBodega, 
		A.IDProveedor ,C.Descr DescrProveedor,A.IDMoneda, E.Descr DescrMoneda,A.IDCondicionPago , F.Descr DescrCondicionPago,F.Dias DiasCondicionPago,
        Descuento ,Seguro	,Flete ,Documentacion ,Anticipos ,A.IDEmbarque, H.Embarque ,A.IDDocumentoCP ,A.TipoCambio ,A.Usuario ,UsuarioCreaEmbarque ,FechaCreaEmbarque ,UsuarioAprobacion ,
        FechaAprobacion ,A.CreateDate ,A.CreatedBy ,A.RecordDate ,A.UpdateBy  
FROM dbo.invOrdenCompra A INNER JOIN dbo.invEstadoOrdenCompra B ON A.IDEstado = B.IDEstadoOrden
INNER JOIN dbo.invBodega C ON A.IDBodega= C.IDBodega 
INNER JOIN dbo.cppProveedor D ON A.IDProveedor = D.IDProveedor
INNER JOIN dbo.globalMoneda E ON A.IDMoneda = E.IDMoneda
INNER JOIN dbo.cppCondicionPago F ON A.IDCondicionPago = F.IDCondicionPago
LEFT  JOIN dbo.invTipoProrrateoRubrosCompra G ON A.IDTipoProrrateo = G.IDTipoProrrateo
LEFT JOIN dbo.invEmbarque H ON A.IDEmbarque = H.IDEmbarque
WHERE (A.IDOrdenCompra = @IDOrdenCompra OR @IDOrdenCompra = -1) AND A.Fecha  BETWEEN @FechaInicial  AND @FechaFinal  AND FechaRequerida  BETWEEN @FechaRequeridaInicial AND @FechaRequeridaFinal
AND (a.IDProveedor = (SELECT Value FROM [dbo].[ConvertListToTable](@Proveedor,@Separador)) OR @Proveedor = '*')  AND (A.IDEstado = (SELECT Value FROM [dbo].[ConvertListToTable](@Estado,@Separador) ) OR @Estado ='*' )


go 


CREATE PROCEDURE dbo.invGetOrdenCompraByID( @IDOrdenCompra AS INT)
AS 
SELECT  A.IDOrdenCompra ,OrdenCompra ,A.Fecha ,FechaRequerida ,FechaEmision ,FechaRequeridaEmbarque ,FechaCotizacion ,IDEstado, B.Descr DescrEstado,A.IDBodega, C.Descr DescrBodega, 
		A.IDProveedor ,C.Descr DescrProveedor,A.IDMoneda, E.Descr DescrMoneda,A.IDCondicionPago , F.Descr DescrCondicionPago,F.Dias DiasCondicionPago,
        Descuento ,Flete,Seguro ,Documentacion ,Anticipos ,A.IDEmbarque, H.Embarque ,A.IDDocumentoCP ,A.TipoCambio ,A.Usuario ,UsuarioCreaEmbarque ,FechaCreaEmbarque ,UsuarioAprobacion ,
        FechaAprobacion ,A.CreateDate ,A.CreatedBy ,A.RecordDate ,A.UpdateBy  
FROM dbo.invOrdenCompra A INNER JOIN dbo.invEstadoOrdenCompra B ON A.IDEstado = B.IDEstadoOrden
INNER JOIN dbo.invBodega C ON A.IDBodega= C.IDBodega 
INNER JOIN dbo.cppProveedor D ON A.IDProveedor = D.IDProveedor
INNER JOIN dbo.globalMoneda E ON A.IDMoneda = E.IDMoneda
INNER JOIN dbo.cppCondicionPago F ON A.IDCondicionPago = F.IDCondicionPago
LEFT  JOIN dbo.invTipoProrrateoRubrosCompra G ON A.IDTipoProrrateo = G.IDTipoProrrateo
LEFT JOIN dbo.invEmbarque H ON A.IDEmbarque = H.IDEmbarque
WHERE (A.IDOrdenCompra = @IDOrdenCompra )


GO

CREATE ALTER  PROCEDURE dbo.invUpdateOrdenCompra (@Operacion nvarchar(1),@IDOrdenCompra INT OUTPUT,@OrdenCompra NVARCHAR(20) OUTPUT,@Fecha DATETIME, 
										@FechaRequerida DATE, @FechaEmision DATE,@FechaRequeridaEmbarque DATE,@FechaCotizacion DATE,
										@IDEstado AS INT, @IDBodega AS INT, @IDProveedor AS INT, @IDMoneda AS INT, @IDCondicionPago AS INT, 
										@Descuento AS DECIMAL(28,4), @Flete AS DECIMAL(28,4),@Seguro AS DECIMAL(28,4),@Documentacion AS DECIMAL(28,4),@Anticipos AS DECIMAL(28,4),
									    @IDEmbarque AS INT,  @IDDocumentoCP AS INT, @TipoCambio AS DECIMAL(28,4),
										 @Usuario AS NVARCHAR(50),@UsuarioEmbarque AS NVARCHAR(50),@FechaCreaEmbarque AS DATETIME, 
										 @UsuarioAprobacion AS NVARCHAR(50),@FechaAprobacion AS DATETIME, @CreateDate AS DATETIME, 
										 @CreatedBy AS NVARCHAR(50), @RecordDate AS DATETIME, @UpdatedBy AS NVARCHAR(50))
AS 
IF (@Operacion ='I')
BEGIN
	SET @IDOrdenCompra = (SELECT ISNULL(MAX(IDOrdenCompra),0)  FROM dbo.invOrdenCompra ) + 1
	
	DECLARE @IDConsecutivo  AS INT
	DECLARE @CodigoConsecutivo AS NVARCHAR(4)
	DECLARE @Documento AS NVARCHAR(20)
	
	SET @IDConsecutivo = (SELECT IDConsecOrdenCompra  FROM dbo.invParametrosCompra WHERE IDParametro=1)
	
	EXEC [dbo].[invGetNextGlobalConsecutivo] @IDConsecutivo,@Documento OUTPUT
	SET @OrdenCompra = @Documento
	
	INSERT INTO dbo.invOrdenCompra(IDOrdenCompra,OrdenCompra,Fecha,FechaRequerida,FechaEmision,FechaRequeridaEmbarque,FechaCotizacion,IdEstado, IDBodega,IDProveedor,IDMoneda,IDCondicionPago,Descuento,Flete,Seguro,Documentacion,Anticipos,IDEmbarque,IdDocumentoCP,TipoCambio,Usuario,UsuarioCreaEmbarque,FechaCreaEmbarque,UsuarioAprobacion,FechaAprobacion,CreateDate,Createdby,RecordDate,UpdateBy)
	VALUES (@IDOrdenCompra, @OrdenCompra, @Fecha,@FechaRequerida,@FechaEmision,@FechaRequeridaEmbarque,@FechaCotizacion,@IDEstado,@IDBodega,@IDProveedor,@IDMoneda,@IDCondicionPago,@Descuento,@Flete,@Seguro,@Documentacion,@Anticipos,@IDEmbarque,@IDDocumentoCP,@TipoCambio,@Usuario,@UsuarioEmbarque,@FechaCreaEmbarque,@UsuarioAprobacion,@FechaAprobacion, @CreateDate,@CreatedBy,@RecordDate,@UpdatedBy)
END										 
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invOrdenCompra SET FechaRequerida= @FechaRequerida ,FechaRequeridaEmbarque = @FechaRequeridaEmbarque, FechaCotizacion = @FechaCotizacion,IDEstado = @IDEstado,IDBodega=@IDBodega, IDCondicionPago = @IDCondicionPago, Descuento= @Descuento ,Flete=@Flete,Seguro=@Seguro,Documentacion = @Documentacion,Anticipos= @Anticipos,IDEmbarque = @IDEmbarque,IDDocumentoCP = @IDDocumentoCP, 
																																																																																																																						TipoCambio = @TipoCambio,UsuarioCreaEmbarque = @UsuarioEmbarque,UsuarioAprobacion =@UsuarioAprobacion, FechaAprobacion=@FechaAprobacion,RecordDate=@RecordDate,UpdateBy=@UpdatedBy
END
IF (@Operacion='D')
BEGIN
	DELETE FROM dbo.invOrdenCompra WHERE IDOrdenCompra=@IDOrdenCompra
END

GO

CREATE   PROCEDURE dbo.invGetOrdenCompraDetalle(@IDOrdenCompra AS int	)
AS 
SELECT A.IDOrdenCompra,A.IDProducto,P.Descr DescrProducto,A.Estado,E.Descr DescrEstado,A.Cantidad,A.CantidadAceptada,A.CantidadRechazada,A.Impuesto,A.MontoDesc,A.PorcDesc,A.PrecioUnitario,A.Comentario,CASE WHEN (F.IDOrdenCompra IS NOT NULL ) THEN 1 ELSE 0 END IsLoadFromSolicitud
  FROM dbo.invOrdenCompraDetalle A
INNER JOIN dbo.invProducto P ON		A.IDProducto = P.IDProducto
INNER JOIN dbo.invEstadoOrdenCompra E ON A.Estado=E.IDEstadoOrden
LEFT  JOIN (SELECT DISTINCT  IDOrdenCompra,IDProducto  FROM dbo.invSolicitudOrdenCompra) F ON A.IDOrdenCompra=F.IDOrdenCompra AND A.IDProducto=F.IDProducto
WHERE A.IDOrdenCompra=@IDOrdenCompra

GO


CREATE   PROCEDURE dbo.invGetOrdenCompraDetalleEmptyExcel
AS 
SELECT A.IDOrdenCompra,A.IDProducto,P.Descr DescrProducto,A.Estado,E.Descr DescrEstado,A.Cantidad,A.CantidadAceptada,A.CantidadRechazada,A.Impuesto,A.MontoDesc,A.PorcDesc,A.PrecioUnitario,A.Comentario,CASE WHEN (F.IDOrdenCompra IS NOT NULL ) THEN 1 ELSE 0 END IsLoadFromSolicitud,A.Estado Status,P.Descr DescrStatus
  FROM dbo.invOrdenCompraDetalle A
INNER JOIN dbo.invProducto P ON		A.IDProducto = P.IDProducto
INNER JOIN dbo.invEstadoOrdenCompra E ON A.Estado=E.IDEstadoOrden
LEFT  JOIN (SELECT DISTINCT  IDOrdenCompra,IDProducto  FROM dbo.invSolicitudOrdenCompra) F ON A.IDOrdenCompra=F.IDOrdenCompra AND A.IDProducto=F.IDProducto
WHERE 1=2


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


CREATE   PROCEDURE dbo.invUpdateEmbaque(@Operacion AS NVARCHAR(1),@IDEmbarque AS INT OUTPUT, @Embarque AS NVARCHAR(20) OUTPUT,@Fecha AS DATE, 
						@FechaEmbarque AS DATE,@Asiento AS NVARCHAR(20),@IDBodega AS INT, @IDProveedor AS INT, @IDOrdenCompra AS INT, 
						@IDDocumentoCP AS INT, @TipoCambio AS DECIMAL(28,4), @Usuario AS NVARCHAR(50),@CreateDate AS DATETIME, 
						@CreatedBy AS NVARCHAR(50),@RecordDate AS DATETIME,@UpdateBy AS NVARCHAR(50))
AS 
IF (@Operacion ='I')
BEGIN
	SET @IDEmbarque = 	(SELECT ISNULL(MAX(IDEmbarque),0) +1  FROM dbo.invEmbarque )
	
	DECLARE @IDConsecutivo  AS INT
	DECLARE @CodigoConsecutivo AS NVARCHAR(4)
	
	SELECT *  FROM dbo.globalConsecutivos
	SET @IDConsecutivo = (SELECT IDConsecEmbarque  FROM dbo.invParametrosCompra WHERE IDParametro=1)
	EXEC [dbo].[invGetNextGlobalConsecutivo] @IDConsecutivo,@Embarque OUTPUT
	
	 INSERT INTO dbo.invEmbarque( IDEmbarque ,Embarque ,Fecha ,FechaEmbarque ,Asiento ,IDBodega ,IDProveedor ,IDOrdenCompra  ,IDDocumentoCP ,TipoCambio ,Usuario ,CreateDate ,CreatedBy ,RecordDate ,UpdateBy)
	 VALUES (@IDEmbarque,@Embarque,@Fecha,@FechaEmbarque,@Asiento,@IDBodega,@IDProveedor,@IDOrdenCompra,@IDDocumentoCP,@TipoCambio,@Usuario,@CreateDate,@CreatedBy,@RecordDate,@UpdateBy)
	 
	 UPDATE dbo.invOrdenCompra SET IDEmbarque=@IDEmbarque WHERE IDOrdenCompra =@IDOrdenCompra
	 
	 UPDATE dbo.globalConsecMask SET  Consecutivo=@Embarque WHERE Codigo='EM'
	 
END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invEmbarque SET  FechaEmbarque=@FechaEmbarque, Asiento= @Asiento,IDBodega=@IDBodega,IDProveedor=@IDProveedor,
			IDOrdenCompra=@IDOrdenCompra,IDDocumentoCP=@IDDocumentoCP,RecordDate= @RecordDate,UpdateBy= @UpdateBy
	  WHERE IDEmbarque=@IDEmbarque
END
IF (@Operacion ='D')
BEGIN
	UPDATE dbo.invOrdenCompra SET  IDEmbarque = -1 WHERE IDEmbarque=@IDEmbarque
	DELETE FROM dbo.invEmbarque WHERE IDEmbarque=@IDEmbarque
END


GO

CREATE aLTER PROCEDURE dbo.invGetEmbarque(@IDEmbarque AS INT,@FechaInicial AS DATE,@FechaFinal AS DATE,
																	@IDProveedor AS INT,@OrdenCompra AS NVARCHAR(20),@Embarque nvarchar(20),@IDDocumentoCP AS INT)
AS
set @FechaInicial = CONVERT(VARCHAR(25),@FechaInicial,101) 
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)

SELECT A.IDEmbarque,A.Embarque,A.Fecha,A.FechaEmbarque,A.Asiento,A.IDBodega,B.Descr DescrBodega,A.IDProveedor,P.Nombre NombreProveedor,A.IDOrdenCompra,
			O.OrdenCompra,A.IDDocumentoCP,A.TipoCambio,A.Usuario,A.CreateDate,A.CreatedBy,A.RecordDate,A.UpdateBy
  FROM dbo.invEmbarque A
LEFT JOIN dbo.invOrdenCompra O ON A.IDOrdenCompra=O.IDOrdenCompra
INNER JOIN dbo.cppProveedor P ON A.IDProveedor=P.IDProveedor
INNER JOIN dbo.invBodega B ON A.IDBodega=B.IDBodega
WHERE (A.IDEmbarque =@IDEmbarque OR @IDEmbarque=-1) AND A.Fecha BETWEEN @FechaInicial AND @FechaFinal AND (A.IDProveedor =@IDProveedor OR @IDProveedor=-1)
 AND (O.OrdenCompra =@OrdenCompra OR o.OrdenCompra LIKE '%'+ @OrdenCompra +'%') AND (A.IDDocumentoCP = @IDDocumentoCP OR @IDDocumentoCP=-1)
AND (A.Embarque LIKE '%' + @Embarque + '%')

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

CREATE  PROCEDURE dbo.invGetEmbarqueDetalle(@IDEmbarque AS INT)
AS 
SELECT A.IDEmbarque,A.IDProducto,P.Descr DescrProducto,A.IDLote,L.LoteProveedor,L.FechaVencimiento,A.Cantidad,A.CantidadAceptada,A.CantidadRechazada 
 FROM dbo.invEmbarqueDetalle A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.invLote L ON a.IDProducto=L.IDProducto AND A.IDLote=L.IDLote
WHERE (A.IDEmbarque =@IDEmbarque AND @IDEmbarque =-1)

GO

CREATE  PROCEDURE dbo.invGetArticuloProveedor(@IDProducto AS BIGINT,@IDProveedor AS INT)
AS	
SELECT  A.IDProducto ,P.Descr DescrProducto,
        A.IDProveedor ,PR.Nombre NombreProveedor,
        A.IDPaisManofactura ,C.Descr DescrPais,
        A.LoteMinCompra ,
        A.PesoMinimoCompra,
        A.Notas
         FROM dbo.invArticuloProveedor A
INNER JOIN dbo.invProducto P ON A.IDProducto = P.IDProducto
INNER JOIN dbo.cppProveedor PR ON A.IDProveedor=PR.IDProveedor
LEFT JOIN dbo.globalPais C ON A.IDPaisManofactura = C.IDPais
WHERE (A.IDProducto = @IDProducto OR @IDProducto =-1) AND (A.IDProveedor=@IDProveedor OR @IDProveedor=-1)


go

CREATE PROCEDURE dbo.invUpdateArticuloProveedor (@Operacion AS NVARCHAR(1),@IDProducto AS BIGINT,@IDProveedor AS INT, 
				@IDPaisManoFactura AS INT,@LoteMinCompra AS DECIMAL(28,4),@PesoMinimoCompra AS DECIMAL(28,4),@Notas NVARCHAR(256),@Usuario AS NVARCHAR(50), @Fecha AS DATETIME)
AS 
IF (@Operacion='I')
BEGIN
	INSERT INTO dbo.invArticuloProveedor( IDProducto ,IDProv eedor ,IDPaisManofactura ,LoteMinCompra ,PesoMinimoCompra,Notas,CreateDate,CreatedBy)
	VALUES (@IDProducto,@IDProveedor,@IDPaisManoFactura,@LoteMinCompra,@PesoMinimoCompra,@Notas,@Fecha,@Usuario)
END			
IF (@Operacion='U')
BEGIN
	UPDATE dbo.invArticuloProveedor SET  IDPaisManofactura=@IDPaisManoFactura,
				LoteMinCompra=@LoteMinCompra, PesoMinimoCompra = @PesoMinimoCompra, Notas=@Notas,UpdatedBy = @Usuario, UpdatedDate= @Fecha
	WHERE IDProducto=@IDProducto AND IDProveedor= @IDProveedor
END
IF (@Operacion='D')
	DELETE FROM dbo.invArticuloProveedor WHERE IDProducto=@IDProducto AND IDProveedor=@IDProveedor

GO

CREATE  PROCEDURE dbo.invGetProductosSinAsociarProveedor(@IDProveedor AS INT,@IDClasificacion1 AS INT,@IDClasificacion2 AS INT,
		@IDClasificacion3 AS INT,@IDClasificacion4  AS INT,@IDClasificacion5  AS INT,@IDClasificacion6 AS INT)
AS
SELECT  IDProducto ,A.Descr ,Alias ,Clasif1 ,C.Descr DescrClasif1,Clasif2,D.Descr DescrClasif2 ,Clasif3 ,E.Descr DescrClasif3,
				Clasif4, F.Descr DescrClasif4 ,Clasif5,G.Descr DescrClasif5 ,Clasif6, H.Descr DescrClasif6
FROM dbo.invProducto A
LEFT  JOIN dbo.invClasificacion c ON A.Clasif1= C.IDClasificacion AND IDGrupo=1
LEFT  JOIN dbo.invClasificacion d ON A.Clasif2= d.IDClasificacion AND D.IDGrupo=2
LEFT  JOIN dbo.invClasificacion e ON A.Clasif3= e.IDClasificacion AND e.IDGrupo=3
LEFT  JOIN dbo.invClasificacion f ON A.Clasif4= f.IDClasificacion AND f.IDGrupo=4
LEFT  JOIN dbo.invClasificacion g ON A.Clasif5= g.IDClasificacion AND g.IDGrupo=5
LEFT  JOIN dbo.invClasificacion h ON A.Clasif6= h.IDClasificacion AND h.IDGrupo=6
WHERE IDProducto  NOT IN (SELECT IDProducto  FROM dbo.invArticuloProveedor WHERE IDProveedor=@IDProveedor) AND A.Activo=1
AND (A.Clasif1 = @IDClasificacion1 OR @IDClasificacion1=-1) AND (A.Clasif2 = @IDClasificacion2  OR @IDClasificacion2 = -1) AND 
(A.Clasif3=@IDClasificacion3 OR @IDClasificacion3=-1) AND (A.Clasif4 = @IDClasificacion4 OR @IDClasificacion4=-1) AND 
(A.Clasif5 = @IDClasificacion5 OR @IDClasificacion5=-1)  AND (A.Clasif6=@IDClasificacion6 OR @IDClasificacion6=-1)


GO

CREATE  PROCEDURE dbo.invGetSolicitudCompra_OrdenCompra(@IDSolicitud AS INT,@IDOrdenCompra AS INT,@IDProducto AS BIGINT)
AS 
SELECT  IDSolicitud ,IDOrdenCompra ,IDProducto ,Cantidad CantOrdenada ,Usuario ,Fecha  FROM dbo.invSolicitudOrdenCompra 
WHERE (IDSolicitud= @IDSolicitud OR @IDSolicitud=-1) AND (IDOrdenCompra = @IDOrdenCompra OR @IDOrdenCompra= -1) AND (IDProducto = @IDProducto OR  @IDProducto = -1) 

GO

CREATE PROCEDURE dbo.invGetGlobalPais(@IDPais AS INT)
AS 
SELECT IDPais,Descr,Activo  FROM dbo.globalPais
WHERE (IDPais = @IDPais OR @IDPais = -1) AND Activo=1

GO

INSERT INTO dbo.invEstadoSolicitud( IDEstado, Descr, Activo ) VALUES(0,'INICIAL',1)
GO
INSERT INTO dbo.invEstadoSolicitud( IDEstado, Descr, Activo ) VALUES(1,'APROBADA',1)
GO
INSERT INTO dbo.invEstadoSolicitud( IDEstado, Descr, Activo ) VALUES(2,'RECHAZADA',1)
GO	
INSERT INTO dbo.invEstadoSolicitud( IDEstado, Descr, Activo ) VALUES(3,'ASIGNADA',1)


GO 

INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (0,'INICIAL',1)

GO 


INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (1,'APROBADO',1)

go 

INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (2,'CONFIRMADA',1)

GO 


INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (3,'BACKORDER',1)

go

INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (4,'CANCELADA',1)

go

INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (5,'RECIBIDA',1)

GO


INSERT INTO dbo.invEstadoOrdenCompra( IDEstadoOrden, Descr, Activo )
VALUES  (5,'RECIBIDA',1)

GO

CREATE  PROCEDURE dbo.invGetProveedor(@IDProveedor AS INT,@Nombre NVARCHAR(250))
AS	
SELECT  IDProveedor ,
        Nombre ,
        IDRuc ,
        Activo  FROM dbo.cppProveedor WHERE (IDProveedor = @IDProveedor OR @IDProveedor=-1) AND (Nombre LIKE '%' + @Nombre + '%' OR @Nombre ='*')
        
GO


CREATE   PROCEDURE dbo.invGetSolicitudesByProveedor (@IDProveedor AS int	, @IDSolicitudDesde AS INT,@IDSolicitudHasta AS INT, @FechaSolicitudDesde AS DATETIME, @FechaSolicitudHasta AS DATETIME, 
				@FechaRequeridaDesde AS DATETIME, @FechaRequeridaHasta AS DATETIME,@IDClasif1 AS INT,@IDClasif2 AS INT,@IDClasif3 AS INT,
				@IDClasif4 AS INT,@IDClasif5 AS INT,@IDClasif6 AS INT,@IDProducto AS BIGINT)
AS

IF (@IDSolicitudDesde =-1)
	SET @IDSolicitudDesde =  (SELECT isnull(MIN(IDSolicitud),0) FROM dbo.invSolicitudCompra)

IF (@IDSolicitudHasta =-1)
	SET @IDSolicitudHasta =  (SELECT isnull(Max(IDSolicitud),0) FROM dbo.invSolicitudCompra)

SELECT A.IDSolicitud,A.Fecha,A.FechaRequerida,B.IDProducto,P.Descr DescrProducto,ISNULL(SUM(B.Cantidad),0) - isnull(SUM(OS.Cantidad),0) Cantidad,
  0 CantOrdenada,B.Comentario
 FROM dbo.invSolicitudCompra A
INNER JOIN dbo.invSolicitudCompraDetalle B ON A.IDSolicitud = B.IDSolicitud
INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
INNER JOIN dbo.invArticuloProveedor D ON P.IDProducto = D.IDProducto
LEFT JOIN dbo.invSolicitudOrdenCompra OS ON B.IDProducto=OS.IDProducto AND B.IDSolicitud=OS.IDSolicitud
WHERE (A.IDSolicitud BETWEEN @IDSolicitudDesde AND @IDSolicitudHasta) AND (FechaRequerida  BETWEEN @FechaRequeridaDesde AND @FechaRequeridaHasta)
AND (P.Clasif1 = @IDClasif1 OR @IDClasif1=-1) AND  (P.Clasif2 = @IDClasif2 OR @IDClasif2=-1) AND  (P.Clasif3 = @IDClasif3 OR @IDClasif3=-1) 
AND  (P.Clasif4 = @IDClasif4 OR @IDClasif4=-1) AND  (P.Clasif5 = @IDClasif5 OR @IDClasif5=-1) AND  (P.Clasif6 = @IDClasif6 OR @IDClasif6=-1) AND (B.IDProducto = @IDProducto OR @IDProducto=-1)
AND D.IDProveedor = @IDProveedor  AND A.IDEstado  IN (1) 
GROUP BY A.IDSolicitud,A.Fecha,A.FechaRequerida,B.IDProducto,P.Descr,B.Comentario
HAVING  ISNULL(SUM(B.Cantidad),0) - isnull(SUM(OS.Cantidad),0) >0


GO



CREATE  PROCEDURE dbo.invUpdateSolicitudCompra_OrdenCompra (@Operacion AS NVARCHAR(1),@IDSolicitud AS INT,@IDOrdenCompra AS INT,@IDProducto AS BIGINT,
					@Cantidad AS Decimal(28,4),@Usuario AS NVARCHAR(50), @Fecha AS DATETIME)
AS 
IF (@Operacion='I')
BEGIN
	INSERT INTO dbo.invSolicitudOrdenCompra( IDSolicitud ,IDOrdenCompra ,IDProducto ,Cantidad ,Usuario ,Fecha)
	VALUES (@IDSolicitud,@IDOrdenCompra,@IDProducto,@Cantidad,@Usuario,@Fecha)		
END
IF (@Operacion='D')
	DELETE FROM dbo.invSolicitudOrdenCompra WHERE (IDProducto=@IDProducto OR @IDProducto=-1) AND (IDSolicitud=@IDSolicitud OR @IDSolicitud=-1) AND IDOrdenCompra =@IDOrdenCompra


GO

SELECT * FROM dbo.invEstadoOrdenCompra
GO

CREATE PROCEDURE dbo.invConfirmarOrdenCompra @IDOrdenCompra  AS INT
AS

UPDATE dbo.invOrdenCompra SET IDEstado=2
WHERE IDOrdenCompra = @IDOrdenCompra

SELECT IDProducto,IDBodega,Cantidad INTO #tmpProducto FROM dbo.invOrdenCompra A
INNER JOIN dbo.invOrdenCompraDetalle B ON A.IDOrdenCompra = B.IDOrdenCompra
WHERE A.IDOrdenCompra=@IDOrdenCompra

INSERT INTO dbo.invExistenciaBodega( IDBodega ,IDProducto ,IDLote ,Existencia ,Reservada ,Transito)
SELECT A.IDBodega,A.IDProducto,0,0,0,0  FROM #tmpProducto A
LEFT JOIN dbo.invExistenciaBodega B ON A.IDBodega = B.IDBodega AND A.IDProducto = B.IDProducto
WHERE B.IDProducto IS NULL


UPDATE  B SET B.Transito = B.Transito + A.Cantidad  FROM #tmpProducto A
INNER JOIN dbo.invExistenciaBodega B ON A.IDBodega = B.IDBodega AND A.IDProducto = B.IDProducto


DROP TABLE #tmpProducto


GO

CREATE PROCEDURE dbo.invDesConfirmarOrdenCompra @IDOrdenCompra  AS INT
AS

UPDATE dbo.invOrdenCompra SET IDEstado=1
WHERE IDOrdenCompra = @IDOrdenCompra

SELECT IDProducto,IDBodega,Cantidad INTO #tmpProducto FROM dbo.invOrdenCompra A
INNER JOIN dbo.invOrdenCompraDetalle B ON A.IDOrdenCompra = B.IDOrdenCompra
WHERE A.IDOrdenCompra=@IDOrdenCompra


UPDATE  B SET B.Transito = B.Transito - A.Cantidad  FROM #tmpProducto A
INNER JOIN dbo.invExistenciaBodega B ON A.IDBodega = B.IDBodega AND A.IDProducto = B.IDProducto

DROP TABLE #tmpProducto


GO


CREATE PROCEDURE dbo.invCancelarOrdenCompra @IDOrdenCompra  AS INT
AS

UPDATE dbo.invOrdenCompra SET IDEstado=4
WHERE IDOrdenCompra = @IDOrdenCompra

SELECT IDProducto,IDBodega,Cantidad INTO #tmpProducto FROM dbo.invOrdenCompra A
INNER JOIN dbo.invOrdenCompraDetalle B ON A.IDOrdenCompra = B.IDOrdenCompra
WHERE A.IDOrdenCompra=@IDOrdenCompra


UPDATE  B SET B.Transito = B.Transito - A.Cantidad  FROM #tmpProducto A
INNER JOIN dbo.invExistenciaBodega B ON A.IDBodega = B.IDBodega AND A.IDProducto = B.IDProducto

DROP TABLE #tmpProducto


GO


--CREATE PROCEDURE dbo.invCreateEmbarqueFromOrdenCompra( @IDOrdenCompra AS INT,@Usuario AS NVARCHAR(50))
--AS 

--DECLARE @IDEmbarque AS INT

--SET @IDEmbarque = (SELECT ISNULL(MAX(IDEmbarque),0) FROM dbo.invEmbarque)

--INSERT INTO dbo.invEmbarque( IDEmbarque ,Embarque ,Fecha ,FechaEmbarque ,Asiento ,IDBodega ,IDProveedor ,IDOrdenCompra ,IDDocumentoCP ,TipoCambio ,Usuario ,CreateDate ,CreatedBy ,RecordDate ,UpdateBy)
--SELECT  @IDEmbarque,'--',GETDATE(),GETDATE() ,null,IDBodega ,IDProveedor ,IDOrdenCompra,-1 ,0 TC, ,Usuario ,UsuarioCreaEmbarque ,FechaCreaEmbarque , Usuario,GETDATE(),Usuario,GETDATE(),Usuario 
--FROM dbo.invOrdenCompra
--WHERE IDOrdenCompra=@IDOrdenCompra

--INSERT INTO dbo.invEmbarqueDetalle( IDEmbarque ,IDProducto ,IDLote ,Cantidad ,CantidadAceptada ,CantidadRechazada ,Comentario)

--SELECT  @IDEmbarque ,IDProducto ,Cantidad ,CantidadAceptada ,CantidadRechazada ,PrecioUnitario ,Impuesto ,PorcDesc ,MontoDesc ,Estado ,Comentario  
--FROM dbo.invOrdenCompraDetalle WHERE IDOrdenCompra=@IDOrdenCompra

CREATE   PROCEDURE dbo.invGetEmbarqueByID(@IDEmbarque AS INT,@IDOrdenCompra AS INT)
AS 
IF (@IDEmbarque =-1)
BEGIN
SELECT  -1 IDEmbarque ,'--' Embarque ,GETDATE() Fecha ,B.FechaRequerida FechaEmbarque ,NULL Asiento ,B.IDBodega ,D.Descr DescrBodega,B.IDProveedor ,C.Nombre NombreProveedor,B.IDOrdenCompra,B.OrdenCompra ,-1 IDDocumentoCP ,
			0 TipoCambio 
	FROM dbo.invEmbarque A
	RIGHT  JOIN dbo.invOrdenCompra B ON A.IDOrdenCompra = B.IDOrdenCompra
	LEFT  JOIN dbo.cppProveedor C ON B.IDProveedor=C.IDProveedor
	LEFT  JOIN dbo.invBodega D ON B.IDBodega=D.IDBodega
	
END 
ELSE	
BEGIN	
	SELECT  A.IDEmbarque ,A.Embarque ,A.Fecha ,A.FechaEmbarque ,A.Asiento ,A.IDBodega ,D.Descr DescrBodega,B.IDProveedor ,C.Nombre NombreProveedor,A.IDOrdenCompra,B.OrdenCompra ,A.IDDocumentoCP ,
			A.TipoCambio ,A.Usuario ,A.CreateDate ,A.CreatedBy ,A.RecordDate ,A.UpdateBy  
	FROM dbo.invEmbarque A
	LEFT  JOIN dbo.invOrdenCompra B ON A.IDOrdenCompra = B.IDOrdenCompra
	LEFT  JOIN dbo.cppProveedor C ON B.IDProveedor=C.IDProveedor
	LEFT  JOIN dbo.invBodega D ON A.IDBodega=D.IDBodega
	WHERE (A.IDEmbarque =@IDEmbarque OR @IDEmbarque=-1) AND (a.IDOrdenCompra=@IDOrdenCompra or @IDOrdenCompra=-1)
END

GO

CREATE   PROCEDURE dbo.invUpdateProveedor(@Operacion AS  nvarchar(1), @IDProveedor AS int	 OUTPUT,@Nombre AS nvarchar(250),@IDRuc AS int	,
@Activo AS bit	,@Alias nvarchar(50), @IDPais AS int,@IDMoneda AS int,@FechaIngreso AS datetime,@Contacto AS nvarchar(50), @Telefono nvarchar(50), 
@IDImpuesto AS int,@IDCategoria AS int	,@IDCondicionPago AS int	,@PorcDescuento AS decimal(28,4), @PorcInteresMora AS decimal(28,4),
@Email AS nvarchar(50),@Direccion AS nvarchar(500),@MultiMoneda bit ,@PagosCongelados bit ,@IsLocal bit ,@TipoContribuyente int )
AS 
IF (@Operacion ='I') 
BEGIN
	SET @IDProveedor = (SELECT  ISNULL(MAX(IDProveedor),0) + 1 FROM dbo.cppProveedor )
	INSERT INTO dbo.cppProveedor(IDProveedor, Nombre ,IDRuc ,Activo ,Alias ,IDPais ,IDMoneda ,FechaIngreso ,Contacto ,Telefono ,IDImpuesto ,IDCategoria ,IDCondicionPago ,
	          PorcDesc ,PorcInteresMora ,email ,Direccion,MultiMoneda,PagosCongelados,IsLocal,TipoContribuyente)
	VALUES  (@IDProveedor, @Nombre ,@IDRuc,@Activo,@Alias,@IDPais,@IDMoneda,@FechaIngreso,@Contacto,@Telefono,@IDImpuesto,@IDCategoria,@IDCondicionPago,@PorcDescuento,@PorcInteresMora,@Email, @Direccion,@MultiMoneda,@PagosCongelados,@IsLocal,@TipoContribuyente)

END
IF (@Operacion='U')
BEGIN
	UPDATE dbo.cppProveedor SET Nombre = @Nombre ,Alias = @Alias, IDPais = @IDPais, IDMoneda= @IDMoneda,FechaIngreso=@FechaIngreso,
				Contacto =@Contacto,Telefono = @Telefono, IDImpuesto = @IDImpuesto, IDCategoria = @IDCategoria,IDCondicionPago =@IDCondicionPago,
				PorcDesc = @PorcDescuento, PorcInteresMora = @PorcInteresMora, email = @Email, Direccion = @Direccion, MultiMoneda = @MultiMoneda, 
				PagosCongelados = @PagosCongelados, IsLocal = @IsLocal,TipoContribuyente =@TipoContribuyente
	WHERE IDProveedor = @IDProveedor
END
IF (@Operacion='D') 
BEGIN
	DELETE FROM dbo.cppProveedor WHERE IDProveedor =@IDProveedor
END


GO

CREATE   PROCEDURE dbo.cppGetProveedor(@IDProveedor AS INT,@Nombre AS NVARCHAR(20), @IDCategoria AS INT)
AS 
SELECT    IDProveedor ,A.Nombre ,A.Alias ,Contacto ,A.IDRuc ,B.RUC,Telefono ,A.IDImpuesto, C.Descr DescrImpuesto ,a.IDCategoria ,D.Descr DescrCategoria,A.IDPais ,E.Descr Pais,a.IDMoneda ,F.Descr Moneda,A.IDCondicionPago ,G.Descr DescrCondicionPago,
        FechaIngreso ,PorcDesc ,PorcInteresMora ,Email ,Direccion ,A.Activo ,MultiMoneda ,PagosCongelados ,IsLocal ,TipoContribuyente
FROM dbo.cppProveedor A
LEFT JOIN dbo.cbRUC B ON A.IDRuc=B.IDRuc
LEFT JOIN dbo.globalImpuesto C ON A.IDImpuesto = C.IDImpuesto
LEFT JOIN dbo.cppCategoriaProveedor D ON A.IDCategoria = D.IDCategoria
LEFT JOIN dbo.globalPais E ON A.IDPais = E.IDPais
LEFT JOIN dbo.globalMoneda F ON F.IDMoneda = A.IDMoneda
LEFT JOIN dbo.cppCondicionPago G ON A.IDCondicionPago=G.IDCondicionPago
WHERE (IDProveedor = @IDProveedor OR @IDProveedor = -1) AND (A.Nombre LIKE '%'+@Nombre+'%' OR @Nombre='*') AND (a.IDCategoria = @IDCategoria OR @IDCategoria=-1)


GO

CREATE PROCEDURE  dbo.cppUpdateCategoriaPoveedor  @Operacion AS NVARCHAR(1), @IDCategoria AS INT OUTPUT, @Descr AS NVARCHAR(255), @Ctr_CXP AS INT, @Cta_CXP BIGINT,
	@Ctr_Letra_CXP INT, @Cta_Letra_CXP BIGINT,@Ctr_ProntoPago_CXP INT, @Cta_ProntoPago_CXP BIGINT,@Ctr_Comision_CXP INT, @Cta_Comision_CxP BIGINT,
	@Ctr_Anticipos_CXP INT, @Cta_Anticipos_CXP BIGINT, @Ctr_CierreDebitos_CXP INT, @Cta_CierreDebitos_CXP BIGINT, @Ctr_Impuestos_CXP INT, @Cta_Impuestos_CXP BIGINT,
	@Activo AS INT
AS
IF (@Operacion='I')
BEGIN	
	SET @IDCategoria = (SELECT isnull(MAX(IDCategoria),0) + 1  FROM dbo.cppCategoriaProveedor)
	INSERT INTO dbo.cppCategoriaProveedor(IDCategoria,Descr,Ctr_CXP,Cta_CXP,Ctr_Letra_CXP,Cta_Letra_CXP,Ctr_ProntoPago_CXP,Cta_ProntoPago_CXP,
						Ctr_Comision_CXP,Cta_Comision_CXP,Ctr_Anticipos_CXP,Cta_Anticipos_CXP,Ctr_CierreDebitos_CXP,Cta_CierreDebitos_CXP,Ctr_Impuestos_CXP,
						Cta_Impuestos_CXP, Activo)
	VALUES (@IDCategoria,@Descr,@Ctr_CXP,@Cta_CXP,@Ctr_Letra_CXP,@Cta_Letra_CXP,@Ctr_ProntoPago_CXP,@Cta_ProntoPago_CXP,
						@Ctr_Comision_CXP,@Cta_Comision_CXP,@Ctr_Anticipos_CXP,@Cta_Anticipos_CXP,@Ctr_CierreDebitos_CXP,@Cta_CierreDebitos_CXP,@Ctr_Impuestos_CXP,
						@Cta_Impuestos_CXP, @Activo)
END	
IF (@Operacion='U') 
BEGIN
	UPDATE dbo.cppCategoriaProveedor SET Descr = @Descr,Ctr_CXP = @Ctr_CXP,Cta_CXP = @Cta_CXP,Ctr_Letra_CXP= @Ctr_Letra_CXP,Cta_Letra_CXP= @Cta_Letra_CXP,
						Ctr_ProntoPago_CXP = @Ctr_ProntoPago_CXP,Cta_ProntoPago_CXP = @Cta_ProntoPago_CXP,Ctr_Comision_CXP =	@Ctr_Comision_CXP, Cta_Comision_CXP = @Cta_Comision_CXP,
						Ctr_Anticipos_CXP = @Ctr_Anticipos_CXP,Cta_Anticipos_CXP = @Cta_Anticipos_CXP,Ctr_CierreDebitos_CXP = @Ctr_CierreDebitos_CXP, Cta_CierreDebitos_CXP =@Cta_CierreDebitos_CXP,
						Ctr_Impuestos_CXP =@Ctr_Impuestos_CXP,Cta_Impuestos_CXP=	@Cta_Impuestos_CXP, Activo =@Activo
	WHERE IDCategoria = @IDCategoria					
END	
IF (@Operacion='D')
BEGIN	
	DELETE FROM dbo.ccpCatgoriaProveedor WHERE IDCategoria= @IDCategoria
END	

GO

CREATE   PROCEDURE dbo.cppGetCategoriaProveedor(@IDCategoria INT, @Descripcion AS NVARCHAR(250))
AS 
SELECT  IDCategoria ,Descr ,Ctr_CXP ,Cta_CXP ,  Ctr_Letra_CXP ,Cta_Letra_CXP ,Ctr_ProntoPago_CXP ,Cta_ProntoPago_CXP ,Ctr_Comision_CXP ,
        Cta_Comision_CXP ,Ctr_Anticipos_CXP ,Cta_Anticipos_CXP ,Ctr_CierreDebitos_CXP ,Cta_CierreDebitos_CXP ,Ctr_Impuestos_CXP ,Cta_Impuestos_CxP ,
        Activo  FROM dbo.cppCategoriaProveedor
WHERE ( IDCategoria=@IDCategoria OR @IDCategoria =-1) AND (Descr LIKE '%' + @Descripcion+ '%' OR @Descripcion ='*')

GO

CREATE PROCEDURE dbo.globalTipoImpuesto(@IDImpuesto AS int) 
AS 
SELECT  IDImpuesto ,
        Descr ,
        Porc ,
        Activo  FROM dbo.globalImpuesto
WHERE (IDImpuesto = @IDImpuesto OR @IDImpuesto=-1)

GO

CREATE PROCEDURE dbo.invGetParametrosCompra
AS 
SELECT  IDParametro ,
        IDConsecSolicitud ,
        IDConsecOrdenCompra ,
        IDConsecEmbarque ,
        IDConsecDevolucion ,
        CantLineasOrdenCompra ,
        IDBodegaDefault ,
        IDTipoCambio ,
        CantDecimalesPrecio ,
        CantDecimalesCantidad ,
        IDTipoAsientoContable ,
        IDPaquete ,
        CtaTransitoLocal ,
        CtrTransitoLocal ,
        CtaTransitoExterior ,
        CtrTransitoExterior ,
        AplicaAutomaticamenteAsiento ,
        CanEditAsiento ,
        CanViewAsiento  FROM dbo.invParametrosCompra
        
        
        GO
        
        
CREATE  PROCEDURE dbo.invUpdateParametrosCompra ( @IDConsecSolicitud INT, @IDConsecOrdeCompra INT, @IDConsecEmbarque INT, @IDConsecDevolucion INT, @CantLineasOrdenCompra INT, @IDBodegaDefault int,
	@IDTipoCambio NVARCHAR(20), @CantDecimalesPrecio int, @CantDecimalesCantidad int, @IDTipoAsientoContable NVARCHAR(2), @IDPaquete INT, @CtaTransitoLocal bigint, @CtrTransitoLocal bigint, @CtaTransitoExterior bigint, @CtrTransitoExterior bigint,
	@AplicaAutomaticamenteAsiento bit, @CanEditAsiento bit, @CanViewAsiento bit )
AS 
UPDATE dbo.invParametrosCompra SET IDConsecSolicitud = @IDConsecSolicitud,IDConsecOrdenCompra=@IDConsecOrdeCompra , IDConsecEmbarque=@IDConsecEmbarque,IDConsecDevolucion= @IDConsecDevolucion,CantLineasOrdenCompra = @CantLineasOrdenCompra, 
	IDBodegaDefault  = @IDBodegaDefault, IDTipoCambio= @IDTipoCambio, CantDecimalesPrecio= @CantDecimalesPrecio,CantDecimalesCantidad= @CantDecimalesCantidad, IDTipoAsientoContable = @IDTipoAsientoContable, IDPaquete = @IDPaquete,  CtaTransitoLocal = @CtaTransitoLocal,
	CtrTransitoLocal  = @CtrTransitoLocal, CtaTransitoExterior = @CtaTransitoExterior, AplicaAutomaticamenteAsiento =@AplicaAutomaticamenteAsiento, CanEditAsiento = @CanEditAsiento, CanViewAsiento=@CanViewAsiento
	WHERE IDParametro=1
	
GO


CREATE PROCEDURE dbo.globalGetConsecutivos(@IDConsecutivo INT, @Prefijo AS NVARCHAR(3))
AS 
SELECT  IDConsecutivo ,Descr ,Prefijo ,Consecutivo ,Documento ,Activo  
FROM dbo.globalconsecutivos
WHERE (IDConsecutivo = @IDConsecutivo OR @IDConsecutivo =-1) AND (Prefijo = @Prefijo OR @Prefijo = '*')

GO 


CREATE  PROCEDURE dbo.invGetParametroCompra(@Parametro AS NVARCHAR(200)) 
AS 
--SET @Paremetro='IDConsecSolicitud'
DECLARE @SQL AS NVARCHAR(1000) 
SET @SQL=  'SELECT '+ @Parametro +' FROM dbo.invParametrosCompra WHERE IDParametro=1'

EXEC (@SQL)


GO


CREATE  PROCEDURE dbo.invUpdateCantRecibidaOrdenCompra(@IDOrdenCompra INT,@IDProducto AS INT, @Cantidad AS  DECIMAL(28,4))
AS 
UPDATE dbo.invOrdenCompraDetalle SET CantidadAceptada = @Cantidad 
WHERE IDOrdenCompra =@IDOrdenCompra AND (IDProducto = @IDProducto OR @IDProducto=-1)

GO



CREATE  PROCEDURE dbo.invCreaPaqueteEmbarque(@Modulo AS NVARCHAR(4),@IDDocumento AS INT,@Usuario AS NVARCHAR(50),@IDTransaccion AS BIGINT OUTPUT )
AS 
/*SET @Modulo = 'COM'
SET @IDDocumento= 1
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


IF (@Modulo = 'CO')
BEGIN
	--//Leer parametros de configuración
	SELECT TOP	1 @IDPaquete = IDPaquete, @TipoCambioCont= IDTipoCambio  FROM dbo.invParametrosCompra
	
	IF (@IDPaquete IS NULL)
	BEGIN
		RAISERROR ( 'GENERACIÓN DEL DOCUMENTO: Revise los parametros de Compra, si el paquete de inventario se encuentra establecido', 16, 1) ;
		return		
	END
	
	SELECT @FechaDocumento = A.Fecha, @Referencia = 'Emabarque: ' + A.Embarque  + ', Orden de Compra: ' + B.OrdenCompra, @Documento = a.Embarque
	 FROM dbo.invEmbarque A
	 INNER JOIN dbo.invOrdenCompra B ON  A.IDOrdenCompra = B.IDOrdenCompra
	  WHERE A.IDEmbarque =@IDDocumento 
	 
	--//Cargar el Tipo de Cambio Contabilidad
	SELECT @TipoCambio = dbo.globalGetTipoCambio(@FechaDocumento,@TipoCambioCont) 
	  
	--//Crear la cabecera del Documento  
	EXEC  dbo.invUpdateDocumentoInv  @Operacion = N'I', -- nvarchar(1)
	    @IDTransaccion = @IDTransaccion OUTPUT, -- int
	    @ModuloOrigen = N'CO', -- nvarchar(4)
	    @IDPaquete =@IDPaquete, -- int
	    @Fecha = @FechaDocumento, -- datetime
	    @Usuario =@Usuario, -- nvarchar(20)
	    @Referencia = @Referencia, -- nvarchar(250)
	    @Documento = @Documento OUTPUT, -- nvarchar(250)
	    @Aplicado = 1, -- bit
	    @EsTraslado = 0, -- bit
	    @IDTraslado = -1 -- int
	
	--//Obtener las transacciones asociadas al Paquete.
	SELECT @IDTipoTran =IDTipoTran, @Factor = Factor,@Naturaleza = Naturaleza, @Transaccion=Transaccion  
	FROM dbo.globalTipoTran WHERE  Transaccion = (SELECT Transaccion  FROM dbo.invPaquete WHERE IDPaquete=@IDPaquete) 

	--//Insertar el detalle del documento
	
	
	INSERT INTO dbo.invTransaccionLinea( IDTransaccion ,IDProducto ,IDLote ,IDTipoTran ,IDBodega ,IDTraslado , Naturaleza ,Factor ,Cantidad ,CostoUntLocal ,CostoUntDolar ,PrecioUntLocal ,PrecioUntDolar ,Transaccion ,TipoCambio ,Aplicado)
	SELECT @IDTransaccion, A.IDProducto,A.IDLote,@IDTipoTran,O.IDBodega,-1 IDTranslado,@Naturaleza,@Factor ,A.Cantidad, P.CostoPromLocal,CostoPromDolar,CASE WHEN O.IDMoneda=1 THEN OD.PrecioUnitario ELSE OD.PrecioUnitario * @TipoCambio END PrecioUnitarioLocal, CASE WHEN O.IDMoneda=1 THEN OD.PrecioUnitario / @TipoCambio ELSE Od.PrecioUnitario END PrecioUnitarioDolar,@Transaccion, @TipoCambio, 0 Aplicado
	FROM dbo.invEmbarqueDetalle A
	INNER JOIN dbo.invProducto P ON A.IDProducto=P.IDProducto
	INNER JOIN dbo.invOrdenCompra O ON A.IDEmbarque=O.IDEmbarque
	INNER JOIN dbo.invOrdenCompraDetalle OD ON O.IDOrdenCompra = OD.IDOrdenCompra AND OD.IDProducto=A.IDProducto
	WHERE A.IDEmbarque=@IDDocumento

	UPDATE dbo.invEmbarque SET DocumentoInv =  @Documento

END  

GO




CREATE  PROCEDURE dbo.invGeneraAsientoContableEmbarque @Modulo AS NVARCHAR(4), @IDDocumento AS INT,@Usuario AS NVARCHAR(50),@Asiento AS NVARCHAR(20) OUTPUT 
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
DECLARE @CtrTransitoExterior AS  BIGINT
DECLARE @CtaTransitoExterior AS BIGINT

SELECT @CtrTransitoExterior = CtrTransitoExterior, @CtaTransitoExterior = CtaTransitoExterior  
FROM dbo.invParametrosCompra WHERE IDParametro=1



--//Seleccionar el documento y Fechas
SELECT @Documento = Embarque,@FechaDocumento = Fecha,@TipoCambio = TipoCambio
FROM dbo.invEmbarque WHERE IDEmbarque=@IDDocumento


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

IF ( @CtaTransitoExterior IS NULL )
BEGIN
	RAISERROR('VERIFIQUE LOS PARAMETROS DE FACTURA:  La cuenta de transito no es definida',16,1);
	RETURN
END

if (@CtrTransitoExterior IS NULL)
BEGIN	
	RAISERROR('VERIFIQUE LOS PARAMETROS DE FACTURA: El centro de costo de transito no es definida',16,1);
	RETURN
END

 EXEC [dbo].[globalGetNextConsecutivo] 'CO', @Asiento OUTPUT
	
INSERT INTO dbo.cntAsiento( IDEjercicio ,Periodo ,Asiento ,Tipo ,Fecha ,FechaHora ,Createdby ,CreateDate ,
						Mayorizadoby ,MayorizadoDate ,Anuladoby ,AnuladoDate ,Concepto ,Mayorizado ,Anulado ,TipoCambio ,ModuloFuente ,CuadreTemporal)
VALUES (	@IDEjercicio,@Periodo	,@Asiento,'CO',@FechaDocumento,GETDATE(),@Usuario,GETDATE(),NULL,NULL,NULL,NULL,'Embarque: ' + @Documento,0,0,@TipoCambio,'CO',0)		
						

SELECT B.IDProducto,A.IDBodega,SUM(B.Cantidad) Cantidad,CASE WHEN C.IDMoneda=1 THEN  D.PrecioUnitario ELSE D.PrecioUnitario * @TipoCambio END PrecioLocal, 
			CASE WHEN C.IDMoneda=1 THEN  D.PrecioUnitario / @TipoCambio ELSE d.PrecioUnitario END PrecioDolar ,P.CostoPromLocal,P.CostoPromDolar,CC.CtaInventario, CC.CtrInventario  INTO #tmpEmbarque
FROM dbo.invEmbarque A
INNER JOIN dbo.invEmbarqueDetalle B ON A.IDEmbarque = B.IDEmbarque
INNER JOIN dbo.invOrdenCompra C ON A.IDEmbarque = C.IDEmbarque
INNER JOIN dbo.invOrdenCompraDetalle D ON C.IDOrdenCompra = D.IDOrdenCompra AND B.IDProducto = D.IDProducto 
INNER JOIN dbo.invProducto P ON B.IDProducto = P.IDProducto
INNER JOIN dbo.invCuentaContable CC ON P.IDCuentaContable = CC.IDCuenta
WHERE A.IDEmbarque = @IDDocumento
GROUP BY B.IDProducto,A.IDBodega,C.IDMoneda,PrecioUnitario,CostoPromDolar,CostoPromLocal,CC.CtaInventario, CC.CtrInventario 

SET @Rows = @@ROWCOUNT



DECLARE @IDProducto AS INT,@IDBodega AS INT,@IDLote AS INT,@Cantidad AS DECIMAL(28,4),@PrecioLocal AS DECIMAL(28,4),@PrecioDolar AS DECIMAL(28,4),
@CostoPromDolar AS DECIMAL(28,4),@CostoPromLocal AS DECIMAL(28,4),@CtrInventario AS BIGINT, @CtaInventario AS BIGINT

ALTER TABLE #tmpEmbarque ADD	 ID INT IDENTITY(1,1)

DECLARE @i AS INT
DECLARE @Linea AS INT
SET @i=1
SET @Linea = 0

WHILE (@Rows>=@i)
BEGIN
	SELECT @IDProducto = IDProducto, @IDBodega = IDBodega, @Cantidad = Cantidad, @PrecioLocal = PrecioLocal, @PrecioDolar = PrecioDolar,
	@CostoPromDolar = CostoPromDolar,@CostoPromLocal = CostoPromLocal,
	@CtaInventario = CtaInventario,@CtrInventario = CtrInventario
	  FROM #tmpEmbarque WHERE ID =@Rows
	  
	 
	 --//cuenta de Transito
	SET @Linea = @Linea + 1 
	INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
	VALUES (@Asiento,@Linea,@CtrTransitoExterior,@CtaTransitoExterior,'Transito: Compra de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, 0,@CostoPromLocal * @Cantidad,@Documento,GETDATE())
	
	 --//Inventario
	SET @Linea = @Linea + 1 
	INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
	VALUES (@Asiento,@Linea,@CtrInventario,@CtaInventario,'Inventario: compra de ' + CAST(@IDProducto AS NVARCHAR(20)) + 'CI-' + @Documento, @CostoPromLocal * @Cantidad,0,@Documento,GETDATE())

	
	SET @i = @i +1
END

UPDATE dbo.invEmbarque SET  Asiento = @Asiento WHERE IDEmbarque = @IDDocumento

DROP TABLE #tmpEmbarque

GO




