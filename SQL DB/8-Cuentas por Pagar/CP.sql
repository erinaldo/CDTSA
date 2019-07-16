






Create Table dbo.cppClaseDocumento ( TipoDocumento nvarchar(1) not null, IDClase nvarchar(10) not null, Descr nvarchar(250), 
Orden int default 0, Activo bit default 1,
DistribAutom bit default 0)
go

alter table dbo.cppClaseDocumento add constraint  pkcppClaseDocumento primary key ( TipoDocumento,IDClase  )
go



insert dbo.cppClaseDocumento ( TipoDocumento,  IDClase , Descr, orden, activo, DistribAutom)
values ('C', 'FAC', 'FACTURA', 1, 1, 0)
GO
insert dbo.cppClaseDocumento ( TipoDocumento, IDClase , Descr, orden, activo, DistribAutom )
values ('D', 'N/D', 'NOTAS DE DEBITO', 2, 1, 0)
GO

insert dbo.cppClaseDocumento ( TipoDocumento,  IDClase , Descr, orden, activo, DistribAutom )
values ('D', 'O/D', 'OTROS DEBITOS', 3, 1, 0)
GO

insert dbo.cppClaseDocumento ( TipoDocumento, IDClase , Descr, orden, activo, DistribAutom  )
values ('D', 'CHQ', 'CHEQUES', 4, 1, 0)
GO

insert dbo.cppClaseDocumento (TipoDocumento, IDClase , Descr, orden, activo, DistribAutom  )
values ('D', 'TEF', 'TRANSFERENCIAS', 5, 1, 0)
GO

insert dbo.cppClaseDocumento (TipoDocumento, IDClase , Descr, orden, activo, DistribAutom   )
values ('C', 'R/C', 'RECIBO DE CAJA', 6, 1, 1)
GO

insert dbo.cppClaseDocumento (TipoDocumento, IDClase , Descr, orden, activo, DistribAutom )
values ('C','N/C', 'NOTAS DE CREDITO', 7, 1, 0)
GO

insert dbo.cppClaseDocumento (TipoDocumento, IDClase , Descr, orden, activo, DistribAutom  )
values ('C','O/C', 'OTROS CREDITO', 8, 1, 1)
GO
insert dbo.cppClaseDocumento (TipoDocumento, IDClase , Descr, orden, activo, DistribAutom  )
values ('C','RET', 'RETENCION', 8, 1, 1)
GO
--SElect * From dbo.cppSubTipoDocumento set DistribAutom = 0


--drop table dbo.cppSubTipoDocumento SELECT * FROM dbo.cppSubTipoDocumento where IDClase in ('N/C', 'N/D', 'R/C') order by IDClase alter table dbo.cppSubTipoDocumento add ContraCtaEnSubTipo bit , CtaDebito varchar(25), CtaCredito varchar(25) EsRecuperacion bit 
-- update dbo.cppSubTipoDocumento set ContraCtaEnSubTipo = 0
Create Table dbo.cppSubTipoDocumento (IDSubTipo int identity(1,1) not null, TipoDocumento nvarchar(1) not null, IDClase nvarchar(10) not null,
Descr nvarchar(200), Descripcion nvarchar(200), Consecutivo int default 0, DistribAutom bit default 0, EsRecuperacion bit default 0, SubTipoGeneraAsiento bit default 0, NaturalezaCta nvarchar(1), CtaDebito varchar(25), CtaCredito varchar(25),
Especial bit default 0, ContraCtaEnSubTipo bit default 0,esInteres BIT DEFAULT 0, esDeslizamiento BIT DEFAULT 0 )
-- ContraCtaEnSubTipo : 1 El Asiento tomara la cta contable de la contracuenta en el subTipoDocumento 0 : Toma la CxC de la sucursal
-- ESPECIAL QUIERE DECIR QUE EL SUBTIPO NO DISTRIBUYE AUTOMATICAMENTE NI MANUALMENTE, NO APLICA NINGUN DOCUMENTO, NO ES RECUPERACION
--, Orden int default 0, DistribAutom bit default 0, EsInteres bit default 0, EsDeslizamiento bit default 0 )
go
/* Explicacion de los Campos de la tabla dbo.[cppSubTipoDocumento]
Field	Descripción	Función
IDSubTipo	Codigo del SubTipo	
TipoDocumento	Tipo de SubTipo de Documento	Indica si el Documento es Débito o Crédito
IDClase	ID de la Clase a la que pertenece	Indica la Clase 
Descr	Descripción del SubTipo de Documento	
Descripcion	Descripción Alterna	
Consecutivo	Consecutivo No Usado, esto es si el usuario quiere	
DistribAutom	Distribución Automática de los SubTipo Créditos	Si es 1 Aplica o Cancela los débitos más vencidos
EsRecuperacion	Indica si un Documento Aplica como Recuperación	Es utilizado en la reporteria
SubTipoGeneraAsiento	Indica si un subtipo genera o no Asiento Contable	Si es 0 la generación de Asiento se hace como un R/C automático
NaturalezaCta	Indica en donde va la cuenta que manda	La cuenta que manda puede estar en Deb o Cred
CtaDebito	Cuenta Contable del SubTipo en el Debito	
CtaCredito	Cuenta Contable del SubTipo en el Crédito	
Especial	Indica si el subtipo corresponde para un Cliente vario o especial	Si es especial, se toma los Proveedores que tengan categoria Especial o Varios
ContraCtaEnSubTipo	Indica si la ContraCuenta la toma del SubTipo o es la Cta CxC de la Sucursal	

*/

alter table dbo.cppSubTipoDocumento add constraint pkcppSubTipoDocumento primary key (TipoDocumento, IDClase, IDSubTipo)
go


create  index  _indcppSubTipoDocumento  on dbo.cppSubTipoDocumento   (IDSubTipo )
go 

alter table dbo.cppSubTipoDocumento add constraint ukcppSubTipoDocumento UNIQUE (TipoDocumento, IDClase, IDSubTipo)
go

alter table dbo.cppSubTipoDocumento add constraint fkcppSubTipoDocumento foreign key (TipoDocumento, IDClase) references dbo.cppClaseDocumento (TipoDocumento, IDClase)
go
--alter table dbo.cppSubTipoDocumento add CtaDebito varchar(25), CtaCredito varchar(25)
--go

alter table dbo.cppSubTipoDocumento add constraint ckEsRecuperacion 
CHECK((TipoDocumento='C' and (EsRecuperacion =1 OR EsRecuperacion = 0)) or (TipoDocumento='D' and EsRecuperacion =0))
go

alter table dbo.cppSubTipoDocumento add constraint ckDistribAutom 
CHECK( (TipoDocumento = 'C' and (DistribAutom = 1 or DistribAutom = 0)) or (TipoDocumento = 'D' and DistribAutom = 0))
go 


alter table dbo.cppSubTipoDocumento add constraint ckNaturaleza 
CHECK( ( not NaturalezaCta is null and ( NaturalezaCta ='D' or NaturalezaCta = 'C'))
)
go

-- delete from  dbo.cppSubTipoDocumento where idsubtipo > 82 order by idSubtipo where TipoDocumento = 'C' and Especial = 1 and DistribAutom=0 and EsRecuperacion = 0

--UPDATE dbo.cppSubTipoDocumento SET NATURALEZACTA ='C' WHERE TIPODOCUMENTO = 'D' delete FROM dbo.cppSubTipoDocumento ORDER BY TIPODOCUMENTO
select * from  dbo.cppSubTipoDocumento 

Insert dbo.cppSubTipoDocumento ( TipoDocumento,  IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial  )	
Values ('C',	 'FAC',	'FACTURAS',	'FACTURA',	1,0, 0, 'C', NULL,NULL, 0	)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom , EsRecuperacion,  SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial)	
Values ('D',	 'TEF',	'TRANSFERENCIAS','TRANSFERENCIAS',	1,0,0, 0, 'D', NULL, NULL,0		)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom , EsRecuperacion,  SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial)	
Values ('D',	 'TEF',	'TRANSFERENCIAS','ANTICIPOS',	1,0,0, 0, 'D', NULL, NULL,0		)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial ) 
Values ('D',  'N/D' , 'NOTAS DE DEBITO', 'NOTA DE DEBITO', 1,0,1, 'D', 'FALTACTA', 'FALTACTA',1  )
go
Insert dbo.cppSubTipoDocumento ( TipoDocumento,  IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('D',	 'O/D',	'OTROS DEBITOS',	'OTROS DEBITOS',	1,0	, 0, 'D', NULL, NULL,0	)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('D',	 'CHQ'	, 'CHEQUES',	'CHEQUES',	1,0,0, 'D', NULL,NULL,0		)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('D',	 'CHQ'	, 'CHEQUES',	'ANTICIPOS',	1,0,0, 'D', NULL,NULL,0		)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('C',	 'N/C'	, 'NOTAS DE CREDITO',	'ANTICIPOS',	1,0,0, 'C', NULL,NULL,0		)
GO

Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('C',	 'RET'	, 'RETENCION',	'RETENCION',	1,0,0, 'C', NULL,NULL,0		)
GO


Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial )	
Values ('C',	 'O/C'	, 'OTROS CREDITOS',	'OTROS CEDITOS',	1,0,0, 'D', NULL,NULL,0		)
GO

/*
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial  )	
Values ('C',	 'N/C',	'NOTA DE CREDITO DIRIGIDA',	'NOTA DE CREDITO DIRIGIDA',	1,0, 0, 'C', NULL, NULL, 0		)
GO
Insert dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, Descr, Descripcion, Consecutivo, DistribAutom, SubTipoGeneraAsiento, NaturalezaCta, CtaDebito, CtaCredito, Especial  )	
Values ('C',	 'N/C',	'NOTA DE CREDITO DISTRIB AUTOMATICA',	'NOTA DE CREDITO DISTRIB AUTOMATICA',	1,1,0, 'C', NULL, NULL,0		)
GO
*/


UPDATE dbo.cppSUBTIPODOCUMENTO SET CTADEBITO = NULL, CTACREDITO = NULL
WHERE SUBTIPOGENERAASIENTO = 1
GO


Update dbo.cppSubTipoDocumento  set SubtipoGeneraAsiento = 1 where IDClase in ('N/D','N/C')
GO
update dbo.cppSubTipoDocumento  set CtaCredito = null, CtaDebito = null where CtaCredito = 'ND' OR CtaDebito = 'ND'
GO

CREATE TABLE dbo.[cppParametrosGenerales](
	[CobraInteresMora] [bit] NULL,
	[CobraDeslizamiento] [bit] NULL,
	[IDSubTipoRCCteEspVarios] [int] NULL,
	[IDSubTipoRCAutomatico] [int] NULL,
	[DiasVencidosInactivaCte] [int] NULL
) ON [PRIMARY]

GO



ALTER TABLE dbo.[cppParametrosGenerales] ADD  DEFAULT ((0)) FOR [CobraInteresMora]
GO

ALTER TABLE dbo.[cppParametrosGenerales] ADD  DEFAULT ((0)) FOR [CobraDeslizamiento]
GO

ALTER TABLE dbo.[cppParametrosGenerales] ADD  DEFAULT ((0)) FOR [IDSubTipoRCCteEspVarios]
GO

ALTER TABLE dbo.[cppParametrosGenerales] ADD  DEFAULT ((0)) FOR [IDSubTipoRCAutomatico]
GO




-- alter table dbo.cppDocumentosCP add FechaOrigVencMigracion datetime datetime

Create Table dbo.cppDocumentosCP ( 
IDDocumentoCP int  identity(1,1) not null ,
IDProveedor int not null,
TipoDocumento nvarchar(1) not null,
IDClase nvarchar(10) not null,
IDSubTipo	int not null, 
Documento nvarchar(20) not null,
Fecha datetime not null,
Vencimiento datetime not null,
Plazo decimal(8,2) default 0,
VencimientoVar datetime not null,
FechaDocVar datetime,
MontoOriginal decimal(28,4) default 0,
FechaUltCredito datetime default '19800101',
SaldoActual  decimal(28,4) default 0,
Cancelado bit default 0,
PorcInteres decimal(8,2) default 0,
Anulado bit default 0,
ConceptoSistema nvarchar(500) default '',
ConceptoUsuario nvarchar(500) default '',
Asiento nvarchar(20),
AsientoReversion nvarchar(20),
RecibimosDe nvarchar(250),
Usuario nvarchar(20), CreateDate datetime, TipoCambio decimal(28,4) default 0,
Contabilizado bit default 0,
IDMoneda INT not null,
Impuesto decimal(28,4) DEFAULT 0
) 
go
alter table dbo.cppDocumentosCP add constraint pkcppDocumentosCP primary key (IDDocumentoCP)
go
alter table dbo.cppDocumentosCP add constraint fkcppDocumentosCppProveedor foreign key (IDProveedor) references dbo.cppProveedor (IDProveedor)
go


alter table dbo.cppDocumentosCP add constraint fkcppSubTipoDocument foreign key  (TipoDocumento, IDClase, IDSubTipo ) references dbo.cppSubTipoDocumento ( TipoDocumento, IDClase, IDSubTipo)
go
-- alter table dbo.cppDocumentosCP drop constraint ukcppDocumentosCP
alter table dbo.cppDocumentosCP add constraint ukcppDocumentosCP UNIQUE ( IDClase, Documento)
go -- select * from dbo.cppDocumentosCP order by idclase

ALTER TABLE dbo.cppDocumentosCP ADD  DEFAULT (getdate()) FOR CreateDate
GO
Create nonclustered index indcppDocumentosCP on dbo.cppDocumentosCP ( IDProveedor, TipoDocumento, IDClase, Fecha, Documento )
go


CREATE NONCLUSTERED INDEX [i_cppDocumentosCP] ON dbo.[cppDocumentosCP] ([IDProveedor], [IDClase], [TipoDocumento])


--drop table dbo.cppAplicaciones SELECT * FROM dbo.cppSubTipoDocumento  alter table dbo.cppAplicaciones  add Asiento nvarchar(20)

--alter table dbo.cppAplicaciones add FecDocPostApp datetime, FecVencPostApp datetime select * from dbo.cppAplicaciones
Create Table dbo.cppAplicaciones ( IDAplicacion int identity(1,1) not null,
IDDocumentoCP int not null,
IDDocCredito int not null, 
DocDebito nvarchar(20) not null,
DocCredito nvarchar(20) not null,
Fecha datetime not null,
FechaCredito datetime not null default '19800101',
MontoCredito decimal(28,4) default 0,
MontoDebitoAnt decimal(28,4) default 0,
MontoDebitoAct decimal(28,4) default 0,
MontoCreditoAnt decimal(28,4) default 0,
MontoCreditoAct decimal(28,4) default 0,
CreateDate	datetime null,
FechaDocVarOrig datetime null,
VencimientoVarOrig datetime null,
FechaUltCreditoAnt datetime null,
IDDebito int not null,
Asiento nvarchar(20),
FecDocPostApp datetime, 
FecVencPostApp datetime
)
go

alter table dbo.cppAplicaciones add constraint pkcppAplicaciones primary key (IDAplicacion)
go

alter table dbo.cppAplicaciones add constraint fkcppAplicacionesDocCP foreign key (IDDocumentoCP) references dbo.cppDocumentosCP (IDDocumentoCP)
go

alter table dbo.cppAplicaciones add constraint fkcppAplicacionesDocCPCred foreign key (IDDocCredito) references dbo.cppDocumentosCP (IDDocumentoCP)
go

alter table dbo.cppAplicaciones add constraint ukcppAplicaciones UNIQUE (IDDocumentoCP, DocCredito, DocDebito, Fecha, IDDocCredito)
go

ALTER TABLE dbo.cppAplicaciones ADD  DEFAULT (getdate()) FOR CreateDate
GO

Create nonclustered index  indcppAplicacionesIDDebito on dbo.cppAplicaciones (IDDocumentoCP)
go

Create nonclustered index  indcppAplicacionesIDCredito on dbo.cppAplicaciones (IDDocCredito)
go


-- alter table dbo.cppAplicaciones add FechaUltCreditoAnt datetime
--drop table dbo.cppSaldoDocumentoCP alter table dbo.cppSaldoDocumentoCP add IDAplicacion int default 0 not null
Create Table dbo.cppSaldoDocumentoCP ( IDSaldo int identity(1,1) not null,
IDDocumentoCP int not null,
Fecha datetime not null,
Saldo decimal(28,4) default 0,
SaldoAnt decimal(28,4) default 0,
CreateDate datetime,
IDAplicacion int default 0 not null

)
go

alter table dbo.cppSaldoDocumentoCP add constraint pkcppSaldoDocumentoCP primary key (IDSaldo)
go

alter table dbo.cppSaldoDocumentoCP add constraint fkcppSaldoDocumentoCP foreign key (IDDocumentoCP) references dbo.cppDocumentosCP (IDDocumentoCP)
go
ALTER TABLE dbo.cppSaldoDocumentoCP ADD  DEFAULT (getdate()) FOR CreateDate
GO


Create nonclustered index indcppSaldoDocumentoCP on dbo.cppSaldoDocumentoCP (Fecha)
go



CREATE NONCLUSTERED INDEX [i_cppSaldoDocumentoCP] ON dbo.[cppSaldoDocumentoCP] ([IDDocumentoCP])

GO

create Trigger trgcppSaldoDocumentoCP on dbo.cppSaldoDocumentoCP  For INSERT
AS
DECLARE @IDSaldo int, @IDAplicacion int
Select @IDSaldo = IDSaldo, @IDAplicacion = IDAplicacion
From inserted i
if @IDAplicacion <> 0
begin
	if not exists(Select IDAplicacion from dbo.cppAplicaciones  (nolock) where idAplicacion = @IDAplicacion )
	begin
		RAISERROR ('Error Insertando una aplicacion inexistente ', 16,16)
		rollback
	end
end
go

--alter table dbo.cppSaldoDocumentoCP add constraint ukcppSaldoDocumentoCP UNIQUE (IDDocumentoCP, Fecha)
--go

--drop function [fnica].[cppGetSaldoDocumentoCC] select * from dbo.cppDocumentosCP
-- select [fnica].[cppGetIDDocumentoCP] ('MT01', 'FA0000002', 'FAC')

CREATE FUNCTION dbo.[cppGetIDDocumentoCP] ( @Documento nvarchar(20), @IDClase nvarchar(10) )
-- this function returns the ID of any kind of Document CC
RETURNS int AS  
BEGIN 
declare @IDDocumentoCP int
 
Set @IDDocumentoCP = (SELECT top 1 IDDocumentoCP
				FROM dbo.cppDocumentosCP (NOLOCK)
				where  Documento = @Documento and IDClase = @IDClase
				ORDER BY  Documento desc
			)

if @IDDocumentoCP is null
	set @IDDocumentoCP = 0
return @IDDocumentoCP
end
go




