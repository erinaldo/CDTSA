CREATE FUNCTION [dbo].[globalDiaDelMes] 
(-- @Cual = 'U' ultimo Dia 'P' Primemr
	@Fecha datetime,
	@Cual nvarchar(1)
	
)
RETURNS datetime
AS
BEGIN
DECLARE @Date DATETIME
if upper(@Cual) = 'P' --Primer Dia
	SET @date = (SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@Fecha)-1),@Fecha),111) AS Date_Value) 
if upper(@Cual) = 'U' --Ultimo Dia	
	SET @date = (SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@Fecha))),DATEADD(mm,1,@Fecha)),111))
	RETURN @Date
END


go

CREATE TABLE [dbo].[globalTipoCambio](
	[IDTipoCambio] [nvarchar](20) NOT NULL,
	[Descr] [nvarchar](50) NOT NULL,
 CONSTRAINT [pkTipoCambio] PRIMARY KEY CLUSTERED 
(
	[IDTipoCambio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[globalTipoCambioDetalle](
	[IDTipoCambio] [nvarchar](20) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Monto] [decimal](28, 8) NULL,
 CONSTRAINT [pkTipoCambioDetalle] PRIMARY KEY CLUSTERED 
(
	[IDTipoCambio] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[globalTipoCambioDetalle]  WITH CHECK ADD  CONSTRAINT [fkTipoCambioDetalle] FOREIGN KEY([IDTipoCambio])
REFERENCES [dbo].[globalTipoCambio] ([IDTipoCambio])
GO

ALTER TABLE [dbo].[globalTipoCambioDetalle] CHECK CONSTRAINT [fkTipoCambioDetalle]
GO

ALTER TABLE [dbo].[globalTipoCambioDetalle] ADD  DEFAULT ((0)) FOR [Monto]
GO


CREATE Procedure [dbo].[globalUpdateTipoCambio] @Operacion nvarchar(1), @IDTipoCambio NVARCHAR (20), @Descr AS NVARCHAR(50)
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO  dbo.globalTipoCambio( IDTipoCambio, Descr )
	VALUES ( @IDTipoCambio , @Descr )
END

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDTipoCambio  from  dbo.globalTipoCambioDetalle    Where IDTipoCambio  = @IDTipoCambio)	
	begin 
		RAISERROR ( 'El tipo de Cambio no puede eliminarser por que tiene dependencias en la Relacion TipoCambio - TipoCambioDetalle.', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.globalTipoCambio WHERE IDTipoCambio=@IDTipoCambio
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.globalTipoCambio set Descr = @Descr 
	where IDTipoCambio = @IDTipoCambio
end

GO



CREATE Procedure [dbo].[globalUpdateTipoCambioDetalle] @Operacion nvarchar(1), @IDTipoCambio NVARCHAR (20), @Fecha AS date, @Monto AS decimal(28,8)
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO  dbo.globalTipoCambioDetalle( IDTipoCambio, Fecha,Monto )
	VALUES ( @IDTipoCambio , @Fecha,@Monto	)
END

if upper(@Operacion) = 'D'
begin
	DELETE  FROM dbo.globalTipoCambioDetalle WHERE IDTipoCambio=@IDTipoCambio AND Fecha=@Fecha
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.globalTipoCambioDetalle set Monto = @Monto
	where IDTipoCambio = @IDTipoCambio AND Fecha=@Fecha
end


GO

INSERT INTO dbo.globalTipoCambio
        ( IDTipoCambio, Descr )
VALUES  ( N'TVEN', -- IDTipoCambio - nvarchar(20)
          N'Tipo de Cambio de Venta'  -- Descr - nvarchar(50)
          )
GO



CREATE TABLE [dbo].[globalCompania](
	[IDCompania] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](30) NULL,
	[Logo] [image] NULL,
	[UsaCentroCosto] [bit] NULL,
	[SimboloMonedaFuncional] [nvarchar](10) NULL,
	[SimboloMonedaExtrangera] [nvarchar](10) NULL,
	[CantDigitosDecimales] [int] NULL,
	[TipoCambio] [nvarchar](20) NULL,
 CONSTRAINT [pk_GlobalCompania] PRIMARY KEY CLUSTERED 
(
	[IDCompania] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[globalCompania]  WITH CHECK ADD  CONSTRAINT [FK_globalCompania_globalTipoCambio] FOREIGN KEY([TipoCambio])
REFERENCES [dbo].[globalTipoCambio] ([IDTipoCambio])
GO

ALTER TABLE [dbo].[globalCompania] CHECK CONSTRAINT [FK_globalCompania_globalTipoCambio]
GO


