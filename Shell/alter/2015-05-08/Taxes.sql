alter table TanksInventoryDetails add Price float, PurchasePrice float, Ratio float,
Value  float,Taxes float
go
update TanksInventoryDetails set Price =0, PurchasePrice =0, Ratio =0,
Value  =0,Taxes =0 where Taxes is null
go
