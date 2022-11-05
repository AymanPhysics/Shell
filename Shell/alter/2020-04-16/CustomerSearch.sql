create table CustomerSearch(
CustomerId bigint,
Search nvarchar(100),
MyGetDate datetime not null default getdate(),
MyLine int identity(1,1)
)

go
