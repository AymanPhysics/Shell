
update D
set Price=case when St.Flag=1 then PurchasePriceSub else PurchasePrice end 
from SalesDetails D
left join Items It on(D.ItemId=It.Id)
left join Stores St on(St.Id=D.StoreId)
where D.Flag=1


update D
set Value=Qty* Price
from SalesDetails D
left join Items It on(D.ItemId=It.Id)
left join Stores St on(St.Id=D.StoreId)
where D.Flag=1