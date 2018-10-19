


ALTER TABLE  DBO.globalMoneda  ADD Nacional bit default 1
go

Update dbo.globalMoneda set Nacional = 0 where MONEDA = 'DOLAR'
go
Update dbo.globalMoneda set Nacional = 1 where MONEDA = 'LOCAL'
go

Create Table dbo.fafTipoVendedor ( IDTipo int not null, Descr nvarchar(250), Activo bit default 1 )
go

Alter table  dbo.fafTipoVendedor add constraint pkTipo primary key (IDTipo)
go

insert fafTipoVendedor ( idtipo, descr, activo )
values (1, 'Normal', 1)
go

insert fafTipoVendedor ( idtipo, descr, activo )
values (2, 'Televenta', 1)
go

insert fafTipoVendedor ( idtipo, descr, activo )
values (3, 'Visitador Medico', 1)
go

insert fafTipoVendedor ( idtipo, descr, activo )
values (4, 'Promotota', 1)
go
-- update fafvendedor set telefono = '4545', celular = '4545', cedula = '145', email = '444'
CREATE TABLE [fafVendedor] (
	[IDVendedor] [int] NOT NULL ,
	[Nombre] [nvarchar] (255)  NOT NULL ,
	[IDTipo] int not null ,
	[Activo] [bit]  default 1,
	Direccion nvarchar(255), 
	Telefono nvarchar(25),
	Celular nvarchar(25),
	Cedula nvarchar(25),
	email nvarchar(250),
	CONSTRAINT [pkfafVendedor] PRIMARY KEY  CLUSTERED 
	(
		[IDVendedor]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

alter table dbo.fafVendedor add constraint fkTipoVend foreign key (IDTipo) references dbo.fafTipoVendedor (IDTipo)
go

Create Table dbo.globalDepto (IDDepto int not null, Descr nvarchar(255), Activo bit default 1 )
go

alter table dbo.globalDepto  add constraint pkDepto primary key (IDDepto)
go

Create Table dbo.globalZona (IDZona int not null, Descr nvarchar(255), Activo bit default 1 )
go

alter table dbo.globalZona  add constraint pkZona primary key (IDZona)
go

Create Table dbo.globalSubZona (IDZona int not null, IDSubZona int not null,  Descr nvarchar(255), Activo bit default 1 )
go

alter table  dbo.globalSubZona  add constraint pkSubZona primary key (IDZona, IDSubZona)
go

alter table  dbo.globalSubZona  add constraint fkZonaSubZona foreign key (IDZona) references dbo.globalZona(IDZona)
go

Create Table dbo.globalMunicipio (IDDepto int not null, IDMunicipio int not null, Descr nvarchar(255), Activo bit default 1 )
go
alter table dbo.globalMunicipio  add constraint pkMuni primary key (IDDepto, IDMunicipio)
go


Create Table dbo.fafCategoriaCliente (IDCategoria int not null, Descr nvarchar(255), Activo bit default 1)
go

alter table dbo.fafCategoriaCliente add constraint pkCatCliente primary key (IDCategoria)
go

Create Table dbo.fafTipoCliente ( IDTipo int not null, Descr nvarchar(255), Activo bit default 1)
go
alter table dbo.fafTipoCliente add constraint pkTipoCliente primary key (IDTipo)
go

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (1, 'ESPECIAL', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (2, 'NORMAL', 1)
GO
insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (3, 'EXCELENTE', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (4, 'OTRO', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (5, 'BUENO', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (6, 'REGULAR', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (7, 'MALO', 1)
GO

insert dbo.fafTipoCliente (IDTipo, Descr, Activo )
values (8, 'INSTITUCIONES', 1)
GO


--drop table dbo.dbo.ccfPlazo alter table dbo.ccfClientes add foto image
Create Table dbo.ccfPlazo ( Plazo int not null, Descr nvarchar(200),  Activo bit )
go
alter table dbo.ccfPlazo add constraint pkPlazo primary key (Plazo)
go
-- alter table  dbo.ccfClientes add Cedula nvarchar(20)

Create table dbo.fafNivelPrecio ( IDNivel int not null, Descr nvarchar(250), IDMoneda int not null, Activo bit default 1)
go

alter table dbo.fafNivelPrecio  add constraint pkfafNivelPrecio primary key (IDNivel)
go

alter table dbo.fafNivelPrecio add constraint fkfafNivelMoneda foreign key (IDMoneda) references dbo.globalMoneda (IDMoneda)
go


--drop table dbo.ccfClientes  alter table dbo.ccfClientes add  Credito bit, 
Create Table dbo.ccfClientes ( IDCliente int not null,   Nombre nvarchar(255), EsFarmacia bit default 0, IDTipo int not null,
Farmacia nvarchar(255), IDCategoria int not null,  IDVendedor int not null, IDDepto int not null, IDMunicipio int not null, 
IDZona int not null, IDSubZona int not null, RUC NVARCHAR(50),  LimiteCredito decimal(28,4) default 0,
IDBodega int not null, Direccion nvarchar(255),  Telefono nvarchar(25), Celular nvarchar(25),
Dueno nvarchar(255), FechaIngreso smalldatetime, 
dateInsert datetime,
userInsert nvarchar(20) ,
dateUpdate datetime,
userUpdate nvarchar(20),
PorcInteres decimal(8,2) default 0,
Plazo int not null,
email nvarchar(250),
pweb  nvarchar(250),
foto image null,
Activo bit default 1,
Cedula nvarchar(20),
IDNivel int not null,
IDMoneda int not null,
EditaNombre bit default 0,
Credito bit default 1
 )
go

alter table dbo.ccfClientes add constraint pkCliente primary key (IDCliente)
go

alter table dbo.ccfClientes add constraint fkClienteDepto foreign key (IDDepto) references dbo.globalDepto (IDDepto)
go

alter table dbo.ccfClientes add constraint fkClienteMunicipio foreign key (IDDepto, IDMunicipio) references dbo.globalMunicipio (IDDepto, IDMunicipio)
go
--alter table dbo.ccfClientes drop constraint fkClienteTipo
alter table dbo.ccfClientes add constraint fkClienteTipo foreign key (IDTipo) references dbo.fafTipoCliente (IDTipo)
go

alter table dbo.ccfClientes add constraint fkClienteNivel foreign key (IDNivel) references dbo.fafNivelPrecio (IDNivel)
go

alter table dbo.ccfClientes add constraint fkClienteVendedor foreign key (IDVendedor) references dbo.fafVendedor (IDVendedor)
go

alter table dbo.ccfClientes add constraint fkClienteCat foreign key (IDCategoria) references dbo.fafCategoriaCliente (IDCategoria)
go

alter table dbo.ccfClientes add constraint fkClienteZona foreign key (IDZona) references dbo.globalZona (IDZona)
go

alter table dbo.ccfClientes add constraint fkClienteBodega foreign key (IDBodega) references dbo.invBodega (IDBodega)
go

alter table dbo.ccfClientes add constraint fkClienteZonaSubZona foreign key (IDZona, IDSubZona) references dbo.globalSubZona (IDZona, IDSubZona)
go

alter table dbo.ccfClientes add constraint fkClientePlazo foreign key (Plazo) references dbo.ccfPlazo (Plazo)
go

CREATE TRIGGER trg_UpdateDatoCliente
ON dbo.ccfClientes
AFTER UPDATE
AS
    UPDATE dbo.ccfClientes
    SET dateUpdate = GETDATE()
    WHERE IDCliente IN (SELECT DISTINCT IDCliente FROM Inserted)

go

CREATE TRIGGER trg_InsertCliente
ON dbo.ccfClientes
FOR INSERT
AS
    UPDATE dbo.ccfClientes
    SET dateInsert = GETDATE()
    WHERE IDCliente IN (SELECT DISTINCT IDCliente FROM Inserted)

go

-- drop table dbo.fafTipoEntrega
Create Table dbo.fafTipoEntrega ( IDTipoEntrega int not null DEFAULT 0 , Descr nvarchar(250), Activo bit default 1 )
go

alter table dbo.fafTipoEntrega add constraint pkTipoEntrega primary key (IDTipoEntrega)
go

insert dbo.fafTipoEntrega (IDTipoEntrega, Descr )
values (1, 'CEDETSA')
GO

insert dbo.fafTipoEntrega (IDTipoEntrega, Descr )
values (2, 'CORREO')
GO

insert dbo.fafTipoEntrega (IDTipoEntrega, Descr )
values (3, 'MENSAJERO')
GO

insert dbo.fafTipoEntrega (IDTipoEntrega, Descr )
values (4, 'PERSONAL')
GO

Create Table dbo.fafTipoFactura ( IDTipo smallint not null, Descr nvarchar(100), Activo bit default 1)
go

alter table dbo.fafTipoFactura add constraint pkTipoFactura primary key (IDTipo)
go

insert dbo.fafTipoFactura ( IDTipo, Descr )
values (1, 'CONTADO')
GO

insert dbo.fafTipoFactura ( IDTipo, Descr )
values (2, 'CREDITO')
GO


Create Table dbo.fafEstadoPedido (Estado nvarchar(1) not null default 'C', Descr nvarchar(50), Activo bit default 1)
go
alter table dbo.fafEstadoPedido add constraint pkEstadoPedido primary key (Estado)
go
Insert dbo.fafEstadoPedido (Estado, Descr )
values ('I', 'INICIADO')
GO
Insert dbo.fafEstadoPedido (Estado, Descr )
values ('A', 'APROBADO')
GO
Insert dbo.fafEstadoPedido (Estado, Descr )
values ('C', 'CANCELADO')
GO
Insert dbo.fafEstadoPedido (Estado, Descr )
values ('F', 'FACTURADO')
GO
Insert dbo.fafEstadoPedido (Estado, Descr )
values ('N', 'ANULADO')
GO


-- drop table dbo.fafpedido alter table dbo.[fafPedido] add IDPlazo int not null
CREATE TABLE dbo.[fafPedido] (	
	[IDPedido] [int] not NULL  Identity(1,1),
	[IDBodega] [int] NOT NULL ,
	Pedido int not null, 
	[IDCliente] [int] NOT NULL ,
	IDTipoEntrega int not null,
	[IDVendedor] [int] NOT NULL ,
	IDDepto int not null,
	IDMunicipio int not null,
	IDZona int not null,
	IDSubZona int not null, 
	Fecha date NOT NULL ,	
	FechaRequerida date,
	[Anulado] [bit] NULL  DEFAULT (0),
	[EsTeleventa] [bit] NULL  DEFAULT (0),
	Estado nvarchar(1) not null default 'C',
	IDFactura bigint null,
	IDNivel int not null,
	IDMoneda int not null,
	IDPlazo int not null,
	TipoCambio decimal (28,4) default 0,	
	dateInsert datetime,
	dateUpdate datetime,
	Nota nvarchar(255)
)
go

alter table dbo.fafPedido add constraint pkPedido primary key (IDPedido)
go

alter table dbo.fafPedido add constraint ukPedido unique (IDBodega, Pedido)
go

alter table dbo.fafPedido add CONSTRAINT [fkfafPedidoMoneda] FOREIGN KEY 
	(
		[IDMoneda]
	) REFERENCES dbo.[globalMoneda] (
		[IDMoneda]
	)
go

alter table dbo.[fafPedido] add CONSTRAINT [fkfafPedidoNivel] FOREIGN KEY 
	(
		[IDNivel]
	) REFERENCES dbo.[fafNivelPrecio] (
		[IDNivel]
	)
go

--alter table dbo.[fafPedido] add constraint fkfafPedidoPlazo foreign key (IDPlazo) references dbo.ccfPlazo (Plazo)
--go

alter table dbo.fafPedido add constraint fkPedidoest foreign key (Estado) references dbo.fafEstadoPedido (Estado)
go

alter table dbo.fafPedido add constraint fkPedidoPlazo foreign key (IDPlazo) references dbo.ccfPlazo (Plazo)
go

alter table dbo.fafPedido add constraint fkPedidoCliente foreign key (IDCliente) references dbo.ccfClientes (IDCliente)
go

alter table dbo.fafPedido add constraint fkPedidoEntrega foreign key (IDTipoEntrega) references dbo.fafTipoEntrega (IDTipoEntrega)
go


alter table dbo.fafPedido add constraint fkPedidoDepto foreign key (IDDepto) references dbo.globalDepto (IDDepto)
go

alter table dbo.fafPedido add constraint fkPedidoMunicipio foreign key (IDDepto, IDMunicipio) references dbo.globalMunicipio (IDDepto, IDMunicipio)
go


alter table dbo.fafPedido add constraint fkPedidoZona foreign key (IDZona) references dbo.globalZona (IDZona)
go
alter table dbo.fafPedido add constraint fkPedidoZonaSubZona foreign key (IDZona, IDSubZona) references dbo.globalSubZona (IDZona, IDSubZona)
go


CREATE TRIGGER trg_UpdatePedido
ON dbo.fafPedido
AFTER UPDATE
AS
    UPDATE dbo.fafPedido
    SET dateUpdate = GETDATE()
    WHERE IDPedido IN (SELECT DISTINCT IDPedido FROM Inserted)

go

CREATE TRIGGER trg_InsertPedido
ON dbo.fafPedido
FOR INSERT
AS
    UPDATE dbo.fafPedido
    SET dateInsert = GETDATE()
    WHERE IDPedido IN (SELECT DISTINCT IDPedido FROM Inserted)

go



--
--alter table dbo.fafPedidoProd add Bonifica bit default 0 not null, BonifConProd bit default 0, 
--CantBonificada  decimal (28,4) default 0,

--alter table dbo.fafPedidoProd add SubTotalFinalLocal decimal(28,4) default 0,SubTotalFinalDolar decimal(28,4) default 0
--DescuentoEspecialLocal decimal(28,4) default 0 , DescuentoEspecialDolar decimal(28,4) default 0 

Create Table dbo.fafPedidoProd ( 
	IDPedidoProd bigint identity(1,1) not null,
	IDPedido int not null,
	IDBodega int not null,
	IDProducto bigint not null,
	Cantidad decimal(28,4) default 0,
	PrecioLocal decimal(28,4) default 0,
	PrecioDolar decimal(28,4) default 0,	
	SubTotalLocal decimal(28,4) default 0,
	SubTotalDolar decimal(28,4) default 0,
	SubTotalFinalLocal decimal(28,4) default 0,SubTotalFinalDolar decimal(28,4) default 0,	
	ImpuestoLocal decimal(28,4) default 0,
	ImpuestoDolar decimal(28,4) default 0,	
	CantFacturada int not null default 0,
	Bonifica bit default 0 not null, BonifConProd bit default 0, CantBonificada  decimal (28,4) default 0,
	DescuentoLocal decimal(28,4) default 0, DescuentoDolar decimal(28,4) default 0, PorcDescuentoEsp decimal(28,4) default 0,
	DescuentoEspecialLocal decimal(28,4) default 0, DescuentoEspecialDolar decimal(28,4) default 0,
		
	backOrder bit default 0
	
	)
	go

alter table dbo.fafPedidoProd add constraint pkPedidoLinea primary key (IDPedidoProd)
go

alter table dbo.fafPedidoProd add constraint ukPedidoLinea UNIQUE (IDPedido, IDBodega, IDProducto)
go

alter table dbo.fafPedidoProd add constraint fkPedidoLineaPed foreign key (IDPedido) references dbo.fafPedido (IDPedido)
go

alter table dbo.fafPedidoProd add constraint fkPedidoLineaBod foreign key (IDBodega) references dbo.invBodega (IDBodega)
go

alter table dbo.fafPedidoProd add constraint fkPedidoLineaProd foreign key (IDProducto) references dbo.invProducto (IDProducto)
go

Create Table dbo.globalConsecMask ( Codigo nvarchar(20) not null, Descr nvarchar(250), Longitud int,
Mascara nvarchar(25) not null, Consecutivo nvarchar(25) not null,
Activo bit default 1, IDModulo int  not null)
go
alter table dbo.globalConsecMask add constraint pkConsecMask primary key (Codigo)
go

alter table dbo.globalConsecMask add constraint fkConsecMaskMod  foreign key (IDModulo) references dbo.secModulo
go


Create Function dbo.getMascaraFromConsecMask ( 
		 @Codigo nvarchar(25)
	) 
returns nvarchar(25)
as
begin
declare @Mascara as nvarchar(25)

Select @Mascara = Mascara
from dbo.globalConsecMask 
where Codigo  = @Codigo 
return @Mascara
end
go

--SELECT  dbo.getNextConsecMask ('F')
Create Function dbo.getNextConsecMask ( 
		 @Codigo nvarchar(25)
	) 
returns nvarchar(25)
as
begin
declare @Mascara as nvarchar(25), @Valor nvarchar(25)
declare @i int, @inic int, @fin int, @index int,  @Caracter nvarchar(1)

Select @Mascara = Mascara, @Valor = Consecutivo 
from dbo.globalConsecMask 
where Codigo  = @Codigo and Activo = 1

Declare @table  table(ID int identity(1,1) not null,Tipo nvarchar(1), inic int, fin int, Long int,  valor nvarchar(25)
, PRIMARY KEY (ID))

set @i = 1
set @index = 1
While @index <= LEN(@Mascara)
begin
	set @i = @index 
	set @Caracter = substring(@Mascara, @i,1) 
	if @Caracter = 'N'
	begin
		set @inic = @i
		while @i <= LEN(@Mascara) and @Caracter = 'N'
		begin
			if substring(@Mascara, @i,1) = 'N'
				set @i = @i + 1
			
			set @fin = @i - 1
		
			set @Caracter = substring(@Mascara, @i,1) 
		end
		insert @table(Tipo, inic, fin, Long,  valor )
		values ('N', @inic, @fin , ((@fin-@inic)+1), SUBSTRING (@Valor , @inic, (@fin-@inic)+1) )
	end
	else -- es Alfanumeric
	begin
	set @inic = @i
		while @i <= LEN(@Mascara) and @Caracter = 'A'
		begin
				if substring(@Mascara, @i,1) = 'A'
					set @i = @i + 1
				
			set @fin = @i -1 
			set @Caracter = substring(@Mascara, @i,1) 
		end
		insert @table(Tipo, inic, fin, Long,  valor )
		values ('A', @inic, @fin , ((@fin-@inic)+1), SUBSTRING (@Valor , @inic, (@fin-@inic)+1) )	
	end
	set @index = @i
end
declare @Count int , @Result nvarchar(25), @ID int, @Tipo nvarchar(1), @Long int, @CantN int, @Ni int
set @CantN = (Select COUNT(*) from @table where Tipo = 'N' )
set @Count = ( Select COUNT(*) from @table )
if @Count >0 
begin
set @i = 1
set @Result = ''
set @Ni = 0

	while @i <= @Count 
	begin
		Select @Id = ID, @Tipo = Tipo, @inic = inic, @fin = fin, 
		@Long = Long, @Valor = Valor
		from @table 
		where ID = @i
		if @Tipo = 'A'
			set @Result = @Result + @Valor 
		if @Tipo = 'N' 
			begin
				set @Ni = @Ni + 1
				if @Ni = @CantN 
					set @Result = @Result + right( Replicate('0', @Long ) + cast(CAST(@Valor as int) + 1 as nvarchar(20)) , @Long )
				else
					set @Result = @Result + @Valor 
			end
		set @i = @i + 1
	end
end
Return @Result 
end
go

create Procedure dbo.globalgetConsecMask ( @Codigo nvarchar(20))
as
set nocount on
Select C.Codigo, C.Descr , C.Longitud , C.Mascara , C.Consecutivo , C.IDModulo , M.descr DescrModulo
from dbo.globalConsecMask C inner join dbo.secModulo M
on C.IDModulo = M.IDModulo 
where (Codigo = @Codigo or @Codigo = '*')
go


CREATE Procedure [dbo].[globalUpdateglobalConsecMask] @Operacion nvarchar(1),
@Codigo nvarchar(20) , @Descr nvarchar(250), @Longitud int,
@Mascara nvarchar(25) , @Consecutivo nvarchar(25) ,
@Activo bit , @IDModulo int  
as
set nocount on
if @Operacion = 'I'
	insert dbo.globalConsecMask (Codigo, Descr, Longitud, Mascara, Consecutivo, IDModulo)
	values (@Codigo, @Descr, @Longitud, @Mascara, @Consecutivo, @IDModulo)
if @Operacion = 'D'
	Delete From dbo.globalConsecMask Where Codigo = @Codigo 
if @Operacion = 'U'
	Update dbo.globalConsecMask set Descr = @Descr , Longitud = @Longitud , Mascara = @Mascara, Consecutivo = @Consecutivo , IDModulo = @IDModulo, Activo = @Activo  
	Where Codigo = @Codigo 

go

alter table dbo.invBodega add CodigoConsecMask  nvarchar(20)
go

alter table dbo.invBodega add constraint  fkCodigoConsecMask foreign key (CodigoConsecMask) references dbo.globalConsecMask (Codigo)
go



-- drop table dbo.[fafFACTURA]
CREATE TABLE dbo.[fafFACTURA] (	
	[IDFactura] bigint NOT NULL identity(1,1) ,
	[IDBodega] [int] NOT NULL ,
	[Factura] [nvarchar] (20) not null ,
	IDTipo smallint not null, 
	[IDCliente] [int] NOT NULL ,
	Nombre nvarchar(250), 
	[IDVendedor] [int] NOT NULL ,
	IDDepto int not null, 
	IDMunicipio int not null,
	IDZona int not null,
	IDSubZona int not null, 
	IDTipoEntrega int not null,
	[Fecha] [datetime] NOT NULL ,	
	[Anulada] [bit] NULL  DEFAULT (0),
	[EsTeleventa] [bit] NULL  DEFAULT (0),
	[IDPedido] [int]    DEFAULT (null),	
	IDNivel int not null,
	IDMoneda int not null,
	IDPlazo int not null,
	TipoCambio decimal(28,4) default 0,
	CodConsecutivo nvarchar(20) not null,
	Mensaje nvarchar(255),
	dateInsert datetime,	
	dateUpdate datetime
)
go

alter table dbo.[fafFACTURA] add CONSTRAINT [pkfafFACTURA] PRIMARY KEY  CLUSTERED 
	([IDFactura])  
go

alter table dbo.[fafFACTURA] add CONSTRAINT [ukfafFACTURA] UNIQUE    
	([IDBodega], Factura)  
go


alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaBodega] FOREIGN KEY 
	(
		[IDBodega]
	) REFERENCES dbo.[invBODEGA] (
		[IDBodega]
	)
go

alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaConsec] FOREIGN KEY 
	(
		CodConsecutivo
	) REFERENCES dbo.globalConsecMask (
		Codigo
	)
go

alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaMoneda] FOREIGN KEY 
	(
		[IDMoneda]
	) REFERENCES dbo.[globalMoneda] (
		[IDMoneda]
	)
go

alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaNivel] FOREIGN KEY 
	(
		[IDNivel]
	) REFERENCES dbo.[fafNivelPrecio] (
		[IDNivel]
	)
go
	
alter table dbo.[fafFACTURA] add CONSTRAINT	 [fkfafFacturaVendedor] FOREIGN KEY 
	(
		[IDVendedor]
	) REFERENCES [fafVendedor] (
		[IDVendedor]
	)

GO

alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaTipoEntrega] FOREIGN KEY 
	(
		[IDTipoEntrega]
	) REFERENCES dbo.[fafTipoEntrega] (
		[IDTipoEntrega]
	)
go

alter table dbo.[fafFACTURA] add CONSTRAINT [fkfafFacturaTipo] FOREIGN KEY 
	(
		[IDTipo]
	) REFERENCES dbo.[fafTipoFactura] (
		[IDTipo]
	)
go


alter table dbo.[fafFACTURA] add constraint fkFacturaPedido foreign key (IDPedido) references dbo.fafPedido (IDPedido)
go

alter table dbo.[fafFACTURA] add constraint fkFacturaPlazo foreign key (IDPlazo) references dbo.ccfPlazo (Plazo)
go

alter table dbo.[fafFACTURA] add constraint fkFacturaCliente foreign key (IDCliente) references dbo.ccfClientes (IDCliente)
go

alter table dbo.fafFactura add constraint fkFacturaDepto foreign key (IDDepto) references dbo.globalDepto (IDDepto)
go

alter table dbo.fafFactura add constraint fkFacturaMunicipio foreign key (IDDepto, IDMunicipio) references dbo.globalMunicipio (IDDepto, IDMunicipio)
go


alter table dbo.fafFactura add constraint fkFacturaZona foreign key (IDZona) references dbo.globalZona (IDZona)
go
alter table dbo.fafFactura add constraint fkFacturaZonaSubZona foreign key (IDZona, IDSubZona) references dbo.globalSubZona (IDZona, IDSubZona)
go


CREATE TRIGGER trg_UpdateFactura
ON dbo.fafFactura
AFTER UPDATE
AS
    UPDATE dbo.fafFactura
    SET dateUpdate = GETDATE()
    WHERE IDFactura  IN (SELECT DISTINCT IDFactura FROM Inserted)
go

CREATE TRIGGER trg_InsertFactura
ON dbo.fafFactura
FOR INSERT
AS
    UPDATE dbo.fafFactura
    SET dateInsert = GETDATE()
    WHERE IDFactura IN (SELECT DISTINCT IDFactura FROM Inserted)

go

-- drop alter table dbo.fafFacturaProd add PorcImpuesto decimal(28,4) default 0,SubTotalFinalDolar decimal(28,4) default 0
CREATE TABLE dbo.fafFacturaProd ( 
IDFacturaProd bigint not null identity(1,1), 
IDFactura bigint not null,	IDBodega int not null, IDProducto bigint not null,  
Bonifica bit default 0 not null, Requerido decimal (28,4) default 0, Bono decimal (28,4) default 0,
BonifConProd bit default 0,CantBonificada  decimal (28,4) default 0 ,
CantFacturada decimal(28,4) default 0,  Cantidad as (CantFacturada + CantBonificada), 
PrecioLocal decimal(28,4) default 0,PrecioDolar decimal(28,4) default 0, 
CostoLocal decimal(28,4) default 0,CostoDolar decimal(28,4) default 0,
DescuentoLocal decimal(28,4) default 0, DescuentoDolar decimal(28,4) default 0, PorcDescuentoEsp decimal(28,4) default 0,
DescuentoEspecialLocal decimal(28,4) default 0, DescuentoEspecialDolar decimal(28,4) default 0,
SubTotalLocal decimal(28,4) default 0,SubTotalDolar decimal(28,4) default 0,
SubTotalFinalLocal decimal(28,4) default 0,SubTotalFinalDolar decimal(28,4) default 0,
ImpuestoLocal decimal(28,4) default 0,  ImpuestoDolar decimal(28,4) default 0,
Factor int default 0, PorcImpuesto decimal(28,4) default 0
 )
go
alter table  dbo.fafFacturaProd add constraint pkFacturaLinea primary key (IDFacturaProd)
go

alter table  dbo.fafFacturaProd add constraint ukFacturaLinea UNIQUE (IDFactura, IDBodega, IDProducto )
go

alter table  dbo.fafFacturaProd add constraint fkFacturaLinea foreign key (IDFactura) references dbo.fafFactura (IDFactura)
go

alter table  dbo.fafFacturaProd add constraint fkFacturaLineaBod foreign key (IDBodega) references dbo.invBodega (IDBodega)
go


--drop table dbo.fafFacturaProdLote

Create Table dbo.fafFacturaProdLote ( IDFactProdLote bigint not null identity(1,1), IDFacturaProd bigint not null,
IDLote int not null,   
CantBonificada  decimal (28,4) default 0 ,
CantFacturada decimal(28,4) default 0,  Cantidad as (CantFacturada + CantBonificada)   )
go

alter table  dbo.fafFacturaProdLote add constraint pkFacturaLineaLote primary key (IDFactProdLote)
go
alter table  dbo.fafFacturaProdLote add constraint ukFacturaLineaLote UNIQUE ( IDFacturaProd,IDLote)
go

alter table dbo.fafFacturaProdLote add constraint fkfafFacturaLineaLoteLin foreign key ( IDFacturaProd) references dbo.fafFacturaProd (IDFacturaProd )
go

--drop table  dbo.fafTablaBonificacion
Create Table dbo.fafTablaBonificacion ( IDTabla int  identity(1,1) not null , IDProveedor int not null, IDProducto bigint not null, 
Requerido decimal(28,2) default 0, Bono decimal(28,2) default 0, CantBonifProv decimal(28,2) default 0,
CantBonifDist decimal(28,2) default 0, Desde date, Hasta date )
go
alter table dbo.fafTablaBonificacion add constraint pkTablaBonif primary key (IDTabla) 
go

alter table dbo.fafTablaBonificacion add constraint ukTablaBonif UNIQUE (IDProveedor, IDProducto, Requerido, Bono)
go
alter table dbo.fafTablaBonificacion add constraint fkTablaBonifProv foreign key (IDProveedor) references dbo.cppProveedor (IDProveedor)
go
alter table dbo.fafTablaBonificacion add constraint fkTablaBonifProd foreign key (IDProducto) references dbo.invProducto (IDProducto)
go

alter table dbo.fafTablaBonificacion add constraint ukTablaBonifProd UNIQUE (IDProveedor, IDProducto, Requerido, Bono) 
go

Create Table dbo.fafPromociones ( IDPromocion int  identity(1,1) not null , IDProveedor int not null, IDProducto bigint not null, 
PorcDesc decimal(28,2) default 0, Desde date, Hasta date )
go
alter table dbo.fafPromociones add constraint pkPromociones primary key (IDPromocion) 
go
alter table dbo.fafPromociones add constraint fkPromProv foreign key (IDProveedor) references dbo.cppProveedor (IDProveedor)
go
alter table dbo.fafPromociones add constraint fkPromProd foreign key (IDProducto) references dbo.invProducto (IDProducto)
go


--drop procedure fafGetMunipios
-- exec dbo.fafGetMasterMunicipios 6,1
Create procedure dbo.fafGetMasterMunicipios( @IDDepto int=-1, @SoloActivos smallint = 1 )
-- -1 indica que son todos los registros tanto para deptos como para municipios
as 
set nocount on 
Select D.IDDepto CodMaster, D.Descr DescrMaster, M.IDMunicipio Codigo, M.Descr , M.Activo 
From dbo.globalDepto D inner join  dbo.globalMunicipio M 
on D.IDDepto = M.IDDepto 
Where (M.IDDepto = @IDDepto or @IDDepto = -1) and (M.Activo = @SoloActivos or @SoloActivos=-1 )
go

Create procedure dbo.fafGetMasterSubZonas( @IDZona int=-1, @SoloActivos smallint = 1 )
-- -1 indica que son todos los registros tanto para deptos como para municipios
as 
set nocount on 
Select D.IDZona CodMaster, D.Descr DescrMaster, M.IDZona Codigo, M.Descr , M.Activo 
From dbo.globalZona D inner join  dbo.globalSubZona M 
on D.IDZona = M.IDZona 
Where (M.IDZona = @IDZona or @IDZona = -1) and (M.Activo = @SoloActivos or @SoloActivos=-1 )
go



-- drop procedure dbo.fafUpdateCliente  Exec dbo.fafUpdateCliente 'D',5,' '
Create Procedure dbo.fafUpdateCliente @Operacion nvarchar(1),
			@IDCliente int
           ,@Nombre nvarchar(255)
           ,@EsFarmacia bit = null
           ,@IDTipo int = null
           ,@Farmacia nvarchar(255) = null
           ,@IDCategoria int = null
           ,@IDVendedor int = null
           ,@IDDepto int = null
           ,@IDMunicipio int = null
           ,@IDZona int = null
           ,@IDSubZona int = null
           ,@RUC nvarchar(50) = null
           ,@LimiteCredito decimal(28,4) = null
           ,@IDBodega int = null
           ,@Direccion nvarchar(255) = null
           ,@Telefono nvarchar(25) = null
           ,@Celular nvarchar(25) = null
           ,@Dueno nvarchar(255) = null
           
           ,@PorcInteres decimal(8,2) = null
           ,@Plazo int = null
           ,@email nvarchar(250) = null
           ,@pweb nvarchar(250) = null
           ,@Activo bit = null
           ,@Cedula nvarchar(20) = null
           ,@IDNivel int  = null
           ,@IDMoneda int  = null
           ,@EditaNombre bit = null
           ,@Credito bit = null           
           ,@Foto image  = null

as

if @Operacion = 'I'
begin
INSERT INTO [dbo].[ccfClientes]
           ([IDCliente]
           ,[Nombre]
           ,[EsFarmacia]
           ,[IDTipo]
           ,[Farmacia]
           ,[IDCategoria]
           ,[IDVendedor]
           ,[IDDepto]
           ,[IDMunicipio]
           ,[IDZona]
           ,[IDSubZona]
           ,[RUC]
           ,[LimiteCredito]
           ,[IDBodega]
           ,[Direccion]
           ,[Telefono]
           ,[Celular]
           ,[Dueno]
		   , FechaIngreso 

           ,[PorcInteres]
           ,[Plazo]
           ,[email]
           ,[pweb]
           ,[Activo]
           ,[Cedula]
           ,IDNivel
           ,IDMoneda
           ,Foto
           ,EditaNombre
           ,Credito )
     VALUES
           (@IDCliente 
           ,@Nombre 
           ,@EsFarmacia 
           ,@IDTipo 
           ,@Farmacia 
           ,@IDCategoria 
           ,@IDVendedor 
           ,@IDDepto 
           ,@IDMunicipio 
           ,@IDZona 
           ,@IDSubZona 
           ,@RUC 
           ,@LimiteCredito 
           ,@IDBodega 
           ,@Direccion 
           ,@Telefono 
           ,@Celular 
           ,@Dueno 
           ,GETDATE() 

           ,@PorcInteres 
           ,@Plazo 
           ,@email 
           ,@pweb 
           ,@Activo 
           ,@Cedula 
           ,@IDNivel
           ,@IDMoneda
           , @Foto 
           , @EditaNombre 
           , @Credito 
          )
 end
 if @Operacion  = 'U'
 begin
 Update dbo.ccfClientes set Nombre =  @Nombre 
           ,EsFarmacia = @EsFarmacia 
           ,IDTipo = @IDTipo 
           ,Farmacia = @Farmacia 
           ,IDCategoria = @IDCategoria 
           ,IDVendedor = @IDVendedor 
           ,IDDepto = @IDDepto 
           ,IDMunicipio = @IDMunicipio 
           ,IDZona = @IDZona 
           ,IDSubZona = @IDSubZona 
           ,IDNivel = @IDNivel 
           ,IDMoneda = @IDMoneda 
           ,RUC = @RUC  
           ,LimiteCredito = @LimiteCredito 
           ,IDBodega = @IDBodega 
           ,Direccion = @Direccion 
           ,Telefono = @Telefono 
           ,Celular = @Celular
           ,Dueno = @Dueno 

           ,PorcInteres = @PorcInteres 
           ,Plazo = @Plazo 
           ,email = @email 
           ,pweb = @pweb 
           ,Activo = @Activo 
           ,Cedula = @Cedula 
           ,Foto = @Foto 
           ,EditaNombre = @EditaNombre 
           ,Credito = @Credito
  Where IDCliente = @IDCliente 
  end  
If @Operacion = 'D'           
	Delete from dbo.ccfClientes where IDCliente = @IDCliente 
GO


-- drop procedure fafgetClientes exec fafgetClientes 0 select * from ccfclientes where foto is null
CREATE  Procedure dbo.fafgetClientes(@IDCliente int, @IDSucursal int = null )
as
set nocount on 
if @IDSucursal is null
	set @IDSucursal = 0
SELECT    C.IDCliente ,C.Nombre   ,C.EsFarmacia  ,C.IDTipo , T. Descr DescrTipo, C.Farmacia ,
			C.FechaIngreso, C.IDCategoria , Cat.Descr DescrCategoria, C.IDVendedor , V.Nombre  NombreVendedor,
			C.IDDepto ,D.Descr DescrDepto,  C.IDMunicipio , M.Descr DescrMunicipio,
			C.IDZona ,Z.Descr DescrZona, C.IDSubZona, sz.Descr DescrSubZona,
			C.IDNivel, P.Descr DescrNivel, C.IDMoneda , N.Descr DescrMoneda,
			C.RUC ,C.LimiteCredito ,C.IDBodega IDSucursal , B.Descr DescrSucursal, C.Direccion ,C.Telefono,
            C.Celular  ,C.Dueno , FechaIngreso ,C.foto  ,C.PorcInteres, 
            C.Plazo ,C.email ,C.pweb ,C.Activo ,C.Cedula, C.EditaNombre, C.Credito 
FROM dbo.ccfClientes C left join dbo.fafTipoCliente T on C.IDTipo = T.IDTipo 
left join dbo.fafCategoriaCliente Cat on C.IDCategoria = Cat.IDCategoria 
left join dbo.fafVendedor V on C.IDVendedor  = V.IDVendedor 
left join dbo.globalDepto D on C.IDDepto   = D.IDDepto 
left join dbo.globalMunicipio M on C.IDDepto   = M.IDDepto and C.IDMunicipio = M.IDMunicipio 
left join dbo.globalZona Z on C.IDZona    = Z.IDZona 
left join dbo.globalSubZona SZ on C.IDZona     = sz.IDZona  and C.IDSubZona  = sz.IDSubZona  
left join dbo.invBodega B on C.IDBodega    = B.IDBodega  
left join dbo.fafNivelPrecio P on C.IDNivel    = P.IDNivel 
left join dbo.globalmoneda N on C.IDMoneda    = N.IDMoneda 
WHERE (C.IDBodega  = @IDSucursal or @IDSucursal = 0) and (C.IDCliente = @IDCliente or @IDCliente = 0 )
go

--drop procedure exec dbo.fafgetVendedores 3
create Procedure dbo.fafgetVendedores ( @IDVendedor int )
as
set nocount on
Select V.IDVendedor, V.Nombre , V.Telefono,  V.Cedula, v.Celular, v.Direccion, v.IDTipo, T.Descr DescrTipo, V.email,  V.Activo 
from dbo.fafVendedor V inner join dbo.fafTipoVendedor T
on V.IDTipo = T.IDTipo 
where IDVendedor = @IDVendedor
go

Create Procedure fafUpdateVendedor @Operacion nvarchar(1),
	@IDVendedor int ,
	@Nombre nvarchar(255) ,
	@IDTipo int = NULL,
	@Direccion nvarchar(255) = NULL,
	@Telefono nvarchar(25) = NULL,
	@Celular nvarchar(25) =NULL,
	@Cedula nvarchar(25) =NULL,
	@email nvarchar(250) =NULL,
	@Activo bit = NULL
as 
set nocount on
if @Operacion = 'I'
begin
INSERT INTO [dbo].[fafVendedor] (
IDVendedor, Nombre, IDTipo, Direccion , Telefono , Celular, Cedula , email, Activo )
values (	@IDVendedor, @Nombre, @IDTipo, @Direccion , @Telefono , @Celular, @Cedula , @email, @Activo)
end
 if @Operacion  = 'U'
 begin
 Update dbo.fafVendedor set Nombre =  @Nombre , IDTipo = @IDTipo, Direccion= @Direccion, Telefono = @Telefono,
 Celular = @Celular , email = @email, Activo = @Activo 	
 where IDVendedor = @IDVendedor 
 end
 if @Operacion  = 'D'
 begin
	Delete From dbo.fafVendedor where IDVendedor = @IDVEndedor 
 end
 go


Create Function dbo.fafVendedorTeleVenta ( @IDVendedor int )
RETURNS int   
AS
begin
declare @Result as smallint  
if exists (
Select IDTipo 
from dbo.fafTipoVendedor  
where Descr like 'Tele%Venta%' 
and IDTipo in ( Select IDTipo  from dbo.fafVendedor where IDVendedor = @IDVendedor )
) 
	set @Result = 1
else
	set @Result = 0
Return @Result 
end
go
-- select dbo.fafGetNextPedido (1)
Create Function dbo.fafGetNextPedido ( @IDBodega int )
returns int
as
begin
Declare @Next int
	set @Next = isnull((select max(Pedido) from dbo.fafPedido Where IDBodega = @IDBodega ),0)
	set @Next = @Next + 1
	return @Next
end
go

-- delete from dbo.fafpedido
-- Exec dbo.fafUpdatePedido 'I',0,1,1,2,1,'07/04/18 23:10:54','07/04/18 23:10:54',0,0,'I',0,'dsd',1
--Exec dbo.fafUpdatePedido" & vbCrLf & "'I',0,1,1,7,1,'20181001','20181001',0,0,'C',0,'',1
Create Procedure dbo.fafUpdatePedido @Operacion nvarchar(1),@IDPedido int,@IDBodega int ,
	@Pedido int ,@IDCliente int ,@IDVendedor int ,	@Fecha datetime ,@FechaRequerida datetime ,
	@Anulado bit ,	@EsTeleventa bit ,	@Estado nvarchar(1) ,	@IDFactura bigint ,	@Nota nvarchar(255) ,
	@IDTipoEntrega int, @IDNivel int, @IDMoneda int, @TipoCambio decimal(28,4), @IDPlazo int
as
set nocount on 
--set @FechaRequerida = CONVERT(VARCHAR(23), @FechaRequerida, 110)
--set @Fecha = CONVERT(VARCHAR(23), @Fecha, 110)

if @Operacion = 'I'
begin 
declare 	@IDDepto int ,	@IDMunicipio int ,	@IDZona int ,	@IDSubZona int 

	Select @IDDepto = IDDepto , @IDMunicipio = IDMunicipio, @IDZona = IDZona , @IDSubZona = IDSubZona ,
	@IDNivel = IDNivel, @IDMoneda = IDMoneda, @IDPlazo = Plazo
	from dbo.ccfClientes 
	where IDCliente = @IDCliente 
	
	insert dbo.fafPedido ([IDBodega]  ,[Pedido]  ,[IDCliente]
		  ,[IDVendedor]  ,[IDDepto]  ,[IDMunicipio]  ,[IDZona]  ,[IDSubZona]  ,[Fecha]
		  ,[FechaRequerida]  ,[Anulado]  ,[EsTeleventa] ,[Estado]  ,[IDFactura] ,[Nota]
		  ,[IDTipoEntrega], IDNivel , IDMoneda, TipoCambio , IDPlazo
			)
	values (@IDBodega  ,@Pedido  ,@IDCliente
		  ,@IDVendedor  ,@IDDepto  ,@IDMunicipio  ,@IDZona  ,@IDSubZona  ,@Fecha
		  ,@FechaRequerida  ,@Anulado  ,@EsTeleventa ,@Estado  ,@IDFactura ,@Nota
		  ,@IDTipoEntrega, @IDNivel, @IDMoneda, @TipoCambio, @IDPlazo
			)
end
if @Operacion = 'U'
begin 
		update dbo.fafPedido set FechaRequerida = @FechaRequerida  ,
		Anulado = @Anulado  ,EsTeleventa= @EsTeleventa ,Estado = @Estado  ,
		IDFactura= @IDFactura ,Nota = @Nota		  ,IDTipoEntrega = @IDTipoEntrega,
		IDNivel = @IDNivel, IDMoneda = @IDMoneda, TipoCambio  = @TipoCambio , IDPlazo = @IDPlazo
		where Pedido = @Pedido and IDBodega = @IDBodega 
end

if @Operacion = 'D'
begin 
		if exists (select IDPedido FROM dbo.fafPedido 
		where Pedido = @Pedido and IDBodega = @IDBodega 
		and Estado = 'C')
		begin 
			Delete From dbo.fafPedidoProd  
			where IDPedido = @IDPedido and IDBodega = @IDBodega 
			
			DELETE FROM dbo.fafPedidoProd 
			where IDPedido = @IDPedido and IDBodega = @IDBodega 

		end
end
GO 

Create Procedure dbo.fafUpdatePedidoProd @Operacion nvarchar(1),
	@IDPedido int, @IDBodega int,
	@IDProducto bigint ,@Cantidad decimal(28, 4) ,
	@PrecioLocal decimal(28, 4) , @PrecioDolar decimal(28, 4) ,
	@ImpuestoLocal decimal(28, 4), @ImpuestoDolar decimal(28, 4),
	@SubTotalLocal decimal(28, 4), @SubTotalDolar decimal(28, 4),
	@SubTotalFinalLocal decimal(28, 4), @SubTotalFinalDolar decimal(28, 4),
@Bonifica bit ,@BonifConProd bit , @CantBonificada  decimal (28,4), 
@DescuentoLocal  decimal (28,4) , @DescuentoDolar  decimal (28,4) , 
@PorcDescuentoEsp   decimal (28,4), @DescuentoEspecialLocal  decimal (28,4) , 
@DescuentoEspecialDolar  decimal (28,4)
as
set nocount on 
if @Operacion = 'I'
begin
	Insert dbo.fafPedidoProd (IDPedido, IDBodega , IDProducto, Cantidad, PrecioLocal, PrecioDolar,    ImpuestoLocal,   ImpuestoDolar, SubtotalLocal, SubTotalDolar, SubtotalFinalLocal, SubTotalFinalDolar,
	Bonifica  ,BonifConProd  , CantBonificada  , DescuentoLocal   , DescuentoDolar,
PorcDescuentoEsp   , DescuentoEspecialLocal, DescuentoEspecialDolar    )
	values (@IDPedido, @IDBodega , @IDProducto, @Cantidad, @PrecioLocal, @PrecioDolar,  @ImpuestoLocal, @ImpuestoDolar, @SubtotalLocal, @SubTotalDolar,@SubtotalFinalLocal, @SubTotalFinalDolar,
	@Bonifica  ,@BonifConProd  , @CantBonificada  , @DescuentoLocal    ,@DescuentoDolar,
	@PorcDescuentoEsp   , @DescuentoEspecialLocal, @DescuentoEspecialDolar    ) 
end
if @Operacion = 'U'
begin
	if exists(Select IDPedido From dbo.fafPedido where IDPedido = @IDPedido and IDBodega = @IDBodega
			and Estado = 'C')
	begin
		Update dbo.fafPedidoProd  set Cantidad = @Cantidad, PrecioDolar = @PrecioDolar, PrecioLocal = @PrecioLocal ,
		 ImpuestoLocal = @ImpuestoLocal , ImpuestoDolar = @ImpuestoDolar, SubTotalLocal = @SubTotalLocal , SubTotalDolar = @SubTotalDolar,
		 Bonifica = @Bonifica  ,BonifConProd=@BonifConProd  , CantBonificada=@CantBonificada  , DescuentoLocal=@DescuentoLocal   , 
		 DescuentoDolar=@DescuentoDolar   ,PorcDescuentoEsp = @PorcDescuentoEsp  , DescuentoEspecialLocal = @DescuentoEspecialLocal 
		 , DescuentoEspecialDolar = @DescuentoEspecialDolar 
		where IDPedido = @IDPedido and IDBodega = @IDBodega and IDProducto = @IDProducto 
	end
end
if @Operacion = 'D'
begin
	if exists(Select IDPedido From dbo.fafPedido where IDPedido = @IDPedido and IDBodega = @IDBodega
			and Estado = 'C')
	begin
		Delete from dbo.fafPedidoProd 
		where IDPedido = @IDPedido and IDBodega = @IDBodega and IDProducto = @IDProducto 
	end
end
go

Create Function dbo.getAutoIDInt()
returns int
begin
	return @@Identity
end
go

Create Function dbo.getAutoIDBigInt()
returns bigint
begin
	return @@Identity
end
go

Create Function dbo.getPorcImpuestoFromProducto(@IDProducto bigint)
returns decimal(28,4)
begin
Declare @PorcImpuesto decimal(28,4)
	set @PorcImpuesto = (
		SELECT Porc
		FROM dbo.globalImpuesto 
		where IDImpuesto in (
			Select TipoImpuesto  
			From dbo.invProducto 
			Where IDProducto = @IDProducto 
		)
	)
		return isnull(@PorcImpuesto,0) 
end
go
-- drop view dbo.vCliente
Create View dbo.vClientes
as
Select C.IDCliente, C.Nombre , C.Telefono , C.Direccion, C.EsFarmacia, C.Farmacia, C.IDTipo, T.Descr DescrTipo,
C.IDCategoria, G.Descr DescrCategoria, C.Activo 
From dbo.ccfClientes C inner join fafTipoCliente T on C.IDTipo = T.IDTipo 
inner join dbo.fafCategoriaCliente G on C.IDCategoria = G.IDCategoria 
go

-- drop procedure dbo.fafUpdateTablaBonificacion delete from dbo.fafTablaBonificacion where idtabla = 5
--exec dbo.fafUpdateTablaBonificacion 'I', 1, 1, 3, 18, 10, 1,1, '20180301', '20180430', 1
--select * from dbo.fafTablaBonificacion 
		--exec dbo.fafUpdateTablaBonificacion 'I',0,1,3,1,1,1,1, '#14/04/18#','#18/04/18#'

--exec dbo.fafUpdateTablaBonificacion 'I',0,1,4,14,2,1,1, '14/04/18','14/04/18'
Create procedure dbo.fafUpdateTablaBonificacion @Operacion nvarchar(1), @IDTabla int, 
@IDProveedor int , @IDProducto bigint , @Requerido decimal(28,2) , @Bono decimal(28,2) , 
@CantBonifProv decimal(28,2) ,@CantBonifDist decimal(28,2) , @Desde date, @Hasta date,
@TodosProdProveedor bit = null 

as
set nocount on 
if @TodosProdProveedor is null
	set @TodosProdProveedor = 0
	
if @Operacion = 'I' 
	if @TodosProdProveedor = 1 
	begin
		Delete from dbo.fafTablaBonificacion where IDProveedor = @IDProveedor 
		Insert dbo.fafTablaBonificacion ( IDProveedor , IDProducto, Requerido, Bono, CantBonifProv , CantBonifDist, Desde, Hasta )
		Select IDProveedor, IDProducto , @Requerido, @Bono, @CantBonifProv , @CantBonifDist, @Desde, @Hasta 
		from dbo.invProveedorProducto 
		where IDProveedor = @IDProveedor 
	end
	else
	begin
		Insert dbo.fafTablaBonificacion ( IDProveedor , IDProducto, Requerido, Bono, CantBonifProv , CantBonifDist, Desde, Hasta )
		values ( @IDProveedor , @IDProducto, @Requerido, @Bono, @CantBonifProv , @CantBonifDist, @Desde, @Hasta )
	end

if @Operacion = 'U'
begin
	Update dbo.fafTablaBonificacion set Requerido = @Requerido , Bono = @Bono , CantBonifProv = @CantBonifProv ,
	Desde = @Desde , Hasta = @Hasta 
	where (@TodosProdProveedor = 0 and   IDTabla = @IDTabla ) or
			(@TodosProdProveedor = 1 and  IDProveedor = @IDProveedor)
end
if @Operacion = 'D'
begin
	Delete from dbo.fafTablaBonificacion
	where (@TodosProdProveedor = 0 and   IDTabla = @IDTabla ) or
			(@TodosProdProveedor = 1 and  IDProveedor = @IDProveedor)
end
go

-- exec fafgetTablaBonificacion 0,4
Create Procedure dbo.fafgetTablaBonificacion @IDProveedor int, @IDProducto bigint = null
as


if @IDProducto is null
	set @IDProducto = 0

set nocount on 
SELECT T.IDTabla, T.IDProveedor, P.Nombre, T.IDProducto, A.Descr Descr, T.Requerido, T.Bono ,
T.CantBonifProv , T.CantBonifDist, T.Desde, T.Hasta 
FROM dbo.fafTablaBonificacion T inner join dbo.cppProveedor P on T.IDProveedor = P.IDProveedor 
inner join dbo.invProducto A on T.IDProducto = A.IDProducto 
where (( @IDProveedor = 0  ) or ( @IDProveedor <> 0 and T.IDProveedor = @IDProveedor ) ) 
and
(@IDProducto = 0 or (@IDProducto <> 0 and T.IDProducto = @IDProducto))
order by T.IDProveedor 

go

Create procedure dbo.fafUpdatePromociones @Operacion nvarchar(1), @IDPromocion int, 
@IDProveedor int , @IDProducto bigint ,@PorcDesc decimal(28,2) , @Desde date, @Hasta date,
@TodosProdProveedor bit = null 

as
set nocount on 
if @TodosProdProveedor is null
	set @TodosProdProveedor = 0
	
if @Operacion = 'I' 
	if @TodosProdProveedor = 1 
	begin
		Delete from dbo.fafPromociones  where IDProveedor = @IDProveedor 
		Insert dbo.fafPromociones ( IDProveedor , IDProducto,  PorcDesc, Desde, Hasta )
		Select IDProveedor, IDProducto , @PorcDesc , @Desde, @Hasta 
		from dbo.invProveedorProducto 
		where IDProveedor = @IDProveedor 
	end
	else
	begin
		Delete from dbo.fafPromociones  where IDProveedor = @IDProveedor and IDProducto = @IDProducto
		Insert dbo.fafPromociones ( IDProveedor , IDProducto,  PorcDesc, Desde, Hasta )
		values ( @IDProveedor , @IDProducto, @PorcDesc , @Desde, @Hasta)
	end

if @Operacion = 'U'
begin
	Update dbo.fafPromociones set 
	PorcDesc = @PorcDesc  ,	Desde = @Desde , Hasta = @Hasta 
	where (@TodosProdProveedor = 0 and   IDPromocion = @IDPromocion ) or
			(@TodosProdProveedor = 1 and  IDProveedor = @IDProveedor)
end
if @Operacion = 'D'
begin
	Delete from dbo.fafPromociones
	where (@TodosProdProveedor = 0 and   IDPromocion = @IDPromocion ) or
			(@TodosProdProveedor = 1 and  IDProveedor = @IDProveedor)
end
go

--exec  dbo.fafgetPromociones 1,0
Create Procedure dbo.fafgetPromociones @IDProveedor int, @IDProducto bigint = null
as


if @IDProducto is null
	set @IDProducto = 0

set nocount on 
SELECT T.IDPromocion , T.IDProveedor, P.Nombre, T.IDProducto, A.Descr Descr, T.porcDesc, T.Desde, T.Hasta 
FROM dbo.fafPromociones  T inner join dbo.cppProveedor P on T.IDProveedor = P.IDProveedor 
inner join dbo.invProducto A on T.IDProducto = A.IDProducto 
where (( @IDProveedor = 0  ) or ( @IDProveedor <> 0 and T.IDProveedor = @IDProveedor ) ) 
and
(@IDProducto = 0 or (@IDProducto <> 0 and T.IDProducto = @IDProducto))
order by T.IDProveedor 

go



--drop view dbo.vProductos 
Create view dbo.vProductos 
as 
SELECT P.IDProducto, P.Descr, P.Alias, P.CostoUltLocal, P.CostoUltDolar, P.CostoPromLocal, P.CostoPromDolar,
isnull(P.Clasif1,'ND') IDClasif1, isnull(C1.Descr,'ND') Clasif1, 
isnull(P.Clasif2,'ND') IDClasif2, isnull(C2.Descr,'ND') Clasif2, 
isnull(P.Clasif3,'ND') IDClasif3, isnull(C3.Descr,'ND') Clasif3, 
isnull(P.Clasif4,'ND') IDClasif4, isnull(C4.Descr,'ND') Clasif4, 
isnull(P.Clasif5,'ND') IDClasif5, isnull(C5.Descr,'ND') Clasif5, 
isnull(P.Clasif6,'ND') IDClasif6, isnull(C6.Descr,'ND') Clasif6,
P.Activo 
FROM DBO.INVPRODUCTO P 
LEFT JOIN DBO.invClasificacion C1 ON P.CLASIF1 = C1.IDCLASIFICACION 
LEFT JOIN DBO.invClasificacion C2 ON P.CLASIF2 = C2.IDCLASIFICACION 
LEFT JOIN DBO.invClasificacion C3 ON P.CLASIF3 = C3.IDCLASIFICACION 
LEFT JOIN DBO.invClasificacion C4 ON P.CLASIF4 = C4.IDCLASIFICACION 
LEFT JOIN DBO.invClasificacion C5 ON P.CLASIF5 = C5.IDCLASIFICACION 
LEFT JOIN DBO.invClasificacion C6 ON P.CLASIF6 = C6.IDCLASIFICACION 
go

-- exec dbo.fafgetProductos 0 select * from dbo.vProductos
Create Procedure dbo.fafgetProductos (@IDProducto bigint, @IncluyeInactivos bit = null )
as
set nocount on 
if @IncluyeInactivos is null
	set @IncluyeInactivos = 0
SELECT IDProducto, Descr, Alias, Clasif1,Clasif2, Clasif3, Clasif4, Clasif4 , Clasif6, Activo, CostoPromDolar, CostoPromLocal 
FROM dbo.vProductos 
Where ( IDProducto = @IDProducto or @IDProducto = 0 ) and  (@IncluyeInactivos = 0 or (@IncluyeInactivos = 1 and Activo in (0,1)))
go

-- exec dbo.fafgetPedido 12,1, NULL, NULL, 'A',0  exec dbo.fafgetPedido 0,0,'20180101','20181002', 'A',1
create Procedure dbo.fafgetPedido (@IDPedido int, @IDBodega int = 0, @FechaInic date = null, @FechaFin date = null, @Estado nvarchar(1) = null, @Consolidado   bit = 0 )
AS
set nocount on 
if @IDPedido is null
	set @IDPedido = 0
if @FechaInic is null
	set @FechaInic = '20000101'
if @FechaFin is null 
	set @FechaFin = (select cast(GETDATE () as DATE))
if @Estado is null
	set @Estado = '*'	


SELECT P.IDPedido, P.Pedido, P.Fecha,  P.IDCliente , Cl.Nombre , L.IDProducto,
A.Descr,  Cantidad , 	L.PrecioLocal ,  L.PrecioDolar , 
		L.SubTotalLocal ,  L.SubTotalDolar , 
		L.ImpuestoLocal , L.ImpuestoDolar ,
		L.DescuentoLocal ,  L.DescuentoDolar   , 
		 I.Porc PorcImp, 
		L.DescuentoESpecialLocal ,  L.DescuentoEspecialDolar, 
		L.SubtotalFinalLocal ,  L.SubtotalFinalDolar ,
			
P.FechaRequerida, P.Anulado , P.EsTeleventa, P.Estado, E.Descr DescrEstado, P.IDBodega,
P.IDVendedor, P.IDTipoEntrega, Cl.Farmacia, CAST(0 as bit) LoteAsignado,
P.IdNivel, P.IDMoneda,M.Nacional, P.idPlazo, 
Bonifica  ,BonifConProd  , CantBonificada  , 
PorcDescuentoEsp   , 
L.SubTotalFinalLocal+L.ImpuestoLocal  TotalFinalLocal,  L.SubTotalFinalDolar+L.ImpuestoDolar TotalFinalDolar
--into #Detalle
FROM DBO.fafPedido P inner join dbo.fafPedidoProd L
on P.IDPedido = L.IDPedido and P.IDBodega = L.IDBodega 
inner join dbo.invBodega B on L.IDBodega = B.IDBodega 
inner join dbo.invProducto A on A.IDProducto = L.IDProducto 
inner join dbo.ccfClientes Cl on P.IDCliente = Cl.IDCliente 
inner join dbo.fafEstadoPedido E on P.Estado = E.Estado 
left join dbo.globalImpuesto I on  A.TipoImpuesto = I.IDImpuesto 
inner join dbo.globalMoneda M  
on P.IDMoneda = M.IDMoneda
WHERE (@IDPedido = 0 or P.IDPedido = @IDPedido) and (P.IDBodega = @IDBodega or @IDBodega = 0 ) and 
(P.Fecha between @FechaInic and @FechaFin ) and
(@Estado = '*' or P.Estado = @Estado ) --and Anulado = 0
 if @Consolidado = 0
 begin
	Select IDPedido, Pedido, Fecha, IDCliente , Nombre , IDProducto,
		Descr,  Cantidad ,
		FechaRequerida, Anulado , EsTeleventa, Estado,  DescrEstado, IDBodega, IDVendedor, IDTipoEntrega, Farmacia, 
		LoteAsignado, IDPlazo, IDNivel, IDMoneda,Nacional,Bonifica  ,BonifConProd  , CantBonificada  ,
		 PrecioLocal, PrecioDolar,
		 SubTotalLocal, SubTotalDolar, PorcImp,
		 ImpuestoLocal,ImpuestoDolar,
		 DescuentoLocal , DescuentoDolar ,
		 PorcDescuentoEsp   , 
		 DescuentoEspecialLocal, DescuentoEspecialDolar,
		 SubTotalFinalLocal,SubTotalFinalDolar,
		 TotalFinalLocal, TotalFinalDolar 
	From #Detalle
 end
 
 if @Consolidado = 1
 begin
	Select IDPedido, Pedido, Fecha, IDCliente , Nombre , FechaRequerida, Anulado , EsTeleventa, Estado,  DescrEstado , IDBodega, IDNivel, IDMoneda,Nacional,IDPlazo,
	SUM( SubTotalLocal) SubTotalLocal, SUM( SubTotalDolar) SubTotalDolar,
	Sum(DescuentoLocal) DescuentoLocal,  Sum(DescuentoDolar) DescuentoDolar,
	Sum(DescuentoEspecialLocal) DescuentoEspecialLocal,   Sum(DescuentoEspecialDolar) DescuentoEspecialDolar,
	Sum(ImpuestoLocal) ImpuestoLocal,  Sum(ImpuestoDolar) ImpuestoDolar, 
	Sum(SubTotalFinalLocal) SubTotalFinalLocal,  Sum(SubTotalFinalDolar) SubTotalFinalDolar	,
	Sum(TotalFinalLocal) TotalFinalLocal, Sum(TotalFinalDolar) TotalFinalDolar
	From #Detalle
	Group by IDPedido, Pedido, Fecha, IDCliente , Nombre , FechaRequerida, Anulado , EsTeleventa, Estado,  DescrEstado, IDBodega, IDNivel, IDMoneda,Nacional, IDPlazo
	Order by IDPedido, Pedido, Fecha, IDCliente , Nombre , FechaRequerida, Anulado , EsTeleventa, Estado,  DescrEstado, IDBodega, IDNivel, IDMoneda,Nacional, IDPlazo
 end 
 drop table #Detalle
go



Create Table dbo.fafPrecios ( IDPrecio int not null identity (1,1),
IDProducto bigint not null, IDNivel int not null, IDMoneda int not null, Precio decimal(28,2) default 0 )
go

alter table dbo.fafPrecios add constraint pkfafPrecios primary key (IDPrecio)
go

alter table dbo.fafPrecios add constraint ukfafPrecios UNIQUE (IDProducto, IDNivel, IDMoneda)
go
alter table dbo.fafPrecios add constraint fkfafPreciosProd foreign key  (IDProducto) references dbo.invProducto (IDProducto )
go
alter table dbo.fafPrecios add constraint fkfafPreciosNivel foreign key  (IDNivel) references dbo.fafNivelPrecio (IDNivel )
go
alter table dbo.fafPrecios add constraint fkfafPreciosMoneda foreign key  (IDMoneda) references dbo.globalMoneda (IDMoneda )
go

create Procedure [dbo].[fafUpdatePrecios] @Operacion nvarchar(1),
	@IDProducto bigint ,
	@IDNivel int ,
	@IDMoneda int ,
	@Precio decimal(28, 2)
as
set nocount on
if @Operacion = 'I'
begin
	Insert dbo.fafPrecios (IDProducto,  IDNivel , IDMoneda , Precio )
	values (@IDProducto,  @IDNivel , @IDMoneda , @Precio)
end
if @Operacion = 'U'
begin
	Update dbo.fafPrecios set Precio = @Precio
	where IDProducto = @IDProducto and IDNivel = @IDNivel and IDMoneda = @IDMoneda 
end
if @Operacion = 'D'
begin
	Delete dbo.fafPrecios 
	where IDProducto = @IDProducto and IDNivel = @IDNivel and IDMoneda = @IDMoneda 
end

go

Create procedure dbo.fafgetListaPrecio ( @IDProducto bigint, @IDNivel int = null )
as
set nocount on

Select P.IDProducto, A.Descr , P.IDNivel , N.Descr DescrNivel, P.IDMoneda, M.Descr DescrMoneda, P.Precio 
From dbo.fafPrecios P inner join dbo.invProducto A on P.IDProducto = A.IDProducto 
inner join dbo.fafNivelPrecio N on P.IDNivel = N.IDNivel 
inner join dbo.globalMoneda M on P.IDMoneda = M.IDMoneda 
Where (P.IDProducto= @IDProducto or @IDProducto = 0) and
(P.IDNivel = @IDNivel or @IDNivel = 0)
go
-- drop table dbo.fafPrecioCliente
Create Table dbo.fafPrecioCliente (IDPrecioCliente bigint not null identity(1,1), IDCliente int null ,
IDNivel int not null , 
IDProducto bigint not null, IDMoneda int not null, 
 Precio decimal(28,2) default 0, Usuario nvarchar(20) )
go 

alter table dbo.fafPrecioCliente add constraint pkPrecioCliente primary key (IDPrecioCliente)
go

alter table dbo.fafPrecioCliente add constraint fkPrecioClienteCte foreign key (IDCliente) references dbo.ccfClientes(IDCliente)
go

alter table dbo.fafPrecioCliente add constraint fkPrecioClienteProd foreign key (IDProducto) references dbo.invProducto (IDProducto)
go

alter table dbo.fafPrecioCliente add constraint fkPrecioClienteMon foreign key (IDMoneda) references dbo.globalMoneda(IDMoneda)
go

alter table dbo.fafPrecioCliente add constraint fkPrecioClienteNiv foreign key (IDNivel) references dbo.fafNivelPrecio(IDNivel)
go

--drop table dbo.fafBitacoraPrecioCliente
Create table dbo.fafBitacoraPrecioCliente (IDCliente int not null,  IDProducto bigint not null, IDMoneda int not null, Fecha datetime not null, Precio decimal(28,2) default 0, Usuario nvarchar(20), IDFactura bigint null)
go
Alter table dbo.fafBitacoraPrecioCliente add constraint pkbitPrecCli primary key (IDCliente,  IDProducto, IDMoneda, Fecha)
go

alter table dbo.fafBitacoraPrecioCliente add constraint fkbitPrecioClienteCte foreign key (IDCliente) references dbo.ccfClientes(IDCliente)
go

alter table dbo.fafBitacoraPrecioCliente add constraint fkbitPrecioClienteProd foreign key (IDProducto) references dbo.invProducto (IDProducto)
go

alter table dbo.fafBitacoraPrecioCliente add constraint fkbitPrecioClienteMoneda foreign key (IDMoneda) references dbo.globalMoneda (IDMoneda)
go

alter table dbo.fafBitacoraPrecioCliente add constraint fkbitPrecioClientefact foreign key (IDFactura) references dbo.fafFactura (IDFactura)
go

create Procedure [dbo].[fafUpdatePrecioCliente] @Operacion nvarchar(1),
	@IDCliente int ,
	@IDProducto bigint ,
	@IDMoneda int ,
	@Precio decimal(28, 2), @Usuario nvarchar(20), @IDFactura bigint = null
as
set nocount on
Declare @IDNivel int
SELECT @IDNivel = IDCliente from dbo.ccfClientes where IDCliente =@IDCliente 
if @Operacion = 'I'
begin
	Insert dbo.fafPrecioCliente (IDCliente, IDNivel , IDProducto,   IDMoneda , Precio , Usuario )
	values (@IDCliente, @IDNivel , @IDProducto  , @IDMoneda , @Precio, @Usuario )
end
if @Operacion = 'U'
begin
	Update dbo.fafPrecioCliente set Precio = @Precio, Usuario = @Usuario 
	where IDCliente = @IDCliente and IDNivel = @IDNivel and IDProducto = @IDProducto  and IDMoneda = @IDMoneda 
end
if @Operacion = 'D'
begin
	Delete dbo.fafPrecioCliente 
	where IDCliente = @IDCliente and IDNivel = @IDNivel and IDProducto = @IDProducto  and IDMoneda = @IDMoneda 
end
-- si se Factura el precio autorizado para el cliente, al momento de facturar se debe eliminar e insertar en la bitacora
if @Operacion = 'F'
begin
	Delete dbo.fafPrecioCliente 
	where IDCliente = @IDCliente and IDNivel = @IDNivel and IDProducto = @IDProducto  and IDMoneda = @IDMoneda 
	insert dbo.fafBitacoraPrecioCliente (IDCliente, IDProducto, Fecha,   IDMoneda , Precio , Usuario, IDFactura  )
	values (@IDCliente, @IDProducto, GETDATE(), @IDMoneda , @Precio , @Usuario, @IDFactura )
end
go
--drop procedure dbo.fafgetPreciosCliente
Create procedure dbo.fafgetPreciosCliente @IDCliente int 
as
set nocount on
select D.IDCliente, C.Nombre , D.IDProducto , P.Descr , D.IDNivel , N.Descr DescrNivel, D.IDMoneda , M.Descr DescrMoneda, D.Precio 
from dbo.fafPrecioCliente D inner join dbo.ccfClientes C on D.IDCliente = C.IDCliente 
inner join dbo.invProducto P on D.IDProducto = P.IDProducto 
inner join dbo.globalMoneda M on D.IDMoneda = M.IDMoneda
inner join dbo.fafNivelPrecio N on D.IDnivel = N.IDNivel 
where (D.IDCliente = @IDCliente or @IDCliente = 0)
go
-- exec dbo.fafgetProductoLote  0,0

 --drop function   select dbo.fafGetPrecio(7,1,4,2) Precio select * from DBO.fafPrecioCliente select * from DBO.fafPrecios
Create Function dbo.fafGetPrecio (@IDCliente int , @IDNivel int,  @IDProducto int, @IDMoneda int)
returns decimal(28,2)
as
begin
Declare @Precio decimal(28,2)
 
SELECT TOP 1 @Precio = isnull(Precio , 0) 
FROM DBO.fafPrecioCliente 
WHERE IDCliente = @IDCliente AND IDNivel=@IDNivel and IDProducto = @IDProducto AND IDMoneda =@IDMoneda 

IF @Precio is null 
	SELECT  @Precio = Precio FROM DBO.fafPrecios 
	WHERE IDProducto =@IDProducto AND IDNivel = @IDNivel  AND IDMoneda = @IDMoneda 

return (isnull(@Precio,0))	
end
go

 --select dbo.fafGetPorcDescuento (3, '20181018')
Create Function dbo.fafGetPorcDescuento (@IDProducto int , @Fecha date)
returns decimal(28,2)
as
begin
Declare @PorcDescuento decimal(28,2)
 
SELECT TOP 1 @PorcDescuento = isnull(PorcDesc , 0)
FROM DBO.fafPromociones 
WHERE IDProducto = @IDProducto AND @Fecha between Desde  and Hasta 

return (isnull(@PorcDescuento,0))	
end
go


CREATE Procedure [dbo].[fafgetProductoLote] @IDBodega int, @IDProducto bigint
as 
Set Nocount on 
Create Table #Resultado ( IDBodega int not null, IDProducto int not null, Descr nvarchar(255),
IDLote int not null, LoteInterno nvarchar(50), LoteProveedor nvarchar(50), FechaVencimiento date,
Existencia decimal(28,2) default 0, AsignadoFA decimal(28,2) default 0, AsignadoBO decimal(28,2) default 0, Atendido bit default 0)
alter table #Resultado add constraint pkresult primary key (IDBodega, IDPRoducto, IDLote)

insert #Resultado (IDBodega, IDProducto, Descr , IDLote, LoteInterno , LoteProveedor , FechaVencimiento, Existencia, AsignadoFA , AsignadoBO )
Select E.IDBodega,  E.IDProducto, P.Descr, E.IDLote, L.LoteInterno, L.LoteProveedor, L.FechaVencimiento, 
(E.Existencia + Transito - Reservada) Existencia, 0.00  AsignadoFA , 0.00 AsignadoBO
From dbo.invExistenciaBodega E inner join dbo.invLote L 
on E.IDLote = L.IDLote and E.IDProducto= L.IDProducto  join dbo.invProducto P
on E.IDProducto = P.IDProducto 
Where (E.IDBodega = @IDBodega or @IDBodega = 0) and 
(E.IDProducto = @IDProducto or @IDProducto = 0)
order by E.IDProducto, L.FechaVencimiento asc

SELECT IDBodega, IDProducto, Descr , IDLote, LoteInterno , LoteProveedor , FechaVencimiento, Existencia, AsignadoFA , AsignadoBO, Atendido  
FROM #Resultado 
drop table #Resultado
go


/*
insert dbo.globalConsecMask  (Codigo, Descr, Longitud, Mascara,consecutivo,  Activo, IDModulo)
values ('F','Facturas',12, 'AAANNNAANNNN','FAC001MN0000',1, 500  )
Set @Mascara = 'AAANNNAANNNN'
Set @Valor = 'REC001MN0000'
select @Mascara Mascara, @Valor Valor

*/
-- drop function select  dbo.getMascaraFromConsecMask ( 'F') select dbo.getConsecMask 
--drop table dbo.globalConsecMask
Create table dbo.invUsuarioBodega (Usuario nvarchar(20) not null, IDBodega int not null )
go

Alter Table dbo.invUsuarioBodega add constraint pkinvUsuarioBodega primary key (Usuario, IDBodega)
go
-- exec dbo.invgetBodegasFromUsuario 'azepeda',0
Create Procedure dbo.invgetBodegasFromUsuario @Usuario nvarchar(20), @SoloFacturacion bit = false 
as
if @SoloFacturacion is null 
	set @SoloFacturacion = 0
set nocount on
Select U.Usuario, S.Descr, U.IDBodega, B.Descr, U.CodigoConsecMask
From  dbo.invUsuarioBodega U inner join dbo.secUsuario S on U.Usuario = S.Usuario 
inner join dbo.invBodega B on U.IDBodega = B.IDBodega 
Where U.Usuario = @Usuario and ((@SoloFacturacion = 1 and  Puedefacturar = 1) or @SoloFacturacion = 0 )
go

-- select [dbo].[globalGetLastTipoCambio] ('20181101', 'TVEN')
CREATE FUNCTION [dbo].[globalGetLastTipoCambio] 
(
	@Fecha date, 
	@IDTipoCambio nvarchar(20)
)
RETURNS DECIMAL(28,4)
AS
BEGIN

	DECLARE @TipoCambio AS DECIMAL(28,4)
	SET @TipoCambio = (SELECT Monto  
						FROM dbo.globalTipoCambioDetalle 
						WHERE IDTipoCambio=@IDTipoCambio and  Fecha= (Select Max(Fecha) 
									from dbo.globalTipoCambioDetalle  
									Where Fecha <= @Fecha AND IDTipoCambio=@IDTipoCambio)
									)						
	RETURN isnull(@TipoCambio, 0)
END
go



alter table  dbo.globalTipoCambio add Activo bit default 1
go
update  dbo.globalTipoCambio set activo = 1
go

--drop table  dbo.fafGlobales

Create Table dbo.fafParametros ( IDParametros int identity(1,1) not null, 
IDNivelPrecioPub int, IDPlazoCont int , TipoCambioFact nvarchar(20),
TipoCambioCont nvarchar(20), NumeroLineasFact int  , IntegracionCont bit default 0
) 
go

alter table dbo.fafParametros add constraint pkglobalesfa primary key (IDParametros)
go

alter table dbo.fafParametros add constraint fkglobalesfa foreign key (IDNivelPrecioPub) references dbo.fafNivelPrecio (IDNivel)
go

alter table dbo.fafParametros add constraint fkglobalesplaz foreign key (IDPlazoCont) references dbo.ccfPlazo (Plazo)
go

alter table dbo.fafParametros add constraint fkglobalestcfac foreign key (TipoCambioFact) references dbo.globalTipoCambio (IDTipoCambio)
go

alter table dbo.fafParametros add constraint fkglobalestcont foreign key (TipoCambioCont) references dbo.globalTipoCambio (IDTipoCambio)
go

Create Procedure dbo.fafUpdateParametros @IDParametros int,
@IDNivelPrecioPub int , @IDPlazoCont int, @TipoCambioFact nvarchar(20),
@TipoCambioCont nvarchar(20) , @NumeroLineasFact int ,
@IntegracionCont bit  
as
set nocount on 
if not exists (select IDParametros from  dbo.fafParametros ) 
	insert dbo.fafParametros (IDNivelPrecioPub, IDPlazoCont , TipoCambioFact , TipoCambioCont , NumeroLineasFact , IntegracionCont ) 
	values (@IDNivelPrecioPub, @IDPlazoCont , @TipoCambioFact , @TipoCambioCont , @NumeroLineasFact , @IntegracionCont )
else
	Update  dbo.fafParametros set IDNivelPrecioPub= @IDNivelPrecioPub, 
	IDPlazoCont  = @IDPlazoCont, TipoCambioFact = @TipoCambioFact , 
	TipoCambioCont = @TipoCambioCont , NumeroLineasFact = @NumeroLineasFact, IntegracionCont =@IntegracionCont 
	Where IDParametros = @IDParametros
go

Create Procedure dbo.fafgetParametros @IDParametros int
as
set nocount on
Select  IDNivelPrecioPub, IDPlazoCont , TipoCambioFact , TipoCambioCont , NumeroLineasFact , IntegracionCont 
from dbo.fafParametros 
where IDParametros = @IDParametros
go

--Exec dbo.fafUpdateFactura 'I',1,'FAC001MN00001',2, 7,'Julio Espinoza',1,2, '20181004',0,0,null,1,2,15,32.7000,'F',' '
create Procedure dbo.fafUpdateFactura @Operacion nvarchar(1),
	@IDBodega int ,	@Factura nvarchar(20) ,	@IDTipo smallint ,	@IDCliente int ,	@Nombre nvarchar(250) ,
	@IDVendedor int ,	@IDTipoEntrega int ,
	@Fecha datetime ,	@Anulada bit ,	@EsTeleventa bit ,	@IDPedido int ,	@IDNivel int ,	@IDMoneda int ,
	@IDPlazo int ,	@TipoCambio decimal(28, 4) ,	@CodConsecutivo nvarchar(20) ,	@Mensaje nvarchar(250) 
as
set nocount on 
if @Operacion = 'I'
begin

declare 	@IDDepto int ,	@IDMunicipio int ,	@IDZona int ,	@IDSubZona int 

	Select @IDDepto = IDDepto , @IDMunicipio = IDMunicipio, @IDZona = IDZona , @IDSubZona = IDSubZona 
	from dbo.ccfClientes 
	where IDCliente = @IDCliente 

INSERT INTO [dbo].[fafFACTURA]
           ([IDBodega]  ,[Factura]  ,[IDTipo] ,[IDCliente] ,[Nombre]
           ,[IDVendedor] ,[IDDepto]  ,[IDMunicipio]  ,[IDZona]  ,[IDSubZona]  ,[IDTipoEntrega]
           ,[Fecha]  ,[Anulada] ,[EsTeleventa]   ,[IDPedido]    ,[IDNivel]   ,[IDMoneda]
           ,[IDPlazo]  ,[TipoCambio]    ,[CodConsecutivo]   ,[Mensaje]  )
     VALUES  ( @IDBodega ,@Factura,   @IDTipo,  @IDCliente,@Nombre, @IDVendedor, 
            @IDDepto,  @IDMunicipio,@IDZona, @IDSubZona, @IDTipoEntrega  ,@Fecha, @Anulada
           ,@EsTeleventa  ,@IDPedido  ,@IDNivel ,@IDMoneda  ,@IDPlazo  ,@TipoCambio  ,@CodConsecutivo
           ,@Mensaje )           
           	
end

go

--Exec dbo.fafUpdateFacturaProd 'I',@@Identity,1,3,0,0,0,0,0,2,163.5000,50,0,0.0000,00.0000,0,327.0000,10,49.05000,1.5, 1" & vbCrLf & ""
Create Procedure dbo.fafUpdateFacturaProd @Operacion nvarchar(1),
	@IDFactura bigint, 	@IDBodega int ,	@IDProducto bigint ,	
	@Bonifica bit ,	@Requerido decimal (28,4), 	@Bono decimal (28,4), @BonifConProd bit ,
	@CantBonificada  decimal (28,4) , @CantFacturada  decimal (28,4) ,	
	@PrecioLocal  decimal (28,4) , @PrecioDolar  decimal (28,4) ,
	@CostoLocal  decimal (28,4) , @CostoDolar  decimal (28,4) ,
	@DescuentoLocal  decimal (28,4) , @DescuentoDolar  decimal (28,4) ,
	@DescuentoESpecialLocal  decimal (28,4) , @DescuentoEspecialDolar  decimal (28,4) ,
	@SubTotalLocal  decimal (28,4) , @SubTotalDolar  decimal (28,4) ,
	@SubTotalFinalLocal decimal(28,4) ,@SubTotalFinalDolar decimal(28,4), 
	@ImpuestoLocal  decimal (28,4) , @ImpuestoDolar  decimal (28,4) , 
	@Factor int, @PorcDescuentoEsp   decimal (28,4), @PorcImpuesto   decimal (28,4)
as
set nocount on 
if @Operacion = 'I'
begin
INSERT INTO [dbo].[fafFacturaProd]
           ([IDFactura]     ,[IDBodega],[IDProducto]   ,[Bonifica]  ,[Requerido] ,[Bono] ,[BonifConProd]
           ,[CantBonificada]  ,[CantFacturada]  ,[PrecioLocal]  ,[PrecioDolar]   ,[CostoLocal]
           ,[CostoDolar]  ,[DescuentoLocal] ,[DescuentoDolar] ,[DescuentoEspecialLocal]  ,[DescuentoEspecialDolar]
           ,[SubTotalLocal]  ,[SubTotalDolar]  ,[SubTotalFinalLocal]  ,[SubTotalFinalDolar]  ,[ImpuestoLocal]  ,[ImpuestoDolar]  
           ,[Factor], PorcDescuentoEsp, PorcImpuesto)
     VALUES  (@IDFactura     ,@IDBodega,@IDProducto   ,@Bonifica  ,@Requerido ,@Bono ,@BonifConProd
           ,@CantBonificada  ,@CantFacturada  ,@PrecioLocal  ,@PrecioDolar   ,@CostoLocal
           ,@CostoDolar  ,@DescuentoLocal ,@DescuentoDolar ,@DescuentoEspecialLocal  ,@DescuentoEspecialDolar
           ,@SubTotalLocal  ,@SubTotalDolar  ,@SubTotalFinalLocal  ,@SubTotalFinalDolar  ,@ImpuestoLocal  ,@ImpuestoDolar  ,@Factor, @PorcDescuentoEsp, @PorcImpuesto)          
           	
end

go

create Procedure dbo.fafUpdateFacturaProdLote @Operacion nvarchar(1),
	 @IDFacturaProd bigint, 	@IDLote int ,	@CantBonificada decimal(28,4) ,	@CantFacturada decimal(28,4) 
as
set nocount on 
if @Operacion = 'I'
begin
	INSERT INTO [dbo].[fafFacturaProdLote] (IDFacturaProd, IDLote, CantBonificada, CantFacturada)
	values  (@IDFacturaProd, @IDLote, @CantBonificada, @CantFacturada)
	
	-- Actualizo la linea a nivel de producto sumarizando los lotes
	Update P set CantBonificada = L.CantBonificada, CantFacturada = L.CantFacturada , DescuentoLocal =  L.CantBonificada*P.PrecioLocal,
	DescuentoDolar =  L.CantBonificada*P.PrecioDolar
	from [dbo].[fafFacturaProd] P inner join (
		Select IDFacturaProd , SUM(CantBonificada ) CantBonificada, SUM(CantFacturada ) CantFacturada
		from [dbo].[fafFacturaProdLote]
		where IDFacturaProd = @IDFacturaProd 
		group by IDFacturaProd 
		) L on P.IDFacturaProd = L.IDFacturaProd 
	Where P.IDFacturaProd = @IDFacturaProd
end
go


Create View dbo.vfafDetalleProducto
as
SELECT F.IDFactura, F.IDBodega , B.Descr DescrBodega, f.Factura , f.Fecha ,F.IDTipo, T.descr DescrTipo, F.IDTipoEntrega, 
E.Descr DescrEntrega, F.IDVendedor , V.Nombre NombreVendedor ,
f.IDCliente, f.Nombre, f.Mensaje , f.Anulada , f.EsTeleventa , f.idplazo , Z.Descr DescrPlazo ,
f.IDMoneda , M.Nacional, M.Descr DescrMoneda, M.Simbolo, P.IDProducto , A.Descr DescrProducto, P.Cantidad,
P.CantFacturada, P.Bonifica , P.CantBonificada, P.BonifConProd,  
 P.PrecioLocal , P.PrecioDolar ,
 P.CostoLocal , P.CostoDolar ,
 P.DescuentoLocal , P.DescuentoDolar  ,
 P.porcDescuentoEsp,P.DescuentoEspecialLocal , P.DescuentoEspecialDolar  ,
 P.SubTotalLocal , P.SubTotalDolar ,
 P.PorcImpuesto, P.ImpuestoLocal , P.ImpuestoDolar ,
 P.SubTotalFinalLocal , P.SubTotalFinalDolar  ,
 P.Factor, F.IDDepto, f.IDMunicipio , f.IDZona, f.IDSubZona , F.tipoCambio, F.codconsecutivo 
FROM DBO.fafFactura F inner join DBO.fafFacturaProd P
on F.IDFactura = P.IDFactura inner join dbo.fafTipoFactura T 
on F.IDTipo = T.IDTipo inner join dbo.fafTipoEntrega E 
on F.IDTipoEntrega= E.IDTipoEntrega inner join dbo.ccfPlazo Z 
on F.idplazo = Z.Plazo inner join dbo.globalMoneda M
on F.IDMoneda = M.IDMoneda inner join dbo.invProducto A
on P.IDProducto = A.IDProducto inner join dbo.fafVendedor V
on F.IDVendedor = V.IDVendedor inner join dbo.invBodega B
on F.IDBodega = B.IDBodega 
WHERE F.Anulada  = 0
go

--exec dbo.fafPrintFactura 13

Create Procedure dbo.fafPrintFactura @IDFactura bigint
as
set nocount on 

 SELECT D.IDFactura, D.Factura , D.Fecha, D.IDTipo , D.DescrTipo, D.TipoCambio,
 D.IDTipoEntrega, D.DescrEntrega, D.IDCliente, D.Nombre, D.EsTeleVenta, D.Anulada, D.DescrPlazo  , 
 D.IDMoneda, D.DescrMoneda, D.Simbolo,  D.IDBodega, D.DescrBodega ,
 D.IDProducto, D.DescrProducto,  D.Cantidad, D.CantFacturada, D.CantBonificada, D.Bonifica, D.BonifConProd,
case when D.Nacional = 1 then D.PrecioLocal else D.PrecioDolar end Precio,
case when D.Nacional = 1 then D.CostoLocal else D.CostoDolar end Costo,
case when D.Nacional = 1 then D.DescuentoLocal else D.DescuentoDolar  end Descuento,
case when D.Nacional = 1 then D.DescuentoEspecialLocal else D.DescuentoEspecialDolar  end DescuentoEspecial,
case when D.Nacional = 1 then D.Cantidad * D.PrecioLocal  else D.Cantidad * D.PrecioDolar   end SubTotal,
case when D.Nacional = 1 then 
( ((D.Cantidad * D.PrecioLocal) - (D.DescuentoLocal + D.DescuentoEspecialLocal ))  * D.PorcImpuesto/100)  
else 
( ((D.Cantidad * D.PrecioDolar) - (D.DescuentoDolar + D.DescuentoEspecialDolar )) * D.PorcImpuesto/100)   
end Impuesto,
case when D.Nacional = 1 then 
		(D.Cantidad * D.PrecioLocal) - (D.DescuentoLocal + D.DescuentoEspecialLocal ) 
		else 
		(D.Cantidad * D.PrecioDolar) - (D.DescuentoDolar + D.DescuentoEspecialDolar ) 
		end SubTotalFinal,
case when D.Nacional = 1 then 
		(D.Cantidad * D.PrecioLocal) - (D.DescuentoLocal + D.DescuentoEspecialLocal ) 
		+ D.ImpuestoLocal
		else 
		(D.Cantidad * D.PrecioDolar) - (D.DescuentoDolar + D.DescuentoEspecialDolar ) 
		+ D.ImpuestoDolar
		end TotalFinal	

 FROM dbo.vfafDetalleProducto D
 WHERE D.IDFactura = @IDFactura
GO


ALTER TABLE dbo.fafParametros ADD IDPaquete INT 
GO
ALTER TABLE dbo.fafParametros WITH CHECK ADD CONSTRAINT [fk_fafParametros_Paquete] FOREIGN KEY ([IDPaquete])
REFERENCES dbo.invPaquete(IDPaquete)
GO	
ALTER TABLE dbo.fafParametros CHECK CONSTRAINT [fk_fafParametros_Paquete]
GO
ALTER TABLE dbo.fafParametros ADD CtrImpuesto INT 	
GO
ALTER TABLE dbo.fafParametros WITH CHECK ADD CONSTRAINT [fk_fafParametros_Centro] FOREIGN KEY ([CtrImpuesto])
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER  TABLE dbo.fafParametros ADD CtaImpuesto BIGINT 	
GO
ALTER TABLE dbo.fafParametros WITH CHECK ADD CONSTRAINT [fk_fafParametros_CuentaContable] FOREIGN KEY ([CtaImpuesto])
REFERENCES dbo.cntCuenta(IDCuenta)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_CxC] FOREIGN KEY (CtrCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_CxC] FOREIGN KEY (CtaCxC)
REFERENCES dbo.cntCuenta(IDCuenta)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrLxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_LxC] FOREIGN KEY (CtrLxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaLxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_LxC] FOREIGN KEY (CtaLxC)
REFERENCES dbo.cntCuenta(IDCuenta)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrContado INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_Contado] FOREIGN KEY (CtrContado)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaContado BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_Contado] FOREIGN KEY (CtaContado)
REFERENCES dbo.cntCuenta(IDCuenta)
GO