CREATE FUNCTION dbo.[cppGetSaldoDocumentoCP] (@IDDocumentoCP int, @Fecha datetime)
-- this function returns the client amount Due (Saldo en C$ ) to a given Document in a Date
RETURNS decimal(28,4) AS  
BEGIN 
set @Fecha = CAST(SUBSTRING(CAST(@Fecha AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)
Declare @Saldo decimal(28,4)
 
Set @Saldo = (SELECT top 1 Saldo
				FROM dbo.cppSaldoDocumentoCP  (NOLOCK)
				where IDDocumentoCP = @IDDocumentoCP and Fecha<= @Fecha
				ORDER BY IDDOCUMENTOCP, FECHA desc
			)

if @Saldo is null
	set @Saldo = 0
return @Saldo
end
go


-- drop procedure dbo.cppUpdatecppDocumentosCP
create Procedure dbo.cppUpdatecppDocumentosCP @Operation nvarchar(1),  @IDDocumentosCP int Output, 
@IDProveedor nvarchar(10) ,@TipoDocumento nvarchar(1) , @IDClase nvarchar(10), 
@IDSubTipo	int , @Documento nvarchar(20) , @Fecha datetime , @Plazo INT ,  @MontoOriginal decimal(28,4) ,
@PorcInteres decimal(8,2),@ConceptoSistema nvarchar(500),@ConceptoUsuario nvarchar(500), @RecibimosDe nvarchar(250),
@IDMoneda INT,@Usuario nvarchar(20), @TipoCambio decimal(28,4)  
-- @Operation = I Nuevo, D Eliminar, F Modifica Fecha Credito
as
set nocount on
declare @Ok bit, @Vencimiento datetime ,@VencimientoVar datetime ,@FechaUltCredito datetime, @SaldoActual  decimal(28,4) 
,@Anulado bit, @Cancelado bit 
set @Ok = 0
if upper(@Operation) = 'I'
begin
	SET @Vencimiento = DATEADD(day, @Plazo, @Fecha )
	SET @VencimientoVar = @Vencimiento
	SET @SaldoActual = @MontoOriginal
	set @Anulado = 0
	set @Cancelado = 0
	insert dbo.cppDocumentosCP ( IDProveedor, TipoDocumento, IDClase, IDSubTipo,Documento,Fecha,
	Vencimiento, Plazo, VencimientoVar, FechaDocVar, MontoOriginal, FechaUltCredito, SaldoActual, 
	Cancelado, PorcInteres, Anulado, ConceptoSistema, ConceptoUsuario, RecibimosDe,Usuario, TipoCambio,IDMoneda
	)
	values (
	@IDProveedor,@TipoDocumento, @IDClase, @IDSubTipo,@Documento,@Fecha,@Vencimiento,@Plazo,@VencimientoVar,@Fecha,
	@MontoOriginal,	@FechaUltCredito, @SaldoActual, @Cancelado, @PorcInteres, @Anulado, @ConceptoSistema, @ConceptoUsuario,
	@RecibimosDe, @Usuario, @TipoCambio,@IDMoneda
	)
	Set @IDDocumentosCP = (SELECT SCOPE_IDENTITY())
end
if upper(@Operation) = 'D'
begin
set @Ok = 1
	if exists( Select IDAplicacion from dbo.cppAPLICACIONES (Nolock)  where IDDocumentoCP =  @IDDocumentosCP )
	begin
		RAISERROR ('Ud está queriendo eliminar un documento que tiene Aplicaciones, primero elimínelas', 16, 10);
		set @Ok = 0
	end
	if exists( Select IDSaldo from dbo.cppSaldoDocumentoCP (Nolock)  where IDDocumentoCP =  @IDDocumentosCP )
	begin
		RAISERROR ('Ud está queriendo eliminar un documento que tiene Saldos, primero elimínelos', 16, 10);
		set @Ok = 0
	end	
	if  @Ok = 1
		Delete from dbo.cppDocumentosCP where IDDocumentoCP =  @IDDocumentosCP
end

Return isnull(@IDDocumentosCP,0)
go


create Function dbo.cppGetDeslizamiento (@SaldoFactura decimal(28,4), @FechaDocVar datetime, @FechaPago datetime, @IDDocDebito int=null)
returns decimal(28,4)
as 
begin
Declare @Deslizamiento decimal(28,4), @TipoCambioDoc decimal(28,4) , @TipoCambioRec decimal(28,4), @FechaDocOrig datetime

if @FechaPago < @FechaDocVar and @IDDocDebito is not null
begin
	select @FechaDocOrig = Fecha, @FechaDocVar = FechaDocVarOrig
	From dbo.cppAplicaciones (NOLOCK)
	where IDAplicacion in
	(
		Select max(IDAplicacion ) from dbo.cppAplicaciones (NOLOCK) where IDDocumentoCP = @IDDocDebito and fechaCredito > @FechaPago
	)
	if @FechaDocVar > @FechaPago
	begin
		set	@FechaDocVar = @FechaDocOrig
	end
end

set @TipoCambioDoc = (select dbo.globalGetUltTasadeCambio(@FechaDocVar) )
set @TipoCambioRec= (select dbo.globalGetUltTasadeCambio(@FechaPago) )

set @Deslizamiento = (
						(case when @TipoCambioDoc > 0 then @SaldoFactura/@TipoCambioDoc else 0 end)-
						(case when @TipoCambioRec > 0 then  @SaldoFactura/@TipoCambioRec else 1 end)
					  )*@TipoCambioRec
set @Deslizamiento = isnull(@Deslizamiento,0 )				  
return  @Deslizamiento
end
go

--drop function dbo.cppGetInteres
Create Function dbo.cppGetInteres (@SaldoFactura decimal(28,4), @Deslizamiento decimal(28,4), @PorcInteres decimal(8,2), @DiasVencidos int)
returns decimal(28,4)
as 
begin
Declare @Interes decimal(28,4)
set @Interes = (( @SaldoFactura+ @Deslizamiento) * @DiasVencidos * (@PorcInteres/100) ) / 360
set @Interes = isnull(@Interes,0 )				  
return  @Interes
end
go

-- drop function [fnica].[cppGetSaldoActualDocumentoCC] 
CREATE FUNCTION dbo.[cppGetSaldoActualDocumentoCP] (@IDDocumentoCP int)
-- this function returns the client amount Due (Saldo en C$ ) to a given Document 
RETURNS decimal(28,4) AS  
BEGIN 

Declare @Saldo decimal(28,4)
 
Set @Saldo = (SELECT top 1 SaldoActual
				FROM dbo.cppDocumentosCP (NOLOCK)
				where IDDocumentoCP = @IDDocumentoCP
			)

if @Saldo is null
	set @Saldo = 0
return @Saldo
end
go

-- drop procedure dbo.cppUpdatecppSaldoDocumentoCP
create PROCEDURE dbo.cppUpdatecppSaldoDocumentoCP @Operation nvarchar(1),
-- 'I' insertar 'D' Delete 
@IDSaldo int OUTPUT, @IDDocumentoCP int, 
@Fecha datetime, @Saldo decimal(28,4), @SaldoAnt decimal(28,4), @IDAplicacion int = null
as
set nocount on
IF @Operation = 'I'
begin
	if @IDAplicacion is null
		set @IDAplicacion = 0
	insert dbo.cppSaldoDocumentoCP ( IDDocumentoCP, Fecha, Saldo, SaldoAnt, IDAplicacion)
	values ( @IDDocumentoCP, @Fecha, @Saldo, @SaldoAnt, @IDAplicacion )
	Set @IDSaldo = (SELECT SCOPE_IDENTITY())
	if @Saldo = 0
	begin
		Update dbo.cppDocumentosCP set Cancelado = 1, SaldoActual = @Saldo, FechaUltCredito = @Fecha
		where IDDocumentoCP = @IDDocumentoCP
	end
	else
	begin
		Update dbo.cppDocumentosCP set SaldoActual = @Saldo, FechaUltCredito = @Fecha
		where IDDocumentoCP = @IDDocumentoCP	
	end
end
IF @Operation = 'D'
begin
	Delete From dbo.cppSaldoDocumentoCP Where IDSaldo = @IDSaldo
end
return isnull(@IDSaldo,0)
go


---************** TRIGGER INSERT DOCUMENTOSCC 
--DROP TRIGGER trgInsertcppDocumentosCP
CREATE TRIGGER trgInsertcppDocumentosCP
ON dbo.cppDocumentosCP
AFTER INSERT 
as
Declare @IDDocumentoCP int, @Tipo nvarchar(1), @IDSubtipo int, 
@DistribAutom bit, @IDProveedor nvarchar(10) , @Documento nvarchar(20),
@Fecha datetime, @MontoOriginal decimal(28,4)

Select @IDDocumentoCP = IDDocumentoCP,  @Tipo = i.TipoDocumento, 
@IDSubtipo = i.IDSubtipo,  
@IDProveedor = i.IDProveedor,
@Documento = i.Documento, @Fecha = i.Fecha, @MontoOriginal = i.MontoOriginal
From inserted i 

insert dbo.cppSaldoDocumentoCP( IDDocumentoCP, Fecha, Saldo, SaldoAnt )
values (@IDDocumentoCP, @Fecha, @MontoOriginal, 0 )
GO


-- drop function dbo.globalGetFechaVariable
Create Function dbo.globalGetFechaVariable( @FechaOriginal datetime, @SaldoDebito decimal(28,4), @FechaVariable datetime, @DifRestante decimal(28,4) )
returns datetime
as
begin
declare @DiasOriginales int, @NuevosDias int, @NewFecha datetime
set @DiasOriginales = (select datediff(day, @FechaOriginal, @FechaVariable))
set @NuevosDias = (select ( @DifRestante * datediff(day, @FechaOriginal, @FechaVariable) ) / @SaldoDebito)
set @NewFecha = (select  dateadd(day,  
		( @DifRestante * @DiasOriginales ) / @SaldoDebito,
			@FechaVariable ) )
			

return (convert( char(11), @NewFecha, 111))
end
go

create Procedure dbo.cppGetEstadoCuentaMovimientos @IDProveedor nvarchar(20), @FECHAINICIAL DATETIME, @FECHAFINAL DATETIME
as
declare @SaldoInicial decimal(28,4), @TotalMovimientos decimal(28,4)
set nocount on 
Select @SaldoInicial = ISNULL(SUM(CASE WHEN D.TIPODOCUMENTO = 'D' THEN D.MONTOORIGINAL ELSE D.MONTOORIGINAL * -1 END),0)
from dbo.cppDocumentosCP D
WHERE  IDProveedor = @IDProveedor and FECHA BETWEEN '19800101'  and dateadd(day, -1, @FECHAINICIAL )

select D.IDCLASE,  D.DOCUMENTO, D.FECHA, D.VENCIMIENTO, 
CASE WHEN D.TIPODOCUMENTO = 'D' THEN D.MONTOORIGINAL ELSE D.MONTOORIGINAL * -1 END MONTO, C.ORDEN , D.ConceptoSistema, D.ConceptoUsuario
into #Resultado
from dbo.cppDocumentosCP D inner join dbo.cppClaseDocumento C
ON D.IDCLASE = C.IDCLASE AND D.TIPODOCUMENTO = C.TIPODOCUMENTO
WHERE D.ANULADO = 0 and IDProveedor = @IDProveedor AND D.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL
ORDER BY D.FECHA,C.ORDEN

select @TotalMovimientos = sum(Monto) 
from #Resultado

Select *
from 
(
Select 'SALDO_I' IDClase,'***' Documento, '' DescrClase,  dateadd(day, -1, @FECHAINICIAL ) Fecha,  '20500101' Vencimiento, ISNULL(@SaldoInicial,0) Monto, 
'SALDO ANTERIOR ' ConceptoSistema, '' ConceptoUsuario
Union all 
	Select R.IDClase, R.Documento, C.Descr DescrClase, R.Fecha, R.Vencimiento, R.Monto, isnull(R.ConceptoSistema,'') ConceptoSistema, isnull(R.ConceptoUsuario, '') ConceptoUsuario
	from #Resultado R inner join dbo.cppClaseDocumento C
	on R.IDClase = C.IDClase
Union all
Select 'SALDO_F' iDClase,'***' Documento, '' DescrClase, dateadd(hour, 6, @FECHAFINAL) Fecha, '20500101'  Vencimiento, ISNULL((@SaldoInicial + @TotalMovimientos ),0) Monto, 
'SALDO FINAL al ' + CONVERT(NVARCHAR(30), @FECHAFINAL  , 103) ConceptoSistema, '' ConceptoUsuario
) X
order by X.Fecha
drop table #Resultado
go

-- EXEC dbo.cppGetDesglosePagos  'CH00941', '*', '20150101', '20150228'
create Procedure dbo.cppGetDesglosePagos  @FECHAINICIAL DATETIME, @FECHAFINAL DATETIME
as
set nocount on
Create table #Documentos (IDDocumento int, Orden int )
Select A.IDAplicacion, A.IDDocumentoCP, A.DocDebito, A.IDDocCredito, A.DocCredito, A.FechaCredito, A.MontoCredito, a.FechaDocVarOrig, a.VencimientoVarOrig
INTO #Aplicaciones
From dbo.cppAplicaciones A inner join dbo.cppDocumentosCP D
on A.IDDocumentoCP = D.IDDocumentoCP
Where  A.FechaCredito between @FECHAINICIAL AND @FECHAFINAL

Insert #Documentos (IDDocumento, orden)
Select Distinct IDDocumentoCP, 1
From #Aplicaciones
Union All
Select Distinct IDDocCredito, 0
From #Aplicaciones

SELECT X.IDProveedor, cast(X.IDDocCredito as nvarchar(20)) + cast( X.IDAPLICACION AS NVARCHAR(20) ) + cast( X.IDDOCUMENTOCP AS NVARCHAR(20) ) OrdenPresentacion,
X.IDAplicacion, X.IDDocumentoCP, X.IDDocCredito, X.FechaCredito, X.TipoDocumento, X.IDClase, X.Documento, X.MontoOriginal, X.MontoCredito, A.DocCredito, X.FechaDocVarOrig, X.VencimientoVarOrig 
into #Resultado
FROM 
(
	SELECT  D.IDProveedor, 0 IDAplicacion, D.IDDocumentoCP, D.IDDocumentoCP IDDocCredito, D.Fecha FechaCredito, D.IDClase, D.TipoDocumento, 
	D.Documento, D.MontoOriginal, 0  MontoCredito, '19800101' FechaDocVarOrig,  '19800101' VencimientoVarOrig
	FROM #Documentos A inner join dbo.cppDocumentosCP D
	on A.IDDocumento = D.IDDocumentoCP 
	WHERE ORDEN = 0
	union all
	SELECT   D.IDProveedor, A.IDAplicacion, A.IDDocumentoCP, A.IDDocCredito, A.FechaCredito, 
	D.IDClase, D.TipoDocumento, D.Documento, D.MontoOriginal, A.MontoCredito, A.FechaDocVarOrig, A.VencimientoVarOrig
	From #Aplicaciones A inner join dbo.cppDocumentosCP D
	on A.IDDocumentoCP = D.IDDocumentoCP
	) X left join #Aplicaciones A
	on X.IDAplicacion = A.IDAplicacion
ORDER BY  X.IDProveedor, cast(X.IDDocCredito as nvarchar(20)) + cast( X.IDAPLICACION AS NVARCHAR(20) ) + cast( X.IDDocumentoCP AS NVARCHAR(20) )


Select  R.IDProveedor, rtrim(C.NombresCliente) + ' ' + rtrim(C.ApellidosCliente) Nombre,  
R.FechaCredito, R.TipoDocumento, R.IDClase, D.Descr DescrClase, R.Documento,  
case when R.TipoDocumento= 'C' THEN R.MontoOriginal ELSE  R.MontoCredito * -1 END MontoCredito,
case when R.TipoDocumento= 'D' THEN R.DocCredito else R.Documento end DocCredito, R.FechaDocVarOrig, R.VencimientoVarOrig, 
case when R.TipoDocumento= 'D' then datediff(day, R.VencimientoVarOrig, R.FechaCredito) else 0 end DiasVencidosAnt
From #Resultado R inner join dbo.cppProveedores C
on R.IDProveedor = C.IDProveedor inner join dbo.cppClaseDocumento D
on R.IDClase = D.IDClase
Order by OrdenPresentacion asc
-- select * from dbo.cppProveedores
DROP TABLE #Documentos
DROP TABLE #Aplicaciones
DROP TABLE #Resultado
go

create Procedure dbo.cpprptGetDesglosePagos @TipoReporte nvarchar(1), @IDProveedor nvarchar(20),  @FECHAINICIAL DATETIME, @FECHAFINAL DATETIME
-- @TipoReporte = 'D' DETALLADO POR DOCUMENTO, 'C' CONSOLIDADO POR CLIENTE, 'S' CONSOLIDADO POR SUCURSAL
as
SET NOCOUNT ON 


select d.IDProveedor,  A.IDDocCredito, A.DocCredito, A.FechaCredito,A.IDDebito IDFactura,  D.IDClase,  A.IDDocumentoCP IDDocDebito, A.DocDebito,  
A.MontoDebitoAnt, A.MontoCredito,D.IDSubTipo 
into #Fuente
From dbo.cppAplicaciones A inner join dbo.cppDocumentosCP D
on A.IDDocumentoCP = D.IDDocumentoCP INNER JOIN dbo.cppProveedores C
ON D.IDProveedor = C.IDProveedor 
Where (C.IDProveedor = @IDProveedor OR @IDProveedor = '*') and 
A.FechaCredito between @FECHAINICIAL AND @FECHAFINAL AND Anulado = 0


SELECT d.IDProveedor, D.IDDocCredito, D.DocCredito, D.FechaCredito, D.IDFACTURA,  SUM(NOMINAL) NOMINAL, SUM(DESLIZ) DESLIZ,  SUM(INTERES) INTERES,
SUM(NOMINAL+DESLIZ+ INTERES ) TOTALAPLICADO
INTO #DETALLE
FROM 
(
	SElect d.IDProveedor, D.IDDocCredito, D.DocCredito, D.FechaCredito, D.IDFACTURA, d.DocDebito,  case when D.IDClase IN( 'FAC', 'N/D') THEN SUM(MONTOCREDITO)  ELSE 0 END NOMINAL,
	 case when D.IDClase = 'INT' THEN SUM(MONTOCREDITO)  ELSE 0 END INTERES,
	 case when D.IDClase = 'D/C' THEN SUM(MONTOCREDITO)  ELSE 0 END DESLIZ
	From #Fuente D 
	Group by d.IDProveedor,D.IDDocCredito, D.DocCredito, D.FechaCredito, D.IDFACTURA, d.DocDebito, D.IDClase
) D
GROUP BY d.IDProveedor, D.IDDocCredito, D.DocCredito, D.FechaCredito, D.IDFACTURA 

IF UPPER(@TipoReporte) = 'D'
SELECT  d.IDProveedor, rtrim(C.NOMBRESCLIENTE) + ' ' + rtrim(C.APELLIDOSCLIENTE) Nombre, d.IDDoccredito, D.DocCredito, D.FechaCredito, D.IDFactura, f.documento Factura,
D.Nominal, D.Interes, D.Desliz, D.TotalAplicado  --, F.docDebito
FROM #DETALLE D INNER JOIN dbo.cppProveedores C
ON D.IDProveedor = C.IDProveedor inner join dbo.cppDocumentosCP F
on D.idfactura = F.IDDocumentoCP

IF UPPER(@TipoReporte) = 'C'
SELECT  C.IDProveedor, rtrim(C.NOMBRESCLIENTE) + ' ' + rtrim(C.APELLIDOSCLIENTE) Nombre,  SUM(D.Nominal) Nominal, SUM(D.DESLIZ) Deslizamiento, Sum(D.Interes) Interes, sum(D.TotalAplicado) TotalAplicado   --, F.docDebito
FROM #DETALLE D INNER JOIN dbo.cppProveedores C
ON D.IDProveedor = C.IDProveedor inner join dbo.cppDocumentosCP F
on D.idfactura = F.IDDocumentoCP 
GROUP BY C.IDProveedor, C.NOMBRESCLIENTE, C.APELLIDOSCLIENTE

IF UPPER(@TipoReporte) = 'S'
SELECT  SUM(D.Nominal) Nominal, SUM(D.DESLIZ) Deslizamiento, Sum(D.Interes) Interes, sum(D.TotalAplicado)  TotalAplicado  --, F.docDebito
FROM #DETALLE D INNER JOIN dbo.cppProveedores C
ON D.IDProveedor = C.IDProveedor inner join dbo.cppDocumentosCP F
on D.idfactura = F.IDDocumentoCP  inner join dbo.GlobalSucursales S
on C.CODSUCURSAL = S.CODSUCURSAL 


drop table #DETALLE
drop table #fuente
GO

-- para las comisiones exec dbo.cpprptGetDesglosePagosParaComisiones '20150201', '20150228'
-- drop procedure dbo.cpprptGetDesglosePagosParaComisiones

Create View dbo.vcppBaseSaldo
as
Select S.IDSaldo, S.IDDocumentoCP, S.Fecha, S.Saldo, S.SaldoAnt, S.CreateDate
from  dbo.cppSaldoDocumentoCP S
go


-- drop view dbo.vcppDetalleSaldo Select * From dbo.vcppDetalleSaldo where IDDocumentoCP = 33 order by Fecha, orden select * from dbo.cppClaseDocumento
CREATE View dbo.vcppDetalleSaldo
as
Select B.IDSaldo, D.IDDocumentoCP, D.IDProveedor, D.TipoDocumento, D.IDClase, D.IDSubtipo,
D.Documento, D.Fecha, D.Vencimiento, D.Plazo, D.VencimientoVar, D.FechaDocVar,
D.MontoOriginal, D.FechaUltCredito, D.SaldoActual, D.Cancelado, D.PorcInteres, D. Anulado,
B.Fecha FechaSaldo, B.Saldo, B.Createdate FechaCreateSaldo, C.Orden, C.EsInteres, C.EsDeslizamiento
from dbo.vcppBaseSaldo B inner join dbo.cppDocumentosCP D
on B.IDDocumentoCP = D.IDDocumentoCP inner join dbo.cppClaseDocumento C
on D.TipoDocumento = C.TipoDocumento and D.IDClase = C.IDClase inner join dbo.cppProveedores T
on D.IDProveedor = T.IDProveedor 
go

create Procedure dbo.cppGetDocumentosxCobrar  @IDProveedor nvarchar(20), @FechaCorte DATETIME
as 
set nocount on 


SELECT D.*
into #Resultado
FROM 
(
Select IDDocumentoCP, max ( IDSaldo ) IDSaldo
From dbo.vcppDetalleSaldo 
where  (@IDProveedor = '*' or IDProveedor = @IDProveedor) 
and FechaSaldo <= @FechaCorte --and Saldo <> 0
Group by IDDocumentoCP
) S INNER JOIN  dbo.vcppDetalleSaldo D
ON S.IDDocumentoCP = D.IDDocumentoCP AND S.IDSALDO = D.IDSALDO
WHERE D.SALDO <> 0 AND D.TIPODOCUMENTO = 'D'

alter table #Resultado add DiasVencidos int default 0, Deslizamiento decimal(28,4), Intereses decimal(28,4), TotalaPagar decimal(28,4)

--************* para corregir los dias vencidos en caso de que el usuario vaya hacia atras

SELECT A.IDDEBITO, max(A.IDDocumentoCP) IDDocumentoCP,  max(IDAplicacion ) IDAPLICACION
INTO #APLICACIONES
from dbo.cppAplicaciones A INNER JOIN #Resultado R
ON A.IDDEBITO = R.IDDocumentoCP
Where A.FECHACREDITO <= @FechaCorte 
GROUP BY A.IDDEBITO


UPDATE R SET VencimientoVar =  A.FecVencPostApp , FechaDocVar = A.FecDocPostApp 
 --select R.DOCUMENTO, R.VENCIMIENTOVAR, A.FecVencPostApp, R.FECHADOCVAR, A.FecDocPostApp
FROM #Resultado R INNER join (
	select IDDocumentoCP, Fecha, VencimientoVarOrig, FechaCredito, FecVencPostApp,FecDocPostApp, IDDEBITO
	From dbo.cppAplicaciones
	where IDAplicacion in
		(
			Select IDAPLICACION from #APLICACIONES
		)
	) A on R.IDDocumentoCP = A.IDDEBITO
WHERE A.FechaCredito <= @FechaCorte

SELECT R.IDDocumentoCP 
into #ConApp
FROM #Resultado R INNER join (
	select IDDocumentoCP, Fecha, VencimientoVarOrig, FechaCredito, FecVencPostApp,FecDocPostApp, IDDEBITO
	From dbo.cppAplicaciones
	where IDAplicacion in
		(
			Select IDAPLICACION from #APLICACIONES
		)
	) A on R.IDDocumentoCP = A.IDDEBITO
WHERE A.FechaCredito <= @FechaCorte


-- los que no tienen aplicaciones
Update R set VencimientoVar = R.Vencimiento, FechaDocVar = R.Fecha
From #Resultado R --left join dbo.cppAplicaciones A
--on R.IDDocumentoCP = A.IDDocumentoCP
Where  R.IDDocumentoCP not in (Select IDDocumentoCP from #ConApp )
--***************

Update #Resultado set DiasVencidos =(select datediff(day, VencimientoVar,@FechaCorte )),
Deslizamiento =  (Select dbo.cppGetDeslizamiento(Saldo , FechaDocVar , @FechaCorte, IDDocumentoCP) )

Update #Resultado set Intereses = (select dbo.cppGetInteres (Saldo, Deslizamiento, PorcInteres, DiasVencidos))

Update #Resultado set Intereses = case when Intereses<=0 then 0 else Intereses end 

Update #Resultado set TotalaPagar = Saldo + Intereses + Deslizamiento

select IDSaldo, IDDocumentoCP, IDProveedor,TipoDocumento, IDClase, IDSubtipo, Documento, Fecha, FechaDocVar, Vencimiento, VencimientoVar, Plazo,
	MontoOriginal, FechaUltCredito, SaldoActual, FechaSaldo, Saldo,DiasVencidos,  Saldo SaldoNominal,Deslizamiento,  Intereses,  TotalaPagar, EsInteres, EsDeslizamiento
	
From #Resultado
order by Vencimiento,Fecha,Documento asc
--SE MODIFICO EL ORDER BY  AGREGANDO LA FECHA FACTURA PARA QUE LA PRESENTACION IMPRESA SE MUESTR OK.


DROP TABLE #APLICACIONES
DROP TABLE #Resultado
DROP TABLE #ConApp
go


-- Para Anular un Documento

CREATE Procedure dbo.cppAnularDocumentoCP @IDDocumentoCP int
-- ANULA DOCUMENTOS DE CREDITO
as
set nocount on

if exists ( Select IDAplicacion From dbo.cppAplicaciones where IDDocumentoCP = @IDDocumentoCP )
begin
	
	RAISERROR ('Ud no puede Anular ese Documento porque hay aplicaciones para el mismo, tiene que solicitar una N/C', -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );	
    Return
end

Declare @Asiento nvarchar(20), @Documento nvarchar(20), @IDProveedor nvarchar(10), @IDClase nvarchar(10)
Select @Asiento = Asiento, @Documento = Documento,  @IDProveedor = IDProveedor, @IDClase = IDClase 
From dbo.cppDocumentosCP D
where IDDocumentoCP= @IDDocumentoCP
 
begin try

Delete From dbo.cppSaldoDocumentoCP where IDDocumentoCP = @IDDocumentoCP 
Update D set Anulado = 1, SaldoActual = 0, ConceptoUsuario = '***ANULADO***', ConceptoSistema = '***ANULADO***'
From dbo.cppDocumentosCP D
where IDDocumentoCP= @IDDocumentoCP
-- este es un script que extrajimos del proceso de edjamit en la facturacion, esto es solamente para las fact de Credito
--anulamos la factura segun el criterio.


end try
begin catch
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );	
end catch

