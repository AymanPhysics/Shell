Create TABLE [dbo].[InventoryMaster]
(
	[StoreId] [int] NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[DocNo] [nvarchar](100) NULL,
	[DayDate] [datetime] NULL,
	[Shift] [int] NULL,
	[InInvoiceNo] [int] NULL,
	[OutInvoiceNo] [int] NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
 CONSTRAINT [PK_InventoryMaster] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC,
	[InvoiceNo] ASC
)
)

Go

CREATE TABLE [dbo].[InventoryDetails](
	[StoreId] [int] NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[DayDate] [datetime] NULL,
	[Shift] [int] NULL,
	[ItemId] [int] NULL,
	[ItemName] [nvarchar](1000) NULL,
	[CurrentBal] [int] NULL,
	[RealBal] [int] NULL,
	[Deference] [int] NULL,
	[Line] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
)

go


alter table [InventoryDetails] alter column 	[CurrentBal] float
alter table [InventoryDetails] alter column 	[RealBal] float
alter table [InventoryDetails] alter column 	[Deference] float

