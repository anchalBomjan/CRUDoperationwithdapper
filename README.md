# CRUDoperationwithdapper



Install-Package Dapper
Install-Package Microsoft.Extensions.Configuration
Install-Package Microsoft.Extensions.DependencyInjection.Abstractions
Install-Package System.Data.SqlClient




--------------------database first--------------



CREATE TABLE [dbo].[Products] (
    [ProductId]          UNIQUEIDENTIFIER NOT NULL,
    [ProductName]        NVARCHAR (100)   NULL,
    [Price]              DECIMAL (18)     NULL,
    [ProductDescription] NVARCHAR (MAX)   NULL,
    [CreatedOn]          DATETIME         NULL,
    [UpdateOn]           DATETIME         NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

Products/Index
we can able to do  edit, delete, and details  function.
