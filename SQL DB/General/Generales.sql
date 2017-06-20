

CREATE TABLE [dbo].[globalCompania](
	[Compania] [nvarchar](10) NOT NULL,
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
	[Compania] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[globalCompania]  WITH CHECK ADD  CONSTRAINT [FK_globalCompania_globalTipoCambio] FOREIGN KEY([TipoCambio])
REFERENCES [dbo].[globalTipoCambio] ([IDTipoCambio])
GO

ALTER TABLE [dbo].[globalCompania] CHECK CONSTRAINT [FK_globalCompania_globalTipoCambio]
GO


