USE CedetsaS4U
--Estructura de Privilegios
create TABLE [dbo].[secUSUARIO](
	[USUARIO] [nvarchar](20) NOT NULL,
	[DESCR] [nvarchar](200) NULL,
	[ACTIVO] [bit] NULL,
	[PASSWORD] [nvarchar](20) NULL
)
alter table [dbo].[secUSUARIO] add
 CONSTRAINT [PK_secUSUARIO] PRIMARY KEY CLUSTERED 
(
	[USUARIO] ASC
)
GO

CREATE TABLE [dbo].[secROLE](
	[IDROLE] [int] NOT NULL,
	[DESCR] [nvarchar](50) NULL,
	[DescrLarga] [nvarchar](200) NULL
)
GO
Alter table [dbo].[secROLE]
add CONSTRAINT [PK_secROLE] PRIMARY KEY CLUSTERED 
(
	[IDROLE] ASC
)
GO

CREATE TABLE [dbo].[secMODULO](
	[IDModulo] [int] NOT NULL,
	[Descr] [nvarchar](200) NULL
)
GO
Alter table [dbo].[secMODULO] add
 CONSTRAINT [PK_secModulo] PRIMARY KEY CLUSTERED 
(
	[IDModulo] ASC
)
GO
CREATE TABLE [dbo].[secUSUARIOROLE](
	[IDROLE] [int] NOT NULL,
	[USUARIO] [nvarchar](20) NOT NULL,
	[IDMODULO] [int] NOT NULL
)
GO
Alter table [dbo].[secUSUARIOROLE] add

 CONSTRAINT [PK_secUsuarioRole] PRIMARY KEY CLUSTERED 
(
	[IDROLE] ASC,
	[USUARIO] ASC,
	[IDMODULO] ASC
)
GO

CREATE TABLE [dbo].[secROLEACCION](
	[IDMODULO] [int] NOT NULL,
	[IDROLE] [int] NOT NULL,
	[IDACCION] [int] NOT NULL
)
GO
alter table [dbo].[secROLEACCION] add
 CONSTRAINT [PK_secRoleAccion] PRIMARY KEY CLUSTERED 
(
	[IDMODULO] ASC,
	[IDROLE] ASC,
	[IDACCION] ASC
)

GO
CREATE TABLE [dbo].[secACCION](
	[IDModulo] [int] NOT NULL,
	[IDAccion] [int] NOT NULL,
	[Descr] [nvarchar](200) NULL
)
GO
alter table [dbo].[secACCION] add
 CONSTRAINT [PK_secACCION] PRIMARY KEY CLUSTERED 
(
	[IDModulo] ASC,
	[IDAccion] ASC
)
GO


ALTER TABLE [dbo].[secUSUARIOROLE]  WITH CHECK ADD  CONSTRAINT [FK_secUsuarioRolex_secModulo] FOREIGN KEY([IDMODULO])
REFERENCES [dbo].[secMODULO] ([IDModulo])
GO

ALTER TABLE [dbo].[secUSUARIOROLE]  WITH CHECK ADD  CONSTRAINT [FK_secUSUARIOROLE_secUSUARIO] FOREIGN KEY([USUARIO])
REFERENCES [dbo].[secUSUARIO] ([USUARIO])
GO
ALTER TABLE [dbo].[secROLEACCION]  WITH CHECK ADD  CONSTRAINT [FK_secRoleAccion_secAccion] FOREIGN KEY([IDMODULO], [IDACCION])
REFERENCES [dbo].[secACCION] ([IDModulo], [IDAccion])
GO


ALTER TABLE [dbo].[secROLEACCION]  WITH CHECK ADD  CONSTRAINT [FK_secRoleAccion_secRole] FOREIGN KEY([IDROLE])
REFERENCES [dbo].[secROLE] ([IDROLE])
GO

ALTER TABLE [dbo].[secACCION]  WITH CHECK ADD  CONSTRAINT [FK_secAccion_secModulo] FOREIGN KEY([IDModulo])
REFERENCES [dbo].[secMODULO] ([IDModulo])
go 



create view [dbo].[vsecModuloRoleAccion]
as
SELECT     dbo.secROLEACCION.IDMODULO, dbo.secROLEACCION.IDROLE, dbo.secROLE.DESCR, dbo.secROLEACCION.IDACCION, 
                      dbo.secACCION.Descr AS DESCRACCION
