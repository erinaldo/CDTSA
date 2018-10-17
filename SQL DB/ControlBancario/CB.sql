CREATE FUNCTION [dbo].[ufn_CantidadConLetra]
(
@Numero Decimal(19,4)
)
RETURNS Varchar(180)
AS
BEGIN

DECLARE @lnEntero INT,
@lcRetorno VARCHAR(512),
@lnTerna INT,
@lcMiles VARCHAR(512),
@lcCadena VARCHAR(512),
@lnUnidades INT,
@lnDecenas INT,
@lnCentenas INT,
@lnFraccion INT

SELECT @lnEntero = CAST(@Numero AS INT),
@lnFraccion = (@Numero - @lnEntero) * 100,
@lcRetorno = '',
@lnTerna = 1

WHILE @lnEntero > 0
BEGIN /* WHILE */
-- Recorro columna por columna
SELECT @lcCadena = ''
SELECT @lnUnidades = @lnEntero % 10
SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
SELECT @lnDecenas = @lnEntero % 10
SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
SELECT @lnCentenas = @lnEntero % 10
SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
--print cast(@lnCentenas as varchar(3)) + cast(@lnDecenas as varchar(3))+ cast(@lnUnidades as varchar(3))
--print @lnEntero

-- Analizo las unidades
SELECT @lcCadena =
CASE /* UNIDADES */
WHEN @lnUnidades = 1 AND @lnTerna = 1 THEN 'UNO ' + @lcCadena
WHEN @lnUnidades = 1 AND @lnTerna <> 1 THEN 'UN ' + @lcCadena
WHEN @lnUnidades = 2 THEN 'DOS ' + @lcCadena
WHEN @lnUnidades = 3 THEN 'TRES ' + @lcCadena
WHEN @lnUnidades = 4 THEN 'CUATRO ' + @lcCadena
WHEN @lnUnidades = 5 THEN 'CINCO ' + @lcCadena
WHEN @lnUnidades = 6 THEN 'SEIS ' + @lcCadena
WHEN @lnUnidades = 7 THEN 'SIETE ' + @lcCadena
WHEN @lnUnidades = 8 THEN 'OCHO ' + @lcCadena
WHEN @lnUnidades = 9 THEN 'NUEVE ' + @lcCadena
ELSE @lcCadena
END /* UNIDADES */

--print @lcCadena
-- Analizo las decenas
SELECT @lcCadena =
CASE /* DECENAS */
WHEN @lnDecenas = 1 THEN
CASE @lnUnidades
WHEN 0 THEN 'DIEZ '
WHEN 1 THEN 'ONCE '
WHEN 2 THEN 'DOCE '
WHEN 3 THEN 'TRECE '
WHEN 4 THEN 'CATORCE '
WHEN 5 THEN 'QUINCE '
ELSE 'DIECI' + @lcCadena
END
WHEN @lnDecenas = 2 AND @lnUnidades = 0 THEN 'VEINTE ' + @lcCadena
WHEN @lnDecenas = 2 AND @lnUnidades <> 0 THEN 'VEINTI' + @lcCadena
WHEN @lnDecenas = 3 AND @lnUnidades = 0 THEN 'TREINTA ' + @lcCadena
WHEN @lnDecenas = 3 AND @lnUnidades <> 0 THEN 'TREINTA Y ' + @lcCadena
WHEN @lnDecenas = 4 AND @lnUnidades = 0 THEN 'CUARENTA ' + @lcCadena
WHEN @lnDecenas = 4 AND @lnUnidades <> 0 THEN 'CUARENTA Y ' + @lcCadena
WHEN @lnDecenas = 5 AND @lnUnidades = 0 THEN 'CINCUENTA ' + @lcCadena
WHEN @lnDecenas = 5 AND @lnUnidades <> 0 THEN 'CINCUENTA Y ' + @lcCadena
WHEN @lnDecenas = 6 AND @lnUnidades = 0 THEN 'SESENTA ' + @lcCadena
WHEN @lnDecenas = 6 AND @lnUnidades <> 0 THEN 'SESENTA Y ' + @lcCadena
WHEN @lnDecenas = 7 AND @lnUnidades = 0 THEN 'SETENTA ' + @lcCadena
WHEN @lnDecenas = 7 AND @lnUnidades <> 0 THEN 'SETENTA Y ' + @lcCadena
WHEN @lnDecenas = 8 AND @lnUnidades = 0 THEN 'OCHENTA ' + @lcCadena
WHEN @lnDecenas = 8 AND @lnUnidades <> 0 THEN 'OCHENTA Y ' + @lcCadena
WHEN @lnDecenas = 9 AND @lnUnidades = 0 THEN 'NOVENTA ' + @lcCadena
WHEN @lnDecenas = 9 AND @lnUnidades <> 0 THEN 'NOVENTA Y ' + @lcCadena
ELSE @lcCadena
END /* DECENAS */

--print @lcCadena

