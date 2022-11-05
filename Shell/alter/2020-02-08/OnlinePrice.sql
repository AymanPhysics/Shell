alter table groups add IsOnline int not null default 1
alter table Types add IsOnline int not null default 1
alter table Items add IsOnline int not null default 1
alter table Items add OnlinePrice float not null default 0
go
update Items set OnlinePrice =SalesPriceSub
