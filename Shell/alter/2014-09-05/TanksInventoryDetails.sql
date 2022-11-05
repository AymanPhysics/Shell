CREATE TABLE [dbo].[TanksInventoryDetails](
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	[Id] [int] NULL,
	[Name] [nvarchar](1000) NULL,
	Bal0Size float,
	Bal0Qty float,
	BeforeSize float,
	BeforeQty float,
	AfterSize float,
	AfterQty float,
	NetSize float,
	NetQty float,
	CarQty float,
	PurshaseDiffQty float,
	CurrentBalSize float,
	CurrentBalQty float,
	SalesQty float,
	PumpsSalesQty float,
	SalesDiffQty float,
	[Line] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]

GO


