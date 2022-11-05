CREATE TABLE [dbo].[BankCashMoney](
	[InvoiceNo] [int] NOT NULL,
	[Flag] [int] NOT NULL,
	Price [float] NULL,
	Qty [float] NULL,
	Value [float] NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL
) ON [PRIMARY]
go
CREATE TABLE [dbo].[MoneyTypes](
	Price [float] ,
	Line int identity(1,1)
)
go
insert [MoneyTypes] select 0.25
insert [MoneyTypes] select 0.5
insert [MoneyTypes] select 1
insert [MoneyTypes] select 5
insert [MoneyTypes] select 10
insert [MoneyTypes] select 20
insert [MoneyTypes] select 50
insert [MoneyTypes] select 100
insert [MoneyTypes] select 200
insert [MoneyTypes] select 500
insert [MoneyTypes] select 1000
