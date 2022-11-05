CREATE TABLE LiquidationDetails(
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	EmpId [int] NULL,
	EmpName [nvarchar](1000) NULL,
	Perc1 [float] NULL,
	Perc2 [float] NULL,
	Value [float] NULL,
	[Line] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]

GO
