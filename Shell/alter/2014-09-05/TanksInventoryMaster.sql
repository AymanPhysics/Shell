CREATE TABLE TanksInventoryMaster(
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK_TanksInventoryMaster] PRIMARY KEY CLUSTERED 
(
	[DayDate] ASC,
	[Shift] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


