alter table ItemsPetroleum add PurchasePrice float,Ratio float
go
update ItemsPetroleum set PurchasePrice=0,Ratio =0 where Ratio is null
go

alter table statics add OilSupplierAccNo bigint
go
update statics set OilSupplierAccNo =667791
go


alter table TanksInventoryMaster add ToId bigint
go
update TanksInventoryMaster set ToId =667791
go

