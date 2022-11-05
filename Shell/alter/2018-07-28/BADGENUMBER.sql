alter table Employees add BADGENUMBER int
go
update Employees set BADGENUMBER =Id
go
alter table Loans add  BankId int
go
update Loans set BankId =0 where BankId  is null
go


alter table ItemsPrices add PriceSub float
go

update ItemsPrices set PriceSub =(select SalesPriceSub from Items where Id=ItemId)