go

--exec dbo.cppGetAntiguedadSaldos 'MT01', 'MT260', '20130830', 0,0 select * from dbo.cppAplicaciones Select * From dbo.cppSaldoDocumentoCP
-- DROP  PROCEDURE dbo.cppGetAntiguedadSaldos
create Procedure dbo.[cppGetAntiguedadSaldos] @IDProveedor nvarchar(20), @FechaCorte DATETIME,
@InclyeInteresAlNominal bit, @InclyeDeslizamientoAlNominal bit, @ConsolidaSucursal bit = null, @EnDolar bit = null
as
declare @TipoCambio as decimal(18,4)

set nocount on 
if @ConsolidaSucursal is null
	set @ConsolidaSucursal = 0
if @EnDolar is null
	set @EnDolar = 0

if @EnDolar = 1
	select @TipoCambio=( SELECT dbo.[globalGetUltTasadeCambio] (@FechaCorte))	
else
	set @TipoCambio = 0
Create Table #Resultados( IDSaldo int, IDDocumentoCP int, IDProveedor nvarchar(20), 
TipoDocumento nvarchar(1), IDClase nvarchar(10), IDSubtipo int, Documento nvarchar(20), 
Fecha datetime, FechaDocVar datetime, Vencimiento datetime, VencimientoVar datetime, Plazo decimal(8,2),
MontoOriginal decimal(28,4), FechaUltCredito datetime, SaldoActual decimal(28,4), 
FechaSaldo datetime, Saldo decimal(28,4) ,DiasVencidos int,  SaldoNominal decimal(28,4) ,  Intereses decimal(28,4) , 
Deslizamiento decimal(28,4) , TotalaPagar decimal(28,4), EsInteres bit, EsDeslizamiento bit 
)
	
Insert #Resultados (IDSaldo, IDDocumentoCP, IDProveedor, TipoDocumento, IDClase, IDSubtipo, 
Documento, Fecha, FechaDocVar, Vencimiento, VencimientoVar, Plazo,	MontoOriginal, FechaUltCredito, SaldoActual, 
FechaSaldo, Saldo,DiasVencidos,  SaldoNominal, Deslizamiento,Intereses, TotalaPagar, EsInteres, EsDeslizamiento)
exec dbo.cppGetDocumentosxCobrar  @IDProveedor, @FechaCorte

if @EnDolar = 1
	Update #Resultados set MontoOriginal = case when @TipoCambio > 0 then  MontoOriginal / @TipoCambio  else MontoOriginal end,
	SaldoActual = case when @TipoCambio > 0 then  SaldoActual / @TipoCambio  else SaldoActual end,
	Saldo = case when @TipoCambio > 0 then  Saldo / @TipoCambio  else Saldo end,
	SaldoNominal = case when @TipoCambio > 0 then  SaldoNominal / @TipoCambio  else SaldoNominal end,
	Intereses = case when @TipoCambio > 0 then  Intereses / @TipoCambio  else Intereses end,
	Deslizamiento = case when @TipoCambio > 0 then  Deslizamiento / @TipoCambio  else Deslizamiento end,
	TotalaPagar = case when @TipoCambio > 0 then  TotalaPagar / @TipoCambio  else TotalaPagar end


Delete From #Resultados
Where ( EsInteres = 1 and @InclyeInteresAlNominal = 0) or (EsDeslizamiento = 1 and @InclyeInteresAlNominal = 0)


	SELECT  IDProveedor,NOMBRE, SUM(ISNULL(NominalNovencido,0)) NominalNovencido,
	SUM(ISNULL(Nominala30,0)) Nominala30,
	SUM(ISNULL(Nominal31a60,0)) Nominal31a60,
	SUM(ISNULL(Nominal61a90,0)) Nominal61a90,  
	SUM(ISNULL(Nominal91a120,0)) Nominal91a120,  
	SUM(ISNULL(Nominal21a180,0)) Nominal21a180,
	SUM(ISNULL(Nominal81a600,0)) Nominal81a600,
	SUM(ISNULL(Nominalmas600,0)) Nominalmas600,
	SUM(ISNULL(NominalNovencido,0)+ ISNULL(Nominala30,0)+ ISNULL(Nominal31a60,0)+ ISNULL(Nominal61a90,0)+
	ISNULL(Nominal91a120,0)+ISNULL(Nominal21a180,0)+ISNULL(Nominal81a600,0)+ISNULL(Nominalmas600,0)) TotalCliente
	into #ResultadoDetallado
	FROM (
		SELECT  IDProveedor,NOMBRE, RANGO, case when rango = 'NO-VENC' then SUM(Nominal) ELSE 0 end NominalNovencido,
		case when rango = '1-30' then SUM(Nominal) ELSE 0 end Nominala30,
		case when rango = '31-60' then SUM(Nominal) ELSE 0 end Nominal31a60,
		case when rango = '61-90' then SUM(Nominal) ELSE 0 end Nominal61a90,
		case when rango = '91-120' then SUM(Nominal) ELSE 0 end Nominal91a120,
		case when rango = '121-180' then SUM(Nominal) ELSE 0 end Nominal21a180,
		case when rango = '181-600' then SUM(Nominal) ELSE 0 end Nominal81a600,
		case when rango = '+600' then SUM(Nominal) ELSE 0 end Nominalmas600    
		FROM 
		(
				SELECT  a.IDProveedor, b.NombresCliente + ' '+ b.apellidoscliente Nombre, a.DiasVencidos,  
		CASE WHEN a.DiasVencidos BETWEEN 1 AND 30 THEN '1-30' ELSE
			CASE WHEN a.DiasVencidos BETWEEN 31 AND 60 THEN '31-60' ELSE
				CASE WHEN a.DiasVencidos BETWEEN 61 AND 90 THEN '61-90' ELSE
					CASE WHEN a.DiasVencidos BETWEEN 91 AND 120 THEN '91-120' ELSE
						CASE WHEN a.DiasVencidos BETWEEN 121 AND 180 THEN '121-180' ELSE
							CASE WHEN a.DiasVencidos BETWEEN 181 AND 600 THEN '181-600' ELSE
								CASE WHEN a.DiasVencidos > 600 THEN '+600' ELSE
										CASE WHEN ( a.DiasVencidos <=0 ) THEN 'NO-VENC' ELSE 'ND' END
								END		
							END
						END
					END
				END				
			END
		END RANGO,
		(a.SaldoNominal+(a.Deslizamiento*@InclyeDeslizamientoAlNominal)+(a.Intereses*@InclyeInteresAlNominal))   Nominal--, a.Intereses Interes, a.TotalaPagar Total 
		FROM #Resultados a INNER JOIN dbo.cppProveedores b
		ON a.IDProveedor = b.IDProveedor


		) T1
		GROUP BY  IDProveedor, NOMBRE, RANGO
	) T2
	GROUP BY  IDProveedor, NOMBRE
	HAVING SUM(ISNULL(NominalNovencido,0)+ ISNULL(Nominala30,0)+ ISNULL(Nominal31a60,0)+ ISNULL(Nominal61a90,0)+
	ISNULL(Nominal91a120,0)+ISNULL(Nominal21a180,0)+ISNULL(Nominal81a600,0)+ISNULL(Nominalmas600,0)) > 0
	


if @ConsolidaSucursal = 0
begin
	Select  IDProveedor,NOMBRE, NominalNovencido, Nominala30, Nominal31a60, Nominal61a90, Nominal91a120, Nominal21a180, Nominal81a600,
	Nominalmas600, TotalCliente
	From #ResultadoDetallado
end

if @ConsolidaSucursal = 1
begin
	Select  sum( NominalNovencido) NominalNovencido, sum(Nominala30) Nominala30, sum(Nominal31a60) Nominal31a60, 
	sum(Nominal61a90) Nominal61a90, sum(Nominal91a120) Nominal91a120, sum(Nominal21a180) Nominal21a180, sum(Nominal81a600) Nominal81a600 ,
	sum(Nominalmas600) Nominalmas600, sum(TotalCliente) TotalCliente
	From #ResultadoDetallado

end

drop table #Resultados
drop table #ResultadoDetallado

go



-- Para Anular un Documento



GO

--Drop procedure dbo.cppAplicaUndoCredito select * from dbo.cppDocumentosCP
-- exec dbo.cppAplicaUndoCredito  817 
-- TipoDocumento = 'C' and Fecha >= '2014-09-30 00:00:00.000' and anulado = 0
create Procedure dbo.cppAplicaUndoCredito @IDDocCredito int, @IDProveedor nvarchar(20)
as
set nocount on

Declare @FechaCredito datetime, @iRwCnt int, @i int, @IDDoc int, @flgInteres int, @flgDeslizam int, @Especial bit, @IDSubTipo int 
SELECT @FechaCredito = Fecha, @IDSubTipo = IDSubTipo 
FROM dbo.cppDocumentosCP (NOLOCK)
where IDDocumentoCP = @IDDocCredito

Select top 1 @Especial = Especial
from dbo.cppSubTipoDocumento  (NOLOCK)
where IDSubTipo = @IDSubTipo

if not exists (Select IDClase  From dbo.cppDocumentosCP (NOLOCK) where IDProveedor = @IDProveedor and  IDDocumentoCP= @IDDocCredito and
 TipoDocumento = 'C' and anulado = 0)
begin
    RAISERROR ('Solamente se permite Desaplicar un documento tipo Credito (R/C o N/C o O/C). ', -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );	
    Return

end

if @Especial = 0 and  exists(Select Fecha From dbo.cppDocumentosCP where IDProveedor = @IDProveedor and  IDDocumentoCP > @IDDocCredito and
 TipoDocumento = 'C' and Fecha >= @FechaCredito and anulado = 0 )
begin
    RAISERROR ('Ud no puede Revertir ese Documento Crédito porque hay afectaciones posteriores al mismo (R/C o N/C), tiene que eliminar los posteriores. ', -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );	
    Return