FROM         dbo.secROLEACCION INNER JOIN
                      dbo.secROLE ON dbo.secROLEACCION.IDROLE = dbo.secROLE.IDROLE INNER JOIN
                      dbo.secACCION ON dbo.secROLEACCION.IDMODULO = dbo.secACCION.IDModulo AND dbo.secROLEACCION.IDACCION = dbo.secACCION.IDAccion
GO

CREATE VIEW [dbo].[vsecPrivilegios]
as
SELECT su.Usuario, m.IDModulo, m.Descr DescrModulo, ra.IDROLE,r.Descr DescrRole, a.IDAccion, a.Descr DescrAccion 
FROM dbo.secModulo m INNER JOIN dbo.secACCION a
ON m.IDModulo = a.IDModulo INNER JOIN dbo.secROLEACCION ra 
ON a.IDModulo = ra.IDMODULO AND a.IDAccion = ra.IDACCION INNER JOIN dbo.secRole r 
ON ra.IDROLE = r.idrole INNER JOIN dbo.secUSUARIOROLE su
ON r.idrole = su.idrole

GO

CREATE PROCEDURE dbo.secGetAccionFromModuloRole @IDModulo INT, @IDRole INT
as
set nocount on
SELECT RA.IDMODULO, RA.IDROLE, R.DESCR DESCRROLE, RA.IDACCION, A.DESCR DESCRACCION
FROM dbo.secRoleAccion RA INNER JOIN dbo.secRole R on
RA.IDRole = R.IDRole inner join dbo.secACCION A
ON RA.IDACCION = A.IDACCION
where RA.IDModulo = @IDModulo and RA.IDRole = @IDRole
GO

--************** PARA OTRO ROLE select * from dbo.secroleaccion where idrole = 2
--exec dbo.secGetRoleFromModuloUsuario 1000, 'azepeda'  drop procedure dbo.secGetRoleFromModuloUsuario
Create procedure dbo.secGetRoleFromModuloUsuario @IDModulo int, @Usuario nvarchar(50)
as 
Select distinct RA.IDRole, R.Descr, U.IDModulo, U.Usuario
From dbo.secRoleAccion RA inner join dbo.secRole R
on R.IDRole = RA.IDRole inner join dbo.secUsuarioRole U
on RA.IDRole = U.IDRole and R.IDRole = U.IDRole
where U.IDModulo = @IDModulo and  U.Usuario = @Usuario
GO


Create procedure dbo.secGetAccionesFromModuloUsuario @IDModulo int, @Usuario nvarchar(50)
as 
Select distinct RA.IDRole, A.IDAccion,A.Descr DescrAccion, R.Descr DescrRole, U.IDModulo, U.Usuario
From dbo.secRoleAccion RA inner join dbo.secRole R  on R.IDRole = RA.IDRole 
inner join dbo.secUsuarioRole U on RA.IDRole = U.IDRole and R.IDRole = U.IDRole
INNER JOIN dbo.secAccion A ON RA.IDACCION=A.IDAccion AND RA.IDMODULO=A.IDModulo
where U.IDModulo = @IDModulo and  U.Usuario = @Usuario


--INGRESO DE DATOS

insert [dbo].[secUSUARIO](
	[USUARIO] ,
	[DESCR] ,
	[ACTIVO] ,
	[PASSWORD] )
values ('azepeda', 'Alfonso Zepeda', 1, '123')

GO

insert [dbo].[secROLE] ([IDROLE] ,
	[DESCR] ,
	[DescrLarga])
values (1, 'Administrador', 'Administrador')
GO


insert [dbo].[secMODULO](
	[IDModulo],
	[Descr] )
VALUES (0, 'Módulo Contable')
GO

--SELECT IDMODULO, USUARIO, IDROLE, IDACCION  FROM dbo. vsecPrivilegios  WHERE USUARIO = 'azepeda' AND IDMODULO = 1

insert dbo.secAccion (IDModulo, IDAccion, Descr )
values (0, 1, 'Acceso al Sistema')
GO


insert [dbo].[secROLEACCION](
	[IDMODULO] ,
	[IDROLE] ,
	[IDACCION] )
values (0, 1, 1)

GO

insert [dbo].[secUSUARIOROLE](
	[IDROLE] ,
	[USUARIO] ,
	[IDMODULO])
values (1, 'azepeda', 0)
GO


