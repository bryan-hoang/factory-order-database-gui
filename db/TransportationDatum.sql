CREATE TABLE [dbo].[TransportationDatum] (
  [Id] INT IDENTITY (1, 1) NOT NULL,
  [Name of Seller] NVARCHAR (MAX) NOT NULL,
  [Truck Company] NVARCHAR (MAX) NOT NULL,
  [Quality] NVARCHAR (MAX) NOT NULL,
  [Weight] NVARCHAR (MAX) NOT NULL,
  [Price] NVARCHAR (MAX) NOT NULL,
  [Number of Bags] NVARCHAR (MAX) NOT NULL,
  [Freight Charges] NVARCHAR (MAX) NOT NULL,
  [Shipment Number] NVARCHAR (MAX) NOT NULL,
  [Date of Arrival] NVARCHAR (MAX) NOT NULL,
  [Total Cost] NVARCHAR (MAX) NOT NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
);