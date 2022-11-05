CREATE TABLE [dbo].[TanksInventoryDetails2](
	InvoiceNo bigint,
	[DayDate] [datetime]  NULL,
	[Shift] [int]  NULL,
	[Id] [int] NULL,
	[Name] [nvarchar](1000) NULL,
	[Bal0Size] [float] NULL,
	[Bal0Qty] [float] NULL,
	[BeforeSize] [float] NULL,
	[BeforeQty] [float] NULL,
	[AfterSize] [float] NULL,
	[AfterQty] [float] NULL,
	[NetSize] [float] NULL,
	[NetQty] [float] NULL,
	[CarQty] [float] NULL,
	[PurshaseDiffQty] [float] NULL,
	[CurrentBalSize] [float] NULL,
	[CurrentBalQty] [float] NULL,
	[SalesQty] [float] NULL,
	[PumpsSalesQty] [float] NULL,
	[SalesDiffQty] [float] NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Price] [float] NULL,
	[PurchasePrice] [float] NULL,
	[Ratio] [float] NULL,
	[Value] [float] NULL,
	[Taxes] [float] NULL,
	[Line] [int] NULL
) ON [PRIMARY]

GO


