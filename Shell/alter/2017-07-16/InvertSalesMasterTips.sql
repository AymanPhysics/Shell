alter table statics add InvertSalesMasterTips int
go
update Statics set InvertSalesMasterTips=0
update Statics set InvertSalesMasterTips=1 -- Shady :)
