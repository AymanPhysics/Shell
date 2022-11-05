alter table statics add ItemTransferInAccNo bigint not null default ''
alter table statics add ItemTransferOutAccNo bigint not null default ''
go
update statics set ItemTransferInAccNo =''
update statics set ItemTransferOutAccNo =''

