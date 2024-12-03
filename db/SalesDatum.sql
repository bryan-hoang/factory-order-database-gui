CREATE TABLE [dbo].[SalesDatum] (
  [SalesDatumID] INT IDENTITY (1, 1) NOT NULL,
  [Name of Buyer] NVARCHAR (MAX) NOT NULL,
  [Weight per Bag] NVARCHAR (MAX) NOT NULL,
  [Price per Bag] NVARCHAR (MAX) NOT NULL,
  [Number of Bags] NVARCHAR (MAX) NOT NULL,
  [Total Cost] NVARCHAR (MAX) NOT NULL,
  [Payment Method] NVARCHAR (MAX) NOT NULL,
  [Date of Sale] NVARCHAR (MAX) NOT NULL,
  PRIMARY KEY CLUSTERED ([SalesDatumID] ASC)
);