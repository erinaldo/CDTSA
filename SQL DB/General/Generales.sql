CREATE TABLE dbo.globalCompania(Compania NVARCHAR(10) NOT NULL,Nombre NVARCHAR(100),Direccion NVARCHAR(100),Telefono NVARCHAR(30),Logo IMAGE,UsaCentroCosto BIT,MonedaFuncional NVARCHAR(10) )
GO 
ALTER TABLE dbo.globalCompania ADD  CONSTRAINT pk_GlobalCompania PRIMARY KEY  (Compania)