end
else
begin
begin transaction 
begin try

	Select top 1 @flgInteres = cast(CobraInteresMora as int), @flgDeslizam = cast(CobraDeslizamiento   as int)
	From dbo.cppParametrosGenerales (NOLOCK)
	
	Select A.* --A.IDDocumentoCP
	into #IntDesl
	From dbo.cppAplicaciones  A  (NOLOCK) INNER JOIN dbo.cppDocumentosCP D (NOLOCK)
	on A.IDDocumentoCP = D.IDDocumentoCP
	where A.IDDocCredito = @IDDocCredito and D.IDClase in ('INT', 'D/C')		
	
	alter table #IntDesl add ID int identity(1,1)
	set @iRwCnt = (Select count(*) from #IntDesl) 	 
	create clustered index idx_tmp on #IntDesl(ID) WITH FILLFACTOR = 100	
	SET @i = 1

	while @i <= @iRwCnt
	begin
		SELECT @IDDoc = IDDocumentoCP From #IntDesl where ID = @i
		Delete From dbo.cppSaldoDocumentoCP where IDDocumentoCP = @IDDoc  
		Delete From dbo.cppAplicaciones where IDDocumentoCP = @IDDoc
		exec dbo.cppAnularDocumentoCP @IDDoc
		set @i = @i + 1
	end	
	-- Para los Debitos No Interes y Deslizam
	Select A.* --A.IDDocumentoCP
	into #Debitos
	From dbo.cppAplicaciones A (NOLOCK) INNER JOIN dbo.cppDocumentosCP D (NOLOCK)
	on A.IDDocumentoCP = D.IDDocumentoCP
	where A.IDDocCredito = @IDDocCredito and D.IDClase in ('FAC', 'N/D','O/D')	

	alter table #Debitos add ID int identity(1,1)

	set @iRwCnt = (Select count(*) from #Debitos) 	 
	create clustered index idx_tmp2 on #Debitos(ID) WITH FILLFACTOR = 100	
	SET @i = 1
-- select * from dbo.cppAplicaciones 
	while @i <= @iRwCnt
	begin
		SELECT @IDDoc = IDDocumentoCP From #Debitos where ID = @i
		Update D set SaldoActual = A.MontoDebitoAnt, VencimientoVar = A.VencimientoVarOrig, FechaDocVar = A.FechaDocVarOrig,
		FechaUltCredito = A.FechaUltCreditoAnt
		From dbo.cppDocumentosCP D (NOLOCK) inner join dbo.cppAplicaciones A (NOLOCK)
		on D.IDDocumentoCP = A.IDDocumentoCP 
		Where A.IDDocCredito = @IDDocCredito

		Delete From dbo.cppSaldoDocumentoCP where IDDocumentoCP = @IDDoc --and SaldoAnt <> 0 -- Revisar esto solo eliminar las facturas >= fecha del recibo
		AND IDAPLICACION IN (SELECT IDAPLICACION FROM dbo.cppAplicaciones (NOLOCK) where IDDocumentoCP = @IDDoc AND IDDOCCREDITO = @IDDocCredito )
		Delete From dbo.cppAplicaciones where IDDocumentoCP = @IDDoc AND IDDOCCREDITO = @IDDocCredito
		
		set @i = @i + 1
	end

		Delete From dbo.cppSaldoDocumentoCP where IDDocumentoCP = @IDDocCredito 
		Delete From dbo.cppAplicaciones where IDDocumentoCP = @IDDocCredito
		exec dbo.cppAnularDocumentoCP @IDDocCredito

-- para actualizar los debitos que no fueron tocados a ellos mismos como documentos pero si generaron interes o deslizamiento
	if @flgInteres = 1 or @flgDeslizam = 1	
	begin
		Select IDDebito, count(*) Cantidad
		into #DebitosSinAfectar
		From 
		( Select * from #IntDesl
			union all
		  Select * from #Debitos
		) x
		group by IDDebito
		having (count(*)) < (@flgInteres+@flgDeslizam+1)
		
		Update D set FechaDocVar = A.FechaDocVarOrig, VencimientoVar = A.VencimientoVarOrig
		From dbo.cppDocumentosCP D inner join ( Select ID.* from #IntDesl ID inner join  #DebitosSinAfectar S on ID.IDDebito = S.IDDebito ) A
		on D.IDDocumentoCP = A.IDDebito
	end

drop table #IntDesl
drop table #Debitos
drop table #DebitosSinAfectar
commit
end try
begin catch
	IF OBJECT_ID('#IntDesl') IS NOT NULL
		DROP TABLE #IntDesl
	IF OBJECT_ID('#Debitos') IS NOT NULL
		DROP TABLE #Debitos	
	IF OBJECT_ID('#DebitosSinAfectar') IS NOT NULL
		DROP TABLE #Debitos			
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	rollback
SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
	
end catch
end


go

--select dbo.cppGetNextConsecRecibo('MG01')
-- drop function dbo.GetNextConsecRecibo
Create Function dbo.cppGetNextConsecRecibo(  @CODSUCURSAL AS NVARCHAR (10) )
returns int
AS
BEGIN
declare @Next int

	set @Next = (SELECT ISNULL( MAX ( CONVERT ( INTEGER , Documento ) ) , 0 )+ 1 
		FROM dbo.cppDocumentosCP (NOLOCK)
		WHERE TipoDocumento = 'C' AND IDCLASE = 'R/C'
	--		convert (varchar , FECHAINGRESO, 112 ) >= '20100525'
	)
	if @Next is null
		set @Next = 1

	return @Next
END
go

--select dbo.cppGetNextConsecutivo('C', 'R/C', '*')

Create Function dbo.cppGetNextConsecutivo(  @TipoDocumento nvarchar(1), @IDClaseDoc nvarchar(20))
-- Devuelve el Consecutivo de un documento pasando su tipo, clase y para todas las sucursales o no
returns int
AS
BEGIN
declare @Next int

	set @Next = (SELECT ISNULL( MAX ( CONVERT ( INTEGER , Documento ) ) , 0 )+ 1 
		FROM dbo.cppDocumentosCP (NOLOCK)
		WHERE TipoDocumento = @TipoDocumento AND IDCLASE = @IDClaseDoc
	--		convert (varchar , FECHAINGRESO, 112 ) >= '20100525'
	)
	if @Next is null
		set @Next = 1

	return @Next
END
go


-- SEGUNDA PARTE
CREATE PROCEDURE dbo.[cppUpdatecppAplicaciones] 
-- 'I' insertar  'S' Actualizar Saldos de Debitos y Creditos en Aplicaciones
@Operation nvarchar(1), @IDDocDebito int, @IDDocCredito int, @SaldoRecibo decimal(28,4)  OUTPUT, 
@AplicaInteresAutom bit =1, @AplicaDeslizamAutom bit =1, @ConceptoSistema nvarchar(500),@ConceptoUsuario nvarchar(500), 
@RecibimosDe nvarchar(250), @Usuario nvarchar(20), @TipoCambio decimal(28,4) 
as
set nocount on
Declare		@IDAplicacion int , @Fecha datetime, @FechaCredito datetime, @MontoDebitoAnt decimal(28,4), 
		@MontoDebitoAct decimal(28,4), @MontoCreditoAnt decimal(28,4),  @MontoCreditoAct decimal(28,4),  
		@MontoCredito decimal(28,4) , @IDDocumentoCP int, @ValorInteres decimal(28,4), @DifRestante decimal(28,4), @FechaInteresNew datetime, 
		@FechaDeslizNew datetime,  @ValorDesliz decimal(28,4),  --@TipoCambio decimal(28,4),
		@IDProveedor nvarchar(10) ,@CodSucursal nvarchar(4) ,@TipoDocumento nvarchar(1) ,
		@IDSubTipo	int , @Documento nvarchar(20) ,  @Vencimiento datetime ,
		@Plazo decimal(8,2) , @VencimientoVar datetime , @FechaDocVar datetime , @MontoOriginal decimal(28,4) ,@FechaUltCredito datetime ,
		@SaldoActual  decimal(28,4) ,@Cancelado bit ,@PorcInteres decimal(8,2),@Anulado bit,
		@NoDocInteres nvarchar(20), @NoDocDeslizamiento nvarchar(20), @Hoy datetime, @DiasVencidos int, @DiasDocumentoVar int,
		@IDSaldo int,
		@SaldoAnteriorDebito decimal(28,4) , @SaldoActualDebito decimal(28,4),
		@SaldoAnteriorCredito decimal(28,4), @SaldoActualCredito decimal(28,4), @SaldoAnterior decimal(28,4),
		@FechaDocVarOrig datetime, @VencimientoVarOrig datetime, @IDSubtipoDesliz int, 
		@IDClaseInteres nvarchar(10), @IDClaseDeslizamiento nvarchar(10), @IDClase nvarchar(10),@DocDebito nvarchar(20), @DocCredito NVARCHAR(20)
Declare @FecDocPostApp datetime, @FecVencPostApp datetime
		

IF @Operation = 'I'
BEGIN

if not exists ( Select IDDocumentoCP From dbo.cppDocumentosCP Where IDDocumentoCP = @IDDocCredito )
begin
    RAISERROR ('EL ID DEL CREDITO NO EXISTE', -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
               RETURN
end

Select @Hoy = Fecha, @DocCredito = DOCUMENTO From dbo.cppDocumentosCP where IDDocumentoCP = @IDDocCredito AND TIPODOCUMENTO = 'C' --) --(select getdate())

Select @IDClaseInteres = IDClase, @IDSubTipo = IDSubTipo From dbo.cppSubTipoDocumento 
where IDClase in (Select IDClase From  dbo.cppCLASEDOCUMENTO 
	Where esInteres= 1  )

Select @IDClaseDeslizamiento = IDClase, @IDSubtipoDesliz = IDSubTipo 
From dbo.cppSubTipoDocumento 
where IDClase in (Select IDClase From  dbo.cppCLASEDOCUMENTO 
	Where esDeslizamiento= 1  ) 

set @IDDocumentoCP  = @IDDocDebito
set @FechaCredito = @Hoy


set @MontoCreditoAct = @SaldoRecibo
set @MontoCredito = @SaldoRecibo
	
	Select @IDProveedor = IDProveedor  ,  @TipoDocumento = TipoDocumento, @IDClase = IDClase,
	@Documento = Documento, @Fecha= Fecha, @Vencimiento= Vencimiento,
	@Plazo = Plazo, @VencimientoVar=VencimientoVar, @FechaDocVar = FechaDocVar,
	@PorcInteres = PorcInteres , @SaldoActual = SaldoActual, @FechaUltCredito = FechaUltCredito 
	From dbo.cppDocumentosCP 
	where IDDocumentoCP= @IDDocumentoCP 
	
	set @FechaDocVarOrig =  @FechaDocVar 
	set @VencimientoVarOrig = @VencimientoVar
	
	set @DiasVencidos		 = (select datediff(day, @VencimientoVar,@FechaCredito ))
	set @ValorDesliz = ( select dbo.cppGetDeslizamiento(@SaldoActual , @FechaDocVar , @FechaCredito, @IDDocumentoCP) )
	if @DiasVencidos > 0
	begin
		set @ValorInteres = (select dbo.cppGetInteres (@SaldoActual, @ValorDesliz, @PorcInteres, @DiasVencidos ))
		set @NoDocInteres = @Documento + '-I-' + @DocCredito
		--+ left ('0' + cast(day(@Hoy) as nvarchar(2)),2) +  
		--					left ('0' + cast(month(@Hoy) as nvarchar(2)),2) + cast(year(@Hoy) as nvarchar(4))		
	end
	else
		set @ValorInteres = 0	
	
	-- SOLO ABONA RECIBO Y NO CANCELA TODO
		if  (@AplicaInteresAutom = 1) and (@SaldoRecibo <= @ValorInteres and @ValorInteres <> 0 and @SaldoRecibo<>0 )
		begin

			set @DiasVencidos		 = (select round((@SaldoRecibo * @DiasVencidos)/@ValorInteres,0))
			set @ValorInteres = @SaldoRecibo -- se pone el valor de interes real a cobrar y no el total de interes
			-- creo el doc interes 
			exec dbo.cppUpdatecppDocumentosCP 'I',  @IDDocumentoCP Output, 
			@IDProveedor   ,'D' , @IDClaseInteres,
			@IDSubTipo	 , @NoDocInteres , @Hoy , @Plazo , @SaldoRecibo , @PorcInteres, 
			@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio

			--set @DifRestante = @SaldoActual-@MontoCredito		
			set @FechaInteresNew = (select dateadd(day,@DiasVencidos, @VencimientoVar))

			Update dbo.cppDocumentosCP set VencimientoVar = @FechaInteresNew 
			where IDDocumentoCP = @IDDocDebito

			-- Actualizo las variables de Saldos de debito y credito
			set @SaldoAnteriorDebito = @ValorInteres
			set @SaldoActualDebito = 0
			set @SaldoAnteriorCredito = @SaldoRecibo -- [fnica].[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
			set @SaldoActualCredito = @SaldoAnteriorCredito - @ValorInteres
					
			-- Aplico el INTERES y su Aplicacion
			INSERT dbo.[cppAplicaciones] (
				  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
				  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct],
				  [MontoCreditoAnt]  ,[MontoCreditoAct],  FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito, FecDocPostApp, FecVencPostApp 
			)
			VALUES ( @IDDocumentoCP, @IDDocCredito,@NoDocInteres, @DocCredito, @FechaCredito, @FechaCredito,
				 @SaldoRecibo, @SaldoAnteriorDebito, @SaldoActualDebito , @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, 
				 @FechaUltCredito, @IDDocDebito, @FecDocPostApp, @FecVencPostApp )
			Set @IDAplicacion = (SELECT SCOPE_IDENTITY())		
			Set @SaldoRecibo =  0 
			-- Saldo del Credito
		
			exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
					@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito, @IDAplicacion
			
			-- Saldo del Debito
			exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocumentoCP , 
					@FechaCredito ,  @SaldoActualDebito , @SaldoAnteriorDebito , @IDAplicacion

			Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito where IDDocumentoCP = @IDDocumentoCP					
			Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito
		-- SOLO ABONA RECIBO Y NO CANCELA TODO
		end 		
		else 
		-- EL RECIBO CANCELA EL INTERES Y SOBRA
		begin

			-- creo el interes
			-- EL SALDO DEL RECIBO ES MAYOR QUE EL INTERES
			IF  (@AplicaInteresAutom = 1) and (@ValorInteres > 0 and @SaldoRecibo > @ValorInteres )
			BEGIN
			-- Actualizo las variables de Saldos de debito y credito
			set @SaldoAnteriorDebito = @ValorInteres
			set @SaldoActualDebito = 0
			set @SaldoAnteriorCredito = @SaldoRecibo 
			set @SaldoActualCredito = @SaldoAnteriorCredito - @ValorInteres
						
				exec dbo.cppUpdatecppDocumentosCP 'I',  @IDDocumentoCP Output, 
				@IDProveedor    ,'D' , @IDClaseInteres,
				@IDSubTipo	 , @NoDocInteres , @Hoy , @Plazo  , @ValorInteres ,@PorcInteres, 
				@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio

				set @SaldoAnterior = dbo.[cppGetSaldoActualDocumentoCC] (@IDDocumentoCP )
				-- Aplico el INTERES 

				INSERT dbo.[cppAplicaciones] (
					  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
					  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct], 
					  [MontoCreditoAnt]  ,[MontoCreditoAct],FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito
					  , FecDocPostApp, FecVencPostApp
				)
				VALUES ( @IDDocumentoCP, @IDDocCredito,@NoDocInteres, @DocCredito, @FechaCredito, @FechaCredito,
					 @ValorInteres, @SaldoAnteriorDebito, @SaldoActualDebito , @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, @FechaUltCredito,  @IDDocDebito
					 , @FecDocPostApp, @FecVencPostApp)					 
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito  where IDDocumentoCP = @IDDocumentoCP					
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito
					 

				Set @IDAplicacion = (SELECT SCOPE_IDENTITY())				
				set @FechaInteresNew = @FechaCredito
				Update dbo.cppDocumentosCP set VencimientoVar = @FechaInteresNew 
				where IDDocumentoCP = @IDDocDebito	

				set @SaldoRecibo = @SaldoRecibo - @ValorInteres
				set @SaldoAnterior = dbo.[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
				exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
					@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito,  @IDAplicacion -- @SaldoRecibo , @SaldoAnterior
				-- Saldo del Debito
				exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocumentoCP , 
					@FechaCredito , 0 , @ValorInteres,  @IDAplicacion				
			-- EL SALDO DEL RECIBO ES MAYOR QUE EL INTERES
			END			
			if 	 (@AplicaDeslizamAutom = 1) and (@SaldoRecibo <= @ValorDesliz and @SaldoRecibo<> 0 )  -- El saldo del Credito abona al deslizamiento
			begin
			-- Actualizo las variables de Saldos de debito y credito
			set @SaldoAnteriorDebito = @ValorDesliz
			set @SaldoActualDebito = 0
			set @SaldoAnteriorCredito = @SaldoRecibo --[fnica].[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
			set @SaldoActualCredito = (select case when @SaldoAnteriorCredito > @ValorDesliz
										then  @SaldoAnteriorCredito - @ValorDesliz	else 0 end)
				-- creo el Deslizamiento
				set @NoDocDeslizamiento = @Documento + '-D-' + @DocCredito
				-- left ('0' + cast(day(@Hoy) as nvarchar(2)),2) +  
				--				left ('0' + cast(month(@Hoy) as nvarchar(2)),2) + cast(year(@Hoy) as nvarchar(4))		
				
				exec dbo.cppUpdatecppDocumentosCP 'I',  @IDDocumentoCP Output, 
				@IDProveedor    ,'D' ,  @IDClaseDeslizamiento,
				@IDSubtipoDesliz	 , @NoDocDeslizamiento , @Hoy , @Plazo , @SaldoRecibo ,@PorcInteres,
				@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio	
				-- Aplico el DESLIZAMIENTO 

				
				INSERT dbo.[cppAplicaciones] (
					  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
					  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct],
					  [MontoCreditoAnt]  ,[MontoCreditoAct],FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito
					  , FecDocPostApp, FecVencPostApp
					  
				)
				VALUES ( @IDDocumentoCP, @IDDocCredito,@NoDocDeslizamiento, @DocCredito, @FechaCredito, @FechaCredito,
					 @SaldoRecibo,@SaldoAnteriorDebito, @SaldoActualDebito , @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, @FechaUltCredito, @IDDocDebito
					 , @FecDocPostApp, @FecVencPostApp)					 
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito where IDDocumentoCP = @IDDocumentoCP					
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito
					 
				SET @DiasDocumentoVar = ( SELECT DATEDIFF(day, @FechaDocVar, @FechaCredito) )
				-- el desliza es saldorecibo aqui el problema
				set @DiasDocumentoVar = (select cast(round((@SaldoRecibo * @DiasDocumentoVar) / @ValorDesliz,0) as int) )
				--set  @DiasDocumentoVar =(select cast(( Select round((@SaldoRecibo * @DiasDocumentoVar) / @SaldoRecibo,0)  ) as int) 

				Update dbo.cppDocumentosCP set FechaDocVar = ( select dateadd(day, @DiasDocumentoVar, @FechaDocVar ) )
				where IDDocumentoCP = @IDDocDebito		
				Set @IDAplicacion = (SELECT SCOPE_IDENTITY())		
					 
				Set @SaldoRecibo =  0 	

				--Saldo del Credito 
							
				exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
					@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito,  @IDAplicacion --@SaldoRecibo , @ValorDesliz

				--Saldo del Debito
				exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocumentoCP , 
					@FechaCredito , @SaldoActualDebito , @SaldoAnteriorDebito, @IDAplicacion

										
			end
			ELSE 
			-- PUEDO PAGAR EL DESLIZAMIENTO Y ME SOBRA				
			BEGIN

				-- creo el Deslizamiento
				IF (@AplicaDeslizamAutom = 1) and ( @ValorDesliz > 0 and @SaldoRecibo > @ValorDesliz )
				BEGIN
			-- Actualizo las variables de Saldos de debito y credito
				set @SaldoAnteriorDebito = @ValorDesliz
				set @SaldoActualDebito = 0
				set @SaldoAnteriorCredito =  @SaldoRecibo -- [fnica].[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
				set @SaldoActualCredito = @SaldoAnteriorCredito - @ValorDesliz

				
					set @NoDocDeslizamiento = @Documento + '-D-' + @DocCredito
					--left ('0' + cast(day(@Hoy) as nvarchar(2)),2) +  
					--				left ('0' + cast(month(@Hoy) as nvarchar(2)),2) + cast(year(@Hoy) as nvarchar(4))		
					
					exec dbo.cppUpdatecppDocumentosCP 'I',  @IDDocumentoCP Output, 
					@IDProveedor    ,'D' ,  @IDClaseDeslizamiento,
					@IDSubtipoDesliz	 , @NoDocDeslizamiento , @Hoy , @Plazo , @ValorDesliz ,@PorcInteres ,
					@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio	
					-- Aplico el DESLIZAMIENTO 

					INSERT dbo.[cppAplicaciones] (
						  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
						  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct],
						  [MontoCreditoAnt]  ,[MontoCreditoAct],FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito
						  , FecDocPostApp, FecVencPostApp
					)
						
					VALUES ( @IDDocumentoCP, @IDDocCredito,@NoDocDeslizamiento, @DocCredito, @FechaCredito, @FechaCredito,
						 @ValorDesliz, @SaldoAnteriorDebito, @SaldoActualDebito , @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, @FechaUltCredito, @IDDocDebito
						 , @FecDocPostApp, @FecVencPostApp)
					Set @IDAplicacion = (SELECT SCOPE_IDENTITY())
					Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito  where IDDocumentoCP = @IDDocumentoCP	
				
					Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito
						 

					Update dbo.cppDocumentosCP set FechaDocVar = @FechaCredito
					where IDDocumentoCP = @IDDocDebito	

					set @SaldoRecibo = @SaldoRecibo - @ValorDesliz

					set @SaldoAnterior = (@SaldoRecibo + @ValorDesliz)
					-- Saldo del Credito
					set @SaldoAnterior = dbo.[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
				
					exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
						@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito, @IDAplicacion --@SaldoRecibo , @SaldoAnterior
					-- Saldo del Debito
					exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocumentoCP , 
						@FechaCredito , 0 , @ValorDesliz, @IDAplicacion	

					
				END	

							
				if (@SaldoRecibo <= @SaldoActual and @SaldoRecibo <>0 ) -- el saldo del recibo es menor que saldo de la factura, la abona
				begin

				set @SaldoAnteriorCredito =  dbo.[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
				set @SaldoAnteriorDebito = @SaldoActual 
				set @SaldoActualDebito = @SaldoActual - @SaldoRecibo 			
				set @SaldoActualCredito = @SaldoAnteriorCredito - @SaldoRecibo  --0 -- Zepeda1410 estaba fijo con valor cero lo quiero cambiar a @SaldoAnteriorCredito - @SaldoRecibo
					-- Aplico la Factura
					
					INSERT dbo.[cppAplicaciones] (
						  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
						  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct],
						  [MontoCreditoAnt]  ,[MontoCreditoAct],FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito
						  , FecDocPostApp, FecVencPostApp
					)
					VALUES ( @IDDocDebito, @IDDocCredito,@Documento, @DocCredito, @Fecha, @FechaCredito,
					 @SaldoRecibo, @SaldoAnteriorDebito, @SaldoActualDebito , @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, @FechaUltCredito, @IDDocDebito
					 , @FecDocPostApp, @FecVencPostApp)						 
						
					Set @IDAplicacion = (SELECT SCOPE_IDENTITY())						 
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito where IDDocumentoCP = @IDDocDebito --@IDDocumentoCP					
				
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito
	 
					Update dbo.cppDocumentosCP set SaldoActual = SaldoActual - @SaldoRecibo
					where IDDocumentoCP = @IDDocDebito

					set @SaldoRecibo = 0
					set @SaldoAnterior =(@SaldoRecibo + @ValorDesliz)
					exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocDebito , 
						@FechaCredito , @SaldoActualDebito , @SaldoAnteriorDebito , @IDAplicacion 

					exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
						@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito , @IDAplicacion 
											
				end
				else
				begin
					-- Aplico la Factura
					if (@SaldoRecibo > @SaldoActual  )
					begin
				set @SaldoAnteriorDebito = dbo.[cppGetSaldoActualDocumentoCC] (@IDDocDebito )
				set @SaldoActualDebito = 0
				set @SaldoAnteriorCredito =  dbo.[cppGetSaldoActualDocumentoCC] (@IDDocCredito )
				set @SaldoActualCredito = @SaldoAnteriorCredito - @SaldoAnteriorDebito						

						SET @Vencimiento = DATEADD(day, @Plazo, @Fecha )
						SET @VencimientoVar = @Vencimiento	
								
						INSERT dbo.[cppAplicaciones] (
							  [IDDocumentoCP]    ,[IDDocCredito]   ,[DocDebito]  ,[DocCredito]
							  ,[Fecha]   ,[FechaCredito]   ,[MontoCredito]   ,[MontoDebitoAnt]  ,[MontoDebitoAct],
							  [MontoCreditoAnt]  ,[MontoCreditoAct],FechaDocVarOrig , VencimientoVarOrig, FechaUltCreditoAnt, IDDebito
							  , FecDocPostApp, FecVencPostApp
						)
						VALUES ( @IDDocDebito, @IDDocCredito,@Documento, @DocCredito, @Fecha, @FechaCredito,
							 @SaldoAnteriorDebito, @SaldoAnteriorDebito, @SaldoActualDebito, @SaldoAnteriorCredito, @SaldoActualCredito, @FechaDocVarOrig , @VencimientoVarOrig, @FechaUltCredito, @IDDocDebito
							 , @FecDocPostApp, @FecVencPostApp)
							
						Set @IDAplicacion = (SELECT SCOPE_IDENTITY())
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualDebito  where IDDocumentoCP = @IDDocumentoCP					
				Update dbo.cppDocumentosCP set SaldoActual = @SaldoActualCredito where IDDocumentoCP = @IDDocCredito							 

						Update dbo.cppDocumentosCP set SaldoActual = 0 --SaldoActual - @SaldoRecibo
						where IDDocumentoCP = @IDDocDebito

						set @SaldoRecibo = @SaldoRecibo - @SaldoActual
						
						exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocCredito , 
							@FechaCredito , @SaldoActualCredito , @SaldoAnteriorCredito	, @IDAplicacion
						-- Saldo del Debito
						exec dbo.cppUpdatecppSaldoDocumentoCP 'I',@IDSaldo OUTPUT, @IDDocDebito , 
							@FechaCredito , @SaldoActualDebito , @SaldoAnteriorDebito, @IDAplicacion
					end				
				end
			END
		-- EL RECIBO CANCELA EL INTERES Y SOBRA
		end

END
-- Esto se hace en un procedo que se llama UndoAplicaciones
--IF @Operation = 'D'
--BEGIN
--	DELETE FROM [fnica].[cppAplicaciones] WHERE IDAplicacion = @IDAplicacion
--	-- devolver el saldo al documento Debito y al documento Credito
--END
IF @Operation = 'S' -- Actualiza Saldos  Debito y Credito
BEGIN 
	Update dbo.cppAplicaciones Set FechaCredito = @FechaCredito,
	MontoDebitoAnt = @MontoDebitoAnt, 
	MontoDebitoAct = @MontoDebitoAct,
	MontoCreditoAnt = @MontoCreditoAnt, MontoCreditoAct = @MontoCreditoAct
	where IDDocumentoCP = @IDDocumentoCP and IDAplicacion = @IDAplicacion
END
return 
GO



CREATE procedure dbo.cppGetDeslizInteresVirtualU @FechaCorte datetime,@IDDocDebito int,   @SaldoRecibo decimal(28,4)
-- Devuelve el deslizamiento e interes virtual de una factura 
as
set nocount on


Declare	@DocDebito nvarchar(20), @DocCredito nvarchar(20),
		@IDAplicacion int , @Fecha datetime, @FechaCredito datetime, @MontoDebitoAnt decimal(28,4), 
		@MontoDebitoAct decimal(28,4), @MontoCreditoAnt decimal(28,4),  @MontoCreditoAct decimal(28,4),  
		@MontoCredito decimal(28,4) , @IDDocumentoCP int, @ValorInteres decimal(28,4), @DifRestante decimal(28,4), @FechaInteresNew datetime, 
		@FechaDeslizNew datetime,  @ValorDesliz decimal(28,4),  @TipoCambio decimal(28,4),
		@IDProveedor nvarchar(10) ,@CodSucursal nvarchar(4) ,@TipoDocumento nvarchar(1) ,
		@IDSubTipo	int , @Documento nvarchar(20) ,  @Vencimiento datetime ,
		@Plazo decimal(8,2) , @VencimientoVar datetime , @FechaDocVar datetime , @MontoOriginal decimal(28,4) ,@FechaUltCredito datetime ,
		@SaldoActual  decimal(28,4) ,@Cancelado bit ,@PorcInteres decimal(8,2),@Anulado bit,
		@NoDocInteres nvarchar(20), @NoDocDeslizamiento nvarchar(20), @DiasVencidos int, @DiasDocumentoVar int,
		@IDSaldo int,
		@SaldoAnteriorDebito decimal(28,4) , @SaldoActualDebito decimal(28,4),@Hoy datetime,
		@SaldoAnteriorCredito decimal(28,4), @SaldoActualCredito decimal(28,4), @SaldoAnterior decimal(28,4), @IDClase nvarchar(20)
		

-- OJO @Hoy es Fecha de Corte		
Set @Hoy = @FechaCorte --'20140818' --(select Fecha From dbo.cppDocumentosCP where IDDocumentoCP = @IDDocCredito) --(select getdate())
	
Select @IDSubTipo = IDSubTipo From dbo.cppSubTipoDocumento 
where IDClase in (Select IDClase From  dbo.cppCLASEDOCUMENTO 
	Where esInteres= 1  ) 
	
set @IDDocumentoCP  = @IDDocDebito
set @FechaCredito = @Hoy

set @MontoCreditoAct = @SaldoRecibo
set @MontoCredito = @SaldoRecibo
	
	Select @IDProveedor = IDProveedor  ,  @TipoDocumento = TipoDocumento,
	@Documento = Documento, @Fecha= Fecha, @Vencimiento= Vencimiento,
	@Plazo = Plazo, @VencimientoVar=VencimientoVar, @FechaDocVar = FechaDocVar, @IDClase = IDClase ,
	@PorcInteres = PorcInteres , @SaldoActual = SaldoActual 
	from dbo.cppDocumentosCP 
	where IDDocumentoCP= @IDDocumentoCP --
	
	set @DiasVencidos		 = (select datediff(day, @VencimientoVar,@FechaCredito ))
	set @ValorDesliz = ( select dbo.cppGetDeslizamiento(@SaldoActual , @FechaDocVar , @FechaCredito, @IDDocumentoCP) ) 

	if @DiasVencidos > 0
	begin
		set @ValorInteres = (select dbo.cppGetInteres (@SaldoActual, @ValorDesliz, @PorcInteres, @DiasVencidos ))
		set @NoDocInteres = @Documento + '-I-' + left ('0' + cast(day(@Hoy) as nvarchar(2)),2) +  
							left ('0' + cast(month(@Hoy) as nvarchar(2)),2) + cast(year(@Hoy) as nvarchar(4))		
	end
	else
		set @ValorInteres = 0
		
		
Select @FechaCredito FechaCorte, @IDDocDebito IDDocDebito, @Documento Documento, @FechaDocVar FechaDocVar, @SaldoActual SaldoNominal, 
@VencimientoVar FVencimiento,  @DiasVencidos DiasVencidos, @ValorDesliz ValorDesliz, @ValorInteres ValorInteres,
(@SaldoActual + @ValorInteres + @ValorDesliz) SaldoTotal, @IDClase

go

CREATE Function dbo.cppGetExisteCreditoAnterior (  @IDProveedor nvarchar(20),  @FechaCorte datetime ) 
returns bit
begin
declare @Result bit, @Fecha datetime
set @Result = 0
set @Fecha = (
		Select max(Fecha)
		From dbo.cppDocumentosCP (NOLOCK)
		where IDProveedor = @IDProveedor and TipoDocumento = 'C' 
		AND Fecha > @FechaCorte and anulado = 0
		)
if @Fecha is null
		set @Result = 0
else
		set @Result = 1
set @Result = isnull(@Result,0)
return @Result
end
go

create procedure dbo.cppAplicaFacturasPendientes  @IDProveedor nvarchar(20),  @IDDocCredito int, @Pago decimal(28,4) ,
@ConceptoSistema nvarchar(500),@ConceptoUsuario nvarchar(500), @RecibimosDe nvarchar(250),
@Usuario nvarchar(20), @TipoCambio decimal(28,4), @CalcInteres bit=1, @CalcDesliz bit=1
-- Esto es un proceso automatico... distribuye el Credito en los débitos más vencidos
-- APLICA EN BATCH TODAS LAS FACTURAS PENDIENTES CON UN RECIBO cuya Distribución es Automatica
as
set nocount on

Declare @ID int ,	@IDDocumentoCP int, @SaldoNominal decimal(28,4), @iRwCnt int, @i int, @SaldoActual decimal(28,4),
		@FechaDocVar datetime, @FechaVencimiento datetime, @VencimientoVar datetime, @Documento nvarchar(20), 
		@TotalSaldo decimal(28,4), @SaldoRecibo decimal(28,4) 
DECLARE @result nVARCHAR(500), @result1 nVARCHAR(1500), @FecVencPostApp datetime, @FecDocPostApp datetime 

if not exists(Select IDDocumentoCP From dbo.cppDocumentosCP (NOLOCK)
				Where IDDocumentoCP = @IDDocCredito and IDSubTipo in (Select IDSubtipo From dbo.cppSubTipoDocumento (NOLOCK) where DistribAutom = 1) 
			)
begin
		RAISERROR ('Ud está queriendo aplicar un Crédito cuya distribución no es Automática o no Existe', 16, 16);
		return
end

if exists(Select IDDocumentoCP From dbo.cppDocumentosCP (NOLOCK)
				Where IDDocumentoCP = @IDDocCredito and Anulado= 1
			)
begin
		RAISERROR ('Ud está queriendo aplicar un Crédito que ha sido Anulado... debe crear un recibo nuevo...', 16, 16);
		return
end
Create Table #Fuente (
		ID int identity(1,1),
		IDDocDebito int,
		SaldoNominal decimal(28,4),
		FechaDocVar datetime,
		FechaVencimiento datetime,
		VencimientoVar datetime,
		Documento nvarchar(20)
)


insert #Fuente (IDDocDebito, SaldoNominal, FechaDocVar, VencimientoVar, Documento)
Select IDDocumentoCP, SaldoActual, FechaDocVar, VencimientoVar, Documento
From dbo.cppDocumentosCP D  (NOLOCK)
--where D.CodSucursal = @CodSucursal and D.IDProveedor = @IDProveedor and D.TipoDocumento = 'D' and D.SaldoActual >0 -- azepeda cambiado el 22/10/2014
where D.IDProveedor = @IDProveedor and D.TipoDocumento = 'D' and D.SaldoActual >0 AND Anulado =0
order by Vencimiento asc

set @iRwCnt = @@ROWCOUNT 
 
create clustered index idx_tmp on #Fuente(ID) WITH FILLFACTOR = 100

begin transaction 
begin try

	SET @i = 1
	set @SaldoRecibo = @Pago
	while @i <= @iRwCnt and @SaldoRecibo > 0
	begin
		Select @IDDocumentoCP = IDDocDebito, @SaldoActual = SaldoNominal,  @FechaDocVar= FechaDocVar, 
		@VencimientoVar = VencimientoVar, @Documento=Documento
		From #Fuente
		where ID = @i


		exec dbo.cppUpdatecppAplicaciones  'I', @IDDocumentoCP, @IDDocCredito,  @SaldoRecibo output, @CalcInteres , @CalcDesliz,
		@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio
		-- esto fue para act las fechas vars en aplicaciones

		SELECT @FecVencPostApp=VencimientoVar, @FecDocPostApp = FechaDocVar
		FROM dbo.cppDocumentosCP (NOLOCK)
		where IDDocumentoCP = @IDDocumentoCP

		Update cppAplicaciones set FecVencPostApp = @FecVencPostApp, FecDocPostApp = @FecDocPostApp
		where IDDocCredito = @IDDocCredito	
			
		set @i = @i + 1
	end

	set @result1 = 'Cancela : '
	Select @result1 = @result1 + DocDebito + ',' from dbo.cppAplicaciones where IDDocCredito = @IDDocCredito
	set @result = substring (@result1,1,500)
	
	Update dbo.cppDocumentosCP set ConceptoSistema = @result
	where IDDocumentoCP = @IDDocCredito
		

drop table #Fuente	
commit
end try
begin catch


	IF OBJECT_ID('#Fuente') IS NOT NULL
		DROP TABLE #Fuente
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	rollback
SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
	
end catch


 
GO

CREATE FUNCTION dbo.parseJSON( @JSON NVARCHAR(MAX))
RETURNS @hierarchy TABLE
  (
   element_id INT IDENTITY(1, 1) NOT NULL, /* internal surrogate primary key gives the order of parsing and the list order */
   sequenceNo [int] NULL, /* the place in the sequence for the element */
   parent_ID INT,/* if the element has a parent then it is in this column. The document is the ultimate parent, so you can get the structure from recursing from the document */
   Object_ID INT,/* each list or object has an object id. This ties all elements to a parent. Lists are treated as objects here */
   NAME NVARCHAR(2000),/* the name of the object */
   StringValue NVARCHAR(MAX) NOT NULL,/*the string representation of the value of the element. */
   ValueType VARCHAR(10) NOT null /* the declared type of the value represented as a string in StringValue*/
  )
AS
BEGIN
  DECLARE
    @FirstObject INT, --the index of the first open bracket found in the JSON string
    @OpenDelimiter INT,--the index of the next open bracket found in the JSON string
    @NextOpenDelimiter INT,--the index of subsequent open bracket found in the JSON string
    @NextCloseDelimiter INT,--the index of subsequent close bracket found in the JSON string
    @Type NVARCHAR(10),--whether it denotes an object or an array
    @NextCloseDelimiterChar CHAR(1),--either a '}' or a ']'
    @Contents NVARCHAR(MAX), --the unparsed contents of the bracketed expression
    @Start INT, --index of the start of the token that you are parsing
    @end INT,--index of the end of the token that you are parsing
    @param INT,--the parameter at the end of the next Object/Array token
    @EndOfName INT,--the index of the start of the parameter at end of Object/Array token
    @token NVARCHAR(200),--either a string or object
    @value NVARCHAR(MAX), -- the value as a string
    @SequenceNo int, -- the sequence number within a list
    @name NVARCHAR(200), --the name as a string
    @parent_ID INT,--the next parent ID to allocate
    @lenJSON INT,--the current length of the JSON String
    @characters NCHAR(36),--used to convert hex to decimal
    @result BIGINT,--the value of the hex symbol being parsed
    @index SMALLINT,--used for parsing the hex value
    @Escape INT --the index of the next escape character
   
 
  DECLARE @Strings TABLE /* in this temporary table we keep all strings, even the names of the elements, since they are 'escaped' in a different way, and may contain, unescaped, brackets denoting objects or lists. These are replaced in the JSON string by tokens representing the string */
    (
     String_ID INT IDENTITY(1, 1),
     StringValue NVARCHAR(MAX)
    )
  SELECT--initialise the characters to convert hex to ascii
    @characters='0123456789abcdefghijklmnopqrstuvwxyz',
    @SequenceNo=0, --set the sequence no. to something sensible.
  /* firstly we process all strings. This is done because [{} and ] aren't escaped in strings, which complicates an iterative parse. */
    @parent_ID=0;
  WHILE 1=1 --forever until there is nothing more to do
    BEGIN
      SELECT
        @start=PATINDEX('%[^a-zA-Z]["]%', @json collate SQL_Latin1_General_CP850_Bin);--next delimited string
      IF @start=0 BREAK --no more so drop through the WHILE loop
      IF SUBSTRING(@json, @start+1, 1)='"'
        BEGIN --Delimited Name
          SET @start=@Start+1;
          SET @end=PATINDEX('%[^\]["]%', RIGHT(@json, LEN(@json+'|')-@start) collate SQL_Latin1_General_CP850_Bin);
        END
      IF @end=0 --no end delimiter to last string
        BREAK --no more
      SELECT @token=SUBSTRING(@json, @start+1, @end-1)
      --now put in the escaped control characters
      SELECT @token=REPLACE(@token, FROMString, TOString)
      FROM
        (SELECT
          '\"' AS FromString, '"' AS ToString
         UNION ALL SELECT '\\', '\'
         UNION ALL SELECT '\/', '/'
         UNION ALL SELECT '\b', CHAR(08)
         UNION ALL SELECT '\f', CHAR(12)
         UNION ALL SELECT '\n', CHAR(10)
         UNION ALL SELECT '\r', CHAR(13)
         UNION ALL SELECT '\t', CHAR(09)
        ) substitutions
      SELECT @result=0, @escape=1
  --Begin to take out any hex escape codes
      WHILE @escape>0
        BEGIN
          SELECT @index=0,
          --find the next hex escape sequence
          @escape=PATINDEX('%\x[0-9a-f][0-9a-f][0-9a-f][0-9a-f]%', @token collate SQL_Latin1_General_CP850_Bin)
          IF @escape>0 --if there is one
            BEGIN
              WHILE @index<4 --there are always four digits to a \x sequence  
                BEGIN
                  SELECT --determine its value
                    @result=@result+POWER(16, @index)
                    *(CHARINDEX(SUBSTRING(@token, @escape+2+3-@index, 1),
                                @characters)-1), @index=@index+1 ;
        
                END
                -- and replace the hex sequence by its unicode value
              SELECT @token=STUFF(@token, @escape, 6, NCHAR(@result))
            END
        END
      --now store the string away
      INSERT INTO @Strings (StringValue) SELECT @token
      -- and replace the string with a token
      SELECT @JSON=STUFF(@json, @start, @end+1,
                    '@string'+CONVERT(NVARCHAR(5), @@identity))
    END
  -- all strings are now removed. Now we find the first leaf. 
  WHILE 1=1  --forever until there is nothing more to do
  BEGIN
 
  SELECT @parent_ID=@parent_ID+1
  --find the first object or list by looking for the open bracket
  SELECT @FirstObject=PATINDEX('%[{[[]%', @json collate SQL_Latin1_General_CP850_Bin)--object or array
  IF @FirstObject = 0 BREAK
  IF (SUBSTRING(@json, @FirstObject, 1)='{')
    SELECT @NextCloseDelimiterChar='}', @type='object'
  ELSE
    SELECT @NextCloseDelimiterChar=']', @type='array'
  SELECT @OpenDelimiter=@firstObject
 
  WHILE 1=1 --find the innermost object or list...
    BEGIN
      SELECT
        @lenJSON=LEN(@JSON+'|')-1
  --find the matching close-delimiter proceeding after the open-delimiter
      SELECT
        @NextCloseDelimiter=CHARINDEX(@NextCloseDelimiterChar, @json,
                                      @OpenDelimiter+1)
  --is there an intervening open-delimiter of either type
      SELECT @NextOpenDelimiter=PATINDEX('%[{[[]%',
             RIGHT(@json, @lenJSON-@OpenDelimiter)collate SQL_Latin1_General_CP850_Bin)--object
      IF @NextOpenDelimiter=0
        BREAK
      SELECT @NextOpenDelimiter=@NextOpenDelimiter+@OpenDelimiter
      IF @NextCloseDelimiter<@NextOpenDelimiter
        BREAK
      IF SUBSTRING(@json, @NextOpenDelimiter, 1)='{'
        SELECT @NextCloseDelimiterChar='}', @type='object'
      ELSE
        SELECT @NextCloseDelimiterChar=']', @type='array'
      SELECT @OpenDelimiter=@NextOpenDelimiter
    END
  ---and parse out the list or name/value pairs
  SELECT
    @contents=SUBSTRING(@json, @OpenDelimiter+1,
                        @NextCloseDelimiter-@OpenDelimiter-1)
  SELECT
    @JSON=STUFF(@json, @OpenDelimiter,
                @NextCloseDelimiter-@OpenDelimiter+1,
                '@'+@type+CONVERT(NVARCHAR(5), @parent_ID))
  WHILE (PATINDEX('%[A-Za-z0-9@+.e]%', @contents collate SQL_Latin1_General_CP850_Bin))<>0
    BEGIN
      IF @Type='Object' --it will be a 0-n list containing a string followed by a string, number,boolean, or null
        BEGIN
          SELECT
            @SequenceNo=0,@end=CHARINDEX(':', ' '+@contents)--if there is anything, it will be a string-based name.
          SELECT  @start=PATINDEX('%[^A-Za-z@][@]%', ' '+@contents collate SQL_Latin1_General_CP850_Bin)--AAAAAAAA
          SELECT @token=SUBSTRING(' '+@contents, @start+1, @End-@Start-1),
            @endofname=PATINDEX('%[0-9]%', @token collate SQL_Latin1_General_CP850_Bin),
            @param=RIGHT(@token, LEN(@token)-@endofname+1)
          SELECT
            @token=LEFT(@token, @endofname-1),
            @Contents=RIGHT(' '+@contents, LEN(' '+@contents+'|')-@end-1)
          SELECT  @name=stringvalue FROM @strings
            WHERE string_id=@param --fetch the name
        END
      ELSE
        SELECT @Name=null,@SequenceNo=@SequenceNo+1
      SELECT
        @end=CHARINDEX(',', @contents)-- a string-token, object-token, list-token, number,boolean, or null
      IF @end=0
        SELECT  @end=PATINDEX('%[A-Za-z0-9@+.e][^A-Za-z0-9@+.e]%', @Contents+' ' collate SQL_Latin1_General_CP850_Bin)
          +1
       SELECT
        @start=PATINDEX('%[^A-Za-z0-9@+.e][A-Za-z0-9@+.e]%', ' '+@contents collate SQL_Latin1_General_CP850_Bin)
      --select @start,@end, LEN(@contents+'|'), @contents 
      SELECT
        @Value=RTRIM(SUBSTRING(@contents, @start, @End-@Start)),
        @Contents=RIGHT(@contents+' ', LEN(@contents+'|')-@end)
      IF SUBSTRING(@value, 1, 7)='@object'
        INSERT INTO @hierarchy
          (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)
          SELECT @name, @SequenceNo, @parent_ID, SUBSTRING(@value, 8, 5),
            SUBSTRING(@value, 8, 5), 'object'
      ELSE
        IF SUBSTRING(@value, 1, 6)='@array'
          INSERT INTO @hierarchy
            (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)
            SELECT @name, @SequenceNo, @parent_ID, SUBSTRING(@value, 7, 5),
              SUBSTRING(@value, 7, 5), 'array'
        ELSE
          IF SUBSTRING(@value, 1, 7)='@string'
            INSERT INTO @hierarchy
              (NAME, SequenceNo, parent_ID, StringValue, ValueType)
              SELECT @name, @SequenceNo, @parent_ID, stringvalue, 'string'
              FROM @strings
              WHERE string_id=SUBSTRING(@value, 8, 5)
          ELSE
            IF @value IN ('true', 'false')
              INSERT INTO @hierarchy
                (NAME, SequenceNo, parent_ID, StringValue, ValueType)
                SELECT @name, @SequenceNo, @parent_ID, @value, 'boolean'
            ELSE
              IF @value='null'
                INSERT INTO @hierarchy
                  (NAME, SequenceNo, parent_ID, StringValue, ValueType)
                  SELECT @name, @SequenceNo, @parent_ID, @value, 'null'
              ELSE
                IF PATINDEX('%[^0-9]%', @value collate SQL_Latin1_General_CP850_Bin)>0
                  INSERT INTO @hierarchy
                    (NAME, SequenceNo, parent_ID, StringValue, ValueType)
                    SELECT @name, @SequenceNo, @parent_ID, @value, 'real'
                ELSE
                  INSERT INTO @hierarchy
                    (NAME, SequenceNo, parent_ID, StringValue, ValueType)
                    SELECT @name, @SequenceNo, @parent_ID, @value, 'int'
      if @Contents=' ' Select @SequenceNo=0
    END
  END
INSERT INTO @hierarchy (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)
  SELECT '-',1, NULL, '', @parent_id-1, @type
--
   RETURN
END
GO

create procedure dbo.cppCreaCreditoAplica @ModalidadCredito nvarchar(1), @IDProveedor nvarchar(10) ,@TipoDocumento nvarchar(1)  ,@IDClase nvarchar(10) 
           ,@IDSubTipo int ,@Documento nvarchar(20) ,@Fecha datetime  
           ,@Plazo int ,@MontoOriginal decimal(28,4) ,@PorcInteres decimal(8,2) 
            ,@ConceptoUsuario nvarchar(500), @DebitosJason nvarchar(max) = null, @CalcInteres bit=0, @CalcDesliz bit=0,
			@RecibimosDe nvarchar(250), @Usuario nvarchar(20), @TipoCambio decimal(28,4)              
-- Este proceso Crea un Documento Credito y lo distribuye automaticamente si la modalidad es 'A', si es 'M' Manual 
-- Crea el Credito y lo distribuye puntualmente en los elementos del parametro @@DebitosJason 
as
set nocount on            
--Declare @IDDocumentoCP int, @Vencimiento datetime,@VencimientoVar datetime,@FechaDocVar datetime,@SaldoActual decimal(28,4),@Cancelado bit
-- ,@ConceptoSistema nvarchar(500),
declare @i int, @iRwCnt int, @Valor decimal(28,4), @IDDocCredito int, @TotalValor decimal(28,4), @Msg nvarchar(250), @IDDocumentoCP int,
	@ConceptoSistema nvarchar(500), @FecVencPostApp datetime, @FecDocPostApp datetime
begin transaction 
begin try


			exec dbo.cppUpdatecppDocumentosCP 'I',  @IDDocumentoCP Output, 
			@IDProveedor   ,'C' , @IDClase,
			@IDSubTipo	 , @Documento , @Fecha , @Plazo , @MontoOriginal , @PorcInteres, 
			@ConceptoSistema, @ConceptoUsuario, @RecibimosDe, @Usuario, @TipoCambio
			set @IDDocCredito = @IDDocumentoCP
if @ModalidadCredito = 'A' -- EL CREDITO SE DISTRIBUYE AUTOMATICAMENTE
BEGIN
	exec dbo.cppAplicaFacturasPendientes @IDProveedor,  @IDDocCredito,  @MontoOriginal,
			@ConceptoSistema ,@ConceptoUsuario , @RecibimosDe ,@Usuario, @TipoCambio,  @CalcInteres , @CalcDesliz
END
if @ModalidadCredito = 'M' -- EL CREDITO SE DISTRIBUYE Manualmente, es decir que el usuario selecciona los documentos a cancelar con sus montos
BEGIN
	if @DebitosJason is null
	begin
		set @Msg = 'La lista de elementos débitos a cancelar está vacía, por favor seleccione al menos uno.'
		raiserror(  @Msg , 16,16 );
		return	
	end
	Select parent_ID,
		   max(case when name='IDDocumentoCP' then convert(int,StringValue) else 0 end) as IDDocumentoCP,
		   max(case when name='Valor' then convert(decimal(28,4),StringValue) else 0 end) as Valor
	INTO #Debitos
	from dbo.parseJSON( @DebitosJason )
	where ValueType = 'string'
	group by parent_ID

	alter table #Debitos add ID int identity(1,1)
	
	if Exists (
		Select IDDocumentoCP
		from #Debitos 
		where IDDocumentoCP not in (
		Select IDDocumentoCP
		From dbo.cppDocumentosCP D (NOLOCK)
		Where D.SaldoActual <> 0 and D.Anulado = 0 )
	) 
	begin
		set @Msg = 'Existen débitos seleccionados que no tienen saldos o están anulados'
		raiserror(  @Msg , 16,16 );
		return	
	end
	
	Select @iRwCnt = isnull(count(*),0), @TotalValor = isnull(sum(Valor),0) from #Debitos
	if @TotalValor < @MontoOriginal or @TotalValor > @MontoOriginal
	begin
	
		set @Msg = 'No se puede Aplicar el Crédito, el total débitos deber ser igual al monto del crédito. Diferencia :'+ 
		cast((@MontoOriginal - @TotalValor) as nvarchar(200)) + ' TotalCrédito : ' + cast(@MontoOriginal  as nvarchar(200)) +
		' TotalDébitos : ' + cast(@TotalValor  as nvarchar(200))
		raiserror(  @Msg , 16,16 );
		return
	end
	
	create clustered index idx_tmpx on #Debitos(ID) WITH FILLFACTOR = 100
	set @i = 1
	while @i <= @iRwCnt
	begin
		Select @IDDocumentoCP = IDDocumentoCP, @Valor = Valor From #Debitos where ID = @i
		exec dbo.cppUpdatecppAplicaciones  'I', @IDDocumentoCP, @IDDocCredito, @Valor, @CalcInteres,@CalcDesliz, @ConceptoSistema,
		@ConceptoUsuario , @RecibimosDe , @Usuario , @TipoCambio 

		SELECT @FecVencPostApp=VencimientoVar, @FecDocPostApp = FechaDocVar
		FROM dbo.cppDocumentosCP (NOLOCK)
		where IDDocumentoCP = @IDDocumentoCP

		Update cppAplicaciones set FecVencPostApp = @FecVencPostApp, FecDocPostApp = @FecDocPostApp
		where IDDocCredito = @IDDocCredito			
		
		set @i = @i + 1
	end
	
END

IF OBJECT_ID('tempdb..#Debitos') IS NOT NULL DROP TABLE #Debitos
commit
end try
begin catch
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	rollback
SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
IF OBJECT_ID('tempdb..#Debitos') IS NOT NULL DROP TABLE #Debitos 	
end catch

  


go


-- exec dbo.cppGetSaldoDeCliente '*', 'MT295', '20150202'
Create Procedure dbo.cppGetSaldoProveedor  @IDProveedor nvarchar(20), @FechaCorte DATETIME,
 @SaldoNominal decimal(28,4) output, @Intereses decimal(28,4) output, 
 @Deslizamiento decimal(28,4) output, @Total decimal(28,4) output
as
set nocount on 
Create Table #Resultados( IDSaldo int, IDDocumentoCP int, IDProveedor nvarchar(20),  
TipoDocumento nvarchar(1), IDClase nvarchar(10), IDSubtipo int, Documento nvarchar(20), 
Fecha datetime, FechaDocVar datetime, Vencimiento datetime, VencimientoVar datetime, Plazo decimal(8,2),
MontoOriginal decimal(28,4), FechaUltCredito datetime, SaldoActual decimal(28,4), 
FechaSaldo datetime, Saldo decimal(28,4) ,DiasVencidos int,  SaldoNominal decimal(28,4) ,  Intereses decimal(28,4) , 
Deslizamiento decimal(28,4) , TotalaPagar decimal(28,4), EsInteres bit, EsDeslizamiento bit 
)

	
Insert #Resultados (IDSaldo, IDDocumentoCP, IDProveedor, TipoDocumento, IDClase, IDSubtipo, 
Documento, Fecha, FechaDocVar, Vencimiento, VencimientoVar, Plazo,	MontoOriginal, FechaUltCredito, SaldoActual, 
FechaSaldo, Saldo,DiasVencidos,  SaldoNominal,  Intereses, Deslizamiento, TotalaPagar, EsInteres, EsDeslizamiento)
exec dbo.cppGetDocumentosxCobrar  @IDProveedor, @FechaCorte

Select IDProveedor, sum(SaldoNominal) SaldoNominal, sum(Deslizamiento) Deslizamiento, 
sum(Intereses) Intereses, sum(SaldoNominal+Deslizamiento+Intereses) Total
into #Resultado2
From #Resultados R 
Group by IDProveedor
--Group by CodSucursal, IDProveedor esto estaba antes

Select top 1 @SaldoNominal = isnull( SaldoNominal,0) , 
@Deslizamiento = isnull(Deslizamiento,0) , 
@Intereses = isnull(Intereses,0) , @Total = isnull(Total,0)
From #Resultado2 R 
if @SaldoNominal is null 
	set @SaldoNominal = isnull( @SaldoNominal,0)
if @Deslizamiento is null 
	set @Deslizamiento = isnull( @Deslizamiento,0)
if @Intereses is null 
	set  @Intereses = isnull( @Intereses,0)
if @Total is null 
	set  @Total = isnull( @Total,0)


drop table #Resultados
drop table #Resultado2
go

#Julio
$Revisado hasta aca

CREATE PROCEDURE [fnica].[uspcppGeneraAsientoAplicacion] @Paquete nvarchar(20),
@tipo_asiento nvarchar(20), @IDDocumento int, @CreditoAplicado bit output, @AsientoOutput nvarchar(10) output
as

SET NOCOUNT on

Declare   @DocCredito nvarchar(20), @IDProveedor nvarchar(10), 
@CodSucursalCliente NVARCHAR(4), @ReciboAplicado BIT, @CodSucursal NVARCHAR(4), @NumeroRecibo NVARCHAR(20)
DECLARE @Modulo_Origen VARCHAR(4)
DECLARE @Consecutivoaudit float, @NewId UNIQUEIDENTIFIER, @Asiento VARCHAR(10), 
 @cta_inventario VARCHAR(25), @cta_cost_venta_loc VARCHAR(25), @cta_Fondo_Dep VARCHAR(25), @cta_CxC VARCHAR(25),
@ctr_inventario VARCHAR(25), @ctr_cost_venta_loc VARCHAR(25), @ctr_Fondo_Dep VARCHAR(25), @ctr_CxC VARCHAR(25), @CentroSucursal VARCHAR(25),
@total_debito_loc DECIMAL(28,8), @total_credito_loc DECIMAL(28,8), @cta_venta_loc VARCHAR(25), @ctr_venta_loc VARCHAR(25),
@cta_IVA VARCHAR(25), @ctr_IVA VARCHAR(25), @total_debito_dol DECIMAL(28,8), @total_credito_dol DECIMAL(28,8) ,
@total_Venta_MasIva_loc DECIMAL(28,8), @total_Venta_MasIva_dol DECIMAL(28,8),
@total_Iva_loc DECIMAL(28,8), @total_Iva_dol DECIMAL(28,8),
@cta VARCHAR(25), @ctr VARCHAR(25)
declare @i INT, @iConsecutivoLineaAsiento INT, @fecha_hora DATETIME, @fecha_Documento DATETIME, @Articulo_Cuenta VARCHAR(4)
declare @iRwCnt int, @SoloServicio smallint, @Categoria nvarchar(20), @flgCreditoReciboCxCSuc bit, @CtaCreditoRecibo varchar(25),
@cta_Interes VARCHAR(25), @ctr_Interes VARCHAR(25), @cta_Diferencial VARCHAR(25), @ctr_Diferencial VARCHAR(25)

DECLARE @CantItems int, @CantServicios int, @FechaIngreso smalldatetime, @Fecha smalldatetime,   --@IDProveedor nvarchar (10) ,
      @TipoCambio numeric(13, 4), @Cliente nvarchar(250) , @RecibimosDe NVARCHAR(250), @Valor numeric(28, 8) ,
      @ValorDolar numeric(28, 8) ,@Concepto NVARCHAR(250), @DOCUMENTO VARCHAR(20), @DescrDet nvarchar(250)

DECLARE @ID INT , @IDDocumentoCP INT, @TIPODOCUMENTO NVARCHAR(1), @IDDOCCREDITO INT,
@IDCLASE NVARCHAR(10), @IDSUBTIPO INT,  @DOCDEBITO NVARCHAR(20), @FECHACREDITO DATETIME, @MONTOCREDITO decimal(28,4)

Select @IDClase = IDClase, @IDSubtipo = IDSubTipo, @DocCredito = Documento, @NumeroRecibo= Documento,
@IDProveedor = IDProveedor
From dbo.cppDocumentosCP 
where IDDocumentoCP = @IDDocumento

Select @CodSucursalCliente = CodSucursal, @Cliente=rtrim(NombresCliente) + ' '+ rtrim(ApellidosCliente)
From dbo.cppProveedores
Where IDProveedor = @IDProveedor



BEGIN TRANSACTION

BEGIN TRY

set @ReciboAplicado = 0 -- default recibo no aplicado
Select @CentroSucursal = Centro_Costo , @cta_inventario = Cta_Inventario, @ctr_inventario = Centro_Inventario,
@cta_CxC = Cta_CxC, @ctr_CxC = Centro_CxC, @cta_Fondo_Dep = Cta_Fondo_Dep, @ctr_Fondo_Dep = Centro_Fondo_Dep,
@cta_IVA = Cta_Iva, @ctr_IVA = Centro_IVA, @ctr_Interes = Centro_Interes, @cta_Interes = Cta_Interes, 
@ctr_Diferencial = Centro_Diferencial, @cta_Diferencial = Cta_Diferencial
from dbo.globalSucursales S (NOLOCK) 
Where CodSucursal = @CodSucursalCliente
-- Select * From  dbo.cppCategoriaCliente 
Select @flgCreditoReciboCxCSuc=flgCreditoReciboCxCSuc,  @CtaCreditoRecibo = CtaCreditoRecibo
From  dbo.cppCategoriaCliente 
where IDCategoria in (Select IDCategoria from dbo.cppProveedores Where IDProveedor = @IDProveedor) 


if @flgCreditoReciboCxCSuc = 0 -- Si el Credito en la Categoria no es la CxC de la Sucursal
      set @cta_CxC = @CtaCreditoRecibo

if not exists(Select * From dbo.cppAplicaciones Where IDDocCredito = @IDDocumento)
begin
	RAISERROR ('Error al contabilizar ya que el Credito no tiene aplicaciones', 16,16)
end

CREATE TABLE #DETDOCASIENTO ( ID INT IDENTITY(1,1), IDDocumentoCP INT, TIPODOCUMENTO NVARCHAR(1), IDDOCCREDITO INT,
IDCLASE NVARCHAR(10), IDSUBTIPO INT, DOCUMENTO NVARCHAR(20), DOCDEBITO NVARCHAR(20),
FECHACREDITO DATETIME, MONTOCREDITO DECIMAL(28,4) DEFAULT 0)

create clustered index idx_tmp on #DETDOCASIENTO(ID) WITH FILLFACTOR = 100



INSERT #DETDOCASIENTO ( IDDocumentoCP, TIPODOCUMENTO, IDDOCCREDITO, IDCLASE, IDSUBTIPO, DOCUMENTO, DOCDEBITO,
FECHACREDITO, MONTOCREDITO)
SELECT IDDocumentoCP, TIPODOCUMENTO, IDDOCCREDITO, IDCLASE, IDSUBTIPO, DOCUMENTO, DOCDEBITO,
FECHACREDITO, MONTOCREDITO
FROM (
-- Debitos de la Aplicacion
Select A.IDDocumentoCP, D.TipoDocumento, A.IDDOCCREDITO, A.IDDEBITO, 
D.IDCLASE, D.IDSUBTIPO, D.DOCUMENTO, A.DOCDEBITO, A.FECHACREDITO, A.MONTOCREDITO
From dbo.cppAplicaciones A INNER JOIN  dbo.cppDocumentosCP D
ON A.IDDocumentoCP = D.IDDocumentoCP
WHERE A.IDDOCCREDITO = @IDDocumento
union all
-- Credito
Select IDDocumentoCP, TipoDocumento, IDDocumentoCP IDDOCCREDITO, IDDocumentoCP IDDEBITO,
IDClase, IDSubTipo, D.Documento, 'ND' DocDebito, D.Fecha FechaCredito, MontoOriginal MontoCredito
from dbo.cppDocumentosCP D
where IDDocumentoCP = @IDDocumento
) X 