--Analizo las centenas
SELECT @lcCadena =
CASE /* CENTENAS */
WHEN @lnCentenas = 1 AND @lnUnidades = 0 AND @lnDecenas = 0 THEN 'CIEN ' + @lcCadena
WHEN @lnCentenas = 1 AND NOT(@lnUnidades = 0 AND @lnDecenas = 0) THEN 'CIENTO ' + @lcCadena
WHEN @lnCentenas = 2 THEN 'DOSCIENTOS ' + @lcCadena
WHEN @lnCentenas = 3 THEN 'TRESCIENTOS ' + @lcCadena
WHEN @lnCentenas = 4 THEN 'CUATROCIENTOS ' + @lcCadena
WHEN @lnCentenas = 5 THEN 'QUINIENTOS ' + @lcCadena
WHEN @lnCentenas = 6 THEN 'SEISCIENTOS ' + @lcCadena
WHEN @lnCentenas = 7 THEN 'SETECIENTOS ' + @lcCadena
WHEN @lnCentenas = 8 THEN 'OCHOCIENTOS ' + @lcCadena
WHEN @lnCentenas = 9 THEN 'NOVECIENTOS ' + @lcCadena
ELSE @lcCadena
END /* CENTENAS */
--print @lcCadena

--Analizo los millares
SELECT @lcCadena =
CASE /* TERNA */
WHEN @lnTerna = 1 THEN @lcCadena
WHEN @lnTerna = 2 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) THEN @lcCadena + ' MIL '
WHEN @lnTerna = 3 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) AND
@lnUnidades = 1 AND @lnDecenas = 0 AND @lnCentenas = 0 THEN @lcCadena + ' MILLON '
WHEN @lnTerna = 3 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) AND
NOT (@lnUnidades = 1 AND @lnDecenas = 0 AND @lnCentenas = 0) THEN @lcCadena + ' MILLONES '
WHEN @lnTerna = 4 AND (@lnUnidades + @lnDecenas + @lnCentenas <> 0) THEN @lcCadena + ' MIL MILLONES '
ELSE ''
END /* MILLARES */
--print @lcCadena

--Armo el retorno columna a columna
--print @lcCadena
SELECT @lcRetorno = @lcCadena + @lcRetorno
SELECT @lnTerna = @lnTerna + 1

END /* WHILE */

IF @lnTerna = 1
SELECT @lcRetorno = 'CERO'

RETURN RTRIM(@lcRetorno)
END
GO


Create Table dbo.cbTipoRUC ( IDTipoRuc int identity(1,1) not null , Descr nvarchar(255), Activo bit default 1 )
Go
alter table dbo.cbTipoRUC add constraint pkTipoRuc primary key (IDTipoRuc)
go

insert dbo.cbTipoRUC ( Descr )
values ('RUC')
GO

insert dbo.cbTipoRUC ( Descr )
values ('CEDULA DE IDENTIDAD')
GO


Create Table dbo.cbRUC (IDRuc int not null, IDTipoRuc int not null , RUC nvarchar(20) not null, Nombre nvarchar(200), Alias nvarchar(200),  Activo BIT )
go

alter table dbo.cbRUC add constraint pkRUC primary key (IDRuc) 
go

alter table dbo.cbRUC add constraint ukRUC unique (RUC)
GO


alter table dbo.cbRUC add constraint FkTIPORUC foreign key (IDTipoRuc) references dbo.cbTipoRUC ( IDTipoRuc )
GO

Create Table dbo.cbBanco ( IDBanco int identity(1,1) not null, Codigo nvarchar(10) not null, 
Descr nvarchar(250) ,Activo bit default 1 )
go

alter table dbo.cbBanco add constraint pkcbBanco primary key (IDBanco)
go

alter table dbo.cbBanco add constraint ukcbBanco unique (Codigo)
go

--drop table dbo.cbTipoCuenta
Create Table dbo.cbTipoCuenta( IDTipo int not null, Descr nvarchar(250), Activo bit default 0 )
go

alter table dbo.cbTipoCuenta add constraint pkTipoCta primary key ( IDTipo )
go

Insert dbo.cbTipoCuenta( IDTipo, Descr )
values (1, 'Cuenta Corriente' )
go
Insert dbo.cbTipoCuenta( IDTipo, Descr )
values (2, 'Cuenta Ahorro' )
go
Insert dbo.cbTipoCuenta( IDTipo, Descr )
values (3, 'Cuenta de Debito' )
go
Insert dbo.cbTipoCuenta( IDTipo, Descr )
values (4, 'Tarjeta de Credito' )
go

Create Table dbo.cbTipoDocumento ( IDTipo int not null, Tipo nvarchar(3) not null , Descr nvarchar(200), Activo bit default 1 )
go

alter table dbo.cbTipoDocumento add constraint pkcbTipoDocumento primary key (IDTipo)
go

alter table dbo.cbTipoDocumento add constraint pkcbTipoDoc unique (Tipo)
go

Create Table dbo.cbSubTipoDocumento ( IDTipo int not null, IDSubtipo int not null, 
SubTipo nvarchar(3) not null, Descr nvarchar(200), ReadOnlySys bit default 0, Activo bit default 1 )

go
alter table dbo.cbSubTipoDocumento add constraint pkSubtipoDoc primary key (IDTipo, IDSubTipo)
go
alter table dbo.cbSubTipoDocumento add constraint usubtipodoc unique (SubTipo)
go

