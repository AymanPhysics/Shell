alter table InventoryDetails add Barcode nvarchar(100)
go
update InventoryDetails set Barcode ='' where Barcode  is null
go
