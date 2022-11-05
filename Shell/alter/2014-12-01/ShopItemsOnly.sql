alter table employees add ShopItemsOnly int
go
update Employees set ShopItemsOnly =0
go
alter table groups add IsShop int
go
update groups set IsShop =0
go
