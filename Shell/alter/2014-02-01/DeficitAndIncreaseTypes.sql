
CREATE TABLE [dbo].DeficitAndIncreaseTypes(
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]

GO


delete DeficitAndIncreaseTypes
insert DeficitAndIncreaseTypes select 1,'���',1,GETDATE()
insert DeficitAndIncreaseTypes select 2,'�����',1,GETDATE()