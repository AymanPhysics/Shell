
select * into TankTypeDetails from 
(
select 1 TankTypeId,* from Tank22500 union
select 2 TankTypeId,* from Tank45000 
)Tbl

go

drop table Tank22500
drop table Tank45000
go

select * from TankTypes
select * from TankTypeDetails