ALTER TABLE  dbo.fafCategoriaCliente ADD CtrRecibosCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_Recibos] FOREIGN KEY (CtrRecibosCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaRecibosCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_RecibosCxC] FOREIGN KEY (CtaRecibosCxC)
REFERENCES dbo.cntCuenta(IDCuenta)



gO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrDebitoCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_DebitoCxC] FOREIGN KEY (CtrDebitoCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaDebitoCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_DebitoCxC] FOREIGN KEY (CtaDebitoCxC)
REFERENCES dbo.cntCuenta(IDCuenta)


gO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrCreditoCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_CreditoCxC] FOREIGN KEY (CtrCreditoCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaCreditoCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_CreditoCxC] FOREIGN KEY (CtaCreditoCxC)
REFERENCES dbo.cntCuenta(IDCuenta)


gO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtrImpuestoCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_ImpuestoCxC] FOREIGN KEY (CtrImpuestoCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaImpuestoCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_ImpuestoCxC] FOREIGN KEY (CtaImpuestoCxC)
REFERENCES dbo.cntCuenta(IDCuenta)


GO


ALTER TABLE  dbo.fafCategoriaCliente ADD CtrProntoPagoCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_ProntoPagoCxC] FOREIGN KEY (CtrProntoPagoCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaProntoPagoCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_ProntoPagoCxC] FOREIGN KEY (CtaProntoPagoCxC)
REFERENCES dbo.cntCuenta(IDCuenta)


GO


ALTER TABLE  dbo.fafCategoriaCliente ADD CtrInteresMoraCxC INT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_CC_InteresMoraCxC] FOREIGN KEY (CtrInteresMoraCxC)
REFERENCES dbo.cntCentroCosto(IDCentro)
GO
ALTER TABLE  dbo.fafCategoriaCliente ADD CtaInteresMoraCxC BIGINT
GO
ALTER TABLE dbo.fafCategoriaCliente WITH CHECK ADD CONSTRAINT [fk_fafCategoriaCliente_Cta_InteresMoraCxC] FOREIGN KEY (CtaInteresMoraCxC)
REFERENCES dbo.cntCuenta(IDCuenta)




