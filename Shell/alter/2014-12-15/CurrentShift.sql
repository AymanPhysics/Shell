alter table Stores add CurrentDate datetime, CurrentShift int
go
update Stores set CurrentDate =(select CurrentDate from Statics ),
 CurrentShift =(select CurrentShift from Statics )