alter table dbo.cbSubTipoDocumento add constraint fksubtipodoc foreign key (IDTipo) references dbo.cbTipoDocumento (IDTipo)
go
insert dbo.cbTipoDocumento (IDTipo, Tipo, Descr, Activo )
values (0,'A/C', 'APERTURA DE SALDO DE CUENTA', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (1,'CHQ', 'CHEQUE', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (2,'DEP', 'DEPOSITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (3,'N/C', 'NOTA DE CREDITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (4,'N/D', 'NOTA DE DEBITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (5,'T/D', 'TRANSFERENCIA TIPO DEBITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (6,'T/C', 'TRANSFERENCIA TIPO CREDITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (7,'O/C', 'OTROS CREDITO', 1)
GO
insert dbo.cbTipoDocumento (IDTipo, Tipo , Descr, Activo )
values (8,'O/D', 'OTROS DEBITO', 1)
GO
-- SUBTIPOS DE DOCUMENTOS delete from dbo.cbSubTipoDocumento
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo , SUBTipo, Descr, Activo , ReadOnlySys )
values (0,0,'A/C', 'APERTURA DE SALDO DE CUENTA', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (1,1, 'CHQ', 'CHEQUE', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys)
values (2,1,'DEP', 'DEPOSITO', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (3,1,'N/C', 'NOTA DE CREDITO', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (4,1,'N/D', 'NOTA DE DEBITO', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (5,1,'T/D', 'TRANSFERENCIA TIPO DEBITO', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (6,1,'T/C', 'TRANSFERENCIA TIPO CREDITO', 1,1)
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo, ReadOnlySys )
values (7,1,'O/C', 'OTROS CREDITO', 1,1 )
GO
insert dbo.cbSubTipoDocumento (IDTipo, IDSubtipo, SUBTipo , Descr, Activo , ReadOnlySys )
values (8,1,'O/D', 'OTROS DEBITO', 1, 1)
GO


-- SELECT * FROM dbo.cbSubTipoDocumento


--drop table dbo.globalMoneda
Create Table dbo.globalMoneda ( IDMoneda int not null, Moneda nvarchar(20) not null, Simbolo nvarchar(10), Descr nvarchar(100), Activo bit default 1 )
go

Alter Table dbo.globalMoneda add constraint pkglobalMoneda primary key (IDMoneda)
go

Alter Table dbo.globalMoneda add constraint ukglobalMoneda unique (Moneda)
go

INSERT dbo.globalMoneda (IDMoneda, Moneda , Descr, Simbolo )
VALUES (1, 'LOCAL', 'Córdobas', 'C$' )
GO
INSERT dbo.globalMoneda (IDMoneda, Moneda , Descr, Simbolo )
VALUES (2, 'DOLAR', 'DOLAR', '$' )
GO

Create Table dbo.cbCuentaBancaria ( IDCuentaBanco int not null, Codigo nvarchar(25), Descr nvarchar(250),
IDBanco int not null, IDMoneda int not null, SaldoInicial decimal(28,4 ) default 0, FechaCreacion date,
IDTipo int not null, 
SaldoLibro decimal(28,4 ) default 0, SaldoBanco decimal(28,4 ) default 0, ConsecDeposito int default 0, ConsecCheque int default 0,
ConsecTransferencia int default 0, Limite decimal(28,4 ) default 0, 
Sobregiro bit default 0, IDCuenta int not null, Activa bit default 1 )

go

alter table dbo.cbCuentaBancaria add constraint pkcbCuentaBancaria primary key (IDCuentaBanco)
go

alter table dbo.cbCuentaBancaria add constraint fkMoneda foreign key (IDMoneda) references dbo.globalMoneda (IDMoneda)
go

alter table dbo.cbCuentaBancaria add constraint fkCuentaContable foreign key (IDCuenta) references dbo.cntCuenta (IDCuenta)
go


alter table dbo.cbCuentaBancaria add constraint fkcuentaTipo foreign key (IDTipo) references dbo.cbTipoCuenta (IDTipo)
go

alter table dbo.cbCuentaBancaria add constraint fkBanco foreign key (IDBanco) references dbo.cbBanco (IDBanco)
go


Create Table dbo.cbCuentaFormatoCheque (IDFormato int not null, IDCuentaBanco int not null, FormatoCheque nvarchar(250), Activo bit default 1)
go

alter table dbo.cbCuentaFormatoCheque add constraint pkCuentaFormatCheque primary key (IDFormato, IDCuentaBanco)
go
alter table dbo.cbCuentaFormatoCheque add constraint fkCuentaFormatCheque foreign key (IDCuentaBanco) references dbo.cbCuentaBancaria (IDCuentaBanco)
go

--drop table dbo.cbMovimientos
Create Table dbo.cbMovimientos (IDCuentaBanco int not null, Fecha date not null, IDTipo int not null, IDSubTipo int not null, 
IDRuc int not null, 
Numero int not null, Pagadero_a nvarchar(250), Monto decimal(28,4) default 0, Asiento nvarchar(20), Anulado bit default 0, AsientoAnulacion nvarchar(20),
Usuario nvarchar(20), UsuarioAnulacion nvarchar(20), FechaAnulacion date,UsuarioAprobacion nvarchar(20), FechaAprobacion date,UsuarioImpresion nvarchar(20),
FechaImpresion date,Impreso bit DEFAULT(0),
Referencia nvarchar(100) Default ' ' not null, ConceptoContable nvarchar(255) )
go

alter table dbo.cbMovimientos add constraint pkcbMovimientos primary key (IDCuentaBanco, Fecha, IDTipo, IDSubtipo, Numero)
go

alter table dbo.cbMovimientos add constraint fkcbMovimientos foreign key (IDCuentaBanco) references dbo.cbCuentaBancaria (IDCuentaBanco)
go
alter table dbo.cbMovimientos add constraint fkcbTipo foreign key (IDTipo, IDSubTipo) references dbo.cbSubTipoDocumento (IDTipo, IDSubTipo)
GO
alter table dbo.cbMovimientos add constraint fkcbRUC foreign key (IDRUC) references dbo.cbRUC (IDRUC)
go


alter table dbo.cbMovimientos 
ADD CONSTRAINT uReferenciaUnica UNIQUE NONCLUSTERED
(
 IDCuentaBanco, Fecha, IDTipo, Numero, Referencia
)
GO


--Valida si el deposito es unico segun la referencia antes de ingresarlo a la base de datos.
CREATE FUNCTION [dbo].[cbReferenciaValida] (@IDCuentaBanco int, @IDTipo int, @IDSubTipo int, @Fecha date, @Numero int, @Referencia nvarchar(100))
RETURNS bit
AS
BEGIN
declare @Resultado bit, @TipoDeposito int
Set @TipoDeposito = (SELECT Distinct IDTipo FROM dbo.cbSubTipoDocumento where SubTipo = 'DEP')

IF @IDTipo = @TipoDeposito
Begin

IF exists (SELECT Distinct IDTipo 
FROM dbo.cbMovimientos 
WHERE IDCuentaBanco = @IDCuentaBanco and IDTipo = @IDTipo and Fecha = @Fecha 
and Numero = @Numero and Referencia = @Referencia )
set @Resultado = 0
ELSE
set @Resultado = 1
end
ELSE
Begin
set @Resultado = 1
End

RETURN @Resultado
END

GO

CREATE Procedure [dbo].[cbUpdateBanco] @Operacion nvarchar(1), @IDBanco int, @Codigo nvarchar(10), @Descr nvarchar(250),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO dbo.cbBanco ( Codigo, Descr, Activo )
	VALUES (@Codigo,@Descr,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDBanco  from  dbo.cbCuentaBancaria    Where IDBanco  = @IDBanco)	
	begin 
		RAISERROR ( 'El Banco esta asociado a una cuenta bancaria, no puede eliminarla', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.cbBanco WHERE IDBanco = @IDBanco 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbBanco SET  Descr = @Descr,Activo=@Activo WHERE IDBanco=@IDBanco

end

GO

CREATE   Procedure [dbo].[cbUpdateCuentaBancaria] @Operacion nvarchar(1), @IDCuentaBanco int, @Codigo nvarchar(10), @Descr nvarchar(250),
			@IDBanco INT,@IDMoneda INT ,@SaldoInicial DECIMAL(28,4), @FechaCreacion DATE,@IDTipo INT, @Limite DECIMAL(28,4),@IDCuenta int ,@Activa BIT
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDCuentaBanco =  (SELECT ISNULL(MAX(IDCuentaBanco),0) +1  FROM dbo.cbCuentaBancaria)
	INSERT INTO dbo.cbCuentaBancaria  ( IDCuentaBanco ,Codigo ,Descr ,IDBanco ,IDMoneda ,SaldoInicial ,FechaCreacion ,IDTipo ,SaldoLibro ,SaldoBanco ,
	          ConsecDeposito ,ConsecCheque ,ConsecTransferencia ,Limite ,Sobregiro ,IDCuenta ,Activa)
	VALUES (@IDCuentaBanco,@Codigo,@Descr,@IDBanco,@IDMoneda,@SaldoInicial,@FechaCreacion,@IDTipo,0,0,0,0,0,@Limite,0,@IDCuenta,@Activa)
END 

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDCuentaBanco  from  dbo.cbMovimientos    Where IDCuentaBanco  = @IDCuentaBanco)	
	begin 
		RAISERROR ( 'La Cuenta bancanria tiene movimientos, no puede ser eliminada. ', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.cbCuentaBancaria WHERE IDCuentaBanco = @IDCuentaBanco 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbCuentaBancaria SET Codigo=@Codigo,  Descr = @Descr, IDBanco=@IDBanco,IDMoneda=@IDMoneda,
											IDTipo=@IDTipo,Limite=@Limite,IDCuenta=@IDCuenta,Activa=@Activa
	WHERE IDCuentaBanco=@IDCuentaBanco

end

GO


CREATE  Procedure [dbo].[cbUpdateSubTipoDocumento] @Operacion nvarchar(1), @IDTipo int, @IDSubTipo INT ,@SubTipo NVARCHAR(3),@Descripcion NVARCHAR(200),@Activo bit
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDSubTipo =  (SELECT ISNULL(MAX(IDSubTipo),1) +1 FROM dbo.cbSubTipoDocumento)
	INSERT INTO dbo.cbSubTipoDocumento( IDTipo ,IDSubtipo ,SubTipo ,Descr ,ReadOnlySys ,Activo )
	VALUES  ( @IDTipo,@IDSubTipo,@SubTipo,@Descripcion,0,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if  (( Select ReadOnlySys  from  dbo.cbSubTipoDocumento    Where IDSubTipo  = @IDSubTipo)	=1)
	begin 
		RAISERROR ( 'No puede eliminar el SubTipo, es un documento del sistema', 16, 1) ;
		return				
	END
	
	if Exists ( Select IDSubTipo  from  dbo.cbMovimientos    Where IDSubTipo  = @IDSubTipo)	
	begin 
		RAISERROR ( 'El SubTipo tiene movimientos, no puede eliminarla', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.cbSubTipoDocumento WHERE IDSubtipo = IDSubtipo AND IDTipo =@IDTipo
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbSubTipoDocumento SET  Descr = @Descripcion,Activo=@Activo WHERE IDTipo=@IDTipo AND IDSubtipo=@IDSubTipo

end

GO


CREATE  Procedure [dbo].[cbUpdateTipoDocumento] @Operacion nvarchar(1), @IDTipo int, @Tipo NVARCHAR(3),@Descripcion NVARCHAR(200),@Activo bit
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDTipo =  (SELECT ISNULL(MAX(IDTipo),0) +1 FROM dbo.cbTipoDocumento)
	INSERT INTO dbo.cbTipoDocumento( IDTipo, Tipo, Descr, Activo )
	VALUES  ( @IDTipo,@Tipo,@Descripcion,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if  EXISTS( Select IDTipo  from  dbo.cbSubTipoDocumento    Where IDTipo  = @IDTipo)
	begin 
		RAISERROR ( 'No puede eliminar el Tipo de Documento, se encuentra asociado a un SubTipo', 16, 1) ;
		return				
	END
	
	DELETE  FROM dbo.cbTipoDocumento WHERE  IDTipo =@IDTipo
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbTipoDocumento SET  Descr = @Descripcion,Activo=@Activo WHERE IDTipo=@IDTipo 

end

GO


CREATE Procedure [dbo].[cbUpdateTipoCuenta] @Operacion nvarchar(1), @IDTipo int,@Descripcion NVARCHAR(200),@Activo bit
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDTipo =  (SELECT ISNULL(MAX(IDTipo),0)+1 FROM dbo.cbTipoCuenta)
	
	INSERT INTO dbo.cbTipoCuenta ( IDTipo, Descr, Activo )
	VALUES  ( @IDTipo,@Descripcion,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if  EXISTS( Select IDTipo  from  dbo.cbCuentaBancaria    Where IDTipo  = @IDTipo)
	begin 
		RAISERROR ( 'No puede eliminar el Tipo Cuenta, se encuentra asociado a una Cuenta Bancaria', 16, 1) ;
		return				
	END
	
	DELETE  FROM dbo.cbTipoCuenta WHERE  IDTipo =@IDTipo
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbTipoCuenta SET  Descr = @Descripcion,Activo=@Activo WHERE IDTipo=@IDTipo 

end

GO

CREATE  Procedure [dbo].[cbUpdateCuentaFormatoCheque] @Operacion nvarchar(1), @IDFormato INT OUTPUT,@IDCuentaBanco INT , @FormatoCheque NVARCHAR(200) ,@Activo bit
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	SET @IDFormato =  (SELECT ISNULL(MAX(IDFormato),0) +1 FROM dbo.cbCuentaFormatoCheque)
	INSERT INTO dbo.cbCuentaFormatoCheque( IDFormato ,IDCuentaBanco ,FormatoCheque  ,Activo)
	VALUES  ( @IDFormato,@IDCuentaBanco,@FormatoCheque,@Activo)
end

if upper(@Operacion) = 'D'
begin

	
	DELETE  FROM dbo.cbCuentaFormatoCheque WHERE  IDFormato =@IDFormato
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbCuentaFormatoCheque SET  FormatoCheque = @FormatoCheque,Activo=@Activo WHERE IDFormato=@IDFormato 

end

GO

--DROP Procedure [dbo].[cbUpdateMovimientos]
CREATE   Procedure [dbo].[cbUpdateMovimientos] @Operacion nvarchar(1), @IDCuentaBanco int,@Fecha DATE,@IDTipo INT,@IDSubTipo INT,@IDRuc int,@Numero INT,
		@Pagaderoa nvarchar(250),@Monto DECIMAL(28,4),@Usuario NVARCHAR(20),@Referencia nvarchar(100),@ConceptoContable NVARCHAR(200)
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	INSERT INTO dbo.cbMovimientos( IDCuentaBanco ,Fecha ,IDTipo ,IDSubTipo,IDRuc ,Numero ,Pagadero_a ,Monto   ,Usuario   ,Referencia ,ConceptoContable)
	VALUES  ( @IDCuentaBanco,@Fecha,@IDTipo,@IDSubTipo,@IDRuc,@Numero,@Pagaderoa,@Monto,@Usuario,@Referencia,@ConceptoContable)
	
	--CK
	--IF (@IDTipo=1)
	--	UPDATE dbo.cbCuentaBancaria SET ConsecCheque = @Numero WHERE IDCuentaBanco=@IDCuentaBanco
end

--if upper(@Operacion) = 'D'
--begin

	
--end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbMovimientos SET  Referencia = @Referencia,IDRuc=@IDRuc,ConceptoContable=@ConceptoContable,Pagadero_a=@Pagaderoa,Monto=@Monto WHERE IDCuentaBanco=@IDCuentaBanco AND Fecha=@Fecha AND  IDTipo=@IDTipo AND IDSubTipo=@IDSubTipo AND Numero=@Numero

end


GO


--drop PROCEDURE dbo.cbNextConsecutivoCheque
CREATE PROCEDURE dbo.cbNextConsecutivoCheque  @IDCuentaBanco AS INT,@NextConsecutivo AS INT OUTPUT
AS 
--SET @IDSUBTIPO=1
--SET @IDTIPO=1

SELECT @NextConsecutivo= ISNULL(ConsecCheque,0) + 1 FROM dbo.cbCuentaBancaria WHERE IDCuentaBanco=@IDCuentaBanco 



GO

CREATE   Procedure [dbo].[cbUpdateRUC] @Operacion nvarchar(1), @IDRuc int, @IDTipoRuc INT ,@Ruc nvarchar(20), @Nombre nvarchar(200),@Alias nvarchar(200),@Activo BIT
as
set nocount on 

if upper(@Operacion) = 'I'
BEGIN
	IF (EXISTS(SELECT *  FROM dbo.cbRUC WHERE RUC=@Ruc OR Nombre=@Nombre))
	BEGIN	
		RAISERROR ( 'El numero RUC y el nombre del Nit deben de ser únicos.', 16, 1) ;
		return				
	END
	
	SET @IDRuc = (SELECT ISNULL(MAX(IDRuc),0)+1  FROM dbo.cbRUC)
	
	INSERT INTO dbo.cbRUC( IDRuc ,IDTipoRuc ,RUC ,Nombre ,Alias  ,Activo)
	VALUES (@IDRuc,@IDTipoRuc,@Ruc,@Nombre,@Alias,@Activo)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDRuc  from  dbo.cbMovimientos    Where IDRuc  = @IDRuc)	
	begin 
		RAISERROR ( 'El ruc posee movimientos en el detalle de movimientos, no puede eliminarla', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.cbRUC WHERE IDRuc = @IDRuc 
end

if upper(@Operacion) = 'U' 
BEGIN
	UPDATE dbo.cbRUC SET  Nombre = @Nombre,Alias =@Alias,Activo=@Activo,IDTipoRuc=@IDTipoRuc WHERE IDRuc=@IDRuc

end



GO

CREATE  PROCEDURE dbo.cbGetMovimientosByCriterios @FechaInicial AS DATE,@FechaFinal AS DATE,@IDRuc AS INT,@NombreRUC AS NVARCHAR(100),@AliasRUC NVARCHAR(100),
						@IDTipo AS INT,@IDSubTipo AS INT,@PagaderoA AS NVARCHAR(100),@Anulado AS INT,@Referencia AS NVARCHAR(200),@ConceptoContable AS NVARCHAR(200)
AS 
SELECT  M.IDCuentaBanco,CB.Descr DescrCuentaBancaria,M.Fecha ,M.IDTipo ,T.Descr DescrTipo,M.IDSubTipo ,D.Descr DescrSubTipo,M.IDRuc ,R.Alias,R.Nombre,M.Numero ,
        M.Pagadero_a ,M.Monto ,M.Asiento ,M.Anulado ,M.AsientoAnulacion ,M.Usuario ,M.UsuarioAnulacion ,M.FechaAnulacion ,M.UsuarioAprobacion, M.FechaAprobacion,
       M.UsuarioImpresion,M.FechaImpresion,M.Impreso, M.Referencia ,M.ConceptoContable  
        FROM dbo.cbMovimientos M
INNER JOIN dbo.cbTipoCuenta T ON M.IDTipo = T.IDTipo
INNER JOIN dbo.cbSubTipoDocumento D ON D.IDTipo = M.IDTipo AND D.IDSubtipo=M.IDSubTipo
INNER JOIN dbo.cbCuentaBancaria CB ON M.IDCuentaBanco=CB.IDCuentaBanco
INNER JOIN dbo.cbRUC R ON M.IDRuc=R.IDRuc
WHERE M.Fecha BETWEEN @FechaInicial AND @FechaFinal AND (M.IDTipo= @IDTipo OR @IDTipo=-1) AND (M.IDSubTipo=@IDSubTipo OR @IDSubtipo=-1)
AND (Pagadero_a LIKE '%' + @PagaderoA + '%') AND (Anulado=@Anulado OR @Anulado=-1) AND (Referencia LIKE '%' + @Referencia + '%') AND ConceptoContable LIKE '%' + @ConceptoContable + '%'
AND (R.Nombre LIKE '%' + @NombreRUC + '%') AND (r.Alias LIKE '%' + @AliasRUC +'%')


GO


CREATE   PROCEDURE dbo.rptGetCheque @IDCuentaBanco AS int,@IDTipo AS int,@IDSubTipo AS int,@Numero AS int
AS 
SELECT  M.IDCuentaBanco ,
		B.Descr,B.ConsecCheque,
        M.Fecha ,
        M.IDTipo ,
        M.IDSubTipo ,
        M.IDRuc ,
        M.Numero ,
        M.Pagadero_a ,
        M.Monto ,
        [dbo].[ufn_CantidadConLetra](M.Monto) MontoEnLetras,  
        M.Asiento ,
        M.Anulado ,
        M.AsientoAnulacion ,
        M.Usuario ,
        M.UsuarioAnulacion ,
        M.FechaAnulacion ,
       M.UsuarioAprobacion,
       M.FechaAprobacion,
       M.UsuarioImpresion,
       M.FechaImpresion,
       M.Impreso, 
        M.Referencia ,
        M.ConceptoContable
FROM dbo.cbMovimientos M
INNER JOIN dbo.cbCuentaBancaria B ON M.IDCuentaBanco=B.IDCuentaBanco
WHERE M.IDCuentaBanco=@IDCuentaBanco AND M.IDTipo=@IDTipo AND M.IDSubTipo=@IDSubTipo AND M.Numero=@Numero

GO



CREATE   PROCEDURE dbo.cbGenerarAsientoContableCheque  @Numero AS INT, @IDCuentaBanco AS INT,@IDTipo AS INT, @IDSubTipo AS INT, @Usuario AS NVARCHAR(50)
AS 
/*
DECLARE @Numero AS INT
DECLARE @IDCuentaBanco AS INT
DECLARE @IDTipo AS INT
DECLARE @IDSubTipo AS INT
DECLARE @IDRuc AS INT
DECLARE @Usuario AS NVARCHAR(50)


SET @IDCuentaBanco =1
SET @Numero =1
SET @IDTipo =1
SET @IDSubTipo=1
SET @IDRuc =2
SET @Usuario ='admin'

*/

DECLARE @IDCuentaProveedor AS INT
DECLARE @IDCuentaContableBanco AS INT
DECLARE @IDEjercicio AS INT
DECLARE @Periodo AS NVARCHAR(10)
DECLARE @IDAsiento AS NVARCHAR(20)
DECLARE @Fecha AS DATE
DECLARE @TipoCambio AS DECIMAL(28,4)
DECLARE @Asiento AS NVARCHAR(20)
DECLARE @Monto AS DECIMAL(28,4)
DECLARE @IDRuc AS INT

DECLARE	@TipoTC AS NVARCHAR(20)
SELECT @TipoTC = TipoCambio FROM dbo.cntParametros

SET @TipoCambio = (SELECT dbo.globalGetTipoCambio(@Fecha,@TipoTC))
SELECT @Fecha = Fecha , @Monto = CASE WHEN C.IDMoneda=2  THEN Monto * @TipoCambio ELSE Monto END, @IDRuc =IDRuc  FROM dbo.cbMovimientos M
INNER JOIN dbo.cbCuentaBancaria C ON M.IDCuentaBanco = C.IDCuentaBanco
 WHERE M.IDCuentaBanco=@IDCuentaBanco AND M.IDTipo=@IDTipo AND IDSubTipo =@IDSubTipo AND Numero=@Numero

SELECT @IDCuentaContableBanco=IDCuenta  FROM dbo.cbCuentaBancaria WHERE IDCuentaBanco=@IDCuentaBanco


declare @LongAsiento INT , @Consecutivo int 

select @LongAsiento = LongAsiento from dbo.cntParametros 

SELECT  @IDEjercicio=IDEjercicio, @Periodo=Periodo 
 FROM dbo.cntPeriodoContable WHERE FechaFinal = CAST( DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@Fecha)+1,0)) AS DATE)





SELECT @Asiento = (tipo + RIGHT( replicate('0', @LongAsiento ) + cast (Consecutivo + 1 as nvarchar(20)), @LongAsiento ) ),
 				@Consecutivo = Consecutivo + 1     
				FROM dbo.cntTipoAsiento (UPDLOCK)                             
				WHERE TIPO = 'BA'
				if exists (Select Asiento From dbo.cntAsiento (NOLOCK)  where Asiento = @Asiento )
				begin
					RAISERROR ( 'Ya Existe ese asiento contable, no se puede crear', 16, 1) ;		
				end	
				Update dbo.cntTipoAsiento set UltimoAsiento = @Asiento , Consecutivo = @Consecutivo 		 			
				where Tipo = 'BA' 

--Grabar la cabecera del asiento
INSERT INTO dbo.cntAsiento( IDEjercicio ,Periodo ,Asiento ,Tipo ,Fecha ,FechaHora ,Createdby ,CreateDate ,Mayorizadoby ,MayorizadoDate
											 , Anuladoby ,AnuladoDate ,Concepto ,Mayorizado ,Anulado ,TipoCambio ,ModuloFuente ,CuadreTemporal)
VALUES  ( @IDEjercicio , -- IDEjercicio - int
          @Periodo , -- Periodo - nvarchar(10)
          @Asiento , -- Asiento - nvarchar(20)
          N'BA' , -- Tipo - nvarchar(2)
          @Fecha , -- Fecha - date
          GETDATE() , -- FechaHora - datetime
           @Usuario, -- Createdby - nvarchar(20)
          GETDATE() , -- CreateDate - datetime
          N'' , -- Mayorizadoby - nvarchar(20)
          NULL , -- MayorizadoDate - datetime
          N'' , -- Anuladoby - nvarchar(20)
          Null , -- AnuladoDate - datetime
          N'Generado de modulo Bancario CK: ' + CAST(@Numero AS NVARCHAR(20)) , -- Concepto - nvarchar(255)
          0 , -- Mayorizado - bit
          0 , -- Anulado - bit
          @TipoCambio , -- TipoCambio - decimal
          N'CB' , -- ModuloFuente - nvarchar(2)
          0  -- CuadreTemporal - bit
        )
       
-- Guardar el detalle del asiento contable
INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
VALUES  ( @Asiento , -- Asiento - nvarchar(20)
          1 , -- Linea - int
          0, -- IDCentro - int
          @IDCuentaContableBanco , -- IDCuenta - int
          N'' , -- Referencia - nvarchar(255)
          NULL , -- Debito - decimal
          @Monto , -- Credito - decimal
          N'' , -- Documento - nvarchar(255)
          '2017-11-24 02:09:37'  -- daterecord - datetime
        )
 
--Actualizar consecutivo del Cheque
UPDATE dbo.cbCuentaBancaria SET ConsecCheque = @Numero WHERE IDCuentaBanco=@IDCuentaBanco

UPDATE dbo.cbMovimientos SET Asiento=@Asiento, FechaAprobacion = GETDATE(), usuarioAprobacion = @Usuario WHERE IDCuentaBanco=@IDCuentaBanco AND IDSubTipo=@IDSubTipo AND IDTipo=@IDTipo AND Numero=@Numero


SELECT @Asiento  Asiento

GO

CREATE PROCEDURE dbo.cbAnularAsientoContableCheque  @Numero AS INT, @IDCuentaBanco AS INT,@IDTipo AS INT, @IDSubTipo AS INT, @Usuario AS NVARCHAR(50)
AS 
/*
DECLARE @Numero AS INT
DECLARE @IDCuentaBanco AS INT
DECLARE @IDTipo AS INT
DECLARE @IDSubTipo AS INT
DECLARE @IDRuc AS INT
DECLARE @Usuario AS NVARCHAR(50)


SET @IDCuentaBanco =1
SET @Numero =1
SET @IDTipo =1
SET @IDSubTipo=1
SET @IDRuc =2
SET @Usuario ='admin'

*/

DECLARE @IDEjercicio AS INT
DECLARE @Periodo AS NVARCHAR(10)
DECLARE @Fecha AS DATE
DECLARE @TipoCambio AS DECIMAL(28,4)
DECLARE @Asiento AS NVARCHAR(20)
DECLARE @AsientoAnt AS NVARCHAR(20)
DECLARE @Monto AS DECIMAL(28,4)


SELECT @AsientoAnt = asiento FROM dbo.cbMovimientos WHERE IDCuentaBanco=@IDCuentaBanco AND IDSubTipo=@IDSubTipo AND IDTipo=@IDTipo AND Numero=@Numero


DECLARE	@TipoTC AS NVARCHAR(20)
SELECT @TipoTC = TipoCambio FROM dbo.cntParametros

SET @TipoCambio = (SELECT dbo.globalGetTipoCambio(@Fecha,@TipoTC))

declare @LongAsiento INT , @Consecutivo int 

select @LongAsiento = LongAsiento from dbo.cntParametros 

SELECT  @IDEjercicio=IDEjercicio, @Periodo=Periodo 
 FROM dbo.cntPeriodoContable WHERE FechaFinal = CAST( DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@Fecha)+1,0)) AS DATE)


SELECT @Asiento = (tipo + RIGHT( replicate('0', @LongAsiento ) + cast (Consecutivo + 1 as nvarchar(20)), @LongAsiento ) ),
 				@Consecutivo = Consecutivo + 1     
				FROM dbo.cntTipoAsiento (UPDLOCK)                             
				WHERE TIPO = 'BA'
				if exists (Select Asiento From dbo.cntAsiento (NOLOCK)  where Asiento = @Asiento )
				begin
					RAISERROR ( 'Ya Existe ese asiento contable, no se puede crear', 16, 1) ;		
				end	
				Update dbo.cntTipoAsiento set UltimoAsiento = @Asiento , Consecutivo = @Consecutivo 		 			
				where Tipo = 'BA' 

--Grabar la cabecera del asiento
INSERT INTO dbo.cntAsiento( IDEjercicio ,Periodo ,Asiento ,Tipo ,Fecha ,FechaHora ,Createdby ,CreateDate ,Mayorizadoby ,MayorizadoDate
											 , Anuladoby ,AnuladoDate ,Concepto ,Mayorizado ,Anulado ,TipoCambio ,ModuloFuente ,CuadreTemporal)

SELECT  @IDEjercicio ,@Periodo ,@Asiento ,Tipo ,GETDATE() ,GETDATE() ,@Usuario ,GETDATE() ,NULL ,NULL MayorizadoDate ,NULL Anuladoby ,
        NULL AnuladoDate , 'Reversion del asiento contable ' + @Asiento Concepto , NULL Mayorizado ,0 Anulado ,@TipoCambio TipoCambio 
        ,ModuloFuente ,0 CuadreTemporal FROM dbo.cntAsiento WHERE Asiento=@AsientoAnt


-- Guardar el detalle del asiento contable
INSERT INTO dbo.cntAsientoDetalle( Asiento ,Linea ,IDCentro ,IDCuenta ,Referencia ,Debito ,Credito ,Documento ,daterecord)
SELECT  @Asiento ,Linea ,IDCentro ,IDCuenta ,'ANULACION -- '  + Referencia Referencia ,Credito Debito ,Debito Credito ,@AsientoAnt Documento ,GETDATE()  
FROM dbo.cntAsientoDetalle WHERE Asiento=@AsientoAnt

 
UPDATE dbo.cbMovimientos SET Anulado=1, AsientoAnulacion=@Asiento,FechaAnulacion = GETDATE(), UsuarioAnulacion = @Usuario WHERE 
IDCuentaBanco=@IDCuentaBanco AND IDSubTipo=@IDSubTipo AND IDTipo=@IDTipo AND Numero=@Numero


GO

CREATE PROCEDURE dbo.cbMarcarChequeImpreso  @Numero AS INT, @IDCuentaBanco AS INT,@IDTipo AS INT, @IDSubTipo AS INT, @Usuario AS NVARCHAR(50)
AS 
update dbo.cbMovimientos SET Impreso=1, UsuarioImpresion = @Usuario,FechaImpresion=GETDATE() WHERE IDCuentaBanco=@IDCuentaBanco AND IDTipo=@IDTipo AND IDSubTipo=@IDSubTipo AND Numero=@Numero