set @iRwCnt = @@ROWCOUNT

SELECT @CodSucursal= CodSucursal,  @NumeroRecibo=Documento,@Fecha=Fecha,
@IDProveedor=IDProveedor, @TipoCambio=TipoCambio,@RecibimosDe=RecibimosDe,
@Valor= MontoOriginal, @ValorDolar= case when TipoCambio >0 then MontoOriginal/TipoCambio else 0 end, 
@Concepto= ConceptoUsuario,@ReciboAplicado= Contabilizado
From dbo.cppDocumentosCP R -- Select * From dbo.cppDocumentosCP
Where R.IDDocumentoCP = @IDDocumento

set @iConsecutivoLineaAsiento = 0
SET @fecha_hora = ( SELECT GETDATE())
SET @Asiento = NULL -- inicializo el asiento
Set @Asiento = (SELECT  ultimo_asiento   
                        FROM dbo.paquete (UPDLOCK)                             
                        WHERE paquete = @Paquete)


SET @Asiento = SUBSTRING(@Asiento,1,2) + RIGHT('00000000' + cast( cast(SUBSTRING(@Asiento,3,8) AS INT) + 1 AS NVARCHAR(8)),8)
IF NOT EXISTS (
      SELECT asiento        
      FROM dbo.asiento_de_diario (NOLOCK) 
      WHERE asiento = @Asiento
)


