alter table LiquidationMaster add SaveId3 int,Custody float
go
update LiquidationMaster set SaveId3 =0,Custody =0 where Custody is null
go
