CREATE TABLE Tanks(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1000) NULL,
	TankTypeId int,
	ItemsPetroleumId int,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]
GO

CREATE TABLE Pumps(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1000) NULL,
	TankId int,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]
GO


CREATE TABLE TankTypes(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]
GO

insert TankTypes select 1,'Tank22500',1,GETDATE()
insert TankTypes select 2,'Tank45000',1,GETDATE()