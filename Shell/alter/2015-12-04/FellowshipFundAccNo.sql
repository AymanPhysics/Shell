alter table statics drop column FellowshipFundAccNo 
go
alter table statics add FellowshipFundAccNo nvarchar(100)
go
update statics set FellowshipFundAccNo =''
go
