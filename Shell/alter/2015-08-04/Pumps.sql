alter table Tanks add Bal0Size float,Bal0Qty float
alter table Pumps add Bal0 float
go
update Tanks set Bal0Size =0,Bal0Qty=0 where Bal0Qty is null
update Pumps set Bal0 =0 where Bal0 is null
go

