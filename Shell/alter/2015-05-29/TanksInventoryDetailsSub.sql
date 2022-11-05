CREATE TABLE [dbo].TanksInventoryDetailsSub(
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	[Id] [int] NULL,
	[BeforeSize] [float] NULL,
	[BeforeQty] [float] NULL,
	[AfterSize] [float] NULL,
	[AfterQty] [float] NULL,
	[NetQty] [float] NULL,
	[CarQty] [float] NULL,
	[PurshaseDiffQty] [float] NULL,
	[SalesQty] [float] NULL,
	[Line] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
) ON [PRIMARY]

GO


