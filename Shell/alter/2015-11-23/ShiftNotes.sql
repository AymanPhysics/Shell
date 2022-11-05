CREATE TABLE ShiftNotes(
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	EmpId int,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
 CONSTRAINT [PK_ShiftNotes] PRIMARY KEY CLUSTERED 
(
	[DayDate] ASC,
	[Shift] ASC,
	EmpId 
))


go
CREATE TABLE Email(Email nvarchar(100))
go
insert Email select 'mr_aymans@yahoo.com'
