alter table groups add TradingFirstAccNo nvarchar(100),TradingLastAccNo  nvarchar(100),BudgetAccNo  nvarchar(100)
go
update groups set TradingFirstAccNo ='',TradingLastAccNo  ='',BudgetAccNo  ='' where BudgetAccNo   is null
go
select * from chart where EndType=1 and SubType=1