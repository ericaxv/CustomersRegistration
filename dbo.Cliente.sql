CREATE TABLE [dbo].[Cliente] (
    [IdCliente] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (50) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

