delete ItemsBarcode
where Barcode in
(select dbo.ean13(id) from items)

insert ItemsBarcode
select Id,dbo.ean13(id),null,null from items

