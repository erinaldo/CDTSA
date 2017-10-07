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
SubTipo nvarchar(3) not null, Descr nvarchar(200), ReadOnlySys bit default 0, Activo bit default 1, Consecutivo int default 0 )

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
SaldoLibro decimal(28,4 ) default 0, SaldoBanco decimal(28,4 ) default 0, UltDeposito int default 0, UltCheque int default 0,
UltTransferencia int default 0, Limite decimal(28,4 ) default 0, 
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


Create Table dbo.cbCuentaFormatoCheque (IDFormato int not null, IDCuentaBanco int not null, FormatoCheque nvarchar(250), UltNoCheque int , Activo bit default 1)
go

alter table dbo.cbCuentaFormatoCheque add constraint pkCuentaFormatCheque primary key (IDFormato, IDCuentaBanco)
go
alter table dbo.cbCuentaFormatoCheque add constraint fkCuentaFormatCheque foreign key (IDCuentaBanco) references dbo.cbCuentaBancaria (IDCuentaBanco)
go

--drop table dbo.cbMovimientos
Create Table dbo.cbMovimientos (IDCuentaBanco int not null, Fecha date not null, IDTipo int not null, IDSubTipo int not null, 
Numero int not null, Pagadero_a nvarchar(250), Monto decimal(28,4) default 0, Asiento nvarchar(20), Anulado bit default 0, AsientoAnulacion nvarchar(20),
Usuario nvarchar(20), UsuarioAnulacion nvarchar(20), FechaAnulacion date,
Referencia nvarchar(100) Default ' ' not null, ConceptoContable nvarchar(255) )
go

alter table dbo.cbMovimientos add constraint pkcbMovimientos primary key (IDCuentaBanco, Fecha, IDTipo, IDSubtipo, Numero)
go

alter table dbo.cbMovimientos add constraint fkcbMovimientos foreign key (IDCuentaBanco) references dbo.cbCuentaBancaria (IDCuentaBanco)
go
alter table dbo.cbMovimientos add constraint fkcbTipo foreign key (IDTipo, IDSubTipo) references dbo.cbSubTipoDocumento (IDTipo, IDSubTipo)
GO


alter table dbo.cbMovimientos 
ADD CONSTRAINT uReferenciaUnica UNIQUE NONCLUSTERED
(
 IDCuentaBanco, Fecha, IDTipo, Numero, Referencia
)
go