USE [ventas]
GO

/****** Object: Table [dbo].[Articulos] Script Date: 9/12/18 7:14:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulos] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]             VARCHAR (70)    NOT NULL,
    [Descripcion]        VARCHAR (MAX)   NULL,
    [CantidadExistencia] INT             NOT NULL,
    [Precio]             NUMERIC (18, 2) NOT NULL,
    [CategoriaId]        INT             NOT NULL,
    [FechaRegistro]      DATETIME        NOT NULL,
    [FechaModificacion]  DATETIME        NULL
);

/****** Object: Table [dbo].[ArticulosCategorias] Script Date: 9/12/18 7:14:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticulosCategorias] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Nombre] VARCHAR (50) NOT NULL
);

/****** Object: Table [dbo].[Clientes] Script Date: 9/12/18 7:14:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Identificacion] VARCHAR (20)  NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [Telefono]       VARCHAR (15)  NULL,
    [Direccion]      VARCHAR (255) NULL,
    [FechaRegistro]  DATETIME      NOT NULL
);


/****** Object: Table [dbo].[Facturas] Script Date: 9/12/18 7:15:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Facturas] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [ClienteId]      INT             NOT NULL,
    [MontoNeto]      NUMERIC (18, 2) NOT NULL,
    [MontoImpuesto]  NUMERIC (18, 2) NOT NULL,
    [MontoDescuento] NUMERIC (18, 2) NOT NULL,
    [MontoTotal]     NUMERIC (18, 2) NOT NULL,
    [FechaRegistro]  DATETIME        NOT NULL
);

/****** Object: Table [dbo].[FacturasDetalles] Script Date: 9/12/18 7:15:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturasDetalles] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [FacturaId]  INT             NOT NULL,
    [ArticuloId] INT             NOT NULL,
    [Cantidad]   INT             NOT NULL,
    [Monto]      NUMERIC (18, 2) NOT NULL
);


ALTER TABLE [dbo].[Articulos]
    ADD CONSTRAINT [FK_Articulos_ArticulosCategorias] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[ArticulosCategorias] ([Id]);

ALTER TABLE [dbo].[Facturas]
    ADD CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id]);

ALTER TABLE [dbo].[FacturasDetalles]
    ADD CONSTRAINT [FK_FacturasDetalles_Articulos] FOREIGN KEY ([ArticuloId]) REFERENCES [dbo].[Articulos] ([Id]);

ALTER TABLE [dbo].[FacturasDetalles]
    ADD CONSTRAINT [FK_FacturasDetalles_Facturas] FOREIGN KEY ([FacturaId]) REFERENCES [dbo].[Facturas] ([Id]);


