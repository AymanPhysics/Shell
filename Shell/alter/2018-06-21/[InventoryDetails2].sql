 
CREATE TABLE [dbo].[InventoryDetails2](
	[StoreId] [int] NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[DayDate] [datetime] NULL,
	[Shift] [int] NULL,
	[ItemId] [int] NULL,
	[ItemName] [nvarchar](1000) NULL,
	Qty [float] NULL,
	QtyAdd [float] NULL,
	QtyBal [float] NULL,
	[Deference] [float] NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[UnitId] [int] NULL,
	[Barcode] [nvarchar](100) NULL,
	[Line] [int] NULL
) ON [PRIMARY]

GO


