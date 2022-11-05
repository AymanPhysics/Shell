CREATE TABLE PumpsInventoryDetails(
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	
Id [int],
Name [nvarchar](1000), 
TankName [nvarchar](1000),
ItemsPetroleumName [nvarchar](1000),
Bal0 [float],
CurrentBal [float],
Qty [float],
Price [float],
Value [float],
        
	[Line] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
) ON [PRIMARY]

GO