UPDATE dbo.paquete SET ultimo_asiento = @Asiento      
WHERE  paquete = @Paquete

set @NewId = (SELECT NEWID())
INSERT INTO dbo.asiento_de_diario ( paquete, tipo_asiento, fecha, contabilidad, origen, notas, marcado,       
total_debito_loc, total_credito_loc, total_debito_dol, total_credito_dol, total_control_loc, total_control_dol, 
ultimo_usuario, fecha_ult_modif,       usuario_creacion, fecha_creacion, 
RowPointer , asiento, clase_asiento )    
VALUES ( @Paquete , @tipo_asiento , @Fecha  , 'F' ,'FA' , @RecibimosDe , 'N'        
,0,0,0,0,0,0,'SA', GETDATE(), 'SA' ,  GETDATE() , 
@NewId , @Asiento , 'N' )

                                          
SET @i = 1
while @i <= @iRwCnt
begin
	SELECT @IDDocumentoCP=IDDocumentoCP, @TIPODOCUMENTO= TIPODOCUMENTO, @IDDOCCREDITO=IDDOCCREDITO, 
	@IDCLASE= IDCLASE, @IDSUBTIPO=IDSUBTIPO, @DOCUMENTO = DOCUMENTO, @DOCDEBITO=DOCDEBITO,
	@FECHACREDITO=FECHACREDITO, @MONTOCREDITO=MONTOCREDITO
	FROM #DETDOCASIENTO
	WHERE ID = @i
	
	SET @Valor = @MONTOCREDITO
	SET @ValorDolar = (CASE WHEN @TipoCambio <> 0 THEN (@Valor/@TipoCambio) ELSE 0 END)
	
	set @NewId = ( SELECT NEWID() )
	set @iConsecutivoLineaAsiento = @iConsecutivoLineaAsiento + 1


	
	if @TIPODOCUMENTO = 'C' -- SI EL DOCUMENTO ES UN CREDITO
	begin
          -- Debito : FONDOS X DEPOSITAR
          INSERT INTO dbo.diario ( asiento, consecutivo, cuenta_contable, centro_costo,       referencia, fuente,      
          debito_local, debito_dolar,   credito_local, credito_dolar,       debito_unidades, credito_unidades, nit, tipo_cambio, RowPointer,base_local, base_dolar ) 
          VALUES ( @Asiento        , @iConsecutivoLineaAsiento, @cta_Fondo_Dep, @ctr_Fondo_Dep, 
          'FONDOXDEP Cliente :  ' + @Cliente, 'RC-' + @NumeroRecibo  ,
          @Valor  , @ValorDolar, null, NULL, null, NULL, 'ND', NULL, @NewId, NULL, NULL ) 
    end
    else
    begin -- SI EL DOCUMENTO ES  DEBITO
		if (@IDClase = 'FAC' OR @IDClase = 'N/D')
		BEGIN
			set @cta = @cta_CxC
			set @ctr = @ctr_CxC
			set @DescrDet = 'Factura/ND '
		END
		if (@IDClase = 'INT') 
		BEGIN
			set @cta = @cta_Interes
			set @ctr = @ctr_Interes
			set @DescrDet = 'Interes '
		END	
		if (@IDClase = 'D/C' )
		BEGIN
			set @cta = @cta_Diferencial
			set @ctr = @ctr_Diferencial
			set @DescrDet = 'Deslizamiento '
		END	
		 			
          INSERT INTO dbo.diario ( asiento, consecutivo, cuenta_contable, centro_costo,       referencia, fuente,      
          debito_local, debito_dolar,   credito_local, credito_dolar,       debito_unidades, credito_unidades, nit, tipo_cambio, RowPointer,base_local, base_dolar ) 
          VALUES ( @Asiento        , @iConsecutivoLineaAsiento, @cta, @ctr, 
          @DescrDet + @Cliente, @IDClase + '-' + @DOCUMENTO  ,
          null, NULL, @Valor , @ValorDolar,  null, NULL, 'ND', NULL, @NewId, NULL, NULL )              
    
    end
	set @i = @i + 1
end

SELECT @total_debito_loc = sum(ISNULL(DEBITO_LOCAL,0)), @total_credito_loc = sum(ISNULL(CREDITO_LOCAL,0)),
@total_debito_dol = sum(ISNULL(DEBITO_DOLAR,0)), @total_credito_dol = SUM(ISNULL(CREDITO_DOLAR,0)) 
FROM dbo.diario (NOLOCK)
WHERE asiento = @Asiento


UPDATE dbo.asiento_de_diario SET        total_debito_loc = @total_debito_loc ,  total_credito_loc =  @total_credito_loc,
total_debito_dol = @total_debito_dol, total_credito_dol = @total_credito_dol,        
total_control_loc = @total_credito_loc , total_control_dol = @total_credito_dol                     
WHERE asiento = @Asiento

UPDATE dbo.cppAplicaciones SET ASIENTO = @Asiento
WHERE IDDOCCREDITO = @IDDocumento

Update dbo.cppDocumentosCP  set Asiento = @Asiento, Contabilizado = 1
where IDDocumentoCP = @IDDocumento

-- Asignar el Asiento que pertenece a la Factura en Proceso
set @AsientoOutput = @Asiento
set @CreditoAplicado = 1
drop table #DETDOCASIENTO
-- GOOD BYE

END TRY
BEGIN CATCH

	IF OBJECT_ID('#DETDOCASIENTO') IS NOT NULL
		DROP TABLE #DETDOCASIENTO
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	
SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
            IF (@@TRANCOUNT>0)
            ROLLBACK
END CATCH

IF (@@TRANCOUNT>0)
COMMIT TRANSACTION

GO


-- select * from dbo.cppProveedores
-- drop procedure [fnica].[uspcppGeneraAsientoReversion]

Create procedure [fnica].[uspcppGeneraAsientoReversion]  @Asiento nvarchar(20) , @Paquete varchar(4), @tipo_asiento nvarchar(20), @AsientoNuevo nvarchar(20) OUTPUT
-- El @Asiento es el asiento origen, @paquete es el paquete en donde quedara el asiento de reversion y el @tipo_asiento es el tipo del asiento de reversion
-- OJO EL PROGRAMA QUE LLAME A ESTE STORE TIENE QUE VALIDAR PRIMERO LLAMANDO A LA FUNCION dbo.cppMayRevertirAsiento QUE
-- DICE SI SE PUEDE O NO REVERTIR
as
set nocount on
Declare @AsientoNew nvarchar(20), @fecha_hora datetime, @isInDiario bit, @isInMayor bit,  @NewId UNIQUEIDENTIFIER
Declare @total_debito_loc DECIMAL(28,8), @total_credito_loc DECIMAL(28,8), @total_debito_Dol DECIMAL(28,8), @total_credito_Dol DECIMAL(28,8)
declare @Fecha as DATE

if exists( Select Asiento FROM dbo.ASIENTO_DE_DIARIO	WHERE ASIENTO = @Asiento )
	set @isInDiario = 1
else
	set @isInDiario = 0	
if exists( Select Asiento FROM dbo.ASIENTO_MAYORIZADO WHERE ASIENTO = @Asiento )
	set @isInMayor = 1
else
	set @isInMayor = 0	
	
if (@isInDiario=1)
	select @Fecha = FECHA  from dbo.ASIENTO_DE_DIARIO where ASIENTO=@Asiento
else
	select @Fecha = FECHA  from dbo.ASIENTO_MAYORIZADO where ASIENTO=@Asiento

--BEGIN TRANSACTION

BEGIN TRY

SET @fecha_hora = ( SELECT GETDATE())
SET @AsientoNew = NULL -- inicializo el asiento
Set @AsientoNew = (SELECT  ultimo_asiento   
                        FROM dbo.paquete (UPDLOCK)                             
                        WHERE paquete = @Paquete)


SET @AsientoNew = SUBSTRING(@AsientoNew,1,2) + RIGHT('00000000' + cast( cast(SUBSTRING(@AsientoNew,3,8) AS INT) + 1 AS NVARCHAR(8)),8)
IF NOT EXISTS (
      SELECT asiento        
      FROM dbo.asiento_de_diario (NOLOCK) 
      WHERE asiento = @AsientoNew
)


UPDATE dbo.paquete SET ultimo_asiento = @AsientoNew      
WHERE  paquete = @Paquete

set @NewId = (SELECT NEWID())

		INSERT INTO dbo.asiento_de_diario ( paquete, tipo_asiento, fecha, contabilidad, origen, notas, marcado,       
		total_debito_loc, total_credito_loc, total_debito_dol, total_credito_dol, total_control_loc, total_control_dol, 
		ultimo_usuario, fecha_ult_modif,       usuario_creacion, fecha_creacion, 
		RowPointer , asiento, clase_asiento )    
		VALUES ( @Paquete , @tipo_asiento , @Fecha   , 'F' ,'FA' , 'ANULACION DE DOCUMENTO, ASIENTO ORIGINAL ' + @Asiento , 'N'        
		,0,0,0,0,0,0,'SA', @fecha_hora , 'SA' ,  @fecha_hora  , 
		@NewId , @AsientoNew , 'N' )


if @isInDiario = 1
begin
	insert dbo.DIARIO ([ASIENTO] ,[CONSECUTIVO]  ,[NIT] ,[CENTRO_COSTO] ,[CUENTA_CONTABLE] ,[FUENTE]  ,[REFERENCIA]   ,
			[DEBITO_LOCAL] ,[DEBITO_DOLAR] ,[CREDITO_LOCAL],[CREDITO_DOLAR],[DEBITO_UNIDADES]
		  ,[CREDITO_UNIDADES]  ,[TIPO_CAMBIO] ,[BASE_LOCAL] ,[BASE_DOLAR], RowPointer 
	)
	SELECT @AsientoNew [ASIENTO] ,[CONSECUTIVO]  ,[NIT] ,[CENTRO_COSTO] ,[CUENTA_CONTABLE] ,[FUENTE], [REFERENCIA]   
		,[CREDITO_LOCAL],[CREDITO_DOLAR], [DEBITO_LOCAL] ,[DEBITO_DOLAR] ,[DEBITO_UNIDADES]
		  ,[CREDITO_UNIDADES]  ,[TIPO_CAMBIO] ,[BASE_LOCAL] ,[BASE_DOLAR], NEWID()

	FROM dbo.DIARIO
	WHERE ASIENTO = @Asiento
end
if @isInMayor = 1
begin
	insert dbo.DIARIO ([ASIENTO] ,[CONSECUTIVO]  ,[NIT] ,[CENTRO_COSTO] ,[CUENTA_CONTABLE] ,[FUENTE]  ,[REFERENCIA]   ,
			[DEBITO_LOCAL] ,[DEBITO_DOLAR] ,[CREDITO_LOCAL],[CREDITO_DOLAR],[DEBITO_UNIDADES]
		  ,[CREDITO_UNIDADES]  ,[TIPO_CAMBIO] ,[BASE_LOCAL] ,[BASE_DOLAR], RowPointer 
	)
	SELECT @AsientoNew [ASIENTO] ,[CONSECUTIVO]  ,[NIT] ,[CENTRO_COSTO] ,[CUENTA_CONTABLE] ,[FUENTE], [REFERENCIA]   
		,[CREDITO_LOCAL],[CREDITO_DOLAR], [DEBITO_LOCAL] ,[DEBITO_DOLAR] ,[DEBITO_UNIDADES]
		  ,[CREDITO_UNIDADES]  ,[TIPO_CAMBIO] ,[BASE_LOCAL] ,[BASE_DOLAR], NEWID() 
	From dbo.Mayor
	WHERE ASIENTO = @Asiento

end
	
	SELECT @total_debito_loc = sum(ISNULL(DEBITO_LOCAL,0)), @total_credito_loc = sum(ISNULL(CREDITO_LOCAL,0)),
	@total_debito_dol = sum(ISNULL(DEBITO_DOLAR,0)), @total_credito_dol = SUM(ISNULL(CREDITO_DOLAR,0)) 
	FROM dbo.diario (NOLOCK)
	WHERE asiento = @AsientoNew


	UPDATE dbo.asiento_de_diario SET        total_debito_loc = @total_credito_loc  ,  total_credito_loc = @total_debito_loc ,
	total_debito_dol =@total_credito_dol , total_credito_dol = @total_debito_dol,        
	total_control_loc = @total_credito_loc , total_control_dol = @total_credito_dol                     
	WHERE asiento = @AsientoNew
			

	set @AsientoNuevo = @AsientoNew 

END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	
	SELECT @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
            --IF (@@TRANCOUNT>0)
            --ROLLBACK
END CATCH

--IF (@@TRANCOUNT>0)
--COMMIT TRANSACTION

GO

create Function dbo.cppMayRevertirAsiento (  @DocumentoCredito bit, @Factura nvarchar(10),  @IDDocumentoCP int )
returns bit 
as
begin
Declare @MayRevertir bit
if @DocumentoCredito = 0 
	if exists ( select FACTURA from dbo.fafFACTURA (NOLOCK)
			where TIPO = '1' AND FACTURA = @Factura AND CODSUCURSAL = @CodSucursal
				and (AsientoReversion is null ) 
	)
		set @MayRevertir = 1	
	else
		set @MayRevertir = 0

if @DocumentoCredito = 1
	if  exists ( select IDDocumentoCP from dbo.cppDocumentosCP  (NOLOCK)
			where IDDocumentoCP = @IDDocumentoCP  
				and  (AsientoReversion is null ) 
	)
		set @MayRevertir = 1	
	else
		set @MayRevertir = 0
		
	if  exists ( select IDDocumentoCP from dbo.cppAplicaciones  (NOLOCK)
			where IDDocumentoCP = @IDDocumentoCP  
				 
	)
		set @MayRevertir = 0	
	else
		set @MayRevertir = 1

Return isnull(@MayRevertir,0)

end
go

create Function dbo.cppMayGeneraAsiento (  @DocumentoCredito bit, @Factura nvarchar(10), @CodSucursal nvarchar(4), @IDDocumentoCP int )
returns bit 
as
begin
Declare @May bit
if @DocumentoCredito = 0 
	if exists ( select FACTURA from dbo.fafFACTURA (NOLOCK)
			where TIPO = '1' AND FACTURA = @Factura AND CODSUCURSAL = @CodSucursal
				and (Asiento is null ) and anulada = 0 
	)
		set @May = 1	
	else
		set @May = 0

if @DocumentoCredito = 1
	if  exists ( select IDDocumentoCP from dbo.cppDocumentosCP   (NOLOCK)
			where IDDocumentoCP = @IDDocumentoCP  
				and  (Asiento is null ) and Anulado = 0 and contabilizado = 0
	)
		set @May = 1	
	else
		set @May = 0
		

Return isnull(@May,0)

end
go


create PROCEDURE [fnica].[uspcppGeneraAsientoSubTipoDoc] @IDProveedor nvarchar(10) , @IDDocumento int , @AsientoOutput nvarchar(10) OUTPUT
as
--***** Este proceso genera el asiento de un subtipo de decumento, para que funcione el flag SubtipoGeneraAsiento debe ser true y la naturalezacta
--***** debe indicar en donde va la cuenta contable que se refiere al subtipo de documento, la otra es la contra cuenta

