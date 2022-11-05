alter table PumpsInventoryDetails add Caliber float,SalesBal float
go
update PumpsInventoryDetails set Caliber =0,SalesBal =Qty where SalesBal  is null
go