alter table Groups add CashCustPrevent int
go
update Groups set  CashCustPrevent = 0  where CashCustPrevent is null
go