SET NOCOUNT on
-- these are variables 
DECLARE @Modulo_Origen VARCHAR(4), @CodSucursalCliente NVARCHAR(4),  @Cliente nvarchar(250)
DECLARE @Consecutivoaudit float, @NewId UNIQUEIDENTIFIER, @Asiento VARCHAR(10), 
 @cta_inventario VARCHAR(25), @cta_cost_venta_loc VARCHAR(25), @cta_Fondo_Dep VARCHAR(25), @cta_CxC VARCHAR(25),
@ctr_inventario VARCHAR(25), @ctr_cost_venta_loc VARCHAR(25), @ctr_Fondo_Dep VARCHAR(25), @ctr_CxC VARCHAR(25), @CentroSucursal VARCHAR(25),
@total_debito_loc DECIMAL(28,8), @total_credito_loc DECIMAL(28,8), @cta_venta_loc VARCHAR(25), @ctr_venta_loc VARCHAR(25),
@cta_IVA VARCHAR(25), @ctr_IVA VARCHAR(25), @total_debito_dol DECIMAL(28,8), @total_credito_dol DECIMAL(28,8) ,
@total_Venta_MasIva_loc DECIMAL(28,8), @total_Venta_MasIva_dol DECIMAL(28,8), @cta_DEBITO VARCHAR(25), @cta_CREDITO VARCHAR(25),
@total_Iva_loc DECIMAL(28,8), @total_Iva_dol DECIMAL(28,8), @ContraCtaEnSubTipo bit, @ctr_Credito VARCHAR(25), @ctr_Debito VARCHAR(25)
declare @i INT, @iConsecutivoLineaAsiento INT, @fecha_hora DATETIME, @fecha_Documento DATETIME, @Articulo_Cuenta VARCHAR(4)
declare @iRwCnt int, @SoloServicio smallint, @Categoria nvarchar(20), @flgCreditoReciboCxCSuc bit, @CtaCreditoRecibo varchar(25)
declare @CodSucursal nvarchar(4) , @IDClase nvarchar(10), @IDSubTipo	int, @Documento nvarchar(20), @NaturalezaCta nvarchar(1)
Declare @FechaIngreso smalldatetime, @Fecha smalldatetime, @TipoCambio numeric(13, 4), @RecibimosDe NVARCHAR(250),  @DescrSubTipo NVARCHAR(250),
      @Valor numeric(28, 8) , @ValorDolar numeric(28, 8) ,  @Concepto NVARCHAR(250), @Paquete nvarchar(4), @Tipo_Paquete nvarchar(4), @IDCategoria nvarchar(20)

Select @IDClase = IDClase, @IDSubtipo = IDSubTipo, @Documento = Documento,@IDProveedor = IDProveedor,
@Valor = MontoOriginal , @ValorDolar = ( case when TipoCambio <> 0 then MontoOriginal / TipoCambio else 0 end )
From dbo.cppDocumentosCP 
where IDDocumentoCP = @IDDocumento

Select @CodSucursalCliente = CodSucursal, @Cliente=rtrim(NombresCliente) + ' '+ rtrim(ApellidosCliente)
From dbo.cppProveedores
Where IDProveedor = @IDProveedor

Select @NaturalezaCta = NaturalezaCta, @cta_DEBITO = CtaDebito, @cta_CREDITO = CtaCredito, @DescrSubTipo = Descr ,
@ContraCtaEnSubTipo = ContraCtaEnSubTipo
from dbo.cppSubTipoDocumento 
Where IDSubTipo = @IDSubtipo and SubTipoGeneraAsiento = 1 and IDClase = @IDClase

-- select * from dbo.cppSubTipoDocumento
BEGIN TRANSACTION

BEGIN TRY
	IF  @IDClase IN ('N/C', 'N/D')
	BEGIN
		if NOT EXISTS(Select IDClase
				   from dbo.cppSubTipoDocumento 
				   Where IDSubTipo = @IDSubtipo and SubTipoGeneraAsiento = 1 and IDClase = @IDClase AND @IDClase IN ('N/C', 'N/D') 
		)
			RAISERROR ('El Subtipo de Documento N/D O N/C No permite Generar Asiento Contable ', 16,16)
	END

	IF  @IDClase IN ('R/C') -- caso de recibos de Proveedores varios ( no cancelan ninguna factura )
	BEGIN
		if NOT EXISTS(Select IDClase
				   from dbo.cppSubTipoDocumento 
				   Where IDSubTipo = @IDSubtipo and SubTipoGeneraAsiento = 1 and IDClase = @IDClase AND @IDClase IN ('R/C') 
		)
			RAISERROR ('El Subtipo de Documento R/C No permite Generar Asiento Contable ', 16,16)
	END

--set @ReciboAplicado = 0 -- default recibo no aplicado
Select @CentroSucursal = Centro_Costo , @cta_inventario = Cta_Inventario, @ctr_inventario = Centro_Inventario,
@cta_CxC = Cta_CxC, @ctr_CxC = Centro_CxC, @cta_Fondo_Dep = Cta_Fondo_Dep, @ctr_Fondo_Dep = Centro_Fondo_Dep,
@cta_IVA = Cta_Iva, @ctr_IVA = Centro_IVA
from dbo.globalSucursales S (NOLOCK) 
Where CodSucursal = @CodSucursalCliente


Select @flgCreditoReciboCxCSuc=flgCreditoReciboCxCSuc,  @CtaCreditoRecibo = CtaCreditoRecibo, @IDCategoria = IDCategoria
From dbo.cppCategoriaCliente 
where IDCategoria in (Select IDCategoria from dbo.cppProveedores Where IDProveedor = @IDProveedor) 


--if @flgCreditoReciboCxCSuc = 0 -- Si el Credito en la Categoria no es la CxC de la Sucursal
--      set @cta_CxC = @CtaCreditoRecibo

if @IDCategoria in ('ProveedoresPECIAL' , 'ProveedoresVARIOS' )
begin
	if @IDClase in ( 'N/C' , 'N/D' )
	begin
		RAISERROR ('El Tipo de Cliente no permite Crear Notas ', 16,16)
	end
end

	IF @NaturalezaCta = 'D'
	BEGIN
		set @cta_Credito = @cta_CxC 
		SET @ctr_Credito = @ctr_CxC
		set @ctr_Debito =  @CentroSucursal
	END
	IF @NaturalezaCta = 'C'
	BEGIN
		if @ContraCtaEnSubTipo = 0
		begin
			set @cta_Debito = @cta_CxC	
			set @ctr_Debito = @ctr_CxC
			SET @ctr_Credito = @CentroSucursal	
		end
		else
		begin
			set @cta_Debito = @cta_DEBITO	
			set @ctr_Debito = @ctr_CxC
			SET @ctr_Credito = @CentroSucursal	
			
		end
	END

	if @IDClase = 'N/C' 
	begin 
		SET @Paquete = 'NC'
		set @Tipo_Paquete = 'NC'
  
	END

	if @IDClase = 'N/D' 
	begin 
		SET @Paquete = 'ND'
		set @Tipo_Paquete = 'ND'
	END

	if @IDClase = 'R/C' 
	begin 
		SET @Paquete = 'RC'
		set @Tipo_Paquete = 'RC'
	END
	

            set @iConsecutivoLineaAsiento = 0
            SET @fecha_hora = ( SELECT GETDATE())
            SET @Fecha = @fecha_hora
            SET @Asiento = NULL -- inicializo el asiento
            Set @Asiento = (SELECT ultimo_asiento   
                                    FROM dbo.paquete (UPDLOCK)                             
                                    WHERE paquete = @Paquete)


            SET @Asiento = SUBSTRING(@Asiento,1,2) + RIGHT('00000000' + cast( cast(SUBSTRING(@Asiento,3,8) AS INT) + 1 AS NVARCHAR(8)),8)
            IF NOT EXISTS (
                  SELECT asiento        
                  FROM dbo.asiento_de_diario (NOLOCK) 
                  WHERE asiento = @Asiento
            )
                  
                  --SELECT @Asiento ASIENTOGENERADO

            UPDATE dbo.paquete SET ultimo_asiento = @Asiento      
            WHERE  paquete = @Paquete
            
            set @Fecha = (select CAST(@Fecha  as DATE))

            set @NewId = (SELECT NEWID())
            INSERT INTO dbo.asiento_de_diario ( paquete, tipo_asiento, fecha, contabilidad, origen, notas, marcado,       
            total_debito_loc, total_credito_loc, total_debito_dol, total_credito_dol, total_control_loc, total_control_dol, 
            ultimo_usuario, fecha_ult_modif,       usuario_creacion, fecha_creacion, 
            RowPointer , asiento, clase_asiento )    
            VALUES ( @Paquete , @Tipo_Paquete , @Fecha  , 'F' ,'FA' , @RecibimosDe , 'N'        
            ,0,0,0,0,0,0,'SA', GETDATE(), 'SA' ,  GETDATE() , 
            @NewId , @Asiento , 'N' )

                                          
          set @NewId = ( SELECT NEWID() )
          set @iConsecutivoLineaAsiento = @iConsecutivoLineaAsiento + 1

			  -- Debito : FONDOS X DEPOSITAR
			  INSERT INTO dbo.diario ( asiento, consecutivo, cuenta_contable, centro_costo,       referencia, fuente,      
			  debito_local, debito_dolar,   credito_local, credito_dolar,       debito_unidades, credito_unidades, nit, tipo_cambio, RowPointer,base_local, base_dolar ) 
			  VALUES ( @Asiento        , @iConsecutivoLineaAsiento, @cta_DEBITO, @ctr_Debito, 
			  @DescrSubTipo + ' ' + @Cliente, @Paquete  + @Documento  ,
			  @Valor  , @ValorDolar, null, NULL, null, NULL, 'ND', NULL, @NewId, NULL, NULL ) 

			  set @NewId = ( SELECT NEWID() )
			  set @iConsecutivoLineaAsiento = @iConsecutivoLineaAsiento + 1
			  -- Credito : Ctas pox Cobrar
			  INSERT INTO dbo.diario ( asiento, consecutivo, cuenta_contable, centro_costo,       referencia, fuente,      
			  debito_local, debito_dolar,   credito_local, credito_dolar,       debito_unidades, credito_unidades, nit, tipo_cambio, RowPointer,base_local, base_dolar ) 
			  VALUES ( @Asiento        , @iConsecutivoLineaAsiento, @cta_Credito, @ctr_Credito, 
			  @DescrSubTipo + ' ' + @Cliente, @Paquete + @Documento  ,
			  null, NULL, @Valor , @ValorDolar,  null, NULL, 'ND', NULL, @NewId, NULL, NULL )              


SELECT @total_debito_loc = sum(ISNULL(DEBITO_LOCAL,0)), @total_credito_loc = sum(ISNULL(CREDITO_LOCAL,0)),
@total_debito_dol = sum(ISNULL(DEBITO_DOLAR,0)), @total_credito_dol = SUM(ISNULL(CREDITO_DOLAR,0)) 
FROM dbo.diario (NOLOCK)
WHERE asiento = @Asiento


UPDATE dbo.asiento_de_diario SET        total_debito_loc = @total_debito_loc ,  total_credito_loc =  @total_credito_loc,
total_debito_dol = @total_debito_dol, total_credito_dol = @total_credito_dol,        
total_control_loc = @total_credito_loc , total_control_dol = @total_credito_dol                     
WHERE asiento = @Asiento

-- Asignar el Asiento que pertenece a la Factura en Proceso
set @AsientoOutput = @Asiento
Update dbo.cppDocumentosCP  set Asiento = @Asiento, Contabilizado = 1
where IDDocumentoCP = @IDDocumento

-- GOOD BYE

END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	
	SELECT @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, -- Message text.
               16, --@ErrorSeverity, -- Severity.
               16--@ErrorState -- State.
               );
            IF (@@TRANCOUNT>0)
            ROLLBACK
END CATCH

IF (@@TRANCOUNT>0)
COMMIT TRANSACTION

go


CREATE Procedure dbo.cppSetAsientoReversion @DocumentoCredito bit, @Factura nvarchar(10), @CodSucursal nvarchar(4), @IDDocumentoCP int, @AsientoReversion nvarchar(20)
as
set nocount on
Declare @MayRevertir bit, @IDClase nvarchar(10)
if @DocumentoCredito = 0 
	if exists ( select FACTURA from dbo.fafFACTURA 
			where TIPO = '1' AND FACTURA = @Factura AND CODSUCURSAL = @CodSucursal
				and (AsientoReversion is null ) 
	)
		Update dbo.fafFACTURA	 set AsientoReversion = @AsientoReversion
		Where TIPO = '1' AND FACTURA = @Factura AND CODSUCURSAL = @CodSucursal

if @DocumentoCredito = 1
	if  exists ( select IDDocumentoCP from dbo.cppDocumentosCP  
			where IDDocumentoCP = @IDDocumentoCP  
				and  (AsientoReversion is null ) 
	)
	begin
		Select @Factura = Documento, @IDClase = IDClase From dbo.cppDocumentosCP Where IDDocumentoCP = @IDDocumentoCP
		Update dbo.cppDocumentosCP	 set AsientoReversion = @AsientoReversion
		Where IDDocumentoCP = @IDDocumentoCP  
				and  (AsientoReversion is null )		
		if @IDClase = 'FAC'
			Update dbo.fafFACTURA	 set AsientoReversion = @AsientoReversion
			Where TIPO = '2' AND FACTURA = @Factura AND CODSUCURSAL = @CodSucursal
				
	end
go

--exec dbo.cppGetDocNoContabilzados 1 '20150216' SELECT TOP 10 * FROM dbo.FAFFACTURA
--Select dbo.invGetNoFactura('CH00', '1')




update dbo.cppSubtipodocumento set CtaDebito = '4-02-01-010-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 15
update dbo.cppSubtipodocumento set CtaDebito = '4-02-01-002-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 16
update dbo.cppSubtipodocumento set CtaDebito = '4-01-01-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 17
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-003-029',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 18
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 19
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 20
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 21
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-001-082',CtaCredito='1-01-03-011-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 22
update dbo.cppSubtipodocumento set CtaDebito = '2-01-03-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 23
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-006-000',CtaCredito='1-01-03-011-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 24
update dbo.cppSubtipodocumento set CtaDebito = '1-01-08-004-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 25
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-001-066',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 26
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 27
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 28
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-007-200',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 29
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-005-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 30
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-010-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 31
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 32
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 33
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 34
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 35
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 36
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 37
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 38
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 39
update dbo.cppSubtipodocumento set CtaDebito = '1-01-06-001-000',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 40
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 41
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 42
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 43
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 44
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 45
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 46
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 47
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 48
update dbo.cppSubtipodocumento set CtaDebito = '4-02-01-010-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 49
update dbo.cppSubtipodocumento set CtaDebito = '4-02-01-002-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 50
update dbo.cppSubtipodocumento set CtaDebito = '4-01-01-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 51
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-003-029',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 52
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-003-029',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 53
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 54
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 55
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-001-082',CtaCredito='1-01-03-011-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 56
update dbo.cppSubtipodocumento set CtaDebito = '2-01-03-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 57
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-006-000',CtaCredito='1-01-03-011-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 58
update dbo.cppSubtipodocumento set CtaDebito = '1-01-08-004-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 59
update dbo.cppSubtipodocumento set CtaDebito = '5-02-01-001-066',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 60
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 61
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 62
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-007-200',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 63
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-005-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 64
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-010-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 65
update dbo.cppSubtipodocumento set CtaDebito = '2-01-06-001-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 66
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 67
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 68
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 69
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 70
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 71
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 72
update dbo.cppSubtipodocumento set CtaDebito = '9-07-02-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 73
update dbo.cppSubtipodocumento set CtaDebito = '1-01-06-001-000',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 74
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 75
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 76
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 77
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 78
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 79
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 80
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-009-004',CtaCredito='1-01-03-001-004',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 81
update dbo.cppSubtipodocumento set CtaDebito = '9-03-01-000-000',CtaCredito='1-01-03-001-010',NaturalezaCta ='D',SubTipoGeneraAsiento =1,EsRecuperacion =1 where IDSubtipo = 82

update dbo.cppSubtipodocumento set CtaDebito = '1-01-01-001-001',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 3



update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='5-02-01-002-001',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 6
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 7
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 8
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 9
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='5-02-01-002-001',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 10
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='4-02-01-006-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 11
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 12
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 13
update dbo.cppSubtipodocumento set CtaDebito = '1-01-03-001-010',CtaCredito='9-03-01-000-000',NaturalezaCta ='C',SubTipoGeneraAsiento =1,EsRecuperacion =0 where IDSubtipo = 14



-- Select * from dbo.cppDocumentosCP



--Agregados (Julio)
CREATE Procedure dbo.[cppGetAntiguedadSaldosDolar]  @IDProveedor nvarchar(20), @FechaCorte DATETIME,
@InclyeInteresAlNominal bit, @InclyeDeslizamientoAlNominal bit
as

set nocount on 
Create Table #Resultados( IDSaldo int, IDDocumentoCP int, IDProveedor nvarchar(20), 
TipoDocumento nvarchar(1), IDClase nvarchar(10), IDSubtipo int, Documento nvarchar(20), 
Fecha datetime, FechaDocVar datetime, Vencimiento datetime, VencimientoVar datetime, Plazo decimal(8,2),
MontoOriginal decimal(28,4), FechaUltCredito datetime, SaldoActual decimal(28,4), 
FechaSaldo datetime, Saldo decimal(28,4) ,DiasVencidos int,  SaldoNominal decimal(28,4) ,  Intereses decimal(28,4) , 
Deslizamiento decimal(28,4) , TotalaPagar decimal(28,4), EsInteres bit, EsDeslizamiento bit 
)

declare @TipoCambio as decimal(18,4)
select @TipoCambio=( SELECT dbo.[globalGetUltTasadeCambio] (@FechaCorte))


Insert #Resultados (IDSaldo, IDDocumentoCP, IDProveedor, TipoDocumento, IDClase, IDSubtipo, 
Documento, Fecha, FechaDocVar, Vencimiento, VencimientoVar, Plazo,	MontoOriginal, FechaUltCredito, SaldoActual, 
FechaSaldo, Saldo,DiasVencidos,  SaldoNominal,  Intereses, Deslizamiento, TotalaPagar, EsInteres, EsDeslizamiento)
exec dbo.cppGetDocumentosxCobrar  @IDProveedor, @FechaCorte

Delete From #Resultados
Where ( EsInteres = 1 and @InclyeInteresAlNominal = 0) or (EsDeslizamiento = 1 and @InclyeInteresAlNominal = 0)

	SELECT IDProveedor,NOMBRE, SUM(ISNULL(NominalNovencido,0)) NominalNovencido,
	SUM(ISNULL(Nominala30,0)) Nominala30,
	SUM(ISNULL(Nominal31a60,0)) Nominal31a60,
	SUM(ISNULL(Nominal61a90,0)) Nominal61a90,  
	SUM(ISNULL(Nominal91a120,0)) Nominal91a120,  
	SUM(ISNULL(Nominal21a180,0)) Nominal21a180,
	SUM(ISNULL(Nominal81a600,0)) Nominal81a600,
	SUM(ISNULL(Nominalmas600,0)) Nominalmas600,
	SUM(ISNULL(NominalNovencido,0)+ ISNULL(Nominala30,0)+ ISNULL(Nominal31a60,0)+ ISNULL(Nominal61a90,0)+
	ISNULL(Nominal91a120,0)+ISNULL(Nominal21a180,0)+ISNULL(Nominal81a600,0)+ISNULL(Nominalmas600,0)) TotalCliente

	FROM (
		SELECT  IDProveedor,NOMBRE, RANGO, case when rango = 'NO-VENC' then SUM(Nominal) ELSE 0 end NominalNovencido,
		case when rango = '1-30' then SUM(Nominal) ELSE 0 end Nominala30,
		case when rango = '31-60' then SUM(Nominal) ELSE 0 end Nominal31a60,
		case when rango = '61-90' then SUM(Nominal) ELSE 0 end Nominal61a90,
		case when rango = '91-120' then SUM(Nominal) ELSE 0 end Nominal91a120,
		case when rango = '121-180' then SUM(Nominal) ELSE 0 end Nominal21a180,
		case when rango = '181-600' then SUM(Nominal) ELSE 0 end Nominal81a600,
		case when rango = '+600' then SUM(Nominal) ELSE 0 end Nominalmas600    
		FROM 
		(
				SELECT  a.IDProveedor, b.NombresCliente + ' '+ b.apellidoscliente Nombre, a.DiasVencidos,  
		CASE WHEN a.DiasVencidos BETWEEN 1 AND 30 THEN '1-30' ELSE
			CASE WHEN a.DiasVencidos BETWEEN 31 AND 60 THEN '31-60' ELSE
				CASE WHEN a.DiasVencidos BETWEEN 61 AND 90 THEN '61-90' ELSE
					CASE WHEN a.DiasVencidos BETWEEN 91 AND 120 THEN '91-120' ELSE
						CASE WHEN a.DiasVencidos BETWEEN 121 AND 180 THEN '121-180' ELSE
							CASE WHEN a.DiasVencidos BETWEEN 181 AND 600 THEN '181-600' ELSE
								CASE WHEN a.DiasVencidos > 600 THEN '+600' ELSE
										CASE WHEN ( a.DiasVencidos <=0 ) THEN 'NO-VENC' ELSE 'ND' END
								END		
							END
						END
					END
				END				
			END
		END RANGO,
		a.SaldoNominal/@TipoCambio Nominal, a.Intereses/@TipoCambio Interes, a.TotalaPagar/@TipoCambio Total 
		FROM #Resultados a INNER JOIN dbo.cppProveedores b
		ON a.IDProveedor = b.IDProveedor


		) T1
		GROUP BY  IDProveedor, NOMBRE, RANGO
	) T2
	GROUP BY  IDProveedor, NOMBRE
	HAVING SUM(ISNULL(NominalNovencido,0)+ ISNULL(Nominala30,0)+ ISNULL(Nominal31a60,0)+ ISNULL(Nominal61a90,0)+
	ISNULL(Nominal91a120,0)+ISNULL(Nominal21a180,0)+ISNULL(Nominal81a600,0)+ISNULL(Nominalmas600,0)) > 0

drop table #Resultados
GO


CREATE PROCEDURE dbo.[cppGetSaldosCartera]  @FechaCorte datetime , @TipoSaldo int
--, @UltimoCortecpp int
AS 

declare @TipoCambio as decimal(18,4)
select @TipoCambio=( SELECT [fnica].[globalGetUltTasadeCambio] (@FechaCorte))

