
create table CustomersCars(CustId bigint,CarNo nvarchar(100))

go

insert CustomersCars(CustId ,CarNo )
select distinct ToId,CarNo from  SalesMaster where CarNo<>''

go
update SalesFlags set Name='ãÈíÚÇÊ ÖÑíÈíÉ' where id=11
update SalesFlags set Name='ãÑÏæÏÇÊ ãÈíÚÇÊ ÖÑíÈíÉ' where id=12
