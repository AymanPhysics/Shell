CREATE TABLE [dbo].[ItemsPrices](
	[ItemId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	Price float,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]

GO
alter TABLE [dbo].[ItemsPrices] add Limit float

go

delete [ItemsPrices]
insert [ItemsPrices]([ItemId] ,	[StoreId] ,	Price ,Limit)
select items.Id i,Stores.Id,SalesPriceSub,LimitSub
	from stores cross join items