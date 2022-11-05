alter table items add Stopped int
go
update items set Stopped =0
go
alter table items add Weight float,WeightSub float
go
update items set Weight =0,WeightSub =0
go

go
alter table salesdetails add Weight float
go
update salesdetails set Weight =0
go
go
alter table deletedsalesdetails add Weight float
go
update deletedsalesdetails set Weight =0
go


go
alter table salesdetails add TotalWeight float
go
update salesdetails set TotalWeight =0
go
go
alter table deletedsalesdetails add TotalWeight float
go
update deletedsalesdetails set TotalWeight =0
go
