CREATE TABLE [dbo].[LiquidationMaster](
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
	Bal[float] ,
	 Net[float] , 
	 Tips[float] , 
	 FellowshipFund[float] , 
	 SmallChange[float] ,
	[SaveId] [int] NULL,
	Total float,
 CONSTRAINT [PK_LiquidationMaster] PRIMARY KEY CLUSTERED 
(
	[DayDate] ASC,
	[Shift] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


