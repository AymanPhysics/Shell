alter table items add Maximum int,MaximumSub int
go
update items set Maximum =Limit,MaximumSub =LimitSub where MaximumSub  is null
go
alter table ItemsPrices add Maximum int
go
update ItemsPrices set Maximum =Limit where Maximum is null
go