CREATE TABLE #tmpResultado
(
	IDSaldo int ,
	IDDocumentoCP int ,
	IDProveedor nvarchar(10) ,
	TipoDocumento nvarchar(1) ,
	IDClase nvarchar(10) ,
	IDSubtipo int ,
	Documento nvarchar(20) ,
	Fecha datetime ,
	FechaDocVar datetime ,
	Vencimiento datetime ,
	VencimientoVar datetime ,
	Plazo decimal(8, 2) ,
	MontoOriginal decimal(28, 4) ,
	FechaUltCredito datetime ,
	SaldoActual decimal(28, 4) ,
	FechaSaldo datetime ,
	Saldo decimal(28, 4) ,
	DiasVencidos int ,
	SaldoNominal decimal(28, 4) ,
	Deslizamiento decimal(28, 4) ,
	Intereses decimal(28, 4) ,
	TotalaPagar decimal(28, 4) ,
	EsInteres bit ,
	EsDeslizamiento bit
)


insert into #tmpresultado
EXECUTE dbo.cppGetDocumentosxCobrar 
  '*'
  ,@FechaCorte


--Saldos de Cartera Detalleado x cliente/Factura
if @TipoSaldo=1 
	select r.IDProveedor, c.NOMBRESCLIENTE + ' ' + c.APELLIDOSCLIENTE AS Cliente,TipoDocumento,Documento,Fecha,Vencimiento,DiasVencidos,SaldoNominal,r.Deslizamiento,r.Intereses,TotalaPagar
	,(SaldoNominal+r.Deslizamiento)/@TipoCambio SaldoDolar,r.Intereses/@TipoCambio InteresesDolar,TotalaPagar/@TipoCambio TotalaPagarDolar,
	CASE WHEN c.MOROSO=0 THEN 'ACTIVO' ELSE 'INACTIVO' END ACTIVO ,	c.FECHATOPE, c.PLAZODIAS, c.CEDULA, c.FECHAINGRESO,c.TIPOGARANTIA
	from #tmpresultado r inner join dbo.cppProveedores c on r.IDProveedor=c.IDProveedor

--Saldos de Cartera Detalleado x cliente
if @TipoSaldo=2 
	Select  r.IDProveedor, c.NOMBRESCLIENTE + ' ' + c.APELLIDOSCLIENTE AS Cliente,r.SaldoNominal,r.Deslizamiento,r.Intereses,r.TotalaPagar,
	r.SaldoDolar,r.InteresesDolar,r.TotalaPagarDolar,CASE WHEN c.MOROSO=0 THEN 'ACTIVO' ELSE 'INACTIVO' END ACTIVO ,	c.FECHATOPE, c.PLAZODIAS, c.CEDULA, c.FECHAINGRESO,c.TIPOGARANTIA
	from 
	(
		select IDProveedor,sum(SaldoNominal) SaldoNominal,sum(Deslizamiento) Deslizamiento,sum(Intereses) Intereses,sum(TotalaPagar) TotalaPagar


		,sum(SaldoNominal+Deslizamiento)/@TipoCambio SaldoDolar,sum(Intereses/@TipoCambio) InteresesDolar,sum(TotalaPagar/@TipoCambio) TotalaPagarDolar
		from #tmpresultado
		group by IDProveedor
	)r inner join dbo.cppProveedores c on r.IDProveedor=c.IDProveedor

--Saldos de Cartera Detalleado x Sucursal x Cliente
if @TipoSaldo=3 

	select sum(SaldoNominal) SaldoNominal,sum(Deslizamiento) Deslizamiento,sum(Intereses) Intereses,sum(TotalaPagar) TotalaPagar
	,sum(SaldoNominal+Deslizamiento)/@TipoCambio SaldoDolar,sum(Intereses/@TipoCambio) InteresesDolar,sum(TotalaPagar/@TipoCambio) TotalaPagarDolar
	from #tmpresultado





--declare @tmpFechaCorte datetime, @tmpFechaSistema datetime

--set @tmpFechaCorte = cast( cast(year(@FechaCorte) as nvarchar(4))+ '/'+ cast(month(@FechaCorte) as nvarchar(2))+ '/'+ cast(day(@FechaCorte) as nvarchar(2))  as datetime)
--set @tmpFechaSistema = cast(  cast(year(getdate()) as nvarchar(4))+ '/'+ cast(month(getdate()) as nvarchar(2))+ '/'+cast( day(getdate()) as nvarchar(2))  as datetime)

--set @Sucursal=isnull(@Sucursal,'*')

----Saldos de Cartera Detalleado x cliente
--	if @TipoSaldo=1 and @tmpFechaCorte<>@tmpFechaSistema--@UltimoCortecpp=1

--		SELECT CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE, SALDOULTIMOCORTE AS SALDO, NOVENCIDOULTIMOCORTE AS NOVENCIDO, 
--			   VENCIDOULTIMOCORTE AS VENCIDO, INTERESESULTIMOCORTE AS INTERESES, FECHAULTIMOCORTEcpp, TCAMBIOULTIMOCORTEcpp
--		FROM   dbo.cppProveedores
--		WHERE (SALDOULTIMOCORTE > 0) AND (CODSUCURSAL = @sucursal or @sucursal='*')
--		ORDER BY CODSUCURSAL, IDProveedor


--	if @TipoSaldo=1 and @tmpFechaCorte=@tmpFechaSistema-- @UltimoCortecpp=0

--		SELECT a.CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE, SALDO, NOVENCIDO, VENCIDO, INTERESES, 
--			   b.SUCURSAL, b.FECHAULTIMOCORTEcpp, b.TCAMBIOULTIMOCORTEcpp
--		FROM   dbo.cppProveedores a INNER JOIN  dbo.globalSUCURSALES b ON a.CODSUCURSAL = b.CODSUCURSAL
--		WHERE  SALDO > 0 AND (a.CODSUCURSAL = @sucursal or @sucursal='*')
--		ORDER BY a.CODSUCURSAL, a.IDProveedor

----Saldos de Cartera Detalleado x Sucursal x Cliente

--	if @TipoSaldo=2 and @tmpFechaCorte<>@tmpFechaSistema--@UltimoCortecpp=1
--		SELECT CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE, SALDOULTIMOCORTE AS SALDO, NOVENCIDOULTIMOCORTE AS NOVENCIDO, 
--			   VENCIDOULTIMOCORTE AS VENCIDO, INTERESESULTIMOCORTE AS INTERESES, FECHAULTIMOCORTEcpp, TCAMBIOULTIMOCORTEcpp
--		FROM   dbo.cppProveedores
--		WHERE (SALDO > 0) AND (CODSUCURSAL = @sucursal) ORDER BY CODSUCURSAL, IDProveedor

--	if @TipoSaldo=2 and @tmpFechaCorte=@tmpFechaSistema--@UltimoCortecpp=0

--		SELECT  a.CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE,SALDO, NOVENCIDO, VENCIDO, INTERESES, 
--				b.SUCURSAL, b.FECHAULTIMOCORTEcpp, b.TCAMBIOULTIMOCORTEcpp
--		FROM    dbo.cppProveedores a INNER JOIN dbo.globalSUCURSALES b ON a.CODSUCURSAL = b.CODSUCURSAL
--		WHERE   (SALDO > 0) AND (a.CODSUCURSAL = @sucursal)
--		ORDER BY a.CODSUCURSAL, a.IDProveedor

-----Saldos de Cartera menores a Cero/Negativos
--	if @TipoSaldo=3 and @tmpFechaCorte<>@tmpFechaSistema--@UltimoCortecpp=0
--		SELECT CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE, SALDOULTIMOCORTE AS SALDO, NOVENCIDOULTIMOCORTE AS NOVENCIDO, 
--			   VENCIDOULTIMOCORTE AS VENCIDO, INTERESESULTIMOCORTE AS INTERESES, FECHAULTIMOCORTEcpp, TCAMBIOULTIMOCORTEcpp
--		FROM   cppProveedores
--		WHERE (SALDO < 0) ORDER BY CODSUCURSAL, IDProveedor

--	if @TipoSaldo=3 and @tmpFechaCorte=@tmpFechaSistema--@UltimoCortecpp=1
--		SELECT a.CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE,SALDO, NOVENCIDO, VENCIDO, INTERESES, 
--			   b.SUCURSAL, b.FECHAULTIMOCORTEcpp,b.TCAMBIOULTIMOCORTEcpp
--		FROM dbo.cppProveedores a INNER JOIN dbo.globalSUCURSALES b ON a.CODSUCURSAL = b.CODSUCURSAL
--		WHERE (SALDO < 0)
--		ORDER BY a.CODSUCURSAL,a.IDProveedor

-----Saldos de Cartera entre 0.01 y 150
--	if @TipoSaldo=4 and @tmpFechaCorte<>@tmpFechaSistema--@UltimoCortecpp=0
--		SELECT CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE, SALDOULTIMOCORTE AS SALDO, NOVENCIDOULTIMOCORTE AS NOVENCIDO, 
--			   VENCIDOULTIMOCORTE AS VENCIDO, INTERESESULTIMOCORTE AS INTERESES, FECHAULTIMOCORTEcpp, TCAMBIOULTIMOCORTEcpp
--		FROM   cppProveedores
--		WHERE (SALDO * TCAMBIOULTIMOCORTEcpp BETWEEN 0.01 AND 150) ORDER BY CODSUCURSAL, IDProveedor

--	if @TipoSaldo=4 and @tmpFechaCorte=@tmpFechaSistema--@UltimoCortecpp=1
--		SELECT a.CODSUCURSAL, IDProveedor, NOMBRESCLIENTE, APELLIDOSCLIENTE,SALDO, NOVENCIDO, VENCIDO, INTERESES, 
--               b.SUCURSAL, b.FECHAULTIMOCORTEcpp,b.TCAMBIOULTIMOCORTEcpp
--		FROM         dbo.cppProveedores a INNER JOIN dbo.globalSUCURSALES b ON a.CODSUCURSAL = b.CODSUCURSAL
--		WHERE     (SALDO * b.TCAMBIOULTIMOCORTEcpp BETWEEN 0.01 AND 150)
--		ORDER BY a.CODSUCURSAL, a.IDProveedor

GO

CREATE PROCEDURE dbo.[uspcppGetAntiguedadSaldosDolar] @FechaCorte datetime , @IDProveedor as nvarchar(25)=null
AS 

declare @TipoCambio as decimal(18,4)
select @TipoCambio=( SELECT [fnica].[globalGetUltTasadeCambio] (@FechaCorte))

if @IDProveedor is null
	set  @IDProveedor='*'


declare @tmpFechaCorte datetime, @tmpFechaSistema datetime

set @tmpFechaCorte = cast( cast(year(@FechaCorte) as nvarchar(4))+ '/'+ cast(month(@FechaCorte) as nvarchar(2))+ '/'+ cast(day(@FechaCorte) as nvarchar(2))  as datetime)
set @tmpFechaSistema = cast(  cast(year(getdate()) as nvarchar(4))+ '/'+ cast(month(getdate()) as nvarchar(2))+ '/'+cast( day(getdate()) as nvarchar(2))  as datetime)

if @tmpFechaCorte=@tmpFechaSistema
begin
	SELECT  IDProveedor,NOMBRE, SUM(ISNULL(PrincipalNovencido,0)) PrincipalNovencido,
	SUM(ISNULL(Principal1a30,0)) Principal1a30,
	SUM(ISNULL(Principal31a60,0)) Principal31a60,
	SUM(ISNULL(Principal61a90,0)) Principal61a90,  
	SUM(ISNULL(Principal91a120,0)) Principal91a120,  
	SUM(ISNULL(Principal121a180,0)) Principal121a180,
	SUM(ISNULL(Principal181a600,0)) Principal181a600,
	SUM(ISNULL(Principalmas600,0)) Principalmas600,
	SUM(ISNULL(PrincipalNovencido,0)+ ISNULL(Principal1a30,0)+ ISNULL(Principal31a60,0)+ ISNULL(Principal61a90,0)+
	ISNULL(Principal91a120,0)+ISNULL(Principal121a180,0)+ISNULL(Principal181a600,0)+ISNULL(Principalmas600,0)) TotalCliente

	FROM (
		SELECT  IDProveedor,NOMBRE, RANGO, case when rango = 'NO-VENC' then SUM(Principal/@TipoCambio) ELSE 0 end PrincipalNovencido,
		case when rango = '1-30' then SUM(Principal/@TipoCambio) ELSE 0 end Principal1a30,
		case when rango = '31-60' then SUM(Principal/@TipoCambio) ELSE 0 end Principal31a60,
		case when rango = '61-90' then SUM(Principal/@TipoCambio) ELSE 0 end Principal61a90,
		case when rango = '91-120' then SUM(Principal/@TipoCambio) ELSE 0 end Principal91a120,
		case when rango = '121-180' then SUM(Principal/@TipoCambio) ELSE 0 end Principal121a180,
		case when rango = '181-600' then SUM(Principal/@TipoCambio) ELSE 0 end Principal181a600,
		case when rango = '+600' then SUM(Principal/@TipoCambio) ELSE 0 end Principalmas600    
		FROM 
		(
		SELECT  a.IDProveedor, b.NombresCliente + ' '+ b.apellidoscliente Nombre, a.Vencido, a.NoVencido, 
		CASE WHEN a.vencido BETWEEN 1 AND 30 THEN '1-30' ELSE
			CASE WHEN a.vencido BETWEEN 31 AND 60 THEN '31-60' ELSE
				CASE WHEN a.vencido BETWEEN 61 AND 90 THEN '61-90' ELSE
					CASE WHEN a.vencido BETWEEN 91 AND 120 THEN '91-120' ELSE
						CASE WHEN a.vencido BETWEEN 121 AND 180 THEN '121-180' ELSE
							CASE WHEN a.vencido BETWEEN 181 AND 600 THEN '181-600' ELSE
								CASE WHEN a.vencido > 600 THEN '+600' ELSE
										CASE WHEN ( a.vencido =0 and a.novencido = 0) OR a.novencido > 0  THEN 'NO-VENC' ELSE 'ND' END
								END		
							END
						END
					END
				END				
			END
		END RANGO,
		a.Principal, a.Interes, a.Total 
		FROM dbo.fafanexoglobal a INNER JOIN dbo.cppProveedores b
		ON a.IDProveedor = b.IDProveedor
		WHERE year(a.FechaCorte) = YEAR(@FechaCorte) AND month(a.FechaCorte) = month(@FechaCorte) AND day(a.FechaCorte) = day(@FechaCorte)
			 and a.cancelada=0 and (a.IDProveedor=@IDProveedor or @IDProveedor='*')
		) T1
		GROUP BY  IDProveedor, NOMBRE, RANGO
	) T2
	GROUP BY  IDProveedor, NOMBRE
	HAVING SUM(ISNULL(PrincipalNovencido,0)+ ISNULL(Principal1a30,0)+ ISNULL(Principal31a60,0)+ ISNULL(Principal61a90,0)+
	ISNULL(Principal91a120,0)+ISNULL(Principal121a180,0)+ISNULL(Principal181a600,0)+ISNULL(Principalmas600,0)) > 0
end
else
begin
 	SELECT IDProveedor,NOMBRE, SUM(ISNULL(PrincipalNovencido,0)) PrincipalNovencido,
	SUM(ISNULL(Principal1a30,0)) Principal1a30,
	SUM(ISNULL(Principal31a60,0)) Principal31a60,
	SUM(ISNULL(Principal61a90,0)) Principal61a90,  
	SUM(ISNULL(Principal91a120,0)) Principal91a120,  
	SUM(ISNULL(Principal121a180,0)) Principal121a180,
	SUM(ISNULL(Principal181a600,0)) Principal181a600,
	SUM(ISNULL(Principalmas600,0)) Principalmas600,
	SUM(ISNULL(PrincipalNovencido,0)+ ISNULL(Principal1a30,0)+ ISNULL(Principal31a60,0)+ ISNULL(Principal61a90,0)+
	ISNULL(Principal91a120,0)+ISNULL(Principal121a180,0)+ISNULL(Principal181a600,0)+ISNULL(Principalmas600,0)) TotalCliente

	FROM (
		SELECT IDProveedor,NOMBRE, RANGO, case when rango = 'NO-VENC' then SUM(Principal/@TipoCambio) ELSE 0 end PrincipalNovencido,
		case when rango = '1-30' then SUM(Principal/@TipoCambio) ELSE 0 end Principal1a30,
		case when rango = '31-60' then SUM(Principal/@TipoCambio) ELSE 0 end Principal31a60,
		case when rango = '61-90' then SUM(Principal/@TipoCambio) ELSE 0 end Principal61a90,
		case when rango = '91-120' then SUM(Principal/@TipoCambio) ELSE 0 end Principal91a120,
		case when rango = '121-180' then SUM(Principal/@TipoCambio) ELSE 0 end Principal121a180,
		case when rango = '181-600' then SUM(Principal/@TipoCambio) ELSE 0 end Principal181a600,
		case when rango = '+600' then SUM(Principal/@TipoCambio) ELSE 0 end Principalmas600    
		FROM 
		(
		SELECT a.IDProveedor, b.NombresCliente + ' '+ b.apellidoscliente Nombre, a.Vencido, a.NoVencido, 
		CASE WHEN a.vencido BETWEEN 1 AND 30 THEN '1-30' ELSE
			CASE WHEN a.vencido BETWEEN 31 AND 60 THEN '31-60' ELSE
				CASE WHEN a.vencido BETWEEN 61 AND 90 THEN '61-90' ELSE
					CASE WHEN a.vencido BETWEEN 91 AND 120 THEN '91-120' ELSE
						CASE WHEN a.vencido BETWEEN 121 AND 180 THEN '121-180' ELSE
							CASE WHEN a.vencido BETWEEN 181 AND 600 THEN '181-600' ELSE
								CASE WHEN a.vencido > 600 THEN '+600' ELSE
										CASE WHEN ( a.vencido =0 and a.novencido = 0) OR a.novencido > 0  THEN 'NO-VENC' ELSE 'ND' END
								END		
							END
						END
					END
				END				
			END
		END RANGO,
		a.Principal, a.Interes, a.Total 
		FROM dbo.fafAnexoGlobalUltimoCortecpp a INNER JOIN dbo.cppProveedores b
		ON a.IDProveedor = b.IDProveedor
		WHERE year(a.FechaCorte) = YEAR(@FechaCorte) AND month(a.FechaCorte) = month(@FechaCorte) AND day(a.FechaCorte) = day(@FechaCorte)
			and a.cancelada=0 and (a.IDProveedor=@IDProveedor or @IDProveedor='*')
		) T1
		GROUP BY  IDProveedor, NOMBRE, RANGO
	) T2
	GROUP BY  IDProveedor, NOMBRE
	HAVING SUM(ISNULL(PrincipalNovencido,0)+ ISNULL(Principal1a30,0)+ ISNULL(Principal31a60,0)+ ISNULL(Principal61a90,0)+
	ISNULL(Principal91a120,0)+ISNULL(Principal121a180,0)+ISNULL(Principal181a600,0)+ISNULL(Principalmas600,0)) > 0
END

GO


CREATE PROCEDURE dbo.[uspcppGetMovimientosCxCProveedores]  @fechainicial datetime ,@fechafinal datetime

AS 

select * into #tmpResultado from 
(
select w.*, isnull(d.NotaCredito,0) NotaCredito, isnull(d.NotaCreditoDolar,0) NotaCreditoDolar from 
(
	select y.*,isnull(c.NotaDebito,0) NotaDebito,isnull(c.NotaDebitoDolar,0) NotaDebitoDolar from 
	(
		Select z.*,isnull(b.Recibos,0)Recibos,isnull(b.RecibosDolar,0)RecibosDolar from --***Facturas
		(
			Select x.IDProveedor,x.NombresCliente+' '+x.ApellidosCliente NombresCliente,isnull(a.Facturas,0)Facturas,isnull(a.FacturasDolar,0)FacturasDolar
			from dbo.cppProveedores x left join 
			(
			Select IDProveedor,sum(totalfactura) Facturas,sum(totalfactura/tipocambio) FacturasDolar from dbo.faffactura 
			where fechafactura between @fechainicial and @fechafinal and anulada=0 and Tipo='2' 
			group by IDProveedor
			)a on x.IDProveedor =a.IDProveedor
		)z Left join --***Recibos
			(
				Select  IDProveedor, SUM(Recibos) Recibos,SUM(RecibosDolar) RecibosDolar from 
				(	
					Select IDProveedor,sum(valor) Recibos,sum(Valordolar) RecibosDolar from dbo.cpprecibos
					where fechaingreso between @fechainicial and @fechafinal and anulada=0 
					group by IDProveedor 
					union all --****For New SISCOBRO
					Select IDProveedor,SUM(MontoOriginal)Recibos,sum(MontoOriginal/TipoCambio) RecibosDolar from dbo.cppDocumentosCP 
					where fecha between @fechainicial and @fechafinal and anulado=0 and IDClase ='R/C' 
					group by IDProveedor
				)rc group by IDProveedor
			)b on z.IDProveedor =b.IDProveedor

	)y left join  --***Notas de Debito
		(
			Select  IDProveedor, SUM(NotaDebito) NotaDebito,SUM(NotaDebitoDolar) NotaDebitoDolar from 
				(
				Select IDProveedor,sum(valor) NotaDebito,sum(Valordolar) NotaDebitoDolar from dbo.cppnotasdebitocredito
				where fechaingreso between @fechainicial and @fechafinal and tipoNota='ND' and anulada=0 
				group by IDProveedor
				union all --****For New SISCOBRO
				Select IDProveedor,SUM(MontoOriginal)Recibos,sum(MontoOriginal/TipoCambio) RecibosDolar from dbo.cppDocumentosCP 
				where fecha between @fechainicial and @fechafinal and anulado=0 and IDClase ='N/D' 
				group by IDProveedor
			)nd group by IDProveedor

		)c on y.IDProveedor =c.IDProveedor
)w left join --***Notas de Credito
	(
		Select  IDProveedor, SUM(NotaCredito) NotaCredito,SUM(NotaCreditoDolar) NotaCreditoDolar from 
			(
				Select IDProveedor,sum(valor) NotaCredito,sum(Valordolar) NotaCreditoDolar from dbo.cppnotasdebitocredito
				where fechaingreso between @fechainicial and @fechafinal and tipoNota='NC' and anulada=0 
				group by IDProveedor
				union all --****For New SISCOBRO
				Select IDProveedor,SUM(MontoOriginal)Recibos,sum(MontoOriginal/TipoCambio) RecibosDolar from dbo.cppDocumentosCP 
				where fecha between @fechainicial and @fechafinal and anulado=0 and IDClase ='N/C' 
				group by IDProveedor
			)nc group by IDProveedor
	)d on w.IDProveedor =d.IDProveedor
)q 
where q.Facturas+q.Recibos+q.NotaDebito+NotaCredito<>0

Select *  from #tmpResultado 
where IDProveedor not in ('MG999','MG100')
order by IDProveedor 

