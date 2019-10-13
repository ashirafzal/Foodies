/*** FoodTime Database 2019 ***/
/*** Created by ashirafzal 8 Oct 2019 ***/

Create database foodtime

CREATE TABLE [dbo].[Activation] (
    [Appstatus] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Customer] (
    [CustID]    INT           IDENTITY (1, 1) NOT NULL,
    [CustName]  NVARCHAR (50) NULL,
    [Contact]   NVARCHAR (50) NULL,
    [OrderTime] TIME (7)      NOT NULL,
    [OrderDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([CustID] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT           IDENTITY (1, 1) NOT NULL,
    [CustID]        INT           NOT NULL,
    [OrderType]     NVARCHAR (50) NULL,
    [OrderCategory] NVARCHAR (50) NULL,
    [Ordertime]     TIME (7)      NOT NULL,
    [OrderDate]     DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Orders_custID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID])
);

CREATE TABLE [dbo].[Bill] (
    [InvioceID]            INT           NOT NULL,
    [CustID]               INT           NOT NULL,
    [OrderID]              INT           NOT NULL,
    [CustName]             NVARCHAR (50) NOT NULL,
    [ProductName]          NVARCHAR (50) NOT NULL,
    [ProductQuantity]      NVARCHAR (50) NOT NULL,
    [ProductRate]          NVARCHAR (50) NOT NULL,
    [ProductAmount]        NVARCHAR (50) NOT NULL,
    [ProductAmountWithGST] NVARCHAR (50) NOT NULL,
    [OrderTime]            TIME (7)      NOT NULL,
    [OrderDate]            DATE          NOT NULL,
    [Totalqty]             NVARCHAR (50) NOT NULL,
    [ActualAmount]         NVARCHAR (50) NOT NULL,
    [TotalAmount]          NVARCHAR (50) NOT NULL,
    [TotalAmountWithGST]   NVARCHAR (50) NOT NULL,
    [DiscountInPercent]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [FK_Bill_CustID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID]),
    CONSTRAINT [FK_Bill_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID])
);

CREATE TABLE [dbo].[Category] (
    [CategoryId]    INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName]  NVARCHAR (50) NULL,
    [CategoryImage] IMAGE         NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

CREATE TABLE [dbo].[Coupon] (
    [CouponId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CouponId] ASC)
);

CREATE TABLE [dbo].[DeletedBill] (
    [InvioceID]            INT           NOT NULL,
    [CustID]               INT           NOT NULL,
    [OrderID]              INT           NOT NULL,
    [CustName]             NVARCHAR (50) NOT NULL,
    [ProductName]          NVARCHAR (50) NOT NULL,
    [ProductQuantity]      NVARCHAR (50) NOT NULL,
    [ProductRate]          NVARCHAR (50) NOT NULL,
    [ProductAmount]        NVARCHAR (50) NOT NULL,
    [ProductAmountWithGST] NVARCHAR (50) NOT NULL,
    [OrderTime]            TIME (7)      NOT NULL,
    [OrderDate]            DATE          NOT NULL,
    [Totalqty]             NVARCHAR (50) NOT NULL,
    [ActualAmount]         NVARCHAR (50) NOT NULL,
    [TotalAmount]          NVARCHAR (50) NOT NULL,
    [TotalAmountWithGST]   NVARCHAR (50) NOT NULL,
    [DiscountInPercent]    NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[EditedBill] (
    [InvioceID2] INT NOT NULL
);

CREATE TABLE [dbo].[LoginDetails] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Loginuser]    NVARCHAR (50) NOT NULL,
    [usercategory] NVARCHAR (50) NOT NULL,
    [time]         TIME (7)      NOT NULL,
    [date]         DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[PcChecker] (
    [Hostname]  NVARCHAR (50) NOT NULL,
    [IpAddress] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Products] (
    [ProductId]       INT           IDENTITY (1, 1) NOT NULL,
    [ProductName]     NVARCHAR (50) NULL,
    [ProductPrice]    INT           NULL,
    [ProductCategory] NVARCHAR (50) NULL,
    [ProductImage]    IMAGE         NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

CREATE TABLE [dbo].[Sales] (
    [OrderID]       INT           NOT NULL,
    [CustID]        INT           NOT NULL,
    [CustName]      NVARCHAR (50) NOT NULL,
    [Contact]       NVARCHAR (50) NOT NULL,
    [OrderType]     NVARCHAR (50) NOT NULL,
    [OrderCategory] NVARCHAR (50) NOT NULL,
    [OrderTime]     TIME (7)      NOT NULL,
    [OrderDate]     DATE          NOT NULL,
    CONSTRAINT [FK_Sales_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    CONSTRAINT [FK_Sales_CustID] FOREIGN KEY ([CustID]) REFERENCES [dbo].[Customer] ([CustID])
);

CREATE TABLE [dbo].[Stock] (
    [stockid]       INT           IDENTITY (1, 1) NOT NULL,
    [stockname]     NVARCHAR (50) NOT NULL,
    [stockweigth]   INT           NOT NULL,
    [stockcompany]  NVARCHAR (50) NULL,
    [stockcategory] NVARCHAR (50) NOT NULL,
    [stockdate]     DATE          NOT NULL,
    [stocktime]     TIME (7)      NOT NULL,
    PRIMARY KEY CLUSTERED ([stockid] ASC)
);

CREATE TABLE [dbo].[stockstatus] (
    [id]                   INT           IDENTITY (1, 1) NOT NULL,
    [stockatthestartofday] NVARCHAR (50) NOT NULL,
    [stockdate]            NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[TrailDays]
(
	[startingdate] DATETIME NOT NULL, 
    [endingdate] DATETIME NOT NULL 
);

/*** Database SQL Codes End ***/