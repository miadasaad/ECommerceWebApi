IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Brand] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Customer] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [price] decimal(18,2) NOT NULL,
    [description] nvarchar(max) NULL,
    [quantity] int NULL,
    [imgUrl] nvarchar(max) NULL,
    [CategoryId] int NOT NULL,
    [BrandId] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Payment] (
    [Id] int NOT NULL IDENTITY,
    [dateTime] datetime2 NOT NULL,
    [MethodType] nvarchar(max) NULL,
    [amount] decimal(18,2) NOT NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payment_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Shipment] (
    [Id] int NOT NULL IDENTITY,
    [DateTime] datetime2 NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Shipment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Shipment_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cart] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cart_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Cart_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [dateTime] datetime2 NOT NULL,
    [totalPrice] decimal(18,2) NOT NULL,
    [CustomerId] int NOT NULL,
    [PaymentId] int NOT NULL,
    [ShipmentId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Payment_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [Payment] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Shipment_ShipmentId] FOREIGN KEY ([ShipmentId]) REFERENCES [Shipment] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderProduct] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [OrdersId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderProduct_Orders_OrdersId] FOREIGN KEY ([OrdersId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProduct_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cart_CustomerId] ON [Cart] ([CustomerId]);
GO

CREATE INDEX [IX_Cart_ProductId] ON [Cart] ([ProductId]);
GO

CREATE INDEX [IX_OrderProduct_OrdersId] ON [OrderProduct] ([OrdersId]);
GO

CREATE INDEX [IX_OrderProduct_ProductId] ON [OrderProduct] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

CREATE INDEX [IX_Orders_PaymentId] ON [Orders] ([PaymentId]);
GO

CREATE INDEX [IX_Orders_ShipmentId] ON [Orders] ([ShipmentId]);
GO

CREATE INDEX [IX_Payment_CustomerId] ON [Payment] ([CustomerId]);
GO

CREATE INDEX [IX_Product_BrandId] ON [Product] ([BrandId]);
GO

CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
GO

CREATE INDEX [IX_Shipment_CustomerId] ON [Shipment] ([CustomerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516094420_tables', N'7.0.5');
GO

COMMIT;
GO

